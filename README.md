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

You can find more examples [here](https://tforkmann.github.io/Feliz.FlatPickr/)
