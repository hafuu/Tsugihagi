module Fumon.Gas.DecisionTableWriter

open System
open TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet
open Fumon.Core.DecisionTable

let writeHeaders (parameters: ParameterDefinition[]) (row: int) (startColumn: int) (sheet: Sheet) =
    parameters
    |> Array.iteri (fun index definition ->
        let column = startColumn + index
        let cell = sheet.getRange(row, column)
        cell.setValue(Some (definition.Name)) |> ignore
    )

let writeTable (parameters: ParameterDefinition[]) (table: Row seq) (startRow: int) (startColumn: int) (sheet: Sheet): unit =
    table
    |> Seq.iteri (fun rowOffset line ->
        let row = startRow + rowOffset
        parameters
        |> Array.iteri (fun columnOffset parameter ->
            let column = startColumn + columnOffset
            let value = line |> Map.find parameter.Name
            let cell = sheet.getRange(row, column)
            cell.setValue(Some value) |> ignore
        )
    )

let write (parameters: ParameterDefinition[]) (table: Row seq) (startRow: int) (startColumn: int) (sheet: Sheet): unit =
    writeHeaders parameters startRow startColumn sheet
    writeTable parameters table (startRow + 1) startColumn sheet
