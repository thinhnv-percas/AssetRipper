using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: the canonical operations a recovered method body performs.
/// </summary>
/// <remarks>
/// These are semantic, not CIL: <see cref="PropertyRead"/> and <see cref="LoadField"/> emit the same
/// kind of instruction and mean different things to a reader, and <see cref="ListAdd"/> is a call the
/// recovery put back rather than an opcode. The point is that a measurement and a reader agree about
/// what a body does without either of them re-deriving it from text.
/// </remarks>
public enum SemanticOperation
{
    LoadField,
    StoreField,
    PropertyRead,
    PropertyWrite,
    LoadStatic,
    StoreStatic,
    ArrayLoad,
    ArrayStore,
    ArrayLength,
    ArrayCreate,

    Call,
    VirtualCall,
    InterfaceCall,
    DelegateCall,
    IndirectCall,

    NewObject,
    NewArray,

    Box,
    Unbox,
    Cast,
    IsInst,

    Compare,
    Arithmetic,

    Branch,
    Switch,
    Loop,

    Return,
    Throw,

    FieldAddress,
    ObjectAddress,

    RuntimeBoundary,

    ListAdd,
}

/// <summary>
/// AssetRipper: one recorded operation - what it was, what it named, where in the graph it sits, and
/// which values it consumed and produced.
/// </summary>
/// <remarks>
/// A sequence of operation names says a method compares something and branches; it cannot say
/// <em>what</em> it compared, so a recovery that compares the wrong field reads identically to one
/// that compares the right one. <see cref="Result"/> and <see cref="Operands"/> name the values by
/// the ISIL local they live in, which is what lets a reader chain them: the load that produced a
/// value and the comparison that consumed it name the same local.
/// </remarks>
public readonly record struct SemanticEntry(
    SemanticOperation Operation,
    string Detail,
    int Block,
    string Result,
    IReadOnlyList<string> Operands,
    string ResultType);

/// <summary>
/// AssetRipper: one basic block of the graph the generator emitted from.
/// </summary>
/// <remarks>
/// Recorded from <see cref="Cpp2IL.Core.Graphs.ISILControlFlowGraph.Blocks"/>, which is the list the
/// generator iterates - not the breadth-first walk, which omits any block nothing reaches while the
/// generator emits it anyway.
/// <para>
/// Exception edges are deliberately absent rather than guessed at. The graph is built from the lifted
/// ISIL, where a throw is still a call to an il2cpp raise helper; the passes that rewrite it into
/// <c>OpCode.Throw</c> do not revisit the edges, and <c>UnreachableAfterThrow</c> then detaches the
/// block. So a throwing block has no outgoing edge to record, and there are no handlers in a recovered
/// body for one to reach.
/// </para>
/// </remarks>
public sealed record SemanticBlock(
    int Id,
    IReadOnlyList<int> Successors,
    IReadOnlyList<int> Predecessors,
    string Terminator,
    string Condition,
    bool IsLoopHeader);

/// <summary>
/// AssetRipper: what a method body was recovered as, recorded by the generator as it emits.
/// </summary>
/// <remarks>
/// <para>
/// This exists because the measurement and the generated code were reading two different programs.
/// The semantic measurements used to parse <c>[NativeSource(Body = …)]</c> - a rendering of the ISIL -
/// and compare the operations they found there against the operations they found in the decompiled
/// C#. Both halves were re-derivations from text, and both were wrong in their own way: the rendering
/// walked a flat instruction list the generator no longer emits from, and it named a field the
/// generator writes out as a property. Each was a whole iteration to find.
/// </para>
/// <para>
/// A record built <em>by the generator, at the point it emits</em> cannot drift from what it emits.
/// Every canonicalisation the generator performs - the accessor pairing, the folded
/// <c>List&lt;T&gt;.Add</c>, a packed store split across the fields it covers - is recorded as the
/// decision is taken rather than inferred from the result afterwards.
/// </para>
/// <para>
/// It is deliberately a *record*, not a second IR the generator consumes: nothing downstream of the
/// generator reads it back, so it cannot change what is exported. A measurement that can change the
/// artefact it measures is worse than no measurement.
/// </para>
/// </remarks>
public sealed class RecoveredSemanticIr
{
    /// <summary>The builder the generator is recording into on this thread, if any.</summary>
    [ThreadStatic]
    private static RecoveredSemanticIr? _current;

    private readonly List<SemanticEntry> _entries = [];
    private readonly List<SemanticBlock> _blocks = [];

    /// <summary>The block whose instructions the generator is emitting, and the instruction itself.</summary>
    private int _block = -1;
    private Instruction? _instruction;

    /// <summary>Every body recorded in this run, keyed by assembly and then by method.</summary>
    /// <remarks>
    /// Keyed by RVA within the assembly because that is what the exported
    /// <c>[Address(RVA = "0x…")]</c> carries, so a measurement reading the export can find the record
    /// for the method it is looking at without matching names through a decompiler's renaming.
    /// </remarks>
    public static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, RecoveredSemanticIr>> Recorded = new();

    public string Method { get; init; } = "";
    public string DeclaringType { get; init; } = "";
    public string ReturnType { get; init; } = "";
    public IReadOnlyList<string> Parameters { get; init; } = [];
    public ulong Rva { get; init; }

    /// <summary>Set when the generator threw; the body that was exported is a stand-in.</summary>
    public string? GeneratorFailure { get; set; }

    public IReadOnlyList<SemanticEntry> Entries => _entries;

    /// <summary>The graph the body was emitted from, in the generator's own iteration order.</summary>
    public IReadOnlyList<SemanticBlock> Blocks => _blocks;

    /// <summary>
    /// Starts recording for one method. The returned scope must be disposed, which is what files the
    /// record; a body that threw out of the generator files what it had reached, with the failure.
    /// </summary>
    public static Scope Begin(MethodAnalysisContext context)
    {
        var recorder = new RecoveredSemanticIr
        {
            Method = context.Name,
            DeclaringType = context.DeclaringType?.FullName ?? "",
            ReturnType = context.ReturnType?.FullName ?? "",
            Parameters = [.. context.Parameters.ConvertAll(parameter => parameter.ParameterType?.FullName ?? "")],
            Rva = context.Rva,
        };

        _current = recorder;
        return new Scope(recorder, context.DeclaringType?.DeclaringAssembly?.Name ?? "<unknown>");
    }

    /// <summary>
    /// Records one operation. Called from the generator at the point the CIL for it is emitted, which
    /// is the whole reason this cannot drift from what is exported.
    /// </summary>
    public static void Record(SemanticOperation operation, string detail = "")
    {
        if (_current is not { } recorder)
            return;

        var instruction = recorder._instruction;
        recorder._entries.Add(new SemanticEntry(
            operation,
            detail,
            recorder._block,
            instruction?.Destination is { } destination ? Describe(destination) : "",
            instruction is null ? [] : DescribeOperands(instruction),
            instruction?.Destination is LocalVariable { Type: { } type } ? type.FullName : ""));
    }

    /// <summary>The block the generator is about to emit, so every operation says where it sits.</summary>
    public static void EnterBlock(Block block)
    {
        if (_current is { } recorder)
            recorder._block = block.ID;
    }

    /// <summary>
    /// The instruction the generator is about to emit code for, so every operation it records names
    /// the values that instruction reads and writes without any site having to pass them.
    /// </summary>
    public static void EnterInstruction(Instruction instruction)
    {
        if (_current is { } recorder)
            recorder._instruction = instruction;
    }

    /// <summary>
    /// Records the shape of the graph, from the same list the generator emits from.
    /// </summary>
    /// <remarks>
    /// A loop header is a block some successor of which jumps back to it - the same back-edge test the
    /// <see cref="SemanticOperation.Loop"/> entries use, recorded here per block so a comparison can
    /// ask which block carries the loop rather than only how many loops there are.
    /// </remarks>
    public static void RecordGraph(ISILControlFlowGraph graph)
    {
        if (_current is not { } recorder)
            return;

        foreach (var block in graph.Blocks)
        {
            if (block == graph.EntryBlock || block == graph.ExitBlock || block.Instructions.Count == 0)
                continue;

            var terminator = block.Instructions[^1];
            var isLoopHeader = block.Predecessors.Exists(predecessor =>
                predecessor.Instructions.Count > 0
                && predecessor.Instructions[0].Index >= block.Instructions[0].Index);

            recorder._blocks.Add(new SemanticBlock(
                block.ID,
                [.. block.Successors.ConvertAll(successor => successor.ID)],
                [.. block.Predecessors.ConvertAll(predecessor => predecessor.ID)],
                terminator.OpCode.ToString(),
                terminator.OpCode is OpCode.ConditionalJump && terminator.Operands.Count > 1
                    ? Describe(terminator.Operands[1])
                    : "",
                isLoopHeader));
        }
    }

    /// <summary>
    /// Names a value so that the operation producing it and the operation consuming it say the same
    /// thing. A local's name is its identity through SSA destruction; anything else is described by
    /// what it reads, which is what makes <c>field.hp -&gt; compare -&gt; branch</c> a readable chain.
    /// </summary>
    internal static string Describe(IOperand operand) => operand switch
    {
        LocalVariable local => local.Name,
        Register register => register.ToString(),
        Immediate immediate => $"#{immediate.Value}",
        FieldReference field => $"{Describe(field.Local)}.{field.Field?.Name ?? "?"}",
        ArrayAccess array => $"{Describe(array.Array)}[]",
        ArrayLength length => $"{Describe(length.Array)}.Length",
        AddressOf address => $"&{Describe(address.Target)}",
        StringLiteral => "\"…\"",
        Instruction instruction => $"@{instruction.Index}",
        MethodAnalysisContext method => method.FullName,
        TypeAnalysisContext type => type.FullName,
        Block block => $"block{block.ID}",
        null => "",
        _ => operand.GetType().Name,
    };

    /// <summary>
    /// What the instruction reads, described.
    /// </summary>
    /// <remarks>
    /// The operands rather than <c>Sources</c>: a field load's source is a <c>FieldReference</c>, and
    /// <c>Sources</c> reports the registers read, which for that shape is nothing at all - so a
    /// <c>LOAD_FIELD</c> recorded from it names no value it read and the chain breaks exactly where it
    /// is most wanted. The destination is skipped, since it is already recorded as the result.
    /// </remarks>
    private static List<string> DescribeOperands(Instruction instruction)
    {
        var operands = instruction.Operands;
        var destination = instruction.Destination;
        List<string> described = new(operands.Count);

        for (var index = 0; index < operands.Count; index++)
        {
            if (ReferenceEquals(operands[index], destination))
                continue;

            described.Add(Describe(operands[index]));
        }

        return described;
    }

    /// <summary>Whether anything is recording, so a caller can skip building a detail string.</summary>
    public static bool IsRecording => _current is not null;

    public readonly struct Scope(RecoveredSemanticIr recorder, string assembly) : IDisposable
    {
        public RecoveredSemanticIr Recorder => recorder;

        public void Dispose()
        {
            recorder._instruction = null;
            _current = null;

            if (recorder.Rva == 0)
                return;

            Recorded
                .GetOrAdd(assembly, static _ => new ConcurrentDictionary<string, RecoveredSemanticIr>())
                [$"0x{recorder.Rva:X}"] = recorder;
        }
    }

    /// <summary>
    /// Every recorded body as JSON, written by hand rather than through a serializer so that this
    /// stays AOT-compatible and so the shape is visible in one place.
    /// </summary>
    public static string ToJson(string assembly)
    {
        if (!Recorded.TryGetValue(assembly, out var bodies))
            return "{}";

        StringBuilder builder = new();
        builder.Append("{\n");
        var firstBody = true;

        foreach (var (rva, body) in bodies)
        {
            if (!firstBody)
                builder.Append(",\n");

            firstBody = false;

            builder.Append("  ").Append(Quote(rva)).Append(": {\n");
            builder.Append("    \"method\": ").Append(Quote(body.Method)).Append(",\n");
            builder.Append("    \"declaringType\": ").Append(Quote(body.DeclaringType)).Append(",\n");
            builder.Append("    \"returnType\": ").Append(Quote(body.ReturnType)).Append(",\n");
            builder.Append("    \"parameters\": [");

            for (var index = 0; index < body.Parameters.Count; index++)
            {
                if (index > 0)
                    builder.Append(", ");

                builder.Append(Quote(body.Parameters[index]));
            }

            builder.Append("],\n");

            if (body.GeneratorFailure is { } failure)
                builder.Append("    \"generatorFailure\": ").Append(Quote(failure)).Append(",\n");

            builder.Append("    \"blocks\": [");

            for (var index = 0; index < body._blocks.Count; index++)
            {
                if (index > 0)
                    builder.Append(", ");

                var block = body._blocks[index];
                builder.Append("{\"id\": ").Append(block.Id);
                builder.Append(", \"successors\": ").Append(Numbers(block.Successors));
                builder.Append(", \"predecessors\": ").Append(Numbers(block.Predecessors));
                builder.Append(", \"terminator\": ").Append(Quote(block.Terminator));
                builder.Append(", \"condition\": ").Append(Quote(block.Condition));
                builder.Append(", \"loopHeader\": ").Append(block.IsLoopHeader ? "true" : "false");
                builder.Append('}');
            }

            builder.Append("],\n");
            builder.Append("    \"operations\": [");

            for (var index = 0; index < body._entries.Count; index++)
            {
                if (index > 0)
                    builder.Append(", ");

                var entry = body._entries[index];
                builder.Append('[').Append(Quote(Name(entry.Operation))).Append(", ").Append(Quote(entry.Detail));
                builder.Append(", ").Append(entry.Block);
                builder.Append(", ").Append(Quote(entry.Result));
                builder.Append(", ").Append(Strings(entry.Operands));
                builder.Append(", ").Append(Quote(entry.ResultType));
                builder.Append(']');
            }

            builder.Append("]\n  }");
        }

        builder.Append("\n}\n");
        return builder.ToString();
    }

    /// <summary>The name a measurement reads, in the brief's own spelling.</summary>
    internal static string Name(SemanticOperation operation) => operation switch
    {
        SemanticOperation.LoadField => "LOAD_FIELD",
        SemanticOperation.StoreField => "STORE_FIELD",
        SemanticOperation.PropertyRead => "PROPERTY_READ",
        SemanticOperation.PropertyWrite => "PROPERTY_WRITE",
        SemanticOperation.LoadStatic => "LOAD_STATIC",
        SemanticOperation.StoreStatic => "STORE_STATIC",
        SemanticOperation.ArrayLoad => "ARRAY_LOAD",
        SemanticOperation.ArrayStore => "ARRAY_STORE",
        SemanticOperation.ArrayLength => "ARRAY_LENGTH",
        SemanticOperation.ArrayCreate => "ARRAY_CREATE",
        SemanticOperation.Call => "CALL",
        SemanticOperation.VirtualCall => "VIRTUAL_CALL",
        SemanticOperation.InterfaceCall => "INTERFACE_CALL",
        SemanticOperation.DelegateCall => "DELEGATE_CALL",
        SemanticOperation.IndirectCall => "INDIRECT_CALL",
        SemanticOperation.NewObject => "NEW_OBJECT",
        SemanticOperation.NewArray => "NEW_ARRAY",
        SemanticOperation.Box => "BOX",
        SemanticOperation.Unbox => "UNBOX",
        SemanticOperation.Cast => "CAST",
        SemanticOperation.IsInst => "ISINST",
        SemanticOperation.Compare => "COMPARE",
        SemanticOperation.Arithmetic => "ARITHMETIC",
        SemanticOperation.Branch => "BRANCH",
        SemanticOperation.Switch => "SWITCH",
        SemanticOperation.Loop => "LOOP",
        SemanticOperation.Return => "RETURN",
        SemanticOperation.Throw => "THROW",
        SemanticOperation.FieldAddress => "FIELD_ADDRESS",
        SemanticOperation.ObjectAddress => "OBJECT_ADDRESS",
        SemanticOperation.RuntimeBoundary => "RUNTIME_BOUNDARY",
        SemanticOperation.ListAdd => "LIST_ADD",
        _ => operation.ToString(),
    };

    private static string Numbers(IReadOnlyList<int> values)
    {
        StringBuilder builder = new();
        builder.Append('[');

        for (var index = 0; index < values.Count; index++)
        {
            if (index > 0)
                builder.Append(", ");

            builder.Append(values[index]);
        }

        builder.Append(']');
        return builder.ToString();
    }

    private static string Strings(IReadOnlyList<string> values)
    {
        StringBuilder builder = new();
        builder.Append('[');

        for (var index = 0; index < values.Count; index++)
        {
            if (index > 0)
                builder.Append(", ");

            builder.Append(Quote(values[index]));
        }

        builder.Append(']');
        return builder.ToString();
    }

    private static string Quote(string value)
    {
        StringBuilder builder = new(value.Length + 2);
        builder.Append('"');

        foreach (var character in value)
        {
            switch (character)
            {
                case '"': builder.Append("\\\""); break;
                case '\\': builder.Append("\\\\"); break;
                case '\n': builder.Append("\\n"); break;
                case '\r': builder.Append("\\r"); break;
                case '\t': builder.Append("\\t"); break;
                default:
                    if (character < 0x20)
                        builder.Append("\\u").Append(((int)character).ToString("x4"));
                    else
                        builder.Append(character);
                    break;
            }
        }

        builder.Append('"');
        return builder.ToString();
    }
}
