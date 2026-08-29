# Dựng lại pipeline IL2CPP → C# bằng thư viện public

Tài liệu triển khai, viết để **mang sang project khác**. Khác với
[IL2CPP-PIPELINE.md](IL2CPP-PIPELINE.md) (mô tả DevX làm gì), file này trả lời:
*tôi tự viết lại thì dùng lib nào ở bước nào, code cụ thể ra sao*.

Ba điểm khác biệt so với bản DevX:

* **Không mã hóa gì cả.** DB struct là JSON đọc được bằng mắt, không cipher,
  không GZip bắt buộc.
* **Chạy được với metadata > v27.** DevX chết ở v27; hướng dẫn này mở tới v39.
* **Không có cổng license.** Không có `HiddenCalls`, không có "demo gate".

> **Nguồn dữ liệu.** Mọi con số và struct trong tài liệu này được đọc trực tiếp
> từ `Editor/Data/il2cpp/libil2cpp/` của Unity cài trên máy này
> (2022.3.62f2 và 6000.3.18f1), không phải nhớ lại. Đây cũng chính là phương pháp
> cốt lõi của tài liệu: **Unity ship toàn bộ source runtime IL2CPP kèm Editor**,
> nên không cần đoán bất kỳ layout nào.

---

## Mục lục

1. [Nguyên tắc nền: ground truth ở đâu](#1-nguyên-tắc-nền-ground-truth-ở-đâu)
2. [Bảng thư viện theo từng bước](#2-bảng-thư-viện-theo-từng-bước)
3. [Bố cục solution đề xuất](#3-bố-cục-solution-đề-xuất)
4. [Bước 1 — Metadata reader theo version](#4-bước-1--metadata-reader-theo-version)
5. [Bước 2 — Binary reader và ánh xạ VA ↔ file offset](#5-bước-2--binary-reader-và-ánh-xạ-va--file-offset)
6. [Bước 3 — Tìm CodeRegistration / MetadataRegistration](#6-bước-3--tìm-coderegistration--metadataregistration)
7. [Bước 4 — Bảng địa chỉ method](#7-bước-4--bảng-địa-chỉ-method)
8. [Bước 5 — Giải string literal (kể cả v27+)](#8-bước-5--giải-string-literal-kể-cả-v27)
9. [Bước 6 — Sinh dummy assembly](#9-bước-6--sinh-dummy-assembly)
10. [Bước 7 — DB struct runtime: tạo và dùng](#10-bước-7--db-struct-runtime-tạo-và-dùng)
11. [Bước 8 — Disassemble và lift thân hàm](#11-bước-8--disassemble-và-lift-thân-hàm)
12. [Bước 9 — Sinh C# và ghi project Unity](#12-bước-9--sinh-c-và-ghi-project-unity)
13. [Cập nhật cho metadata > v27](#13-cập-nhật-cho-metadata--v27)
14. [Harness kiểm chứng](#14-harness-kiểm-chứng)

---

## 1. Nguyên tắc nền: ground truth ở đâu

Đây là điều quan trọng nhất trong cả tài liệu. Mọi tool IL2CPP đều phải biết
layout của `Il2CppGlobalMetadataHeader`, `Il2CppTypeDefinition`,
`Il2CppCodeRegistration`, `Il2CppClass`… theo từng phiên bản Unity.

**Không cần reverse. Unity ship nguyên source runtime kèm Editor:**

```
<Unity>/Editor/Data/il2cpp/libil2cpp/
├── vm/GlobalMetadataFileInternals.h   ← layout file global-metadata.dat
├── vm/GlobalMetadata.cpp              ← version được assert, cách runtime đọc
├── il2cpp-class-internals.h           ← Il2CppClass, CodeRegistration, MetadataRegistration
├── il2cpp-object-internals.h          ← Il2CppObject, Il2CppString, Il2CppArray
├── il2cpp-metadata.h                  ← index typedef, Il2CppMetadataUsage
├── il2cpp-blob.h                      ← Il2CppTypeEnum
└── il2cpp-tabledefs.h                 ← TYPE_ATTRIBUTE_*, FIELD_ATTRIBUTE_*, METHOD_ATTRIBUTE_*
```

Cách lấy version metadata mà một bản Unity phát ra — một lệnh grep:

```bash
grep -n "s_GlobalMetadataHeader->version ==" \
  "<Unity>/Editor/Data/il2cpp/libil2cpp/vm/GlobalMetadata.cpp"
```

Kết quả đo trên máy này:

| Unity | metadata version | dòng |
|---|---|---|
| 2022.3.62f2 | **31** | `GlobalMetadata.cpp:330` |
| 6000.3.18f1 | **39** | `GlobalMetadata.cpp:371` |

Hệ quả thực tế: **cứ mỗi bản Unity muốn hỗ trợ, cài Editor đó một lần, copy
`libil2cpp/` ra, rồi sinh model từ header.** Đó là toàn bộ "bí quyết" của bộ DB
mà DevX bán kèm — và nó cũng giải thích vì sao DB của họ dừng ở 2021: họ ngừng
cài Editor mới.

`il2cpp-tabledefs.h` còn cho bạn toàn bộ hằng số attribute cần để in đúng
`public static readonly` — không phải tự chế bảng bit.

---

## 2. Bảng thư viện theo từng bước

| Bước | Thư viện | NuGet id | Vai trò |
|---|---|---|---|
| Đọc metadata | *(không cần)* | — | `BinaryReader` + reflection là đủ; xem mục 4 |
| Đọc PE | **AsmResolver.PE.File** | `AsmResolver.PE.File` | Section header, RVA↔offset |
| | *(thay thế)* PeNet | `PeNet` | Nhiều tiện ích hơn, nặng hơn |
| Đọc ELF | **ELFSharp** | `ELFSharp` | Program/section header, symbol table |
| Đọc Mach-O | **AsmResolver** / tự viết | — | Format đơn giản, ~200 dòng tự viết là xong |
| Đọc WASM | **dotnet-webassembly** | `WebAssembly` | Section, function table |
| Sinh assembly | **Mono.Cecil** | `Mono.Cecil` | Quen thuộc, tài liệu nhiều |
| | *(thay thế)* AsmResolver.DotNet | `AsmResolver.DotNet` | API hiện đại hơn, kiểm soát metadata sâu hơn |
| Disasm x86/x64 | **Iced** | `Iced` | Nhanh nhất, thuần C#, không native dll |
| Disasm ARM64 | **Disarm** | `Disarm` | Thuần C#, không native dll (Cpp2IL dùng) |
| Disasm mọi kiến trúc | **Capstone** | `Gee.External.Capstone` | Phủ rộng nhất, **cần native dll đi kèm** |
| Decompile nhánh Mono | **ICSharpCode.Decompiler** | `ICSharpCode.Decompiler` | ILSpy dạng thư viện, gọi in-process |
| Sinh DB struct | **clang** | *(có sẵn trong NDK đi kèm Unity)* | 3 lượt: `-fdump-record-layouts`, `-ast-dump`, `-dM -E`. Đã đóng gói sẵn: [tools/structdb_gen.py](tools/structdb_gen.py) — xem mục 10.2 |
| | *(thay thế)* ClangSharp | `ClangSharp` | Nếu muốn parse AST trong C# thay vì parse text |
| JSON | **System.Text.Json** | *(BCL)* | DB struct, config |

### Ghi chú license — đọc trước khi nhúng

Các thư viện trên đều permissive (MIT/BSD/Apache) theo hiểu biết hiện tại, **nhưng
license là thứ phải tự xác nhận lại tại thời điểm tích hợp**, không tin vào bảng
trong tài liệu. Hai điểm cần chú ý riêng:

* **Capstone** là BSD-3 nhưng bạn phải **ship file native** (`.dll`/`.so`) — cùng
  cái mà DevX đổi tên thành `arm_cp.dll`. Nếu muốn tránh native dependency hoàn
  toàn thì dùng **Iced (x86) + Disarm (ARM64)**, cả hai thuần C#.
* **Il2CppInspector** — nếu định copy code từ đó, kiểm tra license trước: nó
  **không** cùng loại permissive với Il2CppDumper. Copy nhầm là ràng buộc cả
  project của bạn. `Il2CppDumper` dễ tham chiếu hơn về mặt này.

Khuyến nghị: **đọc Il2CppDumper để hiểu thuật toán, tự viết lại code**, thay vì
copy — vừa sạch license vừa hiểu được thứ mình đang bảo trì.

---

## 3. Bố cục solution đề xuất

```
Il2CppRestore.sln
├── Il2CppRestore.Metadata/        ← mục 4, 5, 8: đọc global-metadata.dat, không phụ thuộc gì
│   ├── VersionAttribute.cs
│   ├── VersionedReader.cs
│   ├── MetadataStructs.cs         ← sinh/đối chiếu từ GlobalMetadataFileInternals.h
│   └── Il2CppMetadata.cs
├── Il2CppRestore.Binary/          ← mục 5, 6, 7
│   ├── IBinaryImage.cs
│   ├── ElfImage.cs / PeImage.cs / MachOImage.cs / WasmImage.cs
│   └── RegistrationSearch.cs
├── Il2CppRestore.StructDb/        ← mục 10
│   ├── StructDb.cs                ← model + loader JSON
│   └── Generator/                 ← tool riêng, chạy offline, cần Unity Editor
├── Il2CppRestore.Lift/            ← mục 11
│   ├── IArchLifter.cs
│   ├── Arm64Lifter.cs / X64Lifter.cs
│   └── Statements.cs
├── Il2CppRestore.Emit/            ← mục 9, 12
│   ├── DummyAssemblyBuilder.cs
│   ├── CSharpWriter.cs
│   └── UnityProjectWriter.cs
└── Il2CppRestore.Cli/
```

Quy tắc: **`Metadata` không được tham chiếu `Binary`.** Bạn phải đọc được
metadata cả khi không có binary (chế độ "fields only" chạy được ngay, cực nhanh,
và là thứ dùng nhiều nhất trong thực tế).

---

## 4. Bước 1 — Metadata reader theo version

Vấn đề: cùng một struct có field khác nhau giữa các version. Giải pháp chuẩn (và
là thứ Il2CppDumper làm) — **reader điều khiển bằng attribute**, không phải một
rừng `if (version >= x)`.

### 4.1 Attribute và reader

```csharp
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Text;

namespace Il2CppRestore.Metadata;

/// <summary>Field chỉ tồn tại trong khoảng version [Min, Max].</summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public sealed class VersionAttribute : Attribute
{
    public double Min { get; set; } = -1;
    public double Max { get; set; } = -1;

    public bool Applies(double v) =>
        (Min < 0 || v >= Min) && (Max < 0 || v <= Max);
}

public class VersionedReader : BinaryReader
{
    public double Version { get; set; }
    public bool Is32Bit { get; set; }

    // Cache reflection: đọc 20k typeDef mà mỗi lần GetFields() thì chậm gấp ~50 lần.
    private static readonly ConcurrentDictionary<Type, FieldInfo[]> FieldCache = new();

    public VersionedReader(Stream input) : base(input, Encoding.UTF8, leaveOpen: true) { }

    public long Position
    {
        get => BaseStream.Position;
        set => BaseStream.Position = value;
    }

    /// <summary>Con trỏ: 4 byte ở 32-bit, 8 byte ở 64-bit.</summary>
    public ulong ReadPointer() => Is32Bit ? ReadUInt32() : ReadUInt64();

    public T ReadStruct<T>() where T : new()
    {
        var result = new T();
        foreach (var f in FieldsFor(typeof(T)))
        {
            var attrs = (VersionAttribute[])f.GetCustomAttributes(typeof(VersionAttribute), false);
            if (attrs.Length > 0)
            {
                bool ok = false;
                foreach (var a in attrs) if (a.Applies(Version)) { ok = true; break; }
                if (!ok) continue;               // field không tồn tại ở version này -> BỎ QUA, không đọc byte nào
            }
            f.SetValue(result, ReadPrimitive(f.FieldType));
        }
        return result;
    }

    public T[] ReadStructArray<T>(long offset, long byteCount) where T : new()
    {
        Position = offset;
        int stride = SizeOf<T>();
        var arr = new T[byteCount / stride];
        for (int i = 0; i < arr.Length; i++) arr[i] = ReadStruct<T>();
        return arr;
    }

    private object ReadPrimitive(Type t)
    {
        if (t == typeof(byte))   return ReadByte();
        if (t == typeof(sbyte))  return ReadSByte();
        if (t == typeof(short))  return ReadInt16();
        if (t == typeof(ushort)) return ReadUInt16();
        if (t == typeof(int))    return ReadInt32();
        if (t == typeof(uint))   return ReadUInt32();
        if (t == typeof(long))   return ReadInt64();
        if (t == typeof(ulong))  return ReadUInt64();
        // Con trỏ trong struct của binary (không phải metadata file) khai báo là IntPtr:
        if (t == typeof(IntPtr)) return (IntPtr)(long)ReadPointer();
        // Struct lồng nhau (ví dụ Il2CppSectionMetadata ở v39):
        if (t.IsValueType || t.IsClass)
        {
            var m = typeof(VersionedReader).GetMethod(nameof(ReadStruct))!.MakeGenericMethod(t);
            return m.Invoke(this, null)!;
        }
        throw new NotSupportedException($"Kiểu field không hỗ trợ: {t}");
    }

    /// <summary>Kích thước struct ở version hiện tại — phải tính động vì field bị bật/tắt theo version.</summary>
    public int SizeOf<T>()
    {
        int size = 0;
        foreach (var f in FieldsFor(typeof(T)))
        {
            var attrs = (VersionAttribute[])f.GetCustomAttributes(typeof(VersionAttribute), false);
            if (attrs.Length > 0)
            {
                bool ok = false;
                foreach (var a in attrs) if (a.Applies(Version)) { ok = true; break; }
                if (!ok) continue;
            }
            size += SizeOfPrimitive(f.FieldType);
        }
        return size;
    }

    private int SizeOfPrimitive(Type t)
    {
        if (t == typeof(byte) || t == typeof(sbyte))   return 1;
        if (t == typeof(short) || t == typeof(ushort)) return 2;
        if (t == typeof(int) || t == typeof(uint))     return 4;
        if (t == typeof(long) || t == typeof(ulong))   return 8;
        if (t == typeof(IntPtr))                       return Is32Bit ? 4 : 8;
        int nested = 0;
        foreach (var f in FieldsFor(t)) nested += SizeOfPrimitive(f.FieldType);
        return nested;
    }

    private static FieldInfo[] FieldsFor(Type t) =>
        FieldCache.GetOrAdd(t, x => x.GetFields(BindingFlags.Public | BindingFlags.Instance));
}
```

**Ba điểm dễ sai:**

1. `GetFields()` **không đảm bảo thứ tự khai báo** theo spec CLR. Trên .NET
   Framework/CoreCLR hiện tại nó trả đúng thứ tự và Il2CppDumper dựa vào đó,
   nhưng nếu muốn chắc chắn thì thêm `[FieldOrder(n)]` rồi sort. Sai thứ tự =
   đọc rác mà không báo lỗi.
2. Metadata file **không có padding** — các struct đóng gói khít. Đừng dùng
   `Marshal.SizeOf`, nó sẽ cộng padding và lệch ngay.
3. `SizeOf<T>()` phải tính **theo version**, vì `byteCount / stride` là cách duy
   nhất biết số phần tử của mảng (header chỉ cho `offset` + `size` tính bằng byte).

### 4.2 Khai báo struct

Ví dụ `Il2CppTypeDefinition`, viết theo **diff đã kiểm chứng giữa v31 và v39**:

```csharp
public class Il2CppTypeDefinition
{
    public int nameIndex;
    public int namespaceIndex;
    public int byvalTypeIndex;

    // v31 và cũ hơn có byrefTypeIndex; đã bỏ từ một version nào đó — kiểm tra header
    // của đúng bản Unity bạn hỗ trợ rồi bật/tắt bằng [Version].
    [Version(Max = 24.1)] public int byrefTypeIndex;

    public int declaringTypeIndex;
    public int parentIndex;

    /// elementTypeIndex TỒN TẠI tới v31, BỊ BỎ ở v39 (đã đối chiếu 2022.3.62f2 vs 6000.3.18f1).
    [Version(Max = 31)] public int elementTypeIndex;

    [Version(Max = 24.1)] public int rgctxStartIndex;
    [Version(Max = 24.1)] public int rgctxCount;

    public int genericContainerIndex;
    public uint flags;

    public int fieldStart;
    public int methodStart;
    public int eventStart;
    public int propertyStart;
    public int nestedTypesStart;
    public int interfacesStart;
    public int vtableStart;
    public int interfaceOffsetsStart;

    public ushort method_count;
    public ushort property_count;
    public ushort field_count;
    public ushort event_count;
    public ushort nested_type_count;
    public ushort vtable_count;
    public ushort interfaces_count;
    public ushort interface_offsets_count;

    public uint bitfield;
    public uint token;

    // bitfield — comment trong header Unity nói rõ từng bit:
    public bool IsValueType => (bitfield & 1) != 0;
    public bool IsEnumType  => (bitfield & 2) != 0;
    public bool HasFinalize => (bitfield & 4) != 0;
    public bool HasCctor    => (bitfield & 8) != 0;
    public bool IsBlittable => (bitfield & 16) != 0;
}
```

### 4.3 Header và điểm rẽ nhánh v39

Đây là chỗ v39 phá vỡ mọi tool cũ. Header **không còn là dãy cặp
`offset`/`size`** mà là dãy `Il2CppSectionMetadata { offset, size, count }`:

```csharp
public struct Il2CppSectionMetadata   // chỉ tồn tại từ v39
{
    public int offset;
    public int size;
    public int count;
}
```

Cách xử lý sạch nhất: **định nghĩa header ở dạng trung gian**, đọc bằng hai
nhánh, phần còn lại của tool không cần biết:

```csharp
/// Mỗi "section" của metadata quy về một cặp (offset, byteSize) thống nhất.
public readonly record struct Section(int Offset, int Size);

public sealed class MetadataHeader
{
    public uint Sanity;
    public int  Version;

    public Section StringLiterals, StringLiteralData, Strings;
    public Section Events, Properties, Methods;
    public Section ParameterDefaultValues, FieldDefaultValues, FieldAndParameterDefaultValueData;
    public Section FieldMarshaledSizes, Parameters, Fields;
    public Section GenericParameters, GenericParameterConstraints, GenericContainers;
    public Section NestedTypes, Interfaces, VTableMethods, InterfaceOffsets;
    public Section TypeDefinitions, Images, Assemblies;
    public Section FieldRefs, ReferencedAssemblies;

    // v24..v27
    public Section MetadataUsageLists, MetadataUsagePairs;
    public Section AttributesInfo, AttributeTypes;
    // v29+
    public Section AttributeData, AttributeDataRanges;

    public static MetadataHeader Read(VersionedReader r)
    {
        r.Position = 0;
        var h = new MetadataHeader { Sanity = r.ReadUInt32(), Version = r.ReadInt32() };
        if (h.Sanity != 0xFAB11BAF)
            throw new InvalidDataException("Không phải global-metadata.dat");
        r.Version = h.Version;

        // Đọc một section theo đúng bố cục của version
        Section Next() => h.Version >= 39
            ? ReadTriple(r)     // { offset, size, count }
            : ReadPair(r);      // { offset, size }

        h.StringLiterals    = Next();
        h.StringLiteralData = Next();
        h.Strings           = Next();
        h.Events            = Next();
        h.Properties        = Next();
        h.Methods           = Next();
        h.ParameterDefaultValues = Next();
        h.FieldDefaultValues     = Next();
        h.FieldAndParameterDefaultValueData = Next();
        h.FieldMarshaledSizes = Next();
        h.Parameters = Next();
        h.Fields     = Next();
        h.GenericParameters = Next();
        h.GenericParameterConstraints = Next();
        h.GenericContainers = Next();
        h.NestedTypes = Next();
        h.Interfaces  = Next();
        h.VTableMethods = Next();
        h.InterfaceOffsets = Next();
        h.TypeDefinitions = Next();

        if (h.Version <= 24.1)                 // vị trí của rgctx… thay đổi ở các bản cũ
            SkipLegacySections(r, h);

        h.Images     = Next();
        h.Assemblies = Next();

        if (h.Version <= 27) {                 // biến mất từ v29
            h.MetadataUsageLists = Next();
            h.MetadataUsagePairs = Next();
        }

        h.FieldRefs = Next();
        h.ReferencedAssemblies = Next();

        if (h.Version <= 27) {
            h.AttributesInfo = Next();         // Il2CppCustomAttributeTypeRange
            h.AttributeTypes = Next();         // TypeIndex[]
        } else {
            h.AttributeData      = Next();     // blob nhị phân
            h.AttributeDataRanges = Next();    // Il2CppCustomAttributeDataRange
        }
        // … các section còn lại (unresolvedIndirectCall*, windowsRuntime*, exportedTypeDefinitions)
        return h;
    }

    private static Section ReadPair(VersionedReader r)   => new(r.ReadInt32(), r.ReadInt32());
    private static Section ReadTriple(VersionedReader r) { int o = r.ReadInt32(), s = r.ReadInt32(); r.ReadInt32(); return new(o, s); }
}
```

**Cách tự kiểm tra bạn đọc header đúng** — runtime của Unity tự assert điều này
(`GlobalMetadata.cpp:331`), và bạn nên assert y hệt:

```csharp
// stringLiteralOffset LUÔN bằng đúng sizeof(Il2CppGlobalMetadataHeader).
// Nếu lệch -> bạn đọc thiếu/thừa một section. Đây là bài test rẻ nhất và mạnh nhất.
Debug.Assert(h.StringLiterals.Offset == bytesConsumedByHeader);
```

Thứ tự section trong `Next()` phải copy **đúng thứ tự khai báo** trong
`GlobalMetadataFileInternals.h` của bản Unity tương ứng. Đó là lý do mục 13 bảo
bạn mở header ra đối chiếu chứ đừng đoán.

---

## 5. Bước 2 — Binary reader và ánh xạ VA ↔ file offset

Interface tối thiểu mà mọi bước sau cần:

```csharp
public interface IBinaryImage
{
    bool Is32Bit { get; }
    Architecture Arch { get; }        // Arm32 | Arm64 | X86 | X64 | Wasm

    /// Virtual address -> file offset. Trả về -1 nếu VA không nằm trong vùng nào.
    long MapVaToOffset(ulong va);
    /// File offset -> virtual address.
    ulong MapOffsetToVa(long offset);

    ReadOnlySpan<byte> Data { get; }
    IEnumerable<(string Name, ulong Va, long Offset, long Size, bool Executable)> Sections { get; }
    IReadOnlyDictionary<string, ulong> Symbols { get; }   // rỗng nếu đã strip
}
```

### 5.1 ELF (Android / Linux) — ELFSharp

```csharp
using ELFSharp.ELF;
using ELFSharp.ELF.Segments;

public sealed class ElfImage : IBinaryImage
{
    private readonly IELF _elf;
    private readonly byte[] _data;
    private readonly List<(ulong Va, ulong Size, long Off)> _map = new();

    public ElfImage(string path)
    {
        _data = File.ReadAllBytes(path);
        _elf  = ELFReader.Load(path);
        Is32Bit = _elf.Class == Class.Bit32;

        // Ánh xạ dựa trên PROGRAM header (PT_LOAD), KHÔNG phải section header:
        // nhiều .so đã bị strip section header, và ảnh chạy thật do PT_LOAD quyết định.
        foreach (var seg in _elf.Segments)
        {
            if (seg.Type != SegmentType.Load) continue;
            _map.Add((seg.Address, (ulong)seg.Size, seg.Offset));
        }
        _map.Sort((a, b) => a.Va.CompareTo(b.Va));
    }

    public bool Is32Bit { get; }
    public ReadOnlySpan<byte> Data => _data;

    public long MapVaToOffset(ulong va)
    {
        foreach (var (segVa, size, off) in _map)
            if (va >= segVa && va < segVa + size)
                return off + (long)(va - segVa);
        return -1;
    }

    public ulong MapOffsetToVa(long offset)
    {
        foreach (var (segVa, size, off) in _map)
            if (offset >= off && offset < off + (long)size)
                return segVa + (ulong)(offset - off);
        return 0;
    }
}
```

> **Bẫy thường gặp:** file `.so` được dump từ RAM (`libil2cpp.so` lấy bằng
> GameGuardian/Frida) có VA == file offset, `p_offset` bị ghi đè. Phát hiện bằng
> cách so `e_shoff`/section với thực tế, hoặc đơn giản là thử cả hai kiểu ánh xạ
> và chọn cái làm bước 3 thành công. Il2CppDumper gọi trường hợp này là
> `IsDumped`, và khi đó bạn phải hỏi người dùng **base address lúc dump**.

### 5.2 PE (Windows) — AsmResolver

```csharp
using AsmResolver.PE.File;

public sealed class PeImage : IBinaryImage
{
    private readonly PEFile _pe;
    public PeImage(string path) { _pe = PEFile.FromFile(path); }

    public long MapVaToOffset(ulong va)
    {
        ulong imageBase = _pe.OptionalHeader.ImageBase;
        if (va < imageBase) return -1;
        uint rva = (uint)(va - imageBase);
        foreach (var s in _pe.Sections)
            if (rva >= s.Rva && rva < s.Rva + s.GetVirtualSize())
                return s.Offset + (rva - s.Rva);
        return -1;
    }
}
```

### 5.3 Mach-O

Tự viết là hợp lý: đọc `mach_header(_64)`, duyệt `LC_SEGMENT_64`, mỗi
`section_64` cho `(addr, size, offset)`. Nếu là FAT (`0xCAFEBABE` big-endian),
đọc `fat_header` → chọn `cputype` bạn cần rồi đệ quy vào offset của slice.

---

## 6. Bước 3 — Tìm CodeRegistration / MetadataRegistration

Hai struct này giữ toàn bộ con trỏ hàm nhưng **không có symbol**. Phương pháp
đáng tin nhất không phải "quét mù" mà là **quét có ràng buộc đếm**: bạn đã biết
chính xác số image, số type, số method từ metadata, và các struct này chứa đúng
những con số đó.

Layout (đã đối chiếu 2022.3 và 6000.3 — **giống hệt nhau**, ổn định):

```c
typedef struct Il2CppMetadataRegistration {
    int32_t genericClassesCount;                    const void* genericClasses;
    int32_t genericInstsCount;                      const void* genericInsts;
    int32_t genericMethodTableCount;                const void* genericMethodTable;
    int32_t typesCount;                             const void* types;
    int32_t methodSpecsCount;                       const void* methodSpecs;
    int32_t fieldOffsetsCount;                      const void* fieldOffsets;
    int32_t typeDefinitionsSizesCount;              const void* typeDefinitionsSizes;
    size_t  metadataUsagesCount;                    const void* metadataUsages;
} Il2CppMetadataRegistration;

typedef struct Il2CppCodeRegistration {
    /* … */
    uint32_t codeGenModulesCount;                   const void** codeGenModules;   // ← phần tử CUỐI
} Il2CppCodeRegistration;
```

Nhận xét quyết định: cả hai struct kết thúc bằng cặp `(count, pointer)`, và
`count` đó ta **biết trước**:

* `Il2CppCodeRegistration.codeGenModulesCount == metadata.Images.Length`
* `Il2CppMetadataRegistration.typeDefinitionsSizesCount == metadata.TypeDefs.Length`

```csharp
public static class RegistrationSearch
{
    /// <summary>
    /// Quét mọi vị trí thẳng hàng con trỏ trong các section dữ liệu, tìm cụm
    /// (count, ptr) khớp số lượng đã biết, rồi lùi về đầu struct và xác nhận
    /// mọi con trỏ bên trong đều map được sang file offset.
    /// </summary>
    public static ulong FindCodeRegistration(IBinaryImage img, int imageCount)
    {
        int ptr = img.Is32Bit ? 4 : 8;
        // Trong Il2CppCodeRegistration, codeGenModulesCount nằm ở phần tử áp chót.
        // Toàn struct = 17 slot (đếm từ header Unity), phần tử cuối là con trỏ.
        const int slotsBefore = 16;

        foreach (var sec in img.Sections)
        {
            if (sec.Executable) continue;                    // registration nằm ở .data/.data.rel.ro
            for (long off = sec.Offset; off + ptr * 2 <= sec.Offset + sec.Size; off += ptr)
            {
                ulong count = ReadPointer(img, off);
                if (count != (ulong)imageCount) continue;    // ràng buộc 1: đúng số assembly

                ulong modulesPtr = ReadPointer(img, off + ptr);
                if (img.MapVaToOffset(modulesPtr) < 0) continue;   // ràng buộc 2: con trỏ hợp lệ

                // ràng buộc 3: mảng codeGenModules phải toàn con trỏ hợp lệ
                long arr = img.MapVaToOffset(modulesPtr);
                bool ok = true;
                for (int i = 0; i < imageCount && ok; i++)
                    ok = img.MapVaToOffset(ReadPointer(img, arr + (long)i * ptr)) >= 0;
                if (!ok) continue;

                // lùi về đầu struct
                long structOff = off - (long)slotsBefore * ptr;
                if (structOff < sec.Offset) continue;
                return img.MapOffsetToVa(structOff);
            }
        }
        return 0;
    }

    private static ulong ReadPointer(IBinaryImage img, long off) =>
        img.Is32Bit ? BitConverter.ToUInt32(img.Data.Slice((int)off, 4))
                    : BitConverter.ToUInt64(img.Data.Slice((int)off, 8));
}
```

`FindMetadataRegistration` viết y hệt, đổi ràng buộc thành
`typeDefinitionsSizesCount == typeDefs.Length` **và** `typesCount > 0` **và**
`methodSpecsCount >= 0`, rồi lùi 12 slot.

**Đường tắt nên thử trước:** nếu binary còn symbol (một số build Android debug,
hầu hết build Linux), tìm thẳng `g_CodeRegistration` / `g_MetadataRegistration`
trong `img.Symbols`. Rẻ và chắc chắn đúng. Chỉ rơi xuống quét khi không có.

**Đường tắt thứ hai:** trên ELF có `.dynsym`, hàm `il2cpp_init` thường là symbol
export. Disassemble nó, hai giá trị hằng lớn đầu tiên nạp vào thanh ghi chính là
địa chỉ hai struct. Cách này nhanh nhưng phụ thuộc trình biên dịch.

---

## 7. Bước 4 — Bảng địa chỉ method

Sau bước 3 bạn có `codeGenModules` — mảng con trỏ, mỗi phần tử là một
`Il2CppCodeGenModule` (layout đã kiểm chứng, giống nhau giữa 2022.3 và 6000.3):

```c
typedef struct Il2CppCodeGenModule {
    const char* moduleName;
    const uint32_t methodPointerCount;
    const Il2CppMethodPointer* methodPointers;   // ← cái ta cần
    const uint32_t adjustorThunkCount;
    const Il2CppTokenAdjustorThunkPair* adjustorThunks;
    const int32_t* invokerIndices;
    /* … rgctx, debuggerMetadata, moduleInitializer, staticConstructorTypeIndices … */
    const Il2CppMetadataRegistration* metadataRegistration;  // chỉ ở per-assembly mode
    const Il2CppCodeRegistration* codeRegistaration;         // (sic — typo trong Unity)
} Il2CppCodeGenModule;
```

Ánh xạ method → địa chỉ:

```csharp
/// <summary>
/// Trả về VA của thân method, hoặc 0 nếu method không có code
/// (abstract / extern / bị strip).
/// </summary>
public ulong GetMethodPointer(string moduleName, Il2CppMethodDefinition m)
{
    if (m.methodIndex < 0) return 0;
    var module = _codeGenModules[moduleName];

    // Từ v24.2 trở đi, index tra trong methodPointers là RID của token, không phải methodIndex.
    uint rid = m.token & 0x00FFFFFF;
    if (rid == 0 || rid > module.methodPointerCount) return 0;

    long arr = _img.MapVaToOffset(module.methodPointers);
    return ReadPointer(arr + (long)(rid - 1) * PointerSize);
}
```

### Độ dài hàm — đừng lặp lại sai lầm của DevX

Metadata **không lưu độ dài hàm**. Cách phổ biến (và cách DevX dùng) là lấy
khoảng cách tới con trỏ hàm kế tiếp:

```csharp
/// <summary>Bảng VA -> VA kế tiếp, dùng để ƯỚC LƯỢNG độ dài hàm.</summary>
public SortedDictionary<ulong, ulong> BuildFunctionBoundaries()
{
    var all = new SortedSet<ulong>();
    foreach (var m in AllMethodPointers()) all.Add(m);
    foreach (var m in AllGenericMethodPointers()) all.Add(m);
    foreach (var m in AllInvokerPointers()) all.Add(m);      // ĐỪNG QUÊN: invoker nằm xen kẽ
    foreach (var s in _img.Sections) if (s.Executable) all.Add(s.Va + (ulong)s.Size);  // biên section

    var result = new SortedDictionary<ulong, ulong>();
    ulong? prev = null;
    foreach (var va in all) { if (prev is ulong p) result[p] = va; prev = va; }
    return result;
}
```

Ba cải tiến so với DevX, đáng làm ngay từ đầu:

1. **Gộp cả invoker và generic method pointer** vào tập biên. DevX chỉ dùng một
   phần, nên nhiều hàm bị ước lượng dài quá và lift lấn sang hàm kế.
2. **Thêm biên section** để hàm cuối cùng không có `len` vô hạn.
3. **Cắt sớm khi gặp lệnh kết thúc**: `RET` (ARM64) / `ret` (x86) ở mức nesting 0
   là biên thật. Ưu tiên giá trị này hơn ước lượng, và ghi ngược lại vào bảng.

---

## 8. Bước 5 — Giải string literal (kể cả v27+)

Đây là chỗ mọi tool cũ chết ở Unity mới, nên viết kỹ.

### 8.1 Bản chất

Mã máy không chứa chuỗi. Nó nạp một con trỏ từ mảng
`Il2CppMetadataRegistration.metadataUsages[]`. Mỗi slot ở trạng thái **chưa khởi
tạo** (tức là giá trị nằm sẵn trong file) chứa một **token đã mã hóa**: 3 bit cao
là loại, phần còn lại là index.

Trích nguyên văn `il2cpp-metadata.h` (2022.3.62f2):

```c
// Il2CppClass       001               0x20000000
// Il2CppType        010               0x40000000
// MethodInfo        011               0x60000000
// FieldInfo         100               0x80000000
// StringLiteral     101               0xA0000000
// MethodRef         110               0xC0000000
// FieldRVA          111               0xE0000000

static inline Il2CppMetadataUsage GetEncodedIndexType(EncodedMethodIndex index)
{ return (Il2CppMetadataUsage)((index & 0xE0000000) >> 29); }

static inline uint32_t GetDecodedMethodIndex(EncodedMethodIndex index)
{ return (index & 0x1FFFFFFEU) >> 1; }
```

Và runtime giải nó đúng như sau (`GlobalMetadata.cpp:353`):

```cpp
for (size_t i = 0; i < s_Il2CppMetadataRegistration->metadataUsagesCount; i++)
{
    uintptr_t* metadataPointer = reinterpret_cast<uintptr_t*>(s_Il2CppMetadataRegistration->metadataUsages[i]);
    Il2CppMetadataUsage usage = GetEncodedIndexType(static_cast<uint32_t>(*metadataPointer));
    ...
}
```

### 8.2 Vì sao điều này quan trọng

* **v24–v27:** bảng `metadataUsageLists` + `metadataUsagePairs` nằm **trong
  global-metadata.dat**. Tool cũ đọc từ đó.
* **v29 trở lên:** hai bảng đó **đã bị xóa khỏi metadata file** (kiểm chứng: header
  của 2022.3 và 6000.3 không còn field nào tên `metadataUsage*`).

Nhưng `Il2CppMetadataRegistration.metadataUsages` **vẫn còn trong binary**. Nên
thuật toán mới đơn giản hơn cả thuật toán cũ: **đọc thẳng giá trị khởi tạo của
từng slot trong file và giải mã**. Không cần bảng phụ nào cả.

```csharp
public enum UsageKind { Invalid = 0, TypeInfo = 1, Il2CppType = 2, MethodDef = 3,
                        FieldInfo = 4, StringLiteral = 5, MethodRef = 6, FieldRva = 7 }

public readonly record struct Usage(UsageKind Kind, uint Index);

/// <summary>
/// VA của slot -> ý nghĩa. Hoạt động cho MỌI version có metadataUsages trong binary
/// (v19 trở đi), và là con đường DUY NHẤT từ v29.
/// </summary>
public Dictionary<ulong, Usage> BuildUsageMap()
{
    var map = new Dictionary<ulong, Usage>();
    long arr = _img.MapVaToOffset(_metadataRegistration.metadataUsages);
    if (arr < 0) return map;

    for (long i = 0; i < (long)_metadataRegistration.metadataUsagesCount; i++)
    {
        ulong slotVa = ReadPointer(arr + i * PointerSize);   // địa chỉ ô nhớ trong .data
        long slotOff = _img.MapVaToOffset(slotVa);
        if (slotOff < 0) continue;

        uint encoded = BitConverter.ToUInt32(_img.Data.Slice((int)slotOff, 4));
        var kind  = (UsageKind)((encoded & 0xE0000000u) >> 29);
        uint idx  = (encoded & 0x1FFFFFFEu) >> 1;
        if (kind != UsageKind.Invalid) map[slotVa] = new Usage(kind, idx);
    }
    return map;
}

/// <summary>Đọc chuỗi thật từ metadata theo index.</summary>
public string GetStringLiteral(uint index)
{
    // Il2CppStringLiteral { int32 length; int32 dataIndex; }
    long off = _header.StringLiterals.Offset + index * 8;
    _r.Position = off;
    int length    = _r.ReadInt32();
    int dataIndex = _r.ReadInt32();
    _r.Position = _header.StringLiteralData.Offset + dataIndex;
    return Encoding.UTF8.GetString(_r.ReadBytes(length));
}
```

Khi bộ lift thấy `ADRP x0, page; LDR x0, [x0, #off]`, nó tính `page+off`, tra
`BuildUsageMap()`, và nếu là `StringLiteral` thì in ra chuỗi thật.

> **Cảnh báo cho bản "master metadata" / per-assembly mode.** Ở chế độ
> per-assembly (Unity 2021.2+ với `Il2CppCodeGenModule.metadataRegistration != null`),
> mỗi module có bảng registration RIÊNG. Phải lặp qua từng module thay vì dùng
> một bảng global. Kiểm tra field `metadataRegistration` trong mỗi codeGenModule;
> khác null tức là đang ở chế độ đó.

---

## 9. Bước 6 — Sinh dummy assembly

Mục đích: có một bộ `.dll` hợp lệ để (a) làm type resolver, (b) mở được bằng
ILSpy/dnSpy, (c) làm reference khi biên dịch lại project.

```csharp
using Mono.Cecil;
using Mono.Cecil.Cil;

public sealed class DummyAssemblyBuilder
{
    private readonly Il2CppMetadata _md;
    private readonly Dictionary<int, TypeDefinition> _byTypeIndex = new();

    public List<AssemblyDefinition> Build()
    {
        var assemblies = new List<AssemblyDefinition>();

        // PASS 1 — tạo vỏ: assembly, module, và mọi TypeDefinition rỗng.
        // Bắt buộc tách 2 pass: type A có thể kế thừa type B khai báo sau nó.
        foreach (var img in _md.Images)
        {
            string name = _md.GetString(img.nameIndex);
            var asm = AssemblyDefinition.CreateAssembly(
                new AssemblyNameDefinition(Path.GetFileNameWithoutExtension(name), new Version(0, 0, 0, 0)),
                name, ModuleKind.Dll);
            assemblies.Add(asm);

            for (int i = 0; i < img.typeCount; i++)
            {
                int ti = img.typeStart + i;
                var td = _md.TypeDefs[ti];
                var type = new TypeDefinition(
                    _md.GetString(td.namespaceIndex),
                    _md.GetString(td.nameIndex),
                    (TypeAttributes)td.flags);
                _byTypeIndex[ti] = type;

                // Nested type KHÔNG được Add vào Types của module — Cecil sẽ ném lỗi khi ghi.
                if (td.declaringTypeIndex < 0) asm.MainModule.Types.Add(type);
            }
        }

        // PASS 2 — điền quan hệ và thành viên.
        foreach (var (ti, type) in _byTypeIndex)
        {
            var td = _md.TypeDefs[ti];
            var module = type.Module;

            if (td.declaringTypeIndex >= 0)
            {
                var outer = _byTypeIndex[_md.GetTypeDefIndexFromTypeIndex(td.declaringTypeIndex)];
                outer.NestedTypes.Add(type);
            }
            if (td.parentIndex >= 0)
                type.BaseType = ResolveTypeRef(module, _md.Types[td.parentIndex]);

            for (int i = 0; i < td.interfaces_count; i++)
                type.Interfaces.Add(new InterfaceImplementation(
                    ResolveTypeRef(module, _md.Types[_md.InterfaceIndices[td.interfacesStart + i]])));

            // Fields
            for (int i = 0; i < td.field_count; i++)
            {
                var fd = _md.Fields[td.fieldStart + i];
                var field = new FieldDefinition(
                    _md.GetString(fd.nameIndex),
                    (FieldAttributes)_md.Types[fd.typeIndex].attrs,
                    ResolveTypeRef(module, _md.Types[fd.typeIndex]));

                // Giá trị hằng: literal phải có Constant, nếu không ILSpy hiển thị sai.
                if (_md.TryGetFieldDefaultValue(td.fieldStart + i, out object? cv))
                    field.Constant = cv;

                type.Fields.Add(field);
            }

            // Methods — thân rỗng nhưng PHẢI hợp lệ IL, nếu không Cecil ghi ra dll hỏng.
            for (int i = 0; i < td.method_count; i++)
            {
                var mdz = _md.Methods[td.methodStart + i];
                var method = new MethodDefinition(
                    _md.GetString(mdz.nameIndex),
                    (MethodAttributes)mdz.flags,
                    ResolveTypeRef(module, _md.Types[mdz.returnType]));

                for (int p = 0; p < mdz.parameterCount; p++)
                {
                    var pd = _md.Parameters[mdz.parameterStart + p];
                    method.Parameters.Add(new ParameterDefinition(
                        _md.GetString(pd.nameIndex),
                        ParameterAttributes.None,
                        ResolveTypeRef(module, _md.Types[pd.typeIndex])));
                }

                if (!method.IsAbstract && (mdz.flags & 0x2000 /*PInvokeImpl*/) == 0)
                {
                    var il = method.Body.GetILProcessor();
                    il.Append(il.Create(OpCodes.Ldnull));
                    il.Append(il.Create(OpCodes.Throw));
                }

                // Attribute mang địa chỉ gốc — cực kỳ hữu ích khi mở dll bằng dnSpy.
                method.CustomAttributes.Add(MakeAddressAttribute(module, GetMethodPointer(mdz)));
                type.Methods.Add(method);
            }
        }

        return assemblies;
    }
}
```

**Bốn lỗi hay gặp khi ghi bằng Cecil:**

1. Nested type bị Add vào cả `module.Types` lẫn `outer.NestedTypes` → `Write()` ném.
2. Method không abstract mà `Body` rỗng → dll không verify được.
3. `TypeAttributes`/`MethodAttributes` lấy thẳng từ `flags` là **đúng** — IL2CPP
   giữ nguyên giá trị của ECMA-335, kiểm chứng được trong `il2cpp-tabledefs.h`.
4. Generic parameter phải được thêm **trước** khi dùng làm kiểu của field/param,
   nếu không Cecil resolve sang `!0` sai chỉ số.

---

## 10. Bước 7 — DB struct runtime: tạo và dùng

Đây là phần thay thế `.dvxil2c`. Mục tiêu: **JSON, không mã hóa, sinh tự động,
kiểm chứng được bằng mắt và bằng diff.**

### 10.1 Format

Đây là format thật của [structdb/](structdb/) — 370 phiên bản Unity đang dùng nó:

```jsonc
{
  "schema": 1,
  "unityVersion": "2022.3.62f2",
  "pointerSize": 8,
  "metadataVersion": 31,
  "source": { "target": "aarch64-linux-android21", "tool": "tools/structdb_gen.py", … },

  "structs": {
    "Il2CppObject": {
      "size": 16,
      "fields": [
        // union vô danh -> không có tiền tố, nhưng vẫn đánh dấu union
        { "name": "klass",   "type": "Il2CppClass *",  "offset": 0, "size": 8,
          "arrayItemSize": 312, "union": true },
        { "name": "vtable",  "type": "Il2CppVTable *", "offset": 0, "size": 8, "union": true },
        { "name": "monitor", "type": "MonitorData *",  "offset": 8, "size": 8 }
      ]
    },
    "Il2CppType": {
      "size": 16,
      "fields": [
        { "name": "data.dummy", "type": "void *", "offset": 0, "size": 8, "union": true },
        // … 7 thành viên union khác, tất cả offset 0 …
        // bitfield: offset = byte của cụm, bitOffset = vị trí bit THẬT
        { "name": "attrs", "type": "unsigned int", "offset": 8,
          "bits": 16, "bitOrdinal": 0, "bitOffset": 0 },
        { "name": "type",  "type": "Il2CppTypeEnum", "offset": 8,
          "bits": 8,  "bitOrdinal": 1, "bitOffset": 16 }
      ]
    }
  },

  "enums":    { "Il2CppMetadataUsage": "kIl2CppMetadataUsageInvalid=0,kIl2CppMetadataUsageTypeInfo=1,…" },
  "defines":  { "TypeIndex": "int32_t", "StringLiteralIndex": "int32_t" },
  "typedefs": { "MonitorData": "typedef struct MonitorData MonitorData;" }
}
```

| Khoá | Ý nghĩa |
|---|---|
| `type` / `realType` | `type` là kiểu **đã giải typedef**, `realType` là tên gốc khi khác (`int32_t` / `StringLiteralIndex`) |
| `size` | byte. **Vắng mặt với bitfield** |
| `bits` / `bitOffset` | bề rộng và **vị trí bit thật** trong đơn vị lưu trữ tại `offset` |
| `bitOrdinal` | chỉ là số thứ tự, giữ để truy vết — **đừng dùng để dịch bit** |
| `arrayItemSize` | `sizeof` của kiểu được trỏ tới / phần tử mảng |
| `union` | field thuộc một union bên trong struct (nhiều field trùng `offset`) |

`enums` / `defines` / `typedefs` giữ chuỗi C thô, đủ để **tái sinh một header C++
biên dịch được** — đó cũng là một trong hai vòng kiểm chứng ở §10.4.

Không cipher, không GZip. Muốn nhỏ hơn thì `.json.gz` — nhưng **giữ nguyên dạng
JSON bên trong** để `git diff` giữa hai bản Unity đọc được bằng mắt. Chính cái
diff đó là thứ báo cho bạn biết Unity đã đổi gì (xem §13.1).

### 10.2 Sinh DB — tool `structdb_gen.py`

Repo này có sẵn tool làm toàn bộ việc đó: [tools/structdb_gen.py](tools/structdb_gen.py).

```bash
python tools/structdb_gen.py list              # liệt kê Unity Editor trên máy
python tools/structdb_gen.py gen 2022.3.62f2   # sinh x64 + x32, tự kiểm chứng
python tools/structdb_gen.py gen --all         # mọi bản Unity tìm thấy
python tools/structdb_gen.py verify 6000.3.18f1
python tools/structdb_gen.py index             # dựng lại index.json
```

Chạy thật trên máy có Unity 2022.3.62f2 và 6000.3.18f1 — **1,7 giây cho cả hai bản**:

```
2022.3.62f2  (metadata v31)
  x64  structs=88 enums=13 defines=31 typedefs=4  verify=PASS (88 sizeof + 805 offsetof)
  x32  structs=88 enums=13 defines=31 typedefs=4  verify=PASS (88 sizeof + 805 offsetof)
6000.3.18f1  (metadata v39)
  x64  structs=90 enums=13 defines=32 typedefs=4  verify=PASS (90 sizeof + 842 offsetof)
  x32  structs=90 enums=13 defines=32 typedefs=4  verify=PASS (90 sizeof + 842 offsetof)
```

Không cần cài gì thêm: clang lấy từ NDK đi kèm chính bản Unity đó
(`Editor/Data/PlaybackEngines/AndroidPlayer/NDK/.../bin/clang.exe`). Bản Unity nào
không cài Android Build Support thì tool tự mượn clang của bản khác.

#### Ba lượt clang, không phải một

`-Xclang -fdump-record-layouts` **chỉ in layout của struct/union**. Enum, macro và
typedef nằm ở chỗ khác — đây là chỗ dễ bỏ sót nhất:

| Lượt | Cờ | Lấy được |
|---|---|---|
| 1 | `-Xclang -fdump-record-layouts -c` | `sizeof`, `offset`, bitfield của struct |
| 2 | `-Xclang -ast-dump -fsyntax-only` | `EnumDecl` (kèm giá trị), `TypedefDecl` |
| 3 | `-dM -E` | macro object-like (`IL2CPP_ZERO_LEN_ARRAY`…) |

Chỉ chạy lượt 1 thì `enums` / `defines` / `typedefs` sẽ rỗng — và bạn mất luôn
khả năng giải `TypeIndex` → `int32_t`, thứ cần để chuẩn hoá trường `type`.

#### Bảy cái bẫy (tất cả đều đã cắn thật)

**1. `-fsyntax-only` không in layout gì cả.** Phải `-c` (hoặc `-emit-llvm -S`).

**2. Đừng ép layout bằng cách khai báo biến.** Nhiều struct IL2CPP có field `const`
(`Il2CppCodeGenModule.methodPointerCount`, `Il2CppMetadataRegistration.metadataUsagesCount`)
nên default constructor bị xoá, khai báo biến toàn cục sẽ lỗi biên dịch. Dùng:

```cpp
char force_0[sizeof(Il2CppCodeGenModule)];
char align_0[__alignof__(Il2CppCodeGenModule)];
```

**3. Clang in offset TUYỆT ĐỐI cho cả thành viên lồng nhau.** Cộng thêm offset của
struct cha là sai. Ví dụ thật — `Il2CppAssembly` (`sizeof` = 88):

```
    40 |   struct Il2CppAssemblyName aname
    40 |     const char * name
    64 |     int32_t minor          <- 64 la offset trong Il2CppAssembly, KHONG phai trong aname
```

Cộng hai lần cho ra `aname.minor` ở offset 88 = ngay tại `sizeof`. Bug này lọt qua
được vòng kiểm chứng đầu tiên của tôi vì lúc đó tôi **bỏ qua** field lồng nhau khi
sinh `offsetof` — xem mục "kiểm chứng" bên dưới.

**4. Aggregate vô danh không có tên thành viên thì truy cập không có tiền tố.**
So sánh hai dòng dump:

```
0 |   union Il2CppObject::(anonymous at ...)          -> obj.klass       (khong tien to)
0 |   union Il2CppType::(anonymous at ...) data       -> data.dummy      (co tien to 'data.')
```

Phân biệt bằng việc dòng có kết thúc bằng `)` hay không.

**5. Con trỏ hàm in ra chuỗi bắt đầu bằng `struct`.** `CreateCCWFunc` dump thành
`struct Il2CppIUnknown *(*)(Il2CppObject *)`. Nếu xét tiền tố `struct ` trước, bạn
sẽ sinh ra `typedef struct CreateCCWFunc CreateCCWFunc;` — xung đột với định nghĩa
thật. **Kiểm tra `(` trước.**

**6. Bitfield: clang cho (byteOffset, bitStart) tương đối theo byte đó**, không phải
bit offset tuyệt đối:

```
 8:0-15 |   unsigned int attrs
10:0-7  |   Il2CppTypeEnum type
11:5-5  |   unsigned int byref
```

DB này dùng quy ước của DevX: `offset` = byte đầu của cụm bitfield liền nhau,
`bitOffset` = `offset_byte*8 + bitStart − offset*8`. Với `Il2CppType` ra
0/16/24/29/30/31 — tròn 32 bit. Trường `bitOrdinal` chỉ là số thứ tự, **đừng dùng
để dịch bit**.

**7. Đừng lọc decl theo vị trí file.** Clang chỉ in đường dẫn ở decl **đầu tiên**
của mỗi file, các decl sau dùng dạng rút gọn `line:N:C`. Lọc theo `"libil2cpp" in loc`
sẽ chỉ bắt được 2/13 enum. Lọc theo **tên** (tiền tố `Il2Cpp`, hoặc có xuất hiện làm
kiểu field).

#### Kích thước field: đừng lấy hiệu hai offset

Cách "size = offset field kế tiếp − offset field này" sai vì nó nuốt cả padding
chèn giữa (`int a; void* b;` trên x64 sẽ cho `a` = 8 byte). Suy theo **kiểu**:
primitive tra bảng, con trỏ = `pointerSize`, struct = `sizeof` đã parse, mảng =
`n × sizeof(phần tử)`.

Kiểu nào vẫn không suy được (typedef vô hướng, enum) thì **hỏi thẳng clang** bằng
cách bọc vào struct rồi đọc `sizeof`:

```cpp
struct __szprobe_0 { il2cpp_array_size_t x; };
char __f_0[sizeof(__szprobe_0)];
```

Mẹo này giải được hết trừ kiểu mờ thật sự (`MonitorData`,
`Il2CppNameToTypeHandleHashTable`) — mà chúng chỉ được trỏ tới nên không cần size.

#### Đổi kiến trúc

| Target | Dùng cho |
|---|---|
| `aarch64-linux-android21` | Android arm64-v8a (dùng làm `x64`) |
| `armv7a-linux-androideabi21` | Android armeabi-v7a (dùng làm `x32`) |
| `x86_64-pc-windows-msvc` | GameAssembly.dll 64-bit |
| `i386-pc-windows-msvc` | GameAssembly.dll 32-bit |
| `arm64-apple-ios` | iOS |
| `wasm32-unknown-emscripten` | WebGL |


### 10.3 Dùng DB khi lift

Chức năng cần: cho một biến đã biết kiểu và một offset đọc được từ lệnh máy,
trả về đường dẫn field.

```csharp
public sealed class StructDb
{
    private readonly Dictionary<string, StructInfo> _structs;

    /// <summary>
    /// "Il2CppString", 16  ->  "length"
    /// "Il2CppString", 0   ->  "object.klass"    (đệ quy vào struct lồng)
    /// </summary>
    public bool TryResolveField(string structName, long offset, out string path)
    {
        path = "";
        if (!_structs.TryGetValue(Normalize(structName), out var s)) return false;
        if (offset < 0 || offset >= s.Size) return false;

        foreach (var f in s.Fields)
        {
            if (offset < f.Offset || offset >= f.Offset + f.Size) continue;

            // Trúng đúng đầu field, hoặc field không phải struct -> dừng.
            long inner = offset - f.Offset;
            if (inner == 0 || !_structs.ContainsKey(Normalize(f.Type)))
            {
                path = f.Name;
                return true;
            }
            // Đệ quy vào struct con.
            if (TryResolveField(f.Type, inner, out var sub))
            {
                path = f.Name + "." + sub;
                return true;
            }
            path = f.Name;
            return true;
        }
        return false;
    }

    private static string Normalize(string type) =>
        type.Replace("const ", "").Replace("struct ", "").TrimEnd('*', ' ');

    /// <summary>Chọn DB gần nhất khi không có bản khớp chính xác.</summary>
    public static StructDb LoadNearest(string dir, string unityVersion, bool is32Bit)
    {
        var exact = Path.Combine(dir, $"{unityVersion}-{(is32Bit ? "x32" : "x64")}.json");
        if (File.Exists(exact)) return Load(exact);

        // So sánh theo (major, minor, patch) — KHÔNG so sánh chuỗi.
        var target = UnityVersion.Parse(unityVersion);
        var best = Directory.EnumerateFiles(dir, "*.json")
            .Select(p => (Path: p, Ver: UnityVersion.ParseFromFileName(p)))
            .Where(x => x.Ver is not null)
            .OrderBy(x => x.Ver!.DistanceTo(target))
            .FirstOrDefault();

        if (best.Path is null) throw new FileNotFoundException("Không có struct DB nào");

        // Cảnh báo rõ ràng — im lặng dùng DB sai version là nguồn bug tệ nhất.
        Console.Error.WriteLine(
            $"CẢNH BÁO: không có struct DB cho {unityVersion}, dùng tạm {Path.GetFileName(best.Path)}. " +
            "Offset field có thể sai nếu Unity đã đổi layout runtime giữa hai bản.");
        return Load(best.Path);
    }
}
```

Khác biệt then chốt so với DevX: **DevX im lặng khi fallback**. Ở đây phải in
cảnh báo, và tốt nhất là nhúng luôn dòng cảnh báo đó vào header file `.cs` xuất
ra, để người đọc code biết vì sao tên field có thể sai.

### 10.4 Tự kiểm chứng DB

Sinh ngược từ chính JSON rồi biên dịch lại. **Hai vòng**, `structdb_gen.py` chạy cả
hai sau mỗi lần `gen`:

**Vòng 1 — struct.** `static_assert` cho mọi `sizeof` và mọi `offsetof`:

```cpp
static_assert(sizeof(Il2CppType) == 16, "Il2CppType");
static_assert(offsetof(Il2CppAssembly, aname.minor) == 64, "Il2CppAssembly.aname.minor");
static_assert(offsetof(Il2CppType, data.dummy) == 0, "Il2CppType.data.dummy");
```

> **Bài học đắt nhất của cả mục này.** Lần đầu tôi *bỏ qua* field lồng nhau và
> thành viên union khi sinh `offsetof` — vì đường dẫn có dấu chấm trông "rắc rối".
> Nó **PASS**. Bỏ chỗ miễn trừ đó ra thì lộ ngay **hai bug thật**: offset cộng hai
> lần (bẫy #3) và union vô danh bị đặt tên rác (bẫy #4).
>
> `offsetof` **chấp nhận đường dẫn có dấu chấm** trong C++. Đừng miễn trừ gì ngoài
> bitfield — chỗ nào bạn cho qua cho dễ chính là chỗ bug trốn.

**Vòng 2 — enums / defines / typedefs.** Dựng lại một header từ ba map đó rồi
biên dịch; nếu `defines` chứa typedef chuẩn của C (`int32_t`, `size_t`) hoặc
`typedefs` chứa con trỏ hàm bị nhận nhầm thành struct, vòng này sẽ đỏ:

```cpp
typedef struct MonitorData MonitorData;
#define TypeIndex int32_t
enum Il2CppMetadataUsage {kIl2CppMetadataUsageInvalid=0,…};
```

Biên dịch bằng đúng `-target` đã dùng để sinh. Đưa vào CI mỗi khi thêm bản Unity mới.

---

## 11. Bước 8 — Disassemble và lift thân hàm

Phần lớn nhất và khó nhất. Đặt kỳ vọng đúng ngay từ đầu: **đích đến thực tế là
"code đọc hiểu được", không phải "code biên dịch lại được"**.

### 11.1 Chọn backend

```csharp
public interface IArchLifter
{
    Architecture Arch { get; }
    IReadOnlyList<Instruction> Disassemble(ReadOnlySpan<byte> code, ulong baseVa);
    List<Statement> Lift(IReadOnlyList<Instruction> insns, LiftContext ctx);
}
```

Khuyến nghị mạnh: **Disarm cho ARM64, Iced cho x86/x64.** Cả hai thuần C#:

* Không phải ship native `.dll` → không dính bug "quên `arm_cp.dll` thì im lặng
  trả về rỗng" mà DevX mắc phải.
* Không phải `SetCurrentDirectory` trước mỗi lần gọi (giải pháp của DevX, vốn
  không thread-safe — nó phá hoại mọi thread khác đang dùng đường dẫn tương đối).

Nếu vẫn cần ARM32 hoặc kiến trúc lạ thì thêm Capstone, nhưng **cô lập vào một
process/adapter riêng** và **log lỗi rõ ràng**, đừng nuốt exception.

### 11.2 Khung lift ARM64

Ý tưởng: mô phỏng trừu tượng — mỗi thanh ghi giữ một `SymValue` thay vì một số.

```csharp
public abstract record SymValue
{
    public sealed record Unknown() : SymValue;
    public sealed record Const(long Value) : SymValue;
    public sealed record Arg(int Index, string Type) : SymValue;      // x0 = this, x1.. = tham số
    public sealed record This() : SymValue;
    public sealed record Local(int Id, string Type) : SymValue;
    public sealed record StrLit(string Text) : SymValue;
    public sealed record TypeRef(string TypeName) : SymValue;
    public sealed record FieldOf(SymValue Obj, string Field, string Type) : SymValue;
    public sealed record CallResult(string Method, string RetType) : SymValue;
}

public sealed class LiftContext
{
    public required Il2CppMetadata Metadata { get; init; }
    public required IBinaryImage Image { get; init; }
    public required StructDb Structs { get; init; }
    public required Dictionary<ulong, Usage> Usages { get; init; }     // mục 8
    public required Dictionary<ulong, MethodRef> MethodsByVa { get; init; } // mục 7
    public required MethodRef Current { get; init; }

    /// Tên hàm runtime tự học được (mục 11.4)
    public Dictionary<ulong, string> KnownHelpers { get; } = new();
}
```

Vòng lift chính:

```csharp
public List<Statement> Lift(IReadOnlyList<Arm64Instruction> insns, LiftContext ctx)
{
    var regs = new SymValue[32];
    Array.Fill(regs, new SymValue.Unknown());

    // Quy ước gọi AAPCS64: x0..x7 là tham số. Instance method thì x0 = this.
    int reg = 0;
    if (!ctx.Current.IsStatic) regs[reg++] = new SymValue.This();
    for (int i = 0; i < ctx.Current.Parameters.Count && reg < 8; i++, reg++)
        regs[reg] = new SymValue.Arg(i, ctx.Current.Parameters[i].Type);

    var stmts = new List<Statement>();
    var labels = CollectBranchTargets(insns);          // lượt 1 (xem 11.3)

    foreach (var ins in insns)
    {
        if (labels.Contains(ins.Address)) stmts.Add(new Statement.Label(ins.Address));

        switch (ins.Mnemonic)
        {
            // --- Nạp hằng ---
            case "MOV" when ins.Op1 is ImmOperand imm:
                regs[ins.Rd] = new SymValue.Const(imm.Value);
                break;

            // --- ADRP + ADD/LDR: mẫu nạp con trỏ toàn cục của ARM64 ---
            case "ADRP":
                regs[ins.Rd] = new SymValue.Const((long)ins.PageAddress);
                break;

            case "ADD" when regs[ins.Rn] is SymValue.Const b && ins.Op2 is ImmOperand off:
                regs[ins.Rd] = new SymValue.Const(b.Value + off.Value);
                break;

            case "LDR" when regs[ins.Rn] is SymValue.Const baseAddr:
            {
                ulong addr = (ulong)(baseAddr.Value + ins.Offset);

                // (a) Trúng một slot metadataUsage -> chuỗi / type / method
                if (ctx.Usages.TryGetValue(addr, out var u))
                {
                    regs[ins.Rd] = u.Kind switch
                    {
                        UsageKind.StringLiteral => new SymValue.StrLit(ctx.Metadata.GetStringLiteral(u.Index)),
                        UsageKind.TypeInfo      => new SymValue.TypeRef(ctx.Metadata.GetTypeName(u.Index)),
                        UsageKind.MethodDef     => new SymValue.TypeRef(ctx.Metadata.GetMethodName(u.Index)),
                        _                       => new SymValue.Unknown()
                    };
                    break;
                }
                // (b) Không phải usage -> đọc thô
                regs[ins.Rd] = new SymValue.Unknown();
                break;
            }

            // --- Truy cập field: LDR xD, [xN, #off] với xN là object đã biết kiểu ---
            case "LDR" when TryGetObjectType(regs[ins.Rn], out string? objType):
            {
                if (ctx.Structs.TryResolveField(objType!, ins.Offset, out var fieldPath))
                    regs[ins.Rd] = new SymValue.FieldOf(regs[ins.Rn], fieldPath, "var");
                else if (ctx.Metadata.TryResolveManagedField(objType!, ins.Offset, out var mf))
                    regs[ins.Rd] = new SymValue.FieldOf(regs[ins.Rn], mf.Name, mf.Type);
                else
                    regs[ins.Rd] = new SymValue.Unknown();
                break;
            }

            // --- Gọi hàm ---
            case "BL":
            {
                ulong target = ins.BranchTarget;
                string name = ResolveCallee(target, ctx);
                var args = CollectArgs(regs, ctx, target);
                stmts.Add(new Statement.Call(name, args));
                regs[0] = new SymValue.CallResult(name, ReturnTypeOf(name, ctx));
                InvalidateCallerSaved(regs);          // x0..x17 bị hủy sau lời gọi
                break;
            }

            case "RET":
                stmts.Add(new Statement.Return(regs[0]));
                break;

            case "CBZ": case "CBNZ": case "TBZ": case "TBNZ":
                stmts.Add(new Statement.Branch(ins.Mnemonic, regs[ins.Rn], ins.BranchTarget));
                break;
        }
    }
    return stmts;
}
```

### 11.3 Vì sao phải hai lượt

Không thể biết địa chỉ nào cần đặt nhãn cho tới khi đã quét hết hàm — một lệnh
nhảy về sau có thể trỏ ngược lên đầu. Lượt 1 chỉ thu thập:

```csharp
private static HashSet<ulong> CollectBranchTargets(IReadOnlyList<Arm64Instruction> insns)
{
    var targets = new HashSet<ulong>();
    foreach (var i in insns)
        if (i.IsBranch && !i.IsCall && i.BranchTarget != 0)
            targets.Add(i.BranchTarget);
    return targets;
}
```

DevX cũng làm hai lượt, và cũng phải xử lý riêng `TBZ/TBNZ/CBZ/CBNZ` vì đích nhảy
của chúng nằm ở **toán hạng thứ hai/ba**, không phải toán hạng đầu như `B`/`BL`.
Đây là lỗi kinh điển khi tự viết: quên và mất hết nhãn của các nhánh so-sánh-0.

### 11.4 Nhận diện helper runtime — làm cho đúng

Các hàm như `il2cpp_codegen_object_new`, `il2cpp_runtime_class_init`,
`il2cpp_vm_object_new` **không có trong metadata**, nhưng chúng bị gọi ở khắp nơi.
Nếu không đặt tên được, output đầy `sub_4C2100(...)`.

DevX dùng heuristic mong manh (xem [IL2CPP-PIPELINE.md §11.4](IL2CPP-PIPELINE.md)):
"trong `Assembly..ctor` trên ARM64, `BL` cuối cùng là `il2cpp_codegen_object_new`".
Cách đó phụ thuộc vào chính xác một hàm và vỡ khi Unity đổi codegen.

**Cách chắc hơn, ba tầng, thử theo thứ tự:**

```csharp
private string ResolveCallee(ulong target, LiftContext ctx)
{
    // Tầng 1 — method có trong metadata. Chính xác tuyệt đối.
    if (ctx.MethodsByVa.TryGetValue(target, out var m)) return m.FullName;

    // Tầng 2 — symbol export còn sót trong binary. Chính xác tuyệt đối.
    if (ctx.Image.SymbolsByVa.TryGetValue(target, out var sym)) return sym;

    // Tầng 3 — đã học từ trước.
    if (ctx.KnownHelpers.TryGetValue(target, out var known)) return known;

    return $"sub_{target:X}";
}
```

Và **tầng học** — chạy một lần trước khi lift, không phải heuristic trong lúc lift:

```csharp
/// <summary>
/// Học tên helper bằng cách khai thác các method mà ta BIẾT CHẮC nội dung của nó.
/// Ví dụ: mọi .cctor đều bắt đầu bằng il2cpp_runtime_class_init;
/// mọi hàm 'new' đều gọi il2cpp_codegen_object_new ngay trước khi gọi .ctor.
/// </summary>
public void LearnHelpers(LiftContext ctx)
{
    var votes = new Dictionary<ulong, Dictionary<string, int>>();

    foreach (var m in ctx.MethodsByVa.Values)
    {
        var insns = Disassemble(m);

        // Mẫu: BL <X> rồi ngay sau đó BL <ctor đã biết tên>  =>  X là object_new
        for (int i = 0; i + 1 < insns.Count; i++)
        {
            if (insns[i].Mnemonic != "BL" || insns[i + 1].Mnemonic != "BL") continue;
            if (!ctx.MethodsByVa.TryGetValue(insns[i + 1].BranchTarget, out var next)) continue;
            if (next.Name != ".ctor") continue;
            if (ctx.MethodsByVa.ContainsKey(insns[i].BranchTarget)) continue;   // đã biết rồi
            Vote(votes, insns[i].BranchTarget, "il2cpp_codegen_object_new");
        }
    }

    // Chỉ nhận khi có đủ phiếu — một lần trùng khớp có thể là ngẫu nhiên.
    foreach (var (va, tally) in votes)
    {
        var (name, count) = tally.MaxBy(kv => kv.Value);
        if (count >= 10) ctx.KnownHelpers[va] = name;
    }
}
```

Nguyên tắc: **thống kê trên toàn binary, không phải một mẫu đơn lẻ.** Một địa chỉ
được 500 hàm gọi ngay trước `.ctor` thì gần như chắc chắn là `object_new`. Một
địa chỉ trùng khớp đúng một lần thì không.

### 11.5 Giới hạn hàm nên lift

DevX cắt ở ~1 KB mã máy. Nên làm tinh hơn: cắt theo **số lệnh và độ phức tạp**,
và luôn nói rõ trong output:

```csharp
const int MaxInstructions = 4000;
if (insns.Count > MaxInstructions)
{
    writer.WriteLine($"// [{insns.Count} lệnh, vượt ngưỡng {MaxInstructions}] — thân hàm không được lift.");
    writer.WriteLine($"// Chạy lại với --max-insns={insns.Count + 1000} nếu cần hàm này.");
    return;
}
```

Cho người dùng một **hành động cụ thể**, đừng chỉ báo "quá lớn".

---

## 12. Bước 9 — Sinh C# và ghi project Unity

### 12.1 Sinh file

Không cần dấu phân cách trong-một-chuỗi kiểu `//#DECOMPILER_SEPARATOR#` như DevX
— đó là di sản của việc phải giao tiếp với `ILSpy.exe` qua stdout. Khi tự viết,
giữ luôn `Dictionary<TypeKey, string>` trong bộ nhớ.

```csharp
public void WriteType(Il2CppTypeDefinition td, TextWriter w)
{
    w.WriteLine($"// Assembly: {ModuleName}");
    if (StructDbIsApproximate)
        w.WriteLine($"// CẢNH BÁO: struct DB dùng bản {StructDbVersion} thay cho {UnityVersion}; " +
                     "tên field trong thân hàm có thể sai.");

    foreach (var attr in GetCustomAttributes(td)) w.WriteLine(attr);

    string ns = Metadata.GetString(td.namespaceIndex);
    if (ns.Length > 0) { w.WriteLine($"namespace {ns}"); w.WriteLine("{"); }

    w.WriteLine($"{Modifiers(td)} {Kind(td)} {Name(td)}{BaseList(td)}");
    w.WriteLine("{");

    foreach (var f in Fields(td))
        w.WriteLine($"    {Modifiers(f)} {TypeName(f)} {f.Name};   // 0x{FieldOffset(f):X}");

    foreach (var m in Methods(td))
    {
        w.WriteLine($"    // RVA: 0x{m.Rva:X}  VA: 0x{m.Va:X}  token: 0x{m.Token:X}");
        w.WriteLine($"    {Modifiers(m)} {ReturnType(m)} {m.Name}({Parameters(m)})");
        w.WriteLine("    {");
        foreach (var line in LiftBody(m)) w.WriteLine($"        {line}");
        w.WriteLine("    }");
    }

    w.WriteLine("}");
    if (ns.Length > 0) w.WriteLine("}");
}
```

### 12.2 Ghi project + GUID

Điểm mấu chốt: Unity nối `MonoBehaviour` trong scene/prefab với file script qua
**GUID trong `.meta`**. Bạn phải sinh GUID **tất định** và dùng **cùng một hàm**
ở cả hai nơi: khi ghi `.cs.meta` và khi ghi `m_Script` trong scene/prefab.

```csharp
/// <summary>
/// GUID tất định từ (assembly, full type name). Thuật toán cụ thể không quan trọng —
/// điều DUY NHẤT quan trọng là hai chỗ dùng cùng một hàm và kết quả ổn định giữa các lần chạy.
/// </summary>
public static string ScriptGuid(string assemblyName, string fullTypeName)
{
    string key = $"{Path.GetFileNameWithoutExtension(assemblyName)}\\{fullTypeName}";
    Span<byte> hash = stackalloc byte[16];
    MD5.HashData(Encoding.UTF8.GetBytes(key), hash);
    return Convert.ToHexString(hash).ToLowerInvariant();     // 32 ký tự hex, đúng dạng Unity
}

public void WriteScript(string assetsRoot, string assemblyName, string fullTypeName, string code)
{
    // Namespace -> cây thư mục. Chặn độ dài để không vượt MAX_PATH trên Windows.
    string ns = fullTypeName.Contains('.') ? fullTypeName[..fullTypeName.LastIndexOf('.')] : "";
    string cls = fullTypeName.Contains('.') ? fullTypeName[(fullTypeName.LastIndexOf('.') + 1)..] : fullTypeName;
    string dir = Path.Combine(assetsRoot, "Scripts", ns.Replace('.', Path.DirectorySeparatorChar));
    if (dir.Length > 200) dir = Path.Combine(assetsRoot, "Scripts", ns.Replace('.', '_'));

    Directory.CreateDirectory(dir);
    string path = Path.Combine(dir, SanitizeFileName(cls) + ".cs");
    path = MakeUnique(path);

    File.WriteAllText(path, code, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
    File.WriteAllText(path + ".meta", $"""
        fileFormatVersion: 2
        guid: {ScriptGuid(assemblyName, fullTypeName)}
        MonoImporter:
          externalObjects: {{}}
          serializedVersion: 2
          defaultReferences: []
          executionOrder: 0
          icon: {{instanceID: 0}}
          userData:
          assetBundleName:
          assetBundleVariant:
        """);
}
```

Ba chi tiết bắt buộc, sai là project không mở được:

1. **BOM UTF-8.** Unity yêu cầu BOM cho file `.cs` có ký tự non-ASCII, nếu không
   Editor báo lỗi encoding.
2. `fileID: 11500000` là fileID cố định của `MonoScript` — mọi tham chiếu script
   trong scene/prefab đều là `{fileID: 11500000, guid: <...>, type: 3}`.
3. **Tên file phải trùng tên class** với `MonoBehaviour`, nếu không Unity từ chối
   gán component. Với type lồng nhau/generic phải đặt tên phẳng.

---

## 13. Cập nhật cho metadata > v27

Đây là câu hỏi trực tiếp, nên trả lời thành quy trình.

### 13.1 Những gì đã đổi, đo được

| Từ → đến | Thay đổi | Ảnh hưởng |
|---|---|---|
| ≤ v27 → v29+ | `metadataUsageListsOffset/Count`, `metadataUsagePairsOffset/Count` **bị xóa khỏi header** | Phải chuyển sang giải mã trực tiếp slot `metadataUsages` trong binary (mục 8). **Đây là thay đổi làm chết tool cũ.** |
| ≤ v27 → v29+ | `attributesInfoOffset` + `attributeTypesOffset` → `attributeDataOffset` + `attributeDataRangeOffset` | Custom attribute chuyển từ "danh sách type" sang **blob nhị phân đã serialize**. Phải viết parser blob mới (định dạng giống `CustomAttribute` của ECMA-335). |
| v31 → v39 | Header đổi từ cặp `offset,size` sang `Il2CppSectionMetadata { offset, size, count }` | Toàn bộ hàm đọc header phải rẽ nhánh. Bù lại: **`count` giờ có sẵn**, không phải chia `size/stride` nữa. |
| v31 → v39 | `Il2CppTypeDefinition.elementTypeIndex` **bị xóa** (88 → 84 byte) | Không sửa = đọc lệch **toàn bộ** mảng typeDefs. |
| v31 → v39 | `Il2CppStringLiteral.length` **bị xóa** (8 → 4 byte, chỉ còn `dataIndex`) | Bộ đọc string literal ở mục 8.1 phải đổi: độ dài không còn nằm trong bảng, phải suy từ `dataIndex` của phần tử kế tiếp. |
| v31 → v39 | `Il2CppAssemblyDefinition` thêm `moduleToken` (64 → 68 byte) | Ảnh hưởng mảng assemblies. |
| v31 ↔ v39 | `Il2CppCodeRegistration`, `Il2CppMetadataRegistration`, `Il2CppCodeGenModule`, `Il2CppMethodDefinition`, `Il2CppImageDefinition` **không đổi** | Bước 3, 4, 7 chạy nguyên xi. Tin tốt. |

Bốn dòng đầu bảng trên đo được bằng cách sinh struct DB cho cả hai bản rồi diff —
xem [structdb/README.md](structdb/README.md). Đó cũng là cách nhanh nhất để biết
một bản Unity mới đã đổi gì.

### 13.2 Quy trình thêm một version mới

```bash
# 1. Cài bản Unity đó qua Hub. CÓ cài Android Build Support thì tiện nhất
#    (clang nằm trong NDK đi kèm); không có thì tool tự mượn clang bản khác.

# 2. Sinh struct DB — tự phát hiện version metadata, tự kiểm chứng:
python tools/structdb_gen.py gen 2023.2.20f1

# 3. Xem Unity đã đổi gì so với bản gần nhất bạn đang hỗ trợ:
python -c "
import json
a=json.load(open('structdb/2022.3.62f2-x64.json',encoding='utf-8'))['structs']
b=json.load(open('structdb/2023.2.20f1-x64.json',encoding='utf-8'))['structs']
for k in sorted(set(a)&set(b)):
    if a[k]['size']!=b[k]['size']:
        fa={f['name'] for f in a[k]['fields']}; fb={f['name'] for f in b[k]['fields']}
        print(k, a[k]['size'],'->',b[k]['size'], 'bỏ:',sorted(fa-fb), 'thêm:',sorted(fb-fa))
print('chỉ có ở bản mới:', sorted(set(b)-set(a)))
"

# 4. Cập nhật [Version(Min=, Max=)] trong model metadata theo đúng cái diff ở bước 3
```

Bước 3 là toàn bộ công việc. Đúng lệnh đó đã cho ra bảng §13.1 — bao gồm cả hai
thay đổi mà tôi **không** đoán ra được nếu chỉ đọc header bằng mắt
(`Il2CppStringLiteral` mất `length`, `Il2CppAssemblyDefinition` thêm `moduleToken`).

Muốn đối chiếu tận header thì vẫn có:

```bash
diff -u "<Unity_cu>/Editor/Data/il2cpp/libil2cpp/vm/GlobalMetadataFileInternals.h" \
        "<Unity_moi>/Editor/Data/il2cpp/libil2cpp/vm/GlobalMetadataFileInternals.h"
```

Không cần reverse, không cần đoán, không cần chờ tool khác cập nhật.

### 13.3 Bẫy: version phụ

Metadata có version phụ mà **con số trong header không phân biệt được**: 24.0,
24.1, 24.2, 24.3, 24.4, 24.5 đều ghi `version = 24`. Unity 2018.3 và Unity 2019.4
cùng ghi 24 nhưng layout khác nhau.

Cách xử lý: **thăm dò**. Đọc thử với giả định 24.0, kiểm tra bất biến; sai thì thử 24.1…

```csharp
private double ProbeSubVersion(VersionedReader r, int major)
{
    if (major != 24) return major;
    foreach (double candidate in new[] { 24.0, 24.1, 24.2, 24.3, 24.4, 24.5 })
    {
        r.Version = candidate;
        try
        {
            var h = MetadataHeader.Read(r);
            // Bất biến 1: runtime tự assert điều này.
            if (h.StringLiterals.Offset != HeaderSizeFor(candidate)) continue;
            // Bất biến 2: mọi offset phải nằm trong file và tăng dần.
            if (!SectionsAreSaneAndOrdered(h, r.BaseStream.Length)) continue;
            // Bất biến 3: chuỗi đầu tiên phải là ASCII in được.
            if (!LooksLikeIdentifier(ReadFirstString(r, h))) continue;
            return candidate;
        }
        catch { /* thử tiếp */ }
    }
    throw new NotSupportedException($"Không xác định được sub-version của metadata v{major}");
}
```

Ba bất biến trên rẻ và bắt được gần như mọi lần đoán sai. Đừng bỏ qua — đọc metadata
sai version **không ném exception**, nó chỉ trả về rác, và bạn sẽ đi tìm bug ở
bước 8.

---

## 14. Harness kiểm chứng

Không có test, bạn sẽ không biết version nào vừa hỏng. Bốn tầng, từ rẻ đến đắt:

**T1 — Bất biến metadata** (mili-giây, chạy mọi lúc):

```csharp
Assert(header.Sanity == 0xFAB11BAF);
Assert(header.StringLiterals.Offset == HeaderSizeFor(version));   // Unity tự assert cái này
Assert(typeDefs.All(t => t.nameIndex >= 0 && t.nameIndex < header.Strings.Size));
Assert(images.Sum(i => (long)i.typeCount) <= typeDefs.Length);
Assert(methods.All(m => m.declaringType >= 0 && m.declaringType < typeDefs.Length));
```

**T2 — Round-trip struct DB** (mục 10.4): sinh `static_assert` từ JSON, biên dịch.

**T3 — Vòng khép kín, giá trị nhất.** Tự build một game Unity nhỏ có IL2CPP với
**source đã biết trước**, chạy tool lên nó, so output với source gốc:

```
TestGame/
├── Assets/Scripts/Known/*.cs      ← ground truth
├── Build/                         ← build IL2CPP
└── expected/                      ← snapshot output của tool
```

Đây là thứ duy nhất phát hiện được lỗi kiểu "field offset lệch 4 byte" — cả T1
lẫn T2 đều bỏ lọt. Chi phí: một buổi setup, và mỗi bản Unity mới là một build.

**T4 — Snapshot trên game thật.** Giữ vài binary mẫu, so số lượng:
`type count`, `method count`, `số hàm lift thành công / tổng`. Chỉ số cuối là
thước đo chất lượng thật; theo dõi nó qua từng commit.

```csharp
// Chỉ số nên in ra cuối mỗi lần chạy — thứ DevX không có, và đó là lý do
// một run hỏng ở DevX trông y hệt một run thành công.
Console.WriteLine($"Types:    {typesWritten}/{typeDefs.Length}");
Console.WriteLine($"Methods:  {methodsWritten}/{methodDefs.Length}");
Console.WriteLine($"Lifted:   {bodiesLifted}/{methodsWithCode}  ({100.0*bodiesLifted/methodsWithCode:F1}%)");
Console.WriteLine($"Skipped:  {skippedTooBig} quá lớn, {skippedNoCode} không có code, {failed} lỗi");
if (structDbApproximate) Console.WriteLine($"CẢNH BÁO: struct DB {structDbUsed} != Unity {unityVersion}");
```

---

## Phụ lục — checklist khởi động

- [ ] Cài Unity bản cần hỗ trợ (kèm Android Build Support để có clang)
- [ ] `python tools/structdb_gen.py list` → xác nhận thấy Editor và số metadata version
- [ ] `python tools/structdb_gen.py gen <version>` → sinh JSON + tự chạy cả hai vòng
      `static_assert` (mục 10.2, 10.4). Phải thấy `verify=PASS` cho cả x64 lẫn x32
- [ ] Viết `MetadataStructs.cs` theo `GlobalMetadataFileInternals.h`
- [ ] T1 pass trên `global-metadata.dat` thật
- [ ] Bước 3 tìm được registration trên ít nhất một binary thật
- [ ] Dummy dll mở được bằng dnSpy/ILSpy
- [ ] Chế độ "fields only" xuất được project Unity mở được
- [ ] Rồi mới bắt đầu mục 11

Thứ tự này quan trọng: **chế độ "fields only" đã là một sản phẩm dùng được**, và
nó không cần disassembler, không cần struct DB, không cần lift. Làm xong nó trước
rồi hãy đụng tới phần khó — đó cũng là 80% giá trị thực tế của một tool như thế này.
