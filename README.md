# Feliz Binding for [react-flatpickr](https://github.com/hypeserver/react-date-range)

[![Feliz.FlatPickr on Nuget](https://buildstats.info/nuget/Feliz.FlatPickr)](https://www.nuget.org/packages/Feliz.FlatPickr/)
[![Docs](https://github.com/tforkmann/Feliz.FlatPickr/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.FlatPickr/actions/workflows/Docs.yml)

## Installation
Install the nuget package
```
dotnet paket add Feliz.FlatPickr
```

and install the npm package

```
npm install --save react-date-range
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

## Example DateRange
Here is an example DateRange
```fs
[<ReactComponent>]
let DateRangePicker (startDate,endDate,setStartDate,setEndDate) =
    DateRange.dateRangePicker [
        dateRangePicker.months 2
        dateRangePicker.showSelectionPreview true
        dateRangePicker.moveRangeOnFirstSelection false
        dateRangePicker.direction Direction.Horizontal
        dateRangePicker.locale DateTime.Locales.German
        dateRangePicker.onChange (fun handler ->
            setStartDate handler.range1.startDate
            setEndDate handler.range1.endDate
        )
        dateRangePicker.ranges [
            dateRangePicker.range [
                ranges.startDate startDate
                ranges.endDate endDate
            ]
        ]
    ]
```

You can find more examples [here](https://tforkmann.github.io/Feliz.FlatPickr/)
