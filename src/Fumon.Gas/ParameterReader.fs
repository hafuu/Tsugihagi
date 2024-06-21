module Fumon.Gas.ParameterReader

open System
open TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet
open Fumon.Core.DecisionTable

let getStringValue (cell: Range): string option =
    cell.getValue()
    |> Option.bind (fun v ->
        let value = string v
        if String.IsNullOrWhiteSpace(value) then
            None
        else
            Some value
    )

let rec findParameterHeaderIndex (row: int) (column: int) (sheet: Sheet): int =
    let cell = sheet.getRange(row, column)
    match cell.getValue() with
    | Some value when string value = "パラメータ" -> row
    | Some _ | None -> findParameterHeaderIndex (row + 1) (column) sheet

let readParameterValues (startRow: int) (column: int) (sheet: Sheet): string[] =
    let rec loop (row: int) (acc: _ list)=
        let cell = sheet.getRange(row, column)
        match getStringValue cell with
        | Some value -> loop (row + 1) (value :: acc)
        | None -> acc
    loop startRow [] |> List.toArray |> Array.rev

let read (headerRow: int) (startColumn: int) (sheet: Sheet): ParameterDefinition[] =
    let startRow = headerRow + 1
    let rec loop (column: int) (acc: _ list)=
        let cell = sheet.getRange(startRow, column)
        match getStringValue cell with
        | Some name ->
            let values = readParameterValues (startRow + 1) column sheet
            let definition = { Name = name; Values = values }
            loop (column + 1) (definition :: acc)
        | None -> acc
    loop startColumn [] |> List.toArray |> Array.rev
