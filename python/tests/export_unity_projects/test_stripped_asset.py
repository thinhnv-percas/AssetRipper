"""Port of Source/AssetRipper.Tests/StrippedAssetTests.cs (2026-08-03).

**What "stripped" means:** inside a `.unity`/`.prefab`, an object that lives in *another* file
still needs a local anchor for that file's own references to point at. Unity writes it as a
stub: `stripped` after the anchor, and only the few fields that say where the real object is.

**Adaptation, and why it is not a byte-for-byte port.** Upstream's two YAML-content tests
compare against exact Unity output, e.g.:

    --- !u!1 &1 stripped
    GameObject:
      m_CorrespondingSourceObject: {m_FileID: 0, m_PathID: 0, m_TargetClassID: 18}
      m_PrefabInstance: {m_FileID: 0, m_PathID: 0, m_TargetClassID: 1001}
      m_PrefabAsset: {m_FileID: 0, m_PathID: 0, m_TargetClassID: 1001480554}

Those three fields are *editor-only*: they exist on upstream's generated GameObject because it
models Unity's full editor serialization, and upstream's `AssetCreator` builds assets from that
same generated model. This port reads assets through hand-written release-format layouts
(`assetripper_import/asset_creation/layouts/`), where those fields legitimately do not exist --
a release player build does not serialize them, and inventing them would be fabricating fields
this port never read. So the exact byte comparison cannot be reproduced without first porting
the entire generated editor type model, which is explicitly out of scope (see
ROADMAP.md "Ngoài scope vĩnh viễn").

What *is* portable, and is what these tests assert, is every behavior upstream's tests pin that
does not depend on the generated model: which fields survive stripping, that MonoBehaviour
keeps a larger set than other classes, that the `stripped` marker lands on the document root,
and that a non-stripped asset is untouched. The allow-lists themselves are upstream's verbatim,
so a divergence there fails here.
"""
from __future__ import annotations

import io

import pytest
from assetripper_assets.unity_object_base import UnityObjectBase
from assetripper_export_unity_projects.stripped_asset import is_stripped
from assetripper_export_unity_projects.yaml_walker import YamlWalker
from assetripper_processing.prefabs.game_object_hierarchy_object import GameObjectHierarchyObject
from assetripper_serialization_logic.primitive_type import PrimitiveType
from assetripper_yaml import YamlWriter

_GAME_OBJECT_CLASS_ID = 1
_MONO_BEHAVIOUR_CLASS_ID = 114


class _FakeAsset(UnityObjectBase):
    """An asset whose `walk_editor` emits a chosen field list. Deliberately synthetic: the point
    is to feed the walker a mapping containing both allowed and disallowed field names, which no
    real release-format asset in this port carries (see the module docstring)."""

    def __init__(self, class_id: int, class_name: str, fields: "list[tuple[str, str]]"):
        super().__init__(None)
        self._class_id = class_id
        self._class_name = class_name
        self._fields = fields
        self.main_asset = self

    @property
    def class_id(self) -> int:
        return self._class_id

    @property
    def class_name(self) -> str:
        return self._class_name

    def walk_editor(self, walker) -> None:
        if not walker.enter_asset(self):
            return
        for index, (name, value) in enumerate(self._fields):
            if index > 0:
                walker.divide_asset(self)
            if walker.enter_field(self, name):
                walker.visit_primitive(value, PrimitiveType.STRING)
                walker.exit_field(self, name)
        walker.exit_asset(self)


def _hierarchy() -> GameObjectHierarchyObject:
    return GameObjectHierarchyObject(None)


def _yaml_for(asset, export_id: int = 1) -> str:
    """Mirrors upstream's `GetYamlForAsset`: head, one document, tail."""
    buffer = io.StringIO()
    writer = YamlWriter()
    writer.write_head(buffer)
    writer.write_document(YamlWalker().export_yaml_document(asset, export_id))
    writer.write_tail(buffer)
    return buffer.getvalue()


_MIXED_FIELDS = [
    ("m_CorrespondingSourceObject", "kept"),
    ("m_Layer", "dropped"),
    ("m_PrefabInstance", "kept"),
    ("m_Name", "monobehaviour-only"),
    ("m_IsActive", "dropped"),
    ("m_PrefabAsset", "kept"),
]


def test_is_stripped_returns_true_for_a_stripped_asset():
    """Upstream's `IsStrippedReturnsTrueForStrippedAsset`."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", [])
    hierarchy.game_objects.append(asset)
    hierarchy.set_main_asset()

    assert is_stripped(asset) is False
    hierarchy.stripped_assets.append(asset)
    assert is_stripped(asset) is True


def test_is_stripped_is_false_for_an_asset_in_the_same_hierarchy_that_was_not_marked():
    """The membership check must be per-asset, not "does this hierarchy strip anything"."""
    hierarchy = _hierarchy()
    stripped = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", [])
    owned = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", [])
    hierarchy.game_objects.extend([stripped, owned])
    hierarchy.set_main_asset()
    hierarchy.stripped_assets.append(stripped)

    assert is_stripped(stripped) is True
    assert is_stripped(owned) is False


def test_is_stripped_is_false_for_an_asset_with_no_hierarchy():
    """The ordinary case: almost every exported asset is its own main asset."""
    assert is_stripped(_FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", [])) is False


def test_stripped_game_object_keeps_only_the_prefab_source_fields():
    """Upstream's `StrippedGameObjectYamlContent`, minus the generated-model fields -- see the
    module docstring. `m_Name` is in the MonoBehaviour allow-list only, so a GameObject must
    drop it: that asymmetry is the one thing a single shared allow-list would silently break."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", _MIXED_FIELDS)
    hierarchy.game_objects.append(asset)
    hierarchy.set_main_asset()
    hierarchy.stripped_assets.append(asset)

    yaml = _yaml_for(asset)

    assert "--- !u!1 &1 stripped" in yaml
    assert "m_CorrespondingSourceObject:" in yaml
    assert "m_PrefabInstance:" in yaml
    assert "m_PrefabAsset:" in yaml
    assert "m_Layer:" not in yaml
    assert "m_IsActive:" not in yaml
    assert "m_Name:" not in yaml, "m_Name is MonoBehaviour-only in upstream's allow-list"


def test_stripped_mono_behaviour_keeps_the_larger_field_set():
    """Upstream's `StrippedMonoBehaviourYamlContent`: a stripped component still needs its
    script and owning GameObject, or Unity cannot reattach it at all."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(
        _MONO_BEHAVIOUR_CLASS_ID,
        "MonoBehaviour",
        _MIXED_FIELDS
        + [
            ("m_GameObject", "kept"),
            ("m_Enabled", "kept"),
            ("m_EditorHideFlags", "kept"),
            ("m_Script", "kept"),
            ("m_EditorClassIdentifier", "kept"),
        ],
    )
    hierarchy.components.append(asset)
    hierarchy.set_main_asset()
    hierarchy.stripped_assets.append(asset)

    yaml = _yaml_for(asset)

    assert "--- !u!114 &1 stripped" in yaml
    for kept in (
        "m_CorrespondingSourceObject",
        "m_PrefabInstance",
        "m_PrefabAsset",
        "m_GameObject",
        "m_Enabled",
        "m_EditorHideFlags",
        "m_Script",
        "m_Name",
        "m_EditorClassIdentifier",
    ):
        assert f"{kept}:" in yaml, kept
    assert "m_Layer:" not in yaml
    assert "m_IsActive:" not in yaml


def test_field_order_is_preserved_by_the_filter():
    """The filter removes; it must never reorder. Unity is tolerant of order but a reordering
    filter would be a silent behavior change from upstream's remove-in-place loop."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", _MIXED_FIELDS)
    hierarchy.game_objects.append(asset)
    hierarchy.set_main_asset()
    hierarchy.stripped_assets.append(asset)

    yaml = _yaml_for(asset)
    positions = [
        yaml.index("m_CorrespondingSourceObject"),
        yaml.index("m_PrefabInstance"),
        yaml.index("m_PrefabAsset"),
    ]
    assert positions == sorted(positions)


def test_a_non_stripped_asset_is_left_completely_alone():
    """The regression this guards: `export_yaml_document` runs for *every* asset, so a filter
    that fired unconditionally would strip the entire project."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", _MIXED_FIELDS)
    hierarchy.game_objects.append(asset)
    hierarchy.set_main_asset()

    yaml = _yaml_for(asset)

    assert "stripped" not in yaml
    for name, _ in _MIXED_FIELDS:
        assert f"{name}:" in yaml, name


def test_export_id_still_becomes_the_anchor_on_a_stripped_document():
    """The anchor is the whole reason a stripped stub exists -- it is what the owning file's
    references resolve against."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", _MIXED_FIELDS)
    hierarchy.game_objects.append(asset)
    hierarchy.set_main_asset()
    hierarchy.stripped_assets.append(asset)

    assert "&12345 stripped" in _yaml_for(asset, export_id=12345)


@pytest.mark.parametrize(
    "field_name",
    ["m_CorrespondingSourceObject", "m_PrefabAsset", "m_PrefabInstance", "m_PrefabInternal", "m_PrefabParentObject"],
)
def test_every_upstream_allowed_asset_field_survives(field_name):
    """Pins the allow-list itself against upstream's, including the two legacy names
    (`m_PrefabInternal`/`m_PrefabParentObject`) that no modern Unity version emits -- dropping
    them would silently break pre-2018 projects."""
    hierarchy = _hierarchy()
    asset = _FakeAsset(_GAME_OBJECT_CLASS_ID, "GameObject", [(field_name, "kept"), ("m_Layer", "dropped")])
    hierarchy.game_objects.append(asset)
    hierarchy.set_main_asset()
    hierarchy.stripped_assets.append(asset)

    yaml = _yaml_for(asset)
    assert f"{field_name}:" in yaml
    assert "m_Layer:" not in yaml
