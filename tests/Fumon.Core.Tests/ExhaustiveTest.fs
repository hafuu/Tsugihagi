module DecisionTableTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Fumon.Core.Types
open Utils

[<Test>]
let ``デシジョンテーブルを作成できる``() =
    let parameters: ParameterDefinition[] = [|
        p (v "p1") [| v "a"; v "b"; v "c" |]
        p (v "p2") [| v "1"; v "2" |]
        p (v "p3") [| v "あ" |]
    |]
    
    let actual = Exhaustive.create None parameters |> Seq.toArray

    let createRow v1 v2 v3 = Map.ofList [("p1", v v1); ("p2", v v2); ("p3", v v3)]
    
    let expected = [|
        createRow "a" "1" "あ"
        createRow "a" "2" "あ"
        createRow "b" "1" "あ"
        createRow "b" "2" "あ"
        createRow "c" "1" "あ"
        createRow "c" "2" "あ"
    |]

    actual |> shouldEqual expected
