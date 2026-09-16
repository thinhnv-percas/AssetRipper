# Iteration 051 — con trỏ đến từ đâu, và ai nói tên nó

## 1. Baseline (§2)

Dựng lại toàn bộ số liệu 050 trên Impostor trước khi đổi bất cứ thứ gì. Mọi con số tái lập đúng tới
từng chữ số: `EXACT` 2852, `HIGH_CONFIDENCE` 157, `PARTIAL` 1158, `FALLBACK` 1315, `MISSING` 0,
placeholder 4502, unresolved load 2711, 819 file `.cs`, `generatorFailures` 0, field layout
self-check 1394 exact / **0 disagreed**, test 413 pass / 1 fail (lỗi có sẵn).
`METHODINFO_POINTER_AT_0x0` không còn trong bảng phân loại — xác nhận 050 đã phân giải hết 56 lời gọi
qua `methodPointer`. Ghi tại `iterations/051/BASELINE.md`.

Một điểm phải nói ngay: **bước xác minh kho method vàng trong bản baseline đó là rỗng**, và mục 5
dưới đây giải thích vì sao.

## 2. §3 — mục tiêu chính, và nó là gì

Brief đặt `LOADED_POINTER` làm mục tiêu và yêu cầu dựng hệ thống pointer provenance. Việc đầu tiên là
đọc 264 trường hợp đó ra một file chứ không suy đoán về chúng. Chúng gom thành hai hình dạng:

| địa chỉ được gọi | số | hình dạng |
|---|---|---|
| `0xAD947C` | 106 | `(MethodInfo*, Il2CppClass*)` → object; `[obj]` rồi `[klass + 0x1A8]` |
| `0xB349B4` | 58 | `(receiver, Il2CppClass* của một interface, slot)` → `[kết quả]` hoặc `[+0x10]` |

`0xB349B4` bắt đầu bằng `ldr x21,[x0]` / `mov x20,x1` / `mov w19,w2` — nó đọc class của receiver, giữ
lại interface class và slot. Đó là helper tra cứu interface invoke data. Slot là **hằng số** ở cả 58
điểm gọi, và interface class hoặc là metadata usage (26) hoặc là một load của usage slot (32) — cả hai
dạng đều nói ra interface.

`0xAD947C` là một veneer hai lệnh (`ldr x1,[x0,#klass]; b 0xB39C60`) trả về một object mà mã sau đó
gọi virtual ở slot 7. Nguồn là `Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name)` trong các
dummy client của GoogleMobileAds. **Đây không phải bài toán phân loại con trỏ**: nó là một lời gọi
virtual bình thường mà kiểu trả về của helper không ai gọi tên được — một ranh giới runtime.

## 3. Phục hồi: interface call biên dịch thành tra cứu lúc chạy

`InterfaceInvokeDataRecovery` nhận ra hình dạng của call site, không phải địa chỉ. Ba điều kiện độc
lập: đối số thứ hai là runtime class của một *interface*, đối số thứ ba là hằng số nhỏ hơn số method
của interface đó, và giá trị trả về bị deref rồi gọi.

Slot là chỉ số của method bên trong interface — đúng cách runtime dùng nó,
`vtable[interfaceOffset + slot]`, offset đến từ class của receiver lúc chạy còn slot từ interface.
Nên method cần tìm đúng bằng `interface.Methods[slot]`.

**Kiểm chứng ngữ nghĩa**, không phải kiểm chứng con số: `ExposedList<T>.AddCollection` quay về đúng

```csharp
int count = collection.Count;
...
collection.CopyTo(items, size);
```

`ICollection<T>` slot 0 = `get_Count`, slot 5 = `CopyTo` — khớp nguồn Spine, và số diagnostic trong
thân hàm đó đi từ 12 xuống 8.

Ba điều học được, mỗi điều tốn một vòng đo:

1. **Toán hạng 0 của một `Call` là đích, toán hạng 1 là giá trị trả về**, nên đối số bắt đầu từ 2.
   Bản đầu lệch một chỉ số và khớp đúng 0 trường hợp.
2. **Lệnh sinh ra con trỏ hầu như không bao giờ đứng ngay trước chỗ dùng nó.** Cả 592 dispatch cách
   lệnh ấy ít nhất một `Move` hoặc một `Phi`. `PointerProvenance` là phép đi ngược đó, tách riêng để
   dùng lại và test được không cần metadata.
3. **Phép so khớp phải chạy xuôi.** Helper có fast path nội tuyến, nên con trỏ mà dispatch đọc là một
   phi hợp nhất kết quả helper với một địa chỉ vtable do chính trình biên dịch tính — và một phép đi
   ngược thì *đúng đắn* mà từ chối chọn một input của phi. Đi xuôi hỏi một câu chỉ có một đáp án.

Pass chạy hai lần: trong SSA (nơi phi tường minh) và sau khi ra khỏi SSA (nơi load đã gấp vào dispatch
và slot đã thành hằng số). Không chỗ nào thấy được thứ chỗ kia thấy.

Impostor 48 dispatch, Pinata 90.

## 4. §7 — `LOADED_POINTER` tách làm năm

`LoadedPointerKind` hỏi cái gì *sinh ra* con trỏ mà load đọc qua, chứ không hỏi load trông thế nào,
và đi xuyên qua một chuỗi load-qua-load. Nó không viết lại lệnh nào.

| | Impostor | Pinata |
|---|---|---|
| `NATIVE_POINTER` (từ một lời gọi không phân giải được) | **124** | 197 |
| `UNKNOWN:ENTRY_VALUE` | 38 | 98 |
| `UNKNOWN:PRODUCERS_DISAGREE` | 22 | **769** |
| `DELEGATE_POINTER` | 0 | 61 |
| `ARRAY_DATA_POINTER` | 0 | 24 |
| `STACK_POINTER` | 0 | 18 |
| `METHOD_POINTER` | 2 | 0 |

Hai phần ba số còn lại trên Impostor là **ranh giới runtime**, không phải thất bại suy kiểu — thêm
luật suy kiểu ở đó không đổi được gì. Phân bố hai fixture khác hẳn nhau, đúng như mọi họ khác trong dự
án này phân bố theo lựa chọn lệnh của trình biên dịch chứ không theo chương trình.

## 5. §15 — compare-and-swap, gọi tên bằng thứ nó làm

050 ghi rằng `0xAF4130` nhận 339 lời gọi chưa phân giải, 339/339 caller là accessor `add_`/`remove_`,
và mã ở đó là một vòng compare-and-swap — nhưng **luật tìm ra** nó thì không có, nên 050 không sửa gì.

`AtomicIntrinsicRecognizer` đọc lệnh. A64 chỉ có một cách viết compare-and-swap trước LSE: load độc
quyền, so sánh, store độc quyền tới **cùng** địa chỉ. Bit độ rộng và bit thứ tự bộ nhớ cố ý nằm ngoài
mặt nạ — `0xAF41CC` là dạng 32-bit còn `0xAF4130` là 64-bit.

Kiểm chứng ngoài phần test tổng hợp: luật nhận đúng cả **bốn** điểm vào trên test game — `0xAF4130`
(cái không chuỗi thunk nào với tới) cùng `0xAF41A4`, `0xAF41CC`, `0xAF4164` (ba cái metadata với tới
được từ `Interlocked::CompareExchange`). Ba cái sau xác nhận họ này là gì; luật nhận ra cái thứ tư
bằng mã của nó.

Mười case tổng hợp, mỗi case lắp ở một địa chỉ khác nhau, địa chỉ không bao giờ là input.

Impostor 339 `ATOMIC_COMPARE_EXCHANGE` (`RUNTIME_HELPER` 718 → 355). Pinata 238 + 16
`ATOMIC_EXCHANGE`. **Báo, không viết lại**: một ánh xạ sai làm hỏng 339 event accessor theo kiểu im
lặng, và việc chọn overload (`ref object` / `ref int` / generic) là một quyết định nữa mà bằng chứng
hiện có chưa quyết được.

## 6. Kho method vàng đã ba lần không đo gì cả

Khóa của kho vàng tính tương đối so với thư mục game **bên trong** bản rip, nên chĩa phép kiểm tra lên
`Test/Output051` thay vì `Test/Output051/Impostor` thì không khớp một khóa nào — và script vẫn in
`improved 0, regressed 0`. Đúng lời cảnh báo đã ghi trong CLAUDE.md về chuyện khác: một phép đo chưa
từng chạy đọc y hệt một phép đo không tìm thấy gì.

Thêm nữa, luật hợp nhất khi chọn lại **đã được viết ra** trong CLAUDE.md mà code không có: nhánh
`--select` bỏ qua `--corpus` và ghi đè tệp, nên 61 method đóng băng sẽ bị thay sạch bằng 165 method
mới.

Sau khi sửa cả hai: 61/61 có mặt, phân bố trạng thái y hệt giữa bản rip 050 và 051, improved 0
regressed 0. Kho mở rộng lên **165** và bản rip 050 đối chiếu với baseline mới cũng cho improved 0
regressed 0 — nên phép so sánh giữa hai iteration là có nghĩa.

## 7. §20 — chốt chặn cho lỗi đo của 050

Một phép đo giờ **từ chối** báo số từ bản rip đang còn được ghi. 050 để một watch kích hoạt theo một
dòng log thay vì theo tiến trình thoát và báo 280 file `.cs` so với 819, 1845 method so với 5482 — đọc
như regression tệ nhất lịch sử dự án trong khi chỉ là ảnh chụp một thư mục đang được điền. Phân biệt
giữa "bản rip này nhỏ" và "bản rip này chưa xong" là điều không con số nào nói được; chỉ log nói được.
`Test/Scripts/test_measurement_completeness.sh`, 10 case, 2 trong số đó đỏ khi gỡ chốt chặn ra.

## 8. Số liệu

### Impostor

| | 050 | 051 | Δ |
|---|---|---|---|
| `EXACT` | 2852 | 2852 | 0 |
| `HIGH_CONFIDENCE` | 157 | 157 | 0 |
| `PARTIAL` | 1158 | 1158 | 0 |
| `FALLBACK` | 1315 | 1315 | 0 |
| phục hồi không kèm đồ thế chỗ | 3009 | 3009 | 0 |
| placeholder | 4502 | **4455** | −47 |
| `METHOD_NOT_FOUND` | 715 | **691** | −24 |
| `INDIRECT_CALL` | 207 | **183** | −24 |
| `LOADED_POINTER` | 236 | **188** | −48 |
| unresolved load | 2711 | 2712 | +1 |
| Roslyn Assembly-CSharp | 344 | 344 | 0 |
| **field layout** | 1394 / **0 bất đồng** | 1394 / **0** | 0 |
| `.cs` / `genFail` | 819 / 0 | 819 / 0 | 0 |

### Pinata (§21 cổng kiểm chứng độc lập)

| | 050 | 051 | Δ |
|---|---|---|---|
| `EXACT` | 9634 | 9634 | 0 |
| `PARTIAL` | 3043 | 3043 | 0 |
| phục hồi không kèm đồ thế chỗ | 10097 | 10097 | 0 |
| placeholder | 14233 | **14166** | −67 |
| Roslyn Assembly-CSharp | 1481 | 1481 | 0 |
| **field layout** | 3170 / **0 bất đồng** | 3170 / **0** | 0 |
| `.cs` / `genFail` | 3083 / 0 | 3083 / 0 | 0 |

Trạng thái ngữ nghĩa không đổi trên cả hai fixture là **đúng như mong đợi**: 48 và 90 dispatch phục
hồi được nằm rải trong những method vốn đã mang nhiều placeholder khác, nên chúng bớt placeholder mà
chưa vượt qua ranh giới trạng thái nào.

Test 414 → **448** (1 lỗi có sẵn, `GetMainExportID_ValueGreaterThan100000_DebugAssertFails`).

## 9. Không làm, có chủ ý

- **Không ánh xạ `0xAF4130`** sang `Interlocked.CompareExchange`: đã có luật nhận diện, chưa có luật
  chọn overload.
- **Không đụng 34 ô vtable thật** (§10): 050 đã xác lập đó là "tra cứu slot không thấy gì", tức việc
  của metadata chứ không phải của suy kiểu.
- **Không gọi tên `0xAD947C`**: nó là một veneer hai lệnh tới một hàm runtime không được export, và
  đặt cho nó một kiểu trả về mà không có bằng chứng metadata thì là bịa.
- **Không chạy Unity** (`UNITY_NOT_AVAILABLE`), không chạy audit đối chiếu nguồn (nguồn không có mặt
  trong container này).
