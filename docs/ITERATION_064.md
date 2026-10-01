# Iteration 064 — Runtime semantic recovery & Unity executable reconstruction

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`. Baseline: bản rip cuối của 063
(`Test/Out63g-{z,m,j,i,p}`, `Test/Out63o3-i`), đo lại bằng cùng script. Kết quả: `Test/Out64j-*` (mặc định) và
`Test/Out64j-o` (JellyBlastV2 với `CPP2IL_RECOVER_ALSO`, chỉ để đo oracle độc lập).

## Tóm tắt

Brief đặt bốn P0. Mỗi cái được truy tới tầng đầu tiên nơi nghĩa binary ≠ nghĩa phục hồi, và ba trong bốn tầng
đó không phải tầng brief nêu tên:

| # | Triệu chứng | Tầng đầu tiên sai | Sửa |
|---|---|---|---|
| 1 | `currentValue = ref *(Color*)newValue` (SetColor) | field search không nhìn qua `T&`; store tại `[ref+0]` là `starg` | `ValueTypeReferent`; `stobj`/`ldobj` qua managed reference; `ValueFlow` |
| 2 | "class interface đến từ RGCTX" (505 vùng) | một nửa: **ABI** — thân fully shared nhận `il2cppRetVal` trước `MethodInfo`; nửa kia: dispatch qua `invoker_method` | `FullGenericSharing`; `RuntimeInterfaceResolver` phân loại |
| 3 | OBJECT_REFERENCE nint cast | một nửa producer là `default(object)` của load bỏ cuộc | đo (`--trace`, `resolved_producer_rate`); sửa ở producer khác (1, 2) |
| 4 | Merge-Room CS0102 | CAS runtime chưa map nên accessor không bao giờ là field-like; field event bị widen vì body inline đọc nó | `CompareExchangeRecovery` (theo lệnh, overload theo call site); accessor chuẩn khi mọi hiệu ứng đã chứng minh; field mang tên backing của compiler |

Cộng một tầng ngoài brief: `FieldAddressArguments` — đối số `object + k` cho tham số `ref T` là `&field`.

## 1. Value flow (§1–§3) — `reports/VALUE_FLOW_RECOVERY.md`

`SetColor` giờ đúng nghĩa: so sánh từng member, ghi từng member qua tham chiếu. `ValueFlow`
(`ValueKind`, `StoreSemantics`, `LoadSemantics`) là luật chung; `RebindReference` là bất biến được bảo vệ.
Gán lại ref: Impostor 143 → 44, Merge-Room 842 → 148, JellyBlast opt-in 1000 → 520, Pinata 172 → 80. Shape
check DECOMP-0022 của 059 đã đóng băng chính hình dạng sai (`key = ref *(byte*)…`) và được sửa;
`TimeCheatingDetector.FillRequestResult` giờ ghi `result.success = …` thay vì `result = ref *(…)1`.

## 2. Runtime generic context (§4) — `reports/RUNTIME_GENERIC_CONTEXT.md`

`FullGenericSharing`: thân là fully shared khi một instantiation *tại cùng địa chỉ* mang
`__Il2CppFullySharedGenericType` (bằng chứng metadata). 182 thân Merge-Room, 30 RunFromZombies, 19 Impostor,
3 JellyBlast, 0 Pinata (2019.2). Dispatch giải quyết qua lookup (phân biệt, Merge-Room) 251 → 263;
`InterfaceOf` nhận usage kiểu đưa thẳng làm đối số (Pinata INDIRECT_CALL 521 → 335, INDIRECT_JUMP 389 → 220).
152 dispatch còn lại được phân loại theo đường/nguồn/lý do và ghi vào `CPP2IL_DUMP_INTERFACE_CALLS`
(`UNRESOLVED`). Không vùng quét nào bị xoá, không RVA nào bịa.

## 3. OBJECT_REFERENCE (§5)

`cluster_native_int_casts.py --trace` đi từ cast ngược về producer. Impostor: 666/1298 là
`UNRESOLVED_LOAD_STANDIN`; `resolved_producer_rate` 0.2579 (Impostor), 0.368 (Merge-Room). Tổng nint cast
2874 → 2544 (Impostor), 13296 → 13002 (Merge-Room) — từ producer (CAS, ref), không từ cast patching.

## 4. List/array (§6), ABI (§7)

Không đổi luật affine (062). ABI: đường `il2cppRetVal` (§2) là hồi quy ABI mới; AAPCS64 C.3/Apple packing của
063 giữ nguyên trên Impostor, JellyBlast, Pinata (EXACT không lùi ở cả ba).

## 5. Native, package, serialize, shader (§8–§11)

- `native_dependency_graph.py` — `reports/NATIVE_DEPENDENCY_GRAPH_064.md`: RayFire `libRF_CNative_ios.a`
  `STATIC_LIBRARY` / `LINKED_STATIC_NOT_EXTRACTABLE` (34/34 entry point trong `UnityFramework` và trong archive);
  6 Facebook framework PRESERVED; 3 nhóm `__Internal` UNKNOWN (symbol đã strip).
- `package_provenance.py` — `reports/PACKAGE_PROVENANCE_064.md`: TMP, UGUI, Mathematics, VisualScripting
  `UPSTREAM_EXACT` với version chứng minh; Burst, Collections `UPSTREAM_VERSION_MISMATCH`; Newtonsoft `UNKNOWN`.
- `SerializedFieldPolicy` + 8 test: widen không bao giờ đổi việc Unity serialize; fingerprint layout trước/sau
  bằng nhau. MonoBehaviour layout mismatch 0 trên cả năm fixture.
- Shader: Metal giữ là MSL ngoài ShaderLab; `shader_variant_binding.py` gắn material → keyword → biến thể từng
  stage → file `.metal`: JellyBlast `EXTERNAL_PROGRAM_EXACT` 37, `MODULO_ENGINE` 2, rate 1.0 trên 39; không có
  biến thể gần nhất.

## 6. CS0102, manifest, runtime (§12–§15) — `reports/UNITY_RUNTIME_READINESS_064.md`

- CS0102 hết. `CompareExchangeRecovery` 318 (Merge-Room), 686 (Impostor), 476/476 (Pinata), 74 (JellyBlast);
  accessor chuẩn cho 78 / 168 / 117 / 15 event. Field của event interface yêu cầu và bị đọc từ ngoài mang tên
  `<Name>k__BackingField` (1 Merge-Room, 53 Impostor). **Merge-Room Assembly-CSharp lần đầu bind được: lỗi
  thân thật là 684** (46/84 file sạch) — số cũ "1" là lỗi khai báo che, lần thứ năm điều này được ghi.
- `RecoveredProjectManifest.json` cho năm fixture (`recovered_project_manifest.py`).
- Stage và scenario: `UNITY_NOT_AVAILABLE`, runtime `NOT_RUN`; scenario có `message`/`frame`, `expected_state`
  UNKNOWN.

## 7. Số liệu (§16)

| Fixture | EXACT | Placeholder | FALLBACK | Roslyn Assembly-CSharp (body pass) | Golden improved / regressed |
|---|---|---|---|---|---|
| Impostor | 4042 → **4335** | 4301 → 3864 | 170 → 170 | 237 → 237 | 11 / 3 (cùng ba cái 062) |
| Merge-Room | 11221 → **11484** | 25697 → 23789 | 565 → 573 | 5 (1) → 4 (**684**, lần đầu đo được) | 6 / 1 (MMFeedbacks, như 062) |
| RunFromZombies | 2785 → 2820 | 4581 → 4405 | 201 → 201 | 7 → 7 | 15 / 1 (MEASUREMENT_CHANGE) |
| JellyBlastV2 | 3027 → 3056 | 36383 → 36141 | 84 → 84 | 11 (3038) → 11 (3005) | 9 / 0 |
| Pinata | 12533 → **12790** | 12990 → 11734 | 456 → 454 | 1355 → 1297 | — |

Cả hai đầu đo bằng `recovery_metrics.py` cuối cùng (sau ba sửa phép đo của iteration này); số của 063 không
đổi khi đo lại. Merge-Room FALLBACK +8 đã đọc từng cái: 9 method Cinemachine (`ref LensSettings lens`) từ PARTIAL
— load qua tham chiếu giờ giải quyết, placeholder hết, và phép kiểm tên gặp `zeroVector` mà generator viết qua
property `Vector2.zero`; 1 `TraceJsonReader.HasLineInfo` từ `((IJsonLineInfo)flag).HasLineInfo()` (sai) thành
`jsonLineInfo?.HasLineInfo()` mà metric không đếm `?.` là branch.

Bất biến: generatorFailures 0, field-layout disagreement 0, MonoBehaviour layout mismatch 0 trên cả năm;
RunFromZombies behaviour 1.0000 (35/35); oracle độc lập JellyBlast 0.6802 → 0.6817 (906/1329); TrueAlias không
đổi (Impostor 1, JellyBlastV2 1 ví dụ cùng chỗ).

### Phân loại thay đổi (§16)

- **NEW_COVERAGE**: CAS → `CompareExchange<T>`; `il2cppRetVal`; `InterfaceOf` cho usage đưa thẳng;
  `FieldAddressArguments`; ghi qua ref.
- **MEASUREMENT_CHANGE**: (a) accessor event gập thành `public event T X;` không còn thân để đo — số method đo
  được giảm đúng bằng số accessor (Impostor 8782 → 8720 địa chỉ, 31 event field-like); một decompiler đổi tên
  field trùng tên event thành `m_X` và metric giờ đọc `m_X` là X; (b) `recovery_metrics`
  bỏ dòng bị cắt (`JsonArrayContract`); (c) `_003CX_003Ek__BackingField` được đọc là X; (d) RunFromZombies
  `ConvertUtils.TryConvert` EXACT → HIGH_CONFIDENCE vì `value = ref *(object?*)null` (sai) thành `object obj =
  null; value = obj;` (đúng) với một local `object` mà metric đếm là untyped; (e) Merge-Room 684 lỗi thân.
- **REAL_REGRESSION**: không có. Bốn golden regression còn lại là bốn cái đã đọc ở 062/063.
- **UNKNOWN**: không có thay đổi nào không giải thích được.

## 8. Còn lại

Xem `ROADMAP.md` "Sau iteration 064": invoker dispatch (46), lỗi thân Merge-Room (684), OBJECT_REFERENCE ở
producer (load không giải quyết), `ref` qua field gập, class operand không nguồn, package stub chưa khai báo
manifest, native `__Internal` UNKNOWN.
