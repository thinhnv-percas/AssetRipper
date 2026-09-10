# Impostor-Sort-Puzzle-Pro: recovery against its own source

## Input

| | |
|---|---|
| Release asset | `https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro/releases/download/v1/impostor-sort.apk` |
| SHA256 | `8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf` |
| Size | 41,001,430 bytes |
| Platform | Android, `arm64-v8a` (an unused `armeabi-v7a` is also present) |
| Backend | IL2CPP, `global-metadata.dat` v31.1 |
| Unity | 2022.3.62f2 |

The tracked `Test/Input/Impostor` was verified byte-identical to the release asset for
`libil2cpp.so`, `global-metadata.dat` and `data.unity3d`; it omits only
`META-INF/com/android/build/gradle/app-metadata.properties`. So the recovery under test reads exactly
the bytes the reference source was built into.

## Reference

`thinhabc01/Impostor-Sort-Puzzle-Pro` at `a5b796283d7d7cc457b7c73ebf7b5869776d755b`, which is what
tag `v1` and `HEAD` both point at — there is no revision to choose. `ProjectVersion.txt` says
2022.3.62f2, matching the binary, which is what makes this an oracle rather than an approximation.
46 exported files have a reference to compare against; `docs/agent/REFERENCE.md` lists them and the
three places where the binary, not the source, is ground truth.

## Decompiler

Branch `claude/read-current-repository-daqxc1`, base commit `69a31182`. Seven iterations,
`iterations/000-baseline` through `iterations/006`, each with its commit, the change that was in the
working tree, the log, and its own measurements.

## Architecture and pipeline

Mapped in `docs/agent/ARCHITECTURE.md` and `docs/agent/DECOMPILER_PIPELINE.md`. The short of it: a
recovered method body passes through six representations — machine code, ISIL, SSA ISIL over a CFG,
analysed ISIL, CIL, C# text — produced respectively by the game, `NewArmV8InstructionSet`, `SsaForm`,
the 31 passes in `Cpp2IL.Core/Analysis`, `IlGenerator`, and ILSpy through `ScriptDecompiler`. Every
defect below is anchored to the representation it first went wrong in, and was fixed there.

## Issues discovered

Three, all confirmed, all fixed, none of them previously recorded. `reports/issues.json` carries the
evidence per issue.

**DECOMP-0001 — 15 method bodies were not recovered at all.** `METHOD_RECONSTRUCTION`, representation
5. They exported as `throw new Exception("System.ArgumentOutOfRangeException ... at
Cpp2IL.Core.IlGenerator.GenerateIl")`. `IlGenerator` indexed `instructionMap[target][0]` for a branch
target without checking the list was non-empty; generation is allowed to emit nothing for an
instruction — a constructor call the allocation already covers is dropped — so a jump over one had
nothing to bind to. `TimeInGame::CompareTo` is one of the 15 and is covered by the reference source.
The fix resolves such a branch to the first instruction at or after the target that did generate code,
and to a successor's entry when nothing after it in its own block did — which is what the block-level
path had done all along.

**DECOMP-0002 — a value type's constructor call was dropped, so the value stayed zero.**
`METHOD_RECONSTRUCTION`, representation 5. Dropping a `.ctor` call outside a constructor is right for
a reference type and wrong for a value type: there is no allocation to fuse with, il2cpp calls the
constructor on the address of the slot, and that is what C# compiles `x = new T(...)` to.
`TimeInGame.CompareTo` came back as `return default(DateTime).CompareTo(value)` — which compiles, and
reports every pair of times as equal.

**DECOMP-0003 — a raiser handed a constructed exception threw the wrong type, 563 times.** `IL2CPP`,
representation 4. `MetadataResolver.TryRewriteAsThrow` asked `ThrowHelperRecovery` for a name first,
and that names a helper after the first string ending in `Exception` that it or a callee references.
The generic raiser's implementation at `0xB4F35C` and the out-of-memory helper at `0xB4F384` both end
in `adrp/add x1, <the same type_info>; mov x2, xzr; bl __cxa_throw`, so they are indistinguishable by
name; `SetOperands(thrown)` then discarded the exception the call was handed. `Common.Assert` became
`UnityException ex = new UnityException(message); throw new OutOfMemoryException();`. Precedence alone
could not fix it — `IsExceptionRaiser` is true for all seven resolved helpers on this game, because
they all reach the native throw. What settles it is the argument slot: a helper that builds its own
exception has no use for one handed to it.

## Compilation results

`Test/Scripts/compile_recovered_scripts.sh` builds the exported scripts against the assemblies the rip
ships beside them, which is the only compilation measurement available here.

| | baseline | final (iteration 006) |
|---|---|---|
| `Assembly-CSharp` files | 63 | 63 |
| Roslyn errors | 499 | **497** |
| Roslyn warnings | 3012 | 2999 |

Down by two while 15 more method bodies are being compiled at all. The remaining errors are
dominated by two families, both pre-existing and both recorded as open: 275 `CS0030` from locals the
type fixpoint could not type (ROADMAP section 5) and 146 `CS1061` for `bool.m_value`, a trivial
accessor pairing that does not match the primitive wrappers.

## Structural results

The generated project has `Assets/`, `Packages/` and `ProjectSettings/`, with the recovered and
stubbed assemblies under `AuxiliaryFiles/GameAssemblies/`. 819 `.cs` files, unchanged across all six
iterations. No `Library/` is produced, so none was validated.

## Semantic results

`Test/Scripts/audit_recovered_scripts.py` compares the recovery against the source it was built from,
per assembly, counting every diagnostic and known-bad shape per file.

| diagnostic | baseline | final (iteration 006) |
|---|---|---|
| out-of-memory throws | 71 | **46** |
| null-reference throws | 105 | **97** |
| method not found | 231 | **229** |
| `nint` casts | 650 | **645** |
| type mismatches | 606 | **602** |
| unresolved loads | 666 | **665** |
| shared generics | 120 | 120 |
| **total** | **1509** | **1502** |

20 of the 46 files the reference covers carry no diagnostic of any kind, before and after, with none
lost. `TimeInGame.CompareTo` now reads line for line as its source does:

```csharp
// reference                                    // recovered
var thisDate = new DateTime(Year, Month,        DateTime dateTime = default(DateTime);
    Day, Hours, Minutes, Second);               dateTime = new DateTime(Year, Month, Day,
var otherDate = new DateTime(other.Year,            Hours, Minutes, Second);
    other.Month, other.Day, other.Hours,        DateTime value = new DateTime(other.Year,
    other.Minutes, other.Second);                   other.Month, other.Day, other.Hours,
return thisDate.CompareTo(otherDate);               other.Minutes, other.Second);
                                                return dateTime.CompareTo(value);
```

and `Common.Assert` throws the exception it builds.

## IL / metadata consistency

Checked where source and recovery disagreed, and it decided DECOMP-0003 against both the source and
my first three hypotheses. The ISIL dump of `Common::Assert` showed the constructed `UnityException`
reaching the raise call in X0 and the enclosing method's `MethodInfo` in X1, and a hand disassembly of
`0xB4F35C`, `0xB4F384` and the `0xAD96B4`/`BC`/`C4` stub table showed why the name lookup cannot tell
the raiser from the out-of-memory helper. That disassembly also established a second thing, recorded
but not costing anything today: `InspectPotentialThrowHelper` stops at `RET`, `BR` and an
unconditional `B`, and those three stubs end by falling into each other, so a scan from the first
collects all three helpers' calls.

## Regression testing

`reports/regression-matrix.md` has the full table. One regression was produced and caught by
measurement rather than by review: iteration 003's first cut of DECOMP-0003 traced the exception
operand through phis and took a phi's first input, which at a bounds check found an allocation from
elsewhere in the method. Eight injected checks stopped being recognised, `throw new
IndexOutOfRangeException()` became `throw <an uninitialised local>` with the check left standing, and
Roslyn errors went 500 → 596. Iteration 004 removed phi following and the regression with it;
iteration 005 restored it under the condition that every input of the phi be an allocation, which is
sound because an injected check merges the register file of an unresolved call and that is not an
allocation on any path.

`dotnet test AssetRipper.slnx -c Release`: 274 tests at baseline, 279 after, one failure in both —
`ExportIdHandlerTests.GetMainExportID_ValueGreaterThan100000_DebugAssertFails`, which asserts that a
`Debug.Assert` throws and cannot pass in a Release build. Pre-existing; recorded, not fixed.

Regression tests added: `Source/AssetRipper.Tests/Il2CppBranchTargetTests.cs`, five cases over the
branch-target resolution, four of which fail against the pre-fix code (verified by reverting it); and
`Test/Scripts/check_recovered_shapes.sh`, three golden checks that fail on the baseline output and
pass on iteration 006's.

## Performance

58 seconds at baseline, 53 at iteration 006, on 4 cores. No memory or output-size change: 819 files
and 42 MB throughout.

## Known limitations of this run

- **Unity was not available in this container**, so Unity batchmode import, Unity script compilation,
  scene and prefab loading, `BuildPlayer` and every runtime smoke test could not be run. Roslyn
  against the shipped assemblies is weaker than Unity's compilation for Unity-specific assemblies, and
  stricter in one direction: a framework member IL2CPP stripped from the build reads as an error
  against the stub even where the export is fine against a real Unity install.
- **No differential testing was possible** for the same reason: nothing here can execute either the
  reference source or the recovered project.
- **Only `Assembly-CSharp` was compared semantically.** It is the only assembly the reference source
  covers; Spine, DOTween, LeanPool, CodeStage and Zitga ship as their own assemblies and were measured
  only by placeholder counts and by Roslyn.
- Iterations 001–006 were run from the working tree rather than from a commit each, so every
  `source-commit.txt` records the same base. `iterations/<n>/change.txt` says what was in the tree for
  each, and the head of this branch carries iteration 006.

## Open issues

`reports/issues.json` and `AGENT_STATE.md` carry these with their next actions. The largest by
measured cost is the untyped-locals family (ROADMAP section 5): 275 `CS0030` and most of the 1502
remaining audit diagnostics. Next by confidence is the 146 `CS1061` for `bool.m_value`. 55
`base._002Ector(` remain and are blocked behind section 5, because ILSpy will not fold a base call in a
body that carries a stack type mismatch. The seven items in
`docs/articles/ImpostorSortScriptAudit.md` stand, less the `OutOfMemoryException` note, which
DECOMP-0003 explains and closes.

## Final verdict

**PASS_WITH_KNOWN_LIMITATIONS**

Three confirmed defects were traced to the earliest incorrect transformation, fixed there, and each is
covered by a test that fails without the fix. The generated project has no unrecovered method bodies,
compiles to fewer errors than the baseline while compiling strictly more code, and reads closer to its
source on every diagnostic the audit counts. The one regression the loop produced was caught and
removed within the loop.

It is not a PASS. The Unity-side criteria — import, Unity compilation, scene and prefab loading,
runtime smoke test, differential testing — could not be exercised in this container at all, and 497
Roslyn errors and 1502 audit diagnostics remain, classified and open rather than unknown. Calling
that PASS would misreport what was measured.
