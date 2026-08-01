# AssetRipper Python Port — Roadmap & Trạng thái

File này là **nguồn sự thật duy nhất** về tiến độ port AssetRipper (C#) sang Python.
Mọi agent/session làm việc trên project này đọc file này trước, và tự tick checkbox sau khi xong.

- **Branch:** `claude/convert-project-python-6mee7g`
- **Trạng thái:** Phase 1-12, 14, 15 xong, Phase 13 và 16 đang làm (13a, 16b xong, xem PHẦN B).
  641 tests pass. Commit cuối: `PHASE16B_HASH`.
- Texture2D/AudioClip/Mesh giờ export được cả khi payload nằm ở `.resS` ngoài (Phase 9) — điểm
  chặn fidelity lớn nhất trên game thật đã gỡ. Vẫn **chưa test trên game thật** (xem Rủi ro #1).
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
- **Phase 13a xong** (VideoClip, xem PHẦN B): dùng lại `streamed_resource.py` (Phase 9). Còn 13b
  (Sprite export) → 13i, mỗi sub-phase một commit riêng.
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
| Managed `.dll` (Mono `Managed/*.dll`) | ✅ | ❌ | **Phase 16** — `mono_assembly_predicate.py` chỉ nhận diện đuôi `.dll` để báo `ScriptingBackend.MONO`, chưa đọc metadata bên trong |

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
| Script `.cs` có **declaration thật** (class/field/property/method signature) | ❌ | **Phase 16** — dựng lại từ IL2CPP metadata / Mono `.dll`. Đây là mức mà upstream **và mọi tool trên thị trường** đạt được |
| MonoBehaviour **field value** khi asset không có type tree | ❌ | **Phase 16** — cùng một lần parse ra `SerializableType`; hiện các asset này rơi vào `UnknownObject`. Giá trị thực tế **cao hơn** cả bản thân file `.cs` |
| **`ProjectSettings/*.asset`** (PlayerSettings, DynamicsManager, TagManager, …) | ✅ | Phase 15 — `ManagerAssetExporter`/`ManagerExportCollection` |
| Reference tới built-in Unity asset (default material, built-in shader…) | ❌ | **Phase 15 `[~]`** — `EngineAssetsExporter`/`PredefinedAssetCache` chưa xếp lịch (cần database asset built-in theo Unity version không vendored) → asset built-in bị export trùng thay vì trỏ về asset gốc của Unity |
| `.cs` có **method body thật** (logic game chạy được) | ❌ | **Ngoài scope vĩnh viễn** — với IL2CPP thì *không tool nào làm được tin cậy*, kể cả upstream (xem Phase 16g cho evidence). Với Mono thì cần một IL→C# decompiler cỡ ILSpy |

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
| 13 | Asset type còn thiếu (13a-13i) | 🟡 Đang làm — 13a ✅ `25d7b0b`, còn 13b-13i |
| **14** | **Input format còn thiếu (WebGL/WebPlayer/pre-5.0/Zstd)** | ✅ `5cc200a` |
| **15** | **Exporter thiếu ảnh hưởng "project mở được"** | ✅ `994daee` (một phần — `EditorBuildSettingsExportCollection`/`EngineAssets` vẫn `[~]`, xem ghi chú) |
| 16 | **Dựng lại `.cs` từ IL2CPP / Mono** (16a-16g) | 🟡 Đang làm — 16b ✅ `PHASE16B_HASH`. `16d`/`16e` **bị chặn** tới khi có IL2CPP build thật |

Số test theo area (tổng 641): `export_modules` 132, `import_` 105, `io_files` 105, `numerics` 64,
`assets` 48, `export_unity_projects` 59, `gui_web` 42, `io_files_bundle` 29, `processing` 19,
`cli` 13, `yaml` 11, `export_configuration` 9, `configuration` 5.

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
      thường (site.css có ghi chú rõ đây là nợ kỹ thuật tạm thời, không phải quên)

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

# PHẦN B — Còn lại: Phase 13 (đang làm) và Phase 16

Thứ tự đã làm: **Phase 15 → 14 → 13** (đúng thứ tự đề xuất ban đầu). Phase 15 (`ProjectSettings/`)
và Phase 14 (input format) đã xong, xem ghi chú trong từng phase bên dưới.

Còn lại hai phase, **độc lập nhau, chọn theo mục tiêu**:

- **Phase 13** (13a ✅, còn 13b-13i) — fidelity từng asset type. Tăng dần, chia nhỏ được, rủi ro thấp
  ở phần lớn item. Chọn cái này nếu mục tiêu là "asset export ra đúng hơn".
- **Phase 16** — dựng lại `.cs` từ IL2CPP/Mono metadata. Phase lớn nhất còn lại và cũng là thứ duy
  nhất còn chặn tiêu chí "project mở ra giống project gốc": hiện mọi script vẫn là dummy class và
  MonoBehaviour không có type tree thì mất sạch field value. Chọn cái này nếu mục tiêu là "code và
  data của component phải thật".

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

#### 13b — Sprite export (không kèm atlas math)

- [ ] `export_modules/sprite_exporter.py` — port `Textures/YamlSpriteExporter.cs`: `Sprite` (213) →
      `.asset` YAML; `SpriteAtlas` (687078895) → **skip hẳn** (upstream trả
      `EmptyExportCollection.Instance`). Cần port `EmptyExportCollection` (40 dòng, chưa có ở port này)
- **Hiện có:** `Sprite` export ra `.asset` YAML đúng; nhưng `SpriteAtlas` **cũng** export ra `.asset`
      → Unity Editor sẽ thử pack lại atlas đã pack, upstream skip chính vì lý do đó
- **Thiếu:** skip `SpriteAtlas`; `EmptyExportCollection`
- **Effort/Risk:** thấp/thấp — thuần chọn collection, không có math

#### 13c — SpriteProcessor (atlas coordinate recovery)

- [ ] `processing/textures/sprite_processor.py` — port `Textures/SpriteProcessor.cs` (136 dòng) +
      `SpriteExtensions.GetSpriteCoordinatesInAtlas` (~50 dòng math) + `SpriteInformationObject`
- **Hiện có:** sprite **không** thuộc atlas export đúng (field `m_RD` gốc đã đủ). Sprite **thuộc**
      atlas export ra rect/pivot/border **sai** (không recover từ `m_RD` của atlas)
- **Thiếu:** copy `m_RD` từ `SpriteAtlas.RenderDataMap`; recalc `Rect`/`Pivot`/`Border`/`Offset`/
      `TextureRectOffset`; clear reference tới atlas (Unity Editor crash nếu không clear)
- **Effort/Risk:** trung bình/**CAO** — pivot/rect/border math, sai một chút là sprite lệch **âm thầm**.
      ⚠️ **Nên có fixture Unity thật (một game 2D có SpriteAtlas) trước khi làm**, hoặc ít nhất dựng
      test tính tay từng bước theo đúng công thức C#. Đây là item risk cao nhất trong Phase 13
- **Blocked-by:** 13b (cần Sprite export trước mới thấy được kết quả)

#### 13d — AudioMixer + AudioMixerProcessor

- [ ] `processing/audio_mixers/audio_mixer_processor.py` — port `AudioMixers/AudioMixerProcessor.cs`
      (317 dòng): dựng lại cây `AudioMixerGroup`/`AudioMixerSnapshot`/effect từ array phẳng
- [ ] `export_modules/audio_mixer_exporter.py` — port `AudioMixers/AudioMixerExporter.cs` (24 dòng)
- **Hiện có:** `AudioMixer` ra `.mixer` YAML, nhưng group/snapshot/effect vẫn là asset rời không có
      quan hệ cha-con → mixer mở trong Unity sẽ rỗng/phẳng
- **Thiếu:** toàn bộ phần tái tạo cây
- **Effort/Risk:** cao/trung bình — nhiều code nhưng là logic gom nhóm rõ ràng, không phải math

#### 13e — AnimatorController + AnimatorControllerProcessor

- [ ] `processing/animator_controllers/animator_controller_processor.py` — port
      `AnimatorControllers/AnimatorControllerProcessor.cs` (168 dòng)
- [ ] `export_modules/animator_controller_exporter.py` — port `AnimatorControllerExporter.cs`
- **Hiện có:** `AnimationClip`→`.anim` và `AnimatorController`→`.controller` đều ra YAML đúng extension
      (**"AnimationClip" trong danh sách cũ coi như đã xong** ở mức YAML — nó không có exporter riêng
      ở upstream, cũng đi qua `DefaultYamlExporter`)
- **Thiếu:** state machine / state / transition chưa được dựng thành asset con của controller
- **Effort/Risk:** trung bình/trung bình

#### 13f — Cubemap / Texture2DArray (ảnh thật, không chỉ YAML)

- [ ] Mở rộng `texture2d_exporter.py` (hoặc thêm `texture_array_exporter.py`) — port
      `Textures/TextureArrayAssetExporter.cs` (95 dòng): Cubemap (89) → 6 mặt, Texture2DArray (187) →
      N slice, Texture3D → N slice
- **Hiện có:** `Cubemap`→`.cubemap` YAML (metadata đúng, **không có pixel**)
- **Thiếu:** decode + ghi ảnh từng mặt/slice
- **Effort/Risk:** trung bình/thấp — dùng lại `texture_converter.py` đã có, chỉ thêm vòng lặp slice
- **Ghi chú:** `RenderTexture` (84) **không cần làm gì thêm** — nó là buffer runtime, không có pixel
      data trên đĩa; `.renderTexture` YAML hiện tại **đã là đúng và đủ**

#### 13g — TerrainData

- [ ] `export_modules/terrain_exporter.py` — port `Terrains/TerrainYamlExporter.cs` (18 dòng) +
      `TerrainYamlExportCollection`
- **Hiện có:** `TerrainData`→`.asset` YAML (upstream cũng dùng `.asset`) — **đã gần đúng**
- **Thiếu:** `TerrainYamlExportCollection` (xử lý heightmap/alphamap texture kèm theo);
      `TerrainExportMode.MESH`/`HEATMAP` (enum đã declare ở Phase 10, chưa ai đọc)
- **Effort/Risk:** thấp-trung bình/thấp cho nhánh YAML; cao cho nhánh Mesh/Heatmap (cần tự sinh mesh)

#### 13h — ScriptableObjectProcessor

- [ ] `processing/scriptable_object/scriptable_object_processor.py` — port (193 dòng): gom
      `MonoBehaviour` thành group (Timeline asset, PostProcess profile)
- **Hiện có:** `MonoBehaviour`→`.asset` YAML rời
- **Thiếu:** gom nhóm → Timeline/PostProcess mở được trong Editor
- **Effort/Risk:** trung bình/trung bình. Phụ thuộc `IsTimelineAsset()`/`IsPostProcessProfile()` — đọc
      script class name, port này có `MonoScriptInfo` sẵn nên khả thi

#### 13i — LightingDataProcessor (làm cuối)

- [ ] `processing/lighting_data_processor.py` — port `LightingDataProcessor.cs` (409 dòng)
- **Hiện có:** `LightingDataAsset`→`.asset` YAML rời
- **Thiếu:** gắn lightmap/lightprobe vào scene tương ứng
- **Effort/Risk:** cao/cao — file lớn nhất nhóm này, coupling với scene (Phase 12) và lightmap texture.
      Giá trị thấp nhất cho phần lớn dự án → để cuối

- [ ] Release gate + commit + push (mỗi sub-phase một commit riêng, đừng gộp)

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

### Phase 16 — Dựng lại `.cs` từ IL2CPP / Mono ⬜

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

#### 16a — Serialization rules (`WillUnitySerialize`) — ⚠️ **điều chỉnh sau khi đọc kỹ**

- [ ] `assetripper_serialization_logic/field_serializer.py` — port `FieldSerializer.Logic.cs` (phần
      `WillUnitySerialize` + `IsValueTypeSerializable` + các version gate). Các version boundary
      upstream đã ghi sẵn trong comment và phải giữ nguyên: struct serializable từ 4.5;
      int8/int16/uint16/uint32 từ 5.0; char/int64 từ 2017; generic (ngoài `List<T>` và
      `ExposedReference<T>`) từ 2020
- **⚠️ Sửa lại nhận định "không phụ thuộc gì" ở lần viết plan trước** (sau khi đọc hết
      `FieldSerializer.Logic.cs` + `EngineTypePredicates.cs` để bắt đầu implement): claim đó sai.
      Gần một nửa hàm (`IsDelegate`, `ShouldNotTryToResolve`, `IsUnityEngineObject`,
      `IsSerializableUnityClass`, `ShouldImplementIDeserializable`, …) gọi
      `type.IsAssignableTo(namespace, name, runtimeContext)` — một phép walk lên chuỗi base-type
      **xuyên across assembly đã load**. Không có một "type universe" để walk thì không thể port
      trung thực các hàm này bằng field riêng lẻ; mock rời rạc sẽ cho kết quả không khớp AsmResolver
      thật và phải viết lại khi có reader thật. **Việc này gộp chung với 16c/16d** thay vì đứng một
      mình — bất kỳ ai nhặt lại 16a sau này nên đọc lại `EngineTypePredicates.cs` trước khi bắt đầu
- **Hiện có:** không. `SerializableType` có sẵn nhưng chỉ được dựng từ TypeTree (`SerializableTreeType`)
- **Effort/Risk:** trung bình/trung bình (đã tăng so với đánh giá lần đầu — không còn "pure function")
- **Phụ thuộc:** 16c hoặc 16d (cần một type-resolution context thật, không mock được đáng tin cậy)

#### 16b — Emitter `.cs` từ một type model trung lập ✅ `PHASE16B_HASH`

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

#### 16c — Nhánh Mono: đọc metadata .NET từ `.dll`

- [ ] `assetripper_import/structure/assembly/managers/mono_manager.py` + reader ECMA-335:
      PE header → CLI header → metadata root → các table cần dùng (`Assembly`, `Module`, `TypeDef`,
      `TypeRef`, `TypeSpec`, `Field`, `MethodDef`, `Param`, `CustomAttribute`, `Constant`,
      `NestedClass`, `InterfaceImpl`, `GenericParam`, `MemberRef`) + heap (`#Strings`, `#Blob`,
      `#GUID`, `#US`) + decoder cho signature blob. Đây cũng chính là "type universe" mà 16a cần —
      khi làm 16c, port `WillUnitySerialize` (16a) lồng vào đây luôn, tra thẳng vào `TypeDef`/`TypeRef`
      table thay vì AsmResolver's `RuntimeContext`
- **Tại sao làm trước IL2CPP:** không cần parse native binary, spec ECMA-335 công khai và đầy đủ,
      **và nó validate toàn bộ 16a + 16b + 16f end-to-end** trước khi bước vào phần rủi ro cao nhất.
      Không có chỗ nào "đoán" — sai là sai rõ ràng
- **Effort/Risk:** trung bình-cao/thấp — khối code lớn nhất trong phase (~1500-2500 dòng) nhưng
      **không có ẩn số**. Test được bằng cách tự compile một `.dll` nhỏ? Không có .NET SDK ở môi
      trường này → dựng byte layout bằng tay như `_tree_builder.py`/`_bundle_builder.py` đã làm, cộng
      test trên `.dll` thật nếu user cung cấp được
- **Phụ thuộc:** 16a, 16b

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

- [ ] `assetripper_import/structure/assembly/managers/base_manager.py` — interface chung
      (`get_serializable_type(assembly, namespace, class_name) -> SerializableType | None`) để
      `GameStructure`/`ExportHandler` không cần biết backend là Mono hay IL2CPP
- [ ] `unloaded_structure.py` — port `UnloadedStructure.cs`: MonoBehaviour đọc **lazy** sau khi mọi
      asset đã load (vì MonoBehaviour có thể load trước MonoScript nó trỏ tới). Đây là mảnh làm
      field value trở thành thật
- [ ] `game_asset_factory.py` — hiện MonoBehaviour không có type tree → `UnknownObject`
      (xem docstring của nó). Thêm nhánh: có assembly manager thì dựng `UnloadedStructure`
- [ ] `script_exporter.py` — bỏ giả định `AssemblyManager.IsSet` luôn `False` (ghi thẳng trong
      docstring hiện tại), nối vào 16b để ra `.cs` thật; giữ `EmptyScriptExportCollection` làm fallback
- [ ] `ScriptContentLevel` (đã có ở `assetripper_export_configuration`, Phase 10) — nối cho thật:
      Level0 = không load, Level1 = stub, Level2 = default
- **Effort/Risk:** trung bình/trung bình — chỗ dễ vỡ là regression trên đường TypeTree đang chạy tốt.
      **Bắt buộc:** test khẳng định asset *có* type tree vẫn đi đường cũ, không đổi output
- **Phụ thuộc:** 16c (hoặc 16c-alt), hoặc 16d+16e

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
- [ ] `VirtualFileSystem.cs` chưa port — `FileSystem` hiện chỉ có `LocalFileSystem`. Cần nếu muốn test
      export không chạm đĩa thật, hoặc load từ archive không giải nén ra temp
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
