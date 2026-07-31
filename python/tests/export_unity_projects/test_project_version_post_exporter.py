from assetripper_export_unity_projects.project.project_version_post_exporter import ProjectVersionPostExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


def test_writes_editor_version_line(tmp_path):
    ProjectVersionPostExporter().do_post_export(None, str(tmp_path), UnityVersion(2019, 4, 3), FS)

    text = (tmp_path / "ProjectSettings" / "ProjectVersion.txt").read_text(encoding="utf-8")
    assert text == "m_EditorVersion: 2019.4.3f0\n"


def test_unity_5_gets_extra_standard_assets_line(tmp_path):
    ProjectVersionPostExporter().do_post_export(None, str(tmp_path), UnityVersion(5, 6, 0), FS)

    text = (tmp_path / "ProjectSettings" / "ProjectVersion.txt").read_text(encoding="utf-8")
    assert text == "m_EditorVersion: 5.6.0f0\nm_StandardAssetsVersion: 0\n"


def test_non_unity_5_has_no_extra_line(tmp_path):
    ProjectVersionPostExporter().do_post_export(None, str(tmp_path), UnityVersion(2020, 1, 0), FS)

    text = (tmp_path / "ProjectSettings" / "ProjectVersion.txt").read_text(encoding="utf-8")
    assert "m_StandardAssetsVersion" not in text
