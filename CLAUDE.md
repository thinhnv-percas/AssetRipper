# Working in this repository

## Building and testing

The SDK is not on `PATH` in a fresh container. Find it first:

```
export PATH="/tmp/dotnet-sdk:$PATH"     # or wherever `find / -name dotnet -type f` puts it
dotnet build Source/AssetRipper.GUI.Free/AssetRipper.GUI.Free.csproj -c Debug
dotnet test Source/AssetRipper.Tests/AssetRipper.Tests.csproj -c Debug
```

Building `AssetRipper.GUI.Free` builds everything the app needs. Running it:

```
dotnet run -c Debug --project Source/AssetRipper.GUI.Free/AssetRipper.GUI.Free.csproj -- --port 8642 --headless
```

`--headless` skips opening a browser. There is no `--launch-browser` flag.

**Static content is embedded.** JavaScript and CSS under `Source/AssetRipper.GUI.Web/StaticContent`
are embedded resources, so editing one has no effect until the project is rebuilt.

**Page markup is C#, not templates.** Pages are built with the fluent tag builder in
`AssetRipper.Text.Html` (`new Div(writer).WithClass(...)`), and JSON returned to the browser is
serialised by the AOT source generator, which emits **PascalCase** property names. A script reading
`entry.name` will get `undefined`; it is `entry.Name`.

## What an export actually looks like

This is the thing that is easiest to get wrong, and a fixture built from the wrong assumption will
pass while nothing works on a real game. Rip something and look before designing against the output.

**Assets are grouped by type, not by where they came from.** The output is
`Assets/Shader/…`, `Assets/Material/…`, `Assets/MonoBehaviour/…`, `Assets/Plugins/…`. A package's
folder structure is not reproduced anywhere, so nothing about a path says which package an asset
belongs to.

**Assets are named after the asset, not the original file.** A package's `Shaders/TMP_SDF.shader`
comes out as `Assets/Shader/TextMeshPro_Distance Field.shader`, named from the shader's declared name
with `/` replaced. File names cannot be matched across the two sides for shaders.

**How scripts are exported depends on `ScriptExportMode`, and the two modes produce completely
different references.** The default is `Hybrid`.

| | `Hybrid` (default) | `Decompiled` |
| --- | --- | --- |
| Predefined assemblies (`Assembly-CSharp`) | decompiled to `Assets/Scripts/<assembly>/…` | same |
| Everything else, including packages | assembly saved to `Assets/Plugins/<assembly>.dll` | decompiled to `Assets/Scripts/<assembly>/…` |
| A reference to one of its types | `{fileID: <hash of namespace and class>, guid: <the assembly's guid>}` | `{fileID: 11500000, guid: <the script's own guid>}` |

The hash is `ScriptHashing.CalculateScriptFileID`, which replicates Unity's own algorithm, so in
`Hybrid` the fileID already matches what an official package uses and **only the assembly's guid has
to change**. In `Decompiled` both halves of the reference move. Both guids are deterministic:
`CalculateScriptGuid(assembly, namespace, class)` and `CalculateAssemblyGuid(assembly)`.

Assembly definitions are written with **name** references (`"references": ["Unity.TextMeshPro"]`),
not GUID ones, so deleting a decompiled assembly's folder does not leave anything dangling: the name
resolves to whichever assembly definition now carries it, which is the package's own.

The project folder is `<chosen path>/<project name>`, and `settings.AssetsPath` is
`<chosen path>/<project name>/Assets`, not `<chosen path>/Assets`. The project name comes from what
was loaded, a file without its extension or a folder's own name, and falls back to `ExportedProject`
when several paths were loaded at once or the name sanitises away to nothing.

## What a Unity package actually looks like

The other half of the same trap. **Most packages ship source, not an assembly.**
`com.unity.textmeshpro` is 109 `.cs` files and an assembly definition, with no dll anywhere; Unity
compiles it. So a project using the real package refers to one of its types the way it refers to any
source file, as `{fileID: 11500000, guid: <the .cs file's own guid>}`.

Neither ripped shape matches that, so the mapping is per type and the type's name pairs the two sides,
Unity requiring a serialisable class to live in a file named after it. Matching code by file name
across the whole project is not safe on its own: a package file can share a name with one of the
game's own scripts, which is why only `SourcePackageScriptMapping`, which knows the assembly, pairs
code.

TextMeshPro also ships its shaders and fonts inside `Package Resources/TMP Essential Resources.unitypackage`
rather than in the package tree, so they cannot be paired from the package alone.

## Package remapping

`Source/AssetRipper.Export.UnityProjects/PackageRemapping` replaces the ripped copies of Unity
packages with the real ones. `docs/articles/PackageGuidRemapping.md` is the design; the short version:

- It runs at export time when **Official package cache** is set in the export settings, and nothing
  happens when it is empty, since the official guids are not part of the game.
- Only a guid written **inside a reference** is rewritten. A bare `guid:` line is an asset's own
  identity, and rewriting one would give the official package's identity to a file that is still the
  ripped copy.
- `AssetRipper.PackageRemapping.json`, beside the settings file, is written after every run with what
  was worked out, and is where to override it.
- `AuxiliaryFiles/PackageRemapping.txt` is the per package account of a run.

## Il2Cpp method recovery

`Source/AssetRipper.Import/Structure/Assembly/Recovery` recovers method bodies through Cpp2IL and,
at `ScriptContentLevel.Level4`, through Ghidra. `docs/articles/Il2CppMethodRecovery.md` is the design.

**A wrong prototype is much worse than none.** Ghidra locks parameter storage to whatever it is told,
so a mismatched return type can reduce a whole function body to a single return of an uninitialised
register. Everything whose size is not certain is refused rather than guessed at.

Two metadata traps, both measured on a shipped game:

- `Il2CppTypeDefinition.Size` is the **marshalled** size, not the managed one. It is absent for many
  value types and wrong for others: `System.Char` marshals to one byte but occupies two. The managed
  size is `RawSizes.instance_size` less the object header, which is two pointers.
- Metadata carries **no layout at all for generic types**: a generic definition reports an instance
  size of zero and every field offset as zero, and a constructed instance carries no fields. Those stay
  refused for now, but the reason is not that the layout is unknowable — see below.

A field offset is counted from the start of the object, so a class's struct has to carry its inherited
fields as well as its own or every read of one decompiles as arithmetic. Reference type parameters are
typed by the struct they point at, which is free because a pointer is a pointer whatever it addresses.

Unity ships the `libil2cpp` runtime source in the editor installer, and
[MlgmXyysd/libil2cpp](https://github.com/MlgmXyysd/libil2cpp) collects it per Unity version. **It has no
license and the code is Unity's, so nothing may be copied from it into this GPL-3.0 project**; use it to
check facts against the binary, the way a specification is used. What it settles: `metadata/FieldLayout.cpp`
is the exact layout algorithm, and `vm/Class.cpp` shows a generic instance inflating its definition's
fields and running that same algorithm at runtime rather than reading a stored layout. It also explains
raw offsets in decompiled output — `offsetof(Il2CppClass, static_fields)` is 0xb8 on 64 bit, which is
what a doubly dereferenced `PTR_DAT_… + 0xb8` is. Version drift is real and the collection stops at Unity
6000.0.5f1 with metadata version 29, short of the metadata 31 that later 2022.3 patches ship.

## Conventions

Comments explain why, not what, and are written as prose. Match the density and idiom of the file
being edited. Measurements quoted in documentation and commit messages are expected to have been
taken, not estimated.
