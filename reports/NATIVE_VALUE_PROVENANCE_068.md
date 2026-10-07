# Provenance của giá trị native — iteration 068 (§3, §5, §6, §7, §9, §15, §16)

Nhãn: **PROVEN**, **INFERRED**, **UNKNOWN** — ghi tại từng mục.

## 1. Công cụ: một hàng cho mỗi local không kiểu được đọc

`CPP2IL_DUMP_UNTYPED=<file>` (068) ghi từ `Il2CppIlRecoveryOutputFormat`, đúng chỗ một local bị khai báo `object`. Mỗi
hàng gồm:
- assembly, type, method, RVA, tên local;
- opcode ISIL định nghĩa nó và địa chỉ native của lệnh đó (`Instruction.NativeAddress`, gắn ở lifter ARM64);
- số định nghĩa, lần đọc đầu tiên;
- chuỗi định nghĩa phía sau. Call được viết `Type::Name` hoặc `0xADDR`.

`Test/Scripts/untyped_producers.py` gom các hàng thành họ producer:
- ENTRY_VALUE, UNRESOLVED_CALL_ARGUMENT, RUNTIME_HELPER_RESULT, MANAGED_CALL_RESULT, UNRESOLVED_LOAD, FIELD_ADDRESS;
- ARRAY_ELEMENT_ADDRESS, SHARED_GENERIC_ALLOCA, INTERFACE_METADATA, INTEGER_ARITHMETIC, MERGE, OTHER.

Với `--errors`, mỗi lỗi `OBJECT_AS_NATIVE_INT` (luật của `cluster_body_errors`) được gắn với producer của cùng method.
Phép gắn đi theo method, không theo biểu thức, nên là **INFERRED**. `--self-test` có 11 case.

Không sửa cast nào ở output (§0, §28). Mọi thay đổi ở 068 đều nằm ở producer.

## 2. OBJECT_AS_NATIVE_INT theo producer (68e, Assembly-CSharp)

| | Gắn được / không | Producer lớn nhất |
|---|---|---|
| Impostor | 8 / 11 | INTEGER_ARITHMETIC 7, MANAGED_CALL_RESULT 1 |
| Merge-Room | 40 / 10 | ENTRY_VALUE 15, INTEGER_ARITHMETIC 11, MANAGED_CALL_RESULT 6, SHARED_GENERIC_ALLOCA 3, RUNTIME_HELPER_RESULT 3 |
| JellyBlastV2 | 108 / 76 | INTEGER_ARITHMETIC 30, ENTRY_VALUE 28, MERGE 23, RUNTIME_HELPER_RESULT 22 |
| RunFromZombies | 0 / 0 | — |

Đọc được ba điều.

- **Phần lớn của cả họ là local đọc trước khi bị ghi.** Toàn bộ local không kiểu: Impostor 2395, Merge-Room 2975,
  JellyBlastV2 9618. Trong đó 2254, 2816 và 7765 chỉ được đọc bởi một call không giải quyết được. Generator không load
  toán hạng của call đó, nên các local này không tốn gì.
- **Phần còn lại tập trung ở ba producer:**
  - `ENTRY_VALUE`: thanh ghi đọc trước khi bất cứ gì trong method ghi nó. Đây chính là hình dạng mà §10 làm hẹp lại cho
    đối số của call;
  - `INTEGER_ARITHMETIC`: thường là `this + k`, tức địa chỉ field còn dạng số học;
  - `SHARED_GENERIC_ALLOCA`: `stack_slot_size + 15`.
- **`UNKNOWN_PRODUCER` là phần "không gắn được".** Merge-Room 10, JellyBlastV2 76. Đó là lỗi không có local không kiểu
  nào trong cùng method, nên giá trị đến từ biểu thức chứ không từ local. Báo đúng là UNKNOWN, không đoán.

## 3. ARRAY_ELEMENT_ADDRESS (§6) — 26 lỗi Merge-Room, phân theo stride

Mọi phép gập `array + i * stride` thành `array[i]` cần hai bằng chứng: index và stride đều phải chứng minh được.

| Nhóm | File (số lỗi) | Stride | Kết luận |
|---|---|---|---|
| Thân generic chia sẻ hoàn toàn | ExtensionList (5) | `[Il2CppClass<T[]> + 0x104]` = `element_size`, đọc lúc chạy; phần tử chép bằng memcpy `stack_slot_size` (0xFC) | **PROVEN không gập được.** Không có stride tĩnh. |
| Stride giữ trong thanh ghi qua vòng lặp | ExtensionMesh (8) | `mov w9, #12` trước vòng và trên back edge: phi của một hằng 12 = `sizeof(Vector3)` | **PROVEN, đã sửa ở 068.** |
| Member đầu ở offset 0 của phần tử struct | SlicedFilledImage (7), RoomObject (3), GameInstaller (1) | `i << 3` trên `Vector2[]`, đọc `[t + 0x20]` | Đây là sự mơ hồ offset 0 (036–039): địa chỉ phần tử và địa chỉ member đầu là một số. Phía load không mang độ rộng. **UNKNOWN**, để nguyên. |
| Khác | ExtensionDraw (1), Outline (1) | — | Chưa phân loại. |

**Luật mới:** `ArrayRecovery.ScaledIndexBehind` nhận một factor là local khi *mọi* định nghĩa tới được nó, qua copy và phi,
là cùng một hằng bằng stride metadata (`ConstantHeldBy`).
- Chỉ trả lời trên `DefinitionMap`, map biết local nào có hơn một định nghĩa. Ngoài SSA, map chỉ giữ định nghĩa cuối
  nên không thể nói thay các định nghĩa khác.
- Một phi gặp lại trên vòng không đóng góp gì mới.

Test âm:
- stride đọc lúc chạy (`[klass + 0x104]`, local không định nghĩa, shift theo thanh ghi), với 4/8/12/16;
- phi của hai hằng khác nhau;
- local có nhiều định nghĩa;
- `Dictionary` thường không có số định nghĩa;
- bản sao của một load.

## 4. STRUCT_FIRST_MEMBER (§7) — nửa đầu của một cặp store

Merge-Room có 18 lỗi, ví dụ `_direction = (Vector3)num29;` trong `JoystickVirtual`. ISIL là
`this._direction = v147; this._direction.y = v149`: lệnh `stp s0, s1, [x0, #off]` ghi x và y của một `Vector3`.
- Nửa thứ hai nằm sau đầu field, nên offset đủ chứng minh member `y`.
- Nửa đầu ở đúng đầu field. Theo luật 037, chỉ độ rộng mới phân biệt được field với member đầu của nó.

Lifter chỉ cho `STP` một độ rộng *stack* (`stackSize`), không cho độ rộng truy cập trên base heap. Vì vậy nửa đầu đến với
`Size = 0`, và resolver gọi tên cả field.

**Sửa — PROVEN từ encoding:** mỗi nửa của một store pair ghi đúng độ rộng thanh ghi của nó (`PairAccessWidth`: S/W 4,
D/X 8, Q 16), trên mọi base. Test giải mã `stp s0, s1, [x0, #0x30]`, `stp x8, x9, [x0, #0x10]` và `stp w8, w9, [x0, #8]`.

Ghi chú 067 ở chỗ này nói độ rộng heap được giữ nguyên "để logic packed-field không đổi". Đó là một lựa chọn thận trọng,
không phải một phép đo. Với độ rộng, một store pair đi qua đúng luật mà `STR` cùng độ rộng đã đi từ 046.

## 5. Shared generic (§9)

`SetPropertyUtility.SetStruct<T>(ref T currentValue, T newValue)` với `T` là một enum: il2cpp chia sẻ thân dưới
placeholder `System.Int32Enum`. Lời gọi trỏ tới instantiation chia sẻ, nên `ref m_FillDirection` (kiểu
`SlicedFilledImage.FillDirection`) không type-check với `ref Int32Enum`.

`MetadataResolver.InstantiateMethodParameterOn` dựng lại callee trên kiểu của chính field mà đối số trỏ tới, khi:
- tham số gốc là `T` hoặc `ref T` với `IL2CPP_TYPE_MVAR`;
- placeholder chấp nhận kiểu đó (`SharingPlaceholderAdmits`): `Int32Enum` nhận enum nền `int`, `Object` nhận kiểu tham
  chiếu không phải tham số generic.

Merge-Room: 2 instantiation, `SetStruct(ref m_FillDirection, value)`.

## 6. Constraint-based typing (§15) và miền phi con trỏ/số nguyên (§16)

Không có luật mới ở 068. Hai lý do, cả hai đọc được từ phép đo ở trên.
- Phần lớn local không kiểu là thanh ghi một call đã làm hỏng. §10 cắt chúng khỏi tập đối số tại gốc, nên không cần một
  ràng buộc kiểu nào để "giải thích" chúng.
- `MERGE` (JellyBlastV2 429 local, 23 lỗi) là chỗ một miền phi con trỏ/số nguyên sẽ có tác dụng. Mỗi hàng của dump đã mang
  đủ chuỗi định nghĩa để thiết kế luật đó trên dữ liệu. Chưa viết; ghi là việc tiếp theo, kèm hình dạng.
