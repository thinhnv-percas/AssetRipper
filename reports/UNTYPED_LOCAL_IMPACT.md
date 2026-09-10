# Untyped locals, classified by what they actually cost

Measured on iteration 009. 21618 locals reached the generator with no type and were
declared `object`, in 133 groups distinguished by the instruction that writes them and the
first that reads them. The generator raises each one from the single place that declares a local as
`object`, so the total is exact rather than a walk of the finished graph.

**The headline number is 91% noise, and this is the reason not to work from it.** Two of the four
buckets below cannot affect the output at all, and between them they are the great majority.

| bucket | locals | share | why |
|---|---:|---:|---|
| SAFE_NON_ESCAPING | 14583 | 67.5% | first read by an unresolved call or an `IndirectCall`. The generator emits a placeholder for such a call rather than loading its operands, so the local never reaches generated code and its type is never asked for. |
| SAFE_UNUSED | 5182 | 24.0% | never read. The declaration is emitted and nothing else; `DeadCodeEliminator` kept the definition because something else in the block needed to stay. |
| TYPE_INFERABLE | 1116 | 5.2% | written by an instruction whose result type follows from its operands or its opcode - arithmetic over known integers, `IsInst` (the type tested for), a resolved call (its return type), a copy of a typed local. These are the ones the type fixpoint could still take. |
| TYPE_UNKNOWN | 737 | 3.4% | written by something that says nothing about the type: an unresolved load, the return of a call whose target is unknown, or nothing at all. No rule can type these without first resolving what writes them. |

So the actionable set is **1853 locals, 8.6% of the total** - and of those, only the
`TYPE_INFERABLE` half is reachable by a typing rule. The other half needs whatever writes the local to
resolve first, which is the unresolved-load problem rather than a typing problem.

## The dispositions the instructions ask about, per bucket

For each bucket, what the local does downstream:

| | SAFE_UNUSED | SAFE_NON_ESCAPING | TYPE_INFERABLE | TYPE_UNKNOWN |
|---|---|---|---|---|
| never read | all | no | no | no |
| only written | all | no | no | no |
| passed to another method | no | to an *unresolved* call only, which is a placeholder | some | some |
| returned | no | no | some | some |
| stored into a field | no | no | some | some |
| used in arithmetic | no | no | most | some |
| used in a comparison | no | no | some | some |
| used in a branch condition | no | no | some | some |
| used in array indexing | no | no | some | some |
| cast | no | no | **yes - this is what they cost** | **yes** |
| boxed / unboxed | no | no | few | few |
| used as a generic argument | no | no | no | no |
| used in a constructor | no | no | few | few |
| used in a delegate | no | no | few | few |

## Top groups, per bucket

### SAFE_NON_ESCAPING

- **12325** — written by nothing, first read by an unresolved call
  - e.g. `TrackEntry.add_Event: v23`
- **1236** — written by nothing, first read by IndirectCall
  - e.g. `EventQueue.Start: v21`
- **359** — Add, first read by an unresolved call
  - e.g. `TrackEntry.add_Event: 20 Add v40 @ X20_v2, this @ X0 (Spine.TrackEntry), 88`
- **245** — Move from memory, first read by an unresolved call
  - e.g. `ExposedList`1..ctor: 10 Move v13 @ X0_v1, [v12 @ X8_v2 (Il2CppRgctx<Spine.ExposedList`1>)+10]`
- **150** — Call - the return of a call whose target is unknown, first read by an unresolved call
  - e.g. `ExposedList`1.AddEnumerable: 269 Call 1854E70, v237 @ X0_v27, v192 @ X0_v12 (System.OutOfMemoryException), v343 @ X1_v6 (System.Int32), v319 @ X2_v6, `

### SAFE_UNUSED

- **2341** — written by nothing [never read]
  - e.g. `TrackEntry.OnStart: v7`
- **969** — Call - the return of a call whose target is unknown [never read]
  - e.g. `VertexAttachment..ctor: 9 Call 1854CA0, v13 @ X0_v1, this @ X0 (Spine.VertexAttachment), name @ X1 (System.String), methodInfo @ X2 (Il2CppMethodInfo)`
- **791** — Move from memory [never read]
  - e.g. `Enumerator.MoveNext: 22 Move v38 @ X9_v3, [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]`
- **541** — Add [never read]
  - e.g. `Enumerator.MoveNext: 53 Add v138 @ X8_v7, [v38 @ X9_v3+10], [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]`
- **229** — IndirectCall [never read]
  - e.g. `ExposedList`1.AddCollection: 131 IndirectCall [v289 @ X0_v9], v212 @ X0_v11, collection @ X1 (System.Collections.Generic.ICollection`1<T>), this.Items`

### TYPE_INFERABLE

- **153** — Add, first read by Add
  - e.g. `ExposedList`1..ctor: 48 Add v137 @ X10_v5, [v69 @ X8_v18+B0], 8`
- **138** — Xor, first read by And
  - e.g. `TrackEntry.get_IsComplete: 9 Xor v10 @ TEMP2_v1, this.trackTime (System.Single), v4 @ V0_v2 (System.Single)`
- **134** — IsInst, first read by CheckEqual
  - e.g. `SkeletonBinary.ReadSkin: 145 IsInst v448 @ X0_v63, typeof(System.Object), v358[v297 @ X0_v60 (System.Int32)]`
- **118** — Subtract, first read by Move
  - e.g. `ExposedList`1..ctor: 69 Subtract v86 @ X9_v10, v128 @ X9_v8, 1`
- **61** — Multiply, first read by Add
  - e.g. `ExposedList`1.ConvertAll: 100 Multiply v355 @ TEMP_v19, v247 @ X27_v8 (System.Int32), [v351 @ X9_v14 (Il2CppClass<T[]>)+104]`

### TYPE_UNKNOWN

- **313** — Call - the return of a call whose target is unknown, first read by Newobj
  - e.g. `Enumerator.System.Collections.IEnumerator.get_Current: 53 Call AD94AC, v59 @ X0_v5, typeof(System.InvalidOperationException), [v34 @ X8_v3 (Il2CppRgct`
- **79** — written by nothing, first read by Multiply
  - e.g. `Bone.UpdateWorldTransform: v267`
- **57** — Call - the return of a call whose target is unknown, first read by Move
  - e.g. `ExposedList`1..ctor: 25 Call B348B0, v29 @ X0_v30, v44 @ X1_v4, v44 @ X1_v4, [v19 @ X8_v2 (Il2CppRgctx<Spine.ExposedList`1>)+20], v30 @ X3, v31 @ X4, `
- **39** — Move from memory, first read by Subtract
  - e.g. `ExposedList`1..ctor: 44 Move v128 @ X9_v8, [v69 @ X8_v18+12E]`
- **33** — written by nothing, first read by Move
  - e.g. `ExposedList`1.ConvertAll: v27`

## What this says to do

1. **Do not chase the untyped-local count.** 91% of it is unreachable by any typing rule, and a
   reduction in it is not by itself evidence of anything.
2. **The compile errors are not mostly untyped locals either.** On iteration 009 the largest error
   family is framework internals il2cpp inlined, which no typing rule touches, and the second is casts
   fed by an *unresolved load* - so the lever is load resolution, which is what iteration 009 did.
3. **Where a typing rule is the answer, take the seed from the strongest evidence available** and
   never from a phi whose inputs disagree. `reports/issues.json` DECOMP-0003 is the standing example
   of what following one input of a phi costs: eight injected checks stopped being recognised and 98
   compile errors appeared.
