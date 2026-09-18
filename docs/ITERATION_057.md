# Iteration 057 — một nguồn sự thật, và cấu trúc shader thật

## 1. Baseline (§1, §2)

Bốn fixture. Baseline là bản rip cuối của 056 (`Test/Out56F-*`), đo lại bằng chính phép đo của 057.
Bản rip của 057 (`Test/Out57H-*`) chạy sau khi process thoát.

**Method recovery không đổi một byte nào**: EXACT 2513 / 3782 / 7671 / 2867, FALLBACK 150 / 346 / 386 /
44, placeholder 5962 / 4293 / 37.507 / 38.236 — giống hệt baseline trên cả bốn fixture, và
`diff_recovered_scripts.sh` báo `only-in-one: 0  content-differs: 0` cho phần `.cs`. Đó là kết quả
đúng: 057 không đụng vào recovery của method. Nó đổi (a) *cách đo* và (b) *shader và native plugin*.

Invariant: `generatorFailures` 0 cả bốn; field-layout disagreement 0 cả bốn; golden corpus **0/0** cả
bốn; source oracle RunFromZombies `semantic_equivalence_rate` **1,0000 (36/36)**; test 487/488 với một
fail có sẵn; shape checks sạch trên Impostor.

## 2. Nguồn sự thật ngữ nghĩa (§3, §4, §7)

`RecoveredSemanticIr` được **generator ghi tại đúng lúc nó sinh mã**, ra
`AuxiliaryFiles/SemanticIR/<assembly>.json`, khoá theo đúng RVA mà `[Address(RVA = "0x…")]` mang.
`reports/METHOD_SEMANTIC_CONTRACT.md` là bản đầy đủ.

Nó là một **bản ghi**, không phải một IR thứ hai mà generator đọc lại — và điều đó được *kiểm*: bản
rip giống hệt tới từng byte. Một phép đo có thể đổi artefact nó đo thì tệ hơn không đo.

Ba lớp lỗi của §7 được đóng tại gốc chứ không vá từng cái:

| | cách đóng |
|---|---|
| 7.1 CFG vs `ConvertedIsil` | không còn hai danh sách: bản ghi đến từ chính vòng lặp sinh mã |
| 7.2 ghép cặp accessor | ghi `PROPERTY_READ Count` tại chỗ generator quyết định gọi `get_Count`, không phải `FIELD_READ _size` |
| 7.3 array initialiser | `newarr` + `stelem` mỗi phần tử được ghi là `NEW_ARRAY + ARRAY_STORE + ARRAY_STORE` theo cấu trúc, không theo một luật khớp chuỗi |

## 3. Method semantic contract (§5, §6, §8, §9)

`reports/method-contracts/<fixture>.json`, 37.474 contract trên bốn fixture. EXACT 2433 / 3704 / 7670 /
2722. Số method được ghi nhiều hơn số method có `[Address(` trong bản xuất, và cả ba lý do được gọi tên
riêng — `FOLDED_BY_DECOMPILER` (state machine và closure mà decompiler gấp lại),
`ASSEMBLY_NOT_EXPORTED` (assembly chỉ ship stub DLL), `NOT_EXPORTED` (ẩn số trung thực, 16/25/1298/16).

Phép kiểm chặt hơn `recovery_metrics.py`: đòi *tên* từng thao tác substantive xuất hiện trong C#, không
chỉ *lớp*. Bảy ngoại lệ, mỗi cái có lý do phát biểu được.

## 4. Shader (§12–§17)

`reports/SHADER_RECOVERY.md`. Cấu trúc ShaderLab thật đã về: pass được viết ra **0 → 96 / 3 / 48 / 29**.
Thân program chưa, và bản xuất tự nói ra điều đó bằng dấu `AssetRipperReplacementProgram`; hai phép đo
đọc dấu ấy và đặt trần `PARTIAL` / `shader_structure_only`. `shader_exact` vẫn **0**.

**Một phép đo đã bắt được chính lỗi nó tồn tại để bắt.** `validate_unity_stages.py` quyết định "exact"
bằng *sự vắng mặt* của dấu stand-in, nên khi exporter mới ngừng viết dấu đó nó báo `shader_exact
24 of 24`. Cùng lớp lỗi 056 mất một baseline để tìm. Đã sửa.

`reports/SHADER_CORPUS.json`: 19 entry qua bốn họ. `source_shader` là `null` ở **mọi** entry, vì không
fixture nào ship shader nguồn — đó là rào chặn mọi verdict trên `STRUCTURE_ONLY`, và là rào rẻ nhất để
gỡ tiếp.

## 5. `List<T>.Add` (§10, §11)

3055 candidate, 2087 gấp — không đổi, và **tiền đề của §10 sai**. Không có chỗ nào trong resolver chọn
`MethodsByAddress[address][0]`: `ResolveCalls` chỉ commit khi đúng một method nằm ở địa chỉ,
`ResolveAmbiguousCalls` khớp theo kiểu của receiver, và `PreferredOf` chỉ chạy cho các candidate
`AreInterchangeable` (cùng chữ ký, thân dùng chung) nơi lựa chọn không đổi nghĩa.

Truy vết 145 site bị từ chối trên Merge-Room: receiver là `Add of (Add …) and Immediate` — 119 như
thế, 14 gọi tên `_items` ngay bên trong. Đó là **địa chỉ phần tử** của mảng nền, không phải một list.
Nên đây là khiếm khuyết ở phía **ánh xạ đối số**, không phải phía phân giải lời gọi, và pass từ chối
đúng. Lý do từ chối giờ nói ra điều đó thay vì mô tả hình dạng thô.

## 6. Native plugin (§18)

Merge-Room 2/2, JellyBlast 6/6 — giữ nguyên. Thêm `.meta` `PluginImporter` cho framework iOS: platform
iOS, `AddToEmbeddedBinaries: true`, `CPU` đọc từ header Mach-O. Không có nó Unity import với thiết lập
mặc định và một framework iOS không được embed thì không được nạp lúc chạy dù đã copy đúng — nên
preservation rate trước đó tự đánh giá cao hơn thực tế.

## 7. Số cuối

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| EXACT / FALLBACK | 2513 / 150 | 3782 / 346 | 7671 / 386 | 2867 / 44 |
| placeholder | 5962 | 4293 | 37.507 | 38.236 |
| `compile_pass_rate` | 0,9761 | 0,9337 | 0,8929 | 0,8880 |
| `body_recovery_rate` | 0,9618 | 0,9369 | 0,9747 | 0,9941 |
| `reference_resolution_rate` | 1,0000 | 0,9942 | 0,9998 | 1,0000 |
| `shader_exact` / `structure_only` | 0 / 24 | 0 / 3 | 0 / 34 | 0 / 30 |
| ranh giới `UNKNOWN` | 5 | 15 | 34 | 22 |
| native plugin | — | — | 2/2 | 6/6 |

## 8. Còn lại

- Không fixture nào có shader nguồn ⇒ không verdict shader nào vượt được `STRUCTURE_ONLY` bằng bằng
  chứng. Rào rẻ nhất tiếp theo.
- Blob program không được nạp ở chế độ xuất mặc định; `--shader-mode Yaml` giữ chúng. Lấy được dữ liệu
  phải đi trước việc dịch nó, và "GLES nghĩa là GLSL text" vẫn **chưa** được xác nhận.
- 145 site `List.Add` có receiver là địa chỉ phần tử — việc của ánh xạ đối số.
- `Recovered.Runtime` / CS0433 vẫn hoãn (`docs/RECOVERED_RUNTIME_DESIGN.md`).
- Unity không có: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`.
