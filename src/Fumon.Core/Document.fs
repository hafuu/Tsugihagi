module Fumon.Core.Document

open Fumon.Core.Types.Spreadsheet

let generate (spreadsheet: ISpreadsheet): unit =
    let config =
        spreadsheet.TryGetSheet("設定")
        |> Option.map Configuration.read
        |> Option.defaultValue Configuration.defaultConfig
    let sheet = spreadsheet.GetActiveSheet()
    let parameters, parameterEndRow = ParameterReader.read config sheet
    let table = Exhaustive.create parameters
    TableWriter.write config parameters table (parameterEndRow + 2) sheet
