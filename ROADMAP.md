# Roadmap

What is finished, what is not, and how to pick up each piece.

Analysis lives in [FINDINGS.md](FINDINGS.md); build instructions in
[BUILD.md](BUILD.md).

---

## Status

| | state |
|---|---|
| Root solution `Decompiled.sln` | 37 projects, **0 errors** — reconfirmed on a full clean rebuild (`dotnet build Decompiled.sln`, `rm -rf obj bin` first) after the P7b `DevXUnityUnpackerTools` fix, so this now includes `DevXUnityUnpackerMain`'s `ProjectReference` to it |
| Unpacking `0000000000` | done, verified against the original `Memrestore` |
| Unpacking the hash-named sidecars | done, all 7, verified two independent ways |
| File identification | done, 9 of 9 |
| Rebuilding recovered assemblies | **8 of 8 at 0 errors** |
| `DevXUnityUnpackerTools` | 407 → 0 (P1) → 183 (P7b merge) → **0 errors, clean rebuild verified** — see P7b |
| Running anything that was recovered | **the rebuilt app runs and shows its window** — see P3 |
| Merging the loader chain (dropping the encrypted payloads) | Run→Main **done**, Main→Tools **done** (Tools itself builds clean) — re-verify the merged launch still opens a window next — see P7 |
| Deobfuscation | not started — see P5 |

---

## P1 — Finish `DevXUnityUnpackerTools` — done

**Why it mattered.** This is the actual product: 20 MB, 11345 types. Everything
else is a support library.

**Root cause, found.** The "drops types silently, 0-byte `.csproj`, no error, no
non-zero exit code" symptom was never an exception-swallowing bug — there was no
`catch` anywhere in the parallel project writer. It was
`WholeProjectDecompiler`'s `Parallel.ForEach` hitting a failed
`System.Diagnostics.Debug.Assert` deep in the IL reader/transform pipeline
(`ILReader.CreateILVariable`, `ReduceNestingTransform`, ...). In a Debug build,
a failed assert pops a modal **"Assertion Failed: Abort=Quit, Retry=Debug,
Ignore=Continue"** dialog and blocks that thread forever waiting for a human —
which explains both failure modes previously observed: a process that hangs
with no output, and a run that limped to 10009/10347 types because someone was
present to click through the dialogs, with the assert-violated groups ending up
missing or corrupted depending on timing. No human is present in an automated
build, so the run just sat there.

**The fix**, in `DecompilerPreFi`/`DecompilerFi`:

* `ILSpyCmdProgram.Main` now calls `Trace.Listeners.Clear()` before anything
  else runs. `Debug.Listeners` and `Trace.Listeners` are the same collection, so
  this removes `DefaultTraceListener` and its modal dialog entirely — the
  correct fix regardless of build configuration, since a CLI tool must never
  block on unattended UI. (Building `DecompilerFi` in `Release` was tried first
  and does *not* reliably strip these calls — worth knowing if this is
  revisited.)
* `WholeProjectDecompiler.WriteCodeFilesInProject` now runs each output file's
  decompile on a dedicated thread with a 256 MB stack (deep obfuscated ASTs can
  overflow the default 1 MB thread-pool stack), catches any exception per group
  instead of letting one `Parallel.ForEach` failure blow up the whole run, and
  logs `BEGIN`/`END`/`FAIL` per group to `_wpd_progress.log` in the output
  directory — grep it for a `BEGIN` with no matching `END`/`FAIL` to find what
  was in flight when a run dies.
* A new `SkipGroupKeys` property (CLI: `-s|--skipfile <path>`, newline-separated
  group keys) makes specific output files skip decompilation entirely and write
  a one-line placeholder instead. Some obfuscated methods are slow enough that
  they aren't worth waiting on even though they don't crash — see below.

**Result:** rebuilding `Recovered/DevXUnityUnpackerTools` from scratch with the
fixed tool recovered 74 previously-missing files (whole namespace directories
that didn't exist before, matching the `Unreal`/`ICSharpCode.SharpZipLib.*`
clusters FINDINGS.md already pointed at) — added into the existing tree without
touching any already-hand-fixed file. The project now builds at **0 errors**
(was 407): the CS0246s from missing types are gone, and the CS0104/CS0721/
CS0507/CS0051/CS7003 fallout cleared with them (most were knock-on errors from
the same missing symbols, not independent issues).

One type was deliberately left out: `BrotliSharpLib.Brotli`, a 93k-line
obfuscated method (FINDINGS.md §6 already flagged it as what "presumably choked
ILSpy"). Isolated with `-t BrotliSharpLib.Brotli` it does not crash or hang on
an assert — it just runs for 240+ seconds single-threaded with no output and no
sign of finishing. This is a genuine algorithmic limit of ILSpy's recursive AST
transforms on pathological input, not a bug this fix can paper over. It's in the
skip list with a placeholder pointing at the documented fallback: dump it with
`dnSpy.Console --md <token>` the same way the roadmap already recommended (see
"Deliberately not done" below) — that route is known to work for this exact
type.

### Left for later

CS0104/CS0721/CS0507/CS0051/CS7003 no longer appear at all post-fix, so P1b (the
"remaining ~120 errors" that used to need a manual accessibility/static-class
follow-up pass) is moot. `tools/fixdecompiled.py` still doesn't have that
second pass — see P4 — but nothing in this repo currently needs it.

### Side finding, fixed: two pre-existing, unrelated build breaks

Rebuilding `Decompiled.sln` clean (`dotnet restore` + `dotnet build`) to confirm
P1 didn't regress anything turned up 7 pre-existing errors BUILD.md's
"0 errors" didn't account for. Neither project was touched by the P1 fix; both
were already broken. Both are now fixed too, since the underlying repair was
small and low-risk once found:

* **`Microsoft.VisualStudio.Composition.csproj`** referenced
  `System.Threading.Tasks.Dataflow` via a `HintPath` pointing outside the repo
  entirely — `..\..\DevXCrack_1.0.9 (1)\StreamingAssets\DecompilerFi\...` — a
  leftover from whichever machine this was first decompiled on (that exact
  folder, minus the `(1)`, turned out to still exist one level up from this
  repo — see the callout below). Swapped the stale `<Reference HintPath=...>`
  for a `<ProjectReference>` to the `System.Threading.Tasks.Dataflow` project
  that already existed at the repo root but wasn't in `Decompiled.sln` or
  buildable (no `<TargetFramework>`/`<LangVersion>` — added `net472` /
  `latest`, matching the rest of the repo). (Was 3 errors: CS0234, 2×CS0246.)
* **`HelixToolkit.Wpf`** called `input.SplitOnWhitespace()` from `ObjReader.cs`
  and `OffReader.cs`. The method itself was fine —
  `HelixToolkit/HelixToolkit/StringExtensions.cs` already had it, and
  `HelixToolkit.Wpf`'s own namespace is a child of `HelixToolkit`'s, so no
  `using` was even needed. The actual bug: `HelixToolkit.Wpf.csproj` referenced
  the base `HelixToolkit` assembly via the same kind of stale external
  `HintPath` (`..\..\DevXCrack_1.0.9 (1)\HelixToolkit.dll`) instead of a
  `<ProjectReference>` to the `HelixToolkit` project already in this repo.
  Swapped it the same way. Re-decompiling `HelixToolkit.Wpf.dll` with the
  now-fixed `DecompilerFi` (from the original `HelixToolkit.Wpf.dll` found in
  `DevXCrack_1.0.9/`, see below) confirmed no types were actually missing — 0
  new files came out of the diff — so this was never an instance of the P1 bug,
  just the same "stale absolute `HintPath`" pattern as the Dataflow one. (Was
  4×CS1061.)

**Found in the process — a source of original binaries next to this repo.**
`C:\Users\Dev04\Documents\.Thinhnv\DevXCrack_1.0.9\` (a sibling of this repo,
not part of it) turned out to be a full original installation: the same nine
`0000000000`/hash-named files, `DevXUnityUnpackerRun.exe`, and — critically —
unobfuscated originals for everything FINDINGS.md §4 calls "absent as sidecar
files but decompiled from elsewhere in this repo": `HelixToolkit.dll`,
`HelixToolkit.Wpf.dll`, `ICSharpCode.TextEditor.dll`, `Mon2.Cecil.dll`/
`Mon3.Cecil.dll`, `Pngcs.dll`, `DevXUnityUnpackerUnityCommon.dll`. It even has
`StreamingAssets/DecompilerFi/`, a full build of the *original* `DecompilerFi`
this repo's `DecompilerFi`/`DecompilerPreFi` were themselves decompiled from —
which is where the stale `HintPath`s in this repo's `.csproj` files point,
explaining both bugs above. **`A33D874E` (P2) was checked here too and is still
absent** — this folder doesn't have it either. Given `DevXUnityUnpackerRun.exe`
and every other sidecar file are present here in original form, this folder is
also the obvious next stop for P3 (runtime verification) — copy from here
instead of re-packing anything.

---

## P2 — The one sidecar file that is genuinely missing

`DevXUnityUnpackerTools_Structures` → file **`A33D874E`**. It is not in
`DevXUnityUnpackerRun/` and there is no decompiled substitute in this repo.

Nothing in the build fails because of it today, but the recovered `Tools`
assembly does reference it, so anything trying to *run* will need it. Six other
referenced assemblies are also absent as sidecar files
([FINDINGS.md §4](FINDINGS.md)) but do have substitutes in the repo root.

Copy it from a full installation if one is available.

---

## P3 — Runtime verification — done

**The full, real end-to-end test now passes: the rebuilt sources run.**
`DevXUnityUnpackerRun.exe`, `DevXUnityUnpackerMain` and `DevXUnityUnpackerTools`
— all three built from the decompiled sources in this repo — load, resolve each
other, and show the actual application window:
**`"DevXUnity-Unpacker Magic Tools Ver 10.06x64"`**.

The first attempt (just the nine hash-named payload files next to the built
`DevXUnityUnpackerRun.exe`) got past `Assembly.Load`/`EntryPoint.Invoke()`
cleanly but showed no window and exited in 1–4s with no crash logged anywhere.
Root cause, found by instrumenting a *rebuilt* copy of `DevXUnityUnpackerMain`
(temporarily — added logging, rebuilt, repacked into a fresh `0000000000` with
`tools/payload.py pack`, reran; reverted once done) and hooking
`AppDomain.CurrentDomain.FirstChanceException` in `DevXUnityUnpackerRun`'s
`Program.cs` — the one hook that sees an exception even if something downstream
swallows it with an empty `catch {}`:

```
System.IO.FileNotFoundException: Could not load file or assembly
'DevXUnityUnpackerUnityCommon, Version=1.0.0.0, ...'
   at Loader.Load()
```

Mundane, in the end: `Loader.Load()` (`DevXUnityUnpackerTools`' real,
unobfuscated entry point) needs several **plain, unencrypted DLLs** that sit
next to the hash-named sidecar files in a real install but aren't part of that
hash+cipher scheme at all — `DevXUnityUnpackerUnityCommon.dll`,
`HelixToolkit.dll`, `HelixToolkit.Wpf.dll`, `ICSharpCode.TextEditor.dll`,
`Mon2.Cecil.dll`, `Mon3.Cecil.dll`, `Pngcs.dll` — plus `CrackSettings.json`,
`Library/`, `Localization/`, `StreamingAssets/`, and a font (`cambria.ttc`).
`RunDlls.Run()` (the dynamically-`CSharpCodeProvider`-compiled loader shim
`WholeProjectDecompiler`'s obfuscated call chain builds at runtime — see
FINDINGS.md §5) wraps all of this in `try {} catch {}`, so the missing-DLL
exception never surfaced anywhere until the `FirstChanceException` hook caught
it before that swallow.

Copying all of the above from `DevXCrack_1.0.9/` next to the built exe and
rerunning: the window opened. `FirstChanceException` also caught a handful of
`LicChecker.CheckXml`/Base64 `NullReferenceException`s during startup —
all internally caught by the app itself (expected: no real license data is
present; `CrackSettings.AllowOffline = true` by default, which is exactly what
lets it degrade gracefully instead of blocking on them).

**Still open:**

* **`A33D874E` (`DevXUnityUnpackerTools_Structures`, P2) was never actually
  needed** for this — the app ran and showed its window without it. Whatever
  uses it must be a feature path, not startup. Worth knowing if P2 is
  ever revisited: it may matter less than assumed.
* The rebuilt assemblies are **unsigned**, and `InternalsVisibleTo` had its
  `PublicKey=` stripped. Anything doing strong-name or identity checks at
  runtime will behave differently.
* `tools/payload.py pack` round-trips correctly and was used live in this
  investigation (rebuilt `DevXUnityUnpackerMain.exe` → packed → dropped in as
  `0000000000` → ran) — confirmed working, not just "in principle" anymore.
* Beyond the window opening, the app's actual features are unverified — this
  was a launch test, not a functional one.

---

## P4 — Tool hardening

Known gaps in the tools that shipped:

* **`unescape_ids.py` skips interpolation holes.** The state machine treats
  `$"..."` as one opaque literal, so an identifier escape inside `{...}` is left
  as raw ` ` and will not compile. Verified with a test case. There are 458
  interpolated strings in the decompiled output; none of them happened to
  contain an obfuscated identifier, so this never bit — but it is latent. The
  fix is to recurse into the braces of an interpolated string.
* **`fixdecompiled.py errors` needs a second pass that does not exist.**
  Widening accessibility reliably produces fallout — CS0507 (override widened
  access), CS1106 (extension method left in a non-static class), CS0273
  (accessor less restrictive than its property). Those were fixed by hand with
  throwaway scripts each time. They should be folded into the tool as a
  follow-up pass driven by the new build log.
* **No end-to-end pipeline.** unpack → decompile → sdkify → wire references →
  repair → build is currently a sequence of manual steps. It is deterministic
  enough to be one script.
* **`sdkify.py` overwrites the legacy `.csproj` in place.** Once it has run, the
  original is gone and the conversion cannot be checked. On one project its
  embedded-resource count disagreed with a `grep` over the same file; that was
  never chased down, and it may well have been the `grep` matching a closing
  tag. Writing alongside, or backing up first, would make it verifiable.

---

## P5 — Deobfuscation (not started)

Unpacking undoes the packing only. The recovered sources are still obfuscated
and are compilable, not readable:

* **Symbol names** remain `_0020_000A...`. Renaming them meaningfully needs
  either a type-usage-driven heuristic or manual work per subsystem.
* **Control-flow flattening** is untouched. The opaque predicates are constant
  and statically decidable, so a transform could fold them away — this would do
  more for readability than renaming.
* **The decoy string pool** is still in place, and its entries actively mislead
  (see [FINDINGS.md §5](FINDINGS.md)). Resolving the 416 strings to their real
  values and inlining them would help.

Order matters: fold the control flow first, then inline strings, then rename.
Renaming first makes the other two harder to reason about.

---

## P6 — dnSpy GUI plugin

`dnSpy.Decompiler.ILSpy.x` was removed from the solution. It needs
`dnSpy.Contracts.DnSpy` — the GUI contracts assembly — which was never
decompiled and is not in this repo. Only relevant if a dnSpy GUI is wanted; the
console decompiler works without it.

---

## P7 — Merge the loader chain, drop the encrypted payloads

Now that the sources are fully recovered and build clean, the runtime
packing/decryption `DevXUnityUnpackerRun.exe` still does on every launch (XOR
+ GZip, then hash-named-sidecar + custom-cipher, then a `CSharpCodeProvider`
runtime-compiled shim — all cataloged in FINDINGS.md §§2–5) serves no purpose
for *this* repo. It existed to hide the payload from static analysis; we have
the source. Keeping it just adds moving parts and forces every run to carry
along encrypted binary blobs nothing here can regenerate from source control.

**P7a — `DevXUnityUnpackerRun` → `DevXUnityUnpackerMain` — done.**
`DevXUnityUnpackerRun.csproj` now has a plain `<ProjectReference>` to
`Recovered/DevXUnityUnpackerMain`, and its `Program.Main()` calls
`Assembly.LoadFrom(".../DevXUnityUnpackerMain.exe").EntryPoint.Invoke(null, null)`
instead of decrypting `0000000000`. (Needed bumping `DevXUnityUnpackerRun`
from net40 to net472 — a lower-TFM project can't `ProjectReference` a
higher-TFM one under the SDK-style restore, and net472 is what the rest of
the .NET Framework chain in this repo already targets.) The original
`Memrestore`/`DeCompess`/`Copy` methods are left in `Program.cs`, unused —
they're the only surviving buildable copy of the original packer format
FINDINGS.md §2 documents; deleting them would make that section unverifiable
against real source. Verified end-to-end: built, ran with every supporting
file from `DevXCrack_1.0.9/` *except* `0000000000` in place, and the real
application window still opened — see ROADMAP.md P3 for how that test rig
works (short leash, `MainWindowHandle` polling, kill on sight).

**P7b — `DevXUnityUnpackerMain` → `DevXUnityUnpackerTools` (and its other
sidecar dependencies) — in progress, blocked on a pre-existing gap.** The
bigger piece. `DevXUnityUnpackerMain` resolves `DevXUnityUnpackerTools` and
friends through several more obfuscated hops: three CJK-permutation
dispatcher classes (`空記草` → `記草空` → `草記空`, see FINDINGS.md §5) ending
in a `CSharpCodeProvider`-compiled shim (`RunDlls`, dumped in full during the
P3 investigation) that does the hash-filename lookup, the custom cipher, and
`Assembly.Load`. Doing the same merge here means:

`DevXUnityUnpackerMain.csproj` already has a `<ProjectReference>` to
`Recovered/DevXUnityUnpackerTools`, and `Program.Main()` already calls
`new 例子子().子子例()` directly instead of the CJK dispatch chain. What's
left is getting `DevXUnityUnpackerTools.csproj` itself back to a clean build
(a second, independent P1a-merge pass found it was actually at 183 errors,
not 0 — see below), then re-running the P3-style monitored launch against the
merged chain to confirm the window still opens with no `0000000000`-family
file present at all.

Build-error cleanup this pass, 183 → 2:
* Seven files under `Recovered/DevXUnityUnpackerTools/` were silently
  0 bytes — `ICSharpCode.SharpZipLib.Zip.Compression.Streams`,
  `DevXUnityUnpackerTools._WPF`, `ICSharpCode.SharpZipLib.{Lzwrh,Zipco}`,
  `ICSharpCode.SharpZipLibdn`, `PropertyGridExdt`, `WASDdo`, `yg` (all
  `-.cs`). Same root cause as the P1a bug (§6): the file existed on both
  sides of the merge diff, so file-path-based diffing skipped it even though
  one side was empty. Fixed by re-copying the real content from the P1a
  scratch re-decompile. Each then had one dead decoy method (unbound-generic
  `<>`/`<,>` syntax, same pattern as FINDINGS.md §5) that needed the usual
  removal.
* `DMP4/-.cs` (a real, non-decoy Il2Cpp-to-Cecil metadata converter — not an
  obfuscation artifact) imports both `Mono.Cecil` and `Mon3.Cecil`, two
  separate recovered forks of the same library with identical type names,
  causing ~49 CS0104 ambiguous-reference errors. Fixed by dropping the
  unneeded `Mon3.Cecil`/`Mon3.Cecil.Cil`/`Mon3.Collections.Generic` imports —
  every ambiguous type this file actually uses resolves fine via the
  remaining `Mono.Cecil` import alone.
* `DMP4/-.cs` also needed a `Mono.Cecil.DefaultAssemblyResolver`, which
  `Recovered/Mono.Cecil` (the project this repo's Tools build actually
  references) doesn't have. It turns out to be a separately-recovered,
  older/incompatible vintage of Mono.Cecil than the other `Mono.Cecil/`
  recovery at the repo root — missing ~30 files including
  `BaseAssemblyResolver`/`DefaultAssemblyResolver`, and where file names do
  match, API shapes differ (`IAssemblyResolver` gained `IDisposable` and
  `string`-keyed overloads between the two vintages). Copying files across
  was a dead end (cascades into ~30 more errors from version-skewed
  internals like `Table.ImportScope` / `Type.IsGenericType` used as a
  method). Fixed instead with a small hand-written `IAssemblyResolver`
  implementation local to `DMP4/-.cs` — an in-memory register/resolve-by-name
  map, which is all the actual call site needs (no disk search directories
  are exercised by this code path).
* **`BrotliSharpLib.Brotli` re-decompiled with dnSpy, fixing the
  already-known placeholder (FINDINGS.md §6/§8).** ILSpy's `-t`/type-name
  decompile hangs on this 93k-line type indefinitely (confirmed again this
  pass — 120s timeout, no output); `dnSpy.Console --md <token>` (get the
  token via `[Reflection.Assembly]::ReflectionOnlyLoadFrom(...)`
  `.GetType("BrotliSharpLib.Brotli").MetadataToken` in PowerShell) completed
  in a few minutes and produced a *correct* dump — confirmed via reflection
  that the type really is `abstract sealed` (a C# `static class`), which the
  old ILSpy placeholder had wrong (`public class`, no `static`), not just
  incomplete. `tools/unescape_ids.py` converts dnSpy's raw `\uXXXX`
  identifier escapes to the `_XXXX` form the rest of the codebase uses.
  Three decompiler-rendering-quirk categories needed a manual pass after
  that, all mechanical, all in `Brotli.cs` only:
  - `*(ref X + offset)` and `(void*)(ref X + offset)` pointer arithmetic on
    fixed-buffer field access, where `ref` is not valid syntax in that
    position — dropped the spurious `ref` (101 + 4 sites).
  - Generic method calls rendered with a stray CLR arity suffix,
    `` Method`1<T>() `` instead of `Method<T>()` (2 sites).
  - `[FixedBuffer(typeof(elem), n)]` attribute on a compiler-generated
    nested buffer-backing field, instead of sugaring to the `fixed` field
    modifier dnSpy normally uses — converted `[FixedBuffer(typeof(T), N)]
    public BackingType field;` to `fixed T field[N];` (55 sites), then
    marked the 24 containing `struct`s `unsafe` (fixed fields require an
    unsafe context, and these structs had none of their own — everywhere
    else in this file marks `unsafe` per-method instead of per-type, so
    nested structs with only fixed-buffer members had never needed it
    before). Also re-ran `tools/fixdecompiled.py errors` for the resulting
    `private`/`protected` cross-file accessibility fallout (731
    declarations) and one more static-class-as-parameter-type widening,
    same as every other file in this recovery.
* **The "1500+ error eruption" mystery above is solved — and it was never
  really about `Collection<T>`.** Re-adding the plain `Collection<>`
  parameter (undoing the workaround) and instead removing the *actual*
  trigger — the `[DefaultMember("Item")]` attribute on `CustomString.cs`,
  which conflicted with a real indexer once one was added there — made the
  exact same ~1000-error backlog surface, then disappear again when the fix
  was reverted, reproduced twice. **Root cause: a declaration-level compile
  error anywhere in the compilation (a duplicate/conflicting attribute, an
  unresolvable member signature) suppresses Roslyn's method-body-level
  diagnostics for the entire project, not just the file containing it.**
  Every earlier theory in this list was tested against the wrong symbol —
  `Collection<T>` genuinely does resolve fine once `DefaultAssemblyResolver`
  is in place; it was guilty by association, having been the only
  declaration-level error left standing at the time. See
  [FINDINGS.md §6](FINDINGS.md) for the full mechanism and how to recognise
  it (an error count that *grows* after a fix is not a regression).
* **`BrotliSharpLib` swapped for the real open-source library**, superseding
  the dnSpy-recompile fix above entirely. It's
  [master131/BrotliSharpLib](https://github.com/master131/BrotliSharpLib)
  (MIT) — confirmed via matching method signatures against the recovered
  source — so the whole obfuscated 58-file directory was deleted and
  replaced with real upstream source verbatim; see
  [FINDINGS.md §8](FINDINGS.md) for the verification detail.
* **With the cascade unmasked and Brotli swapped, the project's true error
  surface was ~600 (not 1 or 183) — fixed down to 0, file by file.** Every
  fix follows one of the patterns now catalogued in
  [FINDINGS.md §6](FINDINGS.md) (decoy methods, `CS0571` explicit accessor
  calls, fixed-buffer-then-bogus-field-access, `Reverse().ToArray()`'s
  `Span<T>` ambiguity, name collisions from the fixed-length obfuscation
  pool colliding a local variable with an unrelated type/static member) —
  not re-narrated per-file here. Two things worth flagging specifically:
  - **A decoy-removal false positive, caught and left honest rather than
    papered over.** An early, pattern-driven pass deleted what looked like
    a decoy click handler in `MainForm.cs` (it matched the
    unresolvable-generic tell) but was actually a real, if buggy,
    "save packed version metadata" handler. Its two structurally different
    sibling handlers didn't give enough to confidently reconstruct the
    original body, so the menu item is left with no handler and an
    in-code comment explaining why, rather than fabricating behaviour.
  - **C# 14's contextual `field` keyword** broke a property named
    `WasModified` (returns `bool`) that happened to declare a local
    variable literally named `field` inside its accessors — the compiler
    now prefers the keyword (the auto-property backing field, typed to
    match the property, `bool` here) over the shadowing local in that
    position, producing baffling "cannot convert bool to X" errors with no
    connection to the real bug. Renaming the local resolved it immediately
    once recognised; the CS9273 warning-as-error naming the keyword by name
    is the tell.
* `DevXUnityUnpackerTools.csproj` now builds with **0 errors**, confirmed on
  a full clean rebuild (`rm -rf obj bin`, not just incremental).

**Sidecar cleanup, done for 6 of the 8 hashes.** With the six purely-library
sidecars building clean from source through the `Recovered/` chain, their
original encrypted copies in `DevXUnityUnpackerRun/` (and the stale
`bin/Debug/{net40,net472}/` test-staging copies alongside them — untracked,
just leftovers from P3's manual runtime testing) are redundant and removed:

| Hash | Project | Status |
|---|---|---|
| `2C74C997` | DevX.Cecil | 0 errors — **deleted** |
| `45DB8D9A` | ICSharpCode.NRefactory | 0 errors — **deleted** |
| `4382FEFE` | ICSharpCode.Decompiler | 0 errors — **deleted** |
| `33123090` | NAudio | 0 errors — **deleted** |
| `A8043F67` | ICSharpCode.NRefactory.CSharp | 0 errors — **deleted** |
| `E88D01F4` | Mono.Cecil 0.9.6.0 (`Recovered/Mono.Cecil`, confirmed by matching `AssemblyVersion` — *not* the two other, unrelated Mono.Cecil forks in this repo, `Mono.Cecil/` 0.10.3.0 and `Mon3.Cecil/` 0.11.2.0) | 0 errors — **deleted** |
| `8DAFE878` | DevXUnityUnpackerTools | 0 errors (P7b, this session) — **deleted** |
| `002203XLC` | not an assembly (plain-text GUID, see FINDINGS.md §4); consumer never located despite a dedicated search — doesn't fit the real hash-naming scheme or cipher, and no license/GUID-reading code anywhere in the buildable, runtime-verified source touches it | **kept**, unaddressed — likely decoy, or tied to the never-recovered `DevXUnityUnpackerTools_Structures` (`A33D874E`) |

`DevXUnityUnpackerTools_Structures` (`A33D874E`, P2) is separate from this
list of 8 — still absent, still confirmed not needed for the app to run
(P3). Rebuilding the whole `DevXUnityUnpackerRun → Main → Tools` chain after
the deletions reproduces the identical single `DMP4/-.cs` error and nothing
new, confirming none of the six were load-bearing for anything still in the
build.

---

## Deliberately not done

* **The 338-type adoption experiment was reverted.** It took `Tools` from 407 to
  1478 errors. The work is recoverable from the git history if the per-namespace
  approach in P1a needs a starting point.
* **Assemblies are not re-signed.** The original private key is not available,
  so this cannot be done faithfully.
* **`DevXUnityScriptManager`** compiles against Unity 2022.3, but the API
  adaptation was done to satisfy the compiler. The editor UI is not functionally
  verified, and the plugin was originally built against a much older Unity.
