# Reading the recovered scripts against the source, one file at a time

`RunFromZombiesFullProject` ships the Unity source its APK was built from, which makes it the one
place the IL2Cpp recovery can be marked rather than estimated. This is the result of comparing all
sixteen `Assembly-CSharp` scripts, member by member, against that source.

To reproduce: fetch the APK (a release asset, since the copy in the repository is a Git LFS pointer),
unzip it into `Test/Input/RunFromZombies`, and rip it.

```
curl -sSL -o demo.apk https://github.com/thinhabc01/RunFromZombiesFullProject/releases/download/v1/demo.apk
unzip -q demo.apk -d Test/Input/RunFromZombies
git clone --depth 1 https://github.com/thinhabc01/RunFromZombiesFullProject.git
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb \
  --output Test/Output --log Test/AssetRipper.log Test/Input/RunFromZombies
```

Unity 2022.3.62f2, metadata v31.1, ARM64. A run takes about 55 seconds. Every script comes out with no
placeholder of any kind, no ILSpy verification comment, and no decompilation error.

## Where each script stands

| Script | Logic | Notes |
|---|---|---|
| `AudioManager` | matches | `foreach` is a `do`/`while` behind a length test; `Play`'s guard is inverted with an early return; the closure over `name` survives as a lambda. |
| `BoxRaRot` | matches | Converts degrees to radians and back — see below. |
| `Checker` | matches | `scoreCounter` is read once into a local and the increment threaded through it; the high-score write is hoisted out of both arms, as the compiler put it. `Time.timeScale = 0` stays in the Obstacle arm only, as in the source. |
| `HighScore` | matches | — |
| `MenuController` | matches | The coroutine folds back into an iterator; `Mathf.Clamp01` is inlined as a min and a negative clamp. |
| `MenuMove` | matches | `Vector3.MoveTowards` inlined; the `position == destination` test is the real `sqrMagnitude < 1e-10`. |
| `MoveBoard` | matches | `ChangeDirection`'s four-way branch is restructured around one shared assignment and is equivalent on all four paths. |
| `Movement` | **was wrong, fixed** | `right` was assigned nowhere and `screenWidth = Screen.width` lost its conversion. |
| `ObsDropper` | matches | The two nested `if`s of the particle check are merged into one `&&`. |
| `ObsJumper` | matches | Branch inverted: the `isHigh` arm (target 0, speed 5) is emitted first. |
| `ScoreScript` | matches | `"" + scoreCounter` is the `string.Concat` null-coalesce a compiler emits. |
| `Sound` | matches | Fields, `[Range]` and `[HideInInspector]` all present. |
| `Spawner` | **was wrong, fixed** | Both loops ran nineteen iterations instead of twenty. |
| `StreetKiller` | matches | — |
| `UIController` | matches | `PauseButt`'s arms are swapped with the condition, and the two `isPaused` writes merged into one. |
| `ZambiesMovement` | matches | `MoveTowards` inlined; the slider and the speed ramp are exact. |

## The three that were wrong, and why

**`Spawner` spawned nineteen rows per street.** Both `FirstSpawn` and `NextSpawner` loop twenty times
in the source. `subs w8, w8, #1` writes its destination *and* sets its flags from its operands, and the
lifter emitted the flag arithmetic after the write-back — so SSA renamed the flags' source to the value
that had just been stored, and they described one subtraction too many. The loop came out as
`while (num != 1)` evaluated after the decrement. A subtract's flags are now emitted before the
write-back; an add's describe its result and stay where they were.

Fixing that exposed a second defect, in `Simplifier`. Its "is this local read after here" walk marked
the start block visited before walking, so a read *before* the starting index was invisible even though
a loop's back edge reaches it. The counter's back-edge copy therefore looked dead; dropping it left the
counter with a single definition, which switched off the pass's own join guard, and the next constant
pass carried the counter's initial value across the loop header — `while (20 != 1)`. The start block is
re-entered once now, from index zero.

**`Movement`'s character could only move left.** `left` and `right` are adjacent `bool`s at 0x44 and
0x45, and the compiler writes both with one `strh`. The ISIL memory operand carried no access width, so
the store resolved to the one byte field at its offset and the byte past it was dropped: `right` was
assigned nowhere in the class and `if (right)` was unreachable. The width now travels from the lifter
(`MemoryOperand.Size`) through resolution (`FieldReference.AccessSize`) to the generator, which splits
the store when the fields it covers tile the range exactly. Where the value is a constant each field
gets its own literal; where it is computed — the keyboard path, whose two constants the compiler merged
into one register — each field gets a shift and a mask, so `0x100` recovers as
`right = true; left = false`. A wide store also stops typing its value as the head field: typed as a
`bool`, `0x100` had been arriving as `true`.

**`Movement.screenWidth = Screen.width` lost its conversion.** Every conversion, `scvtf` included, is
lifted as a move, so an integer local reached a float field with its integer type intact — IL that
ILSpy annotates `Expected F4, but got I4`. The conversion is emitted at the load now, where the wanted
type is in hand. An integer *immediate* is the opposite case and is deliberately unchanged: there the
bits are the float, because materialise-and-store is the only way a machine writes a float constant.

## What is verbose but not wrong

Worth knowing before reading a recovered script as if a person had written it.

- **Unity's small maths functions are inlined**, so `Vector3.MoveTowards` and `Mathf.Clamp01` appear as
  their arithmetic — including the flag temporaries (`flag2`, `flag3`, …) the branch conditions were
  computed through. This is what the binary contains.
- **A `new Vector3(x, y, z)` arrives as three member stores** into a `default(Vector3)`, and
  `a = b` for a struct as a whole-struct assignment followed by redundant per-member copies.
- **Every branch may be inverted and every early return hoisted**, and a statement the source wrote in
  two arms may appear once after them.
- **`BoxRaRot` multiplies by `Deg2Rad` and then by `Rad2Deg`.** il2cpp inlined `Quaternion.Euler` into a
  degrees-to-radians multiply plus `Internal_FromEulerRad`, and the recovery writes that call back as
  `Quaternion.Euler(arg * 57.29578f)` — so both multiplies survive. The result differs from the source
  by about six parts in a hundred million. Cancelling them means seeing through the aggregate the
  per-component multiply was folded into, which has not been done.
- **A local read out of a state machine field may be duplicated** — `MenuController` has both
  `asyncOperation` and `operation` for the source's one `operation`.
