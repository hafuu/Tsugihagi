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
    NumberPairs: int
    AllPairsDisplay: int[][]
    UnusedPairs: ResizeArray<int[]>
    UnusedPairsSearch: int[][]
    ParameterPositions: int[]
    UnusedCounts: int[]
}
    
let numberPairsCaptured (ts: int[]) (unusedPairsSearch: int[][]): int =
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
        NumberPairs = numberPairs
        AllPairsDisplay = allPairsDisplay
        UnusedPairs = unusedPairs
        UnusedPairsSearch = unusedPairsSearch
        ParameterPositions = parameterPositions
        UnusedCounts = unusedCounts
    }

let bestPairs { UnusedPairs = unusedPairs; UnusedCounts = unusedCounts } =
    let result = ResizeArray<int[]>()
    
    let worstWeight = Array.min  unusedCounts * 2
    let mutable bestWeight = worstWeight
    
    for current in unusedPairs do
        let weight = unusedCounts[current[0]] + unusedCounts[current[1]]
        if weight > bestWeight then
            result.Clear()
            result.Add(current)
            bestWeight <- weight
        elif weight = bestWeight then
            result.Add(current)

    result

let candidates (random: IRandom) ({
    Input = {
        NumberParameters = numberParameters
        LegalValues = legalValues
    }
    UnusedPairsSearch = unusedPairsSearch
    ParameterPositions = parameterPositions
} as context) =
    let best = random.Pick(bestPairs context) // best = [| 2; 5 |]

    let firstPos = parameterPositions[best[0]]
    let secondPos = parameterPositions[best[1]]

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
            let currPos = ordering[i]
            let possibleValues = legalValues[currPos]
            testSets
            |> Seq.collect (fun testSet ->
                let mutable highestCount = 0
                let result = ResizeArray()

                for value in random.CopyAndShuffle(possibleValues) do
                    let currentCount = testSet |> List.sumBy (fun otherValue ->
                        let candidatePair = [| value; otherValue |]
                        if (unusedPairsSearch[candidatePair[0]][candidatePair[1]] = 1 || unusedPairsSearch[candidatePair[1]][candidatePair[0]] = 1) then
                            1
                        else
                            0
                    )

                    if currentCount > highestCount then
                        result.Clear()
                        highestCount <- currentCount
                        result.Add(value :: testSet)
                    else
                        result.Add(value :: testSet)

                result
            )
        
        ) (Seq.singleton ([best[1]; best[0]]))
        |> Seq.map (fun testSet -> testSet |> List.toArray |> Array.sort)

    best, result
    

let copyArray (source: _[]) (dest: _[]) = source |> Array.iteri (fun i x -> dest[i] <- x)

let generate' (random: IRandom) ({
    Input = {
        NumberParameters = numberParameters
    }
    UnusedPairs = unusedPairs
    UnusedPairsSearch = unusedPairsSearch
    UnusedCounts = unusedCounts
} as context) =
    let poolSize = 20

    let testSets = ResizeArray<int[]>()
    while (unusedPairs.Count > 0) do
        let best, candidateSets = candidates random context
        
        let candidateSets = candidateSets |> Seq.toArray
        
        let mutable indexOfBestCandidate = 0
        let mutable mostPairsCaptured = 0

        let bestTestSet = Array.create numberParameters 0

        candidateSets
        |> Array.iteri (fun i candidate ->
            let pairsCaptured = numberPairsCaptured candidate unusedPairsSearch
            if pairsCaptured > mostPairsCaptured then
                mostPairsCaptured <- pairsCaptured
                indexOfBestCandidate <- i
        )

        copyArray candidateSets[indexOfBestCandidate] bestTestSet
        testSets.Add(bestTestSet)

        for i in 0 .. (numberParameters - 2) do
            for j in (i + 1) .. (numberParameters - 1) do
                let v1 = bestTestSet[i]
                let v2 = bestTestSet[j]

                unusedCounts[v1] <- unusedCounts[v1] - 1
                unusedCounts[v2] <- unusedCounts[v2] - 1

                unusedPairsSearch[v1][v2] <- 0

                unusedPairs.RemoveAll(fun curr -> curr[0] = v1 && curr[1] = v2) |> ignore

    testSets.ToArray() |> Array.sort

let generate (random: IRandom) (predicate: (Combination -> bool) option) (input: CombinationInput): Combination seq =
    let data = init input
    let testSets = generate' random data
    testSets
