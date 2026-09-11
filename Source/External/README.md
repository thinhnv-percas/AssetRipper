# Vendored Cpp2IL

Cpp2IL, from the AssetRipper fork's `development` branch at commit `cae273a`, MIT licensed
(`LICENSE.txt`), copyright Samboy063. Four projects: `Cpp2IL.Core`, `LibCpp2IL`,
`StableNameDotNet`, `WasmDisassembler`.

## Why it is here rather than referenced as a package

The newest published `AssetRipper.Cpp2IL.Core` is 1.0.9, built from a commit well behind
`development`, and the gap is worth a lot: on `Test/Input/Pinata` at script content level 3, 1.0.9
leaves 44757 `Method not found` placeholders where `development` leaves 27007, and needs 2469 method
bodies repaired downstream to survive where `development` needs 419.

On top of that the IL generator has defects neither version fixes, and there is no seam to fix them
from outside. They were carried as a patch file and a build flag for a while, which meant the build
everyone actually runs had none of them.

## Changes against upstream

Every change is marked `AssetRipper:` at the point it applies.

1. **A body can run off its own end** — `IlGenerator.EnsureTerminated`. A block whose only successor
   is the exit block gets no bridge, and the analysis warnings appended at the end finish on a call,
   so nothing guarantees a terminator. Reading such a body walks past its last instruction and it is
   discarded as unbalanced.
2. **Every metadata usage was a dead pointer** — `IlGenerator.ResolveGlobal`. A load from a fixed
   address became a placeholder and a null pointer, so a string the metadata holds in full reached
   the source as `object key = 0`. Those addresses are metadata usage slots; string literals become
   `ldstr` and the other kinds keep the placeholder but name the handle.
3. **ARMv7 could not be lifted at all** — `InstructionSets/ArmV7InstructionSet.cs`, rewritten, and
   `Utils/ArmV7CallingConventionResolver.cs`, added. `GetIsilFromMethod` returned an empty list, so
   no method body could be recovered from an armeabi-v7a build. `Utils/ArmV7Utils.cs` also holds its
   Capstone handle per thread now, because bodies are lifted in parallel.
4. **A field inside a value type field was not a field** — `MetadataResolver.FindNestedFieldPath`,
   `FieldReference.ContainingFields`, and the reads and writes for them in `IlGenerator`. This is
   the `TODO: Support nested fields` in upstream's own resolver.
5. **A Mach-O had one executable section** — `MachO/MachOFile.GetExecutableSections`, added, the same
   change `ElfFile` already carries. `Il2CppBinary`'s default returns the primary section alone, which
   on iOS is `__text`; every generated method body is in the section named `il2cpp` beside it, 24 MB
   of it on the game measured here. Anything counting how often a runtime helper is called — which is
   every "does managed code call this" decision in `BaseKeyFunctionAddresses` — saw none of those
   calls.
6. **An encrypted Mach-O said nothing about being encrypted** — `MachO/MachOEncryptionInfo.cs`, added,
   and read in `MachOFile`'s constructor. An App Store build is FairPlay encrypted over its whole
   `__TEXT` segment, so the code registration search — which finds the string `mscorlib.dll` and walks
   back to the module naming it — finds nothing and initialisation fails with "No codegen modules
   found for mscorlib". That reads as a corrupt binary and the real cause was nowhere in the output.

The build files are adapted: `Directory.Build.props` here isolates this tree from
`Source/Directory.Build.props` (whose `CheckForOverflowUnderflow` would change how this code runs),
each project targets only `net10.0`, and packing, SourceLink and package metadata are dropped. The
`.editorconfig` here stops AssetRipper's style rules from applying to code written to other ones.

## Updating

Fetch the branch, diff against commit `cae273a`, take the changes, and re-apply the marked
changes. Then re-measure with `RUN-TEST.bat` — the numbers above are what to compare against.
