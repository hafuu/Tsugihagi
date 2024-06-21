module Fumon.Core.Document

open Fumon.Core.Types.Spreadsheet

let generate (spreadsheet: ISpreadsheet): unit =
    let sheet = spreadsheet.GetActiveSheet()
    let parameters = ParameterReader.read 3 2 sheet
    let table = DecisionTable.create parameters
    DecisionTableWriter.write parameters table 10 2 sheet
