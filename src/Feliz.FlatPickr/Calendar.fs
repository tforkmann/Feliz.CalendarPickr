namespace Feliz.FlatPickr

open Feliz
open Fable.Core.JsInterop
open Fable.Core
open System
open Fable.DateFunctions

[<Erase>]
type calendar =
    static member inline months(months: int) : ICalendarProp =
        Interop.mkCalendarProp "months" months
    static member inline date(date: DateTimeOffset) : ICalendarProp =
        Interop.mkCalendarProp "date" date
    static member inline color(color: string) : ICalendarProp =
        Interop.mkCalendarProp "color" color
    static member inline moveRangeOnFirstSelection(moveRangeOnFirstSelection: bool) : ICalendarProp =
        Interop.mkCalendarProp "moveRangeOnFirstSelection" moveRangeOnFirstSelection
    static member inline direction(direction: Direction) : ICalendarProp =
        Interop.mkCalendarProp "direction" direction
    static member inline showSelectionPreview(showSelectionPreview: bool) : ICalendarProp =
        Interop.mkCalendarProp "showSelectionPreview" showSelectionPreview
    static member inline showMonthAndYearPickers(showMonthAndYearPickers: bool) : ICalendarProp =
        Interop.mkCalendarProp "showMonthAndYearPickers" showMonthAndYearPickers
    static member inline showMonthArrow(showMonthArrow: bool) : ICalendarProp =
        Interop.mkCalendarProp "showMonthArrow" showMonthArrow
    static member inline editableDateInputs(editableDateInputs: bool) : ICalendarProp =
        Interop.mkCalendarProp "editableDateInputs" editableDateInputs

    static member inline locale(locale: ILocale) : ICalendarProp =
        Interop.mkCalendarProp "locale"  locale

    static member inline minDate(minDate: DateTimeOffset) : ICalendarProp =
        Interop.mkCalendarProp "minDate" minDate

    static member inline maxDate(maxDate: DateTimeOffset) : ICalendarProp =
        Interop.mkCalendarProp "maxDate" maxDate
    static member inline dragSelectionEnabled (dragSelectionEnabled: bool) : ICalendarProp =
        Interop.mkCalendarProp "dragSelectionEnabled" dragSelectionEnabled

    static member inline onChange
        (handler : DateTimeOffset -> unit)
        : ICalendarProp =
        !!("onChange" ==> handler)
