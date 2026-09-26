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

Đo trên bản rip cuối của iteration 060 (`Test/Out61c-{m,z,j,i}`), sau khi tiến trình thoát. Baseline
là `Test/Out59G-*` tại commit `f6071e73`.

**Recovery đổi ở ba chỗ, cả ba là lỗi nghĩa-binary ≠ nghĩa-phục hồi ở tầng thấp hơn chỗ triệu chứng**
(`docs/ITERATION_060.md`): `il2cpp_codegen_write_barrier` được định vị trên ARM64; virtual dispatch ở
vị trí tail call được giải quyết; generic virtual dispatch đọc slot lúc chạy được nhận diện.

**Và phép đo `EXACT` đã đổi** (MEASUREMENT_CHANGE): C# viết một delegate allocation bằng bốn cách và
`recovery_metrics.py` chỉ đọc `new`. Cột `EXACT`/`FALLBACK`/`body_recovery_rate` của 059 và của 060
**không cùng thước**; mọi so sánh qua ranh giới đó phải đo lại cả hai đầu.

| | Impostor | RunFromZombies | JellyBlast v2 | Merge-Room |
|---|---:|---:|---:|---:|
| method có địa chỉ native | 5482 | 3928 | 7485 | 16.023 |
| `EXACT` | **4011** | **2770** | **3005** | **11.131** |
| `FALLBACK` | 162 | 114 | 44 | 566 |
| placeholder | 4293 → **4137** | 5962 → **4681** | 38.236 → **37.290** | 39.533 → **26.309** |
| method không còn chỗ thay thế | **77,2 %** | **75,7 %** | **41,3 %** | **74,7 %** |
| `body_recovery_rate` | 0,9369 → **0,9692** | 0,9618 → **0,9488** | 0,9941 → **0,9888** | 0,9724 → **0,9646** |
| `compile_pass_rate` | 0,9337 → **0,9337** | 0,9761 → **0,9761** | 0,8880 → **0,8873** | 0,8993 → **0,9073** |
| `reference_resolution_rate` | **0,9942** | **1,0000** | **1,0000** | **0,9998** |
| `shader_programs_recovered` | 2 / 3 | 1 / 24 | 0 / 30 | 8 / 34 |
| `il2cpp_codegen_write_barrier` | không đủ bằng chứng | không đủ bằng chứng | hai đường bất đồng | **0x179CDFC** |
| `generatorFailures` / lỗi `Decompiling` | **0** | **0** | **0** | **0** |
| golden corpus regression mới | **0** | **0** | **0** | **0** |
| stage E–I | BLOCKED | BLOCKED | BLOCKED | BLOCKED |

### `body_recovery_rate` giảm ở ba fixture, và đó không phải regression

Công thức là `1 − (FALLBACK + MISSING) / total`, nên một method thôi mang placeholder sẽ *bắt đầu*
được chấm — và nếu bản phục hồi của nó còn thiếu thao tác nào thì nó rơi vào `FALLBACK`. Chỉ số này
do đó giảm chính xác khi recovery tốt lên đủ để phơi ra chỗ còn thiếu. `placeholder` và `EXACT` đi
đúng chiều ở cả bốn fixture; `golden corpus` không có regression mới nào. Đây là hình dạng CLAUDE.md
đã ghi từ lâu: "recovering more of a program raises the placeholder count" — cùng một hiệu ứng, ở
một chỉ số khác.

### Cái gì so được với iteration trước, và cái gì không

**So được:** `placeholder`, `compile_pass_rate`, `reference_resolution_rate`, `generatorFailures`,
mọi invariant.

**Không so được:** `EXACT`, `FALLBACK`, `body_recovery_rate` và golden corpus — phép đo `EXACT` đổi ở
060 và baseline corpus đã đóng băng lại. Cả hai bên của bất kỳ so sánh nào qua ranh giới đó phải đo
lại.

**Không đo lại ở 060:** `behaviour_equivalence_rate`, `semantic_equivalence_rate`, hợp đồng hành vi,
các verdict shader, ranh giới `UNKNOWN`, field layout, corpus hành vi. Số của chúng trong
`iterations/059/RESULT.md` là số 059, không phải số hiện tại.

### Merge-Room vẫn không tất định

Đã ghi từ 054 và 058. Một chênh lệch dưới ~50 method trên fixture đó là nhiễu; ba fixture kia ổn định.

