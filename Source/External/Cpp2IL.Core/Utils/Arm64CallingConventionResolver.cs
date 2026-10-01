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
    public static int FloatAggregateMemberCount(TypeAnalysisContext type) => FloatAggregate.MemberCount(type);

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

    protected override int FloatRegisterCount(TypeAnalysisContext type)
        => IsFloatingPoint(type) ? 1 : FloatAggregateMemberCount(type);

    public override IOperand[] ResolveForManaged(MethodAnalysisContext ctx)
    {
        // AssetRipper: placement is Arm64ArgumentPlacement's, which applies AAPCS64 C.3 (an aggregate
        // that does not fit sends every later float to the stack) and sizes each stack slot, packed at
        // natural alignment on Apple platforms.
        var shapes = new List<Arm64ArgumentPlacement.Shape>();

        if (!ctx.IsStatic)
            shapes.Add(Arm64ArgumentPlacement.Shape.Pointer);

        foreach (var par in ctx.Parameters)
            shapes.Add(ShapeOf(par.ParameterType));

        // AssetRipper: a fully shared generic body returning a value of unknown size takes a pointer to
        // copy it to, after the parameters and before the MethodInfo. See FullGenericSharing.
        if (Analysis.FullGenericSharing.ReturnsThroughPointer(ctx))
            shapes.Add(Arm64ArgumentPlacement.Shape.Pointer);

        shapes.Add(Arm64ArgumentPlacement.Shape.Pointer); // The MethodInfo argument

        var appleStackPacking = ctx.AppContext.Binary is LibCpp2IL.MachO.MachOFile;
        var args = new List<IOperand>(shapes.Count);

        foreach (var location in Arm64ArgumentPlacement.Place(shapes, appleStackPacking))
            args.Add(location.OnStack ? new StackOffset(location.StackOffset) : new Register(null, location.Register!));

        return args.ToArray();
    }

    private static Arm64ArgumentPlacement.Shape ShapeOf(TypeAnalysisContext type)
    {
        if (IsFloatingPoint(type))
        {
            var size = type == type.AppContext.SystemTypes.SystemDoubleType ? 8 : 4;
            return new(Arm64ArgumentPlacement.Kind.Float, size, 1, size);
        }

        var members = FloatAggregateMemberCount(type);
        if (members > 0)
            return new(Arm64ArgumentPlacement.Kind.FloatAggregate, members * 4, members, 4);

        // A reference, a pointer, or a value type passed in one integer register. Only the stack slot
        // needs the real size, and only on Apple platforms, where an int takes four bytes rather than eight.
        if (!type.IsValueType)
            return Arm64ArgumentPlacement.Shape.Pointer;

        var unboxed = TypeSizes.UnboxedSize(type, PtrSize);
        return unboxed is > 0 and <= 8 && (unboxed & (unboxed - 1)) == 0
            ? new(Arm64ArgumentPlacement.Kind.Integer, (int)unboxed, 1, (int)unboxed)
            : Arm64ArgumentPlacement.Shape.Pointer;
    }
}
