"""Tests for ROADMAP 16c-alt: recovering script types from user-supplied dummy `.dll` files.

The route this opens: an IL2CPP build has no `Managed/` directory, so the build-discovery pass
finds no assemblies and script recovery produces nothing but empty stubs. Pointing
`assembly_directories` at the output of an external dumper (Il2CppDumper / Cpp2IL /
DevX-GameRecovery) feeds those dummies to the same 16c metadata reader, giving Phase 16's full
output without this port parsing `global-metadata.dat` itself (16d/16e).

Assemblies here are built by `_module_builder`, the same hand-built ECMA-335 module the 16c
reader tests use -- so these exercise the real parse, not a stub.
"""
from __future__ import annotations

from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.game_structure import (
    _collect_assemblies_in_directories,
    _create_assembly_manager,
)
from assetripper_io_files.local_file_system import LocalFileSystem

from ._module_builder import Coded, ModuleBuilder, wrap_pe

FS = LocalFileSystem()

_INT_SIG = bytes([0x06, 0x08])
_PUBLIC = 0x0006


def _minimal_assembly(type_name: str) -> bytes:
    """One MonoBehaviour-derived type in namespace "Game" with a single public int field --
    the smallest module that proves the supplied `.dll` was really parsed (a stub or a
    fallback would not produce a field list)."""
    b = ModuleBuilder()
    h = b.heaps
    h.add_guid()
    b.add_row(TableId.MODULE, generation=0, name=h.add_string("Supplied.dll"), mvid=1, enc_id=0, enc_base_id=0)
    b.add_row(
        TableId.ASSEMBLY_REF, major_version=4, minor_version=0, build_number=0, revision_number=0,
        flags=0, public_key_or_token=h.add_blob(b""), name=h.add_string("UnityEngine"),
        culture=h.add_string(""), hash_value=h.add_blob(b""),
    )
    mono_behaviour = b.add_row(
        TableId.TYPE_REF, resolution_scope=Coded("ResolutionScope", TableId.ASSEMBLY_REF, 1),
        name=h.add_string("MonoBehaviour"), namespace=h.add_string("UnityEngine"),
    )

    # TypeDef row 1 must be the `<Module>` pseudo-type; its (empty) field range is what makes
    # the real type's field_list=1 unambiguous.
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string(type_name), namespace=h.add_string("Game"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, mono_behaviour), field_list=1, method_list=1,
    )
    b.add_row(TableId.FIELD, flags=_PUBLIC, name=h.add_string("health"), signature=h.add_blob(_INT_SIG))
    return wrap_pe(b.build())


def _write_assembly(directory, name: str, *, type_name: str = "Player") -> str:
    path = directory / name
    path.write_bytes(_minimal_assembly(type_name))
    return str(path)


def test_dll_files_in_the_directory_are_collected_by_file_name(tmp_path):
    _write_assembly(tmp_path, "Assembly-CSharp.dll")
    _write_assembly(tmp_path, "UnityEngine.CoreModule.dll")

    collected = _collect_assemblies_in_directories([str(tmp_path)], FS)

    assert set(collected) == {"Assembly-CSharp.dll", "UnityEngine.CoreModule.dll"}
    assert collected["Assembly-CSharp.dll"].endswith("Assembly-CSharp.dll")


def test_non_dll_files_are_ignored(tmp_path):
    """A dumper's output directory also holds `.json` dumps, `.h` headers and native `.so`
    libraries -- handing any of those to the metadata reader is a guaranteed parse failure."""
    _write_assembly(tmp_path, "Assembly-CSharp.dll")
    (tmp_path / "dump.cs").write_text("// not an assembly")
    (tmp_path / "libil2cpp.so").write_bytes(b"\x7fELF")
    (tmp_path / "script.json").write_text("{}")

    assert set(_collect_assemblies_in_directories([str(tmp_path)], FS)) == {"Assembly-CSharp.dll"}


def test_extension_match_is_case_insensitive(tmp_path):
    _write_assembly(tmp_path, "Mixed.DLL")
    assert set(_collect_assemblies_in_directories([str(tmp_path)], FS)) == {"Mixed.DLL"}


def test_subdirectories_are_not_walked(tmp_path):
    """Deliberately non-recursive: a dumper writes the assemblies flat, and descending would
    start picking up unrelated files from sibling output directories."""
    _write_assembly(tmp_path, "Top.dll")
    nested = tmp_path / "nested"
    nested.mkdir()
    _write_assembly(nested, "Nested.dll")

    assert set(_collect_assemblies_in_directories([str(tmp_path)], FS)) == {"Top.dll"}


def test_missing_directory_is_a_warning_not_a_crash(tmp_path):
    """A stale path in saved settings must not take the whole load down with it."""
    _write_assembly(tmp_path, "Real.dll")
    collected = _collect_assemblies_in_directories(
        [str(tmp_path / "does-not-exist"), str(tmp_path)], FS
    )
    assert set(collected) == {"Real.dll"}


def test_several_directories_are_merged(tmp_path):
    first = tmp_path / "a"
    second = tmp_path / "b"
    first.mkdir()
    second.mkdir()
    _write_assembly(first, "First.dll")
    _write_assembly(second, "Second.dll")

    collected = _collect_assemblies_in_directories([str(first), str(second)], FS)
    assert set(collected) == {"First.dll", "Second.dll"}


def test_later_directory_wins_a_same_name_collision(tmp_path):
    first = tmp_path / "a"
    second = tmp_path / "b"
    first.mkdir()
    second.mkdir()
    _write_assembly(first, "Assembly-CSharp.dll")
    _write_assembly(second, "Assembly-CSharp.dll")

    collected = _collect_assemblies_in_directories([str(first), str(second)], FS)
    assert collected["Assembly-CSharp.dll"].startswith(str(second))


class _FakeStructure:
    def __init__(self, assemblies):
        self.assemblies = assemblies


def test_manager_reads_real_types_out_of_a_supplied_assembly(tmp_path):
    """The load-bearing assertion: the supplied `.dll` reaches the 16c reader and its types come
    back with real field layouts, which is the whole point of the shortcut."""
    _write_assembly(tmp_path, "Assembly-CSharp.dll", type_name="Enemy")

    manager = _create_assembly_manager(None, _FakeStructure({}), FS, [str(tmp_path)])

    assert manager is not None
    recovered = manager.get_recovered_type("Assembly-CSharp", "Game", "Enemy")
    assert recovered is not None
    assert recovered.name == "Enemy"
    serializable = manager.get_serializable_type("Assembly-CSharp", "Game", "Enemy")
    assert serializable is not None
    assert [field.name for field in serializable.fields] == ["health"]


def test_supplied_assembly_wins_over_a_same_named_one_in_the_build(tmp_path):
    """Passing the directory at all is a deliberate act, so it's read as "use these". A real
    Mono build is the only case where a collision is even possible, and there the user pointing
    at their own dumped/patched copy is the more specific instruction."""
    build_dir = tmp_path / "build"
    supplied = tmp_path / "supplied"
    build_dir.mkdir()
    supplied.mkdir()
    build_path = _write_assembly(build_dir, "Assembly-CSharp.dll")
    supplied_path = _write_assembly(supplied, "Assembly-CSharp.dll")

    manager = _create_assembly_manager(
        None, _FakeStructure({"Assembly-CSharp.dll": build_path}), FS, [str(supplied)]
    )

    assert manager.get_assembly_file_paths()["Assembly-CSharp.dll"] == supplied_path


def test_build_assemblies_still_used_when_no_directory_is_supplied(tmp_path):
    path = _write_assembly(tmp_path, "Assembly-CSharp.dll")
    manager = _create_assembly_manager(None, _FakeStructure({"Assembly-CSharp.dll": path}), FS, ())
    assert manager.get_assembly_file_paths() == {"Assembly-CSharp.dll": path}


def test_no_assemblies_anywhere_still_yields_no_manager(tmp_path):
    """`None` (not an empty manager) is the pre-16c-alt contract every caller already handles."""
    empty = tmp_path / "empty"
    empty.mkdir()
    assert _create_assembly_manager(None, _FakeStructure({}), FS, [str(empty)]) is None
