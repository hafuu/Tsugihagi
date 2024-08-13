module Tsugihagi.Core.Document

open Tsugihagi.Core.Spreadsheet
open Tsugihagi.Core.Types

let generate (generate: GenerateCombinations) (spreadsheet: ISpreadsheet): unit =
    let config =
        spreadsheet.TryGetSheet("設定")
        |> Option.map Configuration.read
        |> Option.defaultValue Configuration.defaultConfig
    let sheet = spreadsheet.GetActiveSheet()
    let parameters, parameterEndRow = ParameterReader.readParameters config sheet
    let input = ParameterReader.preprocess parameters
    let constraints, constraintsEndRow = ParameterReader.readConstraints config input (parameterEndRow + 1) sheet
    let constraintPredicate =
        if Array.isEmpty constraints then
            None
        else
            Some (ConstraintEvaluator.eval input constraints)
    let table = generate constraintPredicate input
    TableWriter.write config input table (constraintsEndRow + config.MarginTopOfTable) sheet
