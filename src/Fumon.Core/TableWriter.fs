module Fumon.Core.TableWriter

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let writeCellData (cellData: CellData) (cell: ICell): unit =
    cell.SetValue(Some cellData.Value)
    cell.SetBackgroundColor(cellData.BackgroundColor)
    cell.SetFontColor(cellData.FontColor)
    cell.SetHorizontalAlignment(cellData.HorizontalAlignment)
    cell.SetVerticalAlignment(cellData.VerticalAlignment)
    cell.SetWrapStrategy(cellData.WrapStrategy)

let writeHeaders (parameters: ParameterDefinition[]) (row: int) (startColumn: int) (sheet: ISheet): unit =
    sheet.GetCell(row, startColumn - 1).SetValue(Some "No.")

    parameters
    |> Array.iteri (fun index definition ->
        let column = startColumn + index
        let cell = sheet.GetCell(row, column)
        let name = definition.Name
        writeCellData name cell
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
            let parameterValue = combination |> Map.find parameter.Name.Value
            let cell = sheet.GetCell(row, column)
            writeCellData parameterValue cell
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
