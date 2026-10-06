# Iteration 066 — Buildability-driven semantic recovery

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`, `UNITY_NOT_AVAILABLE`.

Baseline là bản rip cuối của 065 (`Test/Out65z-{z,m,i,j,p,o}`), **đo lại bằng script cuối của 066**. Kết quả là
`Test/Out66i-*`, một bản build duy nhất cho cả sáu fixture. Bản rip trung gian (66b–66h) chỉ dùng để quy thay đổi về
nguyên nhân; số của chúng chỉ xuất hiện ở nơi cần cho việc đó.

## Tóm tắt

| § | Brief | Tầng đầu tiên sai | Sửa | Báo cáo |
|---|---|---|---|---|
| §2 | 2315/2510 `UNKNOWN_CLASS_SOURCE` iOS | metadata usage: offset ở một `Add` riêng, không trong memory operand | usage qua địa chỉ tính (base trang + offset); guard `cctor_finished` dạng word; guard method-init qua base trang | `UNKNOWN_CLASS_PROVENANCE_066.md` |
| §3 | `sub sp, sp, xN` | lifter: `mov sp, xN` là phép cộng vào thanh ghi bị bỏ | `ShiftStack [Register]`, `StackState.Dynamic`, `SPDYN`, `OpCode.StackAlloc` → `localloc` | `DYNAMIC_STACK_ALLOCATION_066.md` |
| §4 | 46 `UNKNOWN_RETURN` | mô hình return chỉ biết buffer T | `PlanReturn`: buffer, ô frame, mọi lý do khác có tên | `INVOKER_RETURN_RECOVERY_066.md` |
| §5 | 324 lỗi thân Merge-Room | (nhiều) | 324 → 310; bốn họ P0 không đổi | `MERGE_ROOM_BODY_ERRORS_066.md` §1 |
| §6 | `= ref *(` | địa chỉ field có base là field read, thanh ghi bị dùng lại | `FieldOfALoadedObject` | như trên §2 |
| §7 | store qua ô SP | — | đo được là âm, đã revert | như trên §3 |
| — | ngoài brief | lifter: cờ C/V của ADDS/CMN là hằng 0 | cờ của `a - (-b)` | như trên §4 |
| §8 | dương tính giả của scanner | regex chữ ký | từ khoá câu lệnh, 13 self-test | — |
| §9–§12 | hợp đồng, ma trận, Unity gate, artefact | — | `recovery_contract.py`, `buildability_matrix.py`, `project_artifact_check.py` | `RECOVERY_CONTRACT_066.md`, `BUILDABILITY_MATRIX_066.md` |

## Số liệu (65z → 66i, cả hai đầu đo bằng script cuối)

| Fixture | EXACT | FALLBACK | Placeholder | Lỗi thân Roslyn (A-CSharp) | Golden +/− |
|---|---|---|---|---|---|
| Impostor | 4474 → 4483 | 63 → 63 | 3440 → 3382 | 202 → 208 | 22 / 3 (cả ba có từ trước) |
| Merge-Room | 11923 → 11965 | 221 → 221 | 18601 → **18148** | 324 → **310** | 16 / 2 (MMFeedbacks có từ 062; DateTimeUtils, xem dưới) |
| RunFromZombies | 2967 → 2969 | 59 → 59 | 3902 → 3859 | 7 → 7 | 21 / 3 (2 có từ trước; DateTimeUtils) |
| JellyBlastV2 | 3127 → **4349** | 18 → 32 | 34947 → **16619** | 2599 → 2599 | 22 / 0 |
| Pinata | 13150 → 13178 | 286 → 285 | 8786 → 8442 | 1146 → 1144 | — |
| JellyBlastV2 opt-in | 5357 → **7145** | 30 → 74 | 54695 → **25551** | — | 22 / 0 |

Bất biến (§15):
- generatorFailures 0, field-layout disagreement 0, MonoBehaviour layout mismatch 0 trên cả sáu.
- **TrueAlias 0** trên cả sáu (65z cũng 0). `Unknown` storage hazard tăng trên iOS (42 → 61; opt-in 64 → 83) vì
  nhiều code tới được hơn. Đó không phải TrueAlias.
- Parameter overwrite bởi stand-in: 0 trên cả sáu. Dương tính giả của 065 đã hết.
- RunFromZombies behaviour **1.0000** (35/35).
- Oracle độc lập JellyBlast 0.6862 → **0.7594** (912/1329 → 1013/1334).

## Phân loại thay đổi (§14)

- **NEW_COVERAGE**
  - Usage qua base trang + offset. Guard class-init dạng word: gập qua phần tiếp theo nhân đôi, hoặc chỉ theo word.
    Guard method-init qua base trang.
  - Alloca → `localloc`.
  - Return của invoker qua ô frame: Merge-Room 64 → 80 dòng viết lại.
  - Field address có base là object đã đọc.
  - Cờ ADDS/CMN. `ParseZone` đọc được giờ múi; vòng chữ số của `WriteDefaultIsoDate` thoát được.
- **EXPECTED_CHANGE**
  - FALLBACK JellyBlastV2 18 → 32 và opt-in 30 → 74: method từng có placeholder giờ không còn, nên phép kiểm tên
    mới chạy lần đầu. 19 trường hợp đầu đã đọc; ví dụ `DateTimeParser.ParseZone` có thân 65z là `ZoneHour = 0` vô
    điều kiện.
  - `DateTimeUtils` EXACT → PARTIAL (Merge-Room, RunFromZombies): thân mới phục hồi thêm vòng lặp thoát được và phần
    ghi ngày.
  - `= ref *(` opt-in 399 → 440: code mới tới được mang khiếm khuyết biểu diễn có sẵn.
  - Họ lỗi thân JellyBlastV2 đổi chỗ, tổng không đổi: INTERFACE_SCAN_SURVIVOR 148 → 373 và STRUCT_LOCAL_AS_ADDRESS
    37 → 147, đổi lấy INTERFACE_METHOD_DELEGATE 141 → 4, UNRESOLVED_LOAD_STANDIN 212 → 112, OTHER 786 → 648.
    Class pointer giờ có kiểu, nên scaffolding quét interface trước là số nguyên không kiểu nay đọc thành
    `(nint)typeof(T)`.
- **REAL_REGRESSION**
  - **Còn lại:** `byte*` của buffer alloca gộp với `nint` trong một thanh ghi → local `object`. 14 lỗi trên năm
    fixture (Impostor 8). Lỗi thân Impostor 202 → 208 là phần này, cộng/trừ vài lỗi.
  - **Đã sửa trước khi đóng:**
    - Mô hình buffer của invoker mất `StackAlloc` (64 → 0 dòng viết lại ở 66e).
    - `(nint)stackalloc` (CS8346 ×20).
    - Block chết sau khi gập làm method đúng nguồn bị chấm FALLBACK.
    - Mở rộng store qua SP (66g/66h, xem dưới).
- **MEASUREMENT_CHANGE**
  - `recovery_contract.py` đọc một dump invoker vắng mặt thành "không có invoker" thay vì crash.
  - Stage D của `validate_unity_stages.py` đếm declaration pass. Ma trận lấy body pass.
- **UNKNOWN:** không có thay đổi nào chưa giải thích.

## Đã thử, đo được là âm — đừng làm lại theo cách này

**Giữ store qua SP sau ô bị lấy địa chỉ** (§7):
- 66g: JellyBlastV2 EXACT 4347 → 4149, vì thiết lập frame (`mov x29, sp`) là một address-take.
- 66h, sau khi loại thiết lập frame và lần lưu callee-saved: CS0122 Merge-Room 27 → 57, RunFromZombies EXACT
  2967 → 2908.

Các store giữ lại *đúng* là trường của state machine async được `Start(ref sm)` đọc qua địa chỉ. Nhưng struct sau một
địa chỉ chưa là một storage, nên chúng đi vào local riêng và lộ field private của framework. Phải mô hình "struct sau
một địa chỉ là một storage" trước.

## Runtime

Không có Unity trong container. Mọi stage runtime là `UNITY_NOT_AVAILABLE`; stage E–I là `BLOCKED`. Không có
`FULLY_RECOVERED`. Không fixture nào compile sạch: tỉ lệ file sạch từ 0.352 tới 0.783.

## Còn lại

Xem `ROADMAP.md` "Sau iteration 066".
