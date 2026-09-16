# Iteration 049 — phục hồi lời gọi, và một phép đo dám hạ điểm chính mình

## 1. Baseline

Tái lập 048 bằng harness mới trước khi chạm vào gì. Trùng tới từng con số:
`genFail 0`, 819 / 3083 file `.cs`, 2726 / 9248 load, 2343 / 4779 lời gọi thành placeholder,
shape 16/16, Roslyn 348-0 / 1478-1, test 402 với 1 fail có sẵn.

## 2. §2 — phép đo authoritative, và nó hạ điểm chính tôi

`Test/Scripts/recovery_metrics.py` là nguồn đo duy nhất. Họ placeholder lấy từ
`placeholder_families.MESSAGE_PREFIXES`; không script nào tự định nghĩa lại.

Cái mới là **trạng thái ngữ nghĩa**. "Không có placeholder" không phải phục hồi: một thân hàm đọc
`return default;` trong khi native có một lần đọc field, một phép so sánh, một nhánh và một lời gọi
thì **không mang placeholder nào và đã mất tất cả**.

Bằng chứng vốn đã nằm trong bản export. `[NativeSource(Body = "...")]` là bản kết xuất của **ISIL đã
phân tích** chứ không phải của mã máy, nên những phép toán nó gọi tên là những phép toán mà phân tích
đã phục hồi. So lớp phép toán hai bên thì biết method nào chỉ là đồ thế chỗ.

| | |
|---|---|
| `EXACT` | đủ mọi lớp phép toán IR có, không placeholder, không local `object` |
| `HIGH_CONFIDENCE` | đủ, không placeholder, có local `object` |
| `PARTIAL` | mang placeholder |
| `FALLBACK` | không placeholder, mà thiếu lớp phép toán IR có |
| `MISSING` | thân hàm mất hẳn |

Impostor tại baseline: **2594 EXACT / 145 HIGH_CONFIDENCE / 1540 PARTIAL / 1203 FALLBACK / 0 MISSING**.

048 công bố "3942 method không có placeholder". **1203 trong số đó là đồ thế chỗ.** Con số thật là
2739 method phục hồi không kèm đồ thế chỗ — thấp hơn 1203 so với những gì iteration trước báo.

**Phép đo này tự báo sai hai lần trước khi tin được**, và cả hai đều là "kiểm tra quá chặt cũng sai
như quá lỏng":

* Một lời gọi viết khác nhau ở hai phía — IR viết `Type::Method(`, `"helper"(`, `0xADDR(`; C# viết
  `receiver.Method(`. Một pattern cho cả hai làm phía C# **không khớp gì cả**, nên thiếu hụt bằng
  đúng toàn bộ phía IR: 2304 method bị báo mất hết lời gọi. Thật ra là 54.
* Truy cập field phải so bằng **tên thành viên** chứ không bằng hình dạng, vì C# viết `this.field`
  thành `field` trần. So hình dạng thì mọi method chạm vào state của chính nó đều bị báo là mất nó:
  888 + 767 ca, thật ra là 662.

## 3. §7 + §29 — hai biến thể metadata init là ANH EM, không phải cha con

Ưu tiên số một của brief là phục hồi lời gọi. Thứ chỉ ra chỗ phải đào không phải một giả thuyết mà
**một dòng log mới** (§2): helper runtime nào tìm thấy và helper nào không.

    30 tìm thấy, 5 không:
      il2cpp_codegen_initialize_method
      il2cpp_vm_metadatacache_initializemethodmetadata
      il2cpp_codegen_raise_exception
      il2cpp_codegen_write_barrier
      AddrPInvokeLookup

Và ở bản đầu, **`il2cpp_codegen_initialize_runtime_metadata_inline` cũng nằm trong danh sách không
tìm thấy** — trong khi địa chỉ chưa phân giải bận nhất của cả binary, `0xAD94AC`, nhận **889 lời gọi
từ 268 method**, tức 40% của mọi `Method not found` trong bản export.

Tháo ELF ra đọc thì hết mơ hồ:

```
0xAD9498  str x30, [sp,#-16]!   ; il2cpp_codegen_initialize_runtime_metadata
0xAD949C  bl  0xB28874
0xAD94A0  dmb ish

0xAD94AC  b   0xB28874          ; …_inline: cùng hàm, không có memory barrier
```

Chính comment trên field đã nói đúng hình dạng đó từ đầu — *"Thunk of the above without the memory
barrier, and it hands the value back. Exception handlers use it."* — và code thì đi tìm
`FindAllThunkFunctions(il2cpp_codegen_initialize_runtime_metadata)`, tức **hàm nào nhảy TỚI bản có
barrier**. Không bao giờ có hàm nào làm thế. Hai cái là **anh em**: bản inline là thunk của cái mà
bản barrier *gọi*.

Ứng viên được **xác nhận chứ không giả định**: một veneer là hàm mà toàn bộ nội dung là cú nhảy, nên
hỏi ngược "nó là thunk của cái gì" phải ra đúng câu trả lời cũ. Một địa chỉ sai ở đây sẽ viết lại
những lời gọi thật thành khởi tạo metadata.

Phần **tiêu thụ đã có sẵn từ trước**: `MetadataResolver` viết lời gọi inline thành một `Move` của
handle vào kết quả. Toàn bộ khoảng trống là ở chỗ tìm địa chỉ.

| Impostor | baseline | sau |
|---|---:|---:|
| `METHOD_NOT_FOUND` | 1573 | **713** |
| `NOT_IMPLEMENTED_INSTRUCTION` | 303 | **211** |
| `UNKNOWN_CALL_TARGET` | 107 | 97 |
| placeholder | 5753 | **4876** |
| method `EXACT` | 2594 | **2765** |
| `PARTIAL` | 1540 | **1334** |
| Roslyn | 348 | **345** |
| load bỏ cuộc | 2726 | 2719 |

`NOT_IMPLEMENTED_INSTRUCTION` giảm 92 mà không ai chạm vào lifter: bỏ scaffolding đi thì kéo theo
code chết quanh nó.

**Pinata không đổi một byte.** Ở metadata v24.2 bản barrier không tồn tại (build đó dùng
`il2cpp_codegen_initialize_method`), nên nhánh mới không chạy: 4779 lời gọi, 9248 load, 3083 file,
`genFail` 0 — y hệt baseline.

### Bằng chứng ở mức thân hàm

`Common.Assert`, trước:

```csharp
if (condition) { return; }
Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94AC");
UnityException ex = new UnityException();
Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94AC");
throw ex;
```

sau:

```csharp
if (condition) { return; }
UnityException ex = new UnityException();
throw ex;
```

Đúng bằng nguồn.

## 4. §17 — mã lý do, không chỉ triệu chứng

`METHOD_NOT_FOUND` là triệu chứng và không nói được lời gọi có phục hồi được không. Mỗi mã dưới đây
đọc từ bằng chứng đã có tại điểm đó — số method managed trên địa chỉ, và bốn lệnh đầu ở đó:

| | | |
|---:|---|---|
| 718 | `RUNTIME_HELPER` | hàm thật trong binary này, key-function recovery chưa nhận ra |
| 512 | `NATIVE_ONLY` | PLT stub sang shared library khác — **phụ thuộc ngoài, không phải khuyết tật** |
| 103 | `INDIRECT_TARGET` | toán hạng đích không phải immediate |
| 78 | `RUNTIME_HELPER_VENEER` | veneer mà phía sau không có gì |
| 33 | `GENERIC_SHARED` | nhiều method managed trên cùng một địa chỉ |

512 ca không bao giờ sửa được bằng metadata. 796 ca runtime helper là chỗ công việc thật nằm.

## 5. §13 + §14 — delegate invoke: một pass viết cho hình dạng ở SAI ĐIỂM

`INDIRECT_CALL` (350) tách sạch làm hai bằng chính chữ nó in ra:

* **117** đi qua `X.invoke_impl` — delegate invoke;
* **233** đi qua `[base + offset]` — ô vtable, tức virtual/interface dispatch.

`DelegateInvokeRecovery` **đã tồn tại** và làm đúng việc đầu. Nó không khớp vì nó đòi toán hạng đích
là một `MemoryOperand` với addend 24 — còn nó chạy **sau** `LocalVariables.ResolveTypesAndFields`,
chỗ mà `MetadataResolver` đã biến operand đó thành một `FieldReference` mang đúng cái tên
`invoke_impl`. Lại đúng bài học cũ: *một pass so khớp hình dạng phải được viết theo hình dạng tại
điểm nó chạy.*

Một nửa còn thiếu, và nó là nửa lớn: **delegate generic**. Một generic instance context mang theo
tham số và định nghĩa của nó mà không khai báo thành viên nào của riêng mình, nên hỏi nó `Invoke` —
hay thậm chí hỏi nó *có phải delegate không*, vì điều đó đọc từ base type — đều không ra gì. Mà phần
lớn delegate ở đây là generic: `DOGetter<Vector2>`, `Predicate<T>`, `Action<T>`. Việc instantiate
lại không phải trang trí: phép remap tham số sau đó đọc chữ ký của callee, và kiểu trả về của định
nghĩa mở là một tham số kiểu.

| Impostor | trước | sau hình dạng đã phân giải | sau cả generic |
|---|---:|---:|---:|
| `INDIRECT_CALL` | 350 | 314 | **233** |
| placeholder | 4876 | 4838 | **4756** |
| `EXACT` | 2765 | 2773 | **2775** |
| `PARTIAL` | 1334 | 1322 | **1318** |
| load bỏ cuộc | 2719 | 2717 | **2716** |

233 còn lại **đúng bằng** số ô vtable đã đếm được từ đầu, không dư không thiếu — tức phần delegate
đã hết sạch chứ không phải giảm đi một ít.

Test: luật được tách thành một hàm thuần để kiểm chứng **không cần metadata đứng sau**, đúng cách
`NestedFieldResolver` đã làm. 3 trong 5 test đỏ khi bỏ luật đi.

## 6. §21 + §22 — mã lệnh chưa lift được

`Test/Scripts/instruction_coverage.py`. Cột "lifter case" đọc thẳng từ switch của
`NewArmV8InstructionSet` chứ không đoán: một mã lệnh **có** case mà vẫn báo unimplemented là khuyết
tật khác hẳn một mã lệnh không có case nào.

Impostor + Pinata, 14 mã lệnh, 216 placeholder:

| opcode | count | method | dạng |
|---|---:|---:|---|
| `UNIMPLEMENTED` | 94 | 40 | Disarm không giải mã được — khoảng trống của **disassembler** |
| `FABD` | 48 | 28 | vector |
| `DUP` | 44 | 29 | vector |
| `USHL` | 9 | 5 | vector |
| `BIT`/`BSL`/`BIF` | 10 | 6 | vector (bitwise select) |
| `FADDP`/`FCMGT`/`EXT`/`CMHS`/`ZIP1` | 9 | 6 | vector |
| `REV` | 2 | 2 | scalar (Pinata) |
| `SMULH` | 1 | 1 | scalar |

**Phần còn lại gần như toàn dạng vector**, và §22 cấm đúng việc lift chúng như scalar — sai sẽ im
lặng. Hai ca scalar cộng lại là 3 placeholder. Nên kết luận là: tầng ngữ nghĩa SIMD (`Vector64` /
`Vector128` / lane count / lane type) là điều kiện cần, và iteration này **không** làm nửa vời.

## 7. §15 — native import

485 placeholder, đã có tên từ `.rela.plt` từ trước. Phân loại theo tên:
`__cxa_end_catch` 96, `memcpy` 85, `__cxa_begin_catch` 76, `modf` 73, `__stack_chk_fail` 54,
`__cxa_throw`/`__cxa_allocate_exception` 40, `memset` 18, còn lại là libm.

Đây gần như toàn bộ là `IL2CPP_RUNTIME` và `SYSTEM_API` theo phân loại §15: **giới hạn thật**, không
metadata managed nào gọi tên một hàm libc. Ngoại lệ là số ít có toán tử C# tương đương, và đó chính
là `fmodf → %` của iteration 048 (22 lời gọi). `modf` (73) là hàm tách phần nguyên/phần lẻ qua con
trỏ ra, C# không có toán tử tương đương.

## 8. §16 — indirect jump

254 placeholder. Tách theo toán hạng: 20 là delegate tail-invoke (`X.invoke_impl`), 234 còn lại là
một thanh ghi (`System.IntPtr` 124, không kiểu 80, `System.Int32` 28). Không có ca nào mang hình
dạng bảng nhảy đọc được từ chữ, nên phân loại `SWITCH_TABLE` / `STATE_MACHINE` / `COMPUTED_JUMP`
**chưa có bằng chứng** ở mức này và không được ghi như thể có.

## 9. §19 — bộ nhớ

`recovery_report.py` (046) giữ nguyên cách chia: `MANAGED_FIELD` / `RUNTIME_STRUCT` /
`NATIVE_TEMPORARY` / `ARRAY_ACCESS` / `UNKNOWN`. Iteration này không đụng vào, và load bỏ cuộc giảm
2726 → 2717 như hiệu ứng phụ của việc bỏ scaffolding.

## 10. Không chạy, và nói rõ là không chạy

Unity không có trong container: `UNITY_NOT_AVAILABLE`. U1–U9 và I1–I4 vẫn `NOT_RUN`.
Shader vẫn ở `DUMMY` như 044 đã ghi — **dummy không bao giờ là PASS**.
Golden corpus (§27) chưa dựng. §10/§11/§12 (generic / virtual / interface call recovery) chưa làm:
233 ô vtable là công việc kế tiếp có giá trị cao nhất, và nó cần bảng interface offset + vtable của
metadata chứ không phải heuristic.

## 11. §26 + §30 — bảng tổng kết

Đo bằng `recovery_metrics.py` cho **cả hai đầu**, không phải bằng phép đo của 048.

| Impostor | 048 | 049 | delta |
|---|---:|---:|---:|
| **method `EXACT`** | 2594 | **2775** | **+181** |
| `HIGH_CONFIDENCE` | 145 | 152 | +7 |
| `PARTIAL` | 1540 | **1318** | **−222** |
| `FALLBACK` | 1203 | 1237 | +34 |
| `MISSING` | 0 | 0 | 0 |
| **phục hồi không kèm đồ thế chỗ** | 2739 | **2927** | **+188** |
| placeholder | 5753 | **4756** | **−997** |
| `METHOD_NOT_FOUND` | 1573 | **713** | −860 |
| `INDIRECT_CALL` | 350 | **233** | −117 |
| `NOT_IMPLEMENTED_INSTRUCTION` | 303 | 211 | −92 |
| `UNKNOWN_CALL_TARGET` | 107 | 97 | −10 |
| lời gọi thành placeholder | 2343 | **1444** | −899 |
| load bỏ cuộc | 2726 | 2716 | −10 |
| Roslyn | 348-0 | **345-0** | −3 |
| shape / `.cs` / `genFail` | 16-16 / 819 / 0 | 16-16 / 819 / 0 | 0 |
| test | 402 | **407** | +5 |

| Pinata | 048 | 049 |
|---|---:|---:|
| tất cả | 4779 lời gọi, 9248 load, 3083 `.cs`, 14726 placeholder, genFail 0 | **y hệt** |

`FALLBACK` **tăng 34 và đó là trung thực**: bỏ placeholder đi làm lộ ra những method mà thân hàm vẫn
còn thiếu thứ khác. Chúng chuyển từ `PARTIAL` sang `FALLBACK` chứ không biến mất.

### BEHAVIORALLY RECOVERED

```
method   Common.Assert(bool)                          Assembly-CSharp, 0x40 byte native
trước    hai placeholder "Method not found @AD94AC" kẹp quanh phần thân
sau      if (condition) { return; }
         UnityException ex = new UnityException();
         throw ex;
bằng chứng
         native   0xAD9498 = str x30 / bl 0xB28874 / dmb ish     (bản có barrier, đã nhận ra)
                  0xAD94AC = b  0xB28874                          (bản inline, chưa nhận ra)
         IR       [NativeSource] cho thấy cả hai lời gọi lấy một metadata usage slot làm X0
         metadata comment trên chính field đã mô tả đúng hình dạng đó từ trước
         test     ứng viên phải là thunk của đúng hàm mà bản barrier gọi, nếu không thì bỏ
```

```
họ       delegate invoke                               117 lời gọi, 40 file
trước    Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: getter.invoke_impl (System.IntPtr) …")
sau      lời gọi trực tiếp tới Invoke của chính kiểu delegate đó, đã instantiate
bằng chứng
         IR       toán hạng đích là FieldReference mang tên `invoke_impl`, base đã được
                  phân tích gán kiểu delegate
         số đếm   350 -> 233, và 233 đúng bằng số ô vtable đếm độc lập
         test     5 test, 3 đỏ khi bỏ luật đi
```

## 12. Giới hạn, và việc kế tiếp có giá trị cao nhất

`UNMANAGED_MEMORY_LOAD` (2645) vẫn là họ lớn nhất và iteration này không đụng tới.

Việc kế tiếp có giá trị cao nhất là **233 ô vtable** còn lại của `INDIRECT_CALL`, cộng với 718
`RUNTIME_HELPER`. Cả hai đều có đường đi bằng metadata chứ không bằng heuristic: `InterfaceOffsets`
và `VTable` của `Il2CppTypeDefinition` cho cái thứ nhất, và cách tìm anh-em-veneer của §3 cho cái
thứ hai — `il2cpp_codegen_raise_exception` và `il2cpp_codegen_write_barrier` vẫn nằm trong danh sách
không tìm thấy.

`0xAF4130` là ca lớn nhất còn lại của `RUNTIME_HELPER`: **339 lời gọi, và 339/339 caller là
event accessor `add_`/`remove_`**. Mã máy ở đó là `ldaxr x8,[x0] / cmp x8,x2 / stlxr w9,x1,[x0]` —
một vòng compare-and-swap, tức `Interlocked.CompareExchange(ref location, value, comparand)` với
đúng thứ tự tham số. **Nó vẫn không được ánh xạ**, có chủ ý: không managed method nào nằm ở địa chỉ
đó, và mọi chuỗi thunk từ `System.Threading.Interlocked::CompareExchange` đều dẫn tới `0xAF41A4` /
`0xAF41CC` / `0xAF4164` chứ không tới `0xAF4130`. Ngữ nghĩa thì chắc chắn, còn **cách tìm ra nó một
cách tổng quát thì chưa có**, và ánh xạ sai sẽ làm hỏng im lặng 339 event accessor. Ghi lại làm bằng
chứng, không vá.
