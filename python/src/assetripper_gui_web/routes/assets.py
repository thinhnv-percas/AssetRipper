"""Port of Source/AssetRipper.GUI.Web/Pages/Assets/{AssetAPI,ViewPage,InformationTab,HexTab}.cs

Implements the Information and Hex tabs, plus a Fields tab that has no direct upstream
counterpart: upstream's tabs read generated typed properties, whereas assets here are
TypeTreeObjects with dict-style field access, so the field tree itself is what's worth
showing. Assets whose layout couldn't be resolved (UnknownObject/UnreadableObject) still
fall back to a hex dump of their raw bytes.

`/Assets/Image`, `/Assets/Binary`, `/Assets/Text`, `/Assets/Yaml` (Phase 11) mirror
upstream's `AssetAPI.cs` endpoints: each runs the asset through the real export pipeline
via `asset_preview.render_asset` (Phase 6/9/10's exporters, not reimplemented here) and
serves the resulting bytes with the right MIME type. Each declines (404) if no registered
exporter can handle the asset, or if the asset's actual extension doesn't belong to that
endpoint's group (e.g. a Shader's `.shader` text hitting `/Assets/Image`) -- `view.html`
only links to the endpoint matching the asset's real export extension, so this is a
defense-in-depth check, not the primary gate.
"""
from __future__ import annotations

from flask import Blueprint, Response, abort, render_template

from .. import game_file_loader
from ..asset_preview import IMAGE_EXTENSIONS, TEXT_EXTENSIONS, YAML_EXTENSIONS, mime_type_for_extension, render_asset
from ..path_params import get_path_param
from ..paths import AssetPath, get_asset_path, try_get_asset

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
        dependency_rows=_dependency_rows(asset),
        hex_rows=_hex_dump(raw_data),
        data_length=len(raw_data),
        truncated=len(raw_data) > _MAX_HEX_BYTES,
    )


def _resolve_pptr(collection, pptr):
    """Resolve `pptr` to whatever asset it points at, including a `NullObject` subclass.

    Upstream's DependenciesTab just calls `TryGetAsset`, which deliberately hides `NullObject`
    assets -- a PPtr to one is supposed to read as null. That is the right rule for export, and
    this port keeps it. But in *this port* almost every asset is a `TypeTreeObject`, which derives
    from `NullObject` exactly as upstream's does, so the plain lookup reports "Missing" for
    virtually every dependency and the tab shows nothing useful.

    So the lookup is done twice: the ordinary way first, then explicitly asking for a
    `NullObject`. Browsing is not exporting -- the user wants to see where the reference actually
    goes -- and this is confined to the GUI's dependency listing, nowhere near the export path.
    """
    target = collection.get_asset_by_pptr(pptr)
    if target is not None:
        return target
    from assetripper_assets.null_object import NullObject

    return collection.get_asset_by_pptr(pptr, NullObject)


def _dependency_rows(asset) -> "list[dict]":
    """Port of Pages/Assets/DependenciesTab.cs: every non-null PPtr this asset holds, resolved
    to a real asset where possible. Null PPtrs are skipped -- upstream skips them too, and an
    asset's dependency list is mostly nulls in practice (every unset reference field is one), so
    listing them would bury the real entries."""
    rows: "list[dict]" = []
    fetch = getattr(asset, "fetch_dependencies", None)
    if not callable(fetch):
        return rows
    try:
        dependencies = list(fetch())
    except Exception:  # noqa: BLE001 -- one bad field must not take the whole page down
        return rows

    for field_path, pptr in dependencies:
        if pptr is None or pptr.is_null:
            continue
        target = None
        try:
            target = _resolve_pptr(asset.collection, pptr)
        except Exception:  # noqa: BLE001 -- an unresolvable dependency renders as "Missing"
            target = None
        rows.append(
            {
                "field_path": field_path,
                "file_id": pptr.file_id,
                "path_id": pptr.path_id,
                "target": target,
                "target_path": get_asset_path(target) if target is not None else None,
            }
        )
    return rows


def _resolve_asset():
    path = get_path_param(AssetPath)
    if not game_file_loader.is_loaded():
        abort(404, description="No files loaded.")
    asset = try_get_asset(game_file_loader.game_bundle(), path)
    if asset is None:
        abort(404, description=f"Asset could not be resolved: {path}")
    return asset


def _render(allowed_extensions, as_attachment: bool = False):
    asset = _resolve_asset()

    from assetripper_export_modules.registration import register_default_exporters

    game_bundle = game_file_loader.game_bundle()
    export_version = game_bundle.get_max_unity_version()
    result = render_asset(
        game_bundle, asset, export_version, register_default_exporters, game_file_loader.settings()
    )
    if result is None:
        abort(404, description="No exporter can render this asset.")
    data, extension = result
    if allowed_extensions is not None and extension.lower() not in allowed_extensions:
        abort(404, description=f"Asset exports as .{extension}, not a format this endpoint serves.")

    response = Response(data, mimetype=mime_type_for_extension(extension))
    if as_attachment:
        file_name = f"{asset.get_best_name() or asset.class_name}.{extension}"
        response.headers["Content-Disposition"] = f"attachment; filename={file_name}"
    return response


@bp.get("/Image")
def image():
    return _render(IMAGE_EXTENSIONS)


@bp.get("/Text")
def text():
    return _render(TEXT_EXTENSIONS)


@bp.get("/Yaml")
def yaml():
    return _render(YAML_EXTENSIONS)


@bp.get("/Binary")
def binary():
    return _render(None, as_attachment=True)


@bp.get("/Json")
def json_document():
    """Port of AssetAPI.GetJson: the asset's decoded fields, losslessly. Unlike /Image, /Text and
    /Yaml this does not go through an exporter at all -- it walks the asset directly, so it works
    for every asset whose fields resolved, including ones no content exporter handles."""
    asset = _resolve_asset()
    from assetripper_export_unity_projects.json_walker import export_json

    try:
        text_document = export_json(asset)
    except Exception as ex:  # noqa: BLE001 -- a raw/unreadable asset has nothing to walk
        abort(404, description=f"Asset cannot be rendered as JSON: {ex!r}")
    return Response(text_document, mimetype="application/json")
