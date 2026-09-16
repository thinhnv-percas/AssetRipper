# Compile failures by root cause

4896 errors across 424 files.

| cluster | category | errors | files | most common message |
|---|---|---|---|---|
| `NATIVE_INT_CAST` | CAST | 1525 | 147 | Cannot convert type 'System.Type' to 'nint' |
| `OTHER:CS0433` | OTHER | 1122 | 19 | The type 'TokenAttribute' exists in both 'AlmostEngine.Shared, Version=0.0.0.0, Culture=neutral, PublicKeyToke |
| `INVALID_CAST` | CAST | 623 | 78 | Cannot convert type 'Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<T>' to 'Cysharp.Threading.Tasks.UniTa |
| `ACCESSOR_VISIBILITY` | TYPE | 351 | 211 | 'ES3Cloud.Reset()': cannot change access modifiers when overriding 'protected internal' inherited member 'ES3W |
| `OPERATOR` | CALL | 289 | 39 | Operator '<<' cannot be applied to operands of type 'object' and 'int' |
| `INACCESSIBLE` | TYPE | 245 | 31 | 'Unsafe' is inaccessible due to its protection level |
| `FRAMEWORK_PRIVATE_MEMBER` | TYPE | 192 | 16 | 'List<Text>' does not contain a definition for '_version' and no accessible extension method '_version' accept |
| `MANGLED_IDENTIFIER` | DECOMPILER | 152 | 78 | 'Attribute' does not contain a definition for '_002Ector' |
| `MISSING_TYPE` | REFERENCE | 87 | 15 | The type or namespace name 'DocumentationSortingAttribute' could not be found (are you missing a using directi |
| `OTHER:CS0023` | OTHER | 51 | 4 | Operator '~' cannot be applied to operand of type 'object' |
| `OTHER:CS0115` | OTHER | 44 | 9 | 'CinemachineRecomposer.PrePipelineMutateCameraStateCallback(CinemachineVirtualCameraBase, ref CameraState, flo |
| `MEMBER_NOT_FOUND` | FIELD | 43 | 16 | 'bool' does not contain a definition for 'm_value' and no accessible extension method 'm_value' accepting a fi |
| `ATTRIBUTE_ARGUMENT` | DECOMPILER | 28 | 16 | 'menuName' is not a valid named attribute argument. Named attribute arguments must be fields which are not rea |
| `UNASSIGNED_LOCAL` | CONTROL_FLOW | 20 | 8 | Use of unassigned local variable 'obj' |
| `OTHER:CS0266` | OTHER | 20 | 7 | Cannot implicitly convert type 'object' to 'System.Exception'. An explicit conversion exists (are you missing  |
| `OTHER:CS0171` | OTHER | 15 | 3 | Field 'ValueDropdownItem<T>.Text' must be fully assigned before control is returned to the caller. Consider up |
| `OTHER:CS0426` | OTHER | 12 | 9 | The type name 'Stage' does not exist in the type 'CinemachineCore' |
| `OTHER:CS0103` | OTHER | 12 | 10 | The name 'DocumentationSortingAttribute' does not exist in the current context |
| `OTHER:CS1510` | OTHER | 7 | 5 | A ref or out value must be an assignable variable |
| `OTHER:CS0188` | OTHER | 7 | 4 | The 'this' object cannot be used before all of its fields have been assigned. Consider updating to language ve |
| `OTHER:CS1729` | OTHER | 7 | 5 | 'PropertyGroupAttribute' does not contain a constructor that takes 0 arguments |
| `PARSE` | DECOMPILER | 6 | 2 | Invalid expression term 'ref' |
| `UNSAFE` | DECOMPILER | 6 | 4 | Cannot initialize a by-reference variable with a value |
| `OTHER:CS1073` | OTHER | 6 | 4 | Unexpected token 'ref' |
| `OTHER:CS0039` | OTHER | 6 | 4 | Cannot convert type 'int' to 'System.OperationCanceledException' via a reference conversion, boxing conversion |
| `OTHER:CS0191` | OTHER | 5 | 2 | A readonly field cannot be assigned to (except in a constructor or init-only setter of the type in which the f |
| `OTHER:CS0052` | OTHER | 2 | 2 | Inconsistent accessibility: field type 'Cell.State' is less accessible than field 'Cell._state' |
| `OTHER:CS8174` | OTHER | 2 | 2 | A declaration of a by-reference variable must have an initializer |
| `OTHER:CS1605` | OTHER | 2 | 1 | Cannot use 'this' as a ref or out value because it is read-only |
| `OTHER:CS0106` | OTHER | 2 | 2 | The modifier 'abstract' is not valid for this item |
| `OTHER:CS0102` | OTHER | 1 | 1 | The type 'GameManager' already contains a definition for 'OnStateChanged' |
| `OTHER:CS0144` | OTHER | 1 | 1 | Cannot create an instance of the abstract type or interface 'PropertyGroupAttribute' |
| `OTHER:CS0619` | OTHER | 1 | 1 | 'EmittedAssemblyAttribute.EmittedAssemblyAttribute()' is obsolete: 'This attribute cannot be used in code, and |
| `OTHER:CS0149` | OTHER | 1 | 1 | Method name expected |
| `OTHER:CS0216` | OTHER | 1 | 1 | The operator 'int2.operator <(int2, int2)' requires a matching operator '>' to also be defined |
| `OTHER:CS8377` | OTHER | 1 | 1 | The type 'T' must be a non-nullable value type, along with all fields at any level of nesting, in order to use |
| `OTHER:CS8701` | OTHER | 1 | 1 | Target runtime doesn't support default interface implementation. |
