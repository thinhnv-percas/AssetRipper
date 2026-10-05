using System;
using System.Buffers.Binary;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: a runtime helper whose machine code proves it returns its first argument.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 065. A generic body that needs a class out of its runtime generic context initialises it first:
/// <c>if (!klass-&gt;initialized) klass = helper(klass)</c>, and the lookup is handed whatever came out. On
/// Merge-Room that helper, <c>0x17FDEF4</c>, is
/// <c>stp x30,x19,[sp,#-16]!; mov x19,x0; bl init; ldr w0,[x19,#0xd8]; cbnz w0,raise; mov x0,x19; ldp; ret</c> -
/// the class it was given, or an exception that never returns. Not knowing that, the class operand of 31
/// invoker dispatches and 38 method-pointer dispatches was "a helper's result", which no rule may type.
/// </para>
/// <para>
/// The proof is read off the instructions, never off an address or a name: the prologue saves <c>x0</c> into
/// a callee-saved register; nothing in the function writes that register except the epilogue's restore;
/// every <c>ret</c> is reached straight-line from <c>mov x0, xN</c> through nothing but restores, with no
/// branch landing in between; and nothing leaves the function except <c>ret</c> or a call that does not come
/// back to it. An instruction outside a small whitelist ends the scan with "not proven". A callee-saved
/// register survives every call by the ABI, which is what makes the calls in between harmless.
/// </para>
/// </remarks>
public static class ArgumentReturningHelper
{
    public const int WindowInstructions = 32;

    private static readonly ConcurrentDictionary<(ApplicationAnalysisContext, ulong), bool> Cache = new();

    /// <summary>Whether the function at <paramref name="address"/> returns its first argument on every path that returns.</summary>
    public static bool IsArgumentReturning(ApplicationAnalysisContext app, ulong address)
        => app.Binary.InstructionSetId == LibCpp2IL.DefaultInstructionSets.ARM_V8
            && Cache.GetOrAdd((app, address), static key =>
            {
                var (context, at) = key;
                try
                {
                    if (!context.Binary.TryMapVirtualAddressToRaw(at, out var offset) || offset <= 0)
                        return false;

                    var content = context.Binary.GetRawBinaryContent();
                    var length = Math.Min(WindowInstructions * 4, content.Length - (int)offset);
                    return length > 8 && ReturnsFirstArgument(content.Slice((int)offset, length));
                }
                catch (Exception)
                {
                    return false;
                }
            });

    /// <summary>The proof over raw A64 instruction words, starting at the function's entry.</summary>
    public static bool ReturnsFirstArgument(ReadOnlySpan<byte> code)
    {
        var words = new List<uint>();
        for (var at = 0; at + 4 <= code.Length; at += 4)
            words.Add(BinaryPrimitives.ReadUInt32LittleEndian(code[at..]));

        if (words.Count < 4 || !IsPreIndexStackPush(words[0]))
            return false;

        // mov xN, x0 with N callee-saved (x19-x28)
        if ((words[1] & 0xFFFFFFE0) != 0xAA0003E0)
            return false;
        var saved = (int)(words[1] & 31);
        if (saved is < 19 or > 28)
            return false;

        var end = words.Count;
        for (var index = 2; index < words.Count; index++)
        {
            if (IsPreIndexStackPush(words[index]))
            {
                end = index; // the next function's prologue
                break;
            }
        }

        var branchTargets = new HashSet<int>();
        var returns = new List<int>();

        for (var index = 2; index < end; index++)
        {
            var word = words[index];

            if (word == 0xD65F03C0) // ret
            {
                returns.Add(index);
                continue;
            }

            if (IsCall(word) || IsNop(word))
                continue;

            if (ConditionalTarget(word, index) is { } conditional)
            {
                if (conditional < 0 || conditional >= end)
                    return false;
                branchTargets.Add(conditional);
                continue;
            }

            if ((word & 0xFC000000) == 0x14000000) // b: only inside the function
            {
                var target = index + SignExtend(word & 0x3FFFFFF, 26);
                if (target < 0 || target >= end)
                    return false;
                branchTargets.Add(target);
                continue;
            }

            if (IsRestore(word, saved))
                continue;

            if (!IsPlainDataOrLoad(word, out var written) || written.Contains(saved))
                return false;
        }

        if (returns.Count == 0)
            return false;

        // The last instruction before the next function must leave: a return, a branch, or a call the compiler
        // only places there because it does not come back. Anything else falls into the next function.
        var last = words[end - 1];
        if (last != 0xD65F03C0 && (last & 0xFC000000) != 0x14000000 && !IsCall(last))
            return false;

        foreach (var ret in returns)
        {
            // Straight-line back to `mov x0, xN`, through restores only, with no branch landing in between.
            var proven = false;
            for (var back = ret - 1; back >= 2; back--)
            {
                if (branchTargets.Contains(back + 1))
                    return false;

                if (words[back] == (0xAA0003E0u | ((uint)saved << 16)))
                {
                    proven = true;
                    break;
                }

                if (!IsRestore(words[back], saved))
                    return false;
            }

            if (!proven)
                return false;
        }

        return true;
    }

    private static bool IsPreIndexStackPush(uint word)
        => (word & 0xFFC00000) == 0xA9800000 && ((word >> 5) & 31) == 31; // stp xA, xB, [sp, #imm]!

    private static bool IsCall(uint word) => (word & 0xFC000000) == 0x94000000; // bl

    private static bool IsNop(uint word) => word == 0xD503201F;

    // ldp xA, xB, [sp], #imm (post-index restore) that restores the saved register or x30
    private static bool IsRestore(uint word, int saved)
        => (word & 0xFFC00000) == 0xA8C00000 && ((word >> 5) & 31) == 31;

    private static int? ConditionalTarget(uint word, int index)
    {
        if ((word & 0xFF000010) == 0x54000000) // b.cond
            return index + SignExtend((word >> 5) & 0x7FFFF, 19);
        if ((word & 0x7E000000) == 0x34000000) // cbz / cbnz
            return index + SignExtend((word >> 5) & 0x7FFFF, 19);
        if ((word & 0x7E000000) == 0x36000000) // tbz / tbnz
            return index + SignExtend((word >> 5) & 0x3FFF, 14);
        return null;
    }

    /// <summary>
    /// An instruction from the small set a helper of this shape uses, with the registers it writes. Anything
    /// else is "not proven", not "probably fine".
    /// </summary>
    private static bool IsPlainDataOrLoad(uint word, out int[] written)
    {
        written = [];

        // ldr w/x (unsigned immediate), ldrb/ldrh, ldr (literal is excluded)
        if ((word & 0x3B000000) == 0x39000000 && (word & (1u << 22)) != 0)
        {
            written = [(int)(word & 31)];
            return true;
        }

        // orr/mov (shifted register), add/sub (immediate), movz/movn, and/orr/eor (immediate), cmp/tst (writes xzr)
        if ((word & 0x1F000000) == 0x0A000000 || (word & 0x1F000000) == 0x11000000
            || (word & 0x1F800000) == 0x12800000 || (word & 0x1F800000) == 0x12000000
            || (word & 0x1F000000) == 0x0B000000)
        {
            written = [(int)(word & 31)];
            return true;
        }

        return false;
    }

    private static int SignExtend(uint value, int bits)
        => (int)(value << (32 - bits)) >> (32 - bits);

    /// <summary>
    /// The value <paramref name="operand"/> holds, expressed as the earliest operand that holds the same value:
    /// straight copies, calls to a helper <see cref="IsArgumentReturning"/> proves returns its first argument,
    /// and merges are looked through. Returns <paramref name="operand"/> itself when nothing is.
    /// </summary>
    /// <remarks>
    /// A local is often defined more than once after SSA destruction - <c>v = class; if (!v-&gt;initialized)
    /// v = helper(v)</c> - and the value is still one value when every definition agrees on it. A definition
    /// that hands a local back to itself (directly, through a copy or through the helper) preserves the value
    /// and contributes nothing; any other definition the walk cannot see through makes the answer the local
    /// itself. Disagreement is never resolved by picking one side.
    /// </remarks>
    public static IOperand LookThrough(MethodAnalysisContext method, IOperand operand, IReadOnlyList<Instruction> instructions)
    {
        if (operand is not LocalVariable)
            return operand;

        var definitions = new Dictionary<LocalVariable, List<Instruction>>();
        foreach (var instruction in instructions)
        {
            if (instruction.Destination is LocalVariable destination)
            {
                if (!definitions.TryGetValue(destination, out var list))
                    definitions[destination] = list = [];
                list.Add(instruction);
            }
        }

        var crossedHelper = false;
        var value = ValueOf(method, operand, definitions, [], ref crossedHelper) ?? operand;

        if (crossedHelper && !ReferenceEquals(value, operand))
            System.Threading.Interlocked.Increment(ref LookedThrough);

        return value;
    }

    private static IOperand? ValueOf(MethodAnalysisContext method, IOperand operand, Dictionary<LocalVariable, List<Instruction>> definitions,
        HashSet<LocalVariable> visiting, ref bool crossedHelper)
    {
        if (operand is not LocalVariable local)
            return operand;

        // A walk that comes back to a local it is still inside has gone round a copy cycle: the value is unchanged.
        if (!visiting.Add(local))
            return null;

        try
        {
            if (!definitions.TryGetValue(local, out var defined) || defined.Count == 0)
                return local;

            IOperand? agreed = null;
            foreach (var definition in defined)
            {
                List<IOperand?> sources;
                switch (definition)
                {
                    case { OpCode: OpCode.Move, Operands: [_, var source] }:
                        sources = [ValueOf(method, source, definitions, visiting, ref crossedHelper)];
                        break;
                    case { OpCode: OpCode.Call, Operands: [Immediate { Value: var address }, _, var first, ..] }
                        when IsArgumentReturning(method.AppContext, (ulong)address):
                        crossedHelper = true;
                        sources = [ValueOf(method, first, definitions, visiting, ref crossedHelper)];
                        break;
                    case { OpCode: OpCode.Phi }:
                        sources = [];
                        foreach (var input in definition.Operands.Skip(1))
                            sources.Add(ValueOf(method, input, definitions, visiting, ref crossedHelper));
                        break;
                    default:
                        return local;
                }

                foreach (var source in sources)
                {
                    if (source is null)
                        continue;
                    if (agreed is null)
                        agreed = source;
                    else if (!SameValue(agreed, source))
                        return local;
                }
            }

            return agreed ?? local;
        }
        finally
        {
            visiting.Remove(local);
        }
    }

    /// <summary>Whether two operands name the same value: the same object, or the same class, or the same constant.</summary>
    public static bool SameValue(IOperand left, IOperand right) => (left, right) switch
    {
        _ when ReferenceEquals(left, right) => true,
        (RuntimeClassTypeAnalysisContext a, RuntimeClassTypeAnalysisContext b) => ReferenceEquals(a.RepresentedType, b.RepresentedType),
        (Immediate a, Immediate b) => a.Value == b.Value,
        _ => false,
    };

    /// <summary>How many class operands were followed through an argument-returning helper.</summary>
    public static int LookedThrough;
}
