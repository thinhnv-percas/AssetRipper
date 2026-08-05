"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/ScriptHashing.cs

Replicates Unity's own script FileID/GUID algorithms so exported script references are
stable and match what a real Unity project would assign (rather than random per-run
values), using the pure-Python MD4 (md4.py) and UnityGuid.md5_hash added alongside it.
"""
from __future__ import annotations

import struct

from assetripper_io_files.special_file_names import remove_assembly_file_extension
from assetripper_primitives import UnityGuid

from .md4 import md4


def calculate_script_file_id(namespace: str, name: str) -> int:
    """The FileID of a script inside a compiled assembly."""
    source = b"s\x00\x00\x00" + namespace.encode("utf-8") + name.encode("utf-8")
    digest = md4(source)
    return struct.unpack_from("<i", digest, 0)[0]


def calculate_script_guid(assembly_name: str, namespace: str, class_name: str) -> UnityGuid:
    """A stable per-script GUID derived from (assembly, namespace, class) -- script GUIDs
    are otherwise random when created in the Unity Editor, so this exists purely for
    export-to-export consistency, not to match any real project's actual GUIDs."""
    return UnityGuid.md5_hash(
        assembly_name.encode("utf-8"), namespace.encode("utf-8"), class_name.encode("utf-8")
    )


def calculate_assembly_guid(assembly_name: str) -> UnityGuid:
    """A stable per-assembly GUID, same rationale as calculate_script_guid."""
    return UnityGuid.md5_hash(remove_assembly_file_extension(assembly_name).encode("utf-8"))
