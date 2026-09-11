# Regression matrix

Every row is measured. Shape checks come from `Test/Scripts/check_recovered_shapes.sh` against each
iteration's own exported scripts; numbers from `Test/Scripts/collect_metrics.sh`,
`audit_recovered_scripts.py` and `compile_recovered_scripts.sh`. `iterations/<n>/change.txt` says what
was in the working tree for each.

## Issue state per iteration

| Issue | base | 001 | 002 | 003 | 004 | 005 | 006 | 007 | 008 | 009 | 010 | 011 | Final |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| DECOMP-0001 unrecovered bodies | FAIL | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS |
| DECOMP-0002 value-type ctor | FAIL | FAIL | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS |
| DECOMP-0003 exception raiser | FAIL | FAIL | FAIL | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS |
| DECOMP-0007 shared generic call | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | PASS | PASS | PASS | PASS | PASS |
| DECOMP-0008 field layout self-check | n/a | n/a | n/a | n/a | n/a | n/a | n/a | n/a | n/a | PASS | PASS | PASS | PASS |
| DECOMP-0009 computed field address | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | PASS | PASS | PASS |
| DECOMP-0010 runtime class as handle | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | FAIL | PASS | PASS |
| DECOMP-0012 RGCTX in shared generic code | FAIL through 014, PASS from 015 | | | | | | | | | | | | PASS |
| DECOMP-0013 a phi with disagreeing inputs | FAIL through 015, PASS from 016 | | | | | | | | | | | | PASS |
| DECOMP-0014 the type-check shortcut | FAIL through 017, PASS from 018 | | | | | | | | | | | | PASS |
| injected checks still removed | PASS | PASS | PASS | **FAIL** | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS | PASS |

Two regressions were produced in this work and both were caught by measurement rather than review.

**Iteration 003** traced the exception operand through phis and took a phi's first input; at a bounds
check that found an allocation from elsewhere in the method, so eight injected checks stopped being
recognised and Roslyn went 500 to 596. Removed in 004, restored soundly in 005 by requiring every
input of the phi to be an allocation.

**Iteration 009, mid-flight** laid out the base chain but gated the recursion on the immediate base
declaring fields, which took the layout self-check from 63 disagreements to 318 — a *wrong* offset,
which names the wrong field silently. That never shipped: the self-check is the reason. Two further
steps took it to 0.

## Measurements

| metric                         |   base |    001 |    002 |    003 |    004 |    005 |    006 |    007 |    008 |    009 |    010 |    011 |
|--------------------------------|--------|--------|--------|--------|--------|--------|--------|--------|--------|--------|--------|--------|
| generator failures             |     15 |      0 |      0 |      0 |      0 |      0 |      0 |      0 |      0 |      0 |      0 |      0 |
| audit REAL_ERROR               |   2162 |   2162 |   2163 |   2124 |   2155 |   2150 |   2150 |   2150 |   2150 |   2049 |   1768 |   1766 |
| audit SEMANTIC_RISK            |    301 |    301 |    301 |    263 |    276 |    268 |    268 |    268 |    190 |    210 |    210 |    210 |
| audit EXPECTED                 |     47 |     47 |     47 |     57 |     47 |     47 |     47 |     47 |     47 |     47 |     47 |     47 |
| audit total                    |   1509 |   1509 |   1510 |   1492 |   1506 |   1502 |   1502 |   1502 |   1502 |   1410 |   1220 |   1218 |
| files with no diagnostic       |     20 |     20 |     20 |     19 |     20 |     20 |     20 |     20 |     20 |     21 |     21 |     21 |
| Roslyn errors                  |    499 |    499 |    500 |    596 |    498 |    497 |    497 |    497 |    487 |    462 |    460 |    456 |
| `Method not found`             |   2383 |   2424 |   2424 |   2267 |   2409 |   2382 |   2382 |   2382 |   2382 |   2382 |   2337 |   2337 |
| `Unmanaged memory load`        |   5512 |   5594 |   5595 |   5654 |   5581 |   5570 |   5570 |   5570 |   5570 |   4658 |   4556 |   4556 |
| untyped locals                 |  22360 |  22360 |  22360 |  21850 |  22285 |  22219 |  22219 |  22219 |  22219 |  21618 |  21448 |  21448 |
| run seconds                    |     58 |     57 |     58 |     59 |     54 |     54 |     53 |     60 |     58 |     56 |     52 |     55 |

Note that `audit total` and the three category rows have different denominators: `total` is the
audit's own headline, which counts the diagnostics the recovery *emits* plus ILSpy's type mismatches,
while the categories also count the known-bad *shapes* it looks for in the text (`(nint)` casts,
`ref *(`, shared-generic casts). Neither is a subset of the other; both are reported because they
answer different questions.

`audit REAL_ERROR` is the row to read. It is the subset of audit diagnostics that mean the recovery
lost something the binary contains; `EXPECTED` is the export being faithful about framework members
il2cpp inlined and will not go to zero. The two together are why a raw total is a poor metric: a
metric that counts what could not be recovered goes **up** when something previously discarded in
silence starts being kept, which is what iterations 001 and 008 did.

Baseline to iteration 011: **REAL_ERROR 2162 to 1766**, SEMANTIC_RISK 301 to 210, Roslyn 499 to 456,
unrecovered method bodies 15 to 0, files carrying no diagnostic at all 20 to 21, run time 58s to 55s.
EXPECTED unchanged at 47, correctly.

## Every iteration, REAL_ERROR and Roslyn

012 is a change that measured worse and was reverted; 013 is the reverted tree, kept so the revert is
verified rather than asserted. 007 and 014 are baseline re-verifications at the start of a session.

| iteration | REAL_ERROR | Roslyn | note |
|---|---:|---:|---|
| 000-baseline | 2162 | 499 |  |
| 001 | 2162 | 499 | DECOMP-0001, 15 bodies recovered |
| 002 | 2163 | 500 | DECOMP-0002 |
| 003 | 2124 | 596 | DECOMP-0003 first cut - the phi regression |
| 004 | 2155 | 498 | phi following removed |
| 005 | 2150 | 497 | phi allowed when every input is an allocation |
| 006 | 2150 | 497 | refactor only |
| 007 | 2150 | 497 | baseline re-verification |
| 008 | 2150 | 487 | DECOMP-0007 |
| 009 | 2049 | 462 | DECOMP-0008 |
| 010 | 1768 | 460 | DECOMP-0009 |
| 011 | 1766 | 456 | DECOMP-0010 |
| 012 | 2007 | 548 | DECOMP-0011 - measured worse, reverted |
| 013 | 1766 | 456 | the reverted tree |
| 014 | 1766 | 456 | baseline re-verification |
| 015 | 1307 | 448 | DECOMP-0012 |
| 016 | 1153 | 415 | DECOMP-0013 |
| 017 | 1153 | 415 | DECOMP-0014 first cut, superseded |
| 018 | 1153 | 415 | DECOMP-0014 - measured in typeHierarchyDepth loads, 252 to 178, not in these two columns |

Both of the two rows in bold are changes that looked right and were not, and both were caught by
measurement within one iteration. Iteration 012's is recorded in `CLAUDE.md` under "things measured to
be worth nothing", with the reason not to retry it.

## What did not regress

- `dotnet test AssetRipper.slnx -c Release`: 274 tests at baseline, 279 after, one failure in both.
  `ExportIdHandlerTests.GetMainExportID_ValueGreaterThan100000_DebugAssertFails` asserts that a
  `Debug.Assert` throws and Release compiles those out. Pre-existing; recorded, not fixed.
- No file's audit total rose in any shipped iteration.
- No shape check regressed once passing.
- Files exported: 819 throughout.
- Neither of the two columns above moves for iteration 018, and that is a property of the columns
  rather than of the change: both are measured on `Assembly-CSharp`, and 226 of the 252 loads
  DECOMP-0014 addresses are in spine-unity. `typeHierarchyDepthLoads` in `collect_metrics.sh` is the
  row that moves, 252 to 178. A measurement that covers one assembly will not see work done in
  another, which is worth remembering before concluding a change did nothing.
