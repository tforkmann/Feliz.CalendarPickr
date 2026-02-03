namespace Feliz.FlatPickr

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open System
open Browser.Types

/// Hook result for ImperativeFlatPickr.useImperativeFlatPickr
type ImperativeFlatPickrResult = {
    /// Ref to attach to the input element
    InputRef: IRefValue<HTMLInputElement option>
    /// The flatpickr instance (if initialized)
    Instance: IRefValue<obj option>
    /// Set a new date programmatically
    SetDate: DateTimeOffset option -> unit
    /// Clear the selected date
    Clear: unit -> unit
    /// Check if picker is currently open
    IsOpen: unit -> bool
}

/// Options for imperative flatpickr initialization (lowercase for Feliz-style)
[<Erase>]
type imperativeOption =
    /// Date format string (e.g., "d.m.Y H:i")
    static member inline dateFormat(format: string) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "dateFormat" format

    /// Enable time picker
    static member inline enableTime(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "enableTime" value

    /// Hide the calendar (time-only mode)
    static member inline noCalendar(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "noCalendar" value

    /// Use 24-hour time format
    static member inline time_24hr(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "time_24hr" value

    /// Disable mobile native pickers
    static member inline disableMobile(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "disableMobile" value

    /// Allow manual text input
    static member inline allowInput(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "allowInput" value

    /// Close on date selection
    static member inline closeOnSelect(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "closeOnSelect" value

    /// Display calendar inline
    static member inline inline'(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "inline" value

    /// Default date value
    static member inline defaultDate(date: DateTimeOffset) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "defaultDate" date

    /// Default date value (DateTime)
    static member inline defaultDateDT(date: DateTime) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "defaultDate" date

    /// Minimum selectable date
    static member inline minDate(date: DateTimeOffset) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "minDate" date

    /// Minimum selectable date (DateTime)
    static member inline minDateDT(date: DateTime) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "minDate" date

    /// Maximum selectable date
    static member inline maxDate(date: DateTimeOffset) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "maxDate" date

    /// Maximum selectable date (DateTime)
    static member inline maxDateDT(date: DateTime) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "maxDate" date

    /// Locale setting for calendar localization
    static member inline locale(locale: Locale) : IImperativeOptionsProp =
        let localeObj =
            match locale with
            | Locale.German -> Interop.germanLocale?``default``?de
            | Locale.French -> Interop.frenchLocale?``default``?fr
            | Locale.Italian -> Interop.italianLocale?``default``?it
            | Locale.English -> JS.undefined
        Interop.mkImperativeOptionsProp "locale" localeObj

    /// onChange callback - fires when user selects a date
    static member inline onChange(callback: DateTimeOffset array -> unit) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "onChange"
            (fun (dates: DateTimeOffset array) (_: string) (_: obj) -> callback dates)

    /// onOpen callback - fires when calendar opens
    static member inline onOpen(callback: unit -> unit) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "onOpen"
            (fun (_: DateTimeOffset array) (_: string) (_: obj) -> callback ())

    /// onClose callback - fires when calendar closes
    /// The instance parameter provides access to selectedDates
    static member inline onClose(callback: DateTimeOffset array -> obj -> unit) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "onClose"
            (fun (dates: DateTimeOffset array) (_: string) (instance: obj) -> callback dates instance)

    /// Selection mode
    static member inline mode(mode: Mode) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "mode" mode.Value

    /// Show week numbers
    static member inline weekNumbers(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "weekNumbers" value

    /// Enable seconds in time picker
    static member inline enableSeconds(value: bool) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "enableSeconds" value

    /// Step for hour input
    static member inline hourIncrement(value: int) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "hourIncrement" value

    /// Step for minute input
    static member inline minuteIncrement(value: int) : IImperativeOptionsProp =
        Interop.mkImperativeOptionsProp "minuteIncrement" value

/// Imperative flatpickr binding that directly initializes flatpickr on an input element.
/// This avoids issues with react-flatpickr and provides more control over the instance lifecycle.
///
/// Usage:
/// ```fsharp
/// let picker = ImperativeFlatPickr.useImperativeFlatPickr [
///     imperativeOption.dateFormat "d.m.Y H:i"
///     imperativeOption.enableTime true
///     imperativeOption.locale "de"
///     imperativeOption.onChange (fun dates -> ...)
/// ]
///
/// Html.input [
///     prop.ref (fun el ->
///         if not (isNull el) && picker.InputRef.current.IsNone then
///             picker.InputRef.current <- Some (el :?> HTMLInputElement)
///     )
///     prop.className "input"
/// ]
/// ```
[<Erase>]
type ImperativeFlatPickr =
    /// Creates an imperative flatpickr hook with the given options.
    /// Returns refs and helper functions to control the picker.
    static member inline useImperativeFlatPickr(options: IImperativeOptionsProp seq) : ImperativeFlatPickrResult =
        let inputRef = React.useRef<HTMLInputElement option>(None)
        let instanceRef = React.useRef<obj option>(None)
        let isInitializedRef = React.useRef false

        // Initialize flatpickr when input is available
        React.useEffect(
            (fun () ->
                match inputRef.current, isInitializedRef.current with
                | Some input, false ->
                    isInitializedRef.current <- true
                    let opts = createObj !!options
                    let instance = Interop.flatpickrModule$(input, opts)
                    instanceRef.current <- Some instance
                | _ -> ()
            ),
            [| box inputRef.current |]
        )

        // Cleanup on unmount
        React.useEffectOnce(fun () ->
            React.createDisposable(fun () ->
                instanceRef.current
                |> Option.iter (fun instance -> instance?destroy())
            )
        )

        let setDate (date: DateTimeOffset option) =
            instanceRef.current
            |> Option.iter (fun instance ->
                match date with
                | Some d -> instance?setDate(d, false)
                | None -> instance?clear()
            )

        let clear () =
            instanceRef.current
            |> Option.iter (fun instance -> instance?clear())

        let isOpen () =
            instanceRef.current
            |> Option.map (fun instance -> instance?isOpen : bool)
            |> Option.defaultValue false

        {
            InputRef = inputRef
            Instance = instanceRef
            SetDate = setDate
            Clear = clear
            IsOpen = isOpen
        }

    /// Creates an imperative flatpickr hook with stable callback refs.
    /// This version stores callbacks in refs to prevent re-initialization when callbacks change.
    ///
    /// Usage:
    /// ```fsharp
    /// let picker = ImperativeFlatPickr.useImperativeFlatPickrWithCallbackRefs
    ///     [
    ///         imperativeOption.dateFormat "d.m.Y H:i"
    ///         imperativeOption.enableTime true
    ///     ]
    ///     (Some (fun dates -> dispatch (DateChanged dates)))  // onChange
    ///     (Some (fun () -> dispatch CalendarOpened))          // onOpen
    ///     (Some (fun dates instance -> dispatch (CalendarClosed dates)))  // onClose
    /// ```
    static member inline useImperativeFlatPickrWithCallbackRefs
        (options: IImperativeOptionsProp seq)
        (onChange: (DateTimeOffset array -> unit) option)
        (onOpen: (unit -> unit) option)
        (onClose: (DateTimeOffset array -> obj -> unit) option)
        : ImperativeFlatPickrResult =

        let inputRef = React.useRef<HTMLInputElement option>(None)
        let instanceRef = React.useRef<obj option>(None)
        let isInitializedRef = React.useRef false

        // Store callbacks in refs for stable references
        let onChangeRef = React.useRef onChange
        let onOpenRef = React.useRef onOpen
        let onCloseRef = React.useRef onClose

        // Update callback refs when props change
        React.useEffect(fun () ->
            onChangeRef.current <- onChange
            onOpenRef.current <- onOpen
            onCloseRef.current <- onClose
        )

        // Initialize flatpickr when input is available
        React.useEffect(
            (fun () ->
                match inputRef.current, isInitializedRef.current with
                | Some input, false ->
                    isInitializedRef.current <- true

                    // Build options with callback wrappers that use refs
                    let baseOpts = createObj !!options

                    baseOpts?onChange <- fun (dates: DateTimeOffset array) (_: string) (_: obj) ->
                        onChangeRef.current |> Option.iter (fun cb -> cb dates)

                    baseOpts?onOpen <- fun (_: DateTimeOffset array) (_: string) (_: obj) ->
                        onOpenRef.current |> Option.iter (fun cb -> cb ())

                    baseOpts?onClose <- fun (dates: DateTimeOffset array) (_: string) (instance: obj) ->
                        onCloseRef.current |> Option.iter (fun cb -> cb dates instance)

                    let instance = Interop.flatpickrModule$(input, baseOpts)
                    instanceRef.current <- Some instance
                | _ -> ()
            ),
            [| box inputRef.current |]
        )

        // Cleanup on unmount
        React.useEffectOnce(fun () ->
            React.createDisposable(fun () ->
                instanceRef.current
                |> Option.iter (fun instance -> instance?destroy())
            )
        )

        let setDate (date: DateTimeOffset option) =
            instanceRef.current
            |> Option.iter (fun instance ->
                // Only update if picker is not open (to not interrupt user interaction)
                let isOpen: bool = instance?isOpen
                if not isOpen then
                    match date with
                    | Some d -> instance?setDate(d, false)
                    | None -> instance?clear()
            )

        let clear () =
            instanceRef.current
            |> Option.iter (fun instance -> instance?clear())

        let isOpen () =
            instanceRef.current
            |> Option.map (fun instance -> instance?isOpen : bool)
            |> Option.defaultValue false

        {
            InputRef = inputRef
            Instance = instanceRef
            SetDate = setDate
            Clear = clear
            IsOpen = isOpen
        }
