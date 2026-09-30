using System;
using System.Collections.Generic;

namespace Cpp2IL.Core.Utils;

/// <summary>
/// AssetRipper: where AAPCS64 puts each argument, as a pure function of the argument shapes, so the rule
/// can be tested without metadata behind it.
/// </summary>
/// <remarks>
/// Two rules the resolver used to miss, both silent: a float aggregate that does not fit in the vector
/// registers that are left sets NSRN to 8 (AAPCS64 C.3), so every *later* float argument goes to the
/// stack too; and a stack argument occupies its own size rounded to 8 - a Vector3 takes 16 bytes, not 8
/// (C.3, C.5, C.13). <c>CubicBezierUtility.EvaluateCurve(Vector3 a1, Vector3 c1, Vector3 c2, Vector3 a2,
/// float t)</c> has a1 in V0-V2, c1 in V3-V5, and c2, a2 and t on the stack; the resolver named V6 as t,
/// which nothing wrote, and the method recovered as a curve evaluated at t = 0.
///
/// Apple's arm64 ABI differs in exactly one way that matters here: stack arguments are packed at their
/// natural alignment rather than in 8-byte slots, so on iOS the same method has c2 at 0, a2 at 12 and t at
/// 24 ("Writing ARM64 code for Apple platforms", *Pass arguments to functions correctly*).
/// </remarks>
public static class Arm64ArgumentPlacement
{
    public enum Kind
    {
        Integer,
        Float,
        FloatAggregate,
    }

    /// <param name="Kind">Which register file the argument wants.</param>
    /// <param name="Size">Its size in bytes: the member size times the member count for an aggregate.</param>
    /// <param name="Registers">How many registers of that file it needs (members of an aggregate).</param>
    /// <param name="Alignment">Its natural alignment (a member's size, for an aggregate).</param>
    public readonly record struct Shape(Kind Kind, int Size, int Registers, int Alignment)
    {
        public static Shape Pointer => new(Kind.Integer, 8, 1, 8);
    }

    /// <summary>Where one argument lives: a register name, or a byte offset from the stack pointer at entry.</summary>
    public readonly record struct Location(string? Register, int StackOffset)
    {
        public bool OnStack => Register is null;

        public override string ToString() => Register ?? $"[sp+{StackOffset}]";
    }

    private static readonly string[] IntegerRegisters = ["X0", "X1", "X2", "X3", "X4", "X5", "X6", "X7"];
    private static readonly string[] FloatRegisters = ["V0", "V1", "V2", "V3", "V4", "V5", "V6", "V7"];

    public static List<Location> Place(IReadOnlyList<Shape> arguments, bool appleStackPacking)
    {
        var placed = new List<Location>(arguments.Count);
        var ngrn = 0;
        var nsrn = 0;
        var nsaa = 0;

        foreach (var argument in arguments)
        {
            if (argument.Kind is Kind.Float or Kind.FloatAggregate)
            {
                if (nsrn + argument.Registers <= FloatRegisters.Length)
                {
                    placed.Add(new Location(FloatRegisters[nsrn], 0));
                    nsrn += argument.Registers;
                    continue;
                }

                // C.3: no partial allocation, and nothing after it may take a vector register either.
                nsrn = FloatRegisters.Length;
            }
            else
            {
                if (ngrn < IntegerRegisters.Length)
                {
                    placed.Add(new Location(IntegerRegisters[ngrn++], 0));
                    continue;
                }

                ngrn = IntegerRegisters.Length;
            }

            int size, alignment;
            if (appleStackPacking)
            {
                size = Math.Max(argument.Size, 1);
                alignment = Math.Max(argument.Alignment, 1);
            }
            else
            {
                // C.3/C.5: a float or an aggregate is rounded up to a multiple of 8; C.13 the same for
                // an integer; the address is aligned to at least 8.
                size = RoundUp(Math.Max(argument.Size, 1), 8);
                alignment = Math.Max(argument.Alignment, 8);
            }

            nsaa = RoundUp(nsaa, alignment);
            placed.Add(new Location(null, nsaa));
            nsaa += size;
        }

        return placed;
    }

    private static int RoundUp(int value, int multiple) => (value + multiple - 1) / multiple * multiple;
}
