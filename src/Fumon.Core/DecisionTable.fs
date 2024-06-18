module Fumon.Core.DecisionTable

type ParameterDefinition = {
  Name: string
  Values: string[]
}

type Row = Map<string, string>

let create (parameters: ParameterDefinition[]): seq<Row> =
    parameters
    |> Seq.fold (fun rows p ->
        rows
        |> Seq.collect (fun row ->
            p.Values |> Seq.map (fun value -> Map.add p.Name value row)
        )
    ) (Seq.singleton (Map.empty))
