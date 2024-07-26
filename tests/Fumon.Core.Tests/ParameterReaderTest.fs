module ParameterReaderTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Fumon.Core.Types

open Utils

[<Test>]
let ``前処理できる``() =
    let parameters = [|
        p (v "p1") [| v "a"; v "b" |]
        p (v "p2") [| v "c"; v "d"; v "e"; v "f" |]
        p (v "p3") [| v "g"; v "h"; v "i" |]
        p (v "p4") [| v "j"; v "k" |]
    |]

    let input = ParameterReader.preprocess parameters

    input.NumberParameters |> shouldEqual 4
    input.NumberParameterValues |> shouldEqual 11

    input.ParameterValues |> shouldEqual ([| "a"; "b"; "c"; "d"; "e"; "f"; "g"; "h"; "i"; "j"; "k" |] |> Array.map v)
    input.LegalValues |> shouldEqual [|
        [| 0; 1 |]
        [| 2; 3; 4; 5 |]
        [| 6; 7; 8 |]
        [| 9; 10 |]
    |]
