module Fumon.Core.Types

module rec Spreadsheet =
    type BorderStyle =
        | Solid
        | Double

    type HorizontalAlignment =
        | Left
        | Center
        | Normal
        | Right
        | Unknown

    type VerticalAlignment =
        | Top
        | Middle
        | Bottom
        | Unknown

    type WrapStrategy =
        | Wrap
        | Overflow
        | Clip

    type ICell =
        abstract member GetValue: unit -> string option
        abstract member SetValue: value: string option -> unit

        abstract member GetBackgroundColor: unit -> string option
        abstract member SetBackgroundColor: color: string option -> unit

        abstract member GetFontColor: unit -> string option
        abstract member SetFontColor: color: string option -> unit

        abstract member GetHorizontalAlignment: unit -> HorizontalAlignment
        abstract member SetHorizontalAlignment: align: HorizontalAlignment -> unit

        abstract member GetVerticalAlignment: unit -> VerticalAlignment
        abstract member SetVerticalAlignment: align: VerticalAlignment -> unit

        abstract member GetWrapStrategy: unit -> WrapStrategy
        abstract member SetWrapStrategy: strategy: WrapStrategy -> unit

    type IRange =
        abstract member SetBorder: ?top: bool * ?left: bool * ?bottom: bool * ?right: bool * ?vertical: bool * ?horizontal: bool * ?style: BorderStyle -> unit

    type ISheet =
        abstract member GetCell: row: int * column: int -> ICell
        abstract member GetRange: row: int * column: int * numRows: int * numColumns: int -> IRange

    type ISpreadsheet =
        abstract member GetActiveSheet: unit -> ISheet

open Spreadsheet

type CellData = {
    Value: string
    BackgroundColor: string option
    FontColor: string option
    HorizontalAlignment: HorizontalAlignment
    VerticalAlignment: VerticalAlignment
    WrapStrategy: WrapStrategy
}

type ParameterDefinition = {
  Name: CellData
  Values: CellData[]
}

type Combination = Map<string, CellData>
