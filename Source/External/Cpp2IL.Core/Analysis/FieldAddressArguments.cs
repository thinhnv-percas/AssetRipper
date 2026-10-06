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
        var blockOf = new System.Collections.Generic.Dictionary<Instruction, Cpp2IL.Core.Graphs.Block>();
        foreach (var block in graph.Blocks)
            foreach (var instruction in block.Instructions)
                blockOf[instruction] = block;

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

                if (call.Operands[first + index] is not LocalVariable argument)
                    continue;

                if (Addressed(argument, instructions, method) is not { } field)
                {
                    // iteration 066: the object is itself a field read - `this.lexer + 0x20`
                    if (blockOf.TryGetValue(call, out var callBlock)
                        && FieldOfALoadedObject(argument, call, callBlock, instructions, referent) is { } nested)
                    {
                        call.SetOperand(first + index, new AddressOf(nested));
                        System.Threading.Interlocked.Increment(ref Recovered);
                        System.Threading.Interlocked.Increment(ref RecoveredThroughAFieldLoad);
                        changed = true;
                    }

                    continue;
                }

                if (field.Field.FieldType is not { } fieldType || fieldType.FullName != referent.FullName)
                    continue;

                call.SetOperand(first + index, new AddressOf(field));
                System.Threading.Interlocked.Increment(ref Recovered);
                changed = true;
            }
        }

        changed |= RecoverAddressDefinitions(instructions, method);
        return changed;
    }

    /// <summary>Iteration 067: how many managed references were recovered as a field's address where they are defined.</summary>
    public static int RecoveredDefinitions;

    /// <summary>
    /// AssetRipper: iteration 067 - a managed reference defined as <c>object + constant</c> is the address of the field
    /// there, wherever it is used.
    /// </summary>
    /// <remarks>
    /// The rule above recovers the address only where it is a call's argument. An address that is kept - a ref local
    /// read after the call (<c>SyncRoot</c>'s double-checked <c>_syncRoot</c>), or the value of a ref-returning getter
    /// (<c>ref NextNode =&gt; ref nextNode</c>, lifted to <c>return this + 0x10</c>) - stayed native arithmetic and
    /// read back as <c>ref *(object*)((nint)this + 72)</c>, a pointer to a managed type. The same three facts decide it,
    /// taken from the same rule (<see cref="CompareExchangeRecovery.FieldAddressed(IOperand, IReadOnlyList{Instruction}, MethodAnalysisContext)"/>):
    /// one definition, a class whose field sits at exactly that offset, and the local already typed as a reference to
    /// that field's type by a use that needs one. The definition is rewritten, so every use reads the field.
    /// </remarks>
    private static bool RecoverAddressDefinitions(System.Collections.Generic.IReadOnlyList<Instruction> instructions, MethodAnalysisContext method)
    {
        var changed = false;
        foreach (var definition in instructions)
        {
            if (definition is not { OpCode: OpCode.Add, Operands: [LocalVariable { Type: ByRefTypeAnalysisContext { ElementType: { } referent } } address, LocalVariable, Immediate] })
                continue;

            if (CompareExchangeRecovery.FieldAddressed(address, instructions, method) is not { Field.FieldType: { } fieldType } field
                || fieldType.FullName != referent.FullName)
                continue;

            definition.OpCode = OpCode.Move;
            definition.SetOperands([address, new AddressOf(field)]);
            System.Threading.Interlocked.Increment(ref RecoveredDefinitions);
            changed = true;
        }

        return changed;
    }

    /// <summary>How many of <see cref="Recovered"/> were a field of an object that was itself read out of a field.</summary>
    public static int RecoveredThroughAFieldLoad;

    private static int nestedCounter;

    /// <summary>
    /// AssetRipper: iteration 066 - <c>ref obj.a.b</c>, where <c>obj.a</c> is an object.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>Lexer.NextToken(json, ref this.lexer.index)</c> compiles to a load of <c>this.lexer</c> into a register
    /// and <c>add x1, x8, #0x20</c>. Copy propagation folds the load into the addition, so what reaches here is
    /// <c>t = this.lexer + 0x20</c>: an address whose base is a field read rather than a local, which none of the
    /// rules above accept and which the generator could only render as
    /// <c>ref int index = ref *(int*)((nint)this.lexer + 32)</c> - 44, 124 and 399 of those on three fixtures.
    /// </para>
    /// <para>
    /// The register the machine loaded the object into is put back as a local, defined by the same field read at
    /// the point the addition stood, so nothing between the read and the call can change what it holds; the
    /// argument becomes the address of the field of that local. The definition taken is the one reaching the call
    /// in its own block - the register is routinely reused after SSA destruction - or the only one in the method.
    /// The same three facts as above have to hold: a resolved byref parameter, an object (not a value) whose class
    /// places a field at exactly that offset, and that field's type is the parameter's referent.
    /// </para>
    /// </remarks>
    private static FieldReference? FieldOfALoadedObject(LocalVariable argument, Instruction call, Cpp2IL.Core.Graphs.Block block,
        System.Collections.Generic.IReadOnlyList<Instruction> instructions, TypeAnalysisContext referent)
    {
        var callIndex = block.Instructions.IndexOf(call);
        Instruction? definition = null;
        for (var i = callIndex - 1; i >= 0; i--)
        {
            if (ReferenceEquals(block.Instructions[i].Destination, argument))
            {
                definition = block.Instructions[i];
                break;
            }
        }

        if (definition is null)
        {
            var all = instructions.Where(i => ReferenceEquals(i.Destination, argument)).ToList();
            if (all.Count != 1)
                return null;
            definition = all[0];
        }

        // the base already a local: the object the machine loaded, used straight - provided nothing redefines it
        // between the addition and the call, so the address the call is handed is the one computed
        if (definition is { OpCode: OpCode.Add, Operands: [_, LocalVariable owner, Immediate { Value: var ownerOffset }] }
            && block.Instructions.Contains(definition)
            && owner.Type is { IsValueType: false } ownerType
            && ownerType is not (GenericInstanceTypeAnalysisContext or ByRefTypeAnalysisContext or PointerTypeAnalysisContext)
            && ownerType.GenericParameters.Count == 0
            && ValueFlow.KindOf(ownerType) == ValueKind.ObjectReference)
        {
            var from = block.Instructions.IndexOf(definition);
            for (var i = from + 1; i < callIndex; i++)
                if (ReferenceEquals(block.Instructions[i].Destination, owner))
                    return null;

            return MetadataResolver.SearchFieldAtOffset(ownerType, ownerOffset, wantStatic: false) is { DeclaringType.GenericParameters.Count: 0, FieldType: { } ownerFieldType } ownerField
                   && ownerFieldType.FullName == referent.FullName
                ? new FieldReference(ownerField, owner, (int)ownerOffset)
                : null;
        }

        if (definition is not { OpCode: OpCode.Add, Operands: [_, FieldReference { Field.IsStatic: false, ElementIndex: null, ContainingFields.Count: 0 } load, Immediate { Value: var offset }] }
            || load.Field.FieldType is not { IsValueType: false } objectType
            || objectType is GenericInstanceTypeAnalysisContext or ByRefTypeAnalysisContext or PointerTypeAnalysisContext
            || objectType.GenericParameters.Count > 0
            || ValueFlow.KindOf(objectType) != ValueKind.ObjectReference
            || MetadataResolver.SearchFieldAtOffset(objectType, offset, wantStatic: false) is not { } field
            || field.DeclaringType is null || field.DeclaringType.GenericParameters.Count > 0
            || field.FieldType is not { } fieldType || fieldType.FullName != referent.FullName)
            return null;

        var definingBlock = block.Instructions.Contains(definition) ? block : null;
        if (definingBlock is null)
            return null; // a definition in another block: where to put the read back is not this rule's to decide

        var counter = System.Threading.Interlocked.Increment(ref nestedCounter);
        var loaded = new LocalVariable($"fieldBase{counter}", new Register(null, $"FLDBASE{counter}"), objectType);
        var reread = new FieldReference(load.Field, load.Local, load.Offset) { AccessSize = load.AccessSize };
        definingBlock.Instructions.Insert(definingBlock.Instructions.IndexOf(definition), new Instruction(-1, OpCode.Move, loaded, reread));

        return new FieldReference(field, loaded, (int)offset);
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
