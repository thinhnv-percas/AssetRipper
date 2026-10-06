# Lỗi thân Roslyn — Merge-Room và JellyBlastV2, iteration 067 (§5–§8, §15)

Nhãn: **MEASURED**, **PROVEN**, **UNKNOWN**.

Đo: `compile_recovered_scripts.sh Test/Out67x-m Assembly-CSharp`, body pass, rồi `cluster_body_errors.py`. Họ đặt
theo producer (tầng đầu tiên sai), không theo message. Baseline: `iterations/066/metrics/bodyerr-66i-m.txt`.

## 1. Merge-Room: 310 → 298

| Họ | 66i | 67x | Phân loại |
|---|---:|---:|---|
| OBJECT_AS_NATIVE_INT | 59 | 59 | không đổi |
| OTHER | 48 | 46 | — |
| FRAMEWORK_PRIVATE_MEMBER | 24 | **38** | EXPECTED_CHANGE (§2) |
| INTERFACE_SCAN_SURVIVOR | 29 | 29 | không đổi (§4) |
| SHARED_GENERIC_PLACEHOLDER | 28 | **9** | NEW_COVERAGE (§2) |
| ARRAY_ELEMENT_ADDRESS | 26 | 26 | không đổi |
| STRUCT_FIRST_MEMBER | 21 | 21 | không đổi |
| UNRESOLVED_LOAD_STANDIN | 19 | 19 | không đổi |
| INDIRECT_STRUCT_ARGUMENT | 12 | 12 | không đổi |
| STRUCT_LOCAL_AS_ADDRESS | 12 | 12 | không đổi |
| BASE_CONSTRUCTOR_CALL | 7 | 7 | không đổi |
| WIDE_IMMEDIATE_STRUCT | 6 | **1** | NEW_COVERAGE (kickoff async, xem `STRUCT_STORAGE_IDENTITY_067.md`) |
| FLOAT_USED_AS_INTEGER | 5 | 5 | không đổi |
| STRUCT_SELF_FIELD_ADDRESS | 4 | 4 | không đổi |
| UNASSIGNED_LOCAL, STRIPPED_FRAMEWORK_MEMBER, INLINED_STATIC_PROPERTY | 3 / 3 / 3 | 3 / 3 / 3 | không đổi |
| INTERFACE_METHOD_DELEGATE | 1 | 1 | không đổi |

## 2. SHARED_GENERIC_PLACEHOLDER 28 → 9, FRAMEWORK_PRIVATE_MEMBER 24 → 38 — cùng một thay đổi

Một thân generic chia sẻ của `List<T>.Enumerator.MoveNext` là `List<object>.Enumerator.MoveNext`. Một receiver kiểu
value type mà luật gán kiểu receiver lấy từ *callee* thì nhận kiểu placeholder: enumerator của `List<EItem>` thành
`List<object>.Enumerator`, `Current` đọc ra `object`, và cast về `EItem` là CS0030.

067 thêm guard `SharedPlaceholderReceiver`: luật receiver không gán kiểu một receiver value type từ callee khi callee
là instantiation chia sẻ mà đối số của nó là placeholder. Receiver giữ kiểu của field hay local nó đến từ
(`List<EItem>.Enumerator`), rồi `RetargetSharedGenericCalls` instantiate lại callee. 19 lỗi biến mất.

Phần còn lại là **cùng các lần đọc**, giờ đúng kiểu: il2cpp inline `MoveNext`/`Current`, nên thân đọc thẳng
`enumerator._list` và `enumerator._current`. Đó là field private của framework (CS0122). Trước 067 chúng nằm trong
SHARED_GENERIC_PLACEHOLDER vì kiểu sai đến trước. Đây là **EXPECTED_CHANGE**: kiểu đúng làm lộ lỗi biểu diễn có
sẵn. Cách sửa thuộc accessor pairing (một `MoveNext` inline đọc ba field, không phải một getter), không thuộc typing.

## 3. Bốn họ P0 không đổi

- **OBJECT_AS_NATIVE_INT 59.** Producer phân theo `cluster_native_int_casts.py --trace` chủ yếu là:
  - địa chỉ `this + k` không trúng field (`RoomController.cs:574`, `(nint)this + 168`);
  - một kickoff async lambda chưa phục hồi (`AdsController.cs:289`, `(nint)sm | 8`). Đây là kickoff thứ 18 của
    Merge-Room, cái duy nhất mà `StackStructStorage` để nguyên: state machine của một lambda có ô bên trong bị đọc theo
    tên.

  Brief cấm sửa ở chỗ cast (`(int)(object)x`), và producer chưa được sửa, nên con số đứng yên.
- **ARRAY_ELEMENT_ADDRESS 26.** `nint num3 = (nint)array;` rồi `array + offset`: địa chỉ phần tử được giữ lại thay vì
  gập thành `array[i]`. Đây là phần tử struct, nằm ngoài dạng gập được của 039/055. Chưa làm.
- **INTERFACE_SCAN_SURVIVOR 29.** Mẫu `SlicedFilledImage.cs:750`: `nint num16 = (nint)typeof(SlicedFilledImage);`
  trong vòng lặp không còn dispatch nào. Brief yêu cầu chỉ gỡ scaffolding khi dispatch đã được chứng minh. Trên
  Merge-Room những vùng này không có dispatch đi kèm để chứng minh, nên giữ nguyên. Đây là quyết định có chủ đích,
  không phải bỏ sót.
- **SHARED_GENERIC_PLACEHOLDER 9** còn lại: `SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)((nint)this + 224), …)`.
  Đối số `ref T` của một thân chia sẻ với `T` là enum. Field ở offset 224 có kiểu enum của game, và call phải được
  instantiate trên enum đó. Chưa làm.

## 4. JellyBlastV2: lookup interface bị đặt tên sai — UNKNOWN cho 068

Trên JellyBlastV2, `0xF7087C` là helper runtime tìm `VirtualInvokeData` của một interface (12068 call site).
`ResolveCallsViaMethodInfo` đặt tên nó là `Utilities.TryGetValue`, nên lần gọi không còn là lời gọi tới một địa chỉ
tuyệt đối và không pass nhận diện dispatch nào nhận ra nó.

Nguyên nhân đã truy tới: trong `ResolveTypesAndFields`, entry value `v39 @ X3` của một thanh ghi *không phải tham số*
được gán kiểu `Il2CppMethodInfo`. Luật "call qua một MethodInfo là call tới method đó" sau đó đọc nó như usage của
`TryGetValue`.

Ba cách sửa đã thử và đo, cả ba đã revert:

| Thử | Kết quả |
|---|---|
| Không đổi tên khi method có thân ở địa chỉ khác | METHOD_NOT_FOUND tăng, EXACT Merge-Room 11973 → 11882 |
| Không đổi tên khi địa chỉ nằm ngoài vùng mã managed | như trên |
| Không gán kiểu entry value không định nghĩa từ `PropagateFromCallParameters` | site không đổi; EXACT giảm |

Hai guard đầu đúng về ý, nhưng chặn cả những lần đổi tên đúng mà Merge-Room cần. Cách thứ ba chặn sai rule: kiểu đến
từ một rule khác của fixpoint, chưa định vị. Việc cho 068 là tìm rule đó, bằng `IsilDump.Trace` tại điểm `v39` nhận
kiểu, trước khi viết guard nào.

## 5. EXACT vẫn không phải compile được

`recovery_contract.py --errors` trên 67x đặt trạng thái semantic cạnh lỗi compile của cùng method. Số method EXACT mà
file của nó vẫn fail ở `iterations/067/metrics/contract-67x-m.txt`. Cùng kết luận như 066: không fixture nào compile
sạch.
