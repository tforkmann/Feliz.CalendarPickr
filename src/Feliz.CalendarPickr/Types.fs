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
