# Iteration 045 — từ số đo sang phục hồi chức năng

## 1. Baseline

Đo lại trước khi chạm vào gì, và tái lập đúng 044 tới từng con số.

| | 044 | 045 |
|---|---:|---:|
| `generatorFailures` | 0 | **0** |
| File `.cs` (Impostor / Pinata) | 819 / 3083 | 819 / 3083 |
| Load bỏ cuộc (Impostor / Pinata) | 2722 / 9245 | 2722 / 9245 |
| Roslyn Impostor | 348 / 0 REFERENCE | 348 / 0 |
| Roslyn Pinata | 1478 / 1 | 1478 / 1 |
| Pinata CS0030 | 1125 | 1125 |
| Shape | 16/16 | 16/16 |
| `array[i].field` | 164 | 164 |
| `(float)array[i]` | 0 | 0 |
| `m_Script` gãy | 4 | **6** (xem mục 5) |
| Test | 372 | **376** |

File `.cs` khác baseline: **0**, trên cả hai fixture. Iteration này chỉ thêm đo lường và công cụ;
không đổi một byte nào của bản rip.

## 2. Dân số load đã phân giải

`IlGenerator.ResolvedMemoryLoad` phát ở nhánh `FieldReference` của `LoadOperand` — đúng tấm gương
của chỗ duy nhất một memory operand bị bỏ cuộc — nên hai file là cùng một phép đo trên cùng một giai
đoạn pipeline.

```
resolved   16677
unresolved  2722
tỉ lệ phân giải 0,8597
```

Nguồn gốc con trỏ base, hai dân số:

| Nguồn gốc | resolved | unresolved |
|---|---:|---:|
| THIS | 6572 | 60 |
| PARAMETER | 2937 | 394 |
| INSTANCE_FIELD | 2718 | 138 |
| CALL_RESULT | 1366 | 92 |
| STATIC_FIELD | 1308 | 103 |
| UNKNOWN | 1074 | 809 |
| ALLOCATION | 536 | 8 |
| ENTRY_VALUE | 76 | 160 |
| LOADED_POINTER | 43 | 329 |
| STACK_SLOT | 35 | 81 |
| RUNTIME_STRUCTURE | 12 | 548 |

## 3. Luật hệ toạ độ của iteration 044 bị bác bỏ

Iteration 044 đo bảng chéo trên riêng phần thất bại, thấy nó tách sạch 68/68, và từ chối patch vì
mẫu bị lệch. Nửa còn lại của mẫu lật ngược kết luận:

| nguồn gốc / khung | resolved | unresolved |
|---|---:|---:|
| THIS / VALUE_RELATIVE | **262** | 0 |
| PARAMETER / VALUE_RELATIVE | **610** | 0 |
| CALL_RESULT / VALUE_RELATIVE | **888** | 0 |
| INSTANCE_FIELD / VALUE_RELATIVE | 1 | 0 |
| THIS / OBJECT_RELATIVE | 0 | 3 |
| PARAMETER / OBJECT_RELATIVE | 0 | 14 |
| CALL_RESULT / OBJECT_RELATIVE | 0 | 7 |

Một receiver hay một parameter đọc value type là **value-relative 1761 lần khi nó phân giải được**,
và object-relative **không lần nào**. 25 ca object-relative mà 044 nhìn thấy chính là 25 ca thất
bại. `OBJECT_RELATIVE` là **dấu hiệu của thất bại**, không phải một luật về khung.

Cộng header theo nguồn gốc sẽ phá 1761 ca đúng để cứu 24 — cùng hình dạng với lần bác bỏ
77-so-với-29 của iteration 041, lần này với biên lớn hơn nhiều và có cả nửa đã phân giải của mẫu.
**Khuyến nghị số 1 của iteration 044 đóng lại tại đây.**

## 4. Phép tìm field không phải nút thắt

Cột `SEARCH_ANSWERS` chạy chính phép tìm field của `ResolveFieldOffsets` tại điểm load được đếm, nên
phân biệt được "tìm rồi không thấy" với "chưa bao giờ được hỏi":

```
1417  SEARCH_EMPTY          tìm rồi, metadata không có gì ở offset đó
1241  NO_OWNER              base không có kiểu nào cả
  61  NOT_A_FIELD_ACCESS    operand có index, thuộc đường array
   3  SEARCH_ANSWERS        tìm được mà vẫn bỏ cuộc
```

Điều này **đóng lại họ `RESOLVABLE` 48 load** mà iteration 040 và 044 đánh dấu là "có field đúng
ngay offset đó mà generator vẫn bỏ cuộc". Đo theo metadata thay vì theo layout tính toán thì nó là
**3**, không phải 48. 45 ca chênh lệch là do `GenericInstanceFieldLayout` nằm ở khung boxed (đã ghi
ở iteration 043), nên "có field đúng ngay offset đó" được đọc từ một bảng khác với bảng phép tìm
đọc — cùng một sự thật đếm hai lần chứ không phải hai bằng chứng độc lập.

Còn lại 3 ca, tất cả trong `Spine.PathConstraint..ctor` và họ hàng, nguyên nhân **chưa xác định**:
probe cho thấy `ResolveFieldOffsets` chưa bao giờ nhìn thấy operand đó dưới bất kỳ dạng nào, kể cả
khi chạy ở cuối pipeline. Ghi lại là một ca hẹp còn mở.

## 5. CS0030 — tiền đề của brief sai hai lần

Brief nêu `CS0030 = 1125`, thông báo `Cannot convert type 'int' to 'TCP2_PlanarReflection'`, và đặt
nó làm họ lỗi ưu tiên cao nhất.

**Thông báo đó xuất hiện đúng một lần.** 1125 là số của *mã lỗi*; thông báo đi kèm là cái đầu tiên
trong log, do `grep -m1`. Đã sửa harness để in thông báo phổ biến nhất kèm tỉ lệ ("14 of 128"), nên
một cái đuôi dài không còn đọc được thành một họ nữa.

Phân loại thật, theo **hình dạng toán hạng** bị ép kiểu, đọc từ chính source:

| | | |
|---:|---|---|
| 680 | 60,4% | `LOCAL` — local có kiểu này, dùng ở chỗ muốn kiểu khác |
| 247 | 22,0% | `LITERAL_ZERO_STANDIN` — `((Fsm)0)`, giá trị thay thế của một load không phân giải được |
| 83 | 7,4% | `PARENTHESISED` — `(Matrix4x4)(&obj9)`, địa chỉ ở chỗ muốn giá trị |
| 57 | 5,1% | `DEFAULT_OR_TYPEOF` — `(IntPtr)typeof(...)` |
| 55 | 4,9% | `MEMBER_OR_ELEMENT` |

Hai kết luận:

1. **22% không phải lỗi gán kiểu.** Đó là `ldc.i4.0; conv.i` mà điểm bỏ cuộc đẩy lên, tức phép đếm
   lại của 2722 unresolved load dưới một cái tên khác. Đổi giá trị thay thế đó đã được đo là tệ hơn
   trên mọi trục (CLAUDE.md), nên phần này chỉ giảm khi unresolved load giảm.
2. **60% còn lại không có nguyên nhân áp đảo**: 229 cặp (kiểu nguồn, kiểu đích) riêng biệt, cặp lớn
   nhất 48 (`float → Vector3`). Đây là use-side type recovery của ROADMAP mục 5, và nó là một cái
   đuôi dài chứ không phải một bug. 816 trong 1125 nằm ở PlayMaker.

Theo đúng §11 của brief — không patch trước khi có phân loại — phân loại nói rằng ở đây không có gì
để patch.

## 6. Tham chiếu script và validator

Xem `docs/RUNNABLE_PROJECT_RECOVERY.md`. Tóm tắt: 6 tham chiếu gãy trên Impostor (không phải 4), 4
UNRESOLVED và 2 AMBIGUOUS, không cái nào được sửa vì không cái nào có bằng chứng đủ.
`validate_unity_project.py` báo 9 PASS / 1 FAIL / 1 WARN / 1 UNKNOWN / 3 NOT_RUN.

## 7. Kết quả âm

| Giả thuyết | Thí nghiệm | Kết quả | Vì sao bị loại |
|---|---|---:|---|
| Base được gán kiểu sau khi field resolution chạy lần cuối | `ResolveFieldOffsets` thêm một lần sau `CopyCoalescer` | 2722 → **2722** | Không đổi gì. |
| idem, muộn hơn nữa | thêm một lần ở cuối `Analyze` | 2722 → **2719** | 3 load. Đây là lần thứ ba giả thuyết này bị đo và bác bỏ. |
| Pass bỏ sót block không ai tới | `ResolveFieldOffsets` duyệt `AllInstructions` thay vì walk BFS | 2722 → **2722** | Không đổi gì. **Giữ lại** vì nó khớp pass với thứ thực sự được phát ra, không phải vì nó đáng một con số. |
| Luật khung toạ độ theo nguồn gốc (khuyến nghị 044) | đo trên dân số đã phân giải | — | Bị bác bỏ, mục 3. |
| Họ `RESOLVABLE` 48 load đáng làm | chạy phép tìm tại điểm đếm | 48 → **3** | Con số 48 là artefact của việc đo bằng layout tính toán. |

## 8. Test

376 (từ 372), một fail có sẵn (`GetMainExportID_ValueGreaterThan100000_DebugAssertFails`).

Bốn test mới về hai cách duyệt graph. Đã chứng minh **không suy biến**: định nghĩa `AllInstructions`
thành `Instructions` thì một test đỏ. Một test khẳng định chính tiền đề — walk BFS *không* thấy
block không ai tới — nên nó là thứ phân biệt, không phải thứ trang trí.

Nhánh `_CONFLICT` của `audit_script_references.py` không kích hoạt trên hai fixture nên đã kiểm bằng
fixture tổng hợp: có sibling đã phân giải thì `CONFLICTING`, bỏ sibling đi thì `AMBIGUOUS`.

## 9. Blocker còn lại

- **Unity không có trên máy này.** Import, build, runtime đều `NOT_RUN`. `NOT_RUN` không phải `PASS`.
- **iOS**: `__TEXT` bị FairPlay mã hoá, `BLOCKED` từ layer binary trở xuống. Không tự bypass DRM.
- **Shader decompile**: không có trong cây này; fixture chỉ có GLES.
- **3 load `SEARCH_ANSWERS`** chưa xác định được nguyên nhân.

## 10. Đề xuất iteration 046

Dựa trên bằng chứng của 045.

1. **1241 load `NO_OWNER` là nhóm lớn nhất và là nhóm duy nhất còn chưa phân loại.** Phép tìm field
   đã được chứng minh không phải nút thắt; 46% các load còn lại thất bại vì base **không có kiểu nào
   cả**. Phân loại 1241 ca đó theo `BasePointerOrigin` — 661 UNKNOWN,
   315 LOADED_POINTER, 141 ENTRY_VALUE, 50 STACK_SLOT, 35 INSTANCE_FIELD, 27 CALL_RESULT — trước khi
   làm gì — đúng như "phân loại trước khi làm" đã trả tiền ba lần.

2. **684 load có root cause `RUNTIME_STRUCT` không phải lỗi gán kiểu.** Base có kiểu đúng và đơn giản là không
   có managed field nào để đặt tên. Nhận diện và bỏ đi, thay vì báo là một thất bại — sẽ dời 25% số
   đo ra khỏi cột "chưa phục hồi được" một cách trung thực.

3. **`float → Vector3` 48 ca**, cặp lớn nhất của CS0030 và là một họ đã có tên: một thanh ghi mang
   một thành viên của aggregate bị gán kiểu là cả aggregate. CLAUDE.md đã ghi cách chữa ở phía hai
   đầu; 48 ca này là phần nó chưa với tới.

Không mở thêm subsystem shader cho tới khi có fixture có backend khác GLES.
