# Lỗi thân Merge-Room Assembly-CSharp — iteration 065 (§2, §3, §4)

Nhãn: **MEASURED**, **PROVEN**, **UNKNOWN**. Công cụ:
- `Test/Scripts/compile_recovered_scripts.sh` (body pass, `BODY_ERRORS_TO`).
- `Test/Scripts/cluster_body_errors.py`, `--self-test` 11/11.

Nguyên liệu trong `iterations/065/compile/`:
- `merge-room-body-errors-{64j,65g,65z}.json`
- `*.raw.txt`

## 1. Cách phân cụm

Một message của Roslyn che nhiều producer khác nhau. Ví dụ `Cannot convert type 'X' to 'nint'` có thể là:
- một vùng quét interface còn sót;
- địa chỉ phần tử mảng;
- một struct bị dùng làm địa chỉ của chính nó;
- một load bỏ cuộc.

Nên mỗi lỗi được đọc **cùng biểu thức tại vị trí của nó** và vài dòng sau đó. Họ được đặt tên theo **producer**, tức tầng
đầu tiên sai, không theo message. Mỗi họ là một luật regex trong bảng `FAMILIES`. Lỗi không khớp luật nào vào `OTHER`,
là phần dư đã đo, không phải phỏng đoán.

## 2. Kết quả — MEASURED

| | 64j | 65g | **65z** |
|---|---:|---:|---:|
| Lỗi thân | 684 | 361 | **324** |
| File compile sạch / 84 | — | 48 | 49 |
| CS0030 | 362 | — | 224 |
| CS0122 | 166 | — | 27 |
| CS0149 | 31 | — | 1 |

## 3. Theo họ

**Họ đã giảm:**

| Họ | 64j | 65z | Tầng sai đầu tiên | Nguyên nhân gốc | Pass sửa | Độ tin cậy |
|---|---:|---:|---|---|---|---|
| `INTERFACE_SCAN_SURVIVOR` | 113 | 29 | ISIL analysis | vùng quét interface còn sống cạnh một dispatch đã giải từ đối số của lookup | `InterfaceDispatchRecovery.TryExciseResolvedLookup(OutOfSsa)`, alias frame X29 | PROVEN |
| `FRAMEWORK_PRIVATE_MEMBER` | 103 | 25 | CIL emission | `List<T>.Clear()` inline (`_size = 0; _version++`); accessor pairing đo receiver struct ở frame boxed trên 2022 | `InlineListClearRecovery`, `FieldOffsetFrame.MethodPointerReceiverIsBoxed` | PROVEN |
| `STRUCT_SELF_FIELD_ADDRESS` | 86 | 4 | ISIL analysis | `this + k` của receiver struct truyền làm `ref` (builder async) | `FieldAddressArguments` (receiver kiểu giá trị, field struct qua con trỏ) | PROVEN |
| `OBJECT_AS_NATIVE_INT` | 104 | 59 | ISIL analysis (typing) | producer là load bỏ cuộc hoặc local không kiểu | các bản sửa producer trong `UNRESOLVED_LOAD_RECOVERY_065.md` | MEASURED |
| `STRUCT_LOCAL_AS_ADDRESS` | 52 | 17 | ISIL analysis | struct trả qua buffer ẩn (X8) mà `Return` trả local; composite hai GPR | `LocalVariables.ReturnHiddenBuffer`, AAPCS64 C.10, `StructRegisterFields` | PROVEN |
| `INTERFACE_METHOD_DELEGATE` | 31 | 1 | ISIL analysis | delegate trên method interface biên dịch thành lookup | `InterfaceInvokeDataRecovery.RecoverInterfaceMethodDelegates` → `ldvirtftn` | PROVEN |
| `INDIRECT_STRUCT_ARGUMENT` | 23 | 12 | ISIL lifting (ABI) | AAPCS64 B.4: composite > 16 byte truyền bằng con trỏ tới bản sao | `IlGenerator` truyền giá trị khi kiểu khớp chính xác | PROVEN |

**Họ còn lại:**

| Họ | 64j | 65z | Ví dụ (65z) | Tầng sai đầu tiên | Bản sửa ứng viên | Độ tin cậy |
|---|---:|---:|---|---|---|---|
| `OTHER` | 50 | 54 | `Func<UniTaskVoid> asyncAction = [AsyncStateMachine(…)] () =>` (CS8773) | nhiều tầng | phân cụm tiếp, không sửa theo message | — |
| `SHARED_GENERIC_PLACEHOLDER` | 25 | 28 | `SetStruct(ref *(System.Int32Enum*)((nint)this + 224), …)` | metadata / type resolution | instantiation chia sẻ cần được đặt lại theo receiver trước khi sinh `ref` | UNKNOWN |
| `ARRAY_ELEMENT_ADDRESS` | 26 | 26 | `nint num3 = (nint)array;` | ISIL analysis | địa chỉ phần tử tính trước vòng lặp | UNKNOWN |
| `UNRESOLVED_LOAD_STANDIN` | 23 | 21 | `return (Sprite)0;` | load resolution | xem `UNRESOLVED_LOAD_RECOVERY_065.md` | MEASURED |
| `STRUCT_FIRST_MEMBER` | 22 | 21 | `(UniTask.Awaiter)adsController._cooldownAdsShow` | CIL emission (offset zero) | độ rộng truy cập phải phân biệt struct với member đầu | UNKNOWN |
| `BASE_CONSTRUCTOR_CALL` | 7 | 7 | `base._002Ector();` | CIL emission | ILSpy không gập base call khi thân có stack type mismatch | UNKNOWN |
| `WIDE_IMMEDIATE_STRUCT` | 6 | 6 | `(…d)4294967295L` | ISIL analysis | — | UNKNOWN |
| `FLOAT_USED_AS_INTEGER` | 5 | 5 | | typing | — | UNKNOWN |
| `UNASSIGNED_LOCAL` | 4 | 3 | | SSA destruction | — | UNKNOWN |
| `STRIPPED_FRAMEWORK_MEMBER` | 3 | 3 | `Math.PI` | stub tham chiếu | không phải lỗi recovery | PROVEN |
| `INLINED_STATIC_PROPERTY` | 1 | 3 | `Vector3.upVector.x` | CIL emission | `upVector` không có property public cùng tiền tố (`Vector3.up` là tên khác) | MEASURED |

## 4. §3 CS0030 và §4 CS0122

- **CS0030 362 → 224.** Không có cast nào được thêm vào C#. Mỗi họ giảm là vì producer (lookup, buffer trả về,
  ABI, load) được sửa. Phần còn lại phân theo producer ở bảng trên.
- **CS0122 166 → 27.** Không có member nào bị đổi private → public để đạt con số này.
  - Phần lớn biến mất vì truy cập vào field private của framework (`List<T>._size/_version/_items`, `this + k`
    của builder) được thay bằng thao tác mà nó là thành phần: `List<T>.Clear()`, field address của receiver.
  - 12 còn lại trong `FRAMEWORK_PRIVATE_MEMBER` là enumerator private (`enumerator2._current`).
  - 11 trong `SHARED_GENERIC_PLACEHOLDER` là `System.Int32Enum`, kiểu placeholder của sharing.
  - Widening của export vẫn theo `SerializedFieldPolicy` / `OverrideAccessibility`, không đổi trong iteration này.

## 5. Regression thật và thay đổi đo

- **REAL_REGRESSION, đã sửa trước khi đóng:** khi alias frame X29 vừa bật, `MMSwap` mất cả hai dispatch invoker và
  tham số `i` bị ghi đè (`i = 0;` trước `list[i]`). Nguyên nhân là copy propagation thay `&slot` bằng `&i`. Sửa ở
  `SsaSimplifier`; 65z dịch `MMSwap` đúng nguồn. `parameter_overwrite_scan.py` trên Merge-Room: 64j 2, khi lỗi có mặt
  10, 65z **0**.
- **REAL_REGRESSION, còn lại:** `ExtensionList.cs` 22 → 25 lỗi (`LayerMaskExtension.cs` 9 → 0 cùng lúc), trong một thân fully shared có alloca kích thước động
  (`sub sp, sp, xN`). Không `ShiftStack` nào mô hình được bước đó, nên các ô sau nó có thể bị đặt tên trùng.
- **MEASUREMENT_CHANGE:** mọi chuyển trạng thái mà `recovery_metrics.py` gán cho `zeroVector`, `oneVector`,
  `identityQuaternion`, `decimal.Zero` hoặc `(x as T)?.M()`.
