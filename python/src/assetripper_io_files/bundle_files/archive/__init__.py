"""Port of Source/AssetRipper.IO.Files/BundleFiles/Archive.

Upstream itself only recognizes this format's signature -- `ArchiveBundleFile.Read`/`Write`
both `throw new NotSupportedException()` there too (see the C# file's own README.md:
"I'm not certain that UnityArchive files exist, but code inherited from uTinyRipper
indicated that they do exist."). Ported at the same fidelity: the scheme detects the
`"UnityArchive"` signature so discovery doesn't silently misclassify one of these as
something else, but reading one raises, exactly like upstream.
"""
