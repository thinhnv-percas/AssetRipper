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

- **A value read through a correct pointer can still be ciphertext, and provenance is what says so.**
  `InstanceSize=2249170484` for `Mono.ValueTuple` on the iOS fixture was neither a wrong registration
  candidate nor a chained-fixup bug — the two hypotheses on record. The `typeDefinitionsSizes` table
  is 8702 pointers in `__DATA`, strictly ascending at exactly a 16-byte stride, with no nulls: it is
  right. Every target is in `__TEXT.__const`, which FairPlay encrypts, and reads at entropy 7.999 out
  of 8 against 3.2 to 4.2 in `__DATA`. So the test has to be *where the bytes came from*, never how
  plausible the number looks: `IsVirtualAddressEncrypted` maps an address through the **segments** —
  a byte in a segment but in no section is still encrypted — and `RawSizesAreReadable`,
  `CountEncryptedFieldOffsetTables` and `GetFieldOffsetFromIndex` all answer "not known" off that.
  The old guard was `Size > 1 << 30`, which catches large ciphertext and passes small ciphertext, both
  for the wrong reason. Field offsets are the same shape and matter more quietly: the pointer is in
  `__DATA` and the offsets are not, so reading them lays every field of 5782 types at a random offset
  with nothing downstream able to tell.
- **The iOS fixture has no chained fixups.** It carries `LC_DYLD_INFO_ONLY`, not
  `LC_DYLD_CHAINED_FIXUPS`, so `ApplyChainedFixups` never runs on it and could not have been the
  cause of anything measured there. `__TEXT` is at vm 0 and `__DATA`'s vmaddr equals its file offset,
  so in `__DATA` a virtual address *is* a file offset and needs no transformation at all.
- **`DYLD_CHAINED_PTR_64` and `DYLD_CHAINED_PTR_64_OFFSET` differ in one respect and a dylib cannot
  tell them apart.** The first format's target is an unslid virtual address, the second's is an offset
  from the image base; `UnityFramework` is a dylib and links at zero, so they coincide there and the
  bug is invisible on every iOS fixture. Test it on a synthetic binary with a non-zero image base or
  not at all. A chain is also confined to its page — `next` reaches at most `4*0xFFF` — and an
  unbounded walk runs into the following page's chain and rewrites pointers that were already correct,
  silently.
- **A test whose two outcomes are the same number is not a test.** `Rebase(target, 0, 0) == target`,
  so four of the first chained-fixup tests asserted that a value equalled itself and passed against
  the unfixed code. Reverting each fix and watching the test go red is the only thing that
  establishes a test discriminates — the same "what a pass that never fires looks like" as everywhere
  else in this file, on the test side.
- **A warning routed to Verbose is a warning nobody reads.**
  `AssetRipper.Import/Logging/Logger.cs:16` maps every Cpp2IL and LibCpp2IL warning to
  `LogType.Verbose`, so the Mach-O encryption warning added in iteration 033 never once appeared in a
  log. Anything a reader has to see belongs in AssetRipper's own diagnostics layer, where
  `Logger.Warning` reaches the file. Do not add a diagnostic to LibCpp2IL and assume it is visible.

- **A struct too big to return in registers comes back through a buffer the caller allocates, and the
  reads off it are fields of the returned value.** AAPCS64 passes the address of a stack slot in X8 —
  the indirect result register — and the callee writes there, so every `[X8 + k]` afterwards is an
  unresolved load with an untyped base. The answer is *not* frame arithmetic. The slots the address
  points into are never written under their own names, so there are no SSA versions to choose between
  and nothing typed to land on; what the buffer holds is the call's return value, which the call
  already names as its result operand. `ObscuredDouble::op_Increment` is the whole shape in six
  instructions, and the *store* side of the same instructions names those exact offsets as fields,
  confirming the mapping independently. Worth 121 loads of 211 in that family, and the failure it
  fixes is not a missing load: `GameHelper.SetSizeByWidth` was dividing by zero in native-integer
  arithmetic where the source reads `sprite.bounds.extents.x * 2`. Which register is the buffer comes
  from the callee's own `CallingConventionResolver.HiddenReturnBufferRegister`, never a name written
  down, so the same pass improves x86 with no architecture branch.
- **A family named after a symptom is worth inventorying before it is worth working — a third time,
  and this one had a wrong conclusion already written down.** `reports/FRAME_SLOT_ANALYSIS.md` called
  these 124 loads "X8/X27 pointing into a known stack slot" and concluded that `&stack_-88 + 0x14` is
  exactly `stack_-74`, with "choosing the SSA version" as the only difficulty left. Both premises were
  false and the difficulty did not exist. Counting the same family by the *base register* rather than
  by its shape split it immediately: 121 through X8 (a return buffer) and 89 through X29 (real frame
  spill). Count by the thing that distinguishes the causes, not by the thing that names the symptom.
- **Recovering a value precisely exposes the imprecision at the other end.** Typing the source of
  `this.level = <4 bytes at offset 0>` turned a silent `(ObscuredInt)default(object)` into
  `(ObscuredInt)obscuredInt.currentCryptoKey` — right value, visible mismatch — and ILSpy will not fold
  a constructor's base call in a body carrying a stack type mismatch, so three files grew an
  uncompilable `base._002Ector()`. The defect is on the *destination* side (the machine wrote 4 bytes
  into a 24-byte field, so the destination is `this.level.currentCryptoKey`), and widening the source
  to compensate is distorting one end to hide the other. Report the cost, fix the end that is wrong.

- **An offset landing exactly on a field is not proof the field was accessed; the width is the rest of
  the proof.** `MetadataResolver` had two paths — an exact offset match, which returned at once, and a
  descent into a value type's interior when nothing matched — and only the second ever looked past the
  offset. Four bytes written at the offset of a twelve-byte `Vector3` reached its `x`, and calling that
  a write of the whole vector gives `worldPos = (Vector3)num`, a cast C# does not have that loses y and
  z. The two positions are not symmetric and the asymmetry is the rule: past the start of a field the
  field is not a valid answer at all, so the offset is the whole evidence; *at* the start it is also a
  valid answer, so preferring the member inside needs the width to match that member exactly and the
  offset to name only one field. `NestedFieldResolver` is written over delegates rather than over
  `TypeAnalysisContext` so the search is testable without metadata behind it.
- **`generatorFailures` catches the bug that makes every other number look good.** Moving a
  `continue` inside a new guard let `field == null` fall through to
  `new ConcreteGenericFieldAnalysisContext(null, …)` on the generic path, and 308 bodies threw. The
  unresolved-load count read 2773 → 1615, which looks like the best result in the project's history
  and is 308 methods producing nothing at all. Read that line first, every time.
- **The premise of a task can be wrong even when two iterations and a brief agree on it.** The three
  `mangled_ctor` iteration 036 exposed were diagnosed — here and in that iteration's own notes — as a
  four-byte write into a twenty-four byte `ObscuredInt` field, wanting
  `this.level.currentCryptoKey`. Tracing the decision point says `accessSize=16 size=20`: the write is
  *sixteen* bytes and the struct is *twenty*, whose fields sit at 0x0, 0x4, 0x8, 0xC and 0x10 — so the
  write tiles the first four exactly and the destination is not a nested field at all but a partial,
  exactly-tiling copy. What is left is `IlGenerator.PackedFieldsCovered` one level deeper. And the
  `Expected O, but got I4` is on the *source* side after all, which is iteration 036's offset-zero
  ambiguity — now with the evidence it lacked, namely the width of the store that consumes the load.
  Trace the numbers at the point the decision is made before believing a diagnosis, however well
  attested.
- **One symptom, at least two causes, and the count hides it.** Of the seven `mangled_ctor` on the test
  game, `EventDispatcher..ctor` carries a `base._002Ector()` with **no stack type mismatch anywhere in
  the body** — so "ILSpy will not fold a base call in a body carrying a mismatch" does not explain it,
  and the four pre-existing ones are not the family the new three belong to. Classify before working,
  even a family of seven.

- **Code registration can be found without any string, and that is what makes an encrypted iOS
  binary partly readable.** `FindCodeRegistrationPost2019` starts from the bytes of `mscorlib.dll`,
  so it needs `__cstring`; on an App Store build FairPlay encrypts the whole of `__TEXT` and that
  search reports "No codegen modules found for mscorlib" long after the metadata loaded fine. But
  `Il2CppCodeRegistration` itself lives in `__DATA`, which is *not* encrypted, and it ends in the
  pair `(codeGenModulesCount, addrCodeGenModulePtrs)` whose count is exactly the number of images
  the metadata declares — so a count-constrained scan finds it, confirmed by requiring that many
  pointers all to map. `BinarySearcher` had used this technique for the *metadata* registration
  since forever and never for the code one. Only two of the metadata registration's eight tables
  (`genericMethodTable`, `methodSpecs`) are in the encrypted read-only data; `fieldOffsets`,
  `typeDefinitionsSizes`, `types`, `genericClasses` and `genericInsts` are all in `__DATA`.
- **Every read of data that might be unreadable needs a bound, and failure has to be a message
  rather than an exception in another layer.** Five places in LibCpp2IL took a number out of a table
  and trusted it: `max(adjustorThunk)` of a ciphertext table allocated on a billion
  (`OutOfMemoryException`), a negative generic-method index threw `ArgumentException`,
  `GetCodegenModuleByName` indexed its dictionary and threw `KeyNotFoundException` though its return
  type was already nullable, `GetMethodPointer` indexed `[-1]`, and mapping virtual address 0 threw
  out of key-function discovery. Each one cost *every declaration and every field offset* the
  readable half of the binary would still have given. A method pointer of zero means "the body
  address is not known", which is the honest answer, not a reason to abandon the assembly.
- **DevXUnity-Unpacker, a commercial tool, reaches the same wall and also only warns.** Its Mach-O
  reader handles `LC_ENCRYPTION_INFO` (case 33) and `LC_ENCRYPTION_INFO_64` (case 44) and logs
  "cannot be processed" — it does not decrypt. Independent corroboration that acquiring plaintext is
  not a host-side static-analysis problem; `frida-ios-dump`, `DumpDecrypted` and `bfdecrypt` are all
  device-side acquisition that write back a Mach-O with `cryptid` 0. The architecture therefore
  separates acquisition from parsing: the parser only needs to accept a second input that is not
  store-encrypted.

- **A computed element address over a struct array is not reachable by the fold, and making it
  reachable is not enough.** `ElementSize` knows only the primitives and returns 0 for every struct,
  so `ComputedElementAddress` leaves before it looks at anything; and a struct's stride is rarely a
  power of two, so `Multiply t, i, 12` never matched the `ShiftLeft`-only index check.
  `Vector3ArrayPlugin.EvaluateAndApply` is the whole shape. Fixing both recovers 37 loads and
  introduces seven `(float)array[i]` casts where the baseline had none — because `[t + 0x20]` is the
  address of the element *and* of its first member, which for a struct are different values of
  different widths. This is the offset-zero ambiguity of iterations 036 and 037 one level further
  out, and the missing capability is a `FieldReference` whose base is an `ArrayAccess` rather than a
  `LocalVariable`. `AddressOf(ArrayAccess(…))` already exists, so the nesting is not foreign to the
  IR; only `FieldReference` refuses it.
- **Count the remaining defects by cause, not by the name of the symptom — and the largest cause may
  not be a defect at all.** `ROOT_CAUSE_INVENTORY.md` groups all 2773 unresolved loads: the biggest
  cluster is 651 reads of the *runtime's own* structs (`Il2CppClass`, `Il2CppMethodInfo`, static field
  storage), where the base is correctly typed and there is simply no managed field to name. That is a
  pattern to recognise and drop, not a typing failure, and counting by symptom had it mixed in with
  genuine type-recovery gaps. The next largest, 619, is still unclassified: classify before working.

- **A field reference can name an array element as its base, and that is what cluster B needed.**
  `FieldReference.Local` stays the array and a new `ElementIndex` carries the index, so every pass that
  substitutes the base — copy coalescing, SSA simplification — keeps working unchanged and substitutes
  the array, which is right. Widening `Local` to an `IOperand` instead breaks all of those. Only the
  index is new, and it is walked wherever `ArrayAccess.Index` already is: the local-declaration walk in
  `IlGenerator`, `SsaSimplifier` (both directions), `CopyCoalescer` (both), `EqualityBranchInverter`.
  Missing the declaration walk is not silent for once — it throws `KeyNotFoundException` out of the
  generator — but that is luck, not design. The generator emits `ldelema` for such a base: `ldelem`
  would copy the element and a field written through a copy is written nowhere.
- **The asymmetry from iteration 037 is the rule for array elements too.** Past the start of an element
  the offset itself proves a member was reached, because nothing else lives there, so
  `[t + elementsOffset + f]` is `array[i].<member at f>` with no width needed. *At* the start it proves
  nothing: the element's address and its first member's address are the same number, and for a struct
  those are different values of different widths. Folding that to `array[i]` is what produced
  `(float)changeValue[i]` in iteration 038. Both fold paths — the scaled-index one and the
  elements-offset-added-ahead one — have to exclude a struct element at offset zero, and there are two
  of them, so fixing one leaves the casts in place.

- **A measurement that has never run reads exactly like a measurement that found nothing.** Three
  iterations recorded "Roslyn: NOT RUN" while a perfectly good `csc.dll` sat on the disk:
  `compile_recovered_scripts.sh` searched `${DOTNET_ROOT:-$HOME/.dotnet}`, and in a container where
  the SDK is installed for one user and the harness runs as another, `$HOME` points somewhere with no
  SDK in it. Ask the CLI where its SDKs are (`dotnet --list-sdks`) rather than guessing from an
  environment variable, run `csc -version` to prove what you found starts, and print the status as its
  own line. The real numbers, first measured in iteration 040: **348** errors on Impostor's
  Assembly-CSharp (63 files) and **1600** on Pinata's (1108 files).
- **An error count is a measurement of the recovery only once the errors are known to be the
  recovery's**, and the log alone cannot say. `classify_compile_errors.py` splits them four ways, and
  the discriminator that is not in the log is **member visibility**: C# reports a private member of a
  base type with the same "does not contain a definition" text it uses for a member that is not there,
  and those two want opposite work — a member IL2CPP *stripped* is a defect of what we compile
  against, a private member the export reached is a defect of the export. A string-heap probe cannot
  separate them, because the recovered assemblies are themselves in the reference set and their
  memberrefs carry every name the export names; `invoke_impl` is "present" in six DLLs and declared in
  none of them. The metadata tables carry the flags, so `Test/Tools/MemberVisibility` reads them —
  and it independently reproduced two facts already recorded here: `Math.PI` is ABSENT, `List<T>._size`
  is PRESENT_NONPUBLIC. On the test game all 348 errors are the recovery's; on Pinata exactly one is
  not.
- **A load's cause is not where it was given up on.** Every other column of `CPP2IL_DUMP_LOADS`
  describes the load at the generator, which is the right place to count it and the wrong place to
  explain it — a base typed `object` three copies downstream of an unresolved call says nothing about
  the call. `UnresolvedLoadProvenance` walks the definitions back and names what the walk ends on, and
  the first thing that fell out is that the 301-strong "past the last field of the base type" family
  is **two** causes: 147 genuinely past the last field, and 154 whose base type records no field
  offsets at all, so `largest` is 0 and every positive addend is "past the last field". That is
  metadata that is not there, not a layout failure — the same split `BASE_FIELD_OVERFLOW_ANALYSIS.md`
  had to find by hand for the 850 family, now falling out of the measurement. "value type base" splits
  97/90 the same way.
- **No phi survives to the generator.** SSA is destructed before `IlGenerator` runs, so a pass or a
  measurement placed there will never see one: 0 of 2756 dumped loads reach a phi, and every
  disagreement the provenance walk finds comes from a local with more than one definition after SSA
  destruction. Phi handling written for that point in the pipeline is correct and dead, which is the
  exact shape of "what a pass that never fires looks like" — say so rather than leaving it to be
  discovered again.
- **A test whose subject can be answered by a second rule does not test the first one.** Two of the
  eight Roslyn bootstrap cases passed against the very bug they were written for: case A found a
  compiler through the NuGet fallback tier after the SDK tier failed, and a classifier case asked about
  a type the export declares, which an earlier rule answers whatever the rule under test does. Shut off
  every other route before believing a green case — and case F is the general form of it, since "no
  errors were printed" is also what an absent compiler produces, so it has to assert the assembly was
  built. With the original bug restored, 5 of 6 go red.

- **A field of a generic instance has no `BackingData` at all, so every `BackingData.FieldOffset`
  comparison is silently false on one.** `ConcreteGenericFieldAnalysisContext` is
  `base(null, genericInstanceType)`, which CLAUDE.md already recorded — what was missed is what that
  means for *anything that searches by offset*: no offset above zero can ever match such a type, and
  offset zero would match every one of its fields. `MetadataResolver`'s base-chain walk did exactly
  that, so a field inherited from a generic base class could never be resolved, and
  `TimeCheatingDetector : ACTkDetectorBase<TimeCheatingDetector>` — the ordinary shape of a
  self-referencing singleton base — lost `started` and `isRunning` entirely: `if ((nint)0 != 0)`,
  always false, the whole guard dead code. The offsets are in `GenericInstanceFieldLayout`, which the
  same method already consults when the *owner* is a generic instance and never when it merely
  inherits from one. Worth 34 loads and 25 dead branches on the test game, and 121 Roslyn errors on
  Pinata.
- **A computed layout covers the link's whole base chain, so the field it returns may belong to an
  ancestor.** Instantiating it on the link that answered then declares the field on a type that does
  not declare it: PlayMaker's `ComponentAction<T> : FsmStateAction` places `FsmStateAction.fsm`, and
  attributing that to `ComponentAction<InputField>` was 186 new errors on Pinata — with **nothing at
  all** visible on the ARM64 game. A link answers only for what it declares itself; the rest is left
  to the link that does, which the walk reaches immediately afterwards and where the field is already
  closed. The other half of the same rule is older and was rediscovered here: a field taken from a
  computed layout is declared by the open *definition*, so naming it gives a cast to `Foo<>`, which is
  not a type C# can spell — the code already guarded that for the owner case (`open type is bad`) and
  the guard has to extend to an ancestor.
- **A parse error hides a whole file, which is the declaration-error trap one stage earlier.** ACTk's
  Roslyn count read 4 errors before and after a change that introduced 40 uncompilable casts, because
  a pre-existing CS1525 stops the compiler before it binds anything in that file. When a change could
  introduce a bad *shape*, count the shape across the whole rip; an assembly's error count only
  measures the files that parse.
- **Counting fields by `BackingData.FieldOffset` answers a different question from the one the name
  suggests**, and iteration 040's provenance labels were wrong in three ways because of it. "Declares
  no field offsets" conflated a bare type parameter (no static layout to be missing — 111 of 165), a
  type with no instance fields at all (`System.Object`, `System.Array`, a pointer: a complete layout
  that happens to be empty), and a genuine gap. "Offset within the layout and on no field" asserted
  "on no field" without ever looking. And `PAST_LAST_FIELD` inherited the same error, since a type
  that merely inherits from a generic instance read as having no layout, making every positive addend
  "past the last field". Measuring from the computed layout instead moved 194 loads out of
  MISSING_METADATA and exposed a new group worth reading: **`RESOLVABLE`, 48 loads where a field sits
  at exactly the offset asked for and the generator still gave up** — which is how the generic-base
  defect above was found.

- **The coordinate an offset is measured from belongs to the base pointer, not to the type.** A class's
  recorded offsets already include the 0x10 header, so nothing is to be decided there. A value type
  appears in *both* frames: reached as `this` of the struct's own instance method, il2cpp hands a
  pointer to the boxed object's header, so a field at metadata offset 0 is read at `[this + 0x10]`;
  the same struct in static storage, in a stack slot, or as a field of another object is read at its
  own offset. `CoordinateEvidence` on `CPP2IL_DUMP_LOADS` tries both readings per load and says which
  lands on a field. Il2CppDumper states the static half outright and independently -
  `struct T_o { T_c *klass; void *monitor; T_Fields fields; }` with the two pointers emitted only
  when the type is not a value type.
- **`measure-bodies.py` from `clericall/il2cpp-wasm-teardown` is an outside oracle this project had
  no equivalent of.** Every existing measure counts placeholders, Roslyn errors or diagnostics; none
  answers "how many methods have a real body". It classifies each method empty / trivial stub / real,
  and deliberately counts `throw null;` as a stub because that is Cpp2IL's own placeholder - "a fully
  stubbed assembly otherwise scores 100% live". Its author measures **0.00%** on an ordinary IL2CPP
  export; on this project's rip it measures **96.06%** for Assembly-CSharp and 62.97% across all 819
  files. Worth re-running after any change that could stub bodies.

- **`GenericInstanceFieldLayout` lays every type out from the object, a struct included, so what it
  returns is a boxed offset.** Measured for the first time in iteration 043, because `SelfCheck` skips
  `IsValueType` *and* every field recorded at offset 0 and so had never had anything to say about a
  struct: of 598 and 458 non-generic structs on the two games, **547 and 435 reproduce at
  `metadata + header` and none at the metadata offset itself**. The walk is right about order and
  alignment; it is simply in the other frame. The 11 and 5 that reproduce in neither are
  `[StructLayout(LayoutKind.Explicit)]` unions - `System.Decimal.ulomidLE` overlaps `lo` and `mid` at
  metadata 8 - which a sequential walk cannot express and should not try to.
- **Two frames meeting in one expression is how a header gets added twice.**
  `IlGenerator.OffsetOfInstanceField` took its offset from the computed layout for a generic owner and
  from the metadata for everything else, then `AccessorOffset` added the header to both - so a generic
  value type got it twice and the accessor pairing could not match anything. `FieldOffsetFrame` names
  the two frames and its two conversions are inverses, so the same mistake cannot compose again. The
  header is **two pointers**, not sixteen. Worth nothing measurable today (2 fields on one game, 5 on
  the other, none of which paired before either) - kept because that branch *is* reached, 60 and 128
  times, and is wrong where it is reached.
- **A counter the generator increments has to be read where the generator reports.**
  `Il2CppRecoveryDiagnosticsProcessingLayer` runs *before* bodies are generated, so an `IlGenerator`
  counter printed from there is always 0. That read as "the whole instance accessor pairing is dead
  code" and was one sentence away from being written down as a finding; moving the line to
  `Il2CppIlRecoveryOutputFormat`, where the recovery counters are logged, turned 0 into 2538.

- **A stand-in that compiles looks exactly like success.** `DummyShaderTextExporter` is not empty: it
  reconstructs a shader's `Properties` exactly - names, types, defaults, `[Toggle]`,
  `[HideInInspector]`, even `//CustomEditor` - and then gives **every** shader the same replacement
  unlit pass (`mul(VP, mul(ObjectToWorld, pos))`, sample `_MainTex`). That compiles, so the material
  is not pink, so any check that looks for pink materials reports success while the shading is wrong.
  `ShaderExportMode.Decompile` is not in this repository at all - the dispatch has two branches and
  `Decompile` falls through to Dummy; the GUI gates it behind `GameFileLoader.Premium`.
  `--shader-mode Yaml` does preserve the compiled programs: 12 `m_SubPrograms`, 31 blobs and 18
  `GpuProgramType` entries on one shader.
- **Read the backend before planning shader work.** The test game's shaders carry `GpuProgramType` 4
  and 5 only, which this repo's own `ShaderGpuProgramType55` names `GLES3` and `GLES`: there is not
  one DXBC, SPIR-V or Metal program in it, so HLSLcc and SPIR-V work would apply to zero programs
  and needs a different fixture. The blobs are compressed, so "GLES means GLSL text" is **not**
  confirmed and must not be recorded as if it were.
- **Where the base pointer came from is what the offset frame follows, and the two now cross-tab
  cleanly.** `BasePointerOrigin` reports only what the IR states - a local flagged as the receiver, a
  register the stack analyser named after a frame offset, a type that is static field storage - and
  against the coordinate evidence it separates with no exceptions: static field storage reads
  **value-relative 43/43**, while receiver, parameter, call result and instance field read
  **object-relative 25/25**. That matches il2cpp's physics, and it is still **not** a licence to
  patch: the dump records only loads that were *given up on*, so those 68 are a sample of the
  failures, not of the program. Measure it over resolved loads before acting on it.

- **A rule read off the failures alone is read off a biased sample, and the resolved half can invert
  it.** `IlGenerator.ResolvedMemoryLoad` fires at the `FieldReference` case of `LoadOperand`, the
  exact mirror of the one place a memory operand is given up on, so the two dumps are the same
  measurement over the same pipeline stage: 16677 resolved against 2722 not. Iteration 044's
  coordinate-frame finding - receiver and parameter reads of a value type are object-relative, 25 of
  25 - is **false**: over the resolved population those same origins read **value-relative 1761 times
  and object-relative never**. `OBJECT_RELATIVE` is a signature of failure, not a frame rule, and a
  blanket header by origin would have corrupted 1761 correct resolutions to recover 24. Always
  measure the shape over the successes before believing a pattern in the failures.
- **Ask the pass, at the point the load is counted, whether it would answer.** Two very different
  failures reach the generator as the same placeholder - a search that ran and found nothing, and an
  operand the search never looked at - and no column describing the load distinguishes them.
  `SearchFieldAtOffset` runs `ResolveFieldOffsets`' own search from the dump: 1417 `SEARCH_EMPTY`,
  1241 `NO_OWNER`, 61 `NOT_A_FIELD_ACCESS`, **3** `SEARCH_ANSWERS`. That closes the `RESOLVABLE` 48
  family of iterations 040 and 044: measured against metadata rather than against the computed
  layout it is 3, because `GenericInstanceFieldLayout` is in the boxed frame and "a field sits at
  exactly that offset" was the same fact counted twice, not independent evidence. The field search
  is not the bottleneck. And a probe that mirrors a pass must mirror its guards too - without
  `Index is null && Scale == 0` it reported 37, of which 34 were indexed operands "resolving" to
  whatever sits at offset zero.
- **`ISILControlFlowGraph.Instructions` is a breadth-first walk from the entry block**, so it omits
  any block nothing reaches, while code generation emits every block in `Blocks` - `IlGenerator`
  says so in a comment and iterates `Blocks` itself. Twelve analysis files use the walk.
  `AllInstructions` is the one that matches what is emitted; pointing `ResolveFieldOffsets` at it
  changed **nothing** (2722 to 2722), and it is kept for the alignment rather than for a number.
- **An error code's count is not a family's count, and `grep -m1` invites the confusion.** The
  compile summary printed one example per code taken as the *first* in the log; beside a count of
  1125 that reads as 1125 of that message, and a whole iteration was briefed on exactly that
  misreading (`Cannot convert type 'int' to 'TCP2_PlanarReflection'` occurs **once**). It now prints
  the most common message with its share ("14 of 128"). Classified by the *shape of the operand being
  cast*, read from the source, Pinata's 1125 CS0030 are 60% a local used where another type is wanted
  (229 distinct type pairs, the largest 48), 22% `((Fsm)0)` - the stand-in an unresolved load pushes,
  so a recount of the loads under another name - and the rest known families. There is nothing there
  to fix as one thing.
- **A check that is too strict is as wrong as one that is too lax, and costs more time.**
  `validate_unity_project.py` reported FAIL three times on a project with no defect, each time for
  reading *absent* as *broken*: 369 scripts with no `.cs.meta` (a plain class needs no GUID); two
  `MonoBehaviour`s with none (only ever `AddComponent`ed, so never a MonoScript); 24 reference sites
  to `0000000000000000f000000000000000` and `...e000000000000000` (Unity's own built-in resources,
  which no project declares). What a project validator owes is a verdict it can defend - `UNKNOWN`
  where an editor would be needed to decide, never `FAIL` to look thorough.
- **Counting broken references by one of their shapes misses the other.** "4 `m_Script` at
  `fileID: 0`", recorded in the 044 matrix, was a grep for one string; there are **six**, the other
  two being GUIDs no `.cs.meta` declares. At import both lose the component and every field on it.
  `Test/Scripts/audit_script_references.py` reports each with source, target, reason, candidate and
  an evidence rank - GameObject name, then document name, then *counter*-evidence: a script already
  attached to that GameObject means the component that wanted it is right there, so this is a
  different one. It never applies a repair.

- **"No idea" is a family name too, and it split five ways.** 809 of 2722 loads had an `UNKNOWN`
  base-pointer origin, which read as one problem and was five: 343 an `Add` the walk had no rule
  for, 211 a local with more than one definition, 139 a `Move` of an `AddressOf`, 69 a base that is
  not a local, 47 across seven other opcodes. Four had exact answers. `AddressOf(local)` points into
  that local's storage, so the walk continues there - the same reasoning `OffsetFromLocal` already
  rests on, and worth 98 loads reclassified as the X29 frame spills they are. An operand that names
  storage in a `Move` names it in an `Add` too, so `FieldReference`, `MemoryOperand` and
  `ArrayAccess` answer there as well; between two registers the *type* decides, because an integer
  added to a pointer is a pointer and two pointers are never added - but only where the side is
  typed, so 27 `untyped + integer` stay unknown rather than become a guess. And several definitions
  is not disagreement: where every branch of a merge reaches the same storage that is the answer.
  809 to 396, with the rip unchanged to the byte.
- **Each branch of a merge needs its own visited set.** Two definitions passing through one local is
  convergence, not a cycle; sharing the set reports the second branch as a cycle and loses an origin
  both branches agree on. There is a test for exactly this and it is the only thing that catches it -
  the merge rule alone passes its own tests with the sets shared.
- **The runtime's own structures can be named, and that is the third option between counting them as
  failures and dropping them.** 651 loads - the largest group - read `Il2CppClass` or `MethodInfo`
  with a correctly typed base and no managed field at the offset, ever. `Il2CppClassUsefulOffsets` is
  the curated list of offsets the *passes key on* and must stay that way, since an entry there
  changes what the analysis does; the struct database carries the whole layout, so
  `Il2CppClassOffsetPatcher.MemberNames` builds a separate naming table - 651 of 651 named, no
  `<unnamed>` left. Three groups independently confirm what this file already recorded by other
  routes (61 `stack_slot_size` are iteration 033's shared-generic alloca sequence; `cctor_finished`
  and `initialized_and_no_error` are surviving class-init guards; `typeHierarchyDepth` is 18 as
  recorded). **The two largest had never been read at all: 103 `byval_arg.attrs` and 61
  `stack_slot_size`, and each is almost certainly one unrecognised shape rather than 164 separate
  defects.** A member claims every byte it covers, because a load is at the offset it is at; a
  bitfield says so in its name, because several share one byte.
- **The count of unresolved loads mixes three populations that want opposite work.**
  `recovery_report.py` splits Impostor's 2722: 901 `MANAGED_FIELD` (a real recovery defect), 651
  `RUNTIME_STRUCT` (correctly recovered as what it is), 343 `NATIVE_TEMPORARY`, 66 `ARRAY_ACCESS`,
  761 `UNKNOWN` - with 997 EXACT, 964 INFERRED and 761 NONE confidence, never added together. The
  goal is to drive `UNKNOWN` down, not the total to zero.

- **A bitfield storage unit names a group; the bit names the member, and the bit is in the consumer.**
  Iteration 046 reported 103 loads as `Il2CppClass.byval_arg.attrs` - the first member to claim the
  byte - and that label is **wrong**. Recording what consumes each load says 100 are
  `CheckLess value, 0` (a sign test) and 3 are `And value, 0x80000000`: all of them bit 31, which the
  struct database places as `byval_arg.valuetype`. So they are the value-type test shared generic code
  performs on its own type parameter, and every base is `Il2CppClass<T>` - an *open* parameter, so
  there is no static answer and `RUNTIME_STRUCT` is the right verdict, now with evidence instead of a
  guess. `MethodInfo.is_generic` corrects to `is_inflated` the same way. And 43 of 61
  `stack_slot_size` reads are consumed by `Add value, 0xf` - exactly the round-up of the alloca
  sequence this file described from iteration 033, confirmed instruction for instruction by an
  independent route.
- **Every aggregate hides the distribution, and the distribution is the work list.**
  `method_recovery_report.py` scores each method from its own `[Address(RVA, Length)]` and its body:
  Impostor's 5482 recovered methods are 70.5% clean, 25.1% partial, and the partial quarter carries
  **all** 5130 placeholders, the worst single method holding 113. Pinata's 16365 are 77.9% clean.
  That is the first measure in the project ordered by method rather than by assembly.
- **"A method that compiles but was replaced by an empty body is not recovered" is now measurable, and
  it almost never happens.** 0 lost bodies on Impostor, exactly 2 on Pinata
  (`YandexAppMetricaReceipt`, `YandexAppMetricaConfig`, 76 bytes each). Before this there was no
  number at all for it.
- **Four measurements reported themselves wrong in one iteration, and all four had to be fixed before
  any of them could be believed.** Matching the consuming instruction *by reference* found nothing for
  all 2722 loads - the operand the generator hands the event is not the object still in the graph, so
  match by text. `[NativeSource(Body = "...")]` carries braces **inside a string**, so brace counting
  closed a method body before it opened and reported 366 methods as having lost their body when every
  one had one. Only a few assemblies are recovered and the rest are stubbed **by design**, so scoring
  those as lost bodies invented 322 more - read the log's "Attempted:" line rather than guessing, and
  say `SCOPE: UNKNOWN` when there is no log. And adding one column to the dump shifted `memory` from
  index 21 to 22, which `recovery_report.py` still read as 21 - caught only because the baseline was
  re-measured and compared, never by looking at the code.

- **A placeholder family is an emission site, not a string.** The printed text carries the operand, so
  every `Unmanaged memory load: [v24 @ X29_v1-58]` is its own string and a tally of the text reports
  thousands of singletons and no family at all. `placeholder_families.py` attributes each placeholder
  to the one `instructions.Add(CilOpCodes.Ldstr, …)` in `IlGenerator` that produced it, with the ISIL
  operation that reached it and — where the text carries it — the native opcode underneath. Impostor's
  5853: `UNMANAGED_MEMORY_LOAD` 2651, `METHOD_NOT_FOUND` 1573, `NATIVE_IMPORT` 485, `INDIRECT_CALL`
  350, `NOT_IMPLEMENTED_INSTRUCTION` 303, `INDIRECT_JUMP` 254, `UNRESOLVED_DELEGATE` 128,
  `UNKNOWN_CALL_TARGET` 107. The first three want opposite work — type recovery, call resolution and a
  metadata limitation that no amount of work removes — which one total hides.
- **A restated list of what counts drifts from the list that is printed, and the drift is silent.**
  `method_recovery_report.py` carried a hand-copy of the family names: it spelled `"Unresolved
  delegate"`, a string the generator **never prints** (the real one is `Delegate over an unresolved
  function pointer`), and omitted `Indirect call` and `Indirect jump` outright. 732 placeholders
  invisible, and every method whose only defect was one of those scored `RECOVERED_CLEAN` — 205 of
  them. The list is now defined once, in `placeholder_families.MESSAGE_PREFIXES`, and imported. Any
  comparison against an iteration at or before 047 has to re-measure **both** ends with it: the
  published Impostor figure of 4107 clean methods is really 3902.
- **`diff -rq --include='*.cs' A B` is not a GNU diff option.** It errors out, and with stderr
  discarded that reads as "no files differ" — which is how three iterations reported an unchanged rip
  without ever comparing one. Rebuilding `4dec5263` in a worktree and comparing properly said the
  claims were true and the evidence was not. `Test/Scripts/diff_recovered_scripts.sh` is the real one.
- **An unimplemented opcode names itself, and some of them need no inference at all.** `BFI` and
  `BFXIL` were 92 of Impostor's 303 `NOT_IMPLEMENTED_INSTRUCTION`, and a bitfield *move* is exactly
  `UBFIZ`/`UBFX` plus a read of the destination — the bits the field does not cover stay. Disarm hands
  back the alias's own operands (`BFI W8, W9, 0x4, 0x8` is lsb 4, width 8), so there is no `BFM`
  immr/imms to undo. The part that is easy to get wrong is **width, twice**: `~placed` has to be cut to
  the register's width or the destination's whole high half arrives as ones, and the mask has to be
  *written* at that width or the generator pushes an I8 into an I4 destination (75 stack type
  mismatches, 31 of them recovered by writing it signed). Worth 29 methods and 88 placeholders. What is
  left of the family is not the same kind of work: `FABD` (48) and `DUP` (43) are vector forms, and
  lifting them as scalar would be wrong silently. And the whole family is **16** on the other fixture —
  it is distributed by the instruction selection the compiler used for that build, not by the program.
- **A recovered value can be lost without a placeholder saying so.** `ObscuredUShort.op_Implicit` came
  back as `result = (flag ? ((ObscuredUShort)4294967296L) : ((ObscuredUShort)4294967296L))` — two
  identical branches, so the value was gone — beside three `BFI`/`BFXIL` placeholders that named an
  instruction rather than the loss. Nineteen files changed by that one lift, every one of them somewhere
  a bitfield move belongs (ACTk's `Obscured*` pack a key and a value into a word, `xxHash`,
  `MeshGenerator`, `SkeletonBinary`), which is what a rule matching the shape it aimed at looks like.

- **"No placeholder" is not recovery, and the evidence to say so is already in the export.**
  `[NativeSource(Body = "...")]` renders the *analysed ISIL*, not the machine code, so the operations
  it names are the operations the analysis recovered; comparing those operation classes against the
  ones the C# body names separates a real body from a stand-in. `recovery_metrics.py` scores
  `EXACT` / `HIGH_CONFIDENCE` / `PARTIAL` / `FALLBACK` / `MISSING` on that, and of iteration 048's
  3942 "methods with no placeholder" on the test game, **1203 are stand-ins**. Any comparison against
  an iteration at or before 048 has to re-measure both ends with it.
- **That measure reported itself wrong twice before it could be believed, both times by being too
  strict.** A call is written differently on the two sides - the IR rendering writes `Type::Method(`,
  `"helper"(` or `0xADDR(` and C# writes `receiver.Method(` - so one pattern for both matched nothing
  at all on the C# side and the deficit was the whole IR side: 2304 methods reported as having lost
  their calls, against a true 54. And field access has to be compared by **member name**, not by the
  shape of the access, because C# writes `this.field` as bare `field`: 1655 false losses against a
  true 662. A check that is too strict is as wrong as one that is too lax.
- **The two metadata-init variants are siblings, not parent and child.**
  `il2cpp_codegen_initialize_runtime_metadata` is a stub that *calls* the real function and then
  issues the memory barrier; `..._inline` tail-jumps to that same function without it. So
  `FindAllThunkFunctions(the barrier one)` - looking for a function that jumps *to* the barrier stub -
  can never find it, and the comment on the field had described the real shape all along. On the test
  game the two sit twenty bytes apart in one veneer table (`0xAD9498` / `0xAD94AC`) and the unfound
  one was the busiest unresolved call target in the binary: **889 calls from 268 methods, 40% of every
  `Method not found` placeholder**. The consuming code already existed; the whole gap was finding the
  address. Worth `METHOD_NOT_FOUND` 1573 → 713, and 92 fewer `NOT_IMPLEMENTED_INSTRUCTION` as a
  side-effect, because dropping scaffolding takes dead code with it.
- **Report which runtime helpers were located and which were not.** A call to a helper that was not
  found becomes a placeholder naming an address rather than a cause, so "is this one we failed to
  find, or one this build does not have" was never answerable from a log. `ReportKeyFunctions` prints
  both halves, and that one line is what found the sibling bug above. Still unlocated on the test
  game: `il2cpp_codegen_raise_exception`, `il2cpp_codegen_write_barrier`,
  `il2cpp_codegen_initialize_method` - try the sibling-veneer search on those first.
- **An unresolved call's reason is not its symptom, and the reason is readable where it is counted.**
  How many managed methods sit on the address, plus the first four instructions there, separate
  `RUNTIME_HELPER` (718), `NATIVE_ONLY` (512 - a PLT entry into another shared library, which no
  managed metadata will ever name and which is therefore not a defect), `INDIRECT_TARGET` (103),
  `RUNTIME_HELPER_VENEER` (78) and `GENERIC_SHARED` (33). A third of the family is an external
  dependency, and counting it as a decompiler failure had hidden that.
- **`INDIRECT_CALL` splits cleanly on the text it already prints**: `X.invoke_impl` is a delegate
  invoke, `[base + offset]` is a vtable slot. 117 and 233 on the test game. `DelegateInvokeRecovery`
  already handled the first and never fired, because it matched a raw `MemoryOperand` with addend 24
  while running *after* the resolution that turns that operand into a `FieldReference` literally named
  `invoke_impl` - the same "a pass that matches a shape must be written against the shape at the point
  it runs" as everywhere else in this file. The other half was **generic delegates**: a generic
  instance context carries its arguments and its definition and declares no members of its own, so
  asking it for `Invoke`, or even whether it is a delegate, answers nothing - and most delegates are
  generic (`DOGetter<Vector2>`, `Predicate<T>`, `Action<T>`). Both together took 350 to exactly 233,
  which is the vtable count measured independently.
- **`0xAF4130` on the test game is `Interlocked.CompareExchange` and is deliberately not mapped.**
  339 calls, **339 of 339 callers are `add_`/`remove_` event accessors**, and the machine code is
  `ldaxr x8,[x0] / cmp x8,x2 / stlxr w9,x1,[x0]` - a compare-and-swap loop whose argument order is
  exactly `(ref location, value, comparand)`. The semantics are certain; the *discovery rule* is not,
  because no managed method sits there and every thunk chain from
  `System.Threading.Interlocked::CompareExchange` ends at `0xAF41A4`, `0xAF41CC` or `0xAF4164`
  instead. A wrong mapping would silently corrupt 339 event accessors, so this is recorded as evidence
  rather than patched. Do not map it without a general way to find it.
- **Almost every ARM64 opcode the lifter still has no rule for is a vector form.** After BFI/BFXIL:
  `FABD` 48, `DUP` 44, `USHL` 9, `BIT`/`BSL`/`BIF` 10, `FADDP`/`FCMGT`/`EXT`/`CMHS`/`ZIP1` 9 - against
  `REV` 2 and `SMULH` 1, the only scalars left, three placeholders between them. Lifting a vector form
  as scalar is wrong silently, so this needs a SIMD semantic layer (lane count, lane type, vector
  width) before any of it is worth touching. `Test/Scripts/instruction_coverage.py` reports it, and
  reads the implemented set out of the lifter's own switch rather than guessing - an opcode that *has*
  a case and still reports unimplemented is a different defect. The largest entry, `UNIMPLEMENTED` 94,
  is Disarm failing to decode at all: a disassembler gap, not a lifter one.

- **`INDIRECT_JUMP` splits the same way `INDIRECT_CALL` does, and the largest family is not a jump
  table.** `IndirectJumpClassifier` runs last in `Analyze`, so it sees exactly what the generator
  will, and it rewrites nothing: 288 `DELEGATE_INVOKE`, 135 `VTABLE_SLOT`, 60 `DEFINED_BY_Add` - the
  *only* candidates for a switch table - and 30 `LOADED_POINTER` on the test game. So the answer to
  "classify the indirect jumps" is that most of them are a delegate tail-invoke, which the pass one
  commit earlier already knew how to resolve; extending it to `IndirectJump` took 254 to 120. **The
  return has to be written out**: the generator bridges a block that does not end in a jump or a
  return to its successor, and an indirect jump's block has none, so leaving it implicit gives a block
  with no terminator at all. And the other fixture has **zero** `DELEGATE_INVOKE` among 1591 jumps
  (780 vtable, 444 loaded pointer, 352 computed) - this family is distributed by the compiler's
  instruction selection for that build, exactly like `NOT_IMPLEMENTED_INSTRUCTION`.
- **A counter that does not say what it covers cannot be compared with anything.** The jump
  classifier's first number was 515 against 254 placeholders in the export, and the gap is not a bug:
  analysis runs over 11903 method bodies including the assemblies that are then stubbed, while the
  export counts 5482. Reporting "N jumps across M analysed bodies" is the difference between a number
  and a number someone can use.
- **A golden corpus chosen worst-first can only ever report improvement.** Selecting the hardest
  method per operation class gave 39 methods that were all `FALLBACK`, and the regression actually
  worth catching is an `EXACT` method falling out of `EXACT`. `Test/golden-corpus.json` takes one
  method per *(operation class, status)* instead - 48 methods, 11/11/13/13 across the four statuses -
  and it discriminates: run against the 048 rip it names the 3 methods 049 lifted and the 2 it pushed
  from `PARTIAL` to `FALLBACK`, which is the "removing a placeholder reveals what is still missing"
  effect visible per method rather than only in a total.
- **Enriching a fingerprint means saying which classes count as loss, not adding them all to the
  test.** Sixteen operation classes are reported per side; six count as behaviour lost when absent.
  Every exclusion has a reason that has to be statable: a void method has no `RETURN` in the IR
  rendering, a comparison folded into an `if` is still the comparison, constant folding legitimately
  removes `ARITHMETIC`, a decompiler drops a `CAST` the type system no longer needs, il2cpp's
  `NULL_CHECK`s are removed *on purpose*, and `LOOP`/`SWITCH` are legitimately written as the `goto`
  that `BRANCH` already covers. The per-side table is explicitly **not** a loss measurement - the two
  renderings spell the same operation differently often enough that only the per-method check carries
  that meaning.

- **The "233 unresolved vtable call sites" were not vtable reads, and asking the pass is what says
  so.** `MetadataResolver.ResolveVTableSlot` is public so a probe runs the resolver's own arithmetic
  and its own lookup rather than restating them - a probe that restates a pass drifts from it, which
  this project has paid for twice. Of 468 indirect calls surviving at the end of `Analyze`: 236
  `LOADED_POINTER`, 126 through `MethodInfo.invoker_method`, 56 through `MethodInfo.methodPointer`,
  **34 genuine vtable slots**, 16 other - and **zero** with an untyped base, zero with a misaligned
  offset, zero the resolver would have answered. So the real vtable population is 34, all of them
  "the slot lookup found nothing", which is metadata work and not type recovery.
- **`MethodInfo` carries three function pointers at three offsets and only one of them is a direct
  call.** The struct database places `methodPointer` at 0x00, `virtualMethodPointer` at 0x08,
  `invoker_method` at 0x10 and `klass` at 0x20. A call through `methodPointer` where the MethodInfo
  is a resolved metadata usage **is** a direct call to the method that usage names -
  `ResolveMethodInfoPointerCalls` runs in the same fixpoint as `ResolveVirtualCalls`, because that is
  what types the base. A call through `invoker_method` is **not**: that is the runtime's
  reflection-style invoker, taking the pointer, the MethodInfo, a receiver and a boxed argument
  array. Treating the two alike would be wrong in the quiet way. Read the offsets from the table;
  writing one down has been the same bug three times.
- **A delegate's function pointer is nameable, and the comment saying otherwise was half right.**
  C# genuinely cannot write the two-argument constructor - but il2cpp passes the target's
  `MethodInfo*` alongside the raw pointer, the analysis types that operand as a
  `RuntimeMethodInfoAnalysisContext`, and that context carries the method. So it is
  `ldftn <method>; newobj Delegate::.ctor(object, native int)`, exactly what C# compiles a method
  group to and what a decompiler reads back as one. A **zero** where the receiver goes is a delegate
  over a *static* method and has to become `ldnull`, or the delegate closes over address zero.
  `UNRESOLVED_DELEGATE` 128 → 0 on one fixture and 433 → 122 on the other, and
  `SkeletonUtility.OnEnable` came back as `skeletonAnimation.UpdateLocal -= UpdateLocal;` where it
  had been a placeholder and a null.
- **27 of 30 runtime helpers cannot be named from their call sites, and that is the finding.** 796
  unresolved calls reach exactly 30 addresses; **none of the 30 is named by the binary's export
  table**; and only 3 have call sites uniformly one kind of member with at least ten calls. So the
  rest need machine code read, and `runtime_helper_report.py` ranks them by call sites with the
  caller profile that decides - a helper every one of whose callers is an event accessor is a
  different kind of fact from one called from sixty-nine unrelated methods.
- **A metric read while the export is still writing is not a metric.** A watch that fired on the
  recovery summary line reported 280 `.cs` files and 1845 methods against 819 and 5482 - a
  catastrophic-looking regression that was a mid-export snapshot. The per-assembly counts were
  identical the moment the run finished. Wait for the process, not for a line in its log.

- **An interface call il2cpp compiled as a runtime lookup is still an interface call, and the lookup's
  own arguments are the whole answer.** Where the receiver's class is known at compile time the
  compiler emits the interface offset and slot inline, which `InterfaceDispatchRecovery` matches;
  where it is not — shared generic code, or a receiver typed as the interface — it calls a helper with
  `(receiver, Il2CppClass* of the interface, slot)` and calls through the `VirtualInvokeData` it hands
  back. The helper is not exported and no managed method sits there, so the whole dispatch reaches the
  generator as one indirect call: the largest `LOADED_POINTER` group on the test game. The slot is the
  index of the method *within the interface* — `vtable[interfaceOffset + slot]`, the offset from the
  receiver's class at run time and the slot from the interface — so the answer is exactly
  `interface.Methods[slot]`, which is what the C# source named. `ExposedList<T>.AddCollection` comes
  back as `collection.Count` and `collection.CopyTo`, `ICollection<T>` slots 0 and 5. Nothing needs the
  helper's address and nothing may use one.
- **A `Call`'s operand 0 is its target and operand 1 its return value, so its arguments begin at 2.**
  Reading them from 1 is off by one at every site and matches nothing at all, which is indistinguishable
  from a pass that never fires.
- **A pointer is almost never used where it was made, so a pass that reads only the operand in front of
  it matches nothing.** All 592 interface dispatches were at least one `Move` or one `Phi` from the call
  that produced their pointer. `PointerProvenance` is that backward walk, kept in one place and testable
  without metadata: a merge answers only when every branch reaches the same producer, a revisit
  contributes nothing rather than recursing.
- **A helper with an inline fast path must be matched forwards, from the lookup to the dispatch.** The
  pointer the dispatch reads is a phi of the helper's result and an address the compiler computed
  itself, and a backward walk correctly refuses to pick one input of a merge. Forwards asks a question
  with one answer — what does this lookup's result reach — and both branches of that merge are the same
  dispatch, which is why the fast path exists. `InterfaceInvokeDataRecovery` runs twice for the same
  reason placements keep needing to be doubled here: inside SSA the phi is explicit, and out of SSA the
  load has been folded into the dispatch and a slot that was a register has become a constant. Neither
  placement sees what the other does; one alone gets 16 of 48.
- **`MethodInfo` carries three function pointers and 2022 moved two of them.** `methodPointer` is 0 in
  every layout; `virtualMethodPointer` was *inserted* as the second field in 2022, so `invoker_method`
  is at one pointer before it and two after, and `klass` moves with it (0x18 → 0x20). They mean three
  different things — a direct call, a dispatch that needs the receiver, and the runtime's
  reflection-style trampoline that names no managed target at all — so a label keyed on a raw offset,
  like the old `METHODINFO_POINTER_AT_0x10`, reads as a different family on the next build. Measured
  from the struct database, with no fallback entry: a layout that is not known answers "not known".
- **A compare-and-swap can be named by its instructions, and that is the discovery rule iteration 050
  lacked.** A64 has exactly one way to write one before LSE — an exclusive load, a comparison, an
  exclusive store to the *same* address — and the encodings are unambiguous. The width and ordering
  bits must stay outside the mask: of the test game's four compare-and-swap entry points one is the
  32-bit form and one uses plain `LDXR`. Three of the four are reachable from
  `Interlocked::CompareExchange` through thunks and confirm what the family is; the fourth, `0xAF4130`
  with its 339 event-accessor callers, is only reachable this way. `AtomicIntrinsicRecognizer` reports
  and does not rewrite: a wrong mapping corrupts 339 accessors silently, and choosing the overload
  (`ref object` / `ref int` / generic) is a second decision the evidence does not settle.
- **`LOADED_POINTER` is a symptom and it splits five ways.** On the test game: 124 produced by an
  unresolved call — a runtime boundary, not a type-recovery failure — 38 a register's entry value, 22
  producers that disagree, 2 a `MethodInfo`'s own entry point. Two thirds of what is left is not
  somewhere to add typing rules. Pinata's distribution is nothing like it (769 disagreeing, 61 delegate,
  24 array, 18 stack), the same way every family here is distributed by the compiler's instruction
  selection rather than by the program.
- **The golden corpus was measuring nothing, three times, and printing `improved 0, regressed 0`.** Its
  keys are relative to the *game directory inside* the rip, so `Test/Output051b` matches 0 of 61 while
  `Test/Output051b/Impostor` matches 61 of 61 — and nothing said so. It now answers
  `CORPUS_NOT_APPLICABLE` with a non-zero exit. The union-on-reselection rule recorded in this file was
  also never in the code: `--select` ignored `--corpus` and overwrote the file, so a reselection would
  have replaced all 61 frozen entries with 165 new ones. Both fixed; the corpus is 165 now, with the
  original 61 a subset.
- **A measurement must refuse a rip that is still being written.** Iteration 050's watch fired on a log
  line rather than on the process and reported 280 `.cs` files against 819 and 1845 methods against
  5482 — the worst-looking regression in the project's history, and a snapshot of a directory being
  filled in. No count can separate "this rip is small" from "this rip is not finished"; only the log
  can. `recovery_metrics.py` and `placeholder_families.py` both stop on a log with no completion
  marker, and `Test/Scripts/test_measurement_completeness.sh` goes red if that guard is removed.

- **A generic instance has struct fields too, and the descent into them was excluded outright.** The
  offsets of a generic definition's fields are all zero in metadata, so the nested-field search reads
  nothing there - which is a reason to supply the computed layout, not a reason to skip the search.
  Classifying the 228 generic-instance loads by asking the layout walk itself split them three ways:
  173 *inside* a layout computed correctly and simply not on a field boundary (the ordinary shape of
  reaching a member of a struct field), 35 past the layout (the base is not the type the load thinks
  it is - typing work), 20 with no layout at all (a field that could not be sized). Only the first is
  this pass's, and it is three quarters of the family. Two things differ from the non-generic descent
  and both are the instance's doing: the layout already walks the base chain, so walking it again
  places every inherited field twice; and a field declared `T` has to be substituted before it can be
  descended into, because `T` has no interior and the argument standing in for it may be a struct with
  one. `CirclePlugin.SetFrom` came back as `if (!t.plugOptions.initialized)` where it had been an
  unresolved load and an always-true `if ((nint)0 == 0)`. Worth 158 loads on one fixture and 98 on the
  other, and the field taken from the layout must be closed on the instance or its name is a reference
  to `Foo<>`.
- **"A generic instance with a value type argument" is a property of the base type, not a cause** -
  the fifth family this project has had to split that was named after its symptom. The brief that
  asked for it named the wrong defect, and measuring before working is what said so.
- **A native boundary is not a decompiler failure, and the two reach the generator as one
  placeholder.** `NativeBoundary` separates them from evidence the binary carries: a relocation naming
  the imported symbol, a located key function, how many managed methods sit on the address, an
  instruction sequence recognised for what it does. On the test game 490 are the C library or the C++
  ABI, 339 are the runtime's own compare-and-swap, 33 are managed, and 416 have no evidence at all -
  `UNKNOWN`, which is a verdict and must never be counted as recovered. `P_INVOKE` is declared and
  deliberately never produced: nothing at a call site distinguishes a P/Invoke's target from any other
  imported symbol, and a verdict that cannot be evidenced is worse than one that is absent.
- **The runtime compatibility layer is a representation, not a reimplementation.** `Il2CppRuntime.
  Boundary(kind, detail)` takes the classification and the message that was already being printed, so
  the emitted shape is unchanged - one string became two. That matters: replacing a placeholder with a
  call that consumes the original operands was measured to unbalance the stack in about a thousand
  methods and cost them their bodies. And the message text is passed through verbatim, because every
  measurement in this project keys on it and a representational change that renamed things too would
  make every earlier number incomparable for nothing.
- **A placeholder now reaches the source two ways, and the extractor read one.** The moment the
  generator started using `Il2CppRuntime.Boundary`, three families - `METHOD_NOT_FOUND`,
  `NATIVE_IMPORT`, `UNKNOWN_CALL_TARGET` - read as zero, which is indistinguishable from having fixed
  them. `placeholder_families.messages()` is the one definition of how a placeholder is read; anything
  counting them imports it. `golden_corpus.py` then broke on the import it had copied from the other
  side of that move - the same drift twice in one iteration, and loud only by luck.
- **A null PPtr is not a broken reference, and counting it as one makes the measure meaningless.**
  Unity writes `{fileID: 0}` for every optional slot of every object - `m_CorrespondingSourceObject`
  on a GameObject that is not a prefab instance, `m_ProbeAnchor` on a renderer with none,
  `m_SelectOnUp` under automatic navigation - and on the test game that is 2522 of 2526 apparent
  losses. Reported as `NULL` and excluded from the rate, the project reads 0.9940 resolved; counted as
  broken it reads 0.32, which is a check too strict, which is as wrong as one too lax and costs more
  time. The one slot where null *is* a defect is `m_Script`: a MonoBehaviour that does not resolve
  loses the component and every field on it.
- **A compile rate cannot be read on its own, because an export made of declarations compiles
  beautifully.** The iOS fixture scores 0.9722 against the Android fixture's 0.8952 and has **no
  method bodies at all** - FairPlay encrypts the whole of `__TEXT`, so signatures come back and
  bodies cannot. `validate_unity_stages.py` prints `body_recovery_rate` beside it and says
  `NO_BODIES` rather than blaming a missing argument. And the rate is per *file*: one file with a
  hundred errors and a hundred files with one are the same error count and completely different
  projects, while per assembly is too coarse to move at all.
- **A stage nobody ran has no result.** The nine stages between an export and a running game are
  reported with `BLOCKED` where the tool to decide them is absent, never `PASS` and never `FAIL` -
  reporting either is how a pipeline claims to run a game it has never started. Unity is not in this
  container, so E through I are blocked on every fixture, and no runtime claim may rest on them.
- **Decompiler failure isolation already exists at both levels and measures zero.**
  `ReplaceIfUnverifiable` and `FillMethodBody` catch at the method, `DecompileWholeProject` skips a
  type ILSpy cannot read and decompiles the assembly again (up to 16). On both fixtures: 0 types
  skipped, 0 assemblies abandoned, 0 bodies failed to convert. Verified rather than built - do not
  re-implement it.
- **A golden corpus picked only by how badly recovery went is a corpus of the code least likely to
  run.** The third selection axis is what a method is *for*: `Awake`, `Start`, `Update`, Unity
  callbacks, coroutines, property getters, event accessors, constructors, static entry points -
  matched on the declaration rather than the name, because a Unity message returns void and takes no
  arguments and a helper of the same name does not. 165 to 220, and it immediately said what the
  totals could not: `Color2Plugin` and `QuaternionPlugin` moved `PARTIAL` to `HIGH_CONFIDENCE`.

- **A declaration error hides every body error in the assembly — and removing one looks exactly like
  a regression.** Dropping the event declarations that a recovered body reads through (worth 1386 →
  484 Roslyn errors on the test game, for CS0079) also removed a duplicate-member CS0102 on the iOS
  fixture: `RFEvent` declared both an event `LocalEvent` and a field of that name. Roslyn binds
  declarations first and stops there, so those three errors had been masking every body error in
  `RayFireAssembly`, which read as **119 of 120 files clean**. With them gone the assembly bound for
  the first time and the count went 1938 → 8638. There is no "before" number to compare against,
  because the old measurement never reached a body. This is the second time this trap has been
  recorded and the first time it arrived from a fix that was not aiming at it — so when an error
  count jumps, check whether a declaration error just stopped hiding things before calling it a
  regression.
- **A measurement that accepts the wrong root is the corpus bug in another tool.**
  `validate_unity_stages.py` pointed at the rip output rather than at the game directory inside it
  ran all eight remaining stages and printed a full set of numbers — 1600 errors, `compile_pass_rate`
  0.8962, `body_recovery_rate` 0.8027 — every one of them over a tree that is not a Unity project.
  Stage A now names the subdirectory it meant and nothing below it runs. A number computed over the
  wrong tree is worse than no number.
- **The source is an oracle for what came back and says nothing about what did not.** The source
  oracle pairs a method with a method, so it is silent about everything the recovery never produced;
  `source_manifest.py` enumerates the source instead and names each absence. Three are legitimate and
  must be named rather than counted — a file under an `Editor` folder or in an `Editor`-only asmdef,
  an assembly missing from the rip, and a declaration inside a preprocessor region (22 `UNITY_EDITOR`
  and one `SPINE_TK2D` on the test game). With those named, `NOT_IN_BUILD` is 0 on both fixtures that
  ship source, and the rate is per declared *type*: the exporter writes one type per file, so pairing
  by file name invents a loss for every extra type a source file holds.
- **A stand-in's properties can be perfect and the shading still replaced, so the stand-in is checked
  for first.** The shader oracle decides `DUMMY` before any degree of success and reports
  `property_recovery_rate` beside the verdicts rather than inside them. It also found a real defect
  the reconstruction had always had: `SerializedPropertyType.Color` was written as `Vector`, though
  the two are distinct in the serialized shader and in ShaderLab — a Color property gets the colour
  picker and is converted out of gamma space on assignment. The type was in the metadata and was
  discarded; fixing it took the rate 0.5111 → 1.0000, with every shader still `DUMMY` and
  `shader_exact` still 0.
- **Almost nothing in a Unity game can be executed without Unity, and the number is worth having
  anyway.** `runtime_equivalence.py` tiers each paired method by what it would need: on the source
  oracle's own game **0 of 36** are executable, because every method reaches the engine; on the test
  game 141 of 1814 are. The runner exists and discriminates (proved on synthetic assemblies:
  `x*2` against `x+x` is EQUIVALENT, `x+1` against `x+2` is DIFFERENT with the failing vectors), and
  every planned case is `NOT_RUN` until an oracle assembly exists. A rate over zero executed cases is
  `None`, never a pass.

### Things measured to be worth nothing — do not redo them
- **Adding the object header to a value type's offsets, the iteration 041 proposal.** Measured before
  being written, and the measurement refutes it: of the value-typed bases among 2722 unresolved loads,
  **77 are VALUE_RELATIVE** (the addend is the raw metadata offset) against **29 OBJECT_RELATIVE** (the
  addend is metadata + 0x10), and 43 against 14 once the cases where the first field matches trivially
  are discounted. A blanket `+0x10` would corrupt 77 field identities to recover 29. `BOTH` is zero, so
  the evidence does separate the two readings per load - but "whichever one lands" is a heuristic, not
  a rule, and is the same offset-zero guess rejected in 036, 037 and 038. Anything here needs a rule
  for *how the base pointer was obtained* first.
- **Running field resolution a second time, late, for bases typed after the fixpoint — a third and
  fourth placement.** Iteration 045 retried it after `CopyCoalescer` (2722 to **2722**) and at the
  very end of `Analyze` (2722 to **2719**, three loads). The premise stays false at every placement:
  those bases are typed when the fixpoint runs.
- **Running field resolution a second time, late, for bases typed after the fixpoint.**
  `LocalVariables.ResolveTypesAndFields` runs once and a dozen type-propagating passes follow it, so
  it looked as though copy propagation must be typing bases that field resolution never gets a second
  look at. A second `MetadataResolver.ResolveFieldOffsets` placed after the constant/copy propagation
  loop, still inside SSA, was **called on 11903 methods and changed 2** - and the rip was identical to
  the digit. Probed rather than assumed, because identical numbers are also what a pass that never
  fires looks like. The premise is simply false: those bases are typed when the fixpoint runs.
- **Applying the 041 declaring-type restriction to the open-generic branch.** Iteration 041 proposed
  this as its own next step, and it is dead code: a probe counted the `owner.GenericParameters.Count > 0`
  link as reached **0 times** on Pinata, and unifying it into `BaseChainFieldSearch` changed not one
  `.cs` file on either fixture. The error that motivated it -
  `'ComponentAction<T>' does not contain a definition for 'fsm'` - has a different cause: `fsm` is
  resolved correctly to `FsmStateAction.fsm` and is *private*, which C# reports as "does not contain a
  definition" when reached through a derived type. One occurrence, and in the same family as
  `List<T>._size`.


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

- **Folding a computed element address over a struct array *into the element itself*.** Two
  formulations, both measured, both rejected — and superseded in iteration 039 by folding into the
  element's *member* instead, which needs no width. The rejected pair: Taking the stride from metadata and matching a `Multiply`-scaled index is correct as far
  as it goes - loads 2773 to 2736 - but produces `(float)changeValue[i]`, `(float)localVertices[i]`,
  `(float)wps[i]`: seven casts from a `Vector3` to a `float` against a baseline of zero, where the
  source reads `array[i].x`. Restricting the fold to a base read at exactly one offset - the method's
  own structural evidence that the element is wanted whole rather than taken apart - helps and does
  not settle it: 2753 loads and five such casts, still not none, because an element read once at
  `0x20` can equally be its first member. Do not retry either until a field reference can name an
  array element as its base.

- **Widening a read at offset zero into the whole value.** Offset zero is the one ambiguous offset —
  the address of a struct and the address of its first field are the same number, and the access width
  does not survive to say which was meant — so the destination's type looks like the evidence that
  separates them. It is not reachable evidence. Placed after `ResolveTypesAndFields` the destination is
  still an untyped temporary; placed after copy propagation that temporary has already been typed *from
  the narrow read*, so both ends agree and there is nothing to correct; comparing the types by name
  rather than by reference (the `CopyCoalescer` lesson) changes nothing because that was never the
  cause. Three placements, three results identical to the digit. The one formulation that would fire —
  walking back through the copies to the field reference and widening its source — asserts the machine
  stored 24 bytes when it stored 4, which is distorting the source to hide a destination-side defect.
  Fix `FindNestedFieldPath` instead.

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

Eighteen scripts, and each measures something the others cannot:

- `Test/Scripts/collect_metrics.sh <iteration>` — every placeholder kind and every recovery counter
  from one run into one comparable JSON. **`generatorFailures` first**, for the reason above.
- `Test/Scripts/check_recovered_shapes.sh <rip output>` — golden checks stated as shapes rather than
  counts, so each keeps meaning as the numbers around it move. A check whose file is missing FAILs.
- `Test/Scripts/compile_recovered_scripts.sh <rip output> [assembly]` — Roslyn.
- `Test/Scripts/audit_recovered_scripts.py` — against the source, per assembly.
- `Test/Scripts/placeholder_families.py` — every placeholder back to the `IlGenerator` line that
  emitted it. It owns `MESSAGE_PREFIXES`, the one definition of what a placeholder is; anything else
  that counts them imports it rather than restating it.
- `Test/Scripts/diff_recovered_scripts.sh` — whether two rips differ at all, which is the check
  `diff -rq --include` silently never performed.
- `Test/Scripts/recovery_metrics.py` — the authoritative one: semantic status per method, against the
  IR the export itself carries. Read this before any other number; it is the only one that says how
  much of a body came back rather than how many complaints it printed.
- `Test/Scripts/instruction_coverage.py` — native opcodes the lifter has no rule for, per fixture,
  with the implemented set read out of the lifter's own switch.
- `Test/Scripts/golden_corpus.py` — 591 frozen entries across the three fixtures, one per
  (operation class, status), the worst method carrying each placeholder family, and one per runtime
  role, checked one method at a time against `Test/golden-corpus-baseline.json`. The only measure
  that can say a particular method got worse while the total got better, which is the shape this
  pipeline keeps producing. An entry is a record — `method`, `fixture`, `runtime_role`,
  `semantic_fingerprint`, `status`, `source_available` — because a path and an address are not
  unique across fixtures. The list is unioned on reselection, never replaced, and an entry that
  resolves in no fixture is `retired` with its reason rather than deleted: a frozen entry that gets
  dropped is a hole in the net.
- `Test/Scripts/runtime_helper_report.py` — the runtime helpers managed code still calls unresolved,
  ranked by call sites, with the caller profile that decides whether one can be named at all.
- `Test/Scripts/test_measurement_completeness.sh` — that a measurement refuses a rip still being
  written. Ten cases; two go red if the guard is removed.
- `Test/Scripts/test_placeholder_extraction.sh` — that a placeholder is counted whichever of the two
  call shapes carries it. Five cases; all go red if the second shape stops being read.
- `Test/Scripts/audit_project_references.py` — every PPtr in every serialized document, resolved the
  way the editor would. `NULL` is reported and excluded from the rate; only `m_Script` counts a null
  as a loss.
- `Test/Scripts/validate_unity_stages.py` — the nine stages between an export and a running game,
  with `compile_pass_rate`, `body_recovery_rate`, `reference_resolution_rate` and the shader split.
  Read `body_recovery_rate` before believing `compile_pass_rate`. It takes the **game directory
  inside** the rip; pointed at the output root it now stops at `PROJECT_ROOT_MISMATCH` rather than
  running eight stages against the wrong tree.
- `Test/Scripts/source_oracle.py` — each recovered method against the programmer's own text, by the
  operations both sides reach rather than by string equality. Only for a fixture that ships source.
- `Test/Scripts/source_manifest.py` — the other half of the oracle: what the source declares that
  the rip does not have, with the reason (`EDITOR_ONLY`, `ASSEMBLY_ABSENT`, `CONDITIONAL`) rather
  than a count. Per declared type, never per file — the exporter writes one type per file.
- `Test/Scripts/shader_oracle.py` — an exported shader against the ShaderLab it was built from.
  `DUMMY` is decided before any degree of success, and `property_recovery_rate` is reported beside
  the verdicts and never folded into them.
- `Test/Scripts/runtime_equivalence.py` and `Test/Tools/RuntimeEquivalence` — the only measure that
  runs the recovered IL. The planner tiers each paired method by what it would need to execute; the
  runner loads both assemblies and compares. A case that did not run is `NOT_RUN` with the reason,
  and a rate over zero executed cases is `None`.

`iterations/` holds one immutable directory per run: the commit, the change that was in the working
tree, the log, the metrics, the audit and the compile result. The generated projects themselves are
gitignored, being large and reproducible from the rest.

### The `ref/devx` branch — and seven others

**`ref/devx` is a branch of this repository, and the earlier description of it here was wrong on
every count.** It is not in another repo, it is not just the struct database, and it does have
decompiler code: 39 commits, 20473 files, a rebuilt DevXUnity-Unpacker (37 projects, dnSpy,
ICSharpCode.Decompiler, Mono.Cecil), and two substantial Vietnamese design documents —
`IL2CPP-PIPELINE.md` (734 lines, what DevX does, with file:line into `Recovered/`) and
`IL2CPP-REBUILD-GUIDE.md` (1795 lines, which library to use at each step, with code).

**A default clone here does not show it.** Run
`git fetch origin 'refs/heads/*:refs/remotes/origin/*'` and seven more branches appear as well:
`master`, `claude/decompile-iso-support-loglnw`, `claude/il2cpp-csharp-unity-gui-8p1fyk`,
`claude/tool-gui-unity-preview-coemaf`, `claude/package-cache-shader-match-ktkpii`,
`claude/codegraph-csharp-setup-07l07b`, `claude/convert-project-python-6mee7g`. Search them before
designing anything new; `reports/IOS_REFD_DEVX_ANALYSIS.md` is the worked example of doing so, and
it corrected a conclusion this file had already recorded as settled.

Two things taken from it so far, both by hand rather than by cherry-pick (it is .NET Framework and
Mono.Cecil, incompatible with this tree): the count-constrained registration scan, and treating an
encrypted binary as a warning rather than a stop. The struct database itself is absorbed into
`StructDb/`.

**Where it ends: `ref/devx` has no chained fixup code at all** — zero hits for `ApplyChainedFixups`,
`DYLD_CHAINED_PTR_64`, `LC_DYLD_CHAINED_FIXUPS` or `dyld_chained`, and `IL2CPP-REBUILD-GUIDE.md` §5.3
says only to read `mach_header(_64)` and walk `LC_SEGMENT_64` for `(addr, size, offset)`. It reads
segments and stops, so it rebases nothing. Anything about chained fixups has to come from Apple's
`mach-o/fixup-chains.h`, LLVM or LIEF; the pinned revisions and the verbatim quotes are in
`reports/IOS_TYPE_DEFINITIONS_SIZES_ANALYSIS.md` §6, along with two places not to copy from
(`go-macho` has the semantics backwards, and LIEF's public header drops a `<< 56`). One thing in it
*is* worth knowing and was checked rather than assumed: `typeDefinitionsSizes` is a table of pointers
to the structs, not an array of structs, and AssetRipper already reads it that way.
