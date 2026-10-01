using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: an argument passed to a <c>ref T</c> parameter that is computed as <c>object + offset</c>,
/// where a field of type <c>T</c> sits at exactly that offset, is that field's address.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 064. <c>JsonLexer.Read(ref index)</c> called as <c>lexer.Next(ref this.lexer.index)</c> lifts to
/// <c>add x1, x0, #0x20</c>: the address of the field, computed. Left as arithmetic, the generator could only
/// bind a ref local to it - <c>ref int index = ref *(int*)((nint)this.lexer + 32)</c> - which C# reads as
/// pointer arithmetic on an object reference. The same address computed for a compare-and-swap was already
/// recognised by <see cref="CompareExchangeRecovery.FieldAddressed"/>; this applies that rule wherever the
/// callee's own signature says a managed reference is wanted.
/// </para>
/// <para>
/// Three facts, each of which a wrong match fails: the callee is resolved and the parameter is a byref; the
/// argument is defined once, by <c>object + constant</c>; and a field of the object's class sits at exactly
/// that offset with the parameter's referent type. A type that does not match is left as it was - a
/// <c>ref int</c> handed the address of a <c>long</c> is something this rule has no business naming.
/// </para>
/// </remarks>
public static class FieldAddressArguments
{
    /// <summary>How many arguments were recovered as a field's address.</summary>
    public static int Recovered;

    public static bool Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return false;

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();
        var changed = false;

        foreach (var call in instructions)
        {
            if (call.OpCode is not (OpCode.Call or OpCode.CallVoid) || call.Operands.Count == 0 || call.Operands[0] is not MethodAnalysisContext callee)
                continue;

            var argBase = call.OpCode == OpCode.Call ? 2 : 1;
            var first = argBase + (callee.IsStatic ? 0 : 1);

            for (var index = 0; index < callee.Parameters.Count && first + index < call.Operands.Count; index++)
            {
                if (callee.Parameters[index].ParameterType is not ByRefTypeAnalysisContext { ElementType: { } referent })
                    continue;

                if (call.Operands[first + index] is not LocalVariable
                    || CompareExchangeRecovery.FieldAddressed(call.Operands[first + index], instructions, method) is not { } field
                    || field.Field.FieldType is not { } fieldType
                    || fieldType.FullName != referent.FullName)
                    continue;

                call.SetOperand(first + index, new AddressOf(field));
                System.Threading.Interlocked.Increment(ref Recovered);
                changed = true;
            }
        }

        return changed;
    }
}
