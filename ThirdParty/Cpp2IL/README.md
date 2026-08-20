# Cpp2IL

A copy of [SamboyCoding/Cpp2IL](https://github.com/SamboyCoding/Cpp2IL), branch `assetripper`, at commit
`e3aa824c3b172997086985c5388feb994f02daf7` — the commit the `AssetRipper.Cpp2IL.Core` 1.0.8 package was
built from. MIT licensed; the licence is beside this file.

It is here rather than referenced as a package because the parts that decide what a recovered method
body says are `internal` to it. `IlGenerator` turns ISIL into CIL, and everything it cannot resolve
becomes a `Console.WriteLine` in the exported C#, so improving that output means changing this code
rather than calling it differently.

Only `LibCpp2IL` and `Cpp2IL.Core` are copied, since those are what AssetRipper uses. The project files
are trimmed to the one target framework AssetRipper builds for and no longer produce packages; nothing
else is edited except where a change is described below.

## Changes

Each entry says what was changed and why, so the copy can be rebased onto a newer upstream by
reapplying them.

*(none yet)*
