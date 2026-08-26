# Roadmap

What is finished, what is not, and how to pick up each piece.

Analysis lives in [FINDINGS.md](FINDINGS.md); build instructions in
[BUILD.md](BUILD.md).

---

## Status

| | state |
|---|---|
| Root solution `Decompiled.sln` | 37 projects, **0 errors** |
| Unpacking `0000000000` | done, verified against the original `Memrestore` |
| Unpacking the hash-named sidecars | done, all 7, verified two independent ways |
| File identification | done, 9 of 9 |
| Rebuilding recovered assemblies | **7 of 8 at 0 errors** |
| `DevXUnityUnpackerTools` | **407 errors** — see P1 |
| Running anything that was recovered | **never attempted** — see P3 |
| Deobfuscation | not started — see P5 |

---

## P1 — Finish `DevXUnityUnpackerTools`

**Why it matters.** This is the actual product: 20 MB, 11345 types. Everything
else is a support library.

**Where it stands.** 407 unique errors:

| errors | code | cause |
|---|---|---|
| 288 | CS0246 | types the decompiler never emitted (338 of 10347) |
| 49 | CS0104 | ambiguous references — not yet looked at |
| 29 | CS0721 | `static class` as a parameter type, second round |
| 12 | CS0507 | overrides widened by the accessibility pass |
| 10 | CS0051 | inconsistent accessibility, knock-on |
| 9 | CS7003 | not yet looked at |

### P1a — Recover the 338 missing types

Two routes, in order of preference:

**Fix the decompiler instead of working around it.** We own the ILSpy source —
`DecompilerPreFi/`. It writes namespaces in parallel and drops the ones that
throw, silently, leaving a 0-byte `.csproj`. Adding exception logging to the
project writer would name the failing types and the exception, and it is likely
the same kind of bug already found and fixed in
`SwitchOnNullableTransform.cs:174`. This is the highest-value option: it fixes
the tool for every future assembly, not just this one.

**Or extract per namespace with dnSpy.** Extracting per *type* was tried and
reverted — the dumps are not self-contained. Per namespace should work, but two
cases need handling first:

* types in the global namespace (`_global`), and
* a namespace literally called `as`, which is a C# keyword and must be emitted
  as `@as`.

Note also that reading the token list with `while IFS=$'\t' read` on a CRLF file
puts a `\r` in the output filenames — strip it.

The template that worked is `BrotliSharpLib`: dump with
`dnSpy.Console --md <token>`, convert identifiers with `tools/unescape_ids.py`,
then run `tools/fixdecompiled.py textual`. That removed 561 errors on its own.

### P1b — The remaining ~120 errors

CS0104 (49) and CS7003 (9) have not been examined at all. CS0721/CS0507/CS0051
are the familiar accessibility and static-class rounds and should clear with
another error-driven pass, but that pass currently needs manual follow-up —
see P4.

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

## P3 — Runtime verification (nothing has been run)

Every result so far is "it compiles" or "the bytes match". **No recovered
assembly has been executed.** Open questions:

* Does the rebuilt `DevXUnityUnpackerRun.exe` launch? It resolves its payload
  through `Application.StartupPath`, so `0000000000` and every sidecar must sit
  next to the *built* exe, not in the project folder. This was never set up.
* The rebuilt assemblies are **unsigned**, and `InternalsVisibleTo` had its
  `PublicKey=` stripped. Anything doing strong-name or identity checks at
  runtime will behave differently.
* `tools/payload.py pack` round-trips correctly, so in principle the repaired
  sources could be rebuilt, repacked, and dropped back in place of the
  originals. That has not been tried and is the real end-to-end test.

Start small: copy the nine original files next to the built stub and see whether
it gets past `Assembly.Load`.

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

## Deliberately not done

* **The 338-type adoption experiment was reverted.** It took `Tools` from 407 to
  1478 errors. The work is recoverable from the git history if the per-namespace
  approach in P1a needs a starting point.
* **Assemblies are not re-signed.** The original private key is not available,
  so this cannot be done faithfully.
* **`DevXUnityScriptManager`** compiles against Unity 2022.3, but the API
  adaptation was done to satisfy the compiler. The editor UI is not functionally
  verified, and the plugin was originally built against a much older Unity.
