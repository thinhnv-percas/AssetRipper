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
- **Every busy unresolved call address in the game is a veneer.** A table of single `b` instructions
  sits between the runtime and the generated code, and every call to a runtime helper goes to the
  veneer, so nothing that looks an address up finds anything without the hop.
  `MetadataResolver.ResolveCalls` takes it and asks all the same questions again — key function,
  managed method, throw helper, exception raiser — which is worth 2123 `Method not found`
  placeholders on its own. `Cpp2IlInstructionSet.GetThunkTarget` is the hop; ARM64's is a one-word
  decode, no disassembler.
- **An il2cpp .so has two executable sections**, `.text` for the runtime and one called `il2cpp` for
  every generated method body. `GetEntirePrimaryExecutableSection` returns only the first, so
  `GetCallerCount` — which every "which of these does managed code call" decision in
  `BaseKeyFunctionAddresses` rests on — counted a helper called 7999 times as 1. `Il2CppBinary.
  GetExecutableSections` returns both. The counts do not need a disassembler either: on A64 `B` and
  `BL` are one word with a signed 26 bit word displacement, so the histogram is a scan.
- **`Object::IsInst` is not found by the route Cpp2IL uses.** It looks for the last call in
  `System.Type::IsInstanceOfType`, assuming the one-line icall; on 2019.2 that is managed code
  ending in a virtual dispatch, and the heuristic reads past the end of the method and returns what
  the *next* function calls. On the test game that was the class-init thunk — not a miss but a
  collision, since `HandleKeyFunction` picks the first name with a matching address. It is now found
  as the busiest caller of `Class::IsAssignableFrom`, which is exported as
  `il2cpp_class_is_assignable_from`; IsInst is the only one of its dozen callers managed code calls
  at all, so caller counts separate it by three orders of magnitude. Worth 1351 calls, and with them
  the array store check, which is `value as T` once the call is recognised.
- **A pass that needs a resolved type has to run after the type fixpoint, even if it already ran.**
  The array store check could not be recognised the first time `InjectedCheckRemover` ran because
  the class being tested is only typed by `ResolveTypesAndFields`; both it and `KeyFunctionRecovery`
  now run a second time after it. The check's *epilogue* also needed widening: the helpers never
  return, so the compiler runs several together, and a block that builds an
  `ArrayTypeMismatchException` and falls into one that raises something else is still a check's
  epilogue.
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

- **The argument side of a float aggregate is lost in the lifter, not in the remap.** When the callee
  is known, `NewArmV8InstructionSet` builds the call's operands from
  `CallingConventionResolver.ResolveForManaged`, which names one register per parameter — so by the
  time `RemapRawArguments` sees the call there is nothing left to compose, and only the ~140 calls
  that still had a raw 16-register layout ever reached it. Composing in the lifter instead covers
  5474. The `MakeStruct` destination is a synthetic register (`AGG<address>_<slot>`), which is how
  SSA gets to version it — the same trick `TEMPSHIFT` and `TEMPCOND` use.
- **Recovering more of a program raises the placeholder count.** Composing aggregate arguments took
  unmanaged memory loads from 11892 to 12686, because the loads computing a vector's second and third
  members had been dead code and were dropped rather than reported. A metric that counts what could
  not be recovered goes up when something that was being silently discarded starts being kept.
- **The injected attributes make a lambda uncompilable.** A decompiler renders a `<Foo>b__0` method
  back as a lambda and moves its attributes onto it, and an attribute on a lambda is C# 10 while the
  scripts are exported at the language version the game was written in. Three errors per lambda, 651
  on the test game. `MethodAnalysisContext.IsLambdaBody` is what both injectors skip on.
- **A property that returns a static field is inlined, so the field is what gets named.**
  `Quaternion.identity` recovers as `Quaternion.identityQuaternion`, which is private — fine against
  the recovered assemblies, not compilable against the real ones. The pairing is a naming convention,
  not metadata: the public static property's name is a prefix of the field's.

- **There is a second measurement game and its APK is a release asset.**
  `RunFromZombiesFullProject` ships its own Unity source, so the recovery can be read against the
  real thing. The APK in the repository is a Git LFS pointer, which an unauthorised session cannot
  fetch, but the same file is a release asset and `curl` gets it:
  `https://github.com/thinhabc01/RunFromZombiesFullProject/releases/download/v1/demo.apk`. Unzip into
  `Test/Input/RunFromZombies` (gitignored) and rip that; Unity 2022.3.62f2, metadata v31.1, 55
  seconds. Its sixteen scripts are small enough to read whole.
- **An integer immediate stored where a float belongs is the float's bits.** The machine has no way
  to write a float constant other than to materialise the bit pattern in an integer register and
  store it; a genuine conversion would be an `scvtf`. Converting it as a number turned `-0.5f` into
  `3.2044483E+09f`, which reads as a plausible number and is not one.
- **A member of a game assembly that the recovered body reaches but a compiler would not is ours to
  widen.** il2cpp inlines a constructor, so the caller allocates the object and writes its fields
  directly, and where the type is compiler-generated those fields are private — which the type it is
  nested in cannot reach. Widening to internal is honest for a type this export invented the source
  for. A *framework* member is not: the assembly the exported script is compiled against is not the
  recovered one, so that case wants the public API instead.
- **A MakeStruct whose members all come from one place is that place.** A value read out of a field
  arrives as the field plus loads at four byte steps past it that nothing named; a value returned by
  a call arrives as the local the return register held plus the fields of it that
  `DefineFloatAggregateReturn` named. Folding it back has to be a pass rather than a generator case,
  or what the fold stops reading stays live — and it has to run after copy propagation, because the
  members are still locals until then.

- **A register that carries one member of an aggregate is often typed as the whole aggregate**, because
  the same register held a whole one somewhere else in the method — `Vector3.MoveTowards` inlined
  computes the moved position a component at a time into the registers the unmoved position was in.
  The local then reads as a Vector3 and `position.x + step` comes out as `position + step`. The cure
  is at the ends, as always: arithmetic takes its float type from the operands when the destination
  is not one, and the result is stored into the destination's first member rather than over the whole
  local.

- **A decompiler folds a state machine back only if the kickoff has the exact shape**: allocate
  `<Foo>d__1`, set `<>1__state`, return it. il2cpp inlines a trivial constructor, so the body
  allocates, calls `System.Object::.ctor`, and stores the state field directly — and ILSpy leaves the
  whole generated class in the output instead of a coroutine. `IlGenerator.InlinedConstructor`
  reconstructs the call by matching the stores that follow a `Newobj` against a constructor whose
  parameter names are the fields' names in order.
- **An address-take is versioned where the address is computed, not where the slot is written.** SSA
  can version a slot whose address is taken only while nothing writes it through the other name, and
  a spill does exactly that: take the address of a stack slot, store into it, call the boxing helper
  with the address. Renaming gives the address the version live *before* the store, so the boxed value
  reads as nothing — `Debug.Log(progress)` becomes `object obj = default(object); (float)obj`.
  `SsaForm.RetargetAddressTakesOverwrittenBeforeUse` points it at the version stored before the
  address is first read, within the block only; wider is the general aliasing problem.

- **A flag-setting instruction whose destination aliases a source needs its flags emitted before the
  write-back.** `subs w8, w8, #1` is how every countdown loop is written, and `EmitCompareFlags(src1,
  src2)` ran *after* the `Subtract`, so SSA renamed `src1` to the value just stored and the flags
  described one subtraction too many. A `for (i = 0; i < 20; i++)` came out as `while (num != 1)` after
  the decrement — nineteen iterations, and `Spawner` spawned nineteen rows of obstacles instead of
  twenty. Add's flags describe its result, so those stay after.
- **A store can be wider than the field its offset names.** Two adjacent `bool`s are written by one
  `strh`, and the ISIL memory operand carried no width, so the generator wrote the field at the offset
  and lost the rest: `Movement.right` was never assigned anywhere in the class, `if (right)` was dead
  code and the character could only move one way. `MemoryOperand.Size` now carries the access width
  from the lifter (store side only), `FieldReference.AccessSize` carries it past resolution, and
  `IlGenerator.PackedFieldsCovered` splits the store when the covered fields tile the range exactly.
  A wide store must also *not* type its value as the head field, or the packed word 0x100 arrives as
  `true`.
- **`Simplifier`'s "is this local read after here" walk could not see a read reached by a back edge.**
  It marked the start block visited before walking, so a read *before* `startIndex` in that same block
  was invisible even when the block is reachable from itself. A loop counter's back-edge copy therefore
  looked dead, and dropping it left the counter with one definition — which turned off the
  `stopAtJoins` guard, so the next constant pass carried the counter's initial value across the loop
  header and the trip count became `while (20 != 1)`. The start block is now re-entered once, from
  index 0. This only surfaced once the subtract's flags moved ahead of the write-back, because the
  earlier order let `CopyCoalescer` merge the copy away.
- **`scvtf` is lifted as a move**, along with every other conversion, so a local holding an integer
  reaches a float destination with its integer type intact — `screenWidth = Screen.width` with no
  `conv.r4`, which ILSpy annotates `Expected F4, but got I4`. The conversion belongs in the generator
  where the wanted type is in hand. An integer *immediate* is the opposite case and stays as it was:
  there the bits are the float, because materialise-and-store is the only way to write a float constant.

- **A float aggregate is lost on three sides, not two.** The return and the argument sides were already
  handled; the *parameter* side is `DefineFloatAggregateParameters`. A Vector3 parameter arrives in V0
  to V2, only V0 can be named as the parameter, and the other two read as `default(float)` — a setter
  whose whole body is `field = value` stored value.x and zeroed the rest.
- **A bounds check's condition can be an `Or` of two flags that are one comparison.** One `cmp` sets C
  and Z, and "lower or same" is `!C || Z`; chasing only copies and inversions stops at the `Or` and
  leaves the check in place. Reduce it only when one side is the carry of a `CheckLess` and the other
  the zero flag of the same subtraction, or a real `||` gets mistaken for a check.
- **A trivial property is inlined, so the field is what the body names — and the pairing is measurable.**
  `button.onClick` recovers as `button.m_OnClick` and `stack.Count` as `stack._size`. A name rule
  cannot cover the second, but a getter whose whole body is one load of the field off the receiver and
  a return is that field's accessor whatever either is called. `InstanceAccessorFor` lifts the getter
  once per field and caches it. Getters that also carry il2cpp's null check are not matched yet.
- **A third measurement game: `Impostor-Sort-Puzzle-Pro`.** Release asset
  `https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro/releases/download/v1/impostor-sort.apk`,
  source at `https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro.git`; unzip into
  `Test/Input/Impostor` (gitignored) and rip that. Unity 2022.3.62f2, metadata v31.1, ARM64, about four
  minutes, 6014 bodies. 42 of its own scripts, seven Editor-only.
  `docs/articles/ImpostorSortScriptAudit.md` records what is still wrong in it.
- **An unresolved call keeps the whole register file as its arguments, and that hides what a later call
  reads.** The sixteen raw sources of an unresolved call make every register look defined, so a
  resolved call further on can read a register nothing wrote and pass its entry value: `moveItem(gpc.
  currentBox, gpc.selectedBox, gpc.selectedImposter)` recovered with `null` for the first and third
  arguments, from `v28 @ X3`, the entry version. Treating such a call as clobbering the caller-saved
  registers would at least turn the silent null into a reported placeholder.

- **Arithmetic on an address, or on a local nothing typed, is arithmetic on a native integer.** An
  untyped local is declared `object`, so `sub` had a managed pointer on one side and an object
  reference on the other - a shape no type names, which ILSpy wrote out as
  `(ref *(_003F*)(&obj7)) - (ref *(_003F*)obj5)`, not C# at all (`_003F` is its mangling of `?`, the
  unnameable type). A `conv.i` on each such operand makes the IL well formed and the expression
  renders as pointer arithmetic instead: 148 occurrences across the three games, all gone. Comparisons
  are left alone, because `ceq` on two references is legitimate. What remains of the `ref *(T*)` shape
  is the *other* producer - a ref local assigned by dereferencing an untyped local - which is the
  untyped-locals problem, ROADMAP section 5.

- **The exported scripts can be compiled, and that is the measurement that cannot be argued with.**
  The rip ships every assembly it recovered and stubbed under `AuxiliaryFiles/GameAssemblies`, so
  `Test/Scripts/compile_recovered_scripts.sh <rip output> [assembly]` builds the exported C# against
  exactly the metadata it was recovered from and ranks what Roslyn rejects. Two cautions: the stub
  carries only what the game's metadata carries, so a member IL2CPP *stripped* from the build reads as
  a compile error even though the export is fine against a real Unity install (`Math.PI`,
  `Quaternion.Euler(Vector3)`, `StructLayoutAttribute`); and an error injected by the ripper is not a
  recovery defect at all — 4996 of Pinata's first 4999 were a duplicate `[AttributeAttribute]`, which
  is legal in metadata and rejected only by C#.
- **A declaration error hides every body error in the assembly, and silences every analyzer.** Roslyn
  binds declarations first and stops there when that stage failed, so Pinata read as "3 errors" for a
  long time and its real count is 7139. Both were `StructLayoutAttribute`, a pseudo-custom attribute
  that lives in a type's flags rather than as an attribute and so exists as a type in no stripped
  build; the harness shims it and `LayoutKind` in source. **A suspiciously small error count is a
  reason to read the log, not to celebrate** — and an analyzer that reports nothing is the same
  warning sign, since with no semantic model none of them run.
- **Microsoft.Unity.Analyzers is worth running and faults nothing the recovery does.** Its rules are
  about Unity's own contract rather than C#'s — a message with the wrong signature, a `GetComponent`
  for a type that is not a component — so they catch what a compiler does not mind. `ANALYZERS=<dir>`
  on the compile harness runs them; **most of its rules ship at Info severity, which the command line
  compiler does not print at all**, so the harness raises every `UNT` rule to warning through a global
  analyzer config, without which the run reads as a clean sheet and is a silent one. 224 findings on
  Pinata, 35 on RunFromZombies, 21 on Impostor, every one of them present in the source too, and none
  from the families that would indicate a defect (`UNT0006`, `UNT0010`, `UNT0011`). Do not re-run this
  expecting to find recovery bugs in it; re-run it after a change that could introduce one.
- **A constructor is not something C# can call on an object that already exists.** `x._002Ector()` is
  what a decompiler writes for one, and there are three producers: an allocation whose constructor call
  could not be fused (fixed by matching `InlinedConstructor` on parameter *names* rather than
  positionally, and reading a missing store as the zero a fresh object already holds - worth 372
  unresolved loads on Pinata as well, since the arguments stop being dead code); a stray call the
  `newobj` already covers, which is dropped; and the base call inside a constructor, which is
  retargeted to the direct base where il2cpp folded a trivial one onto `System.Object` and hoisted to
  the front, since an initialiser is the only place C# can write one. **ILSpy will not fold a base call
  in a method that carries a stack type mismatch**, whatever position it is in, so what is left of this
  is section 5.
- **Most of the untyped locals cost nothing, and the breakdown is what says which.**
  `IlGenerator.UntypedLocal` is raised from the one place that declares a local as `object`, and the
  output format groups them by the opcode that writes them and by whether anything reads them. Of
  51464 on Pinata, about 42000 are harmless: 21587 are a register's entry value first read by an
  *unresolved* call, and the generator emits a placeholder for such a call rather than loading its
  operands at all; 6383 are read by nothing. The ~9600 that cost a cast are three quarters arithmetic.
  Read that log line before working on section 5.
- **An enum is its underlying integer, a shift or bitwise result is an integer whatever its operands
  were, and the result of a type check is the type checked for.** Three rules the fixpoint was missing,
  worth 3164 typed locals and 2552 fewer `object` declarations in Pinata's exported source. The
  integer rules that existed all required an operand *already* known to be an integer, which a shift
  by a constant of a register nothing typed does not have - but nothing other than an integer is ever
  shifted. Boolean logic must still run first or a condition assembled from flags stops being boolean.
- **An address used where a reference is wanted is the value at that address.** il2cpp passes a
  pointer to a stack slot where the managed signature takes the value, and `ldloca` there renders as
  `(object)(&obj2)` - a cast from a pointer to a reference, which C# does not have. This applies
  wherever the wanted type is a reference *and* wherever the destination is a local nothing typed,
  since that is declared `object` and has the same problem. `Type.GetTypeFromHandle` is the same
  family: reached holding the type, it came out as `GetTypeFromHandle((RuntimeTypeHandle)typeof(T))`,
  and the token is what a handle is.
- **What is left of section 5 is the same problem from the use side.** A local typed from its
  definition and used somewhere that wants another type: an `int` where a `Fsm` is wanted, a `Type`
  where an `IntPtr` is, a `float` where a `Vector3` is. The rule that covers them types an untyped
  local *from its use* - the argument position of a resolved call, the value side of a store into a
  typed field, the other operand of a comparison - which is the constraint-based formulation the
  machine-code typing literature uses. `PropagateFromCallParameters` is the one instance that exists.
- **A struct's members reach the generator through five paths, and the accessor pairing has to sit in
  all of them.** Each time the pairing "obviously should" have fired and did not, the cause was that
  the access never reaches the code the pairing is in - and the tell is always the same: trace it, see
  it is never *called*, then find who emits the access instead. The five: `LoadOperand`'s
  `FieldReference` case; the `Move` case's own field store (`StoreToOperand` is not on that path);
  `OpCode.MakeStruct`, which is where a four-float struct's stores come from; `LoadOperand`'s
  `LocalVariable` case, where a whole aggregate in a local with a float wanted loads its first member
  directly; and the same rule one step out, on a *field* of an aggregate type, where the property needs
  the field's address so the decision must precede the load. Identical error counts to the digit are
  what a pass that never fires looks like.
- **An inlined framework throw helper is the throw it performs.**
  `System.ThrowHelper.ThrowArgumentOutOfRangeException()` names a type internal to the framework, and
  the helper never returns and is named after what it raises - so the name past `Throw`, looked up in
  the game's own mscorlib, is an exact rendering rather than a stand-in. Worth 147 errors and, because
  a recognised helper stops being an unresolved call, 82 unresolved loads and 54 method-not-found
  placeholders as well. **A delegate's two-argument constructor** (receiver plus function pointer) is
  the opposite case: C# cannot write it at all, a decompiler renders it `new Func<bool>(obj, method)`,
  and the pointer always comes from a load nothing resolved - so the honest output is a reported loss.
- **The offsets in an accessor's body are object-relative even when the field's own are not.** The
  metadata records a value type's fields from the start of its data - `Rect.m_XMin` is 0 - while
  `Rect.set_x` lifts to `Move [X0+10], V0 | Return`, because the receiver il2cpp hands a value type's
  method points at the object header. So the trivial-accessor pairing has to match the field's offset
  *plus the header* for a value type and the field's own for a class, which is why it had always
  worked on `button.m_OnClick` and never on a struct in any game. Two other things hid this: a test
  for a *positive* offset, which reads a struct's first field as "not known"; and the fact that a
  four-float struct is a float aggregate, so its stores come out of `OpCode.MakeStruct` and not the
  general field-store path - pairing that path changed the error counts by nothing at all, which is
  what a pass that never fires looks like. The write side matters more than the read side here: a
  recovered body writes a struct a member at a time, so all 338 of Pinata's `Rect` errors were stores.
- **A member of a game assembly is ours to widen across assemblies too, and `protected` to `internal`
  is not a widening.** il2cpp inlines the fast path of a property, so `Assembly-CSharp` reaches
  straight into PlayMaker's `FsmBool.value`: 4606 errors on Pinata, more than every other kind
  together, and unfixable by pairing because `FsmBool.Value` consults `CastVariable` first - the field
  access really is the inside of it. `Il2CppIlRecoveryOutputFormat.WidenMembersTheBodyCannotReach`
  resolves cross-module references and widens to public, with the owning type, for any assembly that
  is not `IsFrameworkAssembly`. Widening `System.Attribute..ctor` from protected to internal, on the
  other hand, made every attribute the export declares uncompilable: a derived type in another
  assembly can call a protected constructor and cannot call an internal one, so protected becomes
  protected *internal*.
- **A field of a generic instance carries no metadata of its own.**
  `ConcreteGenericFieldAnalysisContext` is `base(null, genericInstanceType)`: `BackingData` is null and
  `DeclaringType` is the instantiation, which has no properties — so anything measured off a field, the
  trivial-accessor pairing included, has to be measured on the definition and instantiated afterwards.
  Every field of a generic type is also at offset 0 in the metadata;
  `GenericInstanceFieldLayout.OffsetOfField` computes where one actually sits, which is the same walk
  `FindFieldAtOffset` does read the other way round.
- **`Test/Scripts/audit_recovered_scripts.py` compares a recovery against the source it was built
  from**, per assembly rather than per file, and counts every diagnostic and known-bad shape per file.
  Run it before and after a change on a game that ships its source;
  `docs/articles/RecoveredScriptVerification.md` is the standing record. Two traps it exists to avoid:
  the exporter writes **one type per file**, so `UserResource.cs`'s four types come back as four files
  and a per-file member diff invents six missing members; and **`#if UNITY_EDITOR` is not in the
  build**, so five of `GameHelper`'s methods are correctly absent.
- **The integer half of the type fixpoint had no seed.** Floats propagated from operands to
  destinations and back, integers only from operands to a destination, so a loop counter nothing typed
  stayed `object` and every use of it read `(nint)obj`. Two seeds: a comparison types its untyped
  operand from whichever other operand is an integer (comparisons only - the same on `Add` would type
  the base of every `[base + index]` computation, and a comparison against the immediate zero is a
  null check, so neither seeds), and arithmetic whose operands are *all* known integers types its
  result (all, not any, for the same reason).
- **A value type local zeroed by an integer 0 needs `initobj`, not a store.** `Move <struct local>, 0`
  emitted `ldc.i4.0; stloc`, which ILSpy wrote as `(Stack<object>.Enumerator)0` - a cast from an int
  to a struct, which is not a conversion C# has.

- **A recovered file is large because of copies, not because of inlining.** `DataController.cs` is 360
  source lines and 2690 recovered ones, but the ratio is per method: four of its nine are near 1:1 and
  three account for 2005 lines. Accounting for all 846 lines of the worst one, the largest single item
  is **192 local-to-local copies** (`num11 = num31;`) left by SSA destruction - one per merged version
  per predecessor edge - against 120 temporary declarations, ~90 lines of unfolded ARM64 flag
  arithmetic, 81 diagnostics, and only 13 lines of inlined `List`/`Stack` internals.
- **Those copies are mostly genuine interference, so coalescing is not the lever.** `CopyCoalescer`
  merges 74262 of them on the third game and keeps 18738 **because the two locals are live at once**,
  which is what a loop-carried value is: `num` is live where `num + 1` is computed, so the copy on the
  back edge cannot be merged away. The pass now logs the three outcomes, and that line is the thing to
  read before trying to improve it. A further 3200 are kept because the types differ.
- **A phi is not code, and treating it as code cost half the size of a recovered file.** A dozen null
  checks branching to one `throw` make that block a join, so SSA gives it a phi for every register
  live there - and `InjectedCheckRemover.GetInjectedThrowType` walked the block's instructions and gave
  up on the first thing that was not a Nop, a Return, a Throw or a Newobj. So the epilogue of every
  such check went unrecognised and all of them survived. Thirty-seven converging on one throw in
  `DataController.GenarateRandomDataMap` is what forced ILSpy into `goto`s: it structures a graph but
  does not duplicate blocks, so a check that cannot be removed can only be a jump. Skipping phis - and
  following a landing block that holds nothing but phis to what it falls into - took that file from
  2647 code lines to 1253, its `goto`s from 41 to 15, its nesting from 27 levels to 19, and Pinata's
  unresolved loads from 12445 to 11215.
- **A throw reaches nothing, and the graph is built before it is one.** The CFG comes from the lifted
  ISIL, where a throw is still a call to an il2cpp raise helper, so its block falls through; the passes
  that rewrite the call into `OpCode.Throw` do not revisit the edges. The throw block therefore had an
  outgoing edge back into the code, and with an entry per check that made it an irreducible loop.
  `UnreachableAfterThrow` runs after SSA destruction and detaches it. Worth 60 lines on that one file
  on its own, and it has to run late: the throw does not exist when the graph is built.

- **The destination can be the side that names a float aggregate, and then it is the one that is
  right.** `FloatArithmeticOperandType` required an *operand* to be an aggregate, so a method returning
  a `Vector3` - whose return value is typed as one, with the machine computing a component straight
  into it - fell through to `(Vector3)(num6 / ...)`, a conversion C# does not have. Two additions: an
  aggregate destination with a scalar float operand is float arithmetic, and so is an aggregate
  destination whose operand aggregates *disagree* with it in type, which is what
  `(Vector3)((object)bottomLeft + (object)quaternion)` was - a register that carried a Quaternion
  earlier in the method typed a Vector3 computed into it later. Same-typed aggregates are deliberately
  left alone, in case the operation really was over the whole value.
- **Zero for a value type is `default`, not a cast from a number.** A struct the recovery could not put
  back together is zero in the register the ABI returns it in, and loading that as a literal read back
  as `(Color)0`. `initobj` is what zeroing a value type is; the reference side of the same rule had
  been emitting `ldnull` for years. Took Impostor's invalid struct casts to zero.
- **`(Vector3)(long)intPtr` is not the arithmetic rule, it is section 5.** 39 of the 79 left on Pinata
  are an `IntPtr`-typed local passed where a `Vector3` argument is wanted, in Obi's middleware.
  Emitting `default(Vector3)` there would compile and would silently lose a value the cast at least
  admits was there.

- **A body that threw out of the generator is invisible in every metric except the log.**
  `AsmResolverDllOutputFormatIlRecovery.FillMethodBody` catches whatever `IlGenerator.GenerateIl`
  throws and puts the exception text in the body, so the method still exports and reads as a `throw`.
  It contributes no placeholders, no untyped locals and no unresolved loads, so 15 lost bodies on the
  third game — `TimeInGame.CompareTo` among them — sat behind clean-looking numbers. Count
  `Cpp2IL [Error] : Decompiling` in the log first, before any other measurement. The cause there was
  that **generation is allowed to emit nothing for an instruction**, and a branch to one of those had
  nothing to bind to: `instructionMap[target][0]` on an empty list, where the same guard was already
  two loops above it for `blockEntryMap`.
- **A value type's constructor call is not the leftover half of an allocation.** Dropping a `.ctor`
  call outside a constructor is right for a reference type, whose object is constructed at the
  `newobj`, and wrong for a value type: there is no allocation, il2cpp calls the constructor on the
  address of the slot holding the value, and that is exactly what C# compiles `x = new T(...)` to and
  what the receiver load already emits. `TimeInGame.CompareTo` built two `DateTime`s and compared
  them, and came back as `return default(DateTime).CompareTo(value)` — compiles, and reports every
  pair of times as equal.
- **A throw helper's name is a guess, and what it is handed is a fact.**
  `ThrowHelperRecovery.ResolveName` names a helper after the first string ending in `Exception` that
  it or, failing that, a callee references. The generic raiser's implementation and the out-of-memory
  helper both end in `adrp/add x1, <the same type_info>; mov x2, xzr; bl __cxa_throw`, so the two are
  indistinguishable by name and `throw new UnityException(message)` came back as
  `throw new OutOfMemoryException()` — 563 times on the third game, with the exception the body built
  left dead in a local beside it. `IsExceptionRaiser` cannot separate them either: it is true for
  every resolved helper, because they all reach the native throw. **An allocation in the argument slot
  is what settles it** — a helper that builds its own exception has no use for one. Trace it through
  straight copies, and through a phi only when *every* input is an allocation: taking a phi's first
  input found an allocation from elsewhere in the method at a *bounds check* call site, which stopped
  eight injected checks being recognised and cost 98 compile errors.
- **`InspectPotentialThrowHelper` stops at `RET`, `BR` and an unconditional `B`, and a stub that ends
  by falling into the next one has none of them.** `0xAD96B4`, `0xAD96BC` and `0xAD96C4` on the third
  game are three two-instruction stubs (`str x30, [sp,#-16]!; bl <helper>`) laid out adjacently, so a
  scan from the first collects all three helpers' calls. The first call target is still the right
  answer for each, so it costs nothing today; any pass that reads that call list as one function's is
  wrong.

- **A family named after a symptom is worth inventorying before it is worth working.** 850 loads were
  reported as "past the last field of the base type". Classifying them rather than counting them said
  four unrelated causes: 361 whose base is the runtime generic context table and so has *no fields to
  be past*, 246 whose base is typed `System.Object`, 139 whose base is typed as an ancestor of the
  real type, 99 open generic parameters. The one that dominated the family was the one the name fitted
  worst, and it was the only one with a metadata answer. `CPP2IL_DUMP_LOADS=<file>` writes one row per
  load from the same event the summary counts, so the inventory and the reported total are the same
  set; `reports/BASE_FIELD_OVERFLOW_ANALYSIS.md` is the worked example.
- **An uninflated generic definition is shared generic code, and its own parameters stand in for the
  arguments.** `RgctxResolver.ResolveMethodEntry` knew this and said so in a comment;
  `ResolveTypeEntry` passed `GenericArguments ?? []` and so failed to inflate every RGCTX entry that
  mentions the type's own parameter. The cost is never one load: an unresolved slot leaves the class
  pointer untyped, which leaves the class-init guard unmatched, which leaves the static field storage
  unresolved. `SingletonMono<T>.Instance` was 39 unresolved loads and no recoverable logic; one
  substitution took `Il2CppRgctx` in the export from 1345 to 12 and the REAL_ERROR audit count from
  1766 to 1307.
- **A phi whose inputs disagree must stay untyped.** `PropagatePhi` took the first typed input and
  stopped, and the backward rule then spread that type to the phi's other inputs. The compiler reuses
  a scratch register freely - X8 carries both a class's static field storage and ordinary objects - so
  `phi(Il2CppStaticFields<UnityEngine.Quaternion>, GamePlayController)` is routine, and typing it as
  the storage made `gpc.<field>` read as `[Il2CppStaticFields<UnityEngine.Quaternion>+3C]`, past the
  end of a sixteen-byte block. 69 occurrences in `DataController.cs` alone, and fixing it took that
  file from 209 diagnostics to 129. This is the third time the same principle has paid: an honest
  unknown costs one reported load, a wrong concrete type costs every use downstream.

- **A shared generic body is attributed to one instantiation, and the type fixpoint is monotonic.**
  il2cpp compiles one body per generic definition and shares it, so the method a call address
  resolves to is whichever instantiation the linker attributed it to - and the first type a local
  receives is the one it keeps. `List<System.Object>.get_Item` typed its result `System.Object`
  before the field declaring `List<LinkedMesh>` had resolved, and `linkedMeshes[i].skin` could never
  come back. The receiver is the stronger evidence, so `MetadataResolver.RetargetSharedGenericCalls`
  re-instantiates the callee on the receiver's own generic arguments, inside the fixpoint where the
  field has had a turn. It is a no-op where the two agree, so nothing has to know which arguments
  are placeholders. **Withholding a type because the callee is shared has to be narrow**: a shared
  `List<T>.Enumerator.MoveNext` returns `bool` whatever T is, and refusing that left the local for
  SSA destruction to merge with the receiver's register - `GUIManager x = (GUIManager)MoveNext()`
  with the loop condition read off `this`. `ContainsSharingPlaceholder` requires the substitution to
  have reached the type in hand.
- **`System.Object` at a use site is the top of the lattice, not evidence.** Every reference type
  converges on it, so a value reaching a position declared `System.Object` is known only to be a
  reference - and recorded under a monotonic fixpoint, that is permanent. A delegate's two-argument
  constructor takes its target as `System.Object`, so `new OnlineTimeCallback(this, ...)` typed the
  argument copy, the copy rule propagated it backwards, and the state machine's `<>4__this` - a
  field metadata declares `TimeCheatingDetector` - arrived to find the local already typed.
  Thirteen field reads in one method became unnameable offsets. **Withholding it outright is worse**:
  the local then falls to `TypeCounters`, whose guess is weaker still, and `obj as ItemResources`
  came back `(int)(obj as ItemResources)`. The fixpoint runs twice instead, once withholding and
  once allowing, with `TypeCounters` still last, so each rank of evidence gets its turn in order.
  The rule is use-site only: a field or a return whose declared type really is `System.Object` is
  that type.
- **Assembly-CSharp holds under a tenth of the unresolved loads.** 359 of 3689 on the test game;
  spine-unity alone holds half. Both measurements that are easy to reach - the Roslyn count and the
  audit - cover only Assembly-CSharp, so a fix landing anywhere else reads as inert. Count per
  assembly before concluding a change did nothing; `reports/TYPE_RECOVERY_ANALYSIS.md` carries the
  table, and `CPP2IL_DUMP_LOADS` names the assembly on every row.
- **A load is given up on for one of two reasons and the defining instruction is what tells them
  apart.** 1576 of the 3689 have no usable base type; 2113 have one and the offset could not be
  placed in it. Working the second list is typing work only sometimes - about 600 of them are
  `Il2CppClass` and `Il2CppMethodInfo` reads with the right base and the right offset, waiting on a
  pass that recognises the shape rather than on a type.

- **Kiểu hợp lưu của một phi lan ngược vào input là bằng chứng yếu.** Một phi là điểm hợp lưu; nói
  rằng mỗi input mang kiểu của hợp lưu chỉ đúng khi không có gì tốt hơn định nghĩa input đó, và dưới
  một fixpoint monotonic điều đó phải được xác lập *trước* khi luật chạy. Trình biên dịch tái sử
  dụng X8 cho class pointer của `List<T>` rồi cho chính `list._items`, nên phi hợp nhất hai giá trị
  đó nhận kiểu class và lan ngược lên cái mảng: `_items.Length` đọc thành
  `[Il2CppClass<List<Object>> + 0x18]`, điều kiện fast path của `List.Add` so sánh với số không, và
  nhánh ghi phần tử mất hẳn — trong một hàm mà nguồn chỉ có `list.Add(t.gameObject)`. Cách sửa là
  xếp lại hạng, không phải cấm luật: hướng lan ngược chuyển xuống pass thứ hai của fixpoint, cùng
  chỗ với `System.Object` tại use site, và `TypeCounters` vẫn cuối cùng.
- **Một vòng phi không chết đối với phép đếm lượt dùng.** `DeadCodeEliminator` đếm lượt dùng rồi lặp
  tới điểm bất động, và phép đếm không nhìn xuyên được một vòng: một phi mang giá trị qua vòng lặp
  được dùng bởi chính phi tiếp theo, nên mọi phi trong vòng đều có vẻ còn dùng. Lifter sinh cả chùm
  cờ cho mỗi `cmp` và SSA phi hoá các thanh ghi cờ tại mỗi điểm hợp lưu, nên trên A64 cả một phép so
  sánh đã được nhận diện và thay thế — kể cả hai lệnh đọc class pointer nuôi nó — vẫn nằm lại sau
  một vòng phi chỉ tham chiếu lẫn nhau. Mark and sweep từ các lệnh có hiệu ứng lấy đi 699 load,
  đưa số lệnh đọc `typeHierarchyDepth` từ 139 xuống 18, và giảm thời gian chạy 42s xuống 38s. Đây
  cùng là hình dạng đã ghi ở trên cho `InterfaceDispatchRecovery`, chỗ phải tự tay gán 0 cho các phi
  hợp lưu thay vì chờ chúng chết. **Phải đánh dấu mọi định nghĩa của một local, không chỉ cái cuối**:
  dạng biểu diễn được coi là SSA nhưng một pass viết lại lệnh có thể để một local có nhiều hơn một
  định nghĩa, và bản chỉ đánh dấu cái cuối cho con số đẹp hơn nhiều (2458 load thay vì 2870, Roslyn
  315 thay vì 340, REAL_ERROR 754 thay vì 884, 15 file tốt lên thay vì 7) trong khi xoá code còn
  sống — CS0165 "use of unassigned local variable" từ 5 lên 12. Đó là bản duy nhất trong toàn bộ
  quá trình tốt hơn trên *mọi* cột dễ đọc và vẫn phải bị loại.
- **Đừng neo shape check vào tên biến do ILSpy sinh kèm số thứ tự.** `boundingBoxAttachment2`,
  `num5`: số đó đếm các biến đứng trước nó, nên bất kỳ thay đổi nào làm thân hàm dài ra hay ngắn đi
  đều đổi nó. Ba check hỏng ở iteration 030 vì đúng lý do đó, không liên quan gì đến ngữ nghĩa, và
  mất một vòng để nhận ra. Neo vào chính câu lệnh (`.Count < items.Length)`, `dictionary[array2[`).

- **Trên iOS, il2cpp không nằm trong app executable.** Unity 2019.3 chuyển player vào một
  framework nhúng, nên `Payload/<name>.app/<name>` là một launcher vài chục KB và mã managed nằm ở
  `Frameworks/UnityFramework.framework/UnityFramework` — 70 KB so với 51 MB trên fixture Jelly Blast,
  và chuỗi `il2cpp` xuất hiện 243 lần ở file sau, 0 lần ở file trước. Đưa sai file vào thì lỗi hiện
  ra là "No codegen modules found for mscorlib", đọc như một vấn đề metadata trong khi metadata đã
  nạp xong từ trước. Phép đo chứng minh binary đúng đã được nạp là **metadata registration đi từ
  `0x0` lên một địa chỉ thật**, vì nó là cấu trúc trong `__DATA`.
- **Một bản iOS tải từ App Store có `__TEXT` bị FairPlay mã hoá và không công cụ tĩnh nào đọc
  được.** `LC_ENCRYPTION_INFO_64` với `cryptid` khác 0 phủ toàn bộ `__TEXT`, mang theo cả `__cstring`
  — và code registration được nhận ra qua chính *tên module*, nên `mscorlib.dll` xuất hiện 0 lần
  trong cả 51 MB. `__DATA` thì không bị mã hoá, nên metadata registration vẫn tìm được: nửa đầu
  pipeline chạy, nửa sau thì không. Ba phép đo phân biệt ciphertext với mã máy mà không cần khoá:
  entropy 7,997 trên 8 (so với 3,638 ở `__DATA`), **không có một lệnh `ret` nào** trong 1 MB, và tỉ
  lệ khớp mặt nạ prologue đúng bằng tỉ lệ ngẫu nhiên. Sự tồn tại của `SC_Info/*.sinf` xác nhận đây
  là bản từ store. `MachOFile` giờ báo điều này tại loader; **báo lỗi input tại input, đừng patch
  tầng dưới để che**. Và lưu ý mọi case trong switch của `MachOLoadCommand.Read` phải tiêu thụ hết
  payload của nó: dạng 64-bit có bốn byte padding sau `cryptid`, bỏ sót làm load command sau bị đọc
  từ giữa command này.
- **Một thân generic chia sẻ hoàn toàn cấp phát stack lúc chạy, và kiểu của những ô đó không tồn tại
  tĩnh.** Trình tự là: đọc `Il2CppClass.stack_slot_size` (offset 0xFC trên 2022.3) của mỗi tham số
  kiểu, cộng 15 rồi `and 0x1FFFFFFF0` để làm tròn lên bội số 16, trừ vào SP, rồi `memset`. 87 trong
  109 load `[X29 - k]` không có kiểu của bản rip nằm trong đúng một type như thế,
  `Spine.Collections.OrderedDictionary<TKey,TValue>`. Đây là điểm dừng hợp lệ chứ không phải thất
  bại: `TKey`/`TValue` là tham số kiểu thật sự, không phải placeholder suy ra được, nên không có
  bằng chứng tĩnh nào gán kiểu cho chúng. Việc *có thể* làm là nhận diện cả trình tự alloca như
  scaffolding runtime và bỏ đi.
- **`[&stack_-88 + 0x14]` chính xác là `stack_-74`, và đó là số học chứ không phải suy đoán.**
  `StackAnalyzer.NameForSlot` đặt tên mỗi ô stack theo chính offset của nó, nên một lệnh đọc qua địa
  chỉ của một ô với offset hằng số có đích xác định được, và các ô đích thường đã có kiểu đúng —
  `combinedBounds = bounds` trong `SkeletonGraphic` là sáu lần load/store float ở đúng offset 0x0
  đến 0x14 của một `Bounds`. 124 load thuộc hình dạng này. Cái khó duy nhất là **chọn version SSA**:
  địa chỉ được lấy ở `stack_-88_v3` còn các ô được ghi ở `_v5`, và chọn sai version tạo ra một giá
  trị sai im lặng. Phải dùng cùng cơ chế `SsaForm.RetargetAddressTakesOverwrittenBeforeUse`, và khi
  không xác định được thì để nguyên placeholder.
- **Một họ bug đặt tên theo triệu chứng vẫn phải phân loại trước khi làm — lần thứ hai.** "245
  frame-pointer spill" là ba thứ khác nhau: 109 cần thông tin runtime, 124 là một phép viết lại
  operand chứ không phải gán kiểu, 23 là spill thường rải trên bảy method. Đúng như 850 load "past
  the last field" trước đây.

### Things measured to be worth nothing — do not redo them
- **Nhận diện cặp so sánh qua chùm cờ A64 trong `TypeCheckRecovery`.** Trên A64 một `cmp` lift
  thành cả một chùm cờ chứ không thành một phép so sánh, và đẳng thức là cờ Z của một phép trừ:
  `Subtract d, a, b` rồi `CheckEqual z, d, 0`. `TypeCheckRecovery` so khớp mọi hình dạng của nó trên
  hai toán hạng của phép so sánh nên không bao giờ nhìn thấy cặp giá trị thật sự đang được so sánh.
  Lấy hai toán hạng của phép trừ là *chính xác* chứ không phải heuristic (`a - b == 0` đúng bằng
  `a == b`), nó nhận thêm 82 phép kiểm tra kiểu (359 lên 441), và đối chiếu nguồn Spine dòng 158 thì
  `var boundingBoxAttachment = attachment as BoundingBoxAttachment;` quay về đúng câu đó. **Và giá
  trị của nó bằng không**: 82 lần nhận thêm đều nằm trong vùng code chết — trong
  `BoundingBoxFollower` nó sinh ra cái `as` thứ ba trong khi nguồn chỉ có hai — nên khi
  `DeadCodeEliminator` biết quét từ gốc, đo có và không có nó cho kết quả giống nhau tới từng con số
  (2799 load, 2079 method-not-found, 13 lệnh đọc typeHierarchyDepth, 39 `as Dictionary`). Bug thật
  là DCE, không phải matcher. Đừng làm lại nếu không có bằng chứng rằng một trong các vùng đó còn
  sống.

- **Generalising the computed element address fold onto an affine evaluator.** The fold matches
  `[t + elementsOffset]` where `t = array + scaled index`, and it misses two shapes the compiler
  emits: a constant index, which has no register at all, and an index left in the addressing mode
  when only the elements offset was added ahead of the load. Evaluating the whole address as an
  affine function of one register with the array as the origin - which is the machinery
  `RecoverStructElementAddresses` already uses - covers all three in one rule, and measured worse on
  every cut: unresolved loads 3689 to 3969, and 4084 with the addend still restricted to the
  elements offset, so it is not the relaxation that costs. Reading through a chain of definitions to
  find the array produces an address that is arithmetically valid and belongs to another expression;
  the narrow shape is precise because the shape itself proves the array is the base. Adding the two
  missing shapes *without* the chain walk is worth 219 loads, and is what shipped.

- **Emitting the blocks in address order rather than the order the graph created them.** Splitting
  appends, so a block split out late sits at the end of `Blocks` whatever address it covers, and it
  looked as though a loop header landing after its own body were what forced the `goto`s. Sorting the
  emission by the address of each block's first instruction measured *worse*: `DataController`'s
  `goto`s went from 15 to 21. The generator gives every fall-through an explicit `br` and resolves
  every target through a label, so the order is free - and ILSpy evidently does better with the graph
  order than with the machine's. The `goto`s were the unremoved null checks, not the layout.

- **Typing the stand-in value a giving-up point pushes.** Every unresolved operand pushes
  `ldc.i4.0; conv.i` - a native integer zero, whatever the use wanted - so a reference position read
  back as `((GameObject)0).SetActive(false)` and a struct one as
  `Type.GetTypeFromHandle((RuntimeTypeHandle)0)`. Pushing `ldnull` for a reference and `initobj` for a
  struct instead measured **worse on every axis**: REAL_ERROR audit diagnostics 1766 to 2007, Roslyn
  456 to 548, `nint_cast` 545 to 703, thirteen files worse. Excluding pointers, byrefs, arrays and
  open generic parameters from the substitution changed the result by nothing at all, to the digit, so
  those are not the cause. The reason appears to be that the wanted type at these positions is
  routinely *not* what the value is - a native integer is what the machine had, and saying so keeps
  the mismatch in one expression instead of propagating a reference into arithmetic. The ill-typed
  placeholder is honest about a value that is genuinely an address. Do not retry this without first
  fixing what makes the load unresolvable.

- **Coalescing copies across different registers.** `CopyCoalescer` only considered copies between
  two versions of one register, and widening it to any local-to-local copy - letting the interference
  graph decide, which is the textbook formulation - made the output *worse*: Impostor's assembly fell
  60 lines but gained 7 diagnostics, and `DataController` itself grew from 2647 to 2737. The copies
  that matter interfere, so the wider search only perturbs types and costs `Simplifier` some
  propagation. Comparing the two ends' types **by name rather than by reference** is the part that was
  worth having, and is kept: 1098 more copies merge on that game.


- **Preferring the scalar float when a phi merges one with a float aggregate, and typing every member
  of a `MakeStruct` as its field's type.** Both are true, and both changed nothing once arithmetic
  took its float type from its operands: the phi's inputs are all aggregates by the time it is typed,
  and the MakeStruct members are already floats. Removing them left the output identical.


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

### The measurement harness

`docs/agent/` maps the pipeline: `ARCHITECTURE.md` per stage, `DECOMPILER_PIPELINE.md` the call graph
and the six representations a body passes through with the table that says which one a given defect
first went wrong in, `REFERENCE.md` how far the third game's source can be trusted. `AGENT_STATE.md`
is where a session picks up; `reports/issues.json` and `reports/regression-matrix.md` are the record.

Four scripts, and each measures something the others cannot:

- `Test/Scripts/collect_metrics.sh <iteration>` — every placeholder kind and every recovery counter
  from one run into one comparable JSON. **`generatorFailures` first**, for the reason above.
- `Test/Scripts/check_recovered_shapes.sh <rip output>` — golden checks stated as shapes rather than
  counts, so each keeps meaning as the numbers around it move. A check whose file is missing FAILs.
- `Test/Scripts/compile_recovered_scripts.sh <rip output> [assembly]` — Roslyn.
- `Test/Scripts/audit_recovered_scripts.py` — against the source, per assembly.

`iterations/` holds one immutable directory per run: the commit, the change that was in the working
tree, the log, the metrics, the audit and the compile result. The generated projects themselves are
gitignored, being large and reproducible from the rest.

### The `ref/devx` branch

`ThinhNV-x-Percas/devx-decompile`, branch `ref/devx`, contains the IL2Cpp runtime struct database
(742 layout files) and `tools/structdb_gen.py`, and nothing else. It has no decompiler code. Its
contents are already absorbed into `StructDb/`; there is nothing further to take from it.
