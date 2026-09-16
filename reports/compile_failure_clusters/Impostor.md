# Compile failures by root cause

484 errors across 55 files.

| cluster | category | errors | files | most common message |
|---|---|---|---|---|
| `FRAMEWORK_PRIVATE_MEMBER` | TYPE | 192 | 13 | 'List<string>' does not contain a definition for '_version' and no accessible extension method '_version' acce |
| `INVALID_CAST` | CAST | 82 | 20 | Cannot convert type 'object*' to 'CodeStage.AntiCheat.ObscuredTypes.ObscuredInt' |
| `NATIVE_INT_CAST` | CAST | 81 | 19 | Cannot convert type 'System.Type' to 'nint' |
| `INACCESSIBLE` | TYPE | 26 | 10 | 'Int32Enum' is inaccessible due to its protection level |
| `MEMBER_NOT_FOUND` | FIELD | 22 | 6 | 'Exception' does not contain a definition for '_message' and no accessible extension method '_message' accepti |
| `OTHER:CS0470` | OTHER | 16 | 2 | Method 'RewardingAdBaseClient.add_OnAdLoaded(EventHandler<EventArgs>)' cannot implement interface accessor 'IR |
| `ATTRIBUTE_ARGUMENT` | DECOMPILER | 12 | 6 | 'menuName' is not a valid named attribute argument. Named attribute arguments must be fields which are not rea |
| `OPERATOR` | CALL | 10 | 4 | Operator '+' cannot be applied to operands of type 'object' and 'int' |
| `MANGLED_IDENTIFIER` | DECOMPILER | 9 | 6 | 'ItemBase' does not contain a definition for '_002Ector' |
| `OTHER:CS0535` | OTHER | 8 | 2 | 'RewardedAdClient' does not implement interface member 'IRewardedAdClient.OnAdLoaded' |
| `UNASSIGNED_LOCAL` | CONTROL_FLOW | 5 | 2 | Use of unassigned local variable 'enumerator2' |
| `ACCESSOR_VISIBILITY` | TYPE | 5 | 4 | 'SkeletonRootMotion.Start()': cannot change access modifiers when overriding 'protected internal' inherited me |
| `PARSE` | DECOMPILER | 4 | 3 | Invalid expression term 'ref' |
| `OTHER:CS7003` | OTHER | 2 | 2 | Unexpected use of an unbound generic name |
| `UNSAFE` | DECOMPILER | 2 | 1 | Cannot initialize a by-reference variable with a value |
| `OTHER:CS1073` | OTHER | 2 | 1 | Unexpected token 'ref' |
| `OTHER:CS1510` | OTHER | 2 | 1 | A ref or out value must be an assignable variable |
| `OTHER:CS0106` | OTHER | 2 | 2 | The modifier 'abstract' is not valid for this item |
| `OTHER:CS8174` | OTHER | 1 | 1 | A declaration of a by-reference variable must have an initializer |
| `OTHER:CS8701` | OTHER | 1 | 1 | Target runtime doesn't support default interface implementation. |
