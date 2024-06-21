module Program

open Fable.Core
open Fumon.Core
open TypeDefinitions.Gas
open Fumon.Gas

let generateDecisionTable() =
    let sheet = SpreadsheetApp.getActiveSheet()
    let parameters = ParameterReader.read 3 2 sheet
    let table = DecisionTable.create parameters
    DecisionTableWriter.write parameters table 10 2 sheet
    
type GlobalExports = {
    mutable generateDecisionTable: unit -> unit
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.generateDecisionTable <- generateDecisionTable
