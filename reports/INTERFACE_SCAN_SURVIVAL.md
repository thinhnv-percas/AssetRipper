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

## `PROVEN`: không phải `InterfaceDispatchRecovery` giải quyết nó

Năm điều kiện của `InterfaceDispatchRecovery.TryExciseLookup` đều được gắn một
`IsilDump.Trace` riêng và dump lại `AIState::EnterState`: **không điều kiện nào
in ra một dòng nào**. Nghĩa là `TryExciseLookup` chưa bao giờ được gọi cho lời gọi
này, tức là `MatchDispatch` đã trả về null — `InterfaceDispatchRecovery` không
khớp nó.

Cái giải quyết nó là `InterfaceInvokeDataRecovery`, pass khớp *xuôi* từ lookup tới
dispatch. Và pass đó **cố ý chỉ xoá lời gọi lookup**:

```csharp
// The lookup is what the dispatch used to need; once the call names its method nothing
// reads it. It has to be removed here rather than left to dead code elimination, which
// keeps an unresolved call for its side effects.
foreach (var lookup in lookupsOf[dispatch])
{
    lookup.OpCode = OpCode.Nop;
    lookup.SetOperands();
}
```

Chính tài liệu của pass nói helper có một **fast path nội tuyến**, và đó là lý do
phép khớp phải đi xuôi. Nhưng fast path đó — toàn bộ vòng quét bảng interface
offset — không được xoá ở đâu cả. `InterfaceDispatchRecovery` có máy móc để xoá
(`TryExciseLookup`), nhưng nó chỉ chạy cho những site chính nó khớp.

**`PROVEN`: dead code elimination không thể xoá được vùng này.** Vùng kết thúc
bằng các lệnh nhảy có điều kiện (block 27, 115, 29), và một nhánh là hiệu ứng điều
khiển — mark-and-sweep giữ lại mọi thứ mà một nhánh phụ thuộc vào. Xoá nó bắt buộc
phải là phẫu thuật luồng điều khiển, đúng thứ `TryExciseLookup` làm.

## Việc còn lại, và vì sao nó chưa được làm ở 060

Dùng lại `TryExciseLookup` từ `InterfaceInvokeDataRecovery` không phải một dòng:
pass đó làm việc trên một danh sách lệnh phẳng, không có khái niệm block hay vùng,
nên nó chưa có `head` (block định nghĩa klass local) lẫn `merge` để đưa vào.

Và **ngữ nghĩa của bản phục hồi ở đây đã đúng rồi** — lời gọi đúng method, đúng
receiver. Cái phải trả là kích thước, độ nhiễu, và cấu trúc thừa mà ILSpy phải
dựng. Phẫu thuật luồng điều khiển để đổi lấy những thứ đó, trong khi nó có thể xoá
nhầm mã còn sống, là một việc xứng đáng có iteration riêng với baseline riêng, chứ
không phải một thứ nhét vào cuối một iteration đang đo dở.

## Đừng làm gì trước khi đo

Điều kiện chặn phải được đo, không đoán. Iteration 060 đã có một pass đo ra giống
hệt baseline tới từng chữ số vì bản đầu của nó viết theo một hình dạng không tồn
tại ở điểm nó chạy; chỉ một bản dump ISIL tại đúng điểm đó mới nói ra sự thật.

## `BLOCKED`

Không có khẳng định runtime. Unity không tồn tại trong container.
