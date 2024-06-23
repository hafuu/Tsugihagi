module Fumon.Gas.GoogleSpreadsheetWrapper

open System
open Fumon.Core.Types.Spreadsheet
open TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet

type CellWrapper(cell: Range) =
    interface ICell with
      member _.GetValue(): string option = 
        cell.getValue()
        |> Option.bind (fun v ->
            let value = string v
            if String.IsNullOrWhiteSpace(value) then
                None
            else
                Some value
        )
      member _.SetValue(value: string option): unit =
        cell.setValue(value |> Option.map box) |> ignore

type RangeWrapper(range: Range) =
    interface IRange with
        member _.SetBorder(?top: bool, ?left: bool, ?bottom: bool, ?right: bool, ?vertical: bool, ?horizontal: bool, ?style: Fumon.Core.Types.Spreadsheet.BorderStyle): unit =
            let gasStyle =
                style
                |> Option.map (function
                    | Solid -> TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet.BorderStyle.SOLID
                    | Double -> TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet.BorderStyle.DOUBLE
                )
                |> Option.defaultValue TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet.BorderStyle.SOLID
            range.setBorder(top, left, bottom, right, vertical, horizontal, Some "#000000", Some gasStyle) |> ignore

type SheetWrapper(sheet: Sheet) =
    interface ISheet with
      member _.GetCell(row: int, column: int): ICell = CellWrapper(sheet.getRange(row, column))
      member _.GetRange(row: int, column: int, numRows: int, numColumns: int) = RangeWrapper(sheet.getRange(row, column, numRows, numColumns))

type SpreadsheetWrapper(spreadsheet: Spreadsheet) =
    interface ISpreadsheet with
      member _.GetActiveSheet(): ISheet = SheetWrapper(spreadsheet.getActiveSheet())

let wrap (app: SpreadsheetApp) = SpreadsheetWrapper(app.getActiveSpreadsheet())
