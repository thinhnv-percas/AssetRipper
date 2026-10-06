using System;
using System.Collections.Generic;
using Cpp2IL.Core.ISIL;
using Disarm;
using Disarm.InternalDisassembly;

namespace Cpp2IL.Core.InstructionSets;

/// <summary>
/// AssetRipper: iteration 067 - the NZCV flags of A64's flag-setting arithmetic, and the condition codes read off them,
/// written once and over an emitter so that a test can evaluate exactly the ISIL the lifter produces.
/// </summary>
/// <remarks>
/// <para>
/// Arm ARM <c>AddWithCarry(x, y, carry_in)</c>: SUBS/CMP is <c>x + NOT(y) + 1</c> and ADDS/CMN is <c>x + y + 0</c>.
/// C is the unsigned carry out and V the signed overflow; N and Z read the result. Three things were wrong before:
/// </para>
/// <list type="bullet">
/// <item>C after a subtraction was emitted as a <em>signed</em> <c>a &lt; b</c>. It is "no borrow", an unsigned
/// <c>a &gt;= b</c>; signed, <c>(uint)(c - '0') &lt; 10</c> accepts ':' and a bounds check accepts a negative index.</item>
/// <item>ADDS was lifted as <c>a - (-b)</c> (iteration 066). That is exact for C only when <c>b != 0</c> - adding zero
/// never carries, subtracting zero never borrows - and for V only when <c>-b</c> does not itself overflow, so
/// <c>0x80000000 + 0x80000000</c> read V = 0. The form is kept for a small nonzero immediate, where it is exact and
/// reads as the source did (<c>(uint)x &lt; (uint)-10</c>), and replaced by the add's own flags everywhere else.</item>
/// </list>
/// The comparison is marked <see cref="Instruction.IsUnsigned"/> rather than given a new opcode, so every pass that
/// matches a comparison by opcode keeps matching it.
/// </remarks>
public static class Arm64FlagLifting
{
    public static readonly Register N = new(null, "N");
    public static readonly Register Z = new(null, "Z");
    public static readonly Register C = new(null, "C");
    public static readonly Register V = new(null, "V");

    public delegate Instruction Emitter(OpCode opCode, params List<IOperand> operands);

    /// <summary>The largest immediate ADDS/CMN can encode: twelve bits, optionally shifted by twelve.</summary>
    private const long MaximumArithmeticImmediate = 0xFFF000;

    /// <summary>The flags of <c>op0 - op1</c> (SUBS, CMP, CCMP).</summary>
    public static void Subtract(Emitter emit, IOperand op0, IOperand op1)
    {
        var temp1 = new Register(null, "TEMP1");
        var temp2 = new Register(null, "TEMP2");
        var temp3 = new Register(null, "TEMP3");
        var temp4 = new Register(null, "TEMP4");

        // C is the inverse of a borrow: unsigned a >= b
        emit(OpCode.CheckLess, C, op0, op1).IsUnsigned = true;
        emit(OpCode.Not, C, C);
        emit(OpCode.Subtract, temp1, op0, op1);
        emit(OpCode.CheckLess, N, temp1, Imm(0));
        emit(OpCode.CheckEqual, Z, temp1, Imm(0));
        // V: the operands differ in sign and the result differs from the first
        emit(OpCode.Xor, temp2, op0, op1);
        emit(OpCode.Xor, temp3, op0, temp1);
        emit(OpCode.And, temp4, temp2, temp3);
        emit(OpCode.CheckLess, V, temp4, Imm(0));
    }

    /// <summary>The flags of <c>op0 + op1</c> (ADDS, CMN, CCMN).</summary>
    public static void Add(Emitter emit, IOperand op0, IOperand op1)
    {
        if (op1 is Immediate { Value: > 0 and <= MaximumArithmeticImmediate } immediate)
        {
            // exact here: the carry of a + b for b != 0 is a >=u -b, and -b of an encodable immediate cannot overflow
            Subtract(emit, op0, Imm(-immediate.Value));
            return;
        }

        var result = new Register(null, "TEMP1");
        var temp2 = new Register(null, "TEMP2");
        var temp3 = new Register(null, "TEMP3");
        var temp4 = new Register(null, "TEMP4");

        emit(OpCode.Add, result, op0, op1);
        // C: the sum wrapped, which for an unsigned add is exactly "it came out smaller than an operand"
        emit(OpCode.CheckLess, C, result, op0).IsUnsigned = true;
        emit(OpCode.CheckLess, N, result, Imm(0));
        emit(OpCode.CheckEqual, Z, result, Imm(0));
        // V: both operands have the sign the result does not
        emit(OpCode.Xor, temp2, op0, result);
        emit(OpCode.Xor, temp3, op1, result);
        emit(OpCode.And, temp4, temp2, temp3);
        emit(OpCode.CheckLess, V, temp4, Imm(0));
    }

    /// <summary>The value of a condition code over the flags, per the Arm ARM's <c>ConditionHolds</c>.</summary>
    public static IOperand Condition(Emitter emit, Arm64ConditionCode condition)
    {
        var temp = new Register(null, "TEMPCOND");
        var temp2 = new Register(null, "TEMPCOND2");

        switch (condition)
        {
            case Arm64ConditionCode.EQ:
                return Z;
            case Arm64ConditionCode.NE:
                emit(OpCode.Not, temp, Z);
                return temp;
            case Arm64ConditionCode.GE: // N == V
                emit(OpCode.CheckEqual, temp, N, V);
                return temp;
            case Arm64ConditionCode.LT: // N != V
                emit(OpCode.CheckEqual, temp, N, V);
                emit(OpCode.Not, temp, temp);
                return temp;
            case Arm64ConditionCode.GT: // Z == 0 && N == V
                emit(OpCode.CheckEqual, temp, N, V);
                emit(OpCode.Not, temp2, Z);
                emit(OpCode.And, temp, temp, temp2);
                return temp;
            case Arm64ConditionCode.LE: // Z == 1 || N != V
                emit(OpCode.CheckEqual, temp, N, V);
                emit(OpCode.Not, temp, temp);
                emit(OpCode.Or, temp, temp, Z);
                return temp;
            case Arm64ConditionCode.CS: // unsigned >=
                return C;
            case Arm64ConditionCode.CC: // unsigned <
                emit(OpCode.Not, temp, C);
                return temp;
            case Arm64ConditionCode.HI: // unsigned >: C == 1 && Z == 0
                emit(OpCode.Not, temp, Z);
                emit(OpCode.And, temp, C, temp);
                return temp;
            case Arm64ConditionCode.LS: // unsigned <=: C == 0 || Z == 1
                emit(OpCode.Not, temp, C);
                emit(OpCode.Or, temp, temp, Z);
                return temp;
            case Arm64ConditionCode.MI:
                return N;
            case Arm64ConditionCode.PL:
                emit(OpCode.Not, temp, N);
                return temp;
            case Arm64ConditionCode.VS:
                return V;
            case Arm64ConditionCode.VC:
                emit(OpCode.Not, temp, V);
                return temp;
            default: // AL/NV are both unconditional
                return Imm(1);
        }
    }

    private static Immediate Imm(long value) => new(value);
}
