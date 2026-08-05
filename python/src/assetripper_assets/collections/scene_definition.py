"""Port of Source/AssetRipper.Assets/Collections/SceneDefinition.cs"""
from __future__ import annotations

import posixpath

from assetripper_primitives import UnityGuid


class SceneDefinition:
    def __init__(self, name: str, path: str, guid: UnityGuid):
        self.name = name
        self.path = path
        self.guid = guid
        self._collections: list = []

    @staticmethod
    def from_name(name: str, guid: UnityGuid | None = None) -> "SceneDefinition":
        guid = guid if guid is not None else UnityGuid()
        return SceneDefinition(
            name=name,
            path=f"Assets/Scenes/{name}",
            guid=UnityGuid.new_guid() if guid.is_zero else guid,
        )

    @staticmethod
    def from_path(path: str, guid: UnityGuid | None = None) -> "SceneDefinition":
        guid = guid if guid is not None else UnityGuid()
        return SceneDefinition(
            name=posixpath.basename(path),
            path=path,
            guid=UnityGuid.new_guid() if guid.is_zero else guid,
        )

    @property
    def collections(self) -> list:
        return self._collections

    @property
    def assets(self):
        for collection in self._collections:
            yield from collection

    def add_collection(self, collection) -> None:
        if collection.scene is not None:
            raise Exception(f"{collection} is already part of a scene.")
        self._collections.append(collection)
        collection.scene = self

    def remove_collection(self, collection) -> None:
        try:
            self._collections.remove(collection)
        except ValueError:
            raise ValueError(f"{collection} is not part of this scene.") from None
        collection.scene = None

    def __str__(self) -> str:
        return self.name
