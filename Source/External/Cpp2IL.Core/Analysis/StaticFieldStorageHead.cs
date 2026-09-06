using System.Collections.Generic;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: names a read of a type's static field storage as the first static field of that type,
/// which is what sits at the head of it.
/// </summary>
/// <remarks>
/// The generator already does this when it emits the load, so the output was right — but the analysis
/// still had the class pointer being read by the memory operand, so its definition survived
/// elimination and the body opened with a dead <c>nint num = (nint)typeof(Checker);</c>. Doing it as
/// a pass instead lets the class pointer die, because a static field reference does not read the
/// local it is written against.
/// </remarks>
public static class StaticFieldStorageHead
{
    public static void Run(MethodAnalysisContext method)
    {
        var is32Bit = method.AppContext.Binary.is32Bit;
        var usedAsABase = new HashSet<LocalVariable>();

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            foreach (var operand in instruction.Operands)
            {
                switch (operand)
                {
                    case MemoryOperand { Base: LocalVariable memoryBase }:
                        usedAsABase.Add(memoryBase);
                        break;
                    case FieldReference { Local: { } fieldLocal }:
                        usedAsABase.Add(fieldLocal);
                        break;
                }
            }
        }

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                if (instruction.Operands[i] is not MemoryOperand { Index: null, Scale: 0, Base: LocalVariable klass } memory
                    || klass.Type is not RuntimeClassTypeAnalysisContext { RepresentedType: { } owner }
                    || memory.Addend is < 0 or > uint.MaxValue
                    || !Il2CppClassUsefulOffsets.IsStaticFieldsPtr((uint)memory.Addend, is32Bit))
                    continue;

                // Where the value read is itself used as a pointer, the loads off it are the type's
                // other static fields and resolve against it. Naming this one would make the local a
                // value rather than a pointer and lose them.
                if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable destination, ..] }
                    && usedAsABase.Contains(destination))
                    continue;

                if (HeadField(owner) is not { } head)
                    continue;

                instruction.SetOperand(i, new FieldReference(head, klass, 0));

                if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable moved, ..] })
                    moved.Type = head.FieldType;
            }
        }
    }

    private static FieldAnalysisContext? HeadField(TypeAnalysisContext owner)
    {
        foreach (var field in owner.Fields)
        {
            if (field.IsStatic && (field.Attributes & System.Reflection.FieldAttributes.Literal) == 0
                && field.BackingData?.FieldOffset == 0)
                return field;
        }

        return null;
    }
}
