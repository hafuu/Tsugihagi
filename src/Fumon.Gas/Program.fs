module Fumon.Gas.Program

open Fable.Core
open Fumon.Core
open TypeDefinitions.Gas
open System

let generateDecisionTable() =
    SpreadsheetApp
    |> GoogleSpreadsheetWrapper.wrap
    |> Document.generate
    
type GlobalExports = {
    mutable generateDecisionTable: unit -> unit
    mutable engine: unit -> string
    mutable version: unit -> string
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.generateDecisionTable <- generateDecisionTable
``global``.engine <- fun () -> AssemblyVersionInformation.AssemblyProduct
``global``.version <- fun () -> AssemblyVersionInformation.AssemblyVersion
