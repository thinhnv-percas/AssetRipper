# Hai runtime helper đông nhất còn lại trên Merge-Room, định danh từ struct database

Sau khi `il2cpp_codegen_write_barrier` được định vị (iteration 060), họ
`METHOD_NOT_FOUND` trên Merge-Room còn 4914 placeholder, và 101 địa chỉ runtime
helper chia nhau 5347 call site. Hai địa chỉ chiếm 1237 trong số đó. Báo cáo này
ghi lại chúng là gì, và vì sao biết tên chúng **không** làm giảm một con số nào.

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`.

## Bảng veneer

**`PROVEN`** bằng cách giải mã trực tiếp `lib/arm64-v8a/libil2cpp.so`. Mỗi ô là
một lệnh `B` một từ, nên bảng đọc được không cần disassembler:

```
179CDFC: B 0x1822D84   il2cpp_codegen_write_barrier      (đã định vị, iteration 060)
179CE04: B 0x1822D84   cùng đích - một biến thể thứ hai
179CE50: <stub>        il2cpp_codegen_initialize_runtime_metadata
179CE64: B 0x17F2058   ..._inline
179CE70: B 0x17E4D30   CHƯA ĐẶT TÊN - 488 call site, 222 method, 5 assembly
179CF80: B 0x17939F8   CHƯA ĐẶT TÊN - 749 call site, 142 method, 4 assembly
179CF84: B 0x17E4724   il2cpp_codegen_runtime_class_init
179CF88: B 0x1801F10   il2cpp_codegen_object_is_inst
179CF8C: B 0x1801C3C   Object::Box
179CF90: B 0x1802160   Object::Unbox
```

Bảng symbol của binary không đặt tên cho một địa chỉ nào trong số này: binary đã
bị strip, chỉ còn tên C API xuất ra, và không tên nào nằm đúng trên các hàm nội
bộ. Đúng như CLAUDE.md đã ghi.

## `0x17E4D30` — địa chỉ dữ liệu của một field

**`PROVEN`.** Hàm là một leaf tám lệnh:

```
ldr   x8, [x1, #0x10]
ldrsw x9, [x1, #0x18]
ldr   w8, [x8, #0x28]
add   x9, x0, x9
sub   x10, x9, #0x10
cmp   w8, #0x0
csel  x0, x9, x10, ge
ret
```

Đối chiếu `StructDb/2022.3.62f2-x64.json.gz`:

| offset | struct | field |
|---|---|---|
| `[x1 + 0x10]` | `FieldInfo` | `parent` (`Il2CppClass *`) |
| `[x1 + 0x18]` | `FieldInfo` | `offset` (`int32_t`) |
| `[klass + 0x28]` | `Il2CppClass` | từ bitfield `byval_arg`; `valuetype` là bit 31 |

`cmp w8, #0` rồi `csel ..., ge` là "bit 31 bằng 0", tức **không phải value type**.
Nên hàm trả về:

- không phải value type: `instance + field->offset`
- là value type: `instance + field->offset - 0x10`

`0x10` là hai con trỏ, đúng bằng object header. Đây chính là quy tắc hai hệ toạ độ
mà CLAUDE.md đã ghi lại nhiều lần, viết thẳng ra trong runtime. Hàm là
`il2cpp::vm::Field::GetInstanceFieldDataPointer` — chữ ký `(void* instance,
FieldInfo* field)`.

## `0x17939F8` — dựng một `Il2CppGenericMethod` rồi tra bảng

**`PROVEN`** cho việc nó đọc `MethodInfo`; **`INFERRED`** cho tên.

```
ldrb  w8, [x0, #0x53]      ; MethodInfo.is_inflated là bit 1 của byte này
tbnz  w8, #0x1, +0x18
mov   x8, xzr
b     +0x08
ldr   x9, [x0, #0x40]      ; MethodInfo.genericMethod
ldp   x0, x8, [x9]         ; methodDefinition, context.class_inst
ldr   x9, [x1, #0x40]      ; MethodInfo.genericMethod của đối số thứ hai
mov   w1, #0x1
ldr   x9, [x9, #0x10]      ; context.method_inst
stp   x0, x8, [sp, #0x8]
add   x0, sp, #0x8
str   x9, [sp, #0x18]
bl    0x1793A64
```

Đối chiếu struct database: `MethodInfo.genericMethod` ở `0x40`, và `0x53` mang
bốn bit `is_generic` / `is_inflated` / `wrapper_type` /
`has_full_generic_sharing_signature`, nên `tbnz w8, #1` là `is_inflated`.

Hàm dựng ba từ `{methodDefinition, class_inst, method_inst}` trên stack — chính là
layout của `Il2CppGenericMethod` — lấy hai từ đầu từ đối số thứ nhất và từ thứ ba
từ đối số thứ hai, rồi tra một bảng băm toàn cục. Một entry point thứ hai ở
`0x1793A40` nhận ba đối số và dựng cùng cấu trúc đó trực tiếp. Đây là hình dạng
của `il2cpp::metadata::GenericMethod::GetMethod`; tên chính xác của wrapper
codegen thì `UNKNOWN`.

## Vì sao đặt tên chúng không giảm một con số nào

**`MEASURED`.** Cả hai địa chỉ đã được `NativeBoundary` phân loại đúng là
`RUNTIME_HELPER` — hình dạng `VENEER_B`, không managed method nào nằm trên đó. Đặt
tên chỉ đổi nhãn.

**`PROVEN`: không có cách viết managed nào cho `GetInstanceFieldDataPointer` tại
các call site này.** Đọc một call site (`MMObservable`) thì đối số thứ hai là
`*([v73+0x80]) + 0x60` — một phần tử trong mảng `fields` của một
`Il2CppClass`, chứ không phải một metadata usage đã giải quyết được. Nghĩa là
field **không** biết được tĩnh: đây là code reflection (Odin, Newtonsoft) đi
duyệt danh sách field lúc chạy. C# không có cú pháp cho "địa chỉ của field này,
cho trước một `FieldInfo`", nên không có gì để sinh ra thay cho lời gọi.

Đúng theo nguyên tắc đã ghi trong CLAUDE.md: một ranh giới native không phải là
thất bại của decompiler, và đếm nó như thất bại là che mất chuyện gì đang xảy ra.
Hai helper này là ranh giới thật.

## Bước tiếp theo có giá trị, nếu có

**`INFERRED`**: nếu `0x17939F8` thật sự là `GenericMethod::GetMethod`, kết quả của
nó là một `MethodInfo*` được dùng cho một lời gọi gián tiếp ngay sau đó — tức là
một generic virtual dispatch. Nhận diện *cặp* đó (lời gọi helper cộng lời gọi gián
tiếp tiêu thụ kết quả) có thể giải quyết được dispatch, giống hệt cách
`InterfaceInvokeDataRecovery` làm với bảng interface. Chưa đo xem có bao nhiêu
trong 749 call site có hình dạng đó.

**`BLOCKED`**: không có khẳng định runtime nào ở đây.
