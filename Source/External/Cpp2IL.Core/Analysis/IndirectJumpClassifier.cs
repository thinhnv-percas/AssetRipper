using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: what each surviving <see cref="OpCode.IndirectJump"/> actually is, counted rather
/// than guessed at.
/// </summary>
/// <remarks>
/// <para>
/// An indirect jump reaches the generator as one placeholder whatever produced it, and the families
/// behind that one label want opposite work: a delegate tail-invoke is a call this pipeline already
/// knows how to resolve, a vtable slot needs the dispatch tables, a jump table needs its cases
/// recovered, and a register that was never written in this method needs nothing at all because it
/// is the caller's value. Naming them by count first is the same discipline every other family in
/// this project has needed - and it is measurement only: nothing here rewrites an instruction.
/// </para>
/// <para>
/// The names are the shapes that can be read off the IR, not semantics that would have to be
/// inferred. In particular nothing is called a switch table unless the target is computed by
/// arithmetic, and a shape the walk has no rule for is reported as the opcode that defined it rather
/// than folded into a general "unknown".
/// </para>
/// </remarks>
public static class IndirectJumpClassifier
{
    private static readonly Dictionary<string, int> KindCounts = [];
    private static readonly Lock CountLock = new();

    /// <summary>A snapshot of what has been counted so far, most common first.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> Counts
    {
        get
        {
            lock (CountLock)
                return [.. KindCounts.OrderByDescending(pair => pair.Value)];
        }
    }

    public static void Reset()
    {
        Interlocked.Exchange(ref methodsSeen, 0);

        lock (CountLock)
            KindCounts.Clear();
    }

    /// <summary>How many methods this pass has been run on, so the counts can be read against it.</summary>
    /// <remarks>
    /// Analysis is not necessarily performed once per method - the diagnostics layer analyses a
    /// sample for real before the export does - and a count that does not say how many methods it
    /// covers cannot be compared with a count of placeholders in the output.
    /// </remarks>
    public static int MethodsSeen => methodsSeen;

    private static int methodsSeen;

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return;

        Interlocked.Increment(ref methodsSeen);

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();

        foreach (var instruction in instructions)
        {
            if (instruction.OpCode != OpCode.IndirectJump || instruction.Operands.Count == 0)
                continue;

            Record(Classify(instruction.Operands[0], instructions));
        }
    }

    private static void Record(string kind)
    {
        lock (CountLock)
            KindCounts[kind] = KindCounts.GetValueOrDefault(kind) + 1;
    }

    private static string Classify(IOperand target, List<Instruction> instructions)
    {
        // A local may have more than one definition once SSA has been destructed, so every definition
        // is classified and they have to agree; disagreement is its own answer rather than a coin toss.
        if (target is LocalVariable local)
        {
            var definitions = instructions.Where(i => ReferenceEquals(i.Destination, local)).ToList();

            if (definitions.Count == 0)
                return "ENTRY_VALUE";

            var kinds = definitions
                .Select(definition => definition.OpCode == OpCode.Move && definition.Operands.Count > 1
                    ? ClassifyDirect(definition.Operands[1])
                    : "DEFINED_BY_" + definition.OpCode)
                .Distinct()
                .ToList();

            return kinds.Count == 1 ? kinds[0] : "DEFINITIONS_DISAGREE";
        }

        return ClassifyDirect(target);
    }

    private static string ClassifyDirect(IOperand operand) => operand switch
    {
        FieldReference { Field.Name: "invoke_impl" or "method_ptr" } => "DELEGATE_INVOKE",
        FieldReference reference when IsRuntimeStructure(reference.Local.Type) => "VTABLE_SLOT",
        FieldReference => "MANAGED_FIELD",
        MemoryOperand { Base: LocalVariable based } when IsRuntimeStructure(based.Type) => "VTABLE_SLOT",
        MemoryOperand => "LOADED_POINTER",
        LocalVariable => "COPY_OF_LOCAL",
        Immediate => "CONSTANT_TARGET",
        _ => "OTHER_" + operand.GetType().Name,
    };

    /// <summary>
    /// A pointer into one of the runtime's own structures, which is where a dispatch table lives.
    /// </summary>
    private static bool IsRuntimeStructure(TypeAnalysisContext? type) =>
        type?.FullName is { } name
        && (name.StartsWith("Il2CppClass", System.StringComparison.Ordinal)
            || name.StartsWith("Il2CppMethodInfo", System.StringComparison.Ordinal)
            || name.StartsWith("Il2CppStaticFields", System.StringComparison.Ordinal));
}
