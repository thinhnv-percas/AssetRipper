# Mô hình layout IL2CPP và hệ toạ độ của field offset

Iteration 043. Trả lời câu hỏi nền: **`FieldOffset = X` nghĩa là X byte tính từ đâu?**

Trả lời bằng phép đo trên hai fixture (Impostor ARM64 v31.1, Pinata x86 v24.2) và đối chiếu với
Il2CppDumper, không bằng suy luận.

---

## 1. Các hệ toạ độ

| Tên | Tính từ | Ai dùng |
|---|---|---|
| `OBJECT_INSTANCE_OFFSET` | đầu object, tức đã gồm header | metadata của một **class** |
| `VALUE_TYPE_OFFSET` | đầu dữ liệu của chính value | metadata của một **struct** |
| `BOXED_VALUE_OFFSET` | đầu object đã box, tức value + header | `GenericInstanceFieldLayout`, và receiver của method của chính struct |
| `NATIVE_DISPLACEMENT` | con trỏ base trong lệnh máy | operand `[base + addend]` sau lifting |
| `RUNTIME_STRUCTURE_OFFSET` | đầu một struct của runtime | `Il2CppClass`, `Il2CppMethodInfo`, static field storage |

Hai điều quan trọng, và cả hai đều phản trực giác:

1. **`OBJECT_INSTANCE_OFFSET` và `BOXED_VALUE_OFFSET` là cùng một thứ** khi type là class — vì
   metadata của class đã gồm header. Chúng chỉ tách nhau ở value type.
2. **`NATIVE_DISPLACEMENT` không cố định thuộc hệ nào.** Nó thuộc hệ mà **con trỏ base** đang ở.
   Đây là kết luận của iteration 042 và không đổi.

---

## 2. Header là gì

Il2CppDumper phát ra layout dưới dạng C struct (`Outputs/StructGenerator.cs`, ~dòng 1095):

```c
struct T_o {
    T_c *klass;      // chỉ khi !IsValueType
    void *monitor;   // chỉ khi !IsValueType
    T_Fields fields; // luôn luôn
};
```

Nên header là **hai con trỏ**, không phải hằng số 16: `2 * pointerSize`, tức 0x10 trên 64-bit và
0x8 trên 32-bit. `FieldOffsetFrame.HeaderSize` nói đúng điều đó, và có test cho bản 32-bit.

Metadata của IL2CPP tự nó đã dùng hai khung: `Il2CppTypeDefinitionSizes.instance_size` của một value
type là kích thước **đã box** — cả `TypeSizes.UnboxedSize` lẫn `GenericInstanceFieldLayout` đều trừ
header ra để lấy kích thước dữ liệu — trong khi *field offset* của cùng type đó lại tính từ 0.

---

## 3. Metadata offset lấy từ đâu

`FieldAnalysisContext.BackingData.FieldOffset`, đọc từ bảng `fieldOffsets` của global-metadata.

- class → `OBJECT_INSTANCE_OFFSET`
- struct → `VALUE_TYPE_OFFSET`
- **field của một generic instance → không có gì cả.** `ConcreteGenericFieldAnalysisContext` dựng
  bằng `base(null, …)` nên `BackingData` là null; còn field của một generic *definition* thì metadata
  ghi tất cả ở 0. Đây là lý do `GenericInstanceFieldLayout` tồn tại.

---

## 4. `LayoutOf` hoạt động thế nào — và nó ở khung nào

`LayoutInto(definition, args, pointerSize, 2L * pointerSize, laid)` — đi chuỗi base trước, rồi field
của chính type, cộng dồn kích thước với alignment. Nó **bắt đầu ở `2 * pointerSize` cho mọi type**,
kể cả struct.

`SelfCheck` đối chiếu phép đi này với offset metadata thật, và đó là phép tự kiểm chứng duy nhất có
được. Nhưng nó bỏ qua:

- `type.IsValueType` — mọi struct;
- `metadataOffset > 0` — mọi field ở offset 0, tức field đầu của mọi struct.

Nên nó chưa bao giờ có gì để nói về struct. `ValueTypeSelfCheck` phủ cả hai chỗ mù, và **đếm riêng
hai cách đọc thay vì tự chọn một**:

| fixture | struct có offset đo được | ở `metadata+header` | ở `metadata` | ở không cái nào | không dựng được |
|---|---:|---:|---:|---:|---:|
| Impostor (ARM64, v31.1) | 598 | **547** | **0** | 11 | 40 |
| Pinata (x86, v24.2) | 458 | **435** | **0** | 5 | 18 |

**Kết luận: `LayoutOf` đúng về thứ tự và alignment của struct, và nó trả về `BOXED_VALUE_OFFSET`.**
Không một struct nào tái lập ở khung metadata, trên cả hai kiến trúc.

### 11 và 5 ca "không cái nào"

Toàn bộ là union `[StructLayout(LayoutKind.Explicit)]`:

```
System.Decimal      [flags meta=0 got=10, hi meta=4 got=14, lo meta=8 got=18,
                     mid meta=C got=1C, ulomidLE meta=8 got=20]
System.Variant, System.Numerics.Register, UnityEngine.UIElements...StyleValue
```

`Decimal.ulomidLE` nằm **chồng** lên `lo` và `mid` ở meta=8. Một phép đi tuần tự không diễn tả được
field chồng nhau, và mọi field *không* chồng của chúng vẫn tái lập đúng ở metadata+header. Đây là
giới hạn đúng của mô hình, không phải lỗi, và không nên "sửa".

---

## 5. `GenericInstanceFieldLayout` với generic

`FindFieldAtOffset(definition, offset, genericArguments)` và `OffsetOfField` là cùng một phép đi đọc
theo hai chiều. `genericArguments` có mặt để một field kiểu `T` được tính kích thước đúng: thiếu nó
thì `T` được tính như một con trỏ, đúng cho reference type và sai cho struct.

`LayoutInto` cũng đi lên base chain, và khi base là generic instance thì nó lấy
`baseInstance.GenericType` cùng `ArgumentsFor(...)`. Vì vậy layout nó trả về **phủ cả chuỗi base** —
đây chính là lý do iteration 041 phải thêm luật "một mắt xích chỉ trả lời cho field nó tự khai báo".

---

## 6. Boxing, nested struct, array element

- **Boxing**: một struct đã box là header + dữ liệu. Receiver mà il2cpp trao cho method của chính
  struct đó trỏ vào header, nên `Rect.set_x` ghi ở `[X0 + 0x10]` cho field metadata ghi ở 0.
- **Nested struct**: offset cộng dồn trong *khung của value*. `FsmColor.value` ở 0x38 cộng
  `Color.g` ở 0x4 là 0x3C. `NestedFieldResolver` làm phép đi này, có kiểm tra độ rộng.
- **Array element**: phần tử nằm inline trong mảng, ở `elementsOffset` (0x20 trên 64-bit) cộng
  `index * stride`. Field bên trong phần tử tính trong khung của value.

---

## 7. Offset 0

Offset 0 là một offset **hợp lệ và phổ biến**: field đầu của mọi struct. Nó không được dùng làm
sentinel cho "không biết".

Chỗ đã vi phạm điều này và đã được ghi nhận:

- `SelfCheck` lọc `metadataOffset > 0`, nên chưa bao giờ kiểm chứng field đầu của bất cứ type nào.
  `ValueTypeSelfCheck` cố ý không có bộ lọc đó.
- `OffsetOfInstanceField` dùng `field.Offset >= 0` chứ không `> 0` — đúng, và comment tại chỗ ghi rõ
  vì sao: một test cho offset dương đọc field đầu của struct thành "không biết" và vì thế **không
  ghép được gì trên bất kỳ struct nào trong bất kỳ game nào**.
- `CoordinateEvidence` (042) đánh dấu addend 0 và addend 0x10 là **bằng chứng yếu**, vì ở mỗi khung
  chúng khớp field đầu một cách tầm thường.

---

## 8. Lỗi tìm được: cộng header hai lần

`IlGenerator.OffsetOfInstanceField`:

```csharp
owner.GenericParameters.Count > 0
    ? GenericInstanceFieldLayout.OffsetOfField(owner, field)   // BOXED_VALUE_OFFSET
    : field.Offset                                             // VALUE_TYPE_OFFSET / OBJECT_INSTANCE_OFFSET
```

rồi cả hai nhánh đi qua `AccessorOffset`, cộng header khi `owner.IsValueType`.

Với một **generic value type**, header rơi vào hai lần: `metadata + 0x10 + 0x10`. Phép ghép accessor
không thể khớp bất cứ thứ gì.

Đo trên đường chạy thật (đếm tại chỗ generator báo cáo, không phải ở processing layer chạy trước đó):

```
Impostor: 2538 lượt đo offset, 262 owner value type, 60 owner generic mở, trong đó 2 là value type
Pinata:   7434 lượt đo offset, 167 owner value type, 128 owner generic mở, trong đó 5 là value type
ghép được trên generic value type: 0 trên cả hai
```

`FieldOffsetFrame` đặt tên hai khung, và hai phép chuyển là nghịch đảo nhau nên không thể cộng cùng
chiều hai lần.

**Giá trị đo được: không một file .cs nào đổi trên cả hai fixture.** Họ bị ảnh hưởng là 2 và 5 field,
vốn đã không ghép được vì lý do khác. Giữ lại vì đường code đó *có chạy* (60 và 128 lượt) và cho câu
trả lời sai ở đó — khác với ứng viên bị loại ở iteration 042, nơi probe đếm được 0 lượt đạt tới.

---

## 9. Test synthetic

Bảy test, cố ý không dùng fixture: "X byte tính từ đâu" là thuộc tính của mô hình layout, không của
binary nào, và đo nó trên một game trộn lẫn ngữ nghĩa mô hình với những gì lifter làm ra từ một lệnh
cụ thể.

Phủ: class (không đổi ở cả hai chiều), struct offset 0, struct offset > 0, round-trip cả hai chiều
cho cả hai loại, cộng hai lần **không** bằng cộng một lần, và header trên 32-bit là 8 chứ không phải
16.

Ba lần phá code có chủ ý đều làm test đỏ: bỏ hẳn phép chuyển (4 đỏ), hardcode header thành 16
(1 đỏ), cộng header cho cả class (2 đỏ).

---

## 10. Bằng chứng ngoài

- **Il2CppDumper** (`Outputs/StructGenerator.cs`): `T_o` phát `klass` và `monitor` chỉ khi
  `!IsValueType`; `AddParents` chỉ đi lên chuỗi cha khi `!IsValueType && !IsEnum`. Xác nhận độc lập
  cả header của class lẫn việc value type không có header.
- **`clericall/il2cpp-wasm-teardown`** (wiki ISIL): "Object Header: offset `0x00`–`0x0F`. First
  Custom Field: luôn bắt đầu ở offset 32 (`0x20`)" cho một MonoBehaviour — tức header 0x10 cộng
  0x10 field của `UnityEngine.Object`. Chỉ nói về class; không đề cập value type.
  `measure-bodies.py` chạy lại trên bản rip này: Assembly-CSharp **96,06% live**, không đổi.
- **`jakzo/Il2CppDecompiler`**: `NOT_RUN` (cần Ghidra, output Il2CppDumper, và `OPENAI_API_KEY`).
  Không có đối chiếu P-code nào được thực hiện và không được ghi là đã làm.

---

## 11. Giả thuyết bị loại

- **"Value type cần cộng 0x10" như một luật chung** — bị bác bỏ bằng số đo ở iteration 042
  (77 VALUE_RELATIVE chống 29 OBJECT_RELATIVE trên native displacement). Iteration 043 không đảo lại
  kết luận đó: 547/0 nói về **layout tính được**, còn 77/29 nói về **displacement trong mã máy**. Hai
  phép đo về hai thứ khác nhau và cả hai đều đúng.
- **"`LayoutOf` sai với struct"** — sai. Nó đúng về thứ tự và alignment; nó chỉ ở một khung khác
  metadata, và khung đó nhất quán.
- **11 ca "không cái nào" là lỗi layout** — sai. Chúng là union explicit-layout.

---

## 12. Còn lại

`RESOLVABLE` vẫn 48 và `NEITHER` trong `CoordinateEvidence` vẫn 163. Cả hai cần luật nói **con trỏ
base có được bằng cách nào** — receiver của method của chính struct, ô stack, static storage, hay
field của object khác — chứ không cần thêm số học offset. Đó là công việc trên IR, không phải trên
mô hình layout, và mô hình layout giờ đã đủ rõ để phát biểu luật đó.
