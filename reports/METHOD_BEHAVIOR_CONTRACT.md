# Hợp đồng hành vi của một method

Iteration 058, §3–§5. Sinh bởi `Test/Scripts/method_behavior_contract.py`, đọc
`AuxiliaryFiles/SemanticIR` — bản ghi mà generator tự viết ra tại đúng lúc nó sinh mã.

## 1. Vì sao cần một tầng nữa

Dự án đã có hai phép đo ngữ nghĩa và cả hai đều mù với luồng điều khiển:

| | so cái gì | không nói được gì |
|---|---|---|
| `recovery_metrics.py` | *lớp* thao tác giữa hai bên | thứ tự, điều kiện, số vòng lặp |
| `method_semantic_contract.py` | *tên* thành viên mà thân hàm chạm tới | như trên |

Một bản phục hồi chạy đúng các thao tác nhưng sai thứ tự, hoặc dưới sai điều kiện, đạt điểm hoàn hảo
ở cả hai. "Mười chín hàng chướng ngại thay vì hai mươi" — khiếm khuyết đã ghi ở iteration 043 — đúng
là hình dạng đó.

## 2. Hợp đồng gồm những gì

```
parameters  return
field reads / writes        static reads / writes       array reads / writes
calls  virtual  interface  delegate  indirect
allocations   throws   runtime boundaries   side_effect_count

control:  blocks  edges  branches  returns  throw_blocks  loop_headers
          conditions[]  = { block, value, decided_by, true_or_false_to }
          exception_edges = 0

value_flow[] = { from, through, to, type }
graph[]      = { id, successors, predecessors, terminator }
```

`conditions` là chỗ §4 và §5 gặp nhau: điều kiện của một nhánh được nối ngược về *thao tác đã sinh
ra nó*, nên `BRANCH` trần trở thành "rẽ nhánh theo kết quả so sánh `hp` với 0".

Ví dụ thật, `MenuMove.Update` trên RunFromZombies:

```
COMPARE CheckLess  ->  v265  <- [v160, #0]
block 10  condition v265  ->  true 11, false 12
CALL UnityEngine.Time::get_deltaTime  -> v160  ->  COMPARE CheckLess
```

## 3. Cạnh ngoại lệ bằng 0, và đó là một phát biểu chứ không phải một lỗ hổng

Đồ thị dựng từ ISIL đã lift, nơi một throw vẫn còn là lời gọi một helper raise của il2cpp. Các pass
viết lại nó thành `OpCode.Throw` không duyệt lại các cạnh, và `UnreachableAfterThrow` tách khối đó
ra. Thân hàm phục hồi cũng không có handler nào để một cạnh như thế đi tới. Nên `exception_edges` là
0 *có lý do*, không phải vì chưa ai đo.

## 4. Con số

Trên bốn bản rip `Test/Out58H-*`:

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| method có hợp đồng | 4615 | 5963 | 17.913 | 8983 |
| có đồ thị | 4615 | 5963 | 17.913 | 8983 |
| có nhánh | 1982 | 2362 | 7384 | 4346 |
| có vòng lặp | 1045 | 1348 | 4101 | 3039 |
| có luồng giá trị | 2844 | 3685 | 11.770 | 6370 |
| có hiệu ứng phụ | 3589 | 4855 | 14.449 | 7406 |
| điều kiện nhánh | 10.448 | 10.660 | 37.664 | 35.028 |
| — truy được về nơi sinh ra | 8536 | 8754 | 30.534 | 24.924 |

*(Merge-Room đo trên bản rip 058 cuối; fixture đó không tất định, xem `docs/RECOVERY_MATRIX.md`.)*

**82% điều kiện nhánh truy được về thao tác sinh ra chúng.** 18% còn lại là điều kiện mà local mang
nó có nhiều hơn một định nghĩa sau khi phá SSA, hoặc được sinh trong một khối không đi tới được.

## 5. Nó bắt được gì, và không bắt được gì

`logic_behavior_corpus.py` đóng băng 293 hợp đồng qua bốn fixture. Nó **ổn định** qua hai bản rip
Merge-Room độc lập (86/86, trên một fixture mà một file `.cs` khác nhau giữa hai lần chạy) và nó
**phân biệt được** (làm hỏng hai entry thì báo đúng hai).

Nó **không** bắt được lỗi mà iteration này tìm ra. Lỗi tham số-thành-local đổi *giá trị được đọc* chứ
không đổi *thao tác được thực hiện*: cùng số field read, cùng lời gọi, cùng đồ thị. Cái bắt được nó
là `source_behavior_oracle.py`, so với chính văn bản lập trình viên viết. Hai phép đo này phân công
như vậy và cần cả hai.
