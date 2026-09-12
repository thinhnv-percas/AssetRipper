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
5. **An encrypted Mach-O failed somewhere unrelated** — `MachO/MachOEncryptionInfoCommand.cs`,
   added, read from the switch in `MachOLoadCommand.Read`, and checked in the `MachOFile`
   constructor. An App Store build's `__TEXT` is FairPlay ciphertext on disk, which takes the
   codegen module *names* with it, so the code registration search reported
   "No codegen modules found for mscorlib" long after the metadata had loaded fine. Note that every
   case in that switch has to consume its whole payload: the 64-bit encryption command carries four
   bytes of padding after `cryptid`, and leaving them unread makes the next load command parse from
   the middle of this one.
6. **An encrypted Mach-O gave up far earlier than it had to** — `BinarySearcher
   .FindCodeRegistrationByModuleCount`, added and wired as a fallback in
   `Il2CppBinary.FindCodeAndMetadataReg`, plus bounds in `Il2CppBinary.Init` (adjustor thunk index,
   generic method table entries), `GetCodegenModuleByName` (was indexing its dictionary although the
   return type is nullable), `GetMethodPointer` (was indexing `[-1]`), and
   `NewArm64Utils.GetArm64MethodBodyAtVirtualAddress` (was mapping virtual address 0).
   `FindCodeRegistrationPost2019` needs the bytes of `mscorlib.dll`, which an App Store iOS build
   keeps in an encrypted section; the struct itself is in `__DATA` and its `codeGenModulesCount` is
   the image count the metadata already gives, so a count-constrained scan finds it with no strings.
   The technique is the one `FindMetadataRegistrationPost24_5` has always used. Method taken from
   `origin/ref/devx:IL2CPP-REBUILD-GUIDE.md` section 6.
7. **Ciphertext was being handed on as a number** — `MachOFile.IsVirtualAddressEncrypted` and the
   virtual `Il2CppBinary.IsVirtualAddressEncrypted` it overrides, with
   `Il2CppTypeDefinition.RawSizesAreReadable`, `Il2CppBinary.CountEncryptedFieldOffsetTables`,
   `Il2CppBinary.ReportEncryptedRegistrationRegions`, the encryption test in
   `Il2CppBinary.GetFieldOffsetFromIndex`, and the replacement of the `Size > 1 << 30` throw in
   `AsmResolverDllOutputFormat.ConfigureTypeSize`. On an App Store iOS build the registration and
   every pointer table are in `__DATA` and read perfectly, while the structs they address are in
   `__TEXT.__const` and are ciphertext. The old code read those bytes and treated them as sizes and
   field offsets. The address's provenance is what separates the two cases, never the plausibility of
   the value; the address is mapped through the segments, because a byte inside a segment but inside
   none of its sections is still encrypted. `-1` was already this method's own "offset not known".
8. **The two 64-bit chained pointer formats were treated as one, and a chain could leave its page** —
   `MachOFile.ApplyChainedFixups` and `MachOFile.PreferredLoadAddress`.
   `DYLD_CHAINED_PTR_64`'s target is an unslid virtual address and `DYLD_CHAINED_PTR_64_OFFSET`'s is
   an offset from the image base (Apple `mach-o/fixup-chains.h`); they agree only on an image that
   links at zero, which every Unity dylib does, so this is untestable on a real iOS fixture and is
   covered by synthetic binaries in `AssetRipper.Tests/MachOChainedFixupTests.cs` instead. The walk is
   also bounded by the page now: `next` reaches at most `4*0xFFF`, a chain belongs to one page, and an
   unbounded walk runs into the next page's chain and rewrites correct pointers with no symptom.

9. **A struct returned through memory read back as nothing** — `Analysis/IndirectReturnBufferRecovery.cs`,
   added and called from `MethodAnalysisContext` before `LocalVariables.ResolveTypesAndFields`. A
   return value too large for the registers is written by the callee into a buffer the caller names in
   the indirect result register, so every read off that buffer had an untyped base and became an
   unresolved load - and the value it stood for read as zero. The reads are fields of the value the
   call already names as its result. Which register is the buffer comes from the callee's own
   `CallingConventionResolver`, so no architecture is named here and x86 improves too.

10. **An exact offset match ignored how wide the access was** — `Analysis/NestedFieldResolver.cs`,
   added, with `MetadataResolver`'s field resolution rewritten to consult it on both paths rather than
   returning at the first field whose offset matches. Four bytes at the offset of a `Vector3` reached
   its `x`; reading that as a write of the whole vector produced a cast from a float to a struct.
   Preferring the member inside needs the width to match it exactly and the offset to name one field,
   because at the start of a field the field itself is also a valid answer.

The build files are adapted: `Directory.Build.props` here isolates this tree from
`Source/Directory.Build.props` (whose `CheckForOverflowUnderflow` would change how this code runs),
each project targets only `net10.0`, and packing, SourceLink and package metadata are dropped. The
`.editorconfig` here stops AssetRipper's style rules from applying to code written to other ones.

## Updating

Fetch the branch, diff against commit `cae273a`, take the changes, and re-apply the marked
changes. Then re-measure with `RUN-TEST.bat` — the numbers above are what to compare against.
