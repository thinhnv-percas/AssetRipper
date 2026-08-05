"""
Port of Source/AssetRipper.Assets/UnityObjectBase.cs and UnityObjectBase.PathDetails.cs

The artificial base class for all Unity classes which inherit from Object.
"""
from __future__ import annotations

import posixpath

from .i_unity_object_base import IUnityObjectBase
from .string_path_extensions import not_empty, remove_period
from .unity_asset_base import UnityAssetBase


class _PathDetails:
    """Project-relative path composition (Assets/Scenes/scene.unity-style paths).
    Uses posixpath deliberately -- these are virtual project paths that always use '/',
    not real host filesystem paths, so path splitting shouldn't depend on the host OS."""

    __slots__ = ("_directory", "_name", "_extension", "_full_path")

    def __init__(self):
        self._directory: str | None = None
        self._name: str | None = None
        self._extension: str | None = None
        self._full_path: str | None = None

    @property
    def directory(self) -> str | None:
        return self._directory

    @directory.setter
    def directory(self, value: str | None) -> None:
        self._directory = not_empty(value)
        self._full_path = None

    @property
    def name(self) -> str | None:
        return self._name

    @name.setter
    def name(self, value: str | None) -> None:
        self._name = not_empty(value)
        self._full_path = None

    @property
    def extension(self) -> str | None:
        """Not including the period."""
        return self._extension

    @extension.setter
    def extension(self, value: str | None) -> None:
        self._extension = not_empty(remove_period(value))
        self._full_path = None

    @property
    def full_path(self) -> str | None:
        if self._full_path is None:
            self._full_path = self._calculate_path()
        return self._full_path

    @full_path.setter
    def full_path(self, value: str | None) -> None:
        if value != self._full_path:
            self._full_path = not_empty(value)
            self._directory = not_empty(posixpath.dirname(value)) if value else None
            base_name = posixpath.basename(value) if value else ""
            root, ext = posixpath.splitext(base_name)
            self._name = not_empty(root)
            self._extension = not_empty(remove_period(ext))

    @property
    def _name_with_extension(self) -> str | None:
        return self._name if self._extension is None else f"{self._name}.{self._extension}"

    def __str__(self) -> str:
        return self.full_path or ""

    def _calculate_path(self) -> str | None:
        name_with_ext = self._name_with_extension
        if self._directory is None:
            return name_with_ext
        return posixpath.join(self._directory, name_with_ext) if name_with_ext else self._directory


class UnityObjectBase(UnityAssetBase, IUnityObjectBase):
    def __init__(self, asset_info):
        self._asset_info = asset_info
        self._original_path_details: _PathDetails | None = None
        self._override_path_details: _PathDetails | None = None
        self.main_asset = None
        self.asset_bundle_name: str | None = None

    @property
    def asset_info(self):
        return self._asset_info

    @property
    def collection(self):
        return self.asset_info.collection

    @property
    def class_id(self) -> int:
        return self.asset_info.class_id

    @property
    def path_id(self) -> int:
        return self.asset_info.path_id

    @property
    def class_name(self) -> str:
        return type(self).__name__

    @property
    def original_path(self) -> str | None:
        return str(self._original_path_details) if self._original_path_details is not None else None

    @original_path.setter
    def original_path(self, value: str | None) -> None:
        if value is None:
            self._original_path_details = None
        else:
            if self._original_path_details is None:
                self._original_path_details = _PathDetails()
            self._original_path_details.full_path = value

    @property
    def original_directory(self) -> str | None:
        return self._original_path_details.directory if self._original_path_details is not None else None

    @original_directory.setter
    def original_directory(self, value: str | None) -> None:
        if self._original_path_details is not None:
            self._original_path_details.directory = value
        elif value is not None:
            self._original_path_details = _PathDetails()
            self._original_path_details.directory = value

    @property
    def original_name(self) -> str | None:
        return self._original_path_details.name if self._original_path_details is not None else None

    @original_name.setter
    def original_name(self, value: str | None) -> None:
        if self._original_path_details is not None:
            self._original_path_details.name = value
        elif value is not None:
            self._original_path_details = _PathDetails()
            self._original_path_details.name = value

    @property
    def original_extension(self) -> str | None:
        return self._original_path_details.extension if self._original_path_details is not None else None

    @original_extension.setter
    def original_extension(self, value: str | None) -> None:
        if self._original_path_details is not None:
            self._original_path_details.extension = value
        elif value is not None:
            self._original_path_details = _PathDetails()
            self._original_path_details.extension = value

    @property
    def override_path(self) -> str | None:
        return str(self._override_path_details) if self._override_path_details is not None else None

    @override_path.setter
    def override_path(self, value: str | None) -> None:
        if value is None:
            self._override_path_details = None
        else:
            if self._override_path_details is None:
                self._override_path_details = _PathDetails()
            self._override_path_details.full_path = value

    @property
    def override_directory(self) -> str | None:
        return self._override_path_details.directory if self._override_path_details is not None else None

    @override_directory.setter
    def override_directory(self, value: str | None) -> None:
        if self._override_path_details is not None:
            self._override_path_details.directory = value
        elif value is not None:
            self._override_path_details = _PathDetails()
            self._override_path_details.directory = value

    @property
    def override_name(self) -> str | None:
        return self._override_path_details.name if self._override_path_details is not None else None

    @override_name.setter
    def override_name(self, value: str | None) -> None:
        if self._override_path_details is not None:
            self._override_path_details.name = value
        elif value is not None:
            self._override_path_details = _PathDetails()
            self._override_path_details.name = value

    @property
    def override_extension(self) -> str | None:
        return self._override_path_details.extension if self._override_path_details is not None else None

    @override_extension.setter
    def override_extension(self, value: str | None) -> None:
        if self._override_path_details is not None:
            self._override_path_details.extension = value
        elif value is not None:
            self._override_path_details = _PathDetails()
            self._override_path_details.extension = value
