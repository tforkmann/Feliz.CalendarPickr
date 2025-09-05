namespace Feliz.FlatPickr

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

[<Erase>]
type DateRange =

    static member inline dateRangePicker(props: IDateRangePickerProp seq) =
        Interop.reactApi.createElement (Interop.DateRangePicker, createObj !!props)

    static member inline calendar(props: ICalendarProp seq) =
        Interop.reactApi.createElement (Interop.Calendar, createObj !!props)

    static member inline children(children: ReactElement list) =
        unbox<IDateRangeProp> (prop.children children)
