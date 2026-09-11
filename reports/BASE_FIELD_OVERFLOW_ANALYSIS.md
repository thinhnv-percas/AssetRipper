# "Past the last field of the base type": 850 loads, four causes, one fixed

Measured on iteration 014 and re-measured on 015. The inventory is
`reports/BASE_FIELD_OVERFLOW_CASES.json`, one row per load, collected from the same event the run's
summary counts — so the inventory and the reported total are the same set, not two estimates.

The family name turned out to describe a *symptom* shared by four unrelated causes, only one of which
is what the name suggests. Counting them would have said 850; classifying them said 361 + 246 + 139 +
99 + 3 + 2.

## How the 850 split, and where they stand after the fix

| sub-family | classification | before (014) | after (015) |
|---|---|---:|---:|
| RGCTX_SLOT_NOT_A_FIELD | AUDIT_FALSE_POSITIVE | 361 | 2 |
| BASE_TYPED_AS_OBJECT | WRONG_TYPE_RESOLUTION | 246 | 246 |
| BASE_TYPED_AS_AN_ANCESTOR | WRONG_BASE_TYPE | 132 | 129 |
| OPEN_GENERIC_PARAMETER_BASE | WRONG_TYPE_RESOLUTION | 98 | 99 |
| RUNTIME_STRUCT_MISREAD_AS_MANAGED | AUDIT_FALSE_POSITIVE | 10 | 10 |
| POINTER_BASE | ADDRESS_CALCULATION_ERROR | 3 | 3 |

The first row is the fix in this iteration. The rest are untouched and are stated below with what
each would take.

## The cause that was fixed — DECOMP-0012

**Observed.** `SingletonMono<T>.Instance` recovered as placeholders end to end: `nint num = 0;` then
`Unmanaged memory load: [v54 (Il2CppRgctx<SingletonMono\`1>)+8]`, then an unresolved class-init
guard, then an unresolved static field read. 39 unresolved loads in that one property.

**Expected**, from `Assets/_Impostor 3/Scripts/Core/Singletons/SingletonMono.cs`:

```csharp
lock (syncRoot) {
    if (instance == null) {
        instance = FindObjectOfType(typeof(T)) as T;
```

**Evidence.** The base of every one of these 361 loads is an `RgctxTableTypeAnalysisContext` with
`declaredInstanceFieldCount = 0` and `largestDeclaredFieldOffset = 0` — a synthetic type with no
managed fields at all, so "past the last field" is vacuous for all of them. A probe on
`RgctxResolver`'s decline path then said the offsets are all pointer-aligned and in range, the entry
types are `IL2CPP_RGCTX_DATA_CLASS` (878), `_METHOD` (693), `_TYPE` (29) — all three handled — and the
owner is a plain `TypeAnalysisContext` in every single case, never a `GenericInstanceTypeAnalysisContext`.

**First divergence.** `RgctxResolver.ResolveTypeEntry`:

```csharp
var typeArguments = (instance as GenericInstanceTypeAnalysisContext)?.GenericArguments ?? [];
```

An uninflated definition is shared generic code — there is no instantiation — so the arguments were
empty and every entry mentioning the type's own parameter failed to inflate. `ResolveMethodEntry`,
twenty lines below in the same file, already handles exactly this and says why in a comment: *"an
uninflated definition is shared generic code, so its own parameters stand in for the arguments"*.
The type case never got the same treatment.

**Root cause.** One missing substitution, and the cost is never one load: an unresolved slot leaves
the class pointer untyped, which leaves the class-init guard unmatched, which leaves the static field
storage unresolved, which leaves everything read out of it unresolved.

**Confidence.** 100. `Il2CppRgctx` in the exported scripts goes 1345 to 12, and the twelve are inside
`[NativeSource]` reconstruction text rather than in a body.

**Result.** REAL_ERROR audit diagnostics 1766 to 1307, Roslyn 456 to 448, unresolved loads 4667 to
3992, `SingletonMono.cs` 199 diagnostics to 51, `SingletonMonoDontDestroy.cs` 159 to 21. No file
worse, 21 files still carrying none, `EXPECTED` unchanged at 47.

## The causes that remain

### BASE_TYPED_AS_OBJECT — 246, WRONG_TYPE_RESOLUTION

The base is typed `System.Object`, which declares no instance fields, so every offset is past the
last. Nothing narrowed the local to what it really holds. 86 in spine-unity, 59 in DOTween, 48 in
Assembly-CSharp. This is the use-side typing problem (ROADMAP section 5) seen from the load: there is
no metadata answer, because metadata does not record the dynamic type. A rule here would be inference,
not deduction, and the standing principle in `CLAUDE.md` is that a wrong concrete answer costs more
than an honest unknown.

### BASE_TYPED_AS_AN_ANCESTOR — 139, WRONG_BASE_TYPE

Same shape, one step weaker: the base is typed as a class that really does declare fields, and the
offset is past all of them — so the object is an instance of something derived from it.

| base type | cases | offset | largest declared | example |
|---|---:|---|---|---|
| `Spine.Attachment` | 34 | 0x38 | 0x10 | Spine.DeformTimeline::Apply |
| `UnityEngine.Component` | 29 | 0x20 | 0x10 | Spine.Unity.Examples.SpineBlinkPlayer+<Start>d__4::MoveNext |
| `UnityEngine.AndroidJavaObject` | 21 | 0xB8 | 0x18 | GoogleMobileAds.Android.RewardedInterstitialAdClient::GetRewardItem |
| `System.Array` | 19 | 0x18 | 0x0 | Spine.VertexAttachment::CopyTo |
| `System.String` | 8 | 0x18 | 0x14 | Spine.SkeletonBinary::ReadSkeletonData |
| `Spine.Slot` | 6 | 0x6C | 0x58 | Spine.VertexAttachment::ComputeWorldVertices |
| `UnityEngine.Object` | 4 | 0x18 | 0x10 | Spine.Unity.Deprecated.SlotBlendModes::GetTexture |
| `UnityEngine.GameObject` | 3 | 0x50 | 0x10 | GoogleMobileAds.Unity.RewardingAdBaseClient+<>c__DisplayClass23_0::<AddClickBehavior>b__1 |

Two of these are not the general problem and could be answered exactly:

- **`System.Array + 0x18`, 19 cases.** That is `Il2CppArray::max_length` on 64-bit, not a managed
  field — `array.Length`. `ArrayRecovery` already knows the sibling constant
  (`ElementsOffset = 4 * pointerSize`), so this is a known runtime-struct offset rather than an
  inference.
- **`System.String + 0x18`, 8 cases.** `System.String` declares `m_stringLength` at 0x10 and
  `m_firstChar` at 0x14, so 0x18 is the second character — string indexing, which is a computed
  element access rather than a field.

The other ~112 are genuinely "the static type is an ancestor of the dynamic one" and have no
metadata answer.

### OPEN_GENERIC_PARAMETER_BASE — 99, WRONG_TYPE_RESOLUTION

The base is typed as an open generic parameter (`T`, `T2`), whose layout is not known until the
instantiation is. 44 of the 99 are at offset 0xE8 and 16 at 0x100, which are `Il2CppClass` offsets
rather than object ones, so a good part of this group is a *runtime struct* access whose base was
mislabelled — worth separating before treating any of it as a typing problem.

### RUNTIME_STRUCT_MISREAD_AS_MANAGED — 10, and POINTER_BASE — 3

`DG.Tweening.Tween + 0x144` against 55 declared fields ending at 0x11C, and three byte-addressed
reads at offsets 1-3 off a pointer. Too few to be worth a pass, and recorded so they are not
rediscovered.

## What this says about the family name

"Past the last field of the base type" is produced by comparing the offset against the largest field
offset in the base's declared type chain. It is a true statement in all 850 cases and a useful
description in about 139 of them. The 361 that dominated it had **no fields to be past**, which the
inventory makes obvious and the summary line could not. A family picked by count would have been
worked as one bug; it was four, and the one that mattered most was the one the name fitted worst.
