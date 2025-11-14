module Index

open Elmish
open Feliz
open Feliz.FlatPickr
open System
open Fable.I18Next
open Fable.Core.JsInterop

type Model = {
    MinDate : DateTimeOffset option
    Today: DateTimeOffset
    MaxDate: DateTimeOffset option
    }

type Msg =
    | SetStartDate of DateTimeOffset
    | SetEndDate of DateTimeOffset

let today = DateTimeOffset.Now

let init () = {
    MinDate = today.AddDays -10.0 |> Some
    Today = today
    MaxDate = today.AddDays 10.0  |> Some }, Cmd.none

let update msg (model: Model) =
    match msg with
    | SetStartDate date -> { model with Today = date }, Cmd.none
    | SetEndDate date -> { model with Today = date }, Cmd.none

let renderWithClearButton (args,ref) =
        Html.div [
            Html.input [
                prop.custom ("ref", ref)
                // prop.value    (unbox<string> args?defaultValue)
                prop.defaultValue (args?defaultValue |> unbox<string>)
                prop.className "flatpickr-input"
            ]
            Html.button [
                prop.className "flatpickr-clear-button"
                prop.text "Clear"
                prop.onClick (fun ev ->
                    let target = ev.target :?> Browser.Types.HTMLElement
                    // the button’s previous sibling is the input
                    let input = target.previousElementSibling :?> Browser.Types.HTMLElement
                    if not (isNullOrUndefined input) then
                        let fp = input?_flatpickr
                        if not (isNull fp) then
                            fp?clear()
                            fp?close()
                )
            ]
        ]

[<ReactComponent>]
let FlatPickrControl (value: DateTimeOffset) (onChange: DateTimeOffset -> unit) =


    FlatPickr.flatPickr [
        flatPickr.className "input"

        // // store FP instance ONCE
        // flatPickr.onReady (fun (_dates, _str, instance) ->
        //     instanceRef.current <- Some instance
        // )

        flatPickr.onChange (fun (dates, _str, _instance) ->
            if dates.Length > 0 then
                let d = dates.[0]
                printfn "Selected date: %A" d
                let norm = DateTimeOffset(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0, d.Offset)
                onChange norm
        )
        flatPickr.options [
            option.dateFormat "d.m.Y H:i"
            option.allowInput true
            option.enableTime true
            option.time_24hr true
            option.locale "de"
            option.defaultDate (DateOption.DateTimeOffset value)
        ]
    ]

let view (model: Model) (dispatch: Msg -> unit) =

    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            Html.h1 (sprintf "current Start Date: %A" model.Today)
            FlatPickr.flatPickr [
                flatPickr.className "input"

                // // store FP instance ONCE
                // flatPickr.onReady (fun (_dates, _str, instance) ->
                //     instanceRef.current <- Some instance
                // )

                flatPickr.onChange (fun (dates, _str, _instance) ->
                    if dates.Length > 0 then
                        dispatch (SetStartDate dates.[0])
                )
                flatPickr.options [
                    option.dateFormat "d.m.Y H:i"
                    option.allowInput true
                    option.enableTime true
                    option.time_24hr true
                    option.locale "de"
                    option.defaultDate (DateOption.DateTimeOffset model.Today)
                ]
            ]
        ]
    ]
