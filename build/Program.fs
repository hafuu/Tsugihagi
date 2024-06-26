open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators

let rootDirectory = __SOURCE_DIRECTORY__ </> ".."

let sln = rootDirectory </> "Fumon.sln"

let initTargets() =
    Target.create "Build" (fun ctx ->
        DotNet.build (fun c -> {
            c with
                Configuration = DotNet.BuildConfiguration.Release
        }) sln
    )

[<EntryPoint>]
let main argv =
    argv
    |> Array.toList
    |> Context.FakeExecutionContext.Create false "build.fsx"
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    initTargets ()
    Target.runOrDefaultWithArguments ("Build")

    0
