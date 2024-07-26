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

let findValuePosition input parameter value =
    input.ParameterValues
    |> Array.indexed
    |> Array.find (fun (index, parameterValue) ->
        let parameterPosition = input.ParameterPositions[index]
        input.Parameters[parameterPosition].Name.Value = parameter && parameterValue.Value = value
    )
    |> fst

let p name values = { Name = name; Values = values }
