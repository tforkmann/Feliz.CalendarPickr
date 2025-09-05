namespace Feliz.FlatPickr

open System
open Fable.Core

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
    static member inline minDate(date:DateTimeOffset option) : IOptionsProp =
        Interop.mkOptionsProp "minDate" date
    static member inline maxDate(date:DateTimeOffset option) : IOptionsProp =
        Interop.mkOptionsProp "maxDate" date
    static member inline time_24hr(time_24hr: bool) : IOptionsProp =
        Interop.mkOptionsProp "time_24hr" time_24hr
    static member inline noCalendar(noCalendar: bool) : IOptionsProp =
        Interop.mkOptionsProp "noCalendar" noCalendar
