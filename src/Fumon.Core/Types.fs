module Fumon.Core.Types

module rec Spreadsheet =
    type ICell =
        abstract member GetValue: unit -> string option
        abstract member SetValue: value: string option -> unit

    type ISheet =
        abstract member GetCell: row: int * column: int -> ICell

    type ISpreadsheet =
        abstract member GetActiveSheet: unit -> ISheet


type ParameterDefinition = {
  Name: string
  Values: string[]
}

type Combination = Map<string, string>
