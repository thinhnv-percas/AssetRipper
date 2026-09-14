# Iteration 046 — phân loại truy cập bộ nhớ theo thứ nó thật sự là

## 1. Baseline

Tái lập 045 đúng tới từng con số trước khi chạm vào gì.

| | 045 | 046 |
|---|---:|---:|
| load bỏ cuộc (Impostor / Pinata) | 2722 / 9245 | **2722 / 9245** |
| `generatorFailures` | 0 | **0** |
| file `.cs` (Impostor / Pinata) | 819 / 3083 | 819 / 3083 |
| file `.cs` khác baseline | — | **0 trên cả hai fixture** |
| Roslyn Impostor | 348 / 0 REFERENCE | 348 / 0 |
| Roslyn Pinata | 1478 / 1 | 1478 / 1 |
| Pinata CS0030 | 1125 | 1125 |
| shape | 16/16 | 16/16 |
| `array[i].field` / `(float)array[i]` | 164 / 0 | 164 / 0 |
| `m_Script` gãy | 6 | 6 |
| test | 376 | **386** |

Iteration này **không đổi một byte nào của bản rip**. Mọi kết quả dưới đây là phân loại, và không
được đọc thành phân giải.

## 2. Root cause: "UNKNOWN" không phải một thứ

809 trong 2722 load có nguồn gốc con trỏ base là `UNKNOWN`. Phân loại thay vì đếm — lần thứ năm
nguyên tắc này trả tiền trong dự án — tách nó thành năm nguyên nhân không liên quan gì nhau:

| | |
|---:|---|
| 343 | `UNKNOWN:OPCODE:Add:*` — định nghĩa là một phép `Add` walk không có luật |
| 211 | `UNKNOWN:MERGED` — local có nhiều hơn một định nghĩa |
| 139 | `UNKNOWN:OPCODE:Move:AddressOf` |
| 69 | base không phải một local |
| 47 | rải trên bảy opcode khác |

## 3. Bốn trong năm có câu trả lời chính xác

**(a) `AddressOf(local)` trỏ vào đúng chỗ lưu trữ của local đó.** Walk chỉ có luật cho
`AddressOf(ArrayAccess)`. Lấy địa chỉ không làm đổi thứ đang được lấy địa chỉ — cùng lập luận mà
`OffsetFromLocal` đã dựa trên. 139 load: **98 thành `STACK_SLOT`** (spill qua X29, đúng họ iteration
043 đã ghi), 41 thành `UNKNOWN:CYCLE`.

**(b) Một toán hạng đặt tên cho chỗ lưu trữ trong `Move` thì cũng đặt tên cho nó trong `Add`.** Walk
chỉ có luật cho `Add pointer, hằng số`. Hỏi cùng câu hỏi đó cho opcode thứ hai:
`FieldReference → INSTANCE_FIELD`, `MemoryOperand → LOADED_POINTER`, `ArrayAccess → ARRAY_ELEMENT`.
Giữa hai thanh ghi thì bằng chứng là kiểu: cộng số nguyên vào con trỏ ra con trỏ, và không bao giờ
cộng hai con trỏ — nên bên được gán kiểu array/pointer/reference là base. **Chỉ khi nó được gán
kiểu.** Một bên không kiểu cạnh một số nguyên thì *có lẽ* là base, và "có lẽ" đúng là thứ phép phân
loại này tồn tại để không báo cáo: 27 ca đó ở lại `UNKNOWN`.

**(c) Nhiều định nghĩa không có nghĩa là bất đồng.** SSA destruction để lại một định nghĩa cho mỗi
version được hợp nhất. Nếu mọi nhánh dẫn tới cùng một chỗ lưu trữ thì đó là câu trả lời, và nó không
kém chính xác đi vì đã tới được bằng nhiều đường. Chỉ bất đồng thật mới là `UNKNOWN:MERGED`:
211 → 160.

Một chi tiết phải đúng: **mỗi nhánh có tập `visited` riêng**. Hai định nghĩa cùng đi qua một local là
*hội tụ*, không phải chu trình; dùng chung tập đó sẽ báo nhánh thứ hai là chu trình và mất một nguồn
gốc mà cả hai nhánh đồng ý. Có test riêng cho điều này và nó đỏ khi bỏ đi.

**(d) Mọi nhánh cùng kết thúc ở một `UNKNOWN` vẫn là `UNKNOWN`, và giữ nguyên lý do.** Thay nó bằng
`UNKNOWN` trơn sẽ mất đúng cái cột nói luật nào còn thiếu.

**Kết quả: chưa phân loại 809 → 396.** 413 load chuyển từ "không biết" sang một nguồn gốc có tên.

| nguồn gốc | 045 | 046 |
|---|---:|---:|
| INSTANCE_FIELD | 138 | **342** |
| LOADED_POINTER | 329 | **386** |
| STACK_SLOT | 81 | **184** |
| PARAMETER | 394 | **433** |
| ARRAY_ELEMENT | 0 | **7** |
| CALL_RESULT | 92 | 95 |

## 4. 651 lệnh đọc cấu trúc runtime, tất cả được gọi tên

Nhóm lớn nhất, và nhóm ít giống các nhóm còn lại nhất: base **được gán kiểu đúng**, ở offset đó không
có managed field nào, và sẽ không bao giờ có. §11 của brief cấm cả hai cách xử lý dễ — đếm là thất
bại, hoặc bỏ đi im lặng. Cách thứ ba là gọi tên.

`Il2CppClassUsefulOffsets` là danh sách chọn lọc những offset các pass **key on**, và nó ở nguyên như
vậy: thêm một mục là đổi hành vi phân tích. Struct database mang **toàn bộ** layout, nên
`Il2CppClassOffsetPatcher.MemberNames` dựng một bảng riêng chỉ để gọi tên — tách hẳn để một
diagnostic tốt hơn không bao giờ đổi được một pass do sơ ý.

**651/651 được gọi tên, không còn `<unnamed>` nào.**

| | |
|---:|---|
| 116 | `Il2CppClass.vtable[]` |
| 103 | `Il2CppStaticFields` |
| 103 | `Il2CppClass.byval_arg.attrs` (bitfield) |
| 74 | `Il2CppClass.interface_offsets_count` |
| 61 | `Il2CppClass.stack_slot_size` |
| 53 | `MethodInfo.is_generic` (bitfield) |
| 37 | `Il2CppClass.interfaceOffsets` |
| 36 | `Il2CppClass.cctor_finished` |
| 18 | `Il2CppClass.typeHierarchyDepth` |
| 16 | `Il2CppClass.static_fields` |
| 13 | `Il2CppClass.fields` |
| 6 + 6 | `typeHierarchy`, `initialized_and_no_error` |
| 4 + 3 + 1 + 1 | `MethodInfo.klass`, `element_size`, `vtable`, `namespaze` |

Ba nhóm xác nhận độc lập những điều `CLAUDE.md` đã ghi bằng con đường khác: 61 lệnh đọc
`stack_slot_size` chính là trình tự alloca của thân generic chia sẻ mà iteration 033 mô tả;
`cctor_finished` và `initialized_and_no_error` là class-init guard còn sót; `typeHierarchyDepth` 18
khớp con số đã ghi.

Và hai nhóm lớn nhất chưa ai đọc tên trước đây — **103 lần đọc `byval_arg.attrs` và 61 lần
`stack_slot_size`** — gần như chắc chắn mỗi nhóm là **một** hình dạng chưa được nhận diện, không phải
164 lỗi rời rạc. Đó là hạng mục giá trị nhất cho iteration sau.

Hai quy ước của bảng, cả hai là quyết định chứ không phải mặc định: một member chiếm **mọi byte nó
phủ**, vì một lệnh load nằm ở đúng offset nó nằm và đọc nửa sau của một con trỏ vẫn là đọc con trỏ
đó; và một bitfield mang chú thích trong tên, vì nhiều bitfield dùng chung một byte nên byte đó gọi
tên cả nhóm. Offset nào bảng không phủ thì báo là không phủ.

## 5. `recovery-report.json` (§13)

| | | |
|---:|---:|---|
| 901 | 33,1% | `MANAGED_FIELD` — lỗi phục hồi thật |
| 761 | 28,0% | `UNKNOWN` |
| 651 | 23,9% | `RUNTIME_STRUCT` — đã gọi đúng tên, không có tương đương managed |
| 343 | 12,6% | `NATIVE_TEMPORARY` |
| 66 | 2,4% | `ARRAY_ACCESS` |

Độ tin cậy: **997 EXACT, 964 INFERRED, 761 NONE** — không gộp ba mức đó lại.

`UNKNOWN` theo assembly: spine-unity 373, DOTween 143, Assembly-CSharp 81, GoogleMobileAds 79. Theo
provenance: `LOADED_POINTER` 376, `UNKNOWN:MERGED` 160.

## 6. Test

386 (từ 376), một fail có sẵn. Mười test mới, tất cả đã chứng minh **không suy biến**:

- bỏ luật hợp nhất → 3 đỏ;
- bỏ riêng việc sao chép tập `visited` → 2 đỏ (trong đó có test hội tụ, thứ mà luật hợp nhất một
  mình không giữ được);
- bốn test cũ khẳng định `UNKNOWN` trơn nay khẳng định đúng lý do cụ thể — cùng chủ đề, câu trả lời
  mịn hơn.

Một assertion của chính tôi sai và fixture đã bắt được: tôi khẳng định byte sau `byval_arg` phải có
tên, trong khi layout tổng hợp để một khoảng trống thật ở đó. Sửa assertion thành khẳng định khoảng
trống là khoảng trống — bảng không được nhận vùng phủ mà nó không có.

## 7. Những thứ KHÔNG làm, và vì sao

- **Không patch resolver.** Iteration 045 đã đo: phép tìm field trả lời được cho 3 trên 2722 load.
  Nó không phải nút thắt và không có gì ở đó để sửa.
- **Không tạo managed field giả** cho 651 lệnh đọc runtime (§11). Chúng được gọi tên như runtime
  operation.
- **Không suy đoán base của `Add untyped, integer`** (27 ca). Bên không kiểu *có lẽ* là base; "có lẽ"
  là thứ phép phân loại này tồn tại để không báo cáo.
- **Không mở subsystem shader.** Fixture chỉ có GLES (đo ở 044); công việc SPIR-V/DXBC/Metal sẽ áp
  dụng cho 0 chương trình ở đây.
- **Không sửa 6 tham chiếu `m_Script` gãy.** 045 đã đo: 4 không có ứng viên nào, 2 chỉ có ứng viên
  theo tên tài liệu — bằng chứng yếu nhất trong thang. Bịa một GUID làm console im lặng và component
  sai.

## 8. Blocker còn lại

- **Unity không có trên máy này.** Import, build, runtime đều `NOT_RUN`. `NOT_RUN` không phải `PASS`.
- **iOS**: `__TEXT` bị FairPlay mã hoá, `BLOCKED` từ layer binary trở xuống.
- **`LOADED_POINTER` 376** là nhóm `UNKNOWN` lớn nhất và thất bại của nó nằm ở *thượng nguồn*: con
  trỏ đọc ra từ vùng nhớ không ai đặt tên được, nên cái hỏng là lệnh load sinh ra nó.

## 9. Đề xuất iteration 047

Dựa trên bằng chứng của 046, theo thứ tự.

1. **103 lần đọc `byval_arg.attrs` và 61 lần `stack_slot_size` gần như chắc chắn là hai hình dạng,
   không phải 164 lỗi.** `byval_arg.attrs` là một phép thử thuộc tính kiểu (value type? enum?);
   `stack_slot_size` là trình tự alloca `CLAUDE.md` đã mô tả từng lệnh một. Nhận diện mỗi hình dạng
   rồi bỏ nó đi là cách duy nhất đúng, và giờ đã biết chính xác phải nhận diện cái gì.
2. **`MANAGED_FIELD / PARAMETER` 429 và `/ INSTANCE_FIELD` 318** là phần `MANAGED_FIELD` thật sự
   lớn nhất — base trỏ vào managed storage, và field không phân giải được. Phân loại theo *kiểu của
   base* trước khi làm gì.
3. **`LOADED_POINTER` 376** chỉ giảm khi lệnh load thượng nguồn được phân giải, nên nó là hệ quả chứ
   không phải việc. Đừng làm trực tiếp.
