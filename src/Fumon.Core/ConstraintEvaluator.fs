module Fumon.Core.ConstraintEvaluator

open System
open Fumon.Core.Types
open Fumon.Core.Types.ConstraintExpression

let getValue (input: CombinationInput) (combination: Combination) (factor: Factor): Value option =
    match factor with
    | ValueFactor value -> Some value
    | ParameterValueFactor parameterPosition ->
        let index = combination[parameterPosition]
        if index < 0 then
            None
        else
            Some (StringValue (input.ParameterValues[index].Value))

let tryConvertToInt (value: Value): int option =
    match value with
    | IntValue v -> Some v
    | StringValue v ->
        match Int32.TryParse(v) with
        | true, v -> Some v
        | false, _ -> None

let getString = function
    | StringValue v -> v
    | IntValue v -> string v

let inline evalRelationGeneric (left: 'a) (relation: Relation) (right: 'a): bool =
    match relation with
    | Equal -> left = right
    | NotEqual -> left <> right
    | GreaterThan -> left > right
    | GreaterThanOrEqual -> left >= right
    | LessThan -> left < right
    | LessThanOrEqual -> left <= right

let evalStringRelation (left: Value) (relation: Relation) (right: Value): bool =
    let left = getString left
    let right = getString right
    evalRelationGeneric left relation right

let evalRelation (input: CombinationInput) (combination: Combination) (left: Factor) (relation: Relation) (right: Factor): Ternary =
    let left = getValue input combination left
    let right = getValue input combination right
    match left, right with
    | (Some (IntValue _ as left), Some right) | (Some left, Some (IntValue _ as right)) ->
        match tryConvertToInt left, tryConvertToInt right with
        | Some left, Some right -> evalRelationGeneric left relation right |> Ternary.ofBool
        | _, _ -> evalStringRelation left relation right |> Ternary.ofBool
    | (Some left, Some right) -> evalStringRelation left relation right |> Ternary.ofBool
    | (None, _ | _, None) -> Unknown

let evalTerm (input: CombinationInput) (combination: Combination) (term: Term): Ternary =
    match term with
    | RelationTerm (left, relation, right) -> evalRelation input combination left relation right
    | LikeTerm (name, pattern) -> failwith "not implemented"
    | InTerm (factor, values) -> values |> Ternary.Array.exists (fun right -> evalRelation input combination factor Equal right)

let rec evalClause (input: CombinationInput) (combination: Combination) (clause: Clause): Ternary =
    match clause with
    | TermClause term -> evalTerm input combination term
    | ParenPredicateClause predicate -> evalPredicate input combination predicate
    | NotClause clause -> Ternary.not (evalClause input combination clause)

and evalPredicate (input: CombinationInput) (combination: Combination) (predicate: Predicate): Ternary =
    match predicate with
    | ClausePredicate clause -> evalClause input combination clause
    | LogicalOperatorPredicate (left, operator, right) ->
        match operator with
        | And -> evalClause input combination left &&& evalPredicate input combination right
        | Or -> evalClause input combination left ||| evalPredicate input combination right

let evalConstraint (input: CombinationInput) (combination: Combination) (constraint_: Constraint): Ternary =
    match constraint_ with
    | ConditionalConstraint (ifPredicate, thenPredicate, elsePredicate) ->
        match elsePredicate with
        | Some elsePredicate ->
            Ternary.ifThenElse
                (fun () -> evalPredicate input combination ifPredicate)
                (fun () -> evalPredicate input combination thenPredicate)
                (fun () -> evalPredicate input combination elsePredicate)
        | None ->
            Ternary.ifThen
                (fun () -> evalPredicate input combination ifPredicate)
                (fun () -> evalPredicate input combination thenPredicate)
            
    | UnconditionalConstraint predicate -> evalPredicate input combination predicate

let eval (input: CombinationInput) (constraints: Constraints) (combination: Combination): Ternary = constraints |> Ternary.Array.forall (evalConstraint input combination)
