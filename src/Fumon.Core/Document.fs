module Fumon.Core.Document

open Fumon.Core.Types.Spreadsheet

let generate (spreadsheet: ISpreadsheet): unit =
    let config =
        spreadsheet.TryGetSheet("設定")
        |> Option.map Configuration.read
        |> Option.defaultValue Configuration.defaultConfig
    let sheet = spreadsheet.GetActiveSheet()
    let parameters, parameterEndRow = ParameterReader.readParameters config sheet
    let constraints, constraintsEndRow = ParameterReader.readConstraints config (parameterEndRow + 1) sheet
    let constraintPredicate =
        if Array.isEmpty constraints then
            None
        else
            Some (ConstraintEvaluator.eval constraints)
    let table = Exhaustive.create constraintPredicate parameters
    TableWriter.write config parameters table (constraintsEndRow + 2) sheet
