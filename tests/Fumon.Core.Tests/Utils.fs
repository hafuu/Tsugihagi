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

let findValuePosition context parameter value =
    context.ParameterValues
    |> Array.indexed
    |> Array.find (fun (index, parameterValue) ->
        let parameterPosition = context.ParameterPositions[index]
        context.Parameters[parameterPosition].Name.Value = parameter && parameterValue.Value = value
    )
    |> fst

let p name values = { Name = name; Values = values }
