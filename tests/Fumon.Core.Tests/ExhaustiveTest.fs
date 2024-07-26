module DecisionTableTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Utils

[<Test>]
let ``デシジョンテーブルを作成できる``() =
    let parameters = [|
        p (v "p1") [| v "a"; v "b"; v "c" |]
        p (v "p2") [| v "1"; v "2" |]
        p (v "p3") [| v "あ" |]
    |]
    let input = ParameterReader.preprocess parameters
    let c parameter value = findValuePosition input parameter value
    
    let actual = Exhaustive.generate None input |> Seq.toArray

    let createRow v1 v2 v3 = [| c "p1" v1; c "p2" v2; c"p3" v3 |]
    
    let expected = [|
        createRow "a" "1" "あ"
        createRow "a" "2" "あ"
        createRow "b" "1" "あ"
        createRow "b" "2" "あ"
        createRow "c" "1" "あ"
        createRow "c" "2" "あ"
    |]

    actual |> shouldEqual expected
