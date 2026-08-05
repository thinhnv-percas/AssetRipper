"""
Command-line entry point for the Python port of AssetRipper.

This is new code (not a port of any single C# file) that ties together the ported
packages into something runnable end-to-end: it reads a file, and if it's recognized as
a Unity SerializedFile (.asset/.assets/.sharedAssets), prints its header/metadata.
Other AssetRipper file formats (bundles, compressed files, resource files) aren't
supported yet -- see the deferred-scope notes for AssetRipper.IO.Files.
"""
