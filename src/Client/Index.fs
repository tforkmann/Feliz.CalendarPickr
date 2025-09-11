module Index

open Elmish
open Feliz
open Feliz.FlatPickr
open System
open Fable.I18Next

type Model = { Date: DateTimeOffset }

type Msg =
    | SetStartDate of DateTimeOffset
    | SetEndDate of DateTimeOffset

let init () =
    { Date = DateTimeOffset.Now }, Cmd.none

let update msg (model: Model) =
    match msg with
    | SetStartDate date -> { model with Date = date }, Cmd.none
    | SetEndDate date -> { model with Date = date }, Cmd.none

let view (model: Model) (dispatch: Msg -> unit) =
    // let format = "d.m.Y H:i"
    let format = "d.m.Y"

    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            FlatPickr.flatPickr [
                flatPickr.disabled false
                flatPickr.value (Some model.Date)
                flatPickr.options [ option.allowInput true; option.clearable true ]
                flatPickr.themeColors (primary = "#D50037", secondary = "#333F4C")
            ]
            FlatPickr.flatPickr [
                flatPickr.disabled false
                flatPickr.value (Some model.Date)
                flatPickr.className "input"
                flatPickr.title (Some "abc")
                flatPickr.themeColors (primary = "#93C90E", secondary = "#000000")
                flatPickr.options [
                    option.allowInput true
                    option.clearable true
                    option.enableTime (format.IndexOfAny [| 'H'; 'h'; 'G'; 'i'; 'S'; 's'; 'K' |] <> -1)
                    option.noCalendar (
                        format.IndexOfAny [| 'd'; 'D'; 'l'; 'j'; 'J'; 'w'; 'W'; 'F'; 'm'; 'n'; 'M'; 'y'; 'Y' |] = -1
                    )
                    option.dateFormat format
                    option.time_24hr (not (format.Contains("K")))
                    option.locale (
                        I18n.GetLanguage()
                        |> function
                            | "de" -> "de"
                            | _ -> "default"
                    )
                    option.disableMobile true
                ]

            ]

        ]
    ]
