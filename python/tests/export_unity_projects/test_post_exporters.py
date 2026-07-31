from dataclasses import dataclass

from assetripper_export_unity_projects.post_exporters import DEFAULT_POST_EXPORTERS, run_default_post_exporters
from assetripper_export_unity_projects.project.package_manifest_post_exporter import PackageManifestPostExporter
from assetripper_export_unity_projects.project.project_version_post_exporter import ProjectVersionPostExporter
from assetripper_export_unity_projects.project.streaming_assets_post_exporter import StreamingAssetsPostExporter
from assetripper_export_modules.scripts.dll_post_exporter import DllPostExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


@dataclass
class _FakeGameData:
    platform_structure: object = None
    assembly_manager: object = None


def test_default_post_exporters_match_upstream_order():
    types = [type(p) for p in DEFAULT_POST_EXPORTERS]
    assert types == [
        ProjectVersionPostExporter,
        PackageManifestPostExporter,
        StreamingAssetsPostExporter,
        DllPostExporter,
    ]


def test_run_default_post_exporters_produces_project_scaffolding(tmp_path):
    run_default_post_exporters(_FakeGameData(), str(tmp_path), UnityVersion(2020, 1, 0), FS)

    assert (tmp_path / "ProjectSettings" / "ProjectVersion.txt").exists()
    assert (tmp_path / "Packages" / "manifest.json").exists()
    assert not (tmp_path / "Assets").exists()  # no platform structure -> nothing to copy
