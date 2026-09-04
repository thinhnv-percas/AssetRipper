# IL2Cpp Script Recovery

IL2Cpp compiles a game's C# to machine code and throws the IL away, so a ripped IL2Cpp project
normally gets class skeletons with empty method bodies. `ScriptContentLevel.Level3` turns on
recovery: Cpp2IL lifts each method's native code to its instruction-set-independent form (ISIL),
converts what it can to CIL, and ILSpy decompiles that back to C#.

The honest ceiling, so nobody expects otherwise: **class skeletons are exact, and method bodies
are readable rather than recompilable.**

## Which binaries bodies can be recovered from

Recovery needs a lifter from native code to ISIL, and Cpp2IL does not have one for every
architecture:

| Binary | Bodies |
|---|---|
| x86, x86-64 | recovered |
| ARM64 (`arm64-v8a`, Apple silicon) | recovered |
| ARMv7 (`armeabi-v7a`) | **not possible** — no ISIL lifter exists |
| WebAssembly (WebGL) | **not possible** — no ISIL lifter exists |

Cpp2IL ships two ARM64 implementations and only the newer one lifts to ISIL; the older one returns
an empty instruction list for every method, which reads in the output as a game whose every method
is empty. `Arm64InstructionSetSelector` picks the lifting one for Level 3 and leaves every other
level on the implementation it has always used. On a binary that cannot be recovered the import logs
a warning saying so, rather than producing empty bodies without comment, and the import also reports
how many methods recovery attempted and how many failed to convert.

## Turning it on

Set **Script Content Level** to **Level 3** on the Settings page. The **IL2Cpp Script Recovery**
section below it holds three options, all of which are ignored at every other level.

| Setting | Default | Effect |
|---|---|---|
| Emit IL2Cpp offsets and addresses | on | Adds `[FieldOffset]`, `[Address]` and `[Token]` attributes to the exported scripts, so each field carries its offset within the object and each method its RVA, file offset and length. |
| Reconstruct unrecovered method bodies | off | Attaches an approximate C# reconstruction, as a `[NativeSource]` attribute, to methods IL recovery could not express. Reads as C#; does not compile. Slow — it analyses every method in the game's own assemblies. |
| IL2Cpp struct database | empty | Directory of runtime struct layout files. Empty means the bundled set is used. See below. |

Nothing here changes script identity: `.cs.meta` GUIDs, and the `m_Script` GUID references inside
exported scenes and prefabs, come from assembly and type names, not from method bodies. An export at
Level 3 is drop-in comparable with one at Level 2.

## Diagnosing empty method bodies

Empty bodies are the failure mode all the others collapse into, and the exported scripts look the
same whichever cause it was. On Windows, `BUILD-AND-RUN.bat` in the repository root builds, deletes
the previous log, starts AssetRipper with a fixed log path, and on exit writes
`AssetRipper-recovery.log` containing just the relevant lines:

```
BUILD-AND-RUN.bat                 Debug build, random port
BUILD-AND-RUN.bat Release         Release build
BUILD-AND-RUN.bat Debug 17845     Debug build on a fixed port
```

What to read in it, in order:

| Line | What it settles |
|---|---|
| `ScriptContentLevel: Level3` | Recovery is on at all. Any other value and nothing below runs. |
| `Il2Cpp recovery installed: ... struct database <path>` | Whether the bundled layouts were found. `not found` means raw offsets instead of runtime field names, nothing worse. |
| `Il2Cpp recovery: Unity ..., metadata v..., 64-bit, instruction set ...` | The binary in hand. The instruction set is what decides whether bodies are possible at all. |
| `Il2Cpp recovery: N assemblies will be attempted ... Attempted: ...` | Which assemblies to open. Framework assemblies are stubbed by design, so empty bodies in `UnityEngine.*` are expected and say nothing about the run. |
| `Il2Cpp recovery: sampled N methods — L lifted to ISIL, E produced none, ...` | The decisive measurement. `L` of zero means the lifting stage is the problem, not the export. |
| `Il2Cpp method body recovery attempted N methods; M failed to convert` | Whether recovery reached the game's code. Zero attempted means it never did. |
| `Il2Cpp method body recovery failure (N methods): <reason>` | The distinct reasons conversion threw, most common first. |

The last one exists because Cpp2IL reports these per method through its own warning channel, which
AssetRipper maps to verbose logging and then discards. Rather than turn that flood on, the reason is
read back out of the `throw` the failed body carries and reported as counts.

## The struct database

A recovered method body is full of reads through the IL2Cpp runtime's own C structs. Without a
layout, `ldr x8, [x0, #0x18]` is "read 8 bytes at +0x18". With one, it is `methodInfo->klass`.

**AssetRipper ships one.** [StructDb/](../../StructDb) holds 370 Unity versions, 5.1.0f3 through
6000.3.18f1, and the build copies it to `<application directory>/structdb`, where it is found with no
configuration. The Settings page reports what was detected.

The database is a directory of JSON files, two per Unity version:

```
structdb/
├── index.json
├── 2019.4.0f1-x64.json.gz   # gzipped in the repo; the loader sniffs the magic
├── 2019.4.0f1-x32.json.gz   # so a plain .json works just as well
└── ...
```

Each file gives, for one Unity version and one pointer size, the `sizeof` of every struct in
`libil2cpp` and every field's offset, type and bit width. The numbers describe Unity's own runtime
and are read out of the `libil2cpp` headers Unity ships with every Editor — none of them is guessed.

**It stays optional.** With no database, every code path falls back to unnamed offsets, which is the
behaviour without any of this. With one, three things improve:

1. Memory accesses in reconstructed bodies get runtime field names.
2. Cpp2IL's `Il2CppClass` offset table, which ships two Unity versions' worth of 64-bit constants
   and nothing at all for 32-bit, is answered from measured per-version layouts instead. This
   affects static-field, interface-offset and element-type recognition on every 32-bit IL2Cpp game.
3. Object headers are named rather than assumed.

### Where it is looked for

The path in Settings wins; a `structdb` subdirectory of that path is accepted too. Otherwise, in
order:

1. `$ASSETRIPPER_IL2CPP_STRUCTDB`
2. `<application directory>/structdb`
3. `<application directory>/StreamingAssets/structdb`
4. `<executable directory>/structdb`
5. `%APPDATA%/AssetRipper/structdb` (`~/.config/AssetRipper/structdb` on Linux and macOS)

A version that is not in the database falls back to **the newest version at or below it** — layouts
only change going forward, so that is the safest approximation — and the fallback is logged with
both version numbers. It is never silent, because a wrong layout produces confidently wrong field
names, which is worse than no field names at all.

Only versions that have *both* widths are offered. A 32-bit game must not silently get 64-bit
offsets.

### Checking it

```
dotnet run --project Source/AssetRipper.Tools.Il2CppStructDbValidator -- StructDb
```

Reads every file and checks the invariants a correct layout must satisfy — offsets non-negative and
monotonic, fields inside `sizeof`, pointers exactly one machine word, bitfields within their storage
unit, a zero-length array last in its struct. Exit code 0 when everything passes. It also answers
offset questions directly, which is the quickest way to see what the recovery layer will name
something:

```
$ ... -- StructDb --no-sweep --version 2019.4.0f1 --offset 0x158
2019.4.0f1 x64 (exact)
  sizeof(Il2CppClass)    304
  Il2CppClass.vtable     0x130 (slot size 16)
  Il2CppClass+0x158 = vtable[2].method (MethodInfo*) -> MethodInfo
```

### Adding a version

Install that Unity Editor and read the layouts out of
`Editor/Data/il2cpp/libil2cpp` with clang's `-Xclang -fdump-record-layouts`, writing one JSON file
per pointer size in the schema below. Unity ships the whole IL2Cpp runtime source with every
Editor, which is why no layout has to be reverse engineered.

```jsonc
{
  "schema": 1,
  "unityVersion": "2019.4.0f1",
  "pointerSize": 8,                 // 4 for -x32.json, 8 for -x64.json
  "metadataVersion": 31,            // optional
  "source": { "origin": "...", "file": "...", "tool": "...", "target": "..." },
  "structs": {
    "Il2CppClass": {
      "size": 304,                  // sizeof
      "pack": 0,                    // only when non-default
      "union": false,               // only when true
      "fields": [
        { "name": "image", "type": "Il2CppImage*", "offset": 0, "size": 8, "arrayItemSize": 80 },
        { "name": "byval_arg", "type": "Il2CppType", "offset": 32, "size": 12 },
        { "name": "valuetype", "type": "uint8_t", "offset": 302,
          "bits": 1, "bitOffset": 1, "bitOrdinal": 1 }
      ]
    }
  },
  "enums":    { "Il2CppTypeEnum": "IL2CPP_TYPE_END=0x00,IL2CPP_TYPE_VOID=0x01" },
  "defines":  { "TypeIndex": "int32_t" },
  "typedefs": { }
}
```

| Key | Present when | Meaning |
|---|---|---|
| `name`, `type`, `offset` | always | as in C; `offset` is in bytes from the start of the struct |
| `size` | non-bitfield | width in bytes |
| `realType` | it differs from `type` | `type` after typedef resolution |
| `arrayItemSize` | pointer or array field | `sizeof` of the pointee, so a resolver can step through a pointer without a second lookup |
| `bits`, `bitOffset` | bitfield | width in bits, and bit position within the storage unit. `bitOffset` is the one to use |
| `bitOrdinal` | bitfield | declaration index, kept for provenance. It is an ordinal, not a bit position |
| `union` | true | this member overlaps its neighbours |

## What is implemented where

| Piece | Location |
|---|---|
| Layout file model, catalog, offset resolver, disk lookup | `AssetRipper.Import/Structure/Assembly/Il2Cpp/StructDb/` |
| The bundled layouts, and their provenance | [`StructDb/`](../../StructDb) |
| Validating a database without opening a game | `AssetRipper.Tools.Il2CppStructDbValidator` |
| `Il2CppClass` offset questions answered from data | `Recovery/StructDbClassOffsets.cs`, `Recovery/Il2CppClassOffsetPatcher.cs` |
| Loading the layout for the game's version | `Recovery/StructDbProcessingLayer.cs` |
| Naming memory accesses in a method's ISIL | `Recovery/RuntimeStructAccessAnnotator.cs` |
| Rendering ISIL as approximate C# | `Recovery/PseudoCSharpWriter.cs` |
| Attaching that text so it survives into ILSpy's output | `Recovery/NativeSourceInjectionProcessingLayer.cs` |
| Choosing an ARM64 implementation that can lift to ISIL | `Recovery/Arm64InstructionSetSelector.cs` |
| Reporting whether this binary can be recovered at all | `Recovery/Il2CppRecoveryDiagnosticsProcessingLayer.cs` |
| IL recovery plus per-run counters | `Recovery/Il2CppIlRecoveryOutputFormat.cs` |
| Installing all of it into `IL2CppManager` | `Recovery/Il2CppRecoverySetup.cs` |

Metadata parsing, binary identification, registration search, dummy assembly generation, the
method address table, string literals and helper-function naming are all Cpp2IL's, and are not
duplicated here.

## Known limits

* ARMv7 and WebAssembly cannot produce method bodies at all, as above.
* At Level 3 the whole import uses the ISIL-capable ARM64 implementation, including for reading raw
  method bytes, where it is stricter about address ranges than the older one. That is the trade for
  getting bodies; lower levels are unaffected.
* `Il2CppClassUsefulOffsets.GetVtableOffset` is a method in Cpp2IL rather than data, so the vtable
  bound used by `IsPointerIntoVtable` cannot be corrected from a layout file. The named-offset
  lookups around it can be, and are.
* The access annotator is a linear forward walk, not a dataflow analysis. It does not merge types
  across branches, and drops a type rather than guess one.
* Reconstruction is bounded three ways — per-method machine-code size, statements per method, and a
  total character budget across the run. User strings live in the `#US` heap, which is addressed by
  24-bit offsets, so an unbounded dump produces an assembly that cannot be written at all.
* The 32-bit `Il2CppClass` improvements need a layout file for a version at or below the game's.
* Unions are flattened in the layout files: several members share one offset, and `Il2CppType` has
  eight fields at offset 0. The resolver returns the first declared member, since choosing between
  them needs runtime context it does not have.
