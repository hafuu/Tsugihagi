module Fumon.Core.Exhaustive

open Fumon.Core.Types

let create (predicate: (Combination -> bool) option) (parameters: ParameterDefinition[]): Combination seq =
    let result =
        parameters
        |> Seq.fold (fun rows p ->
            rows
            |> Seq.collect (fun row ->
                p.Values |> Seq.map (fun value -> Map.add p.Name.Value value row)
            )
        ) (Seq.singleton (Map.empty))
    match predicate with
    | Some pred -> result |> Seq.filter pred
    | None -> result
