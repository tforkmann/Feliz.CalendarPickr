module Docs.Pages.ImperativeFlatPickrView

open Feliz
open Feliz.Bulma
open Feliz.FlatPickr
open Docs.SharedView
open System
open Browser.Types

let code =
    """
    // Imperative FlatPickr provides direct control over the flatpickr instance.
    // Use this when you need programmatic control (SetDate, Clear, IsOpen).

    let picker = ImperativeFlatPickr.useImperativeFlatPickr [
        imperativeOption.dateFormat "d.m.Y H:i"
        imperativeOption.enableTime true
        imperativeOption.time_24hr true
        imperativeOption.locale "de"
        imperativeOption.disableMobile true
        imperativeOption.onChange (fun dates ->
            if dates.Length > 0 then
                printfn "Selected: %A" dates.[0]
        )
    ]

    Html.input [
        prop.ref (fun el ->
            if not (isNull el) && picker.InputRef.current.IsNone then
                picker.InputRef.current <- Some (el :?> HTMLInputElement)
        )
        prop.className "input"
        prop.placeholder "Select date..."
    ]

    // Programmatic control:
    // picker.SetDate (Some DateTimeOffset.Now)  // Set date
    // picker.Clear ()                           // Clear selection
    // picker.IsOpen ()                          // Check if open

    // With stable callback refs (for Elmish dispatch):
    let pickerWithRefs = ImperativeFlatPickr.useImperativeFlatPickrWithCallbackRefs
        [
            imperativeOption.dateFormat "d.m.Y"
            imperativeOption.enableTime false
        ]
        (Some (fun dates -> dispatch (DateChanged dates)))  // onChange
        (Some (fun () -> dispatch CalendarOpened))          // onOpen
        (Some (fun dates _ -> dispatch (CalendarClosed dates)))  // onClose
    """

[<ReactComponent>]
let ImperativeFlatPickrDemo () =
    let picker = ImperativeFlatPickr.useImperativeFlatPickr [
        imperativeOption.dateFormat "d.m.Y H:i"
        imperativeOption.enableTime true
        imperativeOption.time_24hr true
        imperativeOption.locale "de"
        imperativeOption.disableMobile true
        imperativeOption.onChange (fun dates ->
            if dates.Length > 0 then
                Browser.Dom.console.log("Selected:", dates.[0])
        )
    ]

    Html.div [
        prop.style [ style.display.flex; style.gap 10; style.alignItems.center ]
        prop.children [
            Html.input [
                prop.ref (fun el ->
                    if not (isNull el) && picker.InputRef.current.IsNone then
                        picker.InputRef.current <- Some (el :?> HTMLInputElement)
                )
                prop.className "input"
                prop.style [ style.width 200 ]
                prop.placeholder "Select date..."
            ]
            Html.button [
                prop.className "btn btn-sm"
                prop.text "Set Now"
                prop.onClick (fun _ -> picker.SetDate (Some DateTimeOffset.Now))
            ]
            Html.button [
                prop.className "btn btn-sm"
                prop.text "Clear"
                prop.onClick (fun _ -> picker.Clear ())
            ]
        ]
    ]

let title = Html.text "Imperative FlatPickr"

[<ReactComponent>]
let ImperativeFlatPickrView () =
    Html.div [
        Bulma.content [
            codedView title code (ImperativeFlatPickrDemo ())
        ]
        fixDocsView "ImperativeFlatPickr" false
    ]
