# Iteration 060 — kết quả

Bản rip: `Test/Out61c-{m,z,j,i}`. Baseline: `Test/Out59G-*` tại commit `f6071e73`.

| | Merge-Room | Impostor | RunFromZombies | JellyBlast v2 |
|---|---:|---:|---:|---:|
| placeholder (059 → 060) | 39.533 → **26.309** | 4293 → **4137** | 5962 → **4681** | 38.236 → **37.290** |
| EXACT (đo bằng phép đo mới) | **11.131** | 3782 → **4011** | 2515 → **2770** | 2867 → **3005** |
| method không còn chỗ thay thế | **74,7 %** | 72,9 → **77,2 %** | 68,9 → **75,7 %** | 39,4 → **41,3 %** |
| `INDIRECT_JUMP` | 1849 → **381** | — | — | — |
| `METHOD_NOT_FOUND` | 11.859 → **4914** | — | — | — |
| `il2cpp_codegen_write_barrier` | **0x179CDFC** | không đủ bằng chứng | không đủ bằng chứng | hai đường bất đồng |
| `generatorFailures` / lỗi `Decompiling` | 0 | 0 | 0 | 0 |
| golden corpus regression mới | 0 | 0 | 0 | 0 |

Cột EXACT của Merge-Room không có số "trước" so sánh được: phép đo EXACT đã đổi giữa iteration này
(xem MEASUREMENT_CHANGE bên dưới), nên 8170 của 059 và 11.131 của 060 không cùng thước.

## Ba lỗi, cả ba ở tầng thấp hơn chỗ triệu chứng

1. **`il2cpp_codegen_write_barrier` chưa bao giờ được định vị trên ARM64.** Lớp cơ sở trả về 0 cho
   mọi kiến trúc trừ x86. Mỗi lần ghi reference vào field để lại một `Method not found` và một phép
   tính địa chỉ field còn sống, rồi phép tính đó nằm lại trong thanh ghi mà lời gọi kế tiếp đọc —
   nguồn của các receiver `List<T>.Add` đọc thành `this + 0x20`. Tìm bằng hình dạng call site, hai
   đường độc lập. Merge-Room: 40.292 → 32.385 placeholder.
2. **Virtual dispatch ở vị trí tail call không được giải quyết.** Một method có câu lệnh cuối là
   virtual call biên dịch thành `br` chứ không `bl`, và hai resolver chỉ nhìn `IndirectCall`.
   32.338 → 28.278, `INDIRECT_JUMP` 1849 → 381.
3. **Generic virtual dispatch đọc slot lúc chạy.** Thân hàm chia sẻ không có slot hằng số, nên
   compiler đọc `method->slot` ra từ usage mà call site đã nêu và inflate override qua một runtime
   helper. Nhận diện qua chính đối số của helper, không cần tên nó. 28.278 → 26.309.

## MEASUREMENT_CHANGE

`recovery_metrics.py` nhận allocation ở phía C# bằng từ khoá `new`; C# có bốn cách viết một
allocation delegate và chỉ một cách nói `new`. 415 method trên Merge-Room bị chấm FALLBACK vì điều
đó, recovery đã trả lại đủ cả 415. Không phải cải thiện recovery. `--self-test` sáu ca.

## Hai kết quả âm

- Luật "bản sao vào local có kiểu khác là dùng lại thanh ghi" trong `PointerClassifier`: bị chính
  chuỗi định nghĩa bác bỏ, đã gỡ cùng test.
- Phép đi ngược qua block thẳng hàng trong `InlineListAddRecovery`: không bao giờ bước được một
  bước, vì guard là điểm hợp lưu chứ không phải chuỗi. Đã gỡ cùng phép đo chết dựa trên nó.

## Báo cáo

`reports/THIS_OFFSET_PROVENANCE.md`, `reports/LIST_ADD_GUARD_TERMINATORS.md`,
`reports/RUNTIME_HELPER_IDENTIFICATION.md`, `docs/ITERATION_060.md`.

Test: 509 ca, 508 pass, một fail có sẵn (`GetMainExportID_..._DebugAssertFails`, chỉ đỏ ở build
Release). Golden corpus đóng băng lại ở cuối iteration, cố ý: 887 entry, 531 cập nhật, 0 thêm, 0 mất.
Unity không có: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`.
