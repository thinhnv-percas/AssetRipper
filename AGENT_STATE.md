# Agent state

Read this first after a restart, then `reports/regression-matrix.md` for the numbers and
`reports/issues.json` for the open items.

```
Current iteration: 006 (complete)

Decompiler commit:
  claude/read-current-repository-daqxc1, base 69a31182cfe6f4c30f5d1f46d5defd3bf412e55c

Input:
  Impostor-Sort-Puzzle-Pro v1, impostor-sort.apk
  sha256 8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf
  unpacked at Test/Input/Impostor, verified byte-identical for libil2cpp.so,
  global-metadata.dat and data.unity3d

Reference:
  thinhabc01/Impostor-Sort-Puzzle-Pro @ a5b796283d7d7cc457b7c73ebf7b5869776d755b (tag v1)
  Unity 2022.3.62f2, matching the binary

Current stage:
  semantic validation against the reference source, on Assembly-CSharp

Fixed:
  DECOMP-0001  15 method bodies exported as a throw carrying the generator's own stack trace
  DECOMP-0002  a value type's constructor call dropped, so the value stayed zero
  DECOMP-0003  a raiser handed a constructed exception named after the wrong exception

Open:
  DECOMP-0004  the untyped-locals family, ROADMAP section 5 - 275 CS0030 and most of the 1502
               remaining audit diagnostics. The measured breakdown is in the run log.
  DECOMP-0005  146 CS1061 for `bool.m_value` - a trivial accessor pairing that does not match
  DECOMP-0006  55 `base._002Ector(` - ILSpy will not fold a base call in a body that carries a
               stack type mismatch, so this is blocked behind DECOMP-0004
  and the seven items in docs/articles/ImpostorSortScriptAudit.md, of which #1 (an unresolved call
  keeping the whole register file as its arguments) is the largest not yet started

Current hypothesis:
  Nothing in flight. The next item by measured cost is DECOMP-0004; the next by confidence is
  DECOMP-0005, where `bool.m_value` says a struct's trivial accessor pairing is missing the
  primitive wrapper case.

Next action:
  Break down the 275 CS0030 by the opcode that wrote the local, from the untyped-local breakdown the
  run already prints, before touching the type fixpoint.

Last successful stage:
  iteration 006 - 0 generator failures, 1502 audit diagnostics (from 1509), 497 Roslyn errors
  (from 499), all three shape checks passing, no regression in the test suite

Last failure:
  iteration 003 - following a phi's first input broke eight injected checks. Fixed in 004/005 by
  requiring every input of the phi to be an allocation.
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
