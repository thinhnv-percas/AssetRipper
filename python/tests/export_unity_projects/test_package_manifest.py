import json

from assetripper_export_unity_projects.project.package_manifest import create_default_manifest, save_manifest
from assetripper_export_unity_projects.project.package_manifest_post_exporter import PackageManifestPostExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


def test_default_manifest_has_always_present_dependencies():
    manifest = create_default_manifest(UnityVersion(2018, 4, 0))
    deps = manifest["dependencies"]
    assert deps["com.unity.modules.ai"] == "1.0.0"
    assert deps["com.unity.modules.xr"] == "1.0.0"
    assert "com.unity.modules.androidjni" not in deps


def test_androidjni_added_from_2019_2_onward():
    manifest = create_default_manifest(UnityVersion(2019, 2, 0))
    assert manifest["dependencies"]["com.unity.modules.androidjni"] == "1.0.0"

    manifest_older = create_default_manifest(UnityVersion(2019, 1, 0))
    assert "com.unity.modules.androidjni" not in manifest_older["dependencies"]


def test_ai_stays_first_in_insertion_order():
    manifest = create_default_manifest(UnityVersion(2020, 1, 0))
    assert next(iter(manifest["dependencies"])) == "com.unity.modules.ai"


def test_post_exporter_writes_valid_json_under_packages(tmp_path):
    PackageManifestPostExporter().do_post_export(None, str(tmp_path), UnityVersion(2020, 1, 0), FS)

    path = tmp_path / "Packages" / "manifest.json"
    document = json.loads(path.read_text(encoding="utf-8"))
    assert document["dependencies"]["com.unity.modules.ai"] == "1.0.0"


def test_save_manifest_writes_bytes_to_stream(tmp_path):
    file_path = tmp_path / "manifest.json"
    manifest = create_default_manifest(UnityVersion(2020, 1, 0))
    with FS.file.create(str(file_path)) as stream:
        save_manifest(manifest, stream)
    assert json.loads(file_path.read_text(encoding="utf-8")) == manifest
