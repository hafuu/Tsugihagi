module Tsugihagi.Core.Types

open Tsugihagi.Core.Spreadsheet

type Configuration = {
    BeginParameterRow: int
    BeginParameterColumn: int
    ParameterThreshold: int
    ParameterHeaders: string[]
    RowNumberHeader: CellData
    ExtraColumns: CellData[]
}

type ParameterDefinition = {
  Name: CellData
  Values: CellData[]
}

/// 処理の効率化のために前処理されたパラメーターです
/// p1: a, b
/// p2: c, d, e, f
/// p3: g, h, i
/// p4: j, k
/// というパラメーターを例にすると、各値は下記のようになります。
/// NumberParameters = 4
/// NumberParameterValues = 11
/// ParameterValues =    [| a; b; c; e; d; f; g; h; i; j; k |]
/// ParameterPositions = [| 0; 0; 1; 1; 1; 1; 2; 2; 2; 3; 3 |]
/// LegalValues = [|
///     [| 0; 1 |];
///     [| 2; 3; 4; 5 |];
///     [| 6: 7: 8 |];
///     [| 9; 10 |];
/// |]
/// 
type CombinationInput = {
    /// 処理前のパラメーター
    Parameters: ParameterDefinition[]
    /// パラメーターの数
    NumberParameters: int
    /// 値の数の合計
    NumberParameterValues: int
    /// すべての値の一次元の配列
    ParameterValues: CellData[]
    /// 値からパラメーターを逆引きできるテーブル
    ParameterPositions: int[]
    LegalValues: int[][]
}

type Combination = int[]

module rec ConstraintExpression =
    type Constraints = Constraint[]

    type Constraint =
        | ConditionalConstraint of ifPredicate: Predicate * thenPredicate: Predicate * elsePredicate: Predicate option
        | UnconditionalConstraint of Predicate

    type Predicate =
        | ClausePredicate of Clause
        | LogicalOperatorPredicate of Clause * LogicalOperator * Predicate

    type Clause =
        | TermClause of Term
        | ParenPredicateClause of Predicate
        | NotClause of Clause

    type Term =
        | RelationTerm of Factor * Relation * Factor
        | LikeTerm of name: string * pattern: string
        | InTerm of Factor * Factor[]

    type Factor =
        | ParameterValueFactor of parameterPosition: int
        | ValueFactor of Value

    type LogicalOperator =
        | And
        | Or

    type Relation =
        | Equal
        | NotEqual
        | GreaterThan
        | GreaterThanOrEqual
        | LessThan
        | LessThanOrEqual

    type Value =
        | StringValue of string
        | IntValue of int

type Constraints = ConstraintExpression.Constraints

type IRandom =
    abstract Next: minValue: int * maxValue: int -> int

type GenerateCombinations = (Combination -> Ternary) option -> CombinationInput -> Combination seq
