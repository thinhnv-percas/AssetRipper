# Iteration 037 — độ rộng phép ghi, và một tiền đề sai được sửa

Fixture chính: `Test/Input/Impostor` (ARM64, v31.1). Cổng kiểm chứng: `Test/Input/Pinata` (x86, v24.2).

## 1. Kết luận ngắn: tiền đề của task sai

Iteration 036 và brief của iteration 037 đều giả định rằng ba `mangled_ctor` mới sinh ra vì:

> máy ghi **4 byte** vào field `level` dài 24 byte, nên đích đúng phải là `this.level.currentCryptoKey`.

**Đo lại thì không phải.** Trace đúng chỗ quyết định cho:

```
NARROW? field=level type=ObscuredInt accessSize=16 size=20
```

Phép ghi rộng **16 byte**, và `ObscuredInt` dài **20 byte**, không phải 24. Layout thật (đọc từ chính
bản rip):

| offset | field |
|---|---|
| 0x0 | `currentCryptoKey` (int) |
| 0x4 | (int) |
| 0x8 | (int) |
| 0xC | (int) |
| 0x10 | `fakeValueActive` (bool) |

16 byte ở offset 0x30 phủ **đúng bốn field đầu**, 0x0–0xF, lát kín không dư. Cộng thêm một phép ghi
1 byte ở 0x40 (`fakeValueActive`) là copy trọn cấu trúc.

Nên đích **không phải một nested field**. Nó là một phép ghi phủ bốn nested field, lát kín — đúng họ
mà `IlGenerator.PackedFieldsCovered` xử lý cho trường hợp phẳng, nhưng ở đây một tầng sâu hơn.

Và `Expected O, but got I4` đến từ **phía nguồn**, không phải phía đích: `[returned + 0]` được đặt
tên là `currentCryptoKey` (4 byte) trong khi thứ được tiêu thụ là 16 byte. Đó chính là chỗ nhập nhằng
offset-0 mà iteration 036 đã ghi là "không có bằng chứng" — và **bằng chứng còn thiếu chính là độ
rộng của phép ghi tiêu thụ nó**, thứ iteration này tìm ra.

Kết quả: `mangled_ctor` vẫn là 7. Không giảm. Ghi thẳng như vậy.

## 2. Bảy `mangled_ctor`, phân loại

| file | mới ở 036? | chẩn đoán kèm theo | nguyên nhân |
|---|---|---|---|
| `ItemArtifact.cs:68` | có | `Expected O, but got I4` | ghi 16 byte phủ bốn nested field (mục 1) |
| `ItemDistinc.cs:28` | có | `Expected O, but got I4` | như trên |
| `ItemStack.cs:48` | có | `Expected O, but got I4` | như trên |
| `Item.cs:20` | không | `Expected I4, but got I8` | khác họ, chưa điều tra |
| `Item.cs:43` | không | 13 mismatch đủ loại | khác họ |
| `ResourcesUtil.cs` | không | — | khác họ |
| `EventDispatcher.cs:239` | không | **không có mismatch nào** | base call không được hoisted lên đầu; không phải họ stack-type-mismatch |

`EventDispatcher` là phản ví dụ đáng chú ý: nó có `base._002Ector()` mà **không** mang một stack type
mismatch nào, nên lời giải thích "ILSpy không gấp được base call khi có mismatch" không phủ hết cả
bảy. Ít nhất hai nguyên nhân khác nhau cùng sinh ra hình dạng này.

## 3. Cái đã làm — `NestedFieldResolver`

Chỗ hỏng trong `MetadataResolver`: có **hai đường** phân giải field.

1. `field.BackingData?.FieldOffset == memory.Addend` → khớp offset chính xác → trả về ngay.
2. Không khớp → `FindNestedFieldPath` đi xuống trong ruột value type.

Đường 1 **không hề nhìn độ rộng**. Một offset rơi đúng lên một field không chứng minh rằng cả field
đó được truy cập.

Đã tách phần tìm kiếm ra `Source/External/Cpp2IL.Core/Analysis/NestedFieldResolver.cs`, viết qua
delegate thay vì qua `TypeAnalysisContext`, nên tự nó kiểm thử được mà không cần metadata.

**Hai vị trí không đối xứng, và đó là cố ý:**

- Ở relative offset **khác 0**: field ngoài không phải một câu trả lời hợp lệ, nên offset là toàn bộ
  bằng chứng và không cần độ rộng. (Hành vi cũ, giữ nguyên.)
- Ở relative offset **bằng 0**: field ngoài *cũng* là một câu trả lời hợp lệ, nên muốn chọn field
  trong phải có bằng chứng thêm — độ rộng phải khớp **đúng** field trong, và offset đó chỉ được có
  **một** field. Hai field cùng offset là layout chồng lấn, không gì ở đây nói được cái nào.

Trạng thái `visited` khoá theo `(type, offset)` chứ không chỉ theo type.

## 4. `generatorFailures` bắt được một lỗi tự gây, trước mọi phép đo khác

Bản đầu tiên cho **loads 2773 → 1615**, nhìn như một thắng lợi lớn. `generatorFailures` **0 → 308**.

Nguyên nhân: khi chuyển khối `if (field == null) { … continue; }` vào trong guard mới, nhánh
`field == null` **và** guard sai (owner là generic instance) không còn `continue`, nên rơi xuống
`new ConcreteGenericFieldAnalysisContext(field, genericOwner)` với `field == null` →
`NullReferenceException`, 308 thân hàm.

Con số load đẹp lên chỉ vì 308 thân hàm không còn sinh ra gì cả. Đúng như `CLAUDE.md` đã ghi: **đếm
`Cpp2IL [Error] : Decompiling` trước, trước mọi phép đo khác.**

## 5. Đo

Pass chạy: **20 lần** trên Impostor (40 lần từ chối vì không field trong nào giải thích được độ rộng),
**247 lần** trên Pinata (103 lần từ chối). Dòng log này in ra mỗi lần chạy.

**Impostor (ARM64)** — chỉ 5 file đổi, và cả 5 nằm **ngoài** `Assembly-CSharp` (DOTween, spine-unity,
spine-unity-examples), nên audit trên `Assembly-CSharp` không nhúc nhích. Đây đúng là bài học đã ghi:
*Assembly-CSharp giữ chưa tới một phần mười số load; một fix rơi chỗ khác đọc ra như trơ.*

| | 036 | 037 |
|---|---:|---:|
| unresolved loads | 2773 | 2773 |
| generator failures | 0 | 0 |
| file `.cs` | 819 | 819 |
| REAL_ERROR (Assembly-CSharp) | 861 | 861 |
| `mangled_ctor` | 7 | 7 |
| shape checks | 16 PASS | 16 PASS |
| `(Vector2)num` (toàn bộ rip) | 31 | **27** |
| `Expected O, but got F` (toàn bộ rip) | 338 | **333** |

**Pinata (x86, v24.2)** — mọi metric ổn định giống hệt, và pass chạy nhiều hơn hẳn:

| | 036 | 037 |
|---|---:|---:|
| method not found | 4052 | 4052 |
| file `.cs` | 3083 | 3083 |
| unmanaged loads | 9061 | 9061 |
| generator failures | 0 | 0 |
| `(Vector2)num` | 7 | **5** |
| `(Vector3)num` | 32 | **29** |
| `(Quaternion)num` | 2 | **1** |
| `Expected O, but got F` | 309 | **303** |

Test suite: 307 → **320** (thêm 13), 319 pass, một fail có sẵn từ trước không đổi.

Roslyn: **NOT RUN** — môi trường này không có `csc.dll` dưới .NET SDK.

## 6. Mẫu ngữ nghĩa

`SpineboyFootplanter`, và đây là hình dạng của cả 20 lần:

```csharp
// trước — cast từ một float sang Vector3, mất y và z
//IL_xx: Expected O, but got F4
float num = worldPosPrev.x + delta;
worldPos = (Vector3)num;

// sau — 4 byte ở offset của một Vector3 12 byte là thành viên x của nó
float x = worldPosPrev.x + delta;
worldPos.x = x;
```

`footN.worldPos = (Vector3)num` → `footN.worldPos.x = x` ở hai chỗ nữa trong cùng file.

## 7. Việc tiếp theo, với bằng chứng đã có

**Tách một phép ghi phủ nhiều nested field.** `IlGenerator.PackedFieldsCovered` đã làm đúng việc này
cho trường hợp phẳng (`MemoryOperand.Size` + `FieldReference.AccessSize` + "các field phủ lát kín
khoảng"). Trường hợp ở đây giống hệt nhưng sâu hơn một tầng: 16 byte ở offset của `level` lát kín bốn
field đầu của `ObscuredInt`. Cả phía đích lẫn phía nguồn đều cần nó, và nó là thứ duy nhất còn lại
giữa ba `mangled_ctor` mới và một câu trả lời đúng.

**Đừng làm lại**: nới lệnh đọc offset-0 thành cả giá trị (đã loại ở 036, ba lần đặt pass đều không
chạy). Bằng chứng mới — độ rộng của phép ghi tiêu thụ — không làm cho *cả giá trị* thành câu trả lời
đúng: 16 byte không phải 20, nên đó vẫn là một phép copy bộ phận và phải tách thành bốn field.
