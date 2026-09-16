# Iteration 053 — source oracle, và các phép đo biết từ chối

## 1. Ma trận fixture đổi, và Pinata rời đi (§1)

Ba fixture: Impostor (Android, chính), RunFromZombies (Android, **có toàn bộ source**), Jelly Blast
v2 (iOS). Pinata không còn trong ma trận mặc định và lệnh test mặc định không rip nó;
`docs/RECOVERY_MATRIX.md` ghi lý do và số liệu cuối cùng của nó. Cùng lúc gỡ 290 MB output rip bị
commit nhầm ở iteration 052 — quy tắc `.gitignore` thêm trong chính commit đó không có tác dụng lên
file đã được track.

## 2. Source oracle (§3)

`Test/Scripts/source_oracle.py` so từng method của bản recovery với chính văn bản lập trình viên
viết. So theo **ngữ nghĩa**, không theo chuỗi: decompiler có quyền viết `for` thành `while`, gộp một
phép so sánh vào `if`, bỏ một cast mà hệ kiểu không còn cần, và đổi tên mọi biến cục bộ — so bằng
string equality thì mọi method đều sai.

Oracle tự báo sai **bốn lần** trước khi tin được, cả bốn đều vì quá nghiêm: `new T(...)` của value
type quay về thành `default(T)`; comment bị tính vào fingerprint; `GetComponent<T>()` không khớp mẫu
gọi hàm; regex thành viên không chồng lấn nên `a.b.c` chỉ ra một cặp. 0,7778 → **1,0000** (36/36).

`source_manifest.py` là nửa còn lại: oracle chỉ nói được về method nó tìm thấy ở **cả hai** bên, nên
nó im lặng về mọi thứ recovery không hề sinh ra. Manifest liệt kê source, phân giải mỗi file về
assembly Unity biên dịch nó vào, và với mỗi kiểu nói rõ bản rip có hay không — kèm lý do khi không:
EDITOR_ONLY, ASSEMBLY_ABSENT, CONDITIONAL (ghi lại chính điều kiện tiền xử lý). Impostor 425/425,
RunFromZombies 16/16, `NOT_IN_BUILD` bằng **0** trên cả hai.

So theo *kiểu* chứ không theo file, vì exporter viết một kiểu một file: ghép theo tên file sẽ bịa ra
ba mất mát cho mỗi file source bốn kiểu.

## 3. Bỏ khai báo event mà thân hàm đọc xuyên qua (§4)

C# cấm *đọc* một event ngoài accessor của chính nó (CS0079), bất kể mức truy cập. il2cpp thì inline
fast path, nên thân hàm recovered đọc thẳng ô lưu trữ. 433 event trên Impostor. Cách sửa là bỏ khai
báo event và để lại ba thứ metadata vốn có — một field và hai method.

Phép sửa tự báo sai **hai lần**, cả hai đều là "một pass không bao giờ chạy trông y hệt một pass
không tìm thấy gì": ghép theo tên thất bại (`m_OnAdOpening`), rồi ghi nhận bên trong `WidenField`
thất bại vì widening dừng lại ở truy cập cùng kiểu. Ghép **qua chính accessor** và ghi nhận **trước**
quyết định widening, loại trừ accessor của chính event đó: 2 → 136.

Rồi nó kéo theo hai regression phải sửa trước khi giữ: 532 CS0246 `SpecialNameAttribute` (phải xoá
cờ `SpecialName|RuntimeSpecialName`) và 122 CS0470 (phải bỏ qua event hiện thực interface). Kết quả
trên Impostor: 83 event bị bỏ, lỗi Roslyn **1386 → 484**.

Và nó dọn một thứ không ai nhắm tới: **lỗi khai báo CS0102**. Xem mục 7.

## 4. Ranh giới runtime UNKNOWN (§8)

`cluster_runtime_boundaries.py` gom các call UNKNOWN của Impostor theo hình dạng machine code tại
đích: **17 địa chỉ, 17 hình dạng khác nhau**. Không phải một họ — 17 hàm runtime riêng biệt, nên
không có luật chung nào đặt tên được cho chúng, và brief cấm map cả cluster chỉ vì tên caller.

Cái nói được mà không cần tên: một địa chỉ nằm ngoài khoảng của **mọi** method managed thì không thể
là managed code. Luật đọc min/max của `MethodsByAddress`, không ghi địa chỉ nào xuống, và chạy
**cuối cùng** nên không đè lên bằng chứng có tên. Impostor UNKNOWN **416 → 112**, và 112 cái còn lại
không mang địa chỉ nào cả.

## 5. Golden corpus có fixture (§13)

Một entry trước đây là một đường dẫn kèm địa chỉ, và cả hai đều không duy nhất giữa các fixture: 16
trong 220 entry không phân giải được ở bản rip nào — di sản từ thời Pinata — và corpus báo chúng là
"not present" mà không nói nổi chúng thuộc game nào.

Entry giờ là bản ghi: `method`, `fixture`, `runtime_role`, `semantic_fingerprint`, `status`,
`source_available`. Entry không phân giải được ở fixture nào chuyển sang `retired` kèm lý do, không
xoá. **591 entry** — Impostor 213, JellyBlastV2 190, RunFromZombies 188 — cộng 16 retired.

Kiểm chứng rằng check thật sự phân biệt được: sửa một entry baseline từ PARTIAL thành EXACT thì nó
báo REGRESSED và thoát 1.

## 6. Shader oracle, và một defect thật (§14)

`shader_oracle.py` so ShaderLab gốc với shader đã export. DUMMY được xét **trước** mọi mức độ thành
công: `DummyShaderTextExporter` dựng lại `Properties` rồi cho mọi shader cùng một pass unlit, nên
material không hồng và mọi phép kiểm tra "có hồng không" đều báo thành công.

Oracle tìm ra một defect: `SerializedPropertyType.Color` bị ghi thành `Vector`. Hai kiểu này phân
biệt được trong shader đã serialize **và** trong ShaderLab — Color có color picker và được chuyển
khỏi gamma space khi gán. Kiểu đó có trong metadata và bị vứt đi. Sửa tại chỗ biến đổi sai sớm nhất,
tức chính exporter: `property_recovery_rate` **0,5111 → 1,0000**.

Cả ba shader của Impostor và cả 24 của RunFromZombies vẫn **DUMMY**. `shader_exact` bằng 0.

## 7. Con số Jelly Blast tăng vọt, và đó là bẫy lỗi-khai-báo lần thứ hai

Sau phép sửa event, lỗi Roslyn của Jelly Blast đi từ 1938 lên **8638**, file sạch từ 1402 xuống
1306. Đọc như regression tệ nhất trong lịch sử dự án. Nó không phải:

```
bản cũ, RayFireAssembly:  3 lỗi, 119/120 file "sạch"
  RFEvent.cs(37,28): error CS0102: The type 'RFEvent' already contains a definition for 'LocalEvent'
```

Một event và một field trùng tên là **lỗi khai báo**. Roslyn bind khai báo trước và dừng lại ở đó,
nên 3 lỗi ấy che toàn bộ lỗi thân hàm của cả assembly. Phép sửa event bỏ khai báo event trùng, nên
lần đầu tiên assembly ấy bind được và 8000 lỗi vốn đã luôn ở đó mới hiện ra. `PathCreator` y hệt
(`BezierPath.OnModified`, `PathCreatorData.bezierOrVertexPathModified`).

Con số "trước" đúng của Jelly Blast không phải 1938; không có con số trước, vì phép đo cũ chưa từng
chạy tới thân hàm. Đây là lần thứ hai CLAUDE.md phải ghi đúng bài học này, và lần này nó đến từ một
phép sửa không hề nhắm vào nó.

## 8. Ba phép đo học cách từ chối

- `validate_unity_stages.py` trỏ vào thư mục output thay vì thư mục game vẫn chạy hết tám stage và
  vẫn in số — toàn bộ đo trên cây sai. Giờ là `PROJECT_ROOT_MISMATCH`, thoát 2, không stage nào dưới
  A chạy. Một con số tính trên cây sai tệ hơn là không có con số nào.
- `golden_corpus.py` khớp 0 entry vẫn in `improved 0, regressed 0`. Giờ là `CORPUS_NOT_APPLICABLE`.
- `recovery_metrics.py` và `placeholder_families.py` từ chối một bản rip đang được ghi dở.

## 9. Runtime equivalence (§16)

Mọi phép đo khác trong dự án này đọc văn bản; một thân hàm chạm đúng mọi lớp phép toán của nguồn vẫn
có thể sai dấu. `runtime_equivalence.py` xếp mỗi method đã ghép đôi vào ba tầng theo bằng chứng
trong hai thân hàm, và `Test/Tools/RuntimeEquivalence` nạp assembly, gọi cả hai bên, so kết quả.

Runner được chứng minh phân biệt được trên hai assembly tổng hợp: EQUIVALENT cho `x*2` so `x+x`,
DIFFERENT cho `x+1` so `x+2` kèm từng vector sai, METHOD_NOT_FOUND cho method không có.

Impostor: 1814 method ghép đôi, 141 chạy được nếu có oracle assembly. RunFromZombies: 36 ghép đôi,
**0** chạy được — mọi method đều chạm engine. Chưa có oracle assembly, nên cả hai là `NOT_RUN`
kèm lý do. Tỉ lệ trên không case nào là `None`, không bao giờ là pass.

## 10. Trạng thái

**`PROJECT_COMPILES_NOT_RUNTIME_VALIDATED`.** Unity không có trong container này, nên stage E đến I
là `BLOCKED` trên cả ba fixture và không một khẳng định runtime nào được phép dựa vào chúng.
