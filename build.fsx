#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core

open System.Runtime.InteropServices

module Imports =
    [<DllImport("kernel32.dll")>]
    extern uint32 GetCurrentProcessId()

Target.create "Build" (fun _ ->
  printfn "Current process: %d" (Imports.GetCurrentProcessId())
)

Target.runOrDefault "Build"
