module Tsugihagi.Core.Exhaustive

open Tsugihagi.Core.Types

let generate (predicate: (Combination -> Ternary) option) (input: CombinationInput): Combination seq =
    let result =
        input.LegalValues
        |> Seq.fold (fun rows values ->
            rows
            |> Seq.collect (fun row ->
                values |> Seq.map (fun value -> value :: row)
            )
        ) (Seq.singleton [])
        |> Seq.map (fun revRow -> // 逆順に入っているので順番を入れ替える
            let row = Array.create input.NumberParameters 0
            revRow |> List.iteri (fun i value -> row[row.Length - 1 - i] <- value)
            row
        )
    match predicate with
    | Some pred -> result |> Seq.filter (pred >> Ternary.toBool)
    | None -> result
