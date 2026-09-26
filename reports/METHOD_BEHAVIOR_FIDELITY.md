# Trung thực về hành vi: cái gì là khiếm khuyết của phục hồi, và cái gì là của phép đo

Iteration 059, §3–§9.

## 1. Hai thứ phải tách, và chúng đọc giống hệt nhau

Iteration này bắt đầu từ một brief đặt "197 `FALLBACK` và 16 `MISMATCH` của Merge-Room, phần lớn mang
dấu `loops: source N, recovered 0`" làm ưu tiên cao nhất, và yêu cầu truy từ lệnh máy xuống tới nơi
vòng lặp biến mất.

Bước đầu tiên là đếm, không phải truy. Trong 192 hàng `FALLBACK`, **6 hàng có vòng lặp trong nguồn**.
Hai ví dụ đầu tiên mở ra thì bản phục hồi đúng tuyệt đối. Nguyên nhân là phép đo đọc toàn văn file
nguồn trong khi build chỉ biên dịch một nhánh `#if`.

Đây là lần thứ bảy dự án phải tách một họ đặt tên theo triệu chứng trước khi làm nó. Danh sách ở
`CLAUDE.md`; lần này là lần đầu tiên nguyên nhân nằm ngoài pipeline phục hồi hoàn toàn.

## 2. Khiếm khuyết phục hồi thật, tìm bằng cùng một oracle

Một lifted local sống ở đúng một chỗ, và cả ba lần dùng nó — đọc, ghi, lấy địa chỉ — phải đồng ý.
Iteration 058 sửa một trong ba site. Site ghi vẫn `stloc` vào một local generator tự bịa trong khi
site đọc `ldarg` vào tham số:

| | trước | sau |
|---|---|---|
| `TimeCheatingDetector` (`out OnlineTimeResult result`) | `reference = ref *(OnlineTimeResult*)1` | `result = ref *(…)` |
| `ObscuredBool` (`ref byte key`) | `ref byte reference = ref *(byte*)…` | `key = ref *(byte*)…` |

Một tham số `ref`/`out` được gán vào một chỗ mà người gọi không bao giờ đọc. 46 file trên Impostor,
37 trên RunFromZombies, và **mọi con số tổng y nguyên**: cùng số lệnh, khác chỗ ghi. Không phép đo
đếm-được nào thấy được hình dạng đó, và đó là lý do oracle so với nguồn tồn tại.

`LocalStorage.For` là một luật duy nhất; bảy ca test, một ca phát biểu thẳng bất biến. Shape check
DECOMP-0022, đỏ trên bản rip trước khi sửa.

## 3. Provenance của con trỏ

`PointerClassifier` trả lời "con trỏ này trỏ vào cái gì, và được dựng ra thế nào": kind, coordinate
frame, đường đi. Ba thứ phải phân biệt, hai thứ đầu dùng chung kiểu tĩnh — mảng nền `list._items`,
địa chỉ phần tử `&list._items[i]`, và chính cái list.

`InlineListAddRecovery` **không được nới**: 1346 candidate, 820 gấp, 526 từ chối trên Merge-Room, y
hệt 058. Cái đổi là lý do từ chối, và họ "133 element address" của 058 tách ra:

| nhóm | ý nghĩa |
|---|---|
| element address thật, kèm đường đi `v242[i][i]` | đúng như 057/058 kết luận |
| **`[This/ObjectRelative this+32]` ×16** | **không phải** element address — một field ở offset 0x20 của receiver chưa phân giải được |
| `an object, call result` ×35 | receiver là kết quả một lời gọi |
| `an object, new List<char>` ×15, `new NullReferenceException` ×15 | receiver là một cấp phát mới |

Nhóm `this+32` là phát hiện của iteration này: nó nằm lẫn trong cùng một họ trước đây, và công việc
nó đòi hỏi (`MetadataResolver`) khác hẳn công việc mà "ánh xạ đối số" đòi hỏi.

## 4. Bằng chứng cho inline

Một thân hàm mà nguồn nói là gọi một hàm, dài tám byte mã máy, và không chạm một ranh giới runtime
nào, thì **không** gọi gì cả — không đủ chỗ, và không có dấu hiệu nào cho thấy phân tích bỏ cuộc.
il2cpp đã inline nó. `AndroidOnly.IsGoodPlatform` trả `DeviceInfo.IsAndroid()`, thân native tám byte,
và `return true;` là bản phục hồi đúng.

`RecoveredSemanticIr.NativeLength` là con số đó. Không có nó thì "inline" và "mất mát" không phân biệt
được, và một phép đo không phân biệt được hai thứ muốn công việc ngược nhau thì tệ hơn không đo.

## 5. Cái corpus hành vi không bắt được

Corpus đóng băng hợp đồng: thành viên được đọc và ghi, lời gọi, vòng lặp, nhánh. Khiếm khuyết ở mục 2
đổi **giá trị được ghi** chứ không đổi **thao tác được thực hiện** — cùng field, cùng lời gọi, cùng
đồ thị — nên corpus báo 0 thay đổi, đúng như 058. Cái bắt được nó là oracle so với nguồn. Hai phép đo
phân công như vậy và cần cả hai; không cái nào bao hàm cái kia.
