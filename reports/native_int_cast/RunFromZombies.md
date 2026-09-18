# `nint` cast theo producer — RunFromZombies

2983 cast, phân loại theo hình dạng của giá trị bị cast.

| producer | cast | file | ví dụ |
|---|---|---|---|
| `POINTER` | 276 | 47 | `object obj2 = (nint)obj + num4;` |
| `ARRAY` | 46 | 22 | `nint num = (nint)array2;` |
| `FIELD_ADDRESS` | 205 | 28 | `nint num = (nint)this;` |
| `OBJECT_REFERENCE` | 1440 | 92 | `nint num = (nint)writer;` |
| `HANDLE` | 78 | 23 | `text2 = (string)(nint)intPtr;` |
| `INTEGER` | 153 | 25 | `if ((nint)num4 < (nint)0)` |
| `UNKNOWN` | 785 | 87 | `nint num = (nint)t;` |
