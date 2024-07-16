module Fumon.Core.TableWriter

open Fumon.Core.Types
open Fumon.Core.Types.Spreadsheet

let writeHeaders (config: Configuration) (context: PreprocessedParameter) (row: int) (beginColumn: int) (sheet: ISheet): unit =
    sheet.GetCell(row, beginColumn - 1).WriteCellData(config.RowNumberHeader)

    context.Parameters
    |> Array.iteri (fun index definition ->
        let column = beginColumn + index
        sheet.GetCell(row, column).WriteCellData(definition.Name)
    )

    let beginExtraColumn = beginColumn + context.Parameters.Length
    config.ExtraColumns
    |> Array.iteri (fun columnOffset extraColumn ->
        sheet.GetCell(row, beginExtraColumn + columnOffset).WriteCellData(extraColumn)
    )

let writeStyleOnly (cell: ICell) (cellData: CellData): unit =
    cell.WriteCellData({ cellData with Value = null })

let writeTable (context: PreprocessedParameter) (table: Combination seq) (beginRow: int) (beginColumn: int) (sheet: ISheet): int =
    let mutable numRows = 0
    table
    |> Seq.iteri (fun rowOffset combination ->
        let rowNo = rowOffset + 1
        let row = beginRow + rowOffset

        sheet.GetCell(row, beginColumn - 1).SetValue(Some (string rowNo))

        combination
        |> Array.iteri (fun columnOffset valuePosition ->
            let column = beginColumn + columnOffset
            sheet.GetCell(row, column).WriteCellData(context.ParameterValues[valuePosition])
        )

        numRows <- rowNo
    )
    numRows

let writeBorder (config: Configuration) (beginRow: int) (beginColumn: int) (numRows: int) (numColumns: int) (sheet: ISheet): unit =
    let numColumns = numColumns + 1 + config.ExtraColumns.Length
    sheet.GetRange(beginRow, beginColumn - 1, numRows + 1, numColumns).SetBorder(true, true, true, true, true, true, BorderStyle.Solid)
    sheet.GetRange(beginRow, beginColumn - 1, 1, numColumns).SetBorder(bottom = true, style = BorderStyle.Double)

let write (config: Configuration) (context: PreprocessedParameter) (table: Combination seq) (beginRow: int) (sheet: ISheet): unit =
    let beginColumn = config.BeginParameterColumn
    writeHeaders config context beginRow beginColumn sheet
    let numRows = writeTable context table (beginRow + 1) beginColumn sheet
    writeBorder config beginRow beginColumn numRows context.Parameters.Length sheet
