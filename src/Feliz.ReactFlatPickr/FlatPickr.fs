namespace Feliz.ReactFlatPickr

open Feliz
open Fable.Core.JsInterop
open Fable.Core
open System

type Event = Browser.Types.Event

[<Erase>]
type FlatPickr =

    static member inline flatPickr(props: IFlatPickrProp seq) =
        Interop.reactApi.createElement (Interop.flatPickr, createObj !!props)

    static member inline children(children: ReactElement list) =
        unbox<IFlatPickrProp> (prop.children children)
[<Erase>]
type flatPickr =

    static member inline value(value: DateTimeOffset) : IFlatPickrProp =
        Interop.mkFlatPickrProp "value" value
    static member inline className(className: string) : IFlatPickrProp =
        Interop.mkFlatPickrProp "className" className
    static member inline title(title: string) : IFlatPickrProp =
        Interop.mkFlatPickrProp "title" title
    static member inline onChange(callback: DateTimeOffset[] -> Event -> unit) : IFlatPickrProp =
        Interop.mkFlatPickrProp "onChange" callback

    static member inline disabled(disabled: bool) : IFlatPickrProp =
        Interop.mkFlatPickrProp "disabled" disabled
    static member inline options props : IFlatPickrProp =
        Interop.mkFlatPickrProp "options" (createObj !!props)
