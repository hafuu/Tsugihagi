module Fumon.Core.ConstraintEvaluator

open System
open Fumon.Core.Types
open Fumon.Core.Types.ConstraintExpression

let getValue (context: PreprocessedParameter) (combination: Combination) (factor: Factor) =
    match factor with
    | ValueFactor value -> value
    | ParameterValueFactor parameterPosition -> StringValue (context.ParameterValues[combination[parameterPosition]].Value)

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

let evalRelation (context: PreprocessedParameter) (combination: Combination) (left: Factor) (relation: Relation) (right: Factor): bool =
    let left = getValue context combination left
    let right = getValue context combination right
    match left, right with
    | (IntValue _, _) | (_, IntValue _) ->
        match tryConvertToInt left, tryConvertToInt right with
        | Some left, Some right -> evalRelationGeneric left relation right
        | _, _ -> evalStringRelation left relation right
    | _ -> evalStringRelation left relation right

let evalTerm (context: PreprocessedParameter) (combination: Combination) (term: Term): bool =
    match term with
    | RelationTerm (left, relation, right) -> evalRelation context combination left relation right
    | LikeTerm (name, pattern) -> failwith "not implemented"
    | InTerm (factor, values) -> values |> Array.exists (fun right -> evalRelation context combination factor Equal right)

let rec evalClause (context: PreprocessedParameter) (combination: Combination) (clause: Clause): bool =
    match clause with
    | TermClause term -> evalTerm context combination term
    | ParenPredicateClause predicate -> evalPredicate context combination predicate
    | NotClause clause -> not (evalClause context combination clause)

and evalPredicate (context: PreprocessedParameter) (combination: Combination) (predicate: Predicate): bool =
    match predicate with
    | ClausePredicate clause -> evalClause context combination clause
    | LogicalOperatorPredicate (left, operator, right) ->
        match operator with
        | And -> evalClause context combination left && evalPredicate context combination right
        | Or -> evalClause context combination left || evalPredicate context combination right

let evalConstraint (context: PreprocessedParameter) (combination: Combination) (constraint_: Constraint): bool =
    match constraint_ with
    | ConditionalConstraint (ifPredicate, thenPredicate, elsePredicate) ->
        if evalPredicate context combination ifPredicate then
            evalPredicate context combination thenPredicate
        else
            match elsePredicate with
            | Some elsePredicate -> evalPredicate context combination elsePredicate
            | None -> true
    | UnconditionalConstraint predicate -> evalPredicate context combination predicate

let eval (context: PreprocessedParameter) (constraints: Constraints) (combination: Combination): bool = constraints |> Array.forall (evalConstraint context combination)
