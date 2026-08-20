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

### Metadata usages reached through the GOT

`LibCpp2IlContext.CheckForPost27GlobalAt` read the word at the address the code loads from and decoded
it as an encoded metadata token. On a position independent ARM64 binary that address is a GOT entry
holding the *address* of the usage, so the decode always failed and every string literal, type, method
and field the code refers to came out as `Unmanaged memory load: [449BB68]`. It now follows one
indirection, and only for an address the file actually relocates, so an ordinary pointer cannot be
mistaken for a table entry. `Il2CppBinary.HasRelocationAt` and the address list `ElfFile` records while
applying relocations are the supporting change.

`MetadataResolver.ResolveMetadataUsages` gained the second half of the same pattern: the load that
names the usage and the load that reads it are two instructions, so what each local resolved to is
remembered and `Move b, [a]` is resolved as well.

### A MethodInfo* has no managed type

`ContextToTypeSignature` threw on `RuntimeMethodInfoAnalysisContext`, which only became reachable once
usages resolved. It is lowered to `IntPtr`, the same as the `Il2CppClass*` handle beside it.

### A failed method came out empty rather than throwing

`AsmResolverDllOutputFormatIlRecovery.FillMethodBody` wrote its `throw` into the body it had created
before calling the generator, but the generator replaces the body rather than filling it, so anything
that failed part way through was left holding an empty body and read as a method that does nothing.
The catch now starts a fresh body. This is what hid the exception above.
