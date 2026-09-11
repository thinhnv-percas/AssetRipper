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
| 019 | 1153 | 415 | baseline re-verification |
| **020** | 1115 | 406 | DECOMP-0015 first cut - five files worse, a `bool` return typed as a MonoBehaviour; narrowed, not shipped |
| 021 | 1076 | 402 | DECOMP-0015 |
| **022** | 1079 | 404 | DECOMP-0016 applied inside the fixpoint - two files worse, `obj as ItemResources` read as an int; deferred, not shipped |
| 023 | 1076 | 403 | DECOMP-0016 - measured in unresolved loads, 3741 to 3689, almost all outside Assembly-CSharp |
| **024** | not measured | not measured | DECOMP-0017 on the affine evaluator - unresolved loads 3689 to 4077; abandoned |
| **025** | not measured | not measured | the same with single definitions and a reached-the-array guard - 4085; abandoned |
| 026 | 1052 | 389 | DECOMP-0017, the two missing shapes without the chain walk |
| 027 | 1052 | 389 | tái lập baseline, khớp 026 từng con số |
| 028 | 896 | 350 | DECOMP-0018 - phi lan ngược chuyển xuống pass bằng chứng yếu |
| 029 | 896 | 350 | DECOMP-0019 - 82 type check nhận thêm, sau bị chứng minh là vô giá trị |
| **030** | 754 | 315 | DECOMP-0020 bản đầu, chỉ đánh dấu định nghĩa cuối - CS0165 5 lên 12, xoá code còn sống; không nhận |
| **031** | 884 | 340 | cùng bản với đánh dấu mọi định nghĩa, nhưng vẫn còn DECOMP-0019 |
| 032 | 884 | 340 | DECOMP-0020 bản nhận, DECOMP-0019 đã revert |
| 033 | 884 | 340 | DECOMP-0021 (iOS) — Android không đổi một con số nào, đây là điều cần |
| 034 | 884 | 340 | DECOMP-0023 (iOS) — Android và Pinata giống hệt từng con số |

Both of the two rows in bold are changes that looked right and were not, and both were caught by
measurement within one iteration. Iteration 012's is recorded in `CLAUDE.md` under "things measured to
be worth nothing", with the reason not to retry it.

## Hai nền tảng

Từ iteration 033, bảng này chỉ đo Android. Trạng thái iOS ở
`reports/CROSS_PLATFORM_MATRIX.md`; hai cột REAL_ERROR và Roslyn **không tồn tại cho iOS** vì
fixture bị FairPlay mã hoá nên không có script nào được phục hồi để đo. Đừng đọc "Android không đổi"
thành "không có gì xảy ra": ở iteration 033, đúng việc Android không đổi một con số nào là kết quả
cần có, vì thay đổi nằm hoàn toàn ở nhánh iOS và ở LibCpp2IL dùng chung.

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
- The same holds for iteration 023, more sharply: Assembly-CSharp holds 359 of the 3689 unresolved
  loads and none of the 52 DECOMP-0016 removed, so its REAL_ERROR is unchanged and Roslyn moves by
  one inside the existing `Box`-to-`float` family. `reports/TYPE_RECOVERY_ANALYSIS.md` carries the
  per-assembly table, which is now the artefact to read before calling a change inert.
- Iteration 030 là cảnh báo rõ nhất trong toàn bộ bảng này về việc chạy theo số. Nó tốt hơn 032
  trên **mọi** cột dễ đọc — unresolved loads 2458 so với 2870, Roslyn 315 so với 340, REAL_ERROR
  754 so với 884, 15 file tốt lên so với 7 — và nó xoá code còn sống. Thứ phát hiện ra là
  CS0165 "use of unassigned local variable" tăng từ 5 lên 12, một con số nhỏ nằm trong một họ lỗi
  nhỏ, bên cạnh những con số lớn đang đi đúng hướng. Nếu chỉ đọc REAL_ERROR và Roslyn thì bản đó
  đã được commit.
- Iteration 029 là cảnh báo ngược lại: một patch có lý luận đúng, chứng minh được bằng nguồn đối
  chiếu (82 lần `obj as T` được phục hồi, Spine dòng 158), và giá trị thật bằng không — vì 82 lần
  đó nằm trong vùng code chết mà DCE đáng lẽ phải thu gom. Bug thật là DCE. Patch đã revert.
- Iterations 020 and 022 are the two first cuts above. Neither was committed. Both were caught by
  the per-file audit diff within one iteration, and in both cases the cause was the same: a rule
  that withheld evidence rather than ranking it, so something weaker filled the gap. 020's fix was
  to require the substitution to have actually reached the type in hand; 022's was to apply the
  weak evidence in a second pass rather than not at all.
- Iteration 035 là ví dụ về việc hai giả thuyết đã ghi thành hồ sơ đều sai, và chỉ có trace mới nói
  ra điều đó. `InstanceSize=2249170484` trên iOS bị nghi là (a) metareg false positive hoặc (b)
  `ApplyChainedFixups` sai. Trace đầu-cuối cho: bảng con trỏ **đúng** (8702 entry tăng đơn điệu,
  bước 0x10, không null, hai count độc lập khớp `metadata.TypeDefinitionCount`), và binary **không
  có** `LC_DYLD_CHAINED_FIXUPS` nên hàm bị nghi chưa từng chạy. Nguyên nhân là giả thuyết thứ ba:
  đích của bảng nằm trong vùng FairPlay, entropy 7,999/8. Android giống hệt **byte-for-byte** cả 819
  file `.cs` (md5), nên phép đo này là bằng chứng chứ không phải suy luận từ việc "ELF không mã hoá".
  Test suite 279 -> 296 test, 1 fail có sẵn từ trước không đổi.
- Cùng iteration đó, bốn test chained-fixup đầu tiên là **degenerate** và pass với cả code chưa sửa:
  `Rebase(target, 0, 0) == target`, nên dạng encoded và dạng đã rebase là cùng một số. Cách duy nhất
  xác lập một test có phân biệt được hay không là revert từng fix và xem nó đỏ. Đây đúng là hình dạng
  "một pass không bao giờ chạy trông như thế nào" đã ghi nhiều lần trong bảng này, lần này ở phía
  test chứ không phía production.
