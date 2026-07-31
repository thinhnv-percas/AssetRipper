"""Port of Source/AssetRipper.GUI.Web/Pages/Assets/{AssetAPI,ViewPage,InformationTab,HexTab}.cs

Implements the Information and Hex tabs, plus a Fields tab that has no direct upstream
counterpart: upstream's tabs read generated typed properties, whereas assets here are
TypeTreeObjects with dict-style field access, so the field tree itself is what's worth
showing. Assets whose layout couldn't be resolved (UnknownObject/UnreadableObject) still
fall back to a hex dump of their raw bytes.

The Image/Audio/Model/Font/Video/Yaml tabs need Export.Modules.* converters, which are a
later phase.
"""
from __future__ import annotations

from flask import Blueprint, abort, render_template

from .. import game_file_loader
from ..path_params import get_path_param
from ..paths import AssetPath, try_get_asset

bp = Blueprint("assets", __name__, url_prefix="/Assets")

_MAX_HEX_BYTES = 64 * 1024


def _hex_dump(data: bytes, bytes_per_row: int = 16) -> list[tuple[str, str, str]]:
    rows = []
    for offset in range(0, min(len(data), _MAX_HEX_BYTES), bytes_per_row):
        chunk = data[offset : offset + bytes_per_row]
        hex_part = " ".join(f"{b:02x}" for b in chunk)
        ascii_part = "".join(chr(b) if 32 <= b < 127 else "." for b in chunk)
        rows.append((f"{offset:08x}", hex_part, ascii_part))
    return rows


def _field_rows(value, name: str = "", depth: int = 0) -> list[tuple[int, str, str, str]]:
    """Flattens a decoded field tree into (depth, name, type, rendered_value) rows.

    Nested structures and lists recurse; leaves render directly. Long lists are truncated
    so a mesh's vertex buffer doesn't produce a million rows.
    """
    rows: list[tuple[int, str, str, str]] = []
    if hasattr(value, "items") and hasattr(value, "keys"):
        rows.append((depth, name, getattr(getattr(value, "type", None), "name", "") or "", ""))
        for child_name, child_value in value.items():
            rows.extend(_field_rows(child_value, child_name, depth + 1))
    elif isinstance(value, list):
        rows.append((depth, name, f"list[{len(value)}]", ""))
        for i, item in enumerate(value[:64]):
            rows.extend(_field_rows(item, f"[{i}]", depth + 1))
        if len(value) > 64:
            rows.append((depth + 1, f"... {len(value) - 64} more", "", ""))
    else:
        rows.append((depth, name, type(value).__name__, repr(value)))
    return rows


@bp.get("/View")
def view():
    path = get_path_param(AssetPath)
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    asset = try_get_asset(game_file_loader.game_bundle(), path)
    if asset is None:
        abort(404, description=f"Asset could not be resolved: {path}")

    fields = getattr(asset, "fields", None)
    field_rows = []
    if fields is not None and hasattr(fields, "items"):
        for name, value in fields.items():
            field_rows.extend(_field_rows(value, name))

    raw_data = getattr(asset, "raw_data", b"")
    return render_template(
        "assets/view.html",
        asset=asset,
        path=path,
        field_rows=field_rows,
        hex_rows=_hex_dump(raw_data),
        data_length=len(raw_data),
        truncated=len(raw_data) > _MAX_HEX_BYTES,
    )
