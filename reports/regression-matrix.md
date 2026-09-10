# Regression matrix

Every row is measured, not asserted. The shape checks come from
`Test/Scripts/check_recovered_shapes.sh`, run against each iteration's own exported scripts; the
numbers come from `Test/Scripts/collect_metrics.sh`, `Test/Scripts/audit_recovered_scripts.py` and
`Test/Scripts/compile_recovered_scripts.sh`. `iterations/<n>/change.txt` says what was in the working
tree for each.

## Issue state per iteration

| Issue | 000-baseline | 001 | 002 | 003 | 004 | 005 | 006 | Final |
|---|---|---|---|---|---|---|---|---|
| DECOMP-0001 | FAIL | PASS | PASS | PASS | PASS | PASS | PASS | PASS |
| DECOMP-0002 | FAIL | FAIL | PASS | PASS | PASS | PASS | PASS | PASS |
| DECOMP-0003 | FAIL | FAIL | FAIL | PASS | PASS | PASS | PASS | PASS |
| injected checks still removed | PASS | PASS | PASS | **FAIL** | PASS | PASS | PASS | PASS |

The one regression this loop produced is on the last row, and it is why iterations 004 and 005 exist.
Iteration 003's first cut of DECOMP-0003 traced the exception operand through phis and took a phi's
first input; at a bounds check that found an allocation from elsewhere in the method, so eight
injected checks stopped being recognised, `throw new IndexOutOfRangeException()` became
`throw <an uninitialised local>`, and the check was left standing around it. It is visible in every
column of the table below for 003: Roslyn errors 500 to 596, `Unmanaged memory load` up 59,
`GameController.cs` leaving the list of files that carry no diagnostic at all. Iteration 004 removed
phi following entirely and the regression went with it; iteration 005 put it back under the condition
that *every* input of the phi be an allocation, which is sound because an injected check merges the
register file of an unresolved call and that is not an allocation on any path.

## Measurements

| metric                             | 000-baseline |          001 |          002 |          003 |          004 |          005 |          006 |
|------------------------------------|--------------|--------------|--------------|--------------|--------------|--------------|--------------|
| generator failures                 |           15 |            0 |            0 |            0 |            0 |            0 |            0 |
| `Method not found`                 |         2383 |         2424 |         2424 |         2267 |         2409 |         2382 |         2382 |
| `Unmanaged memory load`            |         5512 |         5594 |         5595 |         5654 |         5581 |         5570 |         5570 |
| `Unknown call target`              |          152 |          152 |          152 |          164 |          151 |          149 |          149 |
| untyped locals                     |        22360 |        22360 |        22360 |        21850 |        22285 |        22219 |        22219 |
| loads the generator gave up on     |         5733 |         5733 |         5734 |         5789 |         5720 |         5702 |         5702 |
| audit diagnostics, own scripts     |         1509 |         1509 |         1510 |         1492 |         1506 |         1502 |         1502 |
| Roslyn errors, Assembly-CSharp     |          499 |          499 |          500 |          596 |          498 |          497 |          497 |
| run seconds                        |           58 |           57 |           58 |           59 |           54 |           54 |           53 |

Read the middle rows with the grain: a metric that counts what could not be recovered goes **up** when
something previously discarded in silence starts being kept. Iteration 001 recovered 15 bodies that
had been exported as a `throw` carrying a stack trace, and its `Method not found` count rose by 41
because those bodies now report their own unresolved calls. The rows that only ever mean progress are
the first (generator failures), the seventh (diagnostics on the game's own scripts, against the source
they were built from) and the eighth (what a compiler rejects).

## What did not regress

- `dotnet test AssetRipper.slnx -c Release`: 274 tests at baseline, 279 after (the five new ones), one
  failure in both. `ExportIdHandlerTests.GetMainExportID_ValueGreaterThan100000_DebugAssertFails`
  asserts that a `Debug.Assert` throws, and a Release build compiles those out. Pre-existing, and
  recorded as the baseline rather than fixed.
- Run time: 58s at baseline, 54s at iteration 005.
- Files exported: 819 throughout.
- Iteration 006 is iteration 005 with `MetadataResolver` reading `KeyFunctionRecovery.ObjectNewFunctions`
  rather than a copy of it, and it measures identically on every field of `metrics.json` and on all
  three shape checks. That is what says the refactor changed nothing.
- Files carrying no diagnostic at all, among the 46 the reference source covers: 20 at iteration 002,
  19 at 003 (the regression), 20 at 004 and 005, with none lost relative to 002.
