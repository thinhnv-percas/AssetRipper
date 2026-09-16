# Trạng thái agent

Đọc file này trước tiên sau khi khởi động lại, rồi `reports/regression-matrix.md` cho số liệu và
`reports/issues.json` cho các hạng mục còn mở. Từ iteration 027 trở đi, toàn bộ tài liệu và ghi chú
phân tích viết bằng tiếng Việt; tên class, method, symbol, error code giữ nguyên tiếng Anh.

```
Iteration hiện tại: 047 (hoàn tất; bằng chứng cho hai họ runtime + phép đo theo từng method,
                          không đổi một byte nào của bản rip. Ship: cột consumer, gọi tên bitfield
                          theo bit, method_recovery_report.py, ITERATION_047)

Commit decompiler:
  claude/read-current-repository-daqxc1 @ (xem iterations/034/source-commit.txt), base 69a31182

Fixture — chạy Test/Scripts/download_test_inputs.sh all để tải và verify, không phụ thuộc máy:

  ANDROID (TRẠNG THÁI: OK)
    Impostor-Sort-Puzzle-Pro v1, impostor-sort.apk
    sha256 8e5ab4a9fa42d5f25a1933cd9f931624ee95589add77b7f6381c447dd9fc8aaf
    Test/Input/Impostor, ELF libil2cpp.so arm64-v8a, metadata v31.1, Unity 2022.3.62f2
    Nguồn đối chiếu: thinhabc01/Impostor-Sort-Puzzle-Pro @ a5b7962 (tag v1),
    giải nén tại artifacts/reference/Impostor-Sort-Puzzle-Pro. Spine vendored nên spine-unity
    cũng đối chiếu được.

  ANDROID thứ hai (TRẠNG THÁI: OK) — cổng kiểm chứng độc lập BẮT BUỘC
    Test/Input/Pinata (đã commit trong repo), x86, metadata v24.2.
    Khác cả kiến trúc lẫn metadata version so với Impostor, nên nó bắt được phần lớn loại lỗi
    "đúng cho một codegen, sai cho codegen kia".

  iOS (TRẠNG THÁI: FIXTURE_ENCRYPTED)
    Jelly Blast 1.1, Jelly.Blast.1.1.ipa, 69.828.168 byte
    sha256 4992cab50741c789c566b1456d6774073dba40578e12fd79113d22b410e94c48
    Test/Input/JellyBlast, bundle io.heseri.blast, Unity 2022.3.53f1, metadata v31.1, arm64
    il2cpp: Payload/JellyBlast.app/Frameworks/UnityFramework.framework/UnityFramework
    metadata: Payload/JellyBlast.app/Data/Managed/Metadata/global-metadata.dat
    UnityFramework mang LC_ENCRYPTION_INFO_64 cryptid 1, phủ toàn bộ __TEXT.
    KHÔNG có LC_DYLD_CHAINED_FIXUPS — binary dùng LC_DYLD_INFO_ONLY, nên ApplyChainedFixups không
    bao giờ chạy trên fixture này. __TEXT ở vm 0 và trong __DATA thì VA == file offset.
    Ranh giới thật, đo từng con trỏ (reports/IOS_TYPE_DEFINITIONS_SIZES_ANALYSIS.md mục 3–4):
    metadata, CẢ HAI registration, bảng codegen module và bảng types nằm trong __DATA và ĐỌC ĐƯỢC.
    genericMethodTable và methodSpecs nằm trong __TEXT.__const mã hoá.
    QUAN TRỌNG — iteration 034 ghi ở đây rằng "fieldOffsets, typeDefinitionsSizes ... ĐỌC ĐƯỢC", và
    điều đó chỉ đúng với BẢNG chứ không đúng với ĐÍCH. Hai bảng đó nằm trong __DATA.__data và đọc
    hoàn hảo (8702 con trỏ tăng đơn điệu, bước đúng 0x10, không có null), nhưng mọi con trỏ trong
    chúng trỏ vào __TEXT.__const — entropy 7,999/8 so với 3,2–4,2 ở __DATA. Đó là nguồn của
    InstanceSize=2249170484, và là lý do 5782/5782 field offset table cũng không đọc được.
    Iteration 033 kết luận "codereg không thể tìm được" — SAI, đã sửa ở DECOMP-0023.

Giai đoạn hiện tại:
  rảnh giữa hai iteration. Baseline cho iteration sau là 044b (Impostor); giống 043a tới từng chữ số.

Iteration 044 — bốn thứ phải biết trước khi làm tiếp:

  1. **Luật về khung toạ độ đã có hình dạng, nhưng mẫu bị lệch.** `BasePointerOrigin` cho bảng chéo
     tách sạch: STATIC_FIELD -> VALUE_RELATIVE 43/43, và THIS/PARAMETER/CALL_RESULT/INSTANCE_FIELD
     -> OBJECT_RELATIVE 25/25, không ngoại lệ. NHƯNG dump chỉ ghi load *không phân giải được*, nên
     đó là mẫu của phần thất bại. Phải đo trên cả load đã phân giải trước khi dùng luật này.

  2. **Shader `Dummy` không rỗng và biên dịch được.** Nó phục hồi đúng Properties rồi gắn cùng một
     pass unlit cho MỌI shader. Material không hồng, nên mọi validation kiểu "có hồng không" báo
     PASS trong khi shading sai. `--shader-mode Yaml` giữ được subprogram và blob.

  3. **`ShaderExportMode.Decompile` không tồn tại trong cây này** — nó rơi xuống Dummy; decompiler
     là feature Premium upstream. Và fixture Impostor chỉ có GLES3/GLES, không có DXBC/SPIR-V/Metal,
     nên công việc HLSLcc hay SPIR-V cần một fixture khác.

  4. **Unity không có trên máy này.** Build và runtime validation là UNITY_NOT_AVAILABLE, đã kiểm
     tra chứ không phỏng đoán. Roslyn, shape check, audit và `measure-bodies.py` vẫn chạy được.

Iteration 044 — số liệu: mọi cột bằng đúng 043 (2722 load, genFail 0, 819 file, 16/16 shape,
  Roslyn 348/0, `array[i].field` 164, `(float)array[i]` 0, 0 file .cs đổi). Test 361 -> 372.
  Xem `docs/RECOVERY_MATRIX.md` cho 23 layer và `docs/FULL_RECOVERY_ARCHITECTURE.md` cho 13 tầng.

Iteration 043 — ba thứ phải biết trước khi làm tiếp:

  1. **`GenericInstanceFieldLayout` trả về offset trong khung của object ĐÃ BOX**, kể cả với struct,
     và nó đúng về thứ tự lẫn alignment. Đo: Impostor 547/598 và Pinata 435/458 tái lập ở
     `metadata + header`, **0 ở chính metadata**. 11 và 5 ca còn lại là union explicit-layout
     (`System.Decimal.ulomidLE` chồng lên `lo`/`mid`) — giới hạn đúng của phép đi tuần tự.
     `FieldOffsetFrame` đặt tên hai khung; hai phép chuyển là nghịch đảo nhau.

  2. **`SelfCheck` bỏ qua value type VÀ mọi field ở offset 0.** `ValueTypeSelfCheck` phủ cả hai.
     Đừng đọc "1394 reproduced, 0 disagreed" như thể nó nói gì đó về struct — nó không.

  3. **Counter của generator phải đọc ở chỗ generator báo cáo.**
     `Il2CppRecoveryDiagnosticsProcessingLayer` chạy TRƯỚC khi sinh thân hàm, nên in một counter của
     `IlGenerator` từ đó luôn cho 0. Bẫy này đã sập một lần trong iteration này và suýt được ghi
     thành "toàn bộ instance accessor pairing là code chết".

Iteration 043 — số liệu: mọi cột bằng đúng 042 (2722 load, genFail 0, 819 file, 16/16 shape,
  Roslyn 348 DECOMPILER_ERROR / 0 REFERENCE_ERROR, REAL_ERROR 861, `array[i].field` 164,
  `(float)array[i]` 0, Pinata 1478/1 mã lỗi giống hệt, 0 file .cs đổi). Test 354 -> 361, 1 fail
  có sẵn. `measure-bodies.py` vẫn 96,06% live trên Assembly-CSharp.

Iteration 042 — ba thứ phải biết trước khi làm tiếp:

  1. **Hệ toạ độ của offset thuộc về CON TRỎ BASE, không thuộc về kiểu.** Class thì offset metadata
     đã gồm header 0x10 nên không có gì phải quyết định. Một value type xuất hiện ở CẢ HAI hệ: lấy
     từ `this` của chính method của struct thì il2cpp trao con trỏ vào header của object đã box
     (`[this + 0x10]` cho field ở offset 0); cùng struct đó trong static storage / ô stack / field
     của object khác thì đọc đúng ở offset metadata. Cột `CoordinateEvidence` trên
     `CPP2IL_DUMP_LOADS` đo điều này trên từng load.

  2. **Giả thuyết "+0x10 cho value type" của 041 BỊ BÁC BỎ**: 77 VALUE_RELATIVE chống 29
     OBJECT_RELATIVE (43 chống 14 trên tập không nhập nhằng). `BOTH` = 0 nên bằng chứng CÓ tách
     được trên từng load, nhưng "cách nào trúng thì lấy" là heuristic đã bị loại ba lần (036/037/038).
     Muốn dùng phải có luật nói con trỏ base có được bằng cách nào.

  3. **Ứng viên open-generic branch của 041 là DEAD CODE** — probe đếm 0 lần đạt tới trên Pinata.
     Đừng làm lại. Lỗi `ComponentAction<T>.fsm` là field private của lớp cơ sở, cùng họ với
     `List<T>._size`, không phải lỗi phân giải field.

Iteration 042 — số liệu: mọi cột bằng đúng 041 (2722 load, genFail 0, 819 file, 16/16 shape,
  Roslyn 348 DECOMPILER_ERROR / 0 REFERENCE_ERROR, REAL_ERROR 861, `array[i].field` 164,
  `(float)array[i]` 0, Pinata 1478/1, test 354 với 1 fail có sẵn). Oracle ngoài mới:
  `measure-bodies.py` cho Assembly-CSharp **96,06% live**, toàn rip 62,97%.

Iteration 041 — số liệu:
  Impostor unresolved loads         2756 -> 2722  (−34, toàn bộ ở ACTk.Runtime 186 -> 152)
  Impostor genFail                     0 -> 0
  Impostor REAL_ERROR                861 -> 861   (34 load nằm ngoài Assembly-CSharp)
  Impostor Roslyn                    348 -> 348   AVAILABLE_AND_RUN, 348/348 DECOMPILER_ERROR
  Impostor file                      819 -> 819
  shape check                      16/16 -> 16/16 PASS
  `array[i].field`                   164 -> 164
  `(float)array[i]`                    0 -> 0
  cast `<>` toàn rip                   5 -> 5
  `(nint)0 != 0` toàn rip            134 -> 109   nhánh chết thành điều kiện thật
  Pinata Roslyn DECOMPILER_ERROR    1599 -> 1478  (−121, chỉ CS0030, không mã lỗi mới)
  Pinata genFail / file / mnf          0 / 3083 / 4052 không đổi
  iOS                                không đổi (1481 file, genFail 0)
  test                       343, 1 fail -> 354, 1 fail (đúng lỗi có sẵn từ trước)

Iteration 041 — ba thứ phải biết trước khi làm tiếp:

  1. **Field của một generic instance không có BackingData.** Mọi field của một generic instance là
     `ConcreteGenericFieldAnalysisContext` dựng bằng `base(null, ...)`, nên bất kỳ chỗ nào so
     `BackingData.FieldOffset` đều không bao giờ khớp trên một type như thế — và offset 0 thì khớp
     *mọi* field của nó. Offset thật chỉ có trong `GenericInstanceFieldLayout`.
     `BaseChainFieldSearch` là chỗ chuỗi base hỏi đúng cách. Một mắt xích chỉ trả lời cho field
     **nó tự khai báo**; nới điều này đáng 186 lỗi trên Pinata.

  2. **Nhãn provenance của 040 đã được sửa, đừng trích số cũ.** MISSING_METADATA 378 -> 184,
     PAST_LAST_FIELD 469 -> 416, GENERIC_LAYOUT 277 -> 390, thêm NO_KNOWN_LAYOUT 52 và
     RESOLVABLE 48. Số load không đổi; chỉ nhãn sai được sửa.

  3. **`RESOLVABLE` (48) là nhóm đáng đọc tiếp**, nhưng phải kiểm chứng giả định header trước —
     xem `reports/GENERIC_BASE_FIELD_ANALYSIS.md` mục 7 và 8.

Iteration 040 — hai thứ phải biết trước khi làm tiếp:

  1. **Roslyn CHẠY ĐƯỢC, và vẫn chạy được suốt ba iteration trước.** "Roslyn: NOT RUN" ghi ở
     037–039 là lỗi tìm đường dẫn của harness (`${DOTNET_ROOT:-$HOME/.dotnet}`, HOME=/root, SDK ở
     /home/user/.dotnet), không phải thiếu toolchain. Con số thật, lần đầu:
       Impostor Assembly-CSharp    63 file,  348 lỗi — 348/348 DECOMPILER_ERROR
       Pinata   Assembly-CSharp  1108 file, 1600 lỗi — 1599 DECOMPILER_ERROR, 1 REFERENCE_ERROR
     `compile_recovered_scripts.sh` giờ in `ROSLYN_STATUS` thành dòng riêng. **Không bao giờ ghi
     "0 errors" khi chưa compile** — hai tình huống đó in giống hệt nhau nếu không nói rõ.

  2. **Mỗi unresolved load giờ có nguyên nhân gốc**, không chỉ hình dạng. Xem
     `reports/LOAD_PROVENANCE_ANALYSIS.md`. Bảng chéo hình dạng × nguyên nhân tách họ
     "past the last field" 301 thành 147 thật + 154 base không ghi offset cho field nào.
     **Phi không còn tồn tại ở điểm đo này** — SSA đã destruct trước IlGenerator, 0/2756 dòng đi
     qua một phi.

Iteration 040 — số liệu (Impostor, `Test/Output-040b`):
  unresolved loads                  2756  (bằng 039c từng con số; 040 không sửa recovery)
  generator failures                   0
  Roslyn errors, Assembly-CSharp     348  AVAILABLE_AND_RUN, 348/348 DECOMPILER_ERROR
  shape check                      16/16 PASS
  `(float)array[i]`                    0
  `array[i].field`                   164
  test                       329, 1 fail -> 343, 1 fail (đúng lỗi có sẵn từ trước)

Android — iteration 034 so với baseline gốc (giống 032 từng con số):
  method body không phục hồi được   15 -> 0
  generator failure                  ?  -> 0
  audit REAL_ERROR                 2162 -> 884
  audit SEMANTIC_RISK                301 -> 167
  audit EXPECTED                      47 -> 55
  Roslyn errors, Assembly-CSharp     499 -> 340
  unresolved loads                  5702 -> 2870  (Assembly-CSharp 292 trong đó)
  đọc typeHierarchyDepth             n/a -> 18    (139 trước DECOMP-0020)
  đọc interface_offsets_count        n/a -> 74
  load có base là System.Object      n/a -> 19    (69 trước DECOMP-0016)
  CS0165 use of unassigned local     n/a -> 5     (không đổi; xem DECOMP-0020)
  file không có chẩn đoán nào, /46    20 -> 21
  field layout self-check            n/a -> 1394 exact, 78 thiếu field, 0 disagreement
  thời gian chạy                     58s -> 38s
  test                          274, 1 fail -> 279, 1 fail (đúng lỗi có sẵn từ trước)

  Pinata cùng chiều: unresolved loads 9756 -> 9177, method-not-found 4081 -> 4052,
  3083 file không đổi, 0 generator failure, field layout 0 disagreement.

Họ bug đang xử lý:
  không có cái nào đang dở.

Giả thuyết hiện tại:
  Khôi phục kiểu từ phía sử dụng đã được làm rõ và ghi trong reports/TYPE_RECOVERY_ANALYSIS.md,
  kèm mười hạng bằng chứng mà fixpoint áp dụng theo thứ tự và bảng load theo assembly. Ba hạng
  từng nằm sai chỗ và cả ba đã sửa: một shared generic instantiation cao hơn receiver
  (DECOMP-0015), System.Object - đỉnh của lattice - cao hơn kiểu khai báo của một field
  (DECOMP-0016), và kiểu hợp lưu của một phi lan ngược cao hơn định nghĩa của chính input
  (DECOMP-0018). Cả ba đều sửa bằng cách xếp lại hạng, không phải bằng cách cấm một nguồn.

  DECOMP-0020 (DCE quét từ gốc) là thứ làm hiện ra giá trị của những cái trên: trước nó, code đã
  được nhận diện và thay thế vẫn nằm lại trong thân hàm sau một vòng phi chỉ tham chiếu lẫn nhau.

  2870 load còn lại chia theo họ (reports/TYPE_PROVENANCE.json):
    930  untyped_base      base không có kiểu nào, không từ một Add
    651  runtime_struct    đọc cấu trúc runtime của il2cpp, KHÔNG phải managed field
    440  computed_addr     base là một Add mà array/field fold chưa nhận
    336  ancestor_base     offset vượt field cuối của kiểu base, hoặc giữa hai field
    207  generic_instance  generic instance có argument là value type
    170  valuetype_base    base là một value type
     88  other
     29  open_generic      base là một generic parameter chưa khởi tạo
     19  object_base       base phân giải thành System.Object

Bằng chứng để bắt đầu:
  - reports/TYPE_RECOVERY_ANALYSIS.md - thứ hạng bằng chứng, bốn defect đã mổ xẻ, phần còn lại
    theo họ và theo assembly. Đọc trước khi chạm vào fixpoint.
  - reports/TYPE_PROVENANCE.json - mọi unresolved load nhóm theo lệnh định nghĩa base, 027 và 032
    cạnh nhau. iterations/032/reports/unresolved-loads.tsv là dữ liệu thô từng dòng.
  - reports/OBJECT_BASE_TYPE_PROVENANCE.json - 69 load có base System.Object và 17 còn lại.
  - reports/BASE_FIELD_OVERFLOW_ANALYSIS.md - ví dụ mẫu về phương pháp: phân loại trước khi đếm.
    `CPP2IL_DUMP_LOADS=<file>` ghi một dòng cho mỗi load, từ đúng sự kiện mà bản tóm tắt đếm, và
    có nêu tên lệnh định nghĩa base.
  - reports/UNTYPED_LOCAL_IMPACT.md - 91% untyped local chứng minh được là không tốn gì. Vẫn đúng.
  - reports/BUG_FAMILY_PRIORITY.md - các họ lỗi biên dịch kèm phân loại và file.
  - reports/IOS_INPUT_ANALYSIS.md - fixture iOS: nhận dạng, bảng section Mach-O, bằng chứng mã hoá,
    và bảng nói rõ tầng nào kiểm tra được.
  - reports/CROSS_PLATFORM_MATRIX.md - đối chiếu hai nền tảng theo tầng và theo họ bug.
  - reports/FRAME_SLOT_ANALYSIS.md - 245 load AddressOf tách thành ba nhóm, đọc trước khi làm (a).
  - reports/IOS_REFD_DEVX_ANALYSIS.md - audit branch ref/devx, và CLAUDE.md từng nói sai về nó.
  - reports/IOS_RESEARCH.md - nghiên cứu iOS đầy đủ: ranh giới mã hoá đo từng con trỏ, những gì đã
    xác minh và những gì chưa.

Đã sửa:
  DECOMP-0001  15 method body xuất ra thành một throw mang stack trace của chính generator
  DECOMP-0002  lời gọi constructor của một value type bị bỏ, nên giá trị vẫn là không
  DECOMP-0003  một raiser được đưa exception đã dựng lại bị đặt tên theo exception khác
  DECOMP-0007  một shared generic call không được trỏ lại instantiation của receiver
  DECOMP-0008  generic field layout bỏ cuộc ở base có field và ở struct người dùng định nghĩa
  DECOMP-0009  một load không được fold lại về base mà địa chỉ của nó đã được tính sẵn
  DECOMP-0010  một runtime class trả về không ở chỗ cần RuntimeTypeHandle hoặc Type
  DECOMP-0012  một entry RGCTX trong shared generic code được inflate không có argument
  DECOMP-0013  một phi có input mâu thuẫn lấy kiểu của input đầu tiên
  DECOMP-0014  shortcut kiểm tra kiểu của il2cpp không được fold theo hình dạng thật
  DECOMP-0015  shared generic instantiation cao hơn receiver trong type fixpoint
  DECOMP-0016  System.Object tại use site bị coi là bằng chứng dù nó là đỉnh của lattice
  DECOMP-0017  hai trong ba hình dạng tính địa chỉ phần tử không được fold
  DECOMP-0018  kiểu hợp lưu của một phi lan ngược quá sớm vào input
  DECOMP-0020  DCE đếm lượt dùng nên không nhìn xuyên được một vòng phi
  DECOMP-0021  iOS: il2cpp nằm trong UnityFramework.framework, và Mach-O bị mã hoá báo sai tầng
  DECOMP-0023  code registration chỉ tìm được qua chuỗi tên module; và năm chỗ trong LibCpp2IL
               throw/allocate trên dữ liệu không đọc được

Còn mở:
  DECOMP-0022  245 load qua một địa chỉ được lấy, đã PHÂN LOẠI thành ba nhóm. Nhóm A (109) cần
               thông tin runtime - đừng cố gán kiểu. Nhóm B (124) là mục tiêu tiếp theo.
               Xem reports/FRAME_SLOT_ANALYSIS.md.
  DECOMP-0004  họ untyped local, ROADMAP mục 5. Đọc UNTYPED_LOCAL_IMPACT.md trước.
  DECOMP-0006  `base._002Ector(` - bị chặn sau DECOMP-0004
  và các hạng mục trong docs/articles/ImpostorSortScriptAudit.md, trong đó #1 (một unresolved call
  giữ toàn bộ register file làm argument của nó) là cái lớn nhất chưa bắt đầu

Đo rồi revert:
  DECOMP-0011  gán kiểu cho giá trị thay thế mà một điểm bỏ cuộc đẩy vào. Xấu hơn trên mọi trục.
  DECOMP-0019  nhận diện cặp so sánh qua chùm cờ A64. Lý luận đúng, nhận thêm 82 type check, và
               giá trị bằng không sau khi DECOMP-0020 vào: 82 lần đó đều ở vùng code chết.
  Cả hai ghi trong CLAUDE.md phần "đo ra không đáng gì" kèm lý do không làm lại.

Đo rồi đóng không thay đổi gì:
  DECOMP-0005  phía đọc của accessor pairing đã phủ List<T>._size; phần còn lại không có API công
               khai tương đương. WONT_FIX, kèm số liệu.

Trạng thái regression:
  sạch. Mười lăm shape check pass, field layout self-check 0 disagreement (đây là cổng, không phải
  ghi chú), 0 method body không phục hồi được, 0 generator failure, CS0165 vẫn là 5 như baseline.
  Hai file xấu đi so với baseline 027 (Extensions +6, GraphicController +2), cả hai chỉ là
  type_mismatch dịch chỗ với unresolved_load không đổi.

  Shape check so khớp chuỗi cố định, không phải pattern, và KHÔNG neo vào tên biến có số thứ tự do
  ILSpy sinh. Mỗi check đã được kiểm chứng là fail ở đúng các iteration chưa có fix của nó:
  019 fail 5, 020 fail 5, 023 fail 3, 026 fail 2, 027 fail 2, 028 fail 1, 029 fail 1, 032 pass hết.

Unity test bị chặn:
  U1-U9 trong reports/BLOCKED_UNITY_TESTS.md. Script trong Test/Scripts/unity/ từ chối chạy khi
  không có editor thật (exit 90). KHÔNG phải đang pass. Verdict vẫn là PASS_WITH_KNOWN_LIMITATIONS.

Trạng thái hai nền tảng:
  Xem reports/CROSS_PLATFORM_MATRIX.md. Tóm lại: phát hiện cấu trúc, đọc container ELF/Mach-O, đọc
  metadata v31.1 và tìm metadata registration đều PASS trên cả hai. Code registration, lift mã máy,
  type recovery, sinh C# và field layout self-check là KHÔNG KIỂM TRA ĐƯỢC trên iOS vì fixture bị
  mã hoá. Quy tắc: một họ bug thuần metadata (ancestor, generic instance, value type base, open
  generic) không đọc một byte mã máy nào nên dùng chung logic và không cần kiểm chứng chéo; một họ
  thuộc lift mã máy hoặc frame/stack thì cần, và hiện không làm được - trạng thái iOS phải ghi
  KHÔNG KIỂM TRA ĐƯỢC.

QUAN TRỌNG — ĐỌC TRƯỚC KHI THIẾT KẾ BẤT CỨ GÌ MỚI:
  Repository này có TÁM branch mà một clone mặc định không hiện. Chạy
  `git fetch origin 'refs/heads/*:refs/remotes/origin/*'` rồi tìm trong chúng trước khi tự viết.
  `origin/ref/devx` (39 commit, 20473 file) có một decompiler khác đã được dựng lại, cộng
  IL2CPP-PIPELINE.md (734 dòng) và IL2CPP-REBUILD-GUIDE.md (1795 dòng) bằng tiếng Việt. Chính việc
  audit nó ở iteration 034 đã sửa một kết luận mà CLAUDE.md đã ghi là chốt. Xem
  reports/IOS_REFD_DEVX_ANALYSIS.md.

Việc tiếp theo, theo thứ tự bằng chứng nói là đáng giá:

  (A0) **[XONG ở 039]** Không nới `Local` thành `IOperand` — cách đó phá mọi pass thay thế base.
      Thay vào đó `FieldReference.ElementIndex` mang chỉ số và `Local` vẫn là cái mảng. Xem mục cũ: Đây là năng lực còn
      thiếu chặn cả hai việc lớn nhất đang mở: cluster B của ROOT_CAUSE_INVENTORY (283 load, phải
      diễn đạt được `array[i].field`) và phần còn lại của iteration 037. `AddressOf(ArrayAccess(...))`
      đã tồn tại nên phép lồng không xa lạ với IR. `NestedFieldResolver` (037) đã lo sẵn phần chọn
      field theo offset và độ rộng. Đọc ROOT_CAUSE_INVENTORY.md mục 2 trước — hai giả thuyết đã bị
      loại ở đó, đừng làm lại.

  (A1) **Phân loại cluster G (619 load).** Họ lớn nhất chưa ai mở ra, nhãn hiện tại là UNKNOWN.
      Phân loại trước khi làm.

  (A) **Tách một phép ghi phủ nhiều nested field.** Đây là việc còn lại giữa ba `mangled_ctor` mới
      của 036 và một câu trả lời đúng, và bằng chứng đã đủ. `IlGenerator.PackedFieldsCovered` đã
      làm đúng việc này cho trường hợp phẳng; ở đây sâu hơn một tầng. LƯU Ý: chẩn đoán cũ
      ("ghi 4 byte vào field 24 byte, đích đúng là `this.level.currentCryptoKey`") mà cả iteration
      036 lẫn brief 037 đều nêu là **SAI** — đo tại chỗ quyết định cho `accessSize=16 size=20`, và
      `ObscuredInt` có field ở 0x0/0x4/0x8/0xC/0x10 nên 16 byte lát kín bốn field đầu. Đích là một
      phép copy bộ phận lát kín, không phải một nested field. Xem
      reports/NESTED_DESTINATION_ANALYSIS.md.


  (0) **iOS: ĐÃ GIẢI QUYẾT ở iteration 035 — không còn blocker nào sửa được bằng phân tích tĩnh.**
      `InstanceSize=2249170484` không phải (a) metareg false positive, cũng không phải (b)
      `ApplyChainedFixups` sai — hai giả thuyết đã ghi ở đây trước đó. Cả hai đều sai. Registration
      đúng (8702 con trỏ tăng đơn điệu bước 0x10, hai count độc lập khớp
      `metadata.TypeDefinitionCount`, `metadataUsages == 0` đúng cho v31.1), và binary KHÔNG có
      chained fixups. Đích của bảng nằm trong vùng FairPlay mã hoá, entropy 7,999/8. Đã sửa ở đúng
      layer bằng `IsVirtualAddressEncrypted` — phép kiểm tra là provenance của địa chỉ, không phải
      tính hợp lý của giá trị. Xem reports/IOS_TYPE_DEFINITIONS_SIZES_ANALYSIS.md.
      Việc còn thiếu là plaintext của `__TEXT`, và đó là bài toán acquisition chứ không phải parser:
      repository chỉ cần nhận thêm một input Mach-O `cryptid = 0`. KHÔNG tự viết FairPlay decryptor,
      không đoán khoá, không brute-force.

  (0b) **Chưa làm, đã đo một nửa: `AssetRipper.Import/Logging/Logger.cs:16` map MỌI warning của
      Cpp2IL sang `LogType.Verbose`.** Đó là lý do cảnh báo Mach-O mã hoá thêm ở iteration 033 chưa
      từng xuất hiện trong log nào. Iteration 035 đi vòng qua nó (báo cáo từ
      `Il2CppRecoveryDiagnosticsProcessingLayer`, nơi `Logger.Warning` đến được file). Sửa thẳng dòng
      đó sẽ làm hiện mọi warning của Cpp2IL cùng lúc — cần đo mức ồn trước, CHƯA đo.

  (a) **Nhóm B của DECOMP-0022: XONG ở iteration 036, và mô tả dưới đây SAI.** Không phải số học
      trên stack: `X8` là indirect result register của AAPCS64 và các "slot đích" không tồn tại —
      callee ghi cả khối, nên không có version SSA nào để chọn. Câu trả lời là giá trị trả về của
      lệnh gọi, và nó có kiểu. 121 load qua X8 còn 10; `GameHelper.SetSizeByWidth` từ chia cho số
      không thành `bounds.m_Extents.x + bounds.m_Extents.x`. Xem
      reports/INDIRECT_RETURN_BUFFER_ANALYSIS.md. Giữ đoạn cũ bên dưới làm ví dụ về một kết luận
      nghe hợp lý mà sai.

  (a-cũ) **[SAI] Nhóm B của DECOMP-0022: 124 load qua địa chỉ của một stack slot đã biết.** Đây là mục tiêu
      tiếp theo được khuyến nghị, và nó KHÔNG phải bài toán gán kiểu. `StackAnalyzer.NameForSlot`
      đặt tên slot theo chính offset của nó (`stack_-88`), nên `[&stack_-88 + 0x14]` chính xác là
      `stack_-74` bằng số học trên layout frame đã biết, và các slot đích đã có kiểu đúng. Cái khó
      duy nhất là chọn version SSA: ở ví dụ mẫu địa chỉ được lấy ở `stack_-88_v3` còn các slot được
      ghi ở `_v5`. Hai ràng buộc bắt buộc: chỉ viết lại khi offset là hằng số và slot đích tồn tại;
      version phải lấy từ cùng cơ chế `SsaForm.RetargetAddressTakesOverwrittenBeforeUse` dùng, và
      nếu không xác định được thì ĐỂ NGUYÊN placeholder - chọn sai version tạo ra một giá trị sai
      im lặng, là loại lỗi duy nhất không được phép. Đọc reports/FRAME_SLOT_ANALYSIS.md trước.

  (a2) **Nhóm A của DECOMP-0022: 109 load trong thân generic chia sẻ hoàn toàn — ĐỪNG cố gán kiểu.**
      Đã có bằng chứng rõ ràng rằng nhóm này cần thông tin runtime: slot được cấp phát động bằng
      một trình tự alloca đọc `Il2CppClass.stack_slot_size` (0xFC) rồi trừ vào SP và memset, nên
      kích thước và kiểu của chúng chỉ tồn tại lúc chạy — chúng là tham số kiểu thật sự, không phải
      placeholder suy ra được. Việc *có thể* làm: nhận diện cả trình tự alloca như scaffolding
      runtime và bỏ đi, giống cách TypeCheckRecovery làm với phần của nó. Thân hàm ngắn lại, các
      load vẫn không có kiểu, và thế là đúng. 61 lệnh đọc 0xFC trong bản rip đều thuộc đây.

  (a3) **311 load `Move:memory` không kiểu và 254 load không có định nghĩa trong thân hàm.** Hai
      nhóm còn lại của 930. Chưa phân loại. Làm giống cách đã làm với 245: phân loại trước khi đếm.

  (b) **651 lệnh đọc cấu trúc runtime bị đếm như unresolved load.** `Il2CppClass` ở `0x28`
      (byval_arg bitfield: attrs/type/valuetype - 103 lần), `0xFC` (stack_slot_size - 61),
      `interface_offsets_count` (74 lần trước DCE, còn lại sau), `cctor_finished`,
      `Il2CppMethodInfo` ở `0x53`, static field storage ở `0x8`. Chúng có base đúng và offset
      đúng; thiếu là một pass nhận ra hình dạng, như TypeCheckRecovery và InterfaceDispatchRecovery
      đã làm cho phần của chúng. Offset đọc từ StructDb qua
      `Il2CppClassUsefulOffsets.TryGetOffset`, đừng viết số xuống.
      KHÔNG được ép một cấu trúc runtime thành managed field chỉ để giảm số đếm.

  (c) **Một field của struct element: `array[i].y`.** Phần lớn nhất còn nhận diện được của 440
      `computed_addr`. Không thể fold thành `ArrayAccess` vì một element của `Vector3[]` rộng hơn
      một lệnh load của nó, làm vậy sẽ đọc một Vector3 thành một float. Chúng cần *địa chỉ* của
      element được đặt tên thành một local có kiểu của element, đúng thứ
      `ArrayRecovery.RecoverStructElementAddresses` sinh ra - từ phía sử dụng, ở cuối phân tích, và
      chỉ khi array là base trực tiếp. Kết quả âm của DECOMP-0017 nói: làm bằng cách mở rộng hình
      dạng, không phải bằng cách đi ngược chuỗi định nghĩa.

  (d) **Một unresolved call giữ toàn bộ register file làm argument.** Mục #1 trong
      ImpostorSortScriptAudit.md, chưa bắt đầu. Mười sáu nguồn thô của một call chưa giải quyết làm
      mọi thanh ghi trông như đã được định nghĩa, nên một call đã giải quyết ở sau có thể đọc một
      thanh ghi không ai ghi và truyền giá trị vào hàm. Đây là mất type provenance ở mức nghiêm
      trọng nhất: nó tạo ra `null` im lặng thay vì một placeholder được báo.

  Lưu ý cho người tiếp nhận: spine-unity *có* nguồn đối chiếu. Nguồn của Spine được vendored tại
  `artifacts/reference/.../Assets/ThirdParties/Spine/Runtime/spine-csharp/`, nên một bản phục hồi ở
  đó đọc được đối chiếu nguồn dù `audit_recovered_scripts.py` chỉ phủ Assembly-CSharp. Đó là chỗ
  giữ hơn 40% unresolved load còn lại.

  Và: Assembly-CSharp giữ chưa tới một phần chín số load. Trước khi kết luận một thay đổi không làm
  gì, đọc bảng theo assembly trong reports/TYPE_RECOVERY_ANALYSIS.md.

Giai đoạn thành công gần nhất:
  iteration 034 - audit origin/ref/devx, DECOMP-0023 sửa, iOS đi từ "không qua nổi bước tìm
  codereg" tới "binary khởi tạo xong, lớp recovery chạy và chẩn đoán đúng". Android và Pinata giống
  hệt từng con số.

Lần thất bại gần nhất:
  iteration 030 - DCE chỉ đánh dấu định nghĩa cuối. Tốt hơn trên MỌI cột dễ đọc và vẫn bị loại vì
  nó xoá code còn sống; dấu hiệu duy nhất là CS0165 từ 5 lên 12. Đây là ví dụ mạnh nhất trong repo
  cho nguyên tắc semantic correctness > diagnostic reduction.

## Iteration 045 — bốn điều một session sau phải biết trước khi làm gì

1. **Luật hệ toạ độ của 044 đã bị bác bỏ, và bác bỏ theo chiều ngược lại.** Đo trên dân số load
   ĐÃ phân giải: THIS/PARAMETER/CALL_RESULT đọc value type là VALUE_RELATIVE **1761 lần**,
   OBJECT_RELATIVE **0 lần**. 25 ca object-relative mà 044 nhìn thấy chính là 25 ca thất bại.
   `OBJECT_RELATIVE` là dấu hiệu của thất bại chứ không phải một luật về khung. Đừng làm lại.

2. **Phép tìm field không phải nút thắt, và họ `RESOLVABLE` 48 load là artefact.** Cột
   `SEARCH_ANSWERS` chạy chính phép tìm tại điểm load được đếm: 1417 SEARCH_EMPTY, 1241 NO_OWNER,
   61 NOT_A_FIELD_ACCESS, **3** SEARCH_ANSWERS. Con số 48 của iteration 040/044 đến từ việc đo bằng
   `GenericInstanceFieldLayout`, vốn nằm ở khung boxed — cùng một sự thật đếm hai lần, không phải
   hai bằng chứng độc lập.

3. **CS0030 không phải một họ.** Brief nêu 1125 lần `int -> TCP2_PlanarReflection`; thông báo đó có
   đúng một lần, 1125 là số của mã lỗi và thông báo đi kèm là cái đầu tiên trong log. Phân loại
   theo hình dạng toán hạng: 60% là local dùng sai chỗ (229 cặp kiểu riêng biệt, lớn nhất 48), 22%
   là `((Fsm)0)` tức phép đếm lại của unresolved load. Harness giờ in thông báo phổ biến nhất kèm
   tỉ lệ, nên cái bẫy này không lặp lại được.

4. **"4 m_Script gãy" là 6.** Hai GUID treo không bị đếm vì phép đếm cũ grep một chuỗi
   (`fileID: 0`). `Test/Scripts/audit_script_references.py` và
   `Test/Scripts/validate_unity_project.py` là hai công cụ mới; cả hai đều đã tự bắt được mình báo
   FAIL sai ba lần, mỗi lần vì đọc "vắng mặt" thành "hỏng" (xem
   `docs/RUNNABLE_PROJECT_RECOVERY.md` mục 4).

Bảng số 045: 2722 / 9245 load, genFail 0, 819 / 3083 file, 0 file .cs đổi so với baseline trên cả
hai fixture, shape 16/16, Roslyn 348/0 và 1478/1, `array[i].field` 164, `(float)array[i]` 0,
test 372 -> 376 với 1 fail có sẵn.

## Iteration 046 — ba điều một session sau phải biết

1. **"UNKNOWN" không phải một thứ, và bốn phần năm của nó có câu trả lời chính xác.** 809 load
   không biết nguồn gốc base tách thành năm nguyên nhân; `AddressOf(local)` đi tiếp tới local đó,
   một toán hạng đặt tên chỗ lưu trữ trong `Move` cũng đặt tên nó trong `Add`, và nhiều định nghĩa
   chỉ là UNKNOWN khi chúng **bất đồng**. 809 -> 396. Mỗi nhánh của một merge phải có tập `visited`
   riêng: hai định nghĩa cùng đi qua một local là hội tụ, không phải chu trình.

2. **651 lệnh đọc cấu trúc runtime đều đã có tên, từ struct database.**
   `Il2CppClassOffsetPatcher.MemberNames` là bảng ĐẦY ĐỦ, tách hẳn khỏi
   `Il2CppClassUsefulOffsets` (danh sách chọn lọc mà các pass key on, thêm một mục vào đó là đổi
   hành vi phân tích). Hai nhóm lớn nhất chưa ai đọc tên trước đây — **103 lần `byval_arg.attrs`,
   61 lần `stack_slot_size`** — gần như chắc chắn mỗi nhóm là MỘT hình dạng chưa nhận diện. Đó là
   hạng mục giá trị nhất còn lại.

3. **`recovery_report.py` trả lời "truy cập này là cái gì", không phải "bao nhiêu cái hỏng".**
   901 MANAGED_FIELD / 761 UNKNOWN / 651 RUNTIME_STRUCT / 343 NATIVE_TEMPORARY / 66 ARRAY_ACCESS,
   với 997 EXACT + 964 INFERRED + 761 NONE. Mục tiêu là kéo UNKNOWN xuống, KHÔNG phải kéo tổng về
   0: một lệnh đọc `stack_slot_size` đã được phục hồi đúng thành thứ nó là.

Bảng số 046: 2722 / 9245 load, genFail 0, 819 / 3083 file, **0 file .cs đổi so với baseline trên cả
hai fixture**, shape 16/16, Roslyn 348/0 và 1478/1, `array[i].field` 164, `(float)array[i]` 0,
test 376 -> 386 với 1 fail có sẵn.

## Iteration 047 — ba điều một session sau phải biết

1. **103 lệnh `byval_arg.attrs` của 046 thật ra là `byval_arg.valuetype`, và nhãn cũ SAI.** Một byte
   nhiều bitfield dùng chung chỉ gọi được tên nhóm; thành viên nào bị đọc do BIT quyết định và bit
   nằm ở lệnh tiêu thụ. 100 lệnh `CheckLess ,0` (thử dấu) + 3 lệnh `And ,0x80000000` = bit 31 =
   `valuetype` theo struct database. Đó là phép thử value-type của thân generic chia sẻ trên tham số
   kiểu MỞ, nên không có câu trả lời tĩnh - `RUNTIME_STRUCT` đúng nghĩa, giờ có bằng chứng.
   `MethodInfo.is_generic` cũng đổi thành `is_inflated` theo cùng cách. Và 43/61 `stack_slot_size`
   được tiêu thụ bởi `Add ,0xf` - đúng bước làm tròn của trình tự alloca iteration 033 mô tả.

2. **`method_recovery_report.py` là phép đo đầu tiên theo TỪNG METHOD.** Impostor 5482 method:
   70,5% CLEAN, 25,1% PARTIAL (mang toàn bộ 5130 placeholder), **0 mất hẳn thân**. Pinata 16365:
   77,9% CLEAN, **đúng 2 mất hẳn thân** (`YandexAppMetricaReceipt`, `YandexAppMetricaConfig`, 76 byte
   mỗi cái). Đó là con số §16 cần và không tổng nào đưa ra được. Placeholder TẬP TRUNG: 5130 trong
   1375 method, tệ nhất 113.

3. **Bốn lần phép đo tự báo sai trong một iteration, cả bốn phải sửa trước khi tin.** So khớp bằng
   tham chiếu (operand event nhận không phải object trong graph); ngoặc nhọn bên trong chuỗi của
   `[NativeSource]` (366 ca "mất thân" giả); assembly bị stub có chủ ý bị tính như thân bị mất (322
   ca giả) - phải ĐỌC log chứ không đoán; và một cột mới đẩy chỉ số cột của một classifier khác.
   Cái cuối chỉ bắt được vì baseline được đo lại và so.

Bảng số 047: 2722 / 9245 load, genFail 0, 819 / 3083 file, **0 file .cs đổi trên cả hai fixture**,
shape 16/16, Roslyn 348/0 và 1478/1, `array[i].field` 164, `(float)array[i]` 0,
MANAGED_FIELD/UNKNOWN/RUNTIME_STRUCT/NATIVE_TEMPORARY/ARRAY_ACCESS 901/761/651/343/66,
test 386 -> 388 với 1 fail có sẵn.

## Iteration 048 — bốn điều một session sau phải biết

1. **Một họ placeholder là một ĐIỂM PHÁT RA, không phải một chuỗi.** Chữ in ra mang theo toán hạng,
   nên đếm chữ cho ra hàng nghìn ca đơn lẻ và không họ nào cả. `placeholder_families.py` gắn mỗi
   placeholder về đúng `instructions.Add(CilOpCodes.Ldstr, …)` đã sinh ra nó, kèm phép toán ISIL và —
   nơi chữ có mang — mã lệnh máy. Impostor 5853: `UNMANAGED_MEMORY_LOAD` 2651, `METHOD_NOT_FOUND`
   1573, `NATIVE_IMPORT` 485, `INDIRECT_CALL` 350, `NOT_IMPLEMENTED_INSTRUCTION` 303, `INDIRECT_JUMP`
   254, `UNRESOLVED_DELEGATE` 128, `UNKNOWN_CALL_TARGET` 107. Ba họ đầu muốn ba loại công việc ngược
   nhau, và phép đếm gộp giấu điều đó.

2. **Phép đo của 047 đếm thiếu 732 placeholder và chấm 205 method là sạch trong khi không.**
   `DIAGNOSTIC` trong `method_recovery_report.py` là một bản chép tay của danh sách họ: nó ghi
   `"Unresolved delegate"`, một chuỗi generator **không bao giờ in ra**, và bỏ hẳn `Indirect call`
   cùng `Indirect jump`. Danh sách giờ định nghĩa **một lần** ở
   `placeholder_families.MESSAGE_PREFIXES` và được import. Con số của chính tôi tụt: method sạch
   4107 → 3902, `PARTIAL` 1375 → 1580. Mọi so sánh với iteration ≤ 047 phải đo lại cả hai đầu bằng
   phép đo này.

3. **`diff -rq --include='*.cs' A B` không phải tuỳ chọn của GNU diff.** Nó báo lỗi, và nếu bỏ stderr
   thì đọc thành "không file nào khác" — ba iteration đã báo bản rip không đổi bằng lệnh đó mà chưa
   từng so một lần nào. Đã dựng lại worktree ở `4dec5263`, rip lại Impostor và so: **các khẳng định
   ấy đúng, bằng chứng đằng sau thì không.** Dùng `Test/Scripts/diff_recovered_scripts.sh`.

4. **Một mã lệnh chưa lift được thì tự nói tên nó ra, và có loại không cần suy luận gì.** `BFI` và
   `BFXIL` chiếm 92 trong 303 `NOT_IMPLEMENTED_INSTRUCTION`; chúng là `UBFIZ`/`UBFX` cộng một lần
   **đọc đích**. Phần dễ sai là **bề rộng**, hai lần: `~placed` phải cắt về bề rộng thanh ghi, và mặt
   nạ phải viết ở bề rộng đó nếu không generator đẩy I8 vào đích I4. Còn lại trên Impostor:
   `UNIMPLEMENTED` 93, `FABD` 48, `DUP` 43 — nhưng `FABD`/`DUP` là dạng vector, và lift chúng như
   scalar sẽ sai **im lặng**. Trên Pinata cả họ chỉ có 16 ca: nó phân bố theo tập lệnh trình biên
   dịch sinh ra cho fixture, không theo chương trình.

Bảng số 048: Impostor method sạch **3902 → 3942**, Pinata **13167 → 13176**; placeholder 5862 → 5753
và 14740 → 14726; load bỏ cuộc 2722 → 2726 và 9245 → 9248 (phục hồi thêm thì lộ ra lệnh đọc từng bị
bỏ cùng code chết); genFail 0/0, `.cs` 819/3083, Roslyn 348-0 / 1478-1, shape 16/16, ctor 51,
`array[i].field` 164, `(float)array[i]` 0, test 388 → 402 với 1 fail có sẵn.

## Iteration 049 — bảy điều một session sau phải biết

1. **Phép đo của 048 vẫn còn quá dễ dãi, và 049 hạ điểm chính nó.** "Không có placeholder" không
   phải phục hồi: một thân hàm đọc `return default;` trong khi native có field read, so sánh, nhánh
   và lời gọi thì không mang placeholder nào và đã mất tất cả. `Test/Scripts/recovery_metrics.py`
   chấm `EXACT` / `HIGH_CONFIDENCE` / `PARTIAL` / `FALLBACK` / `MISSING` bằng cách so lớp phép toán
   mà `[NativeSource]` — bản kết xuất của **ISIL đã phân tích** — gọi tên với lớp phép toán thân C#
   gọi tên. Trong 3942 method "không placeholder" của 048, **1203 là đồ thế chỗ**. Mọi so sánh với
   iteration ≤ 048 phải đo lại **cả hai đầu** bằng harness này.

2. **Hai biến thể metadata init là ANH EM, không phải cha con** — và một dòng log là thứ tìm ra nó.
   `il2cpp_codegen_initialize_runtime_metadata` là stub `bl X; dmb ish`; bản `_inline` là `b X`,
   cùng X. Code đi tìm "hàm nào nhảy TỚI bản có barrier", thứ không tồn tại. 889 lời gọi từ 268
   method — 40% của mọi `Method not found`. `ReportKeyFunctions` in ra helper nào tìm thấy và helper
   nào không; ba cái còn lại chưa tìm ra là `il2cpp_codegen_raise_exception`,
   `il2cpp_codegen_write_barrier`, `il2cpp_codegen_initialize_method`, và cách tìm anh-em-veneer này
   là thứ nên thử trước với chúng.

3. **`DelegateInvokeRecovery` là ví dụ thứ N của "pass viết cho hình dạng ở sai điểm".** Nó đòi một
   `MemoryOperand` addend 24, còn nó chạy *sau* phép phân giải biến operand đó thành một
   `FieldReference` tên `invoke_impl`. Và nửa còn thiếu là **delegate generic**: một generic instance
   context không khai báo thành viên nào của riêng nó, nên hỏi nó `Invoke` — hay hỏi nó có phải
   delegate không — đều không ra gì, trong khi phần lớn delegate là generic.

4. **`INDIRECT_CALL` tách sạch bằng chính chữ nó in ra**: `X.invoke_impl` là delegate invoke,
   `[base + offset]` là ô vtable. Sau 049 còn đúng **233 ô vtable** và 0 delegate. Đó là việc kế
   tiếp có giá trị cao nhất, và nó cần `InterfaceOffsets` + `VTable` của `Il2CppTypeDefinition`.

5. **`0xAF4130` cố ý KHÔNG được ánh xạ.** 339 lời gọi, **339/339 caller là event accessor**, và mã
   máy ở đó (`ldaxr x8,[x0] / cmp x8,x2 / stlxr w9,x1,[x0]`) là một vòng compare-and-swap đúng thứ
   tự tham số của `Interlocked.CompareExchange`. Ngữ nghĩa chắc chắn; **cách tìm ra nó một cách tổng
   quát thì chưa có** — mọi chuỗi thunk từ `Interlocked::CompareExchange` dẫn tới `0xAF41A4` /
   `0xAF41CC` / `0xAF4164` chứ không tới `0xAF4130` — và ánh xạ sai sẽ hỏng im lặng 339 event
   accessor. Đừng vá nếu chưa có đường tìm.

6. **`INDIRECT_JUMP` cũng tách sạch, và họ lớn nhất không phải bảng nhảy.** `IndirectJumpClassifier`
   chạy cuối `Analyze` và chỉ đếm: 288 `DELEGATE_INVOKE`, 135 `VTABLE_SLOT`, 60 `DEFINED_BY_Add` (ứng
   viên **duy nhất** cho một bảng nhảy), 30 `LOADED_POINTER`. Nên phần lớn là delegate tail-invoke —
   cùng phép phục hồi ở điều 3, chỉ khác vị trí — và mở rộng sang `IndirectJump` lấy 254 xuống 120.
   Cú `return` phải viết ra: generator nối một block không kết thúc bằng jump/return sang successor,
   mà block của cú nhảy gián tiếp không có successor nào. **Pinata có 0 `DELEGATE_INVOKE`** trong
   1591 cú nhảy, nên không đổi gì ở đó.

7. **Kho method vàng là `Test/golden-corpus.json`, 48 method, chọn bằng máy.** Mỗi lớp phép toán góp
   một method ở mỗi trạng thái nó có, nên kho trải đều cả hai trục thay vì toàn method khó — thứ chỉ
   có thể báo tốt lên. Nó **phân biệt được**: chạy trên bản rip 048 nó chỉ đúng 3 method 049 đưa lên
   và 2 method 049 đẩy từ `PARTIAL` xuống `FALLBACK`. Chạy
   `golden_corpus.py <rip> --log <log> --corpus Test/golden-corpus.json --check Test/golden-corpus-baseline.json`
   trước khi tin bất kỳ con số tổng nào.

Bảng số 049 (Impostor, phép đo mới cho cả hai đầu): `EXACT` 2594 → **2841**, `PARTIAL` 1540 → 1235,
`FALLBACK` 1203 → 1250 (tăng và trung thực: lộ ra chứ không biến mất), phục hồi không kèm đồ thế chỗ
2739 → **2997**; placeholder 5753 → 4617; `METHOD_NOT_FOUND` 1573 → 713; `INDIRECT_CALL` 350 → 233;
`INDIRECT_JUMP` 254 → 120; lời gọi thành placeholder 2343 → 1444; load 2726 → 2711; Roslyn 348 →
**342**; shape 16/16, `.cs` 819, `genFail` 0; test 402 → 407. **Pinata y hệt 048 ở mọi con số.**

Trạng thái tổng: **`RECOVERY_VALIDATED_STATICALLY`**, không phải `FULLY_RECOVERED` — Unity chưa chạy.

## Ghi chú môi trường

Container không có .NET SDK và không có Unity. `dotnet` lấy từ
`https://dot.net/v1/dotnet-install.sh --channel 10.0 --install-dir /home/user/.dotnet`; thêm nó vào
`PATH` và đặt `DOTNET_ROOT` cho `Test/Scripts/compile_recovered_scripts.sh`, script này tìm Roslyn
bên dưới đó. Không có `/usr/bin/time`; dùng `date +%s`.

**Unity không có ở đây**, nên Unity batchmode import, biên dịch script và mọi runtime smoke test
đều không chạy được. Phép đo biên dịch có được là Roslyn chạy trên chính các assembly mà bản rip xuất kèm; nó yếu hơn
phép đo của Unity với các assembly đặc thù Unity, và nghiêm hơn theo một hướng: một thành viên
framework mà IL2CPP đã strip khỏi build sẽ đọc thành lỗi khi đối chiếu stub, dù bản xuất ra vẫn đúng
so với một bản cài Unity thật.

Thêm một phép đo bắt buộc cho mọi thay đổi chạm vào lõi phân tích: chạy lại cả `Test/Input/Pinata`
(metadata v24.2, x86) và so `unresolved loads`, `method-not-found`, số file, `generator failure` và
`field layout self-check`. Impostor là ARM64/v31.1, nên một thay đổi chỉ đúng cho một trong hai sẽ
hiện ra ở đây.

## Vòng lặp, viết thành lệnh

```
dotnet build AssetRipper.slnx -c Release
dotnet test  AssetRipper.slnx -c Release --no-build

dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output iterations/<n>/output --log iterations/<n>/logs/AssetRipper.log Test/Input/Impostor

Test/Scripts/collect_metrics.sh        iterations/<n>
Test/Scripts/check_recovered_shapes.sh iterations/<n>/output
Test/Scripts/compile_recovered_scripts.sh iterations/<n>/output Assembly-CSharp
python3 Test/Scripts/audit_recovered_scripts.py \
  --source artifacts/reference/Impostor-Sort-Puzzle-Pro/Assets \
  --output iterations/<n>/output/Impostor/Assets/Scripts/Assembly-CSharp \
  --json   iterations/<n>/reports/audit.json
```
