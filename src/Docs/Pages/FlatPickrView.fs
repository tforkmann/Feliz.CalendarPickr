module Docs.Pages.FlatPickrView

open Feliz
open Feliz.Bulma
open Feliz.FlatPickr
open Docs.SharedView
open System
open Feliz.UseElmish
open Elmish

type Msg =
    | SetStartDate of DateTimeOffset
    | SetEndDate of DateTimeOffset

type State =
    { StartDate: DateTimeOffset
      EndDate: DateTimeOffset }

let init () =
    {
        StartDate = DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero)
        EndDate = DateTimeOffset(2019, 1, 31, 0, 0, 0, TimeSpan.Zero)
    },
    Cmd.none

let update msg (model: State) =
    match msg with
    | SetStartDate date -> { model with StartDate = date }, Cmd.none
    | SetEndDate date -> { model with EndDate = date }, Cmd.none

let FlatPickr (state: State) (dispatch: Msg -> unit) =
    let now = DateTime.Now

    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            FlatPickr.flatPickr [
            flatPickr.disabled false
            flatPickr.value (DateOption.Date now)
            flatPickr.options [
                option.allowInput true
                option.clearable true
            ]
            flatPickr.themeColors(primary="#D50037", secondary="#333F4C")
        ]
        ]
    ]


let code =
    """
    FlatPickr.flatPickr [
        flatPickr.disabled false
        flatPickr.value (Some now)
        flatPickr.options [
            option.allowInput true
            option.clearable true
            // v1.0 options
            option.weekNumbers true
            option.altInput true
            option.altFormat "F j, Y"
            option.position "below"
        ]
        flatPickr.themeColors(primary="#D50037", secondary="#333F4C")
        // Event callbacks
        flatPickr.onReady (fun (dates, dateStr, instance) -> ())
        flatPickr.onOpen (fun (dates, dateStr, instance) -> ())
        flatPickr.onClose (fun (dates, dateStr, instance) -> ())
        flatPickr.onMonthChange (fun (dates, dateStr, instance) -> ())
        flatPickr.onYearChange (fun (dates, dateStr, instance) -> ())
    ]

    // Disable weekends example
    FlatPickr.flatPickr [
        flatPickr.options [
            option.disableBy (fun date ->
                date.DayOfWeek = DayOfWeek.Saturday ||
                date.DayOfWeek = DayOfWeek.Sunday
            )
        ]
    ]

    // Time picker with seconds
    FlatPickr.flatPickr [
        flatPickr.options [
            option.enableTime true
            option.enableSeconds true
            option.hourIncrement 1
            option.minuteIncrement 15
            option.time_24hr true
        ]
    ]
    """

let title = Html.text "FlatPickr"

[<ReactComponent>]
let FlatPickrView () =
    let state,dispatch = React.useElmish(init, update, [||])
    Html.div [
        Bulma.content [
            codedView title code (FlatPickr state dispatch)
        ]
        fixDocsView "FlatPickr" false
    ]
