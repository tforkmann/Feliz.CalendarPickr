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

        // Event Callbacks
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
                Html.li [ Html.code [ prop.text "flatPickr.onMonthChange" ]; Html.text " - Fired when the month changes" ]
                Html.li [ Html.code [ prop.text "flatPickr.onYearChange" ]; Html.text " - Fired when the year changes" ]
                Html.li [ Html.code [ prop.text "flatPickr.onValueUpdate" ]; Html.text " - Fired when input value updates" ]
                Html.li [ Html.code [ prop.text "flatPickr.onDayCreate" ]; Html.text " - Full control over day cell elements" ]
            ]
        ]

        // Display Options
        Html.divClassed "description mt-4" [ Html.text "Display & UI options:" ]
        Html.ul [
            prop.className "list-disc ml-6"
            prop.children [
                Html.li [ Html.code [ prop.text "option.weekNumbers" ]; Html.text " - Show week numbers" ]
                Html.li [ Html.code [ prop.text "option.shorthandCurrentMonth" ]; Html.text " - Show month shorthand (Jan)" ]
                Html.li [ Html.code [ prop.text "option.altInput" ]; Html.text " - User-friendly date display" ]
                Html.li [ Html.code [ prop.text "option.inline'" ]; Html.text " - Always show calendar" ]
                Html.li [ Html.code [ prop.text "option.position" ]; Html.text " - Calendar position (auto, above, below)" ]
            ]
        ]

        // Time Options
        Html.divClassed "description mt-4" [ Html.text "Time picker options:" ]
        Html.ul [
            prop.className "list-disc ml-6"
            prop.children [
                Html.li [ Html.code [ prop.text "option.enableTime" ]; Html.text " - Enable time picker" ]
                Html.li [ Html.code [ prop.text "option.enableSeconds" ]; Html.text " - Enable seconds" ]
                Html.li [ Html.code [ prop.text "option.hourIncrement" ]; Html.text " - Hour step" ]
                Html.li [ Html.code [ prop.text "option.minuteIncrement" ]; Html.text " - Minute step" ]
                Html.li [ Html.code [ prop.text "option.time_24hr" ]; Html.text " - Use 24-hour format" ]
            ]
        ]

        // Date Constraints
        Html.divClassed "description mt-4" [ Html.text "Date constraint options:" ]
        Html.ul [
            prop.className "list-disc ml-6"
            prop.children [
                Html.li [ Html.code [ prop.text "option.minDate" ]; Html.text " - Minimum selectable date" ]
                Html.li [ Html.code [ prop.text "option.maxDate" ]; Html.text " - Maximum selectable date" ]
                Html.li [ Html.code [ prop.text "option.disableBy" ]; Html.text " - Disable dates by predicate (e.g., weekends)" ]
                Html.li [ Html.code [ prop.text "option.disableDates" ]; Html.text " - Disable specific dates" ]
                Html.li [ Html.code [ prop.text "option.disableRanges" ]; Html.text " - Disable date ranges" ]
                Html.li [ Html.code [ prop.text "option.enableBy" ]; Html.text " - Enable only specific dates" ]
            ]
        ]
    ]
