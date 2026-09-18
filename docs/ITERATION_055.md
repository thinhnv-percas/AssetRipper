# Iteration 055 — ba tiền đề sai, một khiếm khuyết thật

## 1. Baseline (§2)

Bốn bản rip cuối của 054 (`Test/Out54i3`, `Out54z4`, `Out54j2`, `Out54m3`) được tạo bằng đúng build
tại HEAD và cây git sạch, nên chúng là baseline. Build Release lại và chạy test trước khi đổi gì:
471/472 pass, một fail có sẵn từ trước.

## 2. Cụm `FRAMEWORK_PRIVATE_MEMBER`: đo theo call site thì cả ba tiền đề sai (§3, §4, §5)

Brief §3, §4, §5 và iteration 054 đều phân loại cụm này theo **tên member**. Đọc chính dòng nguồn mà
Roslyn chỉ tới, 1627 lỗi trên JellyBlastV2 là đúng bốn hình dạng, không một ngoại lệ:

| số | member | hình dạng |
|---|---|---|
| 429 | `_items` | `string[] items = list._items;` |
| 408 | `_version` | `int version = list._version + 1;` |
| 398 | `_size` | `list._size = size;` |
| 392 | `_version` | `list._version = version;` |

**Không có một lệnh đọc `_size` nào, và không có một lệnh đọc phần tử `_items[i]` nào.**

**§3 sai.** Một probe ghi lại quyết định của `InstanceAccessorFor` cho từng field: `List<T>._size`
**ghép thành công mọi lần**, nên mọi lệnh đọc `_size` đã là `list.Count` từ trước.
`ReturnsNothingButTheField` không quá nghiêm — trên RunFromZombies chỉ **16** getter đọc đúng offset
của field mình mà bị từ chối, không cái nào là `_size`. 398 lỗi là lệnh *ghi*, mà `Count` không có
setter.

**§4 sai.** Cả 429 site đọc *toàn bộ* mảng nền vào một local. `this[int]` không diễn đạt được
`string[] items = list._items;`, nên phép ghép indexer sẽ khớp **0** site.

**Và cả bốn hình dạng là một method**: `List<T>.Add` bị inline. Nhánh chậm của chính nó **tự gọi tên
`List<T>.Add`** — bằng chứng đối chiếu có ngay tại chỗ khớp.

## 3. Earliest wrong transformation: lệnh ghi phần tử

```
num4 = Count << 3
obj4 = (nint)items + num4
obj5 = (nint)obj4 + 32
obj5 = value            <- lệnh ghi mất hẳn, ghi vào một local
```

`ComputedElementAddress` không khớp vì elements offset cộng ở **một lệnh riêng** thay vì làm addend
của memory operand. Một phép tháo đưa nó về chỗ addend lẽ ra mang nó, và mọi luật bên dưới áp dụng
nguyên vẹn.

**Thứ tự là toàn bộ thiết kế.** `t = array + elementsOffset` — luật elements-offset-ahead vốn đã
chạy — cũng khớp phép tháo, và tháo nó ra thì đệ quy về chính cái mảng và không trả lời gì: một
method của golden corpus mất cả `ARRAY_READ` lẫn `ARRAY_WRITE` đúng vì thế. Thử phân biệt bằng *kiểu*
của local bên trong, hoặc bằng opcode định nghĩa nó, đều quá mạnh theo cả hai chiều — một địa chỉ
phần tử đã tính thường được gán kiểu chính mảng đó, và thường tới qua một bản copy. Nên các luật gọi
tên mảng trực tiếp chạy trước, và phép tháo là thứ còn lại khi chúng không trả lời gì.

Kết quả:

- JellyBlastV2: **lệnh ghi phần tử phục hồi 676 → 903** (+227). `obj5 = obj2` thành
  `items[count] = (string)obj2`.
- RunFromZombies: `DefaultJsonNameTable` đi từ `entry.Next = (Entry)next` (gán *địa chỉ*) và
  `next = entry` (ghi vào hư không) thành `entry.Next = array[num8]` và `array[num8] = entry`, mất
  luôn hai stack type mismatch.

Chừng nào lệnh ghi còn chưa phục hồi được thì nhận diện cả vùng thành `list.Add(item)` chỉ sinh ra
`list.Add(<giá trị đã mất>)`. Sửa lệnh ghi trước; nhận diện vùng sau.

## 4. `NATIVE_INT_CAST` theo producer (§7)

`Cannot convert type 'X' to 'nint'` là cùng một thông điệp cho bốn nguyên nhân cần bốn loại công
việc. JellyBlastV2, 17.313 cast: `OBJECT_REFERENCE` 9558 (55%), `POINTER` 2756, `FIELD_ADDRESS` 2079,
`UNKNOWN` 1746, `ARRAY` 825, `INTEGER` 285, `HANDLE` 64.

Cụm `ARRAY` là chỗ `NATIVE_INT_CAST` gặp `FRAMEWORK_PRIVATE_MEMBER` — **một** khiếm khuyết, đã sửa.
`OBJECT_REFERENCE` là cụm duy nhất đã có kết quả âm ghi lại và phải sửa từ phía nguồn.
`FIELD_ADDRESS` phần lớn là đối số write barrier, mà `il2cpp_codegen_write_barrier` vẫn chưa định vị
được — đó là đòn tiếp theo có giá trị nhất, và là công việc key-function discovery.

## 5. Đồ thị phụ thuộc native (§8, §9)

Kết luận "0 native plugin là blocker" của 054 **sai với một nửa ma trận**. Phân năm loại, bốn trong
năm **không được** đi vào project (il2cpp runtime, Unity player, Burst output, thư viện hệ thống):

| | thư viện | game plugin | preserved |
|---|---|---|---|
| Impostor | 6 | **0** | — |
| RunFromZombies | 6 | **0** | — |
| Merge-Room | 10 | 2 (`liblofelt_sdk.so`, hai ABI) | **2 / 2** |
| JellyBlast v2 | 25 | 6 (Facebook SDK) | 0 / 6 |

`NativePluginPostExporter` copy đúng loại `GAME_NATIVE_PLUGIN` vào `Assets/Plugins/Android/<ABI>/`.
`.framework` của iOS chưa preserve — Unity nhập nó khác một `.so` và copy sai layout tệ hơn không
copy — ghi **MISSING** chứ không bỏ qua. Không sinh `[DllImport]` nào (§10).

## 6. Không làm, có chủ ý

**§6 assembly hỗ trợ dùng chung.** Iteration 054 đã thử `NotPublic` và hoàn tác: ILSpy viết attribute
internal ra dạng đủ tên nên `[Address(` không còn khớp và `recovery_metrics.py` đọc một bản rip bình
thường thành `NO_BODIES`. Một assembly `Recovered.Runtime` riêng là kiến trúc đúng, nhưng nó đổi hình
dạng mà **mọi** phép đo trong dự án neo vào, nên phải đi cùng một lượt dạy lại tất cả các phép đo
*và* đo lại cả hai đầu của mọi so sánh. Đó là một iteration có baseline riêng.
`reports/INJECTED_TYPE_COLLISION.md` giữ nguyên là bản ghi.

**§5 `Recovered.FrameworkCompat` cho `_version`.** Không có chỗ đặt: nó phải sống trong assembly dùng
chung của §6. Và sau khi đo lại, `_version` không phải một họ riêng mà là hai trong bốn hình dạng của
cùng một `List<T>.Add` bị inline.

## 7. Phát hiện phụ: Merge-Room không tất định

Bốn bản rip Merge-Room cho **15.276 / 15.273 / 15.246 / 15.224** method có địa chỉ native — chênh tới
52 (0,3%) giữa các lần chạy trên cùng một build. Impostor cho đúng 5482 ba lần. Nên trên Merge-Room,
một chênh lệch dưới ~50 method là nhiễu, không phải regression; ba fixture kia thì ổn định.

## 8. Trạng thái

**`PROJECT_COMPILES_NOT_RUNTIME_VALIDATED`.** Unity không có trong container, stage E–I là `BLOCKED`
trên cả bốn fixture.
