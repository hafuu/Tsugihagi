module Fumon.Gas.Program

open Fable.Core
open Fumon.Core
open TypeDefinitions.Gas

let generateDecisionTable() =
    SpreadsheetApp
    |> GoogleSpreadsheetWrapper.wrap
    |> Document.generate
    
type GlobalExports = {
    mutable generateDecisionTable: unit -> unit
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.generateDecisionTable <- generateDecisionTable
