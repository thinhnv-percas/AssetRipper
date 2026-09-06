using System;
using System.Collections.Generic;
using System.Linq;

namespace Cpp2IL.Core;

public static class Il2CppClassUsefulOffsets
{
    public const int X86_INTERFACE_OFFSETS_OFFSET = 0x50;
    public const int X86_64_INTERFACE_OFFSETS_OFFSET = 0xB0;

    /// <summary>
    /// Where <c>Il2CppClass::vtable</c> starts.
    /// </summary>
    /// <remarks>
    /// AssetRipper: a measured entry wins over the version formula, which is a two-way guess and gets
    /// 2019.2 wrong — its vtable is at 0x130, not 0x138. A host that has the runtime struct layouts
    /// prepends the measured offsets to <see cref="UsefulOffsets"/>, so the first matching entry is
    /// the measured one when there is one. This is what <see cref="IsPointerIntoVtable"/> bounds on
    /// and what the inlined interface dispatch is recognised by, and both are silently wrong when it
    /// is off by a single entry.
    /// </remarks>
    public static int GetVtableOffset(float metadataVersion, bool is32Bit)
    {
        if (MeasuredVtableOffset is { } measured)
            return measured;

        return metadataVersion >= 24.2f
            ? is32Bit ? 0x999 /*TODO*/ : 0x138
            : is32Bit ? 0x999 /*TODO*/ : 0x128;
    }

    /// <summary>
    /// AssetRipper: the offset read from a runtime struct layout for the binary being analysed, when
    /// the host has one. Null falls back to the version formula. Set for the whole of one import,
    /// where the pointer size is fixed, and cleared with the rest of the patch.
    /// </summary>
    public static int? MeasuredVtableOffset { get; set; }

    public static readonly List<UsefulOffset> UsefulOffsets =
    [
        new("cctor_finished", 0x74, typeof(uint), true),
        new("flags1", 0xBB, typeof(byte), true),
        //new UsefulOffset("interface_offsets_count", 0x12A, typeof(ushort), true), //TODO
        // new UsefulOffset("rgctx_data", 0xC0, typeof(IntPtr), true), //TODO
        new("interfaceOffsets", X86_INTERFACE_OFFSETS_OFFSET, typeof(IntPtr), true),
        new("static_fields", 0x5C, typeof(IntPtr), true),
        //new UsefulOffset("vtable", 0x138, typeof(IntPtr), true), //TODO

        //64-bit offsets:
        new("elementType", 0x40, typeof(IntPtr), false),
        new("interfaceOffsets", X86_64_INTERFACE_OFFSETS_OFFSET, typeof(IntPtr), false),
        new("static_fields", 0xB8, typeof(IntPtr), false),
        new("rgctx_data", 0xC0, typeof(IntPtr), false),
        new("cctor_finished", 0xE0, typeof(uint), false),
        new("interface_offsets_count", 0x12A, typeof(ushort), false),
        new("flags1", 0x132, typeof(byte), false),
        new("flags2", 0x133, typeof(byte), false),
        new("vtable", 0x138, typeof(IntPtr), false),

        // AssetRipper: the two an inlined type check reads. These are the 2022.3 values; a host with
        // the runtime struct layouts prepends the measured ones, which is how 2019.2 gets 0x128.
        new("typeHierarchy", 0xC8, typeof(IntPtr), false),
        new("typeHierarchyDepth", 0x130, typeof(ushort), false)
    ];

    /// <summary>AssetRipper: the offset of a named field, when one is known for this pointer size.</summary>
    public static bool TryGetOffset(string name, bool is32Bit, out long offset)
    {
        var match = UsefulOffsets.FirstOrDefault(o => o.is32Bit == is32Bit && o.name == name);
        offset = match?.offset ?? 0;
        return match != null;
    }

    public static bool IsStaticFieldsPtr(uint offset, bool is32Bit)
    {
        return GetOffsetName(offset, is32Bit) == "static_fields";
    }

    public static bool IsInterfaceOffsetsPtr(uint offset, bool is32Bit)
    {
        return GetOffsetName(offset, is32Bit) == "interfaceOffsets";
    }

    public static bool IsInterfaceOffsetsCount(uint offset, bool is32Bit)
    {
        return GetOffsetName(offset, is32Bit) == "interface_offsets_count";
    }

    public static bool IsRGCTXDataPtr(uint offset, bool is32Bit)
    {
        return GetOffsetName(offset, is32Bit) == "rgctx_data";
    }

    public static bool IsElementTypePtr(uint offset, bool is32Bit)
    {
        return GetOffsetName(offset, is32Bit) == "elementType";
    }

    public static bool IsPointerIntoVtable(uint offset, float metadataVersion, bool is32Bit)
    {
        return offset >= GetVtableOffset(metadataVersion, is32Bit);
    }

    public static string? GetOffsetName(uint offset, bool is32Bit) =>
        UsefulOffsets.FirstOrDefault(o => o.is32Bit == is32Bit && o.offset == offset)?.name;

    public class UsefulOffset(string name, uint offset, Type type, bool is32Bit)
    {
        public string name = name;
        public uint offset = offset;
        public Type type = type;
        public bool is32Bit = is32Bit;
    }
}
