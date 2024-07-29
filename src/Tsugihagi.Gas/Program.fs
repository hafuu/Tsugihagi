module Tsugihagi.Gas.Program

open Fable.Core
open Fable.Core.JsInterop
open Tsugihagi.Core
open Tsugihagi.Core.Types
open TypeDefinitions.Gas
open System

let jsRandom =
    { new IRandom with
        member _.Next(minValue: int, maxValue: int): int = emitJsExpr (minValue, maxValue) "Math.floor(Math.random() * ($1 - $0) + $0)"
    }

let generateTable() =
    SpreadsheetApp
    |> GoogleSpreadsheetWrapper.wrap
    |> Document.generate Exhaustive.generate

let generatePairwiseTable() =
    SpreadsheetApp
    |> GoogleSpreadsheetWrapper.wrap
    |> Document.generate (Pairwise.generate jsRandom)
    
type GlobalExports = {
    mutable generateTable: unit -> unit
    mutable generatePairwiseTable: unit -> unit
    mutable engine: unit -> string
    mutable version: unit -> string
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.generateTable <- generateTable
``global``.generatePairwiseTable <- generatePairwiseTable
``global``.engine <- fun () -> AssemblyVersionInformation.AssemblyProduct
``global``.version <- fun () -> AssemblyVersionInformation.AssemblyVersion
