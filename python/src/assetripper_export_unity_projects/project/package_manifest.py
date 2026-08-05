"""Port of Source/AssetRipper.Export.UnityProjects/Project/PackageManifest.cs

Fixed, version-stable list of built-in Unity package dependencies (accurate to at least
2023 per upstream's own comment) -- copied verbatim, not reconstructed.
"""
from __future__ import annotations

import json

_ALWAYS_PRESENT = (
    "com.unity.modules.ai",
    "com.unity.modules.animation",
    "com.unity.modules.assetbundle",
    "com.unity.modules.audio",
    "com.unity.modules.cloth",
    "com.unity.modules.director",
    "com.unity.modules.imageconversion",
    "com.unity.modules.imgui",
    "com.unity.modules.jsonserialize",
    "com.unity.modules.particlesystem",
    "com.unity.modules.physics",
    "com.unity.modules.physics2d",
    "com.unity.modules.screencapture",
    "com.unity.modules.terrain",
    "com.unity.modules.terrainphysics",
    "com.unity.modules.tilemap",
    "com.unity.modules.ui",
    "com.unity.modules.uielements",
    "com.unity.modules.umbra",
    "com.unity.modules.unityanalytics",
    "com.unity.modules.unitywebrequest",
    "com.unity.modules.unitywebrequestassetbundle",
    "com.unity.modules.unitywebrequestaudio",
    "com.unity.modules.unitywebrequesttexture",
    "com.unity.modules.unitywebrequestwww",
    "com.unity.modules.vehicles",
    "com.unity.modules.video",
    "com.unity.modules.vr",
    "com.unity.modules.wind",
    "com.unity.modules.xr",
)


def create_default_manifest(version) -> dict:
    """Returns the `{"dependencies": {...}}` dict for `Packages/manifest.json`."""
    dependencies = {}
    dependencies["com.unity.modules.ai"] = "1.0.0"
    if version.greater_than_or_equals(2019, 2):
        dependencies["com.unity.modules.androidjni"] = "1.0.0"
    for name in _ALWAYS_PRESENT[1:]:
        dependencies[name] = "1.0.0"
    return {"dependencies": dependencies}


def save_manifest(manifest: dict, stream) -> None:
    data = json.dumps(manifest, indent=2).encode("utf-8")
    stream.write(data, 0, len(data))
