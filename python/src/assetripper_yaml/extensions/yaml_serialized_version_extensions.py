"""Port of Source/AssetRipper.Yaml/Extensions/YamlSerializedVersionExtensions.cs"""
from __future__ import annotations

SERIALIZED_VERSION_NAME = "serializedVersion"


def add_serialized_version(mapping_node, version: int) -> None:
    if version > 1:
        mapping_node.add(SERIALIZED_VERSION_NAME, version)


def force_add_serialized_version(mapping_node, version: int) -> None:
    if version > 0:
        mapping_node.add(SERIALIZED_VERSION_NAME, version)


def insert_serialized_version(mapping_node, version: int) -> None:
    if version > 1:
        mapping_node.insert_begin(SERIALIZED_VERSION_NAME, version)
