# Value-flow recovery — iteration 064

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Bản rip baseline: `Test/Out63g-*` và
`Test/Out63o3-i` (063). Bản rip sau: `Test/Out64f-*`. Nguyên liệu: `iterations/064/`.

## 1. Lỗi gốc: một managed reference bị ghi *vào* thay vì ghi *qua*

Triệu chứng (oracle độc lập của 063, UGUI có source upstream khớp khai báo):

```csharp
// trước
public unsafe static bool SetColor(ref Color currentValue, Color newValue)
{
    if ((float)currentValue == newValue.r)
    {
        Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [currentValue @ X0 (UnityEngine.Color&)+4]");
        ...
    currentValue = ref *(Color*)newValue;
    _ = newValue.g; _ = newValue.b; _ = newValue.a;
    return true;
}
// sau
public static bool SetColor(ref Color currentValue, Color newValue)
{
    if (currentValue.r == newValue.r && currentValue.g == newValue.g && currentValue.b == newValue.b && currentValue.a == newValue.a)
        return false;
    currentValue.r = newValue.r; currentValue.g = newValue.g; currentValue.b = newValue.b; currentValue.a = newValue.a;
    return true;
}
```

Hai tầng sai, theo thứ tự chuỗi native → SSA → producer → storage → type → expression:

| Tầng | Sai thế nào | Bằng chứng |
|---|---|---|
| **storage → type** (đầu tiên) | `MetadataResolver.ResolveFieldOffsets` lấy `local.Type` làm owner; với `Color&` owner là một byref, không khai báo field nào, nên `[currentValue + 4]` không bao giờ thành `currentValue.g` | operand dump: `[currentValue @ X0 (UnityEngine.Color&)+4]` ở cả đọc lẫn ghi |
| **expression** | `IlGenerator.StoreToOperand` cho `MemoryOperand` offset 0 gọi `StoreLocal(base)` — tức `starg currentValue`, gán lại tham chiếu | IL: `ldarg newValue; starg currentValue`; ILSpy viết đúng điều đó: `currentValue = ref *(Color*)newValue` |

Sửa ở cả hai, không theo tên method:

- `MetadataResolver.ValueTypeReferent`: base là `T&` với `T` là struct ⇒ tra field của `T` theo offset
  value-relative (một managed pointer trỏ vào dữ liệu, không vào object box). Store được phép — khác struct
  local, ghi qua con trỏ không ghi vào bản sao. Primitive và enum bị loại trừ: `ref float minY` tại +0 là
  chính `minY`, không phải `Single.m_value` (lần chạy đầu sinh ra `minY.m_value = float.MaxValue` — đã đo và sửa
  trước khi giữ).
- `IlGenerator`: store tại offset 0 qua managed reference là `stobj T` (giá trị đã trên stack được cất vào
  scratch, nạp con trỏ, nạp lại giá trị); load là `ldobj T` cho mọi referent — `ldind.ref` trên một `ref T`
  với `T` là struct đọc byte đầu của struct như một tham chiếu. `DestinationType` của store như vậy là referent,
  nên số 0 ghi qua `out VariableDeclaration value` là `null`, không phải `(VariableDeclaration)0`.

## 2. Abstraction chung — `Cpp2IL.Core/Analysis/ValueFlow.cs`

`ValueKind`: `Unknown, RValue, LValue, Address, RefAlias, ObjectReference, NativePointer, ManagedReference,
StructValue, ArrayElement, FieldAddress, MethodInfo, Il2CppClass, GenericContext`. `KindOf(type)` đọc từ
type context (byref → ManagedReference, pointer → NativePointer, `Il2CppClass`/static storage → Il2CppClass,
RGCTX table → GenericContext, generic parameter → **Unknown**, không đoán).

`StoreSemantics` / `LoadSemantics` là nghĩa IL của một store/load trên một operand:

| Operand | Store | Load |
|---|---|---|
| local | `AssignLocal` (stloc/starg), hoặc **`RebindReference`** khi local là managed reference và giá trị không phải địa chỉ | `ReadLocal` |
| `[ref + 0]` | `WriteThroughReference` (stobj) | `ReadThroughReference` (ldobj) |
| `[native pointer + 0]`, `[object + 0]` | `Discarded` | `Unresolved` |
| field / element | `StoreField` / `StoreArrayElement` | `LoadField` / `LoadArrayElement` |

`RebindReference` là bất biến được bảo vệ: chỉ hợp lệ khi giá trị là một địa chỉ (`ref x = ref y`). Generator
và đo lường hỏi cùng một luật (`ValueFlow.WritesThrough`), cùng lý do `LocalStorage.For` tồn tại.

Semantic IR thêm `LOAD_INDIRECT` / `STORE_INDIRECT` (ghi qua `ref`/`out` là hiệu ứng caller thấy được;
`method_semantic_contract.py`, `method_behavior_contract.py` tính nó là side effect).

## 3. Cùng họ: địa chỉ field truyền cho tham số `ref`

`FieldAddressArguments`: tham số của callee là `ref T`, đối số là local được định nghĩa một lần bằng
`object + hằng`, và một field kiểu `T` nằm đúng offset đó ⇒ đối số là `&object.field` (`ldflda`). Ba điều
kiện, mỗi cái một match sai sẽ trượt. Đây là luật `CompareExchangeRecovery.FieldAddressed` đã dùng, áp dụng ở
mọi nơi chữ ký của callee nói cần managed reference. (Hình dạng còn lại: base là một field load đã gập
— `(nint)this.lexer + 32` — chưa được nhận, vì `FieldReference` không lồng được làm base.)

## 4. Số đo — MEASURED

Ba hình dạng của lỗi này trong C# xuất ra:

| Bản rip | `= ref *(` (gán lại ref) | `Expected Ref` (stack mismatch) |
|---|---:|---:|
| Impostor 063 → 064 | 143 → 47 | 26 → 9 |
| Merge-Room 063 → 064 | 842 → 185 | 92 → 33 |
| JellyBlastV2 opt-in 063 → 064 | 1000 → 536 | 76 → 46 |

Bản rip opt-in JellyBlastV2 đổi 108 file khi sửa §1; mọi diff đã đọc đều là một trong: ghi qua ref
(`result = audioClip2` thay vì `result = ref *(AudioClip*)…`), mất `unsafe`, mất `Expected Ref`. Không một
aggregate nào thấy được lỗi này trước đó — đúng như CLAUDE.md ghi cho lỗi storage, lần thứ tư.

## 5. Regression test

- `Il2CppValueFlowTests` (8): mỗi hàng của bảng §2, hai case đầu đỏ với luật cũ (store `[ref+0]` là
  `WriteThroughReference`; giá trị gán vào local managed reference là `RebindReference`).
- C# sinh ra: `check_recovered_shapes.sh` có shape `SetColor` (không còn `= ref *(Color*)`, có
  `currentValue.g = newValue.g`) — chạy trên bản rip opt-in, vì UGUI bị stub ở bản mặc định.

## 6. Còn lại — UNKNOWN

- 47 / 185 / 536 `= ref *(` còn lại phần lớn là `ref T x = ref *(T*)((nint)obj.field + k)`: base là một field
  load đã gập, và `out float a, out float b` truyền hai ô stack liền nhau (`(nint)worldX | 4`).
- `.m_value` (35 / 209 / 115) **không đổi**: đó là truy cập qua một con trỏ primitive *không* phải byref
  (local kiểu `int*`/native int), họ khác.
