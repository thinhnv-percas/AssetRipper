"""Python port of Source/AssetRipper.IO.Files/BundleFiles/FileStream -- the "UnityFS"
bundle format (the modern AssetBundle container)."""
from .blocks_info import BlocksInfo
from .bundle_file_block_reader import decompress_blocks, read_entry
from .file_stream_bundle_file import FileStreamBundleFile
from .file_stream_bundle_header import FileStreamBundleHeader
from .file_stream_bundle_scheme import FileStreamBundleScheme
from .file_stream_node import FileStreamNode
from .node_flags import NodeFlags
from .storage_block import StorageBlock
from .storage_block_flags import StorageBlockFlags

__all__ = [
    "BlocksInfo",
    "StorageBlock",
    "StorageBlockFlags",
    "NodeFlags",
    "FileStreamNode",
    "FileStreamBundleHeader",
    "FileStreamBundleFile",
    "FileStreamBundleScheme",
    "decompress_blocks",
    "read_entry",
]
