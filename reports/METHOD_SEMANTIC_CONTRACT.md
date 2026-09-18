# Hợp đồng ngữ nghĩa của method — và nguồn sự thật mà nó đọc

Iteration 057, §3 đến §9. Sinh bởi `Test/Scripts/method_semantic_contract.py` từ
`AuxiliaryFiles/SemanticIR`, ghi ra `reports/method-contracts/<fixture>.json`.

## Vấn đề mà nó giải

Iteration 056 tìm ra ba lỗi đo lường có cùng một gốc: **phép đo suy lại một thân hàm làm gì bằng cách
đọc hai bản kết xuất của nó** — `[NativeSource(Body = …)]` bên IR, C# đã decompile bên kia — rồi so
những thao tác mà mỗi bên *có vẻ* gọi tên.

| lỗi | hệ quả |
|---|---|
| bản kết xuất đi trên `ConvertedIsil`, generator sinh từ `ControlFlowGraph.Blocks` | một pass gấp cả một vùng lại đọc ra như một mất mát |
| ghép cặp accessor chạy lúc sinh CIL, không trên ISIL | 591 method của một fixture bị xếp FALLBACK vì bản xuất **đổi tên** `_size` thành `Count` |
| `ARRAY_WRITE` chỉ khớp `array[i] = x` | `new char[2] { '#', 'c' }` đọc ra như đã mất một lệnh ghi |

Cả ba đều là suy diễn từ văn bản, và không có gì về mặt cấu trúc ngăn cái thứ tư.

## Nguồn sự thật

`RecoveredSemanticIr` được **generator ghi tại đúng lúc nó sinh mã**. Mọi canonicalization generator
thực hiện — ghép cặp accessor, `List<T>.Add` đã gấp lại, một lệnh ghi packed tách theo các field nó
phủ — được ghi ngay khi quyết định được đưa ra.

```
Native → ISIL → CFG → semantic recovery → DCE → ControlFlowGraph.Blocks
                                                      │
                                        ┌─────────────┴─────────────┐
                                        ↓                           ↓
                             RecoveredSemanticIr                   CIL → C#
                             (bản ghi, không đọc lại)
```

Nó là một **bản ghi**, không phải một IR thứ hai mà generator đọc lại. Không gì phía sau generator đọc
nó, nên nó không thể đổi thứ được xuất ra — và điều đó được kiểm chứ không phải được tuyên bố: bản rip
**giống hệt tới từng byte** so với baseline 056 trên cả bốn fixture (`diff_recovered_scripts.sh`,
`only-in-one: 0  content-differs: 0`).

## Tập thao tác canonical

33 thao tác, §4. Hai thứ được khai báo và **không bao giờ được sinh**, và điều đó được báo ra:

| | vì sao |
|---|---|
| `CAST`, `UNBOX` | generator không phát `castclass` hay `unbox` bao giờ. Một cast trong C# xuất ra là ILSpy kết xuất một stack type mismatch, không phải một thao tác recovery quyết định. |
| `ARRAY_CREATE` | chính là `NEW_ARRAY`. Một array initialiser là một `newarr` và một `stelem` mỗi phần tử, nên `new char[2] { '#', 'c' }` đã ghi `NEW_ARRAY + ARRAY_STORE + ARRAY_STORE` — §7.3 được thoả bằng cấu trúc chứ không bằng một luật khớp chuỗi. |
| `SWITCH` | generator phát `br`/`brtrue`; một switch là nhiều nhánh. `LOOP` thì có, vì một back edge là một sự thật về đồ thị và được ghi từ đồ thị. |

## Kết quả

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| thân hàm được ghi | 4615 | 5963 | 17.913 | 8983 |
| EXACT | 2433 | 3704 | 7670 | 2722 |
| HIGH_CONFIDENCE | 142 | 138 | 417 | 68 |
| PARTIAL | 1073 | 1142 | 6816 | 4587 |
| FALLBACK | 278 | 496 | 501 | 163 |
| MISSING | 0 | 0 | 0 | 0 |
| FOLDED_BY_DECOMPILER | 181 | 439 | 717 | 886 |
| ASSEMBLY_NOT_EXPORTED | 492 | 19 | 494 | 541 |
| NOT_EXPORTED | 16 | 25 | 1298 | 16 |

Số method được ghi **nhiều hơn** số method có `[Address(` trong bản xuất, và cả ba lý do đều được gọi
tên chứ không đếm chung:

- `FOLDED_BY_DECOMPILER` — `<Foo>d__1::MoveNext`, `<>c__DisplayClass::<Play>b__0`. Decompiler gấp một
  state machine thành `yield` và một display class thành lambda, nên chúng không còn method riêng
  trong bản xuất. Đó là decompiler làm đúng việc của nó.
- `ASSEMBLY_NOT_EXPORTED` — assembly được recover nhưng chỉ ship dưới dạng stub DLL, theo thiết kế.
- `NOT_EXPORTED` — phần còn lại, một ẩn số trung thực.

## Vì sao FALLBACK ở đây cao hơn `recovery_metrics.py`

Phép kiểm này **chặt hơn**: nó đòi *tên* của từng thao tác substantive mà IR ghi lại phải xuất hiện
trong C#, chứ không chỉ *lớp* thao tác. Mỗi ngoại lệ phải phát biểu được, nếu không phép kiểm lặng lẽ
ngừng kiểm thứ gì:

| ngoại lệ | vì sao |
|---|---|
| `op_*` | một toán tử — `Object.op_Equality(a, b)` là `a == b` |
| `GetTypeFromHandle` | `typeof(T)` là thứ compiler dịch thành lời gọi này |
| `Item`, `Chars` | indexer là `x[i]` ở cả hai phía |
| `Invoke` | gọi delegate là `d(x)` |
| `Concat` | `string.Concat` là thứ `a + b` biên dịch thành |
| `.ctor` khi caller là `.ctor` | lời gọi base trong constructor chỉ viết được dưới dạng initialiser, và decompiler bỏ nó khi nó là cái ngầm định |
| tên bắt đầu `<` | thành viên do compiler sinh, thuộc về construct mà decompiler đã gấp lại |

## Giới hạn

- Contract mô tả **thao tác**, không mô tả **giá trị**. Hai method đọc cùng một field và tính khác
  nhau có cùng contract. Đó là ranh giới của phép đo tĩnh, và `runtime_equivalence.py` là thứ vượt qua
  nó — khi có Unity.
- `side_effects` là tập lớp thao tác, không phải một phân tích hiệu ứng thật.
