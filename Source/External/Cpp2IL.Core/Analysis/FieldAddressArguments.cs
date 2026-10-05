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

            // AssetRipper: iteration 065. A value type's instance method takes its receiver by
            // reference, so the receiver is the same question as a `ref T` parameter whose T is the
            // declaring type: `this.<>t__builder.SetResult()` in a struct state machine lifts to
            // `add x0, x19, #8` and came out as `Unsafe.AddByteOffset(ref this, 8)` cast to a pointer.
            if (!callee.IsStatic && callee.DeclaringType is { IsValueType: true } receiverType
                && argBase < call.Operands.Count
                && call.Operands[argBase] is LocalVariable
                && Addressed(call.Operands[argBase], instructions, method) is { Field.FieldType: { } receiverFieldType } receiverField
                && receiverFieldType.FullName == receiverType.FullName)
            {
                call.SetOperand(argBase, new AddressOf(receiverField));
                System.Threading.Interlocked.Increment(ref Recovered);
                System.Threading.Interlocked.Increment(ref RecoveredReceivers);
                changed = true;
            }

            for (var index = 0; index < callee.Parameters.Count && first + index < call.Operands.Count; index++)
            {
                if (callee.Parameters[index].ParameterType is not ByRefTypeAnalysisContext { ElementType: { } referent })
                    continue;

                if (call.Operands[first + index] is not LocalVariable
                    || Addressed(call.Operands[first + index], instructions, method) is not { } field
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

    /// <summary>How many of <see cref="Recovered"/> were the receiver of a value type's method.</summary>
    public static int RecoveredReceivers;

    /// <summary>How many of <see cref="Recovered"/> were a field of a struct reached through a pointer to it.</summary>
    public static int RecoveredStructOwners;

    /// <summary>The field an address argument is, through a class reference or a pointer to a struct.</summary>
    private static FieldReference? Addressed(IOperand operand, System.Collections.Generic.IReadOnlyList<Instruction> instructions, MethodAnalysisContext method)
    {
        if (CompareExchangeRecovery.FieldAddressed(operand, instructions, method) is { } field)
            return field;

        if (StructFieldAddressed(operand, instructions, method) is not { } inStruct)
            return null;

        System.Threading.Interlocked.Increment(ref RecoveredStructOwners);
        return inStruct;
    }

    /// <summary>
    /// AssetRipper: the field of a struct whose address <paramref name="operand"/> is, when the struct is
    /// reached through a pointer the method provably holds.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Iteration 065. <see cref="CompareExchangeRecovery.FieldAddressed"/> refuses a value type owner, and
    /// rightly as far as it goes: a register can hold a small struct's bits, and <c>value + 8</c> on those
    /// is arithmetic, not an address. Two owners are pointers whatever their size, and only those are
    /// taken: the receiver of a value type's own instance method, which il2cpp always passes as a
    /// pointer; and a local typed as a managed reference to a struct.
    /// </para>
    /// <para>
    /// The offset is read in the frame the pointer is in. A managed reference addresses the value's data.
    /// The receiver addresses whatever the method pointer's body was compiled to take, which is a fact
    /// of the binary (<see cref="FieldOffsetFrame.MethodPointerReceiverIsBoxed"/>): the data from metadata
    /// 24.5/27.1, the boxed object before. Merge-Room is the first: 86 of its body errors are a state
    /// machine's builder at <c>this + 8</c>, which is its metadata offset exactly.
    /// </para>
    /// </remarks>
    public static FieldReference? StructFieldAddressed(IOperand operand, System.Collections.Generic.IReadOnlyList<Instruction> instructions, MethodAnalysisContext method)
    {
        if (operand is not LocalVariable pointer)
            return null;

        var definitions = instructions.Where(i => ReferenceEquals(i.Destination, pointer)).ToList();

        for (var hop = 0; hop < 4 && definitions is [{ OpCode: OpCode.Move, Operands: [_, LocalVariable copied] }]; hop++)
        {
            pointer = copied;
            definitions = instructions.Where(i => ReferenceEquals(i.Destination, pointer)).ToList();
        }

        if (definitions is not [{ OpCode: OpCode.Add, Operands: [_, LocalVariable owner, Immediate { Value: var displacement }] }]
            || displacement < 0)
            return null;

        TypeAnalysisContext structType;
        long valueOffset;

        if (owner.IsThis && method.DeclaringType is { IsValueType: true } declaring
            && instructions.All(i => !ReferenceEquals(i.Destination, owner)))
        {
            structType = declaring;
            valueOffset = FieldOffsetFrame.MethodPointerReceiverIsBoxed(method.AppContext.MetadataVersion)
                ? displacement - FieldOffsetFrame.HeaderSize(method.AppContext.Binary.PointerSizeBytes)
                : displacement;
        }
        else if (MetadataResolver.ValueTypeReferent(owner.Type) is { } referent)
        {
            structType = referent;
            valueOffset = displacement;
        }
        else
            return null;

        if (valueOffset < 0 || MetadataResolver.ValueFieldAt(structType, valueOffset) is not { } field)
            return null;

        return new FieldReference(field, owner, (int)displacement);
    }
}
