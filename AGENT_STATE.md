# Agent state

Read this first after a restart, then `reports/regression-matrix.md` for the numbers and
`reports/issues.json` for the open items.

```
Current iteration: 011 (complete)

Decompiler commit:
  claude/read-current-repository-daqxc1 @ 55f1490, base 69a31182cfe6f4c30f5d1f46d5defd3bf412e55c

Input:
  Impostor-Sort-Puzzle-Pro v1, impostor-sort.apk
  sha256 8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf
  unpacked at Test/Input/Impostor, verified byte-identical for libil2cpp.so,
  global-metadata.dat and data.unity3d

Reference:
  thinhabc01/Impostor-Sort-Puzzle-Pro @ a5b796283d7d7cc457b7c73ebf7b5869776d755b (tag v1)
  Unity 2022.3.62f2, matching the binary

Current stage:
  idle between iterations. Baseline for the next one is iteration 011.

Where iteration 011 stands, against the baseline:
  unrecovered method bodies      15 -> 0
  audit REAL_ERROR             2162 -> 1766
  audit SEMANTIC_RISK           301 -> 210
  audit EXPECTED                 47 -> 47   (correctly unchanged; see DECOMP-0005)
  Roslyn errors, Assembly-CSharp 499 -> 456
  files with no diagnostic at all 20 -> 21
  field layout self-check       n/a -> 1394 exact, 78 incomplete, 0 disagreed
  run time                       58s -> 55s
  tests                     274, 1 fail -> 279, 1 fail (the same pre-existing one)

Current bug family:
  none in flight. The next by measured impact is DECOMP-0004, and
  reports/BUG_FAMILY_PRIORITY.md has the ranked table with the other axes.

Current hypothesis:
  The remaining 456 Roslyn errors are 156 EXPECTED (framework internals il2cpp inlined, DECOMP-0005)
  and about 250 CS0030, of which the largest identified shapes are a literal zero cast to a
  reference type (80, downstream of an unresolved load) and a reference value converted to nint
  (~110, an address computation whose field identity is still lost). The nint family is what is left
  of DECOMP-0009 where the base is untyped at both ends rather than at one.

Evidence to start from:
  - reports/UNTYPED_LOCAL_IMPACT.md: 91% of the 21448 untyped locals provably cost nothing. Do not
    work from that count.
  - reports/BUG_FAMILY_PRIORITY.md: the families with counts, category, and the files each touches.
  - the run's own breakdowns: `memory loads the generator gave up on, by kind` and
    `locals the analysis could not type, by what defines them`.

Fixed:
  DECOMP-0001  15 method bodies exported as a throw carrying the generator's own stack trace
  DECOMP-0002  a value type's constructor call dropped, so the value stayed zero
  DECOMP-0003  a raiser handed a constructed exception named after the wrong exception
  DECOMP-0007  a shared generic call not retargeted onto the receiver's instantiation
  DECOMP-0008  the generic field layout bailing on a base with fields and on a user struct
  DECOMP-0009  a load not folded back onto the base whose address was computed for it
  DECOMP-0010  a runtime class answering zero where a RuntimeTypeHandle or Type was wanted

Open:
  DECOMP-0004  the untyped-locals family, ROADMAP section 5. Read UNTYPED_LOCAL_IMPACT.md first.
  DECOMP-0006  55 `base._002Ector(` - blocked behind DECOMP-0004, because ILSpy will not fold a base
               call in a body that carries a stack type mismatch
  and the items in docs/articles/ImpostorSortScriptAudit.md, of which #1 (an unresolved call keeping
  the whole register file as its arguments) is the largest not yet started

Measured and closed without a change:
  DECOMP-0005  the read side of the accessor pairing already covers List<T>._size; what is left of
               that family is writes to it and reads of _items and _version, none of which the real
               List<T> exposes. WONT_FIX, with the numbers, in reports/issues.json.

Regression status:
  clean. All seven shape checks pass, no file's audit total rose in any shipped iteration, and the
  field layout self-check reports 0 disagreements - which is a gate, not a note: the shape checks
  fail without it.

Blocked Unity tests:
  U1-U9 in reports/BLOCKED_UNITY_TESTS.md. Scripts in Test/Scripts/unity/ are written and refuse to
  run without a real editor (exit 90). NOT passing. The verdict stays PASS_WITH_KNOWN_LIMITATIONS
  until Test/Scripts/unity/run_all.sh has actually run.

Next action:
  Take the `(T)0` shape (80 errors). It is the downstream half of an unresolved load: the generator
  pushes a zero for an operand it could not resolve, and where the wanted type is a reference or a
  struct that reads as a cast from a number. LoadOperand already has both rules; find which path
  reaches them with expectedType null. Probe rather than guess - the last four fixes were each found
  by dumping the ISIL at the point the pass runs, and three of the four were somewhere other than
  where the output suggested.

Last successful stage:
  iteration 011 - full validation, no regression.

Last failure:
  the mid-flight step in iteration 009 described in reports/regression-matrix.md, caught by the
  layout self-check before it shipped.
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
