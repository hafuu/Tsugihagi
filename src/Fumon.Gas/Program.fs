module Program

open Fable.Core
open Fumon.Core

let x() =
    DecisionTable.create [|
        {
          Name = "p1"
          Values = [| "a"; "b"; "c" |]
        }
        {
          Name = "p2"
          Values = [| "1"; "2" |]
        }
        {
          Name = "p3"
          Values = [| "あ"; |]
        }
    |]
    |> Seq.length
    |> string

type GlobalExports = {
    mutable x: unit -> string
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.x <- x
