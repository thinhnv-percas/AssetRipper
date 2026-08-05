"""Port of Source/AssetRipper.Export.UnityProjects/YamlWalker.cs

Turns an `IUnityAssetBase.walk_editor(walker)` traversal into a YamlNode tree. This is the
linchpin the whole export phase depends on: `SerializableStructure.walk_editor` (the
dynamic reader's traversal, no generated classes involved) drives this walker directly.

Three pieces of the C# original are intentionally not ported, because they depend on
concepts this dynamic-reader-based port doesn't have:

- `EnterAsset`'s GUID/Hash128/PropertyName special-casing: those are upstream *generated*
  engine-struct classes. In this port, engine structs read via the type tree always arrive
  as ordinary Complex structures (see serializable_value._create_instance's docstring), so
  a GUID field exports as its raw sub-fields rather than a hex string. Documented, known
  divergence -- not a new one introduced here.
- `ExitField`'s "m_Structure" popping for IMonoBehaviour: that only exists because upstream
  MonoBehaviour is a *generated* class with typed fields plus an opaque nested structure for
  the rest. Here, a MonoBehaviour read from a type tree is entirely one flat
  SerializableStructure -- there is no separate "m_Structure" field to pop.
- `IsStripped()`/`RemoveStrippedFields`: this port has no "stripped asset" concept yet
  (Prefab-only edge case); every asset behaves as non-stripped.

`CreateYamlNodeForPPtr` also can't include a real `m_TargetClassID`: `PPtr` here carries no
target-type information (SerializablePointerType discards the type-tree's target type name,
see structure/assembly/type_trees/serializable_tree_type.py's `_pointer_type_for`), so it
always reports class ID 0 (Object). `ProjectYamlWalker` (project/project_yaml_walker.py)
overrides this for real project-relative exports, where it matters far less because the
common case resolves the pointer to an actual collection asset instead.

One more note on `enter_dictionary`/`exit_dictionary`/`enter_dictionary_pair`'s
`!use_hyphens_in_dictionaries` branch (pre-Unity-5.4 map formatting): in this port, a Map
field is always read as an array of pairs (SerializableValue.walk_editor), so its container
is always wrapped by `enter_list`/`exit_list` (a YamlSequenceNode), never by
`enter_dictionary` -- regardless of Unity version. The pre-5.4 branch that expects a
YamlMappingNode container is therefore unreachable through the current
SerializableStructure-driven pipeline; it is kept for fidelity with upstream and in case a
future revision routes real Python dicts through `enter_dictionary` directly.
"""
from __future__ import annotations

from dataclasses import dataclass

from assetripper_assets.traversal.asset_walker import AssetWalker
from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_yaml import MappingStyle, SequenceStyle, YamlMappingNode, YamlScalarNode, YamlSequenceNode

FIELDS_TO_SKIP_IN_IMPORTERS = frozenset(
    {
        "m_ObjectHideFlags",
        "m_ExtensionPtr",
        "m_PrefabParentObject",
        "m_CorrespondingSourceObject",
        "m_PrefabInternal",
        "m_PrefabAsset",
        "m_PrefabInstance",
    }
)

_DATA = "data"
_FIRST = "first"
_SECOND = "second"

_HEX_ARRAY_TYPES = frozenset(
    {
        PrimitiveType.SBYTE,
        PrimitiveType.BYTE,
        PrimitiveType.SHORT,
        PrimitiveType.USHORT,
        PrimitiveType.INT,
        PrimitiveType.UINT,
        PrimitiveType.LONG,
        PrimitiveType.ULONG,
        PrimitiveType.BOOL,
        PrimitiveType.CHAR,
    }
)

_WIDTH_BY_TYPE = {
    PrimitiveType.SBYTE: 1,
    PrimitiveType.BYTE: 1,
    PrimitiveType.SHORT: 2,
    PrimitiveType.USHORT: 2,
    PrimitiveType.INT: 4,
    PrimitiveType.UINT: 4,
    PrimitiveType.LONG: 8,
    PrimitiveType.ULONG: 8,
}


@dataclass
class _YamlContext:
    mapping_node: YamlMappingNode | None = None
    sequence_node: YamlSequenceNode | None = None
    field_name: str | None = None


class YamlWalker(AssetWalker):
    def __init__(self):
        self._context_stack: list[_YamlContext] = []
        self.exporting_asset_importer = False
        self.use_hyphens_in_dictionaries = True

    def with_unity_version(self, version) -> "YamlWalker":
        self.use_hyphens_in_dictionaries = version.greater_than_or_equals(5, 4)
        return self

    @property
    def _current_mapping_node(self) -> YamlMappingNode | None:
        return self._context_stack[-1].mapping_node

    @property
    def _current_sequence_node(self) -> YamlSequenceNode | None:
        return self._context_stack[-1].sequence_node

    @property
    def _current_field_name(self) -> str | None:
        return self._context_stack[-1].field_name

    # -- entry points ------------------------------------------------------

    def export_yaml_document(self, asset, export_id: int):
        from assetripper_yaml import YamlDocument

        self._context_stack.clear()

        document = YamlDocument()
        root = document.create_mapping_root()
        root.tag = str(asset.class_id)
        root.anchor = str(export_id)

        self._context_stack.append(_YamlContext(mapping_node=root, field_name=asset.class_name))
        asset.walk_editor(self)

        from .stripped_asset import is_stripped, remove_stripped_fields

        if is_stripped(asset):
            # `walk_editor` produced exactly one child: the class-name key mapped to the
            # asset's own field mapping. The stripped stub keeps only a few of *those*
            # fields, so the filtering happens one level down, not on `root`.
            assert len(root.children) == 1
            remove_stripped_fields(asset, root.children[0][1])
            root.stripped = True

        return document

    def export_yaml_node(self, asset):
        self._context_stack.clear()
        false_root = YamlSequenceNode()
        self._context_stack.append(_YamlContext(sequence_node=false_root))
        asset.walk_editor(self)
        assert len(false_root.children) == 1
        return false_root.children[0]

    # -- AssetWalker overrides ----------------------------------------------

    def enter_asset(self, asset) -> bool:
        result = self._enter_map(asset.flow_mapped_in_yaml)
        assert result
        assert self._current_mapping_node is not None and len(self._current_mapping_node.children) == 0
        assert self._current_sequence_node is None
        assert self._current_field_name is None
        from assetripper_yaml.extensions.yaml_serialized_version_extensions import add_serialized_version

        add_serialized_version(self._current_mapping_node, asset.serialized_version)
        return result

    def divide_asset(self, asset) -> None:
        pass

    def exit_asset(self, asset) -> None:
        self._exit_map()

    def enter_field(self, asset, name: str) -> bool:
        assert self._current_mapping_node is not None
        assert self._current_sequence_node is None
        assert self._current_field_name is None
        if self.exporting_asset_importer and (name in FIELDS_TO_SKIP_IN_IMPORTERS or asset.ignore_field_in_meta_files(name)):
            return False
        self._context_stack.append(_YamlContext(mapping_node=self._current_mapping_node, field_name=name))
        return True

    def exit_field(self, asset, name: str) -> None:
        assert self._current_mapping_node is not None
        assert self._current_sequence_node is None
        assert self._current_field_name is None

    def enter_list(self, list_, primitive_type=None) -> bool:
        if primitive_type in _HEX_ARRAY_TYPES:
            self.visit_primitive(list_, primitive_type)
            return False
        return self._enter_sequence(SequenceStyle.BLOCK)

    def divide_list(self, list_, primitive_type=None) -> None:
        pass

    def exit_list(self, list_, primitive_type=None) -> None:
        self._exit_sequence()

    def enter_pair(self, pair) -> bool:
        first, second = pair
        node = YamlMappingNode()
        self._context_stack.append(_YamlContext(mapping_node=node))
        if not _is_valid_dictionary_key(first):
            self._context_stack.append(_YamlContext(mapping_node=node, field_name=_FIRST))
        return True

    def divide_pair(self, pair) -> None:
        first, second = pair
        assert self._current_mapping_node is not None
        assert self._current_sequence_node is None
        if _is_valid_dictionary_key(first):
            assert self._current_field_name is not None
        else:
            assert self._current_field_name is None
            self._context_stack.append(_YamlContext(mapping_node=self._current_mapping_node, field_name=_SECOND))

    def exit_pair(self, pair) -> None:
        self._exit_map()

    def enter_dictionary(self, dictionary) -> bool:
        if not self.use_hyphens_in_dictionaries:
            return self._enter_map()
        return self._enter_sequence(SequenceStyle.BLOCK_CURVE)

    def divide_dictionary(self, dictionary) -> None:
        pass

    def exit_dictionary(self, dictionary) -> None:
        if not self.use_hyphens_in_dictionaries:
            self._exit_map()
        else:
            self._exit_sequence()

    def enter_dictionary_pair(self, pair) -> bool:
        key_value, second = pair
        if not self.use_hyphens_in_dictionaries:
            assert self._current_mapping_node is not None
            assert self._current_sequence_node is None
            assert self._current_field_name is None
            node = YamlMappingNode()
            self._current_mapping_node.add(_DATA, node)
            self._context_stack.append(_YamlContext(mapping_node=node))
            self._context_stack.append(_YamlContext(mapping_node=node, field_name=_FIRST))
        else:
            assert self._current_mapping_node is None
            assert self._current_sequence_node is not None
            assert self._current_field_name is None
            node = YamlMappingNode()
            self._current_sequence_node.add(node)
            self._context_stack.append(_YamlContext(mapping_node=node))
            self._context_stack.append(_YamlContext(mapping_node=node, field_name=_FIRST))
        return True

    def divide_dictionary_pair(self, pair) -> None:
        if not self.use_hyphens_in_dictionaries:
            assert self._current_mapping_node is not None
            assert self._current_sequence_node is None
            assert self._current_field_name is None
            self._context_stack.append(_YamlContext(mapping_node=self._current_mapping_node, field_name=_SECOND))
        # else: nothing (matches the "IsValidDictionaryKey" branch upstream is really
        # gating on -- this port's SerializablePair.walk_editor only reaches this method
        # for the non-string-key case, see its module docstring)

    def exit_dictionary_pair(self, pair) -> None:
        if not self.use_hyphens_in_dictionaries:
            assert self._current_mapping_node is not None
            assert self._current_sequence_node is None
            assert self._current_field_name is None
            self._context_stack.pop()

    def visit_primitive(self, value, primitive_type=None) -> None:
        node = _to_node(value, primitive_type)
        if self._current_mapping_node is not None:
            assert self._current_sequence_node is None
            if self._current_field_name is not None:
                self._current_mapping_node.add(self._current_field_name, node)
                self._context_stack.pop()
            else:
                self._context_stack.append(_YamlContext(mapping_node=self._current_mapping_node, field_name=_key_to_string(value)))
        else:
            assert self._current_sequence_node is not None
            assert self._current_field_name is None
            self._current_sequence_node.add(node)

    def visit_pptr(self, pptr) -> None:
        self._add_node(self.create_yaml_node_for_pptr(pptr))

    def create_yaml_node_for_pptr(self, pptr):
        node = YamlMappingNode(MappingStyle.FLOW)
        node.add("m_FileID", pptr.file_id)
        node.add("m_PathID", pptr.path_id)
        node.add("m_TargetClassID", 0)  # See module docstring: target type is unknown here.
        return node

    # -- shared helpers (also used by ProjectYamlWalker) --------------------

    def _enter_map(self, flow_mapped: bool = False) -> bool:
        self._context_stack.append(_YamlContext(mapping_node=YamlMappingNode(MappingStyle.FLOW if flow_mapped else MappingStyle.BLOCK)))
        return True

    def _exit_map(self) -> None:
        context = self._context_stack.pop()
        assert context.mapping_node is not None
        assert context.sequence_node is None
        assert context.field_name is None
        self._add_node(context.mapping_node)

    def _enter_sequence(self, style: SequenceStyle) -> bool:
        self._context_stack.append(_YamlContext(sequence_node=YamlSequenceNode(style)))
        return True

    def _exit_sequence(self) -> None:
        context = self._context_stack.pop()
        assert context.mapping_node is None
        assert context.sequence_node is not None
        assert context.field_name is None
        self._add_node(context.sequence_node)

    def _add_node(self, node) -> None:
        if self._current_mapping_node is not None:
            assert self._current_sequence_node is None
            assert self._current_field_name is not None
            self._current_mapping_node.add(self._current_field_name, node)
            self._context_stack.pop()
        else:
            assert self._current_sequence_node is not None
            assert self._current_field_name is None
            self._current_sequence_node.add(node)


def _is_string(value) -> bool:
    return isinstance(value, str)


def _is_valid_dictionary_key(value) -> bool:
    return isinstance(value, (str, int, float))


def _key_to_string(value) -> str:
    return "" if value is None else str(value)


def _to_node(value, primitive_type):
    """Port of YamlWalker.ToNode<T>. `value` is either a scalar or (for hex-encodable
    array element types) the whole list, intercepted by enter_list before the per-element
    loop would otherwise run -- see this module's docstring and enter_list above."""
    if isinstance(value, list):
        return _hex_array_to_node(value, primitive_type)
    if primitive_type == PrimitiveType.CHAR:
        # Unity (and .NET's char, which implements generic-math numeric interfaces)
        # serializes a lone char as its numeric code unit, not as a one-character string.
        return YamlScalarNode.create(ord(value))
    if isinstance(value, bool):
        return YamlScalarNode.create(value)
    if isinstance(value, (int, float, str)):
        return YamlScalarNode.create(value)
    return YamlScalarNode.create(str(value) if value is not None else "")


def _hex_array_to_node(values: list, primitive_type):
    if primitive_type == PrimitiveType.BOOL:
        return YamlScalarNode.create_hex_bool_list(values)
    if primitive_type == PrimitiveType.CHAR:
        return YamlScalarNode.create_hex_char_list(values)
    width = _WIDTH_BY_TYPE.get(primitive_type)
    if width is not None:
        return YamlScalarNode.create_hex_bytes(values, width)
    raise NotImplementedError(str(primitive_type))
