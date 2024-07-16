module Fumon.Core.Document

open Fumon.Core.Types.Spreadsheet

let generate (spreadsheet: ISpreadsheet): unit =
    let config =
        spreadsheet.TryGetSheet("設定")
        |> Option.map Configuration.read
        |> Option.defaultValue Configuration.defaultConfig
    let sheet = spreadsheet.GetActiveSheet()
    let parameters, parameterEndRow = ParameterReader.readParameters config sheet
    let context = ParameterReader.preprocess parameters
    let constraints, constraintsEndRow = ParameterReader.readConstraints config context (parameterEndRow + 1) sheet
    let constraintPredicate =
        if Array.isEmpty constraints then
            None
        else
            Some (ConstraintEvaluator.eval context constraints)
    let table = Exhaustive.create constraintPredicate context
    TableWriter.write config context table (constraintsEndRow + 2) sheet
