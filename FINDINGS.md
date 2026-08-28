# DevXUnityUnpacker — protection analysis

What the files shipped next to `DevXUnityUnpackerRun.exe` are, how they are
packed, and what the code does to resist decompilation.

Everything below was verified against the actual binaries, not inferred from the
source alone; each section says how. Build instructions live in
[BUILD.md](BUILD.md); outstanding work in [ROADMAP.md](ROADMAP.md).

---

## Summary

The product ships as a tiny loader plus a set of packed assemblies with
meaningless file names. Two different container formats are in play, neither of
which is real encryption:

| | container | key |
|---|---|---|
| `0000000000` | XOR keystream over GZip | none — a fixed 128-byte pattern |
| hash-named files | custom stream cipher over GZip | 16 bits, brute-forceable |

All nine files in the folder were unpacked and identified. The recovered
assemblies are heavily obfuscated (renamed symbols, control-flow flattening,
decoy strings, and several tricks aimed specifically at decompilers).

---

## 1. The loader chain

```
DevXUnityUnpackerRun.exe          60-line stub, the only unobfuscated code
  └─ reads  0000000000            XOR + GZip
       └─ DevXUnityUnpackerMain   1.8 MB, 2093 types, obfuscated
            └─ resolves assemblies by name hash → sidecar file
                 └─ DevXUnityUnpackerTools   20 MB, 11345 types ← the real product
                    Mono.Cecil, DevX.Cecil, NAudio, ICSharpCode.*
```

`DevXUnityUnpackerRun.exe` contains nothing but the unpacking routine. The
application proper is `DevXUnityUnpackerTools`; `Main` is mostly a resolver and
a pile of decoys.

---

## 2. Layer 1 — the `0000000000` container

`Memrestore` in [DevXUnityUnpackerRun/Program.cs](DevXUnityUnpackerRun/Program.cs)
fully specifies the format. There is no key material and no per-file state.

```
file 0000000000  ──XOR keystream──▶  GZip stream  ──gunzip──▶  .NET assembly
                                                    Assembly.Load(..).EntryPoint.Invoke()
```

The keystream is `num2 + num3`, where `num2` starts at 10 stepping by 13 and
`num3` starts at 1 stepping by 1317 — so at index `i` it is `11 + 1330*i`.
Since `1330 % 256 == 50`, that collapses to

```
key[i] = (11 + 50*i) & 0xFF
```

a fixed pattern with period 128. Only 128 of the 256 byte values ever appear
(`gcd(50, 256) = 2`). This is obfuscation, not encryption.

Because a GZip stream always starts `1F 8B 08 00`, a correctly packed file
always begins with those bytes XORed against `0B 3D 6F A1`:

```
magic: 14 B6 67 A1
```

which identifies the format from four bytes.

**How this was verified.** A harness running `Memrestore` / `DeCompess` / `Copy`
copied verbatim from `Program.cs` was fed the output of the packer written from
this analysis. The result was byte-identical to the input assembly, and
`Assembly.Load` then resolved it and reported a valid entry point.

One oddity: `Memrestore` calls `Application.Exit()` in the middle of its loop.
With no message loop running it is a no-op — leftover or noise.

---

## 3. Layer 2 — the hash-named sidecar files

### Naming

`DevXUnityUnpackerMain` resolves an assembly by hashing its **simple name,
lowercased**, using the CLR x86 `String.GetHashCode` (seed 352654597, multiplier
1566083941 — reimplemented at token `0x06000002`):

```
filename = String.GetHashCode(name.ToLower()).ToString("X")
```

Every file in the folder matches this rule exactly, which is how
`45DB8D9A` was identified as `ICSharpCode.NRefactory` before it could even be
decrypted.

### The cipher

`例子.测试(byte[], string)` — token `0x06000003`:

```
num  = 1162040133 + hash(secret[:len/2])
num2 = 2506450243 + hash(secret[len/2:])
b    = in[0]                                   # first byte is the seed, not data
for i in 0 .. len(in)-2:
    num  = (num  * 4343255 + b + 5235457)  mod 2^32 mod (2^32-2)
    num2 = (num2 * 5354354 + b + 22646641) mod 2^32 mod (2^32-2)
    out[i] = ((in[i+1] - (num2 & 0xFF)) & 0xFF) ^ (num & 0xFF)
    b = out[i]                                 # chains on plaintext
gunzip(out)                                    # falls back to out on failure
```

A second class, at token `0x060004B9`, does look serious — PBKDF2-SHA1 with 1000
iterations, Rijndael, HMAC-SHA1 — but that is SharpZipLib's WinZip-AES transform
for ZIP files, and has nothing to do with unpacking these assemblies.

### Why the key is only 16 bits

Only `num & 0xFF` and `num2 & 0xFF` are ever used, and multiplication mod 256
depends only on the operands mod 256. So the two 32-bit state words collapse to
their low bytes: **the entire keystream is fixed by 16 bits.** The secret string,
the two hashes and the 32-bit seeds are all irrelevant to recovering the
plaintext — 65536 trial decryptions of four bytes each is enough, and GZip's CRC
confirms the hit.

(The `mod (2^32-2)` step can break the mod-256 closure, but only when a state
word lands exactly on `2^32-2` or `2^32-1`: probability 2⁻³¹ per byte. It did not
occur in any of these files; every GZip CRC passed.)

**How this was verified.** Two independent routes produced byte-identical output
for all seven files: decrypting with a recovered secret string, and
brute-forcing the 16-bit key. The reimplementation of the cipher and of the hash
was also checked against the originals invoked by reflection — exact match on
every reference value.

---

## 4. File inventory

| file | contents | version | unpacked size |
|---|---|---|---|
| `0000000000` | DevXUnityUnpackerMain | 1.0.0.0 | 1.8 MB, 2093 types |
| `8DAFE878` | DevXUnityUnpackerTools | 1.0.0.0 | 20.4 MB, 11345 types |
| `A8043F67` | ICSharpCode.NRefactory.CSharp | 5.0.0.0 | 2.3 MB |
| `33123090` | NAudio | 1.8.2.0 | 463 KB |
| `4382FEFE` | ICSharpCode.Decompiler | 2.4.0.0 | 395 KB |
| `2C74C997` | DevX.Cecil | 0.6.9.0 | 375 KB |
| `45DB8D9A` | ICSharpCode.NRefactory | 5.0.0.0 | 348 KB |
| `E88D01F4` | Mono.Cecil | 0.9.6.0 | 254 KB |
| `002203XLC` | not an assembly — a plain-text GUID, `"E668BDF2-85D8-4BB3-BF9D-18F865D6795B"` | | 40 bytes |

Recovered keys, one pair per file: (136,48) (11,96) (7,71) (7,19) (7,45)
(238,63) (136,14).

`002203XLC` doesn't fit the pattern the other 8 files share, in two
independent ways: `tools/sidecar.py` finds no XOR key for it (expected — the
crack only recognizes a hit by GZip's magic bytes, and this payload, hex-
dumped directly, is plain ASCII: `"E668BDF2-...5B"\r\n`, never GZip'd), and
its filename itself isn't producible by the app's own hash-naming function —
every real implementation found (`DevXUnityUnpackerMain/例子.cs`,
`Recovered/DevXUnityUnpackerMain/bin/Debug/net472/_diag_source.cs`'s dumped
`RunDlls` shim, `記草空.cs`, `MaybeHashCalc.cs`) formats the hash as
`"{0:X}"` — uppercase hex only, `0-9A-F` — and `002203XLC` contains `X`/`L`,
neither a hex digit. A wide search across the license/activation code
(`LicChecker.cs`, `GameRecoveryLicManager.cs`, `ConvertNameToHash.cs`,
`RequestManager.cs`/`GetMethodManager.cs`/`ServerLink.cs`/`CrackSettings.cs`,
`HiddenCalls.cs`) turned up plenty of GUID/license/device-ID-shaped code, but
none of it reads a bare quoted GUID from a file next to the exe — the real
license cache lives under `%LocalAppData%` in a different (RSA-signed) format
entirely. No consumer was found in the fully rebuilt, runtime-verified (P3)
`DevXUnityUnpackerMain`/`DevXUnityUnpackerTools` source, and P3's own
`FirstChanceException` launch trace never touched this file either. Two
unconfirmed hypotheses, roughly equally supported: it belongs to
`DevXUnityUnpackerTools_Structures` (`A33D874E`, the one sidecar this repo
never recovered at all — though the assembly's own name doesn't hash to this
either), or it's simply decoy chaff, consistent with this app's documented
habit of planting misleading artifacts (§5) — an oddly-named, unencrypted,
otherwise-unreferenced 40-byte file fits that pattern as well as any real
purpose. Left as an open question, not a solved one.

### Files that are absent

`DevXUnityUnpackerTools` references seven more assemblies whose sidecar files
are not in this folder. The naming rule gives their file names directly:

| assembly | file to look for |
|---|---|
| DevXUnityUnpackerTools_Structures | `A33D874E` |
| DevXUnityUnpackerUnityCommon | `93368449` |
| HelixToolkit | `D1F09BE0` |
| HelixToolkit.Wpf | `185AE22E` |
| ICSharpCode.TextEditor | `C5544D17` |
| Mon3.Cecil | `60C901F4` |
| Pngcs | `2E4B659E` |

Six of the seven are already decompiled in the root of this repo, so the
rebuilt projects reference those instead. Only
`DevXUnityUnpackerTools_Structures` has no substitute — though nothing in the
build currently fails because of it.

---

## 5. Obfuscation techniques observed

### Symbol renaming
Identifiers are runs of space and newline characters (`U+0020`, `U+000A`), plus
some CJK type names (`例子`, `記草空`). Decompilers escape these — ILSpy to
`_0020_000A…`, dnSpy to raw ` …`, which is not valid C#.

### Control-flow flattening
Methods open with a constant (`int num = 1108131;`) and branch on opaque
predicates built from it (`(num ^ 126309) == 1115603 ? A : B`). The branches are
statically decidable but make the decompiled output unreadable.

### Decoy string pool
416 static string fields, decoded at startup from block-drawing characters
(`U+2593`–`U+25A3`). Critically, **the values the assembly loader appears to use
are decoys**: the type-name slots hold `子例` (a reversal of the real `例子`) and
`测` (a truncation of `测试`), and neither resolves via `Assembly.GetType`. Anyone
reading method `0x0600007C` off a decompiler and trusting those strings will
chase the wrong thing — as happened here before the raw IL was checked.

### Tricks aimed at C#, not at the CLR
These are all legal IL that has no valid C# spelling, so decompiled output
cannot compile without editing:

* **`static class` as a parameter type.** IL allows an `abstract sealed` type in
  a signature; C# does not (371 sites in `Main`).
* **Private and protected members reached across type boundaries** — 17309
  errors in `Main` alone.
* **`<Module>` and `<PrivateImplementationDetails>` in signatures.** Compiler-
  generated types, referenced deliberately; every call site passes `null`.
* **A type that must be `static` and non-`static` at once.** One class declares
  an extension method (requires `static class`) while its own name is used as a
  parameter type in 48 signatures (requires non-static).
* **An entry point named with whitespace.** It carries `[STAThread]`, but C#
  requires the entry point to be literally called `Main`.

### Symbol-renaming scheme, characterized
684 unique non-public member names sampled from the recovered
`BrotliSharpLib/Brotli.cs` (before it was replaced, see §8) came back **98%
either 15 or 16 characters long**, drawn only from `U+0020`/`U+000A`, with no
correlation to the original identifier's length or kind (type, method, field
all land in the same narrow band). That rules out any length-preserving or
hash-derived-length transform — it's flat random selection from a small fixed-
length pool, consistent with common .NET obfuscators' "unprintable identifier"
renaming (Eazfuscator.NET/Agile.NET/ConfuserEx-style). Public API members
(`DecompressBuffer`, `CompressBuffer`, ...) are exempted and keep their real
names — the same pattern later confirmed project-wide: real BCL/library
method names like `GetField`/`SetField`/`Read` survive obfuscation untouched,
while everything internal to the obfuscated assembly gets a whitespace name
from this pool. At project scale, the fixed-size pool produces genuine
collisions — the same random name reused for unrelated members in different
types (see the "declaration-vs-static-reference" bug shape in §6) — which is
itself a useful tell when triaging a build error: if a bare identifier could
plausibly be either a local variable and a type/namespace-scoped member, a
collision, not a logic bug, is the first thing to check.

### What it does *not* do
The main assembly references no networking, `Process`, or registry API at all,
and has no module initializer. It is inert on load — which is what made it safe
to invoke its own routines during analysis.

---

## 6. Decompiler behaviour

Both tools built from this repo were run on the same inputs. They fail
differently, and neither is a clear winner.

| | dnSpy.Console | DecompilerFi (ILSpy) |
|---|---|---|
| invalid identifiers | raw ` ` escapes — **not valid C#** | sanitised to `_0020_` |
| project file | legacy ToolsVersion 4.0, sometimes .NETPortable Profile344 | legacy, usable |
| `DevXUnityUnpackerMain` | 4034 errors | 469 errors |
| `ICSharpCode.Decompiler` | 281 errors | 2 errors (once refs are wired) |
| large obfuscated assembly | completes | hung on an unattended assert dialog — fixed, see below |

ILSpy's `_0020_` identifier style and its `-.cs` catch-all file match the sources
already in this repo, so the original decompile of this project was done with
this same ILSpy fork.

### ILSpy drops types without saying so — root cause found and fixed

On the 20 MB `DevXUnityUnpackerTools` it used to emit only **10009 of 10347
top-level types (96.7%)**, and stayed silent. The 338 missing ones clustered in
`Unreal` (148) and several `ICSharpCode.SharpZipLib.*` namespaces. The only
signal that the run had not finished was a **0-byte `.csproj`** — no error, no
non-zero exit code.

The cause: `WholeProjectDecompiler.WriteCodeFilesInProject` decompiles each
output file inside a `Parallel.ForEach` with no `try`/`catch` anywhere in it.
Somewhere in the IL reader or transform pipeline (`ILReader.CreateILVariable`,
`ReduceNestingTransform`, ...), the obfuscated input trips a
`System.Diagnostics.Debug.Assert`. In a Debug build that pops a modal
`DefaultTraceListener` dialog — *"Assertion Failed: Abort=Quit, Retry=Debug,
Ignore=Continue"* — and blocks that thread forever. There was no exception to
swallow; there was a human-shaped hole in an unattended pipeline. This also
explains why the original decompile that produced 10009/10347 wasn't a clean
failure: someone was presumably present clicking through these dialogs, and
whichever groups hit the assert ended up missing or corrupted depending on
timing, while a fully unattended run just hangs.

Fixed in `DecompilerFi`/`DecompilerPreFi` (see [ROADMAP.md §P1](ROADMAP.md) for
the full writeup): `ILSpyCmdProgram.Main` now clears `Trace.Listeners` before
anything else runs, so a failed assert can never show UI. The per-file decompile
also now runs on a dedicated large-stack thread with the exception caught and
logged per file instead of aborting the whole `Parallel.ForEach`, plus a
skip-list for the rare file that's provably not worth waiting on (see below).
Re-running the fixed tool recovered all but one of the 338 missing types
without needing dnSpy at all, and took `DevXUnityUnpackerTools` from 407 build
errors to 0.

The one holdout is `BrotliSharpLib.Brotli` (93k obfuscated lines, previously
suspected as "presumably what choked ILSpy" — correctly, just not for the
reason assumed). Isolated with `-t BrotliSharpLib.Brotli`, it neither crashes
nor asserts; it just doesn't finish in 240+ seconds single-threaded. That's a
real algorithmic limit in ILSpy's AST transforms on pathological input, not
something a stack size or an exception handler fixes. dnSpy can still dump it
directly (`--md <token>`) — that combination (8 types, one of them this
93k-line one) already removed 561 errors when tried before, so the fallback
below remains valid for this one type.

### A real bug in the rebuilt ILSpy

`DecompilerFi` crashed with a `NullReferenceException` in
`SwitchOnNullableTransform.MatchRoslynSwitchOnNullable`. The cause is in the
decompiled ILSpy source this repo is built from —
[SwitchOnNullableTransform.cs:174](DecompilerPreFi/DecompTools.Decompiler.IL.Transforms/SwitchOnNullableTransform.cs#L174)
came out as

```csharp
if (!NullableLiftingTransform.MatchGetValueOrDefault(value, out ILInstruction arg4) && arg4.Match(arg2).Success)
```

where the guard should read `|| !arg4.Match(...)`. When the match fails, `arg4`
is null and the `&&` still evaluates it. Checked against the pre-fix snapshot:
the line is byte-identical to the raw decompiler output, so this is an original
mis-decompilation, not something introduced while repairing the build.

### A declaration-level error anywhere suppresses semantic diagnostics project-wide

While pushing `DevXUnityUnpackerTools.csproj` from the "1 unfixable error"
state described in ROADMAP.md P7b down to 0, the error count did not shrink
monotonically as fixes landed — at one point *removing* a single obviously-
wrong attribute (`[DefaultMember("Item")]` colliding with a real indexer,
CS0646) caused the reported error count to jump from ~10 to **over 1000**,
with the new errors scattered across dozens of files that hadn't been touched.
Reproduced twice, deterministically, by toggling that one fix on and off: the
same ~1000-error set appeared or vanished as a block, stable in count and
location both times. This rules out non-determinism, MSBuild/Roslyn server
caching, and resource exhaustion (all suspected and ruled out in this exact
project earlier, see ROADMAP.md P7b) as the mechanism.

The actual cause: **a compile error at the *declaration* level (a duplicate
attribute, an indexer/`DefaultMember` clash, a member signature Roslyn can't
resolve at all) suppresses semantic-level diagnostics for the rest of the
compilation**, not just the containing file. Only once every declaration-level
error was gone did Roslyn start reporting the method-body-level errors
(`CS0571` explicit accessor calls, decoy methods, real bugs) that had been
sitting underneath the whole time. Practically: an error count that *grows*
after a fix is not a sign the fix was wrong — check whether the fix removed a
declaration-level error and revealed a backlog, before assuming a regression.

### The "decoy method" pattern

Beyond the decoy string pool (§5) and decoy dispatch strings, obfuscated
non-public methods are frequently replaced wholesale with bodies that do
nothing real: a sequence of calls on `((SomeType)null).Member(...)` (a
guaranteed `NullReferenceException` at runtime, never actually reached because
the method itself is never legitimately called), followed by a `return`
of a hardcoded literal (an int, a numeral-string, or `null`). Hundreds of
these were found and removed project-wide. Reliable tells, in combination:

* Every statement in the body is either a null-cast no-op call or an isolated
  field/property read off a null-cast object — no data flows between
  statements, no branching, no loops.
* The return value (if any) is a literal, not derived from anything computed
  in the body.
* Often paired with a syntactically-broken generic instantiation that only
  exists to make the method fail to compile at all without inspection —
  unbound generic syntax (`Foo<,,,>`), a CLR arity suffix leaking through
  (`` Method`1() ``), or a type argument that resolves to a variable instead
  of a type (`Method<localVarName>()`, CS0118).
* A one-line `[FunAttr(Num = "...")]`-style attribute frequently precedes the
  method; deleting the method but leaving that attribute behind produces an
  orphaned attribute that then attaches to the *next* declaration, occasionally
  causing a fresh duplicate-attribute error (CS0579) if that next member
  happens to carry the same attribute type.

Safe to delete wholesale once confirmed real call sites don't route through
them (dozens of files this pass; none of them are referenced from outside
their own never-instantiated decoy class). Two important caveats **found the
hard way**: (1) an automated pass built on this pattern once deleted a
genuinely real (if buggy) event handler that happened to also reference an
unresolvable generic — see ROADMAP.md P7b's MainForm.cs note; treat the
pattern as a strong prior, not a certainty, on anything with real business
logic nearby. (2) after swapping in a real open-source library for a
previously-decompiled type (see ROADMAP.md P7b's BrotliSharpLib section),
every decoy method built to camouflage itself using that type's *old,
obfuscated* member names breaks — this is expected fallout, not a sign the
swap was wrong, and resolves the same way (delete the now-broken decoy).

### Explicit accessor calls on properties from real assemblies (CS0571)

Decompiled method bodies throughout the project call `.get_X()`/`.set_X()`/
`.add_X()`/`.remove_X()` directly — ILSpy's rendering of an IL `callvirt` on a
property's compiler-generated accessor method. Roslyn accepts this in IL but
refuses to *compile* it once the declaring type comes from real C# source with
proper property metadata (seen against `Mono.Cecil`, `HelixToolkit`,
`ICSharpCode.TextEditor`, and `Pngcs` types alike) — the fix is always to
rewrite to normal property/indexer/event syntax
(`x.get_Y()` → `x.Y`, `x.set_Item(i, v)` → `x[i] = v`,
`x.add_Z(h)` → `x.Z += h`).

### Fixed-size buffers decaying to a bare pointer, then indexed as if it were a struct

Several ASTC- and LZMA-style unsafe structs declare `fixed int name[N];`
(a fixed-size buffer). Accessing that field through a pointer
(`structPtr->name`) already yields `int*` directly — no `&`, no further member
access. Some call sites nonetheless tacked on `.someObfuscatedField` (an
artifact of the same renaming pass, colliding with a same-named field on an
unrelated struct elsewhere in the file — see the naming-scheme note above),
producing `CS1061: 'int*' does not contain a definition for ...`. The fix is
mechanical once recognised: drop the trailing member access (and the leading
`&`, if present) and let the buffer decay to the pointer the call site already
wanted.

### `Reverse().ToArray()` silently resolving to the wrong method

`array.Reverse().ToArray()`, with both `using System;` and `using System.Linq;`
in scope, does not always call `Enumerable.Reverse` — `System.MemoryExtensions
.Reverse<T>(this Span<T>)` is also in scope (via `System`), array-to-`Span<T>`
is an implicit conversion, and the compiler resolves to that overload instead,
which returns `void` (in-place reverse) and breaks the `.ToArray()` chain with
`CS0023: Operator '.' cannot be applied to operand of type 'void'`. Nothing to
do with obfuscation — a plain modern-.NET gotcha that happens to surface a lot
in code this old. Fix: qualify explicitly,
`System.Linq.Enumerable.Reverse(array).ToArray()`.

### Other decompilation defects found

Each of these needed a hand fix; they are catalogued with their repairs in
[BUILD.md](BUILD.md).

* `fixed (IntPtr* p = (IntPtr*)(&arr[0]))` — a cast is not a valid `fixed`
  initializer.
* An `out var` declaration emitted in the *last* disjunct of a `||` chain, while
  earlier disjuncts already use the variable.
* `(expr?)?.Member` — the inner `?` makes the parser see a nullable-type cast.
* `[ComImport]` coclasses given an explicit constructor.
* An indexer rendered as a parameterless property: the index parameter is
  undefined in the body, and every call site names a member that does not exist.
* `new SaveHandle((object)this, (IntPtr)(void*)/*OpCode not supported: LdFtn*/)`
  — ILSpy gave up on an `ldftn`; dnSpy resolves the same site, so the target can
  be read off the other tool's output.
* `*(ref buf + (IntPtr)((ulong)i * 4UL))` — fixed-buffer indexing written as
  pointer arithmetic (101 sites). A regex cannot do this safely because the index
  carries nested parentheses.
* `[FixedBuffer(typeof(int), 4)]` on a synthetic struct field, which C# rejects
  outright — it has to become `unsafe fixed int name[4]`.
* IL generic-arity markers left on nested type names (``Type`1<T>``).

### The biggest single cause of errors was not the decompiler

Neither tool wires up references between the assemblies it decompiles. Adding
the missing `ProjectReference` entries took `ICSharpCode.NRefactory.CSharp` from
**3221 errors to 2**, and accounted for roughly 4000 errors across the set.

---

## 7. Tooling

| tool | what it does |
|---|---|
| `tools/payload.py` | unpack / pack / identify the `0000000000` container |
| `tools/sidecar.py` | name→filename hash, and unpack the hash-named files by brute-forcing the 16-bit key |
| `tools/sdkify.py` | convert dnSpy/ILSpy legacy `.csproj` output to SDK-style net472 |
| `tools/fixdecompiled.py` | apply the recurring decompiler-artifact repairs, textual and error-log driven |
| `tools/unescape_ids.py` | convert dnSpy `\uXXXX` identifier escapes to `_XXXX`, skipping string and char literals and comments |
| `DecompilerFi.exe` (`-p`) | the ILSpy-based project decompiler itself. No longer hangs on an obfuscation-tripped assert (see §6); `-s <file>` skips specific output files (one group key per line, e.g. `BrotliSharpLib\Brotli.cs`) instead of decompiling them, and every run writes `_wpd_progress.log` (`BEGIN`/`END`/`FAIL` per output file) to the output directory. |

```
python tools/payload.py  info      0000000000
python tools/payload.py  unpack    0000000000 payload.dll
python tools/payload.py  pack      payload.dll 0000000000     # both steps are symmetric

python tools/sidecar.py  hash      ICSharpCode.NRefactory      # name -> filename
python tools/sidecar.py  unpackall DevXUnityUnpackerRun out/

python tools/sdkify.py        --all Recovered
python tools/unescape_ids.py  --check <dir>                    # report, change nothing
python tools/fixdecompiled.py all <dir> <build-log>

DecompilerFi.exe <asm.dll> -p -o <outdir> -r <refdir>           # decompile as project
DecompilerFi.exe <asm.dll> -p -o <outdir> -r <refdir> -s skip.txt  # ...skipping known-bad files
```

---

## 8. Open items

* ~~One type, `BrotliSharpLib.Brotli`, is still a placeholder~~ **Fixed**, in
  two stages. First pass: re-decompiled with dnSpy's per-type dump
  (`--md <token>`) during ROADMAP.md P7b, after ILSpy's `-t`/type-name path
  was reconfirmed to hang indefinitely on it — needed `tools/unescape_ids.py`
  (dnSpy's raw `\uXXXX` escapes → this codebase's `_XXXX` form) plus a
  handful of mechanical fixes for decompiler-rendering quirks specific to
  this type (`*(ref X + offset)` pointer arithmetic where `ref` isn't valid
  syntax, a stray CLR generic-arity backtick on two method calls, and
  `[FixedBuffer]` attributes converted to the `fixed` field modifier plus
  `unsafe` on their containing structs). Confirmed via reflection
  (`Type.IsAbstract && Type.IsSealed`) that the type really is a C#
  `static class`, which the old ILSpy placeholder had gotten wrong in
  addition to being incomplete. Second pass, superseding the first entirely:
  `BrotliSharpLib` is [master131/BrotliSharpLib](https://github.com/master131/BrotliSharpLib)
  (MIT), a near-1:1 port of Google's reference Brotli C implementation —
  confirmed structurally via matching method signatures
  (`HistogramClear`/`ClearHistograms`/`HistogramAddHistogram`/
  `BrotliBuildHistogramsWithContext`, `BrotliStream`'s constructors/fields)
  against the recovered source. The whole obfuscated `BrotliSharpLib/`
  directory (58 files, including the 93k-line `Brotli.cs`) was deleted and
  replaced verbatim with the real upstream source — the SDK-style project's
  default `**/*.cs` glob picks up the real project's subfolder layout
  (`Decode/`, `Encode/`, `Encode/Hash/`) with no `.csproj` changes needed.
  Removes the only place in this codebase carrying decompiler-rendering
  workarounds instead of original-looking source, and incidentally confirmed
  every one of the mechanical fixes above was correct (the obfuscated and
  real versions are behaviorally identical up to renaming).
* **`DevXUnityUnpackerTools_Structures` (`A33D874E`) is absent** from the folder
  and has no substitute in this repo.
* **`HelixToolkit.Wpf` likely has the same missing-type bug** `DevXUnityUnpackerTools`
  had (`SplitOnWhitespace` is called but never defined anywhere in the repo) —
  it was decompiled before the fix in §6 existed. Not re-decompiled yet; see
  ROADMAP.md.
* The recovered assemblies stay obfuscated. Unpacking undoes the packing only —
  a decompiler gets you compilable source, not readable source.
* Rebuilt assemblies are **unsigned**; anything checking strong names at runtime
  will behave differently from the originals.
