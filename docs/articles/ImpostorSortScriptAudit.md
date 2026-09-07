# Reading a third game against its source

`Impostor-Sort-Puzzle-Pro` is the third measurement game and the largest: 42 of its own scripts
(seven of them Editor-only, so 35 in the build), against 16 for `RunFromZombiesFullProject`. It also
carries middleware the first two did not — Spine, DOTween, PlayMaker, Lean Pool, CodeStage
AntiCheatToolkit, Google Mobile Ads — so it exercises generic sharing, struct enumerators and inlined
framework properties far harder.

To reproduce:

```
curl -sSL -o impostor-sort.apk \
  https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro/releases/download/v1/impostor-sort.apk
unzip -q impostor-sort.apk -d Test/Input/Impostor
git clone --depth 1 https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro.git
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output Test/Output --log Test/AssetRipper.log Test/Input/Impostor
```

Unity 2022.3.62f2, metadata v31.1, ARM64, both `arm64-v8a` and `armeabi-v7a` in the APK. Ten
assemblies attempted, 6014 method bodies, 0 failed to convert. A run takes about four minutes.

## Fixed

**A float aggregate parameter arrived with only its first member.** AAPCS64 passes a homogeneous
aggregate of up to four floats in V0 to V3, and only the first register can be named as the parameter,
so a `Vector3` parameter's y and z were in registers nothing had defined. They read as
`default(float)`. `Imposter.Toptarget`'s setter, whose whole body is `toptarget = value`, came out
storing value.x and then zeroing the other two, and `MoveToTarget` forwarded `target2` to `DOMove` as
`(0, 0, 0)`. This is the third side of the defect `DefineFloatAggregateReturn` and
`ComposeFloatAggregateArguments` cover on the other two: `DefineFloatAggregateParameters` names each
extra register as the member of the parameter it carries.

**A bounds check whose condition is an `Or` of two flags was not recognised.** One `cmp` sets both C
and Z, and the check branches on "lower or same", which the lifter models as `!C || Z`;
`ChaseCondition` walked only copies and inversions and stopped at the `Or`. Every check of that shape
survived, so `skinList[id]` came out as
`array.Length < id || (object)(array.Length - id) == null` guarding a `throw`, with the null checks
around it keeping a throw block alive. The `Or` now reduces to the comparison behind it when one side
is the carry of a `CheckLess` and the other the zero flag of the same subtraction — unrelated flags do
not match, so a real `||` is not mistaken for a check.

**An array's length was not typed as an int**, which is why comparing `array.Length - index` against
zero was emitted as a reference comparison and produced that `(object)` cast.

**A hidden instance field is read through the property that returns it.** A trivial property is
inlined, so the field is what the body names: `button.onClick` was `button.m_OnClick`. The pairing is
measured from the getter — a getter whose whole body is one load of the field and a return is that
field's accessor — rather than guessed from a name, because `_size` and `Count` share none. 4078 reads
on this game, up from 154.

With those, `Imposter.cs` matches its source: `SetUp` is two statements and the `skinList` initialiser
is back on the field declaration where the source has it.

## Faithful to the binary, not to the source

Worth separating from defects, because the recovery is right and the source is not what shipped.

- **`Box.SetUp` passes `isStand: false` unconditionally**, where the source has `i == 0 ? true : false`.
  `Imposter.SetUp` ignores `isStand`, and the native code moves a literal 0 into X2 inside the loop:
  the C++ compiler dropped a dead argument. Nothing in the recovery could or should recover the
  expression.
- **`gpc.ResetPeeking()` and `TurnOnEffectWrong()` appear as their bodies**, four field stores and a
  `wrongEffect.Play()`. Inlined by il2cpp; the binary has no call to recover.
- **`Mathf`, `Vector3` and `Quaternion` helpers are inlined** throughout, as in the other two games.

## Still wrong

Ordered by how much they cost. Each is stated with the evidence rather than a guess, so the next
session can start from the ISIL rather than from the output.

**1. An unresolved call keeps the whole register file as its arguments, and that hides what a later
call really reads.** `Box.OnMouseDown` calls `moveItem(gpc.currentBox, gpc.selectedBox,
gpc.selectedImposter)`; the recovered call passes a local that is always null, `gpc.selectedBox`, and
`default(Imposter)`. The final ISIL is

```
250 CallVoid Box.moveItem, this @ X0, v241 @ X1_v10 (Box), v307.selectedBox (Box), v28 @ X3 (Imposter)
```

where `v28 @ X3` is the *entry* version of X3 — never written in this body — and `v241 @ X1_v10`
resolves back to a phi of the `methodInfo` register, which the unresolved calls earlier in the method
list among their sixteen raw arguments. The same shape gives
`BackIntoPosition(startTime)` a `float startTime = default(float)` in place of the source's `0f`. Two
things to check first: whether the resolved callee at that address is really `moveItem` (only X0 and
X2 are set before the call, which cannot be a correct three-argument call), and whether treating an
unresolved call as clobbering the caller-saved registers would turn these silent nulls into reported
placeholders.

**2. A `foreach` over a struct enumerator is not recovered, and the exception objects of unremoved
checks end up standing in for the enumerator's stack slot.** `Box.isDoneBox` is the worst body in the
game: it is `unsafe`, casts a `NullReferenceException` to a `Stack<Imposter>.Enumerator*`, and reads
`->Current` off it. The `foreach` body's `imposter.id` reads are the two `Unmanaged memory load`
placeholders left in the method. `OutOfMemoryException` also appears, and it is not in
`InjectedCheckRemover.InjectedExceptions` — adding it is the cheap first step; the address-taken
enumerator slot being confused with an object local is the real one.

**3. Locals with no type are 608 lines of `nint`,** almost all of it inlined `List<T>`/`Stack<T>`
internals, and 565 `Expected O, but got I` plus 243 of the reverse. This is ROADMAP section 5 rather
than anything specific to this game.

**4. A base constructor call is emitted where il2cpp put it — last — so ILSpy cannot fold it** and
renders `base._002Ector()`, which is not valid C#. 16 occurrences. Hoisting the call to the front of a
`.ctor` body is what a compiler does and what makes it recognisable as a base initializer.

**5. `AdManager.Instance` inside one of three otherwise identical lambdas** recovers as
`((AdManager)(object)<>c.<>9)` — the display class's own singleton, cast. The other two lambdas in the
same method get `AdManager.Instance` right, so this is a metadata usage resolving to the wrong class's
static storage rather than a systematic failure.

**6. `List`/`Stack`'s `_size` still appears** (375 reads). Their `Count` getter carries il2cpp's null
check as well as the field load, so the measured accessor pairing does not match it yet.
