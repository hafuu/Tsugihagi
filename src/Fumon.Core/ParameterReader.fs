module Fumon.Core.ParameterReader

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let rec findParameterHeaderIndex (row: int) (column: int) (sheet: ISheet): int =
    let cell = sheet.GetCell(row, column)
    match cell.GetValue() with
    | Some value when string value = "パラメータ" -> row
    | Some _ | None -> findParameterHeaderIndex (row + 1) (column) sheet

let readParameterValues (startRow: int) (column: int) (sheet: ISheet): string[] =
    let rec read' (row: int) (acc: _ list)=
        let cell = sheet.GetCell(row, column)
        match cell.GetValue() with
        | Some value -> read' (row + 1) (value :: acc)
        | None -> acc
    read' startRow [] |> List.toArray |> Array.rev

let read (headerRow: int) (startColumn: int) (sheet: ISheet): ParameterDefinition[] =
    let startRow = headerRow + 1
    let rec read' (column: int) (acc: _ list)=
        let cell = sheet.GetCell(startRow, column)
        match cell.GetValue() with
        | Some name ->
            let values = readParameterValues (startRow + 1) column sheet
            let definition = { Name = name; Values = values }
            read' (column + 1) (definition :: acc)
        | None -> acc
    read' startColumn [] |> List.toArray |> Array.rev
