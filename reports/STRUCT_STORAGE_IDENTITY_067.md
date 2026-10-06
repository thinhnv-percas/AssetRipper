# Storage identity của struct trên stack — iteration 067 (§2)

Nhãn: **PROVEN**, **MEASURED**.

## 1. Lỗi — PROVEN

Stack analysis đặt tên mỗi ô theo offset của chính nó. Vì thế một struct dựng trên stack thành vài local không liên
quan. Ví dụ là kickoff của một method async (`JsonReader.SkipAsync`, RunFromZombies):

| Ô | Nội dung | Ghi bằng |
|---|---|---|
| `stack_-80` | `<>1__state = -1` | `str w10` |
| `stack_-78`/`-68` | `<>t__builder` | 16 + 8 byte (V0, X9), chép từ buffer trả về của `Create()` |
| `stack_-60` | `<>4__this` | `str x19` |
| `stack_-58` | `cancellationToken` | `str x20` |
| — | `&sm \| 8` (`orr` trên địa chỉ căn 16) | làm địa chỉ builder |

Rồi `Start(&sm.<>t__builder, &sm)`.

Không gì đọc các ô bên trong theo tên, nên lần DCE đầu tiên, chạy trước khi biết kiểu, xoá chúng. Kickoff khởi
động state machine không có `this`, không có đối số, builder là một con trỏ số nguyên:

```csharp
int num = 0;
int num2 = (int)((nint)num | (nint)8);
_003CSkipAsync_003Ed__1 stateMachine = (_003CSkipAsync_003Ed__1)4294967295L;
((AsyncTaskMethodBuilder*)num2)->Start(ref stateMachine);
```

066h đã thử giữ các store đó. Chúng thành local riêng chứ không thành member, và lộ `m_builder` private: CS0122
Merge-Room 27 → 57, nên đã revert.

## 2. Sửa

**`StackAnalyzer.KeepStoresInsideAnAddressTakenSlot`** giữ *tạm* một store khi:
- ô của nó nằm trong khoảng 0x100 byte sau một ô bị lấy địa chỉ;
- không gì đọc nó theo tên;
- địa chỉ bị lấy không phải thiết lập frame (`X29`), và offset âm.

**`StackStructStorage`** chạy sau fixpoint kiểu, khi đã biết struct là gì:
- Struct là một ô bị lấy địa chỉ mà một version mang kiểu struct không phải enum hay primitive. Kích thước lấy từ
  metadata. Hai struct chồng nhau thì bỏ cả hai.
- Phải giải thích **toàn bộ** phần trong trước khi viết lại bất cứ gì. Chỉ cần một trong các điều sau là cả struct
  được để nguyên:
  - một ô bên trong bị đọc theo tên (đó là biến khác dùng chung bộ nhớ);
  - một store không phải `Move`;
  - một store không khớp member nào;
  - một store có độ rộng khác member;
  - một bản chép không lát kín member.
- Mỗi store được xét theo **độ rộng lệnh đã ghi** (`StackOffset.Size`, mới; lifter đặt cho STR/STP vào stack và
  frame pointer), không theo tên ô. Một store vector 16 byte lên member float không phải store của member đó.
- Các dạng được nhận:
  - **store member** — độ rộng bằng member;
  - **bản chép nguyên member** — các chunk lát kín member, mỗi chunk đọc cùng một giá trị nguồn ở cùng offset
    tương đối: `sm.<>t__builder = Create()`;
  - **xoá về 0 mở đầu** — 0 ở offset 0 và các 0 bên cạnh trong cùng block: `initobj`;
  - **hằng ở offset 0** — member đầu, không phải cả struct. Kiểm tra trước, vì type propagation thường gán immediate
    kiểu của struct;
  - **`&sm + k` / `&sm | k`** — `&sm.member`. `orr` chỉ khi các bit đặt vào chắc chắn là 0.
- Mọi version của ô thành một storage có kiểu struct.
- Cuối pass, mọi store giữ tạm được **thả**. Store đã viết lại là root nhờ đích của nó; phần còn lại chết như trước 067.

Kèm theo:
- **Builder generic chia sẻ.** `AsyncTaskMethodBuilder<object>.Create()` là thân chia sẻ của
  `AsyncTaskMethodBuilder<byte[]>.Create()`. Bản chép nhận nó khi đối số `object` đứng cho một kiểu tham chiếu, rồi
  instantiate lại lời gọi trên kiểu của member, cùng cách `ReceiverInstantiationOf` làm cho receiver.
- **Một luật cho receiver.** `IlGenerator` có bản sao riêng của `ReceiverInstantiationOf`. Bản đó đã lệch, ít dạng
  receiver hơn, nên giờ gọi lại bản của resolver. Bản của resolver nhận thêm managed reference và địa chỉ một field.

Kết quả trên `SkipAsync`:

```csharp
AsyncTaskMethodBuilder _003C_003Et__builder = AsyncTaskMethodBuilder.Create();
_003CSkipAsync_003Ed__1 stateMachine = default(_003CSkipAsync_003Ed__1);
stateMachine._003C_003E4__this = this;
stateMachine.cancellationToken = cancellationToken;
stateMachine._003C_003Et__builder = _003C_003Et__builder;
stateMachine._003C_003E1__state = -1;
stateMachine._003C_003Et__builder.Start(ref stateMachine);
return stateMachine._003C_003Et__builder.Task;
```

Không còn cast con trỏ, `unsafe` hay `m_builder`.

## 3. Đo

Kickoff async còn dạng con trỏ (`)->Start(ref`), 66i → 67e → 67x (bản cuối):

| | 66i | 67e | 67x | phục hồi |
|---|---:|---:|---:|---:|
| RunFromZombies | 88 | 15 | 14 | 74 |
| Impostor | 3 | 1 | 1 | 2 |
| Merge-Room | 18 | 1 | 1 | 17 |
| JellyBlastV2 | 11 | 0 | 0 | 11 |

Ghi chú:
- `m_builder` trong export JellyBlastV2: 25 → 0.
- CS0122 Merge-Room: 27 → 27. Không quay lại 57 như 066h.
- Phần còn lại trên RunFromZombies: 13 trong 14 là `AsyncTaskMethodBuilder<object>` chia sẻ của Newtonsoft
  (`JsonReader.ReadArrayIntoByteArrayAsync`, `JObject`, `JArray`…), một là `AsyncTaskMethodBuilder` thường. Việc
  instantiate lại builder chia sẻ (`AdoptMemberType`) chỉ thêm được một kickoff (15 → 14). Rendering của các method
  này không còn store `this`/đối số nào, nghĩa là struct bị để nguyên và store tạm đã được thả. Lý do từ chối cụ thể
  là **UNKNOWN**: pass chỉ có counter tổng, chưa ghi lý do theo struct. Việc cho 068 là ghi lý do đó trước khi sửa.

Log (`Il2Cpp method body recovery (067)`), bản cuối 67x:

| | struct phục hồi | struct để nguyên | store member | chép member | địa chỉ member | store giữ tạm |
|---|---:|---:|---:|---:|---:|---:|
| Impostor | 98 | 334 | 84 | 4 | 4 | 3871 |
| Merge-Room | 1588 | 2145 | 432 | 36 | 34 | 26110 |
| RunFromZombies | 233 | 488 | 495 | 296 | 148 | 5287 |
| JellyBlastV2 | 102 | 623 | 172 | 34 | 22 | 7441 |
| Pinata | 370 | 513 | 529 | 0 | 0 | 10195 |

Mọi store giữ tạm mà pass không viết lại được thả ở cuối pass, nên số store giữ tạm không phải số store sống sót.

## 4. Phép đo đã bắt một lỗi trước khi nó ở lại

Bản đầu (67b) suy độ rộng theo tên thanh ghi. Một `Matrix4x4` được chép bằng bốn store vector 16 byte từ một nguồn
không giải được. Pass gọi mỗi store là store của member float ở offset đó: `matrix4x.m01 = 0f;` cùng ba placeholder
mới, và `inverse.m01 = inverse.m01;`. CinemachineComposer giảm HIGH_CONFIDENCE → PARTIAL.

Đưa độ rộng thật vào `StackOffset` loại trường hợp đó. Struct bị để nguyên, như test
`AWiderStoreOverAMemberIsNotAStoreOfTheMember` khẳng định.

## 5. Test (`Il2CppStackStructStorageTests`, 15 case)

- Kickoff thành store member vào một storage: `this`, đối số, builder chép nguyên, state là member đầu, `&sm | 8` là
  `&sm.builder`, `initobj`, mọi version được gán kiểu lại.
- Struct được để nguyên khi:
  - ô bên trong bị đọc theo tên;
  - bản chép không lát kín;
  - bản chép từ hai giá trị;
  - không version nào là struct;
  - store rộng hơn member;
  - không biết độ rộng.
- `orr` có thể carry không phải phép cộng.
- Tên ô đọc ngược thành offset.
