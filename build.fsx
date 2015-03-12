#r @"packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.FscHelper


let sourceDir = __SOURCE_DIRECTORY__
FileUtils.chdir sourceDir

let buildDir = "./build/"

let proj = !! "**/*.fsproj"
let fsx = !! "**/*.fsx"

Target "Clean" (fun _ ->
    CleanDir buildDir
)


Target "Build" (fun _ -> 
    proj
    |> MSBuildDebug "" "Build"
    |> Log "AppBuild-Output: "
) 

Target "CompileFsx" (fun _ ->
    let files = fsx
    for file in files do
        let dir = DirectoryName file
        FileUtils.chdir dir
        [file]
        |> Fsc (fun p -> {p with OtherParams = [ "-I:bin/Debug" ] } )
)

Target "Default" (fun _ ->
    trace "Hello World!"
)


"Clean"
    ==> "Build"
    ==> "CompileFsx"
    ==> "Default"

RunTargetOrDefault "Default"
