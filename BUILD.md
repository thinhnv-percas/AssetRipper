# Build notes

Raw dnSpy/ILSpy decompiler output does not compile as-is. This documents what
was changed to make `Decompiled.sln` build and the tools run.

## Build

```
dotnet build Decompiled.sln
```

Requires the .NET SDK plus .NET Framework 4.7.2 targeting packs (VS 2019 or the
`Microsoft.NETFramework.ReferenceAssemblies` packages). 37 projects, 0 errors.

Unity-side projects resolve the editor assemblies through `Directory.Build.props`:

```
dotnet build Decompiled.sln /p:UnityManagedDir="C:\Program Files\Unity\Hub\Editor\<version>\Editor\Data\Managed"
```

## What runs

| Executable | Notes |
|---|---|
| `dnSpy.Console/bin/Debug/net471/dnSpy.Console.exe` | dnSpy CLI decompiler. Working. |
| `DecompilerFi/bin/Debug/net472/DecompilerFi.exe` | ILSpy CLI decompiler (`ilspycmd`). Working. |
| `DevXUnityUnpackerRun/bin/Debug/net40/DevXUnityUnpackerRun.exe` | Builds, but only a loader stub — see below. |

`DevXUnityUnpackerRun` reads a file named `0000000000` next to the exe,
XOR-decrypts + gunzips it, and invokes its entry point. That payload is the
actual application and is **not** part of this decompile, so the exe prints
"Error on start". Nothing in the source can fix that; the payload has to be
present at runtime.

## Changes made

### Project structure
* Removed **81 BCL facade projects** (`System.Runtime`, `System.Collections`,
  `netstandard`, ...). They contained only `[assembly: TypeForwardedTo]` and
  shadowed the real framework assemblies, which is what caused the original
  wall of `NU1201` restore errors.
* Removed **20 decompiled BCL implementation projects** (`System.Net.Http`,
  `System.IO.Compression`, `System.Diagnostics.Tracing`, ...). They duplicate
  .NET Framework 4.7.2 built-ins and nothing referenced them.
* Replaced decompiled `System.Reflection.Metadata` / `System.Collections.Immutable`
  with the matching official NuGet packages (1.6.0 / 1.5.0 — the versions the
  decompiled `AssemblyInfo` recorded).
* Removed `dnSpy.Decompiler.ILSpy.x`: it needs `dnSpy.Contracts.DnSpy` (the GUI
  contracts assembly), which was never decompiled. Restore that assembly first
  if you need the dnSpy GUI plugin.
* `dnSpy.Console` now references `dnSpy.Decompiler.ILSpy.Core` so the plugin it
  loads reflectively at runtime lands in the output folder. Without it the tool
  builds but fails with "No languages were found".
* Unified target frameworks (net472 for the .NET Framework chain,
  netstandard2.0 for the portable libraries).

### Source fixes (decompiler artifacts)
* `base._002Ector(args);` → constructor initializer `: base(args)`.
* `((Rect)(ref v)).Member` → `v.Member` (41 sites in the Unity projects).
* `Enumerator<T> e = x.GetEnumerator();` → `var e = ...`.
* `switch (enumValue - N)` → `switch ((int)enumValue - N)` (enum arithmetic
  yields the enum type, so int cases don't match).
* Get-only auto-properties assigned in constructors → assign the emitted
  `_003CName_003Ek__BackingField` instead.
* `.TryGetValue(k, ref v)` → `out v`.
* `GUIStyle.op_Implicit(x)` → `(GUIStyle)(x)`.
* Named arguments carrying the original obfuscated parameter names → positional.
* Property setters whose implicit `value` parameter was renamed (`text`,
  `array`, `obj`, `num`, ...) → `value`.
* `Expression` ambiguity in `DecompilerPreFi`: import
  `using ExpressionType = System.Linq.Expressions.ExpressionType;` rather than
  the whole `System.Linq.Expressions` namespace (matches upstream ILSpy).
* Unity ambiguities: `Debug`/`Object`/`Random` qualified; nested types
  (`MultiColumnHeaderState.Column`, `Undo.UndoRedoCallback`, ...) qualified;
  `((TreeView)this).ProtectedMember` → `this.ProtectedMember`.
* Stripped `PublicKey=` from `InternalsVisibleTo` — the satellite assemblies
  (`Mono.Cecil.Mdb/Pdb/Rocks`) can't be re-signed with the original private key,
  so friend access has to be granted to unsigned assemblies.
* `DecompilerFi/app.config`: dropped the binding redirects hand-copied from the
  original build (they pinned facades that are no longer shipped and broke
  `System.ValueTuple` loading). `AutoGenerateBindingRedirects` now generates them.

## The `0000000000` payload format

`DevXUnityUnpackerRun` is a loader, and `Memrestore` in
[Program.cs](DevXUnityUnpackerRun/Program.cs) fully specifies the container
format. There is no key material and no per-file state, so it is reversible
from the source alone.

```
file 0000000000  --XOR keystream-->  GZip stream  --gunzip-->  .NET assembly
                                                               Assembly.Load(..).EntryPoint.Invoke()
```

The keystream is `num2 + num3` where `num2` starts at 10 stepping by 13 and
`num3` starts at 1 stepping by 1317, so at index `i` it is `11 + 1330*i`.
Since `1330 % 256 == 50` that collapses to

```
key[i] = (11 + 50*i) & 0xFF
```

a fixed pattern with period 128 (gcd(50,256)=2, so only 128 of the 256 byte
values ever appear). It is a plain obfuscation layer, not encryption.

Because gzip always starts `1F 8B 08 00`, a correctly packed file always
starts with those bytes XORed against `0B 3D 6F A1`:

```
magic: 14 B6 67 A1
```

which is a cheap way to recognise the format.

### tools/payload.py

```
python tools/payload.py info   0000000000              # identify + PE/CLI header summary
python tools/payload.py unpack 0000000000 payload.dll  # recover the assembly
python tools/payload.py pack   payload.dll 0000000000  # inverse (both steps are symmetric)
```

Verified, not just derived: `pack` output was fed to a harness running
`Memrestore`/`DeCompess`/`Copy` copied verbatim from `Program.cs`, and the
result was byte-identical to the input assembly, with `Assembly.Load` then
resolving it and reporting a valid entry point.

### Caveats
* The payload is **not in this folder** — nothing here can reconstruct it. You
  need the file from an actual installation.
* Recovering it only undoes the packing. The DevX code in this repo is heavily
  obfuscated (identifiers like `_0020_0020_000A_...`), so expect the payload
  assembly to be obfuscated too — a decompiler gets you compilable-ish source,
  not readable source.
* `Memrestore` calls `Application.Exit()` in the middle of the loop. With no
  message loop running it is a no-op; it appears to be leftover or noise.

## Known limitations
* Assemblies are **unsigned**. Anything that checks strong names at runtime will
  behave differently from the originals.
* `DevXUnityScriptManager` was originally built against a much older Unity. It
  now compiles against Unity 2022.3, but the API adaptation was done to satisfy
  the compiler — the editor UI is not functionally verified.
* 605 build warnings remain (mostly unused fields from obfuscated code).
