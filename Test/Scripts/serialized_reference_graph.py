#!/usr/bin/env python3
"""Compares the serialized reference graph of a recovered project with the source project's.

A recovered method that is right does nothing if the component it belongs to is not attached, or is
attached to the wrong GameObject, or if the field it reads points at the wrong object. None of that
is visible to a compiler or to a method-level oracle, and a raw YAML diff cannot see it either: the
two projects do not share a single fileID, a GUID, an instance ID or even a file layout. So this
builds, for each build scene on each side, the graph the editor would build

    Scene -> GameObject -> Component -> serialized field -> target object

and compares it by *semantic identity*: a GameObject is its hierarchy path, a component is its
GameObject plus its type (a script's namespace and class, never its GUID), and a target is what it
is - `GameObject:Root/Child`, `Material:Skin`, `Sprite:button_play`, `Script:Namespace.Class` - never
the number that pointed at it.

Two things make the source side harder than it looks, and both are handled rather than skipped:

  * A source scene holds prefab *instances*; a build flattens them, so the recovered scene holds the
    objects themselves. Each `PrefabInstance` is expanded the way the editor does it: the objects of
    the prefab (itself expanded, recursively) take the fileID `(instance ^ source) & 0x7FFF...`,
    which is exactly the ID the scene's own `stripped` documents and its references already use; the
    instance's modifications are applied (names, active flags, object references); removed
    components are removed and added ones attached.
  * A script can be declared by a `.cs` in the tree, by a class inside a DLL (whose `m_Script`
    fileID is Unity's MD4 hash of `"s\\0\\0\\0" + namespace + name`), or by nothing this checkout
    has - a built-in package such as uGUI is not in a source tree and is not on the package
    registry. The first two are identified exactly. The third is `SOURCE_SCRIPT_UNDECLARED`, which is
    UNKNOWN and never a match: a component whose type we cannot name on one side cannot be said to be
    the right one.

Statuses, per level:

  GameObject  MATCHED | MISSING_IN_RECOVERED | EDITOR_ONLY | EXTRA_IN_RECOVERED
  Component   MATCHED | MISSING_IN_RECOVERED | EXTRA_IN_RECOVERED
              (a MonoBehaviour whose source script is undeclared is paired by position among the
              undeclared ones on the same GameObject, and every result under it is kept apart as
              POSITIONAL)
  Script      BOUND_EXACT | BOUND_EXACT_BY_HASH | BOUND_DIFFERENT | SCRIPT_MISSING |
              SOURCE_SCRIPT_UNDECLARED
  Reference   MATCH | DIFFERENT | NULL_IN_RECOVERED | NULL_IN_SOURCE | NULL_BOTH |
              SOURCE_TARGET_UNKNOWN | SOURCE_TARGET_UNKNOWN_RECOVERED_NULL | RECOVERED_TARGET_UNKNOWN |
              DIFFERENT_NAME_SANITIZED | MATCH_POSITIONAL_TARGET |
              FIELD_ABSENT_IN_SOURCE | FIELD_ABSENT_IN_RECOVERED

`FIELD_ABSENT_IN_SOURCE` is not a failure: a scene saved by an older version of a script carries no
entry for a field added later, and the build serializes its default. `NULL_BOTH` is not a match of
anything and is kept out of the rate. Nothing here is repaired.

Usage:
  serialized_reference_graph.py <source project> <recovered game directory>
      [--package-dir DIR ...] [--json out.json] [--verbose]
  serialized_reference_graph.py --self-test
"""
import argparse
import collections
import copy
import json
import pathlib
import re
import struct
import sys

import yaml

MASK63 = 0x7FFFFFFFFFFFFFFF
BUILTIN_GUIDS = {"0000000000000000e000000000000000", "0000000000000000f000000000000000"}
YAML_EXTENSIONS = {".unity", ".prefab", ".asset", ".mat", ".anim", ".controller", ".overrideController",
                   ".physicMaterial", ".physicsMaterial2D", ".mask", ".flare", ".renderTexture",
                   ".guiskin", ".fontsettings", ".mixer", ".playable", ".lighting", ".spriteatlas",
                   ".terrainlayer", ".brush", ".cubemap", ".giparams"}

# Unity class IDs that a reference may name, for the objects a non-YAML asset carries.
CLASS_NAMES = {1: "GameObject", 4: "Transform", 21: "Material", 23: "MeshRenderer", 28: "Texture2D",
               33: "MeshFilter", 43: "Mesh", 48: "Shader", 49: "TextAsset", 74: "AnimationClip",
               83: "AudioClip", 89: "Cubemap", 90: "Avatar", 91: "AnimatorController", 95: "Animator",
               114: "MonoBehaviour", 115: "MonoScript", 117: "Texture3D", 128: "Font",
               137: "SkinnedMeshRenderer", 187: "Texture2DArray", 213: "Sprite", 224: "RectTransform",
               1001: "PrefabInstance"}

# Classes whose main object an importer names after the file. A model's meshes are named by the
# model file itself, which is not read here, so they stay UNKNOWN rather than being guessed.
MAIN_OBJECT_NAMED_BY_FILE = {28, 213, 83, 128, 49, 89, 117, 187}
MODEL_EXTENSIONS = {".fbx", ".obj", ".dae", ".blend", ".3ds", ".max", ".ma", ".mb"}

# AssetRipper's FileSystem.FixInvalidFileNameCharacters: the platform's invalid file name
# characters, a colon, commas, square brackets and control characters all become '_'. An imported
# asset's main object is named after its file, so this renames the object as well.
EXPORTER_FILE_NAME = re.compile(r"[/\\:,\[\]\x00-\x1F]")

# Keys that are the structure of the graph rather than references out of a component.
STRUCTURAL = {"m_GameObject", "m_Father", "m_Children", "m_Script", "m_CorrespondingSourceObject",
              "m_PrefabInstance", "m_PrefabAsset", "m_PrefabParentObject", "m_PrefabInternal",
              "m_Component"}

HEADER = re.compile(r"^--- !u!(-?\d+) &(-?\d+)( stripped)?")


# --------------------------------------------------------------------------------------------------
# Unity's MonoScript fileID for a class inside a DLL.

def _md4(message: bytes) -> bytes:
    def f(x, y, z): return (x & y) | (~x & z)
    def g(x, y, z): return (x & y) | (x & z) | (y & z)
    def h(x, y, z): return x ^ y ^ z
    def rol(v, s): v &= 0xFFFFFFFF; return ((v << s) | (v >> (32 - s))) & 0xFFFFFFFF

    length = len(message) * 8
    message += b"\x80" + b"\x00" * ((55 - len(message)) % 64) + struct.pack("<Q", length)
    a, b, c, d = 0x67452301, 0xEFCDAB89, 0x98BADCFE, 0x10325476
    for chunk in range(0, len(message), 64):
        x = struct.unpack("<16I", message[chunk:chunk + 64])
        aa, bb, cc, dd = a, b, c, d
        for i in (0, 4, 8, 12):
            a = rol(a + f(b, c, d) + x[i], 3); d = rol(d + f(a, b, c) + x[i + 1], 7)
            c = rol(c + f(d, a, b) + x[i + 2], 11); b = rol(b + f(c, d, a) + x[i + 3], 19)
        for i in (0, 1, 2, 3):
            a = rol(a + g(b, c, d) + x[i] + 0x5A827999, 3); d = rol(d + g(a, b, c) + x[i + 4] + 0x5A827999, 5)
            c = rol(c + g(d, a, b) + x[i + 8] + 0x5A827999, 9); b = rol(b + g(c, d, a) + x[i + 12] + 0x5A827999, 13)
        for i in (0, 2, 1, 3):
            a = rol(a + h(b, c, d) + x[i] + 0x6ED9EBA1, 3); d = rol(d + h(a, b, c) + x[i + 8] + 0x6ED9EBA1, 9)
            c = rol(c + h(d, a, b) + x[i + 4] + 0x6ED9EBA1, 11); b = rol(b + h(c, d, a) + x[i + 12] + 0x6ED9EBA1, 15)
        a, b, c, d = (a + aa) & 0xFFFFFFFF, (b + bb) & 0xFFFFFFFF, (c + cc) & 0xFFFFFFFF, (d + dd) & 0xFFFFFFFF
    return struct.pack("<4I", a, b, c, d)


def script_file_id(namespace: str, name: str) -> int:
    """The fileID Unity gives the MonoScript of `namespace.name` when the class lives in a DLL."""
    digest = _md4(("s\0\0\0" + namespace + name).encode("utf-8"))
    return struct.unpack("<i", digest[:4])[0]


# --------------------------------------------------------------------------------------------------
# Reading.

class Obj:
    __slots__ = ("cls", "type_name", "body", "stripped")

    def __init__(self, cls, type_name, body, stripped=False):
        self.cls, self.type_name, self.body, self.stripped = cls, type_name, body, stripped


class _Loader(yaml.SafeLoader):
    pass


# Unity writes `value: ` with nothing after it and long numbers that must stay integers; both are
# what the safe loader already does. Timestamps and sexagesimal numbers are not Unity's, so the
# resolvers that would read them are removed rather than risked.
for _first, _mappings in list(_Loader.yaml_implicit_resolvers.items()):
    _Loader.yaml_implicit_resolvers[_first] = [(tag, rx) for tag, rx in _mappings
                                                if tag not in ("tag:yaml.org,2002:timestamp",)]


def read_documents(path: pathlib.Path) -> dict:
    """fileID -> Obj for every document in a Unity YAML file."""
    text = path.read_text(encoding="utf-8", errors="replace")
    objects = {}
    header, lines = None, []

    def flush():
        if header is None:
            return
        cls, file_id, stripped = header
        try:
            parsed = yaml.load("\n".join(lines), Loader=_Loader) or {}
        except yaml.YAMLError:
            parsed = {}
        if isinstance(parsed, dict) and parsed:
            type_name, body = next(iter(parsed.items()))
        else:
            type_name, body = "?", {}
        objects[file_id] = Obj(cls, type_name, body if isinstance(body, dict) else {}, stripped)

    for line in text.splitlines():
        match = HEADER.match(line)
        if match:
            flush()
            header = (int(match.group(1)), int(match.group(2)), bool(match.group(3)))
            lines = []
        elif header is not None and not line.startswith("%"):
            lines.append(line)
    flush()
    return objects


def read_meta(path: pathlib.Path):
    try:
        text = path.read_text(encoding="utf-8", errors="replace")
    except OSError:
        return None
    guid = re.search(r"^guid: ([0-9a-f]{32})", text, re.M)
    return (guid.group(1), text) if guid else None


NAMESPACE = re.compile(r"^\s*namespace\s+([A-Za-z_][\w.]*)", re.M)


def script_identity(cs_path: pathlib.Path) -> str | None:
    """`Namespace.Class` for the class a `.cs` file declares under its own file name."""
    try:
        text = cs_path.read_text(encoding="utf-8", errors="replace")
    except OSError:
        return None
    name = cs_path.name[:-3]
    declared = re.search(r"\b(?:class|struct)\s+" + re.escape(name) + r"\b", text)
    if not declared:
        return None
    # The namespace that encloses the declaration is the last one opened before it.
    namespaces = [m for m in NAMESPACE.finditer(text) if m.start() < declared.start()]
    namespace = namespaces[-1].group(1) if namespaces else ""
    return f"{namespace}.{name}" if namespace else name


class Project:
    def __init__(self, root: pathlib.Path, extra_dirs=()):
        self.root = root
        self.guids = {}
        self.meta_text = {}
        for base in [root / "Assets", root / "Packages", *map(pathlib.Path, extra_dirs)]:
            if not base.exists():
                continue
            for meta in base.rglob("*.meta"):
                read = read_meta(meta)
                if read:
                    asset = meta.with_suffix("")
                    self.guids.setdefault(read[0], asset)
                    self.meta_text[asset] = read[1]
        self._documents = {}
        self._expanded = {}
        self._scripts = {}

    def documents(self, path: pathlib.Path) -> dict:
        if path not in self._documents:
            self._documents[path] = read_documents(path)
        return self._documents[path]

    def script(self, path: pathlib.Path):
        if path not in self._scripts:
            self._scripts[path] = script_identity(path)
        return self._scripts[path]

    def expanded(self, path: pathlib.Path, depth=0) -> dict:
        """The objects of a scene or prefab with every prefab instance in it expanded."""
        if path not in self._expanded:
            self._expanded[path] = {}   # a prefab that instantiates itself expands to nothing
            self._expanded[path] = expand(self, self.documents(path), depth)
        return self._expanded[path]


# --------------------------------------------------------------------------------------------------
# Prefab expansion.

def remap(value, mapping):
    """Rewrites every local PPtr in a copied body into the instance's ID space."""
    if isinstance(value, dict):
        if "fileID" in value and not value.get("guid"):
            file_id = value["fileID"]
            if isinstance(file_id, int) and file_id in mapping:
                return {**value, "fileID": mapping[file_id]}
            return value
        return {key: remap(item, mapping) for key, item in value.items()}
    if isinstance(value, list):
        return [remap(item, mapping) for item in value]
    return value


PATH_STEP = re.compile(r"([^.\[]+)|\[(\d+)\]")


def apply_modification(body: dict, property_path: str, value, reference):
    """Sets one overridden property, as far as the graph cares about it."""
    parts = property_path.split(".")
    node = body
    for index, part in enumerate(parts):
        last = index == len(parts) - 1
        if part == "Array":
            continue
        if part == "size" and index > 0 and parts[index - 1] == "Array":
            if isinstance(node, list) and isinstance(value, int):
                del node[value:]
                while len(node) < value:
                    node.append({"fileID": 0})
            return
        element = re.fullmatch(r"data\[(\d+)\]", part)
        if element:
            if not isinstance(node, list):
                return
            position = int(element.group(1))
            while len(node) <= position:
                node.append({"fileID": 0})
            if last:
                node[position] = reference if isinstance(node[position], dict) and "fileID" in node[position] \
                    or reference.get("fileID") else value
                return
            node = node[position]
            continue
        if not isinstance(node, dict):
            return
        if last:
            current = node.get(part)
            is_reference = (isinstance(current, dict) and "fileID" in current) or reference.get("fileID")
            node[part] = dict(reference) if is_reference else value
            return
        following = parts[index + 1] if index + 1 < len(parts) else ""
        if part not in node or not isinstance(node[part], (dict, list)):
            node[part] = [] if following == "Array" else {}
        node = node[part]


def expand(project: Project, documents: dict, depth: int) -> dict:
    objects = {}
    instances = []
    for file_id, obj in documents.items():
        if obj.cls == 1001:
            instances.append((file_id, obj))
        elif not obj.stripped:
            objects[file_id] = Obj(obj.cls, obj.type_name, copy.deepcopy(obj.body))

    for instance_id, instance in instances:
        modification = instance.body.get("m_Modification") or {}
        source = (instance.body.get("m_SourcePrefab") or instance.body.get("m_ParentPrefab") or {})
        source_path = project.guids.get(source.get("guid"))
        if source_path is None or depth > 16 or not source_path.exists():
            continue
        prefab = project.expanded(source_path, depth + 1)
        mapping = {source_id: (instance_id ^ source_id) & MASK63 for source_id in prefab}
        # The XOR is what the editor writes today. A scene upgraded from an older format keeps the
        # IDs its stripped documents were given then, and those are what its references use, so a
        # stripped document is the authority for the object it stands for.
        for stripped_id, stripped in documents.items():
            if not stripped.stripped:
                continue
            if (stripped.body.get("m_PrefabInstance") or {}).get("fileID") != instance_id:
                continue
            corresponding = stripped.body.get("m_CorrespondingSourceObject") or {}
            if corresponding.get("guid") == source.get("guid") and corresponding.get("fileID") in prefab:
                mapping[corresponding["fileID"]] = stripped_id

        removed = {(r.get("fileID"), r.get("guid")) for r in instance.body.get("m_RemovedComponents") or []}
        removed |= {(r.get("fileID"), r.get("guid")) for r in instance.body.get("m_RemovedGameObjects") or []}
        removed_ids = {mapping[f] for f, g in removed if g == source.get("guid") and f in mapping}

        for source_id, obj in prefab.items():
            new_id = mapping[source_id]
            if new_id in removed_ids:
                continue
            objects[new_id] = Obj(obj.cls, obj.type_name, remap(copy.deepcopy(obj.body), mapping))

        parent = (modification.get("m_TransformParent") or {}).get("fileID", 0)
        for source_id, obj in prefab.items():
            if obj.cls in (4, 224) and (obj.body.get("m_Father") or {}).get("fileID", 0) == 0:
                placed = objects.get(mapping[source_id])
                if placed is not None:
                    placed.body["m_Father"] = {"fileID": parent}

        for change in modification.get("m_Modifications") or []:
            target = change.get("target") or {}
            if target.get("guid") != source.get("guid"):
                continue
            placed = objects.get(mapping.get(target.get("fileID")))
            if placed is None:
                continue
            apply_modification(placed.body, str(change.get("propertyPath", "")), change.get("value"),
                               change.get("objectReference") or {"fileID": 0})

        for gone in removed_ids:
            for obj in objects.values():
                if obj.cls == 1:
                    obj.body["m_Component"] = [c for c in obj.body.get("m_Component") or []
                                               if (c.get("component") or {}).get("fileID") != gone]

    # A component added to an instance points at its GameObject; the GameObject's own list, copied
    # from the prefab, does not know about it.
    for file_id, obj in objects.items():
        owner = objects.get((obj.body.get("m_GameObject") or {}).get("fileID"))
        if owner is None or owner.cls != 1:
            continue
        listed = {(c.get("component") or {}).get("fileID") for c in owner.body.get("m_Component") or []}
        if file_id not in listed:
            owner.body.setdefault("m_Component", []).append({"component": {"fileID": file_id}})
    return objects


# --------------------------------------------------------------------------------------------------
# The graph.

class Graph:
    """Semantic identities for every GameObject and component of one expanded file."""

    def __init__(self, project: Project, objects: dict, label: str, root_name: str | None = None):
        self.project, self.objects, self.label = project, objects, label
        # The root of a prefab asset is named after the asset file whatever its serialized m_Name
        # says - the editor renames it on import - and a build carries the asset's name.
        self.root_name = root_name
        self.transform_of = {}
        for file_id, obj in objects.items():
            if obj.cls in (4, 224):
                owner = (obj.body.get("m_GameObject") or {}).get("fileID")
                if owner in objects:
                    self.transform_of[owner] = file_id
        self.children = collections.defaultdict(list)
        for game_object, transform in self.transform_of.items():
            father = (objects[transform].body.get("m_Father") or {}).get("fileID", 0)
            self.children[father if father in objects else 0].append(transform)
        roots_order = []
        for obj in objects.values():
            if obj.type_name == "SceneRoots":
                roots_order = [r.get("fileID") for r in obj.body.get("m_Roots") or []]
        for father, transforms in self.children.items():
            listed = [c.get("fileID") for c in (objects[father].body.get("m_Children") or [])] \
                if father in objects else roots_order

            def order(transform, listed=listed):
                if transform in listed:
                    return (0, listed.index(transform))
                root_order = objects[transform].body.get("m_RootOrder")
                return (1, root_order if isinstance(root_order, int) else 0, transform)
            transforms.sort(key=order)

        self.path = {}
        self._walk(0, "")
        self.component_key = {}
        for game_object, path in self.path.items():
            seen = collections.Counter()
            for entry in objects[game_object].body.get("m_Component") or []:
                component = (entry.get("component") or {}).get("fileID")
                if component not in objects:
                    continue
                kind = self.component_type(component)
                self.component_key[component] = (path, kind, seen[kind])
                seen[kind] += 1

    def _walk(self, father, prefix):
        names = collections.Counter()
        for transform in self.children.get(father, []):
            game_object = (self.objects[transform].body.get("m_GameObject") or {}).get("fileID")
            if game_object not in self.objects:
                continue
            name = str(self.objects[game_object].body.get("m_Name", ""))
            if father == 0 and self.root_name is not None and len(self.children.get(0, [])) == 1:
                name = self.root_name
            ordinal = names[name]
            names[name] += 1
            path = f"{prefix}/{name}" if prefix else name
            if ordinal:
                path += f"[{ordinal}]"
            self.path[game_object] = path
            self._walk(transform, path)

    def component_type(self, file_id) -> str:
        obj = self.objects[file_id]
        if obj.cls != 114:
            return obj.type_name
        return "Script:" + self.script_of(obj.body.get("m_Script") or {})[1]

    def script_of(self, pointer: dict):
        """(status, identity) of the script a MonoBehaviour's `m_Script` names."""
        guid, file_id = pointer.get("guid"), pointer.get("fileID", 0)
        if not file_id:
            return "SCRIPT_MISSING", "<null>"
        path = self.project.guids.get(guid)
        if path is None:
            return "SOURCE_SCRIPT_UNDECLARED", f"?{guid}"
        if path.suffix == ".cs":
            identity = self.project.script(path)
            return ("DECLARED", identity) if identity else ("SOURCE_SCRIPT_UNDECLARED", f"?{guid}")
        if path.suffix == ".dll":
            return "DLL", f"#{file_id}@{path.name}"
        return "SOURCE_SCRIPT_UNDECLARED", f"?{guid}"

    def describe(self, pointer: dict) -> str:
        """What a PPtr points at, as a name both projects can agree on."""
        file_id, guid = pointer.get("fileID", 0), pointer.get("guid")
        if not file_id:
            return "NULL"
        if not guid:
            return self.describe_local(self.objects, file_id, self.path, self.component_key)
        if guid in BUILTIN_GUIDS:
            return f"Builtin:{guid[16]}:{file_id}"
        path = self.project.guids.get(guid)
        if path is None:
            return f"UNKNOWN:guid {guid}"
        if path.suffix == ".cs":
            identity = self.project.script(path)
            return f"Script:{identity}" if identity else f"UNKNOWN:script {path.name}"
        if path.suffix.lower() in YAML_EXTENSIONS or path.suffix == "":
            if path.is_dir():
                return f"UNKNOWN:folder {path.name}"
            objects = self.project.expanded(path) if path.suffix == ".prefab" else self.project.documents(path)
            if file_id not in objects:
                return f"UNKNOWN:{path.name} has no {file_id}"
            if path.suffix == ".prefab":
                inner = Graph(self.project, objects, path.name, root_name=path.stem)
                return "Prefab" + self.describe_local(objects, file_id, inner.path, inner.component_key)
            obj = objects[file_id]
            return f"{self.class_label(obj, objects)}:{obj.body.get('m_Name', path.stem)}"
        return self.describe_imported(path, file_id)

    def class_label(self, obj: Obj, objects) -> str:
        if obj.cls == 114:
            return "MonoBehaviour<" + self.script_of(obj.body.get("m_Script") or {})[1] + ">"
        return obj.type_name

    def describe_local(self, objects, file_id, paths, keys) -> str:
        obj = objects.get(file_id)
        if obj is None:
            return "UNKNOWN:dangling local reference"
        if file_id in paths:
            return f"GameObject:{paths[file_id]}"
        if file_id in keys:
            path, kind, ordinal = keys[file_id]
            return f"Component:{path}#{kind}" + (f"[{ordinal}]" if ordinal else "")
        return f"{self.class_label(obj, objects)}:{obj.body.get('m_Name', '')}"

    def describe_imported(self, path: pathlib.Path, file_id: int) -> str:
        """An object inside an imported asset (texture, model, audio, font, shader)."""
        meta = self.project.meta_text.get(path, "")
        name = None
        cls = file_id // 100000 if 0 < file_id < 100000000 and file_id % 100000 == 0 else None
        table = re.search(r"internalIDToNameTable:\n((?:  - .*\n(?:    .*\n)*)*)", meta)
        if table:
            for entry in re.finditer(r"first:\s*\n\s*(-?\d+):\s*(-?\d+)\s*\n\s*second:\s*(.*)", table.group(1)):
                if int(entry.group(2)) == file_id:
                    cls, name = int(entry.group(1)), entry.group(3).strip()
        if name is None and "nameFileIdTable:" in meta:
            # A sprite sheet names each sprite it cuts out; 2021 and later record it here.
            block = meta.split("nameFileIdTable:", 1)[1]
            for line in block.split("\n")[1:]:
                entry = re.match(r"^\s{6,}(.+?): (-?\d+)\s*$", line)
                if not entry:
                    break
                if int(entry.group(2)) == file_id:
                    cls, name = 213, entry.group(1).strip().strip("'\"")
                    break
        if name is None:
            legacy = re.search(r"^\s*" + str(file_id) + r":\s*(.+)$", meta.split("fileIDToRecycleName:")[-1], re.M) \
                if "fileIDToRecycleName:" in meta else None
            if legacy:
                name = legacy.group(1).strip()
        if name is None and cls in MAIN_OBJECT_NAMED_BY_FILE and file_id == cls * 100000:
            name = path.stem            # the main object of an imported asset carries the file's name
        if name is None and cls == 90 and file_id == 9000000 and path.suffix.lower() in MODEL_EXTENSIONS:
            name = path.stem + "Avatar"  # ModelImporter names the avatar it generates this way
        if name is None and cls == 1 and file_id == 100100000 and path.suffix.lower() in MODEL_EXTENSIONS:
            name = path.stem
        if cls == 48 and path.suffix == ".shader":
            declared = re.search(r'Shader\s+"([^"]+)"', path.read_text(encoding="utf-8", errors="replace"))
            if declared:
                name = declared.group(1)
        if name is None or cls is None:
            return f"UNKNOWN:{path.name} object {file_id}"
        return f"{CLASS_NAMES.get(cls, f'Class{cls}')}:{name}"


def references(body: dict, prefix=""):
    """(property path, PPtr) for every reference in a component's body."""
    for key, value in body.items():
        if not prefix and key in STRUCTURAL:
            continue
        path = f"{prefix}.{key}" if prefix else str(key)
        yield from _references(value, path)


def _references(value, path):
    if isinstance(value, dict):
        if "fileID" in value and set(value) <= {"fileID", "guid", "type"}:
            yield path, value
            return
        for key, item in value.items():
            yield from _references(item, f"{path}.{key}")
    elif isinstance(value, list):
        for index, item in enumerate(value):
            yield from _references(item, f"{path}[{index}]")


# --------------------------------------------------------------------------------------------------
# Comparison.

def bind(source_graph: Graph, recovered_graph: Graph, source_component, recovered_component):
    source_status, source_identity = source_graph.script_of(source_graph.objects[source_component].body.get("m_Script") or {})
    recovered_status, recovered_identity = recovered_graph.script_of(
        recovered_graph.objects[recovered_component].body.get("m_Script") or {})
    if recovered_status == "SCRIPT_MISSING" or recovered_identity.startswith("?"):
        return "SCRIPT_MISSING"
    if source_status == "SOURCE_SCRIPT_UNDECLARED" or source_status == "SCRIPT_MISSING":
        return "SOURCE_SCRIPT_UNDECLARED"
    if source_status == "DLL":
        expected = int(source_identity[1:].split("@")[0])
        namespace, _, name = recovered_identity.rpartition(".")
        return "BOUND_EXACT_BY_HASH" if script_file_id(namespace, name) == expected else "BOUND_DIFFERENT"
    return "BOUND_EXACT" if source_identity == recovered_identity else "BOUND_DIFFERENT"


def reference_status(source_graph, recovered_graph, source_pointer, recovered_pointer, pairing):
    """(status, source description, recovered description) for one field present on both sides."""
    source_target = source_graph.describe(source_pointer)
    recovered_target = recovered_graph.describe(recovered_pointer)
    if source_target == "NULL" and recovered_target == "NULL":
        return "NULL_BOTH", source_target, recovered_target
    # A reference to a component in the same scene is judged through the component pairing, so a
    # component whose script the source cannot name is still followed to the one it was paired with.
    source_local = source_pointer.get("fileID") if not source_pointer.get("guid") else None
    recovered_local = recovered_pointer.get("fileID") if not recovered_pointer.get("guid") else None
    if source_local in pairing and recovered_target != "NULL":
        paired, how = pairing[source_local]
        if recovered_local == paired:
            return ("MATCH" if how == "exact" else "MATCH_POSITIONAL_TARGET"), source_target, recovered_target
    if source_target.startswith("UNKNOWN:"):
        # Not a verdict either way - but a recovery that holds nothing where the source held
        # something unnameable is the case worth reading, so it is not folded in with the rest.
        status = "SOURCE_TARGET_UNKNOWN_RECOVERED_NULL" if recovered_target == "NULL" else "SOURCE_TARGET_UNKNOWN"
        return status, source_target, recovered_target
    if recovered_target.startswith("UNKNOWN:"):
        return "RECOVERED_TARGET_UNKNOWN", source_target, recovered_target
    if source_target == "NULL":
        return "NULL_IN_SOURCE", source_target, recovered_target
    if recovered_target == "NULL":
        return "NULL_IN_RECOVERED", source_target, recovered_target
    if source_target == recovered_target:
        return "MATCH", source_target, recovered_target
    source_class, _, source_name = source_target.partition(":")
    recovered_class, _, recovered_name = recovered_target.partition(":")
    if source_class == recovered_class and EXPORTER_FILE_NAME.sub("_", source_name) == recovered_name:
        return "DIFFERENT_NAME_SANITIZED", source_target, recovered_target
    if "?" in source_target and re.sub(r"<\?[0-9a-f]{32}>|Script:\?[0-9a-f]{32}", "", source_target) == \
            re.sub(r"<[^<>]*>|Script:[\w.]+", "", recovered_target):
        # Everything agrees except a script class the source checkout cannot name.
        return "SOURCE_TARGET_UNKNOWN", source_target, recovered_target
    return "DIFFERENT", source_target, recovered_target


def compare_references(source_graph, recovered_graph, source_component, recovered_component, pairing,
                       tally, examples, scope):
    source_refs = dict(references(source_graph.objects[source_component].body))
    recovered_refs = dict(references(recovered_graph.objects[recovered_component].body))
    for path in sorted(set(source_refs) | set(recovered_refs)):
        if path not in source_refs:
            status, source_target, recovered_target = \
                "FIELD_ABSENT_IN_SOURCE", None, recovered_graph.describe(recovered_refs[path])
        elif path not in recovered_refs:
            status, source_target, recovered_target = \
                "FIELD_ABSENT_IN_RECOVERED", source_graph.describe(source_refs[path]), None
        else:
            status, source_target, recovered_target = reference_status(
                source_graph, recovered_graph, source_refs[path], recovered_refs[path], pairing)
        tally[scope][status] += 1
        # Every "source unknown, recovered null" is kept, since that is the list someone has to read.
        cap = 10 ** 6 if status == "SOURCE_TARGET_UNKNOWN_RECOVERED_NULL" else 25
        if status not in ("MATCH", "NULL_BOTH", "MATCH_POSITIONAL_TARGET") and len(examples[status]) < cap:
            key = source_graph.component_key.get(source_component)
            examples[status].append({"component": f"{key[0]}#{key[1]}" if key else "?", "field": path,
                                     "source": source_target, "recovered": recovered_target})


def pair_components(source_graph, recovered_graph, source_go, recovered_go, result, examples):
    """(source component, recovered component, how) for one matched GameObject."""
    def on(graph, game_object):
        return [c for c, key in graph.component_key.items() if key[0] == graph.path[game_object]]

    source_components = on(source_graph, source_go)
    recovered_components = on(recovered_graph, recovered_go)
    remaining = {recovered_graph.component_key[c][1:]: c for c in recovered_components}
    paired, undeclared = [], []
    for component in source_components:
        key = source_graph.component_key[component][1:]
        if key[0].startswith("Script:?") or key[0].startswith("Script:#"):
            undeclared.append(component)
        elif key in remaining:
            paired.append((component, remaining.pop(key), "exact"))
        else:
            result["components"]["MISSING_IN_RECOVERED"] += 1
            if len(examples["COMPONENT_MISSING"]) < 25:
                examples["COMPONENT_MISSING"].append(f"{source_graph.path[source_go]}#{key[0]}")

    def take(candidate):
        for key, value in list(remaining.items()):
            if value == candidate:
                del remaining[key]

    # A DLL script is named by a hash of its class, so its counterpart is found by hashing each
    # candidate rather than by comparing names.
    for component in list(undeclared):
        identity = source_graph.component_key[component][1]
        if not identity.startswith("Script:#"):
            continue
        expected = int(identity[len("Script:#"):].split("@")[0])
        for candidate in [c for c in remaining.values() if recovered_graph.objects[c].cls == 114]:
            namespace, _, name = recovered_graph.component_key[candidate][1][len("Script:"):].rpartition(".")
            if script_file_id(namespace, name) == expected:
                paired.append((component, candidate, "exact"))
                take(candidate)
                undeclared.remove(component)
                break

    # What is left of the MonoBehaviours on each side is paired in component order, and marked: a
    # build keeps a GameObject's component order, but a position is not a type.
    source_kinds = {source_graph.component_key[s][1] for s in source_components}
    leftovers = [c for c in recovered_components if c in remaining.values()
                 and recovered_graph.objects[c].cls == 114
                 and recovered_graph.component_key[c][1] not in source_kinds]
    for component, candidate in zip(undeclared, leftovers):
        paired.append((component, candidate, "positional"))
        take(candidate)
    for _ in undeclared[len(leftovers):]:
        result["components"]["MISSING_IN_RECOVERED"] += 1
    for extra in remaining.values():
        result["components"]["EXTRA_IN_RECOVERED"] += 1
        if len(examples["COMPONENT_EXTRA"]) < 25:
            examples["COMPONENT_EXTRA"].append(
                f"{recovered_graph.path[recovered_go]}#{recovered_graph.component_key[extra][1]}")
    return paired


def compare_scene(source: Project, recovered: Project, source_scene, recovered_scene):
    source_graph = Graph(source, source.expanded(source_scene), str(source_scene))
    recovered_graph = Graph(recovered, recovered.expanded(recovered_scene), str(recovered_scene))
    result = {"gameObjects": collections.Counter(), "components": collections.Counter(),
              "scripts": collections.Counter(), "references": collections.defaultdict(collections.Counter)}
    examples = collections.defaultdict(list)

    recovered_by_path = {path: go for go, path in recovered_graph.path.items()}
    editor_only_roots = [p for g, p in source_graph.path.items()
                         if source_graph.objects[g].body.get("m_TagString") == "EditorOnly"]
    matched = []
    for game_object, path in source_graph.path.items():
        if path in recovered_by_path:
            result["gameObjects"]["MATCHED"] += 1
            matched.append((game_object, recovered_by_path[path]))
        elif any(path == root or path.startswith(root + "/") for root in editor_only_roots):
            result["gameObjects"]["EDITOR_ONLY"] += 1
        else:
            result["gameObjects"]["MISSING_IN_RECOVERED"] += 1
            if len(examples["GAMEOBJECT_MISSING"]) < 25:
                examples["GAMEOBJECT_MISSING"].append(path)
    source_paths = set(source_graph.path.values())
    for path in recovered_by_path:
        if path not in source_paths:
            result["gameObjects"]["EXTRA_IN_RECOVERED"] += 1
            if len(examples["GAMEOBJECT_EXTRA"]) < 25:
                examples["GAMEOBJECT_EXTRA"].append(path)

    pairs = []
    pairing = {}
    for source_go, recovered_go in matched:
        pairing[source_go] = (recovered_go, "exact")
        for source_component, recovered_component, how in pair_components(
                source_graph, recovered_graph, source_go, recovered_go, result, examples):
            pairs.append((source_go, source_component, recovered_component, how))
            pairing[source_component] = (recovered_component, how)

    for source_go, source_component, recovered_component, how in pairs:
        result["components"]["MATCHED" if how == "exact" else "MATCHED_POSITIONAL"] += 1
        if source_graph.objects[source_component].cls == 114:
            status = bind(source_graph, recovered_graph, source_component, recovered_component)
            result["scripts"][status] += 1
            if status in ("BOUND_DIFFERENT", "SCRIPT_MISSING") and len(examples[status]) < 25:
                examples[status].append({"component": source_graph.path[source_go],
                                         "source": source_graph.component_key[source_component][1],
                                         "recovered": recovered_graph.component_key[recovered_component][1]})
        compare_references(source_graph, recovered_graph, source_component, recovered_component, pairing,
                           result["references"], examples, "exact" if how == "exact" else "positional")

    return {"gameObjects": dict(result["gameObjects"]), "components": dict(result["components"]),
            "scripts": dict(result["scripts"]),
            "references": {scope: dict(counts) for scope, counts in result["references"].items()},
            "examples": dict(examples)}



def build_scenes(root: pathlib.Path):
    settings = root / "ProjectSettings" / "EditorBuildSettings.asset"
    if not settings.exists():
        return []
    text = settings.read_text(encoding="utf-8", errors="replace")
    return [m.group(2) for m in re.finditer(r"- enabled: (1)\n\s+path: (.+)", text)]


def pair_scenes(source_root: pathlib.Path, recovered_root: pathlib.Path):
    """Each recovered scene with the source scene it was built from, by path first and then by name."""
    source_scenes = {p.relative_to(source_root).as_posix(): p for p in source_root.glob("Assets/**/*.unity")}
    by_name = collections.defaultdict(list)
    for relative, path in source_scenes.items():
        by_name[path.name].append(path)
    pairs = []
    for recovered in sorted(recovered_root.glob("Assets/**/*.unity")):
        relative = recovered.relative_to(recovered_root).as_posix()
        if relative in source_scenes:
            pairs.append((relative, source_scenes[relative], recovered, "PATH"))
        elif len(by_name[recovered.name]) == 1:
            pairs.append((relative, by_name[recovered.name][0], recovered, "NAME"))
        else:
            pairs.append((relative, None, recovered, "NO_SOURCE" if not by_name[recovered.name] else "AMBIGUOUS"))
    return pairs


def rates(total):
    """The rates are over what could be decided. UNKNOWN is reported beside them, never inside."""
    decided_statuses = {"MATCH", "DIFFERENT", "DIFFERENT_NAME_SANITIZED", "NULL_IN_RECOVERED",
                        "NULL_IN_SOURCE", "RECOVERED_TARGET_UNKNOWN", "FIELD_ABSENT_IN_RECOVERED"}
    out = {}
    for scope in ("exact", "positional"):
        counts = total["references"].get(scope, {})
        decided = sum(v for k, v in counts.items() if k in decided_statuses)
        out[f"reference_match_rate_{scope}"] = round(counts.get("MATCH", 0) / decided, 4) if decided else None
        out[f"reference_decided_{scope}"] = decided
        out[f"reference_unknown_{scope}"] = counts.get("SOURCE_TARGET_UNKNOWN", 0) + \
            counts.get("SOURCE_TARGET_UNKNOWN_RECOVERED_NULL", 0)
        out[f"reference_positional_target_{scope}"] = counts.get("MATCH_POSITIONAL_TARGET", 0)
    scripts = total["scripts"]
    bound = scripts.get("BOUND_EXACT", 0) + scripts.get("BOUND_EXACT_BY_HASH", 0)
    decidable = bound + scripts.get("BOUND_DIFFERENT", 0) + scripts.get("SCRIPT_MISSING", 0)
    game_objects = total["gameObjects"]
    expected = game_objects.get("MATCHED", 0) + game_objects.get("MISSING_IN_RECOVERED", 0)
    out.update({
        "gameobject_match_rate": round(game_objects.get("MATCHED", 0) / expected, 4) if expected else None,
        "script_binding_rate": round(bound / decidable, 4) if decidable else None,
        "script_binding_decided": f"{decidable} of {sum(scripts.values())}",
    })
    return out


def run(source_root, recovered_root, package_dirs):
    source = Project(source_root, package_dirs)
    recovered = Project(recovered_root)
    report = {"source": str(source_root), "recovered": str(recovered_root),
              "sourceBuildScenes": build_scenes(source_root), "scenes": []}
    total = {"gameObjects": collections.Counter(), "components": collections.Counter(),
             "scripts": collections.Counter(), "references": collections.defaultdict(collections.Counter)}
    for relative, source_scene, recovered_scene, how in pair_scenes(source_root, recovered_root):
        entry = {"scene": relative, "pairedBy": how}
        if source_scene is None:
            report["scenes"].append(entry)
            continue
        entry["sourceScene"] = source_scene.relative_to(source_root).as_posix()
        entry.update(compare_scene(source, recovered, source_scene, recovered_scene))
        for key in ("gameObjects", "components", "scripts"):
            total[key].update(entry[key])
        for scope, counts in entry["references"].items():
            total["references"][scope].update(counts)
        report["scenes"].append(entry)
    report["total"] = {"gameObjects": dict(total["gameObjects"]), "components": dict(total["components"]),
                       "scripts": dict(total["scripts"]),
                       "references": {s: dict(c) for s, c in total["references"].items()}}
    report["rates"] = rates(report["total"])
    return report


# --------------------------------------------------------------------------------------------------

def self_test() -> int:
    import tempfile
    failures = 0

    def check(name, condition):
        nonlocal failures
        print(("ok   " if condition else "FAIL ") + name)
        failures += 0 if condition else 1

    # Unity's own published value for this class (MonoBehaviour fileID of UnityEngine.UI.Image).
    check("DLL script fileID is Unity's MD4 rule", script_file_id("UnityEngine.UI", "Image") == -765806418)

    with tempfile.TemporaryDirectory() as tmp:
        root = pathlib.Path(tmp)
        (root / "Assets").mkdir()
        (root / "ProjectSettings").mkdir()

        def write(name, text, guid):
            (root / "Assets" / name).write_text(text)
            (root / "Assets" / (name + ".meta")).write_text(f"fileFormatVersion: 2\nguid: {guid}\n")

        write("Mover.cs", "namespace Game { public class Mover : MonoBehaviour {} }", "a" * 32)
        write("Skin.mat", "%YAML 1.1\n--- !u!21 &2100000\nMaterial:\n  m_Name: Skin\n", "b" * 32)
        prefab = ("--- !u!1 &100\nGameObject:\n  m_Name: Enemy\n  m_Component:\n  - component: {fileID: 400}\n"
                  "  - component: {fileID: 500}\n  - component: {fileID: 600}\n"
                  "--- !u!4 &400\nTransform:\n  m_GameObject: {fileID: 100}\n  m_Father: {fileID: 0}\n  m_Children: []\n"
                  f"--- !u!114 &500\nMonoBehaviour:\n  m_GameObject: {{fileID: 100}}\n  m_Script: {{fileID: 11500000, guid: {'a' * 32}, type: 3}}\n"
                  "  target: {fileID: 0}\n  skin: {fileID: 0}\n"
                  "--- !u!65 &600\nBoxCollider:\n  m_GameObject: {fileID: 100}\n")
        write("Enemy.prefab", prefab, "c" * 32)
        scene = ("--- !u!1 &1\nGameObject:\n  m_Name: Player\n  m_Component:\n  - component: {fileID: 2}\n"
                 "--- !u!4 &2\nTransform:\n  m_GameObject: {fileID: 1}\n  m_Father: {fileID: 0}\n  m_Children: []\n"
                 "--- !u!1001 &7\nPrefabInstance:\n  m_Modification:\n    m_TransformParent: {fileID: 2}\n"
                 "    m_Modifications:\n"
                 f"    - target: {{fileID: 100, guid: {'c' * 32}, type: 3}}\n      propertyPath: m_Name\n      value: Boss\n      objectReference: {{fileID: 0}}\n"
                 f"    - target: {{fileID: 500, guid: {'c' * 32}, type: 3}}\n      propertyPath: target\n      value: \n      objectReference: {{fileID: 1}}\n"
                 f"    - target: {{fileID: 500, guid: {'c' * 32}, type: 3}}\n      propertyPath: skin\n      value: \n      objectReference: {{fileID: 2100000, guid: {'b' * 32}, type: 2}}\n"
                 f"  m_RemovedComponents:\n  - {{fileID: 600, guid: {'c' * 32}, type: 3}}\n"
                 f"  m_SourcePrefab: {{fileID: 100100000, guid: {'c' * 32}, type: 3}}\n")
        (root / "Assets" / "Main.unity").write_text(scene)

        project = Project(root)
        objects = project.expanded(root / "Assets" / "Main.unity")
        check("an instance's objects take (instance ^ source) & 0x7FFF...", ((7 ^ 500) & MASK63) in objects)
        graph = Graph(project, objects, "Main")
        check("a renamed instance root is placed under its parent", "Player/Boss" in graph.path.values())
        behaviour = objects[(7 ^ 500) & MASK63]
        refs = dict(references(behaviour.body))
        check("a reference override lands on the instance", graph.describe(refs["target"]) == "GameObject:Player")
        check("an override naming an asset resolves by name", graph.describe(refs["skin"]) == "Material:Skin")
        check("a removed component is gone", ((7 ^ 600) & MASK63) not in objects)
        check("a script is its namespace and class, not its GUID",
              graph.component_type((7 ^ 500) & MASK63) == "Script:Game.Mover")

        # An upgraded scene: the stripped document keeps the source's own ID, and a reference uses it.
        upgraded = ("--- !u!1001 &9\nPrefabInstance:\n  m_Modification:\n    m_TransformParent: {fileID: 0}\n"
                    f"    m_Modifications: []\n  m_SourcePrefab: {{fileID: 100100000, guid: {'c' * 32}, type: 3}}\n"
                    "--- !u!114 &500 stripped\nMonoBehaviour:\n"
                    f"  m_CorrespondingSourceObject: {{fileID: 500, guid: {'c' * 32}, type: 3}}\n"
                    "  m_PrefabInstance: {fileID: 9}\n")
        (root / "Assets" / "Old.unity").write_text(upgraded)
        old_objects = Project(root).expanded(root / "Assets" / "Old.unity")
        check("a stripped document's ID is the authority over the XOR", 500 in old_objects
              and ((9 ^ 500) & MASK63) not in old_objects)
        (root / "Assets" / "Enemy.prefab").write_text(prefab.replace("m_Name: Enemy", "m_Name: Stale"))
        renamed = Project(root)
        check("a prefab's root takes the asset's name, not its stale m_Name",
              Graph(renamed, renamed.expanded(root / "Assets" / "Main.unity"), "Main").describe(
                  {"fileID": 100, "guid": "c" * 32, "type": 3}) == "PrefabGameObject:Enemy")
        check("the exporter's file name rule is recognised as a rename, not a different object",
              reference_status(graph, graph, {"fileID": 1}, {"fileID": 1}, {}) [0] == "MATCH"
              and EXPORTER_FILE_NAME.sub("_", "End (Orchestral, Horror)") == "End (Orchestral_ Horror)")

        recovered = Project(root)
        self_graph = Graph(recovered, recovered.expanded(root / "Assets" / "Main.unity"), "Main")
        component = (7 ^ 500) & MASK63
        check("a component bound to its own script is BOUND_EXACT",
              bind(graph, self_graph, component, component) == "BOUND_EXACT")
        broken = copy.deepcopy(self_graph.objects[component].body)
        broken["m_Script"] = {"fileID": 0}
        self_graph.objects[component] = Obj(114, "MonoBehaviour", broken)
        check("a recovered component with no script is SCRIPT_MISSING",
              bind(graph, self_graph, component, component) == "SCRIPT_MISSING")
        undeclared = copy.deepcopy(graph.objects[component].body)
        undeclared["m_Script"] = {"fileID": 11500000, "guid": "d" * 32, "type": 3}
        graph.objects[component] = Obj(114, "MonoBehaviour", undeclared)
        self_graph.objects[component] = Obj(114, "MonoBehaviour", copy.deepcopy(behaviour.body))
        check("an undeclared source script is never a match",
              bind(graph, self_graph, component, component) == "SOURCE_SCRIPT_UNDECLARED")
    return failures


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("source", nargs="?")
    parser.add_argument("recovered", nargs="?")
    parser.add_argument("--package-dir", action="append", default=[])
    parser.add_argument("--json")
    parser.add_argument("--verbose", action="store_true")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()
    if args.self_test:
        sys.exit(1 if self_test() else 0)
    if not args.source or not args.recovered:
        parser.error("source and recovered are required")
    recovered_root = pathlib.Path(args.recovered)
    if not (recovered_root / "Assets").is_dir():
        print(f"PROJECT_ROOT_MISMATCH: {recovered_root} has no Assets/ - pass the game directory inside the rip")
        sys.exit(2)
    report = run(pathlib.Path(args.source), recovered_root, args.package_dir)
    for scene in report["scenes"]:
        print(f"== {scene['scene']} ({scene['pairedBy']}{' <- ' + scene['sourceScene'] if 'sourceScene' in scene else ''})")
        for key in ("gameObjects", "components", "scripts", "references"):
            if key in scene:
                print(f"  {key:12} {json.dumps(scene[key], sort_keys=True)}")
        if args.verbose:
            for status, items in scene.get("examples", {}).items():
                print(f"  -- {status}")
                for item in items[:10]:
                    print(f"     {item}")
    print("TOTAL", json.dumps(report["total"], sort_keys=True))
    print("RATES", json.dumps(report["rates"], sort_keys=True))
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(report, indent=1, sort_keys=True))


if __name__ == "__main__":
    main()
