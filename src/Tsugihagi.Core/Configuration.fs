module Tsugihagi.Core.Configuration

open Tsugihagi.Core.Spreadsheet
open Tsugihagi.Core.Types
open System.Collections.Generic

type ConfigurationDefinition<'a> = {
    Convert: CellData[] -> 'a
    Headers: string[]
    DefaultValues: CellData[]
}

let readValue def (configDict: Dictionary<string, CellData[]>) =
    def.Headers
    |> Array.tryPick (fun key ->
        match configDict.TryGetValue(key) with
        | true, value ->
            try
                Some (def.Convert value)
            with
                _ -> None
        | false, _ -> None
    )
    |> Option.defaultValue (def.DefaultValues |> def.Convert)

module Items =
    let private cell value = {
        Value = value
        BackgroundColor = None
        FontColor = None
        HorizontalAlignment = HorizontalAlignment.Unknown
        VerticalAlignment = VerticalAlignment.Unknown
        WrapStrategy = Overflow
    }

    let beginParameterRow = {
        Convert = fun values -> values[0].Value |> int
        Headers = [| "パラメーター開始行" |]
        DefaultValues = [| cell (string 1) |]
    }

    let beginParameterColumn = {
        Convert = fun values -> values[0].Value |> int
        Headers = [| "パラメーター開始列" |]
        DefaultValues = [| cell (string 2) |]
    }

    let parameterThreshold = {
        Convert = fun values -> values[0].Value |> int
        Headers = [| "パラメーター探索閾値" |]
        DefaultValues = [| cell (string 30) |]
    }

    let parameterHeaders = {
        Convert = fun values -> values |> Array.map _.Value
        Headers = [| "パラメーター判定文字列" |]
        DefaultValues = [| cell "パラメーター"; cell "パラメータ" |]
    }

    let rowNumberHeader = {
        Convert = fun values -> values[0]
        Headers = [| "行番号ヘッダー"; "行番号ヘッダ" |]
        DefaultValues = [|
            {
                Value = "No."
                BackgroundColor = None
                FontColor = None
                HorizontalAlignment = Center
                VerticalAlignment = Middle
                WrapStrategy = Overflow
            }
        |]
    }

    let extraColumns = {
        Convert = id
        Headers = [| "追加カラム" |]
        DefaultValues = [|
            {
                Value = "結果"
                BackgroundColor = None
                FontColor = None
                HorizontalAlignment = Center
                VerticalAlignment = Middle
                WrapStrategy = Overflow
            }
            {
                Value = "備考"
                BackgroundColor = None
                FontColor = None
                HorizontalAlignment = Center
                VerticalAlignment = Middle
                WrapStrategy = Overflow
            }
        |]
    }

let readConfig configDict = {
    BeginParameterRow = readValue Items.beginParameterRow configDict
    BeginParameterColumn = readValue Items.beginParameterColumn configDict
    ParameterThreshold = readValue Items.parameterThreshold configDict
    ParameterHeaders = readValue Items.parameterHeaders configDict
    RowNumberHeader = readValue Items.rowNumberHeader configDict
    ExtraColumns = readValue Items.extraColumns configDict
}

let defaultConfig = readConfig (Dictionary())

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

    readConfig configDict
