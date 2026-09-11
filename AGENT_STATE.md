# Agent state

Read this first after a restart, then `reports/regression-matrix.md` for the numbers and
`reports/issues.json` for the open items.

```
Current iteration: 016 (complete)

Decompiler commit:
  claude/read-current-repository-daqxc1 @ e5a16d6, base 69a31182cfe6f4c30f5d1f46d5defd3bf412e55c

Input:
  Impostor-Sort-Puzzle-Pro v1, impostor-sort.apk
  sha256 8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf
  unpacked at Test/Input/Impostor, verified byte-identical for libil2cpp.so,
  global-metadata.dat and data.unity3d

Reference:
  thinhabc01/Impostor-Sort-Puzzle-Pro @ a5b796283d7d7cc457b7c73ebf7b5869776d755b (tag v1)
  Unity 2022.3.62f2, matching the binary

Current stage:
  idle between iterations. Baseline for the next one is iteration 016.

Where iteration 016 stands, against the original baseline:
  unrecovered method bodies      15 -> 0
  audit REAL_ERROR             2162 -> 1153
  audit SEMANTIC_RISK           301 -> 223
  audit EXPECTED                 47 -> 47   (correctly unchanged; see DECOMP-0005)
  Roslyn errors, Assembly-CSharp 499 -> 415
  unresolved loads              5702 -> 3903
  files with no diagnostic at all 20 -> 21
  field layout self-check       n/a -> 1394 exact, 78 incomplete, 0 disagreed
  run time                       58s -> 53s
  tests                     274, 1 fail -> 279, 1 fail (the same pre-existing one)

Current bug family:
  none in flight.

Current hypothesis:
  The "past the last field of the base type" family is worked out and recorded in
  reports/BASE_FIELD_OVERFLOW_ANALYSIS.md. Its one metadata-answerable cause is fixed (DECOMP-0012);
  what is left of it - 246 bases typed System.Object, ~139 typed as an ancestor, 99 open generic
  parameters - has no metadata answer and is the use-side typing problem.

  The unresolved-load families left in Assembly-CSharp, which is the only assembly with a reference:
    69  past the last field of the base type   (typing, no metadata answer)
    45  base has no type, from Move from an untyped base
    43  base has no type, from no definition
    27  base has no type, from Move from AddressOf(an untyped local)
    26  Il2CppClass.0x28
    23  value type base
  409 in total, of 3903 across the export.

Evidence to start from:
  - reports/BASE_FIELD_OVERFLOW_ANALYSIS.md and .../CASES.json - the worked inventory, and the
    method: classify before counting. `CPP2IL_DUMP_LOADS=<file>` writes one row per load from the
    same event the summary counts.
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
  clean. All nine shape checks pass, the field layout self-check reports 0 disagreements (a gate, not
  a note), 0 unrecovered bodies. One file, ResourcesUtil.cs, gained a single audit diagnostic at
  iteration 016 - a `)(object)` cast that the wrong concrete type had been hiding.

Blocked Unity tests:
  U1-U9 in reports/BLOCKED_UNITY_TESTS.md. Scripts in Test/Scripts/unity/ refuse to run without a
  real editor (exit 90). NOT passing. The verdict stays PASS_WITH_KNOWN_LIMITATIONS.

Next action:
  Two candidates, and the second is the one to take first because it is verifiable.

  (a) `Il2CppClass.typeHierarchyDepth`, 252 loads, is the inlined cast that TypeCheckRecovery did not
      fold. It is the largest single self-contained family left - but 226 of the 252 are in
      spine-unity, which ships no reference source here, so the result could not be checked against
      an oracle.

  (b) `((DataController)(object)instance3).SetBackground(...)` in the newly recovered
      DataController.GenarateDataMap, where the source calls `SetBackground(...)` on `this`. The
      receiver is a `GameManager` local cast to `DataController` - a resolved call whose receiver is
      wrong, which is worse than an unresolved one because it compiles. Small, verifiable against the
      reference, and it appeared only once the surrounding code was recovered.

  Probe rather than guess: every fix this session and last was found by dumping the ISIL at the point
  the pass runs, and most were somewhere other than where the output suggested.

Last successful stage:
  iteration 016 - full validation, no regression beyond the one noted above.

Last failure:
  DECOMP-0011, iteration 012 - reverted on measurement, not shipped.
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
