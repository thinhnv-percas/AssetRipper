# Iteration 065 — Body errors, invoker arguments, unresolved loads & native rebuild

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`.

Baseline là bản rip cuối của 064 (`Test/Out64j-{m,z,j,i,p,o}`), **đo lại bằng script cuối của 065**, nên một số số
của 064 khác số đã công bố. Ví dụ Impostor EXACT 4335 → 4351, do ba sửa phép đo ở §7. Kết quả là `Test/Out65z-*`, một
bản build duy nhất cho cả sáu fixture.

## Tóm tắt

Mỗi P0 được truy tới tầng đầu tiên nơi nghĩa binary ≠ nghĩa phục hồi:

| # | Triệu chứng (brief) | Tầng đầu tiên sai | Sửa |
|---|---|---|---|
| §2 | 684 lỗi thân Merge-Room | 18 họ producer, không phải một | 11 bản sửa producer; 324 còn lại, phân theo họ |
| §5 | 46 dispatch invoker chưa dựng được đối số | mảng `args` trên frame; store `args[1]` bị xoá như store chết | `InvokerArgumentRecovery`; 26 → **60** dòng viết lại với mọi đối số chứng minh được |
| §6 | 70 `UNKNOWN_CLASS_SOURCE` | **stack analysis**: frame pointer X29 của A64 chưa từng được resolve; dưới nó là `mov sp, x29` của epilogue và bản ghi frame của il2cpp | `StackAnalyzer.ResolveFramePointer`; `ArgumentReturningHelper`; 196 → **54** dòng |
| §7 | OBJECT_REFERENCE / load bỏ cuộc | producer, ở nhiều tầng | không đổi cast nào; stand-in producer 666 → 242 (Impostor), 2485 → 1087 (Merge-Room) |

Một lỗi im lặng **có từ trước** lộ ra trong lúc làm và đã được sửa. `SsaSimplifier` thay `&slot` bằng `&i`, khiến tham
số `i` của `MMSwap` bị ghi đè bằng con trỏ method của invoker (`i = 0;` trước `list[i]`). Detector mới:
`parameter_overwrite_scan.py`.

## 1. Body errors (§2–§4) — `reports/MERGE_ROOM_BODY_ERRORS_065.md`

Lỗi thân Merge-Room 684 → **324**. Mỗi họ giảm có pass sửa và độ tin cậy riêng; phần còn lại có ví dụ và bản sửa ứng
viên.

- **CS0030** 362 → 224, không thêm cast nào.
- **CS0122** 166 → 27, không đổi private → public. Phần lớn biến mất vì truy cập field private của framework được thay
  bằng thao tác mà nó là thành phần (`List<T>.Clear()`, field address của receiver).

Các bản sửa producer:
- vùng quét interface bị cắt cạnh dispatch đã giải;
- `InlineListClearRecovery`;
- frame receiver của method pointer theo bảng adjustor thunk;
- `FieldAddressArguments` cho receiver struct;
- trả về qua buffer ẩn;
- AAPCS64 C.10/C.11;
- `StructRegisterFields`;
- truyền giá trị cho composite > 16 byte;
- `ldvirtftn` cho delegate trên method interface;
- member trong static struct field.

## 2. Invoker arguments (§5) — `reports/INVOKER_ARGUMENT_RECOVERY_065.md`

Merge-Room có 30 dispatch viết lại trong 18 method, trong đó `MMSwap` dịch đúng nguồn, `ImmutableList<T>.get_Item` và
11 enumerator `get_Current`. Phần còn lại là `UNKNOWN_ARGUMENT`/`UNKNOWN_RETURN`, mỗi cái có lý do. Không đối số nào
được suy từ kích thước.

## 3. Class provenance (§6) — `reports/UNKNOWN_CLASS_PROVENANCE_065.md`

Ba tầng, mỗi tầng chỉ thấy được khi tầng trước đã sửa:

1. Helper khởi tạo class được chứng minh là trả về đối số từ chính word lệnh. Tự nó không đổi được dispatch nào.
2. Frame pointer X29 thành alias của stack. Đây là must-dataflow; method nào đọc X29 như giá trị bị bỏ nguyên (0 trên
   Merge-Room).
3. Hai lỗi lộ ra sau đó:
   - `mov sp, x29` của epilogue không được stack walk biết, nên restore sau một alloca động bị đặt tên lệch;
   - address-take của bản ghi frame il2cpp làm SSA mất giá trị `MethodInfo*` đã spill.

Kết quả: dispatch giải được 574 → 692. Trên JellyBlastV2 (iOS) có một họ khác: 2315 class operand nạp từ base trang
`adrp` cộng offset chưa được nhận là usage. Ghi lại làm mục tiêu kế tiếp.

## 4. Unresolved loads (§7) — `reports/UNRESOLVED_LOAD_RECOVERY_065.md`

`UNMANAGED_MEMORY_LOAD`, 64j → 65z:

| Fixture | 64j | 65z |
|---|---:|---:|
| Merge-Room | 14998 | 10198 |
| Impostor | 2486 | 2073 |
| RunFromZombies | 2171 | 1684 |
| JellyBlastV2 | 23475 | 22289 |
| Pinata | 7443 | 4493 |
| opt-in | 37618 | 35946 |

`resolved_producer_rate`: 0.2579 → 0.3731 (Impostor), 0.368 → 0.4047 (Merge-Room). "UnresolvedLoadRecovery" không
thành một pass gom chung: mỗi họ có một nguyên nhân ở một tầng khác, và một pass gom chung sẽ phải đoán.

## 5. Ref arguments qua field (§8)

`= ref *(` trong mã phục hồi, 64j → 65z:

| Fixture | 64j | 65z |
|---|---:|---:|
| Impostor | 44 | 44 |
| Merge-Room | 148 | 124 |
| JellyBlastV2 opt-in | 520 | 399 |

Phần giảm đến từ `FieldAddressArguments` (receiver kiểu giá trị, field struct qua con trỏ). 44 trên Impostor là base
field-load đã gập: cần `FieldReference` lồng làm base. Chưa làm.

## 6. Native, package, manifest (§9–§13)

- **RayFire** — `reports/RAYFIRE_STATIC_LIBRARY_PROVENANCE_065.md`. Archive SHA `9a375035…` có lát arm64 **trùng từng
  byte** với mã đã link vào `UnityFramework`: 34/34 entry point, 2920 word so, 0 khác. Đối chứng âm: 33/34 khác. Verdict
  `LINKED_ARCHIVE_PROVEN`; archive được giữ vào project kèm hồ sơ provenance. Không archive giả.
- **iOS `__Internal`** — `reports/IosNativeUnknown_065.md`:
  - Taptic 4/4 PROVEN.
  - Facebook 38/39 PROVEN.
  - GameAnalytics 50/53 PROVEN.

  Bằng chứng là mã wrapper, `LC_FUNCTION_STARTS`, bind opcode của dyld và metadata ObjC; đối chứng RayFire 35/35.
- **Package** — `reports/PACKAGE_MANIFEST_RECONSTRUCTION_065.md`:
  - Bốn package có version chứng minh được.
  - Burst và Collections là `UNKNOWN` (`SOURCE_MISMATCH`).
  - Newtonsoft là `UNKNOWN` với ứng viên {3.2.1, 3.2.2}: DLL của hai version trùng từng byte, nên không fingerprint
    nào chọn được.
- **Manifest** (§13): `recovered_project_manifest.py` nhận bằng chứng native và manifest reconstruction;
  `recovered_project_plan.py` biến manifest thành kế hoạch cho generator, giữ mọi dependency (không bỏ cái nào để
  compile). `iterations/065/manifest/`.

## 7. Runtime (§14–§15)

Không có Unity trong container: mọi stage chạy là `UNITY_NOT_AVAILABLE`; không `NOT_RUN` nào thành `PASS`, không có
`FULLY_RECOVERED`. Schema scenario/snapshot của 061–062 là thứ harness Original vs Recovered sẽ dùng.

## 8. Phép đo đã sửa (MEASUREMENT_CHANGE)

- Rendering viết static field (trần, hoặc trong comment của lệnh không có dạng) theo tên property mà export viết.
- `recovery_metrics.py` đếm `?.`, `??`, ternary là branch, và `0m`/`1m`/`-1m` là `decimal.Zero/One/MinusOne`.
- `LoadsCallOperands` trả "không" cho `IndirectCall`/`IndirectJump`, đúng cái generator emit. Bộ phân loại storage
  hazard trước đó đếm địa chỉ cũ trong danh sách thanh ghi thô như một lần lấy địa chỉ.

## 9. Số liệu (§16, §18)

Cả hai đầu đều đo bằng script cuối.

| Fixture | EXACT | FALLBACK | Placeholder | Roslyn A-CSharp (body pass) | Golden improved / regressed |
|---|---|---|---|---|---|
| Impostor | 4351 → **4474** | 154 → **63** | 3864 → 3440 | 237 → **202** | 22 / 3 (cả ba có từ 064) |
| Merge-Room | 11658 → **11923** | 396 → **221** | 23789 → 18601 | 684 → **324** | 16 / 1 (MMFeedbacks, có từ 062) |
| RunFromZombies | 2935 → **2967** | 85 → **59** | 4405 → 3902 | 7 → 7 | 21 / 2 (ConvertUtils có từ 064; JsonValidatingReader mới, xem dưới) |
| JellyBlastV2 | 3100 → **3127** | 39 → **18** | 36141 → 34947 | 3005 → **2599** | 8 / 0 |
| Pinata | 12907 → **13150** | 337 → **286** | 11734 → 8786 | 1297 → **1146** | — |
| JellyBlastV2 opt-in | 5308 → 5357 | 61 → 30 | 56398 → 54695 | — | 8 / 0 |

Bất biến (§18):
- generatorFailures 0, field-layout disagreement 0, MonoBehaviour layout mismatch 0 trên cả sáu.
- RunFromZombies behaviour **1.0000** (35/35).
- Oracle độc lập JellyBlast 0.6817 → **0.6862** (912/1329).
- **TrueAlias không tăng**: Merge-Room 0 → 0, Impostor 1 → 0, JellyBlastV2 2 → 0, opt-in 3 → 0.
- Parameter overwrite: 0 trên Merge-Room/Impostor/RunFromZombies/Pinata. JellyBlastV2 có 1, là dương tính giả của
  scanner và có cả ở baseline.

### Phân loại thay đổi

- **NEW_COVERAGE**:
  - alias frame X29;
  - helper trả đối số;
  - invoker arguments;
  - List.Clear, buffer ẩn, C.10/C.11, struct register fields, static struct members, `ldvirtftn`.
  - `Unknown` storage hazard tăng (Merge-Room 51 → 57) vì nhiều ô frame có tên hơn. Đây không phải TrueAlias.
- **MEASUREMENT_CHANGE**: §8.
- **REAL_REGRESSION**:
  - **Đã sửa trước khi đóng:** `MMSwap` mất dispatch rồi bị ghi đè tham số, khi alias frame vừa bật.
  - **Còn lại:**
    - `ExtensionList.cs` +3 lỗi trong một thân fully shared có alloca động (`sub sp, sp, xN`, không `ShiftStack`
      nào mô hình được). `LayerMaskExtension.cs` −9 cùng lúc.
    - RunFromZombies `JsonValidatingReader` EXACT → HIGH_CONFIDENCE: một local chưa gán được khai báo `object` thay vì
      `IntPtr`, giá trị không đổi.
- **UNKNOWN**: không có thay đổi nào không giải thích được.

## 10. Còn lại

Xem `ROADMAP.md` "Sau iteration 065".
