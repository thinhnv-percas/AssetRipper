using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Utils;

/// <summary>
/// AssetRipper: a value type made of nothing but up to four floats — every small Unity maths type.
/// AAPCS64 returns and passes one of these in that many consecutive vector registers rather than in
/// memory, which is why it needs naming here rather than being an ABI detail.
/// </summary>
public static class FloatAggregate
{
    /// <summary>How many floats the type is made of, or zero when it is not one of these.</summary>
    public static int MemberCount(TypeAnalysisContext? type)
    {
        if (type is not { IsValueType: true } || type.IsEnumType)
            return 0;

        var single = type.AppContext.SystemTypes.SystemSingleType;

        if (type == single)
            return 0; // a float is not an aggregate of one

        var members = 0;

        foreach (var field in type.Fields)
        {
            if (field.IsStatic)
                continue;

            if (field.FieldType != single || ++members > 4)
                return 0;
        }

        return members;
    }

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
