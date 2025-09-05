module Index

open Elmish
open Feliz
open Feliz.CalendarPickr
open System

type Model = { Date: DateTimeOffset }

type Msg =
    | SetStartDate of DateTimeOffset
    | SetEndDate of DateTimeOffset

let init () =
    {
        Date = DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero)
    },
    Cmd.none

let update msg (model: Model) =
    match msg with
    | SetStartDate date -> { model with Date = date }, Cmd.none
    | SetEndDate date -> { model with Date = date }, Cmd.none

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            FlatPickr.flatPickr [
                flatPickr.disabled false
                flatPickr.value model.Date
                flatPickr.options [
                    option.allowInput true
                    option.clearable true
                ]

            ]

        ]
    ]
