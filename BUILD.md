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

## The hash-named sidecar files

Next to `DevXUnityUnpackerRun.exe` sit more files with hex names. They are the
rest of the application, one encrypted .NET assembly each.

### Naming

`DevXUnityUnpackerMain` resolves an assembly by hashing its simple name,
lowercased, with the CLR x86 `String.GetHashCode` (seed 352654597, multiplier
1566083941 -- token 0x06000002):

```
filename = String.GetHashCode(name.ToLower()).ToString("X")
```

Every file checks out against this:

| file | assembly | version | unpacked |
|---|---|---|---|
| `0000000000` | DevXUnityUnpackerMain | 1.0.0.0 | 1.8 MB, 2093 types |
| `8DAFE878` | DevXUnityUnpackerTools | 1.0.0.0 | 20.4 MB, 11345 types |
| `A8043F67` | ICSharpCode.NRefactory.CSharp | 5.0.0.0 | 2.3 MB |
| `33123090` | NAudio | 1.8.2.0 | 463 KB |
| `4382FEFE` | ICSharpCode.Decompiler | 2.4.0.0 | 395 KB |
| `2C74C997` | DevX.Cecil | 0.6.9.0 | 375 KB |
| `45DB8D9A` | ICSharpCode.NRefactory | 5.0.0.0 | 348 KB |
| `E88D01F4` | Mono.Cecil | 0.9.6.0 | 254 KB |
| `002203XLC` | not an assembly -- a plain-text GUID, `"E668BDF2-85D8-4BB3-BF9D-18F865D6795B"` | | 40 bytes |

`0000000000` uses the simple XOR+GZip container described above; the hash-named
files use the cipher below.

### The cipher, and why it only has a 16-bit key

`例子.测试(byte[], string)` (token 0x06000003):

```
num  = 1162040133 + hash(secret[:len/2])
num2 = 2506450243 + hash(secret[len/2:])
b    = in[0]                                    # first byte is the seed, not data
for i in 0 .. len(in)-2:
    num  = (num  * 4343255 + b + 5235457)  mod 2^32 mod (2^32-2)
    num2 = (num2 * 5354354 + b + 22646641) mod 2^32 mod (2^32-2)
    out[i] = ((in[i+1] - (num2 & 0xFF)) & 0xFF) ^ (num & 0xFF)
    b = out[i]                                  # chains on plaintext
gunzip(out)                                     # falls back to out on failure
```

Only `num & 0xFF` and `num2 & 0xFF` are ever used, and multiplication mod 256
depends only on the operands mod 256. So the two 32-bit state words collapse to
their low bytes: **the whole keystream is fixed by 16 bits**, and the secret
string, the hashes and the seeds are irrelevant to recovering the plaintext.
65536 four-byte trial decryptions find the key; gunzip then CRC-checks the
result. Recovered keys, one per file: (136,48) (11,96) (7,71) (7,19) (7,45)
(238,63) (136,14).

(The `mod (2^32-2)` step can break the mod-256 closure, but only when a state
word lands exactly on 2^32-2 or 2^32-1 -- probability 2^-31 per byte. It did not
occur in any of these files; the gzip CRCs all pass.)

### tools/sidecar.py

```
python tools/sidecar.py hash ICSharpCode.NRefactory     # name -> filename
python tools/sidecar.py info      <file>                # recover key, identify
python tools/sidecar.py unpack    <file> <out.dll>
python tools/sidecar.py unpackall DevXUnityUnpackerRun out/
```

Cross-checked two independent ways: decrypting with a recovered secret string
(found by brute-forcing the app own string constants) and brute-forcing the
16-bit key produce byte-identical output for all seven files.

### Notes for anyone going further
* `DevXUnityUnpackerMain` is obfuscated with renamed symbols (CJK and whitespace
  identifiers), control-flow flattening via opaque predicates, and a decoy
  string pool. Method 0x0600007C looks like the assembly loader but the type and
  method names it feeds to `Assembly.GetType`/`GetMethod` do not resolve -- those
  string-pool slots hold decoys (`子例` for `例子`, `测` for `测试`). Reading it
  straight off a decompiler will send you the wrong way.
* The assembly references no networking, `Process`, or registry API at all, and
  has no module initializer.
* The real application logic is in `DevXUnityUnpackerTools` (11345 types), not in
  the main assembly.

## Rebuilding the recovered assemblies (`Recovered/`)

`Recovered/_assemblies/` holds the eight assemblies unpacked from the loader
payload and the sidecar files. Each was decompiled back to a project next to it.

```
dotnet build Recovered/<Name>/<Name>.csproj
```

### Which decompiler

Both tools built from this repo were tried on the same input, and they fail
differently:

| | dnSpy.Console | DecompilerFi (ILSpy) |
|---|---|---|
| invalid identifiers | emits raw ` ` escapes -- **not valid C#** | sanitises to `_0020_` |
| project file | legacy ToolsVersion 4.0, sometimes .NETPortable Profile344 | legacy, but usable |
| DevXUnityUnpackerMain | 4034 errors | 469 errors |
| ICSharpCode.Decompiler | 281 errors | 2 errors (after wiring refs) |

DecompilerFi wins on the obfuscated assemblies, and the `_0020_` identifier
style plus the `-.cs` catch-all file matches the sources already in this repo --
so the original decompile of this project was done with this same ILSpy fork.

`tools/sdkify.py` converts the legacy projects to SDK-style on net472
(`python tools/sdkify.py --all Recovered`), and `tools/fixdecompiled.py` applies
the repair patterns below.

### Results

| project | errors before | after |
|---|---|---|
| Mono.Cecil | 8 | 0 |
| DevX.Cecil | 160 | 0 |
| NAudio | 8 | 0 |
| ICSharpCode.NRefactory | 140 | 0 |
| ICSharpCode.NRefactory.CSharp | 294 | 0 |
| ICSharpCode.Decompiler | 562 | 0 |
| DevXUnityUnpackerMain | 4034 | 0 |

### What actually broke, and why

* **Missing project references.** ICSharpCode.Decompiler and
  ICSharpCode.NRefactory.CSharp accounted for ~4000 of the errors purely because
  neither decompiler wires up inter-assembly references. Adding them dropped
  ICSharpCode.NRefactory.CSharp from 3221 errors to 2.
* **`static class` as a parameter type** (CS0721, 371 in the main assembly). IL
  permits an `abstract sealed` type in a signature; C# does not. This is a
  deliberate anti-decompiler trick. Dropping the `static` modifier is enough.
* **Private/protected members reached across type boundaries** (CS0122, 17309).
  Same trick. Widening to `internal` preserves behaviour and only changes
  visibility.
* **`<Module>` and `<PrivateImplementationDetails>` in signatures.** ILSpy
  escapes the names but does not emit the declarations, since they are hidden
  types. Every call site passes `null`, so empty stubs suffice --
  `Recovered/DevXUnityUnpackerMain/_CompilerGeneratedStubs.cs`.
* **A type that must be static and non-static at once.** One obfuscated class
  declares an extension method (needs `static class`) while its own name is used
  as a parameter type in 48 signatures (needs non-static). Resolved by keeping
  the class non-static and re-exposing the method from a separate host class.
* **Obfuscated entry point** (CS5001). The entry point is `[STAThread]` but its
  name is a run of whitespace characters, and C# requires the entry point to be
  literally `Main`. A `Program.Main` forwarder plus `<StartupObject>` fixes it.
* **Real decompiler bugs**, each needing a hand fix:
  * `fixed (IntPtr* p = (IntPtr*)(&arr[0]))` -- a cast is not a valid `fixed`
    initializer (NAudio `AsioOut`).
  * an `out var` declaration emitted in the *last* disjunct of a `||` chain
    while earlier disjuncts already use the variable (ICSharpCode.Decompiler
    `ILAstOptimizer`).
  * `(expr?)?.Member` -- the inner `?` makes the parser see a nullable cast.
  * `[ComImport]` coclasses given an explicit constructor (CS0669, NAudio).
  * an indexer rendered as a parameterless property, so the index parameter is
    undefined in the body and every call site names a member that does not exist.
  * `new SaveHandle((object)this, (IntPtr)(void*)/*OpCode not supported: LdFtn*/)`
    -- ILSpy gave up on an `ldftn`; dnSpy resolves the same site, so the target
    method name can be read off the other tool's output.

### A bug in our own rebuilt ILSpy

Decompiling the 20 MB `DevXUnityUnpackerTools` crashed `DecompilerFi` with a
`NullReferenceException` in `SwitchOnNullableTransform.MatchRoslynSwitchOnNullable`.
The cause is in the decompiled ILSpy source this repo is built from --
`DecompilerPreFi/DecompTools.Decompiler.IL.Transforms/SwitchOnNullableTransform.cs:174`
came out as

```csharp
if (!NullableLiftingTransform.MatchGetValueOrDefault(value, out ILInstruction arg4) && arg4.Match(arg2).Success)
```

where the guard should be `|| !arg4.Match(...)`. When the match fails, `arg4` is
null and the `&&` still evaluates it. Verified against the pre-fix snapshot: the
line is byte-identical to the raw decompiler output, so it is an original
mis-decompilation, not something introduced while repairing the build.

### DevXUnityUnpackerTools -- the one that does not finish

The 20 MB, 11345-type main library is the only project that does not reach zero.
It sits at 407 unique errors, and the reason is that **the decompiler does not
emit all of it**:

* 10009 of 10347 top-level types come out (96.7%). The missing 338 are
  concentrated in `Unreal` (148) and several `ICSharpCode.SharpZipLib.*`
  namespaces, and they account for 288 of the remaining errors (CS0246).
* ILSpy fails silently: it writes the files it can and then leaves a 0-byte
  .csproj, with no error on stdout. The empty project file is the only signal
  that the run did not finish.
* dnSpy can dump the missing types one at a time (`--md <token>`), and doing so
  for `BrotliSharpLib` -- 8 types, 93k lines in one of them -- removed 561
  errors. Folding in all 338 the same way was tried and reverted: the per-type
  dumps are not self-contained (global-namespace types, a namespace literally
  called `as`, which is a C# keyword), and the result was worse than leaving
  them out.

What did get fixed there, on top of the patterns listed above:

* `*(ref buf + (IntPtr)((ulong)i * 4UL))` -- fixed-buffer indexing written as
  pointer arithmetic. 101 sites. A regex cannot do this safely because the index
  carries nested parentheses, so `tools/` has a balanced-paren rewriter.
* `(void*)(ref buf + (byte*)(...))` -- taking the address of a buffer element.
* `[FixedBuffer(typeof(int), 4)]` on a synthetic struct field, which C# rejects
  outright (CS1716); it has to become `unsafe fixed int name[4]`.
* IL generic-arity markers left on nested type names (`Type` + backtick + `1<T>`).
* `using @as;` -- the hoisting pass has to accept `@`-escaped keywords.

### Missing sidecar files

`DevXUnityUnpackerTools` also references seven assemblies whose sidecar files are
not in `DevXUnityUnpackerRun/`. Their file names follow the same hash rule, so
they are easy to look for in a full installation:

| assembly | file to copy |
|---|---|
| DevXUnityUnpackerTools_Structures | `A33D874E` |
| DevXUnityUnpackerUnityCommon | `93368449` |
| HelixToolkit | `D1F09BE0` |
| HelixToolkit.Wpf | `185AE22E` |
| ICSharpCode.TextEditor | `C5544D17` |
| Mon3.Cecil | `60C901F4` |
| Pngcs | `2E4B659E` |

Six of the seven are already decompiled in the root of this repo, so the project
references point there instead; only `DevXUnityUnpackerTools_Structures` has no
substitute. Nothing in the build currently fails because of it.

## Known limitations
* Assemblies are **unsigned**. Anything that checks strong names at runtime will
  behave differently from the originals.
* `DevXUnityScriptManager` was originally built against a much older Unity. It
  now compiles against Unity 2022.3, but the API adaptation was done to satisfy
  the compiler — the editor UI is not functionally verified.
* 605 build warnings remain (mostly unused fields from obfuscated code).
