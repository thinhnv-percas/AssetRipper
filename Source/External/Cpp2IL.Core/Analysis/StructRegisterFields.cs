using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: fields of a small struct read out of the general register that carries it.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 065. AAPCS64 passes and returns a composite of up to sixteen bytes that is not a float
/// aggregate in general registers (C.10), so a struct parameter is a register whose bytes are its fields:
/// <c>RemoteConfigController.Settings { float CooldownAdsShow; bool AdsShow; string IronSourceAndroidId; }</c>
/// arrives in X1:X2, and <c>settings.AdsShow</c> is <c>(x1 &gt;&gt; 32) &amp; 1</c>. Read as arithmetic on
/// the struct it is <c>(object)settings &gt;&gt; 32</c>, which is not C#.
/// </para>
/// <para>
/// A shift right by <c>8k</c> of such a register is the field at offset <c>k</c> when one starts there and
/// every bit the consumers keep belongs to it: either nothing else lives between the field's end and the end
/// of the double word, or every use masks with a constant no wider than the field. Anything short of that is
/// left as it was. Only a struct the analysis typed whole is taken, and only a non-generic one, whose metadata
/// offsets are value-relative - the frame the register's bytes are in.
/// </para>
/// </remarks>
public static class StructRegisterFields
{
    /// <summary>Shifts recovered as a field read.</summary>
    public static int ShiftedFieldsRead;

    /// <summary>Reads of a struct register as its field at offset zero (counted by the generator).</summary>
    public static int LeadingFieldsRead;

    private static readonly HashSet<string> Scalars =
    [
        "System.Boolean", "System.Byte", "System.SByte", "System.Int16", "System.UInt16", "System.Char",
        "System.Int32", "System.UInt32", "System.Int64", "System.UInt64", "System.Single", "System.Double",
        "System.IntPtr", "System.UIntPtr",
    ];

    /// <summary>
    /// A struct of up to sixteen bytes that is not a float aggregate - the kind that travels in general
    /// registers - and its instance fields with their value-relative offsets, or null.
    /// </summary>
    public static List<(FieldAnalysisContext Field, long Offset)>? RegisterComposite(TypeAnalysisContext? type)
    {
        if (type is not { IsValueType: true, IsEnumType: false } || Scalars.Contains(type.FullName)
            || type is GenericInstanceTypeAnalysisContext || type.GenericParameters.Count > 0
            || FloatAggregate.MemberCount(type) > 0)
            return null;

        var size = TypeSizes.UnboxedSize(type, 8);
        if (size is <= 0 or > 16)
            return null;

        var fields = type.Fields
            .Where(field => !field.IsStatic && field.BackingData is not null)
            .Select(field => (field, (long)field.BackingData!.FieldOffset))
            .OrderBy(pair => pair.Item2)
            .ToList();

        return fields.Count == 0 ? null : fields;
    }

    /// <summary>The field at offset zero of a register composite when it is exactly of type <paramref name="wanted"/>.</summary>
    public static FieldAnalysisContext? FieldAtZeroOfExactly(TypeAnalysisContext? type, TypeAnalysisContext wanted)
    {
        if (!Scalars.Contains(wanted.FullName) || RegisterComposite(type) is not { } fields)
            return null;

        return fields.FirstOrDefault(pair => pair.Offset == 0) is { Field: { } first } && first.FieldType.FullName == wanted.FullName
            ? first
            : null;
    }

    private static long SizeOf(TypeAnalysisContext type)
        => type.IsValueType ? TypeSizes.UnboxedSize(type, 8) : 8;

    public static bool Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph || method.AppContext.Binary.InstructionSetId != LibCpp2IL.DefaultInstructionSets.ARM_V8)
            return false;

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();
        var changed = false;

        foreach (var shift in instructions)
        {
            if (shift is not { OpCode: OpCode.ShiftRight, Operands: [LocalVariable result, LocalVariable source, Immediate { Value: var bits }] }
                || bits is <= 0 or >= 64 || bits % 8 != 0
                || source.Register.Name is not ['X', ..]
                || RegisterComposite(source.Type) is not { } fields)
                continue;

            var offset = bits / 8;
            if (fields.FirstOrDefault(pair => pair.Offset == offset) is not { Field: { } field }
                || SizeOf(field.FieldType) is var width && width <= 0)
                continue;

            // What the consumers keep must be the field's bits alone.
            var nextStart = fields.Where(pair => pair.Offset > offset).Select(pair => pair.Offset).DefaultIfEmpty(long.MaxValue).Min();
            var fillsTheDoubleWord = nextStart >= 8 && offset + width >= 8;
            var uses = instructions.Where(i => !ReferenceEquals(i, shift) && i.Operands.Skip(1).Any(operand => ReferenceEquals(operand, result))).ToList();
            var masked = uses.Count > 0 && uses.All(use => use is { OpCode: OpCode.And, Operands: [_, var left, var right] }
                && (ReferenceEquals(left, result) && right is Immediate { Value: var maskRight } && FitsIn(maskRight, width)
                    || ReferenceEquals(right, result) && left is Immediate { Value: var maskLeft } && FitsIn(maskLeft, width)));

            if (offset + width > 8 || !(fillsTheDoubleWord || masked && nextStart >= offset + width))
                continue;

            shift.OpCode = OpCode.Move;
            shift.SetOperands(result, new FieldReference(field, source, (int)offset));
            System.Threading.Interlocked.Increment(ref ShiftedFieldsRead);
            changed = true;
        }

        return changed;

        static bool FitsIn(long mask, long width) => mask >= 0 && (width >= 8 || mask < 1L << (int)(8 * width));
    }
}
