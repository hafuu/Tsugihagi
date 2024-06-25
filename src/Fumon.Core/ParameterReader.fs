module Fumon.Core.ParameterReader

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let readCellData (cell: ICell): CellData option =
    cell.GetValue()
    |> Option.map (fun value -> {
        Value = value
        BackgroundColor = cell.GetBackgroundColor()
    })

let rec findParameterHeaderIndex (row: int) (column: int) (sheet: ISheet): int =
    let cell = sheet.GetCell(row, column)
    match cell.GetValue() with
    | Some value when string value = "パラメーター" -> row
    | Some _ | None -> findParameterHeaderIndex (row + 1) (column) sheet

let readParameterValues (beginRow: int) (column: int) (sheet: ISheet): CellData[] =
    let rec read' (row: int) (acc: _ list)=
        let cell = sheet.GetCell(row, column)
        match readCellData cell with
        | Some value -> read' (row + 1) (value :: acc)
        | None -> acc
    read' beginRow [] |> List.toArray |> Array.rev

let read (beginColumn: int) (sheet: ISheet): ParameterDefinition[] * int =
    let beginRow = findParameterHeaderIndex 1 beginColumn sheet + 1
    let rec read' (column: int) (acc: _ list)=
        let cell = sheet.GetCell(beginRow, column)
        match readCellData cell with
        | Some name ->
            let values = readParameterValues (beginRow + 1) column sheet
            let definition = { Name = name; Values = values }
            read' (column + 1) (definition :: acc)
        | None -> acc
    let parameters = read' beginColumn [] |> List.toArray |> Array.rev
    let endRow = beginRow + (parameters |> Seq.map _.Values.Length |> Seq.max)
    parameters, endRow
