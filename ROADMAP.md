# IL2Cpp script recovery — what is still wrong

Everything here is measured on `Test/Input/Pinata` (Unity 2019.2.6f1, metadata v24.2, ARM64,
18440 methods attempted) at script content level 3, on the current `Source/External` build.
`CLAUDE.md` has the command; a run takes about 95 seconds.

Where the run stands today:

| | Count |
|---|---|
| `.cs` files exported | 3083 |
| Decompilation errors | 1 type ILSpy will not read (section 10) |
| Method bodies discarded as invalid | 0 |
| Method bodies needing a downstream stack repair | 0 |
| `Method not found` placeholders | 4288, of which 1361 name the import they call |
| `Unmanaged memory load` placeholders | 10770 |
| `Il2Cpp runtime handle` placeholders | 0 |
| Instructions left unimplemented | 34 |

The run also prints a breakdown of what the unresolved memory loads *are*, classified where the
types are still in hand, one line per kind with an example. Read it before picking anything up here:
it is raised from the one place in the generator that gives up on a load, so its total matches the
placeholder count, and it reorders as things are fixed.

The other measurement is `RunFromZombiesFullProject`, an ARM64 game that ships its own Unity source,
so the output can be read against the real thing. Its sixteen scripts now carry no diagnostic of any
kind and no decompilation error, its one coroutine folds back into an iterator (section 8c), and all
sixteen have been read against the source line by line (section 8d).

The output is not required to compile — the goal is that the logic reads correctly — but it is now
compiled anyway, because a compiler names defects a grep cannot see.
`Test/Scripts/compile_recovered_scripts.sh` builds a game's exported scripts against the assemblies
the rip shipped beside them and ranks what Roslyn rejects: 1749 errors on Pinata, 2 on
RunFromZombies, 499 on Impostor, from 7139, 2 and 765. Most of what is left is section 5 - a local the
analysis could not type, declared `object`, every use of it a cast that does not exist - and section
5b now says what those locals actually are. With `ANALYZERS` set it also runs Microsoft.Unity.Analyzers, which
faults nothing the recovery did on any of the three. Section 8g has the reading. These are the places
the logic still does not read correctly.

## 1. Calls into the il2cpp runtime — about 3100 occurrences

Was the largest single defect. Of the 4475 `Method not found` placeholders that remain, most name an
address that starts no managed method: they are il2cpp runtime helpers compiled into the same section
as the generated code, and the binary is stripped of local symbols.

Two things closed most of it. **The busy addresses are veneers**: a table of single `b` instructions
sits between the runtime and the generated code, and every call goes to the veneer rather than the
function, so nothing that looks an address up found anything. `MetadataResolver` now takes the hop
and asks the same questions again — key function, managed method, throw helper, exception raiser —
which resolved the box and unbox thunks and the helpers that raise an exception by name.
**`Object::IsInst` is now found**, as the busiest caller of the exported
`il2cpp_class_is_assignable_from`; 1351 calls became the `isinst` they always were.

What is left is about 3100 calls over the remaining distinct addresses, the busiest being `@8909C4`
(595, a real function rather than a veneer) and `@8907BC` (196). The route to them is the same:
either an anchor in the exported API that reaches them, or a signature in
`Cpp2IL.Core/Il2CppApiFunctions/NewArm64KeyFunctionAddresses`. Note that `GetCallerCount` now counts
across every executable section, so "which of these does managed code actually call" is a question
that can be asked.

## 2. Calls into the PLT — named, on ELF and ARM64

1361 of them over 28 distinct addresses, and they now say which import they call: `_Unwind_Resume`,
`__cxa_end_catch`, `memcpy`, `sinf`. `ElfFile` reads `.rela.plt` back, keyed by the GOT slot each
relocation binds, and the ARM64 lifter decodes a stub to say which slot it reads — decoded rather
than computed from the section layout, because a PLT's header and entry sizes vary by toolchain.

What is left of this: **ARMv7 stubs are a different shape and are not decoded**, so an armeabi-v7a
game's PLT calls stay anonymous; and it is ELF only, so a Windows game would need the PE import
table instead.

## 3. Inlined interface dispatch — about 1950 occurrences

A read of `Il2CppClass::interface_offsets_count` (0x126 on this game) and `interfaceOffsets` (0xB0),
which together are the inlined interface method lookup the compiler emits in place of a call to
`il2cpp_codegen_get_interface_invoke_data`. `InterfaceDispatchRecovery` matches the A64 shape of the
fast path, measures the vtable bound against the layout rather than a version formula, and now
excises the scan once the dispatch is resolved rather than requiring the merge phis to be dead —
which on A64 they never are, because the scan walks the table with scratch registers the compiler
reuses immediately afterwards. That took `interface_offsets_count` from 2713 to 1309 and
`interfaceOffsets` from 1189 to 644.

What is left is dispatches the *match* does not recognise, not the excision. `IsilDump` (see
`CLAUDE.md`) prints "unrecognised vtable entry chain" with the instruction it was handed for each
one; the scan loop is compiled several ways and each shape needs its own look.

## 3c. Inlined type checks — recovered

`TypeCheckRecovery` recognises the hierarchy walk (`obj->klass->typeHierarchy[T->typeHierarchyDepth
- 1] == T`) and the unbox comparison of two classes' `element_class`, and rewrites both into an
`isinst` and the null test the branch was already doing. 379 casts now read as `as` or `is` in the
output, and the depth comparison that lets the walk be skipped is folded away with them.

`Il2CppClass<T[]>+0x40`, an array class's `element_class`, was 2365 more of these and is the array
store check: `stelem.ref` compiles to a call testing the value against the element class, reached
through the array's own class because the array's type is only known at runtime.
`MetadataResolver.ResolveElementClassLoads` now names it as the runtime class of the element type,
which is what a metadata usage of that type would have produced, so the load resolves. 188 are left,
where the base is an `Il2CppClass<T>` rather than an array's.

The check around it is gone too, now that `Object::IsInst` is identified: it reads as
`value as T`, which makes it an injected check like any other, and `InjectedCheckRemover` drops it.
That needed the rewrite to happen after the element class is typed, so `KeyFunctionRecovery` and
`InjectedCheckRemover` both run a second time after the type fixpoint. The exception the check would
have thrown often survives as a dead `new ArrayTypeMismatchException()`, because the block that
builds it is shared with another check's epilogue and stays reachable from that one.

## 3b. Untyped memory loads — the rest

A load through a register the lifter never typed, so there is no way to tell a field read from a
runtime struct access. The breakdown now says what each of these was defined by, which splits the
group into shapes that want different fixes. What is left, largest first:

- **1462 `Move from AddressOf(an untyped local)`** — a load off the address of a stack slot, so a
  struct built on the stack. The slot itself is never typed, so nothing names the field. Typing the
  slot from what is stored into it, or from the call that takes its address, would resolve the
  whole group.
- **949 `Add of an untyped local and Immediate`** — an address computed into a register before the
  load, which is the same problem the array element work solved for arrays and has not been done for
  anything else.
- **548 `Move from an untyped base`** — a load through a pointer whose own base was unresolved. These
  are cascades: they go when whatever defines the base is fixed, and until then they say nothing on
  their own.

`RuntimeStructAccessAnnotator` on our side is a linear forward walk and cannot help with any of
them.

## 3d. Generic sharing — resolved

`RgctxResolver` had `MethodInfo::klass` at 0x20 and `MethodInfo::rgctx_data` at 0x38, both of which
are the 2022 layout; before 2022 they are at 0x18 and 0x30. Nothing typed the class a shared body
reads out of its `MethodInfo`, so the RGCTX table it points at was untyped and every entry read out
of it was untyped in turn — 1111 loads at `MethodInfo+0x30`, 1019 at `MethodInfo::klass` and about
2600 of the chains hanging off them. Both offsets now come from the tables, and `MethodInfo` is
measured from the struct database the same way `Il2CppClass` is, so the 2022 games keep what they had.

## 4. Field accesses that still do not resolve — about 3200 occurrences

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

## 5c. What the untyped locals are, measured

The count on its own says nothing about what to do, so it is now raised from the one place in
`IlGenerator` that declares a local as `object` and grouped by the opcode that writes it and by
whether anything reads it. Read that breakdown in the log before picking anything up here.

Of 51464 on Pinata, about 42000 cost nothing: 21587 are a register's entry value first read by an
*unresolved* call, whose operands the generator never emits at all; 3513 the same through an
`IndirectCall`; 6383 are read by nothing; 3376 and 2242 are the return of an unresolved call and an
unresolved memory load that nothing reads. The population that actually costs a cast is about 9600,
and three quarters of it is arithmetic.

Five rules followed and are in: an enum is its underlying integer; a shift or bitwise operation
produces an integer whatever its operands were; the result of a type check is the type checked for; a
string literal is a string and an array's length is an int; a read through an integer-typed local is a
dereference of a pointer to one. Together they typed 3164, took Pinata's `object` declarations from
14882 to 12330 and Impostor's audit total from 1687 diagnostics to 1512 - the readability half, and
the larger one, since the compile errors moved only from 2119 to 1970.

**What is left is the same problem from the other side.** The 1427 `CS0030`s on Pinata are a long tail
of a local typed from its definition and used somewhere that wants another type: 185 an `int` where a
`Fsm` is wanted, 83 a `Type` where an `IntPtr` is, 50 a `float` where a `Vector3` is. The rule that
would cover them types an untyped local *from its use* - the argument position of a resolved call, the
value side of a store into a typed field, the other operand of a comparison - which is the
constraint-based formulation the literature on typing machine code uses (retypd, and BinSub for the
polymorphic version). `PropagateFromCallParameters` is the one instance of it that exists.

## 5b. Values the ABI keeps in several registers — recovered

Both sides now. The extra registers of a *return* are named as the fields they carry; an *argument*
gets a `MakeStruct` — a new opcode, not a new operand kind — emitted before the call, building the
value out of the registers it was really passed, into a register of its own so SSA versions it. 5474
of them on the test game. `Vector3.Distance(a, b)` reads with both arguments where it used to read
`Distance((Vector3)0, (Vector3)obj10)`.

Unmanaged memory loads rose from 11892 to 12686 as a result, and that is the change being honest:
the loads computing the second and third members were dead code before, so they were dropped rather
than reported.

What is left of this is the *store* side of a composite: `this.velocity = 0` where the vector was
written a register at a time is still 216 casts of a float to a Vector3 on the test game.

## 6. Calls into the middle of a known method — 1954 occurrences

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

## 10. One type ILSpy will not read

`EasyMobile/Internal/RuntimeHelper` in the first test game throws an `InvalidCastException` out of
ILSpy's `DeclareVariables` transform (a `BlockStatement` where it wants an `Expression`). Nothing in
the IL fails verification, so `ReplaceIfUnverifiable` does not catch it, and ILSpy decompiles an
assembly as one parallel unit, so it used to cost every script after it in that assembly.
`ScriptDecompiler` now reads the file name out of the failure, skips that type and decompiles the
assembly again, so the cost is the one type. What triggers the ILSpy bug has not been narrowed down
past "the corrected constructor" — the same body decompiles when the allocation is built with
`System.Object`'s constructor instead, which is what made it `(DisplayClass)new object()`.

## 11. A delegate over a closure

`Array.Find(sounds, s => s.name == name)` recovers as `Array.Find(sounds, match)`, with `match`
undeclared. The ISIL is right — the display class is allocated, its field stored, a `Predicate<Sound>`
built over `<Play>b__0` — and ILSpy folds the closure into the enclosing method but then loses the
delegate. Whether the emitted IL is at fault or the transform is has not been established.

## 8b. The exported scripts compile — on the second game

`RunFromZombiesFullProject` ships its own Unity source, and its exported scripts had 26 compile
errors of four kinds, then 4 more of a fifth. All five are closed, and its sixteen scripts now read as the source with no
`(nint)`, no `Internal_` member, no attribute on a lambda and no cast of a float to a vector.

- **An attribute on a lambda**, which is C# 10 while the scripts are exported at the version the game
  was written in. The address, token and reconstructed source are no longer injected onto a lambda
  body.
- **An argument the ABI split across registers**, which is section 5b.
- **A private member of a nested compiler-generated type, written from the type it is nested in.**
  il2cpp inlines the constructor, so what the caller does is allocate and write the fields. A member
  of a *game* assembly that a body reaches but a compiler would not is widened to internal; 841 of
  them on the test game. A framework member is left alone, because the assembly the script is really
  compiled against is not the recovered one — for those, a hidden static field is read through the
  public property that returns it, and `Quaternion.Internal_FromEulerRad` is written as the
  `Quaternion.Euler` it is the inside of.
- **A float added to a value the ABI keeps in several registers.** The register holding a vector's x
  is the register that held the whole vector on the path where it did not change, so the local is
  typed as a Vector3 and `position.x + step` reads as `position + step`. Arithmetic now takes its
  float type from its operands where the destination is not a float, and stores the result into the
  destination's first member.
- **A cast to `nint` of something that is not one.** Two causes, both fixed: the class pointer a
  static field read went through stayed live because only the generator knew the head of a type's
  static storage is its first static field, and a comparison against a value the ABI keeps in several
  registers did not know to read its first member.

Measuring this properly still wants the exported scripts actually compiled. Against the *recovered*
assemblies that is possible with the .NET SDK alone and would catch accessibility, casts and syntax;
against the real Unity assemblies it needs Unity. Until then the check is by hand, on a game whose
source is available.

To reproduce: the game's APK is a Git LFS object in its repository and also a release asset, which is
what to fetch — `curl -sSL -o demo.apk
https://github.com/thinhabc01/RunFromZombiesFullProject/releases/download/v1/demo.apk`, unzip it into
`Test/Input/RunFromZombies`, and rip that. It is Unity 2022.3.62f2, metadata v31.1, ARM64, and a run
takes about 55 seconds.

## 8c. Coroutines fold back into iterators

A coroutine is a compiler-generated state machine, and a decompiler folds it back only if the kickoff
method has the exact shape the compiler emits: allocate `<Foo>d__1`, set its `<>1__state` to −2, and
return it. il2cpp inlines that constructor, so what the body did was allocate the object, call
`System.Object::.ctor` on it, and store −2 into the field directly — one field short of the shape, and
ILSpy left the whole state machine class in the output as thirty lines of `<>1__state` switching.

`IlGenerator.InlinedConstructor` reconstructs the call: after a `Newobj` it collects the stores into
the allocated object's own fields and looks for a constructor whose parameters are named after them
in order, then emits `newobj` with those values and drops the stores and the base call.
`ConstructorFor` no longer falls back to the base type's constructor when the allocated type has
none, because `(DisplayClass)new object()` is worse than no allocation at all.

Two smaller things were in the way of the body inside the loop:

- **A 32 bit integer immediate where a float is wanted is the float's bits.** The machine has no
  other way to write a float constant; a real conversion would be an `scvtf`. `-0.5f` was coming out
  as `3.2044483E+09f`, which reads as a number and is not one.
- **An address-take is versioned where the address is computed, not where the slot is written.**
  Boxing a value spills it: take the address of a stack slot, store into the slot, call the helper
  with the address. SSA renaming gave the address the version live at the address-take, so the boxed
  value read as whatever was in the slot beforehand — `Debug.Log(progress)` became
  `object obj = default(object); object message = (float)obj;`. `SsaForm` now retargets such an
  address at the version stored into the slot before the address is first read, within the block.

That last one costs 36 unmanaged memory loads on the test game, which is the usual shape: a load that
was being dropped as dead is now kept and reported.

## 8f. Verifying a recovery against the source, repeatably

`Test/Scripts/audit_recovered_scripts.py` compares a game's recovered scripts against the Unity source
they were built from: it proves no member was lost and counts every diagnostic and every known-bad C#
shape per file, so the reading starts with the files that need it.
`docs/articles/RecoveredScriptVerification.md` is what it currently says — the per-file table, the
defect catalogue with a count and a cause for each shape, and the list of things that are faithful to
the binary rather than to the source and so must not be flagged.

The headline: **no member is lost**, on either game that ships its source (177 of 177 on Impostor,
9 of 9 on RunFromZombies). What is wrong is fidelity inside the bodies, and 915 `(nint)` casts and 995
ILSpy type-mismatch comments on Impostor are one defect wearing many faces — a local nothing typed is
declared `object` and used as a number, which is section 5.

## 8g. Compiling the recovered scripts — measured

`Test/Scripts/compile_recovered_scripts.sh <rip output> [assembly]` compiles the exported C# against
the recovered and stubbed assemblies the rip put under `AuxiliaryFiles/GameAssemblies`, and prints the
errors ranked by C# error code with an example each. `KEEP_LOG=<path>` keeps the log; the exit status
is non-zero when there are errors.

It measures against the *stubbed* framework, which carries only what the game's metadata carries, so a
member IL2CPP stripped from the build is absent here even where the export would compile against a real
Unity install. Both of RunFromZombies' two remaining errors are exactly that: `Math.PI`, which is how
ILSpy renders `0.017453292f`, and `Quaternion.Euler(Vector3)`, which the recovery names in place of the
inlined `Internal_FromEulerRad`.

**A declaration error hides every body error in the assembly**, and that is how Pinata read as 3
errors when it has 7139. Roslyn binds declarations first and stops there if that stage failed, so two
missing attribute types masked everything and, with no semantic model, silenced every analyzer as
well. Both were `StructLayoutAttribute`, a pseudo-custom attribute stored in a type's flags rather
than as an attribute, so a stripped build carries no such type for the exported `[StructLayout(...)]`
to name; the harness shims it and `LayoutKind` in source. A suspiciously small error count is a reason
to read the log.

Classes fixed so far, largest first:

- **4606 of Pinata's were one assembly reaching into another's private fields.** il2cpp inlines the
  fast path of a property, so `Assembly-CSharp` names PlayMaker's `FsmBool.value` and
  `NamedVariable.useVariable`, and neither can be read back through the property - `FsmBool.Value`
  consults `CastVariable` first, so the field access is the inside of it. The widening pass now
  crosses assembly boundaries for any assembly this export invented the source for, to public, with
  the owning type. `protected` to `internal` is not a widening and cost five errors on RunFromZombies
  before it became protected internal.
- **338 were a Rect written a member at a time**, which is section 8j.
- **515 were `EmptyArray<T>.Value`**, an internal framework type holding what `Array.Empty<T>()`
  returns; 181 were `List<T>.AddWithResize`, the private inside of `Add`; 13 were an `out` parameter a
  recovered body never writes.

- **4996 of Pinata's first 4999 were injected by the ripper.** A member carrying several attributes
  Cpp2IL could not read gets an `AttributeAttribute` for each, and C# rejects the second unless the
  attribute type declares `AllowMultiple`. Duplicates are legal in metadata, so nothing was ever wrong
  with the assembly; the injection now goes through `AttributeInjectionUtils`, which applies
  `AttributeUsage`.
- **180 of Impostor's were `List<object>._size`**, and 146 of those are gone. See section 8h.
- **`x._002Ector()`, 51 on Pinata and 21 on Impostor, is down to 27 and 8.** See section 8i.

What is left on Impostor is 603, and it is mostly one defect: 329 `CS0030`, 18 `CS0037`, 10 `CS0019`
and 5 `CS0165` are all a local nothing typed, declared `object` and used as a number or a list, which
is section 5. The remaining named item is 48 `CS0122` — `ObscuredInt`'s private fields, written
directly from another assembly because il2cpp inlined the struct's construction. A member of a *game*
assembly that the recovered body reaches and a compiler would not is ours to widen; this one is
private in a plugin assembly, so widening it means public rather than internal, and nothing does that
yet. Pinata's largest class is 4721 `CS1061` for `List<T>._items`, `_version` and the rest of what
il2cpp inlined out of the framework — the write half of section 8h, which a getter cannot stand in
for.

### The analyzers

`ANALYZERS=<dir>` runs Roslyn analyzers as well, and Microsoft.Unity.Analyzers is the one worth
running: its rules are about Unity's own contract rather than C#'s, so they catch what a compiler does
not mind. Most of them ship at Info severity, which the command line compiler does not print at all,
so the harness writes a global analyzer config raising every `UNT` rule to warning — without it the
run reads as a clean sheet and is a silent one.

224 findings on Pinata, 35 on RunFromZombies, 21 on Impostor, and **none of them is the recovery's**:
every one is in the source too where there is source to check, and the families that would indicate a
defect (`UNT0006`, a message with the wrong signature; `UNT0010` and `UNT0011`, a component
constructed with `new`) do not fire at all.
`docs/articles/RecoveredScriptVerification.md` has the reading, finding by finding.

## 8h. The accessor pairing, for a field of a generic instance — recovered

A trivial property is inlined, so the field is what the body names, and reading it back through the
property is what makes the export compile against a real framework. That was already true for
`button.m_OnClick`; it was not true for `stack.Count` or `list.Count`, because a field of a generic
instance has no metadata of its own — `ConcreteGenericFieldAnalysisContext` is constructed as
`base(null, genericInstanceType)`, so its `BackingData` is null and its declaring type is the
instantiation, which has no properties at all.

So the pairing is measured on the *definition* and the getter it finds is instantiated on the same
arguments, giving `List<object>::get_Count`. That needed one more thing: every field of a generic type
is at offset 0 in the metadata, so the offset the getter's body names had nothing to be compared
against. `GenericInstanceFieldLayout` already computes that layout to resolve a load off a generic
instance; `OffsetOfField` reads the same walk the other way round to place a named field.

`_size` went from 180 to 34 on Impostor. The 34 that remain are *writes* — `list._size = n`, left by an
inlined `Add` — and a getter cannot stand in for those.

## 8i. A constructor called on an object that exists — mostly recovered

`x._002Ector()` names a member no type has, 51 times on Pinata and 21 on Impostor, and it had three
causes.

**An allocation whose constructor call could not be fused leaves both halves broken.**
`IlGenerator.InlinedConstructor` matched a constructor against the field stores that follow a `Newobj`
by comparing parameter names to field names *positionally and pairwise*, and required as many stores
as parameters. `new Movement(currentBox, null, imposter)` failed both: the stores arrive in whatever
order the machine wrote them, and the store of the null is dropped altogether because a freshly
allocated object is already zeroed. The recovered body was `Movement movement = null;
movement._002Ector();`. Matching by name, with a missing store read as a zero and every store required
to be accounted for, recovers the call — and is worth more than the error it fixes, because the
arguments to those constructors stop being dead code: Pinata's unresolved loads fall from 11215 to
10843 and its `Method not found` placeholders from 4394 to 4339.

**A stray call anywhere else is dropped.** The `newobj` has already constructed the object, so the
call adds nothing but an error.

**Inside a constructor it is the base call**, and C# can only write one as an initialiser. il2cpp
folds a trivial constructor onto its base, so a class two levels below `MonoBehaviour` can call
`System.Object..ctor` — legal IL, rendered as `((object)this)._002Ector()`. That is retargeted to the
direct base's parameterless constructor, and the call is hoisted to the front of the body, which is
the only position a decompiler can turn into an initialiser.

Impostor is at 8 and Pinata at 27. Six of Impostor's eight are in constructors whose bodies also carry
an ILSpy stack type mismatch, and ILSpy will not fold the base call in a method with one whatever
position it is in — so those are section 5, not this. The other two are a base call on a generic base
type that the hoist did not move.

## 8k. An inlined throw helper, and a delegate over an unknown pointer

`System.ThrowHelper.ThrowArgumentOutOfRangeException()` was 147 errors on Pinata: il2cpp inlines the
framework's collection code into its caller, so a game script calls a helper on a type that is
internal to the framework the export compiles against. The helper never returns and is named after
what it raises, so the throw is an exact rendering - the name past `Throw` is looked up in the game's
own mscorlib and its parameterless constructor is raised.

A delegate's two-argument constructor takes a receiver and a function pointer, which C# cannot write;
a decompiler renders it `new Func<bool>(obj, method)`, which asks for a method name and is handed a
value. That was all 118 `CS0149`s, and the pointer in every one comes from a memory load nothing
resolved, so there is no method to name and the loss is reported instead.

Both also *recover* rather than rename: unresolved loads fell from 10852 to 10770 and
method-not-found from 4342 to 4288, because a throw helper that is recognised stops being an
unresolved call.

## 8j. A value type's fields, paired with their properties — recovered

The accessor pairing that turns `button.m_OnClick` into `button.onClick` had never matched a single
struct in any game, and three separate things were wrong at once. It is worth writing down because
each of them looked like the whole answer.

`OffsetOfInstanceField` tested for a **positive** offset. The metadata records a value type's fields
from the start of its data, so `Rect.m_XMin` is 0 - read as "offset not known", and the pairing bailed
before looking at a single property.

**The offsets in an accessor's body are object-relative even when the field's are not.** `Rect.set_x`
lifts to `Move [X0+10], V0 | Return` while `m_XMin` sits at 0: the receiver il2cpp hands a value
type's method points at the object header, not at the data. So the offset to match against is the
field's plus the header for a value type and the field's own for a class - which is exactly why this
worked on every class and no struct. Guessing the direction of that adjustment was wrong the first
time; the trace of `set_x`'s ISIL settled it in one run.

**A Rect is four floats, so it is a float aggregate**, and its stores come from `OpCode.MakeStruct`
rather than the general field-store path. Pairing only the general path changed nothing at all -
identical error counts to the digit, which is what a pass that never fires looks like. Three store
paths now take the property when one exists: `MakeStruct`, the `Move` case's own field store, and
`StoreToOperand`. A property on a value type is called on the *address* of the local, so the receiver
is loaded with `ldloca` and a chain through containing fields with `ldflda`.

Worth 338 on Pinata, and its inaccessible-member errors fell from 467 to 147.

**And then two more paths, both on the read side.** A `Rect` is four floats, so it is a float
aggregate, and `rect.m_XMin + 4f` comes out of the `LocalVariable` case in `LoadOperand` as
`ldloca rect; ldfld m_XMin` - nothing there is a `FieldReference` either. A *field* of an aggregate
type does the same one step further out, and there the property needs the field's address rather than
a copy, so whether to take one has to be decided before the field is loaded at all. Another 66, and
`rect.m_XMin` is gone from the output entirely. What is left of the kind is `ColorBlock` - five
`Color`s rather than a homogeneous run of floats, so it arrives by a different route again.

## 8d. The second game's scripts read as the source — line by line

`docs/articles/RunFromZombiesScriptAudit.md` is the per-script record. In summary:

All sixteen `Assembly-CSharp` scripts of `RunFromZombiesFullProject` have been compared against the
Unity source they were built from. Thirteen were faithful already. Three were not, and every cause was
a defect that applies to any game, not to this one:

- **A countdown loop ran one iteration short.** `subs w8, w8, #1` writes its destination and sets its
  flags from its operands, and the lifter emitted the flag arithmetic after the write-back, so SSA
  renamed the source to the value just stored. `for (int i = 0; i < 20; i++)` became `while (num != 1)`
  after the decrement, and `Spawner` laid nineteen rows of obstacles per street instead of twenty.
- **Two adjacent `bool` fields written by one `strh` lost the second one.** The ISIL memory operand
  carried no access width, so a two byte store resolved to the one byte field at its offset and the
  byte past it was dropped. `Movement.right` was assigned nowhere in the class, which made `if (right)`
  unreachable and the character able to move only left. The width now reaches the generator, which
  splits the store when the fields it covers tile the range exactly - by constant where the value is
  one, and by shift and mask where it is not, which is how the keyboard path's packed `0x100` recovers
  as `right = true; left = false`.
- **An integer reaching a float field was not converted.** Every conversion, `scvtf` included, is
  lifted as a move, so `screenWidth = Screen.width` stored an `int` into a `float` - IL that ILSpy
  annotates `Expected F4, but got I4`. The conversion is now emitted at the load, where the wanted type
  is known. 33 of these remain on Pinata, all in code the generator reaches by another route.

Fixing the first exposed a fourth, in `Simplifier`: its "is this local read after here" walk marked the
start block visited before walking, so a read *before* the starting index - which a loop's back edge
reaches - was invisible. A counter's back-edge copy looked dead; dropping it left the counter singly
defined, which turned off the pass's own join guard and let the counter's initial value cross the loop
header. The trip count then read `while (20 != 1)`. The start block is re-entered once now.

What is left in the sixteen is faithful but verbose, and none of it is wrong:

- **`Vector3.MoveTowards` and `Mathf.Clamp01` are inlined**, so their arithmetic and their flag
  temporaries are spelled out at each call site. This is what the binary contains; folding it back would
  mean recognising a library function by its shape.
- **A `new Vector3(x, y, z)` arrives as three member stores** into a `default(Vector3)`, and one
  `Vector3 v = other` as a whole-struct assignment followed by redundant per-member copies.
- **`BoxRaRot` converts degrees to radians and back.** il2cpp inlined `Quaternion.Euler` as a multiply
  by `Deg2Rad` and a call to `Internal_FromEulerRad`; the recovery writes that call as
  `Quaternion.Euler(arg * 57.29578f)`, so the two multiplies both survive. The result differs from the
  source by about six parts in a hundred million. Cancelling them means seeing through the aggregate the
  per-component multiply was folded into.
- **Every branch may be inverted and every early return hoisted**, and a condition that the source
  wrote twice may appear once - `Checker.OnTriggerEnter` writes the high score after the if/else rather
  than inside both arms, which is where the compiler put it.

## 8e. A third game, and the largest

`Impostor-Sort-Puzzle-Pro` (Unity 2022.3.62f2, metadata v31.1, ARM64) ships its own source too, and is
three times the size of `RunFromZombiesFullProject` with Spine, DOTween, PlayMaker, Lean Pool and
CodeStage AntiCheatToolkit on top. `docs/articles/ImpostorSortScriptAudit.md` is the record: what was
fixed, what is faithful to the binary rather than to the source, and the six things still wrong, each
with the ISIL that shows it. The largest remaining one is that an unresolved call keeps the whole
register file as its arguments, which lets a later call read a register nothing wrote and pass `null`
where the source passed a field.

## 12. Measured against the third game's source, and fixed

Three defects found by ripping `Impostor-Sort-Puzzle-Pro` and reading the result against its own
source. `docs/articles/ImpostorSortScriptAudit.md` has them in full, `reports/regression-matrix.md`
the numbers, `reports/issues.json` the evidence. In short: 15 method bodies were exported as a `throw`
carrying the generator's own stack trace, and a body that threw contributes no placeholders so it was
invisible in every other metric; a value type's constructor call was dropped along with the reference
types', so `TimeInGame.CompareTo` compared two zeroed `DateTime`s; and a raiser handed a constructed
exception was named after the out-of-memory helper it is indistinguishable from by name, so
`throw new UnityException(message)` came back as `throw new OutOfMemoryException()` 563 times.

Four more followed from the same loop, each found by dumping the ISIL at the point the pass runs
rather than from reading the output: a **shared generic call** not retargeted onto the receiver's
instantiation, where the correct answer was already in the receiver's declared type (629 calls); the
**generic field layout** bailing on any base type with fields and on any user-defined struct field,
fixed and then gated on a self-check that reproduces every offset metadata carries (1394 exact, 0
disagreeing, where the walk had 63 wrong before); a **load not folded back** onto the base whose
address the machine computed for it, which cost three resolutions per occurrence; and a **runtime
class** answering zero where a `RuntimeTypeHandle` was wanted, though it carries the type it is the
class of.

Two more came out of inventorying the 850 loads reported as "past the last field of the base type"
instead of counting them - that family is four unrelated causes, and the 361 that dominated it have no
fields to be past, their base being the runtime generic context table. **An uninflated generic
definition is shared generic code**, so `RgctxResolver.ResolveTypeEntry` must use the definition's own
parameters as the arguments, which `ResolveMethodEntry` already did; and **a phi whose inputs disagree
must stay untyped**, where it had been taking the first one's type and spreading it backward.

Two more are the *order* the type fixpoint applies evidence in, which is the whole of the design
where the fixpoint is monotonic - the first type a local receives is the one it keeps, so a weaker
source arriving first is permanent. **A shared generic instantiation must not outrank the receiver**:
`List<System.Object>.get_Item` typed its result before the field declaring `List<LinkedMesh>` had
resolved, so `linkedMeshes[i].skin` could never come back. And **`System.Object` at a use site is
the top of the lattice, not evidence**: a delegate's two-argument constructor takes its target as
`System.Object`, which the copy rule then propagated backwards over a field metadata declares
outright. Both first cuts withheld evidence rather than ranking it and both measured worse, in the
same way: something weaker filled the gap. `reports/TYPE_RECOVERY_ANALYSIS.md` has the ranking as it
now stands, the two defects worked through, and what is left by family and by assembly.

One more is not a typing defect at all but is what most of the untyped bases turned out to be. An
architecture with no scaled index addressing mode computes an element's address before the load, and
**the fold for that matched one of the three shapes the compiler emits** - missing a constant index,
which has no register at all, and an index left in the addressing mode. Generalising it onto the
affine evaluator the struct-element path uses measured worse on every cut; the narrow shape is
precise because the shape itself proves the array is the base.

Impostor's own scripts went from 2162 REAL_ERROR audit diagnostics to 1052 and its `Assembly-CSharp`
from 499 Roslyn errors to 389 - while compiling 15 more bodies than before. Unresolved loads across
the whole rip are 5702 to 3569. **Assembly-CSharp holds 347 of those 3569**, and both of the easy
measurements cover only it, so count per assembly before concluding a change did nothing.
`AGENT_STATE.md` says where to pick up. **Read `reports/UNTYPED_LOCAL_IMPACT.md` before starting on
section 5**: 91% of the untyped locals provably cost nothing, and each of the fixes above removed
more of them than a typing rule would have.

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
