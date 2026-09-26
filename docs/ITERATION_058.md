# Iteration 058 — hành vi của method, và chương trình shader thật

## 1. Baseline (§1, §2)

Bốn fixture. Baseline là bản rip cuối của 057 (`Test/Out57H-*`), ở đúng commit `a1194887` mà phiên
làm việc bắt đầu; bản rip của 058 là `Test/Out58H-*`, đo sau khi tiến trình thoát.

Một lưu ý về phương pháp: bản rip baseline **không** được chạy lại từ đầu, vì `Test/Out57H-*` đã là
bản rip tại đúng HEAD và 057 đã ghi nhận nó. Một lần chạy lại đã bắt đầu rồi bị huỷ, vì một lần
`dotnet build` giữa chừng làm hai fixture đầu chạy trên binary cũ và hai fixture sau trên binary mới
— một baseline pha tạp còn tệ hơn không có baseline.

Invariant: `generatorFailures` **0** cả bốn; field-layout disagreement **0** cả bốn (1394/2165/2654/3947
type tái tạo đúng); golden corpus **0 regression** giữa 057 và 058 trên cả bốn; source oracle
RunFromZombies `semantic_equivalence_rate` **1,0000 (36/36)**; test 492/493 với một fail có sẵn; shape
checks sạch trên Impostor.

## 2. Một nguồn sự thật, nay mang cả đồ thị và luồng giá trị (§3, §4, §5)

`RecoveredSemanticIr` vẫn là nguồn duy nhất — **không có IR thứ hai**. Nó được mở rộng tại đúng chỗ
generator sinh mã:

- `RecordGraph` ghi các basic block từ *cùng danh sách* mà vòng lặp sinh mã duyệt: successors,
  predecessors, terminator, điều kiện nhánh, cờ loop header.
- `EnterBlock` / `EnterInstruction` gắn mỗi thao tác vào khối của nó và vào chính lệnh đang được sinh
  mã, nên mọi entry mang theo giá trị nó đọc và giá trị nó tạo ra.

Ghi *operand* chứ không ghi `Sources`: nguồn của một lệnh đọc field là một `FieldReference`, và
`Sources` chỉ kể thanh ghi được đọc — với hình dạng đó là không có gì cả, nên chuỗi đứt đúng chỗ cần
nhất. Kết quả là `field -> compare -> branch` của §5 biểu diễn được:

```
CALL Time::get_deltaTime -> v160 -> COMPARE CheckLess -> v265
block 10  condition v265  ->  true 11, false 12
```

`reports/METHOD_BEHAVIOR_CONTRACT.md` là bản đầy đủ. 37.474 hợp đồng qua bốn fixture; **82% điều kiện
nhánh truy được về thao tác sinh ra chúng**.

Cạnh ngoại lệ là **0 có lý do**, không phải vì chưa đo: đồ thị dựng từ ISIL đã lift, nơi throw còn là
lời gọi helper, và `UnreachableAfterThrow` tách khối đó ra.

## 3. Một lỗi logic thật, tìm ra và sửa ở phép biến đổi sai sớm nhất (§22.4)

`LoadOperand` xử lý `AddressOf { Target: LocalVariable }` bằng `Ldloca locals[addressed]`, bỏ qua
`LoadLocalAddress` — hàm duy nhất biết rằng một `LocalVariable` thường xuyên *chính là một tham số*.
Khi nó là tham số, generator lấy địa chỉ của một local nó tự tạo, mà không ai từng ghi vào.

```
LayerMaskExtension.IncludesAny(this LayerMask layerMask, …)
  ISIL   v10 = UnityEngine.LayerMask::get_value(&layerMask @ X0)
  trước  LayerMask layerMask2 = default(LayerMask); int value = layerMask2.value;
  sau    int value = layerMask.value;
```

`ObscuredBool.op_Implicit` trả về giải mã của *số không*; `TimeInGame` lấy Day/Month/Year từ
`default(DateTime)`. Biên dịch được, đọc rất hợp lý, trả lời sai mọi lần.

Trên Impostor — fixture tất định — **16 file đổi nội dung và mọi con số tổng y nguyên**: 5482 method,
4293 placeholder, EXACT 3782. Đó là hình dạng của một bản sửa tính đúng đắn, và là lý do không phép
đo đếm-được nào bắt được nó.

Giữ lại bằng `check_recovered_shapes.sh` DECOMP-0021 — hai check, cả hai **đỏ** trên bản rip trước
khi sửa.

## 4. Oracle hành vi theo nguồn (§6)

`source_behavior_oracle.py` so hợp đồng hành vi với hành vi của chính văn bản lập trình viên viết.
So sánh cố ý bất đối xứng về lời gọi: il2cpp inline method framework tầm thường, nên
`Vector3.MoveTowards` đã biến mất trước khi có gì để phục hồi. Cái bản phục hồi *không được phép* làm
là đánh mất hiệu ứng của nguồn.

| | RunFromZombies | Merge-Room |
|---|---:|---:|
| `EXACT` | 23 | 1108 |
| `SEMANTICALLY_EQUIVALENT` | 12 | 971 |
| `PARTIAL` | 0 | 699 |
| `MISMATCH` | 0 | 16 |
| `FALLBACK` | 0 | 197 |
| `behaviour_equivalence_rate` | **1,0000** (35/35) | 0,6951 (2079/2991) |

Nó tự báo mình sai **năm** lần trước khi tin được, và cả năm đều đọc y như một khiếm khuyết của bản
phục hồi: `scoreCounter++` là một lần ghi không có dấu `=`; `transform.position = …` là ghi property
mà bản phục hồi gọi đúng tên setter; `Debug.LogFormat("Button A Pressed for the first time")` đọc
thành một vòng `for`; tên của một method một dòng nằm trong chính văn bản thân nó nên đọc thành một
lời gọi đệ quy; và `async` thì cũng nằm trong một state machine như coroutine.

`--self-test` có 9 ca, mỗi ca đỏ nếu luật nó đặt tên bị bỏ đi.

## 5. Corpus hành vi (§7)

`Test/logic-behavior-corpus.json`: 293 hợp đồng đóng băng qua bốn fixture, chọn theo *vai trò* chứ
không theo mức độ hỏng — Unity message, miền (movement/score/health/timer/spawn/level), cấu trúc
(List/array/dictionary/delegate/interface/virtual/coroutine/exception/boundary), và năm hình dạng
regression đã từng sai một lần.

Nó **ổn định** qua hai bản rip Merge-Room độc lập (86/86, trên một fixture mà một file `.cs` khác
nhau giữa hai lần chạy) và nó **phân biệt được** (làm hỏng hai entry thì báo đúng hai).

Nó **không** bắt được lỗi ở mục 3: lỗi đó đổi *giá trị được đọc* chứ không đổi *thao tác được thực
hiện*. Hai phép đo phân công như vậy và cần cả hai.

## 6. Shader: nguồn oracle, blob, và ngữ nghĩa (§9–§16)

`reports/SHADER_PROGRAM_RECOVERY.md` và `reports/SHADER_SEMANTIC_EQUIVALENCE.md`.

**Oracle có tồn tại và luôn tồn tại.** 24/24 shader xuất ra của RunFromZombies, 3/3 của Impostor và
7/32 của Merge-Room có ShaderLab nguồn — trong `Assets/` hoặc ở đúng phiên bản package mà
`manifest.json` ghim. Không cần tạo fixture shader riêng.

**Chương trình GLES *là* mã nguồn GLSL**, câu hỏi bỏ ngỏ từ 053. 3079/6704 sub-program của
RunFromZombies và 231/759 của Impostor đọc ra `#ifdef VERTEX … #ifdef FRAGMENT` trong *một* blob —
đúng dạng khối `GLSLPROGRAM` của Unity. Nên đây là **trích xuất, không phải dịch ngược**, và
exporter viết thẳng nó vào pass: **96 khối GLSL thật** trên ba fixture Android.

**Trên iOS thì không.** JellyBlast v2 biên dịch chỉ sang Metal: 798 binary, 366 in được mà không
mang marker nào, **0 mã nguồn**. Không có văn bản để trích xuất; muốn đi tiếp cần một trình dịch
ngược Metal.

**13 shader đạt `SEMANTICALLY_EQUIVALENT`** (9 + 2 + 2). `shader_exact` vẫn **0** ở mọi fixture và đó
là con số đúng: `EXACT` đòi bộ thao tác trùng khít hai chiều, mà HLSLcc khai triển `lerp` thành số
học.

Thêm vào ShaderLab xuất ra: **Blend, ColorMask, Offset và Stencil**, đều nằm trong asset và đều đang
bị vứt đi. Một chương trình đúng dưới trạng thái blend sai thì không vẽ ra thứ shader đã vẽ.

## 7. `List<T>.Add` (§17)

Không nới recogniser. 3055 candidate, 2087 gấp — không đổi. `reports/LIST_ADD_ARGUMENT_PROVENANCE.md`
phân loại 968 site bị từ chối theo *nguồn gốc của receiver*, và xác nhận lại kết luận của 057 trên cả
bốn fixture: 133 + 26 site có receiver là **địa chỉ của một phần tử mảng**, không phải một list. Ba
thứ được phân biệt rõ — list receiver, backing array, element address. Pass từ chối là **đúng**.

## 8. Số cuối

Xem `docs/RECOVERY_MATRIX.md`.

## 9. Trạng thái

`PROJECT_COMPILES_NOT_RUNTIME_VALIDATED`. Unity không có trong container: stage E–I `BLOCKED`,
`runtime_status: NOT_RUN`. Không có tuyên bố runtime nào.
