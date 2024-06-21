module Fumon.Core.Document

open Fumon.Core.Types.Spreadsheet

let generate (spreadsheet: ISpreadsheet): unit =
    let sheet = spreadsheet.GetActiveSheet()
    let parameters, parameterEndRow = ParameterReader.read 2 sheet
    let table = DecisionTable.create parameters
    DecisionTableWriter.write parameters table (parameterEndRow + 2) 2 sheet
