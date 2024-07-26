module ConstraintEvaluatorTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Fumon.Core.ConstraintParser
open Fumon.Core.ConstraintEvaluator

open Utils

let testCases =
    [
        ("1=1", True)
        ("1=2", False)

        ("1<>2", True)
        ("1<>1", False)
        
        ("1>0", True)
        ("1>2", False)
        
        ("1>=0", True)
        ("1>=1", True)
        ("1>=2", False)

        ("1<2", True)
        ("1<1", False)

        ("1<=2", True)
        ("1<=1", True)
        ("1<=0", False)

        ("'a'='a'", True)
        ("'a'='b'", False)

        ("'a'<>'b'", True)
        ("'a'<>'a'", False)

        ("'b'>'a'", True)
        ("'b'>'b'", False)

        ("'b'>='a'", True)
        ("'b'>='b'", True)
        ("'b'>='c'", False)

        ("'b'<'c'", True)
        ("'b'<'b'", False)

        ("'b'<='c'", True)
        ("'b'<='b'", True)
        ("'b'<='a'", False)

        ("[number] = 100", True)
        ("[number] = 200", False)
        ("[str] = 100", False)
        ("[str] <> 100", True)

        ("'100円' > 100", True)
        ("'100円' > 101", False)

        ("1 in {0, 1, 2}", True)
        ("3 in {0, 1, 2}", False)

        ("not 1 = 1", False)
        ("not 1 <> 1", True)

        ("(1 = 1)", True)
        ("(1 <> 1)", False)

        ("1 = 1 and 2 = 2", True)
        ("1 = 1 and 2 <> 2", False)

        ("1 = 1 or 2 = 2", True)
        ("1 <> 1 or 2 = 2", True)
        ("1 <> 1 or 2 <> 2", False)

        ("if 1 = 1 then 2 = 2", True)
        ("if 1 = 1 then 2 <> 2", False)
        ("if 1 <> 1 then 2 <> 2", True)

        ("if 1 = 1 then 2 = 2 else 3 <> 3", True)
        ("if 1 = 1 then 2 <> 2 else 3 = 3", False)
        ("if 1 <> 1 then 2 <> 2 else 3 = 3", True)
        ("if 1 <> 1 then 2 = 2 else 3 <> 3", False)

        ("[unknown] = 100", Unknown)
        ("not [unknown] = 100", Unknown)
        ("if 1 = 1 then [unknown] = 100", Unknown)
        ("if [unknown] = 100 then 1 = 1", True)
    ]
    |> List.map (fun (str, expected) -> TestCaseData(str, expected))

[<TestCaseSource(nameof(testCases))>]
let ``制約を評価できる``(str, expected) =
    let parameters = [|
        p (v "number") [| v "100" |]
        p (v "str") [| v "bbb" |]
        p (v "unknown") [| v "unknown" |]
    |]
    let input = ParameterReader.preprocess parameters
    let parse = build input
    let constraints = parse str
    let c parameter value = findValuePosition input parameter value
    let combination = [|
        c "number" "100"
        c "str" "bbb"
        -1
    |]

    eval input constraints combination |> shouldEqual expected
