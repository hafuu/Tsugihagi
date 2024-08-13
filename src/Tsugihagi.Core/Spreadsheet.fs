module rec Tsugihagi.Core.Spreadsheet

type CellData = {
    Value: string
    BackgroundColor: string option
    FontColor: string option
    HorizontalAlignment: HorizontalAlignment
    VerticalAlignment: VerticalAlignment
    WrapStrategy: WrapStrategy
}

type BorderStyle =
    | Solid
    | Double

type HorizontalAlignment =
    | Left
    | Center
    | Normal
    | Right
    | Unknown

type VerticalAlignment =
    | Top
    | Middle
    | Bottom
    | Unknown

type WrapStrategy =
    | Wrap
    | Overflow
    | Clip

type ICell =
    abstract member GetValue: unit -> string option
    abstract member SetValue: value: string option -> unit

    abstract member GetBackgroundColor: unit -> string option
    abstract member SetBackgroundColor: color: string option -> unit

    abstract member GetFontColor: unit -> string option
    abstract member SetFontColor: color: string option -> unit

    abstract member GetHorizontalAlignment: unit -> HorizontalAlignment
    abstract member SetHorizontalAlignment: align: HorizontalAlignment -> unit

    abstract member GetVerticalAlignment: unit -> VerticalAlignment
    abstract member SetVerticalAlignment: align: VerticalAlignment -> unit

    abstract member GetWrapStrategy: unit -> WrapStrategy
    abstract member SetWrapStrategy: strategy: WrapStrategy -> unit

    abstract member WriteProductLink: unit -> unit

type IRange =
    abstract member SetBorder: ?top: bool * ?left: bool * ?bottom: bool * ?right: bool * ?vertical: bool * ?horizontal: bool * ?style: BorderStyle -> unit
    abstract member SetHorizontalAlignment: align: HorizontalAlignment -> unit

type ISheet =
    abstract member GetCell: row: int * column: int -> ICell
    abstract member GetRange: row: int * column: int * numRows: int * numColumns: int -> IRange

type ISpreadsheet =
    abstract member GetActiveSheet: unit -> ISheet
    abstract member TryGetSheet: name: string -> ISheet option
    abstract member InsertSheet: name: string -> ISheet

type ICell with
    member this.GetCellData(): CellData option =
        this.GetValue()
        |> Option.map (fun value -> {
            Value = value
            BackgroundColor = this.GetBackgroundColor()
            FontColor = this.GetFontColor()
            HorizontalAlignment = this.GetHorizontalAlignment()
            VerticalAlignment = this.GetVerticalAlignment()
            WrapStrategy = this.GetWrapStrategy()
        })

    member this.WriteCellData(cellData: CellData): unit =
        this.SetValue(Some cellData.Value)
        this.SetBackgroundColor(cellData.BackgroundColor)
        this.SetFontColor(cellData.FontColor)
        this.SetHorizontalAlignment(cellData.HorizontalAlignment)
        this.SetVerticalAlignment(cellData.VerticalAlignment)
        this.SetWrapStrategy(cellData.WrapStrategy)

type ISheet with
    member this.GetValuesHorizontal(row: int, beginColumn: int): CellData[] =
        let rec read' (column: int) (acc: _ list) =
            let cell = this.GetCell(row, column)
            match cell.GetCellData() with
            | Some value -> read' (column + 1) (value :: acc)
            | None -> acc
        read' beginColumn [] |> List.toArray |> Array.rev

    member this.GetValuesVertical(beginRow: int, column: int): CellData[] =
        let rec read' (row: int) (acc: _ list)=
            let cell = this.GetCell(row, column)
            match cell.GetCellData() with
            | Some value -> read' (row + 1) (value :: acc)
            | None -> acc
        read' beginRow [] |> List.toArray |> Array.rev

    member this.SetValue(row: int, column: int, value: string): unit =
        this.GetCell(row, column).SetValue(Some value)

    member this.WriteCellData(row: int, column: int, cellData: CellData): unit =
        this.GetCell(row, column).WriteCellData(cellData)
