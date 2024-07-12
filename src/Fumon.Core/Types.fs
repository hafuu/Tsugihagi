module Fumon.Core.Types

module rec Spreadsheet =
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

    type IRange =
        abstract member SetBorder: ?top: bool * ?left: bool * ?bottom: bool * ?right: bool * ?vertical: bool * ?horizontal: bool * ?style: BorderStyle -> unit

    type ISheet =
        abstract member GetCell: row: int * column: int -> ICell
        abstract member GetRange: row: int * column: int * numRows: int * numColumns: int -> IRange

    type ISpreadsheet =
        abstract member GetActiveSheet: unit -> ISheet
        abstract member TryGetSheet: name: string -> ISheet option

open Spreadsheet

type CellData = {
    Value: string
    BackgroundColor: string option
    FontColor: string option
    HorizontalAlignment: HorizontalAlignment
    VerticalAlignment: VerticalAlignment
    WrapStrategy: WrapStrategy
}

type Configuration = {
    BeginParameterRow: int
    BeginParameterColumn: int
    ParameterThreshold: int
    ParameterHeaders: string[]
    RowNumberHeader: CellData
    ExtraColumns: CellData[]
}

type ParameterDefinition = {
  Name: CellData
  Values: CellData[]
}

type Combination = Map<string, CellData>

module rec ConstraintExpression =
    type Constraints = Constraint[]

    type Constraint =
        | ConditionalConstraint of ifPredicate: Predicate * thenPredicate: Predicate * elsePredicate: Predicate option
        | UnconditionalConstraint of Predicate

    type Predicate =
        | ClausePredicate of Clause
        | LogicalOperatorPredicate of Clause * LogicalOperator * Predicate

    type Clause =
        | TermClause of Term
        | ParenPredicateClause of Predicate
        | NotClause of Clause

    type Term =
        | RelationTerm of Factor * Relation * Factor
        | LikeTerm of name: string * pattern: string
        | InTerm of Factor * Factor[]

    type Factor =
        | NameFactor of string
        | ValueFactor of Value

    type LogicalOperator =
        | And
        | Or

    type Relation =
        | Equal
        | NotEqual
        | GreaterThan
        | GreaterThanOrEqual
        | LessThan
        | LessThanOrEqual

    type Value =
        | StringValue of string
        | IntValue of int

type Constraints = ConstraintExpression.Constraints

type IRandom =
    abstract Next: maxValue: int -> int
    abstract Next: minValue: int * maxValue: int -> int

[<AutoOpen>]
module rec Extensions =
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
