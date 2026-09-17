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

Đo trên bản rip cuối của iteration 054 (`Test/Out54i3`, `Test/Out54z4`, `Test/Out54j2`,
`Test/Out54m3`), sau khi tiến trình rip thoát chứ không theo một dòng log.

| | Impostor | RunFromZombies | JellyBlast v2 | Merge-Room |
|---|---|---|---|---|
| `.cs` | 830 | 796 | 1473 | 3998 |
| method có địa chỉ native | 5482 | 3928 | 7485 | 15.276 |
| `EXACT` | 2878 | 2285 | **2517** (053: 2200) | 6648 |
| `FALLBACK` | 1299 | 405 | 405 | 1495 |
| placeholder | 4297 | 5964 | **38.527** (053: 48.458) | 37.757 |
| `body_recovery_rate` | 0,7630 | **0,8969** | 0,9459 | 0,9021 |
| `compile_pass_rate` | **0,9337** | **0,9761** | **0,8880** (053: 0,8866) | 0,8927 |
| lỗi Roslyn | 484 | 40 | **6630** (053: 8638) | 5143 |
| `reference_resolution_rate` | 0,9942 | **1,0000** | **1,0000** | 0,9998 |
| `semantic_equivalence_rate` | — | **1,0000** (36/36) | — | — |
| `type_recovery_rate` | **1,0000** (430/430) | **1,0000** (16/16) | — | **0,9943** |
| `property_recovery_rate` (shader) | **1,0000** | — | — | **1,0000** |
| `shader_exact` | 0 / 3 | 0 / 24 | 0 / 30 | 0 / 34 |
| ranh giới `UNKNOWN` | **15** (053: 112) | **5** (053: 281) | **22** (053: 814) | **34** |
| field layout | 1394 / **0** | 2165 / **0** | 2654 / **0** | 3947 / **0** |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| golden corpus | 216, 0/0 | 194, 0/0 | 222, 0/0 | 255, 0/0 |
| stage E–I | BLOCKED | BLOCKED | BLOCKED | BLOCKED |

### Merge-Room `compile_pass_rate` 0,8937 → 0,8927

Toàn bộ chênh lệch là **CS0433, 1122 → 1315**: `TokenAttribute` và bảy kiểu khác do chính exporter
tiêm vào *mọi* assembly ở mức public, nên một file tham chiếu hai assembly recovered nhìn thấy hai
kiểu cùng tên. Không lỗi nào trong đó là defect của recovery, mọi cụm khác không đổi một con số nào,
và `reports/INJECTED_TYPE_COLLISION.md` ghi cách sửa cùng lý do nó bị hoãn.

### Lỗi Roslyn của Jelly Blast không so được với 052 trở về trước

1938 → 8638 ở 053 **không phải regression**: bản cũ mang lỗi khai báo CS0102 che toàn bộ lỗi thân
hàm của `RayFireAssembly` và `PathCreator`. Mốc so sánh đúng là 8638 của 053, và 054 đưa nó xuống
6630.
