module Docs.Pages.Use

open Feliz
open Docs.SharedView

[<ReactComponent>]
let UseView () =
    React.fragment [
        Html.divClassed "description" [ Html.text "After installation just open proper namespace:" ]
        Html.divClassed "max-w-xl" [ linedMockupCode "open Feliz.FlatPickr" ]
        Html.divClassed
            "description"
            [ Html.text "Now you can start using the library. Everything important starts with "
              Html.code [
                  prop.className "code"
                  prop.text "FlatPickr.*"
              ]
              Html.text " and "
              Html.code [
                  prop.className "code"
                  prop.text "flatPickr.*"
              ]
              Html.text " modules." ]
        Html.divClassed "description mt-4" [ Html.text "Available event callbacks:" ]
        Html.ul [
            prop.className "list-disc ml-6"
            prop.children [
                Html.li [ Html.code [ prop.text "flatPickr.onChange" ]; Html.text " - Fired when a date is selected" ]
                Html.li [ Html.code [ prop.text "flatPickr.onRangeChange" ]; Html.text " - Fired when a date range is selected" ]
                Html.li [ Html.code [ prop.text "flatPickr.onMultipleChange" ]; Html.text " - Fired when multiple dates are selected" ]
                Html.li [ Html.code [ prop.text "flatPickr.onReady" ]; Html.text " - Fired when the calendar is ready" ]
                Html.li [ Html.code [ prop.text "flatPickr.onOpen" ]; Html.text " - Fired when the calendar is opened" ]
                Html.li [ Html.code [ prop.text "flatPickr.onClose" ]; Html.text " - Fired when the calendar is closed" ]
            ]
        ]
    ]
