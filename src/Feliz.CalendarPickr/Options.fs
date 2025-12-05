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
