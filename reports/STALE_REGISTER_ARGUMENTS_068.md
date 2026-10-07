# Thanh ghi bị call trước làm hỏng không phải đối số — iteration 068 (§10, §11, §13)

Nhãn: **PROVEN** (nguyên nhân gốc 0xF7087C, quy tắc ABI), **MEASURED** (con số), **INFERRED** (chỗ được ghi rõ).

## 1. Nguyên nhân gốc của 0xF7087C — PROVEN

`0xF7087C` trên JellyBlastV2 là helper lookup interface `(receiver, Il2CppClass* interface, slot)`: 12068 call site. 067 ghi
nó bị `ResolveCallsViaMethodInfo` đặt tên `Utilities.TryGetValue` qua `v39 @ X3`, và ba guard thử ở 067 đều đo âm.

Truy tới gốc trong `ResultContainer.GetWebFormattedResponseDictionary`:

1. Method gọi thật `Utilities.TryGetValue<object>(...)`. il2cpp đưa `MethodInfo*` của instantiation đó vào X3.
2. Ngay sau đó, slow path của một lookup interface gọi `0xF7087C` với X0–X2.
3. Call không giải quyết được giữ cả mười sáu thanh ghi thô làm đối số, và IR không mô hình hoá việc một call
   ghi đè X0–X18/V0–V7. X3 của bước 1 vì vậy đọc như đối số của bước 2.
4. `ResolveCallsViaMethodInfo` thấy một `Il2CppMethodInfo` trong danh sách đối số và đặt tên call theo nó.

Sai ở bước 3, không phải ở pass đặt tên. Theo AAPCS64, X0–X18 và V0–V7 là caller-saved, nên code compiler sinh ra không
bao giờ dựa vào chúng còn nguyên qua một call. Một thanh ghi là đối số của call thứ hai chỉ khi được ghi lại sau call
thứ nhất. Guard trên phép đổi tên không sửa được điều đó, vì cùng giá trị cũ còn ghim các use khác.

Cùng nguyên nhân sinh ra các tên giả khác:
- `__cxa_end_catch` thành `Buffer.Claim((int)ex)` hoặc `MoveNext`;
- một struct parameter tách hai thanh ghi không gập lại vào parameter, nên `JsonContract` gọi delegate với
  `default(StreamingContext)` thay vì `context`.

## 2. Sửa — một luật, không phải heuristic

`MetadataResolver.ReachesWithoutAnInterveningCall(graph, call, value)`: trên **mọi** đường từ định nghĩa của `value` tới
`call`, không có `Call`, `CallVoid` hay `IndirectCall` nào khác.
- Input thứ k của một phi được theo từ cuối predecessor thứ k.
- Một giá trị không lệnh nào định nghĩa (entry value) chỉ tới được nếu không có call nào giữa entry và call.

`ReplaceClobberedRawArguments` chạy trong SSA, trước fixpoint kiểu (`ResolveTypesAndFields`) và trước copy propagation.
Với mỗi call chưa giải quyết có layout thanh ghi thô, mỗi đối số không tới được bị thay bằng một local mới tên
`clobbered_<reg>` mà không gì ghi. Slot giữ vị trí và tên cho mọi remap sau, và một giá trị không ai truyền đọc đúng là thế.

Phải chạy trước copy propagation. Sau copy coalescing, một lần nạp lại có thể đã bị gập vào bản sao cũ, nên luật sẽ báo
sai. Đó là lý do bản cài vào `InvokerArgumentRecovery` (chạy sau SSA destruction) bị revert.

Cài đặt là worklist tường minh, có tập visited cho phi đã mở rộng. Bản đệ quy đầu tiên làm **Pinata stack overflow (exit
134)** ở 68e: một vòng phi `v = phi(…, w)`, `w = phi(v)` không có call trên vòng được mở rộng mãi. Test
`ACycleOfPhisThroughALoopIsCheckedOnce` và `AVeryLongChainOfBlocksDoesNotExhaustTheStack` (200000 block) giữ nó.

Không có địa chỉ nào được viết ra. `0xF7087C` không được đặt tên; nó vẫn là `RUNTIME_HELPER` không tên, đúng như bằng
chứng cho phép.

## 3. Đo (68a → 68e, chỉ thêm thay đổi này cùng §9 và §14)

Đối số thô được thay: Impostor 84731, Merge-Room 440619, JellyBlastV2 166108, RunFromZombies 114556.

| | Lỗi thân | EXACT | METHOD_NOT_FOUND | Lookup interface giải quyết |
|---|---|---|---|---|
| Impostor | 194 → 156 | 4450 → 4436 | 341 → 419 | — |
| Merge-Room | 298 → 280 | 11968 → 11876 | 3867 → 4101 | — |
| JellyBlastV2 | 1982 → 1701 | 5262 → 5247 | 2854 → 3356 | 763 → 788 |
| RunFromZombies | 7 → 7 | 2938 → 2931 | 907 → 968 | — |

Bất biến trên bốn fixture:
- generatorFailures 0, TrueAlias 0, parameter overwrite 0;
- behaviour oracle không đổi: RunFromZombies 1.0000 (35/35), Impostor 0.7587, Merge-Room 0.8331;
- hình dạng đặt tên sai quanh 0xF7087C trong `ResultContainer`: 5 → 0.

### Phân loại thay đổi

- **METHOD_NOT_FOUND tăng — EXPECTED_CHANGE.** Đây là những call trước đây được đặt tên từ một MethodInfo không tới được
  call. Bằng chứng của tên đó không hợp lệ theo ABI, nên câu trả lời trung thực là một runtime boundary không tên. Có thể
  một số tên đúng tình cờ; không có cách nào biết từ bằng chứng cũ, và luật không được đoán.
- **EXACT giảm nhẹ — EXPECTED_CHANGE.** Golden regression Impostor 2 → 11, Merge-Room 2 → 22, gồm 11 method của Sirenix
  `BinaryDataWriter`. Mỗi cái đọc được: một call managed giả biến thành boundary. Một method có call "khớp" vì tên giả
  khớp tên IR thì không phải EXACT thật.
- **Lỗi thân giảm — NEW_COVERAGE.** Struct parameter gập lại vào parameter, và giá trị cũ không còn ghim local mang kiểu sai.
- **126 call `0x179CF80` biến mất trên Merge-Room — NEW_COVERAGE.** `MethodSlotDispatchRecovery` giờ nhận được generic
  virtual call `slot = [MethodInfo+0x50]; vtable[slot]` vì X2 cũ (`methodInfo` của chính method) không còn trong danh
  sách đối số của helper. `ES3Type_*Module.Read<T>` giờ gọi `ReadInto<T>(reader, obj)` đúng tên như nguồn.
- **21 method PARTIAL → FALLBACK trên Merge-Room — MEASUREMENT_CHANGE.** Chính 21 method `ES3Type_*Module.Read<T>` ở trên.
  Mất placeholder thì phép kiểm tên chạy lần đầu. Phép kiểm thấy trong rendering một call `0x17FDF50(methodInfo)` (khởi
  tạo method) mà generator không bao giờ phát. Thân C# đúng hơn trước.

## 4. Invoker helper (§13) — PROVEN bằng phép đo

067 suy (INFERRED) từ disassembly:
- `0xE6A35C` là class-init-rồi-trả-klass, chỉ đọc X0, nên "lần dùng" buffer qua X1 là thanh ghi cũ;
- `0x179CE74` là store field qua reflection: FieldInfo → địa chỉ qua `0x17E4D30`, rồi memcpy. Đây là lần đọc buffer thật.

Thay đối số cũ bằng `clobbered_` là một phép thử độc lập cho cả hai:

| | 68a | 68e |
|---|---|---|
| RunFromZombies `UNKNOWN_RETURN:…CALL:0xE6A35C:ARG3` | 4 | **0** (REWRITTEN 2 → 8) |
| Merge-Room `UNKNOWN_RETURN:…CALL:0x17FDEF4:ARG3` | 4 | **0** (REWRITTEN 80 → 86) |
| Merge-Room `UNKNOWN_RETURN:…CALL:0x179CE74:ARG4` | 14 | 14 |

Use cũ biến mất đúng ở helper được suy là không đọc buffer, và giữ nguyên ở helper đọc buffer thật. Vẫn không helper
nào được đặt tên. `0x179CE74` là reflection: C# không có cú pháp cho "địa chỉ field theo FieldInfo", nên 14 lần đó là
`UNKNOWN_RETURN` với lý do, không phải lỗi.

## 5. Vùng quét interface (§11)

Không vùng nào bị xoá ở 068. Luật của 061–067 giữ nguyên: chỉ xoá khi dispatch đã chứng minh. Lookup giải quyết được
tăng (JellyBlastV2 763 → 788) vì toán hạng class không còn bị lẫn với thanh ghi cũ. Vùng còn lại vẫn mang lý do từ
`InterfaceScanRegionClassifier`.
