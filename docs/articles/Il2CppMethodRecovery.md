# Il2Cpp Method Recovery

This document tracks the work to get usable method bodies out of Il2Cpp games.

## Background

Recovering an Il2Cpp game splits into two very different problems:

| Problem | Difficulty | State |
| --- | --- | --- |
| **Metadata recovery** — class, field, method signatures, attributes, inheritance | Solved | Works well at every level |
| **Method body recovery** — the actual statements inside each method | Hard | Partial, this document |

`Level2` (the default) solves only the first. It produces a "dummy dll": correct signatures, empty
bodies.

Two independent approaches attack the second, and they are complementary rather than competing:

| Approach | Output | Coverage | ARM64 | Cost |
| --- | --- | --- | --- | --- |
| **Cpp2IL IL recovery** (`Level3`) | Real C# | ~10-20% on x86, less elsewhere | Weak | Already paid for |
| **Ghidra decompilation** (`Level4`) | Pseudo C | Nearly every function | Mature | An hour or more per binary |
| Frida (`frida-il2cpp-bridge`, external) | Runtime traces and dumps | Only what executes | Android is well tested | Needs a running device |

The key insight behind `Level4` is that Il2Cpp keeps full type and method names in its metadata even
though the compiled binary has no symbols. AssetRipper already knows the address and managed name of
every method, so it can label every native function before decompiling. That is the same result the
community gets from Il2CppDumper plus manual Ghidra setup, without the manual steps.

Neither approach replaces the other. Cpp2IL produces C# that fits into the exported Unity project but
covers a minority of methods. Ghidra covers nearly everything but produces C, not C#.

## Pipeline

```
GameAssembly.dll / libil2cpp.so  +  global-metadata.dat
  └─ LibCpp2IL          parse metadata, map methods to native addresses
  └─ Cpp2IL             disassemble per instruction set (x86, ARMv7, ARMv8, WASM)
       └─ ISIL          instruction set independent IR (33 opcodes)
       └─ ISILControlFlowGraph + DominatorInfo
       └─ IlGenerator   ISIL -> CIL                                  (Level3)
  └─ AsmResolver        emit AssemblyDefinition
  └─ ILSpy              CIL -> C# source at export time
  └─ Ghidra headless    native code -> pseudo C, named from metadata (Level4)
```

## Script content levels

| Level | Behaviour |
| --- | --- |
| `Level0` | Scripts are not exported |
| `Level1` | Method bodies stripped (Mono only) |
| `Level2` | Default. Full methods for Mono, empty methods for Il2Cpp |
| `Level3` | Il2Cpp methods lifted back to CIL where possible |
| `Level4` | Everything `Level3` does, plus Ghidra decompiles the native binary |

## Known limitations

These are properties of the analysis, not of the wiring:

- Cpp2IL IL recovery is partial. Upstream reports roughly 10-20% of methods on x86 games.
- Non-x86 instruction sets do worse in Cpp2IL. ARMv8 covers a narrower set of operations than x86,
  which matters because shipped mobile games are ARM64. Ghidra does not share this weakness.
- `mscorlib` and any assembly whose name starts with `System` or `Unity` are excluded from Cpp2IL
  analysis for performance, so engine and BCL code stays stubbed.
- Recovered C# is not expected to compile. It is for reading, not rebuilding.
- Ghidra output is C, so it will not go into an exported Unity project as source.

## Level 4 setup

The quickest way is `Ghidra.bat` (or `Ghidra.sh`) in the repository root. It downloads Ghidra into
`./ghidra` the first time, reuses it afterwards, and launches AssetRipper with `GHIDRA_INSTALL_DIR`
already pointed at it. The download and the extracted installation are both git ignored.

Ghidra itself is Java, and its decompiler is a separate native executable that the Java side drives
over a pipe, so there is no library to reference from .NET. AssetRipper invokes the headless analyzer
as a child process; that is the only integration Ghidra offers.

Level 4 needs a Ghidra installation. It is found in this order:

1. `GhidraInstallation.OverrideDirectory`, if set programmatically.
2. The `GHIDRA_INSTALL_DIR` environment variable, which is Ghidra's own convention.
3. A `ghidra` directory next to the AssetRipper executable.

A directory counts as an installation when it contains `support/analyzeHeadless` (or
`analyzeHeadless.bat` on Windows). Ghidra 12 requires a JDK 21 runtime.

If no installation is found, Level 4 logs a warning and behaves exactly like Level 3, so it never
fails a load.

Output goes to `GhidraDecompilation_<timestamp>/` next to the executable, one `.c` file per assembly,
each function preceded by its managed name and address. `GhidraHeadlessRunner.Timeout` defaults to
four hours.

Expect the run to take an hour or more on a real game and to need a lot of memory. It runs as a
separate process so a hang or a crash cannot take AssetRipper down with it.

## Phases

### Phase 0 — Enable Cpp2IL recovery (done)

- `IL2CppManager.RecoveryOutputFormat` defaults to `InstrumentedIlRecoveryOutputFormat`.
- `IL2CppManager.RecoveryProcessingLayers` defaults to the same layers as `Level2`.
- `Level3` is selectable in the settings UI.

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
normalized (addresses and numbers collapsed) so the same defect groups into one reason.

The CSV has one row per method with `Assembly, Method, Outcome, InstructionCount, FailureMessage`.

### Phase 2 — Ghidra decompilation (done)

`Level4` writes a symbol file from Il2Cpp metadata, then runs Ghidra headless with a bundled script
that applies those names and exports the decompiled output grouped by assembly. The script is
embedded in `AssetRipper.Import` so it travels with the build.

Addresses are resolved against the loaded image base with a fallback, because the address Il2Cpp
reports does not always match the base Ghidra loads at.

The script also writes `decompilation_index.txt`, keyed by declaring type, method name and parameter
count. During export, `GhidraCommentTransform` looks each method up in that index and attaches the
recovered pseudo C above the declaration as a comment, so the exported `.cs` carries both the C#
signature and the real logic. Matching is by name rather than address because the assemblies handed
to ILSpy are generated and no longer carry native addresses.

The comment is C, not C#, so it cannot be a method body. Long bodies are truncated at 200 lines by
default to keep one method from burying the rest of the file.

### Phase 3 — Measure on a real game (next)

This phase is a decision gate, not a commitment to improve anything.

1. Load a build at `Level3` and collect the recovery CSV.
2. Load the same build at `Level4` and review the Ghidra output.
3. Compare architectures. Building the same game for both ARM64 and x86_64 shows how much the
   instruction set is costing Cpp2IL, and confirms Ghidra is unaffected.
4. Diff recovered output against original source where available. Any first party title is a ground
   truth corpus that outside contributors do not have.
5. Rank Cpp2IL failure reasons by frequency from the CSV.

**Gate:** if Ghidra covers what is needed, further Cpp2IL work is hard to justify. Phase 4 only makes
sense if C# output specifically is required.

### Phase 4 — Cpp2IL improvements (unscheduled, low priority)

Deprioritized in favour of Ghidra, which reaches far higher coverage for far less effort. Only worth
starting if C# output is a hard requirement and Phase 3 shows a concentrated set of failures.

- Try `NewArmV8InstructionSet` instead of `Arm64InstructionSet`. `IL2CppManager` currently hardcodes
  `useNewArm64 = false`. This is the cheapest experiment with the largest potential effect on ARM64.
- Work the ranked failure list from Phase 3. ISIL has only 33 opcodes, so the surface area is finite.
- `AsmResolverDllOutputFormatIlRecovery.WriteControlFlowGraph` dumps a Graphviz CFG for one method.

`IlGenerator` is `internal` to Cpp2IL. Changing lifting behaviour means forking Cpp2IL and building
the package, not patching AssetRipper.

### Phase 5 — Possible extensions (unscheduled)

- Cache Ghidra results keyed by binary hash, so a re-import does not pay the hour again.
- Improve key matching. Declaring type, method name and parameter count is unambiguous for the vast
  majority of methods, but overloads that differ only by parameter type collide and will get the
  wrong comment attached.
- Feed the pseudo C through an LLM refinement pass for readability. Research on this (LLM4Decompile,
  D-LiFT) is promising, but the models reconstruct loops and array indexing unreliably, so the output
  cannot be treated as a source of truth.

## Configuration

| Setting | Default | Purpose |
| --- | --- | --- |
| `ScriptContentLevel` | `Level2` | `Level3` for IL recovery, `Level4` to add Ghidra |
| `GHIDRA_INSTALL_DIR` | unset | Where to find Ghidra |
| `Il2CppRecoveryReport.Enabled` | `true` | Set false to skip statistics collection |
| `GhidraHeadlessRunner.Timeout` | 4 hours | How long to wait for the analyzer |
| `IL2CppManager.RecoveryOutputFormat` | `InstrumentedIlRecoveryOutputFormat` | Replaceable |
| `IL2CppManager.RecoveryProcessingLayers` | Attribute analysis + override name fixer | Replaceable |

## Licensing

Level 3 is a paid feature of the upstream project, but the implementation lives in the public
`AssetRipper.Cpp2IL.Core` package and AssetRipper itself is GPL-3.0. Wiring it up in a fork is a
modification of GPL software using published open source packages, not a circumvention of any
protection mechanism; `GameFileLoader.Premium` is documented in the source as affecting UI only.
Anyone relying on this in production should still consider supporting upstream, whose paid build may
carry improvements beyond the public package.

Ghidra is public domain software released by the NSA and is not bundled here; Level 4 only invokes an
installation the user provides.
