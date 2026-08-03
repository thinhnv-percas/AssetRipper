"""
Phase 16c: a from-scratch ECMA-335 (.NET metadata) reader for Mono `Managed/*.dll` assemblies.

No upstream C# file to port -- upstream reads assemblies with AsmResolver (an external NuGet
package, not vendored in this repo; see ROADMAP.md Phase 16 "Không có gì để port"). This
package implements the public ECMA-335 spec (6th edition, Partition II) directly: PE/COFF
headers -> CLI header -> metadata root -> heaps (#Strings/#US/#GUID/#Blob) -> the compressed
`#~` tables stream -> the subset of tables needed to recover type/field declarations.

Layered bottom-up, each module independently testable against hand-built byte fixtures (no
.NET SDK is available in this environment to compile a real reference `.dll` -- see
tests/import_/dotnet_metadata/_module_builder.py):

- `compressed_integer.py`: ECMA-335 II.23.2 compressed integer encoding, used for blob-heap
  entry lengths and inside signature blobs.
- `pe_image.py`: DOS/COFF/optional headers, section table, RVA->file-offset mapping, and
  locating the CLI header (Cor20Header) and metadata root from those.
- `heaps.py`: the four heap kinds (#Strings, #US, #GUID, #Blob) as random-access-by-index
  readers over the metadata root's bytes.
- `table_ids.py`: `TableId`, the declarative column layout for all 38 possible tables, and the
  coded-index tag tables (ECMA-335 II.24.2.6) -- the data this whole reader is built around.
- `tables_stream.py`: parses the `#~`/`#-` stream header (heap-size flags, Valid/Sorted
  bitmasks, per-table row counts) and decodes every present table's rows using `table_ids`'s
  column layout, with correctly-sized heap/table/coded-index columns.
- `signature.py`: decodes a field signature blob (II.23.2.4) into display-ready C# type text,
  resolving TypeDefOrRef-encoded class/valuetype references and generic instantiations.
- `metadata_reader.py`: the facade tying all of the above together --
  `DotNetMetadataReader.read(data: bytes)` -- exposing typed row access and the two coded-index
  resolvers (`TypeDefOrRef`, `HasCustomAttribute`) callers actually need.

`assetripper_import.structure.assembly.managers.mono_manager` is the consumer: it walks
`TypeDef` rows from here and produces `RecoveredType`/`RecoveredField`
(`..recovered_model`) instances for `assetripper_export_modules.scripts.csharp_emitter` (16b)
to render as `.cs` text.
"""
