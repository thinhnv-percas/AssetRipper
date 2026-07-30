"""Port of Source/AssetRipper.IO.Files/SerializedFiles/TransferInstructionFlags.cs"""
from __future__ import annotations

from enum import IntFlag


class TransferInstructionFlags(IntFlag):
    NO_TRANSFER_INSTRUCTION_FLAGS = 0x0
    NEEDS_INSTANCE_ID_REMAPPING = 0x1
    """Also called ReadWriteFromSerializedFile. Should PPtrs be converted to pathID/fileID
    via the PersistentManager, or should the memory InstanceID be stored in the fileID?"""
    ASSET_META_DATA_ONLY = 0x2
    """Only serialize data needed for .meta files."""
    YAML_GLOBAL_PPTR_REFERENCE = 0x4
    """Also called HandleDrivenProperties."""
    LOAD_AND_UNLOAD_ASSETS_DURING_BUILD = 0x8
    SERIALIZE_DEBUG_PROPERTIES = 0x10
    """Should debug properties be serialized (e.g. Mono private variables)?"""
    IGNORE_DEBUG_PROPERTIES_FOR_INDEX = 0x20
    """Should debug properties be ignored when calculating the TypeTree index?"""
    BUILD_PLAYER_ONLY_SERIALIZE_BUILD_PROPERTIES = 0x40
    """Used by the build player to make materials cull any properties that aren't used anymore."""
    WORKAROUND_35_MESH_SERIALIZATION_FUCKUP = 0x80
    """Also called IsCloningObject."""
    SERIALIZE_GAME_RELEASE = 0x100
    """Is this a game or a project file?"""
    SWAP_ENDIANESS = 0x200
    """Should endianess be swapped when reading/writing a file?"""
    SAVE_GLOBAL_MANAGERS = 0x400
    """Also called ResolveStreamedResourceSources. Should global managers be saved when
    writing the game build?"""
    DONT_READ_OBJECTS_FROM_DISK_BEFORE_WRITING = 0x800
    SERIALIZE_MONO_RELOAD = 0x1000
    """Should mono variables be backed up for an assembly reload?"""
    DONT_REQUIRE_ALL_META_FLAGS = 0x2000
    """Can Unity fast-path calculating all meta data? Skips a bunch of code when
    serializing mono data."""
    SERIALIZE_FOR_PREFAB_SYSTEM = 0x4000
    WARN_ABOUT_LEAKED_OBJECTS = 0x8000
    """Also called SerializeForSlimPlayer."""
    LOAD_PREFAB_AS_SCENE = 0x10000
    SERIALIZE_COPY_PASTE_TRANSFER = 0x20000
    EDITOR_PLAY_MODE = 0x40000
    """Also called SkipSerializeToTempFile."""
    BUILD_RESOURCE_IMAGE = 0x80000
    DONT_WRITE_UNITY_VERSION = 0x100000
    SERIALIZE_EDITOR_MINIMAL_SCENE = 0x200000
    """Binary scene files in the Editor. Causes PrefabInstance.RootGameObject to not be
    included in type trees (2018.3+ only; Prefab.RootGameObject is unaffected)."""
    GENERATE_BAKED_PHYSIX_MESHES = 0x400000
    THREADED_SERIALIZATION = 0x800000
    IS_BUILTIN_RESOURCES_FILE = 0x1000000
    PERFORM_UNLOAD_DEPENDENCY_TRACKING = 0x2000000
    DISABLE_WRITE_TYPE_TREE = 0x4000000
    AUTOREPLACE_EDITOR_WINDOW = 0x8000000
    DONT_CREATE_MONO_BEHAVIOUR_SCRIPT_WRAPPER = 0x10000000
    SERIALIZE_FOR_INSPECTOR = 0x20000000
    SERIALIZED_ASSET_BUNDLE_VERSION = 0x40000000
    """When writing with typetrees disabled, allow later Unity versions an attempt to
    read the SerializedFile."""
    ALLOW_TEXT_SERIALIZATION = 0x80000000


def is_release(flags: TransferInstructionFlags) -> bool:
    return bool(flags & TransferInstructionFlags.SERIALIZE_GAME_RELEASE)


def is_for_prefab(flags: TransferInstructionFlags) -> bool:
    return bool(flags & TransferInstructionFlags.SERIALIZE_FOR_PREFAB_SYSTEM)


def is_editor_scene(flags: TransferInstructionFlags) -> bool:
    return bool(flags & TransferInstructionFlags.SERIALIZE_EDITOR_MINIMAL_SCENE)


def is_builtin_resources(flags: TransferInstructionFlags) -> bool:
    return bool(flags & TransferInstructionFlags.IS_BUILTIN_RESOURCES_FILE)
