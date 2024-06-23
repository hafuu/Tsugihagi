module Fumon.Core.Exhaustive

open Fumon.Core.Types

let create (parameters: ParameterDefinition[]): Combination seq =
    parameters
    |> Seq.fold (fun rows p ->
        rows
        |> Seq.collect (fun row ->
            p.Values |> Seq.map (fun value -> Map.add p.Name value row)
        )
    ) (Seq.singleton (Map.empty))
