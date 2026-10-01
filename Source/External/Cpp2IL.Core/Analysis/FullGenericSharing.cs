using System.Collections.Concurrent;
using System.Linq;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: whether a method body is il2cpp's <em>fully shared</em> generic body, and what that
/// does to its calling convention.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 064. From Unity 2022 il2cpp can compile one body for every instantiation of a generic
/// method, value types included, by not knowing the size of <c>T</c> at all: such a body is emitted
/// for an instantiation whose arguments are <c>Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType</c>,
/// and its C++ signature changes. A value of a fully shared type is handled through a pointer to it
/// (<c>Il2CppFullySharedGenericAny</c>), and a method returning one does not return it: it takes an
/// extra argument, <c>il2cppRetVal</c>, after its parameters and before its <c>MethodInfo</c>, and
/// copies the result there. The body allocates its temporaries with <c>stack_slot_size</c> for the
/// same reason.
/// </para>
/// <para>
/// The calling convention that ignored this put the <c>MethodInfo</c> in the register that actually
/// holds <c>il2cppRetVal</c>. Nothing then typed the real <c>MethodInfo</c>, so nothing read out of it
/// - <c>klass</c>, the runtime generic context, every class and method the body looks up there - was
/// typed either: <c>Sirenix.Serialization.Utilities.ImmutableList`1.get_Item</c> reads its interface
/// class as <c>[[[X3 + klass] + rgctx_data] + 0]</c>, X3 being the <c>MethodInfo</c> of a method with
/// one parameter.
/// </para>
/// <para>
/// Which bodies are fully shared is metadata, not shape: the body at an address is fully shared when
/// an instantiation registered at that address has the placeholder among its arguments. That is what
/// the generic method table records, and a build without full sharing has no such instantiation, so
/// the answer is false everywhere and nothing changes.
/// </para>
/// </remarks>
public static class FullGenericSharing
{
    /// <summary>The type il2cpp substitutes for a generic argument it shares fully.</summary>
    public const string Placeholder = "Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType";

    private static readonly ConcurrentDictionary<(ApplicationAnalysisContext, ulong), ConcreteGenericMethodAnalysisContext?> Instances = new();

    /// <summary>
    /// The fully shared instantiation whose body <paramref name="method"/> is, or null when the body at
    /// its address is not a fully shared one.
    /// </summary>
    public static ConcreteGenericMethodAnalysisContext? FullySharedInstance(MethodAnalysisContext method)
    {
        if (method is ConcreteGenericMethodAnalysisContext concrete && IsFullySharedInstance(concrete))
            return concrete;

        var address = method.UnderlyingPointer;
        if (address == 0)
            return null;

        var app = method.AppContext;
        return Instances.GetOrAdd((app, address), key =>
            key.Item1.MethodsByAddress.TryGetValue(key.Item2, out var atAddress)
                ? atAddress.OfType<ConcreteGenericMethodAnalysisContext>().FirstOrDefault(IsFullySharedInstance)
                : null);
    }

    /// <summary>Whether <paramref name="method"/>'s body is a fully shared one.</summary>
    public static bool IsFullySharedBody(MethodAnalysisContext method) => FullySharedInstance(method) is not null;

    /// <summary>
    /// Whether a fully shared body returns through the extra <c>il2cppRetVal</c> pointer rather than in
    /// a register: its return type, as the shared instantiation states it, is a fully shared value.
    /// </summary>
    public static bool ReturnsThroughPointer(MethodAnalysisContext method)
        => FullySharedInstance(method) is { } instance && !instance.IsVoid && IsFullySharedValue(instance.ReturnType);

    /// <summary>
    /// Whether a type, as a fully shared instantiation states it, is a value whose size the body does not
    /// know: the placeholder itself, or a value type built from it.
    /// </summary>
    /// <remarks>
    /// A reference type built from it - <c>List&lt;__Il2CppFullySharedGenericType&gt;</c>, an array of
    /// it - is still a reference, one register wide, and is passed and returned as one.
    /// </remarks>
    public static bool IsFullySharedValue(TypeAnalysisContext? type) => type switch
    {
        null => false,
        _ when type.FullName == Placeholder => true,
        GenericInstanceTypeAnalysisContext instance => instance.GenericType.IsValueType && instance.GenericArguments.Any(IsFullySharedValueOrArgument),
        _ => false,
    };

    private static bool IsFullySharedValueOrArgument(TypeAnalysisContext type)
        => type.FullName == Placeholder || IsFullySharedValue(type);

    private static bool IsFullySharedInstance(ConcreteGenericMethodAnalysisContext method)
        => method.TypeGenericParameters.Concat(method.MethodGenericParameters).Any(argument => argument.FullName == Placeholder);
}
