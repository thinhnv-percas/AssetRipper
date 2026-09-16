# Iteration 050 — 233 "lời gọi vtable" không phải vtable

## 1. Baseline

Tái lập 049 đúng từng con số trước khi chạm vào gì. Không có divergence nào để ghi.

| | expected của brief | đo được |
|---|---:|---:|
| `EXACT` | ≈2841 | **2841** |
| placeholder | ≈4617 | **4617** |
| `METHOD_NOT_FOUND` | ≈713 | **713** |
| `INDIRECT_CALL` | ≈233 | **233** |
| `INDIRECT_JUMP` | ≈120 | **120** |
| field layout | 1394 exact / 0 bất đồng | **1394 / 0** |
| Roslyn | ≈342 | **342** |
| golden corpus | 48 | **48** |

## 2. §3 — mục tiêu chính, và tiền đề của nó sai

Brief đặt "233 call site liên quan vtable" làm mục tiêu chính. Thay vì tin con số đó, hỏi chính
`MetadataResolver.ResolveVirtualCalls` tại điểm generator bỏ cuộc — chạy **đúng số học và đúng phép
tra slot của nó**, không chép lại; `ResolveVTableSlot` được mở public chính vì một probe chép lại
một pass thì trôi khỏi pass đó, và project này đã trả giá hai lần.

468 lời gọi gián tiếp còn sống ở cuối `Analyze`, theo cái mà đích giữ:

| | |
|---:|---|
| 236 | `LOADED_POINTER` — base không có kiểu |
| 126 | `METHODINFO_POINTER_AT_0x10` — `invoker_method` |
| 56 | `METHODINFO_POINTER_AT_0x0` — `methodPointer` |
| 34 | `VTABLE_SLOT_UNRESOLVED` — base **đúng** là class pointer, tra slot không ra |
| 16 | `LOADED_FROM_reference` / `LOADED_FROM_valuetype` |

và **0** `VTABLE_BASE_UNTYPED`, **0** offset lệch, **0** `VTABLE_RESOLVABLE`.

Nên **182 ca mà nhãn cũ gọi là "ô vtable" thực ra đọc một trường của `MethodInfo`**. Struct database
2022.3 nói thẳng, và offset đọc từ bảng chứ không viết tay — đã là cùng một bug ba lần trong project
này:

```
0x00  methodPointer          0x18  name
0x08  virtualMethodPointer   0x20  klass
0x10  invoker_method         0x28  return_type
```

Ô vtable **thật** chỉ có 34, và tất cả thuộc loại "tra slot không ra" chứ không phải "không có
kiểu" — nên công việc ở đó là metadata, không phải type recovery. Đó là kết luận của §3, đo được,
và nó nói rằng mục tiêu chính của brief không tồn tại ở quy mô brief nghĩ.

## 3. §21 — hai phục hồi ngữ nghĩa thật

### Con trỏ hàm của một delegate không phải thứ không gọi tên được

Comment cũ ở `IlGenerator` nói **đúng** rằng C# không viết được dạng hai tham số, và **sai** rằng
không có method nào để gọi tên. il2cpp truyền cho constructor cả `MethodInfo*` của đích bên cạnh con
trỏ thô; phân tích đã gán kiểu toán hạng đó là `RuntimeMethodInfoAnalysisContext`, và context đó
**mang theo method nó trỏ tới**.

Nên ở đâu có nó thì đây là `ldftn <method>; newobj Delegate::.ctor(object, native int)` — đúng thứ
C# biên dịch một method group thành, và đúng thứ decompiler đọc ngược lại thành một method group.
Chỉ khi không toán hạng nào gọi tên method thì mất mát mới là thật.

Một delegate trên method **tĩnh** được dựng với số không ở chỗ receiver, nên số không đó phải thành
`ldnull`; nếu không delegate đóng trên địa chỉ 0.

### Một lời gọi qua `methodInfo->methodPointer` là lời gọi trực tiếp

Cùng một chỗ nhìn ra. `ResolveMethodInfoPointerCalls` nằm trong **cùng fixpoint** với
`ResolveVirtualCalls`, vì base chỉ được gán kiểu bởi phép phân giải đó.

Hai trường bên cạnh **cố ý** không được đối xử như vậy: `virtualMethodPointer` ở 0x08 là entry ảo,
còn `invoker_method` ở 0x10 là invoker kiểu reflection của runtime — nhận con trỏ, MethodInfo,
receiver và mảng tham số đã box — nên một lời gọi qua nó **không** phải lời gọi tới thân method đó.
Nói ngược lại sẽ sai theo đúng kiểu im lặng mà project này vẫn phải trả giá.

### Bằng chứng ở mức thân hàm

`SkeletonUtility.OnEnable`, trước:

```csharp
Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: UpdateBonesDelegate");
skeletonAnimation.UpdateLocal -= value5;      // value5 là null
```

sau:

```csharp
UpdateBonesDelegate value5 = UpdateLocal;
skeletonAnimation.UpdateLocal -= value5;
```

đúng bằng nguồn Spine.

## 4. §7 — runtime helper, phân tích trước khi ánh xạ thêm

`Test/Scripts/runtime_helper_report.py`. 796 lời gọi đi tới **đúng 30 địa chỉ**, và cột quan trọng
nhất không phải địa chỉ mà là **hình dạng các điểm gọi**.

| địa chỉ | lời gọi | method | asm | hình dạng | hồ sơ caller |
|---|---:|---:|---:|---|---|
| `AF4130` | 339 | 339 | 5 | `FUNCTION_PROLOGUE` | **event accessor 339/339** |
| `B3490C` | 79 | 67 | 7 | `FUNCTION_PROLOGUE` | ordinary 77/79 |
| `9DACB4` | 74 | 69 | 7 | `FUNCTION_PROLOGUE` | ordinary 68/74 |
| `BD3CD0` | 71 | 69 | 7 | `FUNCTION_PROLOGUE` | ordinary 65/71 |
| `AD94B0` | 53 | 49 | 1 | `VENEER_B` → `B277D0` | ordinary 48/53 |
| `AD947C` | 53 | 49 | 1 | `FUNCTION_PROLOGUE` | ordinary 48/53 |
| `B349B4` | 35 | 19 | 3 | `FUNCTION_PROLOGUE` | ordinary 35/35 |

**0 trên 30 địa chỉ được export table đặt tên**, nên bảng symbol đóng lại như một con đường — đúng
như 048 đã ghi. Và chỉ **3 địa chỉ** có call site đồng nhất một loại thành viên với ≥10 lời gọi. Tức
**27 địa chỉ còn lại không đặt tên được từ điểm gọi và phải đọc mã máy** — đó là kết luận của §7,
không phải một bước trung gian, và nó là lý do iteration này **không** ánh xạ thêm helper nào.

`0xAF4130` vẫn **không** được vá, theo đúng §10: ngữ nghĩa chắc chắn (`ldaxr`/`stlxr`, 339/339
caller là event accessor) nhưng cách tìm ra nó một cách tổng quát vẫn chưa có, và ánh xạ sai sẽ hỏng
im lặng 339 event accessor.

## 5. §23 — kho method vàng 48 → 61

Thêm một trục chọn: method **tệ nhất mang mỗi họ placeholder** — theo cách dựng thì đó chính là
những method khó nhất trong bản rip. Kho được **hợp** chứ không thay thế: một mục đã đóng băng không
bao giờ bị bỏ, nếu không tấm lưới bắt hồi quy tự tháo mắt mỗi lần chọn lại.

61 method: 12 `EXACT` / 12 `HIGH_CONFIDENCE` / 21 `PARTIAL` / 16 `FALLBACK`. Chạy trên bản rip trước
hai fix, nó chỉ đúng 2 method 050 đưa lên và 1 method 050 đẩy từ `PARTIAL` xuống `FALLBACK`.

## 6. §23 của brief — báo cáo cuối

```
Iteration 050
HEAD before: 0e82a216
HEAD after:  (commit kết thúc iteration)
```

| | 049 | 050 | tại sao |
|---|---:|---:|---|
| **Impostor** | | | |
| `EXACT` | 2841 | **2852** | delegate và `methodPointer` được phục hồi |
| `HIGH_CONFIDENCE` | 156 | 157 | |
| `PARTIAL` | 1235 | **1158** | placeholder biến mất khỏi thân hàm |
| `FALLBACK` | 1250 | 1315 | **trung thực**: bỏ placeholder làm lộ ra chỗ còn thiếu |
| `MISSING` | 0 | 0 | |
| phục hồi không kèm đồ thế chỗ | 2997 | **3009** | |
| placeholder | 4617 | **4502** | |
| `UNRESOLVED_DELEGATE` | 128 | **0** | cả họ biến mất |
| `INDIRECT_CALL` | 233 | **207** | 56 ca `methodPointer` thành lời gọi trực tiếp |
| `INDIRECT_JUMP` | 120 | 120 | không chạm |
| `METHOD_NOT_FOUND` | 713 | 715 | code từng chết nay còn sống |
| load bỏ cuộc | 2711 | 2711 | |
| Roslyn | 342 | 344 | +3 CS0030, −1 CS0037 — cùng nguyên nhân |
| field layout | 1394 / **0 bất đồng** | 1394 / **0 bất đồng** | bất biến §14 giữ |
| golden corpus | 48 | 61 | 0 hồi quy |
| test | 407 | **414** | 7 test mới |
| **Pinata** | | | |
| `EXACT` | 9580 | **9634** | |
| `PARTIAL` | 3187 | **3043** | |
| `FALLBACK` | 3140 | 3233 | trung thực |
| phục hồi không kèm đồ thế chỗ | 10036 | **10097** | |
| placeholder | 14726 | **14233** | |
| `UNRESOLVED_DELEGATE` | 433 | **122** | |
| load bỏ cuộc | 9248 | **9241** | |
| field layout | 3170 / **0 bất đồng** | 3170 / **0 bất đồng** | |

`.cs` 819 / 3083, `genFail` 0 / 0, shape 16/16 — không đổi trên cả hai fixture.

**§19 cross-fixture: luật chạy tốt trên cả hai**, không phải một luật chỉ đúng cho Android.

| | |
|---|---|
| Native boundaries | 512 `NATIVE_ONLY` (PLT sang shared library khác) vẫn là phụ thuộc ngoài, không phải khuyết tật |
| References | không chạm — 6 `m_Script` gãy như 045 đã đo |
| Shaders | `DUMMY` — không bao giờ là PASS |
| Unity | `UNITY_NOT_AVAILABLE`, U1–U9 và I1–I4 `NOT_RUN` |

Trạng thái tổng, theo §22:

```
RECOVERY_VALIDATED_STATICALLY
```

**không** phải `FULLY_RECOVERED`.

## 7. Việc kế tiếp có giá trị cao nhất

236 `LOADED_POINTER` — lời gọi gián tiếp qua một base **không có kiểu**. Đây giờ là họ lớn nhất còn
lại của `INDIRECT_CALL`, và nó là việc của type recovery chứ không phải của call resolution: sửa chỗ
base mất kiểu thì 236 ca này rơi vào một trong các nhánh đã có.

Sau đó là 126 `invoker_method`, và câu hỏi ở đó không phải "gọi method nào" mà "có nên mô hình hoá
invoker của runtime như một biên native hay không" (§16).
