module Program

open Fable.Core
open Fumon.Core
open TypeDefinitions.Gas

let x() =
    DecisionTable.create [|
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
    |> Seq.length
    |> string

let testGas() =
    let spreadSheet = SpreadsheetApp.getActive()
    let sheet = spreadSheet.getActiveSheet()
    $"{spreadSheet.getName()}の{sheet.getName()}です"


[<Emit("new Date($0, $1, $2)")>]
let createDate (year: int) (month: int) (day): GoogleAppsScript.Base.Date = jsNative

let testDate() =
    let d = createDate 2024 6 20
    d.ToString()
    

type GlobalExports = {
    mutable x: unit -> string
    mutable testGas: unit -> string
    mutable testDate: unit -> string
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.x <- x
``global``.testGas <- testGas
``global``.testDate <- testDate
