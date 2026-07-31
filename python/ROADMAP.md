# AssetRipper Python Port — Roadmap & Trạng thái

File này là **nguồn sự thật duy nhất** về tiến độ port AssetRipper (C#) sang Python.
Mọi agent/session làm việc trên project này đọc file này trước, và tự tick checkbox sau khi xong.

- **Branch:** `claude/convert-project-python-6mee7g`
- **Trạng thái:** Phase 1-9 xong. 547 tests pass. Commit cuối: xem heading Phase 9 bên dưới.
- Texture2D/AudioClip/Mesh giờ export được cả khi payload nằm ở `.resS` ngoài (Phase 9) — điểm
  chặn fidelity lớn nhất trên game thật đã gỡ. Vẫn **chưa test trên game thật** (xem Rủi ro #1).

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
| **8** | **Pipeline driver + wiring CLI/GUI** | ✅ `86cca85` |
| **9** | **Streamed data (`.resS`)** | ✅ xem heading Phase 9 |
| 10 | Settings model + trang Settings | ⬜ Chưa làm — **điểm chặn tiếp theo** |
| 11 | GUI overhaul | ⬜ Chưa làm |
| 12 | Prefab/Scene export (`.prefab`/`.unity`) | ⬜ Chưa làm |
| 13 | Asset type còn thiếu | ⬜ Chưa làm |

Số test theo area (tổng 547): `export_modules` 118, `io_files` 91, `import_` 100, `numerics` 64,
`assets` 48, `export_unity_projects` 37, `gui_web` 24, `io_files_bundle` 21, `cli` 12,
`processing` 16, `yaml` 11, `configuration` 5.

---

# PHẦN A — Đã làm (Phase 1-9)

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

### Phase 9 — Streamed data (`.resS`) ✅ (xem `git log` commit ngay sau Phase 8)

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

---

# PHẦN B — Cần làm (Phase 10-13)

### Phase 10 — Settings model + trang Settings ⬜

- [ ] `src/assetripper_export_configuration/` — enums port từ `Source/AssetRipper.Export/Configuration/`:
      `ImageExportFormat`, `AudioExportFormat`, `TextExportMode`, `ShaderExportMode`,
      `SpriteExportMode`, `TerrainExportMode`, `ScriptContentLevel`, `StreamingAssetsMode`
      (`BundledAssetsExportMode` đã có ở `assetripper_processing/configuration/`, reuse)
- [ ] `ExportSettings` / `ImportSettings` / `ProcessingSettings` / `FullConfiguration` dataclasses,
      persist JSON qua `assetripper_configuration` (đã port sẵn)
- [ ] `export_modules/registration.py` — `register_default_exporters(exporter, settings=None)`, chọn
      `DummyShaderTextExporter` vs `YamlShaderExporter` và text/image/audio format theo settings.
      Xoá được đúng cái comment *"This port has no settings system"* trong file đó
- [ ] `export_handler.py` nhận `settings`
- [ ] GUI `/Settings/Edit` → form thật (hiện `stub.html`)
- [ ] Tests + release gate + commit + push

### Phase 11 — GUI overhaul ⬜

Hiện GUI có 3 asset tab so với 12 của upstream; 4 trang là `stub.html`; không CSS framework; phải gõ
path bằng tay; không có progress.

- [ ] Vendor `bootstrap.min.css` vào `static/vendor/` (upstream cũng dùng Bootstrap — xem
      `OnlineDependencies.cs`). Khai báo trong `package-data` của `pyproject.toml`. **Vendor, không CDN**
      — tool desktop chạy qua `.bat`, phải hoạt động offline
- [ ] Layout mới: navbar, sidebar cây bundle/collection, card, table
- [ ] Asset tabs (3 → ~9), tận dụng exporter Phase 6/9: Image (PNG), Audio (`<audio>` + download),
      Text, Yaml, Model (`.glb` download), Font, Dependencies, Json
- [ ] Endpoints mới mirror `Pages/Assets/AssetAPI.cs`: `/Assets/Image`, `/Assets/Binary`,
      `/Assets/Text`, `/Assets/Yaml`
- [ ] Native file/folder picker qua `tkinter.filedialog` (tương đương `Dialogs.cs` + `NativeDialogs`),
      degrade về input text nếu không có display
- [ ] Auto-open browser khi chạy `assetripper-gui-web` (tương đương `WelcomeMessage.cs`)
- [ ] `progress_callback` optional trong `ProjectExporter.export` (docstring của nó đã tự ghi nhận
      thiếu chỗ này) + GUI poll/SSE hiện tiến độ
- [x] **Sửa nội dung sai** — làm sớm ở Phase 8 (không đợi Phase 11) vì sau khi wiring xong, nội dung
      cũ nói "pipeline không được port" trở thành active-wrong ngay lập tức: `templates/index.html`,
      `gui_web/__init__.py`
- [ ] Điền trang Licenses / Privacy, bỏ `stub.html` khỏi trang đã làm
- [ ] Cập nhật `run_gui.bat` nếu flow đổi
- [ ] Test Flask test-client cho mọi route mới + smoke test render từng tab
- [ ] Release gate + commit + push
- [~] Babylon.js 3D mesh preview — nặng vài MB vendored, `.glb` download đã đủ. Thêm sau nếu cần

### Phase 12 — Prefab/Scene export ⬜

Không có phase này thì project export ra **không có scene hay prefab nào** — chỉ asset rời rạc.

- [ ] `src/assetripper_processing/prefabs/prefab_processor.py` — gap Phase 5 bỏ sót
- [ ] Multi-asset-per-file YAML export: overload trong `export_unity_projects/asset_exporter.py`
      (docstring hiện ghi rõ *"The multi-asset-per-file overload (used upstream for scene/prefab files)
      is not ported"*)
- [ ] `ExportCollection` biến thể cho scene (`.unity`) / prefab (`.prefab`)
- [ ] Tests + release gate + commit + push

⚠️ Đây là phần coupling cao nhất: upstream manipulate typed property, port này phải làm qua dynamic
field access → reimplementation, không phải port 1:1.

### Phase 13 — Asset type còn thiếu ⬜

Thứ tự cost/benefit. Cắt theo nhu cầu thật, đừng làm hết cho đủ.

- [ ] `Sprite` + `SpriteProcessor` — rất phổ biến ở game 2D
- [ ] `AnimationClip`
- [ ] `Terrain` / `TerrainData`
- [ ] `AudioMixer` + `AudioMixerProcessor`
- [ ] `Cubemap` / `RenderTexture`
- [ ] `VideoClip` (streamed — cần Phase 9 trước)
- [ ] `LightingDataProcessor`
- [ ] `ScriptableObjectProcessor`

---

## Việc lẻ, chưa xếp phase

- [ ] `tests/io_endian/` và `tests/primitives/` là **thư mục rỗng** — `EndianSpanReader` và
      `UnityVersion`/`UnityGuid` hiện chỉ được test gián tiếp qua `import_`. Nên có unit test trực tiếp
- [ ] Bổ sung layout Phase 2 cho ~15 type còn thiếu (xem Phase 2)
- [ ] Bổ sung importer Phase 4 còn thiếu (xem Phase 4)
- [ ] Chưa port test upstream: `StrippedAssetTests`, `TextureImporterTests`, `PathIDCalculationTests`,
      `ExportTests`, và toàn bộ `AssetRipper.SerializationLogic.Tests`

---

## Ngoài scope vĩnh viễn

Đừng "sửa" những mục này — chúng được cân nhắc và loại có chủ đích.

| Mục | Lý do |
|---|---|
| Reproduce `AssetRipper.SourceGenerated` | 354 class ID × một class mỗi version range, sinh dưới dạng IL bởi toolchain 20k dòng từ NuGet feed private. Đã thay bằng dynamic reader |
| C# script decompilation | Cần ILSpy. Upstream có `ScriptExportMode.DllExportWithoutRenaming` làm việc tương đương |
| IL2Cpp script recovery | Cần Cpp2IL |
| MonoBehaviour field không có type tree | Cần IL field-layout analysis. Có type tree thì đọc bình thường — upstream cũng rẽ nhánh y vậy |
| Tpk type-tree database | Binary format không vendored; `nightly.link` và GitHub releases trả 403 qua proxy môi trường này |
| Crunch-compressed texture | `AssetRipper.Conversions.Crunch` là native crnlib port |
| Shader decompilation | **Upstream cũng chưa implement** |
| Asset dedup, static mesh separation, prefab outlining | Premium-only upstream; **không processor nào trong repo đọc setting đó** |

---

## Rủi ro đang mang

1. **Không có fixture Unity thật.** Mọi thứ verify bằng binary hand-built. Đây là rủi ro xuyên suốt.
   Phase 9 đặc biệt khó tin cậy nếu không có `.resS` thật để thử. **Nếu user cung cấp được một
   AssetBundle hoặc player build thật, chạy CLI lên nó ngay** — đó là cách duy nhất validate với
   output Unity thật.
2. **Alignment / offset trong binary format** là nguồn lỗi âm thầm số một. Đã có 2 tiền lệ trong
   project: bug type-tree "string" node (ra `{}` thay vì giá trị), và implicit array alignment Unity
   >= 2017. Cả hai đều pass test cho tới khi test đúng chỗ.
3. **Processors và importers là reimplementation**, không phải port 1:1 — chúng mang nhiều behavioural
   uncertainty nhất so với upstream.
4. **Layout coverage hẹp** (5/20 type) — asset ngoài đó, trong file bị strip type tree, thành
   `UnknownObject`.
