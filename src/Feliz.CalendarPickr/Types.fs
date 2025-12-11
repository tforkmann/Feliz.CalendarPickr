namespace Feliz.FlatPickr

type IFlatPickrProp =
    interface
    end

type IFlatPickrStylesProp =
    interface
    end

type IOptionsProp =
    interface
    end

type IImperativeOptionsProp =
    interface
    end

/// FlatPickr selection mode
[<RequireQualifiedAccess>]
type Mode =
    /// Single date/time selection (default)
    | Single
    /// Select a date range (two dates)
    | Range
    /// Select multiple dates
    | Multiple
    member this.Value =
        match this with
        | Single -> "single"
        | Range -> "range"
        | Multiple -> "multiple"

[<RequireQualifiedAccess>]
type DateOption =
| Date of System.DateTime
| DateTimeOffset of System.DateTimeOffset
| String of string
| Number of float
    member this.Value =
        match this with
        | Date d -> d :> obj
        | DateTimeOffset dto -> dto :> obj
        | String s -> s :> obj
        | Number n -> n :> obj
