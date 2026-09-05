<!-- CODEGRAPH_START -->
## CodeGraph

In repositories indexed by CodeGraph (a `.codegraph/` directory exists at the repo root), reach for it BEFORE grep/find or reading files when you need to understand or locate code:

- **MCP tool** (when available): `codegraph_explore` answers most code questions in one call — the relevant symbols' verbatim source plus the call paths between them, including dynamic-dispatch hops grep can't follow. Name a file or symbol in the query to read its current line-numbered source. If it's listed but deferred, load it by name via tool search.
- **Shell** (always works): `codegraph explore "<symbol names or question>"` prints the same output.

If there is no `.codegraph/` directory, skip CodeGraph entirely — indexing is the user's decision.
<!-- CODEGRAPH_END -->

## IL2Cpp script recovery

This repository carries a substantial IL2Cpp → C# recovery feature on top of upstream AssetRipper.
`docs/articles/Il2CppScriptRecovery.md` is the reference; `ROADMAP.md` lists what is still wrong.
What follows is what a session working on it needs to know before touching anything.

### Cpp2IL is vendored, not a package

`Source/External/` holds Cpp2IL (`Cpp2IL.Core`, `LibCpp2IL`, `StableNameDotNet`,
`WasmDisassembler`) from the AssetRipper fork's `development` branch at commit `cae273a`. There is no
`PackageReference` to it. Read `Source/External/README.md` before editing anything in there: every
local change is marked `AssetRipper:` at the point it applies, and updating means diffing upstream
and re-applying them.

`Source/External/Directory.Build.props` deliberately **shadows** `Source/Directory.Build.props`
rather than importing it. The parent sets `CheckForOverflowUnderflow`, and Cpp2IL does a great deal
of unchecked pointer and hash arithmetic that would start throwing under it. Do not "fix" this by
importing the parent.

### Measuring a change

`RUN-TEST.bat` rips `Test/Input/Pinata` at script content level 3. Headless equivalent:

```
dotnet build AssetRipper.slnx -c Release
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output Test/Output --log Test/AssetRipper.log Test/Input/Pinata
```

A run takes about 95 seconds. The numbers worth comparing are in `ROADMAP.md`; count them with
`grep -rho '<placeholder text>' --include=*.cs Test/Output | wc -l`, and read `Test/AssetRipper.log`
for the recovery summary lines (bodies repaired, bodies discarded, errors).

**Verify the artifact that actually ran, not the build's exit code.** A measurement in this project
once came back identical to its baseline because an NU1605 package downgrade had silently made the
build use the NuGet package instead of the source being tested, and the build still reported
success. `ls -la` the DLL for its timestamp and `strings -el <dll> | grep <a string you added>`
before trusting a number. A string literal in a .NET assembly is UTF-16, so plain `strings` will not
find it; `strings` without `-el` does find method and type names.

### Things that are true about the pipeline

- **Metadata usage slots have an extra indirection before metadata v27.** The address baked into the
  code is a per-module pointer holding the address of the usage slot; only that second address keys
  LibCpp2IL's usage dictionaries. Looking up the first address finds nothing, silently.
- **A method address can be shared.** `ApplicationAnalysisContext.MethodsByAddress` maps one address
  to a *list*: generic sharing folds dozens of methods onto one body. Picking `[0]` is wrong unless
  the list has one entry.
- **Value type field offsets are relative to the value's own data**; a class's are relative to the
  object, so they include the 0x10 header. `FsmColor.value` at 0x38 plus `Color.g` at 0x4 is 0x3C.
- **ILSpy decompiles an assembly as one parallel unit.** One unreadable method body throws out of
  that unit and costs every other file in the assembly, which is why
  `Il2CppIlRecoveryOutputFormat.ReplaceIfUnverifiable` stubs a bad body rather than shipping it.
- **The `#US` user string heap is addressed by 24 bit offsets, so 16 MB per module.** Anything that
  emits `ldstr` per instruction has to be bounded or the assembly cannot be written at all.
- **`Il2CppClassUsefulOffsets.UsefulOffsets` is a mutable static list in Cpp2IL.** Patching it needs
  care around `beforefieldinit`: a static field initialiser can run *after* a `Clear()` in the same
  method and capture the emptied list. `Il2CppClassOffsetPatcher` reads the pristine copy through a
  property before clearing, and there is a test for it.
- **Only two Cpp2IL instruction sets lift to ISIL**: `X86InstructionSet` and `NewArmV8InstructionSet`.
  `Arm64InstructionSet`, `ArmV7InstructionSet` and `WasmInstructionSet` return an empty list, which
  looks exactly like a successful run that produced no code.
- **`InstructionSetRegistry.RegisterInstructionSet` uses `Dictionary.Add`** and throws on a second
  registration for the same identifier.

### Things measured to be worth nothing — do not redo them

- **Resolving a bare call address through `MethodsByAddress` when exactly one method sits there.**
  Resolves zero calls on both package 1.0.9 and `development`: the unresolved targets are il2cpp
  runtime functions and PLT stubs, not managed methods at all.
- **Naming unresolved call targets from the key function addresses.** Finds nothing, because the
  lifter has already consumed every call it recognised by the time the generator runs.
- **Raising `MaximumStackRepairs` from 16 to 64.** The same bodies give up, having accumulated 64
  pops instead of 16. Their imbalance is a branch join that merely surfaces at the return, so
  popping there can never settle it.
- **Resolving call targets downstream, in `Il2CppIlRecoveryOutputFormat` rather than in the
  generator.** Placeholders fell but stubs rose from 2490 to 3509, because the downstream code has no
  signature to load arguments from and unbalances the stack. This is why the fix belongs in the
  generator, where the signature is in hand.

### The `ref/devx` branch

`ThinhNV-x-Percas/devx-decompile`, branch `ref/devx`, contains the IL2Cpp runtime struct database
(742 layout files) and `tools/structdb_gen.py`, and nothing else. It has no decompiler code. Its
contents are already absorbed into `StructDb/`; there is nothing further to take from it.
