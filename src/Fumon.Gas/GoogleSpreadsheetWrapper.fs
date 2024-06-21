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

type SheetWrapper(sheet: Sheet) =
    interface ISheet with
      member _.GetCell(row: int, column: int): ICell = CellWrapper(sheet.getRange(row, column))

type SpreadsheetWrapper(spreadsheet: Spreadsheet) =
    interface ISpreadsheet with
      member _.GetActiveSheet(): ISheet = SheetWrapper(spreadsheet.getActiveSheet())

let wrap (app: SpreadsheetApp) = SpreadsheetWrapper(app.getActiveSpreadsheet())
