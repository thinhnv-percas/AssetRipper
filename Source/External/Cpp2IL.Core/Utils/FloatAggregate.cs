using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Utils;

/// <summary>
/// AssetRipper: a value type made of nothing but up to four floats — every small Unity maths type — or
/// up to four doubles: a homogeneous floating-point aggregate (AAPCS64 HFA). AAPCS64 returns and passes
/// one of these in that many consecutive vector registers rather than in memory, which is why it needs
/// naming here rather than being an ABI detail.
/// </summary>
/// <remarks>
/// The doubles matter as much as the floats and were missed: a game's own <c>struct Vec2 { double X, Y; }</c>
/// arrives in D0 and D1, so with only the first register named every operator on it returned its left
/// operand unchanged and every dot product read zero.
/// </remarks>
public static class FloatAggregate
{
    /// <summary>How many floats (or doubles) the type is made of, or zero when it is not one of these.</summary>
    public static int MemberCount(TypeAnalysisContext? type) => Shape(type).members;

    /// <summary>The size of one member: 4 for floats, 8 for doubles, 0 when the type is not an aggregate.</summary>
    public static int MemberSize(TypeAnalysisContext? type) => Shape(type).size;

    private static (int members, int size) Shape(TypeAnalysisContext? type)
    {
        if (type is not { IsValueType: true } || type.IsEnumType)
            return (0, 0);

        var single = type.AppContext.SystemTypes.SystemSingleType;
        var @double = type.AppContext.SystemTypes.SystemDoubleType;

        if (type == single || type == @double)
            return (0, 0); // a float is not an aggregate of one

        TypeAnalysisContext? element = null;
        var members = 0;

        foreach (var field in type.Fields)
        {
            if (field.IsStatic)
                continue;

            // homogeneous: every member the same one of the two, never a mixture
            if (field.FieldType != single && field.FieldType != @double)
                return (0, 0);

            element ??= field.FieldType;

            if (field.FieldType != element || ++members > 4)
                return (0, 0);
        }

        return (members, element == @double ? 8 : 4);
    }

    /// <summary>The type of one member - <c>System.Single</c> or <c>System.Double</c> - or null when the type is not an aggregate.</summary>
    public static TypeAnalysisContext? MemberType(TypeAnalysisContext? type) => FirstMember(type)?.FieldType;

    /// <summary>The first of those floats, which is the one the first register carries.</summary>
    public static FieldAnalysisContext? FirstMember(TypeAnalysisContext? type)
    {
        if (MemberCount(type) < 2)
            return null;

        foreach (var field in type!.Fields)
        {
            if (!field.IsStatic)
                return field;
        }

        return null;
    }
}
