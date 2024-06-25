module Fumon.Core.Types

module rec Spreadsheet =
    type BorderStyle =
        | Solid
        | Double

    type ICell =
        abstract member GetValue: unit -> string option
        abstract member SetValue: value: string option -> unit
        abstract member GetBackgroundColor: unit -> string option
        abstract member SetBackgroundColor: color: string option -> unit

    type IRange =
        abstract member SetBorder: ?top: bool * ?left: bool * ?bottom: bool * ?right: bool * ?vertical: bool * ?horizontal: bool * ?style: BorderStyle -> unit

    type ISheet =
        abstract member GetCell: row: int * column: int -> ICell
        abstract member GetRange: row: int * column: int * numRows: int * numColumns: int -> IRange

    type ISpreadsheet =
        abstract member GetActiveSheet: unit -> ISheet


type CellData = {
    BackgroundColor: string option
    Value: string
}

type ParameterDefinition = {
  Name: CellData
  Values: CellData[]
}

type Combination = Map<string, CellData>
