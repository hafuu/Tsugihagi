module Fumon.Core.Exhaustive

open Fumon.Core.Types

let create (predicate: (Combination -> bool) option) (context: PreprocessedParameter): Combination seq =
    let result =
        context.LegalValues
        |> Seq.fold (fun rows values ->
            rows
            |> Seq.collect (fun row ->
                values |> Seq.map (fun value -> value :: row)
            )
        ) (Seq.singleton [])
        |> Seq.map (fun revRow -> // 逆順に入っているので順番を入れ替える
            let row = Array.create context.NumberParameters 0
            revRow |> List.iteri (fun i value -> row[row.Length - 1 - i] <- value)
            row
        )
    match predicate with
    | Some pred -> result |> Seq.filter pred
    | None -> result
