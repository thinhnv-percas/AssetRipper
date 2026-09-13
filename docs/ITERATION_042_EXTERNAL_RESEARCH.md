# Iteration 042 — nghiên cứu hai công cụ ngoài, và mô hình toạ độ offset

Hai repository được clone và đọc thật, không chỉ README. Một trong hai có tool chạy được và đã
chạy trên chính bản rip của dự án này; cái còn lại không chạy được và được ghi `NOT_RUN`.

---

## A. `clericall/il2cpp-wasm-teardown`

Clone `https://github.com/clericall/il2cpp-wasm-teardown.git`. 19 file: `README.md` (22 KB),
`tools/` (4 Python + 4 PowerShell), `wiki/` (9 trang Markdown).

### Cấu trúc và những gì đã đọc

`tools/measure-bodies.py`, `tools/measure-owned.py`, `tools/remap-ugui.py`, `tools/serve-webgl.py`;
wiki: `ISIL-Reference-and-Calling-Conventions.md`, `Tutorial-Reading-and-Reconstructing-ISIL.md`,
`Methodology-and-Census-Internals.md`, `Known-Limitations-and-Scope.md`.

### Kết luận trung tâm của repo

> "How much of a Unity game's code survives IL2CPP compilation? **Measured: 0.00%.**"
> Cùng phép đo trên hai game Unity backend Mono trả về 93–95%.

Con số 0,00% là đo trên output **AssetRipper hoặc Cpp2IL chưa có body reconstruction** — tức đúng
cái mà tính năng của repo này tồn tại để sửa.

### Tool đã CHẠY THẬT trên bản rip của dự án

`measure-bodies.py` phân loại mọi method thu hồi được thành empty / trivial stub / real body. Chạy
trên `Test/Output-042d`:

| Phạm vi | files | methods | empty | trivialStub | realBody | **live** |
|---|---:|---:|---:|---:|---:|---:|
| Assembly-CSharp | 63 | 254 | 8 | 2 | 244 | **96,06%** |
| toàn bộ rip | 819 | 4780 | 1224 | 546 | 3010 | **62,97%** |

Đây là **một oracle độc lập mà dự án chưa từng có**: mọi phép đo hiện tại đếm placeholder, lỗi
Roslyn hoặc diagnostic — không cái nào trả lời "bao nhiêu method có thân thật". Tool của người khác,
viết cho mục đích khác, không biết gì về repo này, và đi từ 0,00% lên 96,06%.

Lưu ý quan trọng để con số này không bị đọc sai: tool **cố tình** coi `throw null;` là stub chứ
không phải logic, vì đó là placeholder Cpp2IL `dll_il_recovery` sinh ra cho mọi method nó không
dựng lại được — "một assembly bị stub hoàn toàn nếu không sẽ đạt 100% live". Nó cũng coi thân hàm
chỉ gồm `out` parameter assignment là stub. Cả hai bẫy đó đều áp dụng cho output của dự án này, nên
96,06% là con số đã trừ chúng.

### Phương pháp chống false positive — thứ đáng học nhất

- Cả hai tool **thoát với lỗi** khi đường dẫn sai hoặc rỗng, thay vì in kết quả. Lý do được nói
  thẳng trong README: `0.00% live` cũng là câu trả lời đúng cho một bản export IL2CPP thật, nên
  **một lỗi gõ phím không bao giờ được phép bắt chước kết quả**. Đây đúng nguyên tắc mà iteration
  040 phải học bằng cách khác: một phép đo chưa từng chạy đọc giống hệt một phép đo không tìm thấy gì.
- Docstring của `is_trivial` ghi lại hai lần phân loại sai trước đó và vì sao — negative result nằm
  trong code, không bị xoá.
- `measure-owned.py` tách code của chính game khỏi middleware, vì middleware làm loãng tỉ lệ. Bài
  học này dự án đã có dưới dạng "Assembly-CSharp giữ chưa tới một phần mười số load".

### Về ISIL và offset

`ISIL-Reference-and-Calling-Conventions.md` và `Tutorial-Reading-and-Reconstructing-ISIL.md` mô tả
quy trình **thủ công**: đọc ISIL do Cpp2IL xuất, rồi tự tay ánh xạ `[rbx + 0x99]` về tên field bằng
cách tính layout theo thứ tự khai báo và quy tắc alignment.

Điều đáng lấy là **phát biểu tường minh về hệ toạ độ của class**:

> Object Header: offset `0x00`–`0x0F`. Base Class Fields (MonoBehaviour/UnityEngine): tới `0x1F`.
> First Custom Field: luôn bắt đầu ở offset **32 (`0x20`)**.

Trùng khớp với những gì `CLAUDE.md` đã ghi và với `GenericInstanceFieldLayout` của dự án.

### Những gì KHÔNG áp dụng được

Việc ánh xạ offset thủ công chính là thứ `MetadataResolver` đã tự động hoá, và làm tốt hơn: tài liệu
của họ dựng layout bằng cách *suy ra* từ thứ tự khai báo và alignment, trong khi dự án này đọc offset
**đo thật trong metadata**. Suy ra bằng alignment sẽ sai mỗi khi trình biên dịch sắp xếp lại field
hoặc khi `[StructLayout]` can thiệp. Không có gì để lấy ở chiều đó.

Phần WebAssembly porting là field notes, không tái lập được, và không liên quan.

---

## B. `jakzo/Il2CppDecompiler`

Clone `https://github.com/jakzo/Il2CppDecompiler.git`. Đọc `README.md`, `build.gradle`,
`test-script.sh`, `src/main/java/Il2CppDecompiler/Il2CppDecompilerPlugin.java`,
`ghidra_scripts/Il2CppDecompiler.java` (944 dòng).

### Kiến trúc thật, khác với những gì tên repo gợi ra

Chính tác giả ghi: *"This repo contains an extension which doesn't really do anything yet."* Kế
hoạch ban đầu — chuyển P-code của Ghidra sang C# — **đã bị bỏ**. Thứ đang hoạt động là một script
gửi output C của Ghidra cho GPT-4 và nhờ nó viết lại thành C#.

Nghĩa là repo này **không chứa thuật toán layout nào của riêng nó**. Luồng thật:

```
Il2CppDumper  →  il2cpp.h (C struct có offset)  →  Ghidra "Parse C source"
              →  ghidra_with_structs.py gán struct cho từng hàm
              →  Ghidra decompile ra C
              →  LLM viết lại thành C#
```

### Vấn đề Boneworks — bằng chứng thực tế về sai hệ toạ độ

README ghi:

> "For my game (Boneworks) the `il2cpp.h` generated by Il2CppDumper was missing a field in all class
> instances which made all field offsets wrong and caused property accesses to be **off by 8 bytes**."

Một field thiếu trong *mọi* class instance → toàn bộ offset lệch một con trỏ. Đây là xác nhận độc
lập rằng sai phần đầu của layout không hỏng một field mà hỏng **tất cả**, im lặng — và là lý do
iteration này từ chối cộng một hằng số vào offset khi chưa có bằng chứng.

### Xử lý exception / no-return

Script từ chối chạy khi còn hàm chưa đặt tên (`FUN_1234abcd`) trong method. Người dùng phải tự tìm
hàm ném exception, **đổi tên và đánh dấu "No Return"** trong Ghidra, nếu không Ghidra nối tiếp luồng
qua một lệnh gọi không bao giờ trả về và cấu trúc hoá sai. Dự án này tự động hoá đúng việc đó:
`ThrowHelperRecovery`, `InjectedCheckRemover`, và `UnreachableAfterThrow` — cái cuối tồn tại vì
"a throw reaches nothing, and the graph is built before it is one".

### Trạng thái chạy: `NOT_RUN`

Không chạy được, và không được ghi thành PASS. Ba blocker độc lập, mỗi cái đủ để chặn:

1. cần cài Ghidra và chạy auto-analyze trên `GameAssembly.dll` ("could be an hour or more");
2. cần output Il2CppDumper cho chính game đó;
3. `test-script.sh` bắt buộc `OPENAI_API_KEY` và một project Boneworks có sẵn.

Vì thế toàn bộ phần B là **đọc source tĩnh**, không có đối chiếu runtime nào. Mục §8 của brief
(đối chiếu Ghidra P-code) **không thực hiện được** và không được giả vờ đã thực hiện.

### Đường dẫn dẫn tới bằng chứng thật

Dòng 411 của `Il2CppDecompiler.java` trỏ tới
`Perfare/Il2CppDumper/Il2CppDumper/Outputs/StructGenerator.cs`. Đó mới là nơi mô hình layout thật
sự nằm, nên repo thứ ba đã được clone và đọc — xem mục C.

---

## C. `Perfare/Il2CppDumper` — mô hình layout có thẩm quyền

`StructGenerator.cs` phát ra layout dưới dạng C struct. Đoạn quyết định (dòng ~1095):

```c
struct T_o {
    T_c *klass;      // chỉ khi !IsValueType
    void *monitor;   // chỉ khi !IsValueType
    T_Fields fields; // luôn luôn
};
```

và `AddParents` chỉ đi lên chuỗi cha khi `!typeDef.IsValueType && !typeDef.IsEnum`.

Phát biểu thành hai câu:

- **class**: header đúng `0x10` (hai con trỏ) rồi mới tới field. Offset metadata của một class **đã
  bao gồm** header.
- **value type**: **không có header nào cả**. `T_o` chính là `T_Fields`. Offset metadata của một
  struct tính từ dữ liệu của chính nó.

Khớp chính xác với `CLAUDE.md` và độc lập với nó.

---

## D. So sánh ba mô hình

| Capability | Dự án này | wasm-teardown | Il2CppDecompiler (+Dumper) |
|---|---|---|---|
| metadata | đọc trực tiếp từ global-metadata | không đọc; suy từ thứ tự field | Il2CppDumper đọc trực tiếp |
| native instruction | có, qua Cpp2IL ISIL | có, đọc tay bản ISIL xuất ra | có, qua Ghidra disassembler |
| IR | ISIL + SSA + CFG, 6 biểu diễn | ISIL thô, không biến đổi | Ghidra P-code (đã bỏ dùng) |
| field offset | offset **đo thật** trong metadata | **suy ra** từ alignment | offset thật, qua struct C |
| value type | layout riêng + hai hệ toạ độ (xem E) | không đề cập | không header, theo `IsValueType` |
| generic | `GenericInstanceFieldLayout` tính layout cho instantiation | không đề cập | struct riêng cho từng generic class |
| nested field | `NestedFieldResolver`, có kiểm tra độ rộng | thủ công | C struct lồng nhau, Ghidra tự đi xuống |
| validation | `SelfCheck` đối chiếu layout tính được với metadata thật | census + spot-check tay | không có; lỗi Boneworks phải phát hiện bằng mắt |

Điểm mạnh riêng của từng bên: dự án này là bên duy nhất **tự kiểm chứng layout** (`SelfCheck`:
1394 exact, 0 disagreement); wasm-teardown là bên duy nhất có **oracle độ sống của thân hàm**;
Il2CppDumper là mô hình **phát biểu tường minh** class/value-type bằng C struct.

---

## E. Hệ toạ độ — câu trả lời cho "OffsetFromWhat?"

Đây là mục tiêu chính của brief, và câu trả lời **không phải là một thuộc tính của kiểu**.

> Hệ toạ độ là thuộc tính của **cách con trỏ base có được**, không phải của kiểu dữ liệu.

- base là **class**: object-relative. Offset metadata của class đã gồm header, nên không có gì phải
  quyết định.
- base là **value type lấy từ `this` của chính method của struct đó**: il2cpp trao một con trỏ trỏ
  vào header của object đã box, nên field ở metadata offset 0 được đọc ở `[this + 0x10]`.
- base là **value type nằm trong static storage, trong một ô stack, hoặc là field của object khác**:
  value-relative, đọc đúng ở offset metadata.

### Đo, không đoán

Cột `CoordinateEvidence` mới trên `CPP2IL_DUMP_LOADS` thử cả hai cách đọc addend trên từng load và
báo cách nào rơi trúng một field. Trên 2722 load của Impostor:

| | số |
|---|---:|
| `CLASS_OBJECT_RELATIVE` (base là class, không có gì để quyết định) | 553 |
| `NOT_APPLICABLE` (base chưa có kiểu, runtime struct, tham số kiểu mở) | 1900 |
| **`VALUE_RELATIVE`** | **77** |
| **`OBJECT_RELATIVE`** | **29** |
| `BOTH` | **0** |
| `NEITHER` | 163 |

Trừ tiếp các trường hợp yếu — addend 0 khớp field đầu một cách tầm thường ở cách đọc value-relative,
addend 0x10 cũng vậy ở cách đọc object-relative:

| | mạnh | yếu |
|---|---:|---:|
| `VALUE_RELATIVE` | **43** | 34 |
| `OBJECT_RELATIVE` | **14** | 15 |

### Giả thuyết của iteration 041 bị BÁC BỎ

041 đề xuất: "metadata ghi offset từ dữ liệu của chính value, còn `LayoutOf` bắt đầu ở
`2 * pointerSize` như thể có object header" — và đề xuất đó dẫn tới việc cộng `0x10` cho value type.

Áp dụng thành luật chung sẽ **làm sai 77 load để sửa 29** (43 với 14 trên tập không nhập nhằng).
Không phải "chưa đủ bằng chứng" mà là **bằng chứng ngược lại**.

Kiểm chứng cột này bằng một ca đã truy tay đến tận metadata: `ObscuredDecimal.currentCryptoKey` ghi
ở metadata offset `0x0`, mã máy đọc `[X0 + 0x10]` với X0 là `this` của chính method của struct đó,
và cột báo `OBJECT_RELATIVE`. Đúng.

`BOTH = 0` là phát hiện phụ đáng giá: hai cách đọc **không bao giờ** cùng trúng, nên trên từng load
bằng chứng có tách được. Nhưng "cách nào trúng thì lấy" là heuristic, không phải luật — và đúng loại
suy đoán mà các iteration 036/037/038 đã loại. Muốn dùng được thì phải có luật nói con trỏ base có
được bằng cách nào.

---

## F. Kết luận chỉ gồm những gì có bằng chứng

1. Il2CppDumper phát biểu tường minh: class có header `0x10`, value type không có header. Khớp với
   `CLAUDE.md`, và khớp độc lập.
2. Hệ toạ độ thuộc về **con trỏ base**, không thuộc về kiểu. Một value type xuất hiện ở cả hai hệ.
3. Giả thuyết "+0x10 cho mọi value type" của iteration 041 bị **bác bỏ bằng số đo**: 77 chống 29.
4. `measure-bodies.py` là oracle độc lập mới, chạy được, và cho 96,06% trên Assembly-CSharp so với
   0,00% mà chính tác giả nó đo trên bản export IL2CPP thường.
5. Đối chiếu runtime với Ghidra: **NOT_RUN**, ba blocker, không giả vờ đã làm.
