module Fumon.Core.Constraints

open System
open Fumon.Core.Types
open Fumon.Core.Types.ConstraintExpression

let getValue (combination: Combination) (factor: Factor) =
    match factor with
    | ValueFactor value -> value
    | NameFactor name -> StringValue (combination[name].Value)

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

let evalRelation (combination: Combination) (left: Factor) (relation: Relation) (right: Factor): bool =
    let left = getValue combination left
    let right = getValue combination right
    match left, right with
    | (IntValue _, _) | (_, IntValue _) ->
        match tryConvertToInt left, tryConvertToInt right with
        | Some left, Some right -> evalRelationGeneric left relation right
        | _, _ -> evalStringRelation left relation right
    | _ -> evalStringRelation left relation right

let evalTerm (combination: Combination) (term: Term): bool =
    match term with
    | RelationTerm (left, relation, right) -> evalRelation combination left relation right
    | LikeTerm (name, pattern) -> failwith "not implemented"
    | InTerm (factor, values) -> values |> Array.exists (fun right -> evalRelation combination factor Equal right)

let rec evalClause (combination: Combination) (clause: Clause): bool =
    match clause with
    | TermClause term -> evalTerm combination term
    | ParenPredicateClause predicate -> evalPredicate combination predicate
    | NotClause clause -> not (evalClause combination clause)

and evalPredicate (combination: Combination) (predicate: Predicate): bool =
    match predicate with
    | ClausePredicate clause -> evalClause combination clause
    | LogicalOperatorPredicate (left, operator, right) ->
        match operator with
        | And -> evalClause combination left && evalPredicate combination right
        | Or -> evalClause combination left || evalPredicate combination right

let evalConstraint(combination: Combination) (constraint_: Constraint): bool =
    match constraint_ with
    | ConditionalConstraint (ifPredicate, thenPredicate, elsePredicate) ->
        if evalPredicate combination ifPredicate then
            evalPredicate combination thenPredicate
        else
            match elsePredicate with
            | Some elsePredicate -> evalPredicate combination elsePredicate
            | None -> true
    | UnconditionalConstraint predicate -> evalPredicate combination predicate

let eval (constraints: Constraints) (combination: Combination): bool = constraints |> Array.forall (evalConstraint combination)
