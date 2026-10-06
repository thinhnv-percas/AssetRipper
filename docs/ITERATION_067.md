# Iteration 067 — Semantic storage, compile recovery & clean C# output

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`, `UNITY_NOT_AVAILABLE`.

Baseline là bản rip cuối của 066 (`Test/Out66i-{z,m,i,j,p,o}`), **đo lại bằng script cuối của 067**. Kết quả là
`Test/Out67x-*`: một bản build cho cả sáu fixture, cộng hai bản rip của cùng bản build với tuỳ chọn khác:
- `67xk-i`: JellyBlastV2 với `--package-cache`;
- `67xn-j`: RunFromZombies với `--no-cpp2il-injected-attributes`.

Bản rip trung gian (67a–67h) chỉ dùng để quy thay đổi về nguyên nhân.

## Tóm tắt

| § | Brief | Tầng đầu tiên sai | Sửa | Báo cáo |
|---|---|---|---|---|
| §2 | CS0122 `m_builder`, struct trên stack | stack analysis: một struct là nhiều local theo offset; DCE xoá trước khi biết kiểu | giữ tạm + `StackStructStorage` sau fixpoint kiểu; độ rộng store thật (`StackOffset.Size`) | `STRUCT_STORAGE_IDENTITY_067.md` |
| §3 | `= ref *(` | type: tham số lấy kiểu theo thứ tự đếm; địa chỉ field giữ lại | `ParameterIndex`; `RecoverAddressDefinitions`; store qua ref nạp ref trước | `FIELD_REFERENCE_PROVENANCE_067.md` |
| §4 | `UNKNOWN_RETURN` | mô hình buffer không ghi use làm vỡ nó | `T_BUFFER_USED_BY:<use>` | `INVOKER_BOX_RETURN_067.md` |
| §5–§8 | bốn họ P0 Merge-Room | (nhiều) | write barrier iOS (pre-indexed); receiver chia sẻ | `MERGE_ROOM_BODY_ERRORS_067.md` |
| §9 | `byte*` + `nint` | phi của con trỏ với số nguyên không có kiểu | phi word máy → `IntPtr` | `FIELD_REFERENCE_PROVENANCE_067.md` §4 |
| §10 | carry unsigned | `FlagConditionRecovery`: C hạ bằng so sánh có dấu | `Instruction.IsUnsigned` → `clt.un`/`cgt.un`; `Arm64FlagLifting` | `UNSIGNED_FLAGS_067.md` |
| §11 | package manifest | export chỉ ghi module built-in | `proven_package_cache.py` + `PackageRemapPostExporter` có sẵn | `PACKAGE_MANIFEST_067.md` |
| §12 | Cpp2ILInjected attributes | — | tuỳ chọn ở tầng cài layer | `CPP2IL_INJECTED_OUTPUT_067.md` |
| §13 | `global::` | — | transform syntax tree, kiểm va chạm | `GLOBAL_QUALIFICATION_067.md` |
| §14 | gộp tuỳ chọn | — | `RecoveredCodeOutputOptions`, CLI, GUI | hai báo cáo trên |
| §15–§17 | compile, Unity gate | — | đo | `BUILDABILITY_067.md` |

## Số liệu (66i → 67x, cả hai đầu đo bằng script cuối)

`recovery_metrics.py` được sửa ở 067 (xem "Measurement change" bên dưới), nên cột EXACT/FALLBACK của 66i ở đây khác
con số đã công bố trong `docs/ITERATION_066.md`.

| Fixture | EXACT | FALLBACK | Placeholder | Lỗi thân Roslyn (A-CSharp) | File sạch | Golden +/− |
|---|---|---|---|---|---|---|
| Impostor | 4447 → 4449 | 57 → 56 | 3382 → 3406 | 208 → **194** | 0.625 → 0.641 | 22/3 → 22/2 |
| Merge-Room | 11944 → 11954 | 214 → 212 | 18148 → 18142 | 310 → **298** | 0.595 → 0.607 | 16/2 → 16/2 |
| RunFromZombies | 2933 → 2934 | 57 → 57 | 3859 → 3859 | 7 → 7 | 0.783 → 0.783 | 22/3 → 22/2 |
| JellyBlastV2 | 4330 → **5258** | 27 → 38 | 16619 → **12587** | 2599 → **1982** | 0.352 → 0.453 | 25/2 → 31/2 |
| Pinata | 12972 → 12971 | 265 → 265 | 8442 → 8442 | 1144 → 1136 | 0.645 → 0.646 | — |
| JellyBlastV2 opt-in | 7108 → **8510** | 63 → 115 | 25551 → **19343** | — | — | 25/2 → 31/2 |

| Hình dạng | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata | opt-in |
|---|---|---|---|---|---|---|
| `= ref *(` | 35 → 21 | 111 → 85 | 35 → 24 | 213 → 149 | 58 → 27 | 440 → 275 |
| `global::` | 18 → 18 | 36 → 0 | 1 → 0 | 0 → 0 | 4 → 0 | 0 → 0 |
| kickoff `)->Start(ref` | 3 → 1 | 18 → 1 | 88 → 14 | 11 → 0 | — | — |
| so sánh unsigned `(uint)x < Nu` | 0 → 87 | 0 → 565 | 0 → 253 | 0 → 369 | 0 → 695 | 0 → 603 |

Bất biến (§18), trên cả sáu:
- generatorFailures 0, field-layout disagreement 0, MonoBehaviour layout mismatch 0.
- **TrueAlias 0.** Chỉ có NonAlias và Unknown.
- **Parameter overwrite bởi stand-in 0.** Merge-Room có 9 tham số `out`/`ref` được ghi một giá trị không giải được; xem
  MEASUREMENT_CHANGE.
- RunFromZombies behaviour **1.0000** (35/35).
- Oracle độc lập JellyBlast **0.7594 → 0.7864** (1013/1334 → 1049/1334), không thấp hơn ngưỡng 0.7594.

## Phân loại thay đổi (§20)

### NEW_COVERAGE

- **Write barrier của iOS** (`str xT, [x0, #k]!` pre-indexed).
  - JellyBlastV2 `Method not found @F3F1B4` 3615 → 0; METHOD_NOT_FOUND 6354 → 2854.
  - OBJECT_AS_NATIVE_INT 608 → 221 lỗi thân.
  - Đây là phần lớn của EXACT 4330 → 5258 và placeholder 16619 → 12587.
- **Struct trên stack là một storage.** Kickoff async dạng con trỏ 120 → 16 trên bốn fixture; `m_builder` JellyBlastV2
  25 → 0.
- **Carry unsigned chính xác.** Hàng trăm so sánh unsigned trên mỗi fixture. Lỗi giá trị sai im lặng có từ trước;
  không aggregate nào thấy nó.
- **Tham số lấy kiểu của chính nó** (`ParameterIndex`), cùng địa chỉ field nơi được định nghĩa: `= ref *(` giảm trên
  cả sáu.
- **Receiver không lấy kiểu từ callee chia sẻ có placeholder:** SHARED_GENERIC_PLACEHOLDER 28 → 9 / 45 → 7 / 57 → 1.
- **`global::` gỡ ở nơi không va chạm** (Merge-Room 36 → 0). **Tuỳ chọn Cpp2ILInjected** (22511 attribute → 0 khi
  tắt). **Package đã chứng minh vào manifest** (3 trên JellyBlastV2 với cache).

### EXPECTED_CHANGE

- **FRAMEWORK_PRIVATE_MEMBER tăng:** Impostor 9 → 48, Merge-Room 24 → 38, JellyBlastV2 262 → 309. Đó là cùng các lần
  đọc `_list`/`_current`/`_dictionary` của enumerator inline, giờ đúng kiểu; trước đây chúng nằm trong
  SHARED_GENERIC_PLACEHOLDER.
- **Impostor UNMANAGED_MEMORY_LOAD +24**, gần hết ở `SkeletonJson.cs` (+22). Ở 66i enumerator của một `Dictionary`
  mang kiểu `List<object>.Enumerator` và đọc ra `enumerator._dictionary = (Dictionary)enumerator4._list`, tức một kiểu
  cụ thể sai. Giờ cùng các lần đọc là load không giải được, báo ra. Một unknown trung thực đổi lấy một kiểu sai.
- **FALLBACK JellyBlastV2 27 → 38, opt-in 63 → 115.** 14 method chuyển sang FALLBACK, 11 trong đó từ PARTIAL vì
  placeholder biến mất nên phép kiểm tên chạy lần đầu. Các ca đã đọc đều là body *đúng hơn*, nhưng decompiler làm
  mảng thành ngầm định:
  - `String.Concat(string[])` thành `"H:" + text + …` (`HSBColor.ToString`);
  - một mảng `params` thành đối số trực tiếp (`Utilities.GetValueOrDefault`; ở 66i thân này ghi `key` vào
    `(IDictionary)(array + 32)`).

  Phép kiểm không thấy `ARRAY_WRITE` của một mảng không còn trong văn bản. Đây là giới hạn của phép đo, ghi cho 068.
- **Golden:** mọi regression còn lại đã có từ 066 (Impostor `AnimationMatchModifierAsset`, `Skin`; Merge-Room
  `MMFeedbacks`, `DateTimeUtils`; RunFromZombies `JsonValidatingReader`, `DateTimeUtils`). Hai regression được sửa:
  `GUIManager` và `ConvertUtils`. Không có regression golden mới.

### REAL_REGRESSION

- **Pinata `FBSDKViewHiearchy.CheckPathMatchPath`: EXACT → HIGH_CONFIDENCE**, và thân lặp giờ *sai*.
  - Machine code: `mov w?, #-1` rồi `cmn` với một số đếm và `b.hs`.
  - Carry chính xác của ADDS là `(a + b) <u a`. Nhưng `-1` của một thanh ghi W đến generator như immediate
    `0xFFFFFFFF` không có kiểu, nên thành `long` 4294967295.
  - Phép cộng và phép so sánh vì vậy chạy ở 64 bit, và cờ không bao giờ bật như ở 32 bit.
  - Ở 66i, phép so sánh có dấu với một toán hạng `int` đã gieo kiểu `int` cho counter, nên đúng một cách tình cờ.

  Hình dạng `Unsafe.As<object, UIntPtr>`: Pinata 40 → 42, các fixture khác không đổi. Sửa ở 068: lifter phải mang độ
  rộng W vào immediate, hoặc phép so sánh unsigned gieo kiểu theo độ rộng thanh ghi. Đừng hạ carry về dạng có dấu.
- **Đã sửa trước khi đóng:**
  - Matrix4x4 chép bằng store vector bị gọi là store member (67b): độ rộng thật.
  - Hai guard đổi tên `ResolveCallsViaMethodInfo` và một guard `PropagateFromCallParameters` (67f–67h, EXACT Merge-Room
    11973 → 11882): đã revert.

### MEASUREMENT_CHANGE

- **`recovery_metrics.methods()` ghép accessor auto-property đã gập với member sau nó.**
  - Gỡ write barrier làm thêm 30 setter trên JellyBlastV2 thành `get;`/`set;`.
  - Reader không dừng ở accessor không thân, nên lấy `NativeSource` và thân của member kế tiếp. Ví dụ getter
    `FacebookLogger.Instance` bị chấm FALLBACK vì "mất" `new` của static constructor bên dưới.
  - Giờ accessor không thân bị bỏ qua, như accessor event đã gập ở 064. Self-test có case đỏ nếu bỏ sửa.

  Cả hai đầu đã đo lại. EXACT 66i JellyBlastV2 công bố 4349 thành 4330 khi đo lại. Hai golden JellyBlastV2
  (`ResultBase`, `JsonConvert`) đọc EXACT → PARTIAL ở **cả hai đầu**: baseline golden được đóng băng bằng reader cũ.
- **`parameter_overwrite_scan.py` tách tham số `out`/`ref`.** Store qua `out` giờ đúng thứ tự, nên scratch local không
  còn che dạng `index = <không giải được>`. Merge-Room 9: không phải ghi đè tham số by-value.

### UNKNOWN

- Lý do `StackStructStorage` để nguyên 13 kickoff `AsyncTaskMethodBuilder<object>` của RunFromZombies: pass chỉ có
  counter tổng.
- Rule gán kiểu `Il2CppMethodInfo` cho entry value `v39 @ X3` dẫn tới `0xF7087C` → `Utilities.TryGetValue`.
- `0xE6A35C` (RunFromZombies) và `0x179CE74` (Merge-Room): helper nhận buffer của invoker, chưa định vị.

## Đã thử, đo được là âm — đừng làm lại theo cách này

Ba guard quanh lookup `0xF7087C` bị đặt tên sai:
- không đổi tên khi method có thân ở chỗ khác;
- không đổi tên khi địa chỉ nằm ngoài vùng mã managed;
- không gán kiểu entry value không định nghĩa từ `PropagateFromCallParameters`.

Hai cái đầu chặn cả lần đổi tên đúng (METHOD_NOT_FOUND tăng, EXACT Merge-Room 11973 → 11882). Cái thứ ba chặn sai
rule. Tìm rule trước.

## Runtime

Không có Unity trong container. Stage E–I là `BLOCKED (UNITY_NOT_AVAILABLE)`. Không có `FULLY_RECOVERED`. Không
fixture nào compile sạch. Trạng thái là `PROJECT_GENERATED_COMPILE_IMPROVED`: tỉ lệ file sạch tăng trên bốn fixture, không
lùi trên fixture nào.

## Còn lại

Xem `ROADMAP.md` "Sau iteration 067".
