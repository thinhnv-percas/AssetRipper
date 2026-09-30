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

11. **A field could not be read off an array element** — `ISIL/FieldReference.cs` gains `ElementIndex`,
   `ArrayRecovery.ComputedElementAddress` produces it, `IlGenerator.LoadFieldBase` emits `ldelema`
   for it, and the index is walked alongside `ArrayAccess.Index` in the declaration walk,
   `SsaSimplifier`, `CopyCoalescer` and `EqualityBranchInverter`. `array[i].x` had no
   representation, so a computed element address over a struct array could only be reported as an
   unresolved load or folded to `(float)array[i]`, a cast C# does not have. `ElementSize` still
   knows only the primitives; a struct stride comes from `MetadataElementSize`, and the index may be
   scaled by a multiply rather than a shift because a struct stride is rarely a power of two.

12. **An immediate in unwritable memory was decoded as a metadata usage** (iteration 062) —
   `Il2CppBinary.IsVirtualAddressWritable`, overridden by `ElfFile` (PT_LOAD with PF_W) and `MachOFile`
   (segment initial protection), and consulted by `MetadataResolver.NotAUsageSlot`. From metadata v27
   a usage is decoded from the value found at an address, so a small constant (an interface slot, a
   bit mask, a character) that maps into the ELF header read back as `typeof(...)` or `fieldof(...)`.
   A usage slot is a global the runtime fills in, so it is always writable.

13. **A generic struct had no size** (iteration 062) — `TypeSizes.UnboxedSize` falls back to
   `GenericInstanceFieldLayout.ValueTypeSize`, which walks the definition's fields with the instance's
   arguments substituted. il2cpp records sizes for definitions only, so every generic struct read as
   size 0 and `ReturnsViaHiddenBuffer` called it a register return: a `List<T>.Enumerator` returned
   through X8 was never connected to its call and every `foreach` over a list iterated a default
   enumerator. `GenericInstanceFieldLayout` is in the boxed frame, so `MetadataResolver` converts a
   value-relative addend on a generic struct with `FieldOffsetFrame` before looking it up.

14. **A struct slot handed to a call is one piece of memory** (iteration 062) —
   `Analysis/StructSlotAliasRecovery.cs`, added, run after `ResolveTypesAndFields`; and
   `IndirectReturnBufferRecovery.RunBeforeDeadCode`, run before `DeadCodeEliminator` removes the move
   that hands a buffer to its call. A word inside a stack struct read after the struct's address was
   handed to a call is that struct's field, where the word is demonstrably a copy of that field.

15. **Interface dispatch through the runtime lookup** (iteration 062) — `InterfaceInvokeDataRecovery`
   maps a slot through `Il2CppMethodDefinition.slot` rather than the declaration position, resolves a
   dispatch in tail position (`IndirectJump`), and writes one evidence row per resolved call to
   `CPP2IL_DUMP_INTERFACE_CALLS`.

16. **What the emitted body reads** (iteration 062) — `IlGenerator.LoadsCallOperands` states when the
   generator loads a call's operands (never for a call it cannot name), and `StorageHazardClassifier`
   uses it rather than counting the raw registers of an unresolved call as reads.

The build files are adapted: `Directory.Build.props` here isolates this tree from
`Source/Directory.Build.props` (whose `CheckForOverflowUnderflow` would change how this code runs),
each project targets only `net10.0`, and packing, SourceLink and package metadata are dropped. The
`.editorconfig` here stops AssetRipper's style rules from applying to code written to other ones.

17. **An engine or package assembly can be opted back into recovery for a measurement** (iteration
    063) — `OutputFormats/IlRecoveryScope.cs`, added, consulted in
    `AsmResolverDllOutputFormatIlRecovery.FillMethodBody`. `CPP2IL_RECOVER_ALSO=Unity.TextMeshPro,…`
    recovers the named assemblies instead of stubbing them, so an upstream package whose source is
    available at the version the build shipped can serve as an independent source oracle. Unset, the
    decision is exactly upstream's. AssetRipper's `IsFrameworkAssembly` consults the same set.

18. **Arguments past the registers were placed wrong** (iteration 063) — `Utils/Arm64ArgumentPlacement.cs`,
    added, used by `Arm64CallingConventionResolver.ResolveForManaged`. A float aggregate that does not
    fit in the vector registers left sets NSRN to 8 (AAPCS64 C.3), so every later float goes to the
    stack too; each stack argument takes its own size rounded to 8 (a Vector3 16 bytes); and Apple's
    arm64 ABI packs stack arguments at natural alignment instead. `EvaluateCurve(Vector3 ×4, float t)`
    named V6 as `t`, which nothing writes, and recovered a curve at t = 0; `VertexGradient`'s fourth
    Color read as `default(Color)`.

19. **FCMP was lifted as a subtraction** (iteration 063) — `NewArmV8InstructionSet.EmitFloatCompareFlags`,
    used by `FCMP`, `FCMPE`, `FCCMP` and `FCCMPE`. FCMP sets N for less than, Z for equal, C for greater,
    equal or unordered, and V for unordered only. The SUBS lifting computed V as the signed overflow of
    a subtraction of float bit patterns, which reached the source as `object obj = t ^ 1f;` (not C#)
    wherever a condition read V, and computed Z from `a - b`, which is wrong for two infinities. V is
    now `!(a == a && b == b)`. 134 of those expressions on JellyBlastV2 became 0; PathCreator's Roslyn
    errors 474 → 372.

## Updating

Fetch the branch, diff against commit `cae273a`, take the changes, and re-apply the marked
changes. Then re-measure with `RUN-TEST.bat` — the numbers above are what to compare against.
