# `Recovered.Runtime` và `Recovered.FrameworkCompat` — thiết kế kỹ thuật

Iteration 056, §14. Đây là **thiết kế**, chưa phải triển khai. Hai iteration liên tiếp đã hoãn nó, và
iteration 056 hoãn tiếp — nhưng lần này có một bằng chứng mới khiến việc hoãn không còn là "chưa kịp"
mà là một quyết định có căn cứ, và thiết kế dưới đây nói rõ iteration triển khai nó phải mang theo cái
gì.

## Vấn đề

`ApplicationAnalysisContext.InjectTypeIntoAllAssemblies` tiêm tám kiểu — `TokenAttribute`,
`AddressAttribute`, `FieldOffsetAttribute`, `MetadataOffsetAttribute`, `AttributeAttribute`,
`NativeSourceAttribute`, `Cpp2ILHelpers`, `Il2CppRuntime` — vào **mọi** assembly, `public`. Một file
tham chiếu hai assembly đã recover thấy hai kiểu cùng tên: CS0433, 1122 lỗi trên 19 file của
Merge-Room, 23% tổng số lỗi biên dịch của fixture đó, **không một lỗi nào là defect của recovery**.

## Vì sao `NotPublic` không phải là lời giải

Đã thử và đã hoàn tác (`reports/INJECTED_TYPE_COLLISION.md`). `internal` đúng về mặt ngữ nghĩa và dập
được va chạm, nhưng ILSpy viết một attribute internal ra dưới dạng đủ tên — `[Cpp2ILInjected.Token(…)]`
thay cho `[Token(…)]` — nên `[Address(` và `[NativeSource(` thôi không khớp, và `recovery_metrics.py`
đọc một bản rip hoàn toàn bình thường thành `NO_BODIES` với cả năm status bằng 0. Brief §6 của
iteration 055 cấm đúng điều này.

**Iteration 056 vừa trả giá cho cùng một cơ chế hai lần**, với hai thay đổi nhỏ hơn nhiều: đổi bản kết
xuất ISIL đi theo `Blocks` thay vì `ConvertedIsil`, và kết xuất field đã ghép accessor dưới tên
accessor. Cả hai đều đúng, cả hai đều không đụng tới recovery, và cả hai đều dịch EXACT lên hàng trăm
method mỗi fixture. Bất kỳ thay đổi nào chạm vào text mà phép đo neo vào đều phải mang theo baseline
riêng của nó.

## Kiến trúc đề xuất

Một assembly hỗ trợ **duy nhất**, sinh ra một lần cho cả bản rip, mà mọi assembly đã recover tham
chiếu tới:

```
AuxiliaryFiles/GameAssemblies/Recovered.Runtime.dll
  namespace Cpp2ILInjected
    TokenAttribute, AddressAttribute, FieldOffsetAttribute, MetadataOffsetAttribute,
    AttributeAttribute, NativeSourceAttribute        — public, khai báo MỘT lần
    Cpp2ILHelpers                                    — public
    Il2CppRuntime                                    — public
```

Một tên, một assembly, không va chạm. Đây là cách bình thường mà một trình sinh mã xử lý kiểu hỗ trợ
của chính nó, và nó không cần `internal` nên **không đổi cách ILSpy viết attribute ra**.

`Recovered.FrameworkCompat` là một assembly thứ hai, tách riêng vì nó có vòng đời khác: nó chứa các
shim cho ngữ nghĩa framework mà C# không viết được nhưng thân đã recover cần, và mỗi shim phải có bằng
chứng riêng. Iteration 055 đã đo và **không tìm thấy site nào cần nó** cho `List<T>._version`; nó vẫn
rỗng cho tới khi có một site được chứng minh.

## Thứ tự bắt buộc của iteration triển khai

1. **Trước tiên, tháo sự phụ thuộc của phép đo vào text.** `recovery_metrics.py`,
   `placeholder_families.py`, `golden_corpus.py`, `method_recovery_report.py` và
   `check_recovered_shapes.sh` đều khớp `[Address(` / `[NativeSource(` theo chuỗi. Chúng phải nhận cả
   dạng đủ tên **trước** khi assembly hỗ trợ ra đời, và phép nhận ấy phải được kiểm bằng một test đi
   đỏ khi bỏ nó — không thì "0 method có body" và "phép đo không đọc được attribute" in ra cùng một
   thứ.
2. **Baseline riêng.** Rip cả bốn fixture bằng phép đo mới nhưng exporter cũ, rồi bằng cả hai. Ba
   dòng, như iteration 056 đã phải làm.
3. **Assembly hỗ trợ.** `ProjectExporter` sinh `Recovered.Runtime.dll`; `InjectTypeIntoAllAssemblies`
   thay bằng một tham chiếu tới nó. Ràng buộc: bản thân nó phải là một assembly hợp lệ mà
   `compile_recovered_scripts.sh` đưa vào tập tham chiếu, và `.csproj` sinh cho project Unity phải
   liệt kê nó.
4. **Đo CS0433 ở cả hai đầu**, và kiểm rằng `body_recovery_rate` không thành `NO_BODIES` trên bất kỳ
   fixture nào — đó là chế độ hỏng mà brief §6 gọi tên.

## Rủi ro đã biết

- Unity import một `.dll` trong `Assets/` như một managed plugin; assembly hỗ trợ phải nằm cùng chỗ
  với các assembly đã recover khác và phải có `.meta` tương ứng, nếu không project biên dịch được ở
  Roslyn mà không import được ở Unity.
- `Cpp2ILHelpers` và `Il2CppRuntime` có **hành vi** (chúng ném và báo ranh giới native), không chỉ là
  attribute. Gom chúng vào một assembly là đúng, nhưng nó biến một artefact của bản export thành một
  phụ thuộc thật của project đã recover — điều phải nói rõ trong tài liệu bàn giao chứ không để người
  nhận tự phát hiện.
- Nếu một assembly đã recover được biên dịch riêng lẻ (điều `compile_recovered_scripts.sh` làm theo
  từng assembly), nó phải tham chiếu được assembly hỗ trợ; thứ tự build vì thế không còn tuỳ ý.
