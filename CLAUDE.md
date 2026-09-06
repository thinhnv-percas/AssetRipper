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

- **Metadata usage slots have an extra indirection, and it is not a metadata version thing.** The
  address baked into the code is a pointer holding the address of the usage slot; only that second
  address keys LibCpp2IL's usage dictionaries. Looking up the first address finds nothing, silently.
  This is position independent code, not a metadata version: it is there on v24.2 and on v31.1
  alike. `MetadataResolver.FindUsageSlotHolders` takes the hop, and only when the address in the code
  is not itself a usage and the address it holds is. Taking it is what resolved every remaining
  `Il2Cpp runtime handle` placeholder on the test game and, with it, static field access.
- **A method address can be shared.** `ApplicationAnalysisContext.MethodsByAddress` maps one address
  to a *list*: generic sharing folds dozens of methods onto one body. Picking `[0]` is wrong unless
  the list has one entry.
- **AAPCS64 returns and passes a small struct of floats in the vector registers.** A homogeneous
  aggregate of up to four floats — every Unity maths type — comes back in V0 to V3 and is passed the
  same way, not through a hidden buffer and not in the integer registers. ISIL can name only the
  first register per value; the extra registers of a *return* are recovered by emitting a move naming
  each as the field of the returned value it carries. Getting this wrong does not look like an ABI
  bug, it looks like arithmetic: `a.z - b.z` becomes `x - x`, and a vector argument becomes a
  constant that takes everything computing it with it as dead code.
- **A guard is matched by shape, not by an offset.** The class initialization guard was matched
  against one hardcoded `Il2CppClass` byte with a mask of 1 and an inline memory operand, and missed
  on all three counts: the byte moves between Unity versions, an older code generation guards on
  `has_cctor` with a mask of 2, and the load is a separate instruction until copy propagation, which
  runs after the pass. Widening it to "one bit of a byte of a known class pointer" removed 8136
  placeholders. The interface dispatch recovery has the same problem and has not been done.
- **The struct database knows where these bytes are.** `StructDb/<version>-x64.json.gz` carries the
  full `Il2CppClass` layout including bitfield members, with `offset`, `bits` and `bitOrdinal`.
  `Il2CppClassOffsetPatcher` skips bitfields today; when an exact offset is needed rather than a
  shape, that is where to get it.
- **A float loaded from an address the code names outright is a compiler constant**, not a variable.
  A managed static float is reached through the class's static field storage, two pointers away, so
  folding an absolute scalar float load into a literal is safe — which is what the x86 lifter has
  always done and what ARM64 does now.
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
- **Three Cpp2IL instruction sets lift to ISIL**: `X86InstructionSet`, `NewArmV8InstructionSet` and
  `ArmV7InstructionSet`, the last of which is ours. `Arm64InstructionSet` and `WasmInstructionSet`
  return an empty list, which looks exactly like a successful run that produced no code.
- **Android's armeabi-v7a is ARM mode and softfp**, not Thumb and not hard float. The generated code
  proves both: it decodes as ARM and is nonsense as Thumb, and a float argument is moved out of VFP
  with `vmov r1, s0` immediately before the call that takes it.
- **A Capstone disassembler handle is not thread safe.** Bodies are lifted in parallel, so
  `ArmV7Utils` keeps one per thread; sharing one silently corrupts the iteration state.
- **`InstructionSetRegistry.RegisterInstructionSet` uses `Dictionary.Add`** and throws on a second
  registration for the same identifier.
- **A Debug build dies silently on a failed `Debug.Assert`.** There are about 156 of them in
  AssetRipper's own code, asserting invariants that a real game can break. A failed one calls
  `Environment.FailFast`: the process ends at once, `ErrorHandlingMiddleware` never sees it, nothing
  reaches the log file, and the message goes only to standard error. A Release build has none of them
  compiled in, which is why `BUILD-AND-RUN.bat` and `RUN-TEST.bat` both default to Release and why
  the first captures standard error to `AssetRipper-crash.log`. A stack overflow ends the same way
  and leaves its trace in the same place. When a run "just stops", read that file first, then the
  last `Processing :` line in the log — `ExportHandler.Process` names each processor before running
  it precisely so that line points at the culprit.
- **`DebugProvider` cannot be replaced from source.** `Debug.SetProvider` and
  `System.Diagnostics.DebugProvider` are public at runtime but absent from the .NET reference
  assemblies, so an assert cannot be routed into the logger without reflection over a private field,
  which this AOT-compatible build should not do. Release is the answer, not interception.

- **Where the abstraction has one operand and the machine has three, type the ends.** The recurring
  ARM64 defect is a value that lives in several registers and can only be named by one. Naming the
  extra registers as the fields they carry fixes the reads; typing what the first register feeds —
  arithmetic on a float aggregate is float arithmetic, a comparison takes its float type from
  whichever operand has one, an instance method on a value type takes its receiver by reference —
  fixes the rest, and is what turns a chain of casts of an untyped `object` back into the expression
  the source had.
- **A shift or extend on the last register operand is where an index gets scaled.** `add x8, x0, w1,
  sxtw #3` is `x0 + (long)(int)w1 * 8`. Dropping it does not look like a lifter bug, it looks like a
  program that always reads element zero.
- **An architecture with no scaled index addressing mode computes an element's address first**, so
  the load reads `[address + elementsOffset]` and the array and the index are an instruction earlier.
  The fold back has to run *inside* the type resolution fixpoint: it needs the array typed, and what
  it produces types the element, which is the base of the next field access.
- **A new operand kind has about six walkers to teach**: `Instruction.GetSources`, `SsaForm`,
  `SsaSimplifier` (both `ReplaceUses` and `CollectReadLocals`), `CopyCoalescer`, `Simplifier`,
  `DeadCodeEliminator`, and the local-declaration walk in `IlGenerator`. Missing one is silent: a
  local used only inside the new operand is not counted as read, its definition is dropped as dead,
  and the operand ends up indexed by nothing.
- **The constructor a call names is routinely not the allocated type's.** A trivial constructor is
  folded onto its base, so a closure's allocation is followed by `System.Object..ctor`; generic
  sharing names one instantiation's constructor for every other. Fusing the allocation with what the
  call names gives `(DisplayClass)new object()` and delegates of the wrong type.
- **il2cpp's null and bounds checks are matched by shape and the shapes vary.** A64 branches on the
  negation of a less-than for a bounds check; the helper that raises one of these never returns, so
  the compiler puts the calls next to each other and the block that only *builds* the exception falls
  straight into the one that *throws* a different one. Getting these right is what turns a `for` loop
  full of `if (x == null) break;` back into a loop.
- **An `fmov`'s immediate is as wide as the register it moves into**, and one eight byte store can
  initialise two adjacent float fields — the value is a double only by accident of its width.
- **A `Cpp2IlInstructionSet` subclass that forwards to another must forward the virtual members too.**
  `Arm64InstructionSetSelector` forwarded the abstract ones and inherited the base's defaults for the
  rest. `CallingConventionResolver` defaults to null, and every analysis pass that maps a call's raw
  registers onto the callee's signature is written to do nothing when it is absent — so ARM64 calls
  silently kept the whole register file as their arguments. That one line was worth 11605 `Method not
  found` placeholders.

- **A pass that matches a shape must be written against the shape at the point it runs.** The final
  analysed ISIL is heavily folded — a load is inside the instruction that consumed it, a type is
  inside the comparison — and a pass in the middle of the pipeline sees neither. `TypeCheckRecovery`
  matched nothing at first for exactly this reason: the comparison it wanted was against the local
  the class pointer had been loaded into, not against `typeof(T)`. Dump the ISIL from a probe that
  stops where the pass runs, not from the output.
- **The Il2CppClass offsets a pattern keys on move between Unity versions**, so read them out of the
  struct database rather than writing them down: `Il2CppClassUsefulOffsets.TryGetOffset` reads the
  measured table `Il2CppClassOffsetPatcher` prepends. `typeHierarchyDepth` is 0x128 on 2019.2 and
  0x130 on 2022.3, which is the difference between recovering every cast in a game and none of them.
- **A new ISIL opcode is far cheaper than a new operand kind.** An opcode needs a case in
  `Instruction.GetSources` and `GetOrSetDestination` and one in the generator; an operand kind needs
  every walker in the pipeline. Append it after `Throw`: the enum's ranges are compared by value
  (`>= CheckEqual and <= CheckLessOrEqual`), so inserting in the middle silently reclassifies things.
- **ILSpy can throw out of a transform on IL that verifies.** `ReplaceIfUnverifiable` only catches
  what fails verification, and an assembly is decompiled as one parallel unit, so a transform crash
  used to cost every script after it. `ScriptDecompiler` now reads the file name out of the failure,
  skips that type and decompiles the assembly again. If a change suddenly loses a lot of files,
  look for `was abandoned part way through` in the log before looking anywhere else.

- **Count a defect where it is produced, not where it might be.** The unresolved-load breakdown first
  walked the finished graph and counted every memory operand in every body: 45435, against 23173
  actual placeholders. Its two largest groups were operands that never reach the generator at all —
  an object header klass load consumed by a guard, and untyped bases in code that was later dropped.
  Working down that list would have been working on code that is already fine. Raising it from the
  one place in `IlGenerator` that gives up on a load made the total match the placeholder count and
  reordered the list entirely.
- **`IsilDump` prints the ISIL of one named method at points in the analysis.** Set
  `CPP2IL_DUMP_METHOD` to a substring of the full name and `CPP2IL_DUMP_DIR` to a directory; each
  stage becomes a file, and `IsilDump.Trace` appends a line to `trace.txt` beside them. Add a stage
  wherever a pass is not matching. Note that the diagnostic sample layer analyses methods for real,
  so the *first* dump of a method may be that sample rather than the run that produces the body.
- **Every busy unresolved call address in the game is a thunk.** The 0x8D82xx cluster is a table of
  single `b` instructions to the real runtime helpers; `8D82A4` is `il2cpp::vm::Object::IsInst` at
  0x899F2C, called 1353 times. Cpp2IL's key function scan already follows a thunk for some entries,
  so what is missing is which functions it looks for. It also mis-resolves
  `il2cpp_vm_object_is_inst` to the class-init thunk on this game, which is worth knowing before
  trusting any key function address.
- **A pass that names an offset must read it from the tables.** This has now been the same bug three
  times: the vtable offset in `MetadataResolver` and `InterfaceDispatchRecovery`, and
  `MethodInfo::klass`/`rgctx_data` in `RgctxResolver`, all written down as the 2022 layout and all
  wrong before 2022 (`MethodInfo` gained a field ahead of them, so klass is 0x18 not 0x20 and
  rgctx_data 0x30 not 0x38). The cost is never one load: nothing typed the class a shared body reads
  out of its MethodInfo, so the RGCTX table was untyped and every entry read out of it was untyped
  too — about 4600 placeholders from two numbers. `Il2CppClassUsefulOffsets.TryGetOffset` and
  `Il2CppMethodInfoUsefulOffsets.TryGetOffset` read the measured table `Il2CppClassOffsetPatcher`
  prepends, and that patcher now measures `MethodInfo` as well as `Il2CppClass`.
- **A dead lookup around a resolved call is not dead to the analysis.** `InterfaceDispatchRecovery`
  resolved the call and then required the merge phis to be dead before removing the scan that found
  it, which on A64 they never are: the scan walks the interface offset table with scratch registers
  the compiler reuses immediately afterwards, so SSA merges the walk's last value with whatever comes
  next and every phi has a live-looking use. Nothing outside the region reads what the region
  computed, so the answer is to give the phis a defined zero rather than to demand they be unused.
- **`[Il2CppClass<T[]> + element_class]` is the array store check**, and the element class is exactly
  what a metadata usage of T would have produced. It is reached through the array's own class only
  because the array's type is not known until runtime.

### Things measured to be worth nothing — do not redo them

- **Resolving a bare call address through `MethodsByAddress` when exactly one method sits there.**
  Resolves zero calls on both package 1.0.9 and `development`: the unresolved targets are il2cpp
  runtime functions and PLT stubs, not managed methods at all.
- **Naming unresolved call targets from the key function addresses.** Finds nothing, because the
  lifter has already consumed every call it recognised by the time the generator runs.
- **Raising `MaximumStackRepairs` from 16 to 64.** The same bodies give up, having accumulated 64
  pops instead of 16. Their imbalance is a branch join that merely surfaces at the return, so
  popping there can never settle it.
- **Re-running `MetadataInitGuardRemover.Run` after the second `KeyFunctionRecovery` pass.** Zero
  change. The guards survive for a different reason — the shape of the flag test, see above — not
  because the class initializer call was still unresolved when the pass ran.
- **Resolving call targets downstream, in `Il2CppIlRecoveryOutputFormat` rather than in the
  generator.** Placeholders fell but stubs rose from 2490 to 3509, because the downstream code has no
  signature to load arguments from and unbalances the stack. This is why the fix belongs in the
  generator, where the signature is in hand.

### The `ref/devx` branch

`ThinhNV-x-Percas/devx-decompile`, branch `ref/devx`, contains the IL2Cpp runtime struct database
(742 layout files) and `tools/structdb_gen.py`, and nothing else. It has no decompiler code. Its
contents are already absorbed into `StructDb/`; there is nothing further to take from it.
