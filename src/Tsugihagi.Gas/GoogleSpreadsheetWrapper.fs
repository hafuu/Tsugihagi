module Tsugihagi.Gas.GoogleSpreadsheetWrapper

open System
open Tsugihagi.Core.Spreadsheet
open TypeDefinitions.Gas.GoogleAppsScript.Spreadsheet

module TsugihagiTypes = Tsugihagi.Core.Spreadsheet

let setHorizontalAlign (align: TsugihagiTypes.HorizontalAlignment) (range: Range) =
    let align =
        match align with
        | TsugihagiTypes.HorizontalAlignment.Left -> RangeSetHorizontalAlignment.Left
        | TsugihagiTypes.HorizontalAlignment.Center -> RangeSetHorizontalAlignment.Center
        | TsugihagiTypes.HorizontalAlignment.Normal -> RangeSetHorizontalAlignment.Normal
        | TsugihagiTypes.HorizontalAlignment.Right -> RangeSetHorizontalAlignment.Right
        | TsugihagiTypes.HorizontalAlignment.Unknown -> RangeSetHorizontalAlignment.Normal
    range.setHorizontalAlignment(align) |> ignore

let setVerticalAlign (align: TsugihagiTypes.VerticalAlignment) (range: Range) =
    let align =
        match align with
        | TsugihagiTypes.VerticalAlignment.Top -> RangeSetVerticalAlignment.Top
        | TsugihagiTypes.VerticalAlignment.Middle -> RangeSetVerticalAlignment.Middle
        | TsugihagiTypes.VerticalAlignment.Bottom -> RangeSetVerticalAlignment.Bottom
        | TsugihagiTypes.VerticalAlignment.Unknown -> RangeSetVerticalAlignment.Middle
    range.setVerticalAlignment(align) |> ignore


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

        member _.GetHorizontalAlignment(): TsugihagiTypes.HorizontalAlignment = 
            match cell.getHorizontalAlignment().ToLower() with
            | "left" -> TsugihagiTypes.HorizontalAlignment.Left
            | "center" -> TsugihagiTypes.HorizontalAlignment.Center
            | "normal" | "general-left" -> TsugihagiTypes.HorizontalAlignment.Normal
            | "right" -> TsugihagiTypes.HorizontalAlignment.Right
            | _ -> TsugihagiTypes.HorizontalAlignment.Unknown
        member _.SetHorizontalAlignment(align: HorizontalAlignment): unit = 
            setHorizontalAlign align cell

        member _.GetVerticalAlignment(): VerticalAlignment = 
            match cell.getVerticalAlignment().ToLower() with
            | "top" -> TsugihagiTypes.VerticalAlignment.Top
            | "middle" -> TsugihagiTypes.VerticalAlignment.Middle
            | "bottom" -> TsugihagiTypes.VerticalAlignment.Bottom
            | _ -> TsugihagiTypes.VerticalAlignment.Unknown
        member _.SetVerticalAlignment(align: VerticalAlignment): unit =
            setVerticalAlign align cell

        member _.GetWrapStrategy(): TsugihagiTypes.WrapStrategy = 
            match cell.getWrapStrategy().ToString().ToLower() with
            | "wrap" -> TsugihagiTypes.WrapStrategy.Wrap
            | "overflow" -> TsugihagiTypes.WrapStrategy.Overflow
            | "clip" ->  TsugihagiTypes.WrapStrategy.Clip
            | _ -> TsugihagiTypes.WrapStrategy.Overflow
        member _.SetWrapStrategy(strategy: TsugihagiTypes.WrapStrategy): unit = 
            let strategy =
                match strategy with
                | TsugihagiTypes.WrapStrategy.Wrap -> WrapStrategy.WRAP
                | TsugihagiTypes.WrapStrategy.Overflow -> WrapStrategy.OVERFLOW
                | TsugihagiTypes.WrapStrategy.Clip -> WrapStrategy.CLIP
            cell.setWrapStrategy(strategy) |> ignore

        member _.WriteProductLink(): unit =
            cell.setFormula("""=HYPERLINK("https://github.com/hafuu/Tsugihagi", engine() & " " & version() & " https://github.com/hafuu/Tsugihagi")""") |> ignore


type RangeWrapper(range: Range) =
    interface IRange with
        member _.SetBorder(?top: bool, ?left: bool, ?bottom: bool, ?right: bool, ?vertical: bool, ?horizontal: bool, ?style: TsugihagiTypes.BorderStyle): unit =
            let gasStyle =
                style
                |> Option.map (function
                    | TsugihagiTypes.Solid -> BorderStyle.SOLID
                    | TsugihagiTypes.Double -> BorderStyle.DOUBLE
                )
                |> Option.defaultValue BorderStyle.SOLID
            range.setBorder(top, left, bottom, right, vertical, horizontal, Some "#000000", Some gasStyle) |> ignore

        member _.SetHorizontalAlignment(align: HorizontalAlignment): unit = 
            setHorizontalAlign align range

type SheetWrapper(sheet: Sheet) =
    interface ISheet with
      member _.GetCell(row: int, column: int): ICell = CellWrapper(sheet.getRange(row, column))
      member _.GetRange(row: int, column: int, numRows: int, numColumns: int) = RangeWrapper(sheet.getRange(row, column, numRows, numColumns))

type SpreadsheetWrapper(spreadsheet: Spreadsheet) =
    interface ISpreadsheet with
      member _.GetActiveSheet(): ISheet = SheetWrapper(spreadsheet.getActiveSheet())
      member _.TryGetSheet(name: string): ISheet option = spreadsheet.getSheetByName(name) |> Option.map (fun s -> SheetWrapper(s))
      member _.InsertSheet(name: string): ISheet = SheetWrapper(spreadsheet.insertSheet(name))

let wrap (app: SpreadsheetApp) = SpreadsheetWrapper(app.getActiveSpreadsheet())
