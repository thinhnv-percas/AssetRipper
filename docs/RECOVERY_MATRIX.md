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

Đo trên bản rip cuối của iteration 055 (`Test/Out55i2`, `Test/Out55z5`, `Test/Out55j2`,
`Test/Out55m3`), sau khi tiến trình rip thoát chứ không theo một dòng log.

| | Impostor | RunFromZombies | JellyBlast v2 | Merge-Room |
|---|---|---|---|---|
| `.cs` | 830 | 796 | 1473 | 3998 |
| method có địa chỉ native | 5482 | 3928 | 7485 | 15.224 |
| `EXACT` | 2879 | 2285 | 2517 | 6633 |
| `FALLBACK` | 1299 | 405 | 405 | 1488 |
| placeholder | 4297 | 5964 | 38.524 | 37.622 |
| **lệnh ghi phần tử phục hồi** | — | — | **903** (054: 676) | — |
| `body_recovery_rate` | 0,7630 | **0,8969** | 0,9459 | 0,9023 |
| `compile_pass_rate` | **0,9337** | **0,9761** | 0,8880 | **0,8939** (054: 0,8927) |
| `reference_resolution_rate` | 0,9942 | **1,0000** | **1,0000** | 0,9998 |
| `semantic_equivalence_rate` | — | **1,0000** (36/36) | — | — |
| `native_plugin_preservation_rate` | — (0 plugin) | — (0 plugin) | 0 / 6 | **1,0000** (2/2) |
| `shader_exact` | 0 / 3 | 0 / 24 | 0 / 30 | 0 / 34 |
| ranh giới `UNKNOWN` | 15 | 5 | 22 | 34 |
| field layout | 1394 / **0** | 2165 / **0** | 2654 / **0** | 3947 / **0** |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| golden corpus | 216, +1/−0 | 194, 0/0 | 222, 0/0 | 255, 0/0 |
| stage E–I | BLOCKED | BLOCKED | BLOCKED | BLOCKED |

### Merge-Room không tất định — đừng đọc chênh lệch nhỏ là regression

Bốn bản rip Merge-Room trên cùng một build cho **15.276 / 15.273 / 15.246 / 15.224** method có địa
chỉ native, chênh tới 52 (0,3%). Impostor cho đúng 5482 ba lần. Trên Merge-Room, một chênh lệch dưới
~50 method là nhiễu; ba fixture kia ổn định.

### Native plugin: kết luận của 054 sai với một nửa ma trận

Impostor và RunFromZombies **không có plugin nào của game** — 6 thư viện của mỗi cái là đúng hai bản
il2cpp runtime và bốn bản Unity player, không thứ nào được phép đi vào project. Chỉ Merge-Room
(`liblofelt_sdk.so`, hai ABI) và JellyBlast v2 (sáu framework Facebook SDK) có plugin thật.
`reports/RUNTIME_DEPENDENCY_GRAPH.md` là bản ghi.
