# Iteration 047 — bằng chứng cho hai họ runtime, và phép đo theo từng method

## 1. Baseline

Tái lập 046 đúng tới từng con số trước khi chạm vào gì.

| | 046 | 047 |
|---|---:|---:|
| load bỏ cuộc (Impostor / Pinata) | 2722 / 9245 | **2722 / 9245** |
| `generatorFailures` | 0 | **0** |
| file `.cs` (Impostor / Pinata) | 819 / 3083 | 819 / 3083 |
| file `.cs` khác baseline | — | **0 trên cả hai fixture** |
| Roslyn Impostor / Pinata | 348-0 / 1478-1 | 348-0 / 1478-1 |
| shape | 16/16 | 16/16 |
| `array[i].field` / `(float)array[i]` | 164 / 0 | 164 / 0 |
| MANAGED_FIELD / UNKNOWN / RUNTIME_STRUCT / NATIVE_TEMPORARY / ARRAY_ACCESS | 901/761/651/343/66 | **giống hệt** |
| EXACT / INFERRED / NONE | 997/964/761 | **giống hệt** |
| `m_Script` gãy | 6 | 6 |
| test | 386 | **388** |

Iteration này **không đổi một byte nào của bản rip**.

## 2. §12 — `byval_arg.attrs`, và nhãn của 046 sai

Brief cấm mặc định "nhận diện rồi bỏ" với 103 lệnh đọc này và yêu cầu xác định chính xác. Xác định
xong thì nhãn của iteration 046 **sai**.

Một byte mà nhiều bitfield dùng chung chỉ gọi được tên **nhóm**. 046 ghi nhận điều đó trong tên
("(bitfield)") rồi vẫn in ra thành viên đầu tiên chiếm byte — `attrs`. Thành viên nào thật sự bị đọc
thì do **bit** quyết định, và bit nằm ở lệnh tiêu thụ.

Cột `consumer` mới ghi lệnh nào tiêu thụ mỗi load:

| | |
|---:|---|
| 100 | `CheckLess[1]:LocalVariable,0x0` — thử dấu, tức bit 31 |
| 3 | `And[1]:LocalVariable,0x80000000` — mặt nạ đúng bit 31 |

Struct database nói offset 0x28 của `Il2CppClass` là đơn vị bitfield của `byval_arg`:
`attrs` bit 0–15, `type` bit 16–23, `num_mods` bit 24–28, `byref` bit 29, `pinned` bit 30,
**`valuetype` bit 31**.

Nên cả 103 lệnh là **`klass->byval_arg.valuetype`** — phép thử value-type mà thân generic chia sẻ
thực hiện trên chính tham số kiểu của nó. Mọi base là `Il2CppClass<TKey>` hay `Il2CppClass<T>`, tức
tham số kiểu **mở**, nên không có câu trả lời tĩnh: đây là `RUNTIME_STRUCT` đúng nghĩa theo §11, giờ
có bằng chứng thay vì phỏng đoán. 53 lệnh `MethodInfo.is_generic` cũng đổi thành **`is_inflated`**
theo cùng cách.

## 3. §13 — `stack_slot_size`

61 lệnh. **43 được tiêu thụ bởi `Add[1]:LocalVariable,0xf`** — cộng 15.

Đó chính xác là bước làm tròn của trình tự alloca mà `CLAUDE.md` mô tả từ iteration 033 (`+15` rồi
`and 0x1FFFFFFF0`), xác nhận từng lệnh một bằng một con đường độc lập. Phân loại giữ nguyên; điều
thay đổi là nó không còn là một phỏng đoán.

## 4. §14/§15 — điểm phục hồi theo từng method

Mọi phép đo hiện có là một **tổng**. Không cái nào trả lời được câu hỏi dự án bị đánh giá theo — *có
bao nhiêu method quay về với hành vi còn nguyên* — và một tổng thì không thể: một method với 200
placeholder và 200 method mỗi cái một cho ra cùng con số.

Bằng chứng nằm ngay trong bản export: mỗi method mang `[Address(RVA, Length)]`.

**Impostor**, 10 assembly được thử phục hồi, 5482 method:

| | | |
|---:|---:|---|
| 3865 | 70,5% | `RECOVERED_CLEAN` — không placeholder, không local vô kiểu |
| 1375 | 25,1% | `PARTIAL` — mang **toàn bộ** 5130 placeholder |
| 242 | 4,4% | `RECOVERED_UNTYPED` |
| **0** | | **mất hẳn thân** |

**Pinata**, 42 assembly, 16365 method: 12750 CLEAN, 2837 PARTIAL (12565 placeholder), 762 UNTYPED, và
**đúng hai** method mất hẳn thân — cả hai 76 byte trong AppMetricaSDK (`YandexAppMetricaReceipt`,
`YandexAppMetricaConfig`).

Đó chính là con số §16 cần: một method biên dịch được nhưng bị thay bằng thân rỗng **không phải** là
phục hồi. Giờ có phép đo bắt được nó, và nó nói rằng điều đó gần như không xảy ra — với hai cái tên
cụ thể khi nó xảy ra.

Placeholder **tập trung** chứ không rải đều: 5130 nằm trong 1375 method, method tệ nhất 113
(`MeshGenerator`). Báo cáo in top method theo số placeholder, nên "làm gì tiếp" đọc được từ chính nó.

## 5. Ba lần phép đo tự báo sai, và cả ba phải sửa trước khi tin

1. **So khớp lệnh tiêu thụ bằng tham chiếu báo "không có" cho cả 2722 load.** Operand generator đưa
   cho event không phải object còn nằm trong graph. So khớp bằng văn bản thì đúng.
2. **`[NativeSource(Body = "...")]` mang dấu ngoặc nhọn bên trong một chuỗi**, nên phép đếm ngoặc
   đóng khối trước khi nó mở và **366 method đọc thành "mất thân"** trong khi mọi cái đều có thân.
3. **Chỉ một ít assembly được phục hồi; phần còn lại bị stub có chủ ý** và mọi method trong đó rỗng
   một cách chính đáng. Chấm điểm chúng như thân bị mất cho ra **322 ca mất mát không hề tồn tại** —
   đúng kiểu "vắng mặt đọc thành hỏng" đã tốn ba lần đo trong dự án này. `--log` đọc danh sách từ log
   thay vì đoán; không có log thì phạm vi ghi rõ là `UNKNOWN`.

Và một lần thứ tư, ở chiều khác: thêm một cột vào dump đẩy `memory` từ 21 sang 22 và
`recovery_report.py` vẫn đọc 21, làm `ARRAY_ACCESS` rơi 66 xuống 7. **Bắt được vì baseline được đo
lại và so**, không vì nhìn ra.

## 6. Những thứ không làm, và vì sao

- **Không tạo managed field giả** cho 651 lệnh đọc runtime (§11). Chúng được gọi tên, giờ chính xác
  tới từng bit.
- **Không "nhận diện rồi bỏ" `byval_arg`/`stack_slot_size`** — §12 cấm, và điều tra cho thấy nhãn cũ
  sai, nên bỏ theo nhãn cũ sẽ bỏ nhầm thứ.
- **Không patch resolver.** 045 đã đo: phép tìm field trả lời được cho 3 trên 2722.
- **Không sửa 6 tham chiếu `m_Script` gãy** — 045 đã đo: 4 không ứng viên, 2 chỉ có tên tài liệu.
- **Không mở subsystem shader** — fixture chỉ có GLES (044).

## 7. Trạng thái Unity project

`validate-unity-project` trên Impostor: 9 PASS / 1 FAIL (6 `m_Script` gãy) / 1 WARN (shader thay thế
`DUMMY`, không bao giờ là PASS) / 1 UNKNOWN / 3 `NOT_RUN`. Unity không có trên máy → import, build,
runtime đều `NOT_RUN`, và `NOT_RUN` không phải `PASS`.

## 8. Đề xuất iteration 048

1. **1375 method `PARTIAL` mang toàn bộ 5130 placeholder, và top 12 file mang ~700.** Đó là danh sách
   công việc đầu tiên trong dự án được sắp theo *method* chứ theo assembly. Bắt đầu từ
   `MeshGenerator` (113) và `OrderedDictionary` (64+63) — cái thứ hai chính là nơi 103 lệnh
   `byval_arg.valuetype` nằm, nên hai việc là một.
2. **Hai method Pinata mất hẳn thân** có tên cụ thể và 76 byte mã máy mỗi cái. Nhỏ, xác định được, và
   là dạng lỗi tệ nhất theo §16.
3. **`MANAGED_FIELD` 901** vẫn là nhóm lớn nhất của phần hỏng thật. Phân loại theo *kiểu của base*
   trước khi làm gì.
