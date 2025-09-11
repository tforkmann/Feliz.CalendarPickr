namespace Feliz.FlatPickr

open Feliz
open Fable.Core.JsInterop
open Fable.Core
open System
open Browser.Dom

type Event = Browser.Types.Event

[<Erase>]
type FlatPickr =

    static member inline flatPickr(props: IFlatPickrProp seq) =
        Interop.reactApi.createElement (Interop.flatPickr, createObj !!props)

    static member inline children(children: ReactElement list) =
        unbox<IFlatPickrProp> (prop.children children)

[<Erase>]
type flatPickr =

    static member inline value(value: DateOption) : IFlatPickrProp = Interop.mkFlatPickrProp "value" value.Value

    static member inline className(className: string) : IFlatPickrProp =
        Interop.mkFlatPickrProp "className" className

    static member inline title(title: string option) : IFlatPickrProp = Interop.mkFlatPickrProp "title" title
    static member inline styles (props: IFlatPickrStylesProp seq) : IFlatPickrProp = Interop.mkFlatPickrProp "styles" (createObj !!props)

    /// Theme colors using CSS variables
    static member inline themeColors(?primary: string, ?secondary: string) : IFlatPickrProp =
        if primary.IsSome || secondary.IsSome then
            let primaryColor = defaultArg primary "#4caf50" // Default to Material Green if not provided
            let secondaryColor = defaultArg secondary "#388e3c" // Default to Material Green if not provided
            let root = document.documentElement
            root?style?setProperty("--primary", primaryColor)
            root?style?setProperty("--secondary", secondaryColor)
        Interop.mkFlatPickrProp "themeColors" null
    static member inline onChange(callback: DateTimeOffset[] -> Event -> unit) : IFlatPickrProp =
        Interop.mkFlatPickrProp "onChange" callback

    static member inline disabled(disabled: bool) : IFlatPickrProp =
        Interop.mkFlatPickrProp "disabled" disabled

    static member inline options props : IFlatPickrProp =
        Interop.mkFlatPickrProp "options" (createObj !!props)

[<Erase>]
type flatPickrStyle =
    static member inline border(value: string) : IFlatPickrStylesProp =
        Interop.mkStylesProp "border" value
    static member inline backgroundColor(value: string) : IFlatPickrStylesProp =
        Interop.mkStylesProp "backgroundColor" value
