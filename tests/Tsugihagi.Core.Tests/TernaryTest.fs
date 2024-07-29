module TernaryTest

open NUnit.Framework
open FsUnitTyped

open Tsugihagi.Core

let andTestCases =
    [
        (True,    True,    True)
        (True,    False,   False)
        (True,    Unknown, Unknown)
        (False,   True,    False)
        (False,   False,   False)
        (False,   Unknown, False)
        (Unknown, True,    Unknown)
        (Unknown, False,   False)
        (Unknown, Unknown, Unknown)
    ]
    |> List.map (fun (x, y, expected) -> TestCaseData(x, y, expected))

[<TestCaseSource(nameof(andTestCases))>]
let test_and(x: Ternary, y: Ternary, expected) =
    (x &&& y) |> shouldEqual expected

let orTestCases =
    [
        (True,    True,    True)
        (True,    False,   True)
        (True,    Unknown, True)
        (False,   True,    True)
        (False,   False,   False)
        (False,   Unknown, Unknown)
        (Unknown, True,    True)
        (Unknown, False,   Unknown)
        (Unknown, Unknown, Unknown)
    ]
    |> List.map (fun (x, y, expected) -> TestCaseData(x, y, expected))

[<TestCaseSource(nameof(orTestCases))>]
let test_or(x: Ternary, y: Ternary, expected) =
    (x ||| y) |> shouldEqual expected

let ifThenTestCases =
    [
        (True,    True,    True)
        (True,    False,   False)
        (True,    Unknown, Unknown)
        (False,   True,    True)
        (False,   False,   True)
        (False,   Unknown, True)
        (Unknown, True,    True)
        (Unknown, False,   Unknown)
        (Unknown, Unknown, Unknown)
    ]
    |> List.map (fun (if', then', expected) -> TestCaseData(if', then', expected))

[<TestCaseSource(nameof(ifThenTestCases))>]
let test_ifThen(if': Ternary, then': Ternary, expected) =
    (Ternary.ifThen (fun () -> if') (fun () -> then')) |> shouldEqual expected

let ifThenElseTestCases =
    [
        (True,    True,    True,    True)
        (True,    True,    False,   True)
        (True,    True,    Unknown, True)
        (True,    False,   True,    False)
        (True,    False,   False,   False)
        (True,    False,   Unknown, False)
        (True,    Unknown, True,    Unknown)
        (True,    Unknown, False,   Unknown)
        (True,    Unknown, Unknown, Unknown)
        (False,   True,    True,    True)
        (False,   True,    False,   False)
        (False,   True,    Unknown, Unknown)
        (False,   False,   True,    True)
        (False,   False,   False,   False)
        (False,   False,   Unknown, Unknown)
        (False,   Unknown, True,    True)
        (False,   Unknown, False,   False)
        (False,   Unknown, Unknown, Unknown)
        (Unknown, True,    True,    True)
        (Unknown, True,    False,   Unknown)
        (Unknown, True,    Unknown, Unknown)
        (Unknown, False,   True,    Unknown)
        (Unknown, False,   False,   Unknown)
        (Unknown, False,   Unknown, Unknown)
        (Unknown, Unknown, True,    Unknown)
        (Unknown, Unknown, False,   Unknown)
        (Unknown, Unknown, Unknown, Unknown)
    ]
    |> List.map (fun (if', then', else', expected) -> TestCaseData(if', then', else', expected))

[<TestCaseSource(nameof(ifThenElseTestCases))>]
let test_ifThenElse(if': Ternary, then': Ternary, else': Ternary, expected) =
    (Ternary.ifThenElse (fun () -> if') (fun () -> then') (fun () -> else')) |> shouldEqual expected

let existsTestCases =
    [
        ([||], False)
        
        ([| True |], True)
        ([| False |], False)
        ([| Unknown |], Unknown)

        ([| True; True |], True)
        ([| True; False |], True)
        ([| False; True |], True)
        ([| False; False |], False)
        
        ([| False; Unknown |], Unknown)
        ([| Unknown; False |], Unknown)
        ([| True; Unknown |], True)
        ([| Unknown; True |], True)
    ]
    |> List.map (fun (xs, expected) -> TestCaseData(xs, expected))

[<TestCaseSource(nameof(existsTestCases))>]
let test_exists(xs, expected) =
    Ternary.Array.exists id xs |> shouldEqual expected

let forallTestCases =
    [
        ([||], True)
        ([| True |], True)
        ([| False |], False)
        ([| Unknown |], Unknown)

        ([| True; True |], True)
        ([| True; False |], False)
        ([| False; True |], False)
        ([| False; False |], False)
        
        
        ([| False; Unknown |], False)
        ([| Unknown; False |], False)
        ([| True; Unknown |], Unknown)
        ([| Unknown; True |], Unknown)
    ]
    |> List.map (fun (xs, expected) -> TestCaseData(xs, expected))

[<TestCaseSource(nameof(forallTestCases))>]
let test_forall(xs, expected) =
    Ternary.Array.forall id xs |> shouldEqual expected
