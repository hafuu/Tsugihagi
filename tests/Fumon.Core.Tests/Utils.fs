module Utils

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let v value = {
    Value = value
    BackgroundColor = None
    FontColor = None
    HorizontalAlignment = Normal
    VerticalAlignment = Middle
    WrapStrategy = Overflow
}

let p name values = { Name = name; Values = values }
