# Iteration 061 — native cross-oracle, Unity build pipeline, và bốn tầng nơi nghĩa binary khác nghĩa phục hồi

Nhãn: `PROVEN` (suy ra được từ binary, metadata hoặc source), `MEASURED` (số đo trên một bản rip cụ
thể), `INFERRED`, `UNKNOWN`, `BLOCKED`.

## Tóm tắt

Brief yêu cầu chuyển từ "native decompiler" sang "Unity project recovery + validation pipeline", với
`radareorg/r2unity` làm oracle native độc lập và `game-ci/unity-builder` làm tham chiếu kiến trúc cho
build/validation. Không code nào của hai project được copy; cả hai được đọc, chạy (r2unity) và dùng
làm chuẩn so sánh.

Bốn lỗi dạng *nghĩa của binary ≠ nghĩa của bản phục hồi* được tìm ra và sửa ở tầng đầu tiên nơi hai
nghĩa khác nhau. Ba trong bốn không làm đổi một con số tổng hợp nào — chỉ phép đo mới của iteration
này thấy được chúng.

| # | Lỗi | Tầng | Thấy bằng |
|---|---|---|---|
| 1 | Bốn chỗ `ldloca` lấy thẳng local bịa ra thay vì hỏi luật lưu trữ; member đầu của một parameter `Vector3` đọc ra 0 | storage (`IlGenerator`) | diff + đọc source; mọi aggregate đứng yên |
| 2 | Bảng entry của shader blob segmented đọc với stride 8 thay vì 12; mọi program gán nhầm variant | đọc blob (`ShaderProgramProbe`) | kiểm ngữ nghĩa program với source TMP |
| 3 | Pinata không rip được từ iteration 057 (`KeywordNames` không tồn tại trước 2021, exception kết thúc process) | đọc cấu trúc shader | chạy lại fixture thứ năm |
| 4 | Material vẽ bằng base variant trong khi keyword của nó chọn variant khác | export ShaderLab | `shader_variant_binding.py` — đo, chưa sửa |

## 1. Native cross-oracle (§4–§8) — `reports/NATIVE_CROSS_ORACLE.md`

LibCpp2IL (`AR`, ghi ra qua `CPP2IL_DUMP_NATIVE_FACTS`), một reader viết mới không chung code
(`READER`, `Test/Scripts/il2cpp_native_reader.py`) và r2unity (`R2UNITY`, commit `60267a76`, radare2
6.2.3). **`PROVEN`: trên bốn fixture, 227.215 method entry, 143.133 field offset, 34.095 type size và
209.562 generic entry, AR = READER tuyệt đối, không một DISAGREE.**

Mọi DISAGREE của r2unity có nguyên nhân: nó nối method theo thứ tự hàng thay vì `methodPointers[rid-1]`
(`R2UNITY_SEQUENTIAL_SCATTER`, 0 chưa giải thích), và trọng tài thứ ba — lệnh đầu của getter
auto-property phải load đúng offset của backing field — chọn READER ở mọi trường hợp phân biệt được,
r2unity ở 0. r2unity cũng không áp relocation ELF (`R_AARCH64_RELATIVE`), nên trên Android nó chỉ độc
lập ở phép join; trên JellyBlastV2 (Mach-O) nó độc lập hoàn toàn và kết quả giống hệt.

`AR_INTERPRETATION` (3044–6570 mỗi fixture): definition không có body riêng được LibCpp2IL gán body
của một instantiation. Là diễn giải có chủ đích; được giữ riêng, không sửa. Value-type frame: không
một instance field value type nào có raw offset dưới header trên cả bốn fixture.

## 2. Unity build provider (§13–§17)

`AssetRipper.Validation.Unity` + `AssetRipper.Tools.UnityBuildValidator`: `IUnityBuildProvider`
(Local, Docker, Unavailable), `BuildRequest` lấy version từ `ProjectVersion.txt`, editor script
`RecoveredBuildValidation.BuildPlayer()` cài vào project lúc build và gỡ sau, `UnityLogClassifier`
phân loại theo bằng chứng trong log (không map mọi exit khác 0 thành compile failed),
`RecoveredProjectFingerprint`, cache theo `(UnityVersion, Platform, ProjectFingerprint,
PackageLockFingerprint)` và không bao giờ cache `UNITY_NOT_AVAILABLE`. 14 test. Container này không có
Unity: `iterations/061/unity-build-RunFromZombies.json` ghi `UNITY_NOT_AVAILABLE`, level `BLOCKED`.

Bẫy ghi lại: MSBuild đọc `X.cs.txt` là culture `cs` (tiếng Séc) và đưa resource vào satellite assembly;
template được đổi tên `.template` và đặt `WithCulture="false"`.

## 3. Serialized reference graph + script binding (§11–§12) — `reports/SERIALIZED_REFERENCE_GRAPH.md`

`Test/Scripts/serialized_reference_graph.py` dựng `Scene → GameObject → Component → field → target`
ở cả source và recovered, mở rộng prefab instance phía source và so theo identity ngữ nghĩa. **Trên
ba game có source: 1356 GameObject, 0 thiếu; 0 component thiếu hay thừa; 169/169 script decidable
BOUND_EXACT; 0 reference trỏ sai object.** Khác biệt thật duy nhất:
`FixInvalidFileNameCharacters` đổi tên `AudioClip` (dấu phẩy thành `_`) theo danh sách ký tự của hệ
điều hành đang chạy export.

Ba sửa đổi phép đo, mỗi cái đọc giống một lỗi recovery: stripped document là authority chứ không phải
phép XOR (scene được nâng cấp từ format cũ); root của prefab asset mang tên file; sprite sheet từ 2021
ghi tên trong `nameFileIdTable`.

## 4. StorageIdentity (§10) — `reports/STORAGE_IDENTITY.md`

**Lỗi 1.** `IlGenerator` khai báo IL local cho mọi lifted local kể cả parameter, và bốn chỗ lấy thẳng
`locals[...]`. `ObscuredVector3.Encrypt(value)` mã hoá `x` thành 0; `Vector3Plugin` của DOTween tính
`x` từ `default(Vector3)`. Impostor 30 file, Merge-Room 161, JellyBlastV2 46 đổi; mọi thay đổi là một
`default(...)` biến mất (134/562/217) — EXACT, placeholder và Roslyn đứng yên tới từng chữ số.
RunFromZombies 0 file. Một test đọc source generator giữ bất biến: chỉ ba helper được index map đó.

`StorageIdentity` (kind, alias group, frame, def/use, address-taken, escapes) xây trên
`LocalStorage.For`. Hazard — một vị trí máy nằm ở nhiều chỗ IL khi địa chỉ bị lấy: 22 / 103 / 68 / 81
(Impostor / RunFromZombies / Merge-Room / JellyBlastV2). UNKNOWN, chưa sửa.

## 5. Shader (§21–§22) — `reports/SHADER_VARIANT_BINDING.md`

**Lỗi 2.** Entry của blob segmented là `(offset, length, segment)`. Probe đọc cặp 8 byte, nên chỉ
một trong ba entry đúng. Layout giờ do chính bảng quyết định (program đầu phải bắt đầu ngay sau bảng).
Impostor: program source 231 → 484/759, "variant bị strip" 457 → **0**; Merge-Room 194 → 412, 291 → 0.
TMP: 12/12 variant khớp source (`_UnderlayColor` đúng dưới `UNDERLAY_ON`, `discard` đúng dưới
`UNITY_UI_ALPHACLIP`). Oracle shader cho kết quả **giống hệt** trước và sau: nó gộp operation của mọi
program nên mù với việc gán nhầm variant.

**Lỗi 3.** Pinata (2019.2) exit 134 từ 057. `TryExport` giờ rơi về canned pass khi không đọc được cấu
trúc; `KeywordsKnown` ghi `null` thay vì rỗng (rỗng biến mọi variant thành base).

**Lỗi 4, đo chưa sửa.** ShaderLab export mang một `GLSLPROGRAM` mỗi pass, không có directive keyword:
4/9 (Impostor) và 6/30 (Merge-Room) binding material vẽ bằng base variant trong khi keyword của chúng
chọn variant khác.

`ICompiledShaderProgram`: GLSL / Metal (BinaryOnly) / DXBC / SPIR-V / Unknown / Stripped; chỉ GLSL mang
được text, theo cấu trúc.

## 6. Runtime contracts (§18–§20) — `reports/RUNTIME_CONTRACTS.md`

`runtime_snapshot.py`: schema `assetripper.runtime-snapshot/1`, khoá không có instance ID. Initial
state source vs recovered: 0.9975 / 0.9963 / 0.9924 bằng nhau. `lifecycle_contract.py`: 423 class, 886
message, 0 khác biệt đã quyết định; 2 dưới branch không quyết định được. `source_preprocessor` học
`project_defines` (scripting define của player, `versionDefines` của asmdef theo manifest) và chế độ
`undecided="drop"` làm cận thứ hai.

## 7. Interface lookup (§23) — chỉ phân loại, không xoá

`InterfaceScanRegionClassifier`: vùng quét = slice xuôi từ mọi lệnh đọc `interface_offsets_count` /
`interfaceOffsets`; chết khi không giá trị nào tới một effect và mọi branch hội tụ về đúng một block
qua các block chỉ chứa vùng. Không gì bị xoá. `reports/INTERFACE_SCAN_REGIONS.md`.

**`MEASURED`**: Merge-Room 869 vùng — 88 chết đã chứng minh, 189 branch phân kỳ, 592 giá trị thoát ra
effect; Impostor 78 — 26 / 2 / 50. Trong 592: **340 là indirect call qua chính slot vùng tính ra**,
tức một interface dispatch chưa bao giờ được giải quyết. Kết luận của 060 ("vùng sống sót là
scaffolding sau lời gọi đã giải quyết") đúng cho method nó đọc và sai cho phần lớn tập.

Một lỗi của chính walker được tìm ra khi đo: `Add v, v, 16` dùng một object local ở cả vị trí đích và
nguồn, và bỏ qua mọi operand bằng đích làm lệnh tăng "không đọc gì" — bước lặp rơi khỏi vùng của nó.
`StorageIdentities.Analyze` có đúng lỗi đó; cả hai giờ chỉ bỏ vị trí đích.

## `BLOCKED`

Không có Unity: không build, không runtime, không `PROJECT_BUILD_VALIDATED`, không `RUNTIME_VALIDATED`.
