module Index

open Elmish
open Feliz
open Feliz.FlatPickr
open System

type Model = { Date: DateTime }

type Msg =
    | SetStartDate of DateTime
    | SetEndDate of DateTime

let init () =
    {
        Date = DateTime(2019, 1, 1)
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
                flatPickr.value (Some model.Date)
                flatPickr.options [
                    option.allowInput true
                    option.clearable true
                ]
                flatPickr.themeColors(primary="#D50037", secondary="#333F4C")

            ]

        ]
    ]
