open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.JavaScript

let project = "Fumon"

let rootDirectory = __SOURCE_DIRECTORY__ </> ".."

let sln = rootDirectory </> "Fumon.sln"

let fableOutput = "out"

let release = ReleaseNotes.load "RELEASE_NOTES.md"

let initTargets() =
    Target.create "RestoreNpm" (fun ctx ->
        Npm.exec "ci" id 
    )

    Target.create "Restore" ignore

    Target.create "AssemblyInfo" (fun ctx ->
        !! "src/**/*.fsproj"
        |> Seq.iter (fun projectPath ->
            let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
            let projectDirectory = System.IO.Path.GetDirectoryName(projectPath)
            let attributes = [
                AssemblyInfo.Title projectName
                AssemblyInfo.Product project
                AssemblyInfo.Version release.AssemblyVersion
                AssemblyInfo.FileVersion release.AssemblyVersion
            ]
            AssemblyInfoFile.createFSharp (projectDirectory </> "AssemblyInfo.fs") attributes
        )
    )

    Target.create "PreBuild" ignore

    Target.create "BuildFable" (fun ctx ->
        let result = DotNet.exec id "fable" $"./src/Fumon.Gas/ --lang js -o {fableOutput}"
        if not result.OK then
            failwithf "Errors while Fable build: %A" result.Messages
    )

    Target.create "BuildGas" (fun ctx ->
        Npm.run "build:gas" id
    )

    Target.create "Build" ignore

    Target.create "Release" ignore

    "RestoreNpm"
    ==> "Restore"
    |> ignore

    "AssemblyInfo"
    ==> "PreBuild"
    |> ignore

    "BuildFable"
    ==> "BuildGas"
    ==> "Build"
    |> ignore

    "Restore"
    ==> "PreBuild"
    ==> "Build"
    ==> "Release"
    |> ignore

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
