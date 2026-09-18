# `nint` cast theo producer — JellyBlastV2

17313 cast, phân loại theo hình dạng của giá trị bị cast.

| producer | cast | file | ví dụ |
|---|---|---|---|
| `POINTER` | 2756 | 255 | `obj = (nint)obj + 8;` |
| `ARRAY` | 825 | 139 | `object obj = (nint)array + 36;` |
| `FIELD_ADDRESS` | 2079 | 317 | `object obj = (nint)this + 40;` |
| `OBJECT_REFERENCE` | 9558 | 409 | `int num4 = num3 & (nint)obj;` |
| `HANDLE` | 64 | 25 | `if (fluidSolver.octopusHeadParticleCount > (nint)intPtr)` |
| `INTEGER` | 285 | 60 | `int num2 = (int)((nint)num | (nint)8);` |
| `UNKNOWN` | 1746 | 246 | `object obj4 = (nint)path + 32;` |
