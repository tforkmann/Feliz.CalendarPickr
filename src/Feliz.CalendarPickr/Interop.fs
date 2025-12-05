namespace Feliz.FlatPickr

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkFlatPickrProp (key: string) (value: obj) : IFlatPickrProp = unbox (key, value)
    let inline mkOptionsProp (key: string) (value: obj) : IOptionsProp = unbox (key, value)
    let inline mkStylesProp (key: string) (value: obj) : IFlatPickrStylesProp = unbox (key, value)

    // Import base flatpickr CSS instead of hardcoded theme
    // Users can import their own theme or override colors via CSS variables
    importSideEffects "flatpickr/dist/flatpickr.css"
    importSideEffects "flatpickr/dist/l10n/de.js"
    importSideEffects "./clearbutton.js"
    importSideEffects "./override.css"
    let flatPickr: obj = importDefault "react-flatpickr"
    let attachClearButton: obj -> unit = import "attachClearButton" "./clearbutton.js"

