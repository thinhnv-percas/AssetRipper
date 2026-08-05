# Il2Cpp Method Recovery

This document tracks the work to make `ScriptContentLevel.Level3` produce usable C# method bodies for
Il2Cpp games.

## Background

Recovering an Il2Cpp game splits into two very different problems:

| Problem | Difficulty | State |
| --- | --- | --- |
| **Metadata recovery** — class, field, method signatures, attributes, inheritance | Solved | Works well at every level |
| **Method body recovery** — the actual statements inside each method | Hard | Partial, this document |

`Level2` (the default) solves only the first. It produces a "dummy dll": correct signatures, empty
bodies. `Level3` additionally lifts each method's native machine code back into CIL, which ILSpy then
decompiles into real C# during export.

### Pipeline

```
GameAssembly.dll + global-metadata.dat
  └─ LibCpp2IL          parse metadata, map methods to native addresses
  └─ Cpp2IL             disassemble per instruction set (x86, ARMv7, ARMv8, WASM)
       └─ ISIL          instruction set independent IR (33 opcodes)
       └─ ISILControlFlowGraph + DominatorInfo
       └─ IlGenerator   ISIL -> CIL
  └─ AsmResolver        emit AssemblyDefinition
  └─ ILSpy              CIL -> C# source at export time
```

`AsmResolverDllOutputFormatIlRecovery` drives the `Analyze()` -> `IlGenerator.GenerateIl()` half of
that pipeline. When recovery of a method throws, it replaces that body with
`throw new Exception(message)` and moves on, so one bad method never fails the export.

## Known limitations

These are properties of the upstream analysis, not of the wiring:

- Success is partial. Upstream reports roughly 10-20% of methods on x86 games.
- Non-x86 instruction sets do worse. ARMv8 covers a narrower set of operations than x86, which
  matters because shipped mobile games are ARM64.
- `mscorlib` and any assembly whose name starts with `System` or `Unity` are excluded from analysis
  for performance, so engine and BCL code stays stubbed regardless of level.
- Recovered C# is not expected to compile. It is for reading, not rebuilding.

## Phases

### Phase 0 — Enable and measure (done)

- `IL2CppManager.RecoveryOutputFormat` defaults to `InstrumentedIlRecoveryOutputFormat`.
- `IL2CppManager.RecoveryProcessingLayers` defaults to the same layers as `Level2`.
- `Level3` is selectable in the settings UI.
- Every `Level3` load logs a recovery summary and writes a per method CSV next to the executable.

### Phase 1 — Benchmark instrumentation (done)

`Il2CppRecoveryReport` records one row per method. Because Cpp2IL swallows its failures and releases
its analysis data before returning, the outcome is read back off the generated body by
`MethodBodyClassifier`:

| Outcome | Meaning |
| --- | --- |
| `Excluded` | Declaring assembly is skipped by Cpp2IL for performance |
| `NoBody` | Abstract or extern, nothing to recover |
| `Failed` | Recovery threw; the message is captured for grouping |
| `Minimal` | Recovery ran but lifted nothing, body returns a default value |
| `Recovered` | Real instructions were produced |

Only `Failed`, `Minimal` and `Recovered` count towards the success rate. Failure messages are
normalized (addresses and numbers collapsed) so the same underlying defect groups into one reason
regardless of which method hit it.

The CSV has one row per method with `Assembly, Method, Outcome, InstructionCount, FailureMessage`,
which is what Phase 2 prioritizes against.

### Phase 2 — Measure a real game, then decide (next)

This phase is a decision gate, not a commitment to improve anything.

1. Load a build at `Level3` and collect the CSV.
2. Compare architectures. Build the same game for both ARM64 and x86_64 if possible; the delta
   between them is the clearest signal of how much the instruction set is costing.
3. Diff recovered C# against original source where available. Any first party title is a ground
   truth corpus that outside contributors do not have.
4. Rank failure reasons by frequency from the CSV.

**Gate:** if the recovered fraction on the target architecture is too low to answer the question that
motivated the work, stop here. The measurement is cheap; the improvement work is not.

### Phase 3 — Targeted improvements (unscheduled)

Only worth starting if Phase 2 shows a concentrated set of failures.

- Try `NewArmV8InstructionSet` instead of `Arm64InstructionSet`. `IL2CppManager` currently hardcodes
  `useNewArm64 = false`. This is the cheapest experiment with the largest potential effect on ARM64.
- Work the ranked failure list from Phase 2. ISIL has only 33 opcodes, so the surface area is finite.
- `AsmResolverDllOutputFormatIlRecovery.WriteControlFlowGraph` dumps a Graphviz CFG for one method,
  which is the tool for investigating an individual failure.

`IlGenerator` is `internal` to Cpp2IL. Changing lifting behaviour means forking Cpp2IL and building
the package, not patching AssetRipper.

### Phase 4 — Upstream (unscheduled)

Fixes belong in [Cpp2IL](https://github.com/SamboyCoding/Cpp2IL). ARM64 is the weakest area and the
one most likely to benefit others, and upstreaming avoids carrying a fork indefinitely.

## Configuration

| Setting | Default | Purpose |
| --- | --- | --- |
| `ScriptContentLevel` | `Level2` | Set to `Level3` to enable recovery |
| `Il2CppRecoveryReport.Enabled` | `true` | Set false to skip statistics collection |
| `IL2CppManager.RecoveryOutputFormat` | `InstrumentedIlRecoveryOutputFormat` | Replaceable |
| `IL2CppManager.RecoveryProcessingLayers` | Attribute analysis + override name fixer | Replaceable |

## Licensing

Level 3 is a paid feature of the upstream project, but the implementation lives in the public
`AssetRipper.Cpp2IL.Core` package and AssetRipper itself is GPL-3.0. Wiring it up in a fork is a
modification of GPL software using published open source packages, not a circumvention of any
protection mechanism; `GameFileLoader.Premium` is documented in the source as affecting UI only.
Anyone relying on this in production should still consider supporting upstream, whose paid build may
carry improvements beyond the public package.
