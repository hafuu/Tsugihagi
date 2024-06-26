module DecisionTableTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let v (value: string): CellData = {
    Value = value
    BackgroundColor = None
    FontColor = None
    HorizontalAlignment = Normal
    VerticalAlignment = Middle
    WrapStrategy = Overflow
}

[<Test>]
let ``デシジョンテーブルを作成できる``() =
    let parameters: ParameterDefinition[] = [|
        {
            Name = v "p1"
            Values = [| v "a"; v "b"; v "c" |]
        }
        {
            Name = v "p2"
            Values = [| v "1"; v "2" |]
        }
        {
            Name = v "p3"
            Values = [| v "あ"; |]
        }
    |]
    
    let actual = Exhaustive.create parameters |> Seq.toArray

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
