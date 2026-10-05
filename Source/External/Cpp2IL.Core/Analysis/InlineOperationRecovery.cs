using System;
using System.Collections.Concurrent;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: the framework a family of inlined framework operations is recognised through.
/// </summary>
/// <remarks>
/// il2cpp inlines the fast path of a collection operation into its caller, so a body that the
/// programmer wrote as <c>list.Add(x)</c> arrives as a read of the backing array, a version bump, a
/// capacity test, an element store and a size update — four private fields of the framework type,
/// none of which C# lets the caller name. Those are not four defects: they are one operation whose
/// name was lost, and putting the name back is a semantic rewrite in the IR rather than a repair of
/// the generated C#.
///
/// A family reports rather than asserts. <see cref="MatchStatus"/> separates a site the evidence
/// settles from one it does not, and only <see cref="MatchStatus.Exact"/> is rewritten - a rule that
/// guesses corrupts a call site silently, which is the failure mode this whole pipeline is written
/// against. Every rejection is counted under the reason it was rejected for, because a family that
/// matches nothing and a family that is never reached print the same number otherwise.
/// </remarks>
public static class InlineOperationRecovery
{
    /// <summary>
    /// How far the evidence at a candidate site goes.
    /// </summary>
    public enum MatchStatus
    {
        /// <summary>Nothing at the site identifies the operation.</summary>
        Unknown,

        /// <summary>The shape is present but a part of it could not be tied to the same receiver.</summary>
        Partial,

        /// <summary>Every part is present and consistent, but one rests on an inference.</summary>
        HighConfidence,

        /// <summary>Every part is present, consistent, and named by the binary itself.</summary>
        Exact,
    }

    /// <summary>The families this recovery knows. <c>LIST_ADD</c> and, from iteration 065, <c>LIST_CLEAR</c> are implemented.</summary>
    public enum Family
    {
        ListAdd,
        ListInsert,
        ListRemoveAt,
        ListClear,
        DictionaryAdd,
        HashSetAdd,
    }

    private static long _candidates;
    private static long _matched;

    /// <summary>Candidate sites the families were offered, across every analysed body.</summary>
    public static long Candidates => Interlocked.Read(ref _candidates);

    /// <summary>Candidate sites rewritten into the operation they came from.</summary>
    public static long Matched => Interlocked.Read(ref _matched);

    /// <summary>Why each rejected site was rejected, so a rule that never fires cannot read as a rule that finds nothing.</summary>
    public static readonly ConcurrentDictionary<string, int> Rejections = new();

    /// <summary>Matches per family, for the per-fixture breakdown.</summary>
    public static readonly ConcurrentDictionary<string, int> MatchesByFamily = new();

    /// <summary>The methods a match was made in, capped, so a report can name them.</summary>
    public static readonly ConcurrentDictionary<string, int> MatchedMethods = new();

    internal static void CountCandidate() => Interlocked.Increment(ref _candidates);

    internal static void CountMatch(Family family, MethodAnalysisContext method)
    {
        Interlocked.Increment(ref _matched);
        MatchesByFamily.AddOrUpdate(family.ToString(), 1, static (_, count) => count + 1);

        if (MatchedMethods.Count < 4096)
            MatchedMethods.AddOrUpdate(method.FullName, 1, static (_, count) => count + 1);
    }

    /// <summary>
    /// Writes every rejection reason with its count and examples, where
    /// <c>CPP2IL_DUMP_REJECTIONS</c> names a file.
    /// </summary>
    /// <remarks>
    /// The log prints the twenty-five largest reasons, which is a truncated measurement: the moment a
    /// reason is made more specific it splits into several smaller ones and the family disappears
    /// from the log altogether - which reads exactly like a family that stopped occurring. The file
    /// carries all of them.
    /// </remarks>
    public static void DumpRejections()
    {
        var path = Environment.GetEnvironmentVariable("CPP2IL_DUMP_REJECTIONS");

        if (string.IsNullOrEmpty(path))
            return;

        List<string> lines = [];

        foreach (var (reason, count) in Rejections)
        {
            var examples = RejectionExamples.TryGetValue(reason, out var named) ? string.Join(" | ", named) : "";
            lines.Add($"{count}\t{reason}\t{examples}");
        }

        lines.Sort(static (left, right) =>
            int.Parse(right.Split('\t')[0]).CompareTo(int.Parse(left.Split('\t')[0])));

        try
        {
            File.WriteAllLines(path, lines);
        }
        catch (IOException)
        {
            // A dump that cannot be written is not a reason to fail a rip.
        }
    }

    /// <summary>Up to three methods per reason, so a family has an example and not only a count.</summary>
    /// <remarks>
    /// A count says how big a family is; an example says what it is. Seven times now this project has
    /// had to split a family named after its symptom, and every time the split came from reading
    /// cases rather than from the total.
    /// </remarks>
    public static readonly ConcurrentDictionary<string, List<string>> RejectionExamples = new();

    internal static void CountRejection(Family family, string reason, MethodAnalysisContext? method = null)
    {
        var key = $"{family}:{reason}";
        Rejections.AddOrUpdate(key, 1, static (_, count) => count + 1);

        if (method is null)
            return;

        var examples = RejectionExamples.GetOrAdd(key, static _ => []);

        lock (examples)
        {
            if (examples.Count < 3)
                examples.Add(method.FullName ?? method.Name);
        }
    }

    /// <summary>
    /// Runs every implemented family over one body.
    /// </summary>
    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } cfg)
            return;

        Run(cfg, method);
    }

    /// <summary>
    /// Runs every implemented family over one graph. Split out so a family can be exercised over a
    /// graph built by hand, with no metadata behind it.
    /// </summary>
    public static void Run(ISILControlFlowGraph cfg, MethodAnalysisContext? method)
    {
        // AssetRipper: iteration 065, Clear beside Add. Both run; either rewriting is reason to tidy.
        var added = InlineListAddRecovery.Run(cfg, method);
        var cleared = InlineListClearRecovery.Run(cfg, method);

        if (!added && !cleared)
            return;

        // A rewritten site leaves the fast path with nothing reaching it and the loads that fed the
        // capacity test with nothing reading them.
        cfg.RemoveUnreachableBlocks();
        DeadCodeEliminator.Run(cfg);
    }

    /// <summary>Resets every counter. For tests, which must not see another test's totals.</summary>
    public static void ResetCounters()
    {
        Interlocked.Exchange(ref _candidates, 0);
        Interlocked.Exchange(ref _matched, 0);
        Rejections.Clear();
        RejectionExamples.Clear();
        MatchesByFamily.Clear();
        MatchedMethods.Clear();
    }

    /// <summary>The families that have a rule, for the report to distinguish absent from unimplemented.</summary>
    public static IReadOnlyList<Family> ImplementedFamilies { get; } = [Family.ListAdd, Family.ListClear];
}
