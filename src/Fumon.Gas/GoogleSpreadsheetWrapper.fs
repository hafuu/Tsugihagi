module Fumon.Gas.GoogleSpreadsheetWrapper

open System
open Fumon.Core.Types.Spreadsheet
open TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet

module FumonTypes = Fumon.Core.Types.Spreadsheet

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

        member _.GetBackgroundColor(): string option = 
            let color = cell.getBackground()
            if String.IsNullOrWhiteSpace(color) then
                None
            else
                Some color
        member _.SetBackgroundColor(color: string option): unit = 
            cell.setBackground(color) |> ignore

        member _.GetFontColor(): string option =
            match cell.getFontColorObject() with
            | null -> None
            | color -> Some (color.asRgbColor().asHexString())
            
        member _.SetFontColor(color: string option): unit =
            cell.setFontColor(color) |> ignore

        member _.GetHorizontalAlignment(): FumonTypes.HorizontalAlignment = 
            match cell.getHorizontalAlignment().ToLower() with
            | "left" -> FumonTypes.HorizontalAlignment.Left
            | "center" -> FumonTypes.HorizontalAlignment.Center
            | "normal" | "general-left" -> FumonTypes.HorizontalAlignment.Normal
            | "right" -> FumonTypes.HorizontalAlignment.Right
            | _ -> FumonTypes.HorizontalAlignment.Unknown
        member _.SetHorizontalAlignment(align: HorizontalAlignment): unit = 
            let align =
                match align with
                | FumonTypes.HorizontalAlignment.Left -> RangeSetHorizontalAlignment.Left
                | FumonTypes.HorizontalAlignment.Center -> RangeSetHorizontalAlignment.Center
                | FumonTypes.HorizontalAlignment.Normal -> RangeSetHorizontalAlignment.Normal
                | FumonTypes.HorizontalAlignment.Right -> RangeSetHorizontalAlignment.Right
                | FumonTypes.HorizontalAlignment.Unknown -> RangeSetHorizontalAlignment.Normal
            cell.setHorizontalAlignment(align) |> ignore

        member _.GetVerticalAlignment(): VerticalAlignment = 
            match cell.getVerticalAlignment().ToLower() with
            | "top" -> FumonTypes.VerticalAlignment.Top
            | "middle" -> FumonTypes.VerticalAlignment.Middle
            | "bottom" -> FumonTypes.VerticalAlignment.Bottom
            | _ -> FumonTypes.VerticalAlignment.Unknown
        member _.SetVerticalAlignment(align: VerticalAlignment): unit =
            let align =
                match align with
                | FumonTypes.VerticalAlignment.Top -> RangeSetVerticalAlignment.Top
                | FumonTypes.VerticalAlignment.Middle -> RangeSetVerticalAlignment.Middle
                | FumonTypes.VerticalAlignment.Bottom -> RangeSetVerticalAlignment.Bottom
                | FumonTypes.VerticalAlignment.Unknown -> RangeSetVerticalAlignment.Middle
            cell.setVerticalAlignment(align) |> ignore

        member _.GetWrapStrategy(): FumonTypes.WrapStrategy = 
            match cell.getWrapStrategy().ToString().ToLower() with
            | "wrap" -> FumonTypes.WrapStrategy.Wrap
            | "overflow" -> FumonTypes.WrapStrategy.Overflow
            | "clip" ->  FumonTypes.WrapStrategy.Clip
            | _ -> FumonTypes.WrapStrategy.Overflow
        member _.SetWrapStrategy(strategy: FumonTypes.WrapStrategy): unit = 
            let strategy =
                match strategy with
                | FumonTypes.WrapStrategy.Wrap -> WrapStrategy.WRAP
                | FumonTypes.WrapStrategy.Overflow -> WrapStrategy.OVERFLOW
                | FumonTypes.WrapStrategy.Clip -> WrapStrategy.CLIP
            cell.setWrapStrategy(strategy) |> ignore


type RangeWrapper(range: Range) =
    interface IRange with
        member _.SetBorder(?top: bool, ?left: bool, ?bottom: bool, ?right: bool, ?vertical: bool, ?horizontal: bool, ?style: FumonTypes.BorderStyle): unit =
            let gasStyle =
                style
                |> Option.map (function
                    | FumonTypes.Solid -> BorderStyle.SOLID
                    | FumonTypes.Double -> BorderStyle.DOUBLE
                )
                |> Option.defaultValue BorderStyle.SOLID
            range.setBorder(top, left, bottom, right, vertical, horizontal, Some "#000000", Some gasStyle) |> ignore

type SheetWrapper(sheet: Sheet) =
    interface ISheet with
      member _.GetCell(row: int, column: int): ICell = CellWrapper(sheet.getRange(row, column))
      member _.GetRange(row: int, column: int, numRows: int, numColumns: int) = RangeWrapper(sheet.getRange(row, column, numRows, numColumns))

type SpreadsheetWrapper(spreadsheet: Spreadsheet) =
    interface ISpreadsheet with
      member _.GetActiveSheet(): ISheet = SheetWrapper(spreadsheet.getActiveSheet())
      member _.TryGetSheet(name: string): ISheet option = spreadsheet.getSheetByName(name) |> Option.map (fun s -> SheetWrapper(s))

let wrap (app: SpreadsheetApp) = SpreadsheetWrapper(app.getActiveSpreadsheet())
