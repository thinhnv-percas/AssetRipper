"""
Phase 16f part 2: tests for MonoAssemblyManager, the multi-assembly wrapper GameStructure
builds from PlatformGameStructure.assemblies -- lazy per-assembly parsing/caching on top of
the single-assembly mono_manager.py already covered by test_mono_manager*.py.
"""
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId
from assetripper_import.structure.assembly.managers.base_manager import BaseManager
from assetripper_import.structure.assembly.managers.mono_assembly_manager import MonoAssemblyManager
from assetripper_io_files.virtual_file_system import VirtualFileSystem

from ._module_builder import Coded, ModuleBuilder, wrap_pe


def _build_dll(assembly_name: str, type_name: str) -> bytes:
    b = ModuleBuilder()
    h = b.heaps
    h.add_guid()
    b.add_row(TableId.MODULE, generation=0, name=h.add_string(f"{assembly_name}.dll"), mvid=1, enc_id=0, enc_base_id=0)
    b.add_row(TableId.ASSEMBLY_REF, major_version=4, minor_version=0, build_number=0, revision_number=0,
              flags=0, public_key_or_token=h.add_blob(b""), name=h.add_string("mscorlib"), culture=h.add_string(""),
              hash_value=h.add_blob(b""))
    tr_object = b.add_row(
        TableId.TYPE_REF, resolution_scope=Coded("ResolutionScope", TableId.ASSEMBLY_REF, 1),
        name=h.add_string("Object"), namespace=h.add_string("System"),
    )
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string("<Module>"), namespace=h.add_string(""),
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )
    b.add_row(
        TableId.TYPE_DEF, flags=0, name=h.add_string(type_name), namespace=h.add_string("MyGame"),
        extends=Coded("TypeDefOrRef", TableId.TYPE_REF, tr_object), field_list=1, method_list=1,
    )
    b.add_row(TableId.FIELD, flags=0x0006, name=h.add_string("x"), signature=h.add_blob(bytes([0x06, 0x08])))
    return wrap_pe(b.build())


def _build_manager() -> MonoAssemblyManager:
    fs = VirtualFileSystem()
    fs.directory.create("/Managed")
    fs.file.write_all_bytes("/Managed/Assembly-CSharp.dll", _build_dll("Assembly-CSharp", "Foo"))
    fs.file.write_all_bytes("/Managed/Garbage.dll", b"not a real PE file")
    return MonoAssemblyManager(
        {"Assembly-CSharp.dll": "/Managed/Assembly-CSharp.dll", "Garbage.dll": "/Managed/Garbage.dll"}, fs
    )


def test_base_manager_resolves_nothing():
    manager = BaseManager()
    assert manager.get_serializable_type("Any", "Any", "Any") is None
    assert manager.get_recovered_type("Any", "Any", "Any") is None
    assert manager.get_assembly_file_paths() == {}


def test_resolves_a_type_from_the_right_assembly():
    manager = _build_manager()
    recovered = manager.get_recovered_type("Assembly-CSharp", "MyGame", "Foo")
    assert recovered is not None
    assert recovered.name == "Foo"

    serializable = manager.get_serializable_type("Assembly-CSharp", "MyGame", "Foo")
    assert serializable is not None
    assert [f.name for f in serializable.fields] == ["x"]


def test_unknown_assembly_name_resolves_to_none():
    manager = _build_manager()
    assert manager.get_serializable_type("NoSuchAssembly", "MyGame", "Foo") is None
    assert manager.get_recovered_type("NoSuchAssembly", "MyGame", "Foo") is None


def test_a_dll_that_fails_to_parse_is_cached_as_unresolvable():
    manager = _build_manager()
    assert manager.get_serializable_type("Garbage", "MyGame", "Foo") is None
    # Second call must not re-attempt parsing (and not raise) -- exercises the cache branch.
    assert manager.get_serializable_type("Garbage", "MyGame", "Foo") is None


def test_get_assembly_file_paths_returns_a_copy():
    manager = _build_manager()
    paths = manager.get_assembly_file_paths()
    assert paths == {
        "Assembly-CSharp.dll": "/Managed/Assembly-CSharp.dll",
        "Garbage.dll": "/Managed/Garbage.dll",
    }
    paths["Injected.dll"] = "/should/not/leak"
    assert "Injected.dll" not in manager.get_assembly_file_paths()
