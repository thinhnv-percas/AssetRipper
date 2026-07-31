"""Port of Source/AssetRipper.SourceGenerated.Extensions/{StreamedResourceExtensions,
StreamingInfoExtensions}.cs

Closes the gap that made every real Unity player build export almost nothing: Texture2D
(`m_StreamData`), Mesh (`m_StreamData`), and AudioClip (`m_Resource`) all keep their actual
payload bytes in an external `.resS` resource file rather than inline, and the exporters
previously declined whenever that field was empty rather than resolving the reference.

Two distinct struct shapes point at the same kind of external data, matching upstream's own
two extension classes:
- `StreamingInfo` (Texture2D/Mesh's `m_StreamData`): fields `path`, `offset`, `size` (no
  `m_` prefix). `offset` is a 32-bit field before Unity 2020 and 64-bit from 2020 onward in
  the real serialized layout (`Has_Offset_UInt64()` in StreamingInfoExtensions.cs) -- this
  doesn't matter here since Python ints have no fixed width; whichever value the dynamic
  reader already decoded is used as-is.
- `StreamedResource` (AudioClip's `m_Resource`): fields `m_Source`, `m_Offset`, `m_Size`
  (with the `m_` prefix -- a real, if inconsistent, difference between the two structs in
  Unity's own serialization).

Both field-name sets are reconstructed (not vendored -- SourceGenerated isn't in this repo),
cross-checked against multiple independent public Unity-asset tools that agree on this exact
split, so confidence is high but not verified the way e.g. the shader templates are.
"""
from __future__ import annotations

_INT64_MAX = 2**63 - 1


def get_content(path: "str | None", offset: int, size: int, collection) -> "bytes | None":
    """Resolves `path` to a ResourceFile in `collection`'s bundle hierarchy (or its
    ancestors, via Bundle.resolve_resource) and reads `size` bytes starting at `offset`.
    Returns None if the path is empty, the numbers overflow a signed 64-bit range (matching
    upstream's own overflow guard), the resource can't be resolved, or it's shorter than
    `offset + size`."""
    if not path:
        return None
    if offset > _INT64_MAX or size > _INT64_MAX or offset + size > _INT64_MAX:
        return None
    if size == 0:
        # Data might be read by its type for this version, so we can't even export raw data.
        return None

    resource = collection.bundle.resolve_resource(path)
    if resource is None:
        return None

    data = resource.to_byte_array()
    if len(data) < offset + size:
        return None

    return data[offset:offset + size]


def check_integrity(path: "str | None", offset: int, size: int, collection) -> bool:
    if not path:
        return True
    if offset > _INT64_MAX or size > _INT64_MAX or offset + size > _INT64_MAX:
        return False
    if size == 0:
        return False

    resource = collection.bundle.resolve_resource(path)
    if resource is None:
        return False

    return len(resource.to_byte_array()) >= offset + size


def get_streaming_info_content(streaming_info, collection) -> bytes:
    """`m_StreamData` (Texture2D, Mesh): `{path, offset, size}`."""
    path = streaming_info.get("path")
    offset = streaming_info.get("offset") or 0
    size = streaming_info.get("size") or 0
    return get_content(path, offset, size, collection) or b""


def get_streamed_resource_content(streamed_resource, collection) -> bytes:
    """`m_Resource` (AudioClip): `{m_Source, m_Offset, m_Size}`."""
    path = streamed_resource.get("m_Source")
    offset = streamed_resource.get("m_Offset") or 0
    size = streamed_resource.get("m_Size") or 0
    return get_content(path, offset, size, collection) or b""
