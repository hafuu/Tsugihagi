// ts2fable 0.9.0
module rec TypeDefinitions.Gas
open System
open Fable.Core
open Fable.Core.JS

#nowarn "3390" // disable warnings for invalid XML comments
#nowarn "0044" // disable warnings for `Obsolete` usage

type BigNumber =
    obj

type Byte =
    float

type Integer =
    float

type Char =
    string

type JdbcSQL_XML =
    obj


type Array<'T> = System.Collections.Generic.IList<'T>

[<AutoOpen>]
module Globals =
    let [<Emit("SpreadsheetApp")>] SpreadsheetApp:GoogleAppsScript.Spreadsheet.SpreadsheetApp = jsNative

    let [<Emit("Utilities")>] Utilities:GoogleAppsScript.Utilities.Utilities = jsNative

module GoogleAppsScript =

    module Base =
        
        type [<AllowNullLiteral>] IExports =
          abstract DateConstructor: DateConstructorStatic
          /// Apps Script has a non-standard Date Class
          abstract Date: DateConstructor

        /// The types of Colors
        type [<RequireQualifiedAccess>] ColorType =
            | UNSUPPORTED = 0
            | RGB = 1
            | THEME = 2

        
        /// A color defined by red, green, blue color channels.
        type [<AllowNullLiteral>] RgbColor =
            abstract asHexString: unit -> string
            abstract getBlue: unit -> Integer
            abstract getColorType: unit -> ColorType
            abstract getGreen: unit -> Integer
            abstract getRed: unit -> Integer

        /// <summary>Apps Script has a non-standard Date Class</summary>
        /// <seealso href="https://github.com/microsoft/TypeScript/blob/master/lib/lib.es5.d.ts">Enables basic storage and retrieval of dates and times.</seealso>
        type [<AllowNullLiteral>] Date =
            /// Returns a string representation of a date. The format of the string depends on the locale.
            abstract toString: unit -> string
            /// Returns a date as a string value.
            abstract toDateString: unit -> string
            /// Returns a time as a string value.
            abstract toTimeString: unit -> string
            /// Returns a value as a string value appropriate to the host environment's current locale.
            abstract toLocaleString: unit -> string
            /// Returns a date as a string value appropriate to the host environment's current locale.
            abstract toLocaleDateString: unit -> string
            /// Returns a time as a string value appropriate to the host environment's current locale.
            abstract toLocaleTimeString: unit -> string
            /// Returns the stored time value in milliseconds since midnight, January 1, 1970 UTC.
            abstract valueOf: unit -> float
            /// Gets the time value in milliseconds.
            abstract getTime: unit -> float
            /// Gets the year, using local time.
            abstract getFullYear: unit -> float
            /// Gets the year using Universal Coordinated Time (UTC).
            abstract getUTCFullYear: unit -> float
            /// Gets the month, using local time.
            abstract getMonth: unit -> float
            /// Gets the month of a Date object using Universal Coordinated Time (UTC).
            abstract getUTCMonth: unit -> float
            /// Gets the day-of-the-month, using local time.
            abstract getDate: unit -> float
            /// Gets the day-of-the-month, using Universal Coordinated Time (UTC).
            abstract getUTCDate: unit -> float
            /// Gets the day of the week, using local time.
            abstract getDay: unit -> float
            /// Gets the day of the week using Universal Coordinated Time (UTC).
            abstract getUTCDay: unit -> float
            /// Gets the hours in a date, using local time.
            abstract getHours: unit -> float
            /// Gets the hours value in a Date object using Universal Coordinated Time (UTC).
            abstract getUTCHours: unit -> float
            /// Gets the minutes of a Date object, using local time.
            abstract getMinutes: unit -> float
            /// Gets the minutes of a Date object using Universal Coordinated Time (UTC).
            abstract getUTCMinutes: unit -> float
            /// Gets the seconds of a Date object, using local time.
            abstract getSeconds: unit -> float
            /// Gets the seconds of a Date object using Universal Coordinated Time (UTC).
            abstract getUTCSeconds: unit -> float
            /// Gets the milliseconds of a Date, using local time.
            abstract getMilliseconds: unit -> float
            /// Gets the milliseconds of a Date object using Universal Coordinated Time (UTC).
            abstract getUTCMilliseconds: unit -> float
            /// Gets the difference in minutes between the time on the local computer and Universal Coordinated Time (UTC).
            abstract getTimezoneOffset: unit -> float
            /// <summary>Sets the date and time value in the Date object.</summary>
            /// <param name="time">A numeric value representing the number of elapsed milliseconds since midnight, January 1, 1970 GMT.</param>
            abstract setTime: time: float -> float
            /// <summary>Sets the milliseconds value in the Date object using local time.</summary>
            /// <param name="ms">A numeric value equal to the millisecond value.</param>
            abstract setMilliseconds: ms: float -> float
            /// <summary>Sets the milliseconds value in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="ms">A numeric value equal to the millisecond value.</param>
            abstract setUTCMilliseconds: ms: float -> float
            /// <summary>Sets the seconds value in the Date object using local time.</summary>
            /// <param name="sec">A numeric value equal to the seconds value.</param>
            /// <param name="ms">A numeric value equal to the milliseconds value.</param>
            abstract setSeconds: sec: float * ?ms: float -> float
            /// <summary>Sets the seconds value in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="sec">A numeric value equal to the seconds value.</param>
            /// <param name="ms">A numeric value equal to the milliseconds value.</param>
            abstract setUTCSeconds: sec: float * ?ms: float -> float
            /// <summary>Sets the minutes value in the Date object using local time.</summary>
            /// <param name="min">A numeric value equal to the minutes value.</param>
            /// <param name="sec">A numeric value equal to the seconds value.</param>
            /// <param name="ms">A numeric value equal to the milliseconds value.</param>
            abstract setMinutes: min: float * ?sec: float * ?ms: float -> float
            /// <summary>Sets the minutes value in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="min">A numeric value equal to the minutes value.</param>
            /// <param name="sec">A numeric value equal to the seconds value.</param>
            /// <param name="ms">A numeric value equal to the milliseconds value.</param>
            abstract setUTCMinutes: min: float * ?sec: float * ?ms: float -> float
            /// <summary>Sets the hour value in the Date object using local time.</summary>
            /// <param name="hours">A numeric value equal to the hours value.</param>
            /// <param name="min">A numeric value equal to the minutes value.</param>
            /// <param name="sec">A numeric value equal to the seconds value.</param>
            /// <param name="ms">A numeric value equal to the milliseconds value.</param>
            abstract setHours: hours: float * ?min: float * ?sec: float * ?ms: float -> float
            /// <summary>Sets the hours value in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="hours">A numeric value equal to the hours value.</param>
            /// <param name="min">A numeric value equal to the minutes value.</param>
            /// <param name="sec">A numeric value equal to the seconds value.</param>
            /// <param name="ms">A numeric value equal to the milliseconds value.</param>
            abstract setUTCHours: hours: float * ?min: float * ?sec: float * ?ms: float -> float
            /// <summary>Sets the numeric day-of-the-month value of the Date object using local time.</summary>
            /// <param name="date">A numeric value equal to the day of the month.</param>
            abstract setDate: date: float -> float
            /// <summary>Sets the numeric day of the month in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="date">A numeric value equal to the day of the month.</param>
            abstract setUTCDate: date: float -> float
            /// <summary>Sets the month value in the Date object using local time.</summary>
            /// <param name="month">A numeric value equal to the month. The value for January is 0, and other month values follow consecutively.</param>
            /// <param name="date">A numeric value representing the day of the month. If this value is not supplied, the value from a call to the getDate method is used.</param>
            abstract setMonth: month: float * ?date: float -> float
            /// <summary>Sets the month value in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="month">A numeric value equal to the month. The value for January is 0, and other month values follow consecutively.</param>
            /// <param name="date">A numeric value representing the day of the month. If it is not supplied, the value from a call to the getUTCDate method is used.</param>
            abstract setUTCMonth: month: float * ?date: float -> float
            /// <summary>Sets the year of the Date object using local time.</summary>
            /// <param name="year">A numeric value for the year.</param>
            /// <param name="month">A zero-based numeric value for the month (0 for January, 11 for December). Must be specified if numDate is specified.</param>
            /// <param name="date">A numeric value equal for the day of the month.</param>
            abstract setFullYear: year: float * ?month: float * ?date: float -> float
            /// <summary>Sets the year value in the Date object using Universal Coordinated Time (UTC).</summary>
            /// <param name="year">A numeric value equal to the year.</param>
            /// <param name="month">A numeric value equal to the month. The value for January is 0, and other month values follow consecutively. Must be supplied if numDate is supplied.</param>
            /// <param name="date">A numeric value equal to the day of the month.</param>
            abstract setUTCFullYear: year: float * ?month: float * ?date: float -> float
            /// Returns a date converted to a string using Universal Coordinated Time (UTC).
            abstract toUTCString: unit -> string
            /// Returns a date as a string value in ISO format.
            abstract toISOString: unit -> string
            /// Used by the JSON.stringify method to enable the transformation of an object's data for JavaScript Object Notation (JSON) serialization.
            abstract toJSON: ?key: obj -> string

        type [<AllowNullLiteral>] DateConstructor =
            [<Emit("$0($1...)")>] abstract Invoke: unit -> string
            abstract prototype: DateTime
            /// <summary>Parses a string containing a date, and returns the number of milliseconds between that date and midnight, January 1, 1970.</summary>
            /// <param name="s">A date string</param>
            abstract parse: s: string -> float
            /// <summary>Returns the number of milliseconds between midnight, January 1, 1970 Universal Coordinated Time (UTC) (or GMT) and the specified date.</summary>
            /// <param name="year">The full year designation is required for cross-century date accuracy. If year is between 0 and 99 is used, then year is assumed to be 1900 + year.</param>
            /// <param name="month">The month as an number between 0 and 11 (January to December).</param>
            /// <param name="date">The date as an number between 1 and 31.</param>
            /// <param name="hours">Must be supplied if minutes is supplied. An number from 0 to 23 (midnight to 11pm) that specifies the hour.</param>
            /// <param name="minutes">Must be supplied if seconds is supplied. An number from 0 to 59 that specifies the minutes.</param>
            /// <param name="seconds">Must be supplied if milliseconds is supplied. An number from 0 to 59 that specifies the seconds.</param>
            /// <param name="ms">An number from 0 to 999 that specifies the milliseconds.</param>
            abstract UTC: year: float * month: float * ?date: float * ?hours: float * ?minutes: float * ?seconds: float * ?ms: float -> float
            abstract now: unit -> float

        type [<AllowNullLiteral>] DateConstructorStatic =
            [<EmitConstructor>] abstract Create: unit -> DateConstructor
            [<EmitConstructor>] abstract Create: value: U2<float, string> -> DateConstructor
            [<EmitConstructor>] abstract Create: year: float * month: float * ?date: float * ?hours: float * ?minutes: float * ?seconds: float * ?ms: float -> DateConstructor

    module Spreadsheet =

        /// An enumeration of the types of series used to calculate auto-filled values. The manner in which
        /// these series affect calculated values differs depending on the type and amount of source data.
        type [<RequireQualifiedAccess>] AutoFillSeries =
            | DEFAULT_SERIES = 0
            | ALTERNATE_SERIES = 1

        /// Access and modify bandings, the color patterns applied to rows or columns of a range. Each
        /// banding consists of a range and a set of colors for rows, columns, headers, and footers.
        type [<AllowNullLiteral>] Banding =
            abstract copyTo: range: Range -> Banding
            abstract getFirstColumnColor: unit -> string option
            abstract getFirstRowColor: unit -> string option
            abstract getFooterColumnColor: unit -> string option
            abstract getFooterRowColor: unit -> string option
            abstract getHeaderColumnColor: unit -> string option
            abstract getHeaderRowColor: unit -> string option
            abstract getRange: unit -> Range
            abstract getSecondColumnColor: unit -> string option
            abstract getSecondRowColor: unit -> string option
            abstract remove: unit -> unit
            abstract setFirstColumnColor: color: string option -> Banding
            abstract setFirstRowColor: color: string option -> Banding
            abstract setFooterColumnColor: color: string option -> Banding
            abstract setFooterRowColor: color: string option -> Banding
            abstract setHeaderColumnColor: color: string option -> Banding
            abstract setHeaderRowColor: color: string option -> Banding
            abstract setRange: range: Range -> Banding
            abstract setSecondColumnColor: color: string option -> Banding
            abstract setSecondRowColor: color: string option -> Banding

        /// An enumeration of banding themes. Each theme consists of several complementary colors that are
        /// applied to different cells based on the banding settings.
        type [<RequireQualifiedAccess>] BandingTheme =
            | LIGHT_GREY = 0
            | CYAN = 1
            | GREEN = 2
            | YELLOW = 3
            | ORANGE = 4
            | BLUE = 5
            | TEAL = 6
            | GREY = 7
            | BROWN = 8
            | LIGHT_GREEN = 9
            | INDIGO = 10
            | PINK = 11

        /// Access the existing BigQuery data source specification. To create a new data source
        /// specification, use SpreadsheetApp.newDataSourceSpec().
        type [<AllowNullLiteral>] BigQueryDataSourceSpec =
            abstract copy: unit -> DataSourceSpecBuilder
            abstract getParameters: unit -> ResizeArray<DataSourceParameter>
            abstract getProjectId: unit -> string
            abstract getRawQuery: unit -> string
            abstract getType: unit -> DataSourceType

        /// The builder for BigQueryDataSourceSpecBuilder.
        type [<AllowNullLiteral>] BigQueryDataSourceSpecBuilder =
            abstract build: unit -> DataSourceSpec
            abstract copy: unit -> DataSourceSpecBuilder
            abstract getParameters: unit -> ResizeArray<DataSourceParameter>
            abstract getProjectId: unit -> string
            abstract getRawQuery: unit -> string
            abstract getType: unit -> DataSourceType
            abstract removeAllParameters: unit -> BigQueryDataSourceSpecBuilder
            abstract removeParameter: parameterName: string -> BigQueryDataSourceSpecBuilder
            abstract setParameterFromCell: parameterName: string * sourceCell: string -> BigQueryDataSourceSpecBuilder
            abstract setProjectId: projectId: string -> BigQueryDataSourceSpecBuilder
            abstract setRawQuery: rawQuery: string -> BigQueryDataSourceSpecBuilder

        /// Access boolean conditions in ConditionalFormatRules. Each
        /// conditional format rule may contain a single boolean condition. The boolean condition itself
        /// contains a boolean criteria (with values) and formatting settings. The criteria is evaluated
        /// against the content of a cell resulting in either a true or false value. If the
        /// criteria evaluates to true, the condition's formatting settings are applied to the cell.
        type [<AllowNullLiteral>] BooleanCondition =
            abstract getBackground: unit -> string option
            abstract getBold: unit -> bool option
            abstract getCriteriaType: unit -> BooleanCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj option>
            abstract getFontColor: unit -> string option
            abstract getItalic: unit -> bool option
            abstract getStrikethrough: unit -> bool option
            abstract getUnderline: unit -> bool option

        /// An enumeration representing the boolean criteria that can be used in conditional format or
        /// filter.
        type [<RequireQualifiedAccess>] BooleanCriteria =
            | CELL_EMPTY = 0
            | CELL_NOT_EMPTY = 1
            | DATE_AFTER = 2
            | DATE_BEFORE = 3
            | DATE_EQUAL_TO = 4
            | DATE_AFTER_RELATIVE = 5
            | DATE_BEFORE_RELATIVE = 6
            | DATE_EQUAL_TO_RELATIVE = 7
            | NUMBER_BETWEEN = 8
            | NUMBER_EQUAL_TO = 9
            | NUMBER_GREATER_THAN = 10
            | NUMBER_GREATER_THAN_OR_EQUAL_TO = 11
            | NUMBER_LESS_THAN = 12
            | NUMBER_LESS_THAN_OR_EQUAL_TO = 13
            | NUMBER_NOT_BETWEEN = 14
            | NUMBER_NOT_EQUAL_TO = 15
            | TEXT_CONTAINS = 16
            | TEXT_DOES_NOT_CONTAIN = 17
            | TEXT_EQUAL_TO = 18
            | TEXT_STARTS_WITH = 19
            | TEXT_ENDS_WITH = 20
            | CUSTOM_FORMULA = 21

        /// Styles that can be set on a range using Range.setBorder(top, left, bottom, right, vertical, horizontal, color, style).
        type [<RequireQualifiedAccess>] BorderStyle =
            | DOTTED = 0
            | DASHED = 1
            | SOLID = 2
            | SOLID_MEDIUM = 3
            | SOLID_THICK = 4
            | DOUBLE = 5

        /// Represents an image to add to a cell. To add an image to a cell, you must create a new image
        /// value for the image using SpreadsheetApp.newCellImage() and CellImageBuilder. Then you can
        /// use Range.setValue(value) or Range.setValues(values) to add the image value to the cell.
        type [<AllowNullLiteral>] CellImage =
            abstract valueType: ValueType with get, set
            abstract getAltTextDescription: unit -> string
            abstract getAltTextTitle: unit -> string
            abstract getContentUrl: unit -> string
            abstract getUrl: unit -> string option
            abstract toBuilder: unit -> CellImageBuilder

        /// Builder for CellImage. This builder creates the image value needed to add an image to a cell.
        type [<AllowNullLiteral>] CellImageBuilder =
            abstract valueType: ValueType with get, set
            abstract build: unit -> CellImage
            abstract getAltTextDescription: unit -> string
            abstract getAltTextTitle: unit -> string
            abstract getContentUrl: unit -> string
            abstract getUrl: unit -> string option
            abstract setAltTextDescription: description: string -> CellImageBuilder
            abstract setAltTextTitle: title: string -> CellImageBuilder
            abstract setSourceUrl: url: string -> CellImageBuilder
            abstract toBuilder: unit -> CellImageBuilder

        /// A representation for a color.
        type [<AllowNullLiteral>] Color =
            abstract asRgbColor: unit -> Base.RgbColor
            abstract asThemeColor: unit -> ThemeColor
            abstract getColorType: unit -> Base.ColorType

        /// The builder for ColorBuilder. To create a new builder, use SpreadsheetApp.newColor().
        type [<AllowNullLiteral>] ColorBuilder =
            abstract asRgbColor: unit -> Base.RgbColor
            abstract asThemeColor: unit -> ThemeColor
            abstract build: unit -> Color
            abstract getColorType: unit -> Base.ColorType
            abstract setRgbColor: cssString: string -> ColorBuilder
            abstract setThemeColor: themeColorType: ThemeColorType -> ColorBuilder

        /// Access conditional formatting rules. To create a new rule, use SpreadsheetApp.newConditionalFormatRule() and ConditionalFormatRuleBuilder.
        /// You can use Sheet.setConditionalFormatRules(rules) to set the
        /// rules for a given sheet.
        type [<AllowNullLiteral>] ConditionalFormatRule =
            abstract copy: unit -> ConditionalFormatRuleBuilder
            abstract getBooleanCondition: unit -> BooleanCondition option
            abstract getGradientCondition: unit -> GradientCondition option
            abstract getRanges: unit -> ResizeArray<Range>

        /// Builder for conditional format rules.
        /// 
        ///     // Adds a conditional format rule to a sheet that causes cells in range A1:B3 to turn red if
        ///     // they contain a number between 1 and 10.
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var range = sheet.getRange("A1:B3");
        ///     var rule = SpreadsheetApp.newConditionalFormatRule()
        ///         .whenNumberBetween(1, 10)
        ///         .setBackground("#FF0000")
        ///         .setRanges([range])
        ///         .build();
        ///     var rules = sheet.getConditionalFormatRules();
        ///     rules.push(rule);
        ///     sheet.setConditionalFormatRules(rules);
        type [<AllowNullLiteral>] ConditionalFormatRuleBuilder =
            abstract build: unit -> ConditionalFormatRule
            abstract copy: unit -> ConditionalFormatRuleBuilder
            abstract getBooleanCondition: unit -> BooleanCondition option
            abstract getGradientCondition: unit -> GradientCondition option
            abstract getRanges: unit -> ResizeArray<Range>
            abstract setBackground: color: string option -> ConditionalFormatRuleBuilder
            abstract setBold: bold: bool option -> ConditionalFormatRuleBuilder
            abstract setFontColor: color: string option -> ConditionalFormatRuleBuilder
            abstract setGradientMaxpoint: color: string -> ConditionalFormatRuleBuilder
            abstract setGradientMaxpointWithValue: color: string * ``type``: InterpolationType * value: string -> ConditionalFormatRuleBuilder
            abstract setGradientMidpointWithValue: color: string * ``type``: InterpolationType * value: string -> ConditionalFormatRuleBuilder
            abstract setGradientMinpoint: color: string -> ConditionalFormatRuleBuilder
            abstract setGradientMinpointWithValue: color: string * ``type``: InterpolationType * value: string -> ConditionalFormatRuleBuilder
            abstract setItalic: italic: bool option -> ConditionalFormatRuleBuilder
            abstract setRanges: ranges: ResizeArray<Range> -> ConditionalFormatRuleBuilder
            abstract setStrikethrough: strikethrough: bool option -> ConditionalFormatRuleBuilder
            abstract setUnderline: underline: bool option -> ConditionalFormatRuleBuilder
            abstract whenCellEmpty: unit -> ConditionalFormatRuleBuilder
            abstract whenCellNotEmpty: unit -> ConditionalFormatRuleBuilder
            abstract whenDateAfter: date: Base.Date -> ConditionalFormatRuleBuilder
            abstract whenDateAfter: date: RelativeDate -> ConditionalFormatRuleBuilder
            abstract whenDateBefore: date: Base.Date -> ConditionalFormatRuleBuilder
            abstract whenDateBefore: date: RelativeDate -> ConditionalFormatRuleBuilder
            abstract whenDateEqualTo: date: Base.Date -> ConditionalFormatRuleBuilder
            abstract whenDateEqualTo: date: RelativeDate -> ConditionalFormatRuleBuilder
            abstract whenFormulaSatisfied: formula: string -> ConditionalFormatRuleBuilder
            abstract whenNumberBetween: start: float * ``end``: float -> ConditionalFormatRuleBuilder
            abstract whenNumberEqualTo: number: float -> ConditionalFormatRuleBuilder
            abstract whenNumberGreaterThan: number: float -> ConditionalFormatRuleBuilder
            abstract whenNumberGreaterThanOrEqualTo: number: float -> ConditionalFormatRuleBuilder
            abstract whenNumberLessThan: number: float -> ConditionalFormatRuleBuilder
            abstract whenNumberLessThanOrEqualTo: number: float -> ConditionalFormatRuleBuilder
            abstract whenNumberNotBetween: start: float * ``end``: float -> ConditionalFormatRuleBuilder
            abstract whenNumberNotEqualTo: number: float -> ConditionalFormatRuleBuilder
            abstract whenTextContains: text: string -> ConditionalFormatRuleBuilder
            abstract whenTextDoesNotContain: text: string -> ConditionalFormatRuleBuilder
            abstract whenTextEndsWith: text: string -> ConditionalFormatRuleBuilder
            abstract whenTextEqualTo: text: string -> ConditionalFormatRuleBuilder
            abstract whenTextStartsWith: text: string -> ConditionalFormatRuleBuilder
            abstract withCriteria: criteria: BooleanCriteria * args: ResizeArray<obj option> -> ConditionalFormatRuleBuilder

        /// Access the chart's position within a sheet. Can be updated using the EmbeddedChart.modify() function.
        /// 
        ///     chart = chart.modify().setPosition(5, 5, 0, 0).build();
        ///     sheet.updateChart(chart);
        type [<AllowNullLiteral>] ContainerInfo =
            abstract getAnchorColumn: unit -> Integer
            abstract getAnchorRow: unit -> Integer
            abstract getOffsetX: unit -> Integer
            abstract getOffsetY: unit -> Integer

        /// An enumeration of possible special paste types.
        type [<RequireQualifiedAccess>] CopyPasteType =
            | PASTE_NORMAL = 0
            | PASTE_NO_BORDERS = 1
            | PASTE_FORMAT = 2
            | PASTE_FORMULA = 3
            | PASTE_DATA_VALIDATION = 4
            | PASTE_VALUES = 5
            | PASTE_CONDITIONAL_FORMATTING = 6
            | PASTE_COLUMN_WIDTHS = 7

        /// An enumeration of data execution error codes.
        type [<RequireQualifiedAccess>] DataExecutionErrorCode =
            | DATA_EXECUTION_ERROR_CODE_UNSUPPORTED = 0
            | NONE = 1
            | TIME_OUT = 2
            | TOO_MANY_ROWS = 3
            | TOO_MANY_CELLS = 4
            | ENGINE = 5
            | PARAMETER_INVALID = 6
            | UNSUPPORTED_DATA_TYPE = 7
            | DUPLICATE_COLUMN_NAMES = 8
            | INTERRUPTED = 9
            | OTHER = 10
            | TOO_MANY_CHARS_PER_CELL = 11

        /// An enumeration of data execution states.
        type [<RequireQualifiedAccess>] DataExecutionState =
            | DATA_EXECUTION_STATE_UNSUPPORTED = 0
            | RUNNING = 1
            | SUCCESS = 2
            | ERROR = 3
            | NOT_STARTED = 4

        /// The data execution status.
        type [<AllowNullLiteral>] DataExecutionStatus =
            abstract getErrorCode: unit -> DataExecutionErrorCode
            abstract getErrorMessage: unit -> string
            abstract getExecutionState: unit -> DataExecutionState
            abstract getLastRefreshedTime: unit -> Base.Date option
            abstract isTruncated: unit -> bool

        /// Access and modify existing data source. To create a data source table with new data source, see
        /// DataSourceTable.
        type [<AllowNullLiteral>] DataSource =
            abstract getSpec: unit -> DataSourceSpec
            abstract updateSpec: spec: DataSourceSpec -> DataSource

        /// Access and modify a data source column.
        /// 
        /// Only use this class with data that's connected to a database.
        type [<AllowNullLiteral>] DataSourceColumn =
            abstract getDataSource: unit -> DataSource
            abstract getFormula: unit -> string
            abstract getName: unit -> string
            abstract hasArrayDependency: unit -> bool
            abstract isCalculatedColumn: unit -> bool
            abstract remove: unit -> unit
            abstract setFormula: formula: string -> DataSourceColumn
            abstract setName: name: string -> DataSourceColumn

        /// Access and modify existing data source formulas.
        type [<AllowNullLiteral>] DataSourceFormula =
            abstract forceRefreshData: unit -> DataSourceFormula
            abstract getAnchorCell: unit -> Range
            abstract getDataSource: unit -> DataSource
            abstract getDisplayValue: unit -> string
            abstract getFormula: unit -> string
            abstract getStatus: unit -> DataExecutionStatus
            abstract refreshData: unit -> DataSourceFormula
            abstract setFormula: formula: string -> DataSourceFormula
            abstract waitForCompletion: timeoutInSeconds: float -> DataExecutionStatus

        /// Access existing data source parameters.
        type [<AllowNullLiteral>] DataSourceParameter =
            abstract getName: unit -> string
            abstract getSourceCell: unit -> string option
            abstract getType: unit -> DataSourceParameterType

        /// An enumeration of data source parameter types.
        type [<RequireQualifiedAccess>] DataSourceParameterType =
            | DATA_SOURCE_PARAMETER_TYPE_UNSUPPORTED = 0
            | CELL = 1

        /// Access and modify existing data source pivot table.
        /// Only use this class with data that's connected to a database
        type [<AllowNullLiteral>] DataSourcePivotTable =
            abstract addColumnGroup: columnName: string -> PivotGroup
            abstract addFilter: columnName: string * filterCriteria: FilterCriteria -> PivotFilter
            abstract addPivotValue: columnName: string * summarizeFunction: PivotTableSummarizeFunction -> PivotValue
            abstract addRowGroup: columnName: string -> PivotGroup
            abstract asPivotTable: unit -> PivotTable
            abstract forceRefreshData: unit -> DataSourcePivotTable
            abstract getDataSource: unit -> DataSource
            abstract getStatus: unit -> DataExecutionStatus
            abstract refreshData: unit -> DataSourcePivotTable
            abstract waitForCompletion: timeoutInSeconds: float -> DataExecutionStatus

        /// Access and modify existing data source sheet. To create a new data source sheet, use Spreadsheet.insertDataSourceSheet(spec).
        /// 
        /// Only use this class with data that's connected to a database.
        type [<AllowNullLiteral>] DataSourceSheet =
            abstract addFilter: columnName: string * filterCriteria: FilterCriteria -> DataSourceSheet
            abstract asSheet: unit -> Sheet
            abstract autoResizeColumn: columnName: string -> DataSourceSheet
            abstract autoResizeColumns: columnNames: ResizeArray<string> -> DataSourceSheet
            abstract forceRefreshData: unit -> DataSourceSheet
            abstract getColumnWidth: columnName: string -> float
            abstract getDataSource: unit -> DataSource
            abstract getFilters: unit -> ResizeArray<DataSourceSheetFilter>
            abstract getSheetValues: columnName: string * ?startRow: float * ?numRows: float -> ResizeArray<obj option>
            abstract getSortSpecs: unit -> ResizeArray<SortSpec>
            abstract getStatus: unit -> DataExecutionStatus
            abstract refreshData: unit -> DataSourceSheet
            abstract removeFilters: columnName: string -> DataSourceSheet
            abstract removeSortSpec: columnName: string -> DataSourceSheet
            abstract setColumnWidth: columnName: string * width: float -> DataSourceSheet
            abstract setColumnWidths: columnNames: ResizeArray<string> * width: float -> DataSourceSheet
            abstract setSortSpec: columnName: string * ascending: bool -> DataSourceSheet
            abstract waitForCompletion: timeoutInSeconds: float -> DataExecutionStatus

        /// Access and modify an existing data source sheet filter. To create a new data source sheet filter, use DataSourceSheet.addFilter(columnName, filterCriteria).
        /// 
        /// Only use this class with data that's connected to a database.
        type [<AllowNullLiteral>] DataSourceSheetFilter =
            abstract getDataSourceColumn: unit -> DataSourceColumn
            abstract getDataSourceSheet: unit -> DataSourceSheet
            abstract getFilterCriteria: unit -> FilterCriteria
            abstract remove: unit -> unit
            abstract setFilterCriteria: filterCriteria: FilterCriteria -> DataSourceSheetFilter

        /// Access the general settings of an existing data source spec. To access data source spec for
        /// certain type, use as...() method. To create a new data source spec, use SpreadsheetApp.newDataSourceSpec().
        /// 
        /// This example shows how to get information from a BigQuery data source spec.
        /// 
        ///     var dataSourceTable =
        ///         SpreadsheetApp.getActive().getSheetByName("Data Sheet 1").getDataSourceTables()[0];
        ///     var spec = dataSourceTable.getDataSource().getSpec();
        ///     if (spec.getType() == SpreadsheetApp.DataSourceType.BIGQUERY) {
        ///       var bqSpec = spec.asBigQuery();
        ///       Logger.log("Project ID: %s\n", bqSpec.getProjectId());
        ///       Logger.log("Raw query string: %s\n", bqSpec.getRawQuery());
        ///     }
        type [<AllowNullLiteral>] DataSourceSpec =
            abstract asBigQuery: unit -> BigQueryDataSourceSpec
            abstract copy: unit -> DataSourceSpecBuilder
            abstract getParameters: unit -> ResizeArray<DataSourceParameter>
            abstract getType: unit -> DataSourceType

        /// <summary>
        /// The builder for DataSourceSpec. To create a specification for certain type, use as...() method. To create a new builder, use SpreadsheetApp.newDataSourceSpec(). To use the specification, see DataSourceTable.
        /// 
        /// This examples show how to build a BigQuery data source specification.
        /// 
        ///     var spec = SpreadsheetApp.newDataSourceSpec()
        ///                .asBigQuery()
        ///                .setProjectId('big_query_project')
        ///                .setRawQuery('select
        /// </summary>
        type [<AllowNullLiteral>] DataSourceSpecBuilder =
            abstract asBigQuery: unit -> BigQueryDataSourceSpecBuilder
            abstract build: unit -> DataSourceSpec
            abstract copy: unit -> DataSourceSpecBuilder
            abstract getParameters: unit -> ResizeArray<DataSourceParameter>
            abstract getType: unit -> DataSourceType
            abstract removeAllParameters: unit -> DataSourceSpecBuilder
            abstract removeParameter: parameterName: string -> DataSourceSpecBuilder
            abstract setParameterFromCell: parameterName: string * sourceCell: string -> DataSourceSpecBuilder

        /// <summary>
        /// Access and modify existing data source table. To create a new data source table on a new sheet,
        /// use Spreadsheet.insertSheetWithDataSourceTable(spec).
        /// 
        /// This example shows how to create a new data source table.
        /// 
        ///     SpreadsheetApp.enableBigQueryExecution();
        ///     var spreadsheet = SpreadsheetApp.getActive();
        ///     var spec = SpreadsheetApp.newDataSourceSpec()
        ///                .asBigQuery()
        ///                .setProjectId('big_query_project')
        ///                .setRawQuery('select
        /// </summary>
        type [<AllowNullLiteral>] DataSourceTable =
            abstract forceRefreshData: unit -> DataSourceTable
            abstract getDataSource: unit -> DataSource
            abstract getRange: unit -> Range
            abstract getStatus: unit -> DataExecutionStatus
            abstract refreshData: unit -> DataSourceTable
            abstract waitForCompletion: timeoutInSeconds: Integer -> DataExecutionStatus

        /// An enumeration of data source types.
        type [<RequireQualifiedAccess>] DataSourceType =
            | DATA_SOURCE_TYPE_UNSUPPORTED = 0
            | BIGQUERY = 1

        /// Access data validation rules. To create a new rule, use SpreadsheetApp.newDataValidation() and DataValidationBuilder. You can use
        /// Range.setDataValidation(rule) to set the validation rule for a range.
        /// 
        ///     // Log information about the data validation rule for cell A1.
        ///     var cell = SpreadsheetApp.getActive().getRange('A1');
        ///     var rule = cell.getDataValidation();
        ///     if (rule != null) {
        ///       var criteria = rule.getCriteriaType();
        ///       var args = rule.getCriteriaValues();
        ///       Logger.log('The data validation rule is %s %s', criteria, args);
        ///     } else {
        ///       Logger.log('The cell does not have a data validation rule.')
        ///     }
        type [<AllowNullLiteral>] DataValidation =
            abstract copy: unit -> DataValidationBuilder
            abstract getAllowInvalid: unit -> bool
            abstract getCriteriaType: unit -> DataValidationCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj option>
            abstract getHelpText: unit -> string

        /// Builder for data validation rules.
        /// 
        ///     // Set the data validation for cell A1 to require a value from B1:B10.
        ///     var cell = SpreadsheetApp.getActive().getRange('A1');
        ///     var range = SpreadsheetApp.getActive().getRange('B1:B10');
        ///     var rule = SpreadsheetApp.newDataValidation().requireValueInRange(range).build();
        ///     cell.setDataValidation(rule);
        type [<AllowNullLiteral>] DataValidationBuilder =
            abstract build: unit -> DataValidation
            abstract copy: unit -> DataValidationBuilder
            abstract getAllowInvalid: unit -> bool
            abstract getCriteriaType: unit -> DataValidationCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj option>
            abstract getHelpText: unit -> string option
            abstract requireCheckbox: unit -> DataValidationBuilder
            abstract requireCheckbox: checkedValue: obj option -> DataValidationBuilder
            abstract requireCheckbox: checkedValue: obj option * uncheckedValue: obj option -> DataValidationBuilder
            abstract requireDate: unit -> DataValidationBuilder
            abstract requireDateAfter: date: Base.Date -> DataValidationBuilder
            abstract requireDateBefore: date: Base.Date -> DataValidationBuilder
            abstract requireDateBetween: start: Base.Date * ``end``: Base.Date -> DataValidationBuilder
            abstract requireDateEqualTo: date: Base.Date -> DataValidationBuilder
            abstract requireDateNotBetween: start: Base.Date * ``end``: Base.Date -> DataValidationBuilder
            abstract requireDateOnOrAfter: date: Base.Date -> DataValidationBuilder
            abstract requireDateOnOrBefore: date: Base.Date -> DataValidationBuilder
            abstract requireFormulaSatisfied: formula: string -> DataValidationBuilder
            abstract requireNumberBetween: start: float * ``end``: float -> DataValidationBuilder
            abstract requireNumberEqualTo: number: float -> DataValidationBuilder
            abstract requireNumberGreaterThan: number: float -> DataValidationBuilder
            abstract requireNumberGreaterThanOrEqualTo: number: float -> DataValidationBuilder
            abstract requireNumberLessThan: number: float -> DataValidationBuilder
            abstract requireNumberLessThanOrEqualTo: number: float -> DataValidationBuilder
            abstract requireNumberNotBetween: start: float * ``end``: float -> DataValidationBuilder
            abstract requireNumberNotEqualTo: number: float -> DataValidationBuilder
            abstract requireTextContains: text: string -> DataValidationBuilder
            abstract requireTextDoesNotContain: text: string -> DataValidationBuilder
            abstract requireTextEqualTo: text: string -> DataValidationBuilder
            abstract requireTextIsEmail: unit -> DataValidationBuilder
            abstract requireTextIsUrl: unit -> DataValidationBuilder
            abstract requireValueInList: values: ResizeArray<string> -> DataValidationBuilder
            abstract requireValueInList: values: ResizeArray<string> * showDropdown: bool -> DataValidationBuilder
            abstract requireValueInRange: range: Range -> DataValidationBuilder
            abstract requireValueInRange: range: Range * showDropdown: bool -> DataValidationBuilder
            abstract setAllowInvalid: allowInvalidData: bool -> DataValidationBuilder
            abstract setHelpText: helpText: string -> DataValidationBuilder
            abstract withCriteria: criteria: DataValidationCriteria * args: ResizeArray<obj option> -> DataValidationBuilder

        /// An enumeration representing the data validation criteria that can be set on a range.
        /// 
        ///     // Change existing data-validation rules that require a date in 2013 to require a date in 2014.
        ///     var oldDates = [new Date('1/1/2013'), new Date('12/31/2013')];
        ///     var newDates = [new Date('1/1/2014'), new Date('12/31/2014')];
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var range = sheet.getRange(1, 1, sheet.getMaxRows(), sheet.getMaxColumns());
        ///     var rules = range.getDataValidations();
        /// 
        ///     for (var i = 0; i < rules.length; i++) {
        ///       for (var j = 0; j < rules[i].length; j++) {
        ///         var rule = rules[i][j];
        /// 
        ///         if (rule != null) {
        ///           var criteria = rule.getCriteriaType();
        ///           var args = rule.getCriteriaValues();
        /// 
        ///           if (criteria == SpreadsheetApp.DataValidationCriteria.DATE_BETWEEN
        ///               && args[0].getTime() == oldDates[0].getTime()
        ///               && args[1].getTime() == oldDates[1].getTime()) {
        ///             // Create a builder from the existing rule, then change the dates.
        ///             rules[i][j] = rule.copy().withCriteria(criteria, newDates).build();
        ///           }
        ///         }
        ///       }
        ///     }
        ///     range.setDataValidations(rules);
        type [<RequireQualifiedAccess>] DataValidationCriteria =
            | DATE_AFTER = 0
            | DATE_BEFORE = 1
            | DATE_BETWEEN = 2
            | DATE_EQUAL_TO = 3
            | DATE_IS_VALID_DATE = 4
            | DATE_NOT_BETWEEN = 5
            | DATE_ON_OR_AFTER = 6
            | DATE_ON_OR_BEFORE = 7
            | NUMBER_BETWEEN = 8
            | NUMBER_EQUAL_TO = 9
            | NUMBER_GREATER_THAN = 10
            | NUMBER_GREATER_THAN_OR_EQUAL_TO = 11
            | NUMBER_LESS_THAN = 12
            | NUMBER_LESS_THAN_OR_EQUAL_TO = 13
            | NUMBER_NOT_BETWEEN = 14
            | NUMBER_NOT_EQUAL_TO = 15
            | TEXT_CONTAINS = 16
            | TEXT_DOES_NOT_CONTAIN = 17
            | TEXT_EQUAL_TO = 18
            | TEXT_IS_VALID_EMAIL = 19
            | TEXT_IS_VALID_URL = 20
            | VALUE_IN_LIST = 21
            | VALUE_IN_RANGE = 22
            | CUSTOM_FORMULA = 23
            | CHECKBOX = 24

        /// Access and modify developer metadata. To create new developer metadata use Range.addDeveloperMetadata(key), Sheet.addDeveloperMetadata(key), or Spreadsheet.addDeveloperMetadata(key).
        type [<AllowNullLiteral>] DeveloperMetadata =
            abstract getId: unit -> Integer
            abstract getKey: unit -> string
            abstract getLocation: unit -> DeveloperMetadataLocation
            abstract getValue: unit -> string option
            abstract getVisibility: unit -> DeveloperMetadataVisibility
            abstract moveToColumn: column: Range -> DeveloperMetadata
            abstract moveToRow: row: Range -> DeveloperMetadata
            abstract moveToSheet: sheet: Sheet -> DeveloperMetadata
            abstract moveToSpreadsheet: unit -> DeveloperMetadata
            abstract remove: unit -> unit
            abstract setKey: key: string -> DeveloperMetadata
            abstract setValue: value: string -> DeveloperMetadata
            abstract setVisibility: visibility: DeveloperMetadataVisibility -> DeveloperMetadata

        /// Search for developer metadata in a spreadsheet. To create new developer metadata finder use
        /// Range.createDeveloperMetadataFinder(), Sheet.createDeveloperMetadataFinder(),
        /// or Spreadsheet.createDeveloperMetadataFinder().
        type [<AllowNullLiteral>] DeveloperMetadataFinder =
            abstract find: unit -> ResizeArray<DeveloperMetadata>
            abstract onIntersectingLocations: unit -> DeveloperMetadataFinder
            abstract withId: id: Integer -> DeveloperMetadataFinder
            abstract withKey: key: string -> DeveloperMetadataFinder
            abstract withLocationType: locationType: DeveloperMetadataLocationType -> DeveloperMetadataFinder
            abstract withValue: value: string -> DeveloperMetadataFinder
            abstract withVisibility: visibility: DeveloperMetadataVisibility -> DeveloperMetadataFinder

        /// Access developer metadata location information.
        type [<AllowNullLiteral>] DeveloperMetadataLocation =
            abstract getColumn: unit -> Range option
            abstract getLocationType: unit -> DeveloperMetadataLocationType
            abstract getRow: unit -> Range option
            abstract getSheet: unit -> Sheet option
            abstract getSpreadsheet: unit -> Spreadsheet option

        /// An enumeration of the types of developer metadata location types.
        type [<RequireQualifiedAccess>] DeveloperMetadataLocationType =
            | SPREADSHEET = 0
            | SHEET = 1
            | ROW = 2
            | COLUMN = 3

        /// An enumeration of the types of developer metadata visibility.
        type [<RequireQualifiedAccess>] DeveloperMetadataVisibility =
            | DOCUMENT = 0
            | PROJECT = 1

        /// An enumeration of possible directions along which data can be stored in a spreadsheet.
        type [<RequireQualifiedAccess>] Dimension =
            | COLUMNS = 0
            | ROWS = 1

        /// An enumeration representing the possible directions that one can move within a spreadsheet using
        /// the arrow keys.
        type [<RequireQualifiedAccess>] Direction =
            | UP = 0
            | DOWN = 1
            | PREVIOUS = 2
            | NEXT = 3

        /// Represents a drawing over a sheet in a spreadsheet.
        type [<AllowNullLiteral>] Drawing =
            abstract getContainerInfo: unit -> ContainerInfo
            abstract getHeight: unit -> Integer
            abstract getOnAction: unit -> string
            abstract getSheet: unit -> Sheet
            abstract getWidth: unit -> Integer
            abstract getZIndex: unit -> float
            abstract remove: unit -> unit
            abstract setHeight: height: Integer -> Drawing
            abstract setOnAction: macroName: string -> Drawing
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> Drawing
            abstract setWidth: width: Integer -> Drawing
            abstract setZIndex: zIndex: float -> Drawing

        /// Builder for area charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedAreaChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedAreaChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedAreaChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedAreaChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedAreaChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            //abstract setPointStyle: style: Charts.PointStyle -> EmbeddedAreaChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedAreaChartBuilder
            abstract setStacked: unit -> EmbeddedAreaChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedAreaChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedAreaChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedAreaChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedAreaChartBuilder
            abstract useLogScale: unit -> EmbeddedAreaChartBuilder

        /// Builder for bar charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedBarChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedBarChartBuilder
            abstract reverseDirection: unit -> EmbeddedBarChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedBarChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedBarChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedBarChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedBarChartBuilder
            abstract setStacked: unit -> EmbeddedBarChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedBarChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedBarChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedBarChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedBarChartBuilder
            abstract useLogScale: unit -> EmbeddedBarChartBuilder

        /// Represents a chart that has been embedded into a spreadsheet.
        /// 
        /// This example shows how to modify an existing chart:
        /// 
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var range = sheet.getRange("A2:B8")
        ///     var chart = sheet.getCharts()[0];
        ///     chart = chart.modify()
        ///         .addRange(range)
        ///         .setOption('title', 'Updated!')
        ///         .setOption('animation.duration', 500)
        ///         .setPosition(2,2,0,0)
        ///         .build();
        ///     sheet.updateChart(chart);
        /// 
        /// This example shows how to create a new chart:
        /// 
        ///     function newChart(range, sheet) {
        ///       var sheet = SpreadsheetApp.getActiveSheet();
        ///       var chartBuilder = sheet.newChart();
        ///       chartBuilder.addRange(range)
        ///           .setChartType(Charts.ChartType.LINE)
        ///           .setOption('title', 'My Line Chart!');
        ///       sheet.insertChart(chartBuilder.build());
        ///     }
        type [<AllowNullLiteral>] EmbeddedChart =
            //abstract getAs: contentType: string -> Base.Blob
            //abstract getBlob: unit -> Base.Blob
            abstract getChartId: unit -> Integer option
            abstract getContainerInfo: unit -> ContainerInfo
            //abstract getHiddenDimensionStrategy: unit -> Charts.ChartHiddenDimensionStrategy
            //abstract getMergeStrategy: unit -> Charts.ChartMergeStrategy
            abstract getNumHeaders: unit -> Integer
            //abstract getOptions: unit -> Charts.ChartOptions
            abstract getRanges: unit -> ResizeArray<Range>
            abstract getTransposeRowsAndColumns: unit -> bool
            abstract modify: unit -> EmbeddedChartBuilder

        /// Builder used to edit an EmbeddedChart. Changes made to the chart are not saved until
        /// Sheet.updateChart(chart) is called on the rebuilt chart.
        /// 
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var range = sheet.getRange("A1:B8");
        ///     var chart = sheet.getCharts()[0];
        ///     chart = chart.modify()
        ///         .addRange(range)
        ///         .setOption('title', 'Updated!')
        ///         .setOption('animation.duration', 500)
        ///         .setPosition(2,2,0,0)
        ///         .build();
        ///     sheet.updateChart(chart);
        type [<AllowNullLiteral>] EmbeddedChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            //abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder

        /// Builder for column charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedColumnChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedColumnChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedColumnChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedColumnChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedColumnChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedColumnChartBuilder
            abstract setStacked: unit -> EmbeddedColumnChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedColumnChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedColumnChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedColumnChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedColumnChartBuilder
            abstract useLogScale: unit -> EmbeddedColumnChartBuilder

        /// Builder for combo charts. For more details, see the Gviz documentation.
        type [<AllowNullLiteral>] EmbeddedComboChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedComboChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedComboChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedComboChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedComboChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedComboChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedComboChartBuilder
            abstract setStacked: unit -> EmbeddedComboChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedComboChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedComboChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedComboChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedComboChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedComboChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedComboChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedComboChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedComboChartBuilder
            abstract useLogScale: unit -> EmbeddedComboChartBuilder

        /// Builder for histogram charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedHistogramChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedHistogramChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedHistogramChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedHistogramChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedHistogramChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedHistogramChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedHistogramChartBuilder
            abstract setStacked: unit -> EmbeddedHistogramChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedHistogramChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedHistogramChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedHistogramChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedHistogramChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedHistogramChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedHistogramChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedHistogramChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedHistogramChartBuilder
            abstract useLogScale: unit -> EmbeddedHistogramChartBuilder

        /// Builder for line charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedLineChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedLineChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedLineChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedLineChartBuilder
            //abstract setCurveStyle: style: Charts.CurveStyle -> EmbeddedLineChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedLineChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            //abstract setPointStyle: style: Charts.PointStyle -> EmbeddedLineChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setRange: start: float * ``end``: float -> EmbeddedLineChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedLineChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedLineChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedLineChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedLineChartBuilder
            abstract useLogScale: unit -> EmbeddedLineChartBuilder

        /// Builder for pie charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedPieChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract reverseCategories: unit -> EmbeddedPieChartBuilder
            abstract set3D: unit -> EmbeddedPieChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedPieChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedPieChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedPieChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedPieChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedPieChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedPieChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder

        /// Builder for scatter charts. For more details, see the Gviz
        /// documentation.
        type [<AllowNullLiteral>] EmbeddedScatterChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            abstract setBackgroundColor: cssValue: string -> EmbeddedScatterChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setColors: cssValues: ResizeArray<string> -> EmbeddedScatterChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            //abstract setLegendPosition: position: Charts.Position -> EmbeddedScatterChartBuilder
            //abstract setLegendTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            //abstract setPointStyle: style: Charts.PointStyle -> EmbeddedScatterChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setTitle: chartTitle: string -> EmbeddedScatterChartBuilder
            //abstract setTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            abstract setXAxisLogScale: unit -> EmbeddedScatterChartBuilder
            abstract setXAxisRange: start: float * ``end``: float -> EmbeddedScatterChartBuilder
            //abstract setXAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setXAxisTitle: title: string -> EmbeddedScatterChartBuilder
            //abstract setXAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setYAxisLogScale: unit -> EmbeddedScatterChartBuilder
            abstract setYAxisRange: start: float * ``end``: float -> EmbeddedScatterChartBuilder
            //abstract setYAxisTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder
            abstract setYAxisTitle: title: string -> EmbeddedScatterChartBuilder
            //abstract setYAxisTitleTextStyle: textStyle: Charts.TextStyle -> EmbeddedScatterChartBuilder

        /// Builder for table charts. For more details, see the Gviz documentation.
        type [<AllowNullLiteral>] EmbeddedTableChartBuilder =
            abstract addRange: range: Range -> EmbeddedChartBuilder
            abstract asAreaChart: unit -> EmbeddedAreaChartBuilder
            abstract asBarChart: unit -> EmbeddedBarChartBuilder
            abstract asColumnChart: unit -> EmbeddedColumnChartBuilder
            abstract asComboChart: unit -> EmbeddedComboChartBuilder
            abstract asHistogramChart: unit -> EmbeddedHistogramChartBuilder
            abstract asLineChart: unit -> EmbeddedLineChartBuilder
            abstract asPieChart: unit -> EmbeddedPieChartBuilder
            abstract asScatterChart: unit -> EmbeddedScatterChartBuilder
            abstract asTableChart: unit -> EmbeddedTableChartBuilder
            abstract build: unit -> EmbeddedChart
            abstract clearRanges: unit -> EmbeddedChartBuilder
            abstract enablePaging: enablePaging: bool -> EmbeddedTableChartBuilder
            abstract enablePaging: pageSize: Integer -> EmbeddedTableChartBuilder
            abstract enablePaging: pageSize: Integer * startPage: Integer -> EmbeddedTableChartBuilder
            abstract enableRtlTable: rtlEnabled: bool -> EmbeddedTableChartBuilder
            abstract enableSorting: enableSorting: bool -> EmbeddedTableChartBuilder
            //abstract getChartType: unit -> Charts.ChartType
            abstract getContainer: unit -> ContainerInfo
            abstract getRanges: unit -> ResizeArray<Range>
            abstract removeRange: range: Range -> EmbeddedChartBuilder
            //abstract setChartType: ``type``: Charts.ChartType -> EmbeddedChartBuilder
            abstract setFirstRowNumber: number: Integer -> EmbeddedTableChartBuilder
            //abstract setHiddenDimensionStrategy: strategy: Charts.ChartHiddenDimensionStrategy -> EmbeddedChartBuilder
            abstract setInitialSortingAscending: column: Integer -> EmbeddedTableChartBuilder
            abstract setInitialSortingDescending: column: Integer -> EmbeddedTableChartBuilder
            //abstract setMergeStrategy: mergeStrategy: Charts.ChartMergeStrategy -> EmbeddedChartBuilder
            abstract setNumHeaders: headers: Integer -> EmbeddedChartBuilder
            abstract setOption: option: string * value: obj option -> EmbeddedChartBuilder
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> EmbeddedChartBuilder
            abstract setTransposeRowsAndColumns: transpose: bool -> EmbeddedChartBuilder
            abstract showRowNumberColumn: showRowNumber: bool -> EmbeddedTableChartBuilder
            abstract useAlternatingRowStyle: alternate: bool -> EmbeddedTableChartBuilder

        /// Access and modify existing filters. To create a new filter, use Range.createFilter().
        type [<AllowNullLiteral>] Filter =
            abstract getColumnFilterCriteria: columnPosition: Integer -> FilterCriteria option
            abstract getRange: unit -> Range
            abstract remove: unit -> unit
            abstract removeColumnFilterCriteria: columnPosition: Integer -> Filter
            abstract setColumnFilterCriteria: columnPosition: Integer * filterCriteria: FilterCriteria option -> Filter
            abstract sort: columnPosition: Integer * ascending: bool -> Filter

        /// Access filter criteria. To create a new criteria, use SpreadsheetApp.newFilterCriteria() and FilterCriteriaBuilder.
        type [<AllowNullLiteral>] FilterCriteria =
            abstract copy: unit -> FilterCriteriaBuilder
            abstract getCriteriaType: unit -> BooleanCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj option>
            abstract getHiddenValues: unit -> ResizeArray<string>
            abstract getVisibleValues: unit -> ResizeArray<string>

        /// Builder for FilterCriteria.
        type [<AllowNullLiteral>] FilterCriteriaBuilder =
            abstract build: unit -> FilterCriteria
            abstract copy: unit -> FilterCriteriaBuilder
            abstract getCriteriaType: unit -> BooleanCriteria
            abstract getCriteriaValues: unit -> ResizeArray<obj option>
            abstract getHiddenValues: unit -> ResizeArray<string>
            abstract getVisibleValues: unit -> ResizeArray<string>
            abstract setHiddenValues: values: ResizeArray<string> -> FilterCriteriaBuilder
            abstract setVisibleValues: values: ResizeArray<string> -> FilterCriteriaBuilder
            abstract whenCellEmpty: unit -> FilterCriteriaBuilder
            abstract whenCellNotEmpty: unit -> FilterCriteriaBuilder
            abstract whenDateAfter: date: Base.Date -> FilterCriteriaBuilder
            abstract whenDateAfter: date: RelativeDate -> FilterCriteriaBuilder
            abstract whenDateBefore: date: Base.Date -> FilterCriteriaBuilder
            abstract whenDateBefore: date: RelativeDate -> FilterCriteriaBuilder
            abstract whenDateEqualTo: date: Base.Date -> FilterCriteriaBuilder
            abstract whenDateEqualTo: date: RelativeDate -> FilterCriteriaBuilder
            abstract whenFormulaSatisfied: formula: string -> FilterCriteriaBuilder
            abstract whenNumberBetween: start: float * ``end``: float -> FilterCriteriaBuilder
            abstract whenNumberEqualTo: number: float -> FilterCriteriaBuilder
            abstract whenNumberGreaterThan: number: float -> FilterCriteriaBuilder
            abstract whenNumberGreaterThanOrEqualTo: number: float -> FilterCriteriaBuilder
            abstract whenNumberLessThan: number: float -> FilterCriteriaBuilder
            abstract whenNumberLessThanOrEqualTo: number: float -> FilterCriteriaBuilder
            abstract whenNumberNotBetween: start: float * ``end``: float -> FilterCriteriaBuilder
            abstract whenNumberNotEqualTo: number: float -> FilterCriteriaBuilder
            abstract whenTextContains: text: string -> FilterCriteriaBuilder
            abstract whenTextDoesNotContain: text: string -> FilterCriteriaBuilder
            abstract whenTextEndsWith: text: string -> FilterCriteriaBuilder
            abstract whenTextEqualTo: text: string -> FilterCriteriaBuilder
            abstract whenTextStartsWith: text: string -> FilterCriteriaBuilder
            abstract withCriteria: criteria: BooleanCriteria * args: ResizeArray<obj option> -> FilterCriteriaBuilder

        /// Access gradient (color) conditions in ConditionalFormatRuleApis.
        /// Each conditional format rule may contain a single gradient condition. A gradient condition is
        /// defined by three points along a number scale (min, mid, and max), each of which has a color, a
        /// value, and a InterpolationType. The content of a cell is
        /// compared to the values in the number scale and the color applied to the cell is interpolated
        /// based on the cell content's proximity to the gradient condition min, mid, and max points.
        /// 
        ///     // Logs all the information inside gradient conditional format rules on a sheet.
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var rules = sheet.getConditionalFormatRules();
        ///     for (int i = 0; i < rules.length; i++) {
        ///       var gradient = rules[i].getGradientCondition();
        ///       Logger.log("The conditional format gradient information for rule %d:\n
        ///         MinColor %s, MinType %s, MinValue %s, \n
        ///         MidColor %s, MidType %s, MidValue %s, \n
        ///         MaxColor %s, MaxType %s, MaxValue %s \n", i,
        ///         gradient.getMinColor(), gradient.getMinType(), gradient.getMinValue(),
        ///         gradient.getMidColor(), gradient.getMidType(), gradient.getMidValue(),
        ///         gradient.getMaxColor(), gradient.getMaxType(), gradient.getMaxValue());
        ///     }
        type [<AllowNullLiteral>] GradientCondition =
            abstract getMaxColor: unit -> string
            abstract getMaxType: unit -> InterpolationType option
            abstract getMaxValue: unit -> string
            abstract getMidColor: unit -> string
            abstract getMidType: unit -> InterpolationType option
            abstract getMidValue: unit -> string
            abstract getMinColor: unit -> string
            abstract getMinType: unit -> InterpolationType option
            abstract getMinValue: unit -> string

        /// Access and modify spreadsheet groups. Groups are an association between an interval of contiguous
        /// rows or columns that can be expanded or collapsed as a unit to hide/show the rows or columns.
        /// Each group has a control toggle on the row or column directly before or after the group
        /// (depending on settings) that can expand or collapse the group as a whole.
        /// 
        /// The depth of a group refers to the nested position of the group and how many larger
        /// groups contain the group. The collapsed state of a group refers to whether the group
        /// should remain collapsed or expanded after a parent group has been expanded. Additionally, at the
        /// time that a group is collapsed or expanded, the rows or columns within the group are hidden or
        /// set visible, though individual rows or columns can be hidden or set visible irrespective of the
        /// collapsed state.
        type [<AllowNullLiteral>] Group =
            abstract collapse: unit -> Group
            abstract expand: unit -> Group
            abstract getControlIndex: unit -> Integer
            abstract getDepth: unit -> Integer
            abstract getRange: unit -> Range
            abstract isCollapsed: unit -> bool
            abstract remove: unit -> unit

        /// An enumeration representing the possible positions that a group control toggle can have.
        type [<RequireQualifiedAccess>] GroupControlTogglePosition =
            | BEFORE = 0
            | AFTER = 1

        /// An enumeration representing the interpolation options for calculating a value to be used in a
        /// GradientCondition in a ConditionalFormatRule.
        type [<RequireQualifiedAccess>] InterpolationType =
            | NUMBER = 0
            | PERCENT = 1
            | PERCENTILE = 2
            | MIN = 3
            | MAX = 4

        /// Create, access and modify named ranges in a spreadsheet. Named ranges are ranges that have
        /// associated string aliases. They can be viewed and edited via the Sheets UI under the Data >
        /// Named ranges... menu.
        type [<AllowNullLiteral>] NamedRange =
            abstract getName: unit -> string
            abstract getRange: unit -> Range
            abstract remove: unit -> unit
            abstract setName: name: string -> NamedRange
            abstract setRange: range: Range -> NamedRange

        /// Represents an image over the grid in a spreadsheet.
        type [<AllowNullLiteral>] OverGridImage =
            abstract assignScript: functionName: string -> OverGridImage
            abstract getAltTextDescription: unit -> string
            abstract getAltTextTitle: unit -> string
            abstract getAnchorCell: unit -> Range
            abstract getAnchorCellXOffset: unit -> Integer
            abstract getAnchorCellYOffset: unit -> Integer
            abstract getHeight: unit -> Integer
            abstract getInherentHeight: unit -> Integer
            abstract getInherentWidth: unit -> Integer
            abstract getScript: unit -> string
            abstract getSheet: unit -> Sheet
            abstract getUrl: unit -> string option
            abstract getWidth: unit -> Integer
            abstract remove: unit -> unit
            //abstract replace: blob: Base.BlobSource -> OverGridImage
            abstract replace: url: string -> OverGridImage
            abstract resetSize: unit -> OverGridImage
            abstract setAltTextDescription: description: string -> OverGridImage
            abstract setAltTextTitle: title: string -> OverGridImage
            abstract setAnchorCell: cell: Range -> OverGridImage
            abstract setAnchorCellXOffset: offset: Integer -> OverGridImage
            abstract setAnchorCellYOffset: offset: Integer -> OverGridImage
            abstract setHeight: height: Integer -> OverGridImage
            abstract setWidth: width: Integer -> OverGridImage

        /// Deprecated. For spreadsheets created in the newer version of Google Sheets, use the more powerful
        ///     Protection class instead. Although this class is deprecated, it remains available
        ///     for compatibility with the older version of Sheets.
        /// Access and modify protected sheets in the older version of Google Sheets.
        type [<AllowNullLiteral>] PageProtection =
            [<Obsolete("DO NOT USE")>]
            abstract addUser: email: string -> unit
            [<Obsolete("DO NOT USE")>]
            abstract getUsers: unit -> ResizeArray<string>
            [<Obsolete("DO NOT USE")>]
            abstract isProtected: unit -> bool
            [<Obsolete("DO NOT USE")>]
            abstract removeUser: user: string -> unit
            [<Obsolete("DO NOT USE")>]
            abstract setProtected: protection: bool -> unit

        /// Access and modify pivot table filters.
        type [<AllowNullLiteral>] PivotFilter =
            abstract getFilterCriteria: unit -> FilterCriteria
            abstract getPivotTable: unit -> PivotTable
            abstract getSourceDataColumn: unit -> Integer
            abstract remove: unit -> unit
            abstract setFilterCriteria: filterCriteria: FilterCriteria -> PivotFilter

        /// Access and modify pivot table breakout groups.
        type [<AllowNullLiteral>] PivotGroup =
            abstract addManualGroupingRule: groupName: string * groupMembers: ResizeArray<obj option> -> PivotGroup
            abstract areLabelsRepeated: unit -> bool
            abstract clearGroupingRule: unit -> PivotGroup
            abstract clearSort: unit -> PivotGroup
            abstract getDimension: unit -> Dimension
            abstract getIndex: unit -> Integer
            abstract getPivotTable: unit -> PivotTable
            abstract getSourceDataColumn: unit -> Integer
            abstract hideRepeatedLabels: unit -> PivotGroup
            abstract isSortAscending: unit -> bool
            abstract moveToIndex: index: Integer -> PivotGroup
            abstract remove: unit -> unit
            abstract removeManualGroupingRule: groupName: string -> PivotGroup
            abstract resetDisplayName: unit -> PivotGroup
            abstract setDisplayName: name: string -> PivotGroup
            abstract setHistogramGroupingRule: minValue: Integer * maxValue: Integer * intervalSize: Integer -> PivotGroup
            abstract showRepeatedLabels: unit -> PivotGroup
            abstract showTotals: showTotals: bool -> PivotGroup
            abstract sortAscending: unit -> PivotGroup
            abstract sortBy: value: PivotValue * oppositeGroupValues: ResizeArray<obj option> -> PivotGroup
            abstract sortDescending: unit -> PivotGroup
            abstract totalsAreShown: unit -> bool

        /// Access and modify pivot tables.
        type [<AllowNullLiteral>] PivotTable =
            abstract addCalculatedPivotValue: name: string * formula: string -> PivotValue
            abstract addColumnGroup: sourceDataColumn: Integer -> PivotGroup
            abstract addFilter: sourceDataColumn: Integer * filterCriteria: FilterCriteria -> PivotFilter
            abstract addPivotValue: sourceDataColumn: Integer * summarizeFunction: PivotTableSummarizeFunction -> PivotValue
            abstract addRowGroup: sourceDataColumn: Integer -> PivotGroup
            abstract getAnchorCell: unit -> Range
            abstract getColumnGroups: unit -> ResizeArray<PivotGroup>
            abstract getFilters: unit -> ResizeArray<PivotFilter>
            abstract getPivotValues: unit -> ResizeArray<PivotValue>
            abstract getRowGroups: unit -> ResizeArray<PivotGroup>
            abstract getValuesDisplayOrientation: unit -> Dimension
            abstract remove: unit -> unit
            abstract setValuesDisplayOrientation: dimension: Dimension -> PivotTable

        /// An enumeration of functions that summarize pivot table data.
        type [<RequireQualifiedAccess>] PivotTableSummarizeFunction =
            | CUSTOM = 0
            | SUM = 1
            | COUNTA = 2
            | COUNT = 3
            | COUNTUNIQUE = 4
            | AVERAGE = 5
            | MAX = 6
            | MIN = 7
            | MEDIAN = 8
            | PRODUCT = 9
            | STDEV = 10
            | STDEVP = 11
            | VAR = 12
            | VARP = 13

        /// Access and modify value groups in pivot tables.
        type [<AllowNullLiteral>] PivotValue =
            abstract getDisplayType: unit -> PivotValueDisplayType
            abstract getFormula: unit -> string option
            abstract getPivotTable: unit -> PivotTable
            abstract getSummarizedBy: unit -> PivotTableSummarizeFunction
            abstract setDisplayName: name: string -> PivotValue
            abstract setFormula: formula: string -> PivotValue
            abstract showAs: displayType: PivotValueDisplayType -> PivotValue
            abstract summarizeBy: summarizeFunction: PivotTableSummarizeFunction -> PivotValue

        /// An enumeration of ways to display a pivot value as a function of another value.
        type [<RequireQualifiedAccess>] PivotValueDisplayType =
            | DEFAULT = 0
            | PERCENT_OF_ROW_TOTAL = 1
            | PERCENT_OF_COLUMN_TOTAL = 2
            | PERCENT_OF_GRAND_TOTAL = 3

        /// Access and modify protected ranges and sheets. A protected range can protect either a static
        /// range of cells or a named range. A protected sheet may include unprotected regions. For
        /// spreadsheets created with the older version of Google Sheets, use the PageProtection
        /// class instead.
        /// 
        ///     // Protect range A1:B10, then remove all other users from the list of editors.
        ///     var ss = SpreadsheetApp.getActive();
        ///     var range = ss.getRange('A1:B10');
        ///     var protection = range.protect().setDescription('Sample protected range');
        /// 
        ///     // Ensure the current user is an editor before removing others. Otherwise, if the user's edit
        ///     // permission comes from a group, the script throws an exception upon removing the group.
        ///     var me = Session.getEffectiveUser();
        ///     protection.addEditor(me);
        ///     protection.removeEditors(protection.getEditors());
        ///     if (protection.canDomainEdit()) {
        ///       protection.setDomainEdit(false);
        ///     }
        /// 
        ///     // Remove all range protections in the spreadsheet that the user has permission to edit.
        ///     var ss = SpreadsheetApp.getActive();
        ///     var protections = ss.getProtections(SpreadsheetApp.ProtectionType.RANGE);
        ///     for (var i = 0; i < protections.length; i++) {
        ///       var protection = protections[i];
        ///       if (protection.canEdit()) {
        ///         protection.remove();
        ///       }
        ///     }
        /// 
        ///     // Protect the active sheet, then remove all other users from the list of editors.
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var protection = sheet.protect().setDescription('Sample protected sheet');
        /// 
        ///     // Ensure the current user is an editor before removing others. Otherwise, if the user's edit
        ///     // permission comes from a group, the script throws an exception upon removing the group.
        ///     var me = Session.getEffectiveUser();
        ///     protection.addEditor(me);
        ///     protection.removeEditors(protection.getEditors());
        ///     if (protection.canDomainEdit()) {
        ///       protection.setDomainEdit(false);
        ///     }
        type [<AllowNullLiteral>] Protection =
            abstract addEditor: emailAddress: string -> Protection
            //abstract addEditor: user: Base.User -> Protection
            abstract addEditors: emailAddresses: ResizeArray<string> -> Protection
            abstract canDomainEdit: unit -> bool
            abstract canEdit: unit -> bool
            abstract getDescription: unit -> string
            //abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getProtectionType: unit -> ProtectionType
            abstract getRange: unit -> Range
            abstract getRangeName: unit -> string option
            abstract getUnprotectedRanges: unit -> ResizeArray<Range>
            abstract isWarningOnly: unit -> bool
            abstract remove: unit -> unit
            abstract removeEditor: emailAddress: string -> Protection
            //abstract removeEditor: user: Base.User -> Protection
            abstract removeEditors: emailAddresses: ResizeArray<string> -> Protection
            //abstract removeEditors: users: ResizeArray<Base.User> -> Protection
            abstract setDescription: description: string -> Protection
            abstract setDomainEdit: editable: bool -> Protection
            abstract setNamedRange: namedRange: NamedRange -> Protection
            abstract setRange: range: Range -> Protection
            abstract setRangeName: rangeName: string -> Protection
            abstract setUnprotectedRanges: ranges: ResizeArray<Range> -> Protection
            abstract setWarningOnly: warningOnly: bool -> Protection

        /// An enumeration representing the parts of a spreadsheet that can be protected from edits.
        /// 
        ///     // Remove all range protections in the spreadsheet that the user has permission to edit.
        ///     var ss = SpreadsheetApp.getActive();
        ///     var protections = ss.getProtections(SpreadsheetApp.ProtectionType.RANGE);
        ///     for (var i = 0; i < protections.length; i++) {
        ///       var protection = protections[i];
        ///       if (protection.canEdit()) {
        ///         protection.remove();
        ///       }
        ///     }
        /// 
        ///     // Removes sheet protection from the active sheet, if the user has permission to edit it.
        ///     var sheet = SpreadsheetApp.getActiveSheet();
        ///     var protection = sheet.getProtections(SpreadsheetApp.ProtectionType.SHEET)[0];
        ///     if (protection && protection.canEdit()) {
        ///       protection.remove();
        ///     }
        type [<RequireQualifiedAccess>] ProtectionType =
            | RANGE = 0
            | SHEET = 1

        type [<StringEnum>] [<RequireQualifiedAccess>] FontLine =
            | None
            | Underline
            | [<CompiledName("line-through")>] LineThrough

        type [<StringEnum>] [<RequireQualifiedAccess>] FontStyle =
            | Normal
            | Italic

        type [<StringEnum>] [<RequireQualifiedAccess>] FontWeight =
            | Normal
            | Bold

        /// Access and modify spreadsheet ranges. A range can be a single cell in a sheet or a group of
        /// adjacent cells in a sheet.
        type [<AllowNullLiteral>] Range =
            abstract activate: unit -> Range
            abstract activateAsCurrentCell: unit -> Range
            abstract addDeveloperMetadata: key: string -> Range
            abstract addDeveloperMetadata: key: string * visibility: DeveloperMetadataVisibility -> Range
            abstract addDeveloperMetadata: key: string * value: string -> Range
            abstract addDeveloperMetadata: key: string * value: string * visibility: DeveloperMetadataVisibility -> Range
            abstract applyColumnBanding: unit -> Banding
            abstract applyColumnBanding: bandingTheme: BandingTheme -> Banding
            abstract applyColumnBanding: bandingTheme: BandingTheme * showHeader: bool * showFooter: bool -> Banding
            abstract applyRowBanding: unit -> Banding
            abstract applyRowBanding: bandingTheme: BandingTheme -> Banding
            abstract applyRowBanding: bandingTheme: BandingTheme * showHeader: bool * showFooter: bool -> Banding
            abstract autoFill: destination: Range * series: AutoFillSeries -> unit
            abstract autoFillToNeighbor: series: AutoFillSeries -> unit
            abstract breakApart: unit -> Range
            abstract canEdit: unit -> bool
            abstract check: unit -> Range
            abstract clear: unit -> Range
            abstract clear: options: RangeClearOptions -> Range
            abstract clearContent: unit -> Range
            abstract clearDataValidations: unit -> Range
            abstract clearFormat: unit -> Range
            abstract clearNote: unit -> Range
            abstract collapseGroups: unit -> Range
            abstract copyFormatToRange: gridId: Integer * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract copyFormatToRange: sheet: Sheet * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract copyTo: destination: Range -> unit
            abstract copyTo: destination: Range * copyPasteType: CopyPasteType * transposed: bool -> unit
            abstract copyTo: destination: Range * options: {| formatOnly: bool option; contentsOnly: bool option |} -> unit
            abstract copyValuesToRange: gridId: Integer * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract copyValuesToRange: sheet: Sheet * column: Integer * columnEnd: Integer * row: Integer * rowEnd: Integer -> unit
            abstract createDataSourcePivotTable: dataSource: DataSource -> DataSourcePivotTable
            abstract createDataSourceTable: dataSource: DataSource -> DataSourceTable
            abstract createDeveloperMetadataFinder: unit -> DeveloperMetadataFinder
            abstract createFilter: unit -> Filter
            abstract createPivotTable: sourceData: Range -> PivotTable
            abstract createTextFinder: findText: string -> TextFinder
            abstract deleteCells: shiftDimension: Dimension -> unit
            abstract expandGroups: unit -> Range
            abstract getA1Notation: unit -> string
            abstract getBackground: unit -> string
            abstract getBackgroundObject: unit -> Color
            abstract getBackgroundObjects: unit -> ResizeArray<ResizeArray<Color>>
            abstract getBackgrounds: unit -> ResizeArray<ResizeArray<string>>
            abstract getBandings: unit -> ResizeArray<Banding>
            abstract getCell: row: Integer * column: Integer -> Range
            abstract getColumn: unit -> Integer
            abstract getDataRegion: unit -> Range
            abstract getDataRegion: dimension: Dimension -> Range
            abstract getDataSourceFormula: unit -> DataSourceFormula
            abstract getDataSourceFormulas: unit -> ResizeArray<DataSourceFormula>
            abstract getDataSourcePivotTables: unit -> ResizeArray<DataSourcePivotTable>
            abstract getDataSourceTables: unit -> ResizeArray<DataSourceTable>
            abstract getDataSourceUrl: unit -> string
            //abstract getDataTable: unit -> Charts.DataTable
            //abstract getDataTable: firstRowIsHeader: bool -> Charts.DataTable
            abstract getDataValidation: unit -> DataValidation option
            abstract getDataValidations: unit -> Array<Array<DataValidation option>>
            abstract getDeveloperMetadata: unit -> ResizeArray<DeveloperMetadata>
            abstract getDisplayValue: unit -> string
            abstract getDisplayValues: unit -> ResizeArray<ResizeArray<string>>
            abstract getFilter: unit -> Filter option
            [<Obsolete("Deprecated, use getFontColorObject")>]
            abstract getFontColor: unit -> string
            [<Obsolete("Deprecated, use getFontColorObjects")>]
            abstract getFontColors: unit -> ResizeArray<ResizeArray<string>>
            abstract getFontColorObject: unit -> Color
            abstract getFontColorObjects: unit -> ResizeArray<ResizeArray<Color>>
            abstract getFontFamilies: unit -> ResizeArray<ResizeArray<string>>
            abstract getFontFamily: unit -> string
            abstract getFontLine: unit -> FontLine
            abstract getFontLines: unit -> ResizeArray<ResizeArray<FontLine>>
            abstract getFontSize: unit -> Integer
            abstract getFontSizes: unit -> ResizeArray<ResizeArray<Integer>>
            abstract getFontStyle: unit -> FontStyle
            abstract getFontStyles: unit -> ResizeArray<ResizeArray<FontStyle>>
            abstract getFontWeight: unit -> FontWeight
            abstract getFontWeights: unit -> ResizeArray<ResizeArray<FontWeight>>
            abstract getFormula: unit -> string
            abstract getFormulaR1C1: unit -> string option
            abstract getFormulas: unit -> ResizeArray<ResizeArray<string>>
            abstract getFormulasR1C1: unit -> Array<Array<string option>>
            abstract getGridId: unit -> Integer
            abstract getHeight: unit -> Integer
            abstract getHorizontalAlignment: unit -> string
            abstract getHorizontalAlignments: unit -> ResizeArray<ResizeArray<string>>
            abstract getLastColumn: unit -> Integer
            abstract getLastRow: unit -> Integer
            abstract getMergedRanges: unit -> ResizeArray<Range>
            abstract getNextDataCell: direction: Direction -> Range
            abstract getNote: unit -> string
            abstract getNotes: unit -> ResizeArray<ResizeArray<string>>
            abstract getNumColumns: unit -> Integer
            abstract getNumRows: unit -> Integer
            abstract getNumberFormat: unit -> string
            abstract getNumberFormats: unit -> ResizeArray<ResizeArray<string>>
            abstract getRichTextValue: unit -> RichTextValue option
            abstract getRichTextValues: unit -> Array<Array<RichTextValue option>>
            abstract getRow: unit -> Integer
            abstract getRowIndex: unit -> Integer
            abstract getSheet: unit -> Sheet
            abstract getTextDirection: unit -> TextDirection option
            abstract getTextDirections: unit -> Array<Array<TextDirection option>>
            abstract getTextRotation: unit -> TextRotation
            abstract getTextRotations: unit -> ResizeArray<ResizeArray<TextRotation>>
            abstract getTextStyle: unit -> TextStyle
            abstract getTextStyles: unit -> ResizeArray<ResizeArray<TextStyle>>
            abstract getValue: unit -> obj option
            abstract getValues: unit -> ResizeArray<ResizeArray<obj option>>
            abstract getVerticalAlignment: unit -> string
            abstract getVerticalAlignments: unit -> ResizeArray<ResizeArray<string>>
            abstract getWidth: unit -> Integer
            abstract getWrap: unit -> bool
            abstract getWrapStrategies: unit -> ResizeArray<ResizeArray<WrapStrategy>>
            abstract getWrapStrategy: unit -> WrapStrategy
            abstract getWraps: unit -> ResizeArray<ResizeArray<bool>>
            abstract insertCells: shiftDimension: Dimension -> Range
            abstract insertCheckboxes: unit -> Range
            abstract insertCheckboxes: checkedValue: obj option -> Range
            abstract insertCheckboxes: checkedValue: obj option * uncheckedValue: obj option -> Range
            abstract isBlank: unit -> bool
            abstract isChecked: unit -> bool option
            abstract isEndColumnBounded: unit -> bool
            abstract isEndRowBounded: unit -> bool
            abstract isPartOfMerge: unit -> bool
            abstract isStartColumnBounded: unit -> bool
            abstract isStartRowBounded: unit -> bool
            abstract merge: unit -> Range
            abstract mergeAcross: unit -> Range
            abstract mergeVertically: unit -> Range
            abstract moveTo: target: Range -> unit
            abstract offset: rowOffset: Integer * columnOffset: Integer -> Range
            abstract offset: rowOffset: Integer * columnOffset: Integer * numRows: Integer -> Range
            abstract offset: rowOffset: Integer * columnOffset: Integer * numRows: Integer * numColumns: Integer -> Range
            abstract protect: unit -> Protection
            abstract randomize: unit -> Range
            abstract removeCheckboxes: unit -> Range
            abstract removeDuplicates: unit -> Range
            abstract removeDuplicates: columnsToCompare: ResizeArray<Integer> -> Range
            abstract setBackground: color: string option -> Range
            abstract setBackgroundObject: color: Color option -> Range
            abstract setBackgroundObjects: color: ResizeArray<ResizeArray<Color>> option -> Range
            abstract setBackgroundRGB: red: Integer * green: Integer * blue: Integer -> Range
            abstract setBackgrounds: color: Array<Array<string option>> -> Range
            abstract setBorder: top: bool option * left: bool option * bottom: bool option * right: bool option * vertical: bool option * horizontal: bool option -> Range
            abstract setBorder: top: bool option * left: bool option * bottom: bool option * right: bool option * vertical: bool option * horizontal: bool option * color: string option * style: BorderStyle option -> Range
            abstract setDataValidation: rule: DataValidation option -> Range
            abstract setDataValidations: rules: Array<Array<DataValidation option>> -> Range
            abstract setFontColor: color: string option -> Range
            abstract setFontColorObject: color: Color option -> Range
            abstract setFontColorObjects: colors: Array<Array<Color option>> -> Range
            abstract setFontColors: colors: ResizeArray<ResizeArray<obj option>> -> Range
            abstract setFontFamilies: fontFamilies: Array<Array<string option>> -> Range
            abstract setFontFamily: fontFamily: string option -> Range
            abstract setFontLine: fontLine: FontLine option -> Range
            abstract setFontLines: fontLines: Array<Array<FontLine option>> -> Range
            abstract setFontSize: size: Integer -> Range
            abstract setFontSizes: sizes: ResizeArray<ResizeArray<Integer>> -> Range
            abstract setFontStyle: fontStyle: FontStyle option -> Range
            abstract setFontStyles: fontStyles: Array<Array<FontStyle option>> -> Range
            abstract setFontWeight: fontWeight: FontWeight option -> Range
            abstract setFontWeights: fontWeights: Array<Array<FontWeight option>> -> Range
            abstract setFormula: formula: string -> Range
            abstract setFormulaR1C1: formula: string -> Range
            abstract setFormulas: formulas: ResizeArray<ResizeArray<string>> -> Range
            abstract setFormulasR1C1: formulas: ResizeArray<ResizeArray<string>> -> Range
            abstract setHorizontalAlignment: alignment: RangeSetHorizontalAlignment -> Range
            abstract setHorizontalAlignments: alignments: Array<Array<RangeSetHorizontalAlignment>> -> Range
            abstract setNote: note: string option -> Range
            abstract setNotes: notes: Array<Array<string option>> -> Range
            abstract setNumberFormat: numberFormat: string -> Range
            abstract setNumberFormats: numberFormats: ResizeArray<ResizeArray<string>> -> Range
            abstract setRichTextValue: value: RichTextValue -> Range
            abstract setRichTextValues: values: ResizeArray<ResizeArray<RichTextValue>> -> Range
            abstract setShowHyperlink: showHyperlink: bool -> Range
            abstract setTextDirection: direction: TextDirection option -> Range
            abstract setTextDirections: directions: Array<Array<TextDirection option>> -> Range
            abstract setTextRotation: degrees: Integer -> Range
            abstract setTextRotation: rotation: TextRotation -> Range
            abstract setTextRotations: rotations: ResizeArray<ResizeArray<TextRotation>> -> Range
            abstract setTextStyle: style: TextStyle -> Range
            abstract setTextStyles: styles: ResizeArray<ResizeArray<TextStyle>> -> Range
            abstract setValue: value: obj option -> Range
            abstract setValues: values: ResizeArray<ResizeArray<obj option>> -> Range
            abstract setVerticalAlignment: alignment: RangeSetVerticalAlignment -> Range
            abstract setVerticalAlignments: alignments: Array<Array<RangeSetVerticalAlignment>> -> Range
            abstract setVerticalText: isVertical: bool -> Range
            abstract setWrap: isWrapEnabled: bool -> Range
            abstract setWrapStrategies: strategies: ResizeArray<ResizeArray<WrapStrategy>> -> Range
            abstract setWrapStrategy: strategy: WrapStrategy -> Range
            abstract setWraps: isWrapEnabled: ResizeArray<ResizeArray<bool>> -> Range
            abstract shiftColumnGroupDepth: delta: Integer -> Range
            abstract shiftRowGroupDepth: delta: Integer -> Range
            abstract sort: sortSpecObj: obj option -> Range
            abstract splitTextToColumns: unit -> unit
            abstract splitTextToColumns: delimiter: string -> unit
            abstract splitTextToColumns: delimiter: TextToColumnsDelimiter -> unit
            abstract trimWhitespace: unit -> Range
            abstract uncheck: unit -> Range

        type [<AllowNullLiteral>] RangeClearOptions =
            abstract commentsOnly: bool option with get, set
            abstract contentsOnly: bool option with get, set
            abstract formatOnly: bool option with get, set
            abstract validationsOnly: bool option with get, set
            abstract skipFilteredRows: bool option with get, set

        /// A collection of one or more Range instances in the same sheet. You can use this class
        /// to apply operations on collections of non-adjacent ranges or cells.
        type [<AllowNullLiteral>] RangeList =
            abstract activate: unit -> RangeList
            abstract breakApart: unit -> RangeList
            abstract check: unit -> RangeList
            abstract clear: unit -> RangeList
            abstract clear: options: RangeListClearOptions -> RangeList
            abstract clearContent: unit -> RangeList
            abstract clearDataValidations: unit -> RangeList
            abstract clearFormat: unit -> RangeList
            abstract clearNote: unit -> RangeList
            abstract getRanges: unit -> ResizeArray<Range>
            abstract insertCheckboxes: unit -> RangeList
            abstract insertCheckboxes: checkedValue: obj option -> RangeList
            abstract insertCheckboxes: checkedValue: obj option * uncheckedValue: obj option -> RangeList
            abstract removeCheckboxes: unit -> RangeList
            abstract setBackground: color: string option -> RangeList
            abstract setBackgroundRGB: red: Integer * green: Integer * blue: Integer -> RangeList
            abstract setBorder: top: bool option * left: bool option * bottom: bool option * right: bool option * vertical: bool option * horizontal: bool option -> RangeList
            abstract setBorder: top: bool option * left: bool option * bottom: bool option * right: bool option * vertical: bool option * horizontal: bool option * color: string option * style: BorderStyle option -> RangeList
            abstract setFontColor: color: string option -> RangeList
            abstract setFontFamily: fontFamily: string option -> RangeList
            abstract setFontLine: fontLine: FontLine option -> RangeList
            abstract setFontSize: size: Integer -> RangeList
            abstract setFontStyle: fontStyle: FontStyle option -> RangeList
            abstract setFontWeight: fontWeight: FontWeight option -> RangeList
            abstract setFormula: formula: string -> RangeList
            abstract setFormulaR1C1: formula: string -> RangeList
            abstract setHorizontalAlignment: alignment: RangeSetHorizontalAlignment -> RangeList
            abstract setNote: note: string option -> RangeList
            abstract setNumberFormat: numberFormat: string -> RangeList
            abstract setShowHyperlink: showHyperlink: bool -> RangeList
            abstract setTextDirection: direction: TextDirection option -> RangeList
            abstract setTextRotation: degrees: Integer -> RangeList
            abstract setValue: value: obj option -> RangeList
            abstract setVerticalAlignment: alignment: RangeSetVerticalAlignment -> RangeList
            abstract setVerticalText: isVertical: bool -> RangeList
            abstract setWrap: isWrapEnabled: bool -> RangeList
            abstract setWrapStrategy: strategy: WrapStrategy -> RangeList
            abstract trimWhitespace: unit -> RangeList
            abstract uncheck: unit -> RangeList

        type [<AllowNullLiteral>] RangeListClearOptions =
            abstract commentsOnly: bool option with get, set
            abstract contentsOnly: bool option with get, set
            abstract formatOnly: bool option with get, set
            abstract validationsOnly: bool option with get, set
            abstract skipFilteredRows: bool option with get, set

        /// An enumeration representing the possible intervals used in spreadsheet recalculation.
        type [<RequireQualifiedAccess>] RecalculationInterval =
            | ON_CHANGE = 0
            | MINUTE = 1
            | HOUR = 2

        /// An enumeration representing the relative date options for calculating a value to be used in
        /// date-based BooleanCriteria.
        type [<RequireQualifiedAccess>] RelativeDate =
            | TODAY = 0
            | TOMORROW = 1
            | YESTERDAY = 2
            | PAST_WEEK = 3
            | PAST_MONTH = 4
            | PAST_YEAR = 5

        /// A stylized text string used to represent cell text. Substrings of the text can have different
        /// text styles.
        /// 
        /// A run is the longest unbroken substring having the same text style. For example, the
        /// sentence "This kid has two apples." has four runs: ["This ", "kid ", "has two ",
        /// "apples."].
        type [<AllowNullLiteral>] RichTextValue =
            abstract copy: unit -> RichTextValueBuilder
            abstract getEndIndex: unit -> Integer
            abstract getLinkUrl: unit -> string option
            abstract getLinkUrl: startOffset: Integer * endOffset: Integer -> string option
            abstract getRuns: unit -> ResizeArray<RichTextValue>
            abstract getStartIndex: unit -> Integer
            abstract getText: unit -> string
            abstract getTextStyle: unit -> TextStyle
            abstract getTextStyle: startOffset: Integer * endOffset: Integer -> TextStyle

        /// A builder for Rich Text values.
        type [<AllowNullLiteral>] RichTextValueBuilder =
            abstract build: unit -> RichTextValue
            abstract setLinkUrl: startOffset: Integer * endOffset: Integer * linkUrl: string option -> RichTextValueBuilder
            abstract setLinkUrl: linkUrl: string option -> RichTextValueBuilder
            abstract setText: text: string -> RichTextValueBuilder
            abstract setTextStyle: startOffset: Integer * endOffset: Integer * textStyle: TextStyle option -> RichTextValueBuilder
            abstract setTextStyle: textStyle: TextStyle option -> RichTextValueBuilder

        /// Access the current active selection in the active sheet. A selection is the set of cells the user
        /// has highlighted in the sheet, which can be non-adjacent ranges. One cell in the selection is the
        /// current cell, where the user's current focus is. The current cell is highlighted with a
        /// darker border in the Google Sheets UI.
        /// 
        ///     var activeSheet = SpreadsheetApp.getActiveSheet();
        ///     var rangeList = activeSheet.getRangeList(['A1:B4', 'D1:E4']);
        ///     rangeList.activate();
        /// 
        ///     var selection = activeSheet.getSelection();
        ///     // Current Cell: D1
        ///     Logger.log('Current Cell: ' + selection.getCurrentCell().getA1Notation());
        ///     // Active Range: D1:E4
        ///     Logger.log('Active Range: ' + selection.getActiveRange().getA1Notation());
        ///     // Active Ranges: A1:B4, D1:E4
        ///     var ranges =  selection.getActiveRangeList().getRanges();
        ///     for (var i = 0; i < ranges.length; i++) {
        ///       Logger.log('Active Ranges: ' + ranges[i].getA1Notation());
        ///     }
        ///     Logger.log('Active Sheet: ' + selection.getActiveSheet().getName());
        type [<AllowNullLiteral>] Selection =
            abstract getActiveRange: unit -> Range option
            abstract getActiveRangeList: unit -> RangeList option
            abstract getActiveSheet: unit -> Sheet
            abstract getCurrentCell: unit -> Range option
            abstract getNextDataRange: direction: Direction -> Range option

        /// Access and modify spreadsheet sheets. Common operations are renaming a sheet and accessing range
        /// objects from the sheet.
        type [<AllowNullLiteral>] Sheet =
            abstract activate: unit -> Sheet
            abstract addDeveloperMetadata: key: string -> Sheet
            abstract addDeveloperMetadata: key: string * visibility: DeveloperMetadataVisibility -> Sheet
            abstract addDeveloperMetadata: key: string * value: string -> Sheet
            abstract addDeveloperMetadata: key: string * value: string * visibility: DeveloperMetadataVisibility -> Sheet
            abstract appendRow: rowContents: ResizeArray<obj option> -> Sheet
            abstract asDataSourceSheet: unit -> DataSourceSheet option
            abstract autoResizeColumn: columnPosition: Integer -> Sheet
            abstract autoResizeColumns: startColumn: Integer * numColumns: Integer -> Sheet
            abstract autoResizeRows: startRow: Integer * numRows: Integer -> Sheet
            abstract clear: unit -> Sheet
            abstract clear: options: {| formatOnly: bool option; contentsOnly: bool option |} -> Sheet
            abstract clearConditionalFormatRules: unit -> unit
            abstract clearContents: unit -> Sheet
            abstract clearFormats: unit -> Sheet
            abstract clearNotes: unit -> Sheet
            abstract collapseAllColumnGroups: unit -> Sheet
            abstract collapseAllRowGroups: unit -> Sheet
            abstract copyTo: spreadsheet: Spreadsheet -> Sheet
            abstract createDeveloperMetadataFinder: unit -> DeveloperMetadataFinder
            abstract createTextFinder: findText: string -> TextFinder
            abstract deleteColumn: columnPosition: Integer -> Sheet
            abstract deleteColumns: columnPosition: Integer * howMany: Integer -> unit
            abstract deleteRow: rowPosition: Integer -> Sheet
            abstract deleteRows: rowPosition: Integer * howMany: Integer -> unit
            abstract expandAllColumnGroups: unit -> Sheet
            abstract expandAllRowGroups: unit -> Sheet
            abstract expandColumnGroupsUpToDepth: groupDepth: Integer -> Sheet
            abstract expandRowGroupsUpToDepth: groupDepth: Integer -> Sheet
            abstract getActiveCell: unit -> Range
            abstract getActiveRange: unit -> Range option
            abstract getActiveRangeList: unit -> RangeList option
            abstract getBandings: unit -> ResizeArray<Banding>
            abstract getCharts: unit -> ResizeArray<EmbeddedChart>
            abstract getColumnGroup: columnIndex: Integer * groupDepth: Integer -> Group option
            abstract getColumnGroupControlPosition: unit -> GroupControlTogglePosition
            abstract getColumnGroupDepth: columnIndex: Integer -> Integer
            abstract getColumnWidth: columnPosition: Integer -> Integer
            abstract getConditionalFormatRules: unit -> ResizeArray<ConditionalFormatRule>
            abstract getCurrentCell: unit -> Range option
            abstract getDataRange: unit -> Range
            abstract getDataSourceTables: unit -> ResizeArray<DataSourceTable>
            abstract getDeveloperMetadata: unit -> ResizeArray<DeveloperMetadata>
            abstract getDrawings: unit -> ResizeArray<Drawing>
            abstract getFilter: unit -> Filter option
            abstract getFormUrl: unit -> string option
            abstract getFrozenColumns: unit -> Integer
            abstract getFrozenRows: unit -> Integer
            abstract getImages: unit -> ResizeArray<OverGridImage>
            abstract getIndex: unit -> Integer
            abstract getLastColumn: unit -> Integer
            abstract getLastRow: unit -> Integer
            abstract getMaxColumns: unit -> Integer
            abstract getMaxRows: unit -> Integer
            abstract getName: unit -> string
            abstract getNamedRanges: unit -> ResizeArray<NamedRange>
            abstract getParent: unit -> Spreadsheet
            abstract getPivotTables: unit -> ResizeArray<PivotTable>
            abstract getProtections: ``type``: ProtectionType -> ResizeArray<Protection>
            abstract getRange: row: Integer * column: Integer -> Range
            abstract getRange: row: Integer * column: Integer * numRows: Integer -> Range
            abstract getRange: row: Integer * column: Integer * numRows: Integer * numColumns: Integer -> Range
            abstract getRange: a1Notation: string -> Range
            abstract getRangeList: a1Notations: ResizeArray<string> -> RangeList
            abstract getRowGroup: rowIndex: Integer * groupDepth: Integer -> Group option
            abstract getRowGroupControlPosition: unit -> GroupControlTogglePosition
            abstract getRowGroupDepth: rowIndex: Integer -> Integer
            abstract getRowHeight: rowPosition: Integer -> Integer
            abstract getSelection: unit -> Selection
            abstract getSheetId: unit -> Integer
            abstract getSheetName: unit -> string
            abstract getSheetValues: startRow: Integer * startColumn: Integer * numRows: Integer * numColumns: Integer -> ResizeArray<ResizeArray<obj option>>
            abstract getSlicers: unit -> ResizeArray<Slicer>
            abstract getTabColor: unit -> string option
            abstract getType: unit -> SheetType
            abstract hasHiddenGridlines: unit -> bool
            abstract hideColumn: column: Range -> unit
            abstract hideColumns: columnIndex: Integer -> unit
            abstract hideColumns: columnIndex: Integer * numColumns: Integer -> unit
            abstract hideRow: row: Range -> unit
            abstract hideRows: rowIndex: Integer -> unit
            abstract hideRows: rowIndex: Integer * numRows: Integer -> unit
            abstract hideSheet: unit -> Sheet
            abstract insertChart: chart: EmbeddedChart -> unit
            abstract insertColumnAfter: afterPosition: Integer -> Sheet
            abstract insertColumnBefore: beforePosition: Integer -> Sheet
            abstract insertColumns: columnIndex: Integer -> unit
            abstract insertColumns: columnIndex: Integer * numColumns: Integer -> unit
            abstract insertColumnsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertColumnsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            //abstract insertImage: blobSource: Base.BlobSource * column: Integer * row: Integer -> OverGridImage
            //abstract insertImage: blobSource: Base.BlobSource * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> OverGridImage
            abstract insertImage: url: string * column: Integer * row: Integer -> OverGridImage
            abstract insertImage: url: string * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> OverGridImage
            abstract insertRowAfter: afterPosition: Integer -> Sheet
            abstract insertRowBefore: beforePosition: Integer -> Sheet
            abstract insertRows: rowIndex: Integer -> unit
            abstract insertRows: rowIndex: Integer * numRows: Integer -> unit
            abstract insertRowsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertRowsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            abstract insertSlicer: range: Range * anchorRowPos: Integer * anchorColPos: Integer -> Slicer
            abstract insertSlicer: range: Range * anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> Slicer
            abstract isColumnHiddenByUser: columnPosition: Integer -> bool
            abstract isRightToLeft: unit -> bool
            abstract isRowHiddenByFilter: rowPosition: Integer -> bool
            abstract isRowHiddenByUser: rowPosition: Integer -> bool
            abstract isSheetHidden: unit -> bool
            abstract moveColumns: columnSpec: Range * destinationIndex: Integer -> unit
            abstract moveRows: rowSpec: Range * destinationIndex: Integer -> unit
            abstract newChart: unit -> EmbeddedChartBuilder
            abstract protect: unit -> Protection
            abstract removeChart: chart: EmbeddedChart -> unit
            abstract setActiveRange: range: Range -> Range
            abstract setActiveRangeList: rangeList: RangeList -> RangeList
            abstract setActiveSelection: range: Range -> Range
            abstract setActiveSelection: a1Notation: string -> Range
            abstract setColumnGroupControlPosition: position: GroupControlTogglePosition -> Sheet
            abstract setColumnWidth: columnPosition: Integer * width: Integer -> Sheet
            abstract setColumnWidths: startColumn: Integer * numColumns: Integer * width: Integer -> Sheet
            abstract setConditionalFormatRules: rules: ResizeArray<ConditionalFormatRule> -> unit
            abstract setCurrentCell: cell: Range -> Range
            abstract setFrozenColumns: columns: Integer -> unit
            abstract setFrozenRows: rows: Integer -> unit
            abstract setHiddenGridlines: hideGridlines: bool -> Sheet
            abstract setName: name: string -> Sheet
            abstract setRightToLeft: rightToLeft: bool -> Sheet
            abstract setRowGroupControlPosition: position: GroupControlTogglePosition -> Sheet
            abstract setRowHeight: rowPosition: Integer * height: Integer -> Sheet
            abstract setRowHeights: startRow: Integer * numRows: Integer * height: Integer -> Sheet
            abstract setRowHeightsForced: startRow: Integer * numRows: Integer * height: Integer -> Sheet
            abstract setTabColor: color: string option -> Sheet
            abstract showColumns: columnIndex: Integer -> unit
            abstract showColumns: columnIndex: Integer * numColumns: Integer -> unit
            abstract showRows: rowIndex: Integer -> unit
            abstract showRows: rowIndex: Integer * numRows: Integer -> unit
            abstract showSheet: unit -> Sheet
            abstract sort: columnPosition: Integer -> Sheet
            abstract sort: columnPosition: Integer * ascending: bool -> Sheet
            abstract unhideColumn: column: Range -> unit
            abstract unhideRow: row: Range -> unit
            abstract updateChart: chart: EmbeddedChart -> unit
            [<Obsolete("DO NOT USE")>]
            abstract getSheetProtection: unit -> PageProtection
            [<Obsolete("DO NOT USE")>]
            abstract setSheetProtection: permissions: PageProtection -> unit

        /// The different types of sheets that can exist in a spreadsheet.
        type [<RequireQualifiedAccess>] SheetType =
            | GRID = 0
            | OBJECT = 1

        /// Represents a slicer, which is used
        /// to filter ranges, charts and pivot tables in a non-collaborative manner. This class contains
        /// methods to access and modify existing slicers. To create a new slicer, use Sheet.insertSlicer(range, anchorRowPos, anchorColPos).
        type [<AllowNullLiteral>] Slicer =
            abstract getBackgroundColor: unit -> string option
            abstract getColumnPosition: unit -> Integer option
            abstract getContainerInfo: unit -> ContainerInfo
            abstract getFilterCriteria: unit -> FilterCriteria option
            abstract getRange: unit -> Range
            abstract getTitle: unit -> string
            abstract getTitleHorizontalAlignment: unit -> string
            abstract getTitleTextStyle: unit -> TextStyle
            abstract isAppliedToPivotTables: unit -> bool
            abstract remove: unit -> unit
            abstract setApplyToPivotTables: applyToPivotTables: bool -> Slicer
            abstract setBackgroundColor: color: string option -> Slicer
            abstract setColumnFilterCriteria: columnPosition: Integer * filterCriteria: FilterCriteria option -> Slicer
            abstract setPosition: anchorRowPos: Integer * anchorColPos: Integer * offsetX: Integer * offsetY: Integer -> Slicer
            abstract setRange: rangeApi: Range -> Slicer
            abstract setTitle: title: string -> Slicer
            abstract setTitleHorizontalAlignment: horizontalAlignment: string option -> Slicer
            abstract setTitleTextStyle: textStyle: TextStyle -> Slicer

        /// Access and modify Google Sheets files. Common operations are adding new sheets and adding
        /// collaborators.
        type [<AllowNullLiteral>] Spreadsheet =
            abstract addDeveloperMetadata: key: string -> Spreadsheet
            abstract addDeveloperMetadata: key: string * visibility: DeveloperMetadataVisibility -> Spreadsheet
            abstract addDeveloperMetadata: key: string * value: string -> Spreadsheet
            abstract addDeveloperMetadata: key: string * value: string * visibility: DeveloperMetadataVisibility -> Spreadsheet
            abstract addEditor: emailAddress: string -> Spreadsheet
            //abstract addEditor: user: Base.User -> Spreadsheet
            abstract addEditors: emailAddresses: ResizeArray<string> -> Spreadsheet
            abstract addMenu: name: string * subMenus: Array<{| name: string; functionName: string |} option> -> unit
            abstract addViewer: emailAddress: string -> Spreadsheet
            //abstract addViewer: user: Base.User -> Spreadsheet
            abstract addViewers: emailAddresses: ResizeArray<string> -> Spreadsheet
            abstract appendRow: rowContents: ResizeArray<obj option> -> Sheet
            abstract autoResizeColumn: columnPosition: Integer -> Sheet
            abstract copy: name: string -> Spreadsheet
            abstract createDeveloperMetadataFinder: unit -> DeveloperMetadataFinder
            abstract createTextFinder: findText: string -> TextFinder
            abstract deleteActiveSheet: unit -> Sheet
            abstract deleteColumn: columnPosition: Integer -> Sheet
            abstract deleteColumns: columnPosition: Integer * howMany: Integer -> unit
            abstract deleteRow: rowPosition: Integer -> Sheet
            abstract deleteRows: rowPosition: Integer * howMany: Integer -> unit
            abstract deleteSheet: sheet: Sheet -> unit
            abstract duplicateActiveSheet: unit -> Sheet
            abstract getActiveCell: unit -> Range
            abstract getActiveRange: unit -> Range option
            abstract getActiveRangeList: unit -> RangeList option
            abstract getActiveSheet: unit -> Sheet
            //abstract getAs: contentType: string -> Base.Blob
            abstract getBandings: unit -> ResizeArray<Banding>
            //abstract getBlob: unit -> Base.Blob
            abstract getColumnWidth: columnPosition: Integer -> Integer
            abstract getCurrentCell: unit -> Range option
            abstract getDataRange: unit -> Range
            abstract getDataSourceTables: unit -> ResizeArray<DataSourceTable>
            abstract getDeveloperMetadata: unit -> ResizeArray<DeveloperMetadata>
            //abstract getEditors: unit -> ResizeArray<Base.User>
            abstract getFormUrl: unit -> string option
            abstract getFrozenColumns: unit -> Integer
            abstract getFrozenRows: unit -> Integer
            abstract getId: unit -> string
            abstract getImages: unit -> ResizeArray<OverGridImage>
            abstract getIterativeCalculationConvergenceThreshold: unit -> float
            abstract getLastColumn: unit -> Integer
            abstract getLastRow: unit -> Integer
            abstract getMaxIterativeCalculationCycles: unit -> Integer
            abstract getName: unit -> string
            abstract getNamedRanges: unit -> ResizeArray<NamedRange>
            abstract getNumSheets: unit -> Integer
            //abstract getOwner: unit -> Base.User option
            abstract getPredefinedSpreadsheetThemes: unit -> ResizeArray<SpreadsheetTheme>
            abstract getProtections: ``type``: ProtectionType -> ResizeArray<Protection>
            abstract getRange: a1Notation: string -> Range
            abstract getRangeByName: name: string -> Range option
            abstract getRangeList: a1Notations: ResizeArray<string> -> RangeList
            abstract getRecalculationInterval: unit -> RecalculationInterval
            abstract getRowHeight: rowPosition: Integer -> Integer
            abstract getSelection: unit -> Selection
            abstract getSheetByName: name: string -> Sheet option
            abstract getSheetId: unit -> Integer
            abstract getSheetName: unit -> string
            abstract getSheetValues: startRow: Integer * startColumn: Integer * numRows: Integer * numColumns: Integer -> ResizeArray<ResizeArray<obj option>>
            abstract getSheets: unit -> ResizeArray<Sheet>
            abstract getSpreadsheetLocale: unit -> string
            abstract getSpreadsheetTheme: unit -> SpreadsheetTheme option
            abstract getSpreadsheetTimeZone: unit -> string
            abstract getUrl: unit -> string
            //abstract getViewers: unit -> ResizeArray<Base.User>
            abstract hideColumn: column: Range -> unit
            abstract hideRow: row: Range -> unit
            abstract insertColumnAfter: afterPosition: Integer -> Sheet
            abstract insertColumnBefore: beforePosition: Integer -> Sheet
            abstract insertColumnsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertColumnsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            //abstract insertImage: blobSource: Base.BlobSource * column: Integer * row: Integer -> OverGridImage
            //abstract insertImage: blobSource: Base.BlobSource * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> OverGridImage
            abstract insertImage: url: string * column: Integer * row: Integer -> OverGridImage
            abstract insertImage: url: string * column: Integer * row: Integer * offsetX: Integer * offsetY: Integer -> OverGridImage
            abstract insertRowAfter: afterPosition: Integer -> Sheet
            abstract insertRowBefore: beforePosition: Integer -> Sheet
            abstract insertRowsAfter: afterPosition: Integer * howMany: Integer -> Sheet
            abstract insertRowsBefore: beforePosition: Integer * howMany: Integer -> Sheet
            abstract insertSheet: unit -> Sheet
            abstract insertSheet: sheetIndex: Integer -> Sheet
            abstract insertSheet: sheetIndex: Integer * options: {| template: Sheet option |} -> Sheet
            abstract insertSheet: options: {| template: Sheet option |} -> Sheet
            abstract insertSheet: sheetName: string -> Sheet
            abstract insertSheet: sheetName: string * sheetIndex: Integer -> Sheet
            abstract insertSheet: sheetName: string * sheetIndex: Integer * options: {| template: Sheet option |} -> Sheet
            abstract insertSheet: sheetName: string * options: {| template: Sheet option |} -> Sheet
            abstract insertSheetWithDataSourceTable: spec: DataSourceSpec -> Sheet
            abstract isColumnHiddenByUser: columnPosition: Integer -> bool
            abstract isIterativeCalculationEnabled: unit -> bool
            abstract isRowHiddenByFilter: rowPosition: Integer -> bool
            abstract isRowHiddenByUser: rowPosition: Integer -> bool
            abstract moveActiveSheet: pos: Integer -> unit
            abstract moveChartToObjectSheet: chart: EmbeddedChart -> Sheet
            abstract removeEditor: emailAddress: string -> Spreadsheet
            //abstract removeEditor: user: Base.User -> Spreadsheet
            abstract removeMenu: name: string -> unit
            abstract removeNamedRange: name: string -> unit
            abstract removeViewer: emailAddress: string -> Spreadsheet
            //abstract removeViewer: user: Base.User -> Spreadsheet
            abstract rename: newName: string -> unit
            abstract renameActiveSheet: newName: string -> unit
            abstract resetSpreadsheetTheme: unit -> SpreadsheetTheme
            abstract setActiveRange: range: Range -> Range
            abstract setActiveRangeList: rangeList: RangeList -> RangeList
            abstract setActiveSelection: range: Range -> Range
            abstract setActiveSelection: a1Notation: string -> Range
            abstract setActiveSheet: sheet: Sheet -> Sheet
            abstract setActiveSheet: sheet: Sheet * restoreSelection: bool -> Sheet
            abstract setColumnWidth: columnPosition: Integer * width: Integer -> Sheet
            abstract setCurrentCell: cell: Range -> Range
            abstract setFrozenColumns: columns: Integer -> unit
            abstract setFrozenRows: rows: Integer -> unit
            abstract setIterativeCalculationConvergenceThreshold: minThreshold: float -> Spreadsheet
            abstract setIterativeCalculationEnabled: isEnabled: bool -> Spreadsheet
            abstract setMaxIterativeCalculationCycles: maxIterations: Integer -> Spreadsheet
            abstract setNamedRange: name: string * range: Range -> unit
            abstract setRecalculationInterval: recalculationInterval: RecalculationInterval -> Spreadsheet
            abstract setRowHeight: rowPosition: Integer * height: Integer -> Sheet
            abstract setSpreadsheetLocale: locale: string -> unit
            abstract setSpreadsheetTheme: theme: SpreadsheetTheme -> SpreadsheetTheme
            abstract setSpreadsheetTimeZone: timezone: string -> unit
            //abstract show: userInterface: HTML.HtmlOutput -> unit
            abstract sort: columnPosition: Integer -> Sheet
            abstract sort: columnPosition: Integer * ascending: bool -> Sheet
            abstract toast: msg: string -> unit
            abstract toast: msg: string * title: string -> unit
            abstract toast: msg: string * title: string * timeoutSeconds: float option -> unit
            abstract unhideColumn: column: Range -> unit
            abstract unhideRow: row: Range -> unit
            abstract updateMenu: name: string * subMenus: Array<{| name: string; functionName: string |}> -> unit
            [<Obsolete("DO NOT USE")>]
            abstract getSheetProtection: unit -> PageProtection
            [<Obsolete("DO NOT USE")>]
            abstract isAnonymousView: unit -> bool
            [<Obsolete("DO NOT USE")>]
            abstract isAnonymousWrite: unit -> bool
            [<Obsolete("DO NOT USE")>]
            abstract setAnonymousAccess: anonymousReadAllowed: bool * anonymousWriteAllowed: bool -> unit
            [<Obsolete("DO NOT USE")>]
            abstract setSheetProtection: permissions: PageProtection -> unit

        /// Access and create Google Sheets files. This class is the parent class for the Spreadsheet service.
        type [<AllowNullLiteral>] SpreadsheetApp =
            abstract AutoFillSeries: obj with get, set
            abstract BandingTheme: obj with get, set
            abstract BooleanCriteria: obj with get, set
            abstract BorderStyle: obj with get, set
            abstract ColorType: obj with get, set
            abstract CopyPasteType: obj with get, set
            abstract DataExecutionErrorCode: obj with get, set
            abstract DataExecutionState: obj with get, set
            abstract DataSourceParameterType: obj with get, set
            abstract DataSourceType: obj with get, set
            abstract DataValidationCriteria: obj with get, set
            abstract DeveloperMetadataLocationType: obj with get, set
            abstract DeveloperMetadataVisibility: obj with get, set
            abstract Dimension: obj with get, set
            abstract Direction: obj with get, set
            abstract GroupControlTogglePosition: obj with get, set
            abstract InterpolationType: obj with get, set
            abstract PivotTableSummarizeFunction: obj with get, set
            abstract PivotValueDisplayType: obj with get, set
            abstract ProtectionType: obj with get, set
            abstract RecalculationInterval: obj with get, set
            abstract RelativeDate: obj with get, set
            abstract SheetType: obj with get, set
            abstract TextDirection: obj with get, set
            abstract TextToColumnsDelimiter: obj with get, set
            abstract ThemeColorType: obj with get, set
            abstract ValueType: obj with get, set
            abstract WrapStrategy: obj with get, set
            abstract create: name: string -> Spreadsheet
            abstract create: name: string * rows: Integer * columns: Integer -> Spreadsheet
            abstract enableAllDataSourcesExecution: unit -> unit
            abstract enableBigQueryExecution: unit -> unit
            abstract flush: unit -> unit
            abstract getActive: unit -> Spreadsheet
            abstract getActiveRange: unit -> Range
            abstract getActiveRangeList: unit -> RangeList
            abstract getActiveSheet: unit -> Sheet
            abstract getActiveSpreadsheet: unit -> Spreadsheet
            abstract getCurrentCell: unit -> Range
            abstract getSelection: unit -> Selection
            //abstract getUi: unit -> Base.Ui
            abstract newCellImage: unit -> CellImageBuilder
            abstract newColor: unit -> ColorBuilder
            abstract newConditionalFormatRule: unit -> ConditionalFormatRuleBuilder
            abstract newDataSourceSpec: unit -> DataSourceSpecBuilder
            abstract newDataValidation: unit -> DataValidationBuilder
            abstract newFilterCriteria: unit -> FilterCriteriaBuilder
            abstract newRichTextValue: unit -> RichTextValueBuilder
            abstract newTextStyle: unit -> TextStyleBuilder
            //abstract ``open``: file: Drive.File -> Spreadsheet
            abstract openById: id: string -> Spreadsheet
            abstract openByUrl: url: string -> Spreadsheet
            abstract setActiveRange: range: Range -> Range
            abstract setActiveRangeList: rangeList: RangeList -> RangeList
            abstract setActiveSheet: sheet: Sheet -> Sheet
            abstract setActiveSheet: sheet: Sheet * restoreSelection: bool -> Sheet
            abstract setActiveSpreadsheet: newActiveSpreadsheet: Spreadsheet -> unit
            abstract setCurrentCell: cell: Range -> Range

        /// Access and modify existing themes. To set a theme on a spreadsheet, use Spreadsheet.setSpreadsheetTheme(theme).
        type [<AllowNullLiteral>] SpreadsheetTheme =
            abstract getConcreteColor: themeColorType: ThemeColorType -> Color
            abstract getFontFamily: unit -> string option
            abstract getThemeColors: unit -> ResizeArray<ThemeColorType>
            abstract setConcreteColor: themeColorType: ThemeColorType * color: Color -> SpreadsheetTheme
            abstract setConcreteColor: themeColorType: ThemeColorType * red: Integer * green: Integer * blue: Integer -> SpreadsheetTheme
            abstract setFontFamily: fontFamily: string -> SpreadsheetTheme

        /// An enumerations representing the sort order.
        type [<RequireQualifiedAccess>] SortOrder =
            | ASCENDING = 0
            | DESCENDING = 1

        /// The sorting specification.
        type [<AllowNullLiteral>] SortSpec =
            abstract getBackgroundColor: unit -> Color option
            abstract getDataSourceColumn: unit -> DataSourceColumn
            abstract getDimensionIndex: unit -> float option
            abstract getForegroundColor: unit -> Color option
            abstract getSortOrder: unit -> SortOrder
            abstract isAscending: unit -> bool

        /// An enumerations of text directions.
        type [<RequireQualifiedAccess>] TextDirection =
            | LEFT_TO_RIGHT = 0
            | RIGHT_TO_LEFT = 1

        /// Find or replace text within a range, sheet or spreadsheet. Can also specify search options.
        type [<AllowNullLiteral>] TextFinder =
            abstract findAll: unit -> ResizeArray<Range>
            abstract findNext: unit -> Range option
            abstract findPrevious: unit -> Range option
            abstract getCurrentMatch: unit -> Range option
            abstract ignoreDiacritics: ignoreDiacritics: bool -> TextFinder
            abstract matchCase: matchCase: bool -> TextFinder
            abstract matchEntireCell: matchEntireCell: bool -> TextFinder
            abstract matchFormulaText: matchFormulaText: bool -> TextFinder
            abstract replaceAllWith: replaceText: string -> Integer
            abstract replaceWith: replaceText: string -> Integer
            abstract startFrom: startRange: Range -> TextFinder
            abstract useRegularExpression: useRegEx: bool -> TextFinder

        /// Access the text rotation settings for a cell.
        type [<AllowNullLiteral>] TextRotation =
            abstract getDegrees: unit -> Integer
            abstract isVertical: unit -> bool

        /// The rendered style of text in a cell.
        /// 
        /// Text styles can have a corresponding RichTextValue. If the RichTextValue spans multiple text runs that have different values for a given text style read
        /// method, the method returns null. To avoid this, query for text styles using the Rich Text
        /// values returned by the RichTextValue.getRuns() method.
        type [<AllowNullLiteral>] TextStyle =
            abstract copy: unit -> TextStyleBuilder
            abstract getFontFamily: unit -> string option
            abstract getFontSize: unit -> Integer option
            abstract getForegroundColor: unit -> string option
            abstract getForegroundColorObject: unit -> Color option
            abstract isBold: unit -> bool option
            abstract isItalic: unit -> bool option
            abstract isStrikethrough: unit -> bool option
            abstract isUnderline: unit -> bool option

        /// A builder for text styles.
        type [<AllowNullLiteral>] TextStyleBuilder =
            abstract build: unit -> TextStyle
            abstract setBold: bold: bool -> TextStyleBuilder
            abstract setFontFamily: fontFamily: string -> TextStyleBuilder
            abstract setFontSize: fontSize: Integer -> TextStyleBuilder
            abstract setForegroundColor: cssString: string -> TextStyleBuilder
            abstract setForegroundColorObject: color: Color -> TextStyleBuilder
            abstract setItalic: italic: bool -> TextStyleBuilder
            abstract setStrikethrough: strikethrough: bool -> TextStyleBuilder
            abstract setUnderline: underline: bool -> TextStyleBuilder

        /// An enumeration of the types of preset delimiters that can split a column of text into multiple
        /// columns.
        type [<RequireQualifiedAccess>] TextToColumnsDelimiter =
            | COMMA = 0
            | SEMICOLON = 1
            | PERIOD = 2
            | SPACE = 3

        /// A representation for a theme color.
        type [<AllowNullLiteral>] ThemeColor =
            abstract getColorType: unit -> Base.ColorType
            abstract getThemeColorType: unit -> ThemeColorType

        /// An enum which describes various color entries supported in themes.
        type [<RequireQualifiedAccess>] ThemeColorType =
            | UNSUPPORTED = 0
            | TEXT = 1
            | BACKGROUND = 2
            | ACCENT1 = 3
            | ACCENT2 = 4
            | ACCENT3 = 5
            | ACCENT4 = 6
            | ACCENT5 = 7
            | ACCENT6 = 8
            | HYPERLINK = 9

        /// An enumeration of the value types returned by Range.getValue and Range.getValues() from the Range class of the Spreadsheet service.
        /// The enumeration values listed below are in addition to Number, Boolean, Date, or String.
        type [<RequireQualifiedAccess>] ValueType =
            | IMAGE = 0

        /// An enumeration of the strategies used to handle cell text wrapping.
        type [<RequireQualifiedAccess>] WrapStrategy =
            | WRAP = 0
            | OVERFLOW = 1
            | CLIP = 2

        type [<StringEnum>] [<RequireQualifiedAccess>] RangeSetHorizontalAlignment =
            | Left
            | Center
            | Normal
            | Right

        type [<StringEnum>] [<RequireQualifiedAccess>] RangeSetVerticalAlignment =
            | Top
            | Middle
            | Bottom

    module Utilities =

        /// This service provides utilities for string encoding/decoding, date formatting, JSON manipulation,
        /// and other miscellaneous tasks.
        type [<AllowNullLiteral>] Utilities =
            abstract Charset: obj with get, set
            abstract DigestAlgorithm: obj with get, set
            abstract MacAlgorithm: obj with get, set
            abstract RsaAlgorithm: obj with get, set
            abstract base64Decode: encoded: string -> ResizeArray<Byte>
            //abstract base64Decode: encoded: string * charset: Charset -> ResizeArray<Byte>
            abstract base64DecodeWebSafe: encoded: string -> ResizeArray<Byte>
            //abstract base64DecodeWebSafe: encoded: string * charset: Charset -> ResizeArray<Byte>
            abstract base64Encode: data: ResizeArray<Byte> -> string
            abstract base64Encode: data: string -> string
            //abstract base64Encode: data: string * charset: Charset -> string
            abstract base64EncodeWebSafe: data: ResizeArray<Byte> -> string
            abstract base64EncodeWebSafe: data: string -> string
            //abstract base64EncodeWebSafe: data: string * charset: Charset -> string
            //abstract computeDigest: algorithm: DigestAlgorithm * value: ResizeArray<Byte> -> ResizeArray<Byte>
            //abstract computeDigest: algorithm: DigestAlgorithm * value: string -> ResizeArray<Byte>
            //abstract computeDigest: algorithm: DigestAlgorithm * value: string * charset: Charset -> ResizeArray<Byte>
            //abstract computeHmacSha256Signature: value: ResizeArray<Byte> * key: ResizeArray<Byte> -> ResizeArray<Byte>
            //abstract computeHmacSha256Signature: value: string * key: string -> ResizeArray<Byte>
            //abstract computeHmacSha256Signature: value: string * key: string * charset: Charset -> ResizeArray<Byte>
            //abstract computeHmacSignature: algorithm: MacAlgorithm * value: ResizeArray<Byte> * key: ResizeArray<Byte> -> ResizeArray<Byte>
            //abstract computeHmacSignature: algorithm: MacAlgorithm * value: string * key: string -> ResizeArray<Byte>
            //abstract computeHmacSignature: algorithm: MacAlgorithm * value: string * key: string * charset: Charset -> ResizeArray<Byte>
            //abstract computeRsaSha1Signature: value: string * key: string -> ResizeArray<Byte>
            //abstract computeRsaSha1Signature: value: string * key: string * charset: Charset -> ResizeArray<Byte>
            //abstract computeRsaSha256Signature: value: string * key: string -> ResizeArray<Byte>
            //abstract computeRsaSha256Signature: value: string * key: string * charset: Charset -> ResizeArray<Byte>
            //abstract computeRsaSignature: algorithm: RsaAlgorithm * value: string * key: string -> ResizeArray<Byte>
            //abstract computeRsaSignature: algorithm: RsaAlgorithm * value: string * key: string * charset: Charset -> ResizeArray<Byte>
            abstract formatDate: date: Base.Date * timeZone: string * format: string -> string
            abstract formatString: template: string * [<ParamArray>] args: obj option[] -> string
            abstract getUuid: unit -> string
            //abstract gzip: blob: Base.BlobSource -> Base.Blob
            //abstract gzip: blob: Base.BlobSource * name: string -> Base.Blob
            //abstract newBlob: data: ResizeArray<Byte> -> Base.Blob
            //abstract newBlob: data: ResizeArray<Byte> * contentType: string -> Base.Blob
            //abstract newBlob: data: ResizeArray<Byte> * contentType: string * name: string -> Base.Blob
            //abstract newBlob: data: string -> Base.Blob
            //abstract newBlob: data: string * contentType: string -> Base.Blob
            //abstract newBlob: data: string * contentType: string * name: string -> Base.Blob
            abstract parseCsv: csv: string -> ResizeArray<ResizeArray<string>>
            abstract parseCsv: csv: string * delimiter: Char -> ResizeArray<ResizeArray<string>>
            abstract parseDate: date: string * timeZone: string * format: string -> DateTime
            abstract sleep: milliseconds: Integer -> unit
            //abstract ungzip: blob: Base.BlobSource -> Base.Blob
            //abstract unzip: blob: Base.BlobSource -> ResizeArray<Base.Blob>
            //abstract zip: blobs: ResizeArray<Base.BlobSource> -> Base.Blob
            //abstract zip: blobs: ResizeArray<Base.BlobSource> * name: string -> Base.Blob
            [<Obsolete("DO NOT USE")>]
            abstract jsonParse: jsonString: string -> obj option
            [<Obsolete("DO NOT USE")>]
            abstract jsonStringify: obj: obj option -> string
