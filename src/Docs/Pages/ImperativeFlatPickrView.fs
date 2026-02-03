module Docs.Pages.ImperativeFlatPickrView

open Feliz
open Feliz.Bulma
open Feliz.FlatPickr
open Docs.SharedView
open System
open Browser.Types

let code =
    """
    // Imperative FlatPickr with Locale DU (type-safe localization)

    // Available locales:
    // - Locale.German   (de)
    // - Locale.English  (en - default)
    // - Locale.French   (fr)
    // - Locale.Italian  (it)

    let picker = ImperativeFlatPickr.useImperativeFlatPickr [
        imperativeOption.dateFormat "d.m.Y H:i"
        imperativeOption.enableTime true
        imperativeOption.time_24hr true
        imperativeOption.locale Locale.German  // Type-safe locale!
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
    """

[<ReactComponent>]
let LocalizedPicker (label: string) (locale: Locale) =
    let picker = ImperativeFlatPickr.useImperativeFlatPickr [
        imperativeOption.dateFormat "d.m.Y"
        imperativeOption.enableTime false
        imperativeOption.locale locale
        imperativeOption.disableMobile true
    ]

    Html.div [
        prop.style [ style.marginBottom 20 ]
        prop.children [
            Html.label [
                prop.style [ style.fontWeight.bold; style.marginRight 10 ]
                prop.text label
            ]
            Html.input [
                prop.ref (fun el ->
                    if not (isNull el) && picker.InputRef.current.IsNone then
                        picker.InputRef.current <- Some (el :?> HTMLInputElement)
                )
                prop.className "input"
                prop.style [ style.width 200 ]
                prop.placeholder "Select date..."
            ]
        ]
    ]

[<ReactComponent>]
let ImperativeFlatPickrDemo () =
    Html.div [
        prop.children [
            Html.h3 "Locale Examples"
            LocalizedPicker "German (Locale.German):" Locale.German
            LocalizedPicker "English (Locale.English):" Locale.English
            LocalizedPicker "French (Locale.French):" Locale.French
            LocalizedPicker "Italian (Locale.Italian):" Locale.Italian
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
