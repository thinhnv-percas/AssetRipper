"""Port of the reachable-without-generated-classes slice of AssetRipper.Export.UnityProjects'
content exporters (byte-passthrough tier only -- see the plan's Phase 6 cost/benefit
ordering). Textures, meshes, audio, shaders, and script exporters are not yet ported.

Architecture note: upstream dispatches exporters by *generated* C# type (`ITextAsset`,
`IMovieTexture`, ... are all distinct types), so `ObjectHandlerStack<IAssetExporter>` keyed
by `Type` works. In this port, every dynamically-read asset is the SAME Python type
(TypeTreeObject), regardless of its real Unity class -- type-based dispatch can't
distinguish a TextAsset from a Texture2D. `register_default_exporters` in
project_exporter_registration.py works around this by keying content exporters on
`asset.class_id` (an int) instead, checked before the type-based ObjectHandlerStack.
"""
