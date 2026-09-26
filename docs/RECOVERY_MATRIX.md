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

Đo trên bản rip cuối của iteration 058 (`Test/Out58H-{z,i,m,j}`), sau khi tiến trình thoát. Baseline
là `Test/Out57H-*`.

**Recovery của method đổi ở một chỗ và chỉ một chỗ**: lấy địa chỉ của một tham số nay ra `ldarga` chứ
không phải `ldloca` của một local generator tự bịa (`docs/ITERATION_058.md` mục 3). Trên Impostor —
fixture tất định — 16 file đổi *nội dung* và mọi con số tổng y nguyên. Đó là hình dạng của một bản
sửa tính đúng đắn.

| | Impostor | RunFromZombies | JellyBlast v2 | Merge-Room |
|---|---|---|---|---|
| method có địa chỉ native | 5482 | 3928 | 7485 | 16.317 |
| `EXACT` | 3782 | 2513 | 2867 | 8170 |
| `FALLBACK` | 346 | 150 | 44 | 450 |
| placeholder | 4293 | 5962 | 38.236 | 39.533 |
| thân hàm có semantic IR | 5963 | 4615 | 8983 | 17.913 |
| contract `EXACT` (chặt hơn, theo tên) | 3704 | 2433 | 2722 | 8168 |
| **hợp đồng hành vi** | **5963** | **4615** | **8983** | **17.913** |
| — có nhánh | 2362 | 1982 | 4346 | 7384 |
| — có vòng lặp | 1348 | 1045 | 3039 | 4101 |
| — điều kiện truy được về nơi sinh | 8754/10.660 | 8536/10.448 | 24.924/35.028 | 30.534/37.664 |
| `behaviour_equivalence_rate` | — | **1,0000** (35/35) | — | 0,6951 (2079/2991) |
| **shader: khối GLSL thật viết ra** | **3** | **43** | **0** | **50** |
| shader `SEMANTICALLY_EQUIVALENT` | **2** / 3 | **9** / 24 | 0 / 0 so được | **2** / 7 |
| `shader_exact` | 0 | 0 | 0 | 0 |
| `shader_programs_recovered` | 2 / 3 | 1 / 24 | 0 / 30 | 8 / 34 |
| `shader_dummy` | 0 | 0 | 0 | 0 |
| `body_recovery_rate` | 0,9369 | 0,9618 | 0,9941 | 0,9724 |
| `compile_pass_rate` | 0,9337 | **0,9761** | 0,8880 | 0,8993 |
| `reference_resolution_rate` | 0,9942 | **1,0000** | **1,0000** | 0,9998 |
| `semantic_equivalence_rate` (lớp thao tác) | — | **1,0000** (36/36) | — | — |
| `native_plugin_preservation_rate` | — (0 plugin) | — (0 plugin) | **1,0000** (6/6) + `.meta` | **1,0000** (2/2) |
| ranh giới `UNKNOWN` | 15 | 5 | 22 | 41 |
| field layout | 1394 / **0** | 2165 / **0** | 2654 / **0** | 3947 / **0** |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| golden corpus (057 → 058) | 0 / 0 | 0 / 0 | 0 / 0 | 0 / 0 |
| corpus hành vi | 84/84 | 50/50 | 73/73 | 86/86 |
| stage E–I | BLOCKED | BLOCKED | BLOCKED | BLOCKED |

### Merge-Room không tất định — vẫn đúng, và lần này đo được trực tiếp

Hai bản rip 058 của cùng một build khác nhau ở **một file `.cs`**
(`CinemachineStoryboard.cs`): một lần ILSpy bỏ dở assembly `Cinemachine`, lần kia không. Bản rip
`Test/Out58H-m` có 16.317 method so với 15.282 của `Test/Out58F-m` vì đúng chuyện đó — chênh 1035,
và nó *không* phải hiệu ứng của thay đổi nào trong iteration này. Trên fixture đó, chỉ tin những
khác biệt mà một bản rip thứ hai tái lập được.

### Shader: `shader_exact` giờ do ai quyết

`validate_unity_stages.py` **không còn** in `shader_exact`. Nó quyết "exact" bằng *sự vắng mặt* của
dấu bản thay thế, nên ngay khi một pass mang được chương trình thật nó báo `shader_exact 10 of 34` —
cùng lớp lỗi mà 057 đã mất một baseline để tìm. Nó nay in `shader_programs_recovered`, và exactness
là việc của `shader_semantic_equivalence.py`, so với ShaderLab nguồn.

