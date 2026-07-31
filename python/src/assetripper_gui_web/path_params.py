"""Shared helper for routes that take a Path/Query-style query-string parameter
holding a JSON-encoded Paths.* value, mirroring the `TryGetXFromQuery` pattern
repeated in AssetRipper.GUI.Web's *API.cs files."""
from __future__ import annotations

from flask import abort, request


def get_path_param(path_cls, param_name: str = "Path"):
    """Reads and parses the `param_name` query parameter as `path_cls.from_json(...)`.
    Aborts the request with 404 if the parameter is missing or malformed, matching the
    C# `Results.NotFound(...)` behavior in the *API TryGetXFromQuery helpers."""
    json_text = request.args.get(param_name)
    if not json_text:
        abort(404, description="The path must be included in the request.")
    try:
        return path_cls.from_json(json_text)
    except Exception as ex:  # noqa: BLE001 -- mirrors the C# catch-all around FromJson
        abort(404, description=str(ex))
