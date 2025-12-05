# Feliz Binding for [react-flatpickr](https://github.com/haoxins/react-flatpickr)

[![Feliz.FlatPickr on Nuget](https://buildstats.info/nuget/Feliz.FlatPickr)](https://www.nuget.org/packages/Feliz.FlatPickr/)
[![Docs](https://github.com/tforkmann/Feliz.FlatPickr/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.FlatPickr/actions/workflows/Docs.yml)

## Installation
Install the nuget package
```
dotnet paket add Feliz.FlatPickr
```

and install the npm package

```
npm install --save react-flatpickr
```

or use Femto:
```
femto install Feliz.FlatPickr
```

## Start test app

- Start your test app by cloning this repository and then execute:
```
dotnet run
```

## Example FlatPickr usage
Here is an example FlatPickr
```fs
[<ReactComponent>]
let FlatPickr date =
     FlatPickr.flatPickr [
        flatPickr.disabled false
        flatPickr.value date
        flatPickr.options [
            option.allowInput true
            option.clearable true
        ]
    ]

```

## Date Range Picker
Select a date range (start and end date):
```fs
[<ReactComponent>]
let DateRangePicker () =
    let range, setRange = React.useState<(DateTimeOffset * DateTimeOffset) option>(None)

    FlatPickr.flatPickr [
        flatPickr.onRangeChange setRange
        flatPickr.options [
            FlatPickr.option.enableRange        // Enable range mode
            FlatPickr.option.showMonths 2       // Show 2 months side by side
            FlatPickr.option.rangeSeparator " bis "  // German "to"
            FlatPickr.option.dateFormat "d.m.Y"
        ]
    ]
```

## Time Range Picker
Select a time range:
```fs
[<ReactComponent>]
let TimeRangePicker () =
    let range, setRange = React.useState<(DateTimeOffset * DateTimeOffset) option>(None)

    FlatPickr.flatPickr [
        flatPickr.onRangeChange setRange
        flatPickr.options [
            FlatPickr.option.enableRange
            FlatPickr.option.enableTime true
            FlatPickr.option.noCalendar true    // Time only, no date
            FlatPickr.option.time_24hr true
            FlatPickr.option.dateFormat "H:i"
        ]
    ]
```

## Multiple Date Selection
Select multiple dates:
```fs
[<ReactComponent>]
let MultipleDatePicker () =
    let dates, setDates = React.useState<DateTimeOffset[]>([||])

    FlatPickr.flatPickr [
        flatPickr.onMultipleChange setDates
        flatPickr.options [
            FlatPickr.option.enableMultiple
        ]
    ]
```

## Event Callbacks
Handle calendar lifecycle events:
```fs
[<ReactComponent>]
let FlatPickrWithEvents () =
    FlatPickr.flatPickr [
        flatPickr.onReady (fun (dates, dateStr, instance) ->
            printfn "Calendar ready with %d dates" dates.Length
        )
        flatPickr.onOpen (fun (dates, dateStr, instance) ->
            printfn "Calendar opened"
        )
        flatPickr.onClose (fun (dates, dateStr, instance) ->
            printfn "Calendar closed with selection: %s" dateStr
        )
        flatPickr.onChange (fun (dates, dateStr, instance) ->
            printfn "Date changed to: %s" dateStr
        )
        flatPickr.onMonthChange (fun (dates, dateStr, instance) ->
            printfn "Month changed"
        )
        flatPickr.onYearChange (fun (dates, dateStr, instance) ->
            printfn "Year changed"
        )
    ]
```

Available event callbacks:
- `flatPickr.onChange` - Fired when a date is selected
- `flatPickr.onRangeChange` - Fired when a date range is selected
- `flatPickr.onMultipleChange` - Fired when multiple dates are selected
- `flatPickr.onReady` - Fired when the calendar is ready and instance is created
- `flatPickr.onOpen` - Fired when the calendar is opened
- `flatPickr.onClose` - Fired when the calendar is closed
- `flatPickr.onMonthChange` - Fired when the month changes
- `flatPickr.onYearChange` - Fired when the year changes
- `flatPickr.onValueUpdate` - Fired when input value updates
- `flatPickr.onDayCreate` - Full control over day cell elements

## Week Numbers
Show week numbers in the calendar:
```fs
FlatPickr.flatPickr [
    flatPickr.options [
        option.weekNumbers true
    ]
]
```

## Disable Dates
Disable specific dates, ranges, or use a predicate function:
```fs
// Disable weekends
FlatPickr.flatPickr [
    flatPickr.options [
        option.disableBy (fun date ->
            date.DayOfWeek = DayOfWeek.Saturday ||
            date.DayOfWeek = DayOfWeek.Sunday
        )
    ]
]

// Disable specific dates
FlatPickr.flatPickr [
    flatPickr.options [
        option.disableDates [ "2025-12-25"; "2025-12-26"; "2025-01-01" ]
    ]
]

// Disable date ranges
FlatPickr.flatPickr [
    flatPickr.options [
        option.disableRanges [
            (DateOption.DateTime (DateTime(2025, 12, 24)),
             DateOption.DateTime (DateTime(2025, 12, 31)))
        ]
    ]
]
```

## Time Picker Options
Configure the time picker with custom increments and seconds:
```fs
FlatPickr.flatPickr [
    flatPickr.options [
        option.enableTime true
        option.enableSeconds true
        option.hourIncrement 1
        option.minuteIncrement 15
        option.defaultHour 9
        option.defaultMinute 0
        option.time_24hr true
    ]
]
```

## User-Friendly Date Display
Show a formatted date to users while keeping the actual value:
```fs
FlatPickr.flatPickr [
    flatPickr.options [
        option.altInput true
        option.altFormat "F j, Y"      // "December 5, 2025"
        option.dateFormat "Y-m-d"       // Actual value: "2025-12-05"
    ]
]
```

## Calendar Position
Control where the calendar appears:
```fs
FlatPickr.flatPickr [
    flatPickr.options [
        option.position "above"         // "auto", "above", "below"
        option.static' true             // Position next to input
    ]
]
```

## Inline Calendar
Display the calendar always visible (no input field):
```fs
FlatPickr.flatPickr [
    flatPickr.options [
        option.inline' true
    ]
]
```

## Custom Navigation Arrows
Customize the month navigation icons:
```fs
FlatPickr.flatPickr [
    flatPickr.options [
        option.prevArrow "<i class='fa fa-chevron-left'></i>"
        option.nextArrow "<i class='fa fa-chevron-right'></i>"
    ]
]
```

## All Available Options

### Display & UI
| Option | Description |
|--------|-------------|
| `weekNumbers` | Show week numbers |
| `shorthandCurrentMonth` | Show month shorthand (e.g., "Jan") |
| `monthSelectorType` | "dropdown" or "static" |
| `altInput` | Show user-friendly date format |
| `altFormat` | Format for altInput display |
| `altInputClass` | CSS class for alt input |
| `ariaDateFormat` | Accessibility date format |
| `inline'` | Always show calendar |

### Position
| Option | Description |
|--------|-------------|
| `position` | "auto", "above", "below", etc. |
| `static'` | Position next to input |
| `appendTo` | Attach to DOM element |

### Time
| Option | Description |
|--------|-------------|
| `enableTime` | Enable time picker |
| `enableSeconds` | Enable seconds |
| `hourIncrement` | Hour step |
| `minuteIncrement` | Minute step |
| `defaultHour` | Initial hour |
| `defaultMinute` | Initial minute |
| `defaultSeconds` | Initial seconds |
| `time_24hr` | Use 24-hour format |
| `noCalendar` | Time only, no calendar |

### Date Constraints
| Option | Description |
|--------|-------------|
| `minDate` | Minimum selectable date |
| `maxDate` | Maximum selectable date |
| `disable` | Disable DateOption array |
| `disableDates` | Disable string dates |
| `disableBy` | Disable by predicate function |
| `disableRanges` | Disable date ranges |
| `enable` | Enable only specific dates |
| `enableDates` | Enable string dates |
| `enableBy` | Enable by predicate function |
| `enableRanges` | Enable date ranges |

### Behavior
| Option | Description |
|--------|-------------|
| `clickOpens` | Click to open (default: true) |
| `allowInput` | Allow manual input |
| `wrap` | Enable input groups |

### Navigation
| Option | Description |
|--------|-------------|
| `prevArrow` | Previous month HTML |
| `nextArrow` | Next month HTML |

You can find more examples [here](https://tforkmann.github.io/Feliz.FlatPickr/)
