module ConstraintParserTest

open NUnit.Framework
open FsUnitTyped

open Tsugihagi.Core
open Tsugihagi.Core.ConstraintParser
open Tsugihagi.Core.Types
open Tsugihagi.Core.Types.ConstraintExpression
open Utils


let parameters = [|
    p (v "hoge") [| v "a"; v "b" |]
    p (v "piyo") [| v "c"; v "d" |]
|]
let input = ParameterReader.preprocess parameters
let intValue n = ValueFactor(IntValue(n))
let name n =
    let position = input.Parameters |> Array.findIndex (fun p -> p.Name.Value = n)
    ParameterValueFactor(position)

let parse = build input

let parseCases =
    [
        (["[hoge]"; "="; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", Equal,intValue 30))))|])
        (["30"; "="; "[hoge]"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(intValue 30, Equal, name "hoge"))))|])
        (["[hoge]"; "="; "\"piyo\""], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", Equal, ValueFactor(StringValue "piyo")))))|])
        (["[hoge]"; "="; "'piyo'"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", Equal, ValueFactor(StringValue "piyo")))))|])

        (["[hoge]"; "="; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", Equal, intValue 30))))|])
        (["[hoge]"; "<>"; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", NotEqual, intValue 30))))|])
        (["[hoge]"; ">"; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", GreaterThan, intValue 30))))|])
        (["[hoge]"; ">="; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", GreaterThanOrEqual, intValue 30))))|])
        (["[hoge]"; "<"; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", LessThan, intValue 30))))|])
        (["[hoge]"; "<="; "30"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", LessThanOrEqual, intValue 30))))|])

        (["[hoge]"; "="; "[piyo]"], [|UnconditionalConstraint(ClausePredicate(TermClause(RelationTerm(name "hoge", Equal, name "piyo"))))|])
        (["[hoge]"; "in"; "{"; "1"; ","; "2"; "}"], [|UnconditionalConstraint(ClausePredicate(TermClause(InTerm(name "hoge", [| intValue 1; intValue 2 |]))))|])
        (["[hoge]"; "IN"; "{"; "[piyo]" ;"}"], [|UnconditionalConstraint(ClausePredicate(TermClause(InTerm(name "hoge", [|name "piyo"|]))))|])


        (["not"; "[hoge]"; "="; "30"], [|UnconditionalConstraint(ClausePredicate(NotClause(TermClause(RelationTerm(name "hoge", Equal, intValue 30)))))|])
        (["NOT"; "[hoge]"; "="; "30"], [|UnconditionalConstraint(ClausePredicate(NotClause(TermClause(RelationTerm(name "hoge", Equal, intValue 30)))))|])

        (["("; "[hoge]"; "="; "30"; ")"], [|UnconditionalConstraint(ClausePredicate(ParenPredicateClause(ClausePredicate(TermClause(RelationTerm(name "hoge", Equal, intValue 30))))))|])

        (["1"; "="; "1"; "AND"; "2"; "<>"; "3"], [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                    And,
                    ClausePredicate(TermClause(RelationTerm(intValue 2, NotEqual, intValue 3)))
                )
            )
        |])
        (["1"; "="; "1"; "and"; "2"; "<>"; "3"], [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                    And,
                    ClausePredicate(TermClause(RelationTerm(intValue 2, NotEqual, intValue 3)))
                )
            )
        |])
        (["1"; "="; "1"; "OR"; "2"; "<>"; "3"], [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                    Or,
                    ClausePredicate(TermClause(RelationTerm(intValue 2, NotEqual, intValue 3)))
                )
            )
        |])
        (["1"; "="; "1"; "or"; "2"; "<>"; "3"], [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                    Or,
                    ClausePredicate(TermClause(RelationTerm(intValue 2, NotEqual, intValue 3)))
                )
            )
        |])

        (["IF"; "30"; "="; "30"; "THEN"; "20"; "<>"; "20"], [|
            ConditionalConstraint(
                ClausePredicate(TermClause(RelationTerm(intValue 30, Equal,intValue 30))),
                ClausePredicate(TermClause(RelationTerm(intValue 20, NotEqual,intValue 20))),
                None
            )
        |])
        (["if"; "30"; "="; "30"; "then"; "20"; "<>"; "20"; "else"; "40"; "="; "40"], [|
            ConditionalConstraint(
                ClausePredicate(TermClause(RelationTerm(intValue 30, Equal,intValue 30))),
                ClausePredicate(TermClause(RelationTerm(intValue 20, NotEqual,intValue 20))),
                Some(ClausePredicate(TermClause(RelationTerm(intValue 40, Equal,intValue 40))))
            )
        |])
        
    ]
    |> List.map (fun (str, expected) -> TestCaseData(str, expected))

[<TestCaseSource(nameof(parseCases))>]
let ``制約をパースできる``(input: string list, expected: Constraints) =
    let str = String.concat "" input
    let actual = parse str
    actual |> shouldEqual expected

[<TestCaseSource(nameof(parseCases))>]
let ``空白ありの制約をパースできる``(input: string list, expected: Constraints) =
    let spaces = "  "
    let str = spaces + String.concat spaces input + spaces
    let actual = parse str
    actual |> shouldEqual expected


let complexCases =
    [
        ("1 = 1 or 2 = 2 and 2 <> 3", [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                    Or,
                    LogicalOperatorPredicate(
                        TermClause(RelationTerm(intValue 2, Equal, intValue 2)),
                        And,
                        ClausePredicate(TermClause(RelationTerm(intValue 2, NotEqual, intValue 3)))
                    )
                )
            )
        |])

        ("not 1 = 1 or 2 = 2", [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    NotClause(
                        TermClause(RelationTerm(intValue 1, Equal, intValue 1))
                    ),
                    Or,
                    ClausePredicate(TermClause(RelationTerm(intValue 2, Equal, intValue 2)))
                )
            )
        |])

        ("1 = 1 or not 2 = 2", [|
            UnconditionalConstraint(
                LogicalOperatorPredicate(
                    TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                    Or,
                    ClausePredicate(NotClause(TermClause(RelationTerm(intValue 2, Equal, intValue 2))))
                )
            )
        |])

        ("not (1 = 1 or 2 = 2)", [|
            UnconditionalConstraint(
                ClausePredicate(
                    NotClause(
                        ParenPredicateClause(
                            LogicalOperatorPredicate(
                                TermClause(RelationTerm(intValue 1, Equal, intValue 1)),
                                Or,
                                ClausePredicate(TermClause(RelationTerm(intValue 2, Equal, intValue 2)))
                            )
                        )
                    )
                )
            )
        |])
    ]
    |> List.map (fun (str, expected) -> TestCaseData(str, expected))

[<TestCaseSource(nameof(complexCases))>]
let ``複雑な制約をパースできる``(str: string, expected: Constraints) =
    let actual = parse str
    actual |> shouldEqual expected
