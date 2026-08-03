from dataclasses import dataclass, field

from assetripper_export_modules.scripts.dll_post_exporter import DllPostExporter
from assetripper_io_files.local_file_system import LocalFileSystem
from assetripper_primitives import UnityVersion

FS = LocalFileSystem()


@dataclass
class _FakeGameData:
    assembly_manager: object = None


@dataclass
class _FakeAssemblyManager:
    """Phase 16f: a real `MonoAssemblyManager`-shaped manager (`assembly_paths` -> only what
    `get_assembly_file_paths` needs), without depending on assetripper_import here."""

    paths: dict = field(default_factory=dict)

    def get_assembly_file_paths(self) -> dict:
        return dict(self.paths)


def test_no_assembly_manager_is_a_no_op(tmp_path):
    DllPostExporter().do_post_export(_FakeGameData(), str(tmp_path), UnityVersion(2020, 1, 0), FS)
    assert list(tmp_path.iterdir()) == []


def test_assembly_manager_with_no_assemblies_is_a_no_op(tmp_path):
    game_data = _FakeGameData(assembly_manager=_FakeAssemblyManager())
    DllPostExporter().do_post_export(game_data, str(tmp_path), UnityVersion(2020, 1, 0), FS)
    assert list(tmp_path.iterdir()) == []


def test_assembly_manager_copies_each_dll_into_auxiliary_files(tmp_path):
    source = tmp_path / "source"
    source.mkdir()
    (source / "Assembly-CSharp.dll").write_bytes(b"fake dll bytes")

    output = tmp_path / "output"
    output.mkdir()

    game_data = _FakeGameData(
        assembly_manager=_FakeAssemblyManager({"Assembly-CSharp.dll": str(source / "Assembly-CSharp.dll")})
    )
    DllPostExporter().do_post_export(game_data, str(output), UnityVersion(2020, 1, 0), FS)

    copied = output / "AuxiliaryFiles" / "GameAssemblies" / "Assembly-CSharp.dll"
    assert copied.read_bytes() == b"fake dll bytes"
