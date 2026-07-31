"""Port of the reachable-without-generated-classes slice of AssetRipper.Export.UnityProjects.

Turns dynamically-read assets (assetripper_import.asset_creation.type_tree_object) into a
directory of Unity YAML `.asset` files with matching `.meta` files -- see this package's
individual modules for what's ported and what's deliberately deferred to later phases.
"""
