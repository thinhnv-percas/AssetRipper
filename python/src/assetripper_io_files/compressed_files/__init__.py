"""Port of Source/AssetRipper.IO.Files/CompressedFiles.

Container files whose entire content is one compressed blob, wrapping a single
`ResourceFile` once decompressed (as opposed to `bundle_files`, where the compression is
per-block inside an archive with many entries). Used for Unity WebGL's `.data.gz`/
`.data.br`/`.unityweb`-with-`Content-Encoding` style delivery, and for pre-5.0 WebPlayer
`.unity3d` bundles that were themselves gzip- or brotli-wrapped on top of the Raw/Web
bundle format (see `..bundle_files.raw_web`).
"""
