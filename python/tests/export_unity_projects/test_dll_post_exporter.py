from dataclasses import dataclass

from assetripper_export_modules.scripts.dll_post_exporter import DllPostExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


@dataclass
class _FakeGameData:
    assembly_manager: object = None


def test_no_assembly_manager_is_a_no_op(tmp_path):
    DllPostExporter().do_post_export(_FakeGameData(), str(tmp_path), UnityVersion(2020, 1, 0), FS)
    assert list(tmp_path.iterdir()) == []
