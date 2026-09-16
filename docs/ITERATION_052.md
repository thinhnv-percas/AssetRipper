# Iteration 052 — từ "C# đọc được" sang "project chạy được"

## 1. Baseline (§2)

Tái lập toàn bộ số liệu 051 trên cả hai fixture trước khi đổi gì, sau khi tiến trình rip thoát chứ
không theo một dòng log. Mọi con số khớp tới từng chữ số; `iterations/052/BASELINE.md` là bản ghi.
Golden corpus 165/165 có mặt, improved 0 regressed 0. Test 447 pass / 1 fail có sẵn.

## 2. §7 — tiền đề của brief sai, và phép đo nói ra chỗ sai

Brief đặt "generic parameter bị mặc định bằng kích thước con trỏ khi đối số thật là value type" làm
mục tiêu. `GenericInstanceFieldLayout` đã thay tham số bằng đối số thật và đã tính kích thước struct
người dùng định nghĩa từ lâu. Nhãn cũ che nguyên nhân thật: **"generic instance, value type argument"
đặt tên theo một thuộc tính của base type**, không phải nguyên nhân.

Hỏi chính phép tính layout thì 228 load tách làm ba:

| verdict | số | là việc gì |
|---|---|---|
| nằm trong layout, không rơi vào biên field | **173** | đọc member của một struct field |
| vượt quá layout | 35 | base không phải kiểu load tưởng — việc của suy kiểu |
| không tính được layout | 20 | một field không xác định được kích thước |

Ba phần tư họ này là hình dạng bình thường của `NestedFieldResolver`, và phép đi xuống đó **bị chặn
cho mọi generic owner**. Lý do kỹ thuật có thật — offset của field trên một generic definition đều
bằng 0 trong metadata — nên nguồn offset phải là layout đã tính. Hai khác biệt, cả hai do generic
instance: layout đã bao gồm base chain nên không đi lại, và một field khai báo `T` phải được thay thế
trước khi đi xuống.

Kiểm chứng ngữ nghĩa, `CirclePlugin.SetFrom`:

```
trước:  NoteDecompilerIssue("Unmanaged memory load: [t + 0x154]")
        if ((nint)0 == 0)                    <- guard luôn đúng, code chết
sau:    if (!t.plugOptions.initialized)      <- đúng điều kiện trong nguồn
```

Nhóm đó đi từ 161 xuống **3**.

## 3. §5 + §14 — ranh giới native được gọi tên, và code sinh ra nói ra nó

`NativeBoundary` phân loại theo bằng chứng binary mang sẵn: relocation gọi tên symbol, key function
đã định vị, số managed method ở địa chỉ, hoặc chuỗi lệnh nhận diện theo việc nó làm. Không có bằng
chứng thì `UNKNOWN` — một phán quyết, không phải thất bại.

`Il2CppRuntime` là tầng tương thích runtime, **không phải bản cài đặt lại il2cpp**: một method nhận
loại ranh giới và phần chi tiết vốn đã được báo cáo. Hình dạng code phát ra không đổi (một chuỗi
thành hai), điều này quan trọng — thay placeholder bằng lời gọi tiêu thụ toán hạng gốc đã từng đo
được là làm lệch stack ở khoảng một nghìn method.

| | Impostor | Pinata |
|---|---|---|
| `SYSTEM_API` | 490 | 1207 |
| `UNKNOWN` | 416 | 2860 |
| `IL2CPP_RUNTIME` | 339 | 237 |
| `MANAGED` | 33 | 13 |
| `EXTERNAL_DEPENDENCY` | 0 | 36 |

339 `IL2CPP_RUNTIME:AtomicCompareExchange` là chính con số 051 đo được cho vòng compare-and-swap, giờ
tới được code sinh ra.

**Kết quả âm**: bước nhảy qua veneer trong bộ phân loại không đổi một con số nào — veneer đã bị tiêu
thụ sớm hơn trong pipeline.

## 4. §15 — tham chiếu, và một check quá chặt sai ngang một check quá lỏng

`audit_project_references.py` duyệt mọi document được serialize và phân giải mọi PPtr đúng cách editor
làm. Phán quyết thứ sáu, `NULL`, quyết định phép đo có nghĩa hay không: Unity ghi `{fileID: 0}` cho
mọi ô tuỳ chọn của mọi object, và trên test game đó là 2522 trong 2526 "mất mát" biểu kiến. Tính chúng
là hỏng thì báo một project không lỗi là 32% resolve.

| | Impostor | Pinata | JellyBlast (iOS) |
|---|---|---|---|
| tham chiếu có đích | 1175 | 35928 | 89950 |
| `reference_resolution_rate` | **0.9940** | **0.9999** | **1.0000** |
| không đi theo được | 7 (6 `m_Script` + 1 `m_Texture`) | 2 (`m_Script`) | 1 |

## 5. §19 + §22 — chín stage, và stage nào thật sự chạy

`validate_unity_stages.py`. `BLOCKED` không bao giờ là PASS và cũng không phải FAIL.

| | Impostor | Pinata | JellyBlast |
|---|---|---|---|
| A project generated | PASS | PASS | PASS |
| B scripts generated | PASS 830 | PASS 3130 | PASS 1501 |
| C references consistent | FAIL 7 | FAIL 2 | FAIL 1 |
| D C# compiles | FAIL 743/830 | FAIL 2364/3115 | FAIL 1422/1473 |
| E–I | BLOCKED `UNITY_NOT_AVAILABLE` | BLOCKED | BLOCKED |
| `compile_pass_rate` | **0.8952** | **0.7589** | 0.9722 |
| `body_recovery_rate` | **0.7598** | — | **NO_BODIES** |
| `shader_dummy` | 3/3 | 22/22 | 30/30 |

`compile_pass_rate` đo theo **file**, không theo lỗi và không theo assembly: một file mang một trăm
lỗi và một trăm file mang một lỗi là cùng số lỗi và hai project khác hẳn nhau.

**Tỉ lệ biên dịch của fixture iOS cao hơn Android và không tốt hơn**: FairPlay mã hoá toàn bộ
`__TEXT`, nên 1473 file toàn khai báo dĩ nhiên biên dịch sạch. `body_recovery_rate` in ngay bên cạnh
để chặn đúng cách đọc đó.

## 6. §13 — đã có sẵn, và đo được là bằng không

Cô lập lỗi tồn tại ở cả hai mức: `ReplaceIfUnverifiable` và `FillMethodBody` chặn ở mức method trước
khi ILSpy thấy; `DecompileWholeProject` bỏ qua type mà ILSpy không đọc được rồi dịch lại, tối đa 16
type. Đo trên cả hai fixture: **0 type bị bỏ qua, 0 assembly bị bỏ dở, 0 thân hàm chuyển đổi thất
bại**. Đây là kết quả kiểm chứng, không phải việc phải làm.

## 7. §21 — kho method vàng biết method dùng để làm gì

Trục thứ ba: vai trò lúc chạy (Awake/OnEnable, Start, Update, OnDestroy, callback Unity, coroutine,
property getter, event accessor, constructor, static entry). Khớp trên dòng khai báo chứ không trên
tên. 165 → **220**, 165 cũ là tập con. Nó lập tức nói được điều tổng số không nói: `Color2Plugin` và
`QuaternionPlugin` đi từ `PARTIAL` lên `HIGH_CONFIDENCE`.

## 8. Hai cái bẫy đo mà iteration này tự tạo rồi tự dập

- Placeholder giờ tới mã nguồn theo **hai** hình dạng. Trình trích xuất chỉ đọc một, nên ba họ —
  `METHOD_NOT_FOUND`, `NATIVE_IMPORT`, `UNKNOWN_CALL_TARGET` — đọc thành số không, không phân biệt
  được với việc đã sửa xong chúng. Một định nghĩa duy nhất, dùng chung, và năm case đỏ khi hình dạng
  thứ hai ngừng được đọc.
- `golden_corpus.py` import định nghĩa đó từ chỗ nó vừa rời đi. Gãy to tiếng nên rẻ — nhưng là lần
  thứ hai trong một iteration mà một bản sao chép tay trôi khỏi bản gốc.

## 9. Số liệu

| | Impostor 051 | Impostor 052 | Pinata 051 | Pinata 052 |
|---|---|---|---|---|
| `EXACT` | 2852 | **2860** | 9634 | **9636** |
| `HIGH_CONFIDENCE` | 157 | **163** | 463 | **467** |
| `PARTIAL` | 1158 | **1142** | 3043 | **3036** |
| `FALLBACK` | 1315 | 1317 | 3233 | 3234 |
| phục hồi không kèm đồ thế chỗ | 3009 | **3023** | 10097 | **10103** |
| placeholder | 4455 | **4297** | 14166 | **14068** |
| unresolved load | 2712 | **2554** | — | — |
| Roslyn Assembly-CSharp | 344 | 344 | 1481 | 1481 |
| **field layout** | 1394 / **0** | 1394 / **0** | 3170 / **0** | 3170 / **0** |
| `generatorFailures` | 0 | 0 | 0 | 0 |
| `.cs` | 819 | 830 | 3083 | 3130 |

`.cs` tăng là kiểu `Il2CppRuntime` được tiêm vào mỗi assembly, không phải hồi quy.
Test 448 → **461**.

## 10. Không làm, có chủ ý

- Không ánh xạ `0xAF4130` sang một overload `Interlocked` cụ thể: bằng chứng chưa quyết được overload.
- Không sinh `P_INVOKE`: không gì tại call site phân biệt đích của một P/Invoke với một symbol import
  khác, và một phán quyết không chứng minh được thì tệ hơn một phán quyết vắng mặt.
- Không mở rộng framework member để dập CS1061 (`List<T>._version`): assembly mà script xuất ra được
  biên dịch dựa trên không phải assembly phục hồi, nên nới rộng ở đó là làm sai ở đầu kia.
- Không chạy Unity: `UNITY_NOT_AVAILABLE`, stage E–I `BLOCKED`.

## 11. Sáu câu hỏi của §27

**Q1 — APK/IPA đi tới stage nào?** Cả ba fixture qua A và B, dừng ở C và D. APK (Impostor, Pinata) có
thân hàm thật; IPA (JellyBlast) chỉ có khai báo vì `__TEXT` bị mã hoá.

**Q2 — C# sinh ra biên dịch được bao nhiêu?** 743/830 file (0.8952) trên Impostor, 2364/3115 (0.7589)
trên Pinata, 1422/1473 (0.9722) trên JellyBlast nhưng trên khai báo.

**Q3 — Bao nhiêu tham chiếu resolve?** 0.9940 / 0.9999 / 1.0000. Hỏng: 6 `m_Script` + 1 `m_Texture`,
2 `m_Script`, 1.

**Q4 — Bao nhiêu ranh giới runtime được biểu diễn semantic?** Impostor 862 trong 1278 được gọi tên
(490 SYSTEM_API + 339 IL2CPP_RUNTIME + 33 MANAGED), 416 UNKNOWN. Pinata 1493 trong 4353.

**Q5 — Unity chạy fixture nào?** Không cái nào. `UNITY_NOT_AVAILABLE`, và không có stage nào được ghi
PASS vì lý do đó.

**Q6 — Nút thắt lớn nhất tiếp theo?** `UNKNOWN` trong phân loại ranh giới — 416 và 2860 lời gọi tới
các hàm runtime không được export, không có managed method, không phải key function. 051 đã xác lập
27 trong 30 địa chỉ không gọi tên được từ call site, nên bước tiếp theo phải đọc mã máy của chúng
theo cách `AtomicIntrinsicRecognizer` đọc compare-and-swap. Sau đó là `UNMANAGED_MEMORY_LOAD` (2515)
và shader: 0/3, 0/22, 0/30 exact.

## 12. Trạng thái

**`RECOVERY_VALIDATED_STATICALLY`.** Project chưa biên dịch sạch nên chưa tới
`PROJECT_COMPILES_NOT_RUNTIME_VALIDATED`; Unity không có mặt nên không stage runtime nào chạy.
