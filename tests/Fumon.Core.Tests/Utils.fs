module Utils

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let v (value: string): CellData = {
    Value = value
    BackgroundColor = None
    FontColor = None
    HorizontalAlignment = Normal
    VerticalAlignment = Middle
    WrapStrategy = Overflow
}
