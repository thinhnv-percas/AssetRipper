# AssetRipper Python Port — Roadmap & Trạng thái

File này là **nguồn sự thật duy nhất** về tiến độ port AssetRipper (C#) sang Python.
Mọi agent/session làm việc trên project này đọc file này trước, và tự tick checkbox sau khi xong.

- **Branch:** `claude/convert-project-python-6mee7g`
- **Trạng thái:** Phase 1-12, 14, 15 xong, Phase 13 và 16 đang làm (13a/13b/13h xong, 13c một
  phần, 13d/13e/13f/13g/13i đã rà soát và đánh dấu `[~]` với lý do cụ thể — xem PHẦN B; 16a+16b+16c
  xong, 16f phần 1 (dựng `SerializableType` thật từ Mono `.dll`, gồm PPtr detection + kế thừa
  nhiều cấp) cũng xong — nhưng **chưa nối vào pipeline export** (16f phần 2: `GameAssetFactory`/
  `script_exporter`/`GameStructure` chưa gọi tới), xem 16f).
  **Phase 17 viết lại xong (17a-17e, xem ngay dưới) — chỉ còn 1 test đối chiếu GUI-mức-thật dời
  lại xong; Phase 19 (bug thật user đang gặp) đã sửa xong 19a-19d; Phase 18's Mesh layout xong.**
  748 tests pass. Commit cuối: `(pending)`.
- 🟡 **LẦN ĐẦU CÓ FIXTURE UNITY THẬT (2026-08-01), phát hiện quan trọng nhất từ trước giờ — xem
  Phase 18.** `python/input-test/demo-android.apk`/`demo-ios.ipa` (Git LFS) là build IL2CPP thật.
  Chạy full pipeline phát hiện: (1) 3 bug crash thật (đã sửa), và (2) **gap nghiêm trọng nhất project
  từng có**: build release **không có type tree nhúng**, và port này ban đầu **chỉ có hand-written
  layout cho 5 class** (Phase 2) — Texture2D/Sprite/Material/AudioClip/MonoBehaviour đọc ra rỗng
  (`UnknownObject`) dù pipeline không crash. **Cập nhật: 4/7 class ưu tiên đã có layout, byte-verified
  bằng chính fixture thật** (Texture2D/AudioClip/Sprite/Material) — export thật trên
  `demo-android.apk` giờ ra **105 PNG + 58 material + 11 audio thật** thay vì 0. MonoBehaviour (cần
  Phase 16 trước)/Mesh/Shader/BuildSettings còn lại. Xem Phase 18 chi tiết.
- ✅ **Phase 17 (viết lại) xong — 17a-17e.** Bản cũ (`37db9bf`) hiểu sai mục tiêu: "browse project
  **đã export xong**" (phải bấm Export ra thư mục trước). Mục tiêu đúng, giờ đã implement: **xem
  trước những file SẼ được export** — asset **và** code `.cs` — **ngay sau khi load game, không cần
  export ra đĩa**. `VirtualFileSystem` (17a, port sát từ chính `VirtualFileSystem.cs` upstream) +
  `ExportPlan` (17b, chạy `ExportHandler.export` thật vào VFS) + `routes/projects.py`/`/Project`
  (17c, đọc từ plan, render inline, banner trung thực bắt buộc) + bỏ nav link input-bundle-thô (17d)
  + 16 test mới + release gate (17e). Còn nợ lại, ghi rõ không giấu: 1 test đối chiếu preview-vs-export
  ở mức GUI thật với `demo-android.apk` (bất biến đã chứng minh 2 lần ở tầng thấp hơn — 17a, 17b), và
  rủi ro RAM khi Phase 18 làm xong nhiều class hơn (xem "Rủi ro riêng của Phase 17" mục 2).
- ✅ **Phase 19 — GUI không nhận `.apk`/`.ipa` (bug user đang gặp) — đã sửa xong (19a-19d).**
  Root cause đúng như điều tra: engine đúng, GUI sai entry point (`/LoadFile` gọi `load_file`, không
  phải `load_paths`). `/LoadFile`+`/LoadFolder` giờ là alias của cùng một handler luôn gọi
  `load_paths`; `askopenfilename` thêm `filetypes` cho apk/ipa/obb/zip/assets/bundle; `load_file`'s
  trạng thái mâu thuẫn đã sửa; load giờ chạy background thread + progress bar (`/Load/Progress`),
  không còn treo browser 38 giây không phản hồi. Verify bằng cả apk giả (test, không cần LFS) và
  `demo-android.apk` thật qua chính Flask test client. Xem Phase 19.
- Texture2D/AudioClip/Mesh giờ export được cả khi payload nằm ở `.resS` ngoài (Phase 9) — điểm
  chặn fidelity lớn nhất **về input format** đã gỡ, nhưng không giúp gì nếu chính asset đó không có
  type tree để đọc field trước (xem Phase 18) — hai vấn đề độc lập nhau.
- Settings model thật đã có (Phase 10): image/audio/text/shader format và bundled-assets grouping
  không còn hardcode, `/Settings/Edit` là form thật.
- GUI giờ có Bootstrap vendored, asset preview tab (Image/Audio/Text/Yaml/Binary), file picker
  native, auto-open browser, progress bar export thật (Phase 11) — nhưng chưa có sidebar cây/tab
  Dependencies-Json riêng, xem phần "Còn lại" trong Phase 11.
- Scene/Prefab export thật đã có (Phase 12): GameObject/Component/Transform giờ gom vào một file
  `.unity`/`.prefab` duy nhất thay vì mỗi cái một `.asset` rời — đã verify bằng test đọc lại nội dung
  YAML xuất ra thật. Sẵn tiện phát hiện và sửa 1 bug có sẵn: `TypeTreeObject` thiếu `.name` khiến mọi
  asset xuất tên theo class name thay vì tên thật trong game (xem ghi chú trong Phase 12).
- ⚠️ **Audit 2026-08-01** (xem "Mục tiêu & Scope" ngay dưới) phát hiện 3 gap lớn chưa từng có trong
  roadmap: input format WebGL/WebPlayer/legacy bundle chưa đọc được (Phase 14), `ProjectSettings/*`
  chưa xuất đúng chỗ (Phase 15), và Phase 13 cần kế hoạch chi tiết từng type. Đã thêm vào PHẦN B.
- **Phase 15 xong** (cùng ngày, sau audit): `ProjectSettings/*.asset` giờ export đúng chỗ
  (`ManagerAssetExporter`/`ManagerExportCollection`), 7 manager rác (BuildSettings, PreloadData,
  AssetBundle, AssetBundleManifest, MonoManager, ResourceManager, ShaderNameRegistry) bị skip đúng
  cách thay vì export lẫn vào `Assets/`, và `UnknownObject`/`UnreadableObject` giờ dump raw byte thay
  vì YAML rỗng. `EditorBuildSettingsExportCollection` và `EngineAssets` vẫn `[~]` — xem Phase 15.
- **Phase 14 xong**: `scheme_reader.py` giờ đọc được GZip/Brotli-wrapped WebGL `.data`, WebFile
  container (`UnityWebData1.0`), bundle `UnityRaw`/`UnityWeb` (pre-Unity-5.0/WebPlayer), và Zstd-nén
  storage block — input coverage giờ khớp bảng "Mục tiêu & Scope" (mọi hàng ✅ trừ WebGL-theo-URL,
  hàng duy nhất còn ngoài scope). 2 dependency mới: `brotli`, `zstandard`.
- **Phase 13a/13b/13c/13h xong** (VideoClip, Sprite export, SpriteProcessor một phần,
  ScriptableObjectProcessor — xem PHẦN B), mỗi sub-phase một commit riêng. **13d/13e/13f/13g/13i đã
  rà soát kỹ và đánh dấu `[~]`** thay vì để `[ ]` treo: 13d/13e/13i bị chặn cứng bởi cùng một lỗ hổng
  kiến trúc ("dựng instance Unity thật từ đầu" — port này chỉ đọc theo layout có sẵn, chưa tổng hợp
  được layout mới); 13g bị chặn bởi đúng rào cản field-name-confidence port này đã tự đặt ra
  (`main_asset_processor.py`); 13f được sửa lại sau khi phát hiện ghi chú cũ sai (Cubemap thật ra
  dùng chung exporter Texture2D, không phải TextureArrayAssetExporter) nhưng hoá ra rủi ro hơn tưởng
  (field số-mặt không xác nhận được tên + Texture2DArray/CubemapArray/Texture3D cần bảng decode
  GraphicsFormat hoàn toàn mới) nên cũng không port lần này.
- 🆕 **Phase 16 — dựng lại `.cs` từ IL2CPP / Mono** đã có plan đầy đủ (16a-16g, xem PHẦN B). Thay thế
  3 hàng trước đây nằm trong "Ngoài scope vĩnh viễn". **Trần của việc này là declaration thật + method
  body rỗng** — không phải logic game chạy được; upstream và mọi tool trên thị trường cũng chỉ tới đó
  (có evidence trong phase). Khuyến nghị dừng ở mốc `16c-alt`: cho toàn bộ kết quả với ~15% effort,
  đổi lại user tự chạy Il2CppDumper ở ngoài.

---

## Mục tiêu & Scope input/output

**Mục tiêu:** input = **Unity** build → output = Unity project (C#) mở được bằng Unity Editor.

**Chỉ Unity — engine khác không nằm trong scope và không được tracking ở file này.** AssetRipper
upstream là tool Unity-only (README: *"a powerful tool for analyzing **Unity** game files"*, hỗ trợ
Unity `3.5.0`–`6000.5.X`); không có dòng C# nào trong 53 project để port cho engine khác, và output
cũng sẽ không phải Unity project — đó sẽ là một tool khác, không phải port này.

### Input format — trạng thái thật

| Input | Upstream C# | Port Python | Ghi chú |
|---|---|---|---|
| Unity game directory (Win/Linux/Mac/Android/iOS/Switch/PS4/WiiU/WinPhone) | ✅ | ✅ | 14/14 platform structure đã port (Phase 3) |
| `.assets` / `level*` / `globalgamemanagers` (SerializedFile) | ✅ | ✅ | Phase 1-2 |
| AssetBundle `UnityFS` (LZ4/LZMA/none) | ✅ | ✅ | Phase 2 |
| APK / OBB / XAPK / APKS / IPA / VPK / XAP / APPX | ✅ | ✅ | `zip_extractor.py`, giải nén rồi discovery như directory |
| `.resS` / `.resource` streamed data | ✅ | ✅ | Phase 9 |
| AssetBundle nén **Zstd** | ✅ | ✅ | Phase 14 — signature-sniff trước khi throw, đúng như C# |
| **Unity WebGL** (`.data`, `.data.unityweb`, `.datagz`) | ✅ | ✅ | Phase 14 — `WebFile`/GZip/Brotli scheme đã port |
| **WebPlayer bundle** (`UnityWeb`, `UnityRaw` pre-5.0) | ✅ | ✅ | Phase 14 — `BundleFiles/RawWeb` đã port |
| Game **pre-Unity-5.0** nói chung | ✅ | ✅ | Phase 14 — cùng format trên (`UnityRaw`/`UnityWeb` bundle) |
| Unity WebGL game **theo URL** | ❌ | ❌ | **Upstream cũng không có.** Không có `HttpClient`/`WebRequest` nào trong `AssetRipper.Import` hay `GUI.Web/Pages/Commands.cs` — chỉ `LoadFile`/`LoadFolder` từ path local. Muốn có thì phải tự viết downloader (tải `.data`/`.wasm` từ URL về temp dir rồi load như WebGL build) — **feature mới, không phải port** |
| `GameAssembly.dll` / `libil2cpp.so` + `global-metadata.dat` (IL2CPP) | ✅ | ❌ | **Phase 16** — đã *tìm thấy* đường dẫn cho cả 8 platform IL2CPP (Phase 3, `il2cpp_metadata_path`/`il2cpp_game_assembly_path`) nhưng **chưa parse**. Đây là input cho việc dựng lại `.cs` — xem Phase 16 |
| Managed `.dll` (Mono `Managed/*.dll`) | ✅ | ⚠️ | **Phase 16c+16f-phần1 ✅** — `mono_manager.py` đọc được metadata ECMA-335 thật (PE→CLI→tables→field signature) và ra cả `RecoveredType`/`RecoveredField` (16c) lẫn `SerializableType` thật đọc được bytes (16f phần 1, PPtr + kế thừa nhiều cấp), nhưng **chưa nối vào pipeline** (`GameStructure`/`GameAssetFactory`/`ScriptExporter` chưa gọi nó) — đó là Phase 16f phần 2, chưa làm. `mono_assembly_predicate.py` (chỉ nhận diện đuôi `.dll`) vẫn là con đường duy nhất `ScriptingBackend.MONO` thật sự đi qua hôm nay |

### Output format — trạng thái thật

| Output | Trạng thái | Ghi chú |
|---|---|---|
| `Assets/**/*.asset` + `.meta` (YAML) | ✅ | Phase 4 |
| Asset nội dung thật (`.png`/`.wav`/`.txt`/`.shader`/`.glb`/`.ttf`/`.ogv`) | ✅ | Phase 6, 9 |
| `.unity` (scene) / `.prefab` | ✅ | Phase 12 |
| `ProjectSettings/ProjectVersion.txt` | ✅ | Phase 7 |
| `Packages/manifest.json` | ✅ | Phase 7 |
| `Assets/StreamingAssets/**` | ✅ | Phase 7 |
| Script `.cs` (dummy class) + `.meta` GUID ổn định | ✅ | Phase 6c-2 |
| Script `.cs` có **declaration thật** (class/field/property/method signature) | ❌ | **Phase 16c ✅ đã đọc được** (Mono `.dll` → `RecoveredType`) **nhưng chưa export ra** — `script_exporter.py` chưa gọi 16c/16b, vẫn luôn dùng `EmptyScript`. Cần Phase 16f phần 2 để nối. IL2CPP (16d/16e) vẫn hoàn toàn chưa làm |
| MonoBehaviour **field value** khi asset không có type tree | ❌ | **Phase 16f phần 1 ✅ đã đọc được** (`get_serializable_type` dựng `SerializableType` thật, PPtr + kế thừa nhiều cấp, test đọc bytes thật qua `SerializableStructure`) **nhưng chưa nối** — `GameAssetFactory`/`UnloadedStructure` (phần 2) chưa gọi tới; các asset này vẫn rơi vào `UnknownObject` hôm nay. Giá trị thực tế **cao hơn** cả bản thân file `.cs` |
| **`ProjectSettings/*.asset`** (PlayerSettings, DynamicsManager, TagManager, …) | ✅ | Phase 15 — `ManagerAssetExporter`/`ManagerExportCollection` |
| Reference tới built-in Unity asset (default material, built-in shader…) | ❌ | **Phase 15 `[~]`** — `EngineAssetsExporter`/`PredefinedAssetCache` chưa xếp lịch (cần database asset built-in theo Unity version không vendored) → asset built-in bị export trùng thay vì trỏ về asset gốc của Unity |
| `.cs` có **method body thật** (logic game chạy được) | ❌ | **Ngoài scope vĩnh viễn** — với IL2CPP thì *không tool nào làm được tin cậy*, kể cả upstream (xem Phase 16g cho evidence). Với Mono thì cần một IL→C# decompiler cỡ ILSpy |
| **Xem trước file SẼ được export (asset + code `.cs`) ngay trong GUI**, không cần export ra đĩa | ❌ | **Phase 17 (đã viết lại)** — feature mới không có ở upstream. Bản `37db9bf` làm sai mục tiêu (browse project *đã* export); bản đúng: chạy exporter thật vào `VirtualFileSystem` rồi hiện cây + render nội dung từng file ngay sau khi load game |

---

## Giao thức tick cho agent

| Ký hiệu | Nghĩa |
|---|---|
| `- [ ]` | Chưa làm |
| `- [x]` | Xong, đã qua release gate, đã commit |
| `- [~]` | Cố ý bỏ scope — **bắt buộc** ghi lý do ngay sau dấu `—` |

**Quy tắc:**

1. Chỉ đổi `- [ ]` thành `- [x]` **sau khi** đã chạy xong release gate bên dưới và đã commit. Không
   tick trước.
2. Khi tick một phase, ghi commit hash vào dòng tiêu đề phase: `### Phase 8 — ... ✅ `abc1234``.
3. Khi phát hiện việc mới cần làm, **thêm checkbox mới** vào phase tương ứng thay vì làm im lặng.
4. Khi quyết định bỏ một item, dùng `- [~]` kèm lý do. Không xoá dòng — người sau cần biết đã bỏ gì
   và vì sao.
5. Cập nhật dòng **Trạng thái** ở đầu file (số test, commit cuối) mỗi lần commit.

### Release gate (chạy đủ trước khi tick)

```bash
cd python
python -m pytest -q                                   # phải pass 100%
rm -rf dist build *.egg-info && python -m build --wheel
python -c "import zipfile; print('\n'.join(zipfile.ZipFile('dist/assetripper_python-0.1.0-py3-none-any.whl').namelist()))" | grep <file_mới>
python -m venv /tmp/venv_check && /tmp/venv_check/bin/pip install --quiet dist/*.whl
/tmp/venv_check/bin/python -c "import <module_mới>; print('OK')"   # clean-room import test
pip install --quiet -e . && python -m pytest -q       # editable reinstall + chạy lại
git fetch origin claude/convert-project-python-6mee7g && git status -sb   # check divergence
```

Bước wheel-content check tồn tại vì đã từng suýt mất `scripts/__init__.py` — thiếu `__init__.py` thì
`setuptools.packages.find` **âm thầm** loại package khỏi wheel mà tests (chạy editable) vẫn pass.

### Kỷ luật code bắt buộc

- **Không fabricate.** Thà để gap trung thực còn hơn đoán. Mọi field name đoán, mọi sub-feature bỏ,
  mọi lựa chọn giảm fidelity đều phải ghi trong module docstring.
- **Phân biệt rõ** "verified" (ví dụ MD4 test vs RFC 1320 vectors) và "best-effort reconstruction"
  (ví dụ shape của `NativeFormatImporter`).
- **Docstring mở đầu mỗi module** ghi rõ port từ file C# nào, và cắt bớt cái gì.
- Test theo pattern có sẵn: `tests/import_/_tree_builder.py` (dựng TypeTree + binary payload bằng
  tay), `SerializedFileBuilder` + `ObjectInfo` + `SerializedType`.

---

## Tổng quan

| Phase | Nội dung | Trạng thái |
|---|---|---|
| 1 | Dynamic asset reader (TypeTree-driven) | ✅ `88ffc58` |
| 2 | Hand-written layouts cho file bị strip type tree | ✅ `670e2ac` |
| 3 | Game structure discovery (Platforms, GameStructure) | ✅ `17ebd0c` |
| 4 | YAML asset export + `.meta` + project driver | ✅ `395e0b7` |
| 5 | Essential processors | ✅ `789188a` |
| 6 | Content exporters (texture/shader/text/audio/script/mesh) | ✅ `e2841be`…`84cbf57` |
| 7 | Project scaffolding post-exporters | ✅ `fba6ba5` |
| 8 | Pipeline driver + wiring CLI/GUI | ✅ `86cca85` |
| 9 | Streamed data (`.resS`) | ✅ `404ce54` |
| 10 | Settings model + trang Settings | ✅ `1eaef6f` |
| 11 | GUI overhaul | ✅ `f9c9b80` (một phần — xem ghi chú) |
| **12** | **Prefab/Scene export (`.prefab`/`.unity`)** | ✅ `6b4fae3` (một phần — xem ghi chú) |
| 13 | Asset type còn thiếu (13a-13i) | 🟡 13a `25d7b0b`, 13b `19e3b0a`, 13c ⚠️ `93d591b` (một phần), 13h ✅ `c8093ba`. 13d/13e/13f/13g/13i `[~]` — đã rà soát, không port (lý do trong từng mục) |
| **14** | **Input format còn thiếu (WebGL/WebPlayer/pre-5.0/Zstd)** | ✅ `5cc200a` |
| **15** | **Exporter thiếu ảnh hưởng "project mở được"** | ✅ `994daee` (một phần — `EditorBuildSettingsExportCollection`/`EngineAssets` vẫn `[~]`, xem ghi chú) |
| 16 | **Dựng lại `.cs` từ IL2CPP / Mono** (16a-16g) | 🟡 Đang làm — 16a+16b+16c ✅ (16b `38a23cd`, 16a+16c `acd8e36`), 16f phần 1 ✅ `(pending)` (dựng `SerializableType` thật, PPtr + kế thừa). Đọc được Mono `.dll` thật nhưng **chưa nối vào export** (16f phần 2). `16d`/`16e` **bị chặn** tới khi có IL2CPP build thật |
| 17 | **Xem trước file SẼ được export (asset + code) ngay trên tool** (17a-17e) | ✅ 17a `a71bef0`, 17b `58a4f76`, 17c-17e `0cb790e` — 1 test GUI-mức-thật dời lại, xem chi tiết |
| 18 | **Fixture Unity thật đầu tiên: 3 bug crash + gap "build thật không type tree"** | 🟡 3 bug đã sửa `0e4c206`; layout Texture2D/AudioClip/Sprite/Material xong `d9494ec`; Mesh xong `8d12472`; MonoBehaviour/Shader/BuildSettings còn lại |
| 19 | **GUI không nhận input `.apk`/`.ipa`** (19a-19d) | ✅ `1e64fd3` — bug user báo đã sửa xong (19a-19d) |

Số test theo area (tổng 748): `export_modules` 135, `import_` 146, `io_files` 118, `numerics` 64,
`assets` 48, `export_unity_projects` 60, `gui_web` 71, `io_files_bundle` 29, `processing` 34,
`cli` 13, `yaml` 11, `export_configuration` 9, `configuration` 5, `real_fixtures` 5 (skip nếu chưa
`git lfs pull` file thật ở `python/input-test/`).

---

# PHẦN A — Đã làm (Phase 1-12)

### Phase 1 — Dynamic asset reader ✅ `88ffc58`

Bước mở khoá cả project: thay vì reproduce `AssetRipper.SourceGenerated` (354 class ID × một class
mỗi version range, sinh ra dưới dạng IL bởi toolchain 20k dòng từ package NuGet private), dùng
TypeTree-driven dynamic reader mà AssetRipper đã có sẵn nhưng chỉ dùng làm fallback.

- [x] `assetripper_serialization_logic/` — `primitive_type.py`, `serializable_type.py`, `mono_utils.py` (chỉ string overload)
- [x] `assetripper_io_endian/endian_span_reader.py` — code mới, không có counterpart C#; dùng `struct.Struct` + `unpack_from`, bulk-unpack array
- [x] `type_tree_node_struct.py` — shape predicates (`is_array`, `is_vector`, `is_map`, `is_pptr`, `align_bytes`, …), `try_make_from_type_tree`, `from_node_list`
- [x] `serializable_tree_type.py` — `from_root_node(root, mono_behaviour_structure=False)`
- [x] `serializable_value.py` / `serializable_structure.py` / `serializable_pair.py` — interpreter. Collapse struct 2-slot của C# thành một `value: Any`
- [x] `type_tree_object.py` — `SingleTypeTreeObject`
- [x] `game_asset_factory.py` — resolution order: embedded type tree → hand-written layout → `UnknownObject`
- [x] `class_id_type.py` — 354 members (artifact generated *duy nhất* có commit trong repo C#)
- [x] Field access API: `asset["m_Name"]`, `asset.get(name, default)`, `asset.fields`
- [~] `DoubleTypeTreeObject` — cần cặp release+editor tree, embedded tree không cung cấp

### Phase 2 — Hand-written layouts ✅ `670e2ac`

- [x] Layout builder + registry (`asset_creation/layouts/`)
- [x] `text_asset.py`, `game_object.py`, `transform.py`, `asset_bundle.py`, `mono_script.py`
- [ ] Còn thiếu layout cho: `Texture2D`, `Sprite`, `SpriteAtlas`, `Mesh`, `AudioClip`, `Font`, `VideoClip`, `Material`, `Shader`, `MonoBehaviour`, `ResourceManager`, `BuildSettings`, `PlayerSettings`, `TerrainData`, `AnimationClip` — plan gốc dự kiến ~20 type, hiện có 5. **Asset ngoài 5 type này, trong file bị strip type tree, sẽ thành `UnknownObject`.**

### Phase 3 — Game structure discovery ✅ `17ebd0c`

- [x] `platform_checker.py` + 13 platform subclass (Windows/Linux/Mac/Android/iOS/Switch/PS4/WebGL/WebPlayer/WiiU/WindowsPhone/Mixed)
- [x] `platform_game_structure.py`
- [x] `game_structure.py` — `load(paths, file_system, ...)`; assembly manager luôn `None`
- [x] `zip_extractor.py` (apk/zip → temp dir)
- [x] `GameBundle.from_paths` + `SerializedBundle.from_file_container`
- [x] `scheme_reader.load_file` wrapper
- [x] `assetripper_processing/game_data.py`
- [~] `EngineResourceInjector` / `VersionChanger` — không cần cho scope hiện tại
- [ ] **(audit 2026-08-01)** `GameInitializer.CustomResourceProvider.cs` chưa port — thiếu sót không
      được ghi nhận ở lần commit phase này
- ⚠️ **(audit 2026-08-01)** 14/14 platform structure đã port, nhưng lúc đó **discovery ≠ load được**:
      `WebGLGameStructure` tìm đúng `.data`/`.data.unityweb`/`.datagz` và `WebPlayerGameStructure` tìm
      đúng bundle, nhưng `scheme_reader` chưa có scheme để **đọc** chúng → load thất bại.
      **Đã sửa ở Phase 14** — scheme đọc được rồi, gap này không còn

### Phase 4 — YAML export + `.meta` ✅ `395e0b7`

- [x] `yaml_walker.py` + `asset_walker.py` — driven bởi `SerializableStructure.walk_editor()`
- [x] `meta.py` — `.meta` YamlDocument (honor `SOURCE_DATE_EPOCH` cho reproducible build)
- [x] `export_id_handler.py` — XxHash32/64 với seed, verified vs known vectors
- [x] `project_exporter.py` + `object_handler_stack.py` + `project_asset_container.py`
- [x] `export_collection.py` / `asset_export_collection.py`
- [x] Importers hand-written: `NativeFormatImporter`, `TextScriptImporter`, `ShaderImporter`, `MonoImporter`
- [x] `override_exporter_for_class_id()` — dispatch theo class ID, vì dynamic reader sinh ra **cùng một Python type** cho mọi asset nên type-based dispatch không phân biệt được TextAsset vs Texture2D
- [ ] Importer còn thiếu: `TextureImporter`, `TrueTypeFontImporter`, `AudioImporter`, `ModelImporter`, `VideoClipImporter`, `DefaultImporter` — hiện fallback về `NativeFormatImporter`
- [~] Multi-asset-per-file export overload — cần cho scene/prefab, xem Phase 12

### Phase 5 — Essential processors ✅ `789188a`

- [x] `i_asset_processor.py`
- [x] `SceneDefinitionProcessor`
- [x] `OriginalPathProcessor`
- [x] `MainAssetProcessor`
- [x] `EditorFormatProcessor`
- [ ] `PrefabProcessor` — **plan Phase 5 có ghi nhưng bỏ sót.** Xem Phase 12
- [~] 11 assembly processor — iterate `assembly_manager.get_assemblies()`, luôn rỗng ở port này → provably no-op
- [ ] `AnimatorControllerProcessor`, `AudioMixerProcessor`, `LightingDataProcessor`, `SpriteProcessor`, `ScriptableObjectProcessor` — xem Phase 13

### Phase 6 — Content exporters ✅ `e2841be` `aaade6e` `e9f837a` `51a34a4` `7ce13f6` `84cbf57`

- [x] **6a** Byte-passthrough: `TextAsset` (49), `Font` (128), `MovieTexture` (152) + blocklist `DangerousExtensions`
- [x] **6b** `Texture2D` (28) → PNG, qua `texture2ddecoder` + `Pillow`. `_decode_argb4444` viết tay vì Pillow không có rawmode
- [x] **6c-1** Shaders (48): `SimpleShaderExporter`, `DummyShaderTextExporter`, `YamlShaderExporter` + template copy verbatim + 2 Editor patch script
- [x] **6c-2** `MonoScript` (115): MD4 tự viết (verified vs 7 RFC 1320 vectors), `script_hashing`, `EmptyScriptExportCollection`, `SingleRedirectExportCollection`
- [x] **6c-3** `AudioClip` (83): magic-byte sniffing FSB5/IT/XM/S3M/MOD, raw dump
- [x] **6c-4** `Mesh` (43) → glTF/GLB: vertex stream decode + glb writer viết tay
- [x] `build_windows.bat` + `run_gui.bat`
- [~] FSB5 rebuild (PCM→WAV, Vorbis→OGG) — layout per-sample header không có tài liệu trong repo, đoán sẽ ra file hỏng im lặng
- [~] `CompressedMesh` — subsystem bit-packed riêng, không vendor đủ để decode tin cậy
- [~] Crunch texture — `AssetRipper.Conversions.Crunch` là native crnlib port
- [~] Shader decompile — **upstream cũng chưa implement**, nó fallback về DummyShaderTextExporter
- [~] Blend shapes, bind pose/skeleton hierarchy trong Mesh
- [~] Pre-2018 vertex channel layout (`vertex_format.py` chỉ target Unity >= 2019)
- ⚠️ **(audit 2026-08-01)** Port có **12 content exporter**, upstream có **~30**. Những cái thiếu ảnh
      hưởng lớn nhất **không** phải asset type lạ mà là 4 exporter hạ tầng: `ManagerAssetExporter`
      (mất `ProjectSettings/`), `UnknownObjectExporter`/`UnreadableObjectExporter` (asset không đọc
      được ra YAML rỗng thay vì dump byte), `DummyAssetExporter`. **Đã port ở Phase 15** (cùng ngày) —
      xem Phase 15 để biết chi tiết + 2 phần còn `[~]`

### Phase 7 — Post-exporters ✅ `fba6ba5`

- [x] `i_post_exporter.py`
- [x] `ProjectVersionPostExporter` → `ProjectSettings/ProjectVersion.txt`
- [x] `PackageManifestPostExporter` → `Packages/manifest.json`
- [x] `StreamingAssetsPostExporter` → `Assets/StreamingAssets` (tự recurse vì FileSystem API single-level)
- [x] `DllPostExporter` — no-op có chủ đích, assembly manager luôn `None`
- [x] `post_exporters.py` — `DEFAULT_POST_EXPORTERS` đúng thứ tự upstream
- [~] `PathIdMapExporter` — dump export-ID phục vụ debug, không phải project scaffolding

### Phase 8 — Pipeline driver + wiring ✅ `86cca85`

`ProjectExporter` trước phase này **chỉ được gọi từ test files** — không có production code path
nào chạy `load → process → export`, và GUI/CLI vẫn ở trạng thái Phase 0. Đây là bước nối, không thêm
tính năng mới.

- [x] `src/assetripper_export_unity_projects/export_handler.py` — `ExportHandler` với
      `load()`/`process()`/`export()`/`load_and_process()`/`load_process_and_export()`
- [x] `src/assetripper_processing/default_processors.py` — `SceneDefinitionProcessor` →
      `OriginalPathProcessor` → `MainAssetProcessor` → `EditorFormatProcessor`, đúng thứ tự upstream
- [x] `src/assetripper_cli/cli.py` — sub-command `inspect` (giữ back-compat khi gọi không có
      sub-command) + `export <input...> -o <output>`
- [x] `src/assetripper_gui_web/game_file_loader.py` — `load_paths(paths)` dùng `ExportHandler`,
      lưu `GameData` vào state (`has_game_data()`/`game_data()`); giữ `load_file` cho single-file browsing
- [x] `routes/commands.py` — `/LoadFolder` dùng `load_paths`; `/Export/UnityProject` gọi export thật
- [x] `templates/index.html` + `routes/home.py` — form Load Folder + Export (nội dung cũ nói pipeline
      chưa port, đã sai từ Phase 6-7, sửa luôn thay vì để tới Phase 11 vì nó active-wrong ngay sau khi
      wiring xong)
- [x] `tests/export_unity_projects/test_export_handler.py` — **test end-to-end đầu tiên của project**:
      ghi SerializedFile thật ra đĩa → `load_process_and_export` qua `MixedGameStructure` → assert
      `.txt`+`.meta` (TextAsset qua `TextAssetExporter` thật, không phải `.asset` generic) +
      `ProjectSettings/ProjectVersion.txt` + `Packages/manifest.json`
- [x] `tests/cli/test_cli_export.py`, `tests/gui_web/test_export_wiring.py`
- [x] Release gate + commit + push

**Phát hiện trong lúc làm:** `TypeTree.build_string_buffer()` phải gọi thủ công trước khi ghi tree ra
đĩa, nếu không offset chuỗi trong node.type/node.name vẫn là 0 và đọc lại sẽ `KeyError`. Mọi test
trước Phase 8 build `SerializedFile` thẳng trong memory (không ghi+đọc lại qua đĩa) nên chưa bao giờ
gặp path này — `test_export_handler.py` là test *đầu tiên* thật sự ghi bytes ra đĩa rồi đọc lại qua
`scheme_reader.load_file`, giống hệt cách CLI/GUI thật sự dùng. Không phải bug mới, chỉ là chưa có gì
kiểm tra path đó trước đây.

**Reuse:** `GameStructure.load()` tại `assetripper_import/structure/game_structure.py:78`,
`GameData.from_game_structure()`, `register_default_exporters()`, `run_default_post_exporters()`.

### Phase 9 — Streamed data (`.resS`) ✅ `404ce54`

Trước phase này cả 3 exporter binary lớn đều decline khi payload nằm ở file ngoài. Player build của
Unity để **gần như toàn bộ** texture/audio/mesh ở đó → trên game thật, export ra gần như rỗng. Nhỏ về
code, tác động lớn nhất trong toàn bộ roadmap.

- [x] `src/assetripper_import/streamed_resource.py` — `get_content(path, offset, size, collection)`,
      `check_integrity(...)`, cộng hai wrapper theo đúng field name mỗi struct dùng:
      `get_streaming_info_content` (`m_StreamData`: `path`/`offset`/`size`, không `m_` prefix) và
      `get_streamed_resource_content` (`m_Resource`: `m_Source`/`m_Offset`/`m_Size`, có `m_` prefix —
      một khác biệt thật giữa hai struct trong Unity, không phải lỗi đánh máy)
- [x] `export_modules/texture2d_exporter.py::_image_data_bytes` — fallback `m_StreamData` khi
      `"image data"` rỗng
- [x] `export_modules/audio_clip_exporter.py::_audio_data_bytes` — fallback `m_Resource`
- [x] `export_modules/meshes/mesh_data.py::get_mesh_data` — fallback `m_StreamData` cho
      `m_VertexData.m_DataSize`
- [x] `tests/import_/test_streamed_resource.py` — 11 unit test cho module core (offset slicing,
      overflow guard, resource không resolve được, 2 field-name shape)
- [x] `tests/export_modules/test_streamed_data_export.py` — 6 test end-to-end (Texture2D/AudioClip/
      Mesh × positive-với-ResourceFile + negative-resource-thiếu) qua `ProjectExporter` thật
- [x] Release gate + commit + push

**Không đổi so với dự kiến ban đầu:** không cần phân biệt `Offset_UInt32`/`Offset_UInt64` theo version
— Python int không có width cố định, đọc được giá trị nào từ dynamic reader thì dùng giá trị đó,
không cần biết nó từng là 4 hay 8 byte trên đĩa.

**Reuse:** `Bundle.resolve_resource(name)` tại `assetripper_assets/bundles/bundle.py:105` — đã xử lý
`fix_file_identifier` và tra ngược lên bundle cha, dùng thẳng không cần sửa gì.

### Phase 10 — Settings model + trang Settings ✅ `1eaef6f`

Trước phase này format ảnh/audio/text/shader bị hardcode trong `registration.py` (comment cũ trong đó
tự ghi nhận *"This port has no settings system"*), và `/Settings/Edit` là `stub.html`.

- [x] `src/assetripper_export_configuration/` — 8 enum port từ `Source/AssetRipper.Export/Configuration/`:
      `ImageExportFormat`, `AudioExportFormat`, `TextExportMode`, `ShaderExportMode`,
      `SpriteExportMode`, `TerrainExportMode`, `ScriptContentLevel`, `StreamingAssetsMode`
      (`BundledAssetsExportMode` đã có ở `assetripper_processing/configuration/`, reuse)
- [x] `ExportSettings` / `ImportSettings` / `ProcessingSettings` / `FullConfiguration` dataclasses —
      plain `to_dict`/`from_dict`/`save`/`load` qua stdlib `json`, **không** dùng
      `assetripper_configuration`'s `DataStorage`/`SingletonData` machinery (built cho một file settings
      hợp nhất nhiều record — overkill cho 3 dataclass nhỏ ở đây; xem docstring
      `full_configuration.py`)
- [x] `export_modules/registration.py` — `register_default_exporters(exporter, settings=None)`, chọn
      `DummyShaderTextExporter` vs `YamlShaderExporter` theo `ShaderExportMode`, và
      image/text/audio format theo settings tương ứng. Xoá được đúng cái comment *"This port has no
      settings system"* cũ trong file đó
- [x] `texture2d_exporter.py`/`text_asset_exporter.py`/`audio_clip_exporter.py` — nhận
      `ImageExportFormat`/`TextExportMode`/`AudioExportFormat` qua constructor. `AudioExportFormat`
      không đổi hành vi gì cả (xem ghi chú bên dưới)
- [x] `i_post_exporter.py` + 4 implementation + `post_exporters.py` — `settings=None` optional thêm
      vào cuối `do_post_export(...)`; `StreamingAssetsPostExporter` đọc
      `settings.import_settings.streaming_assets_mode == IGNORE` để bỏ qua copy StreamingAssets
- [x] `default_processors.py` — `run_default_processors(game_data, settings=None)` đọc
      `settings.processing_settings.bundled_assets_export_mode`; sửa luôn default riêng của
      `default_processors()`/`run_default_processors()` từ `GROUP_BY_ASSET_TYPE` (lệch so với upstream,
      tự để lại từ Phase 5/8) sang `DIRECT_EXPORT` (đúng default thật của upstream)
- [x] `export_handler.py` — `load()`/`process()`/`export()`/`load_and_process()`/
      `load_process_and_export()` đều nhận `settings=None`; `load()` suy ra
      `default_version`/`target_version`/`ignore_streaming_assets` từ `settings.import_settings` (chỉ
      khi `kwargs` chưa tự set — keyword argument luôn thắng)
- [x] `cli.py` — `export` subcommand có thêm `--config <settings.json>`, load qua
      `FullConfiguration.load()`
- [x] `game_file_loader.py` — state `settings()`/`set_settings()`, session-only (không persist ra
      đĩa), dùng bởi `load_paths` và `/Export/UnityProject`
- [x] GUI `/Settings/Edit` — form thật (`templates/settings.html`), GET render giá trị hiện tại, POST
      cập nhật state. Field cho enum port nhưng chưa consume (`SpriteExportMode`,
      `ScriptContentLevel`, `remove_nullable_attributes`, `publicize_assemblies`) vẫn hiện trên form,
      đánh dấu rõ "not yet consumed"
- [x] `tests/export_configuration/test_full_configuration.py` (9), `test_registration_settings.py` (4),
      settings-threading test trong `test_export_handler.py`/`test_streaming_assets_post_exporter.py`/
      `test_cli_export.py`, `tests/gui_web/test_settings_page.py` (4), audio constructor smoke test —
      21 test mới
- [x] Release gate + commit + push

**Quyết định trong lúc làm:**
- `TerrainExportMode` được giữ lại **không** làm field trên `ExportSettings` — grep upstream thật
  (`ExportSettings.cs`) thấy nó chỉ được dùng bởi 1 class dropdown GUI riêng
  (`TerrainExportModeDropDownSetting.cs`), không phải field thật. Giữ enum đứng riêng, không gán vào
  dataclass nào, tránh bịa ra một setting upstream không có.
- `AudioExportFormat` **không đổi hành vi export nào** trong port này: `PreferWav` upstream chỉ có
  tác dụng khi FSB5 rebuild ra `.ogg` (không rebuild FSB5 trong port này, xem `audio_clip_decoder.py`
  — `get_export_extension` không bao giờ trả `"ogg"`), nên nhánh đó là dead code không thể chạy tới.
  Vẫn wire tham số vào constructor cho đúng shape/để callers không phải chờ Phase 13, nhưng ghi rõ
  trong docstring đây là no-op thật, không phải bug.
- `ImportSettings.default_version`/`target_version` (`UnityVersion | None`) **không** có field trên
  form GUI — cần parser/validator version-string mà phase này không thêm; set qua JSON file +
  `--config` của CLI thay vì qua GUI.

**Reuse:** `assetripper_processing/configuration/bundled_assets_export_mode.py` (đã có từ Phase 5),
`GameStructure.load()`'s `default_version`/`target_version`/`ignore_streaming_assets` kwargs (đã có
từ trước phase này, chỉ cần truyền vào).

### Phase 11 — GUI overhaul ✅ `f9c9b80` (một phần — xem việc còn lại bên dưới)

Hiện GUI có 3 asset tab so với 12 của upstream; 4 trang là `stub.html`; không CSS framework; phải gõ
path bằng tay; không có progress. Phase này làm xong phần backend/wiring (progress, preview
endpoint, file picker, auto-open) và một layout Bootstrap thật, nhưng **không** làm sidebar cây +
toàn bộ 9 tab distinct như upstream — xem "Còn lại" bên dưới, tracked chứ không âm thầm bỏ qua.

- [x] Vendor `bootstrap.min.css` (v5.3.3, tải thật từ jsdelivr CDN lúc build, không phải gõ tay) +
      `LICENSE` vào `static/vendor/bootstrap/` — đã nằm trong `package-data` sẵn có (`static/**/*`)
- [x] `layout.html` — navbar Bootstrap thật (thay nav CSS tay), flash message thành `alert`,
      `data-bs-theme="dark"`. **Chưa làm:** sidebar cây bundle/collection — vẫn là link phẳng trong
      navbar, xem "Còn lại"
- [x] `src/assetripper_gui_web/asset_preview.py` — `render_asset(game_bundle, asset, export_version,
      register_exporters, settings)`: chạy asset qua `ProjectExporter` thật vào một temp dir rồi đọc
      bytes lại, thay vì viết lại logic encode riêng cho GUI (tái dùng nguyên Phase 6/9/10, không
      phải reimplement Texture2D/Audio/Text decode lần hai)
- [x] Endpoints mirror `Pages/Assets/AssetAPI.cs`: `/Assets/Image`, `/Assets/Text`, `/Assets/Yaml`,
      `/Assets/Binary` (`routes/assets.py`)
- [x] `templates/assets/view.html` — section "Preview": `<img>`/`<audio>`/`<iframe>` tuỳ class ID đã
      có exporter (Texture2D/AudioClip/TextAsset/Shader/Font/MovieTexture/Mesh), cộng link download +
      link Yaml cho asset không có content exporter riêng (rơi về `DefaultYamlExporter`). **Chưa
      làm:** tab Dependencies/Json riêng như upstream — xem "Còn lại"
- [x] `src/assetripper_gui_web/routes/dialogs.py` — `/Dialogs/File`, `/Dialogs/Folder` qua
      `tkinter.filedialog`; degrade về 404 `{"available": false}` khi không có display (verified
      thật trong CI — container test không có display, đúng path degrade cần test)
- [x] `templates/index.html` — nút "Browse..." gọi `/Dialogs/*`, tự điền input nếu có; im lặng
      không làm gì nếu 404 (input tay vẫn dùng được)
- [x] `assetripper-gui-web` tự mở trình duyệt sau 1s (đợi server sẵn sàng), `--no-browser` để tắt;
      `run_gui.bat` bỏ `start` cũ của chính nó (tránh mở 2 tab)
- [x] `ProjectExporter.export(..., progress_callback=None)` — gọi mỗi collection exportable; `
      create_collections()` public alias để `asset_preview.py` dùng chung logic gom nhóm
- [x] `ExportHandler.export/load_process_and_export` nhận `progress_callback`
- [x] GUI: `/Export/UnityProject` giờ chạy export trên background thread
      (`game_file_loader.start_export`), trả response ngay; `/Export/Progress` (JSON) cho
      `index.html` poll mỗi 500ms, progress bar thật
- [x] **Sửa nội dung sai** — làm sớm ở Phase 8 (không đợi Phase 11): `templates/index.html`,
      `gui_web/__init__.py`; refresh lại lần nữa ở phase này cho khớp Phase 9-11
- [x] Điền trang Licenses (danh sách dependency PyPI thật + Bootstrap, không bịa license chưa xác
      minh được — xem docstring `home.py`) / Privacy (verbatim upstream: "This app does not access
      the internet."), bỏ `stub.html` khỏi 2 trang này
- [x] Test Flask test-client: `test_asset_preview.py` (5), `test_dialogs.py` (2), `test_main.py` (2),
      cộng test progress trong `test_export_wiring.py` (4 mới), test nội dung Licenses/Privacy trong
      `test_flask_app.py` (2 mới) — 15 test mới cho riêng phần GUI, cộng 2 test `progress_callback`/
      `create_collections` trong `test_project_exporter.py`
- [x] Release gate + commit + push
- [~] Babylon.js 3D mesh preview — nặng vài MB vendored, `.glb` download đã đủ. Thêm sau nếu cần
- [ ] **Còn lại (chưa làm, không bịa là xong):** sidebar cây bundle/collection thật (hiện chỉ có
      navbar phẳng); tách tab Dependencies/Json riêng biệt như upstream (hiện gộp vào link
      "Download exported file" + Yaml); pass đổi toàn bộ template khác (`bundles/collections/
      resources/scenes/failed_files/search`) sang class Bootstrap `.table`/`.card` thay vì `<table>`
      thường (site.css có ghi chú rõ đây là nợ kỹ thuật tạm thời, không phải quên). **(audit
      2026-08-01):** sidebar cây **đầu ra** giờ có phase riêng — Phase 17 (đã viết lại: xem trước file
      sẽ được export). Sidebar cây **đầu vào** (bundle/collection): user đã chốt *"bỏ phần view loaded
      bundle cũng được"* → nợ này có thể **xoá thay vì trả**, xem Phase 17d để chốt xoá hẳn hay chỉ gỡ
      khỏi navbar

### Phase 12 — Prefab/Scene export ✅ `6b4fae3` (một phần — xem "Còn lại" bên dưới)

Trước phase này project export ra **không có scene hay prefab nào** — mọi GameObject/Transform/
Component ra file `.asset` rời rạc. Đây là phần coupling cao nhất trong roadmap: upstream dùng
generated typed property (`IGameObject`, `ITransform.Father_C4P`, ...), port này phải làm qua dynamic
field access (`asset.get("m_Father")`) — reimplementation thuật toán, không phải port 1:1 dòng-theo-dòng.

- [x] `src/assetripper_processing/prefabs/game_object_helpers.py` — reimplementation của
      `GameObjectExtensions`: `is_root`/`get_root`/`fetch_hierarchy`/`get_components`/`get_children`
      qua dynamic field access. Xử lý đúng 2 shape thật khác nhau của `m_Component`: struct
      `ComponentPair` (field `component`) từ type tree thật, vs `pair<int,PPtr>` (`.first`/`.second`)
      từ hand-written layout Phase 2 — verified bằng `TypeTreeNodeStruct.is_pair`'s structural check
      (`type_name == "pair"` cụ thể), không phải đoán
- [x] `game_object_hierarchy_object.py`/`scene_hierarchy_object.py`/`prefab_hierarchy_object.py` —
      port `GameObjectHierarchyObject`/`SceneHierarchyObject`/`PrefabHierarchyObject`. `Create()` xây
      hierarchy bằng cách walk từ root GameObject (`is_root` + `fetch_hierarchy`) thay vì switch theo
      generated interface như upstream — cùng kết quả, không cần phân loại "class ID nào là Component"
- [x] `synthetic_prefab_instance.py` — marker `PrefabInstance` tổng hợp cho GameObject rời (không có
      PrefabInstance thật). **Luôn** dùng style hiện đại (2018.3+, marker bị hidden khỏi YAML) bất kể
      version file gốc — xem docstring, quyết định fidelity có chủ đích
- [x] `prefab_processor.py` — port `PrefabProcessor.Process`, KHÔNG làm 2 nhánh:
      `AddMissingTransforms` (cần dựng Transform từ đầu, cùng loại gap `SceneDefinitionProcessor` đã
      từ chối) và "prefab có PrefabInstance thật sẵn" (cần field `RootGameObjectP` chưa xác minh được
      tên field thật) — cả 2 ghi rõ lý do trong docstring, không âm thầm bỏ
- [x] Wired vào `default_processors.py`, sau `EditorFormatProcessor`
- [x] `export_unity_projects/asset_exporter.py::export_assets` — multi-asset-per-file YAML overload
      (nhiều `--- !u!<ClassID> &<exportID>` document, một file), xoá được đúng câu docstring cũ ghi
      "not ported here"
- [x] `project/assets_export_collection.py` — `AssetsExportCollection`, base multi-asset kế thừa
      `AssetExportCollection` sẵn có (không viết lại machinery path/meta)
- [x] `project/scene_export_collection.py` — `SceneExportCollection` (kế thừa `ExportCollection`
      thẳng, không qua `AssetExportCollection` vì path đến từ `Scene.path` chứ không phải
      `get_best_directory()`), export ID theo đúng rule upstream (path_id thật nếu
      `SerializedAssetCollection`, ngược lại pseudo-random 32/64-bit theo version)
- [x] `project/prefab_export_collection.py` — `PrefabExportCollection` (kế thừa
      `AssetsExportCollection`), luôn dùng `PrefabImporter` (không có nhánh `NativeFormatImporter`
      pre-2018.3, khớp quyết định ở `synthetic_prefab_instance.py`)
- [x] `project/scene_yaml_exporter.py` — `SceneYamlExporter`, dispatch theo `asset.main_asset` (không
      phải class ID, vì `PrefabHierarchyObject` dùng lại đúng class ID `PrefabInstance` thật — class-ID
      dispatch không phân biệt được 2 cái); đăng ký trên `UnityObjectBase` trong
      `ProjectExporter.__init__`, tried trước `DefaultYamlExporter`
- [x] `project/default_importer.py`, `project/prefab_importer.py` — 2 importer hand-written mới
      (shape giống `TextScriptImporter`, best-effort từ hiểu biết chung về `.meta` thật)
- [x] `Bundle.scenes` property mới (`assetripper_assets/bundles/bundle.py`) — port trực tiếp từ
      `Bundle.cs`, cần cho `PrefabProcessor` duyệt hết scene
- [x] **Phát hiện + sửa trong lúc làm:** `TypeTreeObject` chưa có property `.name` — nghĩa là
      `get_best_name()`'s `getattr(self,"name",None)` fallback **chưa bao giờ hoạt động** cho asset
      đọc bằng dynamic reader, mọi file export tên theo `class_name` ("TextAsset.txt") thay vì tên
      thật trong game ("MyText.txt"). Phát hiện khi đặt tên `.prefab` xuất ra. Đã thêm
      `TypeTreeObject.name` (đọc `m_Name`), sửa 11 test hardcode tên sai theo bug cũ
      (`tests/{cli,export_unity_projects,gui_web}/test_*.py`) — xem
      `tests/import_/test_type_tree_object_name.py`
- [x] Tests: `tests/processing/test_prefab_processor.py` (3), `tests/export_unity_projects/
      test_scene_prefab_export.py` (2, end-to-end thật — xuất ra `.unity`/`.prefab` bằng
      `ProjectExporter` rồi đọc lại nội dung YAML), `tests/import_/test_type_tree_object_name.py` (2)
      — 7 test mới, cộng sửa 11 test cũ
- [x] Release gate + commit + push
- [ ] **Còn lại (chưa làm, không bịa là xong):** `AddMissingTransforms` (Transform-từ-đầu, edge case
      hiếm); prefab hoá cho `PrefabInstance` thật sẵn có trong scene (cần field `RootGameObjectP`
      chưa xác minh); `StrippedAssets`/`--- !u!1 &2 stripped` support (upstream cũng chưa dùng thật
      trong `PrefabProcessor.Process`, chỉ test code set — xem `game_object_hierarchy_object.py`
      docstring, không phải quên mà là "vốn dĩ chưa cần" ngay cả ở upstream); `IsSceneDuplicate` thật
      (hiện `is_scene_duplicate` luôn `False`)

---

# PHẦN B — Còn lại: Phase 13, 16, 17 (viết lại), 18, 19

Thứ tự đã làm: **Phase 15 → 14 → 13 → 17(sai mục tiêu) → 18**. Phase 15 (`ProjectSettings/`) và
Phase 14 (input format) đã xong, xem ghi chú trong từng phase bên dưới.

**Ưu tiên khuyến nghị (2026-08-01, sau khi có fixture thật + user feedback):**

1. **Phase 19** — GUI không nhận `.apk`/`.ipa`. Bug user **đang gặp**, đã điều tra xong, fix rẻ nhất
   trong danh sách này. Làm trước.
2. **Phase 18's gap chính** — hand-written layout cho Texture2D/Sprite/Material/Shader/Mesh/AudioClip.
   Không có nó thì trên **mọi** build release thật, export ra gần như không có asset nào — và Phase 17
   (xem trước output) cũng sẽ chỉ hiện ra một cây gần rỗng. Đây là thứ chặn giá trị thực tế lớn nhất.
3. **Phase 17 (bản viết lại)** — xem trước file sẽ được export, asset + code, ngay trên tool. Cần
   `VirtualFileSystem` (17a). Làm sau #2 thì mới có nội dung thật để xem.
4. **Phase 16** — dựng lại `.cs` từ IL2CPP/Mono metadata. Phase lớn nhất còn lại; là thứ duy nhất còn
   chặn "code của component phải thật" (hiện mọi script vẫn là dummy class). Cũng là thứ Phase 17 cần
   để tab code có nội dung thật thay vì stub.
5. **Phase 13** (13a/13b/13h ✅, 13c ⚠️ một phần, 13d/13e/13f/13g/13i `[~]`) — **không còn việc khả thi
   nào chưa làm**: mọi sub-phase đã hoặc port xong hoặc đánh giá và đánh dấu `[~]` với lý do cụ thể.

**Cập nhật tiến độ (2026-08-01, cùng ngày):** #1 (Phase 19) và #3 (Phase 17) đã làm xong theo đúng thứ
tự khuyến nghị ở trên. #2 (Phase 18's gap chính) đã làm một phần (4/7 class, xem Phase 18) trước cả khi
làm #3 — thứ tự thực tế lệch nhẹ so với khuyến nghị (làm 18 rồi 17 rồi 19, thay vì 19 rồi 18 rồi 17)
nhưng không ảnh hưởng kết quả vì các phase này độc lập nhau. Còn lại theo đúng khuyến nghị: #4 (Phase 16)
đang làm, #5 (Phase 13) đã xong không còn việc khả thi.

Đánh số giữ nguyên theo thứ tự thêm vào file (append-only, đúng giao thức tick) — số phase **không**
phải thứ tự làm.

### Phase 13 — Asset type còn thiếu ⬜

**Phát hiện quan trọng từ audit:** phần lớn type trong danh sách này **đã export được dưới dạng YAML
generic với đúng extension** qua `DefaultYamlExporter` + `_EXTENSION_BY_CLASS_ID`
(`export_collection.py`) — `AnimationClip`→`.anim`, `AnimatorController`→`.controller`,
`AudioMixer`→`.mixer`, `Cubemap`→`.cubemap`, `RenderTexture`→`.renderTexture`, `TerrainData`/`Sprite`→
`.asset`. Nên gap thật **hẹp hơn** danh sách cũ ngụ ý: không phải "chưa export được gì", mà là "thiếu
processor tái tạo lại quan hệ/nội dung nhị phân". Mỗi item dưới đây ghi rõ **hiện có gì / thiếu gì**.

#### 13a — VideoClip ✅ `25d7b0b`

- [x] `export_modules/video_clip_exporter.py` — port `Miscellaneous/{VideoClipExporter,
      VideoClipExportCollection}.cs`. Dùng lại `assetripper_import/streamed_resource.py` (Phase 9)
      cho `m_ExternalResources` (cùng shape StreamingInfo với Texture2D/Mesh's `m_StreamData`).
      Đăng ký cho cả 2 class ID cùng nghĩa "VideoClip" qua các version Unity: 327 và 329
      (`ClassIDType` không có `VideoClip` tên chung, chỉ `VideoClip_327`/`VideoClip_329` — cùng kiểu
      `AvatarMask_319`/`AvatarMask_1011`). Extension lấy từ `m_OriginalPath` (fallback `.bytes` nếu
      không có extension), khớp `GetExtensionFromPath` upstream
- [~] `VideoClipExportCollection.CreateImporter` (dựng `VideoClipImporter` thật với EndFrame/
      OriginalWidth/OriginalHeight/SourceFileSize/FrameRate/ImportAudio) — **không port**: generated
      importer class không có trong repo này. Fallback về `NativeFormatImporter` (base class), giống
      hệt cách `MovieTextureAssetExporter` đã làm — mở được trong Unity nhưng không có các setting
      importer riêng
- **Test:** 3 test mới (`test_video_clip_exporter.py`) — export bằng resource thật, fallback extension
  `.bytes` khi `m_OriginalPath` không có extension, và không export khi resource không resolve được
- **Release gate + commit:** xong

#### 13b — Sprite export (không kèm atlas math) ✅ `19e3b0a`

- [x] `export_modules/sprite_exporter.py` — port `Textures/YamlSpriteExporter.cs`: `Sprite` (213) →
      `.asset` YAML; `SpriteAtlas` (687078895) → **skip hẳn** qua `EmptyExportCollection` (đã có sẵn
      từ Phase 15, không cần port lại)
- [x] Đăng ký có điều kiện theo `export_settings.sprite_export_mode` (mặc định `YAML`, khớp upstream) —
      `NATIVE`/`TEXTURE_2D` chưa có exporter ảnh thật nên rơi về `DefaultYamlExporter`, ghi rõ trong
      docstring `sprite_export_mode.py` (enum này trước đây khai báo nhưng chưa ai đọc)
- **Test:** 3 test mới (`test_sprite_exporter.py`) — Sprite ra `.asset` đúng, SpriteAtlas không ra file
      nào cả, và cả hai cùng lúc chỉ Sprite được export
- **Effort/Risk thực tế:** đúng như dự đoán — thấp/thấp

#### 13c — SpriteProcessor (atlas coordinate recovery) ⚠️ `93d591b` — **làm một phần, xem giới hạn**

- [x] `processing/textures/sprite_coordinates.py` — port `SpriteExtensions.
      GetSpriteCoordinatesInAtlas` (~50 dòng math) như **pure function** trên tuple số thô (không
      đụng vào asset động) — cố ý tách riêng để test được bằng tay từng bước đúng công thức C#,
      độc lập với phần field-access dễ vỡ hơn. 5 test tính tay (identity, có crop, thiếu field pivot,
      thiếu field border, border-component-bằng-0-giữ-nguyên-0)
- [x] `processing/textures/sprite_processor.py` — port phần **an toàn** của `SpriteProcessor.cs`:
      clear `m_SpriteAtlas` PPtr + `m_AtlasTags` khi resolve được atlas thật (upstream làm việc này
      **vô điều kiện**, không phụ thuộc lookup RenderDataMap — lý do là tránh Unity Editor crash khi
      cố pack lại atlas đã pack, không liên quan gì tới độ chính xác rect/pivot/border); và chạy
      `get_sprite_coordinates_in_atlas` cho mọi sprite dùng chính `m_RD.textureRect`/
      `textureRectOffset` hiện có của sprite làm input (đúng bằng nhánh fallback "không resolve được
      atlas data" mà upstream tự có sẵn — không phải bịa thêm)
- **⚠️ CHỦ ĐỘNG KHÔNG PORT: recover `m_RD` từ `SpriteAtlas.RenderDataMap`.** Việc này cần khớp
      `sprite.m_RenderDataKey` (`pair<GUID, SInt64>`) với key trong `atlas.m_RenderDataMap` — tức là
      cần biết chính xác tên sub-field của struct `GUID` khi đọc động. Project này **đã từ chối đoán
      việc này một lần trước đó, với đúng lý do**: xem docstring `scene_definition_processor.py`
      ("`IOcclusionCullingSettings.SceneGUID` recovery is skipped... GUID sub-structure... sub-field
      names... aren't known with confidence here"). Đoán sai ở đây sẽ làm lệch rect/pivot/border của
      **mọi sprite trong atlas** một cách âm thầm — đúng rủi ro ROADMAP đã cảnh báo trước khi làm.
      **Hệ quả thực tế:** sprite thuộc atlas thật vẫn dùng `m_RD.textureRect` **gốc, chưa cắt theo
      atlas** làm input — với sprite không hề bị crop thật (không atlas, hoặc atlas không crop) thì
      công thức là identity (không đổi gì), nhưng với sprite **thật sự bị atlas crop** thì rect/pivot/
      border ra **sai** giống hệt như trước khi làm 13c. **Đừng tin output atlas-sprite của port này
      khi chưa có fixture Unity thật để so sánh**
- [~] `SpriteInformationObject`/`ObjectFactory` (xác định texture "chính" khi nhiều sprite share 1
      texture) — không port: đây là vấn đề tổ chức export (tên/collection của file PNG dùng chung),
      không phải tính đúng của riêng từng sprite. Để lại cho sau nếu cần
- **Test:** 8 test mới (`test_sprite_coordinates.py` 5, `test_sprite_processor.py` 3) — bao gồm 1 test
      chuyên biệt xác nhận reference tới atlas resolve được **đã bị clear** đúng
- **Đăng ký vào pipeline:** `SpriteProcessor` thêm vào `default_processors.py`, đúng vị trí upstream
      (giữa `EditorFormatProcessor` và `PrefabProcessor`)

**Kết quả rà soát 13d-13i (phiên này, trước khi code):** đọc lại toàn bộ 6 file C# nguồn
(`AudioMixerProcessor.cs` 317 dòng, `AnimatorControllerProcessor.cs` 168 dòng,
`ScriptableObjectProcessor.cs`/`ScriptableObjectGroup.cs`, `LightingDataProcessor.cs` (90/409 dòng
đầu), `TerrainYamlExporter.cs`/`TerrainYamlExportCollection.cs`, `TextureArrayAssetExporter.cs` 95
dòng + phần liên quan của `TextureConverter.cs`) trước khi quyết định làm cái nào. Kết luận: **3/6
bị chặn cứng bởi cùng một lỗ hổng nền tảng** (13d/13e/13i — xem "Rủi ro" bên dưới), **1/6 bị chặn
bởi đúng rào cản field-name-confidence port này đã tự đặt ra cho chính nó** (13g), **1/6 hoá ra
rộng và rủi ro hơn ghi chú cũ tưởng** (13f — sửa lại), và **1/6 khả thi thật, đã làm** (13h).

**Rủi ro nền tảng chung của 13d/13e/13i — "dựng asset Unity thật từ đầu":** cả ba đều gọi một biến
thể của "tạo mới một instance kiểu Unity thật, có field layout thật" (`processedCollection.
CreateAudioMixerEffectController()`, `VirtualAnimationFactory.CreateRootAnimatorStateMachine()`,
`processedCollection.CreateLightingDataAsset()`). Reader động (Phase 1-2) của port này chỉ đọc bytes
theo shape **đã biết trước** (type tree có sẵn) — nó không tổng hợp được một instance **mới toanh**
của một class sinh (generated) với field layout tự bịa. Đây là đúng lỗ hổng Phase 12's "Generated
Settings" `ProcessedAssetCollection` đã từng gặp và bỏ qua (xem `scene_definition_processor.py`'s
docstring) — không phải giới hạn riêng của 3 item này, mà là giới hạn kiến trúc chung của port. Cần
port trước một "instance-synthesis layer" (viết field theo layout tự chọn, không chỉ đọc theo layout
có sẵn) mới mở khoá được cả ba, việc đó lớn hơn hẳn quy mô một sub-phase Phase 13 đơn lẻ.

#### 13d — AudioMixer + AudioMixerProcessor `[~]` — chặn cứng, không port

- [~] `processing/audio_mixers/audio_mixer_processor.py` — port `AudioMixers/AudioMixerProcessor.cs`
      (317 dòng): dựng lại cây `AudioMixerGroup`/`AudioMixerSnapshot`/effect từ array phẳng.
      **Chặn cứng** bởi `processedCollection.CreateAudioMixerEffectController()` (dựng
      `IAudioMixerEffectController` — kiểu Unity thật — từ đầu) — xem "Rủi ro nền tảng" ở trên. Đoán
      field layout để tự dựng instance này sẽ ra file `.mixer`/effect controller **sai âm thầm** thay
      vì chỉ thiếu, đúng loại rủi ro port này đã từ chối nhận trước đây (Phase 12)
- [~] `export_modules/audio_mixer_exporter.py` — port `AudioMixers/AudioMixerExporter.cs` (24 dòng)
      — không port, phụ thuộc trực tiếp vào group/snapshot mà processor trên không dựng được
- **Hiện có:** `AudioMixer` ra `.mixer` YAML, nhưng group/snapshot/effect vẫn là asset rời không có
      quan hệ cha-con → mixer mở trong Unity sẽ rỗng/phẳng. **Không đổi** so với trước phiên này
- **Thiếu:** toàn bộ phần tái tạo cây — cần instance-synthesis layer trước (xem trên), không phải
      thiếu thời gian/effort

#### 13e — AnimatorController + AnimatorControllerProcessor `[~]` — chặn cứng, không port

- [~] `processing/animator_controllers/animator_controller_processor.py` — port
      `AnimatorControllers/AnimatorControllerProcessor.cs` (168 dòng). **Chặn cứng** bởi
      `VirtualAnimationFactory.CreateRootAnimatorStateMachine()` — dựng cây state machine/state/
      transition Unity thật từ đầu, cùng lỗ hổng "Rủi ro nền tảng" ở trên
- [~] `export_modules/animator_controller_exporter.py` — không port, cùng lý do
- **Hiện có:** `AnimationClip`→`.anim` và `AnimatorController`→`.controller` đều ra YAML đúng extension
      (**"AnimationClip" trong danh sách cũ coi như đã xong** ở mức YAML — nó không có exporter riêng
      ở upstream, cũng đi qua `DefaultYamlExporter`)
- **Thiếu:** state machine / state / transition — cần instance-synthesis layer, không phải effort

#### 13f — Cubemap / Texture2DArray (ảnh thật, không chỉ YAML) `[~]` — sửa lại ghi chú cũ, không port

- **Sửa một nhận định sai của ghi chú cũ:** đọc lại `ProjectExporter.Overrides.cs` (comment
      `OverrideExporter<ITexture2D>(textureExporter); //Texture2D and Cubemap`) và
      `TextureConverter.cs::TryConvertToBitmap(ITexture2D texture, ...)` cho thấy **Cubemap (89)
      KHÔNG đi qua `TextureArrayAssetExporter`** như ghi chú cũ viết — nó dùng đúng exporter/hàm decode
      của Texture2D, chỉ khác ở `Depth = texture.ImageCount_C28` (số mặt, thường 6) thay vì 1, và
      **không lật ảnh** (`if (texture is not ICubemap) bitmap.FlipY();`). `TextureArrayAssetExporter`
      chỉ thật sự áp dụng cho Texture2DArray(187)/CubemapArray(188)/Texture3D(117)
- [~] Cubemap: **không port**, dù ban đầu tưởng "gần như miễn phí" (dùng lại decode Texture2D có sẵn).
      Hai rào cản thật sau khi đọc kỹ `TextureConverter.cs`:
      1. Field cấp số mặt (`ImageCount_C28`) là **property sinh (source-generated)**, không tìm thấy
         field serialize gốc tương ứng trong source đã đọc được ở đây để xác nhận tên chắc chắn — đúng
         loại "tên field không biết chắc" port này đã từ chối đoán trước đó (xem 13g, `main_asset_processor.py`)
      2. Layout `Width×Height×Depth` phải decode **từng lớp** rồi ghép dọc thành 1 ảnh
         `Width×(Height×Depth)` (đã trace từ `DirectBitmap<T,U>.FlipY()`/`GetLayer()` — flip xảy ra
         **trong từng lớp**, không phải trên toàn ảnh) — cơ chế đã hiểu rõ, nhưng bytes-per-layer cho
         format nén (BC/ETC/ASTC) không có field `ActualImageSize`/`m_CompleteImageSize` tương ứng đã
         confirm trong port này để tính chính xác; đoán bằng `len(data)//depth` có thể sai khi có mip
- [~] Texture2DArray(187)/CubemapArray(188)/Texture3D(117): **không port** — các hàm C# tương ứng
      (`TryConvertToBitmap(ITexture2DArray/...)`) decode qua **`GraphicsFormat`**, một bảng switch
      hoàn toàn khác và chưa port (port này mới chỉ có bảng theo `TextureFormat` cũ, xem
      `texture_format.py`) — đúng như ghi chú cũ đã cảnh báo "cần native-decode-library uncertainty",
      chỉ là nó áp dụng cho *cả 3* class ID này, không phải Cubemap
- **Hiện có:** `Cubemap`/`Texture2DArray`/`CubemapArray`/`Texture3D` đều ra `.cubemap`/
      `.renderTexture`/... YAML đúng extension qua `DefaultYamlExporter` (metadata đúng, không có pixel)
- **Ghi chú:** `RenderTexture` (84) **không cần làm gì thêm** — nó là buffer runtime, không có pixel
      data trên đĩa; `.renderTexture` YAML hiện tại **đã là đúng và đủ**

#### 13g — TerrainData `[~]` — không port (field-name-confidence, cùng rào cản đã tự đặt ra)

- [~] `export_modules/terrain_exporter.py` — port `Terrains/TerrainYamlExporter.cs` (18 dòng) +
      `TerrainYamlExportCollection` (base class `AssetsExportCollection` đã có sẵn từ Phase 12, tái sử
      dụng được thật — không phải rào cản). **Rào cản thật:** nhóm heightmap/alphamap texture kèm theo
      cần field như `m_SplatDatabase.m_AlphaTextures` — `main_asset_processor.py`'s docstring **đã tự
      từ chối port đúng việc này** (`terrainData.GetSplatAlphaTextures`) với lý do "exact field
      layouts this port doesn't have confirmed". Đánh giá ban đầu của phiên này (tưởng "tin cậy vừa
      phải, làm được") đã bị **sửa lại** theo đúng tiền lệ nghiêm ngặt hơn đã có sẵn trong code — không
      đoán field name mới khi chính port đã từ chối đoán field đó một lần trước rồi
- **Hiện có:** `TerrainData`→`.asset` YAML (upstream cũng dùng `.asset`) — **đã gần đúng**, không đổi
- **Thiếu:** grouping heightmap/alphamap — cần field name chưa xác nhận được; `TerrainExportMode.MESH`/
      `HEATMAP` (enum đã declare ở Phase 10, chưa ai đọc) — cần tự sinh mesh, effort/risk cao hơn nữa

#### 13h — ScriptableObjectProcessor ✅ `c8093ba`

- [x] `processing/scriptable_object/scriptable_object_group.py` — port `ScriptableObjectGroup.cs`:
      marker asset gom root (TimelineAsset/PostProcessProfile) + children, `class_id=-1` (không phải
      ClassID thật) giống hệt Phase 12's `GameObjectHierarchyObject`/`PrefabHierarchyObject` — **đây
      chính là lý do 13h KHÔNG bị chặn bởi rào cản "dựng asset Unity thật" của 13d/13e/13i**: group
      không cần field layout Unity thật, chỉ là container gom nhóm nội bộ Python
- [x] `processing/scriptable_object/scriptable_object_processor.py` — port `ScriptableObjectProcessor.cs`
      (193 dòng): tìm `TimelineAsset`/`PostProcessProfile` qua `m_Script` PPtr → `MonoScript.m_Namespace`/
      `m_ClassName` (field chuẩn, cùng độ tin cậy `mono_script_info.py` đã dùng — không đoán mới); dò
      `m_Tracks`/`m_Parent`/`m_Clips.m_Asset`/`m_Markers.m_Objects`/`m_MarkerTrack` (Timeline) và
      `settings` (PostProcessProfile) qua truy cập field động (`asset.get(...)`), **tái hiện thuật
      toán** của upstream (không phải port nguyên văn `LoadStructure()`/`SerializableStructure` —
      xem docstring module để biết giới hạn thật: chỉ đọc được field khi serialized file có type tree
      nhúng thật, giống mọi helper động khác trong port này, ví dụ `game_object_helpers.py`)
- [x] `export_unity_projects/project/scriptable_object_group_export_collection.py` — port
      `ScriptableObjectGroupExportCollection` (nested class trong `ScriptableObjectGroupExporter.cs`):
      subclass `AssetsExportCollection` (Phase 12) — root làm asset chính, children làm extra, group
      marker tự thêm vào `assets` (để `ProjectExporter`'s "đã queued" logic không tạo collection thứ 2
      cho nó) nhưng **không** vào `exportable_assets` (không bao giờ serialize marker)
- [x] Đăng ký dispatch: mở rộng `scene_yaml_exporter.py` (đã tồn tại từ Phase 12, dispatch theo
      `asset.main_asset`'s Python type) thêm nhánh `ScriptableObjectGroup` — gộp 2 exporter class của
      upstream (`SceneYamlExporter`/`ScriptableObjectGroupExporter`) thành 1 vì port này vốn đã tổng
      quát hoá cơ chế dispatch-theo-main_asset dùng chung cho cả ba loại marker
- [x] **Sửa 1 bug thứ tự processor có từ Phase 13c:** `default_processors.py` từng liệt kê
      `SpriteProcessor` *trước* `PrefabProcessor`, ngược với thứ tự thật của upstream
      (`ExportHandler.cs` dòng 90-92: `PrefabProcessor` → `SpriteProcessor` → `ScriptableObjectProcessor`).
      Không có phụ thuộc chức năng thật giữa Sprite/Prefab (2 loại asset khác nhau) nên khả năng cao
      chưa từng gây lỗi quan sát được, nhưng giờ `ScriptableObjectProcessor` phải chạy sau cùng nên thứ
      tự đúng mới thành quan trọng — đã sửa lại đúng thứ tự upstream
- **Test:** 9 test mới — `test_scriptable_object_processor.py` (4: Timeline đầy đủ track/clip/marker/
      marker-track, PostProcessProfile, track không thuộc root nào bị loại, child share giữa 2 root
      thành nonunique và bị loại khỏi cả hai) + `test_scriptable_object_export.py` (1, end-to-end: 1
      file `.playable` duy nhất chứa cả 5 asset thay vì 5 file `.asset` rời)
- **Effort/Risk thực tế:** đúng như dự đoán ban đầu — trung bình/trung bình

#### 13i — LightingDataProcessor (làm cuối) `[~]` — chặn cứng, không port

- [~] `processing/lighting_data_processor.py` — port `LightingDataProcessor.cs` (409 dòng). **Chặn
      cứng** bởi `processedCollection.CreateLightingDataAsset()` — cùng lỗ hổng "Rủi ro nền tảng" ở
      trên, cộng thêm định dạng nhị phân "EnlightenData" riêng chưa từng đọc qua trong phiên này
- **Hiện có:** `LightingDataAsset`→`.asset` YAML rời — không đổi
- **Thiếu:** gắn lightmap/lightprobe vào scene tương ứng — cần instance-synthesis layer trước, cộng
      coupling với scene (Phase 12) và lightmap texture. Giá trị thấp nhất cho phần lớn dự án, đúng
      như ghi chú "để cuối" ban đầu — giờ có thêm lý do kỹ thuật rõ ràng để không làm, không chỉ ưu
      tiên thấp

- [x] Release gate + commit + push (mỗi sub-phase một commit riêng, đừng gộp) — 13h là sub-phase duy
      nhất trong nhóm 13d-13i thực sự port được; 13d/13e/13f/13g/13i đã đánh giá xong và đánh dấu `[~]`
      với lý do cụ thể thay vì để `[ ]` treo không rõ trạng thái

### Phase 14 — Input format còn thiếu (mở khoá WebGL / WebPlayer / pre-5.0) (commit `5cc200a`)

Xem bảng "Mục tiêu & Scope input/output" ở đầu file (đã cập nhật ✅). `scheme_reader.py` giờ đăng ký
đủ 8 scheme upstream có, đúng thứ tự (xem docstring của nó về gotcha `Stack<IScheme>` + `foreach` LIFO
của C#) — không còn format nào rơi về `ResourceFile` thô hay throw ngay khi gặp signature đã biết.

- [x] `io_files/compressed_files/gzip/` — port `CompressedFiles/GZip/{GZipFile,GZipFileScheme}.cs`.
      Dùng stdlib `gzip`. Mở khoá `.datagz` (WebGL Release build)
- [x] `io_files/compressed_files/brotli/` — port `CompressedFiles/Brotli/{BrotliFile,BrotliFileScheme}.cs`.
      Signature `"UnityWeb Compressed Content (brotli)"` detect bằng cách parse một phần header
      meta-block Brotli (port bit-for-bit từ C#, xem docstring `brotli_file.py`), không cần chạy decoder
      thật để sniff. **Dependency mới**: `brotli` (thêm vào `pyproject.toml`). Mở khoá `.data.unityweb`
- [x] `io_files/web_files/` — port `WebFiles/{WebFile,WebFileEntry,WebFileScheme}.cs`. Signature
      `"UnityWebData1.0"`. Container chứa các SerializedFile bên trong `.data` của WebGL build.
      Cần thêm `EndianReader.read_string`/`EndianWriter.write_string` (length-prefixed, không align) —
      chưa có trong port trước đây, chỉ có `read_string_zero_term`
- [x] `io_files/bundle_files/raw_web/` — port `BundleFiles/RawWeb/**` (`RawBundleFile` = `UnityRaw`,
      `WebBundleFile` = `UnityWeb`, `RawWebNode`, `BundleScene`). C#'s `RawWebBundleFile<THeader>`
      generic collapse thành 1 class cụ thể + cờ `_is_web_variant` (Python không cần generic).
      Mở khoá bundle pre-Unity-5.0 và WebPlayer bundle. Cần thêm
      `LzmaCompression.decompress_lzma_size_stream` (Web variant nén cả metadata+data cùng lúc, kèm
      8-byte size embedded — khác `decompress_lzma_stream` đã có từ Phase 1, vốn cần biết size trước)
- [x] `io_files/bundle_files/archive/` — port `BundleFiles/Archive/**` (`UnityArchive`). Upstream tự nó
      cũng chỉ nhận diện signature rồi `throw NotSupportedException()` khi đọc thật (xem
      `Archive/README.md`: *"I'm not certain that UnityArchive files exist..."*) — port giữ đúng fidelity
      đó: `can_read` nhận diện được, `read()` raise `NotImplementedError`
- [x] Zstd: `bundle_file_block_reader.decompress_blocks`'s nhánh cuối giờ thử `zstd_compression.is_zstd`
      trước khi throw, đúng như C#. **Dependency mới**: `zstandard`. Phát hiện và sửa luôn 1 bug có sẵn
      trong lúc làm: `storage_block_flags.get_compression_type` dùng `CompressionType(value)` strict —
      raise `ValueError` cho compression type ngoài enum (đúng trường hợp Zstd) thay vì trả về giá trị
      thô như C# enum cast (không strict); giờ trả về `int` nếu value không khớp member nào
- [x] Đăng ký hết vào `scheme_reader._schemes()` **đúng thứ tự upstream** — xem docstring, `SchemeReader.cs`
      dùng `Stack<IScheme>` + `foreach` (LIFO) nên thứ tự effective là **ngược** với thứ tự liệt kê trong
      code C#; tuple ở đây viết thẳng theo effective order đó
- [x] Test: 21 test mới — `test_gzip_file.py` (4), `test_brotli_file.py` (6, gồm cả test heuristic parse
      byte-by-byte vì không dựng được Brotli thật có đúng framing của Unity), `test_web_file.py` (3),
      `test_raw_web_bundle.py` (4, builder riêng `_raw_web_bundle_builder.py`), `test_archive_bundle.py`
      (3), `test_zstd_decompression.py` (1) + 1 test end-to-end
      (`test_scheme_reader.py::test_gzip_wrapped_web_file_recursively_discovers_the_embedded_serialized_file`)
      dựng "WebGL build giả" (SerializedFile → WebFile → gzip) và đọc lại đệ quy qua
      `scheme_reader.read_file` + `read_contents_recursively`
- [x] Release gate + commit + push
- [~] Unity WebGL game **theo URL** — **upstream không có**, đây sẽ là feature mới chứ không phải port.
      Nếu cần: thêm downloader tải `.data`/`.wasm`/`.framework.js` từ URL về temp dir rồi gọi
      `GameStructure.load` như WebGL build thường. Chưa làm vì (a) không có gì để port, (b) cần quyết
      định policy network (proxy, robots, rate limit) mà repo này chưa có tiền lệ

### Phase 15 — Exporter còn thiếu ảnh hưởng trực tiếp "project mở được" (commit `994daee`)

Nhóm nhỏ nhưng **impact cao nhất còn lại**: trước phase này, project export ra **mất toàn bộ
`ProjectSettings/`**.

- [x] `export_unity_projects/project/manager_asset_exporter.py` + `manager_export_collection.py` —
      port `Project/{ManagerAssetExporter,ManagerExportCollection}.cs`. Manager singleton xuất vào
      `ProjectSettings/<Name>.asset` với `GetExportID() == 1`, kèm 3 phép đổi tên upstream:
      `PlayerSettings`→`ProjectSettings`, `NavMeshProjectSettings`→`NavMeshAreas`,
      `PhysicsManager`→`DynamicsManager`. Không có interface `IGlobalGameManager` nên dùng
      `_GLOBAL_GAME_MANAGER_CLASS_IDS` hard-code (13 class ID phổ biến: TimeManager, AudioManager,
      InputManager, Physics2DSettings, GraphicsSettings, QualitySettings, PhysicsManager, TagManager,
      DelayedCallManager, NavMeshProjectSettings, NetworkManager, ClusterInputManager,
      UnityConnectSettings) + PlayerSettings (129, không có tên trong `ClassIDType` — xem docstring
      của `class_id_type.py`), cùng kiểu `_LEVEL_GAME_MANAGER_CLASS_IDS` ở
      `scene_definition_processor.py` đã làm. Docstring của `manager_asset_exporter.py` liệt kê rõ một
      nhóm manager hiếm/legacy (AnimationManager, NotificationManager, HaloManager,
      MasterServerInterface, UnityAdsManager, RuntimeInitializeOnLoadManager,
      CloudWebServicesManager, CloudServiceHandlerBehaviour, UnityAnalyticsManager,
      CrashReportManager, PerformanceReportingManager, NScreenBridge) **không** nằm trong danh sách
      này — game thật hầu như không dùng các subsystem đó, nhưng nếu có, asset sẽ rơi vào
      `Assets/<ClassName>/` thay vì `ProjectSettings/` thay vì bị bỏ sót âm thầm
- [~] `export_unity_projects/project/editor_build_settings_export_collection.py` — **chưa làm**:
      `EditorBuildSettingsExportCollection.cs` phụ thuộc "Generated Settings" collection mà
      `SceneDefinitionProcessor` hiện chưa tạo (xem docstring của nó), và `EditorBuildSettings` gần như
      không bao giờ xuất hiện trong player build đã build xong (nó là asset chỉ tồn tại lúc dev trong
      Editor) — giá trị thực tế cho use case "extract từ build đã ship" gần như bằng 0. Nếu một asset
      class 1045 vẫn xuất hiện, nó rơi vào `ManagerExportCollection` thường (đúng thư mục
      `ProjectSettings/EditorBuildSettings.asset`, chỉ thiếu phần patch GUID scene — chi tiết thẩm mỹ,
      không ảnh hưởng gì khác trong port này)
- [x] `export_unity_projects/raw_assets/` — port `RawAssets/{UnknownObjectExporter,
      UnreadableObjectExporter}.cs` + `{Unknown,Unreadable}ExportCollection.cs`. `UnknownObject`/
      `UnreadableObject` giờ dump raw byte vào `AssetRipper/{UnknownAssets,UnreadableAssets}/`, gate bởi
      `export_settings.export_unreadable_assets` (mặc định `False` → dùng `DummyAssetExporter` skip,
      không export gì cả, đúng hành vi mặc định của upstream)
- [x] `export_unity_projects/dummy_asset_exporter.py` — port `DummyAssetExporter.cs` +
      `EmptyExportCollection.cs` + `SkipExportCollection.cs`. Dùng cho 7 class `IGlobalGameManager`
      upstream dummy-export ở priority cao hơn `ManagerAssetExporter` (BuildSettings, PreloadData,
      AssetBundle, AssetBundleManifest, MonoManager, ResourceManager, ShaderNameRegistry — xem
      docstring `manager_asset_exporter.py`), và cho raw asset khi `export_unreadable_assets=False`
- [x] **Fix kèm theo, không có trong checklist gốc**: `project_exporter.py::_create_collection` trước
      đây luôn thử class-ID dispatch trước bất kể loại asset — nếu một `UnreadableObject` mang class ID
      trùng với class đã đăng ký exporter riêng (vd TextAsset=49), nó sẽ bị đưa nhầm vào
      `TextAssetExporter` (crash, vì `RawDataObject` không có field thật) thay vì
      `UnreadableObjectExporter`. Giờ `RawDataObject` luôn bỏ qua class-ID dispatch, đi thẳng vào
      type-based stack — có test regression riêng
      (`test_raw_asset_exporters.py::test_class_id_dispatch_is_bypassed_for_raw_data_objects`)
- [~] `EngineAssets/{EngineAssetsExporter,PredefinedAssetCache}.cs` (built-in Unity asset → trỏ về
      asset gốc của Unity thay vì export trùng) — **chưa xếp lịch**: `PredefinedAssetCache.cs` cần
      database asset built-in theo từng version Unity mà repo này không vendored (cùng loại rào cản
      Tpk database, xem "Ngoài scope"). Ghi lại ở đây để không ai tưởng là quên; nếu làm thì phải tự
      dựng database từ Unity Editor thật
- [x] Test (16 test mới: `test_manager_export.py` 7, `test_raw_asset_exporters.py` 4,
      `test_dummy_asset_exporter.py` 5) + release gate + commit + push

---

### Phase 16 — Dựng lại `.cs` từ IL2CPP / Mono ⬜ (16a+16b+16c+16f-phần1 ✅ — còn 16c-alt/16d/16e/16f-phần2, xem bên dưới)

> Phase này thay thế 3 hàng trước đây nằm trong "Ngoài scope vĩnh viễn" (C# script decompilation,
> IL2Cpp script recovery, MonoBehaviour field không có type tree). Chỉ **method body** còn ngoài
> scope — xem 16g.

#### Đọc cái này trước khi đọc plan: trần của việc này là gì

**Kết quả khả thi = declaration thật + method body rỗng.** Không phải logic game chạy được. Đây không
phải giới hạn của port này mà là giới hạn của toàn bộ state of the art:

| Tool | IL2CPP → C# đạt tới đâu | Nguồn |
|---|---|---|
| **AssetRipper (upstream)** | Declaration đầy đủ, method body **stub** (`return null;`, `return default(float);`). Cpp2IL *có* sinh được một phần method body nhưng upstream **tắt tính năng đó**: *"the method output frequency is not high enough to justify enabling that feature for use in AssetRipper"*, và ghi rõ sẽ còn vậy *"for the foreseeable future"* | [AssetRipper#74](https://github.com/AssetRipper/AssetRipper/issues/74) |
| **Cpp2IL** | Nhánh development chỉ fill method rỗng; method body recovery nằm ở nhánh legacy, platform-specific, chưa port sang ISIL | [Cpp2IL](https://github.com/SamboyCoding/Cpp2IL), [#223](https://github.com/SamboyCoding/Cpp2IL/issues/223) |
| **DevX-GameRecovery** | Cùng kiến trúc: metadata → DLL → decompiler ngoài (dnSpy, DecompilerFi) → import vào Unity project. Chỉ hỗ trợ **ARM64 (apk, ipa)**. Closed-source thương mại → tham khảo được *hình dáng sản phẩm*, không phải nguồn để port | [devxdevelopment.com](https://www.devxdevelopment.com/) |

Nên: **đừng hứa với ai là sẽ ra game chạy được.** Cái Phase 16 đổi lại là hai thứ cụ thể:

1. `.cs` có class/field/property/method **signature** thật → component trong `.unity`/`.prefab` bind
   được vào script thật thay vì dummy class.
2. **MonoBehaviour field value đọc được** trên game không có type tree (hiện rơi vào `UnknownObject`).
   Cái này giá trị **cao hơn** bản thân file `.cs`: nó làm data của component trở thành thật.

#### Không có gì để port — đây là implement mới

`grep AsmResolver\|Cpp2IL Source/AssetRipper.Import/AssetRipper.Import.csproj` → cả hai là
**PackageReference** (`AsmResolver.DotNet 6.0.1`, `AssetRipper.Cpp2IL.Core 1.0.8`), không vendored.
`ICSharpCode.Decompiler` cũng vậy. Nên khác mọi phase trước, Phase 16 **không phải port 1:1** mà là
implement file format từ spec công khai (Il2CppDumper / Il2CppInspector struct definitions, ECMA-335).
Cùng loại việc với bundle format ở Phase 2/14 — khác ở chỗ không có file C# nào trong repo để đối chiếu.

⚠️ **Trước khi copy struct definition từ repo tham khảo nào, check license của repo đó.** Implement
lại format từ tài liệu là một chuyện, copy code là chuyện khác.

#### Hai đầu dây đã có sẵn — chỉ thiếu đoạn giữa

| Đầu | Trạng thái |
|---|---|
| **Discovery** | ✅ Phase 3 đã resolve `il2cpp_metadata_path` + `il2cpp_game_assembly_path` cho **cả 8 platform IL2CPP** (Windows/Linux/Mac/Android/iOS/Switch/PS4 + `_has_il2cpp_files()`), và `gameStructure.assemblies` cho Mono |
| **Consumption** | ✅ `assetripper_serialization_logic.SerializableType`/`Field` + `SerializableStructure.read()` đã có từ Phase 1. **Dựng được `SerializableType` là MonoBehaviour đọc được ngay, không sửa gì downstream** |

Đoạn giữa còn thiếu: parse metadata → `SerializableType` → emit `.cs`.

#### Ràng buộc quan trọng nhất: cần **cả hai** file, không chỉ `global-metadata.dat`

| Bảng | Nằm ở đâu |
|---|---|
| type definition (namespace, name, flags, field/method range), field definition (name, **typeIndex**, flags), method definition, string heap, custom attribute table, default value | `global-metadata.dat` |
| **`Il2CppType[]`** — bảng mà *mọi* `typeIndex` trỏ vào | **binary** (`Il2CppMetadataRegistration`) |
| method pointer / RVA, generic inst table, codegen module | **binary** (`Il2CppCodeRegistration`) |

Chuỗi resolve một field: `field.typeIndex` → `binary.types[typeIndex]` → `Il2CppType{type, data}` →
với `IL2CPP_TYPE_CLASS`/`VALUETYPE` thì `data.klassIndex` → quay lại `metadata.typeDefinitions[]`.

**Hệ quả: 16d (metadata parser) một mình gần như vô giá trị** — không có binary thì không resolve được
kiểu của bất kỳ field nào, mà tên type thì `MonoScript` asset đã cho sẵn rồi (`m_ClassName`/
`m_Namespace`/`m_AssemblyName`, xem `mono_script_info.py`). Đừng ship 16d rồi tưởng là đã có gì.
Đây cũng đúng là lý do `web-global-metadata-parser` tự ghi *"without the binary (thus without address /
complete type info)"*. Nguồn cho phân chia trên:
[katyscode IL2CPP part 2](https://katyscode.wordpress.com/2020/12/27/il2cpp-part-2/),
[Il2CppDumper](https://github.com/Perfare/Il2CppDumper).

---

#### 16a — Serialization rules (`WillUnitySerialize`) — ✅ (gộp vào 16c, xem bên dưới)

- [x] Không port `field_serializer.py` riêng như dự tính ban đầu — đúng như ghi chú "gộp chung với
      16c" bên dưới đã cảnh báo. Một **tập con thực dụng** của `WillUnitySerialize` được implement
      thẳng trong `mono_manager.py` (16c), vì nó cần đúng "type universe" (bảng `TypeDef`/`Field`
      thật) mà tài liệu này đã xác định là điều kiện tiên quyết. Rule đã áp dụng: field bị loại nếu
      `static`/`const`/`[NonSerialized]`; field không public thì phải có `[SerializeField]` hoặc
      `[SerializeReference]` mới giữ; field tên chứa `<` (auto-property backing field do compiler
      sinh) bị loại
- **⚠️ Đã đơn giản hoá so với `FieldSerializer.Logic.cs` đầy đủ, ghi rõ trong docstring
      `mono_manager.py`:** không có version gate (struct từ 4.5, int8/16/uint16/32 từ 5.0,
      char/int64 từ 2017, generic từ 2020 — tất cả rule version-specific của upstream bị bỏ qua,
      field cứ đủ điều kiện cơ bản là được nhận bất kể version); không xử lý các case đặc biệt của
      `EngineTypePredicates.cs` (`IsDelegate`, `IsUnityEngineObject`, các built-in type như
      `AnimationCurve`/`LayerMask`, …) — field kiểu đó vẫn được emit, chỉ là không có nuance riêng
      của Unity cho chúng. Nhận định "không phụ thuộc gì" ở lần viết plan đầu tiên đã đúng là sai
      (xem lịch sử git của mục này) — bản 16a độc lập chưa từng được viết, đi thẳng vào 16c
- **Effort/Risk thực tế:** thấp hơn dự kiến ban đầu **chính vì** đã gộp vào 16c thay vì làm rời —
      không phải mock lại `RuntimeContext`, tra thẳng bảng thật
- **Phụ thuộc:** 16c (đã thoả)

#### 16b — Emitter `.cs` từ một type model trung lập ✅ `38a23cd`

- [x] `assetripper_export_modules/scripts/csharp_emitter.py` — nhận `RecoveredType`
      (`assetripper_import/structure/assembly/recovered_model.py`: namespace, name, base type,
      field name/type-text/visibility/attribute, `is_struct`) và sinh text C#. Không có method body
      (không có model cho nó — `RecoveredType` không mang method signature), đúng ceiling "declaration
      only" đã ghi ở đầu Phase 16
- [x] `RecoveredField.type_name` là text C# **đã format sẵn** (`"int"`, `"List<Foo>"`, …) do reader
      (16c/16d) tự quyết định — emitter không tự suy luận type text, giữ nó test được độc lập hoàn
      toàn không cần reader thật đứng sau, đúng như dự kiến
- [x] Generic mangled name (`` Foo`2 `` → `Foo<T1, T2>`) dùng lại `mono_script_extensions.is_generic`
      đã có sẵn từ Phase 6c-2, không viết lại
- [x] Giữ `EmptyScript` làm fallback khi không recover được type — chưa đổi gì ở đó
- **Test:** 9 test mới (`test_csharp_emitter.py` 6, `test_recovered_model.py` 3) — class/struct,
      có/không namespace, public/private field, nhiều attribute trên 1 field, generic, không field nào
- **Effort/Risk thực tế:** đúng như dự đoán — thấp/thấp, không phát sinh bất ngờ
- **Không phụ thuộc gì** — đúng như dự đoán ban đầu, khác với 16a

#### 16c — Nhánh Mono: đọc metadata .NET từ `.dll` ✅ `acd8e36`

- [x] `assetripper_import/structure/assembly/dotnet_metadata/` (package mới, 7 module): `pe_image.py`
      (DOS/COFF/optional header, section table, RVA→file-offset, định vị CLI header qua data
      directory 14), `heaps.py` (`#Strings`/`#US`/`#GUID`/`#Blob`), `compressed_integer.py` (ECMA-335
      II.23.2, cả dạng 1/2/4-byte), `table_ids.py` (layout cột khai báo cho **cả 38 table** 0x00-0x2C
      + toàn bộ 12 loại coded index của II.24.2.6, kể cả các bảng hiếm dùng như `FieldPtr`/`EncLog`
      để không có ẩn số nào khi tính kích thước cột), `tables_stream.py` (parser `#~`/`#-` hai lượt:
      đọc row count trước, rồi mới tính được kích thước cột phụ thuộc row count), `signature.py`
      (decode field signature blob → text C#: primitive, `CLASS`/`VALUETYPE`, `SZARRAY`,
      `GENERICINST`, `VAR`; `ARRAY` đa chiều và con trỏ chỉ có fallback text vì Unity không serialize
      chúng), `metadata_reader.py` (facade nối tất cả, cộng resolver cho `TypeDefOrRef` và
      `HasCustomAttribute` coded index)
- [x] `assetripper_import/structure/assembly/managers/mono_manager.py` — `read_assembly(data) ->
      MonoAssembly`, tra `TypeDef` ra `RecoveredType`/`RecoveredField` (16b); gộp thẳng rule
      `WillUnitySerialize` rút gọn của 16a vào đây (xem 16a để biết chính xác đã đơn giản hoá gì).
      Bỏ qua `TypeDef` là enum (base `System.Enum`) vì `RecoveredType` không mô hình được enum;
      nested type đọc được nhưng không nối lồng nhau về mặt cú pháp — mỗi cái vẫn là một
      `RecoveredType` top-level riêng, đủ dùng để 16f tra theo (namespace, class_name)
- **Không port `Assembly`/`MethodDef`/`Param`/`Constant`/`NestedClass`/`InterfaceImpl` sâu hơn mức
      cột thô** — bảng có đọc được (vì `table_ids.py` khai báo đủ cột để tính offset) nhưng
      `mono_manager.py` chỉ thật sự dùng `Module`, `TypeDef`, `TypeRef`, `TypeSpec`, `Field`,
      `MemberRef`, `CustomAttribute`, `GenericParam`, `AssemblyRef` — đúng tập tối thiểu để ra field
      declaration, không hơn (không có method body, xem 16g)
- **Test:** `tests/import_/test_dotnet_metadata.py` (17 test: compressed integer, 4 loại heap,
      signature decoder — primitive/string/array/class-ref/generic/`VAR`, cộng một module tối giản
      dựng bằng tay qua PE thật) + `tests/import_/test_mono_manager.py` (5 test end-to-end: struct
      công khai, enum bị loại đúng như thiết kế, generic type param tự resolve, đủ 5 rule
      `WillUnitySerialize` rút gọn trên một class giả lập `MonoBehaviour`, và emit ra `.cs` qua 16b
      để chắc chắn nối được đầu-cuối). `tests/import_/_module_builder.py` (mới) là bộ dựng byte PE
      hoàn chỉnh bằng tay — không có .NET SDK ở môi trường này nên không compile được `.dll` thật để
      so sánh, đúng như rủi ro ROADMAP đã lường trước
- **⚠️ Chưa test trên `.dll` thật nào** — không có Mono/.NET assembly thật trong repo hay
      `input-test/` (fixture IL2CPP hiện có không dùng Mono). Nếu sau này có `.dll` thật, nên thêm
      test đối chiếu trước khi tin cậy hoàn toàn kết quả trên game production
- **Effort/Risk thực tế:** đúng như dự đoán — khối lớn nhất trong phase (~750 dòng source, không
      tính test), nhưng đúng là "không có ẩn số": mọi chỗ khó (kích thước cột phụ thuộc row count,
      coded index tag bits, generic signature) đều có công thức rõ ràng trong spec, không phải đoán
- **Phụ thuộc:** 16a (gộp), 16b (đã có, `38a23cd`) — cả hai đã thoả

#### 16c-alt — Đường tắt: nhận dummy DLL do tool ngoài sinh ra ⭐ **khuyến nghị làm MVP**

- [ ] Cho `ExportHandler.load(...)` nhận thêm một directory chứa dummy DLL đã có sẵn (do user chạy
      Il2CppDumper / Cpp2IL / DevX ở ngoài), rồi đi thẳng vào 16c reader — **bỏ qua hoàn toàn 16d+16e**
- **Vì sao đáng làm trước:** đây chính là cách DevX-GameRecovery hoạt động (nó gọi decompiler ngoài),
      và nó cho **toàn bộ kết quả của Phase 16 với ~15% effort**. Đổi lại là user phải chạy một tool
      nữa bằng tay. Upstream cũng có đúng đường này: `ScriptContentLevel` + việc user tự cung cấp dll
- **Effort/Risk:** rất thấp/rất thấp một khi 16c xong (chỉ là thêm một input path)
- **Phụ thuộc:** 16c

#### 16d — IL2CPP: parser `global-metadata.dat`

- [ ] `assetripper_import/structure/assembly/il2cpp/metadata.py` — magic `0xFAB11BAF`, đọc
      `metadataVersion` rồi dispatch layout theo version. **Chốt một range version cụ thể** (đề xuất:
      24.0-31, phủ Unity 2018.4 → 2022+, tức đại đa số game đang ship) và ghi rõ trong docstring
      version nào *không* hỗ trợ, thay vì cố phủ hết 16-31
- [ ] Bảng cần đọc: string heap, `Il2CppImageDefinition[]`, `Il2CppTypeDefinition[]`,
      `Il2CppFieldDefinition[]`, `Il2CppMethodDefinition[]`, `Il2CppParameterDefinition[]`,
      generic container/param, interface + nested type index table, custom attribute table, default value
- **⚠️ Một mình không dùng được** — xem "Ràng buộc quan trọng nhất" ở trên. Chỉ ship cùng 16e
- **Effort/Risk:** trung bình/**cao** — nhiều version, layout thay đổi giữa các version, và
      **không có fixture thật để verify** (xem "Rủi ro riêng" bên dưới)
- **Phụ thuộc:** 16a, 16b

#### 16e — IL2CPP: parser binary + định vị `Il2CppMetadataRegistration`

- [ ] `assetripper_import/structure/assembly/il2cpp/binary/` — container parser. **Bắt đầu bằng
      PE (`GameAssembly.dll`) + ELF64 (`libil2cpp.so` arm64)** vì phủ Windows + Android arm64, hai
      target phổ biến nhất. Mach-O (iOS/Mac), ELF32, NSO (Switch), WASM (WebGL) để sau, mỗi cái một
      commit riêng
- [ ] Định vị `Il2CppCodeRegistration` + `Il2CppMetadataRegistration`: release build **không export
      symbol** cho chúng → phải scan heuristic qua section, đúng cách Il2CppDumper làm. Với v24.2+ có
      thêm `Il2CppCodeGenModule` làm mốc
- [ ] Đọc `Il2CppType[]` → hàm `resolve_type(type_index) -> RecoveredTypeRef` khép kín chuỗi resolve
      đã mô tả ở trên
- **Effort/Risk:** cao/**cao nhất trong phase** — heuristic scan là chỗ dễ sai nhất, và game mobile
      có anti-tamper thường **mã hoá/obfuscate `global-metadata.dat`**, lúc đó Il2CppDumper cũng fail
      (xem [tutorial của katyscode về obfuscated metadata](https://katyscode.wordpress.com/2021/02/23/il2cpp-finding-obfuscated-global-metadata/)).
      **Game obfuscated nằm ngoài scope Phase 16** — ghi rõ trong docstring, đừng cố
- **Phụ thuộc:** 16d

#### 16f — Wiring + MonoBehaviour field recovery (nơi giá trị thật xuất hiện)

**Phần 1 — `SerializableType` builder ✅ `(pending)`** (phần khó/rủi ro nhất: dựng đúng byte layout
từ metadata; phần 2 dưới đây, còn lại, chỉ là nối dây):

- [x] `mono_manager.py::MonoAssembly.get_serializable_type(namespace, class_name) ->
      SerializableType | None` — dựng thật một `SerializableType` graph (không chỉ text `.cs`)
      từ field signature blob, tái dùng đúng gating `WillUnitySerialize` đã có ở 16c
      (`_serialized_field_row_numbers`) thay vì viết lại
- [x] **PPtr detection thật**: field có kiểu (trực tiếp hoặc qua chuỗi `extends` trong CÙNG
      assembly) dẫn tới `UnityEngine.Object`/`MonoBehaviour`/`Behaviour`/`Component` →
      `SerializablePointerType.shared()`, đúng hành vi Unity thật (không inline object reference)
      — đây chính là phần `IsAssignableTo` walk mà 16a từng nói "không mock được", giờ mock được
      thật vì đã có type universe thật (16c)
- [x] **Kế thừa nhiều cấp trong cùng assembly**: field của lớp cha (cũng local) được gộp vào theo
      đúng thứ tự Unity thật (cha trước, con sau) — `_local_base_chain`. Đây là mảnh giá trị nhất
      của 16a mà bản RecoveredType/.cs (16c) không cần tới (vì .cs không redeclare field kế thừa)
- [x] `List<T>` được nhận diện là mảng 1 cấp (đúng cách Unity serialize nó thật)
- [x] `assetripper_import/structure/assembly/managers/unity_engine_structs.py` (mới) — layout
      cứng cho 7 struct built-in **chắc chắn nhất** (Vector2/3/4, Quaternion, Color, Color32,
      Rect — tên field đã được xác nhận độc lập qua `_tree_builder.py`'s `rect_nodes`/
      `vector2_nodes`/`vector4_nodes` cho 4/7 cái). **Cố ý không** làm 13 cái còn lại trong
      `mono_utils._ENGINE_STRUCT_NAMES` (Bounds, BoundsInt, Matrix4x4, LayerMask, RectOffset,
      GUID, Hash128, Vector2Int, Vector3Int, SphericalHarmonicsL2, AnimationCurve, Gradient,
      GUIStyle, PropertyName) — tên field private của một số cái (`m_X`/`m_Extent`, không phải
      `x`/`m_Extents`) không đủ chắc chắn để đoán mà không có fixture thật, và đoán sai thì lệch
      byte toàn bộ field phía sau
- **Quy tắc an toàn cốt lõi**: field không resolve được (external type chưa load, generic khác
      `List<T>`, struct built-in chưa hardcode, ...) → **cả type bị decline** (`None`), không chỉ
      field đó — một layout đúng-một-phần còn tệ hơn không có gì, vì mọi field sau field sai sẽ
      lệch byte theo
- **Test:** `tests/import_/test_mono_manager_serializable_type.py` (6 test) — struct 1 field,
      đủ 8 dạng field trên 1 class (`int`/`float`/`string`/nested struct/`string[]`/PPtr/
      `List<int>`/`Vector3`), field không resolve được làm cả type decline, kế thừa 2 cấp đúng
      thứ tự, cache trả cùng instance, và **test đọc bytes thật** qua
      `SerializableStructure.read`/`EndianSpanReader` (không chỉ assert cấu trúc) để chắc chắn
      graph dựng ra thật sự tiêu thụ được, không chỉ trông hợp lý
- **Chưa làm (Phần 2 — nối dây thật, xem việc còn lại):**
  - [ ] `assetripper_import/structure/assembly/managers/base_manager.py` — interface chung
        (`get_serializable_type(assembly, namespace, class_name) -> SerializableType | None`) để
        `GameStructure`/`ExportHandler` không cần biết backend là Mono hay IL2CPP. Cần thêm: nhiều
        `MonoAssembly` (một per `.dll` trong `Managed/`) + resolve theo `assembly` name — hiện
        `MonoAssembly.get_serializable_type` chỉ tra trong CHÍNH `.dll` đó, chưa cross-assembly
  - [ ] `unloaded_structure.py` — port `UnloadedStructure.cs`: MonoBehaviour đọc **lazy** sau khi mọi
        asset đã load (vì MonoBehaviour có thể load trước MonoScript nó trỏ tới)
  - [ ] `game_asset_factory.py` — hiện MonoBehaviour không có type tree → `UnknownObject`
        (xem docstring của nó). Thêm nhánh: có assembly manager thì dựng `UnloadedStructure`
  - [ ] `script_exporter.py` — bỏ giả định `AssemblyManager.IsSet` luôn `False` (ghi thẳng trong
        docstring hiện tại), nối vào 16b để ra `.cs` thật; giữ `EmptyScriptExportCollection` làm fallback
  - [ ] `ScriptContentLevel` (đã có ở `assetripper_export_configuration`, Phase 10) — nối cho thật:
        Level0 = không load, Level1 = stub, Level2 = default
  - **Effort/Risk:** thấp/trung bình (đã giảm so với đánh giá ban đầu — phần khó nhất, dựng đúng
        `SerializableType`, đã xong ở Phần 1). Chỗ dễ vỡ là regression trên đường TypeTree đang
        chạy tốt. **Bắt buộc:** test khẳng định asset *có* type tree vẫn đi đường cũ, không đổi output
  - **Phụ thuộc:** 16c (hoặc 16c-alt), hoặc 16d+16e — đã thoả (16c xong)

#### 16g — Method body: ngoài scope, có evidence

- [~] **Không làm.** IL2CPP: xem bảng ở đầu Phase 16 — upstream tự tắt tính năng này của Cpp2IL vì
      tỉ lệ ra được quá thấp, và không có gì để port (Cpp2IL là NuGet). Mono: cần một IL→C#
      decompiler cỡ ILSpy, tức một project riêng lớn hơn cả port này. Ghi lại ở đây để không ai
      tưởng là quên. Method body sẽ là stub trả default, **đúng bằng mức upstream ship**

---

**Thứ tự đề xuất:** `16a + 16b` (song song, không phụ thuộc gì) → `16c` → **`16c-alt` (dừng được ở
đây và đã có kết quả dùng được)** → `16f` → `16d` → `16e`.

Lý do đặt `16c-alt` làm mốc dừng: nó cho toàn bộ output của Phase 16 mà không phải chạm vào native
binary parsing — phần rủi ro cao nhất và cũng là phần **không thể verify** nếu không có game thật.
Chỉ đi tiếp `16d`/`16e` khi đã quyết định rằng "user phải tự chạy Il2CppDumper" là không chấp nhận được.

### Phase 17 — Xem trước **những file SẼ được export** (asset + code) ngay trên tool 🔴 VIẾT LẠI

> ⚠️ **Phase này đã bị làm sai mục tiêu một lần (commit `37db9bf`) và đang được viết lại.** Bản cũ
> hiểu mục tiêu là "browse **project đã export xong**" — tức là phải bấm Export ra một thư mục
> trước, rồi mới xem lại được. **Đó không phải mục tiêu.** Mục tiêu thật (user chốt lại
> 2026-08-01): sau khi load một game (`.apk`/`.ipa`/folder), tool phải cho xem **danh sách + nội
> dung những file sẽ được export ra** — asset (ảnh/âm thanh/mesh/YAML) **và code `.cs`** — **ngay
> trên tool, không cần export ra đĩa trước.** Tức là "xem trước kết quả decompile", không phải
> "mở lại thư mục đã export".
>
> Đây vẫn là **feature mới, không có ở upstream** (upstream export ra đĩa rồi kết thúc).

**Phần nào của `37db9bf` giữ được, phần nào phải bỏ:**

| Đã có ở `37db9bf` | Số phận |
|---|---|
| `routes/projects.py` browse/File endpoint + guard path-traversal + template breadcrumb | **Giữ, dùng lại** — chỉ đổi *nguồn dữ liệu* của cây (từ "thư mục trên đĩa" → "cây file sẽ-được-export"), không phải viết lại route/template |
| `/Project/Load` (mở lại một project đã export sẵn trên đĩa) | **Giữ như feature phụ** — vẫn có ích thật ("hôm qua export rồi, giờ xem lại"), nhưng **không còn là đường chính** |
| `start_export(output_directory=None)` → `tempfile.mkdtemp` + `_owned_temp_dir` + `atexit` cleanup | **Bỏ phần lớn** — mục tiêu mới không cần export ra đĩa trước, nên toàn bộ nhánh temp-dir + cleanup này trở thành thừa. Chỉ giữ nếu vẫn muốn giữ "export ra temp rồi browse" như đường phụ |
| Quyết định "17a-lite: **không** port `VirtualFileSystem`" | **SAI với mục tiêu mới — phải làm ngược lại.** Xem ngay dưới |

**Tự sửa một quyết định của chính phase này:** bản `37db9bf` ghi rõ *"chốt không port `VirtualFileSystem`,
17a-lite đã đủ"*. Lý do đó **đúng với mục tiêu cũ** (browse thư mục đã có trên đĩa thì `os.listdir` là đủ)
nhưng **sai với mục tiêu mới**. Kiểm tra lại code xác nhận: `IExportCollection` (xem
`export_unity_projects/i_export_collection.py`) **chỉ** có `export(container, project_directory, file_system)` —
**không** có `get_export_paths()` hay bất cứ cách nào biết trước "collection này sẽ ghi ra file nào,
tên gì" mà không thật sự chạy exporter (tên file phụ thuộc `_get_unique_file_name` → cần
`file_system.get_unique_name` để chống trùng tên). Nên cách **duy nhất** để biết chính xác cây output
mà không ghi đĩa là **chạy `export()` thật vào một `FileSystem` trong RAM** → `VirtualFileSystem` giờ là
**bắt buộc**, không còn là tuỳ chọn. Tin tốt: hạ tầng abstraction đã có sẵn
(`assetripper_io_files/filesystem.py`'s `FileImplementation`/`DirectoryImplementation`/`PathImplementation`),
nên port này là "implement 3 class lên một dict trong RAM", nhẹ hơn nhiều so với 505 dòng C#.

**Trần của phase này (không đổi):** cây file + nội dung từng file. **Không** emulate Unity Editor
(không scene viewport 2D/3D, không material inspector, không prefab hierarchy đồ hoạ).

#### ⚠️ Đọc trước: nội dung xem được phụ thuộc hoàn toàn vào Phase 18

Trên `demo-android.apk` (build release thật), Phase 18 đã xác nhận **Texture2D/Sprite/Material/Shader/
Mesh/AudioClip/MonoBehaviour đọc ra rỗng** (không type tree + port chỉ có 5 hand-written layout).
Nghĩa là cây preview của Phase 17 trên game thật sẽ **hiện ra rất ít file asset thật** — chủ yếu
`.prefab` + `ProjectSettings/*`. **Đây không phải bug của Phase 17.** Ngược lại: Phase 17 chính là
công cụ làm cho gap Phase 18 **hiện ra rõ ràng** thay vì ẩn đi. Tương tự với code: `.cs` hiện vẫn là
**dummy class rỗng** (`ScriptExporter`/`EmptyScriptExportCollection`) cho tới khi Phase 16 xong.
**UI bắt buộc phải nói rõ hai điều này**, không để user tưởng "tool xem được nhưng game này rỗng".

#### 17a — `VirtualFileSystem` ✅ `a71bef0`

- [x] `assetripper_io_files/virtual_file_system.py` — port khá sát 1:1 từ chính
      `Source/AssetRipper.IO.Files/VirtualFileSystem.cs`/`.g.cs` (đọc lại mới thấy: upstream **đã có**
      class này, không phải feature mới của port này — chỉ là chưa port trước đó). `_DirectoryEntry`/
      `_FileEntry` cây dict trong RAM, khớp `DirectoryEntry`/`FileEntry` của C#. `file.create()` trả
      `_VirtualFileStream(MemoryStream)` mà buffer **là chính** `_FileEntry.data` (share reference,
      không copy) — nhiều handle cùng ghi vào một file thấy nhau ngay, giống `SmartStream.CreateReference()`
      upstream. `open_write` tự tạo file nếu chưa có (khác upstream — upstream bắt buộc file có sẵn —
      nhưng khớp đúng `LocalFileSystem`'s `open_write` hiện có của port này, đúng yêu cầu "khớp surface
      LocalFileSystem" hơn là khớp 1:1 upstream ở điểm này)
- [x] `directory.delete` **cố ý để `NotImplementedError`** — khớp đúng upstream (`VirtualDirectoryImplementation`
      không bao giờ override `DirectoryImplementation.Delete`'s `NotSupportedException` mặc định); grep
      xác nhận không có call site nào trong port gọi `directory.delete`, nên không có gì để implement
- [x] `enumerate_files`/`enumerate_directories` trên path không tồn tại: trả rỗng thay vì raise — khác
      upstream (upstream's `OpenDirectory` throw `DirectoryNotFoundException`) nhưng khớp
      `LocalFileSystem`'s glob-based behavior của port này, và Phase 17c sẽ lấy `path` trực tiếp từ query
      string URL nên "không tìm thấy gì" đúng hơn là 500
- [x] `get_unique_name` (kế thừa nguyên từ `FileSystem` base, không override) hoạt động đúng trên VFS vì
      chỉ dựa vào `directory.exists`/`file.exists`/`path.*` đã implement đúng — test riêng cho case trùng
      tên (`test_get_unique_name_resolves_collision_in_virtual_file_system`)
- [x] Test `tests/io_files/test_virtual_file_system.py` (13 test): write→read round-trip, nested
      directory tự tạo, `file.create` đòi hỏi parent dir có sẵn (giống `LocalFileSystem`, không tự
      `mkdir -p`), `enumerate_files`/`enumerate_directories` (kể cả trên path không tồn tại),
      `get_unique_name` khi trùng tên và khi không, `directory.delete` raise, path join/full-path
      normalize, và **test đối chiếu** `test_export_path_set_matches_local_file_system_export`: export
      cùng một synthetic game (fixture giống `test_export_handler.py`) vào `LocalFileSystem` (tmp_path)
      và `VirtualFileSystem`, assert **danh sách path ra giống nhau từng file** — test quan trọng nhất
      của 17a, chứng minh preview == export thật. Lưu ý khi viết test này: **input luôn đọc từ
      `LocalFileSystem` thật** (game data thật sự nằm trên đĩa, apk/ipa không có "bản ảo"), chỉ **export**
      mới dùng `VirtualFileSystem` — gọi `load_and_process` với `LocalFileSystem` rồi `export` riêng với
      VFS, không gọi `load_process_and_export` với VFS cho cả hai (thử sai lần đầu, VFS rỗng không có
      gì để đọc input game dir)
- **Effort/Risk:** trung bình/thấp-trung bình — thấp hơn dự kiến vì có sẵn `VirtualFileSystem.cs` upstream
      để port sát, không phải tự thiết kế từ đầu
- **Phụ thuộc:** không

#### 17b — `ExportPlan`: chạy export thật vào RAM, lấy ra cây "sẽ được export" ✅ `58a4f76`

- [x] `assetripper_gui_web/export_plan.py` — `build_export_plan(game_data, settings=None) -> ExportPlan`.
      **Khác kế hoạch gốc một chỗ, có chủ đích:** không tự giữ index `path -> node` riêng —
      `VirtualFileSystem` (17a) đã lộ đủ qua interface `FileSystem` chuẩn
      (`directory.get_files`/`get_directories`, `file.read_all_bytes`/`exists`) để browse trực tiếp,
      nên `ExportPlan` chỉ là dataclass mỏng giữ `file_system` (chính VFS) + `project_version` (cho
      banner UI) + `all_files()` (cho cảnh báo "gần rỗng" ở 17c). Thêm một index riêng sẽ là abstraction
      thừa — vi phạm đúng nguyên tắc "không port/thêm thứ không cần" mà ROADMAP này giữ xuyên suốt
- [x] **Dùng lại `ExportHandler.export` y nguyên, không copy logic:**
      `ExportHandler().export(game_data, "/", vfs, settings=settings)` rồi trả `ExportPlan(vfs, ...)` —
      đúng yêu cầu, không tự dựng `ProjectExporter`/`register_default_exporters` riêng
- [x] Test `tests/gui_web/test_export_plan.py` (3 test): plan chứa đúng file thật export ra (kể cả đọc
      lại bytes), **test đối chiếu thứ hai** (nối tiếp 17a nhưng ở tầng `ExportPlan` thay vì
      `VirtualFileSystem` trực tiếp) — cùng `game_data`, path set của plan khớp hệt path set của một
      `ExportHandler.export` thật ra `tmp_path` — và settings (`text_export_mode=BYTES`) được truyền
      đúng xuống qua `build_export_plan`
- [ ] **Chưa làm ở 17b, dời sang 17c:** cache `(game_data, settings) -> ExportPlan` trong
      `game_file_loader._state` + invalidate khi đổi Settings/load game mới. Lý do dời: đây là logic
      gắn với GUI state thật (`_state`), thuộc đúng phạm vi "Endpoint + UI" của 17c hơn là "build một
      ExportPlan thuần" của 17b — `build_export_plan` tự nó đã là pure function, không cần biết gì về
      GUI state để test hay dùng lại (CLI có thể gọi thẳng nếu cần sau này)
- **Phụ thuộc:** 17a

#### 17c — Endpoint + UI: cây file sẽ-được-export, xem được asset **và** code ✅ `0cb790e`

- [x] `routes/projects.py` đọc `game_file_loader.get_export_plan()` (17b) thay vì `os.listdir` trên
      thư mục thật. **Giữ nguyên shape URL** (`/Project`, `/Project/Browse?path=`, `/Project/File?path=`,
      `/Project/Load`). **Khác với kế hoạch gốc một chỗ, có chủ đích:** không mở thêm URL mới cho
      "file view" — `/Project/Browse?path=` tự phân nhánh: nếu `path` trỏ vào một **thư mục** thì hiện
      bảng liệt kê (như cũ); nếu trỏ vào một **file** thì hiện luôn nội dung file đó inline ngay trong
      cùng trang (ảnh/audio/`<pre>`...). `/Project/File?path=` vẫn đúng vai trò ROADMAP mô tả: endpoint
      **raw bytes** (mime type qua `asset_preview.mime_type_for_extension`), dùng làm `src` cho
      `<img>`/`<audio>` và làm link tải — cách này thoả đúng yêu cầu "giữ nguyên shape URL" theo nghĩa
      đen (không thêm URL nào ngoài 4 cái đã liệt kê)
- [x] Render inline theo loại (`_render_kind` trong `routes/projects.py`): ảnh → `<img>`; âm thanh →
      `<audio controls>`; code `.cs` → `<pre>` + banner dummy-stub; text/YAML (mở rộng
      `asset_preview.YAML_EXTENSIONS` thêm `mat`/`prefab`/`unity`/`meta`/`controller`, thêm
      `CODE_EXTENSIONS`={`cs`}) → `<pre>`; mesh `.glb` → link tải; binary khác → link tải (ROADMAP cho
      phép "hex view **hoặc** link tải" — chọn link tải, không lặp lại `_hex_dump` đã có ở
      `routes/assets.py` cho asset raw-bytes debugging)
- [x] Cả 3 banner trung thực bắt buộc đã có trong `templates/projects/view.html`: banner preview
      chung ("preview of the files that would be exported... not a Unity Editor" — chỉ hiện khi xem
      qua `ExportPlan`, không hiện khi xem một project **thật** đã load qua `/Project/Load`), banner
      dummy-stub trên mỗi file `.cs`, và banner "no embedded type trees" khi `_asset_count_warning()`
      phát hiện `Assets/` (trừ `.meta`) rỗng trong plan
- [x] Bỏ hẳn yêu cầu "phải Export trước mới browse được": `browse()` gate giờ check
      `game_file_loader.has_browsable_project()` (= có `game_data` HOẶC đã `/Project/Load`) thay vì
      `has_exported_project()` — cây hiện ngay sau `/LoadFolder`
- [x] **Dọn theo cùng: bỏ hẳn nhánh "OutputPath rỗng → export vào temp dir rồi browse"** ở
      `game_file_loader.start_export`/`commands.py` (`_owned_temp_dir`, `atexit` cleanup) — nhánh này
      đã thừa thật (đúng ghi chú ở bảng đầu Phase 17), `ExportPlan` preview thay thế nó hoàn toàn mà
      không cần ghi đĩa. `/Export/UnityProject` giờ đòi `OutputPath` thật trở lại, y hệt trước khi có
      Phase 17 — export ra đĩa và preview-trong-RAM giờ là hai tính năng tách biệt rõ ràng
- [x] `/Project/Load` (browse một project **thật** đã export ở lần chạy trước) giữ nguyên, và **có
      precedence** so với `ExportPlan` preview khi cả hai đều sẵn sàng (browsing một export cũ là hành
      động chủ động của user, nên ưu tiên hơn preview mặc định) — `reset()` (từ `load_paths` mới) xoá
      precedence này, quay lại preview
- [x] Path-traversal: nguồn `/Project/Load` (đĩa thật) giữ nguyên guard cũ (400). Nguồn `ExportPlan`
      (VFS) **không cần guard riêng** — path là literal dict-key lookup trong cây RAM, không có
      directory entry nào tên `..` để "thoát" ra ngoài, nên một path bịa chỉ 404 như path sai bất kỳ
      (xem `_resolve_plan`'s docstring trong `routes/projects.py`)
- [x] Smoke-test thủ công qua dev server thật (`python -m assetripper_gui_web ... --no-browser` +
      `curl`), không chỉ Flask test client: `/LoadFolder` → `/Project/Browse` hiện cây ngay, browse
      subdirectory, xem file `.txt`/`.meta` inline qua `<pre>`, `/Project/File` trả đúng bytes, navbar
      không còn "Search", traversal trên nguồn plan trả 404 sạch (không crash), `OutputPath` rỗng bị
      từ chối — xem chi tiết trong lịch sử phiên làm việc
- **Phụ thuộc:** 17b

#### 17d — Bỏ (hạ xuống phụ) phần browse input bundle ✅ `0cb790e`

User đã chốt: *"bỏ phần view loaded bundle cũng được"*.

- [x] **Quyết định:** gỡ khỏi navbar, **giữ route + test** (khuyến nghị của bản kế hoạch, không xoá
      hẳn) — chi phí gần bằng 0 và Phase 18 sẽ cần soi asset đầu vào để viết hand-written layout.
      Cụ thể: bỏ link "Search" khỏi `templates/layout.html`'s navbar. Link "View root bundle" ở
      `index.html` **không xoá hẳn** (khác một chút so với chữ "navbar/index" ở đầu mục 17d) — giữ lại
      nhưng đổi nhãn thành "Raw input-bundle inspection (debug)" kèm giải thích khi nào cần dùng, để
      công cụ debug Phase 18 vẫn dễ tìm mà không còn là lối đi chính trên trang chủ
- [x] `/Bundles/View`, `/Collections/View`, `/Assets/View`, `/Resources/View`, `/FailedFiles/View`,
      `/Scenes/View`, `/Search` — route/blueprint **không đổi gì**, vẫn đăng ký như cũ, test hiện có
      của chúng không cần sửa (đã verify: suite vẫn 705 pass sau khi bỏ nav link)
- [x] **`load_file()` đã dọn theo quyết định này ở Phase 19b** — giữ nguyên (không xoá), chỉ không còn
      được gọi từ nút Load chính của GUI nữa (19a); trạng thái mâu thuẫn "loaded but empty" của nó cũng
      đã sửa ở 19b, xem Phase 19
- **Phụ thuộc:** 17c (bỏ sau khi đã có cái thay thế — có rồi, xong)

#### 17e — Test + release gate ✅ `0cb790e`

- [x] `tests/gui_web/test_project_browse.py` — **viết lại hoàn toàn** phần lấy dữ liệu (16 test, từ
      11 test cũ): giữ lại đúng như dự định 2 test path-traversal (đổi tên rõ "on_disk_source"), test
      "chưa load thì redirect" (đổi thông báo), test `/Project/Load`. Thêm mới: cây hiện ra ngay sau
      `/LoadFolder` không cần `/Export/UnityProject`; browse subdirectory; `/Project/File` trả đúng
      nội dung; browse thẳng vào một file `.txt` hiện nội dung inline (không chỉ link tải); `_render_kind`
      nhận diện `.cs`; `/Export/UnityProject` từ chối `OutputPath` rỗng; export đĩa thật không còn tự
      động thành nguồn browse; disk-Load có precedence; traversal trên nguồn plan trả 404 (không phải
      lỗi, đối lập có chủ đích với nguồn disk trả 400); và 2 unit test thuần cho `_asset_count_warning`
- [ ] **Chưa làm — dời sang lúc có fixture thật hoặc phiên sau:** test đối chiếu preview-vs-export ở
      mức GUI thật (dùng `demo-android.apk` qua Flask test client, so `ExportPlan`'s path set với một
      `/Export/UnityProject` thật ra `tmp_path`). Rủi ro thấp vì bản chất đã được chứng minh ở tầng
      thấp hơn hai lần: `test_virtual_file_system.py::test_export_path_set_matches_local_file_system_export`
      (17a, VFS trực tiếp) và `test_export_plan.py::test_build_export_plan_matches_a_real_disk_export_of_the_same_game_data`
      (17b, qua ExportPlan) đều đã chứng minh đúng bất biến này bằng game synthetic; thêm một lớp GUI
      route phía trên (`browse()`/`get_export_plan()` chỉ đọc lại `ExportPlan`, không biến đổi path)
      khó có khả năng phá vỡ bất biến đó, nhưng vẫn nên làm để phủ đúng route thật, không chỉ hàm nội
      bộ — ghi lại rõ ràng thay vì bỏ qua âm thầm
- [x] Release gate (full suite 705 pass, wheel build + fresh-venv import + `pip install -e .`
      rerun) + smoke test qua dev server thật (xem 17c) + commit + push

**Thứ tự:** `17a` → `17b` → `17c` → (chốt quyết định) `17d` → `17e`. Không đảo — 17c không có gì để
render nếu chưa có 17b, và 17b không chạy được nếu chưa có 17a.

#### Rủi ro riêng của Phase 17 (bản viết lại)

1. **Preview lệch export thật.** Rủi ro số 1 của phase này. Nếu `VirtualFileSystem` khác
   `LocalFileSystem` ở bất cứ chi tiết nào ảnh hưởng tên/đường dẫn file (nhất là `get_unique_name` khi
   trùng tên), preview sẽ **nói dối** — tệ hơn hẳn không có preview. Chống bằng test đối chiếu path-set
   ở cả 17a và 17e, và bằng việc `export_plan` **gọi lại `ExportHandler.export`** chứ không copy logic.
2. **RAM — chưa xử lý, đã biết và chấp nhận có chủ đích cho lần này.** `build_export_plan` (17b) chạy
   `ExportHandler.export` **đầy đủ** vào VFS (không phải "cây metadata + render on-demand" như risk
   note gốc đề xuất) — bytes thật của mọi file (kể cả PNG đã decode) nằm trong RAM một khi plan được
   build. Lý do chưa đổi kiến trúc: (a) `IExportCollection.export()` không có API "chỉ liệt kê path,
   đừng ghi nội dung", nên tách "metadata-only" đòi sửa tận `IExportCollection`/từng exporter — vượt
   quy mô 17b; (b) trên fixture thật hiện có (`demo-android.apk`), export ra rất ít file (đa số asset
   vẫn đọc rỗng, xem Phase 18) nên chưa thấy vấn đề RAM thật. **Vẫn là nợ kỹ thuật thật** nếu/khi
   Phase 18 làm xong nhiều class hơn (hàng trăm MB PNG có thể tích luỹ trong `ExportPlan` cache) — để
   lại làm sau nếu triệu chứng RAM thật xuất hiện, không rewrite trước khi có bằng chứng cần
3. **User tưởng preview = Unity Editor mở được.** Đã xử lý: banner rõ ràng ở `/Project` (chỉ hiện khi
   xem qua `ExportPlan`, không hiện khi browse một project thật đã load qua `/Project/Load`).
4. **User tưởng "tool xem được ⇒ decompile xong".** Đã xử lý: banner "no type trees" khi
   `Assets/` rỗng + nhãn dummy-stub trên mọi file `.cs` — cả hai bắt buộc, không thể tắt.
5. **Stale plan sau khi đổi Settings.** Đã xử lý ở 17c/`game_file_loader.get_export_plan()`: cache key
   `(id(game_data), id(settings))`, cả `load_paths` và `/Settings/Edit` đều luôn tạo object mới (không
   mutate tại chỗ) nên so sánh identity là đủ để phát hiện stale, không cần gọi invalidate tường minh.

### Phase 18 — Fixture Unity thật đầu tiên: 3 bug + 1 gap nghiêm trọng 🔴 `0e4c206`

**Bối cảnh:** user đẩy 2 file thật lên `python/input-test/` qua Git LFS —
`demo-android.apk` (build IL2CPP Android thật, có `libil2cpp.so` + `global-metadata.dat`, Unity
`2022.3.62f2`) và `demo-ios.ipa` (chưa test trong phase này — 300MB, để phase sau). Đây là fixture
Unity thật **đầu tiên** trong toàn bộ project — mọi phase trước giờ chỉ verify bằng
`SerializedFileBuilder`/`_tree_builder.py` tự dựng byte tay. Chạy thẳng
`ExportHandler.load_and_process` + `.export()` lên `demo-android.apk` (không sửa gì trước) để xem
pipeline có thật sự chạy được trên game thật không.

#### 3 bug crash thật, đã sửa ✅ `0e4c206`

- [x] **`scene_helpers.py`**: `try_get_scene_path`/`is_scene_duplicate` gọi `build_settings.get(...)`
      không kiểm tra `build_settings` có `.get` hay không — crash `AttributeError` ngay bug đầu tiên
      gặp phải. Nguyên nhân gốc: build thật (release) **không nhúng type tree**, nên BuildSettings đọc
      ra là `UnknownObject` chứ không phải `TypeTreeObject`, khác hẳn giả định cũ trong docstring
      module ("type tree có mặt ở hầu hết file thật" — **sai**, ít nhất với release build). Sửa bằng
      helper `_scenes(build_settings)` coi "không có `.get`" giống hệt "không có BuildSettings" (trả
      `False, None` thay vì crash) — game vẫn export được, chỉ là tên scene fallback về tên file thô
- [x] **`raw_data_object.py`**: đây là bug **nền tảng nhất trong 3 cái** — thêm
      `.get`/`.items`/`.keys`/`__contains__`/`__getitem__` vào `RawDataObject` (báo "không field nào"
      một cách nhất quán) thay vì chờ `AttributeError` ở TỪNG call site riêng lẻ khắp codebase.
      `original_path_processor.py` là call site thứ 2 hit đúng bug này ngay sau khi sửa cái đầu — xác
      nhận đây là lỗi hệ thống (mọi nơi gọi `asset.get(...)`), không phải lỗi cục bộ. `__setitem__`
      **cố ý không thêm** — ghi field vào asset có layout không xác định là bug thật của caller, không
      nên nuốt âm thầm
- [x] **`sprite_coordinates.py`**: `get_sprite_coordinates_in_atlas` chia cho `sprite_width`/
      `atlas_width` không kiểm tra 0 — `ZeroDivisionError` khi gặp Sprite có `m_Rect` rỗng (hệ quả
      trực tiếp của bug `RawDataObject` ở trên: Sprite không đọc được layout → mọi field mặc định 0).
      C# không bao giờ throw ở phép chia float (`x/0f` = `Infinity`, `0f/0f` = `NaN`) — thêm helper
      `_div()` replicate đúng semantics IEEE-754 đó thay vì để Python's `/` raise
- **Test:** 5 test đơn vị mới (2 `test_raw_data_object.py`, 1 `test_scene_helpers.py`, 2
      `test_sprite_coordinates.py`) + 2 test tích hợp thật (`tests/real_fixtures/
      test_demo_android_apk.py`, **skip tự động nếu chưa `git lfs pull`** — file LFS pointer chỉ
      ~130 byte, phân biệt được với file thật đã pull bằng ngưỡng size) chạy full
      `load_and_process` + `export` lên chính `demo-android.apk`, xác nhận: không crash, ra được
      `ProjectSettings/ProjectVersion.txt` + ít nhất 1 `.prefab`, và xác nhận
      `sharedassets0.assets`/`sharedassets1.assets` (vốn bị chia nhỏ vật lý thành `.split0`-`.split5`
      trên APK — giới hạn nén ZIP >1MB lịch sử của Android) được `MultiFileStream` ghép lại đúng
      (module này đã port sẵn từ Phase 1-3, hoá ra đã đúng, không phải sửa — chỉ verify lần đầu
      bằng file thật)

#### Gap nghiêm trọng nhất: build thật (release) không có type tree ⚠️ `d9494ec` — **5/7 class đã có
     layout, byte-verified bằng chính fixture thật; MonoBehaviour/Shader/BuildSettings còn lại**

Sau khi sửa 3 bug trên, pipeline chạy hết không crash và export ra project — nhưng kiểm tra nội dung
thật thì phát hiện: **Texture2D (111 asset), Sprite (39), Material (58), Shader (68), Mesh (29),
AudioClip (11), MonoBehaviour (496), AnimationClip, AnimatorController, ComputeShader, ...** — tức là
gần như *mọi* class ngoài GameObject/Transform/PrefabInstance/MonoScript — đều đọc ra
`UnknownObject` rỗng trên file `sharedassets0.assets`/`sharedassets1.assets` này, dù các file đó
**có load được** (884 + 322 object). Lý do: `has_type_tree=False` trên build release thật (bình
thường, không phải lỗi build), và Phase 2's hand-written layout **chỉ phủ 5 class**.

**Đây chính là rủi ro "chưa test trên game thật" mà hầu như mọi phase trước (Phase 6, 9, 13, ...) tự
ghi chú cảnh báo — giờ đã biết chính xác nó tệ tới mức nào.** Phase 9 (`.resS` streamed data) tự nó
làm đúng, nhưng vô dụng nếu Texture2D không có field `m_Width`/`m_TextureFormat`/`m_StreamData` để
đọc trước — hai lớp vấn đề độc lập, và lớp "đọc field" mới là lớp chặn thật trên build release.

**Đã làm (commit `d9494ec`) — 4 hand-written layout mới, `assetripper_import/asset_creation/
layouts/{texture2d,audio_clip,sprite,material}.py`:**

- [x] **`Texture2D`(28)**, **`AudioClip`(83)**, **`Sprite`(213)**, **`Material`(21)** — field order lấy
      từ Perfare/AssetStudio (`Texture2D.cs`/`AudioClip.cs`/`Sprite.cs`/`Material.cs`, tool tham chiếu
      lâu đời, được cộng đồng dùng rộng rãi), **rồi verify byte-chính-xác bằng cách đọc thật từng byte
      của `demo-android.apk`** — không chỉ tin tài liệu công khai suông. Cách làm: dựng layout ứng
      viên, chạy `GameAssetFactory.read_asset` thật (không phải parser tay) lên **toàn bộ 8 sample**
      mỗi loại tìm được trong file thật, chỉnh tới khi `SerializableStructure.try_read` tiêu thụ
      **đúng số byte** với giá trị hợp lý (VD Texture2D "EmojiOne" 512x512 mip_count=10 khớp
      log2(512)+1; AudioClip offset/size của 8 sample nối liền nhau khớp hệt cấu trúc file
      `.resource` đóng gói tuần tự; Sprite path_id của `RD.texture` trỏ đúng vào các Texture2D liền kề;
      Material "TextMeshPro/Sprite" ra đúng property `_ColorMask`/`_Stencil*`/`_ClipRect`/`_Color`)
- [x] **Phát hiện + sửa một chi tiết format Unity 2022.2+ chưa document rõ ở đâu công khai lúc tra
      cứu:** `Texture2D.m_IgnoreMasterTextureLimit` (bool) bị **thay thế** bởi `m_IgnoreMipmapLimit`
      (bool) + `m_MipmapLimitGroupName` (string) kể từ Unity 2022.2 (tính năng Mipmap Limit Groups) —
      chỉ tìm ra được nhờ so khớp byte thật, không tài liệu công khai nào tra được liệt kê rõ field
      này thay thế field cũ ở vị trí nào
- [x] **Kết quả thật trên `demo-android.apk`:** trước khi có layout — 0 file `.png`/`.mat`/`.fsb`.
      Sau: **105 `.png`** (ảnh thật, decode được, kích thước hợp lý: 256x256, 1024x1024, 2x2, 24x1920
      loading-bar…), **58 `.mat`** (YAML material thật với property đúng), **11 `.fsb`** (audio thật,
      offset/size khớp file resource gốc)
- [~] **Không port đầy đủ, ghi rõ trong từng module:** Sprite's `secondaryTextures`/`m_Bones` và
      Material's `m_BuildTextureStacks` — mọi sample thật đều rỗng (count=0) nên phần tử bên trong các
      mảng này **chưa verify được** cho trường hợp không rỗng; đoán tốt nhất theo public API, tài liệu
      rõ trong docstring từng module. Một Sprite/Material thật dùng các tính năng hiếm này (2D Sprite
      Skin, texture stacks) có thể đọc lỗi (`UnreadableObject`, an toàn) thay vì sai âm thầm
- **Test:** 8 test mới trong `test_layouts.py` (synthetic, không cần Git LFS) + mở rộng
      `test_demo_android_apk.py` với `test_real_content_is_actually_exported` (assert thật: >50 PNG,
      >20 mat, >5 audio, PNG decode được, mat YAML có field đúng) — khẳng định cải thiện đo được, không
      chỉ "không crash"

#### Mesh (43) — layout thứ 5, cùng ngày, đợt 2 ✅ `8d12472`

- [x] `assetripper_import/asset_creation/layouts/mesh.py` — field order lấy từ
      Perfare/AssetStudio's `Mesh.cs` (fetch trực tiếp qua `curl` từ raw.githubusercontent.com —
      WebFetch's summarizer từ chối reproduce nguyên văn vì lo ngại bản quyền, nhưng `curl` qua Bash
      tool lấy được y nguyên; **đọc trực tiếp bằng Read tool, không qua model tóm tắt trung gian**,
      để tránh sai lệch do việc tóm tắt gây ra) + `AnimationClip.cs` (nơi `PackedFloatVector`/
      `PackedIntVector` được định nghĩa — dùng chung bởi `CompressedMesh`, đặt tên hơi lạ nhưng xác
      nhận đúng qua chính source)
- [x] **Quy trình verify khác một bậc so với 4 layout trước:** vì Mesh có quá nhiều field/version-gate
      (BlendShapeData, VertexData, CompressedMesh, nhiều mảng lồng nhau), **viết script Python dò byte
      thủ công trước** (không qua DSL) để trace từng field một qua tất cả 29 sample Mesh thật trong
      `demo-android.apk`, xác nhận consume **đúng 100% byte count** cho cả 29/29 trước khi encode vào
      DSL — rồi verify lại lần hai qua `GameAssetFactory.read_asset` thật (đúng quy trình đã dùng cho
      Texture2D/AudioClip/Sprite/Material, chỉ thêm một bước dò tay ở giữa vì độ phức tạp cao hơn hẳn)
- [x] Scoped `min_version=2019.1.0` (nơi `m_BonesAABB`/`m_VariableBoneCountWeights` xuất hiện — không
      model version cũ hơn, đúng "modern era only" như các layout khác); `m_CookingOptions` (2022.1+)
      là field duy nhất trong khoảng hỗ trợ còn có version gate runtime
- [x] **Kết quả thật trên `demo-android.apk`:** trước — 0 file `.glb`. Sau — **29 `.glb`** (100% số
      Mesh trong fixture), mỗi file được xác nhận là glTF 2.0 binary hợp lệ thật (magic `glTF`, length
      khớp file size, JSON chunk parse được, có `POSITION`/`NORMAL`/`TEXCOORD_0` accessor thật) — không
      chỉ "có file .glb" mà còn "file .glb đó dùng được"
- [~] **Không verify được cho trường hợp không rỗng, ghi rõ trong module:** `m_Shapes` (BlendShapeData
      — không Mesh nào trong fixture có blend shape) và `m_CompressedMesh` (mọi sample đều
      `m_MeshCompression=0`, tức không nén — bản thân `mesh_data.py` cũng đã tự khai từ trước là
      "declined" cho case nén, nên gap này không thêm rủi ro thực tế nào ngoài phần đã biết)
- **Test:** 3 test mới trong `test_layouts.py` (synthetic minimal + 1 SubMesh + not-registered-before-
      2019.1) + `test_demo_android_apk.py::test_real_meshes_are_actually_exported` (assert thật: ≥25
      `.glb`, 1 file decode được qua parser glTF thủ công, có mesh + accessor `POSITION` thật)

**Còn lại, chưa làm:**
- [ ] `MonoBehaviour`(114): field thật tuỳ theo **script gắn vào nó** (không có layout cố định) — cần
      Phase 16's script-metadata recovery (biết field layout từ IL2CPP/Mono) TRƯỚC KHI viết được layout
      tổng quát cho nó. Không tách rời được khỏi Phase 16. Đây là gap ảnh hưởng nhiều asset nhất còn
      lại (496 MonoBehaviour trong fixture) nhưng bản chất khác hẳn 4 class trên (không thể "chỉ viết
      thêm 1 layout")
- [ ] `BuildSettings`(141): byte thật cho thấy ~28 byte flag giữa `m_Scenes` và version string mà
      tài liệu công khai tra được (rất cũ, thời Unity 2.x-3.x) không khớp — không đủ tự tin đặt tên
      field, để lại `[~]`. Giá trị thấp (chỉ ảnh hưởng tên file scene fallback, đã graceful từ Phase 18
      bug-fix pass)
- [x] `Mesh`(43) — ✅ xong `8d12472`, xem mục riêng ngay trên
- [~] `Shader`(48): **đã điều tra cùng ngày (đợt 3, commit `7dcd3f8`), quyết định không làm trong phiên này — bằng
      chứng cụ thể, không phải suy đoán:**
  - Đọc trực tiếp Perfare/AssetStudio's `Shader.cs` (curl, 1031 dòng): với Unity ≥5.5 (bao gồm
    2022.3 của fixture), `Shader` **không còn field `m_Script`** (chỉ có ở nhánh cũ <5.5) — toàn bộ
    nội dung nằm trong `m_ParsedForm` (`SerializedShader`), một cây lồng nhau sâu: `SubShader[]` →
    `Pass[]` → `SerializedProgram`/`SerializedSubProgram` (per-GPU-target: DX9/DX11/GLES/Vulkan/
    Metal...), cộng `SerializedProperties`/`SerializedShaderState` (blend/stencil/fog state, mỗi
    field lại là `SerializedShaderFloatValue`/`VectorValue` gồm cả tên biến để hỗ trợ property
    override) — ước tính **~15+ struct lồng nhau**, nhiều hơn hẳn độ phức tạp của Mesh, với nhiều
    version-gate riêng bên trong từng struct con (VD `SerializedShaderState` tự có gate 2017.2+ và
    2020.1+ không liên quan gì đến gate ở tầng Shader ngoài cùng)
  - Kiểm tra thật 68 sample Shader trong `demo-android.apk`: kích thước 4KB – 340KB (so với Mesh
    lớn nhất chỉ 36KB) — xác nhận đây là dữ liệu chương trình GPU đã biên dịch thật, không phải
    metadata gọn nhẹ
  - **Khác Mesh ở điểm mấu chốt:** `SerializableStructure.try_read` đòi hỏi khớp byte **toàn bộ**
    object mới trả về `TypeTreeObject` — với một cây ~15+ struct lồng nhau như thế này, sai bất kỳ
    field nào ở bất kỳ tầng nào (kể cả tầng sâu trong `SerializedProgram`) làm hỏng **toàn bộ** phép
    đọc, không có đường "đọc được một phần". Áp dụng đúng kỷ luật đã dùng cho Mesh (dò tay từng byte
    qua toàn bộ sample thật trước khi tin) cho quy mô này tốn nhiều lần công sức hơn Mesh, cho một
    class mà `DummyShaderTextExporter`/`UnknownObject` đã export graceful (không crash) từ trước —
    tức là đây là value-add, không phải bug cần vá
  - **Không phải "sẽ không bao giờ làm"** — chỉ là không đủ effort/risk hợp lý trong phiên này so
    với việc đã làm xong Mesh. Nếu quay lại: bắt đầu bằng cách dò tay 1-2 sample nhỏ nhất (4188 byte)
    trước, đúng phương pháp Mesh đã dùng, thay vì viết cả `SerializedShader` một lần
- [ ] Cân nhắc: dùng chính 2 file thật này làm **fixture chuẩn cho release gate** (không chỉ optional
      skip) một khi kích thước/Git LFS được chấp nhận là chi phí xứng đáng

### Phase 19 — GUI không nhận được input `.apk`/`.ipa` ✅ `1e64fd3` (bug thật, user báo 2026-08-01)

**Triệu chứng user báo:** "phần GUI tool vẫn chưa hoạt động với file apk và ipa input".

**Đã điều tra, xác nhận nguyên nhân — engine không sai, GUI entry point sai.** Chạy trực tiếp:

| Gọi gì | `.apk` | `.ipa` |
|---|---|---|
| `game_file_loader.load_paths([path])` (đằng sau nút **Load Folder**) | ✅ OK, 3s | ✅ OK, 38s, Unity 2022.3.62f3, 26 collection |
| `game_file_loader.load_file(path)` (đằng sau nút **Load File**) | ❌ báo *"is not a recognized SerializedFile or UnityFS bundle"* | ❌ như trên |

Tức là `GameStructure`/`zip_extractor`/`platform_checker` **đã xử lý đúng** `.apk`/`.ipa` từ Phase 3
(`zip_extractor._DIRECT_EXTRACT_EXTENSIONS` có sẵn cả `.apk`/`.ipa`/`.obb`/`.zip`/`.vpk`/`.xap`/`.appx`).
Bug thuần ở phía GUI:

1. **Nút "Load File" gọi `load_file`, mà `load_file` chỉ đọc được SerializedFile/UnityFS thô.** Với
   người dùng có 1 file `.apk` trong tay thì "Load File" là nút hiển nhiên phải bấm — và nó fail. Đường
   duy nhất chạy được (`load_paths`) lại nằm sau nút **"Load Folder"**.
2. **Native picker của "Load Folder" là `askdirectory`** (xem `routes/dialogs.py`) → **không chọn được
   file `.apk`**. Nên ngay cả khi biết phải dùng Load Folder, user vẫn phải gõ path thủ công.
3. **Bug thật trong `load_file`:** nó set `_state.game_bundle = bundle` **trước** khi validate file.
   File không đọc được → GUI vẫn ở trạng thái `is_loaded() == True` với một `GameBundle` rỗng
   (`has_game_data() == False`), nên trang chủ hiện "Loaded bundle" + link "View root bundle" cho một
   bundle chẳng có gì, và Export thì im lặng không khả dụng. Trạng thái mâu thuẫn, không phải chỉ là
   message xấu.
4. **Không có progress khi load.** `.ipa` mất **38 giây** (giải nén ZIP 300MB + đọc toàn bộ
   SerializedFile). `/LoadFolder` là POST đồng bộ → browser treo 38s không phản hồi gì, user tưởng
   tool chết. Export đã có progress bar từ Phase 11; load thì chưa. Đây là yêu cầu UX **phát hiện được
   nhờ có fixture thật**, không phải suy đoán.

#### 19a — Một entry point "Load" duy nhất, nhận cả file lẫn folder ✅ `1e64fd3`

- [x] Gộp `/LoadFile` + `/LoadFolder` thành một luồng: **luôn** gọi `load_paths([path])` bất kể path là
      file hay folder. Không cần thêm logic phát hiện định dạng ở tầng GUI —
      `zip_extractor.process` + `platform_checker.check_platform` đã tự phân loại đúng
      (`.apk`/`.ipa`/`.obb`/`.zip` → giải nén; folder game → platform structure; file `.assets`/bundle
      lẻ → `MixedGameStructure`)
- [x] `index.html`: một form "Load a game" duy nhất + 2 nút picker cạnh nhau ("Choose file…" /
      "Choose folder…"), cùng POST về `commands.load_folder` (giờ chỉ còn là tên route, cả hai route
      đều gọi cùng handler). Ghi rõ trên form: chấp nhận `.apk`, `.ipa`, `.obb`, `.zip`, folder game
      (Windows/Linux/Mac/Android/iOS/Switch/PS4/WebGL), hoặc một file `.assets`/bundle lẻ
- [x] `routes/dialogs.py`: `askopenfilename` thêm `filetypes` (apk/ipa/obb/zip/assets/bundle/unity3d +
      "All files"), giữ nguyên cơ chế degrade về text input khi không có display
- [x] Giữ `/LoadFile` + `/LoadFolder` như alias (không collapse thành 1 URL) để không phá bookmark/test
      cũ — cả hai gọi chung một hàm `_load()` nội bộ trong `routes/commands.py`
- [x] Test: `tests/gui_web/test_load_input.py` — apk giả nhưng hợp lệ (ZIP thật, `assets/bin/Data/` +
      `META-INF/` để qua được `AndroidGameStructure.is_android_structure`, chứa 1 SerializedFile tên
      `globalgamemanagers`) qua cả `/LoadFile` và `/LoadFolder`, cùng kết quả; file rác → không load
      được + có error rõ ràng. Phát hiện khi viết test: `sharedassetsN.assets` **không** dùng được làm
      tên file trong fixture tối giản này — nó chỉ được `GameStructure` nhận diện như *dependency* của
      `globalgamemanagers`, không phải qua quét tên file trực tiếp; `globalgamemanagers` mới là tên
      `_collect_default_serialized_files` quét trực tiếp
- [x] `tests/real_fixtures/test_demo_android_apk.py::test_real_android_apk_loads_through_the_gui` —
      đóng đúng khoảng trống để bug lọt qua: dùng `demo-android.apk` thật qua Flask test client
      (`/LoadFile` và `/LoadFolder`), không chỉ qua `ExportHandler` như các test khác trong file
- **Effort/Risk:** thấp/thấp như dự kiến
- **Lưu ý phụ phát sinh khi sửa:** dọn theo luôn nhánh "OutputPath rỗng → export vào temp dir" ở
      `/Export/UnityProject` — dọn ở Phase 17c (đã xong), không lặp lại ở đây

#### 19b — Sửa bug trạng thái mâu thuẫn của `load_file` ✅ `1e64fd3`

- [x] `load_file`: chỉ set `_state.game_bundle` **sau** khi đã xác nhận đọc được (chuyển `bundle` thành
      biến local, chỉ gán vào `_state.game_bundle` ở 2 nhánh thành công) — không còn để
      `is_loaded() == True` với bundle rỗng khi validate fail
- [x] Test regression: `tests/gui_web/test_flask_app.py::test_load_file_on_an_unreadable_file_leaves_nothing_loaded`
      + `test_load_file_on_a_missing_path_leaves_nothing_loaded` — file rác/path không tồn tại →
      `is_loaded()` `False` + có `load_errors()`, không phải "loaded nhưng rỗng"
- [x] Theo quyết định Phase 17d (giữ route input-bundle debug, không xoá hẳn): `load_file` **không xoá**
      — vẫn hữu ích cho công cụ debug asset thô (`/Bundles/View` etc.), chỉ không còn được gọi từ nút
      Load chính của GUI nữa (đó là ý của 19a, không phải 19b)
- **Effort/Risk:** thấp/thấp như dự kiến

#### 19c — Progress khi load (không để browser treo 38 giây) ✅ `1e64fd3`

- [x] `game_file_loader.start_load`/`load_progress()` — background thread + `load_progress` state,
      giống hệt pattern `start_export`/`export_progress` (Phase 11): `/Load/Progress` (JSON) + poll ở
      `index.html`. Nút Load bị disable trong lúc chạy (chặn double-submit qua UI); `start_load` cũng tự
      `raise RuntimeError` nếu gọi chồng khi đang chạy (test riêng)
- [x] `progress_callback(message: str)` thêm vào `GameStructure.__init__`/`.load()`,
      `ExportHandler.load()`/`.load_and_process()` — 4 mốc thô đúng như kế hoạch: "Extracting
      archive…" → "Discovering platform structure…" → "Reading N file(s)…" → "Running processors…".
      Cố ý **không** báo % vì không có cách rẻ để biết tổng số trước (khác `ProjectExporter.export`'s
      progress theo từng asset, vốn đã biết tổng số collection trước)
- [x] `reset()` **cố ý không đụng** `load_progress` (ghi rõ trong docstring field) — `load_paths` tự gọi
      `reset()` làm bước đầu tiên của chính nó, và nếu `reset()` cũng xoá `load_progress` thì cờ
      `running: True` mà `start_load` vừa set sẽ bị chính lệnh gọi đó xoá mất giữa chừng
- [x] Trang chủ tự `location.reload()` sau khi load xong (thành công hay lỗi) để mọi phần phụ thuộc
      trạng thái (Load errors, Preview link, Export section) cập nhật đúng mà không cần JS tự vá từng
      phần
- **Effort/Risk:** thấp-trung bình/thấp như dự kiến
- **Ghi chú:** cơ chế `progress_callback` này **chưa** được nối vào Phase 17b's `build_export_plan` —
      build một `ExportPlan` cho game lớn cũng chạy `ExportHandler.export` đầy đủ nên cũng tốn thời
      gian tương tự, nhưng nối progress vào đó là việc của khi 17b thực sự cần (game nhỏ hiện tại
      không thấy vấn đề, xem Phase 17 rủi ro #2) — không mở rộng phạm vi 19c để làm luôn việc đó

#### 19d — Test ✅ `1e64fd3` (gộp luôn vào 19a/19b/19c ở trên thay vì tách riêng)

Bản kế hoạch gốc coi 19d là bước test riêng sau 19a; thực tế test được viết cùng lúc với từng sub-phase
(19a/19b/19c) để không bao giờ commit một sub-phase mà chưa có test đi kèm — xem checklist test cụ thể
ở từng mục trên. Việc còn lại của 19d:

- [x] Test cùng path apk giả qua cả `/LoadFile` và `/LoadFolder` → cùng kết quả (xong ở 19a)
- [x] Test file rác → `is_loaded()` `False` + có error (xong ở 19b, không phải "loaded nhưng rỗng" nữa)
- [x] Test GUI thật với `demo-android.apk` (xong ở 19a)
- [ ] `.ipa` thật: **vẫn chưa** đưa vào release gate (38s + 300MB) — số đo cũ (38s, Unity 2022.3.62f3,
      26 collection) đã ghi nhận ở đầu Phase 19, chưa đo lại lần này vì 19a/19b/19c không đổi hành vi
      xử lý `.ipa` (chỉ đổi route wiring + progress, đã verify bằng apk thật + apk giả)

**Thứ tự đã làm:** `19a` (gỡ bug user báo) → test 19a → `19c` (progress) → `19b` (fix state bug, sau
khi 17d đã chốt giữ route debug) — đúng thứ tự dự kiến.

#### Rủi ro riêng của Phase 16

1. **Không có fixture IL2CPP thật là blocker cứng, không phải chỉ là rủi ro.** Với bundle format
   (Phase 2/14) còn dựng được byte layout bằng tay vì format đơn giản và tự mình sinh được cả hai
   phía. Với `global-metadata.dat` thì "test parser của mình bằng file mình tự sinh" **không chứng
   minh được gì** về game thật — layout mới là ẩn số, không phải code đọc nó.
   → **16d/16e không nên bắt đầu trước khi có ít nhất một IL2CPP build thật** (một APK là đủ).
   16a/16b/16c thì không bị chặn.
2. **Metadata version drift.** Unity đổi layout `global-metadata.dat` giữa các version mà không có
   tài liệu chính thức (xem [Il2CppDumper#873](https://github.com/Perfare/Il2CppDumper/issues/873) —
   vẫn đang có người xin doc cho v31). Chốt range và fail rõ ràng ngoài range, đừng đoán.
3. **Game obfuscated/encrypted metadata** — ngoài scope, ghi rõ. Đây là mặc định ở nhiều game mobile
   thương mại, nên khả năng cao là game thật đầu tiên gặp phải sẽ fail vì lý do này chứ không phải
   vì parser sai. Phân biệt được hai nguyên nhân đó là việc bắt buộc trước khi debug.
4. **Regression lên đường TypeTree đang chạy đúng.** 16f chạm vào `game_asset_factory.py`, nơi mọi
   asset đi qua. Test regression trước khi sửa, không phải sau.
5. **Đây là phase lớn nhất kể từ Phase 1-3.** Tổng ~4000-6000 dòng nếu làm hết 16a-16f. Nếu chỉ tới
   `16c-alt` thì ~2500 dòng. Đừng bắt đầu nếu chưa chốt dừng ở đâu.

---

## Việc lẻ, chưa xếp phase

- [ ] `tests/io_endian/` và `tests/primitives/` là **thư mục rỗng** — `EndianSpanReader` và
      `UnityVersion`/`UnityGuid` hiện chỉ được test gián tiếp qua `import_`. Nên có unit test trực tiếp
- [ ] Bổ sung layout Phase 2 cho ~15 type còn thiếu (xem Phase 2)
- [ ] Bổ sung importer Phase 4 còn thiếu (xem Phase 4)
- [ ] Chưa port test upstream: `StrippedAssetTests`, `TextureImporterTests`, `PathIDCalculationTests`,
      `ExportTests`, và toàn bộ `AssetRipper.SerializationLogic.Tests`

**Thêm từ audit 2026-08-01:**

- [ ] `SceneAssetExporter.cs` / `SceneAssetExportCollection.cs` chưa port — `SceneAsset` (1032) là
      placeholder Unity dùng để một scene reference scene khác. Phase 12 dùng lại class ID này cho
      `SceneHierarchyObject` nên cần kiểm tra xung đột trước khi port
- [ ] `YamlStreamedAssetExporter.cs` / `YamlStreamedAssetExportCollection.cs` chưa port — YAML export
      cho asset có streamed data (Phase 9 chỉ làm nhánh binary dump)
- [ ] `ScriptableObjectGroupExporter.cs` chưa port (đi cùng 13h)
- [ ] `DeletedAssetsExporter.cs` / `DeletedAssetsExportCollection.cs` chưa port — premium-adjacent,
      chưa rõ có cần
- [ ] `LightmapTextureAssetExporter.cs`, `RawTextureExporter.cs` chưa port (đi cùng 13f/13i)
- [ ] `RedirectExportCollection.cs` / `SingleRedirectExportCollection.cs` — `single_redirect` đã có,
      `RedirectExportCollection` (bản nhiều asset) chưa
- [x] `VirtualFileSystem.cs` ✅ `a71bef0` — port ở `assetripper_io_files/virtual_file_system.py`, xem
      Phase 17, mục 17a.
- [ ] `GameInitializer.CustomResourceProvider.cs` chưa port (Phase 3 chỉ ghi nhận
      `EngineResourceInjector`/`VersionChanger` bị bỏ, thiếu mục này)
- [ ] `ObjectFactory` pattern (dùng bởi `SpriteProcessor` upstream, `AssetGroup`-tạo-theo-nhu-cầu) chưa
      có tương đương — Phase 12 tạo hierarchy trực tiếp. Xem lại khi làm 13c

---

## Ngoài scope vĩnh viễn

Đừng "sửa" những mục này — chúng được cân nhắc và loại có chủ đích.

| Mục | Lý do |
|---|---|
| Reproduce `AssetRipper.SourceGenerated` | 354 class ID × một class mỗi version range, sinh dưới dạng IL bởi toolchain 20k dòng từ NuGet feed private. Đã thay bằng dynamic reader |
| ~~C# script decompilation~~ | **Đã chuyển sang Phase 16** (không còn ngoài scope). Phần *thật sự* ngoài scope vĩnh viễn chỉ còn **method body** — xem 16g |
| ~~IL2Cpp script recovery~~ | **Đã chuyển sang Phase 16.** Cpp2IL không vendored nên không có gì để port, nhưng format `global-metadata.dat` + `Il2CppMetadataRegistration` là format file đọc được — cùng loại việc như bundle format đã làm ở Phase 2/14 |
| ~~MonoBehaviour field không có type tree~~ | **Đã chuyển sang Phase 16** (16f). Có type tree thì vẫn đọc bình thường như hiện tại — upstream cũng rẽ nhánh y vậy |
| Tpk type-tree database | Binary format không vendored; `nightly.link` và GitHub releases trả 403 qua proxy môi trường này |
| Crunch-compressed texture | `AssetRipper.Conversions.Crunch` là native crnlib port |
| Shader decompilation | **Upstream cũng chưa implement** |
| Asset dedup, static mesh separation, prefab outlining | Premium-only upstream; **không processor nào trong repo đọc setting đó** |
| Engine không phải Unity | Xem "Chỉ Unity" ở đầu mục "Mục tiêu & Scope" — không nằm trong scope, không có gì để port |
| Unity WebGL game theo URL (tải trực tiếp từ web) | Upstream cũng không có (không có `HttpClient`/`WebRequest` nào trong `Import`/`GUI.Web`). Xem ghi chú `- [~]` cuối Phase 14: khả thi nhưng là **feature mới**, cần quyết định policy network trước |

---

## Rủi ro đang mang

1. **Không có fixture Unity thật.** Mọi thứ verify bằng binary hand-built. Đây là rủi ro xuyên suốt.
   Phase 9 đặc biệt khó tin cậy nếu không có `.resS` thật để thử. **Nếu user cung cấp được một
   AssetBundle hoặc player build thật, chạy CLI lên nó ngay** — đó là cách duy nhất validate với
   output Unity thật. Với **Phase 16d/16e (IL2CPP)** thì đây không còn là rủi ro mà là **blocker
   cứng**: layout `global-metadata.dat` mới là ẩn số, nên tự sinh file rồi tự đọc lại không chứng
   minh được gì (xem "Rủi ro riêng của Phase 16" #1).
2. **Alignment / offset trong binary format** là nguồn lỗi âm thầm số một. Đã có 2 tiền lệ trong
   project: bug type-tree "string" node (ra `{}` thay vì giá trị), và implicit array alignment Unity
   >= 2017. Cả hai đều pass test cho tới khi test đúng chỗ.
3. **Processors và importers là reimplementation**, không phải port 1:1 — chúng mang nhiều behavioural
   uncertainty nhất so với upstream.
4. **Layout coverage hẹp** (5/20 type) — asset ngoài đó, trong file bị strip type tree, thành
   `UnknownObject`.
5. ~~**`ProjectSettings/` đang mất hoàn toàn**~~ — **đã sửa ở Phase 15** (phát hiện ở audit
   2026-08-01, cùng ngày đã port `ManagerAssetExporter`/`ManagerExportCollection`). Vẫn còn 2 việc
   nhỏ chưa làm trong nhóm này: `EditorBuildSettingsExportCollection` (`[~]`, giá trị thực tế thấp —
   xem Phase 15) và `EngineAssets`/`PredefinedAssetCache` (`[~]`, cần database built-in không
   vendored). Cả hai không chặn "project mở được" — chỉ thiếu build-settings scene list và asset
   built-in bị export trùng thay vì trỏ về bản gốc.
6. ~~**Input format coverage hẹp hơn platform coverage.**~~ — **đã sửa ở Phase 14**: WebGL/WebPlayer/
   pre-Unity-5.0 giờ đọc được (GZip/Brotli/WebFile/RawWeb/Zstd scheme đã port), không chỉ discovery.
   Vẫn chưa test trên game thật (xem rủi ro #1) — mọi verify vẫn là synthetic byte layout tự dựng.
7. **Số test cao không đồng nghĩa coverage cao.** 591 test nhưng 0 fixture Unity thật; nhiều nhánh
   "đã port" chỉ được test bằng chính giả định của người port (xem rủi ro #1). Test đếm được, độ đúng
   thì không.
