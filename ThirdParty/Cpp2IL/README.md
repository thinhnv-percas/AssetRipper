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

### The metadata initialization function was never looked for on ARM64

Every metadata use is preceded by a call to `il2cpp_codegen_initialize_runtime_metadata`, which is not
exported and so has to be found by pattern: the first call in `System.Exception::get_Message` is it.
That was written for x86 only, guarded by an instruction set check with a *TODO make this abstract*
beside it. Reading the first call out of a method body is now a `virtual` the instruction sets
implement, and ARM64 implements it, which finds the function at 0x1d35808 on the measured game — 2433
`Method not found` lines in one assembly, and 12899 unnamed calls in the Ghidra output.

Calls to it, and to the class initializer beside it, are then deleted rather than named. Metadata
initialization fills in globals the method is about to read and a class init runs a static constructor;
neither is something C# writes, and both are emitted before nearly every metadata use. Only the void
form is deleted, since the same functions are sometimes called for the pointer they return.

### An IsInst that lands on a managed method is not IsInst

`Object::IsInst` is found by taking the last call in `System.Type::IsInstanceOfType`. On the measured
game that method makes one call and then tail branches, so the rule does not hold and the answer was a
managed method's address. `Object::IsInst` is part of the runtime and never is one, so that case now
answers nothing rather than naming the wrong function.

### A failed method came out empty rather than throwing

`AsmResolverDllOutputFormatIlRecovery.FillMethodBody` wrote its `throw` into the body it had created
before calling the generator, but the generator replaces the body rather than filling it, so anything
that failed part way through was left holding an empty body and read as a method that does nothing.
The catch now starts a fresh body. This is what hid the exception above.
