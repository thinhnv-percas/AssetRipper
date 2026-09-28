# Storage identity — iteration 061

Một giá trị được khôi phục sống ở đâu — parameter, local, field, phần tử mảng, ô spill trên stack —
là câu hỏi mà generator trả lời ở sáu chỗ, và nó từng trả lời theo nhiều cách. Iteration 058 tìm ra
chỗ address-of, iteration 059 chỗ store. Cả hai lần body vẫn compile, đọc hợp lý, và mọi con số tổng
hợp giữ nguyên tới từng chữ số. Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**.

## 1. Bốn chỗ còn lại vẫn bỏ qua luật — PROVEN, đã sửa

`IlGenerator` khai báo một IL local cho **mọi** lifted local, kể cả local mang tên một parameter. Ba
helper `LoadLocal`, `StoreLocal`, `LoadLocalAddress` hỏi `LocalStorage.For` và đưa parameter về
`ldarg`/`starg`/`ldarga`. Bốn chỗ khác lấy thẳng `locals[...]` qua `TryGetValue` rồi `ldloca`:

| Chỗ | Làm gì |
|---|---|
| `Move <struct local>, 0` | `initobj` để zero một value type |
| `OpCode.MakeStruct` | ghi từng member của một aggregate đã được ABI rải ra nhiều thanh ghi |
| arithmetic float vào một aggregate | ghi kết quả vào member đầu của đích |
| `LoadOperand` của một aggregate khi cần float | đọc member đầu |

Khi local đó là một parameter, cả bốn đọc hoặc ghi một local mà không gì khác chạm tới. Chỗ thứ tư là
nặng nhất: member đầu của một parameter `Vector3` đọc ra **0**. Trên Impostor:

```
-			Vector3 vector = default(Vector3);
-			return Encrypt(vector.x, value.y, value.z, key);
+			return Encrypt(value.x, value.y, value.z, key);
```

`ObscuredVector3` mã hoá `x` của mọi vector thành 0; `Vector3Plugin` của DOTween tính `x` của mọi
tween từ `default(Vector3)`; các operator của `ObscuredVector3` (`a + b`, `a - b`, so sánh `lhs`/`rhs`) đều đọc `x` của toán hạng parameter là 0.

Bốn chỗ giờ gọi `LoadLocalAddress`. Điều kiện kích hoạt giữ nguyên, chỉ nơi lưu trữ đổi.

| | Impostor | RunFromZombies |
|---|---:|---:|
| File `.cs` đổi nội dung | 30 (ACTk, DOTween, LeanPool, spine-unity) | 0 |
| `default(...)` bị bỏ / thêm | 134 / 16 | — |
| EXACT / HIGH / PARTIAL / FALLBACK | 4011 / 219 / 1083 / 169, **không đổi** | không đổi |
| Roslyn DOTween / ACTk / spine-unity | 2 / 4 / 18, **không đổi** | — |
| Lỗi `Decompiling` | 0 | 0 |

16 `default(...)` được thêm là ILSpy đánh số lại cùng một câu lệnh sau khi một local bịa ra biến mất;
đã đọc từng hunk. Diff đầy đủ: `iterations/061/storage/impostor-diff.patch`.

Đây là lần thứ ba cùng một họ lỗi và lần thứ ba mọi con số đếm được đều đứng yên. Chỉ một phép so
theo hành vi (source oracle) hoặc đọc diff thấy được nó.

## 2. Luật được giữ bằng test, không bằng quy ước — PROVEN

`Il2CppStorageIdentityTests.OnlyTheStorageHelpersIndexTheInventedLocals` đọc source của
`IlGenerator.cs` và yêu cầu `locals[` xuất hiện đúng ba lần (ba helper) và `locals.TryGetValue(` không
lần nào. Đưa lại một chỗ bỏ qua thì test đỏ (đã kiểm).

## 3. `StorageIdentity` — mô hình, và phép đo nó cho

`Cpp2IL.Core/Analysis/StorageIdentity.cs` xây *trên* `LocalStorage.For` chứ không bên cạnh nó — một
luật thứ hai là cách hai bên từng lệch nhau. Mỗi local có: `Kind` (This, Parameter, Local, Temporary,
Spill, Stack, Field, Static, ArrayElement, Unknown), `AliasGroup` (khoá của chính vùng nhớ: mọi SSA
version của một ô stack là `stack:-58`), `CoordinateFrame`, `Site` (chỗ IL), `DefinitionSites`,
`UseSites`, `AddressTaken`, `Escapes` (địa chỉ được đưa cho một call, ghi vào bộ nhớ, hoặc return).

`IlGenerator.StorageAnalyzed` phát cho mỗi body; nó là phép đo, không gì trong generation đọc lại nó,
và rip giống hệt khi có hay không có handler.

| | Impostor | RunFromZombies |
|---|---:|---:|
| Body | 5963 | 4615 |
| Temporary / Local / Parameter / This / Spill | 34518 / 23549 / 5695 / 3983 / 820 | 33171 / 19873 / 4183 / 3347 / 1126 |
| Address-taken / escaping | 911 / 751 | 1357 / 893 |
| **Hazard**: một vị trí máy nằm ở nhiều chỗ IL khi địa chỉ bị lấy | **22** (21 escaping) | **103** (102 escaping) |

Hazard là dạng tổng quát của lỗi 058/059: ghi qua địa chỉ tới một chỗ, đọc một chỗ khác không thấy.
Gần như tất cả đều là ô spill (`stack:-58` trong `ObscuredPrefs.DecryptValue`, `stack:-C0` trong
`Spine.Skin.AddSkin`) có địa chỉ được đưa cho một call. **UNKNOWN**: chưa xác lập được cái nào là mất
giá trị thật; `SsaForm.RetargetAddressTakesOverwrittenBeforeUse` đã xử lý dạng trong một block. Sửa
chúng là bài toán aliasing tổng quát và cần bằng chứng riêng theo §27 trước khi động vào.

## 4. Regression test

`Il2CppStorageIdentityTests` (10 case): parameter vs local, `ref`/`out` là địa chỉ sẵn, ghi qua field
là đọc base, phần tử mảng không phải mảng, mọi version của một ô spill là một vị trí, ô bị tách có địa
chỉ bị lấy là hazard, địa chỉ lấy ở một chỗ thì không, temporary, receiver của struct là
object-relative, và bất biến ở §2.
