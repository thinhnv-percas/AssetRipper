# IL2Cpp script recovery — what is still wrong

Everything here is measured on `Test/Input/Pinata` (Unity 2019.2.6f1, metadata v24.2, ARM64,
18440 methods attempted) at script content level 3, on the current `Source/External` build.
`CLAUDE.md` has the command; a run takes about 95 seconds.

Where the run stands today:

| | Count |
|---|---|
| `.cs` files exported | 3083 |
| Decompilation errors | 0 |
| Method bodies discarded as invalid | 0 |
| Method bodies needing a downstream stack repair | 0 |
| `Method not found` placeholders | 9409 |
| `Unmanaged memory load` placeholders | 29350 |
| `Il2Cpp runtime handle` placeholders | 0 |
| Instructions left unimplemented | 34 |

The output does not compile and is not meant to. The goal is that the logic reads correctly. These
are the places it still does not.

## 1. Calls into the il2cpp runtime — about 6000 occurrences

The largest single defect. Of the 9630 `Method not found` placeholders, most name an address that
starts no managed method: they are il2cpp runtime helpers compiled into the same section as the
generated code. 402 distinct addresses remain, the busiest of them (`@8D82A4`) called 1352 times;
the top six account for 5781 of them. The binary is stripped of local symbols, so there is nothing
in it to name them with, and Cpp2IL's key function scan does not recognise them.

The right fix is not naming them but recognising them: a call the lifter identifies becomes an ISIL
operation and never reaches the generator as an address. That means extending
`Cpp2IL.Core/Il2CppApiFunctions/NewArm64KeyFunctionAddresses` with signatures for the helpers, which
is per-Unity-version reverse engineering, not a code change. Identifying the busiest handful — they
cluster right next to `il2cpp_codegen_object_new` at 0x8D82B4 and
`il2cpp_codegen_runtime_class_init` at 0x8D8298 — would account for most of the 18862.

## 2. Calls into the PLT — 1794 occurrences

24 distinct addresses in the ELF `.plt`, calls into libc and the C++ runtime. These are exactly
nameable and nothing does it. An AArch64 PLT entry is 16 bytes after a 32 byte header, so stub *n*
corresponds to relocation *n* in `.rela.plt`, whose symbol name is in `.dynsym` — on this binary,
368 entries, and (0x6D2380 − 0x6D1940 − 32) / 16 lands exactly on one.

`LibCpp2IL.Elf.ElfFile` reads section headers and relocations already but keeps neither the section
list nor the symbol names accessible, so this needs a small public accessor added to the vendored
`ElfFile` — a fourth `AssetRipper:` change. It is ELF only; a Windows game would need the PE import
table instead.

## 3. Inlined interface dispatch — about 5300 occurrences

The largest remaining group of `Unmanaged memory load` placeholders is one shape: a read of
`Il2CppClass::interface_offsets_count` (0x126 on this game), `interfaceOffsets` (0xB0) and
`typeHierarchyDepth` (0x128), which together are the inlined interface method lookup the compiler
emits in place of a call to `il2cpp_codegen_get_interface_invoke_data`.
`InterfaceDispatchRecovery` now matches the A64 shape of the fast path and measures the vtable
bound against the layout rather than a version formula, which took roughly a fifth of them. The rest
fail somewhere else in the match or in the excision, and each needs its own look: the scan loop is
compiled several ways and the pass gives up silently on any of them.

## 3b. Untyped memory loads — the rest

A load through a register the lifter never typed, so there is no way to tell a field read from a
runtime struct access. Nothing local fixes this. It needs type propagation in Cpp2IL's own analysis,
which merges types across branches; the current `LocalVariables` pass drops a type rather than guess
one, and `RuntimeStructAccessAnnotator` on our side is a linear forward walk with the same limit.

## 4. Field accesses that still do not resolve — about 5100 occurrences

The typed ones that remain, after nested value type fields were fixed. Three known causes:

- **Generic instances with a value type argument** — `List<int>+0x18` is `_size`, 414 occurrences on
  this game, 2220 across all generic-typed loads. `MetadataResolver.ResolveFieldOffsets` bails on
  any generic instance with a value type argument because `GenericInstanceFieldLayout` sizes a
  generic parameter as a pointer, which is wrong for a struct. The fix is to substitute the actual
  argument before sizing and bail only when the substituted type is a struct of unknown size — for
  `List<T>` no field is of type `T`, so it would resolve.
- **A base-typed local** — `[X21 (UnityEngine.Object)+18]` where the object is really a derived type
  and 0x18 is the derived type's first field. Wants the same type propagation as item 3.
- **Offsets past the end of the last field**, where any answer is a guess. Correctly left alone.

## 5. Locals with no type — pervasive

`object obj25 = 0; object obj4 = default(object); text2 = (string)obj;` — the shape of a recovered
body whose locals the analysis could not type. A recovered string literal now reads
`object key = "MORPEH__SAVED_DATA"` rather than `object key = 0`, which is the improvement this
project made, but the local is still `object` and every use of it is a cast. Same root cause as
item 3.

## 6. Calls into the middle of a known method — 1959 occurrences

Now labelled `inside <method> +0x4` rather than left as a bare address. The
label is honest but it is not a resolution: what the address really is — an adjustor thunk, a shared
generic entry point, a tail-call target — has not been established. Worth an investigation before
any attempt to turn these into real calls.

## 7. A reported crash, not yet reproduced

A rip of Smash Fest (`com.flow.cannonball`, Unity 2022.3.62f3, metadata v31.1, 94407 methods) ended
with the process gone and the log stopping after `Processing : Lighting Data Assets`. Import had
finished cleanly: 21 assemblies attempted, 12213 methods recovered, 0 failed to convert.

Nothing was logged because nothing could be. The run was a Debug build, where a failed
`Debug.Assert` calls `Environment.FailFast` and ends the process before any handler or logger sees
it; a stack overflow does the same. Both write to standard error only, and the GUI does not capture
it. So the crash is in `LightingDataProcessor`, `PrefabProcessor` or `SpriteProcessor` —
`ScriptableObjectProcessor` logs a line of its own first — and there are asserts on that path in
`PrefabProcessor` (a scene's asset bundle must be a streamed scene bundle), `AssetGroup` (an asset
must not already belong to a group, which both hierarchy builders go through) and
`SpriteInformationObject` (the same, for a sprite's texture).

Three changes since make the next run say which: every processor names itself in the log before it
runs, `BUILD-AND-RUN.bat` and `RUN-TEST.bat` rip in Release where those asserts do not exist, and
`BUILD-AND-RUN.bat` captures standard error to `AssetRipper-crash.log`. An unhandled exception on a
background thread now reaches the log too, which it did not before. What is still missing is the
game itself: none of this is reproduced here, and if it turns out to be a real assert rather than a
Debug-only one, the invariant it guards needs looking at rather than compiling out.

That run also hit the native source injection budget: 4194304 characters per assembly, exhausted in
`Newtonsoft.Json`, so later methods in it carry no reconstruction. The budget is a guess, not a
measurement.

## 7b. ARM64 composite values are named by their first register only

AAPCS64 returns and passes a small struct of floats in several vector registers. Both directions are
counted correctly, and ISIL has one operand per argument and one per return value, so only the first
register can be named. The extra registers of a return are recovered by naming each as the field of
the returned value it carries, and the first register is read as the struct's first field wherever a
float is wanted, so `Vector3.MoveTowards` inlined into a caller comes out as its three component
subtractions. What is left is an argument: `transform.position = v` carries `v` because the analysis
types the parameter, but a method taking two vectors would see only the first register of each, and
nothing says the other two belong to it.

## 8. ARMv7 recovery is new, and shallower than ARM64's

`ArmV7InstructionSet` lifts ARM mode code now, measured on `RunFromZombiesFullProject` — an
armeabi-v7a game that ships its own Unity source, so the output can be read against the real thing.
4632 methods lift, 5 fail, and across `Assembly-CSharp` no instruction is left unimplemented. What
the bodies get right is the shape: call sequences and their arguments, control flow, field reads and
writes at the right offsets, `typeof(T)` handles, and `Time.deltaTime`.

What they get wrong, on `ZambiesMovement.Update` against its source:

- **A static field read through the type's static storage was a placeholder, and is not any more.**
  What blocked it was not `PropagateStaticFieldStorage` but the step before: position independent
  code does not name a metadata usage slot directly, so the class pointer the storage hangs off was
  never resolved. That is fixed for both architectures — see the note in `CLAUDE.md` — and
  `realSpeed = speed + (0.05f * Checker.scoreCounter)` now recovers as written on ARM64. The ARMv7
  path has not been re-measured since.
- **`ldr rD, [pc, rN]` is read through, not stopped at.** It looks like it should resolve to the
  address it computes, and it was tried: doing that loses every `typeof(T)` in the method, because
  the word at that address is the metadata usage slot's address and the load after it is what
  resolves. Measured, twice; do not change it back.
- **Carry is dropped.** `ADC`, `SBC` and `RSC` lift as plain arithmetic because ISIL cannot add a
  flag to an expression. Wrong only at a word boundary.
- **A register pair is two moves.** `LDRD`/`STRD` and `SMULL`/`UMULL` have no 64 bit operand to
  write, so the high half of a `long` is not modelled.
- **NEON is opaque.** `VLD1`/`VST1` and the multi-register VFP forms lift as `Nop`.
- **S and D registers are separate names**, so code that writes `d0` and reads `s0` or `s1` is not
  seen to alias. Unity's float code stays in `s` registers, so this has not bitten yet.
- 19 instructions across all assemblies still lift as `NotImplemented`, all of them exotic
  (`umlaleq`, `qdaddeq`, `mrc2`) and most of them literal pool bytes decoded as code.

## 9. Smaller things

- **`Il2CppClassUsefulOffsets.GetVtableOffset` is a method in Cpp2IL, not data**, so the vtable bound
  used by `IsPointerIntoVtable` cannot be corrected from a struct database layout file. The named
  offset lookups around it can be, and are.
- **Unions are flattened in the struct database**: several members share one offset and `Il2CppType`
  has eight fields at offset 0. The resolver returns the first declared member because choosing
  needs runtime context it does not have.
- **32 bit `Il2CppClass` improvements need a layout file at or below the game's version.**
- **`MetadataInitGuardRemover.InitialisedFlagOffset64` is still a hardcoded 0x135**, which is right
  for 2022.3 and wrong for 2019.2 (0x12E). It no longer matters, because the guard is recognised by
  shape rather than by that constant, but the constant is still there and still wrong.
- **The remaining 34 unimplemented ARM64 instructions** are `BFI` (19), `BFXIL` (5), `REV` (4),
  `USHL` (2) and `DUP` (2). `BFI` and `BFXIL` are expressible with shifts and masks; the rest are
  vector or byte-order operations ISIL has no shape for.
- **`ReconstructNativeBodies` has no considered default.** It is off unless asked for. Turning it on
  costs run time and output size for text that does not compile; whether that is the right default
  for the GUI has not been decided.
- **WebAssembly cannot produce method bodies at all.** `WasmInstructionSet.GetIsilFromMethod` returns
  an empty list unconditionally, and the run reports success either way, which is why
  `Il2CppRecoveryDiagnosticsProcessingLayer` warns about the architecture up front. ARMv7 was in the
  same position until `Source/External/Cpp2IL.Core/InstructionSets/ArmV7InstructionSet.cs` was
  written; see section 8.
