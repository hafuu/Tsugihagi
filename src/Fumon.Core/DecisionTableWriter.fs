module Fumon.Core.DecisionTableWriter

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let writeHeaders (parameters: ParameterDefinition[]) (row: int) (startColumn: int) (sheet: ISheet) =
    parameters
    |> Array.iteri (fun index definition ->
        let column = startColumn + index
        let cell = sheet.GetCell(row, column)
        cell.SetValue(Some (definition.Name)) |> ignore
    )

let writeTable (parameters: ParameterDefinition[]) (table: Combination seq) (startRow: int) (startColumn: int) (sheet: ISheet): unit =
    table
    |> Seq.iteri (fun rowOffset combination ->
        let row = startRow + rowOffset
        parameters
        |> Array.iteri (fun columnOffset parameter ->
            let column = startColumn + columnOffset
            let value = combination |> Map.find parameter.Name
            let cell = sheet.GetCell(row, column)
            cell.SetValue(Some value) |> ignore
        )
    )

let write (parameters: ParameterDefinition[]) (table: Combination seq) (startRow: int) (startColumn: int) (sheet: ISheet): unit =
    writeHeaders parameters startRow startColumn sheet
    writeTable parameters table (startRow + 1) startColumn sheet
