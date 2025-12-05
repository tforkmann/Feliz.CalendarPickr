namespace Feliz.FlatPickr

open System
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type option =
    static member inline allowInput(allowInput: bool) : IOptionsProp =
        Interop.mkOptionsProp "allowInput" allowInput
    static member inline clearable(clearable: bool) : IOptionsProp =
        Interop.mkOptionsProp "clearable" clearable
    static member inline locale(locale: string) : IOptionsProp =
        Interop.mkOptionsProp "locale" locale
    static member inline dateFormat(format: string) : IOptionsProp =
        Interop.mkOptionsProp "dateFormat" format
    static member inline disableMobile(disableMobile: bool) : IOptionsProp =
        Interop.mkOptionsProp "disableMobile" disableMobile
    static member inline minDate(date:DateOption option) : IOptionsProp =
        match date with
        | None -> Interop.mkOptionsProp "minDate" null
        | Some date -> Interop.mkOptionsProp "minDate" date.Value
    static member inline maxDate(date:DateOption option ) : IOptionsProp =
        match date with
        | None -> Interop.mkOptionsProp "maxDate" null
        | Some date -> Interop.mkOptionsProp "maxDate" date.Value
    static member inline time_24hr(time_24hr: bool) : IOptionsProp =
        Interop.mkOptionsProp "time_24hr" time_24hr
    static member inline noCalendar(noCalendar: bool) : IOptionsProp =
        Interop.mkOptionsProp "noCalendar" noCalendar
    static member inline enableTime(enableTime: bool) : IOptionsProp =
        Interop.mkOptionsProp "enableTime" enableTime
    static member inline defaultDate(date: DateOption) : IOptionsProp = Interop.mkOptionsProp "defaultDate" date.Value
    static member inline defaultDates(dates: DateOption seq) : IOptionsProp = Interop.mkOptionsProp "defaultDate" (dates |> Seq.map (fun d -> d.Value) |> Seq.toArray)

    /// Selection mode: Single (default), Range, or Multiple
    static member inline mode(mode: Mode) : IOptionsProp =
        Interop.mkOptionsProp "mode" mode.Value

    /// Shorthand for mode Range - enables date range selection
    static member inline enableRange : IOptionsProp =
        Interop.mkOptionsProp "mode" "range"

    /// Shorthand for mode Multiple - enables multiple date selection
    static member inline enableMultiple : IOptionsProp =
        Interop.mkOptionsProp "mode" "multiple"

    /// Date separator for range mode (default: " to ")
    static member inline rangeSeparator(separator: string) : IOptionsProp =
        Interop.mkOptionsProp "rangeSeparator" separator

    /// Number of months to show (useful for range mode)
    static member inline showMonths(months: int) : IOptionsProp =
        Interop.mkOptionsProp "showMonths" months

    /// Display the calendar inline (always visible)
    static member inline inline'(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "inline" value

    // ============================================
    // Display & UI Options
    // ============================================

    /// Show week numbers in the calendar
    static member inline weekNumbers(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "weekNumbers" value

    /// Show month using shorthand (e.g., "Jan" instead of "January")
    static member inline shorthandCurrentMonth(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "shorthandCurrentMonth" value

    /// Month selector type: "dropdown" or "static"
    static member inline monthSelectorType(value: string) : IOptionsProp =
        Interop.mkOptionsProp "monthSelectorType" value

    /// Shows a user-friendly formatted date in the input while keeping the actual format for forms
    static member inline altInput(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "altInput" value

    /// Format for the alternative input display (requires altInput: true)
    static member inline altFormat(format: string) : IOptionsProp =
        Interop.mkOptionsProp "altFormat" format

    /// CSS class for the alternative input element
    static member inline altInputClass(className: string) : IOptionsProp =
        Interop.mkOptionsProp "altInputClass" className

    /// Format for aria-label on calendar days (accessibility)
    static member inline ariaDateFormat(format: string) : IOptionsProp =
        Interop.mkOptionsProp "ariaDateFormat" format

    // ============================================
    // Position Options
    // ============================================

    /// Calendar position relative to input: "auto", "above", "below", "auto left", "auto center", "auto right"
    static member inline position(value: string) : IOptionsProp =
        Interop.mkOptionsProp "position" value

    /// Positions calendar inside wrapper next to input (instead of absolute positioning)
    static member inline static'(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "static" value

    /// Attaches calendar to specified DOM element instead of body
    static member inline appendTo(element: Browser.Types.HTMLElement) : IOptionsProp =
        Interop.mkOptionsProp "appendTo" element

    // ============================================
    // Arrow Customization
    // ============================================

    /// HTML for the previous month arrow icon
    static member inline prevArrow(html: string) : IOptionsProp =
        Interop.mkOptionsProp "prevArrow" html

    /// HTML for the next month arrow icon
    static member inline nextArrow(html: string) : IOptionsProp =
        Interop.mkOptionsProp "nextArrow" html

    // ============================================
    // Time Options
    // ============================================

    /// Enable seconds in the time picker
    static member inline enableSeconds(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "enableSeconds" value

    /// Step for hour input (including scrolling)
    static member inline hourIncrement(value: int) : IOptionsProp =
        Interop.mkOptionsProp "hourIncrement" value

    /// Step for minute input (including scrolling)
    static member inline minuteIncrement(value: int) : IOptionsProp =
        Interop.mkOptionsProp "minuteIncrement" value

    /// Initial hour value when no date is selected (default: 12)
    static member inline defaultHour(value: int) : IOptionsProp =
        Interop.mkOptionsProp "defaultHour" value

    /// Initial minute value when no date is selected (default: 0)
    static member inline defaultMinute(value: int) : IOptionsProp =
        Interop.mkOptionsProp "defaultMinute" value

    /// Initial seconds value when no date is selected (default: 0)
    static member inline defaultSeconds(value: int) : IOptionsProp =
        Interop.mkOptionsProp "defaultSeconds" value

    // ============================================
    // Behavior Options
    // ============================================

    /// Whether clicking on input opens the picker (default: true)
    static member inline clickOpens(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "clickOpens" value

    /// Allows preloading of invalid dates
    static member inline allowInvalidPreload(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "allowInvalidPreload" value

    /// Enable custom elements and input groups with data attributes
    static member inline wrap(value: bool) : IOptionsProp =
        Interop.mkOptionsProp "wrap" value

    /// Separator for dates in multiple mode (alternative to rangeSeparator)
    static member inline conjunction(separator: string) : IOptionsProp =
        Interop.mkOptionsProp "conjunction" separator

    // ============================================
    // Date Constraints
    // ============================================

    /// Disable specific dates (array of date strings or DateOptions)
    static member inline disable(dates: DateOption seq) : IOptionsProp =
        Interop.mkOptionsProp "disable" (dates |> Seq.map (fun d -> d.Value) |> Seq.toArray)

    /// Disable specific dates using date strings
    static member inline disableDates(dates: string seq) : IOptionsProp =
        Interop.mkOptionsProp "disable" (dates |> Seq.toArray)

    /// Disable dates using a predicate function (e.g., to disable weekends)
    static member inline disableBy(predicate: DateTime -> bool) : IOptionsProp =
        Interop.mkOptionsProp "disable" [| box (System.Func<DateTime, bool>(predicate)) |]

    /// Disable date ranges
    static member inline disableRanges(ranges: (DateOption * DateOption) seq) : IOptionsProp =
        let jsRanges =
            ranges
            |> Seq.map (fun (fromDate, toDate) ->
                createObj [
                    "from" ==> fromDate.Value
                    "to" ==> toDate.Value
                ])
            |> Seq.toArray
        Interop.mkOptionsProp "disable" jsRanges

    /// Enable only specific dates (reverse of disable)
    static member inline enable(dates: DateOption seq) : IOptionsProp =
        Interop.mkOptionsProp "enable" (dates |> Seq.map (fun d -> d.Value) |> Seq.toArray)

    /// Enable only specific dates using date strings
    static member inline enableDates(dates: string seq) : IOptionsProp =
        Interop.mkOptionsProp "enable" (dates |> Seq.toArray)

    /// Enable dates using a predicate function
    static member inline enableBy(predicate: DateTime -> bool) : IOptionsProp =
        Interop.mkOptionsProp "enable" [| box (System.Func<DateTime, bool>(predicate)) |]

    /// Enable only date ranges
    static member inline enableRanges(ranges: (DateOption * DateOption) seq) : IOptionsProp =
        let jsRanges =
            ranges
            |> Seq.map (fun (fromDate, toDate) ->
                createObj [
                    "from" ==> fromDate.Value
                    "to" ==> toDate.Value
                ])
            |> Seq.toArray
        Interop.mkOptionsProp "enable" jsRanges
