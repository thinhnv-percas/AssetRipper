# IL2Cpp runtime struct layouts

370 Unity versions, **5.1.0f3 → 6000.3.18f1**, two files each — `<version>-x32.json.gz` and
`<version>-x64.json.gz` — plus a plain-text `index.json` listing coverage.

Each file gives, for one Unity release and one pointer size, the `sizeof` of every C struct in the
IL2Cpp runtime and every field's offset, type and bit width. This is what turns
`ldr x8, [x0, #0x18]` in a recovered method body from "read 8 bytes at +0x18" into
`methodInfo->klass`.

See [docs/articles/Il2CppScriptRecovery.md](../docs/articles/Il2CppScriptRecovery.md) for how
AssetRipper uses this, and for the full field schema.

## Storage

The layouts are gzipped: 62 MB of JSON becomes 6.4 MB, and a typical file goes from 89 KB to 8 KB.
`StructDbCatalog` sniffs the gzip magic rather than trusting the extension, so an uncompressed
`<version>-x64.json` dropped in beside them is read just the same. To read one by hand:

```
gzip -dc StructDb/2019.4.0f1-x64.json.gz | python3 -m json.tool | less
```

`index.json` is left uncompressed so coverage can be read and diffed without unpacking anything.

## Provenance

| Source | Versions | Range |
|---|---|---|
| `dvxil2c` | 368 | 5.1.0f3 → 2021.2.9f1 |
| `clang` | 2 | 2022.3.62f2 (metadata v31), 6000.3.18f1 (metadata v39) |

Every number describes Unity's own runtime, and none was guessed: Unity ships the whole
`libil2cpp` source with each Editor, and the layouts are read out of those headers by compiling
them. The two `clang` files were generated that way directly; the 368 `dvxil2c` files were decoded
from a third-party tool's data files, and the same procedure regenerates any of them given the
matching Editor install. The `source` field in each file and in `index.json` records which.

Struct counts grow with Unity: 25 structs in 5.1, 74 by 2021.2, 90 in 6000.3.

## Gotchas, all of them load-bearing

**A trailing zero-length array sits at `sizeof`, not inside it.** `Il2CppClass.vtable` is
`VirtualInvokeData[0]` at `offset == sizeof(Il2CppClass)` with `size: 0`; `Il2CppString.chars` is
the same shape. These are C flexible array members (`IL2CPP_ZERO_LEN_ARRAY`, which appears in
`defines`), and `sizeof` excludes them by definition. Element *i* lives at
`base + offset + i * arrayItemSize`. Any check that treats `sizeof` as an upper bound reports ~690
false errors across this set and, worse, makes the vtable unreachable.

**`arrayItemSize` identifies a type; it is not always the stride.** Use
`structs[<name>].size` when stepping through an array of structs.

**Unions are flattened.** Members of a union carry `"union": true` and several share one `offset` —
`Il2CppType` has eight different fields at `offset: 0`. Resolving a read to one of them needs
context (usually the `type` field), so a resolver either picks the first declared member or hands
back candidates.

**`Il2CppObject` is absent from the 368 `dvxil2c` files.** That tool only stored the structs it
used. Its shape has never changed — a class pointer, then the monitor pointer — and
`RuntimeStructAccessAnnotator` falls back to that when the struct is missing.

**A version not in the set falls back to the newest version at or below it**, and the substitution
is logged with both version numbers. Layouts only change going forward, so that is the safest
approximation; a silent fallback would produce confidently wrong field names.

## Checking the set

```
dotnet run --project Source/AssetRipper.Tools.Il2CppStructDbValidator -- StructDb
```

The invariant sweep reads every file and checks that offsets are non-negative and monotonic, that
non-flexible fields fit inside `sizeof`, that pointers are exactly one machine word wide, that
bitfields fit their storage unit, and that a zero-length array is the last member of its struct.
Exit code is 0 when everything passes.
