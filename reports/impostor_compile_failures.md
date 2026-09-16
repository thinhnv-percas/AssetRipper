# Compile failures by root cause

1386 errors across 84 files.

| cluster | category | errors | files | most common message |
|---|---|---|---|---|
| `EVENT_BACKING_FIELD` | FIELD | 433 | 17 | Cannot convert type 'System.EventHandler<System.EventArgs>' to 'int' |
| `NATIVE_INT_CAST` | CAST | 413 | 41 | Cannot convert type 'System.Type' to 'nint' |
| `FRAMEWORK_PRIVATE_MEMBER` | TYPE | 214 | 16 | 'List<string>' does not contain a definition for '_version' and no accessible extension method '_version' acce |
| `INVALID_CAST` | CAST | 151 | 37 | Cannot convert type 'int' to 'string' |
| `MEMBER_NOT_FOUND` | FIELD | 47 | 10 | 'Exception' does not contain a definition for '_message' and no accessible extension method '_message' accepti |
| `INACCESSIBLE` | TYPE | 32 | 12 | 'Int32Enum' is inaccessible due to its protection level |
| `MANGLED_IDENTIFIER` | DECOMPILER | 25 | 14 | The type or namespace name '_003F' could not be found (are you missing a using directive or an assembly refere |
| `OPERATOR` | CALL | 17 | 8 | Operator '+' cannot be applied to operands of type 'object' and 'int' |
| `ACCESSOR_VISIBILITY` | TYPE | 16 | 7 | The property or indexer 'RequestConfiguration.Builder.MaxAdContentRating' cannot be used in this context becau |
| `ATTRIBUTE_ARGUMENT` | DECOMPILER | 12 | 6 | 'menuName' is not a valid named attribute argument. Named attribute arguments must be fields which are not rea |
| `UNASSIGNED_LOCAL` | CONTROL_FLOW | 5 | 2 | Use of unassigned local variable 'enumerator2' |
| `PARSE` | DECOMPILER | 4 | 3 | Invalid expression term 'ref' |
| `OTHER:CS7003` | OTHER | 2 | 2 | Unexpected use of an unbound generic name |
| `UNSAFE` | DECOMPILER | 2 | 1 | Cannot initialize a by-reference variable with a value |
| `OTHER:CS1073` | OTHER | 2 | 1 | Unexpected token 'ref' |
| `OTHER:CS1510` | OTHER | 2 | 1 | A ref or out value must be an assignable variable |
| `OTHER:CS0106` | OTHER | 2 | 2 | The modifier 'abstract' is not valid for this item |
| `OTHER:CS0102` | OTHER | 2 | 1 | The type 'SpineboyBeginnerModel' already contains a definition for 'StartAimEvent' |
| `OTHER:CS0191` | OTHER | 1 | 1 | A readonly field cannot be assigned to (except in a constructor or init-only setter of the type in which the f |
| `OTHER:CS0266` | OTHER | 1 | 1 | Cannot implicitly convert type 'object' to 'System.Exception'. An explicit conversion exists (are you missing  |
| `OTHER:CS1729` | OTHER | 1 | 1 | 'AndroidJavaProxy' does not contain a constructor that takes 0 arguments |
| `OTHER:CS8174` | OTHER | 1 | 1 | A declaration of a by-reference variable must have an initializer |
| `OTHER:CS8701` | OTHER | 1 | 1 | Target runtime doesn't support default interface implementation. |
