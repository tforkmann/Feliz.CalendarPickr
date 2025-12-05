#### 0.9.0 - 2025-12-05
* BREAKING: Remove hardcoded material_green.css theme import
* Import base flatpickr.css instead, allowing users to apply their own theme or override colors via CSS variables
* This enables proper corporate design/white-label support where primary colors vary per tenant

#### 0.8.0 - 2025-12-05
* Add `option.inline'` for displaying calendar inline (always visible)

#### 0.7.0 - 2025-12-04
* Add onReady, onOpen, and onClose event callbacks
#### 0.6.0 - 2025-11-28
* Add range mode support with `FlatPickr.option.mode`, `FlatPickr.option.enableRange`
* Add multiple selection mode with `FlatPickr.option.enableMultiple`
* Add `flatPickr.onRangeChange` callback for range selection
* Add `flatPickr.onMultipleChange` callback for multiple date selection
* Add `FlatPickr.option.rangeSeparator` for customizing range display
* Add `FlatPickr.option.showMonths` for displaying multiple months
* Add `Mode` discriminated union type (Single, Range, Multiple)

#### 0.5.8 - 2025-11-14
* Fix onChange event
#### 0.5.7 - 2025-11-14
* Move defaultDate to Options
#### 0.5.6 - 2025-11-14
* Add defaultDate property
#### 0.5.5 - 2025-11-13
* Make minDate and maxDate optional
#### 0.5.4 - 2025-10-09
* Add clear button to DatePicker
#### 0.5.3 - 2025-09-11
* Introduce DateOption type to unify DateTime and DateTimeOffset handling
#### 0.5.1 - 2025-09-11
* Add DateTimeOffset support
#### 0.4.4 - 2025-09-10
* Remove border from current month
#### 0.4.3 - 2025-09-09
* Optimize override.css deployment
#### 0.4.2 - 2025-09-09
* Copy override.css to output directory
#### 0.3.0 - 2025-09-05
* Color overwrite
#### 0.2.6 - 2025-09-05
* Initial release
