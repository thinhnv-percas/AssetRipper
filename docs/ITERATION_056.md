# Iteration 056 — một thao tác được đặt lại tên, và hai phép đo mô tả sai chương trình

## 1. Baseline (§1)

Bốn fixture: Impostor, RunFromZombies, Merge-Room, JellyBlastV2. Pinata không nằm trong acceptance.
Mọi phép đo chỉ chạy **sau khi process thoát**, không theo log line.

Baseline của iteration được đo **ba lần**, vì hai phép sửa đo lường trong chính iteration này làm
dịch mẫu số, và khi đó **cả hai đầu của mọi so sánh phải được đo lại**:

| | EXACT (z / i / m / j) | FALLBACK |
|---|---|---|
| HEAD 056 (`86afb0de`), renderer cũ | 2285 / 2879 / 6634 / 2517 | 405 / 1299 / 1487 / 405 |
| + hai phép sửa đo lường, pass tắt | **2513 / 3776 / 7605 / 2855** | 150 / 346 / 384 / 43 |
| + `InlineListAddRecovery` | **2513 / 3782 / 7671 / 2867** | 150 / 346 / 386 / 44 |

Dòng thứ hai **không phải recovery**. Đó là phép đo lần đầu tiên mô tả đúng chương trình được xuất
ra, và nó phải được đọc như vậy chứ không như một bước nhảy về chất lượng phục hồi.

Invariant, cả bốn fixture: `generatorFailures = 0`; field-layout disagreement **0** (2165/1394/3947/2654
type dựng lại đúng, 0 sai); golden corpus **0 regression**; source oracle RunFromZombies
`semantic_equivalence_rate` **1.0000 (36/36)**; test 487 ca, 1 fail có sẵn từ trước
(`GetMainExportID_ValueGreaterThan100000_DebugAssertFails`, chỉ đỏ ở Release).

## 2. Hai phép đo mô tả sai chương trình (phát hiện, không phải mục tiêu)

`[NativeSource(Body = …)]` là thứ mọi phép đo ngữ nghĩa của dự án đọc như "những gì phân tích phục
hồi được". Nó mô tả **hai chương trình khác** với thứ được xuất ra, vì hai lý do độc lập:

**(a) Nó kết xuất danh sách phẳng, còn generator sinh từ đồ thị.** `PseudoCSharpWriter` đọc
`MethodAnalysisContext.ConvertedIsil` — danh sách mà CFG được dựng từ đó — trong khi `IlGenerator`
lặp `ControlFlowGraph.Blocks`. Một pass gỡ block khỏi đồ thị không đụng tới danh sách phẳng, nên mọi
lệnh của block đã chết vẫn nằm trong bản kết xuất. Hệ quả: **một pass gấp cả một vùng lại đọc ra như
một mất mát** — các thao tác nó bỏ đi vẫn ở phía IR và biến mất ở phía C#. Đó chính là 6 "regression"
đầu tiên mà `InlineListAddRecovery` gây ra, và không cái nào là regression.

**(b) Ghép cặp accessor chạy lúc sinh CIL, không trên ISIL.** Bản kết xuất gọi `list._size` trong khi
thân được xuất ghi `list.Count`. `unmentioned_members` so tên rồi đếm một thành viên mà bản xuất **cố
ý đổi tên** thành một thành viên bị mất. Trên Impostor, đúng **591** method bị xếp FALLBACK vì lý do
này, và cả 591 đều mất **duy nhất** lớp `FIELD` — mẫu của một defect đo lường, không phải của một
defect phục hồi. Ba method đầu được đọc tay để xác nhận: thân là `return IsStarted;`, IR nói
`started`.

`IlGenerator.NameReadsAreWrittenUnder` trả lời bằng **chính quyết định ghép cặp** thay vì phát biểu
lại luật của nó — luật ấy đo từ thân getter, và một bản phát biểu lại sẽ trôi khỏi nó.

**(c) Một array initialiser là một lệnh ghi mảng.** `recovery_metrics.ARRAY_WRITE` chỉ khớp dạng
`array[i] = x`, còn decompiler ghi `new char[2] { '#', 'c' }`. Một method mà lệnh ghi mảng *khác* duy
nhất của nó là đường nhanh `List.Add` được inline, sau khi gấp lại chỉ còn initialiser, và đọc ra như
đã mất một lệnh ghi. Đây là lần thứ ba cùng một cái bẫy ("một call được viết khác nhau ở hai phía").

## 3. `InlineListAddRecovery` (§2–§8)

Xem `reports/INLINE_LIST_ADD.md` cho toàn bộ. Tóm tắt:

- **Neo** là lời gọi `List<T>::AddWithResize` của đường chậm — private của framework, chỉ `Add` gọi.
  Đó là bằng chứng binary mang sẵn, không phải hình dạng đoán từ một lệnh ghi mảng, và là lý do một
  lệnh ghi mảng thường / collection tự viết / indexer setter / `Insert` / `RemoveAt` / lệnh ghi
  dictionary **không chạm tới pass**.
- **Bốn kiểm tra cấu trúc** xác lập vùng sắp xoá đúng là đường nhanh của *chính* receiver ấy. Chúng
  đã bắt được một neo sai: 159 site của Merge-Room có receiver là một địa chỉ tính bằng số học con
  trỏ — địa chỉ của `AddWithResize` bị dùng chung. Từ chối cả 159.
- **Biểu diễn** là một `CallVoid` tới chính `List<T>::Add`, không phải opcode mới: mọi pass phía sau
  đã xử lý đúng một call, còn một opcode mới cần dạy lại sáu walker.
- **Vị trí**: sau `ArrayRecovery` (để `items.Length` là một `ArrayLength`) và ngoài SSA (để xoá đường
  nhanh không để lại phi phải vá).
- **3055 candidate, 2087 gấp (68%)**, 968 từ chối, mỗi cái dưới lý do của nó.
- 16 test, mỗi kiểm tra được ít nhất một test phân biệt (bỏ từng kiểm tra một thì có test đỏ).

## 4. Native plugin iOS (§9–§11)

`reports/IOS_NATIVE_PLUGIN.md`. JellyBlast v2 từ **0 / 6** lên **6 / 6**. Framework được chép nguyên
bundle (binary, `Info.plist`, headers, resources), bỏ lại `_CodeSignature`. Kiến trúc đọc từ header
Mach-O chứ không viết sẵn. `NativeLibraryClassifier` dùng chung giữa exporter và
`runtime_dependency_graph.py`.

## 5. Số cuối

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| EXACT | 2513 | 3782 | 7671 | 2867 |
| HIGH_CONFIDENCE | 192 | 212 | 469 | 81 |
| PARTIAL | 1073 | 1142 | 6743 | 4493 |
| FALLBACK | 150 | 346 | 386 | 44 |
| MISSING | 0 | 0 | 0 | 0 |
| placeholder | 5962 | 4293 | 37507 | 38236 |
| `compile_pass_rate` | 0.9761 | 0.9337 | 0.8929 | 0.8880 |
| `body_recovery_rate` | 0.9618 | 0.9369 | 0.9747 | 0.9941 |
| `reference_resolution_rate` | 1.0000 | 0.9942 | 0.9998 | 1.0000 |
| `shader_exact` | 0 / 24 | 0 / 3 | 0 / 34 | 0 / 30 |
| `native_plugin_preservation_rate` | — (0 plugin) | — (0 plugin) | 1.0000 | **1.0000** |
| lệnh đọc member private `List<T>` | 304 → **46** | 736 → **216** | 1665 → **380** | 2648 → **988** |

Merge-Room báo 15269 method lần này; fixture ấy không tái lập được chính xác (biên ±52 đã ghi ở
iteration 055), nên một chênh lệch dưới khoảng năm mươi method ở đó là nhiễu.

## 6. Còn lại

- `Recovered.Runtime` / `Recovered.FrameworkCompat` và CS0433: vẫn hoãn, vẫn cùng lý do — đổi hình
  dạng của injected type là đổi chính text mà mọi phép đo key vào (`reports/INJECTED_TYPE_COLLISION.md`).
  Iteration 056 vừa trả giá cho đúng điều đó hai lần với hai phép sửa nhỏ hơn nhiều.
- Bản export chưa sinh `.meta` `PluginImporter` cho framework iOS.
- ~200 site `List.Add` không gấp được vì cả hai vế của capacity test chưa resolve thành field — công
  việc type recovery.
- Shader vẫn `DUMMY` toàn bộ, `shader_exact` 0. Đúng theo §18: không gọi Dummy là recovered.
- Unity không có. Stage E–I `BLOCKED`, `runtime_status: NOT_RUN`. Không có claim runtime nào.
