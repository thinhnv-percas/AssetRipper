using System;
using System.IO;
using System.Text;
using System.Threading;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: writes the ISIL of one method out at named points in the analysis.
/// </summary>
/// <remarks>
/// <para>
/// Every pass that matches a shape has to be written against the shape at the point it runs, and the
/// final body says nothing about that: a load is folded into the instruction that consumed it, a
/// class pointer is folded into a comparison, and a pass in the middle of the pipeline sees neither.
/// So when a pass matches nothing the only way to find out why is to look at what it was actually
/// handed.
/// </para>
/// <para>
/// Set <c>CPP2IL_DUMP_METHOD</c> to a substring of the method's full name and
/// <c>CPP2IL_DUMP_DIR</c> to somewhere to put the files; each stage becomes one file. Unset, this
/// costs one null check per stage.
/// </para>
/// </remarks>
public static class IsilDump
{
    private static readonly string? Wanted = Environment.GetEnvironmentVariable("CPP2IL_DUMP_METHOD");

    // AssetRipper: several methods, separated by '|', each into a subdirectory named after its pattern.
    private static readonly string[] Patterns = Wanted?.Split('|', StringSplitOptions.RemoveEmptyEntries) ?? [];

    private static string? Matching(MethodAnalysisContext method)
    {
        foreach (var pattern in Patterns)
            if (method.FullName.Contains(pattern, StringComparison.Ordinal))
                return pattern;
        return null;
    }

    private static string DirectoryFor(string pattern)
        => Patterns.Length > 1 ? Path.Combine(Directory!, Sanitise(pattern)) : Directory!;
    private static readonly string? Directory = Environment.GetEnvironmentVariable("CPP2IL_DUMP_DIR");

    private static int _ordinal;

    public static void Stage(MethodAnalysisContext method, string stage)
    {
        if (Wanted == null || Directory == null || method.ControlFlowGraph is not { } cfg)
            return;

        if (Matching(method) is not { } pattern)
            return;

        var directory = DirectoryFor(pattern);
        var text = new StringBuilder();
        text.AppendLine($"{method.FullName} @ {stage}");
        text.AppendLine();

        foreach (var block in cfg.Blocks)
        {
            text.AppendLine($"block {block.ID} ({block.BlockType}) <- [{string.Join(", ", block.Predecessors.ConvertAll(p => p.ID))}] -> [{string.Join(", ", block.Successors.ConvertAll(s => s.ID))}]");

            foreach (var instruction in block.Instructions)
                text.AppendLine($"    {instruction}");

            text.AppendLine();
        }

        System.IO.Directory.CreateDirectory(directory);
        var ordinal = Interlocked.Increment(ref _ordinal);
        File.WriteAllText(Path.Combine(directory, $"{ordinal:D3}-{Sanitise(stage)}.txt"), text.ToString());
    }

    /// <summary>A line of free text, appended to <c>trace.txt</c> beside the stage dumps.</summary>
    public static void Trace(MethodAnalysisContext method, string message)
    {
        if (Wanted == null || Directory == null || Matching(method) is not { } pattern)
            return;

        var directory = DirectoryFor(pattern);
        System.IO.Directory.CreateDirectory(directory);

        lock (TraceLock)
            File.AppendAllText(Path.Combine(directory, "trace.txt"), $"{method.FullName}: {message}{Environment.NewLine}");
    }

    private static readonly object TraceLock = new();

    private static string Sanitise(string name)
    {
        var chars = name.ToCharArray();

        for (var i = 0; i < chars.Length; i++)
            if (Array.IndexOf(Path.GetInvalidFileNameChars(), chars[i]) >= 0)
                chars[i] = '_';

        return new string(chars);
    }
}
