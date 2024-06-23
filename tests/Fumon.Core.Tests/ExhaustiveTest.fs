module DecisionTableTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Fumon.Core.Types

[<Test>]
let ``デシジョンテーブルを作成できる``() =
    let parameters: ParameterDefinition[] = [|
        {
            Name = "p1"
            Values = [| "a"; "b"; "c" |]
        }
        {
            Name = "p2"
            Values = [| "1"; "2" |]
        }
        {
            Name = "p3"
            Values = [| "あ"; |]
        }
    |]
    
    let actual = Exhaustive.create parameters |> Seq.toArray

    let createRow v1 v2 v3 = Map.ofList [("p1", v1); ("p2", v2); ("p3", v3)]
    
    let expected = [|
        createRow "a" "1" "あ"
        createRow "a" "2" "あ"
        createRow "b" "1" "あ"
        createRow "b" "2" "あ"
        createRow "c" "1" "あ"
        createRow "c" "2" "あ"
    |]

    actual |> shouldEqual expected
