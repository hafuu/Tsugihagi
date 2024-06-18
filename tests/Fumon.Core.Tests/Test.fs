module Test

open System
open NUnit.Framework
open FsUnit
open FsUnitTyped

[<Test>]
let hoge() =
    1 |> shouldEqual 1
