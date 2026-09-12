# Bảng phân loại nguyên nhân gốc

Lập ở iteration 038 từ `Test/loads-038base.tsv` (2773 unresolved load trên fixture Impostor, ARM64,
metadata v31.1, commit `a9dc8aee`). Phân theo **nguyên nhân**, không theo tên triệu chứng — đây là
lần thứ tư trong dự án một họ đặt tên theo triệu chứng hoá ra là nhiều nguyên nhân khác nhau.

Mức độ chắc chắn dùng đúng bốn nhãn: `CONFIRMED_ROOT_CAUSE`, `LIKELY_ROOT_CAUSE`, `SYMPTOM_ONLY`,
`UNKNOWN`. Một giả thuyết không được ghi thành sự thật.

## Bảng

| Cluster | Số | % | Hình dạng native/IR | Nguyên nhân | Layer | Mức chắc chắn | Trạng thái |
|---|---:|---:|---|---|---|---|---|
| **A** | 651 | 23,5% | `[klass + k]`, `[MethodInfo + k]`, `[static storage + 8]` | Đọc **cấu trúc của chính runtime**. Base đã có kiểu đúng; không có managed field nào để đặt tên. Không phải lỗi gán kiểu. | J. nhận diện pattern | CONFIRMED_ROOT_CAUSE | OPEN |
| **B** | 283 | 10,2% | `Multiply t, i, stride` → `Add u, array, t` → `[u + 0x20(+f)]` | `ElementSize` chỉ biết primitive nên trả 0 cho mọi struct, và phép nhân stride không phải luỹ thừa hai không khớp `ShiftLeft`. Nhưng **fix không an toàn nếu thiếu độ rộng** — xem mục 2. | E/G. memory + type | CONFIRMED_ROOT_CAUSE | **REJECTED ở 038** |
| **C** | 301 | 10,9% | `[base + k]` với k quá field cuối | Đã phân loại ở `reports/BASE_FIELD_OVERFLOW_ANALYSIS.md`: **bốn** nguyên nhân không liên quan nhau. | nhiều | SYMPTOM_ONLY | OPEN |
| **D** | 424 | 15,3% | `generic instance, value type argument` (206), `value type base` (188), `generic instance, reference arguments` (30) | Layout của một instantiation generic, và base là value type nên không lấy được địa chỉ field ngoài. | H/I. field layout + generic | LIKELY_ROOT_CAUSE | OPEN |
| **E** | 100 | 3,6% | `AddressOf(stack_*)` | Ba thứ khác nhau, đã phân loại ở `reports/FRAME_SLOT_ANALYSIS.md` + `reports/INDIRECT_RETURN_BUFFER_ANALYSIS.md`: buffer trả về (đã xử lý ở 036), alloca của thân generic chia sẻ (cần thông tin runtime), spill thường. | E. stack/memory | CONFIRMED_ROOT_CAUSE | PARTIALLY DONE |
| **F** | 221 | 8,0% | base không có định nghĩa nào | Giá trị vào hàm của một thanh ghi, thường bị một lệnh gọi chưa phân giải đọc trước. | F. SSA/use-def | LIKELY_ROOT_CAUSE | OPEN |
| **G** | 619 | 22,3% | base untyped từ Move / Add / call result | Họ lớn nhất còn lại và **chưa được phân loại**. Gần như chắc chắn là nhiều nguyên nhân. | G. type recovery | UNKNOWN | OPEN |
| **H** | 69 | 2,5% | `[hằng số]` | Địa chỉ tuyệt đối; một phần là hằng số của compiler đã xử lý, phần còn lại chưa rõ. | C. lifting | UNKNOWN | OPEN |
| **I** | 105 | 3,8% | còn lại | — | — | UNKNOWN | OPEN |

**Nhận xét quan trọng:** cluster A (651) lớn hơn cluster B gần gấp ba và **không phải lỗi gán kiểu
chút nào** — base đã đúng, chỉ là runtime struct không có managed field. Đếm theo triệu chứng
("unresolved load") gộp nó chung với những thứ hoàn toàn khác.

---

## 2. Cluster B — điều tra đầy đủ, và vì sao bị loại

### Nguyên nhân gốc (CONFIRMED)

Truy vết `DG.Tweening.Plugins.Vector3ArrayPlugin::EvaluateAndApply`:

```
 87 Subtract v664 @ X10_v21, changeValue.Length, 1
101 Multiply v718 @ TEMP_v78, v664 @ X10_v21, 12          ← i * sizeof(Vector3)
102 Add      v424 @ X11_v8, changeValue (Vector3[]), v718 ← array + i*12
110 Add      v723, [v424 + 20], [v425 + 20]               ← array[i].x
112 Add      v420, [v424 + 28], [v425 + 28]               ← array[i].z
```

`ArrayRecovery.ComputedElementAddress` bỏ qua cả hai vì:

1. `ElementSize` chỉ có bảng primitive, trả **0** cho mọi struct, và hàm thoát ngay trước khi nhìn
   bất cứ thứ gì khác. Chú thích trong code nói struct array "được xử lý bởi element-address path",
   nhưng path đó phục hồi `&array[i]` (một phép lấy địa chỉ), không phải lệnh **đọc** qua một địa chỉ
   đã tính sẵn.
2. Stride của `Vector3` là 12, không phải luỹ thừa hai, nên compiler sinh `Multiply` chứ không
   `ShiftLeft` — và chỉ `ShiftLeft` được khớp.

Phân bố addend trong cả cluster (283 load):

| addend | số | ý nghĩa |
|---|---:|---|
| `== 0x20` | 98 | cả phần tử, hoặc thành viên đầu của nó |
| `> 0x20` | 101 | một field bên trong phần tử |
| `< 0x20` | 84 | **chưa phân loại** |

### Thí nghiệm, theo đúng dạng Hypothesis / Experiment / Expected / Observed / Conclusion

**Giả thuyết 1.** Lấy stride của struct từ metadata và khớp cả `Multiply` sẽ phục hồi các lệnh đọc
phần tử mảng mà không mất gì.

- *Thí nghiệm*: `ElementSize` trả 0 thì rơi sang `MetadataElementSize` (đã có sẵn trong cùng file);
  thêm nhánh `Multiply` vào phép nhận diện index.
- *Kỳ vọng*: unresolved load giảm, không có hình dạng sai mới.
- *Quan sát*: load 2773 → **2736** (−37), cluster 283 → 256, generator failures 0, 16 shape check
  PASS. **Nhưng** xuất hiện **7 phép cast `(float)array[i]`** trong khi baseline có **0**:
  `(float)changeValue[num29]`, `(float)localVertices[num2]`, `(float)wps[num11]` — ép một `Vector3`
  thành `float`, thứ C# không có, ở chỗ nguồn viết `array[i].x`.
- *Kết luận*: **LOẠI**. `[t + 0x20]` là địa chỉ của phần tử *và* địa chỉ thành viên đầu của nó; với
  một struct đó là hai giá trị khác nhau, khác độ rộng. Đúng cùng một chỗ nhập nhằng offset-0 đã ghi
  ở iteration 036 và 037, lần này ở một tầng ngoài.

**Giả thuyết 2.** Phương thức tự nói ra cái nào được muốn: một base chỉ được đọc ở **một** offset là
cả phần tử; đọc ở **nhiều** offset là phần tử bị tháo ra từng thành viên. Đây là bằng chứng cấu trúc
có sẵn trong chính hàm, không phải suy đoán.

- *Thí nghiệm*: chỉ fold khi local tính địa chỉ được dùng làm base của đúng một addend duy nhất.
- *Kỳ vọng*: các trường hợp tháo-thành-viên không còn fold, hết cast sai.
- *Quan sát*: load 2773 → 2753 (−20), cast sai **7 → 5**, vẫn **không về 0**.
- *Kết luận*: **LOẠI**. Lọc đúng hướng nhưng không đủ: một phần tử struct đọc ở duy nhất offset
  `0x20` vẫn có thể là `.x` chứ không phải cả phần tử.

### Năng lực còn thiếu

Câu trả lời đúng cho `[t + 0x20 + f]` là **thành viên `f` của `array[i]`**, tức một field reference
mà base là một phần tử mảng. Hôm nay không diễn đạt được:
`FieldReference(FieldAnalysisContext field, LocalVariable local, int offset)` nhận một
`LocalVariable`, nên không lồng được một `ArrayAccess` vào. `AddressOf(ArrayAccess(...))` đã tồn tại,
nên phép lồng không xa lạ với IR — chỉ `FieldReference` là chưa.

Đây là việc đáng làm tiếp, và `CLAUDE.md` đã cảnh báo cái giá: một **operand kind** mới phải dạy
khoảng sáu walker. Nhưng ở đây không cần operand kind mới — chỉ cần nới base của `FieldReference`
thành `IOperand`, và `NestedFieldResolver` (viết ở 037) đã giải quyết sẵn phần chọn field theo
offset và độ rộng.

**Đừng làm lại giả thuyết 1 hoặc 2 nếu chưa có năng lực đó.** Cả hai đã đo, cả hai đánh đổi một
họ cast không hợp lệ *mới* lấy vài chục load được báo — và một hình dạng sai im lặng đắt hơn một
load được báo, đúng như đã ghi nhiều lần.

---

## 3. Việc tiếp theo, theo bằng chứng

1. **Nới base của `FieldReference` thành `IOperand`** để diễn đạt được `array[i].field`. Mở khoá
   cluster B (283) và có thể cả phần "phép ghi phủ nhiều nested field" còn lại từ iteration 037.
2. **Phân loại cluster G (619)** — họ lớn nhất chưa ai mở ra. Phải phân loại trước khi làm, đúng như
   A/C/E đã dạy.
3. **Cluster A (651)** không phải việc gán kiểu: nó là nhận diện một hình dạng runtime rồi bỏ đi,
   giống cách `TypeCheckRecovery` và `InterfaceDispatchRecovery` làm phần của chúng.
