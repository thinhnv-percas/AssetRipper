"""Port of Source/AssetRipper.IO.Files/WebFiles.

`WebFile` is the "UnityWebData1.0" archive container WebGL builds place the actual asset
files inside (typically named `<Product>.data`, itself often further gzip/brotli-wrapped --
see `..compressed_files`). Unlike the UnityFS bundle format, this is a flat, uncompressed
name/offset/size table with no per-entry compression of its own.
"""
