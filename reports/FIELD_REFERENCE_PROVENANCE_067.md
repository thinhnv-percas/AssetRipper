# Địa chỉ field, tham số và `= ref *(` — iteration 067 (§3, §9)

Nhãn: **PROVEN**, **MEASURED**, **UNKNOWN**.

## 1. Họ `= ref *(` phân ra theo producer — MEASURED

`= ref *(T*)X` là cách ILSpy viết một managed reference mà IL cho nó từ một số nguyên. Trên Merge-Room 67a, theo dạng
của `X`:

| Dạng | Producer thật | Sửa |
|---|---|---|
| `ref *(T*)null` trên tham số `out` | tham số `out` mang kiểu sai, nên store qua nó thành *rebind* (`starg`) | §2 |
| `ref *(T*)((nint)this + k)` | địa chỉ `object + k` trúng đúng một field, nhưng không phải đối số call | §3 |
| `ref *(T*)(&num)`, `ref *(T*)intPtr`, `ref *(decimal*)null` | load không giải, nhánh `isArray ?` | không đổi (UNKNOWN) |

## 2. Tham số lấy kiểu của chính nó — PROVEN

`LocalVariables.PropagateFromParameters` gán kiểu tham số bằng *cách đếm*: local thứ n nhận kiểu tham số thứ n. Một
tham số mà không gì đọc thanh ghi của nó thì không có local. Vì thế mọi tham số sau nó nhận kiểu của tham số đứng
trước.

Ví dụ `TryConvert(T instance, ConvertBinder binder, out object result)`: `instance` không được đọc, nên `result` mang
kiểu `ConvertBinder`. Store `*result = 0` thành `result = ref *(object?*)null`. Đó không phải C#, và với caller thì
`result` không bao giờ được gán.

Lỗi này im lặng: thân vẫn compile ở mọi chỗ kiểu sai tình cờ vừa.

Sửa: `LocalVariable.ParameterIndex` được ghi khi tạo, và `AssignParameterTypes` dùng nó. Test
`AParameterLocalIsTypedFromItsOwnParameterWhenAnEarlierOneHasNoLocal` đỏ nếu quay lại cách đếm.

Kèm theo:
- Store qua managed reference giờ nạp reference trước giá trị. Trước đó giá trị được đỗ vào một local nháp,
  ILSpy viết `object obj = null; result = obj;`.
- `parameter_overwrite_scan.py` tách tham số `out`/`ref` được ghi một giá trị không giải được ra khỏi nhóm "tham
  số bị ghi đè". Với `out`, ghi là việc của method; giá trị không giải được đã được đếm là load không giải.
  Trước đây scratch local che dạng này: `int num7 = 0; index = num7;`.

## 3. Địa chỉ field nơi nó được định nghĩa — PROVEN

`FieldAddressArguments` đã phục hồi `&obj.field` khi nó là đối số call. Một địa chỉ được *giữ lại* thì vẫn là số
học native:
- ref local đọc sau call (`_syncRoot` double-checked của `SyncRoot`);
- giá trị của getter trả ref (`ref NextNode => ref nextNode`, lift thành `return this + 0x10`).

`RecoverAddressDefinitions` áp cùng luật (`CompareExchangeRecovery.FieldAddressed`) tại chính định nghĩa. Điều kiện:
- một định nghiã `object + k`;
- class có field đúng offset `k`;
- local đã mang kiểu `ref` tới kiểu của field đó, do một lần dùng cần như vậy.

Kết quả: `ref object syncRoot = ref _syncRoot;`.

## 4. Phi của con trỏ với số nguyên — PROVEN (§9)

Regression của 066: buffer `stackalloc` và một số nguyên dùng chung một thanh ghi. Phi của chúng bất đồng nên không
có kiểu, local thành `object`, và `(object)ptr` không phải chuyển đổi C# có. Impostor có 8 lỗi như vậy.

Một phi mà mọi input có kiểu đều là word máy đã có câu trả lời: số nguyên native (`System.IntPtr`). Word máy gồm
con trỏ unmanaged, số nguyên, và runtime handle (`Il2CppClass*`, …, vốn đã hạ thành `IntPtr`). Điều kiện: có ít nhất
một con trỏ. Tham chiếu và struct vẫn bất đồng thành không gì, giữ nguyên trường hợp `Il2CppStaticFields<Quaternion>`
với một object mà chú thích của luật phi mô tả.

## 5. Đo

| `= ref *(` | 66i | 67x |
|---|---:|---:|
| Impostor | 35 | 21 |
| Merge-Room | 111 | 85 |
| RunFromZombies | 35 | 24 |
| JellyBlastV2 | 213 | 149 |

Số cuối ở bảng tổng của `docs/ITERATION_067.md`.

Bất biến: TrueAlias 0, parameter overwrite (by-value) 0, layout mismatch 0 trên mọi fixture.

## 6. Còn lại — UNKNOWN

- `ref *(T*)null` trên Newtonsoft/ConvertUtils (`decimal`): đối số `ref` của một call mà địa chỉ đến từ một ô stack
  bị bỏ. Đó là phần storage của struct mà `StackStructStorage` chưa nhận vì có ô bên trong bị đọc theo tên.
- `FieldReference` lồng làm base (`this.a.b` khi `a` là struct) cho AddressOf/Load/Store: §3 của brief. Chưa làm
  tổng quát. Các trường hợp `FieldOfALoadedObject` (066) và `RecoverAddressDefinitions` (067) là những ca đã được
  chứng minh.
