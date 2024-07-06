module ConstraintsTest

open NUnit.Framework
open FsUnitTyped

open System
open Fumon.Core.ConstraintParser
open Fumon.Core.Constraints

open Utils

let testCases =
    [
        ("1=1", true)
        ("1=2", false)

        ("1<>2", true)
        ("1<>1", false)
        
        ("1>0", true)
        ("1>2", false)
        
        ("1>=0", true)
        ("1>=1", true)
        ("1>=2", false)

        ("1<2", true)
        ("1<1", false)

        ("1<=2", true)
        ("1<=1", true)
        ("1<=0", false)

        ("'a'='a'", true)
        ("'a'='b'", false)

        ("'a'<>'b'", true)
        ("'a'<>'a'", false)

        ("'b'>'a'", true)
        ("'b'>'b'", false)

        ("'b'>='a'", true)
        ("'b'>='b'", true)
        ("'b'>='c'", false)

        ("'b'<'c'", true)
        ("'b'<'b'", false)

        ("'b'<='c'", true)
        ("'b'<='b'", true)
        ("'b'<='a'", false)

        ("[number] = 100", true)
        ("[number] = 200", false)
        ("[str] = 100", false)
        ("[str] <> 100", true)

        ("'100円' > 100", true)
        ("'100円' > 101", false)

        ("1 in {0, 1, 2}", true)
        ("3 in {0, 1, 2}", false)

        ("not 1 = 1", false)
        ("not 1 <> 1", true)

        ("(1 = 1)", true)
        ("(1 <> 1)", false)

        ("1 = 1 and 2 = 2", true)
        ("1 = 1 and 2 <> 2", false)

        ("1 = 1 or 2 = 2", true)
        ("1 <> 1 or 2 = 2", true)
        ("1 <> 1 or 2 <> 2", false)

        ("if 1 = 1 then 2 = 2", true)
        ("if 1 = 1 then 2 <> 2", false)
        ("if 1 <> 1 then 2 <> 2", true)

        ("if 1 = 1 then 2 = 2 else 3 <> 3", true)
        ("if 1 = 1 then 2 <> 2 else 3 = 3", false)
        ("if 1 <> 1 then 2 <> 2 else 3 = 3", true)
        ("if 1 <> 1 then 2 = 2 else 3 <> 3", false)
    ]
    |> List.map (fun (str, expected) -> TestCaseData(str, expected))

[<TestCaseSource(nameof(testCases))>]
let ``制約を評価できる``(str: string, expected: bool) =
    let constraints = parse str
    let combination = Map.ofList [
        ("number", v "100")
        ("str", v "bbb")
    ]

    eval constraints combination |> shouldEqual expected
