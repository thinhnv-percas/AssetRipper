# Ma trận fixture

Từ iteration 054, **bốn** fixture dưới đây là ma trận mặc định. Mọi acceptance đo trên chúng.

| | Impostor | RunFromZombies | JellyBlast v2 |
|---|---|---|---|
| nguồn | `thinhabc01/Impostor-Sort-Puzzle-Pro` release v1 | `thinhabc01/RunFromZombiesFullProject` release v1 | `ThinhNV-x-Percas/jelly-blast` release v2 |
| file | `impostor-sort.apk` | `demo.apk` | `io.heseri.blast-1.1.ipa` |
| sha256 | `8e5ab4a9…c447dd9fc8aaf` | `b5d241baedbbd3b44c5f971338e229cbd748bf8963352474c14f6b73e5b55818` | `11093fbd6ea9a7094aff349aca838209b291818cd8a6cd772a47ea00ba6c6b7f` |
| nền tảng | Android, ELF arm64-v8a | Android, ELF arm64-v8a | iOS, Mach-O arm64 |
| Unity | 2022.3.62f2 | 2022.3.62f2 | 2022.3.53f1 |
| metadata | v31.1 | v31.1 | v31.1 |
| thư mục | `Test/Input/Impostor` | `Test/Input/RunFromZombies` | `Test/Input/JellyBlastV2` |
| **có source đối chiếu** | có (42 script của game) | **có, toàn bộ project** | không |
| vai trò | fixture chính | **source oracle** | cổng iOS |

Cả ba đều gitignored; `Test/Scripts/download_test_inputs.sh` tải và verify.

## Vì sao Pinata rời ma trận mặc định

Pinata (`Test/Input/Pinata`, x86, metadata v24.2) là cổng kiểm chứng độc lập từ iteration 027 đến
052 và làm tốt việc đó: nó bắt được phần lớn loại lỗi "đúng cho một codegen, sai cho codegen kia".
Nó rời ma trận **mặc định** từ 053 vì hai lý do nêu trong brief của iteration đó, không phải vì nó
sai:

- không có source để đối chiếu, nên nó không nói được điều gì về ngữ nghĩa mà chỉ nói về số lượng;
- RunFromZombies vừa là Android vừa **có source**, nên nó thay được vai trò cổng kiểm chứng và làm
  thêm được việc Pinata không làm được.

Số liệu cuối cùng của Pinata nằm ở `reports/regression-matrix.md` mục 052. Nó **không còn ảnh hưởng
acceptance**, và lệnh test mặc định không rip nó.

## Trạng thái iOS

`reports/JELLYBLAST_V2.md` có bản fingerprint đầy đủ. Tóm tắt: **`IOS_DECRYPTED`** — `cryptid=0`,
entropy `__TEXT` 6,541/8, 4225 lệnh `ret` trong 1 MiB, `mscorlib.dll` có mặt. Bản v1 là
`IOS_ENCRYPTED` và mọi kết luận rút ra từ nó **không áp dụng cho v2**.

## Merge-Room (thêm ở iteration 054)

| | |
|---|---|
| nguồn | `thinhabc01/Merge-Room` release v1, `merge-room.apk` |
| sha256 | `fdd2b98f269d5e1d4d825d694d66c607c1e1a6c85c361726e19af0d0f7836ff2` |
| nền tảng | Android, ELF arm64-v8a (+ armeabi-v7a) |
| Unity | 2022.3.62f2, metadata v31 |
| thư mục | `Test/Input/MergeRoom` |
| có source đối chiếu | có — `thinhabc01/Merge-Room` @ `63e88b33` |
| vai trò | fixture Android lớn nhất, 29 assembly recovery |

`reports/MERGE_ROOM.md` là bản fingerprint và baseline đầy đủ.

## Con số hiện tại

Đo trên bản rip cuối của iteration 059 (`Test/Out59G-{z,i,m,j}`), sau khi tiến trình thoát. Baseline
là `Test/Out58H-*` tại commit `7babffb8`.

**Recovery của method đổi ở một chỗ**: ghi vào một lifted local mà thực ra là *tham số* nay ra `starg`
chứ không phải `stloc` vào một local generator tự bịa (`docs/ITERATION_059.md` mục 3). Trên Impostor —
fixture tất định — **46 file đổi nội dung và mọi con số tổng y nguyên**; 37 trên RunFromZombies, 85
trên JellyBlast, 180 trên Merge-Room. Cùng số lệnh, khác chỗ ghi.

**Phần lớn chuyển động của oracle Merge-Room là phép đo trở nên trung thực, không phải phục hồi tốt
lên.** `source_preprocessor` rút file nguồn về chương trình mà build đã biên dịch; trước nó 192
method bị báo `FALLBACK` trên những bản phục hồi *chính xác*. Hai thứ được ghi riêng vì lý do đó.

| | Impostor | RunFromZombies | JellyBlast v2 | Merge-Room |
|---|---:|---:|---:|---:|
| method có địa chỉ native | 5482 | 3928 | 7485 | 16.317 |
| `EXACT` | 3782 | 2515 | 2867 | 8170 |
| `FALLBACK` | 346 | 150 | 44 | 450 |
| placeholder | 4293 | 5962 | 38.236 | 39.533 |
| hợp đồng hành vi | 5963 | 4615 | 8983 | 17.913 |
| — điều kiện nhánh truy được về nơi sinh | 8754 | 8536 | 24.924 | 30.534 |
| `behaviour_equivalence_rate` | — | **1,0000** (35/35) | — | **0,7284** (2178/2990) |
| — `MISMATCH` (058 → 059) | — | 0 → 0 | — | 16 → **15** |
| — `FALLBACK` (058 → 059) | — | 0 → 0 | — | 197 → **114** |
| `semantic_equivalence_rate` (lớp thao tác) | — | **1,0000** (36/36) | — | — |
| **shader: hàng ánh xạ blob** | **1644** | **13.143** | **2532** | **978** |
| — có `ParameterBlobIndices` | 1644 | 13.143 | 2532 | 978 |
| — chỉ số chương trình ∩ chỉ số tham số | **0** | **0** | **0** | **0** |
| **biến thể phục hồi / chương trình khác nhau** | **551 / 133** | **7153 / 1312** | 0 | **298 / 96** |
| khối GLSL viết vào ShaderLab | 3 | 43 | 0 | 50 |
| shader `SEMANTICALLY_EQUIVALENT` | **2** / 3 | **9** / 24 | — | **3** / 7 |
| `shader_exact` | 0 | 0 | 0 | 0 |
| `METAL_BINARY_ONLY` | 0 | 0 | **29** | 0 |
| `NO_SOURCE_ORACLE` | 0 | 0 | 0 | 25 |
| `body_recovery_rate` | 0,9369 | 0,9618 | 0,9941 | 0,9724 |
| `compile_pass_rate` | 0,9337 | **0,9761** | 0,8880 | 0,8993 |
| `reference_resolution_rate` | 0,9942 | **1,0000** | **1,0000** | 0,9998 |
| ranh giới `UNKNOWN` | 15 | 5 | 22 | 41 |
| field layout | 1394 / **0** | 2165 / **0** | 2654 / **0** | 3947 / **0** |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| golden corpus regression (058 → 059) | **0** | **0** | **0** | **0** |
| corpus hành vi | 84/84 | 50/50 | 73/73 | 86/86 |
| stage E–I | BLOCKED | BLOCKED | BLOCKED | BLOCKED |

### Cái gì so được với iteration trước, và cái gì không

**So được:** mọi con số method (recovery đổi đúng một chỗ, và chỗ đó không đổi số lượng gì), mọi
invariant, golden corpus, `compile_pass_rate`, `reference_resolution_rate`.

**Không so được:** `behaviour_equivalence_rate` và các verdict shader. Oracle hành vi trước 059 đọc
toàn văn file nguồn; verdict shader trước 059 so với toàn văn shader nguồn thay vì với biến thể gốc.
Cả hai bên của bất kỳ so sánh nào qua ranh giới đó phải đo lại.

### Merge-Room vẫn không tất định

Đã ghi từ 054 và 058. Một chênh lệch dưới ~50 method trên fixture đó là nhiễu; ba fixture kia ổn định.

