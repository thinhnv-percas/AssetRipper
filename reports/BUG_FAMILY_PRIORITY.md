# Bug families, ranked by demonstrated correctness impact

Measured on iteration 009: 462 Roslyn errors over `Assembly-CSharp`, and
1410 audit diagnostics on the 46 files the reference source covers.
Ranked by what each family demonstrably breaks, not by count - the largest family is also the one
nothing can be done about.

Categories are the ones `reports/BLOCKED_UNITY_TESTS.md` and the audit use:
**REAL_ERROR** the export is wrong; **SEMANTIC_RISK** it compiles or nearly does but the meaning is
suspect; **EXPECTED** the export is faithful to the binary and the error is a property of compiling
against real assemblies; **UNRESOLVED** not yet classified.

| family | category | errors | files | example |
|---|---|---:|---:|---|
| framework internals il2cpp inlined | EXPECTED | 155 | 13 | `UserResource.cs:36  IntPtr invoke_impl = action.invoke_impl;` |
| another impossible conversion | REAL_ERROR | 141 | 19 | `CSVSerializer.cs:18  Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);` |
| a reference value converted to nint | REAL_ERROR | 111 | 18 | `GamePlayController.cs:227  object obj = (nint)this + 88;` |
| null assigned to an nint local | REAL_ERROR | 17 | 8 | `Item.cs:84  num = unchecked((nint)null);` |
| shared generic instantiation, from a local type | REAL_ERROR | 13 | 2 | `AdManager.cs:234  System.Int32Enum? int32Enum = null;` |
| arithmetic on mismatched types | REAL_ERROR | 8 | 3 | `GameHelper.cs:128  if ((num2 & 1) != 0)` |
| a constructor called on an existing object | SEMANTIC_RISK | 5 | 4 | `UserResourceInventory.cs:74  base._002Ector();` |
| a local not assigned on every path | SEMANTIC_RISK | 5 | 2 | `Item.cs:102  bool flag8 = num != 1;` |
| other (CS7003) | UNRESOLVED | 2 | 2 | `ResourcesUtil.cs:407  ((UserResourceItem<>)(object)userResourceItem).SetValue((object)inventoryNew.resources);` |
| other (CS0246) | UNRESOLVED | 2 | 1 | `ResourcesUtil.cs:408  List<_00210> collectionsValue = ((UserResourceInventory<_00210>)(object)userResourceItem).Collec` |
| other (CS1061) | UNRESOLVED | 1 | 1 | `UserResource.cs:37  IntPtr method_code = action.method_code;` |
| an inaccessible framework member | EXPECTED | 1 | 1 | `Item.cs:61  num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);` |
| other (CS0029) | UNRESOLVED | 1 | 1 | `CSVHelper.cs:123  throw list6;` |

Totals: **290 REAL_ERROR**, 10 SEMANTIC_RISK, 156 EXPECTED, 6 UNRESOLVED.

So the metric that matters is not 462 but **290**, and the 462 will not go to zero: 156 of it is
the export being right about a binary that inlined framework internals.

## The other axes

| family | count | compiler | semantic | runtime | affected reference methods | priority |
|---|---:|---|---|---|---|---|
| framework internals il2cpp inlined | 155 | yes | none - faithful | none | many, harmlessly | **none** - WONT_FIX, see DECOMP-0005 |
| a cast fed by an unresolved load | 0 | yes | **high** - the value is `(T)0`, so the read is lost | would read the wrong field or zero | `DataController`, `CSVSerializer`, `GUIManager` | **1** |
| a reference value converted to nint | 111 | yes | medium - an address computation whose field identity is lost | none if the address is only arithmetic | `Item`, `GamePlayController` | **2** |
| shared generic instantiation, from a local type | 13 | yes | medium - names a type internal to the framework | none | `EventDispatcher`, `AdManager` | **3** |
| null assigned to an nint local | 17 | yes | medium - a reference was typed as an integer | a null check on it would be wrong | several | **4** |
| a constructor called on an existing object | 5 | yes | low - the object is constructed at the `newobj` | none | `UserResource` | 5 - blocked behind family 1, see DECOMP-0006 |
| a local not assigned on every path | 5 | yes | low | none | `DataController` | 6 |
| arithmetic on mismatched types | 8 | yes | **high** - float and integer arithmetic differ | wrong number | `GameHelper` | 7 - small but real |

## What was worked, and in what order

The order above is not the order taken, because tractability matters as much as impact and the
evidence for one family sometimes only appears once another is fixed:

1. **DECOMP-0007, shared generic call targets** (iteration 008) - taken first because the correct
   answer was already in hand: the call named `Dictionary<Int32Enum, object>` while the receiver was
   typed `Dictionary<TypeResources, UserResource>`. 629 calls retargeted, Roslyn 497 to 487.
2. **DECOMP-0008, the generic field layout** (iteration 009) - family 1's root cause for the generic
   cases: the layout walk bailed on any base type with fields and on any user-defined struct field.
   Roslyn 487 to 462, audit 1502 to 1410, and the 63 layouts that were already *wrong* went to 0.
3. What remains of family 1 is loads off a base that has no type at all, which is the
   unresolved-load problem from the other side and is where the next iteration goes.
