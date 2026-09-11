# Use-side type recovery

What a local's type is taken from, where that goes wrong, and what is left. The numbers are the
Impostor rip (Unity 2022.3.62f2, metadata v31.1, ARM64) at iterations 021, 023 and 026;
`reports/TYPE_PROVENANCE.json` and `reports/OBJECT_BASE_TYPE_PROVENANCE.json` carry the rows.

## The order evidence is applied in

`LocalVariables.ResolveTypesAndFields` is monotonic: the first type a local receives is the one it
keeps. That makes the order rules run in the whole of the design, and every defect in this section
has been one of two shapes - a weaker source got there first, or a source that should have been
consulted never ran at all.

The order now is:

| rank | evidence | where |
| --- | --- | --- |
| 1 | the method's own signature: return, parameters, `this` | `PropagateFromReturn`, `PropagateFromParameters` |
| 2 | a type-metadata global, a `newobj`, a `MethodInfo` | `SeedRuntimeClassTypes`, `SeedNewobjResults`, `SeedMethodInfoTypes` |
| 3 | a resolved call's declaring type, parameters and return | `PropagateFromCallParameters`, inside the fixpoint |
| 4 | a resolved field's declared type, either direction of the move | `PropagateMove`, inside the fixpoint |
| 5 | an array's element type, an RGCTX entry, static field storage | `ArrayRecovery`, `RgctxResolver`, `PropagateStaticFieldStorage` |
| 6 | a copy, in whichever direction is missing a type | `PropagateMove`, inside the fixpoint |
| 7 | a phi, only where every typed input agrees | `PropagatePhi` (DECOMP-0013) |
| 8 | `System.Object` at a use site | second fixpoint pass (DECOMP-0016) |
| 9 | "only ever counted with" | `TypeCounters`, last |

Ranks 8 and 9 are the two that are guesses rather than deductions, and both now run after the
fixpoint has settled rather than inside it.

## DECOMP-0015: a shared generic body is attributed to one instantiation

il2cpp compiles one body per generic definition and shares it, so the method a call resolves to is
whichever instantiation the linker attributed that address to. Rank 3 therefore carried a type that
is an artefact of the build:

```
Move v1133 @ X0_v969 (List`1<System.Object>), v1173.linkedMeshes (List`1<Spine.SkeletonJson+LinkedMesh>)
Call List`1<System.Object>.get_Item, v1134 (System.Object), ...
Move v5514 (System.String), [v1134 @ X0_v971 (System.Object)+18]
```

against `private List<LinkedMesh> linkedMeshes;` and `linkedMeshes[i].skin` in the reference. The
receiver is the stronger evidence - it comes from a field signature - so `RetargetSharedGenericCalls`
re-instantiates the callee on the receiver's generic arguments, inside the fixpoint where the field
has had a turn to resolve. Where the two agree it is a no-op, so nothing has to know which arguments
are placeholders.

Withholding a type because the callee is shared has to be narrow. `List<T>.Enumerator.MoveNext`
returns `bool` whatever T is, and refusing that left the local for SSA destruction to merge with the
receiver's register: `GUIManager x = (GUIManager)enumerator.MoveNext()` with the loop condition read
off `this`. `ContainsSharingPlaceholder` asks whether the substitution reached the type in hand;
both halves are required before evidence is discarded.

## DECOMP-0016: `System.Object` is the top of the lattice

Every reference type converges on `System.Object`, so a value reaching a position declared
`System.Object` is only known to be a reference. Recording that is worse than recording nothing.

A delegate's two-argument constructor takes its target as `System.Object`:

```
Move v44 @ X19_v2 (System.Object), v16.<>4__this (CodeStage.AntiCheat.Detectors.TimeCheatingDetector)
...
Move v329 @ X1_v10 (System.Object), v44 @ X19_v2 (System.Object)
CallVoid OnlineTimeCallback..ctor, v308 (OnlineTimeCallback), v329 (System.Object), ...
```

Rank 3 typed `v329` from the constructor's parameter, rank 6 copied that backwards into `v44`, and
the field at rank 4 - which names the type outright - arrived to find the local already typed.
Thirteen field reads off the detector in that one method became unnameable offsets.

Withholding it outright is not the answer: the local then falls to rank 9, and
`obj as ItemResources` came back as `(int)(obj as ItemResources)` because its only other uses are a
comparison with zero and a copy. The fixpoint therefore runs twice, once withholding and once
allowing, with `TypeCounters` still last. Loads whose base resolved to `System.Object` fell from 69
to 17.

This is a use-site rule only. A field or a return whose declared type really is `System.Object` is
that type and is left alone.

## DECOMP-0017: an element address is computed in three shapes, and the fold took one

Not a typing defect, but it is what most of the untyped bases turned out to be. An architecture
with no scaled index addressing mode computes an element's address before the load, so the load
reads `[t + elementsOffset]` and the array and the index are an instruction earlier.
`ComputedElementAddress` matched `t = array + (index << log2(elementSize))` and missed two: a
constant index, which has no register at all because the whole offset is folded into the add, and
an index the compiler leaves in the addressing mode, having added only the elements offset ahead of
the load. `entry[header[j]] = value` came back as `dictionary[(string)0] = value;`.

Generalising the fold onto the affine evaluator that the struct-element path already uses covers all
three in one rule and measured worse on every cut: 3689 unresolved loads to 3969, and to 4084 with
the addend still restricted, so it is not the relaxation that costs. Reading through a chain of
definitions to find the array gives an address that is arithmetically valid and belongs to another
expression. The narrow shape is precise for a reason worth keeping: the shape itself proves the
array is the base.

## What is left

3569 loads are given up on, counted at the one place in `IlGenerator` that gives up, so the total
matches the placeholder count. They split in two:

- **1468 have no usable base type.** By what defines the base: 551 an `Add` (a computed address the
  array and field folds still do not claim), 339 a load from memory nothing typed, 254 no definition
  in the body at all (an entry value, or a stack slot written elsewhere), 245 an `AddressOf`, 51 a
  call.
- **2101 have a base type and the offset could not be placed in it.** A value type base, an offset
  past the last field of the base type, a generic instance with a value type argument, and about 600
  that are runtime structure reads rather than managed fields at all - `Il2CppClass` at
  `typeHierarchyDepth` (139), `0x28` (111), `interface_offsets_count` (84), `0xFC` (61),
  `cctor_finished` (49), `Il2CppMethodInfo` at `0x53` (53), static field storage at `0x8` (49).

The runtime-structure group is not a typing defect. Those loads have the right base and the right
offset; what is missing is a pass that recognises the shape the offset belongs to - the hierarchy
walk, the interface offset scan, the class-init guard - the way `TypeCheckRecovery` and
`InterfaceDispatchRecovery` already recognise theirs. Counting them as unresolved loads overstates
the typing problem by about a sixth.

Of the 551 `Add`-defined bases that remain, the largest identifiable group is an offset partway into
a *struct* element - `array[i].y` on a `Vector3[]` or a `SubmeshInstruction[]`. Folding those to an
`ArrayAccess` would be wrong: one element is wider than one load of it, so naming the access as the
element reads a `Vector3` as a `float`. What they need is the element's address named as a local of
the element's type, which is what `RecoverStructElementAddresses` produces from the uses and cannot
produce from the shape alone. The next largest is the hierarchy walk, `[klass + 0xC8] + depth*8 - 8`,
which belongs to the runtime-structure group above.

## Per assembly

Assembly-CSharp holds 359 of the 3689, under a tenth. spine-unity alone holds half. A change that
moves nothing in Assembly-CSharp has still moved something real, and the only way to see it is to
count per assembly.

| assembly | 021 | 023 | 026 | reference source available |
| --- | --- | --- | --- | --- |
| spine-unity | 1863 | 1839 | 1766 | yes, vendored at `Assets/ThirdParties/Spine/Runtime/spine-csharp` |
| DOTween | 840 | 835 | 825 | no |
| Assembly-CSharp | 359 | 359 | 347 | yes, the game's own scripts |
| ACTk.Runtime | 243 | 227 | 212 | no |
| spine-unity-examples | 221 | 214 | 207 | yes, same vendoring |
| GoogleMobileAds | 179 | 179 | 177 | no |
| LeanPool | 19 | 19 | 19 | no |
| Mono.Security | 17 | 17 | 16 | no |
| **total** | **3741** | **3689** | **3569** | |

Assembly-CSharp's REAL_ERROR is 1076 at both 021 and 023 and its Roslyn count moves by one inside
the existing `Box`-to-`float` family: DECOMP-0016 landed entirely outside it. Read against the
table, that is what a fix in another assembly looks like, not a fix that did nothing. DECOMP-0017 at
026 lands in both, and both move — REAL_ERROR 1052, Roslyn 389.
