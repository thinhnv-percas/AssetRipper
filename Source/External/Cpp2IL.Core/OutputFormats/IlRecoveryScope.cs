using System;
using System.Collections.Generic;
using System.Linq;

namespace Cpp2IL.Core.OutputFormats;

/// <summary>
/// AssetRipper: which assemblies are opted back into body recovery for a measurement run.
/// </summary>
/// <remarks>
/// Engine and package assemblies are stubbed by name (<c>UnityEngine.*</c>, <c>Unity.*</c>, the BCL): a
/// recovered project gets those from the Unity install and the Package Manager, not from the export. That
/// also means the one kind of code whose source is independently available - an upstream package at the
/// version the build shipped - never has a recovered body to compare against. <c>CPP2IL_RECOVER_ALSO</c>
/// names assemblies (comma separated, without <c>.dll</c>) to recover anyway, so a source oracle can be
/// run on them. It is off unless set, and nothing else changes when it is.
/// </remarks>
public static class IlRecoveryScope
{
    private static readonly HashSet<string> Also = Parse(Environment.GetEnvironmentVariable("CPP2IL_RECOVER_ALSO"));

    /// <summary>The assemblies named by the environment, for a log line that says the run was not a default one.</summary>
    public static IReadOnlyCollection<string> RecoveredAlso => Also;

    public static bool IsRecoveredAlso(string assemblyName) => Also.Contains(Normalise(assemblyName));

    public static HashSet<string> Parse(string? value)
        => value is null
            ? new HashSet<string>(StringComparer.Ordinal)
            : value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(Normalise)
                .ToHashSet(StringComparer.Ordinal);

    private static string Normalise(string assemblyName)
        => assemblyName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) ? assemblyName[..^4] : assemblyName;
}
