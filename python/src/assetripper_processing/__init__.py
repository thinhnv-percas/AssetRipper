"""Port of the reachable-without-generated-classes slice of AssetRipper.Processing.

Only the processors upstream's own ExportHandler.GetProcessors() ordering makes essential
to a loadable project are ported here (scene definitions, original paths, main-asset
pairing, editor-format defaults for PlayerSettings), each scoped down to what's tractable
without generated typed classes -- see each module's docstring for exactly what's covered
and what's deferred. The 11 Assemblies/ processors are skipped entirely: they all iterate
`assembly_manager.get_assemblies()`, which is always empty under this port's null assembly
manager (see assetripper_import/structure/game_structure.py), making them provable no-ops.

PrefabProcessor is NOT ported this phase: it needs to synthesize brand-new default-valued
Transform/PrefabInstance assets from scratch (a "construct an instance to serialize", not
"read bytes against a layout" operation Phase 2's layouts don't support) and the
multi-asset-per-file (.prefab/.unity) export machinery Phase 4 explicitly deferred. Scene/
prefab file generation is consequently still not implemented -- this phase lays the
SceneDefinition/original-path/main-asset groundwork it will need.
"""
