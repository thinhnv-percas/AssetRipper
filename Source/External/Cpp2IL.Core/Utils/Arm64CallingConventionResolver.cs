using System.Collections.Generic;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Utils;

// integer args in X0-X7, fp args in V0-V7 (independent counters), rest on the stack.
// Oversized struct returns go via a pointer in X8, which is not an argument register.
public class Arm64CallingConventionResolver : BaseCallingConventionResolver
{
    private const int PtrSize = 8;

    private static readonly string[] IntegerRegisters = ["X0", "X1", "X2", "X3", "X4", "X5", "X6", "X7"];
    private static readonly string[] FloatRegisters = ["V0", "V1", "V2", "V3", "V4", "V5", "V6", "V7"];

    public override Register ReturnRegister(MethodAnalysisContext ctx)
        => new(null, IsFloatingPoint(ctx.ReturnType) || IsFloatAggregate(ctx.ReturnType) ? "V0" : "X0");

    /// <summary>
    /// AssetRipper: whether the type is a homogeneous float aggregate, which AAPCS64 returns in V0 to
    /// V3 rather than in the integer registers. Unity's small maths types are all of this shape, and
    /// calling <c>Transform.get_position</c> an X0 return put the vector where it never was.
    /// </summary>
    public static bool IsFloatAggregate(TypeAnalysisContext type) => FloatAggregateMemberCount(type) >= 2;

    /// <summary>
    /// AssetRipper: how many registers such a return occupies, or zero when the type is not one.
    /// </summary>
    public static int FloatAggregateMemberCount(TypeAnalysisContext type)
    {
        if (!type.IsValueType || type.IsEnumType)
            return 0;

        var single = type.AppContext.SystemTypes.SystemSingleType;
        var members = 0;

        foreach (var field in type.Fields)
        {
            if (field.IsStatic)
                continue;

            // Only an aggregate of up to four floats qualifies; anything else goes by the usual rules.
            if (field.FieldType != single || ++members > 4)
                return 0;
        }

        return members;
    }

    public override Register? HiddenReturnBufferRegister(MethodAnalysisContext ctx)
        => ReturnsViaHiddenBuffer(ctx) ? new Register(null, "X8") : null;

    public override bool ReturnsViaHiddenBuffer(MethodAnalysisContext ctx)
    {
        if (ctx.IsVoid)
            return false;

        var returnType = ctx.ReturnType;
        if (!returnType.IsValueType || IsFloatingPoint(returnType))
            return false;

        var size = TypeSizes.UnboxedSize(returnType, PtrSize);
        if (size == 0)
            return false; // unknown size (e.g. generic), assume a register return

        return size > 16;
    }

    protected override (string[] Integer, string[] Float) RawRegisters(ApplicationAnalysisContext app)
        => (IntegerRegisters, FloatRegisters);

    protected override bool HiddenBufferConsumesArgumentSlot => false;

    public override IOperand[] ResolveForManaged(MethodAnalysisContext ctx)
    {
        var args = new List<IOperand>();

        var integer = 0;
        var floating = 0;
        var stack = 0;

        void AddParameter(ParameterAnalysisContext? par)
        {
            if (par != null && IsFloatingPoint(par))
            {
                if (floating < FloatRegisters.Length)
                {
                    args.Add(new Register(null, FloatRegisters[floating++]));
                    return;
                }
            }
            else if (integer < IntegerRegisters.Length)
            {
                args.Add(new Register(null, IntegerRegisters[integer++]));
                return;
            }

            args.Add(new StackOffset(stack));
            stack += PtrSize;
        }

        if (!ctx.IsStatic)
            AddParameter(null);

        foreach (var par in ctx.Parameters)
            AddParameter(par);

        AddParameter(null); // The MethodInfo argument

        return args.ToArray();
    }
}
