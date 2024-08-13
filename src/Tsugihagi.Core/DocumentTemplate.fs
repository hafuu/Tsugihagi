module Tsugihagi.Core.DocumentTemplate

open Tsugihagi.Core.Spreadsheet
open Tsugihagi.Core.Configuration

let initializeTemplate (sheet: ISheet) =
    sheet.GetCell(1, 1).WriteProductLink()

    sheet.SetValue(3, 2, "パラメーター")

    sheet.SetValue(4, 2, "p1")
    sheet.SetValue(5, 2, "a")
    sheet.SetValue(6, 2, "b")

    sheet.SetValue(4, 3, "p2")
    sheet.SetValue(5, 3, "c")
    sheet.SetValue(6, 3, "d")
    sheet.SetValue(7, 3, "e")
    sheet.SetValue(8, 3, "f")

    sheet.SetValue(4, 4, "p3")
    sheet.SetValue(5, 4, "g")
    sheet.SetValue(6, 4, "h")
    sheet.SetValue(7, 4, "i")

    sheet.SetValue(4, 5, "p4")
    sheet.SetValue(5, 5, "j")
    sheet.SetValue(6, 5, "k")

    sheet.GetRange(4, 2, 1, 4).SetHorizontalAlignment(HorizontalAlignment.Center)
    sheet.GetRange(4, 2, 5, 4).SetBorder(true, true, true, true, true, true, BorderStyle.Solid)

    sheet.SetValue(10, 2, "制約")
    sheet.SetValue(11, 2, @"if [p1] = ""a"" then [p2] = ""c""")
    sheet.GetRange(10, 2, 2, 7).SetBorder(true, true, true, true, false, true, BorderStyle.Solid)

let initializeConfiguration (sheet: ISheet) =
    let wrap (def: ConfigurationDefinition<_>) = {|
        Headers = def.Headers
        DefaultValues = def.DefaultValues
    |}
    let items = [|
        wrap Items.beginParameterRow
        wrap Items.beginParameterColumn
        wrap Items.parameterThreshold
        wrap Items.parameterHeaders
        wrap Items.marginTopOfTable
        wrap Items.rowNumberHeader
        wrap Items.extraColumns
    |]

    items
    |> Array.iteri (fun index item ->
        let row = index + 1
        sheet.SetValue(row, 1, item.Headers[0])
        item.DefaultValues
        |> Array.iteri (fun valueIndex value ->
            sheet.WriteCellData(row, 2 + valueIndex, value)
        )
    )

let initializeIfNotExists (spreadsheet: ISpreadsheet) init name =
    match spreadsheet.TryGetSheet(name) with
    | Some _ -> ()
    | None ->
        let template = spreadsheet.InsertSheet(name)
        init template

let initialize (spreadsheet: ISpreadsheet): unit =
    initializeIfNotExists spreadsheet initializeTemplate "template"
    initializeIfNotExists spreadsheet initializeConfiguration "設定"
