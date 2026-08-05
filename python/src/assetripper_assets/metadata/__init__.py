"""Python port of Source/AssetRipper.Assets/Metadata."""
from .asset_info import AssetInfo
from .i_pptr import IPPtr
from .null_pptr import NullPPtr
from .pptr import PPtr

__all__ = ["AssetInfo", "IPPtr", "PPtr", "NullPPtr"]
