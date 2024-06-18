module Program

open Test
open Fable.Core

let x() = String.concat "," (hello())

type GlobalExports = {
    mutable x: unit -> string
}

[<Global>]
let ``global``: GlobalExports = jsNative

``global``.x <- x
