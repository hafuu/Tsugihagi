module Fumon.Core.TableWriter

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let writeHeaders (parameters: ParameterDefinition[]) (row: int) (startColumn: int) (sheet: ISheet) =
    parameters
    |> Array.iteri (fun index definition ->
        let column = startColumn + index
        let cell = sheet.GetCell(row, column)
        cell.SetValue(Some (definition.Name))
    )

let writeTable (parameters: ParameterDefinition[]) (table: Combination seq) (beginRow: int) (beginColumn: int) (sheet: ISheet): unit =
    table
    |> Seq.iteri (fun rowOffset combination ->
        let row = beginRow + rowOffset
        parameters
        |> Array.iteri (fun columnOffset parameter ->
            let column = beginColumn + columnOffset
            let value = combination |> Map.find parameter.Name
            let cell = sheet.GetCell(row, column)
            cell.SetValue(Some value)
        )
    )

let write (parameters: ParameterDefinition[]) (table: Combination seq) (beginRow: int) (beginColumn: int) (sheet: ISheet): unit =
    writeHeaders parameters beginRow beginColumn sheet
    writeTable parameters table (beginRow + 1) beginColumn sheet
