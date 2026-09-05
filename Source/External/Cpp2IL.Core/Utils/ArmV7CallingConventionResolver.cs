using System.Collections.Generic;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Utils;

/// <summary>
/// AssetRipper: added. AAPCS as Android's armeabi-v7a uses it.
/// </summary>
/// <remarks>
/// Integer and floating point arguments alike travel in R0-R3 and then on the stack, because the ABI
/// is softfp: VFP does the arithmetic but takes no part in the calling convention. The generated code
/// says so plainly — a float argument is moved out of VFP with <c>vmov r1, s0</c> immediately before
/// the call that consumes it.
/// </remarks>
public class ArmV7CallingConventionResolver : BaseCallingConventionResolver
{
    private const int PtrSize = 4;

    private static readonly string[] IntegerRegisters = ["R0", "R1", "R2", "R3"];

    /// <summary>Empty by design: softfp passes nothing in VFP.</summary>
    private static readonly string[] FloatRegisters = [];

    public override Register ReturnRegister(MethodAnalysisContext ctx) => new(null, "R0");

    public override Register? HiddenReturnBufferRegister(MethodAnalysisContext ctx)
        => ReturnsViaHiddenBuffer(ctx) ? new Register(null, "R0") : null;

    /// <summary>
    /// Whether the caller passes a pointer for the return value rather than receiving it in a register.
    /// </summary>
    /// <remarks>
    /// A fundamental type comes back in R0, or in R0:R1 when it is eight bytes. Only a composite
    /// larger than a word is written through a pointer, and that pointer takes the first argument
    /// register: <c>Transform.get_position</c> is called with the buffer in R0, <c>this</c> in R1 and
    /// the MethodInfo in R2.
    /// </remarks>
    public override bool ReturnsViaHiddenBuffer(MethodAnalysisContext ctx)
    {
        if (ctx.IsVoid)
            return false;

        var returnType = ctx.ReturnType;

        if (!returnType.IsValueType || IsFundamental(returnType))
            return false;

        // Zero means the size is not known, for a generic parameter among other things. A register
        // return is the assumption that loses least when it is wrong.
        var size = TypeSizes.UnboxedSize(returnType, PtrSize);
        return size > PtrSize;
    }

    private static bool IsFundamental(TypeAnalysisContext type)
        => type.IsEnumType || type.AppContext.SystemTypes.TryGetIl2CppTypeEnum(type, out _);

    protected override (string[] Integer, string[] Float) RawRegisters(ApplicationAnalysisContext app)
        => (IntegerRegisters, FloatRegisters);

    public override IOperand[] ResolveForManaged(MethodAnalysisContext ctx)
    {
        var args = new List<IOperand>();

        var integer = 0;
        var stack = 0;

        void AddParameter(ParameterAnalysisContext? par, bool emit)
        {
            // An eight byte argument occupies an even aligned pair, so R0:R1 or R2:R3, and the odd
            // register is skipped rather than used. Only the first register of the pair names the
            // argument here; ISIL has no way to say that a value spans two.
            var size = par is null ? PtrSize : TypeSizes.UnboxedSize(par.ParameterType, PtrSize);
            var slots = size > PtrSize && size <= 8 ? 2 : 1;

            if (slots == 2 && integer % 2 != 0)
                integer++;

            if (integer + slots <= IntegerRegisters.Length)
            {
                if (emit)
                    args.Add(new Register(null, IntegerRegisters[integer]));

                integer += slots;
                return;
            }

            // Once an argument goes to the stack every later one does too, even if a register is free.
            integer = IntegerRegisters.Length;

            if (slots == 2 && stack % 8 != 0)
                stack += PtrSize;

            if (emit)
                args.Add(new StackOffset(stack));

            stack += slots * PtrSize;
        }

        if (ReturnsViaHiddenBuffer(ctx))
            AddParameter(null, false);

        if (!ctx.IsStatic)
            AddParameter(null, true);

        foreach (var par in ctx.Parameters)
            AddParameter(par, true);

        AddParameter(null, true); // The MethodInfo argument

        return args.ToArray();
    }
}
