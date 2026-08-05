"""Port of Source/AssetRipper.Import/AssetCreation/TypeTreeObject.cs

An IUnityObjectBase backed entirely by a SerializableStructure, i.e. an asset read purely
from its type tree with no generated class involved. This replaces the placeholder
`RawAsset` the GUI used previously.

Only `SingleTypeTreeObject` is ported. `DoubleTypeTreeObject` exists upstream to hold a
release tree and an editor tree side by side, converting between them via CopyValues; it is
only constructible from the Tpk database (which supplies both trees for a class/version),
and a SerializedFile's embedded tree gives just one. Revisit if the Tpk path is added.

`StructureBackedAsset` factors out everything below "how the SerializableStructure was
built" so `structure.assembly.managers.unloaded_structure` (Phase 16f) can reuse the same
asset shape for a MonoBehaviour resolved from Mono metadata instead of a TypeTreeNodeStruct,
without duplicating the field-access/traversal forwarding.
"""
from __future__ import annotations

from assetripper_assets.null_object import NullObject

from ..structure.assembly.type_trees.serializable_tree_type import SerializableTreeType


class StructureBackedAsset(NullObject):
    """Note: upstream derives from NullObject so that these never masquerade as real typed
    assets -- `AssetCollection.get_asset` filters NullObject out unless explicitly asked
    for it. That behaviour is inherited here."""

    def __init__(self, asset_info, structure):
        super().__init__(asset_info)
        self.fields = structure

    @property
    def is_player_settings(self) -> bool:
        return self.class_id == 129

    @property
    def name(self) -> str | None:
        """Stand-in for upstream's `INamed` marker interface: every generated class that
        actually has an `m_Name` field implements `INamed.Name` typed to that field, which
        `IUnityObjectBase.get_best_name()` falls back to via `getattr(self, "name", None)`.
        A dynamically-read asset has no generated interface to implement, so without this
        property that fallback was silently dead -- every such asset's "best name" fell
        straight through to its class name, discovered while naming Phase 12's synthesized
        `.prefab` files. Returns None (same as `INamed` simply not being implemented) for
        classes with no `m_Name` field. Doesn't affect `__str__`/`__repr__` below, which
        intentionally still show the class name."""
        value = self.get("m_Name")
        return value if isinstance(value, str) else None

    @property
    def release_fields(self):
        return self.fields

    @property
    def editor_fields(self):
        return self.fields

    @property
    def flow_mapped_in_yaml(self) -> bool:
        return self.fields.flow_mapped_in_yaml

    @property
    def serialized_version(self) -> int:
        return self.fields.serialized_version

    @property
    def class_name(self) -> str:
        return self.fields.type.name

    # -- reading --

    def read_release(self, reader) -> None:
        self.fields.read(reader, self.collection.version, self.collection.flags)

    def read_editor(self, reader) -> None:
        self.fields.read(reader, self.collection.version, self.collection.flags)

    # -- traversal --

    def walk_release(self, walker) -> None:
        self.fields.walk_release(walker)

    def walk_editor(self, walker) -> None:
        self.fields.walk_editor(walker)

    def walk_standard(self, walker) -> None:
        self.fields.walk_standard(walker)

    def fetch_dependencies(self):
        return self.fields.fetch_dependencies()

    def reset(self) -> None:
        self.fields.reset()

    # -- field access, forwarded to the backing structure --

    def __getitem__(self, name: str):
        return self.fields[name]

    def __setitem__(self, name: str, value) -> None:
        self.fields[name] = value

    def __contains__(self, name: str) -> bool:
        return name in self.fields

    def get(self, name: str, default=None):
        return self.fields.get(name, default)

    def items(self):
        return self.fields.items()

    def keys(self):
        return self.fields.keys()

    def __str__(self) -> str:
        return self.class_name

    __repr__ = __str__


class TypeTreeObject(StructureBackedAsset):
    def __init__(self, asset_info, root, mono_behaviour_structure: bool = False):
        structure = SerializableTreeType.from_root_node(
            root, mono_behaviour_structure
        ).create_serializable_structure()
        super().__init__(asset_info, structure)

    @staticmethod
    def create(asset_info, root, mono_behaviour_structure: bool = False) -> "TypeTreeObject":
        return TypeTreeObject(asset_info, root, mono_behaviour_structure)
