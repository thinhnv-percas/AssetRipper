# Build notes

Raw decompiler output does not compile as-is. This documents what was changed to
make everything here build, and how to reproduce it.

For what the shipped files actually *are* — the container formats, the cipher,
the obfuscation, and the decompiler defects behind most of these fixes — see
[FINDINGS.md](FINDINGS.md).

---

## Building

### The root solution

```
dotnet build Decompiled.sln
```

37 projects, 0 errors. Needs the .NET SDK plus .NET Framework 4.7.2 targeting
packs (VS 2019, or the `Microsoft.NETFramework.ReferenceAssemblies` packages).

The Unity-side projects resolve editor assemblies through
`Directory.Build.props`:

```
dotnet build Decompiled.sln /p:UnityManagedDir="C:\Program Files\Unity\Hub\Editor\<version>\Editor\Data\Managed"
```

### The recovered assemblies

`Recovered/_assemblies/` holds the eight assemblies unpacked from the loader
payload and the sidecar files; each was decompiled back to a project beside it.

```
dotnet build Recovered/<Name>/<Name>.csproj
```

| project | errors before | after |
|---|---|---|
| Mono.Cecil | 8 | **0** |
| DevX.Cecil | 160 | **0** |
| NAudio | 8 | **0** |
| ICSharpCode.NRefactory | 140 | **0** |
| ICSharpCode.NRefactory.CSharp | 294 | **0** |
| ICSharpCode.Decompiler | 562 | **0** |
| DevXUnityUnpackerMain | 4034 | **0** |
| DevXUnityUnpackerTools | ~4000 | 407 |

`DevXUnityUnpackerTools` is the one that does not finish, because the decompiler
emits only 10009 of its 10347 top-level types. See
[FINDINGS.md §6](FINDINGS.md).

---

## What runs

| Executable | Notes |
|---|---|
| `dnSpy.Console/bin/Debug/net471/dnSpy.Console.exe` | dnSpy CLI decompiler. Working — decompiles a DLL to a project. |
| `DecompilerFi/bin/Debug/net472/DecompilerFi.exe` | ILSpy CLI decompiler (`ilspycmd`). Working. |
| `DevXUnityUnpackerRun/bin/Debug/net40/DevXUnityUnpackerRun.exe` | The loader stub. Builds. Launching it was not tested: it resolves its payload via `Application.StartupPath`, so `0000000000` and every sidecar file would have to sit next to the built exe, not in the project folder. |

---

## Reproducing a decompile

1. **Unpack** — `tools/payload.py` for `0000000000`, `tools/sidecar.py` for the
   hash-named files.
2. **Decompile** — prefer `DecompilerFi` (ILSpy). It sanitises invalid
   identifiers to `_0020_`, which compiles; dnSpy writes raw `\u0020` escapes,
   which do not. If dnSpy output must be used, run `tools/unescape_ids.py` over
   it first — it converts identifier escapes while leaving string literals,
   char literals and comments alone.
3. **Convert the projects** — `python tools/sdkify.py --all Recovered` rewrites
   the legacy `.csproj` files ILSpy and dnSpy emit (ToolsVersion 4.0, sometimes
   .NETPortable Profile344, which no longer exists on a modern machine) into
   SDK-style net472.
4. **Wire references** — neither decompiler links the assemblies it produces to
   each other. This is the single largest source of errors; see below.
5. **Repair** — `python tools/fixdecompiled.py all <dir> <build-log>`.

---

## What actually broke, and why

### Missing project references — ~4000 errors
Neither decompiler wires up inter-assembly references. Adding the missing
`ProjectReference` entries took `ICSharpCode.NRefactory.CSharp` from **3221
errors to 2**, and `ICSharpCode.Decompiler` from 965 to 2. Always do this before
reading a single compiler error.

### Anti-decompiler constructs
Legal IL with no valid C# spelling. Details and the full list in
[FINDINGS.md §5](FINDINGS.md); the repairs are:

| construct | repair |
|---|---|
| `static class` used as a parameter type (CS0721, 371 sites) | drop the `static` modifier |
| private/protected members reached across types (CS0122, 17309) | widen to `internal` |
| `<Module>` / `<PrivateImplementationDetails>` in signatures | empty stubs — `Recovered/DevXUnityUnpackerMain/_CompilerGeneratedStubs.cs` |
| a class that must be `static` and non-`static` at once | keep it non-static, re-expose the extension method from a separate host class |
| entry point named with whitespace (CS5001) | a `Program.Main` forwarder plus `<StartupObject>` |

Widening accessibility has knock-on effects worth knowing about: an `override`
may not widen access (CS0507), an extension method still needs a `static` class
(CS1106), and an accessor may not be less restrictive than its property
(CS0273). `tools/fixdecompiled.py` handles the first pass; the fallout needs a
second, error-log-driven pass.

### Decompiler defects
Each needed a hand fix. Catalogued in [FINDINGS.md §6](FINDINGS.md), including a
genuine bug in the rebuilt ILSpy itself that crashes it on large assemblies.

### Recurring textual artifacts
Handled by `tools/fixdecompiled.py textual`:

* `base._002Ector(args);` → constructor initializer `: base(args)`
* `((Rect)(ref v)).Member` → `v.Member`
* `Enumerator<T> e = x.GetEnumerator();` → `var e = ...`
* `switch (enumValue - N)` → `switch ((int)enumValue - N)` — enum arithmetic
  yields the enum type, so `int` cases never match
* get-only auto-properties assigned in constructors → assign the emitted
  `_003CName_003Ek__BackingField`
* `.TryGetValue(k, ref v)` → `out v`
* `GUIStyle.op_Implicit(x)` → `(GUIStyle)(x)`
* `(expr?)?.Member` → `(expr)?.Member`
* named arguments carrying the original obfuscated parameter names → positional
* property setters whose implicit `value` parameter was renamed (`text`,
  `array`, `obj`, `num`, …) → `value`
* `*(ref buf + (IntPtr)((ulong)i * 4UL))` → `buf[i]` — needs a balanced-paren
  rewriter, not a regex
* `[FixedBuffer(typeof(int), 4)]` + field → `unsafe fixed int name[4]`
* IL generic-arity markers on nested type names (``Type`1<T>``) → `Type<T>`

### Ambiguities the decompiler leaves behind
* `Expression` in `DecompilerPreFi`: import
  `using ExpressionType = System.Linq.Expressions.ExpressionType;` rather than
  the whole namespace — this matches upstream ILSpy.
* Unity: qualify `Debug` / `Object` / `Random`, and nested types
  (`MultiColumnHeaderState.Column`, `Undo.UndoRedoCallback`, …);
  `((TreeView)this).ProtectedMember` → `this.ProtectedMember`.

---

## Changes to the root solution

### Project structure
* Removed **81 BCL facade projects** (`System.Runtime`, `System.Collections`,
  `netstandard`, …). They contained only `[assembly: TypeForwardedTo]` and
  shadowed the real framework assemblies — the cause of the original wall of
  `NU1201` restore errors.
* Removed **20 decompiled BCL implementation projects** (`System.Net.Http`,
  `System.IO.Compression`, `System.Diagnostics.Tracing`, …). They duplicate
  .NET Framework 4.7.2 built-ins and nothing referenced them.
* Replaced decompiled `System.Reflection.Metadata` /
  `System.Collections.Immutable` with the official NuGet packages (1.6.0 /
  1.5.0 — the versions the decompiled `AssemblyInfo` recorded).
* Removed `dnSpy.Decompiler.ILSpy.x`: it needs `dnSpy.Contracts.DnSpy` (the GUI
  contracts assembly), which was never decompiled.
* `dnSpy.Console` now references `dnSpy.Decompiler.ILSpy.Core`, the plugin it
  loads reflectively at runtime. Without it the tool builds but fails with
  "No languages were found".
* `HelixToolkit.csproj` had no `<TargetFramework>` at all; added net40.
* Unified target frameworks — net472 for the .NET Framework chain,
  netstandard2.0 for the portable libraries.

### Assembly identity
* Stripped `PublicKey=` from `InternalsVisibleTo`. The satellite assemblies
  (`Mono.Cecil.Mdb/Pdb/Rocks`) cannot be re-signed with the original private
  key, so friend access has to be granted to unsigned assemblies.
* `DecompilerFi/app.config`: dropped the binding redirects hand-copied from the
  original build. They pinned facades that are no longer shipped and broke
  `System.ValueTuple` loading. `AutoGenerateBindingRedirects` now generates them.

---

## Known limitations

* Assemblies are **unsigned**. Anything checking strong names at runtime will
  behave differently from the originals.
* `DevXUnityScriptManager` was originally built against a much older Unity. It
  now compiles against Unity 2022.3, but the API adaptation was done to satisfy
  the compiler — the editor UI is not functionally verified.
* `DevXUnityUnpackerTools` still has 407 errors, and the cause is missing
  decompiler output rather than anything fixable in the source.
* ~605 build warnings remain, mostly unused fields from obfuscated code.
