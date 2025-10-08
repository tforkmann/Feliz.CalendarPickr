module Index

open Elmish
open Feliz
open Feliz.FlatPickr
open System
open Fable.I18Next
open Fable.Core.JsInterop

type Model = { Date: DateTime }

type Msg =
    | SetStartDate of DateTime
    | SetEndDate of DateTime

let init () = { Date = DateTime.Now }, Cmd.none

let update msg (model: Model) =
    match msg with
    | SetStartDate date -> { model with Date = date }, Cmd.none
    | SetEndDate date -> { model with Date = date }, Cmd.none

let private renderWithClearButton: obj * obj -> ReactElement =
    fun (args, ref) ->
        Html.div [
            Html.input [
                prop.custom ("ref", ref)
                prop.defaultValue (unbox<string> args?defaultValue)
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

let view (model: Model) (dispatch: Msg -> unit) =
    // let format = "d.m.Y H:i"
    let format = "d.m.Y"

    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            FlatPickr.flatPickr [
                flatPickr.disabled false
                flatPickr.value (DateOption.Date model.Date)
                flatPickr.className "input"
                flatPickr.title (Some "abc")
                flatPickr.onChange (fun (dates, string, instance) ->
                    if dates.Length > 0 then
                        dispatch (SetStartDate dates[0].Date))
                flatPickr.themeColors (primary = "#93C90E", secondary = "#000000")
                flatPickr.showClearButton true
                flatPickr.render (fun (args, ref) -> renderWithClearButton (args, ref))
                flatPickr.options [
                    option.allowInput true
                    option.clearable true
                    option.enableTime (format.IndexOfAny [| 'H'; 'h'; 'G'; 'i'; 'S'; 's'; 'K' |] <> -1)
                    option.noCalendar (
                        format.IndexOfAny [| 'd'; 'D'; 'l'; 'j'; 'J'; 'w'; 'W'; 'F'; 'm'; 'n'; 'M'; 'y'; 'Y' |] = -1
                    )
                    option.dateFormat format
                    option.time_24hr (not (format.Contains "K"))
                    option.locale "de"
                    option.maxDate (DateOption.Date model.Date)
                    option.disableMobile true
                ]
            ]

        ]
    ]
