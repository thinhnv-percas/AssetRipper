using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Utils;

public abstract class BaseCallingConventionResolver
{
    public static bool IsFloatingPoint(TypeAnalysisContext type)
        => type == type.AppContext.SystemTypes.SystemSingleType || type == type.AppContext.SystemTypes.SystemDoubleType;

    protected static bool IsFloatingPoint(ParameterAnalysisContext par) => IsFloatingPoint(par.ParameterType);

    public abstract Register ReturnRegister(MethodAnalysisContext ctx);

    public abstract bool ReturnsViaHiddenBuffer(MethodAnalysisContext ctx);

    public abstract Register? HiddenReturnBufferRegister(MethodAnalysisContext ctx);

    public abstract IOperand[] ResolveForManaged(MethodAnalysisContext ctx);

    protected abstract (string[] Integer, string[] Float) RawRegisters(ApplicationAnalysisContext app);

    // MSVC style: argument slot n is integer register n or float register n, not both
    protected virtual bool UsesShadowedArgumentSlots(ApplicationAnalysisContext app) => false;

    // false when the return buffer pointer lives outside the argument registers (e.g. arm64 uses x8)
    protected virtual bool HiddenBufferConsumesArgumentSlot => true;

    /// <summary>
    /// AssetRipper: how many float registers an argument of this type occupies. Zero means it travels
    /// in the integer registers instead. More than one is a small aggregate of floats, which AAPCS64
    /// spreads over consecutive vector registers; ISIL can only name the first of them, but consuming
    /// the right number keeps every argument after it aligned with the register it was passed in.
    /// </summary>
    protected virtual int FloatRegisterCount(TypeAnalysisContext type) => IsFloatingPoint(type) ? 1 : 0;

    public IOperand[] ResolveForUnmanaged(ApplicationAnalysisContext app, ulong target)
    {
        // We don't know the callee's signature, so preserve every argument register.

        var (integerRegisters, floatRegisters) = RawRegisters(app);
        return integerRegisters.Concat(floatRegisters).Select(name => (IOperand)new Register(null, name)).ToArray();
    }

    public bool HasRawArgumentLayout(Instruction call, ApplicationAnalysisContext app)
    {
        var (integerRegisters, floatRegisters) = RawRegisters(app);
        var argBase = ArgBase(call);

        if (call.Operands.Count != argBase + integerRegisters.Length + floatRegisters.Length)
            return false;

        for (var i = 0; i < integerRegisters.Length; i++)
            if (RegisterName(call.Operands[argBase + i]) != integerRegisters[i])
                return false;

        for (var i = 0; i < floatRegisters.Length; i++)
            if (RegisterName(call.Operands[argBase + integerRegisters.Length + i]) != floatRegisters[i])
                return false;

        return true;
    }

    // TODO Fix handling of params on the stack here
    public void RemapRawArguments(Instruction call, MethodAnalysisContext resolved)
    {
        var app = resolved.AppContext;

        if (!HasRawArgumentLayout(call, app))
            return;

        var (integerRegisters, floatRegisters) = RawRegisters(app);
        var argBase = ArgBase(call);

        var slots = new List<(int FloatRegisters, bool Emit)>();
        if (ReturnsViaHiddenBuffer(resolved) && HiddenBufferConsumesArgumentSlot)
            slots.Add((0, false));
        if (!resolved.IsStatic)
            slots.Add((0, true));
        foreach (var parameter in resolved.Parameters)
            slots.Add((FloatRegisterCount(parameter.ParameterType), true));
        slots.Add((0, true)); // the MethodInfo argument

        var operands = new List<IOperand>(argBase + slots.Count);
        for (var i = 0; i < argBase; i++)
            operands.Add(call.Operands[i]);

        if (UsesShadowedArgumentSlots(app))
        {
            for (var slot = 0; slot < slots.Count && slot < integerRegisters.Length; slot++)
                if (slots[slot].Emit)
                    operands.Add(call.Operands[argBase + (slots[slot].FloatRegisters > 0 ? integerRegisters.Length + slot : slot)]);
        }
        else
        {
            // AssetRipper: a convention with no floating point registers is one that passes floating
            // point arguments in the integer ones — softfp, which is what Android's armeabi-v7a is.
            // Read as "no float registers left" instead, this stopped at the first float parameter and
            // dropped it and everything after it, so slider.value = x lost the x.
            var passesFloatsInIntegerRegisters = floatRegisters.Length == 0;

            // independent integer/float counters
            var (integer, floating) = (0, 0);

            foreach (var (floatRegisterCount, emit) in slots)
            {
                var count = passesFloatsInIntegerRegisters ? 0 : floatRegisterCount;
                IOperand operand;

                if (count > 0)
                {
                    if (floating + count > floatRegisters.Length)
                        break;

                    operand = call.Operands[argBase + integerRegisters.Length + floating];
                    floating += count;
                }
                else
                {
                    if (integer >= integerRegisters.Length)
                        break;

                    operand = call.Operands[argBase + integer++];
                }

                if (emit)
                    operands.Add(operand);
            }
        }

        call.SetOperands(operands);
    }

    protected static int ArgBase(Instruction call) => call.OpCode is OpCode.CallVoid ? 1 : 2;

    private static string? RegisterName(IOperand operand) => operand switch
    {
        Register register => register.Name,
        LocalVariable { Register.Name: var name } => name,
        _ => null
    };
}
