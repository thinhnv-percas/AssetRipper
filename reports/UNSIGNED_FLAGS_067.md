# Cờ C/V của A64 và so sánh unsigned — iteration 067 (§10)

Nhãn: **PROVEN**, **MEASURED**.

## 1. Lỗi — PROVEN

Ba chỗ sai, cả ba trong cùng một chuỗi lift cờ:

1. **C sau phép trừ được phát là so sánh *signed*.** Arm ARM: SUBS/CMP là `x + NOT(y) + 1`, C là carry out, tức
   "không mượn" — `a >=u b`. Lifter ghi `C = !(a < b)` với `clt` signed. Hệ quả: `(uint)(c - '0') < 10` nhận `':'`
   (vì `0 < -10` signed là sai); mọi bounds check `(uint)i >= (uint)len` nhận chỉ số âm.
2. **ADDS/CMN được lift thành `a - (-b)` (iteration 066).** Chính xác cho C chỉ khi `b != 0` (cộng 0 không bao giờ
   carry, trừ 0 không bao giờ mượn), và cho V chỉ khi `-b` không tràn. `0x80000000 + 0x80000000`: kết quả 0, C = 1,
   V = 1; dạng `a - (-b)` cho V = 0 vì `-0x80000000 == 0x80000000`.
3. **CCMN** phủ định toán hạng rồi so sánh — cùng lỗi 2.

## 2. Sửa

- `Instruction.IsUnsigned`: một cờ, không phải opcode mới. 19 chỗ khớp phép so sánh theo `OpCode.CheckLess`
  (bounds check, type check, guard, `InlineListAdd`, write barrier, gán kiểu bool) vẫn khớp nguyên.
- Generator: `IlGenerator.ComparisonOpCodes` phát `clt.un`/`cgt.un` cho phép so sánh unsigned trên số nguyên. Trên
  float thì không: ở đó `.un` nghĩa là "hoặc unordered", không phải điều cờ nói.
- `Arm64FlagLifting` (mới) giữ ba chuỗi một lần:
  - `Subtract`: C = `!(a <u b)`; N, Z từ `a - b`; V = `((a^b) & (a^r)) < 0`.
  - `Add`: C = `(a + b) <u a`; V = `((a^r) & (b^r)) < 0`. Với immediate dương ≤ `0xFFF000` (dải mã hoá được của
    ADDS) thì giữ `a - (-b)`, vì ở đó nó chính xác và đọc giống nguồn (`(uint)x < (uint)-10`).
  - `Condition`: bảng `ConditionHolds` của Arm ARM. Mười bốn điều kiện đều đã đúng; giờ được kiểm.
- `FlagConditionRecovery` (pass x86) không đọc carry unsigned như cờ dấu, và xoá cờ khi viết lại thành quan hệ
  signed của chính nó.

## 3. Test — đánh giá ISIL lifter phát ra, không đánh giá một hàm phụ

`Il2CppIteration067Tests` chạy một bộ thông dịch nhỏ trên đúng chuỗi ISIL mà `Arm64FlagLifting` phát ra, ở độ rộng
32 và 64 bit, rồi so với `AddWithCarry` của Arm ARM viết lại bằng `BigInteger`, cho cả 4 cờ và 14 điều kiện:

- ADDS 32 bit: `0xFFFFFFFF+1`, `0xFFFFFFFF+0xFFFFFFFF`, `0x7FFFFFFF+1`, `0x80000000+0x80000000`, `0+0`, `5+0`, …
- ADDS 64 bit: các vector tương ứng.
- SUBS 32 và 64 bit: `0-1`, `0x80000000-1`, `0x7FFFFFFF-0xFFFFFFFF`, `0-0x80000000`, …
- Immediate nhỏ, mọi toán hạng đầu × `{1, 10, 0xFFF, 0xFFF000}`.
- Phép thử chữ số `cmn w12, #0xa; b.lo` nhận `0`–`9`, từ chối `:`, `/`, `A`.

Kiểm tra phân biệt:
- Bỏ `IsUnsigned` khỏi carry: 11 test đỏ.
- Cho immediate 0 đi đường `a - (-b)`: 1 test đỏ (`AddingZeroNeverCarries`).

## 4. Trên output — MEASURED

RunFromZombies 66i → 67a: 47 file khác, toàn bộ là phép so sánh unsigned hiện ra, ví dụ `bool flag = num < 39;` →
`bool flag = (uint)num < 39u;`. Đó là kiểm tra khoảng của switch mà compiler viết `(uint)(x - lo) < n`.
Kết quả RunFromZombies:
- EXACT, placeholder, lỗi thân Roslyn: không đổi.
- Behaviour oracle 1.0000 (35/35).

Hình dạng `(nuint)num >= (nuint)0u` (luôn đúng) xuất hiện ở bốn file Newtonsoft. Đó là kiểm tra độ sâu phân cấp
lớp của cast, trên hai load không giải được mà stand-in đều là 0. 66i cũng luôn đúng (`num >= 0` signed), nên không
có thay đổi ngữ nghĩa.

## 5. Giới hạn

- `FlagConditionRecovery` (x86) vẫn hạ điều kiện unsigned qua hình dạng signed. Đó là xấp xỉ có ghi chú trong chính
  pass, không thuộc A64.
- Generator không chèn chuyển độ rộng cho phép so sánh. Một toán hạng 32 bit nằm trong local 64 bit được so sánh ở
  64 bit, đúng khi giá trị đã được mở rộng dấu nhất quán ở cả hai phía. Đây là giới hạn có từ trước, không mới.
