# Bảng đối chiếu hai nền tảng

Trạng thái của từng tầng pipeline và từng họ bug trên Android và iOS, kèm phân loại. Cập nhật ở
iteration 033.

## Fixture

| | Android | iOS |
|---|---|---|
| Game | Impostor-Sort-Puzzle-Pro v1 | Jelly Blast 1.1 |
| Thứ hai | Pinata (trong repo) | — |
| Container | ELF `libil2cpp.so`, 27.434.328 byte | Mach-O `UnityFramework`, 51.406.160 byte |
| Kiến trúc | arm64-v8a (Impostor), x86 (Pinata) | arm64 |
| Unity | 2022.3.62f2 (Impostor), 2019.2 (Pinata) | 2022.3.53f1 |
| Metadata | v31.1 / v24.2 | v31.1 |
| Nguồn đối chiếu | có (game + spine-csharp vendored) | không |
| Trạng thái | `OK` | `FIXTURE_ENCRYPTED` |

## Tầng pipeline

| tầng | Android | iOS | phân loại |
|---|---|---|---|
| Phát hiện cấu trúc game | PASS | PASS | — |
| Định vị il2cpp binary | PASS | PASS *(sau DECOMP-0021)* | **DECOMPILER_BUG** đã sửa, IOS_ONLY |
| Đọc container (ELF / Mach-O) | PASS | PASS | — |
| Nhận diện binary bị mã hoá | không áp dụng | PASS *(sau DECOMP-0021)* | IOS_ONLY |
| Đọc `global-metadata.dat` | PASS | PASS | — |
| Metadata registration | PASS | PASS | — |
| Code registration | PASS | **KHÔNG KIỂM TRA ĐƯỢC** | FIXTURE_ENCRYPTED |
| Lift mã máy → ISIL | PASS | **KHÔNG KIỂM TRA ĐƯỢC** | FIXTURE_ENCRYPTED |
| SSA, type recovery, DCE | PASS | **KHÔNG KIỂM TRA ĐƯỢC** | FIXTURE_ENCRYPTED |
| Sinh CIL và C# | PASS | **KHÔNG KIỂM TRA ĐƯỢC** | FIXTURE_ENCRYPTED |
| Field layout self-check | PASS, 0 disagreement | **KHÔNG KIỂM TRA ĐƯỢC** | FIXTURE_ENCRYPTED |

`KHÔNG KIỂM TRA ĐƯỢC` không phải FAIL và cũng không phải PASS. Xem
`reports/IOS_INPUT_ANALYSIS.md` để biết bằng chứng và điều kiện để kiểm tra được.

## Họ bug

Cột iOS để trống ở đâu thì nghĩa là fixture hiện tại không cho đo, không phải là đã đo và bằng 0.

| họ bug | Android (Impostor) | iOS | cùng root cause? | đặc thù nền tảng? | đã sửa? |
|---|---:|---|---|---|---|
| `untyped_base` | 930 | không đo được | chưa biết | chưa biết | chưa |
| trong đó: frame-pointer spill (`AddressOf`) | 245 | không đo được | chưa biết — ARM64 cả hai, nhưng register allocation và vị trí spill do compiler quyết | có thể | chưa |
| trong đó: `Move:memory` không kiểu | 311 | không đo được | chưa biết | chưa biết | chưa |
| trong đó: không có định nghĩa trong thân hàm | 254 | không đo được | chưa biết | chưa biết | chưa |
| `runtime_struct` | 651 | không đo được | offset đọc từ StructDb theo Unity version, nên rất có thể chung | có thể khác layout theo version | chưa |
| `computed_addr` | 440 | không đo được | chưa biết | chưa biết | phần nào (DECOMP-0017) |
| `ancestor_base` | 336 | không đo được | thuần metadata, nên gần như chắc chắn chung | không | chưa |
| `generic_instance` | 207 | không đo được | thuần metadata | không | chưa |
| `valuetype_base` | 170 | không đo được | thuần metadata | không | chưa |
| `open_generic` | 29 | không đo được | thuần metadata | không | chưa |
| `object_base` | 19 | không đo được | thuần metadata | không | DECOMP-0016 |
| il2cpp binary sai file trong bundle | không áp dụng | đã FAIL, giờ PASS | không | **IOS_ONLY** | **DECOMP-0021** |
| Mach-O bị mã hoá báo sai tầng | không áp dụng | đã FAIL, giờ PASS | không | **IOS_ONLY** | **DECOMP-0021** |

## Nguyên tắc rút ra cho các iteration sau

1. Một họ bug thuần **metadata** (ancestor, generic instance, value type base, open generic) gần như
   chắc chắn dùng chung logic giữa hai nền tảng: nó không đọc một byte mã máy nào. Sửa ở đó không
   cần kiểm chứng chéo trên iOS.
2. Một họ bug thuộc **lift mã máy hoặc frame/stack** thì phải kiểm chứng chéo, vì cùng ARM64 nhưng
   register allocation, vị trí spill, prologue/epilogue là do compiler chọn. Với fixture hiện tại
   việc kiểm chứng đó **không làm được**, nên trạng thái iOS phải ghi `KHÔNG KIỂM TRA ĐƯỢC`.
3. Mọi thay đổi vẫn phải chạy trên cả **Impostor (ARM64, v31.1)** và **Pinata (x86, v24.2)**. Hai
   fixture đó khác nhau cả kiến trúc lẫn metadata version, nên chúng bắt được phần lớn loại lỗi
   "đúng cho một codegen, sai cho codegen kia" mà cặp Android/iOS lẽ ra sẽ bắt.
