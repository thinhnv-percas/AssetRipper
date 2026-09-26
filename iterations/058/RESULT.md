# Iteration 058 — kết quả

Bản rip: `Test/Out58H-{z,i,m,j}`. Baseline: `Test/Out57H-*` (bản cuối của 057, tại commit
`a1194887`).

| | RunFromZombies | Impostor | Merge-Room | JellyBlast v2 |
|---|---:|---:|---:|---:|
| EXACT (baseline → sau) | 2513 → 2513 | 3782 → 3782 | 7671 → 8170 | 2867 → 2867 |
| FALLBACK | 150 | 346 | 450 | 44 |
| placeholder | 5962 | 4293 | 39.533 | 38.236 |
| hợp đồng hành vi | 4615 | 5963 | 17.913 | 8983 |
| điều kiện nhánh truy được về nơi sinh | 8536/10.448 | 8754/10.660 | 30.534/37.664 | 24.924/35.028 |
| behaviour_equivalence_rate | **1,0000** (35/35) | — | 0,6951 | — |
| khối GLSL thật viết ra (trước → sau) | 0 → **43** | 0 → **3** | 0 → **50** | 0 → 0 |
| shader SEMANTICALLY_EQUIVALENT | **9**/24 | **2**/3 | **2**/7 | 0 |
| `shader_exact` | 0 | 0 | 0 | 0 |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| field layout disagreement | 0 / 2165 | 0 / 1394 | 0 / 3947 | 0 / 2654 |
| golden corpus 057 → 058 | 0 / 0 | 0 / 0 | 0 / 0 | 0 / 0 |

Một lỗi logic thật tìm ra và sửa: lấy địa chỉ của một *tham số* ra `ldloca` của một local generator
tự bịa, nên `ObscuredBool.op_Implicit` trả về giải mã của số không và `TimeInGame` lấy ngày tháng từ
`default(DateTime)`. Trên Impostor: 16 file đổi nội dung, **mọi con số tổng y nguyên**.

Test: 493 ca, 492 pass, một fail có sẵn. Shape checks sạch, gồm DECOMP-0021 mới (đỏ trên bản rip
trước khi sửa).

Unity không có: stage E–I `BLOCKED`, `runtime_status: NOT_RUN`.

Phép đo tự báo mình sai trong iteration này, tất cả đã sửa trước khi tin: bốn ở phía shader (trạng
thái nhiều lệnh trên một dòng, trạng thái đọc lọt vào khối chương trình, mặc định ShaderLab, trạng
thái do property điều khiển), năm ở phía oracle hành vi (`++` là ghi, ghi property khớp setter, chữ
trong string literal, tên method một dòng nằm trong thân nó, `async`), một ở `validate_unity_stages`
(neo "exact" vào sự vắng mặt của một chuỗi), và ba ở probe shader (`m_PlayerSubPrograms`, tìm marker
trong đoạn dài nhất, text chạy tới cuối sub-program).
