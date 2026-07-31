"""
Python port of the type-tree-driven parts of Source/AssetRipper.Import.

Upstream, AssetRipper.Import resolves an asset's field layout from generated per-version
classes (AssetRipper.SourceGenerated) and falls back to a TypeTree-driven dynamic reader.
Since the generated assembly is unavailable to this port, that fallback becomes the primary
path: every asset is read against a Unity TypeTree and exposed as a TypeTreeObject with
dict-style field access.

Ported: AssetCreation (minus the generated-class paths), Structure/Assembly/TypeTrees,
Structure/Assembly/Serializable.

Not ported: Structure/Assembly/Managers (AsmResolver assembly loading + Cpp2IL), the
IL-derived MonoBehaviour path (UnloadedStructure), and Logging (this port raises or returns
errors rather than routing through a global logger).
"""
from .class_id_type import ClassIDType

__all__ = ["ClassIDType"]
