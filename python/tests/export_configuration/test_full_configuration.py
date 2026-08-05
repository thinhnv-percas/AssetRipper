"""Round-trip tests for the Phase 10 settings model
(src/assetripper_export_configuration/): each dataclass's to_dict/from_dict, and
FullConfiguration's JSON save/load."""
from assetripper_export_configuration.audio_export_format import AudioExportFormat
from assetripper_export_configuration.export_settings import ExportSettings
from assetripper_export_configuration.full_configuration import FullConfiguration
from assetripper_export_configuration.image_export_format import (
    ImageExportFormat,
    get_pillow_format_and_extension,
)
from assetripper_export_configuration.import_settings import ImportSettings
from assetripper_export_configuration.processing_settings import ProcessingSettings
from assetripper_export_configuration.script_content_level import ScriptContentLevel
from assetripper_export_configuration.shader_export_mode import ShaderExportMode
from assetripper_export_configuration.streaming_assets_mode import StreamingAssetsMode
from assetripper_export_configuration.text_export_mode import TextExportMode
from assetripper_primitives import UnityVersion
from assetripper_processing.configuration.bundled_assets_export_mode import BundledAssetsExportMode


def test_export_settings_round_trips_through_dict():
    settings = ExportSettings(
        audio_export_format=AudioExportFormat.PREFER_WAV,
        image_export_format=ImageExportFormat.JPEG,
        shader_export_mode=ShaderExportMode.YAML,
        text_export_mode=TextExportMode.TXT,
        export_unreadable_assets=True,
    )
    assert ExportSettings.from_dict(settings.to_dict()) == settings


def test_import_settings_round_trips_including_unity_version():
    settings = ImportSettings(
        script_content_level=ScriptContentLevel.LEVEL_0,
        streaming_assets_mode=StreamingAssetsMode.IGNORE,
        default_version=UnityVersion(2019, 4, 0),
        target_version=None,
    )
    round_tripped = ImportSettings.from_dict(settings.to_dict())
    assert round_tripped == settings
    assert round_tripped.ignore_streaming_assets is True


def test_import_settings_defaults_have_extract_not_ignore():
    settings = ImportSettings()
    assert settings.ignore_streaming_assets is False


def test_processing_settings_default_matches_upstream_direct_export():
    # Phase 5/8's own default_processors() had defaulted to GROUP_BY_ASSET_TYPE; this
    # settings model corrects that deviation -- see processing_settings.py's docstring.
    assert ProcessingSettings().bundled_assets_export_mode == BundledAssetsExportMode.DIRECT_EXPORT


def test_processing_settings_round_trips_through_dict():
    settings = ProcessingSettings(
        bundled_assets_export_mode=BundledAssetsExportMode.GROUP_BY_BUNDLE_NAME,
        remove_nullable_attributes=True,
        publicize_assemblies=True,
    )
    assert ProcessingSettings.from_dict(settings.to_dict()) == settings


def test_full_configuration_round_trips_through_dict():
    config = FullConfiguration(
        import_settings=ImportSettings(streaming_assets_mode=StreamingAssetsMode.IGNORE),
        export_settings=ExportSettings(image_export_format=ImageExportFormat.TGA),
        processing_settings=ProcessingSettings(publicize_assemblies=True),
    )
    assert FullConfiguration.from_dict(config.to_dict()) == config


def test_full_configuration_save_and_load_json_file(tmp_path):
    config = FullConfiguration(export_settings=ExportSettings(audio_export_format=AudioExportFormat.NATIVE))
    path = str(tmp_path / "settings.json")
    config.save(path)
    assert FullConfiguration.load(path) == config


def test_full_configuration_defaults_are_used_when_unset():
    assert FullConfiguration() == FullConfiguration.from_dict({})


def test_get_pillow_format_and_extension_maps_every_member():
    expected = {
        ImageExportFormat.BMP: ("BMP", "bmp"),
        ImageExportFormat.JPEG: ("JPEG", "jpeg"),
        ImageExportFormat.PNG: ("PNG", "png"),
        ImageExportFormat.TGA: ("TGA", "tga"),
        # EXR/HDR fall back to Png -- neither format has a Pillow encoder available here.
        ImageExportFormat.EXR: ("PNG", "png"),
        ImageExportFormat.HDR: ("PNG", "png"),
    }
    for member, (pillow_format, extension) in expected.items():
        assert get_pillow_format_and_extension(member) == (pillow_format, extension)
