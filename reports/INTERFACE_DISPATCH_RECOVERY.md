# Interface dispatch recovery — iteration 062

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**, **BLOCKED**. Bản rip: `Test/Out62m-*`; baseline:
bản rip cuối của 061 (`Out61l-z`, `Out61m-m`, `Out61h-j`, `Out61i-i`, `Out61j-p`).

## 1. Điểm đầu tiên nghĩa binary khác nghĩa phục hồi — PROVEN

Iteration 061 đo 869 vùng quét interface sống sót trên Merge-Room, 592 trong đó `ValueEscapes`, và
340 là indirect call qua chính slot vùng tính ra: dispatch chưa bao giờ được giải quyết. Đọc một site
(`Sirenix.Serialization.UInt16Serializer::ReadValue`) cho nguyên nhân, và nó không nằm ở pass dispatch:

```
Move X2, 29                       ; slot của helper lookup, trong machine code
Call 17FDFF8, X0, X1, X2          ; (receiver, Il2CppClass* interface, slot)
```

Sau `MetadataResolver.ResolveAll`, `X2` là `typeof(T)`. Từ metadata v27 một usage được giải mã từ giá
trị nằm **tại** địa chỉ, và `29` là một địa chỉ ánh xạ vào header ELF, nên nó đọc ra một token hợp lý.
Slot 16 và 8 sống sót vì tình cờ; một site khác thành `fieldof(<PrivateImplementationDetails>…)`.
`InterfaceInvokeDataRecovery.MatchDispatch` cần một slot `Immediate`, nên không gì khớp.

**Sửa**: `Il2CppBinary.IsVirtualAddressWritable` (ELF: `PT_LOAD` có `PF_W`; Mach-O: `InitialProtection`
có `PROT_WRITE`). Một usage slot là global mà runtime điền vào lúc khởi tạo, nên luôn ghi được; một
immediate trỏ vào vùng không ghi được không phải usage slot, dù byte ở đó giải mã ra gì.

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
|---|---:|---:|---:|---:|---:|
| Immediate không còn đọc như usage slot | 35 421 | 139 624 | 36 516 | 84 291 | 151 175 |

Đa số là hằng số không bao giờ trùng một usage; con số chỉ là số lần luật được hỏi và trả lời "không".
Những chỗ nó đổi output là hằng số từng bị đọc sai, và cả năm ví dụ dưới đây kiểm được với source:

| File | 061 | 062 | Source |
|---|---|---|---|
| ACTk `ObscuredPrefs` | `(DataType)(int)typeof(Action<CustomRenderTexture>)` | `DataType.Quaternion` | `DataType.Quaternion` |
| Newtonsoft `JsonConvert.EnsureDecimalPlace` | `(char)(int)typeof(_0021_00210)` | `'E'` | `text.IndexOf('E')` |
| MoreMountains `MMColors` | `dictionary.Add(0, DarkViolet)`, `(int)typeof(...)` | `dictionary.Add(37, DarkViolet)`, `29`, `49`… | các khoá số |
| DOTween `TweenParams.SetEase(AnimationCurve)` | `Ease.Unset` | `Ease.INTERNAL_Custom` | `Ease.INTERNAL_Custom` |
| Newtonsoft `XmlNodeConverter` | `(nint)0 >> tokenType` | `61559 >> tokenType` | bitmask hằng |

`typeof(_0021_00210)` trên toàn rip: Merge-Room 22 → 1, Impostor 2 → 1. Check `DECOMP-0040`
(`check_recovered_shapes.sh`) đỏ trên 061 và xanh trên 062.

## 2. Slot → method — theo metadata, không theo vị trí

`InterfaceInvokeDataRecovery.MethodOfSlot` từng lấy `methods[slot]`, vị trí trong danh sách khai báo.
Slot là `Il2CppMethodDefinition.slot`; một member static hoặc không virtual của interface không có slot
(0xFFFF) nhưng vẫn chiếm một vị trí. `MemberHoldingSlot` hỏi slot của metadata, như
`InterfaceDispatchRecovery` và `MetadataResolver` vốn đã làm. **MEASURED**: trên cả năm fixture,
**0** lookup có slot khác vị trí (`SlotDisagreesWithPosition`), nên đây là làm cứng, không đổi output.
Không có chỗ nào dùng `MethodsByAddress[address][0]`, và không method nào được chọn theo tên.

## 3. Tail position

Một dispatch là câu lệnh cuối của method thành `IndirectJump`, không phải `IndirectCall`. Pass giờ nhận
cả hai; với tail call, operand được dựng lại (target, một kết quả mới, rồi các thanh ghi argument) và
`Return` được viết ra, vì generator nối một block không kết thúc bằng jump hay return vào successor.

| | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
|---|---:|---:|---:|---:|---:|
| Dispatch giải quyết (061) | 48 | 505 | 177 | 36 | 90 |
| Dispatch giải quyết (062) | 52 | 551 | 179 | 56 | 128 |
| trong đó tail position | 4 | 34 | 12 | 20 | 38 |

`BidirectionalDictionary<TFirst,TSecond>.TryGetByFirst` trở về thành một tail call tới
`IDictionary<TFirst,TSecond>.TryGetValue` (slot 6, generic context `TFirst,TSecond`), thay cho một vùng
quét, một `Method not found @17FDFF8` và một `Indirect jump`.

## 4. Bằng chứng cho mỗi call đã giải quyết

`CPP2IL_DUMP_INTERFACE_CALLS` ghi một hàng cho mỗi dispatch: caller, CALL/TAIL, receiver, interface
class được đưa cho lookup, slot, method interface, token của nó, RVA, generic context, confidence
(`EXACT`) và bằng chứng (`lookup(receiver, interface class, slot) reaches the dispatch pointer; slot =
Il2CppMethodDefinition.slot`). RVA luôn là `RUNTIME_DISPATCH`: method interface là abstract, và
implementation nào chạy là quyết định của class receiver lúc chạy — đúng như source viết. Ghi một RVA
ở đó sẽ là bịa. 966 hàng: `iterations/062/interface-dispatch/evidence-*.tsv`.

## 5. Regression corpus — `Test/interface-dispatch-corpus.json`

`interface_dispatch_corpus.py --select` chọn từ chính các hàng bằng chứng, tối đa ba mỗi trường hợp mỗi
fixture: `CALL`, `TAIL`, `GENERIC_INTERFACE`, `GENERIC_RECEIVER`, `EXPLICIT_IMPL`. "Trong if", "trong
vòng lặp" và "nhiều implementation" không phải sự thật một hàng mang theo — hai cái đầu là control flow
của caller, cái thứ ba là cây kiểu của chương trình — nên được ghi `NOT_SELECTABLE_FROM_ROWS` thay vì
lấp bằng phỏng đoán. `--check` yêu cầu C# phục hồi của caller vẫn gọi tên method interface.

| | 062 | 061 |
|---|---|---|
| Impostor | 11 NAMED | 10 NAMED, 1 NOT_NAMED |
| Merge-Room | 14 NAMED, 1 NOT_PRESENT | 11 NAMED, 3 NOT_NAMED |
| RunFromZombies | 14 NAMED, 1 NOT_PRESENT | 10 NAMED, 4 NOT_NAMED |
| JellyBlastV2 | 13 NAMED, 1 NOT_PRESENT | 9 NAMED, 4 NOT_NAMED |
| Pinata | 8 NAMED, 6 NOT_PRESENT | 8 NAMED, 6 NOT_PRESENT |

Bản đầu của checker báo `Dispose` NOT_NAMED cho `JsonConvert.DeserializeObject` trong khi C# viết
`((IDisposable)jsonTextReader2).Dispose()`: nó chỉ đọc overload đầu tiên cùng tên. Hàng không mang RVA
của caller, nên checker giờ đọc mọi overload cùng tên và nói rõ đó là điều nó kiểm.

## 6. Vùng quét interface còn sống

| | 061 total / escapes / diverges / dead | 062 |
|---|---|---|
| Impostor | 78 / 50 / 2 / 26 | 78 / 54 / 0 / 24 |
| Merge-Room | 869 / 592 / 189 / 88 | 854 / 505 / 207 / 142 |

`DeadRegionProven` tăng 88 → 142 trên Merge-Room: vùng mà dispatch của nó đã được giải quyết giờ chết
thật. Chúng vẫn không bị xoá: xoá chỉ vì DCE nói chết là thứ §7 cấm, và pass giải quyết dispatch đã
tự xoá lookup của chính nó khi nó chứng minh được.

## 7. Còn lại — UNKNOWN

- 505 vùng `ValueEscapes` trên Merge-Room, 223 qua indirect call/jump qua giá trị của vùng. Phần lớn là
  code generic chia sẻ lấy class interface từ RGCTX (`[X1+10]`, `[X1 (T)+10]`) chứ không từ một metadata
  usage; `InterfaceOf` không nhận một class pointer như vậy.
- `Call 37F7320` với argument kiểu `OutOfMemoryException` (≈32 trên Merge-Room): chưa phân loại.
- Cross-oracle với r2unity cho interface: r2unity không có khái niệm dispatch, chỉ có method table;
  việc kiểm chéo mà nó cho được (token → method) đã được làm ở 061 và không đổi (LibCpp2IL không đổi ở
  tầng đó). **Không có CROSS_ORACLE_DISAGREEMENT mới.**

---

# Iteration 063

## 8. Logic interface corpus — `Test/logic-interface-corpus.json`

`Test/Scripts/logic_interface_corpus.py` chọn theo bốn ưu tiên của brief §7 — interface generic, virtual
generic, interface trên receiver generic, lookup mà class interface đến từ runtime generic context —
từ chính các hàng bằng chứng của pass (`CPP2IL_DUMP_INTERFACE_CALLS`), không theo tên. Mỗi case mang
caller, CALL/TAIL, receiver, class interface đưa cho lookup, slot, method interface, token, generic
context, confidence, các hạng mục, và một cột xác nhận source.

| | Số |
|---|---:|
| Case | **77** (JellyBlastV2 20, Impostor 17, Merge-Room 20, RunFromZombies 20) |
| GENERIC_INTERFACE | 43 |
| GENERIC_RECEIVER | 50 |
| RUNTIME_CONTEXT_CLASS | 32 |
| TAIL | 20 |
| GENERIC_VIRTUAL | **0** — không có hàng nào: pass runtime-lookup không bao giờ gặp một generic virtual method qua interface trên bốn fixture |

**Source chỉ để xác nhận** (§8). Với caller trong package có source độc lập (TMP, UGUI, VisualScripting,
Mathematics, Voodoo, PathCreator), cột `sourceConfirmation` hỏi source method có nêu tên method interface
không: `SOURCE_CONFIRMED` 1 (`Unity.VisualScripting.LinqUtility.AddRange` → `ICollection<T>.Add`), phần
còn lại `NO_SOURCE` (Newtonsoft, Facebook, code game). Một source không nêu tên không phải bác bỏ
(`SOURCE_SILENT`): caller có thể đi qua một helper đã bị inline.

`--check` (caller trong C# phục hồi vẫn gọi tên method interface, mọi overload): trên bản rip cuối 063 —
JellyBlastV2 19 NAMED + 1 STUBBED (VisualScripting bị stub ở bản rip mặc định; NAMED trên bản rip opt-in), Impostor 17/17, Merge-Room 20/20, RunFromZombies 12 NAMED + 8 NOT_PRESENT
(Mono.Security bị stub). Hai lỗi đo đã sửa trước khi tin: một implementation tường minh được C# viết
`void ICollection.CopyTo(`, và một `.ctor` được viết bằng tên type.

## 9. RGCTX — UNKNOWN, không đổi

505 vùng `ValueEscapes` trên Merge-Room lấy class interface từ RGCTX vẫn chưa được giải quyết: iteration
này dùng phần ngân sách đó cho các lỗi mà oracle độc lập chỉ ra (ABI, FCMP, P/Invoke, serialize), vì chúng
làm sai giá trị lặng lẽ còn một dispatch chưa giải quyết thì được báo. Không có vùng quét nào bị xoá chỉ
vì DCE nói chết.

---

# Iteration 064

## 10. "RGCTX — UNKNOWN" của §9 được tách thành nguyên nhân — `reports/RUNTIME_GENERIC_CONTEXT.md`

Đọc từng method thay vì đếm vùng: một nửa có class interface đã có kiểu và dispatch đi qua
`VirtualInvokeData.method->invoker_method` (bộ invoker của thân generic chia sẻ hoàn toàn); nửa kia lấy class
từ RGCTX thật nhưng `MethodInfo` bị đặt sai thanh ghi, vì thân fully shared nhận `il2cppRetVal` trước
`MethodInfo`. Tầng sai đầu tiên của nửa thứ hai là calling convention (`FullGenericSharing`), không phải
`InterfaceOf`.

`RuntimeInterfaceResolver` ghi mỗi dispatch còn sống do lookup nuôi vào `CPP2IL_DUMP_INTERFACE_CALLS` với
confidence `UNRESOLVED` và họ `đường:nguồn class:lý do`. Merge-Room: dispatch giải quyết qua lookup (phân biệt)
251 → 263, `ValueEscapes` 505 → 496, 152 dispatch còn lại đã phân loại; 46 trong đó có đích EXACT qua invoker và
chờ dựng lại đối số. `InterfaceOf` nhận thêm một usage kiểu đưa thẳng làm đối số — giá trị của nó là class
pointer, như `SeedRuntimeClassTypes` đã đọc — điều đó một mình lấy đi 186 `INDIRECT_CALL` và 169
`INDIRECT_JUMP` trên Pinata.
