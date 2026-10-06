# Lỗi thân Merge-Room, field address lồng, store qua ô SP và cờ ADDS — iteration 066 (§5, §6, §7)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**. Gộp ba mục §5–§7 cùng phát hiện ADDS vào một báo cáo, vì cả bốn được đo
trên cùng bộ lỗi thân và cùng bản rip (`Test/Out66i-*`).

## 1. Lỗi thân Merge-Room theo họ producer (§5) — MEASURED

`cluster_body_errors.py` trên body pass của Assembly-CSharp, 65z → 66i:

| Họ | 65z | 66i |
|---|---:|---:|
| OBJECT_AS_NATIVE_INT | 59 | 59 |
| OTHER | 54 | 48 |
| INTERFACE_SCAN_SURVIVOR | 29 | 29 |
| SHARED_GENERIC_PLACEHOLDER | 28 | 28 |
| ARRAY_ELEMENT_ADDRESS | 26 | 26 |
| FRAMEWORK_PRIVATE_MEMBER | 25 | 24 |
| STRUCT_FIRST_MEMBER | 21 | 21 |
| UNRESOLVED_LOAD_STANDIN | 21 | 19 |
| STRUCT_LOCAL_AS_ADDRESS | 17 | 12 |
| INDIRECT_STRUCT_ARGUMENT | 12 | 12 |
| khác | 12 | 12 |
| **Tổng** | **324** | **310** |

Bốn họ P0 brief §5 nêu tên đứng yên: 59 / 29 / 28 / 26. 066 không có pass nào nhắm vào chúng. Phần giảm đến từ:
- alloca động: `ExtensionList.cs` 25 → 10, phần lớn từ OTHER và STRUCT_LOCAL_AS_ADDRESS;
- guard đã gỡ: UNRESOLVED_LOAD_STANDIN.

Số theo họ và ví dụ: `iterations/066/metrics/clusters-{65z,66i}-m.{txt,json}`.

Hợp đồng theo method (`RECOVERY_CONTRACT_066.md`) trả lời "vì sao method này không compile" cho 96 method của
Merge-Room. 49 trong số đó là EXACT về ngữ nghĩa nhưng vẫn fail.

## 2. Field address qua một field object đã đọc (§6)

**Hình dạng.** `Lexer.NextToken(json, ref this.lexer.index)` là `ldr x8, [x0, #lexer]; add x1, x8, #0x20`. Sau SSA
destruction, thanh ghi của địa chỉ bị dùng lại nên `v230` có ba định nghĩa. `CompareExchangeRecovery.FieldAddressed`
dừng ở `DEFINITIONS_3`, và generator chỉ còn cách viết `ref int index = ref *(int*)((nint)this.lexer + 32)`.

**Sửa.** `FieldAddressArguments.FieldOfALoadedObject` lấy định nghĩa *tới được* lời gọi trong chính block của nó.
Hai trường hợp:
- Base là local kiểu class không bị định nghĩa lại giữa phép cộng và lời gọi: dùng thẳng.
- Base là một field read đã gập: đặt lại thanh ghi máy đã nạp thành một local, định nghĩa bằng cùng field read tại
  vị trí phép cộng.

Ba điều kiện như cũ vẫn phải giữ:
- tham số byref đã resolve;
- base là một object có field nằm đúng offset;
- kiểu của field là referent của tham số.

Kết quả: `ParseObject` của Impostor thành `Lexer.NextToken(lexer.json, ref lexer2.index)`.

| `= ref *(` | 65z | 66i |
|---|---:|---:|
| Impostor | 44 | 35 |
| Merge-Room | 124 | 111 |
| JellyBlastV2 | 249 | 213 |
| JellyBlastV2 opt-in | 399 | **440** |

Opt-in tăng vì code mới tới được. Ví dụ `AppRequestResult` (Facebook): `reference = ref *(IEnumerable<object>*)null`
nằm trong vùng 65z còn bị guard không giải che. Đó là khiếm khuyết biểu diễn có sẵn, bị lộ ra, không phải khiếm
khuyết mới. Biểu diễn đúng (`FieldReference` lồng làm base cho AddressOf/Load/Store) vẫn chưa làm. Đây là phần lớn của
những gì còn lại.

## 3. Store qua ô SP sau ô bị lấy địa chỉ (§7) — đo được là âm, đã revert

Mở rộng `KeepStoresReadThroughABaseAddress` từ store qua X29 sang store qua SP được viết, đo hai lần, rồi revert:

- **66g.** Giữ 2177–11915 store mỗi fixture. JellyBlastV2 EXACT 4347 → 4149: thiết lập frame (`mov x29, sp` là một
  address-take của ô 0) làm mọi lần lưu thanh ghi phía trên nó trông như "chỉ đọc được qua địa chỉ".
- **66h.** Loại thiết lập frame và lần lưu thanh ghi callee-saved trong prologue. Vẫn giữ 813–11833 store, và các
  store đó là trường `<>t__builder` của state machine async tại `stateMachine + 8 / +0x10`. Chúng thật sự được
  `Start(ref stateMachine)` đọc qua địa chỉ, nên giữ chúng là *đúng* về ngữ nghĩa. Nhưng chúng rơi vào các local
  riêng chứ không vào state machine: struct sau một địa chỉ chưa được mô hình như một storage. Kết quả là
  `asyncTaskMethodBuilder.m_builder` (private, CS0122) và hai load không giải mỗi method async:
  - CS0122 Merge-Room 27 → 57;
  - RunFromZombies EXACT 2967 → 2908;
  - lỗi thân Impostor 202 → 225.

  Không có gì đúng hơn xuất hiện trong output, nên luật được revert về dạng 065.

Test `slot=value; p=&slot; slot=value2; return *p` và các biến thể ở mức SSA vẫn là test của 065
(`SsaForm.OnlyRecordedInUnreadSlots`, `RetargetAddressTakesOverwrittenBeforeUse`). 066 không thêm test SSA mới cho
§7. Việc cần làm trước là mô hình "struct sau một địa chỉ là một storage".

## 4. Phát hiện ngoài brief: cờ của ADDS/CMN là hằng số — PROVEN, đã sửa

Lần chạy đầu cho thấy `DateTimeParser.ParseZone` (Newtonsoft, JellyBlastV2) rơi PARTIAL → FALLBACK. Truy ngược thì
không phải lỗi của 066:

```
sub w12, w11, #0x3a
cmn w12, #0xa                  ; (uint)(c - '0') < 10
b.lo fail
```

Disarm trả `cmn` về dạng ADDS vào thanh ghi zero. Nhánh ADDS của lifter gọi `EmitResultFlags`, hàm này ghi **C = 0
và V = 0 hằng số**. Hệ quả:
- Mọi `b.lo` / `b.hs` sau một ADDS hoặc CMN rẽ theo một hằng.
- Ở đây mọi chữ số bị từ chối, nên `ZoneHour` luôn là 0. 65z cũng thế.
- `DateTimeUtils.WriteDefaultIsoDate` có vòng lặp chữ số `while (true)` không bao giờ thoát, và ngày không bao giờ
  được ghi.

Cờ của `a + b` là cờ của `a - (-b)`. Nhánh CMN tường minh đã lift đúng như thế. Giờ ADDS cũng vậy, tính trước khi
ghi lại như phép trừ.

Giới hạn: `FlagConditionRecovery` đã hạ điều kiện unsigned bằng phép so sánh signed (ghi trong chính pass đó). Cờ
mới chính xác trừ nơi signed và unsigned khác nhau. Cờ cũ sai trên mọi đường.

Kết quả:
- `ParseZone` phục hồi `ZoneHour = 10*c1 + c2 - 528`.
- `WriteDefaultIsoDate` có `do … while` với điều kiện thoát và phần ghi ngày.
- `while (true)` trên JellyBlastV2: 1867 → 1144. Con số này gộp với guard đã gập, không tách được.
- Golden corpus báo `DateTimeUtils` EXACT → PARTIAL trên Merge-Room và RunFromZombies. Đó là phần thân mới phục hồi
  (vòng lặp thoát được, phần còn lại của method) được chấm lại, không phải mất mát: **EXPECTED_CHANGE**.
