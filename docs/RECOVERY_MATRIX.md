# Ma trận fixture

Từ iteration 053, ba fixture dưới đây là ma trận mặc định. Mọi acceptance đo trên chúng.

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

## Con số hiện tại

Đo trên bản rip cuối của iteration 053 (`Test/Out53ish`, `Test/Out53zb`, `Test/Out53jb`), sau khi
tiến trình rip thoát chứ không theo một dòng log.

| | Impostor | RunFromZombies | JellyBlast v2 |
|---|---|---|---|
| `.cs` | 830 | 796 | 1501 |
| method có địa chỉ native | 5482 | 3928 | 7485 |
| `EXACT` | 2878 (52,5%) | 2285 (58,2%) | 2200 (29,4%) |
| `FALLBACK` | 1299 | 405 | 369 |
| placeholder | 4309 | 5820 | 48458 |
| `body_recovery_rate` | 0,7630 | **0,8969** | 0,9507 |
| `compile_pass_rate` | **0,9337** | **0,9761** | 0,8866 |
| lỗi Roslyn | 484 | 40 | 8638 |
| `reference_resolution_rate` | 0,9942 | **1,0000** | 1,0000 (2/113286 không theo được) |
| `semantic_equivalence_rate` | — | **1,0000** (36/36) | — |
| `type_recovery_rate` | **1,0000** (425/425) | **1,0000** (16/16) | — |
| `property_recovery_rate` (shader) | **1,0000** (45/45) | — | — |
| `shader_exact` | 0 / 3 | 0 / 24 | 0 / 30 |
| field layout | 1394 / **0** | 2165 / **0** | 2654 / **0** |
| `generatorFailures` | 0 | 0 | 0 |
| golden corpus | 213, improved 0 regressed 0 | 188, improved 0 regressed 0 | 190, improved 0 regressed 0 |
| stage E–I | BLOCKED | BLOCKED | BLOCKED |

### Lỗi Roslyn của Jelly Blast không so được với iteration trước

1938 → 8638 **không phải regression**. Bản rip trước phép sửa event mang lỗi khai báo CS0102 — một
event và một field trùng tên trong `RFEvent` và `BezierPath` — và Roslyn bind khai báo trước rồi
dừng, nên ba lỗi ấy che toàn bộ lỗi thân hàm của cả `RayFireAssembly` (119/120 file đọc là "sạch")
và `PathCreator`. Bỏ khai báo event trùng khiến hai assembly ấy lần đầu bind được. Không có con số
"trước" đúng để so, vì phép đo cũ chưa từng chạy tới thân hàm.
