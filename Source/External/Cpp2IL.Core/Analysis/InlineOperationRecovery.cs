using System.Collections.Concurrent;
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

    /// <summary>The families this recovery knows. Only <c>LIST_ADD</c> is implemented today.</summary>
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

    internal static void CountRejection(Family family, string reason)
        => Rejections.AddOrUpdate($"{family}:{reason}", 1, static (_, count) => count + 1);

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
        if (!InlineListAddRecovery.Run(cfg, method))
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
        MatchesByFamily.Clear();
        MatchedMethods.Clear();
    }

    /// <summary>The families that have a rule, for the report to distinguish absent from unimplemented.</summary>
    public static IReadOnlyList<Family> ImplementedFamilies { get; } = [Family.ListAdd];
}
