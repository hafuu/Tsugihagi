module Tsugihagi.Core.DocumentTemplate

open Tsugihagi.Core.Types
open Tsugihagi.Core.Types.Spreadsheet

let initializeTemplate' (sheet: ISheet) =
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

let initializeTemplate (spreadsheet: ISpreadsheet) =
    let name = "template"
    match spreadsheet.TryGetSheet(name) with
    | Some _ -> ()
    | None ->
        let template = spreadsheet.InsertSheet(name)
        initializeTemplate' template

let initialize (spreadsheet: ISpreadsheet): unit =
    initializeTemplate spreadsheet
