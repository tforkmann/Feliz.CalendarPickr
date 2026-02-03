namespace Feliz.FlatPickr

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkFlatPickrProp (key: string) (value: obj) : IFlatPickrProp = unbox (key, value)
    let inline mkOptionsProp (key: string) (value: obj) : IOptionsProp = unbox (key, value)
    let inline mkStylesProp (key: string) (value: obj) : IFlatPickrStylesProp = unbox (key, value)
    let inline mkImperativeOptionsProp (key: string) (value: obj) : IImperativeOptionsProp = unbox (key, value)

    /// Direct flatpickr import (not react-flatpickr)
    let flatpickrModule: obj = importDefault "flatpickr"

    // Import base flatpickr CSS and locale files as side effects
    // This registers locales globally so we can use string identifiers
    importSideEffects "flatpickr/dist/flatpickr.css"
    importSideEffects "flatpickr/dist/l10n/de.js"
    importSideEffects "flatpickr/dist/l10n/fr.js"
    importSideEffects "flatpickr/dist/l10n/it.js"
    importSideEffects "./clearbutton.js"
    importSideEffects "./override.css"
    let flatPickr: obj = importDefault "react-flatpickr"
    let attachClearButton: obj -> unit = import "attachClearButton" "./clearbutton.js"

