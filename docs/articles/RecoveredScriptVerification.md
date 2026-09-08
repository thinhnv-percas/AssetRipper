# Verifying recovered scripts against the source

Three of the measurement games ship the Unity source their APK was built from, so the recovery can be
marked rather than estimated. This is how that check is run, what it currently says, and — file by
file — what is wrong and what only looks wrong.

`Test/Scripts/audit_recovered_scripts.py` does the mechanical half: it proves no member was lost and
counts every diagnostic and every known-bad C# shape per file, so the reading starts with the files
that need it. `Test/Scripts/compile_recovered_scripts.sh` does the half that cannot be argued with:
it compiles the exported scripts and reports what the compiler rejects. The judgement is still a
person's.

## Running it

```
# rip the game
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output Test/Output --log Test/AssetRipper.log Test/Input/Impostor

# clone what it was built from
git clone --depth 1 https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro.git /tmp/impostor-src

# compare
python3 Test/Scripts/audit_recovered_scripts.py \
  --source /tmp/impostor-src/Assets \
  --output Test/Output/Impostor/Assets/Scripts/Assembly-CSharp
```

The script skips what is not in a player build — `ThirdParties`, `GoogleMobileAds`, `Spine`,
`Plugins`, any `Editor` directory, and anything inside `#if UNITY_EDITOR` — and it strips the
attributes the recovery injects before comparing, since those are not part of the source.

## Compiling it

A grep guesses at what will not compile. A compiler knows. The rip output ships every assembly it
recovered and every one it stubbed under `AuxiliaryFiles/GameAssemblies`, so the exported C# can be
compiled against exactly the metadata it was recovered from:

```
Test/Scripts/compile_recovered_scripts.sh Test/Output Assembly-CSharp
```

The script finds the assemblies beside the scripts, references all of them but the one being
compiled, runs Roslyn directly with `-nostdlib -noconfig` (the game's own `mscorlib` is among the
references, so the SDK's must not be), and prints the error count followed by a table of C# error
codes with one example each. `KEEP_LOG=<path>` keeps the full log; the exit status is non-zero when
there are errors, so it can gate a change.

Three things about what it measures.

It compiles against the *stubbed* framework rather than the real Unity assemblies, and a stub carries
only what the game's il2cpp metadata carries — a member Unity strips from the build is absent here
even though the export would compile against a real Unity install.

It compiles every file as one assembly, which is stricter than the exporter needs to be:
duplicate-attribute and accessibility rules only bite in source.

And **a declaration error hides every body error in the assembly.** Roslyn binds declarations first
and stops there if that stage failed, so two missing attribute types made Pinata read as "3 errors"
when its real count is 7139 — and silenced every analyzer, since none of them had a semantic model to
work with. Both were `StructLayoutAttribute`, which is a pseudo-custom attribute: it lives in a type's
flags rather than as an attribute, so a stripped build carries no such type for the exported
`[StructLayout(...)]` to name. The harness shims it and `LayoutKind` in source. Any future
declaration error will mask the same way, so a suspiciously small error count is a reason to read the
log rather than to celebrate.

| | Pinata | RunFromZombies | Impostor |
|---|---:|---:|---:|
| files compiled | 1108 | 22 | 63 |
| errors, first run | 4999 | 2 | 765 |
| errors, declaration stage unmasked | 7139 | 2 | 765 |
| errors now | 7066 | 2 | 603 |

What the first run found, in the order it found it:

- **4996 of Pinata's 4999 were the ripper's own attribute injection.** A member that carries several
  attributes Cpp2IL could not read gets an `AttributeAttribute` for each — a Unity field with both a
  `Tooltip` and a `Range` gets two. Duplicate custom attributes are legal in metadata, so the
  recovered assembly was always valid; C# rejects the second unless the attribute type declares
  `AllowMultiple`, and the export is C#. Fixed by injecting that type through
  `AttributeInjectionUtils`, which applies `AttributeUsage` for every other injected attribute.
- **Pinata's `StructLayoutAttribute` errors were not 3 of 4999, they were the reason the other 7136
  were invisible.** See the declaration-stage note above.
- **RunFromZombies' 2 are both stripped members**, in one file. `Math.PI` is how ILSpy renders the
  constant `0.017453292f`, and `Quaternion.Euler(Vector3)` is the public method the recovery names in
  place of the inlined `Internal_FromEulerRad`; the game calls neither, so IL2CPP stripped both out of
  the assemblies the stubs are built from. Sixteen recovered scripts, no diagnostics, and nothing the
  compiler objects to that a real Unity reference would not resolve.
- **180 of Impostor's were `List<object>._size`**, the second half of the trivial-accessor pairing —
  see the defect catalogue below. 146 are now gone; the 34 that remain are *writes* to `_size`, which
  no getter can stand in for.
- **`x._002Ector()`, 51 on Pinata and 21 on Impostor**, is a constructor called on an object that
  already exists — a member no type has. 13 of Impostor's and 24 of Pinata's were the leftover half of
  an allocation whose constructor call could not be fused, and are now either fused or dropped; see
  the defect catalogue.
- **The rest of Impostor's 603 is one defect**, section 5 of `ROADMAP.md`: a local nothing typed is
  declared `object`, and every use of it is a cast that C# does not have. 329 `CS0030`, 18 `CS0037`,
  10 `CS0019` and 5 `CS0165` are all that, and the `nint` in `Cannot convert type 'GamePlayController'
  to 'nint'` is the tell. 48 `CS0122` are a separate item: `ObscuredInt`'s private fields, written
  directly because il2cpp inlined the struct's construction, from a game plugin assembly in which they
  are private and another assembly's code is reaching them. The largest single class on Pinata is
  4721 `CS1061` for `List<T>._items` and the rest of what il2cpp inlined out of the framework, which
  is the write half of the accessor problem below.

## What Microsoft.Unity.Analyzers says

Set `ANALYZERS` to a directory of analyzer assemblies and the same script runs them:

```
curl -sSL -o a.nupkg https://www.nuget.org/api/v2/package/Microsoft.Unity.Analyzers
unzip -q a.nupkg -d unity-analyzers
ANALYZERS=unity-analyzers/analyzers/dotnet/cs Test/Scripts/compile_recovered_scripts.sh Test/Output
```

It is worth running because its rules are about Unity's own contract — a message with the wrong
signature, a `GetComponent` for a type that is not a component, a `SerializeField` on something that
cannot be serialised — which is the kind of thing a recovery gets wrong and a compiler does not mind.
Most of its rules ship at Info severity, which the command line compiler does not print, so the script
raises every `UNT` rule to warning; without that the first run reads as a clean sheet and is a silent
one.

| | Pinata | RunFromZombies | Impostor |
|---|---:|---:|---:|
| UNT findings | 224 | 35 | 21 |
| attributable to the recovery | 0 | 0 | 0 |

Every finding is in the source too, where there is source to check:

- **`UNT0021`, 143 + 27 + 15** — a Unity message that is private rather than protected. Every Unity
  script ever written trips this; it is a style rule and says nothing about the recovery.
- **`UNT0001`, 6 + 3 + 2 empty messages** — read against the source, every one is empty there too:
  `ObsJumper`, `ObsDropper` and `ZambiesMovement` all have `void Start() { }`, and Impostor's
  `TestCube` has an empty `Start` and an empty `Update`.
- **`UNT0013`, 4 on Impostor** — `[SerializeField] public SkeletonAnimation _animation;` and
  `[SerializeField] private readonly string[] skinList`, both exactly as written in `Imposter.cs`, and
  `[SerializeField] public GameObject effect;` in `Box.cs`.
- **`UNT0005`, 2 on Pinata** — `Time.deltaTime` inside a `FixedUpdate`, in EpicToonFX's
  `ETFXProjectileScript`. The asset does that.
- **`UNT0039`, `UNT0041`, `UNT0025`, `UNT0028`, `UNT0016`** — `GetComponent` without
  `[RequireComponent]`, `Animator.SetFloat` with a string rather than a hash, `Input.GetKey` with a
  string, an allocating physics call, `Invoke` with a method name. All source-level style, all in Obi's
  and EpicToonFX's samples and in the games' own scripts.

Nothing fires from the families that would indicate a recovery defect — `UNT0006` for a message with
the wrong signature, `UNT0010` and `UNT0011` for a component constructed with `new`. That is a real
result, and it is the one the analyzers were run for.

## Nothing is missing

The first question is whether a member was lost, because everything else is a matter of degree.

| Game | Source files in the build | Members declared | Present in the recovery | Absent |
|---|---|---|---|---|
| `Impostor-Sort-Puzzle-Pro` | 35 | 177 | 177 | **0** |
| `RunFromZombiesFullProject` | 16 | 9 | 9 | **0** |

So the thing to read for is fidelity *inside* the bodies, not coverage. Two notes on why an earlier
count of this looked worse than it is:

- **The exporter writes one type per file.** `UserResource.cs` declares four types in the source and
  comes back as `UserResource.cs`, `UserResourceItem.cs`, `UserResourceCollectionItem.cs` and
  `UserResourceInventory.cs`. Comparing file against file makes six members of `UserResource` look
  missing when they are one directory over. The comparison has to be per assembly.
- **`#if UNITY_EDITOR` is not in the build.** `GameHelper.GetAllScenes`, `GetAllAssets`, `PingObj`,
  `Hide` and `Show` are all inside that guard, so they are correctly absent.

## Where each file stands

`Impostor-Sort-Puzzle-Pro`, ordered by how much is wrong. `unresolved` is
`Unmanaged memory load`, `not found` is `Method not found`, `mismatch` is an ILSpy
`Expected X, but got Y` comment, `nint` is a value used as a native integer.

| File | lines | unresolved | not found | mismatch | nint |
|---|---:|---:|---:|---:|---:|
| `DataController.cs` | 2647 | 198 | 0 | 194 | 304 |
| `SingletonMono.cs` | 934 | 136 | 70 | 145 | 115 |
| `SingletonMonoDontDestroy.cs` | 833 | 120 | 50 | 146 | 107 |
| `Extensions.cs` | 742 | 63 | 25 | 76 | 96 |
| `UserResourceCollectionItem.cs` | 598 | 77 | 5 | 68 | 55 |
| `UserResourceItem.cs` | 391 | 45 | 3 | 47 | 26 |
| `CSVSerializer.cs` | 957 | 38 | 10 | 42 | 34 |
| `GameHelper.cs` | 547 | 28 | 7 | 53 | 48 |
| `GUIManager.cs` | 928 | 10 | 2 | 46 | 8 |
| `ResourcesUtil.cs` | 369 | 7 | 19 | 21 | 7 |
| `Item.cs` | 222 | 0 | 8 | 35 | 15 |
| `CSVHelper.cs` | 820 | 0 | 7 | 30 | 31 |
| `CSVReader.cs` | 343 | 14 | 0 | 21 | 23 |
| `EventDispatcher.cs` | 280 | 14 | 3 | 13 | 16 |
| `GraphicController.cs` | 422 | 18 | 4 | 6 | 9 |
| `GamePlayController.cs` | 385 | 11 | 0 | 13 | 5 |
| `Common.cs` | 150 | 3 | 6 | 4 | 6 |
| `UserResourceInventory.cs` | 70 | 3 | 5 | 4 | 2 |
| `ItemResources.cs` | 65 | 4 | 0 | 6 | 0 |
| `AdManager.cs` | 411 | 2 | 0 | 7 | 2 |
| `ItemDistinc.cs` | 45 | 1 | 4 | 1 | 0 |
| `RandNumber.cs` | 61 | 2 | 0 | 4 | 1 |
| `UserResource.cs` | 40 | 3 | 0 | 3 | 0 |
| `Box.cs` | 411 | 2 | 0 | 2 | 2 |
| `ItemStack.cs` | 43 | 1 | 0 | 3 | 0 |
| `ItemArtifact.cs` | 54 | 1 | 0 | 2 | 0 |
| `TimeInGame.cs` | 192 | 0 | 0 | 2 | 3 |
| `UtilityGame.cs` | 136 | 0 | 0 | 1 | 0 |
| **TOTAL (46 files)** | **13948** | **801** | **228** | **995** | **915** |

**Eighteen of the 46 files carry no diagnostic at all**: `DataCreatePlayer`,
`EventDispatcherExtension`, `EventID`, `Extension`, `GDPR`, `GameController`, `GameManager`,
`Imposter`, `Inventory`, `ItemBase`, `ItemInventory`, `Log`, `Movement`, `RatingReviewManager`,
`TestCube`, `TypeResources`, `TypeResourcesValue`, `TypeScene`. All sixteen of
`RunFromZombiesFullProject` are in that state.

Two things the table makes obvious and reading one file at a time does not:

- **`SingletonMono` and `SingletonMonoDontDestroy` are 59 and 70 source lines and come back as 934
  and 833.** They are generic base classes, so every instantiation's shared body folds onto them and
  they inherit the defects of all of it. Half the `Method not found` in the whole assembly is in those
  two files.
- **`DataController` alone is a fifth of everything.** It is the largest source file (360 lines) and
  the one with the most inlined `List<T>` and `Stack<T>` work, which is where the untyped locals come
  from.

## Why one file is seven times its source

`DataController.cs` is 360 source lines and 2690 recovered ones. The ratio is not uniform, and where it
comes from is worth knowing before reading any large recovered file.

Per method, against the source method it came from:

| Method | source | recovered | ratio |
|---|---:|---:|---:|
| `SetBackground` | 12 | 14 | 1.2× |
| `Start` | 7 | 6 | 0.9× |
| `LoadMap` | 29 | 34 | 1.2× |
| `availableRandomList` | 13 | 59 | 4.5× |
| `setUpRandomList` | 40 | 137 | 3.4× |
| `GenarateDataMap` | 66 | 361 | 5.5× |
| `AddOneBox` | 40 | 344 | 8.6× |
| `GenarateRandomMap` | 66 | 815 | 12× |
| `GenarateRandomDataMap` | 65 | 846 | 13× |

So four methods are near 1:1 and three account for 2005 of the 2647 lines. The expansion is not a
property of the recovery, it is a property of what those three methods do: nested loops over
`Stack<int>` and `List<Stack<int>>`, six `new Vector3(...)`, and a ternary inside a constructor
argument — all of which il2cpp inlines.

Taking the worst one, `GenarateRandomDataMap`, and accounting for all 846 lines:

| Lines | What |
|---:|---|
| 192 | **local-to-local copies that were never coalesced** — `num11 = num31;`, `flag8 = flag12;`, `vector = vector2;` |
| 120 | flag, `num` and `obj` temporary declarations |
| 99 | braces and blanks |
| ~90 | the ARM64 flag arithmetic — `flag = num < 0`, `flag = !flag`, `num & num` — that `FlagConditionRecovery` did not fold |
| 81 | diagnostic placeholder calls |
| 13 | inlined `List`/`Stack` internals (`._size`, `._items`, `._version`) |
| 8 | `goto` and labels |
| 7 | per-member `Vector3` stores |
| ~236 | the method's own statements, one per operation, with no expression nesting |

The largest single item is not the game's code and not the inlining: it is **192 lines of copies a
compiler would never write.** They come from SSA destruction — one copy per merged version on each
predecessor edge. They sit in groups before a `break` at a label:

```csharp
IL_16f2:
num11 = num31;
randomLevels = randomLevels2;
num2 = (nint)typeof(Quaternion);
break;
```

That is a loop's back edge written out by hand.

**And they cannot be coalesced away.** `CopyCoalescer` now reports its three outcomes, and on this game
they are 74262 copies merged, 18738 kept **because the two locals are live at once**, and 3200 kept
because their types differ. Interference is what a loop-carried value *is*: `num` is live at the point
`num + 1` is computed, so the copy the back edge needs can never be merged. Widening the pass to
consider copies between different registers — the textbook formulation, letting the interference graph
decide — was measured and made the output worse; comparing the two ends' types by name rather than by
reference identity was the part worth keeping, and merges 1098 more.

The second number worth quoting was that **the recovered file nested 27 levels deep**, with 41
`goto`s. It was tempting to read that as a consequence of the copies, since that is where the copies
appear — it was not.

**It was the null checks.** A dozen of them branching to one `throw` make that block a join, so SSA
gives it a phi for every register live there — and the matcher that recognises a check's epilogue
walked the block's instructions and gave up on the first thing that was not a Nop, a Return, a Throw
or a Newobj. A phi is none of those, so the epilogue went unrecognised and every check pointing at it
survived: thirty-seven of them converging on one throw in this one method. ILSpy structures a graph
but does not duplicate blocks, so a check it cannot remove can only be a jump.

A phi is not code — it is the merge of the predecessors' values. Skipping them, and following a
landing block that holds nothing but phis to whatever it falls into, is the whole fix:

| | before | after |
|---|---:|---:|
| `DataController.cs` code lines | 2647 | **1253** |
| `goto`s in it | 41 | **15** |
| labels | 12 | **5** |
| deepest nesting | 27 | **19** |
| `GenarateRandomDataMap` | 846 | **249** |
| `GenarateRandomMap` | 815 | **238** |
| `GenarateDataMap` | 361 | **225** |
| the whole assembly | 13891 | **10864** |
| its diagnostics | 2030 | **1694** |
| Pinata's unresolved loads | 12445 | **11215** |

`GenarateRandomDataMap` went from 13× its source to 3.8×, and now opens with the source's own first
four statements in order. What is left in it is the untyped-locals problem and the unresolved loads,
not structure.

Two things were tried on the way and are recorded as worth nothing. **Emitting the blocks in address
order** rather than the order the graph created them — on the theory that a loop header split out late
lands after its own body — measured worse, taking `DataController`'s `goto`s from 15 to 21; the
generator gives every fall-through an explicit `br`, so the order is free, and ILSpy does better with
the graph order than with the machine's. **Coalescing copies across different registers** also
measured worse, and the copies that matter cannot be coalesced anyway: `CopyCoalescer` reports 74262
merged against 18738 kept *because the two locals are live at once*, which is what a loop-carried
value is.

One thing did come out of the throw investigation. A throw reaches nothing, but the graph is built
from the lifted ISIL where a throw is still a call to an il2cpp raise helper — so its block fell
through, and with an entry per check that made it an irreducible loop. `UnreachableAfterThrow` runs
after SSA destruction, where the throw exists, and detaches it.

## The defect catalogue

Every distinct shape, with what produces it. Counts are over `Impostor`'s `Assembly-CSharp`.

### Fixed

| Shape | Was | Now | Cause |
|---|---:|---:|---|
| `(ref *(_003F*)(&a)) - (ref *(_003F*)b)` | 148 across 3 games | 0 | Integer arithmetic reached `sub` with a managed pointer on one side and an object reference on the other. Each such operand is converted to a native integer first. |
| `ref *(T*)x` in this assembly | 374 | 0 | The same. |
| `(Stack<object>.Enumerator)0` | 33 | 0 | A value type local zeroed by an integer 0. `initobj` is what zeroing a value type is. |
| `toptarget.y = default(float)` | every `Vector3` parameter | 0 | AAPCS64 passes a float aggregate in V0–V3 and only V0 could be named as the parameter. `DefineFloatAggregateParameters` names the rest. |
| `array.Length < i \|\| (object)(array.Length - i) == null` | every bounds check of that shape | 0 | The condition is an `Or` of two flags that are one comparison, and the chase stopped at the `Or`. |
| `button.m_OnClick` | 12 | 3 | A trivial property is inlined, so the field is what the body names. The accessor is measured from the getter. |
| `if ((nint)obj >= gpc.maxValueCols)` on a loop counter | — | 0 | A comparison against a typed `int` now types the untyped side, which is the seed the integer half of the type fixpoint was missing. |
| `list._size` read | 180 | 34 | The accessor pairing could not see a field of a generic instance: its `BackingData` is null, its declaring type is the instantiation, and every field of a generic type is at offset 0 in the metadata. It is measured on the definition against a computed offset, and the getter instantiated on the same arguments. The 34 left are writes. |
| `[AttributeAttribute]` twice on one member | 4996 | 0 | Legal in metadata, rejected by C#. The injected attribute type now declares `AllowMultiple`. |
| `x._002Ector()` on an object that exists | 21 on Impostor, 51 on Pinata | 8 and 27 | Three causes. An allocation whose constructor call could not be fused: `InlinedConstructor` compared parameter names to the fields stored after it positionally and pairwise, so `new Movement(currentBox, null, imposter)` missed — the stores arrive in the machine's order and the store of a null is dropped, since the object is already zeroed. Matched by name now, with a missing store read as a zero. A stray call anywhere else is dropped, the `newobj` having already constructed the object. Inside a constructor it is the base call: retargeted to the direct base where il2cpp folded a trivial constructor onto `System.Object`, and hoisted to the front, which is the only place C# can write one. What is left is a constructor whose body also carries a stack type mismatch, where ILSpy will not fold the call whatever position it is in. |

### Open, in the order they cost

**1. A local nothing typed is declared `object` and used as a number — 915 `(nint)` casts, 995 type
mismatches.** This is one defect wearing many faces and it is the whole of ROADMAP section 5. Of what
is left: 53 are `(nint)typeof(T)`, address arithmetic on a class handle the recovery names as a
`Type`; the rest are references in address arithmetic the field resolver did not fold into a field
access, and locals in inlined `List<T>`/`Stack<T>` internals. Each is honest about what the machine
does and none of it compiles. The two seeds added this round — a comparison against a typed integer,
and arithmetic whose operands are *all* known integers — closed the loop-counter case; the remaining
ones need the address-arithmetic side, which is a different problem from typing.

**2. An unresolved call keeps the whole register file as its arguments — the worst kind, because it is
silent.** `Box.OnMouseDown` calls `moveItem(gpc.currentBox, gpc.selectedBox, gpc.selectedImposter)`
and the recovery passes `null`, `gpc.selectedBox`, `null`. The final ISIL is

```
250 CallVoid Box.moveItem, this @ X0, v241 @ X1_v10 (Box), v307.selectedBox (Box), v28 @ X3 (Imposter)
```

where `v28 @ X3` is the *entry* version of X3, never written in this body: the sixteen raw sources of
the unresolved calls earlier in the method make every register look defined. Nothing reports this — no
placeholder, no comment — which is why it is first among the open items despite being one call.
Treating an unresolved call as clobbering the caller-saved registers would at least make it visible.

**3. A `foreach` over a struct enumerator is not recovered — 40 `unsafe` methods.** `Box.isDoneBox`
casts a `NullReferenceException` to a `Stack<Imposter>.Enumerator*` and reads `->Current` off it: the
enumerator lives in an address-taken stack slot, and the exception objects of checks that were not
removed end up standing in for it. 101 `NullReferenceException` and 69 `OutOfMemoryException` mentions
are those unremoved checks; `OutOfMemoryException` is not in
`InjectedCheckRemover.InjectedExceptions`, which is the cheap first step.

**4. Generic sharing names one instantiation for every other — 76 `(List<object>)(object)` and 17
`(Stack<object>)(object)`.** `targets[i]` on a `List<GameObject>` comes back as
`((List<object>)(object)targets)[i]`. Legal C#, wrong type, and it is why 147 `._size` and 36
`._items` reads remain: `Count`'s getter on the shared instantiation carries il2cpp's null check as
well as the field load, so the measured accessor pairing does not match it.

**5. A base constructor call is where il2cpp put it — last — so ILSpy cannot fold it, 16
`base._002Ector()`.** Not valid C#. Hoisting the call to the front of a `.ctor` body is what a
compiler does and what makes it recognisable as a base initializer.

**6. 97 `_003C_003E` names.** Compiler-generated types and fields — `<>c`, `<>9__3_0` — which the
source never wrote and C# will not accept as identifiers. They are honest: the assembly really
contains them. Rendering a display class back as a lambda closes some, which is why `GDPR.cs` reads
correctly despite having three of them.

**7. One lambda of three resolves `AdManager.Instance` as `((AdManager)(object)<>c.<>9)`** — the
display class's own singleton, cast. The other two in the same method are right, so this is a metadata
usage resolving to the wrong class's static storage rather than a systematic failure.

## Faithful to the binary, not to the source

These are not defects, and a check that flagged them would be wrong. Worth knowing before reading a
recovered body as if a person had written it.

- **`Box.SetUp` passes `isStand: false` unconditionally** where the source has `i == 0 ? true : false`.
  `Imposter.SetUp` ignores `isStand`, and the native code moves a literal 0 into X2 inside the loop:
  the C++ compiler dropped a dead argument. Nothing in the recovery could or should recover the
  expression.
- **Unity's small maths functions are inlined**, so `Vector3.MoveTowards`, `Mathf.Clamp01` and
  `Quaternion.Euler` appear as their arithmetic, including the flag temporaries the branch conditions
  were computed through.
- **A method the source called is inlined**, so `gpc.ResetPeeking()` appears as its four field stores
  and `TurnOnEffectWrong()` as `wrongEffect.Play()`.
- **Every branch may be inverted and every early return hoisted**, and a statement the source wrote in
  two arms may appear once after them — `Checker.OnTriggerEnter` writes the high score after the
  if/else rather than inside both, which is where the compiler put it.
- **A `new Vector3(x, y, z)` arrives as three member stores** into a `default(Vector3)`, and a struct
  copy as a whole-struct assignment followed by redundant per-member copies.
- **`BoxRaRot` converts degrees to radians and back**, because il2cpp inlined `Quaternion.Euler` into a
  multiply by `Deg2Rad` and a call to `Internal_FromEulerRad`, and the recovery writes that call back
  as `Quaternion.Euler(arg * 57.29578f)`. The result differs from the source by about six parts in a
  hundred million.
- **An `Il2CppClass<T>` or `Il2CppStaticFields<T>` in the output is inside a diagnostic string**, never
  a cast — 238 mentions, all of them the text of a placeholder naming what could not be resolved.

## Where the numbers stand

| | Pinata | RunFromZombies | Impostor |
|---|---:|---:|---:|
| Unity | 2019.2.6f1 | 2022.3.62f2 | 2022.3.62f2 |
| metadata | v24.2 | v31.1 | v31.1 |
| method bodies attempted | 18440 | 4636 | 6014 |
| failed to convert | 0 | 0 | 0 |
| `.cs` files exported | 3083 | — | — |
| `Unmanaged memory load` | 10843 | 0 in its own scripts | 801 in its own scripts |
| `Method not found` | 4339 | 0 | 228 |
| members lost | — | 0 of 9 | 0 of 177 |
| compile errors | 7066 | 2 | 603 |
| UNT findings, none the recovery's | 224 | 35 | 21 |

Pinata's unresolved-load count moves up as more is recovered, not down: a load that was being dropped
as dead code is reported once something starts keeping it. It is a count of what could not be
recovered, so it rises when something that was being silently discarded starts being kept.
