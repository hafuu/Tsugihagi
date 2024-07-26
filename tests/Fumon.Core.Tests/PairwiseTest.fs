module PairwiseTest

open NUnit.Framework
open FsUnitTyped

open Fumon.Core
open Fumon.Core.Types
open Utils

let random =
    let random = System.Random()
    { new IRandom with
        member this.Next(minValue: int, maxValue: int): int =
            random.Next(minValue, maxValue)
    }

let toArrayArray (xss: int[,]) = Array.init (xss.GetLength(0)) (fun i -> xss[i, *])

let printInit input =
    let printArrayArray (xss: int[][]) =
        for xs in xss do
            printfn "  %s" (xs |> Seq.map string |> String.concat "; ")

    let context = Pairwise.init input

    printfn "numberParameters: %d" context.Input.NumberParameters
    printfn "numberParameterValues: %d" context.Input.NumberParameterValues
    printfn "numberPairs: %d" context.NumberPairs

    printfn "parameterValues: %s" (context.Input.ParameterValues |> Seq.map _.Value |> String.concat "; ")

    printfn "legalValues:"
    context.Input.LegalValues |> printArrayArray

    printfn "allPairsDisplay:"
    context.AllPairsDisplay |> toArrayArray |> printArrayArray
           
    printfn "unusedPairs:"
    context.UnusedPairs |> Seq.toArray |> printArrayArray

    printfn "unusedPairsSearch:"
    context.UnusedPairsSearch |> toArrayArray |> printArrayArray

    printfn "parameterPositions: %s" (context.ParameterPositions |> Seq.map string |> String.concat "; ")

    printfn "unusedCounts: %s" (context.UnusedCounts |> Seq.map string |> String.concat "; ")

[<Test>]
let ``初期化できる``() =
    let parameters = [|
        p (v "p1") [| v "a"; v "b" |]
        p (v "p2") [| v "c"; v "d"; v "e"; v "f" |]
        p (v "p3") [| v "g"; v "h"; v "i" |]
        p (v "p4") [| v "j"; v "k" |]
    |]
    let input = ParameterReader.preprocess parameters

    let context = Pairwise.init input

    context.NumberPairs |> shouldEqual 44
    
    let allPairs = [|
        [| 0; 2  |]
        [| 0; 3  |]
        [| 0; 4  |]
        [| 0; 5  |]
        [| 1; 2  |]
        [| 1; 3  |]
        [| 1; 4  |]
        [| 1; 5  |]
        [| 0; 6  |]
        [| 0; 7  |]
        [| 0; 8  |]
        [| 1; 6  |]
        [| 1; 7  |]
        [| 1; 8  |]
        [| 0; 9  |]
        [| 0; 10 |]
        [| 1; 9  |]
        [| 1; 10 |]
        [| 2; 6  |]
        [| 2; 7  |]
        [| 2; 8  |]
        [| 3; 6  |]
        [| 3; 7  |]
        [| 3; 8  |]
        [| 4; 6  |]
        [| 4; 7  |]
        [| 4; 8  |]
        [| 5; 6  |]
        [| 5; 7  |]
        [| 5; 8  |]
        [| 2; 9  |]
        [| 2; 10 |]
        [| 3; 9  |]
        [| 3; 10 |]
        [| 4; 9  |]
        [| 4; 10 |]
        [| 5; 9  |]
        [| 5; 10 |]
        [| 6; 9  |]
        [| 6; 10 |]
        [| 7; 9  |]
        [| 7; 10 |]
        [| 8; 9  |]
        [| 8; 10 |]
    |]
    context.AllPairsDisplay |> shouldEqual (array2D allPairs)
    context.UnusedPairs |> shouldEqual (ResizeArray(allPairs))

    context.UnusedPairsSearch |> shouldEqual (array2D [|
        [| 0; 0; 1; 1; 1; 1; 1; 1; 1; 1; 1 |]
        [| 0; 0; 1; 1; 1; 1; 1; 1; 1; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 1; 1; 1; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 1; 1; 1; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 1; 1; 1; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 1; 1; 1; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 0; 0; 0; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 0; 0; 0; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 0; 0; 0; 1; 1 |]
        [| 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0 |]
        [| 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0 |]
    |])

    context.ParameterPositions |> shouldEqual [| 0; 0; 1; 1; 1; 1; 2; 2; 2; 3; 3 |]
    context.UnusedCounts |> shouldEqual [|9; 9; 7; 7; 7; 7; 8; 8; 8; 9; 9  |]

[<Test>]
let ``生成できる``() =
    let parameters = [|
        p (v "p1") [| v "a"; v "b" |]
        p (v "p2") [| v "c"; v "d"; v "e"; v "f" |]
        p (v "p3") [| v "g"; v "h"; v "i" |]
        p (v "p4") [| v "j"; v "k" |]
        //p (v "p5") [| v "l"; v "m"; v "n"|]
        //p (v "p6") [| v "o"; v "p"; v "q"; v "r"; v "s" |]
    |]
    let input = ParameterReader.preprocess parameters

    let context = Pairwise.init input
    let result = Pairwise.generate' random context |> Seq.toArray

    let ok =
        context.AllPairsDisplay
        |> toArrayArray
        |> Array.forall (fun pair ->
            result
            |> Seq.exists (fun row ->
                Array.contains pair[0] row && Array.contains pair[1] row 
            )
        )

    result
    |> Seq.toArray
    |> printfn "%A"

    Seq.length result |> shouldBeSmallerThan context.NumberPairs
    ok |> shouldEqual true
