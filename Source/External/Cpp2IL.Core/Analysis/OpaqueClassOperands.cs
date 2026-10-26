using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: an allocation whose class argument names nothing, given the type the rest of the body says it is.
/// </summary>
/// <remarks>
/// <para>
/// The class an allocation hands the runtime is a metadata usage slot. On a protected build the slots of the game's own
/// assemblies are not readable in the file - Kitty Knots carries <c>libpairipcore.so</c> as a dependency of
/// <c>libil2cpp.so</c>, and one contiguous block of 6390 slots in <c>.data</c> holds values that decode to nothing,
/// uniformly spread over every kind bit including the invalid ones - so the class load stays an unresolved memory read.
/// The rest of the body is not protected, and it says what was allocated: the constructor called on the new object,
/// and the type the fixpoint gave the destination from where the object goes.
/// </para>
/// <para>
/// The generator never reads an allocation's class operand; it fuses the allocation with the constructor call. So an
/// operand that names nothing only keeps the load chain behind it alive, and each link of that chain is printed as an
/// unresolved load. Replacing it with what the body establishes - or with nothing - lets that chain die.
/// </para>
/// <para>
/// The constructor a call names is routinely not the allocated type's own (a trivial constructor is folded onto its
/// base), so the destination's type is preferred where it is a concrete class at or below the constructor's type, and a
/// call to <c>System.Object..ctor</c> is never taken as the type.
/// </para>
/// </remarks>
public static class OpaqueClassOperands
{
    public static long AllocationsTyped;
    public static long AllocationsCleared;

    public static void Run(MethodAnalysisContext method)
    {
        var instructions = method.ControlFlowGraph!.Instructions;

        for (var index = 0; index < instructions.Count; index++)
        {
            var instruction = instructions[index];

            if (instruction is not { OpCode: OpCode.Newobj, Operands: [LocalVariable allocated, var classOperand, ..] }
                || NamesAType(classOperand))
                continue;

            var constructorType = ConstructorTypeAfter(instructions, index, allocated);
            var allocatedType = Concrete(allocated.Type) is { } fromUses && (constructorType is null || Derives(fromUses, constructorType))
                ? fromUses
                : constructorType;

            if (allocatedType is not null)
            {
                instruction.SetOperand(1, allocatedType);
                System.Threading.Interlocked.Increment(ref AllocationsTyped);
            }
            else
            {
                instruction.SetOperand(1, new Immediate(0));
                System.Threading.Interlocked.Increment(ref AllocationsCleared);
            }
        }
    }

    private static bool NamesAType(IOperand classOperand) => classOperand switch
    {
        TypeAnalysisContext => true,
        LocalVariable { Type: RuntimeClassTypeAnalysisContext } => true,
        _ => false,
    };

    private static TypeAnalysisContext? ConstructorTypeAfter(System.Collections.Generic.List<Instruction> instructions, int index, LocalVariable allocated)
    {
        for (var i = index + 1; i < instructions.Count; i++)
        {
            if (instructions[i] is not { OpCode: OpCode.Call or OpCode.CallVoid, Operands: [MethodAnalysisContext { Name: ".ctor" } constructor, ..] } call)
                continue;

            var receiver = call.OpCode == OpCode.CallVoid ? 1 : 2;

            if (call.Operands.Count <= receiver || !ReferenceEquals(call.Operands[receiver], allocated))
                continue;

            return constructor.DeclaringType is { FullName: not "System.Object" } owner ? Concrete(owner) : null;
        }

        return null;
    }

    private static TypeAnalysisContext? Concrete(TypeAnalysisContext? type) =>
        type is { IsValueType: false, IsInterface: false, IsAbstract: false, FullName: not "System.Object" }
            and not SzArrayTypeAnalysisContext
            and not GenericParameterTypeAnalysisContext
            and not RuntimeClassTypeAnalysisContext
            and not PointerTypeAnalysisContext
            and not ByRefTypeAnalysisContext
            ? type
            : null;

    private static bool Derives(TypeAnalysisContext type, TypeAnalysisContext ancestor)
    {
        for (var current = type; current is not null; current = current.BaseType)
        {
            if (ReferenceEquals(current, ancestor) || current.FullName == ancestor.FullName)
                return true;
        }

        return false;
    }
}
