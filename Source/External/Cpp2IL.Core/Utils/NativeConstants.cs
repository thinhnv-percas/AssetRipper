using System;
using Cpp2IL.Core.ISIL;
using LibCpp2IL;

namespace Cpp2IL.Core.Utils;

/// <summary>
/// AssetRipper: reads a floating point constant a compiler placed in the binary, so that a load of it
/// becomes the number it is rather than a memory access nothing downstream can name.
/// </summary>
/// <remarks>
/// The address has to be one the code names outright — a literal pool entry, or a page address plus a
/// displacement. A managed static float is never reached that way: it lives in the class's static
/// field storage, behind two pointers. So an absolute address loaded into a floating point register in
/// il2cpp generated code is a constant the compiler emitted, which is the same assumption the x86
/// lifter has always made for a scalar float operand.
/// </remarks>
public static class NativeConstants
{
    public static IOperand? ReadFloat(Il2CppBinary binary, ulong address, bool isDouble)
    {
        if (address == 0 || !binary.TryMapVirtualAddressToRaw(address, out var raw))
            return null;

        var content = binary.GetRawBinaryContent();
        var size = isDouble ? 8 : 4;

        if (raw < 0 || raw + size > content.Length)
            return null;

        var bytes = content.Slice((int)raw, size).ToArray();

        return isDouble
            ? new DoubleLiteral(BitConverter.ToDouble(bytes, 0))
            : new FloatLiteral(BitConverter.ToSingle(bytes, 0));
    }
}
