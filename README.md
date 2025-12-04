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
    ]
```

Available event callbacks:
- `flatPickr.onReady` - Fired when the calendar is ready and instance is created
- `flatPickr.onOpen` - Fired when the calendar is opened
- `flatPickr.onClose` - Fired when the calendar is closed
- `flatPickr.onChange` - Fired when a date is selected

You can find more examples [here](https://tforkmann.github.io/Feliz.FlatPickr/)
