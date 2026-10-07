# Vì sao một struct trên stack bị để nguyên — iteration 068 (§14)

Nhãn: **MEASURED**. Nguồn: dòng log `(068): stack structs left alone by reason` và dump `CPP2IL_DUMP_STRUCT_REJECTIONS`.
Mỗi hàng của dump ghi assembly, type, method, RVA, địa chỉ native của lệnh gây từ chối, slot, kiểu ứng viên, lý do,
chi tiết và lệnh ISIL.

## 1. Luật không đổi

`StackStructStorage` (067) viết lại *cả* struct hoặc không gì. 068 không nới luật nào. Mỗi lần từ chối giờ mang tên
luật đã từ chối, nên câu hỏi "vì sao kickoff này còn ở dạng con trỏ" trả lời được mà không cần đọc ISIL.

| Lý do | Nghĩa |
|---|---|
| `NOTHING_TO_REWRITE` | slot không có store nào cần viết lại; không phải lỗi |
| `NAMED_READ_INSIDE` | một byte bên trong struct được đọc bằng tên ô, không qua member |
| `STORE_WIDTH_MISMATCH` | độ rộng store khác kích thước member ở offset đó |
| `ROOT_STORE_OF_OTHER_VALUE` | offset 0 nhận một giá trị không phải bản sao của struct |
| `VERSION_READ_AS_VALUE` | một version SSA của slot được đọc như một giá trị |
| `CONFLICTING_STRUCT_TYPES` | các version của slot mang kiểu struct khác nhau |
| `INCOMPLETE_COPY` | bản sao theo khối không phủ hết member |
| `UNKNOWN_STORE_WIDTH` / `UNMATCHED_MEMBER` | store không có độ rộng, hoặc offset không trúng member |
| `UNKNOWN_COPY_SOURCE` / `COPY_SOURCE_NOT_MEMBER_TYPE` | nguồn của bản sao không truy được, hoặc khác kiểu member |
| `NON_MOVE_STORE` | slot được ghi bởi lệnh không phải `Move` |
| `UNKNOWN_MEMBER_LAYOUT` / `OVERLAPPING_STORAGE` | kích thước 0, hoặc hai slot chồng lên nhau |

## 2. Phân bố (68e)

| Lý do | Impostor | Merge-Room | JellyBlastV2 | RunFromZombies |
|---|---|---|---|---|
| NOTHING_TO_REWRITE | 98 | 787 | 305 | 233 |
| NAMED_READ_INSIDE | 88 | 1000 | 117 | 16 |
| STORE_WIDTH_MISMATCH | 64 | 196 | 117 | 181 |
| ROOT_STORE_OF_OTHER_VALUE | 48 | 82 | 28 | 18 |
| VERSION_READ_AS_VALUE | 16 | 40 | 21 | 6 |
| CONFLICTING_STRUCT_TYPES | 4 | 33 | 26 | 16 |
| INCOMPLETE_COPY | 4 | 20 | 16 | — |
| UNKNOWN_COPY_SOURCE | 10 | 4 | 10 | 2 |
| UNMATCHED_MEMBER | 2 | 2 | — | 16 |
| COPY_SOURCE_NOT_MEMBER_TYPE | — | 2 | — | 12 |
| NON_MOVE_STORE | 4 | 12 | 9 | 4 |

Đọc được ba điều.

- **NAMED_READ_INSIDE của Merge-Room là một kiểu.** 768 trên 1000 là `UnityEngine.Keyframe`. Đó là các mảng keyframe của
  `AnimationCurve` dựng trên stack, rồi đọc lại từng float theo tên ô. Đây là một hình dạng, không phải 768 lỗi.
- **STORE_WIDTH_MISMATCH phần lớn là store đóng gói.** Trên RunFromZombies, 131/181 là `offset 8 width 8 member 1`: một
  store 8 byte khởi tạo nhiều member `bool`/`byte` liền nhau. Đây là `IlGenerator.PackedFieldsCovered` ở tầng struct trên
  stack, và chưa được làm.
- **13 kickoff async còn lại của RunFromZombies là hai lý do:**
  - 6 `UNMATCHED_MEMBER offset 4 width 0`, của `<ReadArrayIntoByteArrayAsync>d__5`, `<DoReadAsBytesAsync>d__42`,
    `<DoReadAsStringAsync>d__55`…: bản sao 4 byte của `[X8 + 4]`, một phần của `AsyncTaskMethodBuilder<object>` trả qua
    buffer X8;
  - 6 `COPY_SOURCE_NOT_MEMBER_TYPE member at 8 size 24`: builder đến qua V0.

  Cả hai đều là builder chia sẻ `AsyncTaskMethodBuilder<object>` của Newtonsoft, như 067 đã ghi.

## 3. Luật padding — đã viết, chưa từng bắn

Một store vào vùng mà mọi field đều không phủ (`IStackStructModel.IsPadding`) được lập kế hoạch như Nop thay vì làm cả
struct thất bại. Test: `AStoreIntoPaddingIsDroppedNotRefused`, `AStoreThatReachesAMemberIsNotPadding`.

Trên fixture, `0 padding stores dropped` ở cả bốn. Lý do đọc được ngay từ dump: store ở offset 4 có `width 0`. Lệnh đó do
`StructSlotAliasRecovery` tạo ra, nên không có bản ghi độ rộng trong `StackAnalyzer.StackStoreWidths`. Luật yêu cầu độ
rộng > 0 trước khi gọi một vùng là padding, và luật đó phải giữ: không có độ rộng thì không chứng minh được store không
chạm member. Việc còn lại là mang độ rộng qua `StructSlotAliasRecovery`. Chưa làm ở 068; đây là bước đầu tiên của lần sau.
