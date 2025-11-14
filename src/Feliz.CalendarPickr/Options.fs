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
