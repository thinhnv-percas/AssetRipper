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

Branch `claude/read-current-repository-daqxc1`, base commit `69a31182`. Twelve iterations,
`iterations/000-baseline` through `iterations/011`, each with its commit, the change that was in the
working tree, the log, and its own measurements.

## Architecture and pipeline

Mapped in `docs/agent/ARCHITECTURE.md` and `docs/agent/DECOMPILER_PIPELINE.md`. The short of it: a
recovered method body passes through six representations — machine code, ISIL, SSA ISIL over a CFG,
analysed ISIL, CIL, C# text — produced respectively by the game, `NewArmV8InstructionSet`, `SsaForm`,
the 31 passes in `Cpp2IL.Core/Analysis`, `IlGenerator`, and ILSpy through `ScriptDecompiler`. Every
defect below is anchored to the representation it first went wrong in, and was fixed there.

## Issues discovered

Ten recorded: seven confirmed and fixed, one measured and closed without a change, two open with the
evidence to start from. None was previously recorded. `reports/issues.json` carries the evidence per
issue and `reports/BUG_FAMILY_PRIORITY.md` ranks what remains.

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

**DECOMP-0007 — a shared generic call was not retargeted onto the receiver's instantiation.**
`GENERIC_INFERENCE`, representation 5. il2cpp compiles one body per generic definition and shares it,
so a call resolves to whichever instantiation the address was attributed to — every int-backed enum
key shares `Dictionary<System.Int32Enum, System.Object>`. `resourceDict.ContainsKey(statType)` came
out as `((Dictionary<System.Int32Enum, object>)(object)resourceDict).ContainsKey((System.Int32Enum)statType)`,
naming a type internal to the framework and casting a field whose declared type was known exactly.
The receiver's type is the stronger evidence, so where the two are instantiations of one definition
and disagree the receiver wins — and no list of sharing placeholders is needed, because when they
agree it is a no-op. 629 calls retargeted.

**DECOMP-0008 — the generic field layout gave up rather than computing.** `METADATA`,
representation 4. Two TODOs: it bailed if any base type had an instance field, and it could not size a
user-defined value type, which truncated the layout at the first struct field. A wrong offset is worse
than none — it names the wrong field silently — so the fix is gated on a check that can settle it: a
non-generic type carries the real offsets and the same walk has to reproduce them. That self-check
went 827 exact / 63 disagreeing before, to 1394 / **0** after, and it caught a wrong intermediate step
that would otherwise have shipped 318 disagreements. The last step is the one that matters most:
a struct's size comes from il2cpp's recorded `instance_size` less the object header, because packing
its fields is a guess wherever a fixed buffer or an explicit layout is involved.

**DECOMP-0009 — a load was not folded back onto the base whose address was computed for it.**
`IL2CPP`, representation 4. `[t + K]` where `t = base + J` is `[base + (J + K)]`. The compiler
computes a field's address ahead of the load whenever it is wanted more than once, and nothing typed
the intermediate — so the load off it did not resolve, and neither did the load off what it produced.
One missing rule cost three resolutions in `GamePlayController.RewindPlay`, which read
`object obj = (nint)this + 88; … ((GameObject)0).SetActive(value: false);` and now reads
`if (currentBox != null) { … box.effect.SetActive(value: false); }`, as its source does.

**DECOMP-0010 — a runtime class answered zero where a handle was wanted.** `METADATA`,
representation 5. `Type.GetTypeFromHandle(typeof(T))` came out as
`Type.GetTypeFromHandle((RuntimeTypeHandle)0)`: the `RuntimeClassTypeAnalysisContext` case sat ahead
of the cases that know how to answer, and a runtime class carries the type it is the class of.

**DECOMP-0005 — measured and closed without a change.** The 146 `CS1061` were assumed to be an
accessor pairing that did not match. Probing said the read side already covers `List<T>._size`: all
180 of its occurrences are *writes*, and `List<T>.Count` has no public setter. What remains is reads
of `_items` and `_version`, which the real `List<T>` does not expose at all. The export is faithful
and a compiler is right to reject it.

## Compilation results

`Test/Scripts/compile_recovered_scripts.sh` builds the exported scripts against the assemblies the rip
ships beside them, which is the only compilation measurement available here.

| | baseline | final (iteration 011) |
|---|---|---|
| `Assembly-CSharp` files | 63 | 63 |
| Roslyn errors | 499 | **456** |
| Roslyn warnings | 3012 | 2837 |

Down 43 while 15 more method bodies are being compiled at all. `reports/BUG_FAMILY_PRIORITY.md`
classifies what is left: **156 of the 456 are EXPECTED** — the export being right about a binary that
inlined framework internals, which no change to the recovery can or should remove — and about 250 are
`CS0030`, of which the two largest identified shapes are a literal zero cast to a reference type (80,
downstream of an unresolved load) and a reference value converted to `nint` (~110, an address
computation whose field identity is still lost).

## Structural results

The generated project has `Assets/`, `Packages/` and `ProjectSettings/`, with the recovered and
stubbed assemblies under `AuxiliaryFiles/GameAssemblies/`. 819 `.cs` files, unchanged across all six
iterations. No `Library/` is produced, so none was validated.

## Semantic results

`Test/Scripts/audit_recovered_scripts.py` compares the recovery against the source it was built from,
per assembly, counting every diagnostic and known-bad shape per file.

| | baseline | final (iteration 011) |
|---|---|---|
| **REAL_ERROR** — the recovery lost something the binary has | **2162** | **1766** |
| SEMANTIC_RISK — reads as valid C#, meaning suspect | 301 | 210 |
| EXPECTED — faithful; a property of what il2cpp inlined | 47 | 47 |
| BENIGN — a compiler-generated name the source never wrote | 150 | 148 |
| the audit's own headline total | 1509 | 1218 |
| files carrying no diagnostic at all, of 46 | 20 | 21 |

`audit_recovered_scripts.py` now reports those categories, because the raw total is a poor metric: it
goes **up** when something previously discarded in silence starts being kept, and `EXPECTED` will not
go to zero and should not. Two files that read semantically as their source now and did not before:

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

`GamePlayController.RewindPlay` is the other, and it is the clearest single result of the work:

```csharp
// reference                                     // recovered, iteration 011
if (currentBox != null) {                        if (currentBox != null) {
    currentBox.effect.SetActive(false);              Box box = currentBox;
    ...                                              box.effect.SetActive(value: false);
}                                                }
// recovered at baseline:
//   object obj = (nint)this + 88;
//   if ((UnityEngine.Object)obj != null) {
//       object obj2 = obj;
//       Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X8_v19+58]");
//       ((GameObject)0).SetActive(value: false);
```

`Common.Assert` throws the exception it builds, `ResourcesUtil` reads `resourceDict.ContainsKey(statType)`,
and `CSVSerializer.Deserialize<T>` opens `Type typeFromHandle = typeof(T);`.

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

`reports/regression-matrix.md` has the full table. **Two** regressions were produced and both were
caught by measurement rather than by review.

The second never shipped, and is the better illustration. Iteration 009's fix laid out the base chain
but gated the recursion on the immediate base declaring instance fields; `ArgumentException`'s
immediate base declares none and `Exception` above it declares 0x80 bytes of them, so `_paramName`
landed at 0x10 instead of 0x90. That is a *wrong offset*, which names the wrong field silently and no
compiler would object to. The layout self-check the same change introduced took it from 63
disagreements to 318, which is why it was found at all; two further steps took it to 0.

The first: iteration 003's first cut of DECOMP-0003 traced the exception
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
branch-target resolution, four of which fail against the pre-fix code (verified by reverting it);
`Test/Scripts/check_recovered_shapes.sh`, six golden checks each verified to fail on the output of the
iteration before its fix; and the field-layout self-check, which the shape checks read out of the run
log and fail on unless it reports 0 disagreements. That last one is the most valuable of them: it is
the only exact check on a computation whose whole purpose is to run where metadata has no answer.

## Performance

58 seconds at baseline, 55 at iteration 011, on 4 cores; the fastest iteration was 52. No memory or
output-size change: 819 files throughout. The four analysis passes added all run inside loops that
already existed, and the field-layout self-check runs once over 1472 types.

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
- Iterations 001–011 were run from the working tree rather than from a commit each, so several
  `source-commit.txt` files record the commit their work was built on rather than one containing it.
  `iterations/<n>/change.txt` says what was in the tree for each, and the head of this branch carries
  iteration 011.

## Open issues

`reports/issues.json`, `reports/BUG_FAMILY_PRIORITY.md` and `AGENT_STATE.md` carry these with the
evidence to start from. Two are open and one is closed as WONT_FIX with its measurement.

`reports/UNTYPED_LOCAL_IMPACT.md` exists because the obvious next target is a trap: 21448 locals reach
the generator untyped, and **91% of them provably cost nothing** — 67.5% are first read by an
unresolved call, for which the generator emits a placeholder rather than loading operands, and 24% are
never read at all. The actionable set is about 1850, of which only the half that a typing rule can
reach is worth a rule. That report is the reason none of this session's four fixes was a typing rule:
each was a resolution rule instead, and between them they removed more untyped locals (22219 to 21448)
than a typing pass was going to.

`docs/articles/ImpostorSortScriptAudit.md` still stands, less the `OutOfMemoryException` note that
DECOMP-0003 closed and the `_size` note that DECOMP-0005 corrected. Its item #1 — an unresolved call
keeping the whole register file as its arguments, which lets a later call read a register nothing
wrote and pass its entry value — is the largest thing not yet started.

## Final verdict

**PASS_WITH_KNOWN_LIMITATIONS**

Seven confirmed defects were traced to the earliest incorrect transformation, fixed there, and each is
covered by a check that fails without the fix. An eighth was measured and closed as WONT_FIX rather
than guessed at. The generated project has no unrecovered method bodies, compiles to 43 fewer errors
than the baseline while compiling strictly more code, and its REAL_ERROR audit count is down 18% —
with `EXPECTED` unchanged, which is what says the reduction is recovery rather than accounting. Three
methods with a reference to compare against now read as their source does where they did not. Both
regressions the loop produced were caught by measurement, one of them before it shipped.

It is not a PASS, and cannot become one here. The Unity-side criteria — import, Unity compilation,
scene and prefab loading, player build, runtime smoke test, differential testing — could not be
exercised in this container at all. They are registered as U1–U9 in
`reports/BLOCKED_UNITY_TESTS.md`, the scripts to run them are written and wired
(`Test/Scripts/unity/run_all.sh`), and every one of them exits 90 rather than reporting anything when
no editor is present. 456 Roslyn errors and 1766 REAL_ERROR audit diagnostics remain, classified and
open rather than unknown. Calling that PASS would misreport what was measured.
