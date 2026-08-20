# Il2Cpp Method Recovery

This document tracks the work to get usable method bodies out of Il2Cpp games.

## Background

Recovering an Il2Cpp game splits into two very different problems:

| Problem | Difficulty | State |
| --- | --- | --- |
| **Metadata recovery** — class, field, method signatures, attributes, inheritance | Solved | Works well at every level |
| **Method body recovery** — the actual statements inside each method | Hard | Partial, this document |

`Level2` (the default) solves only the first. It produces a "dummy dll": correct signatures, empty
bodies.

Two independent approaches attack the second, and they are complementary rather than competing:

| Approach | Output | Coverage | ARM64 | Cost |
| --- | --- | --- | --- | --- |
| **Cpp2IL IL recovery** (`Level3`) | Real C# | ~10-20% on x86, less elsewhere | Weak | Already paid for |
| **Ghidra decompilation** (`Level4`) | Pseudo C | Nearly every function | Mature | An hour or more per binary |
| Frida (`frida-il2cpp-bridge`, external) | Runtime traces and dumps | Only what executes | Android is well tested | Needs a running device |

The key insight behind `Level4` is that Il2Cpp keeps full type and method names in its metadata even
though the compiled binary has no symbols. AssetRipper already knows the address and managed name of
every method, so it can label every native function before decompiling. That is the same result the
community gets from Il2CppDumper plus manual Ghidra setup, without the manual steps.

Neither approach replaces the other. Cpp2IL produces C# that fits into the exported Unity project but
covers a minority of methods. Ghidra covers nearly everything but produces C, not C#.

## Pipeline

```
GameAssembly.dll / libil2cpp.so  +  global-metadata.dat
  └─ LibCpp2IL          parse metadata, map methods to native addresses
  └─ Cpp2IL             disassemble per instruction set (x86, ARMv7, ARMv8, WASM)
       └─ ISIL          instruction set independent IR (33 opcodes)
       └─ ISILControlFlowGraph + DominatorInfo
       └─ IlGenerator   ISIL -> CIL                                  (Level3)
  └─ AsmResolver        emit AssemblyDefinition
  └─ ILSpy              CIL -> C# source at export time
  └─ Ghidra headless    native code -> pseudo C, named from metadata (Level4)
```

## Script content levels

| Level | Behaviour |
| --- | --- |
| `Level0` | Scripts are not exported |
| `Level1` | Method bodies stripped (Mono only) |
| `Level2` | Default. Full methods for Mono, empty methods for Il2Cpp |
| `Level3` | Il2Cpp methods lifted back to CIL where possible |
| `Level4` | Everything `Level3` does, plus Ghidra decompiles the native binary |

## Known limitations

These are properties of the analysis, not of the wiring:

- Cpp2IL IL recovery is partial. Upstream reports roughly 10-20% of methods on x86 games.
- Non-x86 instruction sets do worse in Cpp2IL. ARMv8 covers a narrower set of operations than x86,
  which matters because shipped mobile games are ARM64. Ghidra does not share this weakness.
- `mscorlib` and any assembly whose name starts with `System` or `Unity` are excluded from Cpp2IL
  analysis for performance, so engine and BCL code stays stubbed.
- Recovered C# is not expected to compile. It is for reading, not rebuilding.
- Ghidra output is C, so it will not go into an exported Unity project as source.

## Level 4 setup

The quickest way is `Ghidra.bat` (or `Ghidra.sh`) in the repository root. It downloads Ghidra into
`./ghidra` the first time, reuses it afterwards, and launches AssetRipper with `GHIDRA_INSTALL_DIR`
already pointed at it. The download and the extracted installation are both git ignored.

Ghidra itself is Java, and its decompiler is a separate native executable that the Java side drives
over a pipe, so there is no library to reference from .NET. AssetRipper invokes the headless analyzer
as a child process; that is the only integration Ghidra offers.

Level 4 needs a Ghidra installation. It is found in this order:

1. `GhidraInstallation.OverrideDirectory`, if set programmatically.
2. The `GHIDRA_INSTALL_DIR` environment variable, which is Ghidra's own convention.
3. A `ghidra` directory next to the AssetRipper executable.

A directory counts as an installation when it contains `support/analyzeHeadless` (or
`analyzeHeadless.bat` on Windows). Ghidra 12 requires a JDK 21 runtime.

If no installation is found, Level 4 logs a warning and behaves exactly like Level 3, so it never
fails a load.

Output goes to `GhidraDecompilation_<timestamp>/` next to the executable, one `.c` file per assembly,
each function preceded by its managed name and address. `GhidraHeadlessRunner.Timeout` defaults to
four hours.

Expect the run to take an hour or more on a real game and to need a lot of memory. It runs as a
separate process so a hang or a crash cannot take AssetRipper down with it.

Measured on a 74 MB ARM64 `libil2cpp.so` from a shipped Unity 2022.3 game: Ghidra's analysis took 87
minutes, after which decompiling 120 methods took under a minute. Skipping analysis with
`-noanalysis` cuts the 87 minutes to under a minute, but the result is not usable: without it Ghidra
resolves no calls and loses register context, so every body is full of `func_0x...` and `unaff_...`.
Analysis is the cost of readable output. Re-running against an already analyzed project is fast,
which is what makes caching the project worth doing.

Ghidra's output is relayed to the log as it arrives, so a long run reports what it is doing rather
than going silent. The export script emits progress while naming functions and while decompiling,
which AssetRipper turns into lines like `Ghidra decompiling: 1250/48000 (2.6 %)`, throttled to one
every `GhidraHeadlessRunner.ProgressInterval`. Ghidra's own startup chatter, its per analyzer timing
table and the JVM banner are dropped; everything filtered out is still available at verbose level. On
failure the last 50 lines are written to the log for diagnosis.

## Phases

### Phase 0 — Enable Cpp2IL recovery (done)

- `IL2CppManager.RecoveryOutputFormat` defaults to `InstrumentedIlRecoveryOutputFormat`.
- `IL2CppManager.RecoveryProcessingLayers` defaults to the same layers as `Level2`.
- `Level3` is selectable in the settings UI.

### Phase 1 — Benchmark instrumentation (done)

`Il2CppRecoveryReport` records one row per method. Because Cpp2IL swallows its failures and releases
its analysis data before returning, the outcome is read back off the generated body by
`MethodBodyClassifier`:

| Outcome | Meaning |
| --- | --- |
| `Excluded` | Declaring assembly is skipped by Cpp2IL for performance |
| `NoBody` | Abstract or extern, nothing to recover |
| `Failed` | Recovery threw; the message is captured for grouping |
| `Minimal` | Recovery ran but lifted nothing, body returns a default value |
| `Recovered` | Real instructions were produced |

Only `Failed`, `Minimal` and `Recovered` count towards the success rate. Failure messages are
normalized (addresses and numbers collapsed) so the same defect groups into one reason.

The CSV has one row per method with `Assembly, Method, Outcome, InstructionCount, FailureMessage`.

### Phase 2 — Ghidra decompilation (done)

`Level4` writes a symbol file from Il2Cpp metadata, then runs Ghidra headless with a bundled script
that applies those names and exports the decompiled output grouped by assembly. The script is
embedded in `AssetRipper.Import` so it travels with the build.

### Address calibration

The address Il2Cpp reports does not always match the base Ghidra loads the image at. A PE is normally
loaded at the base its header asks for, so its addresses already line up; an ELF shared object is
loaded at an arbitrary base, so every address is short by exactly that much.

Getting this wrong is silent and total. On a real 74 MB `libil2cpp.so` the unshifted addresses all
still land inside the image, just on the wrong functions, so every method decompiles successfully and
every result is worthless. Measured on a sample of 3000 methods from that binary, the unshifted
addresses hit a function start 61 times out of 3000; shifted by the image base they hit 3000 out of
3000.

Rather than special casing the binary format, the script scores both interpretations against the
functions the analyzer already found and takes the winner. Every Il2Cpp address must be the start of
a function, so the correct interpretation matches nearly all of them. Only functions the analyzer
discovered by itself count, because functions this script named on a previous run would otherwise
vouch for whatever offset produced them.

### Function signatures

Names alone still leave Ghidra guessing parameter counts and types from the machine code, which is
where most of the noise in decompiled output comes from. The symbol file therefore also carries a C
prototype per method, which the script applies before decompiling. Il2Cpp passes the instance as an
implicit first argument and a MethodInfo pointer as an implicit last one, and both are included.

The effect on a two argument method, without and then with a prototype:

```c
int Foo(int param_1,int param_2)          // Ghidra's own guess
int Foo(int baseDamage,int multiplier)    // with the prototype applied
```

**A wrong prototype is much worse than none.** Ghidra locks parameter storage to whatever it is
given, so a mismatched return type can reduce an entire function body to a single return of an
uninitialised register. `GhidraTypeMapper` therefore refuses to emit a prototype unless every type
has a certain size: primitives map to the matching built in type, reference and pointer sized types
become `void *`, and anything whose size depends on something Ghidra has not been given is refused
outright. Methods without a prototype simply keep their name and Ghidra's own guess.

### Type layouts

Il2Cpp metadata carries every field's name and offset, so Ghidra can be given the layout of each type
and show a field access by name. Instance methods take a pointer to their declaring type, which is
what connects a body to its layout.

Fields whose type could not be mapped are left out rather than guessed, so they become a gap and the
offsets of everything after them still hold. A reference type begins with the object header so its
fields start past zero; a value type has no header and its first field sits at zero.

**A class's struct carries the fields it inherits as well as its own.** An offset is counted from the
start of the object rather than from the start of the class that declares the field, so a base class's
fields occupy the low offsets of every derived instance. Leaving them out was what made a read of an
inherited field decompile as arithmetic while the class's own fields read by name. A field the derived
class shadows keeps the derived name, and a value type is not walked upwards at all since it inherits
nothing to lay out.

**A reference type parameter is typed by the struct it points at.** A reference is a pointer whatever
it points at, so naming the struct costs nothing in size or calling convention, and completeness is not
required for the same reason: an incomplete layout names the fields it knows and the rest stays padding.
This is what lets a field read through a parameter come out as a member rather than as arithmetic, and
it applies to return types too, so a local assigned from a call is typed as well.

Enums are resolved to the primitive they are stored as. An enum is a value type in the metadata, but
the ABI passes its underlying field, so typing it carries none of the sizing risk of a real struct.

Measured on a shipped ARM64 game (Unity 2022.3, 74 MB `libil2cpp.so`, 85483 methods with an address):

| | |
| --- | --- |
| Methods given a prototype | 80816, 94.5 percent |
| Types with a layout | 4716, of which 1230 are complete |
| Field accesses in the sampled output | 1256, of which 21 remain unnamed |

### Passing value types by value

A method taking a `Vector3` cannot be typed without knowing exactly how large a `Vector3` is, and
guessing wrong misassigns the argument registers. The metadata answers this directly, in the instance
size a boxed value occupies: subtracting the object header, which is a class pointer and a monitor
pointer, leaves the size of the value itself. Measured against the metadata of a shipped game,
`Vector3` is 12 bytes, `Quaternion` 16 and `Bounds` 24.

The other size the metadata carries, `native_size`, is the marshalled one and is the wrong one to
use. It is absent for 504 of the value types in that game, and where it differs it describes a
different layout: `System.Char` marshals to one byte but occupies two, and `HandleRef` marshals to a
bare handle but holds a reference alongside it. Reading it as the size refused those 504 types
outright and sized 41 more wrongly.

Size alone is not enough, because the convention also depends on the field types: on ARM64 a struct
of four floats travels in floating point registers while one of four integers does not. A layout is
therefore only passed by value when it is **complete**, meaning every field maps to a type of known
size and laying those fields out the way a C compiler would reproduces the declared size exactly.
That last test is what separates a struct ending in alignment padding, which is fine, from one whose
size only fits because a field is missing, which is not. It holds for 1230 of 4716 types, but they are
the ones games actually pass around. A value type with no fields at all is described by its size alone:
it occupies the one byte that keeps two of them apart, and a byte cannot hold a floating point value,
so there is nothing left to infer.

Measured on 17 methods taking or returning such structs, giving Ghidra the prototype cut references
to uninitialised registers from 1007 to 32.

Primitives are mapped to their built in type before this is consulted, because the metadata describes
`System.Single` as a value type wrapping its own storage and it would otherwise become a one field
struct that merely behaves like a float.

A constructed generic is refused on its raw type alone, since its size depends on the arguments it was
constructed with. That reasoning only applies to value types: a `List<int>` is as much a pointer as any
other class, and refusing those cost 6884 type occurrences against the 3566 that value type
instantiations account for.

### What is left, and why it stays left

The 4667 methods still without a prototype are almost entirely blocked by two things, and neither has
the data to decide it safely.

Constructed generic value types account for 3566 of the refusals, `ReadOnlySpan<char>` and
`UniTask<bool>` among them. Il2Cpp metadata carries no layout for a generic type in any form: the
definition reports an instance size of zero and every one of its field offsets as zero, and a
constructed instance carries no fields of its own. The only route left is to compute the layout from
the declaration and the type arguments.

That was measured rather than assumed. Laying every complete value type out the way a C compiler
would, ignoring the offsets the metadata gives, reproduces the declared size for 998 of 999 and every
offset for 988. The failures are the compiler generated async state machines, whose fields Il2Cpp
reorders, and one type built on a fixed buffer. So the rule is close but not exact — and for a generic
type there is no declared size to check it against, which is precisely the check every other decision
here rests on. A wrong prototype costs more than a missing one, so these stay refused.

That reasoning holds for a layout we invent. It does not hold for the one Il2Cpp itself computes, which
is a different thing and is described under Unity's own runtime source below.

Generic parameters, `T` and `TState`, account for another 2841. Their size is not a property of the
method at all.

Two smaller ideas were measured and dropped. A struct larger than 16 bytes that is certainly not a
homogeneous float aggregate is passed as a pointer to a copy, so it needs no layout when it appears as
a parameter; that turned out to unlock 7 methods. Fixed buffers could be described as array fields,
which would complete 8 more types and unlock none.

### Explicit layouts

A type with an explicit layout compiles to a C++ union, and a struct definition cannot hold two fields
at the same offset. One member per range of bytes is therefore chosen, which makes the emitted file say
exactly what Ghidra will get instead of leaving the script to overwrite one field with the next. The
largest member is preferred, being the one most likely to span the union as declared, and among equals
one that is not floating point.

That last preference is the part that matters. A union holding both a float and an int does not travel
in floating point registers, so describing it by its floating point members alone would classify it
wrongly. `System.Numerics.Register` is the case in point: sixteen bytes overlaid as bytes, ints, floats
and doubles. It is described as two `ulonglong` fields, and a union that has no such member left after
the selection is refused rather than guessed at. The same reasoning follows a struct into a nested one,
so `v256`, which is two `v128` unions, is accepted because `v128` itself resolved to integer members.

### Nested value types

A struct made of other structs cannot be described until they are. `Bounds` is two `Vector3` fields,
so on its own it is neither complete nor usable in a prototype, and neither is anything taking a
`Bounds`. Resolving this in one pass would depend on the order types happen to appear in, so the
layouts are instead revisited until nothing more can be resolved: completeness spreads outwards from
the types made only of primitives. A value type cannot contain itself, so the process always settles.
Only a complete nested layout is embedded, since an incomplete one would leave the outer struct's
field types partly guessed, which is the exact thing the completeness rule exists to prevent.

Ghidra resolves a field's type by name against the structs already registered, so the layout file is
written with the embedded struct first. `SortByDependency` does that ordering, and the script fills
each struct and registers it before starting the next, because the data type manager keeps its own
copy and editing a struct after registering it has no effect.

On the same game this took complete layouts from 334 to 511 and prototypes from 79.2 to 87.0 percent,
6621 methods gained and none lost. Sampling the 97 methods that mention `Bounds`, 27 could be typed
before and all 97 after, and across that sample the accesses still decompiling as a raw offset fell
from 47 of 1256 to 21. Two levels of nesting resolve in the output: a `Bounds` argument decompiles
as `(newValue->m_Extents).y`, and a `Bounds` local as `local_88.m_Center.x`. Being 24 bytes, it is
returned indirectly, and Ghidra renders that correctly as `__return_storage_ptr__` only because the
layout is complete enough to classify.

The script also writes `decompilation_index.txt`, keyed by declaring type, method name and parameter
count. During export, `GhidraCommentTransform` looks each method up in that index and writes the
recovered pseudo C **inside** the method it belongs to, as the first thing in the body, so the exported
`.cs` carries both the C# signature and the real logic while a class still reads as a list of its
members rather than as pages of C between them. A method with no body, such as an abstract one, has
nowhere to put it and falls back to sitting above the declaration. Matching is by name rather than address because the assemblies handed
to ILSpy are generated and no longer carry native addresses.

The comment is C, not C#, so it cannot be a method body. Long bodies are truncated at 200 lines by
default to keep one method from burying the rest of the file.

### Unity's own runtime source

Everything above was worked out from the metadata and from what the decompiler produced. The runtime
that reads that metadata is itself C++ source, and Unity ships it inside the editor installer:
`libil2cpp`. [MlgmXyysd/libil2cpp](https://github.com/MlgmXyysd/libil2cpp) collects those trees, one per
Unity patch release, from 4.6.2f1 to 6000.0.5f1, with a table of the metadata version each one carries.

It has no license and the code is Unity's, so nothing from it can be copied into AssetRipper, which is
GPL-3.0. It is useful the way a specification is: it says what the numbers in the binary mean, and every
claim taken from it is worth confirming against the binary before it is relied on.

Read that way it settles two questions this document leaves open.

The first is the layout rule. `metadata/FieldLayout.cpp` is the whole algorithm in sixty lines, and the
file is byte for byte identical in 2022.3.32f1 and 6000.0.5f1. A field's alignment comes from its type,
packing lowers it rather than raising it, the running size starts at the parent's and an empty field
still advances it by one byte, and the final size is the running size aligned to the largest alignment
seen. That is the rule the 998 of 999 measurement was approximating, which means the remaining
disagreements are a difference from a known algorithm rather than an unknown.

The second is generics, and it reverses the conclusion above. `vm/Class.cpp` shows that a generic
instance does not read a layout from anywhere: `SetupFieldsLocked` inflates the definition's fields with
the type arguments and then runs the same `LayoutFieldsLocked` as every other type, and
`SetupFieldOffsetsLocked` writes back what came out. The metadata carrying no layout for a generic is
therefore not a gap to guess across; the layout is computed, and it is computed by an algorithm we can
reproduce. The verification we were missing comes with it, since the same code path produces every
non-generic layout, and those have declared sizes to check against — all 999 of them. An implementation
that reproduces 999 of 999 has been tested on far more evidence than a generic instantiation would ever
offer on its own. `UpdateInstanceSizeForGenericClass` also explains the zero instance size a generic
definition reports: nothing ever sets one, because nothing lays a definition out.

It also explains output we already have. `offsetof(Il2CppClass, static_fields)` works out to 0xb8 on 64
bit, and the decompiled output for the measured game contains 4434 reads shaped
`*(long *)(*(long *)PTR_DAT_… + 0xb8)`, about a tenth of the 41720 accesses still decompiling as a raw
offset. Those are static field reads. `Il2CppObject` is two pointers, and `Il2CppArraySize` puts its
elements at 0x20, which is the other arithmetic that shows up constantly. Describing those three structs
to Ghidra costs nothing and names all of it.

Two cautions, both measured. Version drift is real: `Il2CppClass` agrees between 2022.3.32f1 and
6000.0.5f1 up to and past `static_fields`, but `initializationExceptionGCHandle` changes from a
`uint32_t` to an `Il2CppGCHandle`, which is a pointer, so every field after it moves by four bytes on 64
bit. And the collection stops short of what is being ripped: its newest tree is 6000.0.5f1 and every
entry in its table reports metadata version 29, while the game measured here is 2022.3.62f2 and the
header of its `global-metadata.dat` says 31. The nearest tree is a guide to what is stable, not a
description of this binary.

Naming the class behind each of those globals is a separate problem and is not solved by reading the
source. `LibCpp2IlMain.GetAnyGlobalByAddress` only maps the pre-27 metadata usage table; on this game
every sampled address answered null, and the same addresses without the image base subtracted answered
with unrelated string literals, which is worse than nothing. What does exist is
`ApplicationAnalysisContext.GetOrCreateKeyFunctionAddresses`, which finds
`il2cpp_codegen_initialize_runtime_metadata` among some thirty runtime entry points. That function is
what fills those globals from a token, so the call site carries the answer.

The exported API is the cheap end of the same idea. The game exports 241 `il2cpp_` symbols and
`il2cpp-api-functions.h` declares 239, so Ghidra already names them from the dynamic symbol table and
only the prototypes are missing.

Ordered by what they would cost:

1. Register `Il2CppObject`, `Il2CppArraySize` and `Il2CppClass` as structs and type the globals that are
   dereferenced as classes. Bounded work, and it addresses a tenth of the remaining raw offsets.
2. Implement `FieldLayout::LayoutFields` exactly and require it to reproduce all 999 declared sizes and
   offsets before it is used for anything. If it does not, the difference is the answer to the async
   state machine cases as well. **Done — see below.**
3. Only then lay out constructed generic value types by inflating their definitions, which is the 3566
   refusals. Generic parameters stay refused regardless; their size is not a property of the method.

### Running the layout rule rather than approximating it

`Il2CppFieldLayout` is that algorithm. It is the runtime's, not a reconstruction: a field's alignment
comes from its type, packing lowers that alignment and never raises it, the running size starts where
the base class's fields stopped rather than where the base class ended, a field of no size still
advances the type by a byte, and the type ends at its furthest field rounded up to the strictest
alignment any field asked for. A value type's own offsets are counted from the value while the runtime
counts from the boxed object, so the header is added back and one calculation covers both kinds.

Only a handful of decisions are not in `FieldLayout.cpp` itself and had to be read out of `Class.cpp`
around it. A value type's alignment starts at one rather than at its parent's, since the value is not
an object. Packing is dropped entirely for a type holding a reference, because such a type is not
blittable and a misaligned pointer would cost more than the packing saves. A declaration that states
its own size keeps it, which is what a fixed buffer is: one declared element and a size covering the
rest. A type with no instance fields at all is whatever its definition records, which is the only thing
that can be right for `System.Array`, whose size is an array's bounds and length on the C++ side rather
than anything managed. And the instance layout has to be published before the static one is worked out,
exactly as the runtime marks the type sized between the two, or a type with a static field of its own
type — `System.Guid.Empty`, `System.DateTime.MinValue` — waits on itself and both are refused.

`Il2CppFieldLayoutReport.Verify` is the check, and it has to be re-run per game rather than assumed. On
the same ARM64 build, 9119 types have a recorded layout to compare against:

| | matched | disagreed |
| --- | --- | --- |
| Instance size | 8251 | 82 |
| Field offsets | 8331 | 82 |
| Static storage size | 8655 | 0 |

454 more were refused rather than described, which is not a disagreement. Every one of the 82 that
disagreed inherits from a constructed generic, so the calculation is exact everywhere it has the data:
2284 of 2284 value types, including the async state machines the earlier approximation could not
reproduce, and 5967 of 5967 reference types that do not descend from a generic. The static sizes are an
independent check on the same code, since a type's static storage is laid out by the same rule and
recorded separately.

Two details of the run are worth keeping. 68 types put their first field inside the size their base
class declared, which is the Itanium ABI reusing the base's trailing padding; all 68 are right, and all
68 would be wrong under the Microsoft rule, so the ABI is a real distinction rather than a theoretical
one and is taken from whether the binary is a PE. Packing, on the other hand, is barely exercised: two
types in the whole game carry a packing directive.

Nothing consumes this yet. It exists so that the next step — inflating a generic definition with its
type arguments and laying the result out — is a step onto something already checked, and the 82 types
that disagree are how that step will be checked in turn, since they have recorded layouts that only a
correct generic layout can reproduce.

### Phase 3 — Measure on a real game (next)

This phase is a decision gate, not a commitment to improve anything.

1. Load a build at `Level3` and collect the recovery CSV.
2. Load the same build at `Level4` and review the Ghidra output.
3. Compare architectures. Building the same game for both ARM64 and x86_64 shows how much the
   instruction set is costing Cpp2IL, and confirms Ghidra is unaffected.
4. Diff recovered output against original source where available. Any first party title is a ground
   truth corpus that outside contributors do not have.
5. Rank Cpp2IL failure reasons by frequency from the CSV.

**Gate:** if Ghidra covers what is needed, further Cpp2IL work is hard to justify. Phase 4 only makes
sense if C# output specifically is required.

### Phase 4 — Cpp2IL improvements (unscheduled, low priority)

Deprioritized in favour of Ghidra, which reaches far higher coverage for far less effort. Only worth
starting if C# output is a hard requirement and Phase 3 shows a concentrated set of failures.

- Try `NewArmV8InstructionSet` instead of `Arm64InstructionSet`. `IL2CppManager` currently hardcodes
  `useNewArm64 = false`. This is the cheapest experiment with the largest potential effect on ARM64.
- Work the ranked failure list from Phase 3. ISIL has only 33 opcodes, so the surface area is finite.
- `AsmResolverDllOutputFormatIlRecovery.WriteControlFlowGraph` dumps a Graphviz CFG for one method.

`IlGenerator` is `internal` to Cpp2IL. Changing lifting behaviour means forking Cpp2IL and building
the package, not patching AssetRipper.

### Phase 5 — Possible extensions (unscheduled)

- Cache Ghidra results keyed by binary hash, so a re-import does not pay the hour again.
- Improve key matching. Declaring type, method name and parameter count is unambiguous for the vast
  majority of methods, but overloads that differ only by parameter type collide and will get the
  wrong comment attached.
- Feed the pseudo C through an LLM refinement pass for readability. Research on this (LLM4Decompile,
  D-LiFT) is promising, but the models reconstruct loops and array indexing unreliably, so the output
  cannot be treated as a source of truth.

## Configuration

| Setting | Default | Purpose |
| --- | --- | --- |
| `ScriptContentLevel` | `Level2` | `Level3` for IL recovery, `Level4` to add Ghidra |
| `GHIDRA_INSTALL_DIR` | unset | Where to find Ghidra |
| `Il2CppRecoveryReport.Enabled` | `true` | Set false to skip statistics collection |
| `GhidraHeadlessRunner.Timeout` | 4 hours | How long to wait for the analyzer |
| `IL2CppManager.RecoveryOutputFormat` | `InstrumentedIlRecoveryOutputFormat` | Replaceable |
| `IL2CppManager.RecoveryProcessingLayers` | Attribute analysis + override name fixer | Replaceable |

## Licensing

Level 3 is a paid feature of the upstream project, but the implementation lives in the public
`AssetRipper.Cpp2IL.Core` package and AssetRipper itself is GPL-3.0. Wiring it up in a fork is a
modification of GPL software using published open source packages, not a circumvention of any
protection mechanism; `GameFileLoader.Premium` is documented in the source as affecting UI only.
Anyone relying on this in production should still consider supporting upstream, whose paid build may
carry improvements beyond the public package.

Ghidra is public domain software released by the NSA and is not bundled here; Level 4 only invokes an
installation the user provides.
