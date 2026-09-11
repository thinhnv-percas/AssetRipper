# Trạng thái agent

Đọc file này trước tiên sau khi khởi động lại, rồi `reports/regression-matrix.md` cho số liệu và
`reports/issues.json` cho các hạng mục còn mở. Từ iteration 027 trở đi, toàn bộ tài liệu và ghi chú
phân tích viết bằng tiếng Việt; tên class, method, symbol, error code giữ nguyên tiếng Anh.

```
Iteration hiện tại: 036 (hoàn tất; DECOMP-0026 buffer trả về gián tiếp)

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
  rảnh giữa hai iteration. Baseline cho iteration sau là 034 (Android giống 032 từng con số).

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
