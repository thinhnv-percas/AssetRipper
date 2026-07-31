"""Port of Source/AssetRipper.GUI.Web/Pages/Assets/{AssetAPI,ViewPage,InformationTab,HexTab}.cs

Only the Information and Hex tabs are implemented: they only need the raw ObjectInfo
bytes RawAsset carries. Image/Audio/Model/Font/Video/Json/Yaml/Text tabs all need
typed asset classes (SourceGenerated) or Export.Modules.* converters, neither of
which is ported.
"""
from __future__ import annotations

from flask import Blueprint, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import AssetPath, try_get_asset

bp = Blueprint("assets", __name__, url_prefix="/Assets")


def _hex_dump(data: bytes, bytes_per_row: int = 16) -> list[tuple[str, str, str]]:
    rows = []
    for offset in range(0, len(data), bytes_per_row):
        chunk = data[offset : offset + bytes_per_row]
        hex_part = " ".join(f"{b:02x}" for b in chunk)
        ascii_part = "".join(chr(b) if 32 <= b < 127 else "." for b in chunk)
        rows.append((f"{offset:08x}", hex_part, ascii_part))
    return rows


@bp.get("/View")
def view():
    path = get_path_param(AssetPath)
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    asset = try_get_asset(game_file_loader.game_bundle(), path)
    if asset is None:
        abort(404, description=f"Asset could not be resolved: {path}")

    object_data = getattr(asset, "object_data", b"")
    return render_template(
        "assets/view.html",
        asset=asset,
        path=path,
        hex_rows=_hex_dump(object_data),
        data_length=len(object_data),
    )
