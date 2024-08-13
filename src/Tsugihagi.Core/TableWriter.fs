module Tsugihagi.Core.TableWriter

open Tsugihagi.Core.Spreadsheet
open Tsugihagi.Core.Types

let writeHeaders (config: Configuration) (input: CombinationInput) (row: int) (beginColumn: int) (sheet: ISheet): unit =
    sheet.GetCell(row, beginColumn - 1).WriteCellData(config.RowNumberHeader)

    input.Parameters
    |> Array.iteri (fun index definition ->
        let column = beginColumn + index
        sheet.GetCell(row, column).WriteCellData(definition.Name)
    )

    let beginExtraColumn = beginColumn + input.Parameters.Length
    config.ExtraColumns
    |> Array.iteri (fun columnOffset extraColumn ->
        sheet.GetCell(row, beginExtraColumn + columnOffset).WriteCellData(extraColumn)
    )

let writeStyleOnly (cell: ICell) (cellData: CellData): unit =
    cell.WriteCellData({ cellData with Value = null })

let writeTable (input: CombinationInput) (table: Combination seq) (beginRow: int) (beginColumn: int) (sheet: ISheet): int =
    let mutable numRows = 0
    table
    |> Seq.iteri (fun rowOffset combination ->
        let rowNo = rowOffset + 1
        let row = beginRow + rowOffset

        sheet.GetCell(row, beginColumn - 1).SetValue(Some (string rowNo))

        combination
        |> Array.iteri (fun columnOffset valuePosition ->
            let column = beginColumn + columnOffset
            sheet.GetCell(row, column).WriteCellData(input.ParameterValues[valuePosition])
        )

        numRows <- rowNo
    )
    numRows

let writeBorder (config: Configuration) (beginRow: int) (beginColumn: int) (numRows: int) (numColumns: int) (sheet: ISheet): unit =
    let numColumns = numColumns + 1 + config.ExtraColumns.Length
    sheet.GetRange(beginRow, beginColumn - 1, numRows + 1, numColumns).SetBorder(true, true, true, true, true, true, BorderStyle.Solid)
    sheet.GetRange(beginRow, beginColumn - 1, 1, numColumns).SetBorder(bottom = true, style = BorderStyle.Double)

let write (config: Configuration) (input: CombinationInput) (table: Combination seq) (beginRow: int) (sheet: ISheet): unit =
    let beginColumn = config.BeginParameterColumn
    writeHeaders config input beginRow beginColumn sheet
    let numRows = writeTable input table (beginRow + 1) beginColumn sheet
    writeBorder config beginRow beginColumn numRows input.Parameters.Length sheet
