namespace Feliz.FlatPickr

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open System
open Browser.Types

/// Props for imperative flatpickr initialization
type IImperativeFlatPickrOptionProp = interface end

/// Imperative flatpickr binding that directly initializes flatpickr on an input element.
/// This avoids issues with react-flatpickr and provides more control over the instance lifecycle.
[<Erase; RequireQualifiedAccess>]
module ImperativeInterop =
    let inline mkOptionProp (key: string) (value: obj) : IImperativeFlatPickrOptionProp = unbox (key, value)

    /// Direct flatpickr import (not react-flatpickr)
    let flatpickrModule: obj = importDefault "flatpickr"

    /// German locale
    let germanLocale: obj = importDefault "flatpickr/dist/l10n/de.js"

/// Options for imperative flatpickr initialization
[<Erase>]
type imperativeOption =
    /// Date format string (e.g., "d.m.Y H:i")
    static member inline dateFormat(format: string) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "dateFormat" format

    /// Enable time picker
    static member inline enableTime(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "enableTime" value

    /// Hide the calendar (time-only mode)
    static member inline noCalendar(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "noCalendar" value

    /// Use 24-hour time format
    static member inline time_24hr(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "time_24hr" value

    /// Disable mobile native pickers
    static member inline disableMobile(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "disableMobile" value

    /// Allow manual text input
    static member inline allowInput(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "allowInput" value

    /// Close on date selection
    static member inline closeOnSelect(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "closeOnSelect" value

    /// Display calendar inline
    static member inline inline'(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "inline" value

    /// Default date value
    static member inline defaultDate(date: DateTimeOffset) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "defaultDate" date

    /// Default date value (DateTime)
    static member inline defaultDateDT(date: DateTime) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "defaultDate" date

    /// Minimum selectable date
    static member inline minDate(date: DateTimeOffset) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "minDate" date

    /// Minimum selectable date (DateTime)
    static member inline minDateDT(date: DateTime) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "minDate" date

    /// Maximum selectable date
    static member inline maxDate(date: DateTimeOffset) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "maxDate" date

    /// Maximum selectable date (DateTime)
    static member inline maxDateDT(date: DateTime) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "maxDate" date

    /// Locale setting ("de" for German, "default" for English)
    static member inline locale(locale: string) : IImperativeFlatPickrOptionProp =
        let localeObj =
            match locale with
            | "de" -> ImperativeInterop.germanLocale?``default``?de
            | _ -> JS.undefined
        ImperativeInterop.mkOptionProp "locale" localeObj

    /// onChange callback - fires when user selects a date
    static member inline onChange(callback: DateTimeOffset array -> unit) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "onChange"
            (fun (dates: DateTimeOffset array) (_: string) (_: obj) -> callback dates)

    /// onOpen callback - fires when calendar opens
    static member inline onOpen(callback: unit -> unit) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "onOpen"
            (fun (_: DateTimeOffset array) (_: string) (_: obj) -> callback ())

    /// onClose callback - fires when calendar closes
    /// The instance parameter provides access to selectedDates
    static member inline onClose(callback: DateTimeOffset array -> obj -> unit) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "onClose"
            (fun (dates: DateTimeOffset array) (_: string) (instance: obj) -> callback dates instance)

    /// Selection mode
    static member inline mode(mode: Mode) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "mode" mode.Value

    /// Show week numbers
    static member inline weekNumbers(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "weekNumbers" value

    /// Enable seconds in time picker
    static member inline enableSeconds(value: bool) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "enableSeconds" value

    /// Step for hour input
    static member inline hourIncrement(value: int) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "hourIncrement" value

    /// Step for minute input
    static member inline minuteIncrement(value: int) : IImperativeFlatPickrOptionProp =
        ImperativeInterop.mkOptionProp "minuteIncrement" value


/// Hook result for useImperativeFlatPickr
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

/// React hook for imperative flatpickr initialization.
/// This provides direct control over the flatpickr instance and avoids issues with react-flatpickr.
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
    static member inline useImperativeFlatPickr(options: IImperativeFlatPickrOptionProp seq) : ImperativeFlatPickrResult =
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
                    let instance = ImperativeInterop.flatpickrModule$(input, opts)
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
            |> Option.map (fun instance -> instance?isOpen :> bool)
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
        (options: IImperativeFlatPickrOptionProp seq)
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

                    let instance = ImperativeInterop.flatpickrModule$(input, baseOpts)
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
            |> Option.map (fun instance -> instance?isOpen :> bool)
            |> Option.defaultValue false

        {
            InputRef = inputRef
            Instance = instanceRef
            SetDate = setDate
            Clear = clear
            IsOpen = isOpen
        }
