module Fumon.Core.TableWriter

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let writeHeaders (parameters: ParameterDefinition[]) (row: int) (startColumn: int) (sheet: ISheet): unit =
    sheet.GetCell(row, startColumn - 1).SetValue(Some "No.")

    parameters
    |> Array.iteri (fun index definition ->
        let column = startColumn + index
        let cell = sheet.GetCell(row, column)
        cell.SetValue(Some (definition.Name))
    )

    sheet.GetCell(row, startColumn + parameters.Length).SetValue(Some "備考")

let writeTable (parameters: ParameterDefinition[]) (table: Combination seq) (beginRow: int) (beginColumn: int) (sheet: ISheet): int =
    let mutable numRows = 0
    table
    |> Seq.iteri (fun rowOffset combination ->
        let rowNo = rowOffset + 1
        let row = beginRow + rowOffset

        sheet.GetCell(row, beginColumn - 1).SetValue(Some (string rowNo))

        parameters
        |> Array.iteri (fun columnOffset parameter ->
            let column = beginColumn + columnOffset
            let value = combination |> Map.find parameter.Name
            let cell = sheet.GetCell(row, column)
            cell.SetValue(Some value)
        )

        numRows <- rowNo
    )
    numRows

let writeBorder (beginRow: int) (beginColumn: int) (numRows: int) (numColumns: int) (sheet: ISheet): unit =
    sheet.GetRange(beginRow, beginColumn - 1, numRows + 1, numColumns + 2).SetBorder(true, true, true, true, true, true, BorderStyle.Solid)
    sheet.GetRange(beginRow, beginColumn - 1, 1, numColumns + 2).SetBorder(bottom = true, style = BorderStyle.Double)

let write (parameters: ParameterDefinition[]) (table: Combination seq) (beginRow: int) (beginColumn: int) (sheet: ISheet): unit =
    writeHeaders parameters beginRow beginColumn sheet
    let numRows = writeTable parameters table (beginRow + 1) beginColumn sheet
    writeBorder beginRow beginColumn numRows parameters.Length sheet
