# Agent state

Read this first after a restart, then `reports/regression-matrix.md` for the numbers and
`reports/issues.json` for the open items.

```
Current iteration: 026 (complete; 020, 022, 024 and 025 were first cuts, not committed)

Decompiler commit:
  claude/read-current-repository-daqxc1 @ 53f98aa, base 69a31182cfe6f4c30f5d1f46d5defd3bf412e55c

Input:
  Impostor-Sort-Puzzle-Pro v1, impostor-sort.apk
  sha256 8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf
  unpacked at Test/Input/Impostor, verified byte-identical for libil2cpp.so,
  global-metadata.dat and data.unity3d

Reference:
  thinhabc01/Impostor-Sort-Puzzle-Pro @ a5b796283d7d7cc457b7c73ebf7b5869776d755b (tag v1)
  Unity 2022.3.62f2, matching the binary

Current stage:
  idle between iterations. Baseline for the next one is iteration 026.

Where iteration 026 stands, against the original baseline:
  unrecovered method bodies      15 -> 0
  audit REAL_ERROR             2162 -> 1052
  audit SEMANTIC_RISK           301 -> 187
  audit EXPECTED                 47 -> 51
  Roslyn errors, Assembly-CSharp 499 -> 389
  unresolved loads              5702 -> 3569  (Assembly-CSharp 347 of them)
  loads with a System.Object base n/a -> 17   (69 before DECOMP-0016)
  typeHierarchyDepth loads      n/a  -> 139
  files with no diagnostic at all 20 -> 21
  field layout self-check       n/a -> 1394 exact, 78 incomplete, 0 disagreed
  run time                       58s -> 53s
  tests                     274, 1 fail -> 279, 1 fail (the same pre-existing one)

Current bug family:
  none in flight.

Current hypothesis:
  Use-side typing is worked out and recorded in reports/TYPE_RECOVERY_ANALYSIS.md, with the
  evidence ranks the fixpoint now applies in order and the per-assembly load table. Two ranks were
  out of order and both are fixed: a shared generic instantiation outranking the receiver
  (DECOMP-0015), and System.Object - the top of the lattice - outranking a field's declared type
  (DECOMP-0016). What is left of the 3689 splits into 1576 whose base has no usable type and 2113
  whose base is typed and whose offset could not be placed; about 600 of the second group are
  runtime structure reads rather than managed fields, and are a pattern-recognition problem, not a
  typing one.

  The biggest single typing group left is 659 loads whose base is defined by an `Add` whose own
  base is untyped - the computed-address problem one step back from where ArrayRecovery and
  FoldComputedFieldAddresses already claim it.

Evidence to start from:
  - reports/TYPE_RECOVERY_ANALYSIS.md - the evidence ranking, both defects worked through, what is
    left by family and by assembly. Read before touching the fixpoint.
  - reports/TYPE_PROVENANCE.json - every unresolved load grouped by what defines its base, 021 and
    023 side by side.
  - reports/OBJECT_BASE_TYPE_PROVENANCE.json - the 69 System.Object-based loads and the 17 left.
  - reports/BASE_FIELD_OVERFLOW_ANALYSIS.md and .../CASES.json - the worked inventory, and the
    method: classify before counting. `CPP2IL_DUMP_LOADS=<file>` writes one row per load from the
    same event the summary counts; it now names the instruction that defined the base.
  - reports/UNTYPED_LOCAL_IMPACT.md - 91% of untyped locals provably cost nothing. Still true.
  - reports/BUG_FAMILY_PRIORITY.md - the compile-error families with category and files.

Fixed:
  DECOMP-0001  15 method bodies exported as a throw carrying the generator's own stack trace
  DECOMP-0002  a value type's constructor call dropped, so the value stayed zero
  DECOMP-0003  a raiser handed a constructed exception named after the wrong exception
  DECOMP-0007  a shared generic call not retargeted onto the receiver's instantiation
  DECOMP-0008  the generic field layout bailing on a base with fields and on a user struct
  DECOMP-0009  a load not folded back onto the base whose address was computed for it
  DECOMP-0010  a runtime class answering zero where a RuntimeTypeHandle or Type was wanted
  DECOMP-0012  an RGCTX entry in shared generic code inflated with no arguments
  DECOMP-0013  a phi with disagreeing inputs taking the first one's type
  DECOMP-0014  il2cpp's type-check shortcut not folded on the shape it actually has
  DECOMP-0015  a shared generic instantiation outranking the receiver inside the type fixpoint
  DECOMP-0016  System.Object at a use site taken as evidence when it is the top of the lattice
  DECOMP-0017  two of the three shapes an element address is computed in not folded

Open:
  DECOMP-0004  the untyped-locals family, ROADMAP section 5. Read UNTYPED_LOCAL_IMPACT.md first.
  DECOMP-0006  `base._002Ector(` - blocked behind DECOMP-0004
  and the items in docs/articles/ImpostorSortScriptAudit.md, of which #1 (an unresolved call keeping
  the whole register file as its arguments) is the largest not yet started

Measured and reverted:
  DECOMP-0011  typing the stand-in value a giving-up point pushes. Worse on every axis; recorded in
               CLAUDE.md under "measured to be worth nothing" with the reason not to retry it.

Measured and closed without a change:
  DECOMP-0005  the read side of the accessor pairing already covers List<T>._size; what is left of
               that family has no public equivalent at all. WONT_FIX, with the numbers.

Regression status:
  clean. All thirteen shape checks pass, the field layout self-check reports 0 disagreements (a
  gate, not a note), 0 unrecovered bodies, 0 generator failures. No file's audit total is worse than
  at iteration 019. The checks match fixed strings, not patterns: DECOMP-0017's own check read
  `[array2[num5]]` as a character class and failed against output that contained it.

Blocked Unity tests:
  U1-U9 in reports/BLOCKED_UNITY_TESTS.md. Scripts in Test/Scripts/unity/ refuse to run without a
  real editor (exit 90). NOT passing. The verdict stays PASS_WITH_KNOWN_LIMITATIONS.

Next action:
  Four, roughly in order of what the evidence says they are worth.

  (a) **A field of a struct element: `array[i].y`.** The largest identifiable part of the 551
      `Add`-defined bases left. The fold cannot name these as an ArrayAccess, because one element
      of a `Vector3[]` is wider than one load of it and doing so reads a Vector3 as a float. They
      need the element's *address* named as a local of the element's type, which is what
      `ArrayRecovery.RecoverStructElementAddresses` produces - from the uses, at the end of
      analysis, and only when the array is the base directly. Making it reach a computed base is
      the work, and DECOMP-0017's negative result says to do it by extending the shape rather than
      by walking the definition chain.

  (b) **About 600 runtime structure reads counted as unresolved loads.** `Il2CppClass` at
      `typeHierarchyDepth` (139), `0x28` (111), `interface_offsets_count` (84), `0xFC` (61),
      `cctor_finished` (49), `Il2CppMethodInfo` at `0x53` (53), static field storage at `0x8` (49).
      These have the right base and the right offset; what is missing is a pass that recognises the
      shape, as `TypeCheckRecovery` and `InterfaceDispatchRecovery` do for theirs. The hierarchy
      *walk* - `obj->klass->typeHierarchy[T->typeHierarchyDepth - 1] == T` - is the 139, and is (a)
      from the previous state file, still unfinished.

  (c) **An object's klass gets over-typed from a narrowed local.** `v1161 = [v563]` where v563 is
      typed `Spine.RotateTimeline` gives `Il2CppClass<Spine.RotateTimeline>`, but the object's class
      is not known at compile time - that is the point of the check being there. Same family as
      DECOMP-0013 and DECOMP-0016: a type asserted where none is known. Worth making a klass load
      decline when the source local's type came from a cast rather than from an allocation.

  (d) **The enumerator in an address-taken stack slot** is still typed from the shared
      instantiation, which is what DECOMP-0015's shape check deliberately does not claim. il2cpp
      stores the enumerator into a stack slot and calls MoveNext on its address; the slot's type
      should come from the value stored into it, which is now correctly typed. A store-into-slot
      propagation, not a call-retarget.

  Note for whoever takes these: spine-unity *is* verifiable. Spine's own source is vendored at
  `artifacts/reference/.../Assets/ThirdParties/Spine/Runtime/spine-csharp/`, so a recovery there can
  be read against it even though `audit_recovered_scripts.py` only covers Assembly-CSharp. That is
  where half the remaining unresolved loads are.

  And: Assembly-CSharp holds under a tenth of the loads. Before concluding a change did nothing,
  read the per-assembly table in reports/TYPE_RECOVERY_ANALYSIS.md.

Last successful stage:
  iteration 026 - full validation, no file worse than 019, no regression.

Last failure:
  DECOMP-0011, iteration 012 - reverted on measurement, not shipped. Iterations 020, 022, 024 and
  025 were first cuts caught by measurement and narrowed before shipping. 024 and 025 are recorded
  in CLAUDE.md under "measured to be worth nothing"; do not redo the affine generalisation.
```

## Environment notes

The container has no .NET SDK and no Unity. `dotnet` came from
`https://dot.net/v1/dotnet-install.sh --channel 10.0 --install-dir /home/user/.dotnet`; add it to
`PATH` and set `DOTNET_ROOT` for `Test/Scripts/compile_recovered_scripts.sh`, which finds Roslyn
under it. There is no `/usr/bin/time`.

**Unity itself is unavailable here**, so Unity batchmode import, script compilation and any runtime
smoke test could not be run. Roslyn against the assemblies the rip ships is the compilation
measurement that was available; it is weaker than Unity's for Unity-specific assemblies and stricter
in one direction, because a framework member IL2CPP stripped from the build reads as an error against
the stub even though the export is fine against a real Unity install.

## The loop, as commands

```
dotnet build AssetRipper.slnx -c Release
dotnet test  AssetRipper.slnx -c Release --no-build

dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output iterations/<n>/output --log iterations/<n>/logs/AssetRipper.log Test/Input/Impostor

Test/Scripts/collect_metrics.sh        iterations/<n>
Test/Scripts/check_recovered_shapes.sh iterations/<n>/output
Test/Scripts/compile_recovered_scripts.sh iterations/<n>/output Assembly-CSharp
python3 Test/Scripts/audit_recovered_scripts.py \
  --source artifacts/reference/Impostor-Sort-Puzzle-Pro/Assets \
  --output iterations/<n>/output/Impostor/Assets/Scripts/Assembly-CSharp \
  --json   iterations/<n>/reports/audit.json
```
