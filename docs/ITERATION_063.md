# Iteration 063 — JellyBlast source oracle, interface dispatch, shader, Unity runtime fidelity

Nhãn: `PROVEN`, `MEASURED`, `INFERRED`, `UNKNOWN`, `BLOCKED`. Baseline: bản rip cuối của 062
(`Test/Out62m-{z,m,j,i,p}`), đo lại bằng cùng script. Kết quả: `Test/Out63g-*` (mặc định) và
`Test/Out63o3-i` (JellyBlastV2 với `CPP2IL_RECOVER_ALSO`, chỉ để đo source oracle).

## Tóm tắt

Brief yêu cầu dùng source JellyBlast làm oracle cho mọi thứ. Việc đầu tiên nó đòi — kiểm chứng rằng
source là thứ build ra IPA (§3) — trả lời **ngược lại**: source được suy ra từ chính IPA này (một bản rip
của pipeline này, `fe27775f`, rồi 64 commit sửa tay/LLM). Vì thế mọi so sánh được gắn nhãn trước khi đo:
**INDEPENDENT** chỉ cho package upstream khớp khai báo với build, **DERIVED** cho code game, scene, prefab,
shader. Dùng phần độc lập làm oracle tìm ra năm điểm đầu tiên nghĩa binary ≠ nghĩa phục hồi, cả năm đã sửa
tại tầng đầu tiên sai:

| # | Triệu chứng | Tầng đầu tiên sai | Sửa |
|---|---|---|---|
| 1 | `EvaluateCurve(..., float t)` phục hồi với `t = default` | resolver ABI ARM64 bỏ AAPCS64 C.3; stack slot 8 byte cố định | `Arm64ArgumentPlacement` (C.3, kích thước, đóng gói Apple) |
| 2 | `object obj = t ^ 1f;` | FCMP lift như SUBS | cờ IEEE, V = unordered |
| 3 | 131 `static extern` không `[DllImport]` | import map không có trong metadata | `__Internal` trên build Apple (55/55 với DLL upstream) |
| 4 | UI Image mất sprite (khi mở UGUI) | widen field lên public đổi layout serialize | `NotSerialized` cho field widen |
| 5 | Assembly-CSharp "22 lỗi" | lỗi khai báo của export (CS0507, CS0122, CS0052) và stub strip getter (CS0617) che mọi lỗi thân | `OverrideAccessibility`, không export type Jobs ILPP, widen kiểu của member, body pass trong harness |

Và một tiền đề sai trong chính CLAUDE.md: **chương trình Metal của Unity là MSL source**, không phải thư
viện. 780/780 trên JellyBlast; trích ra, không nhúng vào ShaderLab.

## 1. Build provenance (§2–§3) — `reports/JELLYBLAST_BUILD_PROVENANCE.md`

Pin: `develop` @ `462789cf` + fingerprint IPA (UnityFramework, global-metadata, data.unity3d, Unity
2022.3.53f1). So khai báo theo hướng build ⊆ source (`AssemblyFingerprint`, `SourceDeclarationSurface`,
`build_provenance.py`, tái tạo bằng `jellyblast_build_provenance.sh`): PROVEN_BUILD_MATCH cho Mathematics,
TMP, VisualScripting, UGUI, Voodoo; LIKELY_MATCH PathCreator; SOURCE_MISMATCH RayFire, Burst, Collections
(version khác) và Assembly-CSharp (230 member + 19 type thiếu, **tất cả quy được về commit**: sample SDK bị
xoá, Collections hạ về 1.2.4, event viết lại). Project: **SOURCE_MISMATCH**.

## 2. Source oracle (§4–§5) — `reports/JELLYBLAST_SOURCE_ORACLE.md`

`jellyblast_source_oracle.py`: ghép theo assembly, nhãn category/provenance/oracle, tách NOT_IN_BUILD.
`CPP2IL_RECOVER_ALSO` mở package bị stub để có thân mà so. **INDEPENDENT behaviour 0.6802 (904/1329)**;
VERSION_MISMATCH 0.7572, DERIVED 0.6925, không bao giờ cộng. Bốn luật đo sửa trước khi tin
(`calls_complete`, event accessor, backing field của accessor inline, `UNDECIDED_ARITHMETIC`), 17/17
self-test. Fix-commit corpus: 66 method người đã sửa.

## 3. Interface dispatch (§6–§9) — `reports/INTERFACE_DISPATCH_RECOVERY.md` §8–§9

`Test/logic-interface-corpus.json`: 77 case chọn từ bằng chứng của pass theo ưu tiên của brief
(GENERIC_INTERFACE 43, GENERIC_RECEIVER 50, RUNTIME_CONTEXT_CLASS 32, TAIL 20, GENERIC_VIRTUAL 0 — không
tồn tại trên bốn fixture). Source chỉ xác nhận (1 SOURCE_CONFIRMED). `--check`: 19 + 1 STUBBED, 17/17, 20/20,
12 + 8 NOT_PRESENT. RGCTX: **UNKNOWN**, không đổi.

## 4. Serialized, prefab, package, settings, native (§10–§11, §18–§21)

- Scene (`reports/JELLYBLAST_SERIALIZED_ORACLE.md`): so với derivation root 106/106 GameObject, 228/228
  reference, 173/173 binding; với `develop` 19 GameObject + 1 field + 1 null khác, **tất cả là chỉnh tay**.
- Prefab (`reports/JELLYBLAST_PREFAB_ORACLE.md`): 26 MATCH, 23 mismatch đều SOURCE_EDIT, 0 lỗi phục hồi,
  21 prefab demo vendor NOT_IN_BUILD.
- `project_oracle.py`: 7 package build chứng minh vắng khỏi manifest phục hồi (version không đổi để
  compile, §19); player settings 26 MATCH, 3 UNKNOWN (`iOSTargetOSVersionString` không được ghi — Info.plist
  nói 12.0; bundle id là `{}` ở cả source lẫn bản rip, Info.plist nói `io.heseri.blast`); 6 Facebook
  framework + bundle đã có trong bản rip; `libRF_CNative_ios.a` link tĩnh vào UnityFramework, không lấy lại
  được thành file.

## 5. Shader & Metal (§12–§15) — `reports/JELLYBLAST_SHADER_ORACLE.md`, `reports/JELLYBLAST_METAL_ANALYSIS.md`

780 MSL (336 vertex, 444 fragment, `xlatMtlMain`), 532 chương trình khác nhau, 384 parameter block,
0 `MTLB`. Source shader: 19 viết lại tay từ stand-in, 7 vẫn là stand-in, TMP là bản sao upstream. MSL so
với source: TMP 3/3 sampling agree (độc lập); Custom 9/18 khác — build là tham chiếu, source là bản chép.

## 6. Storage (§16–§17) — `reports/STORAGE_HAZARD_ANALYSIS.md` §7

TrueAlias không đổi (Impostor 1, JellyBlastV2 2). Lỗi storage mới tìm qua oracle độc lập, **chưa sửa**:
ghi qua `ref Color` ra gán lại ref.

## 7. Unity build và runtime (§23–§26) — `reports/UNITY_BUILD_VALIDATION.md` §5

Build request cho cả project source và project phục hồi: `UNITY_NOT_AVAILABLE`, discovery PASSED, bốn stage
NOT_REACHED, runtime NOT_RUN. 260 runtime scenario từ scene: `expected_state` 0/260 xác định, cần engine.
**BLOCKED**; không mô phỏng output Unity.

## 8. Số liệu (§26)

| Fixture | EXACT | Placeholder | Assembly-CSharp Roslyn (body pass) | Golden improved / regressed |
|---|---|---|---|---|
| Impostor | 4027 → 4042 | 4291 → 4301 | 237 → 237 | 2 / 3 (cùng ba cái của 062) |
| Merge-Room | 11184 → 11221 | 25580 → 25697 | 6 (2) → 5 (1): CS0052 hết, còn CS0102 che thân | 2 / 1 (MMFeedbacks, như 062) |
| RunFromZombies | 2785 → 2785 | 4578 → 4581 | 7 → 7 | 0 / 0 |
| JellyBlastV2 | 3014 → 3027 | 36304 → 36383 | 21 (10) → 11 (**3038**) | 9 / 0 |
| Pinata | 12526 → 12533 | 12974 → 12990 | 1432 → 1355 | — |

Placeholder tăng nhẹ ở mọi fixture là **MEASUREMENT_CHANGE**: V của FCMP giờ đọc toán hạng hai lần
(`b == b`), và một load không giải quyết đã gập vào toán hạng được báo lại; không có gì mất. Số JellyBlastV2
Roslyn tăng vì lần đầu nó đo được thân — số trước là số lỗi khai báo.

## 9. Bất biến (§32)

| Bất biến | Kết quả |
|---|---|
| `generatorFailures = 0` | 0 trên cả năm |
| field-layout disagreement = 0 | 0 trên cả năm |
| layout mismatch khi đọc MonoBehaviour | 0 trên cả năm (mới đo) |
| RunFromZombies behaviour oracle không lùi | 1.0000 (35/35) |
| reference graph true mismatch không tăng | JellyBlast so với derivation root 1.0000; lỗi quy cho phục hồi 0 |
| không bịa runtime PASS | runtime `NOT_RUN` ở mọi nơi |
| golden corpus | không đóng băng lại; các regression còn lại là ba cái 062 đã đọc và MMFeedbacks |
