module Fumon.Core.ParameterReader

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let rec findParameterHeaderIndex (row: int) (column: int) (sheet: ISheet): int =
    let cell = sheet.GetCell(row, column)
    match cell.GetValue() with
    | Some value when string value = "パラメーター" -> row
    | Some _ | None -> findParameterHeaderIndex (row + 1) (column) sheet

let read (config: Configuration) (sheet: ISheet): ParameterDefinition[] * int =
    let beginColumn = config.BeginParameterColumn
    let beginRow = findParameterHeaderIndex config.BeginParameterRow beginColumn sheet + 1
    let rec read' (column: int) (acc: _ list)=
        let cell = sheet.GetCell(beginRow, column)
        match cell.GetCellData() with
        | Some name ->
            let values = sheet.GetValuesVertical(beginRow + 1, column)
            let definition = { Name = name; Values = values }
            read' (column + 1) (definition :: acc)
        | None -> acc
    let parameters = read' beginColumn [] |> List.toArray |> Array.rev
    let endRow = beginRow + (parameters |> Seq.map _.Values.Length |> Seq.max)
    parameters, endRow
