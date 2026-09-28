# Vùng quét interface offset — iteration 061 (§23)

Tiếp theo `INTERFACE_SCAN_SURVIVAL.md` (060). Iteration này chỉ **phân loại, dựng lại vùng, chứng
minh chết hoặc không**, và không xoá gì. Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**.

## Phép chứng minh

`InterfaceScanRegionClassifier` chạy cuối `Analyze`, cạnh `IndirectJumpClassifier`, nên thấy đúng cái
generator sẽ thấy. Vùng của một class pointer = slice xuôi từ mọi lệnh đọc `interface_offsets_count`
và `interfaceOffsets` (offset lấy từ bảng StructDb, không viết tay), cộng mọi branch mà điều kiện do
slice tính. Vùng **chết** khi cả ba đúng:

1. không giá trị nào của vùng tới một effect (call, store, return, throw, indirect jump) — mọi lệnh
   đọc giá trị của vùng nằm trong vùng theo cách dựng, nên đây là toàn bộ câu hỏi về dữ liệu;
2. (hệ quả của 1) vùng không có effect;
3. mỗi branch trong vùng tới **đúng một** block ngoài vùng qua các block chỉ chứa lệnh của vùng, `Nop`
   và `Jump` — tức branch chọn giữa hai cách không làm gì.

CFG ở đây không tính post-dominator (`DominatorInfo` để phần đó bị comment), nên điều kiện 3 được viết
thẳng bằng phép duyệt. Test: 4 case, mỗi case đỏ khi bỏ luật nó kiểm.

## Kết quả — MEASURED

| | Impostor | Merge-Room |
|---|---:|---:|
| Vùng quét sống sót | 78 (44 body) | 869 (469 body) |
| **DeadRegionProven** | **26** | **88** |
| ValueEscapes | 50 | 592 |
| ControlDiverges | 2 | 189 |
| Lệnh / memory read trong vùng chết | 286 / 116 | 1034 / 404 |

`ValueEscapes` trên Merge-Room, theo effect nhận giá trị:

| Effect | Vùng |
|---|---:|
| indirect call hoặc jump **qua chính giá trị của vùng** | 340 |
| call tới đích chưa giải quyết | 170 |
| call tới method đã giải quyết (giá trị của vùng là một đối số) | 80 |
| store vào bộ nhớ | 2 |

## Điều này sửa lại kết luận của 060

060 đọc `AIState.EnterState` đến cùng và kết luận vùng quét sống sót là scaffolding sau một lời gọi
**đã** được giải quyết. Điều đó đúng cho method đó — và phép đo nói nó là thiểu số: **340 vùng là một
interface dispatch chưa bao giờ được giải quyết**, lời gọi vẫn là `IndirectCall` qua slot mà vùng
tính ra. Đó là việc của recovery (`InterfaceDispatchRecovery` / `InterfaceInvokeDataRecovery` không
khớp các dispatch đó), không phải việc dọn mã chết. Xoá những vùng đó sẽ xoá chính lời gọi.

80 vùng chảy vào đối số của một lời gọi đã giải quyết là dạng "raw argument layout" đã biết: lời gọi
được đặt tên nhưng vẫn mang thanh ghi nó không dùng. UNKNOWN cho tới khi đọc từng cái.

## Một lỗi của chính walker, tìm ra khi đo

Lần chạy đầu cho **0** vùng chết trên cả hai fixture. Dump `AIState::EnterState` cho thấy branch của vùng
tới block 116 (hội tụ thật) và block 29 — bước lặp `Add v791, v791, 16`. Lệnh đó dùng **một object
local** ở cả vị trí đích và nguồn, và walker bỏ qua mọi operand bằng đích theo tham chiếu, nên nó "không
đọc gì", rơi khỏi vùng, và block của nó thôi là scaffolding. `StorageIdentities.Analyze` có đúng lỗi đó.
Cả hai giờ chỉ bỏ **vị trí** đích (`StorageIdentities.DestinationPosition`). ControlDiverges 277 → 189,
DeadRegionProven 0 → 88.

## Việc tiếp theo

- 340 dispatch chưa giải quyết: dump vài method, xem hình dạng nào hai pass dispatch không khớp.
- 88 vùng chết đã chứng minh: xoá được bằng đúng phép chứng minh này, nhưng phải trong một iteration có
  baseline riêng và so từng body — không nhét vào iteration đang đo dở.
