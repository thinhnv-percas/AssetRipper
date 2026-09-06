using System.Collections.Generic;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: turns a <see cref="OpCode.MakeStruct"/> back into the single value its members came
/// from, where they came from one.
/// </summary>
/// <remarks>
/// <para>
/// Composing an argument out of the registers it arrived in is only necessary because the registers
/// are where the value was. Often they were filled from one place a moment earlier, and rebuilding
/// the value member by member then says less than naming where it came from — and costs a
/// placeholder for every member the analysis could not resolve.
/// </para>
/// <para>
/// This runs as a pass rather than in the generator so that what the fold stops reading dies: the
/// static field storage pointer a <c>Quaternion.identity</c> read went through is not needed once
/// the read is the field itself, and neither is the class pointer it was loaded from.
/// </para>
/// </remarks>
public static class MakeStructFolder
{
    public static void Run(MethodAnalysisContext method)
    {
        var definitions = new Dictionary<LocalVariable, IOperand>();

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable destination, var source] })
                definitions[destination] = source;

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            if (instruction.OpCode != OpCode.MakeStruct)
                continue;

            if (WholeValueBehind(instruction, definitions) is not { } whole)
                continue;

            instruction.OpCode = OpCode.Move;
            instruction.SetOperands(instruction.Operands[0], whole);
        }
    }

    /// <summary>
    /// AssetRipper: what a member is, which is what defined the local it arrived in. The members are
    /// still locals here, because a load is not a copy and the propagation above leaves it where it is.
    /// </summary>
    private static IOperand Behind(IOperand operand, Dictionary<LocalVariable, IOperand> definitions)
        => operand is LocalVariable local && definitions.TryGetValue(local, out var source) ? source : operand;

    private static IOperand? WholeValueBehind(Instruction instruction, Dictionary<LocalVariable, IOperand> definitions)
    {
        if (instruction.Operands is not [_, TypeAnalysisContext type, var first, ..] || instruction.Operands.Count < 4)
            return null;

        var head = Behind(first, definitions);

        switch (head)
        {
            // A value read out of a field: the first member resolves to the field and the rest are
            // loads at four byte steps past it that nothing named. Quaternion.identity arrives this
            // way, as identityQuaternion plus three unresolved loads off the static field storage.
            case FieldReference source when source.Field.FieldType.FullName == type.FullName:
            {
                for (var member = 1; member + 2 < instruction.Operands.Count; member++)
                {
                    if (Behind(instruction.Operands[member + 2], definitions) is not MemoryOperand { Index: null, Scale: 0, Base: LocalVariable memoryBase } load
                        || !ReferenceEquals(memoryBase, source.Local) || load.Addend != source.Offset + member * 4)
                        return null;
                }

                return source;
            }

            // A value returned by a call: the first member is the local the return register held and
            // the rest are the fields of it that DefineFloatAggregateReturn named, so the whole value
            // is already in hand.
            case LocalVariable { Type: { } localType } local when localType.FullName == type.FullName:
            {
                for (var member = 1; member + 2 < instruction.Operands.Count; member++)
                {
                    if (Behind(instruction.Operands[member + 2], definitions) is not FieldReference part
                        || !ReferenceEquals(part.Local, local))
                        return null;
                }

                return local;
            }

            default:
                return null;
        }
    }
}
