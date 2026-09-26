# Quét interface offset sống sót sau một lời gọi ĐÃ giải quyết

Sau iteration 060, nhóm `RUNTIME_STRUCT` lớn nhất còn lại trên Merge-Room là phần
quét bảng interface offset: **930** `Il2CppClass.interface_offsets_count`, **840**
`MethodInfo.slot`, **478** `Il2CppClass.interfaceOffsets`, tổng 2248 trên 18.191
unresolved load. Báo cáo này ghi lại chúng là gì, vì đọc tên chúng dễ dẫn tới kết
luận sai.

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`.

## `PROVEN`: lời gọi đã được giải quyết; cái sống sót là scaffolding

`MoreMountains.Tools.AIState::EnterState` là ví dụ đọc được hết. ISIL cuối cùng:

```
block 26  v128 = typeof(System.IDisposable)
block 27  v534 = [v143]                              ; klass của receiver
          v782 = [v534 + 0x12E]                      ; interface_offsets_count
          CheckEqual v537, [v534 + 0x12E], 0
          ConditionalJump @b30, v537
block 28  v791 = [v534 + 0xB0] + 8                   ; &interfaceOffsets[0].offset
block 115 CheckEqual v796, [v791 - 8], [v128]        ; so với IDisposable
          ConditionalJump @b32, v796
block 29  v791 += 16; đếm lùi; lặp lại @b115
block 32  v897 = [v791] << 4
          v898 = v534 + v897
          v900 = v898 + 312                          ; + vtableOffset
block 30  Nop; Nop; Jump @b116
block 116 v125 = [v900 + 8]
          Call IDisposable.Dispose, v553, v143
```

Dòng cuối là điểm mấu chốt: **lời gọi đã là `Call IDisposable.Dispose`**.
`InterfaceDispatchRecovery` đã khớp, đã giải quyết, và slow path ở block 30 đã
thành `Nop`. Cái còn lại — block 27, 28, 29, 115, 32 — là phép tra cứu mà lời gọi
không còn cần tới.

Nên 2248 load này **không phải** lỗi type recovery, cũng không phải dispatch chưa
giải quyết được. Chúng là mã chết sau một lần nhận diện thành công. Ngữ nghĩa của
bản phục hồi đã đúng; cái sai là kích thước và độ nhiễu, cộng với việc mã chết đó
ép ILSpy dựng thêm cấu trúc (CLAUDE.md đã ghi hiệu ứng này cho các injected check
không xoá được).

## `PROVEN`: `TryExciseLookup` không chạy, và một điều kiện của nó là nghi phạm

`InterfaceDispatchRecovery.TryExciseLookup` tồn tại đúng để xoá vùng này, và
iteration trước đã sửa nó ở chỗ "đòi các phi phải chết" — nhưng ở đây nó vẫn không
chạy: nếu có, `head` đã được nối thẳng tới `merge` và năm block kia đã biến mất.

Nó có năm điều kiện: `head == merge`; `TryCollectRegion`;
`region.Contains(slowBlock)`; `RegionIsSideEffectFree`; `AnyValueEscapes`.
**`UNKNOWN`: chưa đo điều kiện nào trong năm điều kiện đó là điều kiện chặn.**
Cách đo là thêm một `IsilDump.Trace` cho mỗi nhánh rồi dump `AIState::EnterState`
— cùng cách iteration 060 dùng để tìm ra ba nguyên nhân im lặng của
`MethodSlotDispatchRecovery`.

**`INFERRED`**: ứng viên mạnh nhất là `v125 = [v900 + 8]` ở block 116 — phép đọc
MethodInfo ẩn khỏi vtable entry, vẫn còn đó và vẫn giữ `v900` sống, nên giữ cả
vùng quét sống. `RewriteDispatch` *có* đặt tên phép đọc đó thành
`RuntimeMethodInfoAnalysisContext`, nhưng chỉ khi base của nó được định nghĩa bởi
**chính phi** mà pass đã khớp; ở đây base là `v900`, giá trị nhánh nhanh, không
phải phi. Đây đúng là hình dạng mà `MethodSlotDispatchRecovery` đã phải xử lý ở
iteration 060: giải phóng MethodInfo ẩn là điều kiện để scaffolding chết.

## Đừng làm gì trước khi đo

Điều kiện chặn phải được đo, không đoán. Iteration 060 đã có một pass đo ra giống
hệt baseline tới từng chữ số vì bản đầu của nó viết theo một hình dạng không tồn
tại ở điểm nó chạy; chỉ một bản dump ISIL tại đúng điểm đó mới nói ra sự thật.

## `BLOCKED`

Không có khẳng định runtime. Unity không tồn tại trong container.
