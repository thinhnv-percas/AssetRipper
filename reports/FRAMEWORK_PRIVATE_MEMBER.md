# `FRAMEWORK_PRIVATE_MEMBER` — ba thứ khác nhau dưới một cái tên

Iteration 054, §7. Cụm này là cụm lỗi biên dịch lớn nhất còn lại sau khi sửa page base:
**1637 lỗi / 50 file** trên JellyBlastV2 và **192 / 13** trên Impostor. Brief cấm chữa nó bằng cách
public hoá mọi framework member, và yêu cầu phân biệt *framework real limitation* với *recovery
mistake* với *compatibility API requirement*. Đây là phép phân biệt đó, đo chứ không đoán.

## Đo theo member, không theo owner

| member | JellyBlastV2 | có public API đọc được không |
|---|---|---|
| `List<T>._version` | 800 | **không** |
| `List<T>._items` | 429 | **không** (có `this[int]`, xem dưới) |
| `List<T>._size` | 398 | **có** — `Count` |
| `object::_002Ector` | 96 | không phải member (xem `MANGLED_IDENTIFIER`) |
| `int::m_value` | 22 | không |
| `Math::PI` | 8 | **bị strip khỏi build**, không phải defect |
| `Dictionary<T>::_entries` | 7 | không |

`List<T>` chiếm **1627 của 1780** — cụm này về bản chất là một kiểu, không phải một họ.

## Ba phân loại

**1. `recovery mistake` — `_size`, 398 lỗi.** `List<T>.Count` là một property tầm thường trả về
`_size`, và phép ghép accessor (`IlGenerator.InstanceAccessorFor`) tồn tại đúng để viết
`list.Count`. Nó không khớp ở đây. `ReturnsNothingButTheField` đòi thân getter đúng bằng *một* lệnh
Move từ `[X0 + offset]` rồi Return; bất cứ thứ gì khác — null check của il2cpp, class-init guard —
làm nó trả về false. CLAUDE.md đã ghi đúng khoảng trống này ("Getters that also carry il2cpp's null
check are not matched yet"). Đây là việc của recovery và là mục tiêu tiếp theo có biên giới rõ.

**2. `framework real limitation` — `_version` và `_entries`, 807 lỗi.** `_version` là bộ đếm sửa
đổi mà enumerator dùng để ném `InvalidOperationException`. Không có API công khai nào đọc nó, ở bất
kỳ phiên bản nào của framework. Code recovered chạm vào nó vì il2cpp **inline `foreach`**, nên thân
hàm thật sự đọc field đó. Bản recovery đúng về máy và không thể biên dịch được — đây là chỗ một
compatibility surrogate là câu trả lời duy nhất, chứ không phải nới accessibility.

**3. `compatibility API requirement` — `_items`, 429 lỗi.** `_items` là mảng nền. il2cpp inline
`get_Item` thành `_items[i]` cộng một bounds check so với `_size`, và `InjectedCheckRemover` bỏ
check đó đi — nên `list._items[i]` đúng bằng `list[i]` tại mọi chỗ nó xuất hiện. Đây là một phép
ghép accessor thứ hai (indexer thay vì property), không phải một giới hạn.

`Math.PI` (8) là họ khác hẳn và đã được ghi từ trước: member bị IL2CPP strip khỏi build, nên nó là
khiếm khuyết của bộ assembly ta biên dịch *với*, không phải của bản export.

## Không làm

Không nới accessibility của member framework: assembly mà script exported được biên dịch với không
phải assembly recovered, nên nới nó chỉ che lỗi chứ không làm code đúng hơn. Không đổi public API
signature để dập CS1061.
