namespace FLib

open System.Runtime.CompilerServices

type Data = Data of string


[<Extension>]
type FLibExtensions =
    
    [<Extension>]
    static member Length(x:Data) =
        match x with
        | Data s -> s.Length