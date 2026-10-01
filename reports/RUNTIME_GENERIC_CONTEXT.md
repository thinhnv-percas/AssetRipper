# Runtime generic context và dispatch interface — iteration 064

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Fixture: Merge-Room (Unity 2022.3, ARM64), nơi
062–063 ghi lại 505 vùng quét interface `ValueEscapes` "lấy class interface từ RGCTX". Baseline
`Test/Out63g-m`, sau `Test/Out64f-m`. Bằng chứng từng dispatch: `CPP2IL_DUMP_INTERFACE_CALLS`
(`iterations/064/interface/`).

## 1. Tiền đề "class interface đến từ RGCTX" — đúng một nửa, và nửa kia là một lỗi ABI

Đọc từng method thay vì đếm theo triệu chứng:

- `MoreMountains.Tools.ListExtensions.MMSwap<T>`: class interface **đã có kiểu** —
  `Il2CppClass<IList`1<T>>`, do `RgctxResolver` gán — và lookup gọi slot 0 và 1 (`get_Item`, `set_Item`).
  Cái không khớp là *dispatch*: trong thân generic chia sẻ hoàn toàn lời gọi không đi qua
  `VirtualInvokeData.methodPtr` mà qua `VirtualInvokeData.method->invoker_method` — bộ invoker kiểu reflection,
  nhận đối số dưới dạng mảng con trỏ và ghi kết quả vào buffer. Hai lần load từ kết quả lookup, không phải một.
- `Sirenix.Serialization.Utilities.ImmutableList`1.get_Item`: class interface **đến từ RGCTX thật** —
  `[[[X3 + klass] + rgctx_data] + 0]`. Nhưng `get_Item(int)` chỉ có một tham số: `MethodInfo` phải ở X2. Nó ở
  X3 vì thân này là bản **fully shared** (Unity 2022): một method trả về giá trị kích thước không biết nhận thêm
  đối số `il2cppRetVal` *sau* các tham số và *trước* `MethodInfo`. Calling convention bỏ qua điều đó, nên
  `MethodInfo` thật không bao giờ được gán kiểu và mọi thứ đọc từ nó — `klass`, RGCTX, class interface — cũng
  không.

**Tầng sai đầu tiên** cho nửa thứ hai là `Arm64CallingConventionResolver.ResolveForManaged`, không phải
`InterfaceOf`.

## 2. `FullGenericSharing` — bằng chứng metadata, không phải hình dạng

Một thân là fully shared khi một instantiation đăng ký **tại cùng địa chỉ** mang
`Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType` trong đối số generic — đó là điều generic method table
ghi lại. Build không có full sharing không có instantiation như vậy, nên câu trả lời là false ở mọi nơi và
không gì thay đổi (Pinata 2019.2: 0 thân).

Từ instantiation đó (không từ definition) quyết định từng kiểu: placeholder, hoặc value type dựng từ
placeholder, là "giá trị fully shared"; kiểu tham chiếu dựng từ nó (`List<__Il2CppFullySharedGenericType>`)
vẫn là một thanh ghi. Hệ quả áp ở ba chỗ, cùng một vị từ:

| Chỗ | Thay đổi |
|---|---|
| `Arm64CallingConventionResolver.ResolveForManaged` | thêm một con trỏ `il2cppRetVal` sau tham số, trước `MethodInfo` |
| `BaseCallingConventionResolver.RemapRawArguments` | slot đó tồn tại ở call site nhưng không phải đối số managed |
| `LocalVariables` | local ở thanh ghi đó tên `il2cppRetVal`, kiểu `ReturnType&` |

**MEASURED**: 182 thân trên Merge-Room, 19 trên Impostor, nhận `il2cppRetVal`.

## 3. Phân loại dispatch còn sống — `RuntimeInterfaceResolver`

Chạy cuối `Analyze`, không viết lại gì. Với mỗi indirect call/jump còn sống: con trỏ có tới từ kết quả của
một lookup không; theo đường nào (`METHOD_POINTER`, `INVOKER_THROUGH_METHOD` — offset `invoker_method` đọc từ
bảng đo của struct database, không viết tay — hoặc `TWO_LOADS_OTHER`); class interface đến từ đâu
(`METADATA_USAGE`, `RGCTX_ENTRY`, `TYPED_CLASS_LOCAL`, `METHODINFO_FIELD`, `CLASS_FIELD`, `UNKNOWN_CLASS_SOURCE`);
và vì sao lookup không giải quyết. Mỗi hàng ghi vào `CPP2IL_DUMP_INTERFACE_CALLS` với confidence `UNRESOLVED`
và họ của nó ở cột evidence — cùng file với các hàng `EXACT`, nên corpus chọn từ một nguồn.

Theo dispatch phân biệt (caller, receiver, class, slot), Merge-Room 064:

| Đường : nguồn class : lý do | Dispatch |
|---|---:|
| `INVOKER_THROUGH_METHOD : METADATA_USAGE : DISPATCH_PATH_NOT_RECOVERED` | **46** |
| `METHOD_POINTER : UNKNOWN_CLASS_SOURCE : CLASS_NOT_AN_INTERFACE_POINTER` | 39 |
| `INVOKER_THROUGH_METHOD : UNKNOWN_CLASS_SOURCE : CLASS_NOT_AN_INTERFACE_POINTER` | 31 |
| `TWO_LOADS_OTHER : UNKNOWN_CLASS_SOURCE : …` | 15 |
| `* : * : SLOT_NAMES_NO_METHOD` | 18 |
| `METHOD_POINTER : … : LOOKUPS_DISAGREE_OR_LATE` | 2 |
| `METHOD_POINTER : CLASS_FIELD : …` | 1 |
| **tổng** | **152** |

Log đếm mỗi lần phân tích; mỗi thân được phân tích hai lần (rendering và sinh IL), nên số trong log là gấp đôi.
Bảng trên đếm từ file bằng chứng, khử trùng lặp.

## 4. Cái đã giải quyết — MEASURED

| | 063 | 064 |
|---|---:|---:|
| Dispatch interface giải quyết qua lookup (phân biệt) | 251 | **263** |
| Vùng quét `ValueEscapes` | 505 | 496 |
| `Il2CppRgctx` trong C# xuất ra | 284 | 264 |

Thêm hai nguồn, cả hai không suy đoán:

- `InterfaceOf` nhận một usage kiểu được đưa thẳng làm đối số (`Type: Sirenix.Serialization.IDataWriter`): giá
  trị của usage *là* class pointer, đúng như `SeedRuntimeClassTypes` đọc khi nó được move vào local trước. Ba
  điều kiện của lookup (class interface, slot nhỏ hơn số method, kết quả bị deref và gọi) không đổi.
- `MethodInfo` đúng thanh ghi trong thân fully shared (§2) ⇒ RGCTX có kiểu ⇒ class interface có kiểu.

## 5. Còn lại — UNKNOWN, kèm điều cần để đi tiếp

- **46 dispatch qua invoker với method đã biết chính xác.** Đích là `interface.Methods[slot]` — bằng chứng
  như mọi dispatch EXACT khác. Cái thiếu là *đối số*: invoker nhận `void** args` (một mảng con trỏ trên stack,
  mỗi phần tử trỏ tới một giá trị) và `void* ret`. Dựng lại `list[i]` cần chứng minh từng ô của mảng được ghi
  bằng địa chỉ của giá trị nào trước lời gọi — cùng loại bài toán ô stack đã ghi trong CLAUDE.md
  (`RetargetAddressTakesOverwrittenBeforeUse`), và giá trị kiểu `T` nằm trong buffer `alloca` kích thước
  `stack_slot_size`, không có kiểu tĩnh. Không viết lại: một lời gọi tên đúng với đối số sai là lỗi im lặng.
- **70 với class operand không có nguồn** (`UNKNOWN_CLASS_SOURCE`): phần lớn là `vNNN @ X1` — giá trị vào của
  một thanh ghi, hoặc kết quả của class-init helper (`0x17FDEF4(v60)`) mà chuỗi provenance không đi xuyên.
- **18 `SLOT_NAMES_NO_METHOD`**: interface không generic (`System.Collections.IList`) có slot không khớp
  `Il2CppMethodDefinition.slot` nào — cần đọc riêng.

Không vùng quét nào bị xoá; không RVA implementation nào được bịa cho method interface abstract (cột RVA là
`RUNTIME_DISPATCH`).
