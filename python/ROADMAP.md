# AssetRipper Python Port — Roadmap & Trạng thái

File này là **nguồn sự thật duy nhất** về tiến độ port AssetRipper (C#) sang Python.
Mọi agent/session làm việc trên project này đọc file này trước, và tự tick checkbox sau khi xong.

- **Branch:** `claude/convert-project-python-6mee7g`
- **Trạng thái:** Phase 1-12 xong (Phase 11, 12 mỗi cái một phần — xem ghi chú trong từng phase).
  591 tests pass. Commit cuối: `6b4fae3`.
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
| 13 | Asset type còn thiếu | ⬜ Chưa làm — **điểm chặn tiếp theo** |

Số test theo area (tổng 591): `export_modules` 123, `import_` 102, `io_files` 91, `numerics` 64,
`assets` 48, `export_unity_projects` 43, `gui_web` 42, `io_files_bundle` 21, `processing` 19,
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

# PHẦN B — Cần làm (Phase 13)

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
