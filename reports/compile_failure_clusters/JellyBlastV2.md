# Compile failures by root cause

6630 errors across 165 files.

| cluster | category | errors | files | most common message |
|---|---|---|---|---|
| `NATIVE_INT_CAST` | CAST | 1862 | 92 | Cannot convert type 'string[]' to 'nint' |
| `INVALID_CAST` | CAST | 1746 | 81 | Cannot convert type 'int' to 'string' |
| `FRAMEWORK_PRIVATE_MEMBER` | TYPE | 1637 | 50 | 'List<int>' does not contain a definition for '_version' and no accessible extension method '_version' accepti |
| `INACCESSIBLE` | TYPE | 450 | 40 | 'Bounds.m_Extents' is inaccessible due to its protection level |
| `OPERATOR` | CALL | 434 | 46 | Operator '^' cannot be applied to operands of type 'float' and 'float' |
| `UNASSIGNED_LOCAL` | CONTROL_FLOW | 126 | 14 | Use of unassigned local variable 'array' |
| `MANGLED_IDENTIFIER` | DECOMPILER | 117 | 84 | 'object' does not contain a definition for '_002Ector' |
| `MEMBER_NOT_FOUND` | FIELD | 47 | 11 | 'int' does not contain a definition for 'm_value' and no accessible extension method 'm_value' accepting a fir |
| `ATTRIBUTE_ARGUMENT` | DECOMPILER | 41 | 27 | 'GenericTypeArguments' is not a valid named attribute argument. Named attribute arguments must be fields which |
| `OTHER:CS8174` | OTHER | 37 | 2 | A declaration of a by-reference variable must have an initializer |
| `OTHER:CS0149` | OTHER | 30 | 11 | Method name expected |
| `OTHER:CS0266` | OTHER | 21 | 4 | Cannot implicitly convert type 'object' to 'int'. An explicit conversion exists (are you missing a cast?) |
| `ACCESSOR_VISIBILITY` | TYPE | 15 | 10 | The property or indexer 'MinMax3D.Min' cannot be used in this context because the set accessor is inaccessible |
| `OTHER:CS1612` | OTHER | 13 | 2 | Cannot modify the return value of 'MinMax3D.Max' because it is not a variable |
| `UNSAFE` | DECOMPILER | 13 | 2 | Cannot initialize a by-reference variable with a value |
| `OTHER:CS1073` | OTHER | 13 | 2 | Unexpected token 'ref' |
| `OTHER:CS1510` | OTHER | 13 | 2 | A ref or out value must be an assignable variable |
| `OTHER:CS0170` | OTHER | 3 | 2 | Use of possibly unassigned field 'x' |
| `OTHER:CS0023` | OTHER | 3 | 1 | Operator '~' cannot be applied to operand of type 'float' |
| `OTHER:CS0216` | OTHER | 2 | 2 | The operator 'int2.operator <(int2, int)' requires a matching operator '>' to also be defined |
| `OTHER:CS0106` | OTHER | 2 | 2 | The modifier 'abstract' is not valid for this item |
| `OTHER:CS0053` | OTHER | 1 | 1 | Inconsistent accessibility: property type 'IFacebook' is less accessible than property 'FB.FacebookImpl' |
| `OTHER:CS0052` | OTHER | 1 | 1 | Inconsistent accessibility: field type 'JProperty.JPropertyList' is less accessible than field 'JProperty._con |
| `OTHER:CS0103` | OTHER | 1 | 1 | The name '_003CItem1_003Ek__BackingField' does not exist in the current context |
| `OTHER:CS0250` | OTHER | 1 | 1 | Do not directly call your base type Finalize method. It is called automatically from your destructor. |
| `OTHER:CS8701` | OTHER | 1 | 1 | Target runtime doesn't support default interface implementation. |
