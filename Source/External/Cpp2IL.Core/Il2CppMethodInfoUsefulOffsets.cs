using System;
using System.Collections.Generic;
using System.Linq;
using LibCpp2IL;

namespace Cpp2IL.Core;

public static class Il2CppMethodInfoUsefulOffsets
{
    public const int X86_KLASS_OFFSET = 0x00; //TODO
    public const int X86_64_KLASS_OFFSET = 0x18;

    public static readonly List<UsefulOffset> UsefulOffsets =
    [
        new UsefulOffset("klass", X86_KLASS_OFFSET, typeof(ushort), true),

        //64-bit offsets:
        new UsefulOffset("klass", X86_64_KLASS_OFFSET, typeof(IntPtr), false),

        // AssetRipper: MethodInfo::rgctx_data, which generic sharing reads to find the type arguments
        // a shared body was called with. These are the 2019-2021 offsets; a host with the runtime
        // struct layouts prepends the measured ones, which is how 2022.3 gets 0x38.
        new UsefulOffset("rgctx_data", 0x30, typeof(IntPtr), false)
    ];

    /// <summary>AssetRipper: the offset of a named field, when one is known for this pointer size.</summary>
    public static bool TryGetOffset(string name, bool is32Bit, out long offset)
    {
        var match = UsefulOffsets.FirstOrDefault(o => o.is32Bit == is32Bit && o.name == name);
        offset = match?.offset ?? 0;
        return match != null;
    }

    public static bool IsKlassPtr(uint offset, Il2CppBinary binary)
    {
        return GetOffsetName(offset, binary) == "klass";
    }

    public static string? GetOffsetName(uint offset, Il2CppBinary binary)
    {
        var is32Bit = binary.is32Bit;

        return UsefulOffsets.FirstOrDefault(o => o.is32Bit == is32Bit && o.offset == offset)?.name;
    }

    public class UsefulOffset(string name, uint offset, Type type, bool is32Bit)
    {
        public string name = name;
        public uint offset = offset;
        public Type type = type;
        public bool is32Bit = is32Bit;
    }
}
