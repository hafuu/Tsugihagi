module Tsugihagi.Core.Configuration

open Tsugihagi.Core.Spreadsheet
open Tsugihagi.Core.Types
open System.Collections.Generic

let defaultConfig = {
    BeginParameterRow = 1
    BeginParameterColumn = 2
    ParameterThreshold = 30
    ParameterHeaders = [| "パラメーター"; "パラメータ" |]
    RowNumberHeader = {
        Value = "No."
        BackgroundColor = None
        FontColor = None
        HorizontalAlignment = Normal
        VerticalAlignment = Bottom
        WrapStrategy = Overflow
    }
    ExtraColumns = [||]
}

let read (sheet: ISheet): Configuration =
    let configDict = Dictionary<string, CellData[]>()
    let rec read' row: unit =
        match sheet.GetCell(row, 1).GetCellData() with
        | Some key ->
            configDict[key.Value] <- sheet.GetValuesHorizontal(row, 2)
            read' (row + 1)
        | None ->
            if row > 50 then
                read' 50
            else
                ()
    do read' 1

    let tryRead key convert defaultValue =
        try
            convert configDict[key]
        with
            _ -> defaultValue

    {
        BeginParameterRow =
            tryRead
                "パラメーター開始行"
                (fun values -> values[0].Value |> int)
                defaultConfig.BeginParameterRow
        BeginParameterColumn =
            tryRead
                "パラメーター開始列"
                (fun values -> values[0].Value |> int)
                defaultConfig.BeginParameterColumn
        ParameterThreshold =
            tryRead
                "パラメーター探索閾値"
                (fun values -> values[0].Value |> int)
                defaultConfig.ParameterThreshold
        ParameterHeaders =
            tryRead
                "パラメーター判定文字列"
                (fun values -> values |> Array.map _.Value)
                defaultConfig.ParameterHeaders
        RowNumberHeader =
            tryRead
                "行番号ヘッダ"
                (fun values -> values[0])
                defaultConfig.RowNumberHeader
        ExtraColumns =
            tryRead
                "追加カラム"
                id
                defaultConfig.ExtraColumns
    }
