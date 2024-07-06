module Fumon.Core.ParameterReader

open System
open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let rec findIndex header threshold (beginRow: int) (column: int) (sheet: ISheet): int option =
    let thresholdRow = beginRow + threshold
    let rec find' row =
        let cell = sheet.GetCell(row, column)
        match cell.GetValue() with
        | Some value when string value = header -> Some row
        | Some _ | None ->
            if row < thresholdRow then
                find' (row + 1)
            else
                None
    find' beginRow

let readParameters (config: Configuration) (sheet: ISheet): ParameterDefinition[] * int =
    let beginColumn = config.BeginParameterColumn
    let headerRow = findIndex "パラメーター" config.ParameterThreshold config.BeginParameterRow beginColumn sheet
    let beginRow = headerRow.Value + 1
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

let readConstraints (config: Configuration) (beginRow: int) (sheet: ISheet): Constraints * int =
    let column = config.BeginParameterColumn
    let headerRow = findIndex "制約" config.ParameterThreshold beginRow column sheet
    match headerRow with
    | None -> [||], beginRow
    | Some headerRow ->
        let mutable endRow = headerRow
        let result = ResizeArray()
        let rec read' row =
            match sheet.GetCell(row, column).GetValue() with
            | Some constraintStr ->
                let constraints = ConstraintParser.parse constraintStr
                result.AddRange(constraints)
                endRow <- row
                read' (row + 1)
            | None -> ()
        read' (headerRow + 1)
        result.ToArray(), endRow
