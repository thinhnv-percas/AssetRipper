using System.Collections.Concurrent;
using System.Linq;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Utils;

/// <summary>
/// AssetRipper: resolves a floating point machine instruction that has no ISIL equivalent — a square
/// root, an absolute value, a rounding mode — to the managed method that computes the same thing, so
/// the lifter can emit a call instead of a diagnostic.
/// </summary>
/// <remarks>
/// Only an exact signature match is taken. Nothing downstream inserts a widening or narrowing
/// conversion, so a call to <c>System.Math.Sqrt(double)</c> from single precision code would leave a
/// float32 where the signature wants a float64 and the whole body would be discarded as unverifiable
/// — strictly worse than the diagnostic it replaced. For single precision that means
/// <c>UnityEngine.Mathf</c> or <c>System.MathF</c>, whichever the game ships.
/// </remarks>
public static class MathIntrinsics
{
    private static readonly ConcurrentDictionary<(ApplicationAnalysisContext, string, bool, int), MethodAnalysisContext?> Cache = new();

    /// <param name="name">The <c>System.Math</c> spelling of the operation, e.g. <c>Ceiling</c>.</param>
    /// <param name="isDouble">Whether the machine instruction operated on double precision registers.</param>
    /// <param name="parameterCount">How many operands the machine instruction consumed.</param>
    public static MethodAnalysisContext? Resolve(ApplicationAnalysisContext app, string name, bool isDouble, int parameterCount)
        => Cache.GetOrAdd((app, name, isDouble, parameterCount), key => Find(key.Item1, key.Item2, key.Item3, key.Item4));

    private static MethodAnalysisContext? Find(ApplicationAnalysisContext app, string name, bool isDouble, int parameterCount)
    {
        var corlib = app.SystemTypes.SystemDoubleType.DeclaringAssembly;

        if (isDouble)
            return Match(corlib.GetTypeByFullName("System.Math"), name, app.SystemTypes.SystemDoubleType, parameterCount);

        var single = app.SystemTypes.SystemSingleType;

        // Mathf first: a Unity game always has it, and it predates MathF by years.
        return Match(FindType(app, "UnityEngine.Mathf"), UnityName(name), single, parameterCount)
            ?? Match(corlib.GetTypeByFullName("System.MathF"), name, single, parameterCount);
    }

    private static TypeAnalysisContext? FindType(ApplicationAnalysisContext app, string fullName)
    {
        foreach (var assembly in app.Assemblies)
        {
            if (assembly.GetTypeByFullName(fullName) is { } type)
                return type;
        }

        return null;
    }

    private static MethodAnalysisContext? Match(TypeAnalysisContext? type, string? name, TypeAnalysisContext parameterType, int parameterCount)
    {
        if (type == null || name == null)
            return null;

        return type.Methods.FirstOrDefault(m =>
            m.IsStatic && m.Name == name && m.ReturnType == parameterType
            && m.Parameters.Count == parameterCount
            && m.Parameters.All(p => p.ParameterType == parameterType));
    }

    // Mathf spells two of them differently, and has no equivalent for the rest.
    private static string? UnityName(string name) => name switch
    {
        "Ceiling" => "Ceil",
        "Sqrt" or "Abs" or "Floor" or "Round" or "Max" or "Min" => name,
        _ => null,
    };
}
