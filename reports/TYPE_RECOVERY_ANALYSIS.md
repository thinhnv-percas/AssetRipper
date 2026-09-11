# Khôi phục kiểu từ phía sử dụng (use-side type recovery)

Kiểu của một giá trị được lấy từ đâu, chỗ nào lấy sai, và còn lại những gì. Số liệu là bản rip
Impostor (Unity 2022.3.62f2, metadata v31.1, ARM64) tại các iteration 021, 023, 026, 027 và 032;
`reports/TYPE_PROVENANCE.json` và `reports/OBJECT_BASE_TYPE_PROVENANCE.json` giữ dữ liệu từng dòng.

## Thứ tự bằng chứng được áp dụng

`LocalVariables.ResolveTypesAndFields` là monotonic: kiểu đầu tiên một local nhận được là kiểu nó
giữ mãi. Điều đó biến *thứ tự* các luật chạy thành toàn bộ thiết kế, và mọi defect trong phần này
đều là một trong hai hình dạng — một nguồn yếu hơn tới trước, hoặc một nguồn đáng lẽ phải được hỏi
thì không bao giờ chạy.

Thứ tự hiện tại:

| hạng | bằng chứng | ở đâu |
| --- | --- | --- |
| 1 | signature của chính method: return, parameter, `this` | `PropagateFromReturn`, `PropagateFromParameters` |
| 2 | một global type-metadata, một `newobj`, một `MethodInfo` | `SeedRuntimeClassTypes`, `SeedNewobjResults`, `SeedMethodInfoTypes` |
| 3 | declaring type / parameter / return của một call đã giải quyết | `PropagateFromCallParameters`, trong fixpoint |
| 4 | kiểu khai báo của một field đã giải quyết, cả hai hướng của move | `PropagateMove`, trong fixpoint |
| 5 | element type của array, một entry RGCTX, static field storage | `ArrayRecovery`, `RgctxResolver`, `PropagateStaticFieldStorage` |
| 6 | một phép copy, theo hướng nào đang thiếu kiểu | `PropagateMove`, trong fixpoint |
| 7 | một phi, chỉ khi mọi input có kiểu đều nói giống nhau (hướng tiến) | `PropagatePhi` (DECOMP-0013) |
| 8 | `System.Object` tại một use site | pass thứ hai của fixpoint (DECOMP-0016) |
| 9 | kiểu hợp lưu của một phi lan **ngược** vào input | pass thứ hai của fixpoint (DECOMP-0018) |
| 10 | "chỉ từng được đếm cùng" | `TypeCounters`, chạy cuối |

Hạng 8, 9 và 10 là ba cái đoán thay vì suy ra, và cả ba giờ chạy **sau** khi fixpoint đã dừng thay
vì ở trong nó. Đây là điểm quan trọng nhất của toàn bộ phần này: cách sửa đúng không phải cấm một
nguồn bằng chứng, mà là xếp nó vào đúng hạng.

## DECOMP-0015: một thân generic chia sẻ bị gán về một instantiation

il2cpp biên dịch một thân cho mỗi generic definition rồi chia sẻ, nên method mà một call phân giải
ra là instantiation nào mà linker tình cờ gán cho địa chỉ đó. Hạng 3 vì thế mang một kiểu là sản
phẩm của quá trình build:

```
Move v1133 @ X0_v969 (List`1<System.Object>), v1173.linkedMeshes (List`1<Spine.SkeletonJson+LinkedMesh>)
Call List`1<System.Object>.get_Item, v1134 (System.Object), ...
Move v5514 (System.String), [v1134 @ X0_v971 (System.Object)+18]
```

đối chiếu `private List<LinkedMesh> linkedMeshes;` và `linkedMeshes[i].skin` trong nguồn. Receiver
là bằng chứng mạnh hơn — nó đến từ signature của một field — nên `RetargetSharedGenericCalls` khởi
tạo lại callee trên generic arguments của receiver, ngay trong fixpoint nơi field đã có một lượt để
phân giải. Chỗ nào hai bên trùng nhau thì đây là no-op, nên không có gì phải biết argument nào là
placeholder.

Giữ lại một kiểu vì callee bị chia sẻ thì phải hẹp. `List<T>.Enumerator.MoveNext` trả `bool` bất kể
T là gì, và từ chối cái đó để lại local cho SSA destruction hợp nhất với thanh ghi của receiver:
`GUIManager x = (GUIManager)enumerator.MoveNext()` với điều kiện vòng lặp đọc từ `this`.
`ContainsSharingPlaceholder` hỏi xem phép thế có thật sự chạm tới kiểu đang xét hay không; phải đủ
cả hai nửa mới được bỏ bằng chứng.

## DECOMP-0016: `System.Object` là đỉnh của lattice

Mọi reference type đều hội tụ về `System.Object`, nên một giá trị tới một vị trí khai báo
`System.Object` chỉ cho biết nó là một reference. Ghi lại điều đó còn tệ hơn không ghi gì.

Constructor hai đối số của một delegate nhận target là `System.Object`:

```
Move v44 @ X19_v2 (System.Object), v16.<>4__this (CodeStage.AntiCheat.Detectors.TimeCheatingDetector)
...
Move v329 @ X1_v10 (System.Object), v44 @ X19_v2 (System.Object)
CallVoid OnlineTimeCallback..ctor, v308 (OnlineTimeCallback), v329 (System.Object), ...
```

Hạng 3 gán kiểu cho `v329` từ parameter của constructor, hạng 6 copy ngược vào `v44`, và field ở
hạng 4 — thứ gọi tên kiểu ra rõ ràng — đến thì local đã có kiểu. Mười ba lệnh đọc field trên
detector trong đúng một method biến thành offset không gọi tên được.

Giữ lại nó hoàn toàn cũng không phải câu trả lời: local rơi xuống hạng 10, và
`obj as ItemResources` quay về thành `(int)(obj as ItemResources)`. Nên fixpoint chạy hai lần, một
lần giữ lại và một lần cho qua, với `TypeCounters` vẫn cuối cùng. Số load có base là `System.Object`
giảm từ 69 xuống 17.

Đây là luật chỉ dành cho use site. Một field hay một return có kiểu khai báo thật sự là
`System.Object` thì đó là kiểu của nó và không bị can thiệp.

## DECOMP-0018: kiểu hợp lưu của một phi không được lan ngược quá sớm

Một phi là điểm hợp lưu. Nói rằng mỗi input mang kiểu của hợp lưu chỉ đúng khi không có gì tốt hơn
định nghĩa input đó — và dưới một fixpoint monotonic, "không có gì tốt hơn" phải được xác lập trước
khi luật chạy, không phải sau.

Trình biên dịch tái sử dụng X8 cho class pointer của `List<T>` rồi cho chính `list._items`:

```
Phi v115 @ X8_v16 (Il2CppClass<List`1<Object>>), v116 @ X8_v29, v44 @ X8_v2, v117 @ X8_v17, v44 @ X8_v2
Move v117 @ X8_v17 (Il2CppClass<List`1<Object>>), v50._items (UnityEngine.Object[])
```

`v117` là cái mảng, nhưng phi hợp nhất nó với hai class pointer thật nên nó nhận kiểu class trước
khi field kịp nói. `GameHelper.FindAllChild` — thân hàm trong nguồn chỉ là `list.Add(t.gameObject)`
và một `foreach` — phục hồi thành:

```csharp
nint num = (nint)list2._items;
Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [Il2CppClass<List<Object>> + 0x18]");
if ((nint)count < (nint)0) { ... }        // lệnh ghi phần tử mất hẳn
```

`_items.Length` đọc thành `[Il2CppClass<...> + 0x18]` vì base sai kiểu; điều kiện của fast path so
sánh với số không, và nhánh ghi phần tử biến mất. Sau khi hướng lan ngược chuyển xuống pass thứ hai:

```csharp
UnityEngine.Object[] items = list2._items;
if (list2.Count < items.Length) { list2._size = count + 1; items[count] = gameObject; }
else list2.Add(gameObject);
```

Đúng thân của `List<T>.Add` mà il2cpp đã inline. REAL_ERROR 1052 → 896, `DataController.cs` 127 → 60.

## DECOMP-0020: một vòng phi không chết đối với phép đếm lượt dùng

Không phải defect về kiểu, nhưng là thứ giữ lại phần lớn hậu quả của mọi defect về kiểu.

`DeadCodeEliminator` đếm lượt dùng rồi lặp tới điểm bất động. Phép đếm không nhìn xuyên được một
vòng: một phi mang giá trị qua vòng lặp được dùng bởi chính phi tiếp theo trong vòng, nên mọi phi
trong vòng đều có vẻ còn được dùng dù không có gì bên ngoài đọc bất kỳ cái nào. Lifter sinh cả chùm
cờ cho mỗi `cmp` và SSA phi hoá các thanh ghi cờ tại mỗi điểm hợp lưu, nên trên A64 cả một phép so
sánh đã được nhận diện và thay thế — kể cả hai lệnh đọc class pointer nuôi nó — vẫn nằm lại trong
thân hàm sau một vòng phi chỉ tham chiếu lẫn nhau.

Thay bằng mark and sweep từ các lệnh có hiệu ứng. Số lệnh đọc `typeHierarchyDepth` trong bản rip
giảm từ 139 xuống 18, `interface_offsets_count` từ 84 xuống 74, tổng unresolved load 3232 → 2870,
thời gian chạy 42s → 38s.

**Phải đánh dấu mọi định nghĩa của một local, không chỉ cái cuối.** Bản đầu chỉ đánh dấu cái cuối và
cho con số đẹp hơn nhiều (2458 load, Roslyn 315) nhưng CS0165 "use of unassigned local variable"
tăng từ 5 lên 12 — phần nhìn thấy được của việc xoá code còn sống. Phần không nhìn thấy được là một
local giữ lại giá trị của một định nghĩa khác, và đó là loại sai duy nhất không thể chấp nhận. Con
số đẹp hơn không được nhận.

## Còn lại những gì

2870 load bị bỏ cuộc, đếm tại đúng một chỗ trong `IlGenerator` bỏ cuộc, nên tổng khớp với số
placeholder. Theo họ nguyên nhân:

| họ | số | bản chất |
| --- | ---: | --- |
| `untyped_base` | 930 | base không có kiểu nào, và không phải từ một `Add` |
| `runtime_struct` | 651 | đọc cấu trúc runtime của il2cpp, không phải managed field |
| `computed_addr` | 440 | base là một `Add` mà array/field fold chưa nhận |
| `ancestor_base` | 336 | offset vượt field cuối của kiểu base, hoặc nằm giữa hai field |
| `generic_instance` | 207 | một generic instance có argument là value type |
| `valuetype_base` | 170 | base là một value type |
| `open_generic` | 29 | base là một generic parameter chưa khởi tạo |
| `object_base` | 19 | base phân giải thành `System.Object` |

Trong 930 `untyped_base`, phân theo lệnh định nghĩa base: 311 một lệnh đọc memory mà không gì gán
kiểu, 254 không có định nghĩa nào trong thân hàm (giá trị vào hàm, hoặc một stack slot bị ghi ở chỗ
khác), 245 một `AddressOf` — phần lớn là truy cập tương đối frame pointer `[X29 - 0x34]`, tức là
local/struct bị spill lên stack, cần dựng lại biến trên frame chứ không phải một luật gán kiểu.

`runtime_struct` không phải defect về kiểu. Những load đó có base đúng và offset đúng; thiếu là một
pass nhận ra hình dạng mà offset thuộc về — phép duyệt cây kế thừa, phép quét interface offset,
guard khởi tạo class — như `TypeCheckRecovery` và `InterfaceDispatchRecovery` đã làm cho phần của
chúng. **Không được ép một cấu trúc runtime thành managed field chỉ để giảm số đếm.**

Phần lớn nhất còn nhận diện được của `computed_addr` là một offset nằm giữa thân một *struct*
element — `array[i].y` trên `Vector3[]` hay `SubmeshInstruction[]`. Fold chúng thành một
`ArrayAccess` là sai: một element rộng hơn một lệnh load của nó, nên gọi tên phép truy cập là
element sẽ đọc một `Vector3` thành một `float`. Cái chúng cần là *địa chỉ* của element được đặt tên
thành một local có kiểu của element, đúng thứ `RecoverStructElementAddresses` sinh ra từ phía sử
dụng và không sinh được từ hình dạng.

## Theo assembly

Assembly-CSharp giữ 292 trong 2870, chưa tới một phần chín. spine-unity một mình giữ hơn 40%. Cả
hai phép đo dễ với tới — số lỗi Roslyn và bản audit — chỉ phủ Assembly-CSharp, nên một fix rơi vào
chỗ khác đọc như là vô tác dụng.

| assembly | 021 | 023 | 026 | 027 | 032 | có nguồn đối chiếu |
| --- | ---: | ---: | ---: | ---: | ---: | --- |
| spine-unity | 1863 | 1839 | 1766 | 1766 | 1176 | có, vendored tại `Assets/ThirdParties/Spine/Runtime/spine-csharp` |
| DOTween | 840 | 835 | 825 | 825 | 809 | không |
| Assembly-CSharp | 359 | 359 | 347 | 347 | 292 | có, script của chính game |
| ACTk.Runtime | 243 | 227 | 212 | 212 | 208 | không |
| spine-unity-examples | 221 | 214 | 207 | 207 | 183 | có, cùng chỗ vendored |
| GoogleMobileAds | 179 | 179 | 177 | 177 | 167 | không |
| LeanPool | 19 | 19 | 19 | 19 | 19 | không |
| Mono.Security | 17 | 17 | 16 | 16 | 16 | không |
| **tổng** | **3741** | **3689** | **3569** | **3569** | **2870** | |

DECOMP-0016 rơi hoàn toàn ngoài Assembly-CSharp: REAL_ERROR của nó là 1076 ở cả 021 và 023 và số
Roslyn dịch đúng một lỗi trong họ `Box`-sang-`float` đã có. Đọc cùng bảng này thì đó là hình dạng
của một fix ở assembly khác, không phải một fix vô tác dụng.
