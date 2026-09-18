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

Đo trên bản rip cuối của iteration 057 (`Test/Out57H-{z,i,m,j}`), sau khi tiến trình thoát.

**Method recovery không đổi so với 056.** Iteration 057 đổi *cách đo* (một nguồn sự thật ngữ nghĩa do
generator tự ghi) và *shader / native plugin*; nó không đụng vào recovery của method, và bản rip giống
hệt baseline 056 tới từng byte ở phần `.cs`.

| | Impostor | RunFromZombies | JellyBlast v2 | Merge-Room |
|---|---|---|---|---|
| method có địa chỉ native | 5482 | 3928 | 7485 | 15.269 |
| `EXACT` | 3782 | 2513 | 2867 | 7671 |
| `FALLBACK` | 346 | 150 | 44 | 386 |
| placeholder | 4293 | 5962 | 38.236 | 37.507 |
| **thân hàm có semantic IR** | **5963** | **4615** | **8983** | **17.913** |
| contract `EXACT` (chặt hơn, theo tên) | 3704 | 2433 | 2722 | 7670 |
| **shader: pass được viết ra** | **3** (trước 0) | **96** (trước 0) | **29** (trước 0) | **48** (trước 0) |
| `shader_exact` | 0 / 3 | 0 / 24 | 0 / 30 | 0 / 34 |
| `shader_structure_only` | 3 / 3 | 24 / 24 | 30 / 30 | 34 / 34 |
| `shader_dummy` | 0 | 0 | 0 | 0 |
| `body_recovery_rate` | 0,9369 | 0,9618 | 0,9941 | 0,9747 |
| `compile_pass_rate` | 0,9337 | **0,9761** | 0,8880 | 0,8929 |
| `reference_resolution_rate` | 0,9942 | **1,0000** | **1,0000** | 0,9998 |
| `semantic_equivalence_rate` | — | **1,0000** (36/36) | — | — |
| `native_plugin_preservation_rate` | — (0 plugin) | — (0 plugin) | **1,0000** (6/6) + `.meta` | **1,0000** (2/2) |
| ranh giới `UNKNOWN` | 15 | 5 | 22 | 34 |
| field layout | 1394 / **0** | 2165 / **0** | 2654 / **0** | 3947 / **0** |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| golden corpus (056 → 057) | 0 / 0 | 0 / 0 | 0 / 0 | 0 / 0 |
| stage E–I | BLOCKED | BLOCKED | BLOCKED | BLOCKED |

### Merge-Room không tất định — đừng đọc chênh lệch nhỏ là regression

Bốn bản rip Merge-Room trên cùng một build cho **15.276 / 15.273 / 15.246 / 15.224** method có địa
chỉ native, chênh tới 52 (0,3%). Impostor cho đúng 5482 ba lần. Trên Merge-Room, một chênh lệch dưới
~50 method là nhiễu; ba fixture kia ổn định.

### Shader: số trước 057 không so được

Trước 057 mọi shader xuất ra là một pass đóng hộp, nên bất kỳ số shader nào công bố ở iteration ≤ 056
đo trên một artefact khác. `shader_exact` vẫn **0** ở cả hai bên, và đó là số duy nhất so được.
