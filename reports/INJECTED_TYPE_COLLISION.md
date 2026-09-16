# CS0433 — kiểu do chính exporter tiêm vào va nhau

Iteration 054. Đo được trên fixture Merge-Room: **1122 lỗi trên 19 file**, 23% tổng số lỗi biên dịch
của fixture đó. Không một lỗi nào là defect của recovery.

## Nguyên nhân

`ApplicationAnalysisContext.InjectTypeIntoAllAssemblies` tiêm `TokenAttribute`, `AddressAttribute`,
`FieldOffsetAttribute`, `MetadataOffsetAttribute`, `AttributeAttribute`, `NativeSourceAttribute`,
`Cpp2ILHelpers` và `Il2CppRuntime` vào **mọi** assembly, và mặc định là `TypeAttributes.Public`.
Một file tham chiếu tới hai assembly recovered thì nhìn thấy hai kiểu cùng tên:

```
CinemachineMixer.cs(8,2): error CS0433: The type 'TokenAttribute' exists in both
  'AlmostEngine.Shared, Version=0.0.0.0, …' and 'AlmostEngine, Version=0.0.0.0, …'
```

Fixture càng nhiều assembly recovered thì càng nặng — Merge-Room có 29, nên nó hiện ra ở đây mà
không hiện ở ba fixture kia.

## Cách sửa, và vì sao chưa làm trong iteration này

Mọi kiểu trong danh sách trên đều là artefact của chính bản export và chỉ được dùng *bên trong*
assembly nó được tiêm vào, nên `internal` vừa đúng vừa dập được va chạm; một attribute internal đặt
trên một member public là C# hợp lệ. Đã thử: một dòng đổi mặc định thành
`TypeAttributes.NotPublic`, build được, `TokenAttribute` xuất ra `internal sealed` đúng như mong đợi.

Nó bị **hoàn tác**, vì nó đổi hình dạng mà mọi phép đo trong dự án này neo vào. ILSpy viết một
attribute internal ra dạng đủ tên — `[Cpp2ILInjected.Token(…)]` thay cho `[Token(…)]` — nên
`[Address(` và `[NativeSource(` không còn khớp, và `recovery_metrics.py` đọc RunFromZombies thành
`NO_BODIES` với cả năm trạng thái ngữ nghĩa bằng 0 trong khi bản rip hoàn toàn bình thường
(`compile_pass_rate` vẫn 0,9761).

Nên phép sửa này phải đi cùng một lần đổi các phép đo sang nhận cả hai dạng, **và** đo lại cả hai
đầu của mọi so sánh. Đó là việc của một iteration có baseline riêng cho nó, không phải việc chen vào
giữa một iteration đang so với 053.

Mục tiêu tiếp theo, ghi rõ ràng: đổi mặc định sang `NotPublic`, dạy `recovery_metrics.py`,
`placeholder_families.py`, `golden_corpus.py` và `method_recovery_report.py` đọc cả dạng đủ tên, rồi
đo lại toàn bộ ma trận trên cả hai đầu.
