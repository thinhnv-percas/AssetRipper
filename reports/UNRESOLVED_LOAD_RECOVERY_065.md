# Unresolved load recovery — iteration 065 (§7)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Công cụ: `placeholder_families.py`, `cluster_native_int_casts.py --trace`,
log `Il2Cpp method body recovery (065)`.

## 1. Nguyên tắc

Brief §7 cấm sửa `(nint)object` ở đầu ra, và cấm biến unknown thành `object` chỉ để một biểu thức compile được.
`OBJECT_REFERENCE` nint cast là triệu chứng ở use site. Producer của nó (064, `--trace`) phần lớn là
`default(object)`, tức stand-in của một load bị bỏ cuộc. Nên mọi thay đổi ở đây nhắm vào **producer**: load không
được giải, hoặc giá trị không có kiểu. Không có dòng nào thêm cast hay đổi kiểu một local chỉ vì use site cần.

"UnresolvedLoadRecovery" không thành một pass riêng. Mỗi họ load bỏ cuộc có một nguyên nhân khác nhau, ở một tầng
khác nhau, và một pass gom chung sẽ phải đoán. Các bản sửa nằm ở đúng tầng mà load đầu tiên sai.

## 2. Các producer đã sửa — PROVEN (mỗi cái có counter trong log)

| Producer | Tầng sai đầu tiên | Sửa | Merge-Room |
|---|---|---|---:|
| Member trong một static struct field (`Vector3.one.y` ở storage + 0x10) | resolve field | `MetadataResolver.FindNestedStaticFieldPath`; `ldsflda`, hoặc property public khi có | 2695 member |
| Receiver của method pointer struct ở frame sai trên 2022 | CIL emission (accessor pairing) | `FieldOffsetFrame.MethodPointerReceiverIsBoxed` theo bảng adjustor thunk | `Rect.m_Width` … |
| Struct trả qua hidden buffer (X8) mà `Return` trả local | ISIL analysis | `LocalVariables.ReturnHiddenBuffer` (mọi đường đều ghi buffer) | 440 (86 để nguyên) |
| Composite 9–16 byte đi qua hai GPR | ISIL lifting (ABI) | AAPCS64 C.10/C.11; `DefineIntegerCompositeParameters` đặt tên thanh ghi thứ hai | 263 (168 để nguyên) |
| `lsr x, struct_reg, #8k` / phần thấp của thanh ghi struct | ISIL analysis | `StructRegisterFields` | 54 + 41 |
| Struct > 16 byte truyền bằng con trỏ tới bản sao | CIL emission | truyền giá trị khi kiểu khớp chính xác | 57 |
| Field address của receiver struct / field struct qua con trỏ | ISIL analysis | `FieldAddressArguments` | 463 + 150 |
| `List<T>.Clear()` inline | ISIL analysis | `InlineListClearRecovery` (anchor là store 0 vào `_size` cùng `_version++`) | 182 |
| Vùng quét interface sống sót cạnh dispatch đã giải | ISIL analysis | `InterfaceDispatchRecovery.TryExciseResolvedLookup(OutOfSsa)` | 657 |
| Spill qua frame pointer X29 | stack analysis | `StackAnalyzer.ResolveFramePointer` (xem `UNKNOWN_CLASS_PROVENANCE_065.md`) | 5949 truy cập + 1182 địa chỉ |
| `out` local của call tới instantiation chia sẻ có kiểu `System.Object` | typing | guard chia sẻ trong `TypeAddressedLocals` và `PropagateFromCallParameters` | — |

## 3. Kết quả — MEASURED

`UNMANAGED_MEMORY_LOAD` (placeholder do `IlGenerator.cs` phát cho một load không đặt được):

| Fixture | 64j | 65g | **65z** |
|---|---:|---:|---:|
| Merge-Room | 14998 | 13837 | **10198** |
| Impostor | 2486 | 2326 | **2073** |
| RunFromZombies | 2171 | 2046 | **1684** |
| JellyBlastV2 | 23475 | 23364 | **22289** |
| JellyBlastV2 opt-in | 37618 | — | **35946** |
| Pinata | 7443 | 5635 | **4493** |

Producer của `OBJECT_REFERENCE` nint cast (`cluster_native_int_casts.py --trace`):

| | Impostor 64j | Impostor 65g | **Impostor 65z** | Merge-Room 64j | Merge-Room 65g | **Merge-Room 65z** |
|---|---:|---:|---:|---:|---:|---:|
| nint cast tổng | 2544 | 1994 | **1735** | 13002 | 10642 | **8865** |
| `OBJECT_REFERENCE` | 1291 | 963 | **737** | 6055 | 4950 | **3541** |
| … producer `UNRESOLVED_LOAD_STANDIN` | 666 | 392 | **242** | 2485 | 1815 | **1087** |
| `resolved_producer_rate` | 0.2579 | 0.3146 | **0.3731** | 0.368 | 0.3899 | **0.4047** |

Cast giảm mà không có thay đổi nào ở phía cast. Số giảm của nhóm `UNRESOLVED_LOAD_STANDIN` lớn nhất, đúng như dự
đoán khi sửa producer.

## 4. Còn lại — UNKNOWN

- 1087 cast trên Merge-Room vẫn có producer là stand-in. Họ lớn nhất theo `placeholder_families` vẫn là load qua base
  không kiểu, và một phần là cấu trúc runtime (`Il2CppClass`, `MethodInfo`) mà không field managed nào đặt tên được.
- Một ô stack *sau* ô bị lấy địa chỉ trông như chết với mọi pass xoá copy. Với store qua frame pointer, đã sửa bằng
  `KeepStoresReadThroughABaseAddress` (dãy liên tiếp bắt đầu từ ô bị lấy địa chỉ). Với ô SP, giới hạn này vẫn còn
  như trước 065.

## 5. Một store giá trị sai im lặng — PROVEN, đã sửa

Alias frame X29 lộ ra một lỗi có sẵn trong `SsaSimplifier`: thay `&slot` bằng `&i` khi `slot = i`. Một địa chỉ đặt tên
một storage, không phải một giá trị. Sau phép thay, thanh ghi của tham số `i` thành thanh ghi bị lấy địa chỉ, và
`CopyCoalescer.FindEscapedSlotGroups` gộp mọi version của nó thành một storage. Con trỏ method của invoker, nạp vào
cùng X1 sau đó, vì vậy ghi đè `i`: `i = 0;` ngay trước `list[i]` trong `MMSwap`.

Không aggregate nào thấy lỗi này: placeholder, status và Roslyn đều không đổi. Bản sửa chỉ cho phép thay trong cùng
một thanh ghi. Detector mới `Test/Scripts/parameter_overwrite_scan.py` đếm tham số bị gán stand-in ngay sau
placeholder của nó (`--self-test` 2/2):

| Fixture | 64j | khi lỗi có mặt (65r) | 65z |
|---|---:|---:|---:|
| Merge-Room | 2 | 10 | **0** |
| Impostor | 0 | — | 0 |
| RunFromZombies | 0 | — | 0 |
| JellyBlastV2 | 1 | — | 1 (dương tính giả của scanner: dòng `else if (…)` bị đọc là chữ ký) |
