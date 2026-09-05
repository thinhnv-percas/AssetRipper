# Cpp2IL patches

`cpp2il-recovery-fixes.patch` fixes four defects in Cpp2IL. Two of them cost this project 2490
method bodies on the test game; the third left every string in every recovered body unreadable; the
fourth dropped every field access that lands inside a value type field. All four are upstream of
anything this repository controls, so they cannot be fixed from here; what is here is the patch, the
mechanism to build against a patched checkout, and the measurements that justify it.

## What it fixes

**A body can run off its own end.** `GenerateIl` bridges each block to its successor, but a block
whose only successor is the exit block gets no bridge, and the analysis warnings appended at the end
finish on a call. Nothing guarantees a terminator, so the body is invalid IL: reading it walks past
the last instruction. AsmResolver reports that as a stack imbalance at an offset one byte past the
final call, and the body is discarded. `EnsureTerminated` appends a return, preceded by a default
value where the method returns one.

**A resolved call target is thrown away.** The lifter resolves a call, uses it, and keeps only the
address, so a method the model knows arrives at the generator as a bare number and is emitted as a
`Method not found @ACC5DC` diagnostic. Looking the address up again in `MethodsByAddress` turns it
back into the call it is. Only an unambiguous address is taken: identical bodies are folded onto one
address and generic sharing puts dozens of methods there, where any single pick would be wrong.

**Every metadata usage is a dead pointer.** A load from a fixed address is emitted as an
`Unmanaged memory load: [1EF26B0]` diagnostic followed by a null pointer, so a string literal that
the metadata holds in full reaches the decompiled source as `object key = 0`, and every use of it
becomes a cast of a number. Those addresses are metadata usage slots: the il2cpp runtime fills them
in at startup with a string literal, an `Il2CppClass*`, a `MethodInfo*` or a `FieldInfo*`, and
LibCpp2IL can read them back. String literals are the only kind expressible in IL, so those become
`ldstr` and the source reads `object key = "MORPEH__SAVED_DATA"`. The rest keep the null-pointer
placeholder, because a runtime handle has no IL equivalent, but the diagnostic now names what the
handle is: `typeof(UnityEngine.Debug)`, `methodof(AndroidTenjin::System.Void Init(System.String
apiKey))`, `fieldof(...)`.

Pre-27 metadata puts one indirection in the way, which is why the obvious lookup finds nothing: the
address baked into the code is a per-module pointer holding the address of the usage slot, and only
that second address is the one the usage dictionaries are keyed by. Post-27 `GetAnyGlobalByAddress`
already reads through the address itself, so the extra dereference is skipped there.

**A field inside a value type field is not a field.** `MetadataResolver.ResolveFieldOffsets` maps
`[local + offset]` to the field at exactly that offset and gives up otherwise, which is marked in
the source as a TODO. An offset that lands in the interior of a value type field is a nested access:
`FsmColor` holds a `Color value` at 0x38, so a load from 0x3C is that colour's `g` component, and
`FsmColor(FsmColor source)` recovers as `value.y = source.value.y` instead of two dead placeholders.
The search descends into a value type field when the offset falls inside it, and stops at anything
else, because past the end of the last field any answer is a guess. `FieldReference` carries the
fields it sits inside; a read chains `ldfld`, which takes a value type instance on the stack, and a
write takes `ldflda` down to the containing field so it does not write into a copy. Only a reference
typed base is taken, since a value typed local on the stack has no address to write through.

Doing this in the generator is what makes it safe. The generator loads arguments from the resolved
signature, so the stack balances by construction. The same idea applied downstream, where the
signature is not available, unbalanced the stack in 1019 methods and cost them their bodies — that
was measured, and is why this belongs here.

## Measured on the test game

Ripping `Test/Input/Pinata` at script content level 3, 18397 methods attempted:

| | Package 1.0.9 | Package + downstream repair | Patched source |
|---|---|---|---|
| Bodies discarded as invalid | 2490 | 21 | **0** |
| `Method not found` placeholders | 40034 | 40034 | **27007** |
| `Unmanaged memory load` placeholders | 76063 | 76063 | **48409** |
| String literals recovered as `ldstr` | 0 | 0 | **4784** |
| Runtime handles named rather than hex | 0 | 0 | **21100** |
| Nested field accesses recovered | 0 | 0 | **1770** |
| Decompilation errors | 0 | 0 | 0 |

`Morpeh.Hypercasual.SaveSystem.OnAwake` is the shape of the difference. Before:

```csharp
Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1EF26B0]");
object key = 0;
if (!PlayerPrefs.HasKey((string)key))
```

After:

```csharp
object key = "MORPEH__SAVED_DATA";
if (!PlayerPrefs.HasKey((string)key))
```

and, further down the same method, `Debug.Log(string.Format((string)format, arg, arg2))` where
`format` is now `"SAVED INTS {0} STRINGS {1}"` instead of `0`.

## Applying it

```
git clone --branch development https://github.com/AssetRipper/Cpp2IL.git
git -C Cpp2IL apply /path/to/AssetRipper/Patches/cpp2il-recovery-fixes.patch
dotnet build /path/to/AssetRipper/AssetRipper.slnx -p:Cpp2ILSourcePath=/path/to/Cpp2IL
```

Without `Cpp2ILSourcePath` the build uses the published package and behaves as before, with the
downstream repair in `Il2CppIlRecoveryOutputFormat` covering what it can. That repair is kept
deliberately: it is what protects a package build, and it costs nothing on a patched build, where it
reports zero repairs because there is nothing left to repair.

The patch targets the `development` branch. It is written to be submitted upstream — that is the
real home for it, and this directory is the interim.
