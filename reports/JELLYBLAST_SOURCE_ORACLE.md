# JellyBlast source oracle — iteration 063

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Source: `develop` @ `462789cf`
(`Test/fixtures/jellyblast-source-revision.txt`). Bản rip đo: `Test/Out63o3-i` (JellyBlastV2 với
`CPP2IL_RECOVER_ALSO`, xem §2). Nguyên liệu: `iterations/063/source-oracle/`.

## 1. Mỗi assembly có ba nhãn trước khi một method nào được so

`Test/Scripts/jellyblast_source_oracle.py`. `source_oracle.py` và `source_behavior_oracle.py` gom cả project
rồi ghép method theo (type, tên) xuyên mọi assembly — sai hai lần với fixture này: class không phải
identity nếu thiếu assembly, và source không phải một loại bằng chứng.

| Nhãn | Giá trị | Từ đâu |
|---|---|---|
| category (§18) | GAME / THIRD_PARTY / UNITY_PACKAGE / ENGINE / GENERATED_CODE | nơi source nằm: asmdef trong `Assets`, package trong `PackageCache` (`com.unity.*` hay không), predefined assembly, module engine |
| provenance | PROVEN_BUILD_MATCH / LIKELY_MATCH / SOURCE_MISMATCH / NO_SOURCE | `build_provenance.py` |
| oracle | **INDEPENDENT** / **VERSION_MISMATCH** / **DERIVED** / NO_SOURCE | khai báo khớp và chưa từng qua decompile → INDEPENDENT; version khác → VERSION_MISMATCH; suy ra từ chính IPA (pin: `derived_assemblies`) hoặc có dấu decompiler → DERIVED |

Source được tiền xử lý theo symbol của player iOS 2022.3.53f1 cộng define của project và `versionDefines`
của asmdef sở hữu file. `NOT_AVAILABLE` được tách: **NOT_IN_BUILD** (IL2CPP strip method, không có gì để
phục hồi — 2940 trên các assembly độc lập) khác với method thật sự không ghép được (45).

## 2. Package có source độc lập chưa bao giờ có thân phục hồi

Pipeline stub mọi `Unity.*`/`UnityEngine.*` theo tên — đúng cho project (package đến từ Package Manager),
nhưng nghĩa là đúng loại code có source độc lập không bao giờ có thân để so. `CPP2IL_RECOVER_ALSO`
(Cpp2IL `IlRecoveryScope`) mở lại những assembly được nêu tên, **chỉ cho phép đo**; không đặt thì quyết
định y như upstream, và log in một cảnh báo khi đặt.

Chạy nó lộ ra một lỗi thật (§5.4): widening đổi layout serialize.

## 3. Kết quả — MEASURED

| Assembly | Oracle | So được | EXACT+EQ | PARTIAL | FALLBACK | MISMATCH | UNDECIDED_ARITHMETIC |
|---|---|---:|---:|---:|---:|---:|---:|
| UnityEngine.UI | INDEPENDENT | 336 | 245 | 82 | 8 | 1 | — |
| Unity.TextMeshPro | INDEPENDENT | 430 | 322 | 94 | 12 | 2 | — |
| Unity.VisualScripting.Core | INDEPENDENT | 390 | 235 | 120 | 33 | 2 | 8 |
| Unity.Mathematics | INDEPENDENT | 57 | 33 | 19 | 5 | 0 | — |
| Voodoo.UI.Particles | INDEPENDENT | 60 | 39 | 20 | 0 | 1 | — |
| PathCreator | INDEPENDENT | 56 | 30 | 24 | 2 | 0 | 1 |
| RayFireAssembly | VERSION_MISMATCH | 449 | 340 | 95 | 10 | 4 | — |
| Assembly-CSharp | DERIVED | 379 | 268 | 85 | 10 | 16 | — |
| Assembly-CSharp-firstpass | DERIVED | 34 | 18 | 16 | 0 | 0 | — |

**`behaviour_equivalence_rate` INDEPENDENT = 0.6802 (904/1329)** — con số duy nhất ở đây so với văn bản
của programmer. VERSION_MISMATCH 0.7572 (340/449) và DERIVED 0.6925 (286/413) được báo riêng và không bao
giờ cộng vào.

## 4. Phép đo đã phải sửa trước khi tin được

- **Call vắng mặt khỏi machine code.** Một project call mà thân phục hồi không gọi tên bị tính là mất.
  Nhưng khi thân không có runtime boundary và không có placeholder nào — mọi call machine code thực hiện
  đều được đặt tên — thì call vắng mặt khỏi chính machine code: compiler native đã inline nó
  (`calls_complete`). Bằng chứng phải gồm cả placeholder: một `Indirect call` chưa giải quyết là
  placeholder, không phải boundary.
- **Event và accessor bị inline.** `OnModified += h` là `add_OnModified`; `GameState = x` bị inline
  thành ghi `_gameState`; getter lười ghi `_text` khi đọc. Ghép theo quy ước tên backing field, chỉ cho
  member mà source nêu tên.
- **UNDECIDED_ARITHMETIC.** Một thân chỉ tính toán (source chỉ gọi framework, thân phục hồi là N phép
  số học, mọi call đã giải quyết) bị gọi FALLBACK — sai, vì FALLBACK khẳng định là bản thay thế.
  `EvaluateCurveDerivative` tính đúng đạo hàm Bézier. Contract so effect và call, không so giá trị, nên
  câu trả lời trung thực là "không quyết định được"; không tính là đạt.

Mỗi luật có một case self-test đỏ nếu bỏ luật: 17/17. RunFromZombies vẫn 1.0000 (35/35).

## 5. Lỗi phục hồi mà oracle độc lập tìm ra — PROVEN, đã sửa

Điểm đầu tiên nơi nghĩa binary khác nghĩa phục hồi, theo §36:

1. **AAPCS64 C.3 và kích thước stack argument.** `PathCreator.CubicBezierUtility.EvaluateCurve(Vector3 a1,
   Vector3 c1, Vector3 c2, Vector3 a2, float t)` phục hồi với `t` là `default(float)`: a1 ở V0–V2, c1 ở
   V3–V5, c2 không vừa nên NSRN = 8 và **mọi float sau cũng lên stack** — resolver gán V6 cho `t`, thứ
   không ai ghi. Thêm: stack slot theo kích thước (Vector3 16 byte), và Apple đóng gói theo natural
   alignment. `Arm64ArgumentPlacement` (5 test, 3 đỏ nếu bỏ C.3). 13 file đổi trên JellyBlastV2, mỗi file
   là một tham số trên stack từng đọc thành default: `VertexGradient` (Color thứ tư), `DOCurve`,
   `VertexHelper`, `TMP_TextUtilities`, RayFire…
2. **FCMP lift như SUBS.** `Mathf.Clamp01` inline ra `object obj = t ^ 1f;` — không phải C#. V của FCMP là
   unordered; giờ `!(a == a && b == b)`, N/Z/C là so sánh float. 134 → 0 biểu thức đó; PathCreator
   Roslyn 474 → 372.
3. **P/Invoke mất import map.** 131 `static extern` không `[DllImport]` — compile được, không bind được
   lúc chạy (haptic Taptic, GameAnalytics, Facebook, RayFire). Trên iOS mọi P/Invoke là `__Internal`,
   entry point là tên method: 55/55 trong `RFLib_DotNet_2018_ios.dll` upstream mà source ship. Source
   đã thêm tay đúng attribute này cho `TapticManager`.
4. **Widen đổi layout serialize** — `reports/JELLYBLAST_SERIALIZED_ORACLE.md` §3.

Chưa sửa, được ghi nhận: `SetPropertyUtility.SetColor` ghi qua `ref Color` ra `currentValue = ref *(Color*)
newValue` (gán lại ref thay vì lưu giá trị) và đọc member qua `Color&` không giải quyết — lỗi storage
qua con trỏ tới struct; Vector3 chỉ có `.x` được tính khi phép toán là SIMD (lớp vector, đã biết).

## 6. Fix-commit corpus — DERIVED

`jellyblast_fix_corpus.py` đọc commit của source: 66 method được nêu tên trong commit "Fix <Type>: …" (sau
khi bỏ 21 từ không phải tên method của build) trên 13 type, và 34 file được sửa nguyên file. Hôm nay, so
với bản đã sửa: 3 EXACT, 23 SEMANTICALLY_EQUIVALENT, 14 PARTIAL, 5 MISMATCH, 18 không ghép được (chủ yếu
constructor: harvest không đọc constructor). Bản sửa là cách đọc của một người (hoặc LLM) trên bản rip
cũ và machine code, nên nơi hai bên khác nhau, bên nào cũng có thể đúng.

## 7. Giới hạn

- Contract so effect, call, vòng lặp và nhánh — không so giá trị. Lỗi giá trị (tham số `t`) chỉ thấy
  qua diff và qua đọc.
- Package bị stub trong project xuất ra; đo chúng là đo pipeline, không phải project.
