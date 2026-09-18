using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
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

/// <summary>One recorded operation: what it was, and what it named.</summary>
public readonly record struct SemanticEntry(SemanticOperation Operation, string Detail);

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
        => _current?._entries.Add(new SemanticEntry(operation, detail));

    /// <summary>Whether anything is recording, so a caller can skip building a detail string.</summary>
    public static bool IsRecording => _current is not null;

    public readonly struct Scope(RecoveredSemanticIr recorder, string assembly) : IDisposable
    {
        public RecoveredSemanticIr Recorder => recorder;

        public void Dispose()
        {
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

            builder.Append("    \"operations\": [");

            for (var index = 0; index < body._entries.Count; index++)
            {
                if (index > 0)
                    builder.Append(", ");

                var entry = body._entries[index];
                builder.Append('[').Append(Quote(Name(entry.Operation))).Append(", ").Append(Quote(entry.Detail)).Append(']');
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
