# Iteration 062 — interface dispatch, shader variant selection, storage alias, Unity build stages

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`. Baseline: bản rip cuối của 061
(`Out61l-z`, `Out61m-m`, `Out61h-j`, `Out61i-i`, `Out61j-p`), đo lại bằng đúng các script dưới đây —
không phép đo nào đổi định nghĩa ở iteration này ngoài những gì ghi ở §6. Kết quả: `Test/Out62m-*`.

## Tóm tắt

Iteration không tối ưu số placeholder. Nó đi tìm điểm đầu tiên nơi nghĩa binary khác nghĩa phục hồi,
theo bốn mục P0 của brief, và ở cả bốn nơi điểm đó nằm sớm hơn chỗ triệu chứng hiện ra:

| # | Triệu chứng | Tầng đầu tiên sai | Sửa |
|---|---|---|---|
| 1 | 340 interface dispatch trên Merge-Room chưa giải quyết | một immediate (slot) trỏ vào header ELF được giải mã thành metadata usage | `IsVirtualAddressWritable`: usage slot luôn ghi được |
| 2 | material vẽ bằng base variant | export ghi một program mỗi pass | mọi variant dưới guard keyword chính xác, scope từ `KeywordFlags` |
| 3 | 1–8 TrueAlias mỗi fixture | struct generic không có size, nên `List<T>.Enumerator` trả qua buffer không được nối với call | `GenericInstanceFieldLayout.ValueTypeSize`, frame, `StructSlotAliasRecovery` |
| 4 | "Unity exited 1" | một status cho sáu stage | `UnityBuildStages`, mỗi stage một bằng chứng |

## 1. Interface dispatch (§3–§8) — `reports/INTERFACE_DISPATCH_RECOVERY.md`

`PROVEN`: slot của helper lookup (`Move X2, 29`) bị `MetadataResolver` đọc thành `typeof(T)` vì từ v27
một usage được giải mã từ giá trị tại địa chỉ và 29 ánh xạ vào header ELF. Một usage slot là global
runtime điền vào, nên luôn nằm trong vùng ghi được; `Il2CppBinary.IsVirtualAddressWritable` (ELF,
Mach-O) trả lời điều đó. Cùng lỗi đọc sai hằng số ở những chỗ không liên quan tới interface, mỗi chỗ
kiểm được với source: `DataType.Quaternion`, `IndexOf(text, 'E')`, các khoá `MMColors`,
`Ease.INTERNAL_Custom`, bitmask `61559`.

Slot → method theo `Il2CppMethodDefinition.slot` (0 khác biệt đo được với vị trí, làm cứng); dispatch ở
tail position; một hàng bằng chứng mỗi call (966 hàng); regression corpus 60 entry chọn từ chính bằng
chứng, xanh trên 062, 12 NOT_NAMED trên 061. Dispatch giải quyết: 48/505/177/36/90 → 52/551/179/56/128.

## 2. Shader variant selection (§9–§14) — `reports/SHADER_VARIANT_RUNTIME_FIDELITY.md`

Mọi variant của pass dưới guard là đúng tập keyword nó được compile cho; trạng thái build gốc không
compile rơi vào `#error VARIANT_SELECTION_UNKNOWN`. Không chọn first/base/nearest. Identity của program
là content hash; `ShaderVariants.json` mang backend/stage/blob/byte range/hash. Scope keyword đọc từ bit
0 của `m_KeywordFlags` (16/16 đồng ý với pragma nguồn). Tier bất đồng thì không nhúng.

`shader_variant_fidelity.py` đánh giá chuỗi guard thật với mọi tổ hợp keyword engine: Impostor **9/9**,
Merge-Room **29/30** EXACT (061 binding 0.5556 và 0.8000). Hoán đổi hai guard cho 3 `WRONG_PROGRAM`.

## 3. Storage alias hazards (§15–§18) — `reports/STORAGE_HAZARD_ANALYSIS.md`

`StorageHazardClassifier` cho mỗi hazard một kết luận (`TrueAlias`/`SpillAlias`/`Copy`/`Reuse`/
`NonAlias`/`Unknown`), thứ tự chỉ trong một block, qua block chỉ reachability. Đọc các TrueAlias cho
họ lỗi `foreach` lặp trên enumerator mặc định — compile được, không làm gì — với ba nguyên nhân chồng
nhau, sửa từ tầng đầu: size của struct generic (kiểm chéo với machine code: X8 giữ địa chỉ stack ở
261/601/159/282 call, không ở 0/0/2/2 — và 20 trên 62 ở Pinata, **UNKNOWN**), frame của offset struct
generic, và aliasing word-trong-struct sau khi địa chỉ được giao, chỉ khi có provenance.

`MoveNext` trên enumerator chưa từng gán: 113/244/30/95/126 → 5/5/5/0/112.

## 4. Unity build (§20–§21) — `reports/UNITY_BUILD_VALIDATION.md`

Sáu stage (`PROJECT_DISCOVERY`…`RUNTIME`), mỗi stage quyết định trên bằng chứng riêng; exit code một
mình không quyết định stage nào; `RUNTIME` không bao giờ do build quyết định. Container không có Unity:
`UNITY_NOT_AVAILABLE`, discovery `PASSED`, bốn stage `NOT_REACHED`, runtime `NOT_RUN`. **BLOCKED**.

## 5. Số liệu (§26)

| Fixture | EXACT | PARTIAL | placeholder | UNMANAGED_LOAD | INDIRECT_CALL | INDIRECT_JUMP | file `.cs` đổi |
|---|---|---|---|---|---|---|---:|
| Impostor | 4011 → 4027 | 1083 → 1066 | 4149 → 4291 | 2419 → 2565 | 183 → 183 | 56 → 54 | 75 |
| Merge-Room | 11131 → 11184 | 3493 → 3447 | 26380 → 25580 | 17132 → 16469 | 865 → 800 | 357 → 337 | 374 |
| RunFromZombies | 2770 → 2785 | 752 → 743 | 4642 → 4578 | 2360 → 2303 | 152 → 154 | 132 → 126 | 38 |
| JellyBlastV2 | 3005 → 3014 | 4311 → 4302 | 36566 → 36304 | 23839 → 23598 | 1228 → 1228 | 532 → 522 | 91 |
| Pinata | 12526 → 12526 | 2748 → 2751 | 13048 → 12974 | 7693 → 7657 | 521 → 521 | 408 → 389 | 56 |

Placeholder Impostor tăng: nơi 061 có một null lặng lẽ (`default(Dictionary<string, object>)`, vì
vòng lặp không bao giờ chạy) giờ là một unresolved load được báo. Đó là hướng §31 yêu cầu.

## 6. Bất biến (§27)

| Bất biến | Kết quả |
|---|---|
| `generatorFailures = 0` | **0** trên cả năm fixture |
| field-layout disagreement = 0 | **0 disagreed** trên cả năm |
| RunFromZombies source behavior | **1.0000 (35/35)**, như 061 |
| reference graph true mismatch không tăng | giống hệt bản rip cuối 061 trên cả ba fixture có source (match rate 1.0 / 1.0 / 0.9986) |
| golden corpus regression = 0 | **KHÔNG giữ được về con số**: Impostor 3, Merge-Room 1 — xem dưới |

Bốn regression đã được đọc từng cái:

- `GUIManager.TurnOnOffSound` EXACT → FALLBACK: thân C# **đúng hơn** — 061 lặp enumerator mặc định và
  gán `volume` cho `default(AudioSource)`; 062 gán cho từng `_current`. Metric hạ nó vì một đoạn IR vô
  nghĩa (hai throw helper bị nhận nhầm là `Dispose`) giờ đọc `[v418 + 0]` là field `_list`, một tên C#
  không bao giờ phát ra vì đoạn đó không được emit. Lỗi của phép đo, không phải của bản phục hồi.
- `AnimationMatchModifierAsset`, `Skin.AddSkin`, `MMFeedbacks` → PARTIAL: `default(Timeline)`,
  `default(MeshAttachment)`, `default(Object)` lặng lẽ được thay bằng một unresolved load báo ra
  (`[X8 + 0x10]`, phần tử đọc qua một thanh ghi giữ địa chỉ enumerator mà định nghĩa không phải một
  `&slot` trực tiếp).

Không cái nào là một thân tệ đi. Chúng được ghi là regression của phép đo, không được che đi, và
golden baseline **không** được đóng băng lại.

Golden corpus RunFromZombies 194/194 và JellyBlastV2 222/222: 0 regression. Shape check: tất cả pass
trên 062; hai check `DECOMP-0015` được neo lại vào kiểu thay vì vào tên biến có số thứ tự của ILSpy
(chúng hỏng vì biến `enumerator` thành `enumerator2` khi vòng lặp được khôi phục đúng).

## 7. Còn mở

- 3 TrueAlias: một enumerator Spine tái dùng ô sau `Dispose`; hai word float trước
  `Matrix4x4.op_Multiply` (buffer trả về 64 byte).
- Pinata: 20/62 call trả struct generic qua buffer mà X8 không giữ địa chỉ stack; `MoveNext` trên
  enumerator mặc định chỉ giảm 126 → 112.
- Phần tử đọc qua một thanh ghi mà định nghĩa không phải `&slot` trực tiếp (bản sao, phi).
- 505 vùng quét `ValueEscapes` trên Merge-Room, phần lớn lấy class interface từ RGCTX.
- Unity, runtime scenario, so sánh runtime với bản gốc: **BLOCKED**.
