# Fake > 5.13.7 fails to load kernel32.dll

Any attempt to use a native library from the user's `PATH` fails in Fake versions after 5.13.7.

It looks as though the new functionality added to support native libraries
doesn't allow them to be loaded from the user's `PATH`, which breaks scripts
which use native libraries such as `kernel32.dll`.

For example, this works when using Fake 5.13.7 but fails with 5.14:

```fsharp
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
```
