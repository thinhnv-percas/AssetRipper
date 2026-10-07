# Độ rộng thanh ghi của immediate — iteration 068 (§4)

Nhãn: **PROVEN**, **MEASURED**.

## 1. Regression của 067 — PROVEN

Pinata, `FBSDKViewHiearchy.CheckPathMatchPath` (RVA `0xD2C61C`). Machine code: `mov w?, #-1`, rồi `cmn` với một số đếm, rồi
`b.hs`. 067 làm carry của ADDS chính xác (`(a + b) <u a`). Nhưng:

- Disarm trả `mov w8, #-1` về immediate `0xFFFFFFFF`, giá trị dương.
- `Immediate` của ISIL không mang độ rộng, nên generator chọn kiểu theo độ lớn: 4294967295 không vừa `int`, thành `ldc.i8`,
  local thành `long`.
- Phép cộng và so sánh unsigned do đó chạy ở 64 bit: `4294967295 + count` không bao giờ nhỏ hơn `4294967295`, cờ C không
  bật, và vòng lặp ném `ArgumentOutOfRangeException` ngay lần đầu.

Ở 066, phép so sánh *có dấu* với một toán hạng `int` đã gieo kiểu `int` cho counter, nên đúng một cách tình cờ.

## 2. Sửa — luật tổng quát, không phải ca riêng của -1

`NewArmV8InstructionSet.ImmediateAtWidth(value, is64)`: một immediate trên đường dữ liệu 32 bit là `int` mang đúng các bit
đó (mở rộng dấu từ 32 bit). Đường dữ liệu đọc từ toán hạng thanh ghi đầu tiên của lệnh: thanh ghi W là 32 bit, mọi thứ
khác giữ nguyên. Với lệnh store, toán hạng đầu là giá trị được ghi; với compare, là giá trị đầu được so sánh. Luật áp ở
một chỗ, `LiftImmediate`, mà `ConvertOperand` và `MOVK` cùng gọi.

`MaskImmediate` đã áp đúng luật này cho mask của BFI/BFXIL từ 048. 068 mở rộng nó cho mọi immediate.

Hệ quả ở generator: bit của một `float` có bit dấu bật (`-0.5f` = `0xBF000000`) giờ đến dưới dạng số âm. Nhánh "immediate
là bit của float" nhận cả khoảng `int` âm cho `Single`: cùng 32 bit, chỉ khác cách viết.

## 3. Test (`Il2CppIteration068Tests`, 22 case)

Test giải mã word lệnh A64 thật bằng Disarm, rồi chạy chúng qua đúng `LiftImmediate`:

| Lệnh | Immediate lift ra |
|---|---|
| `mov w8, #-1` | `-1` |
| `mov x8, #-1` | `-1` |
| `mov w8, #0x80000000` | `int.MinValue` |
| `mov x8, #0x80000000` | `2147483648` |
| `and w8, w8, #0xff000000` | `-16777216` |
| `cmn w8, #1` / `cmn x8, #1` | `1` |
| `adds w0, w1, #1` / `adds x0, x1, #1` | `1` |
| `subs w0, w1, #1` / `subs x0, x1, #1` | `1` |

Hai test còn lại đặt lỗi cạnh luật:
- **Carry của `-1 + n` là 32 bit.** Lấy immediate đã lift, tính độ rộng IL từ kiểu nó cho, chạy chuỗi cờ của
  `Arm64FlagLifting.Add` ở độ rộng đó, rồi so với `AddWithCarry` 32 bit của Arm ARM, với n = 0, 1, 5, 0x7FFFFFFF.
- **Biểu diễn cũ cho carry sai.** Kiểm tra lại phép đo: `0xFFFFFFFF` giữ dạng long thì phép tính chạy 64 bit và carry khác
  máy.

Bỏ luật: 8 trong 22 case đỏ.

Regression ở fixture: `check_recovered_shapes.sh` có `DECOMP-0073` (chỉ chạy khi file có trong rip). Nó PASS trên 68a và
FAIL trên 67x.

## 4. Đo (67x → 68a, chỉ thay đổi này)

| | EXACT | Lỗi thân | Golden mới |
|---|---|---|---|
| Impostor | 4449 → 4450 | 194 → 194 | 0 |
| Merge-Room | 11954 → 11968 | 298 → 298 | 0 |
| RunFromZombies | 2934 → 2938 | 7 → 7 | 0 |
| JellyBlastV2 | 5258 → 5262 | 1982 → 1982 | 0 |
| Pinata | 12971 → 12975 | 1136 → 1136 | — |

- RunFromZombies behaviour: 1.0000 (35/35).
- Pinata: 200 file đổi nội dung.

Hình dạng thay đổi phổ biến nhất:

```csharp
// 67x
object obj = 4294967295L;
if ((IntPtr)obj != (IntPtr)(-1))

// 68a
int num = -1;
if (num != -1)
```

Dạng 67x là một **lỗi im lặng khác có từ trước**. `(IntPtr)4294967295 != (IntPtr)(-1)` luôn đúng ở 64 bit, nên mọi điều
kiện "counter khác -1" luôn đúng.

## 5. Giới hạn — INFERRED

Một giá trị ghi vào thanh ghi W rồi đọc bằng thanh ghi X (64 bit) thì phần cứng mở rộng **zero**, không mở rộng dấu.
ISIL đặt tên W và X cùng một thanh ghi, nên không phân biệt được hai cách đọc. Luật chọn ngữ nghĩa 32 bit vì đó là cách
il2cpp dùng thanh ghi W cho giá trị `int`. Một hằng âm 32 bit dùng làm chỉ số 64 bit sau `uxtw` sẽ bị đọc sai. Chưa đo
được ca nào như vậy.
