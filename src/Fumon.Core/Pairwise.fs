module Fumon.Core.Pairwise

open Fumon.Core.Types

type IRandom with
    member this.Next(maxValue: int): int = this.Next(0, maxValue)
    member this.Pick(xs: ResizeArray<_>) = xs[this.Next(xs.Count)]
    member this.CopyAndShuffle(source: _[]): _[] =
        let xs = Array.copy source
        for i in 0 .. (xs.Length - 1) do
            let j = this.Next(i, xs.Length)
            let temp = xs[j]
            xs[j] <- xs[i]
            xs[i] <- temp
        xs
    member this.Shuffle(xs: ResizeArray<_>): unit =
        for i in 0 .. (xs.Count - 1) do
            let j = this.Next(i, xs.Count)
            let temp = xs[j]
            xs[j] <- xs[i]
            xs[i] <- temp
    member this.Shuffle(xs: _[], ?beginIndex: int): unit =
        let beginIndex = defaultArg beginIndex 0
        for i in beginIndex .. (xs.Length - 1) do
            let j = this.Next(i, xs.Length)
            let temp = xs[j]
            xs[j] <- xs[i]
            xs[i] <- temp

type PairwiseContext = {
    Input: CombinationInput
    Predicate: (Combination -> Ternary) option
    NumberPairs: int
    AllPairsDisplay: int[][]
    UnusedPairs: ResizeArray<int[]>
    UnusedPairsSearch: int[][]
    ParameterPositions: int[]
    UnusedCounts: int[]
}
with
    member this.Remove(testSet: int[]) =
        for i in 0 .. (testSet.Length - 2) do
            for j in (i + 1) .. (testSet.Length - 1) do
                let v1 = testSet[i]
                let v2 = testSet[j]

                this.UnusedCounts[v1] <- this.UnusedCounts[v1] - 1
                this.UnusedCounts[v2] <- this.UnusedCounts[v2] - 1

                this.UnusedPairsSearch[v1][v2] <- 0

                this.UnusedPairs.RemoveAll(fun curr -> curr[0] = v1 && curr[1] = v2) |> ignore

    member this.EvalPredicate(testCase: int seq): Ternary =
        match this.Predicate with
        | Some predicate ->
            let array = Array.create this.Input.Parameters.Length -1
            for t in testCase do
                array[this.Input.ParameterPositions[t]] <- t
            predicate array
        | None -> True
    
let numberPairsCaptured (unusedPairsSearch: int[][]) (ts: int[]): int =
    let mutable ans = 0
    for i in 0 .. (ts.Length - 2) do
        for j in (i + 1) .. (ts.Length - 1) do
            if unusedPairsSearch[ts[i]][ts[j]] = 1 then
                ans <- ans + 1
    ans

let init ({ NumberParameterValues = numberParameterValues; LegalValues = legalValues } as input) =
    let numberPairs =
        let mutable num = 0
        for i in 0 .. (legalValues.Length - 2) do
            for j in (i + 1) .. (legalValues.Length - 1) do
                num <- num + (legalValues[i].Length * legalValues[j].Length)
        num

    let allPairsDisplay = Array.init numberPairs (fun _ -> Array.create 2 0)
    let unusedPairs = ResizeArray<int[]>()
    let unusedPairsSearch = Array.init numberParameterValues (fun _ -> Array.create numberParameterValues 0)
    do
        let mutable currPair = 0
        for i in 0 .. (legalValues.Length - 2) do
            for j in (i + 1) .. (legalValues.Length - 1) do
                let firstRow = legalValues[i]
                let secondRow = legalValues[j]
                for x in 0 .. (firstRow.Length - 1) do
                    for y in 0 .. (secondRow.Length - 1) do
                        allPairsDisplay[currPair][0] <- firstRow[x]
                        allPairsDisplay[currPair][1] <- secondRow[y]

                        let aPair = [| firstRow[x]; secondRow[y] |]

                        unusedPairs.Add(aPair)
                        unusedPairsSearch[firstRow[x]][secondRow[y]] <- 1

                        currPair <- currPair + 1

    let parameterPositions = Array.create numberParameterValues 0
    do
        let mutable k = 0
        for i in 0 .. (legalValues.Length - 1) do
            let curr = legalValues[i]
            for j in 0 .. (curr.Length - 1) do
                parameterPositions[k] <- i
                k <- k + 1


    let unusedCounts = Array.create numberParameterValues 0
    do
        for i in 0 .. (numberPairs - 1) do
            unusedCounts[allPairsDisplay[i][0]] <- unusedCounts[allPairsDisplay[i][0]] + 1
            unusedCounts[allPairsDisplay[i][1]] <- unusedCounts[allPairsDisplay[i][1]] + 1

    {
        Input = input
        Predicate = None
        NumberPairs = numberPairs
        AllPairsDisplay = allPairsDisplay
        UnusedPairs = unusedPairs
        UnusedPairsSearch = unusedPairsSearch
        ParameterPositions = parameterPositions
        UnusedCounts = unusedCounts
    }

let betterPairs (random: IRandom) context =
    let unused = context.UnusedPairs.ToArray()
    random.Shuffle(unused)
    unused
    |> Array.sortByDescending (fun pair ->
        context.UnusedCounts[pair[0]] + context.UnusedCounts[pair[1]]
    )

let candidates' (random: IRandom) context (pair: int[]) =
    let numberParameters = context.Input.NumberParameters
    let legalValues = context.Input.LegalValues
    let unusedPairsSearch = context.UnusedPairsSearch
    let parameterPositions = context.ParameterPositions

    // pair = [| 2; 5 |]
    let firstPos = parameterPositions[pair[0]]
    let secondPos = parameterPositions[pair[1]]

    let ordering = Array.init numberParameters id // ordering = [| 0; 1; 2; 4; 5; 6; 7; 8 |]

    ordering[0] <- firstPos
    ordering[firstPos] <- 0 // ordering = [| 2; 1; 0; 3; 4; 5; 6; 7; 8 |]

    let t = ordering[1]
    ordering[1] <- secondPos
    ordering[secondPos] <- t // ordering = [| 2; 5; 0; 3; 4; 1; 6; 7; 8 |]

    random.Shuffle(ordering, 2) // ordering = [| 2; 5; 3; 0; 1; 6; 7; 4; 8 |]

    let result =
        seq { 2 .. (numberParameters - 1) }
        |> Seq.fold (fun (testSets: seq<int list>) i ->
            let possibleValues = legalValues[ordering[i]]
            testSets
            |> Seq.collect (fun testSet ->
                random.CopyAndShuffle(possibleValues)
                |> Array.choose (fun value ->
                    let current = value :: testSet
                    if context.EvalPredicate(current) <> False then
                        let currentCount = testSet |> List.sumBy (fun otherValue ->
                            let candidatePair = [| value; otherValue |]
                            if (unusedPairsSearch[candidatePair[0]][candidatePair[1]] = 1 || unusedPairsSearch[candidatePair[1]][candidatePair[0]] = 1) then
                                1
                            else
                                0
                        )
                        Some {| CurrentCount = currentCount; TestSet = current |}
                    else
                        None
                )
                |> Array.groupBy _.CurrentCount
                |> Array.maxBy fst
                |> snd
                |> Array.map _.TestSet
            )
            
        ) (Seq.singleton ([pair[1]; pair[0]]))
        |> Seq.map (fun testSet -> testSet |> List.toArray)

    result

let copyArray (source: _[]) (dest: _[]) = source |> Array.iteri (fun i x -> dest[i] <- x)

let removeInvalidPairs context =
    let invalids = context.UnusedPairs.ToArray() |> Array.filter (fun pair -> context.EvalPredicate(pair) = False)
    for i in 0 .. (invalids.Length - 1) do
        context.Remove(invalids[i])

let generate' (random: IRandom) context =
    let poolSize = 20

    if context.Predicate.IsSome then
        removeInvalidPairs context // 明らかに不要な組み合わせは事前に削除しておく

    let testSets = ResizeArray<int[]>()

    let mutable loop = true

    while loop do
        let candidateSets =
            betterPairs random context
            |> Seq.collect (candidates' random context)
            |> Seq.truncate poolSize
            |> Seq.toArray
        
        if candidateSets.Length = 0 then
            loop <- false
        else
            let bestTestSet = candidateSets |> Array.maxBy (numberPairsCaptured context.UnusedPairsSearch) |> Array.sort

            testSets.Add(bestTestSet)

            context.Remove(bestTestSet)

    testSets.ToArray() |> Array.sort

let generate (random: IRandom) (predicate: (Combination -> Ternary) option) (input: CombinationInput): Combination seq =
    let data = { init input with Predicate = predicate }
    let testSets = generate' random data
    testSets
