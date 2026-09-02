using AssetRipper.Il2CppRestore.Binary;
using AssetRipper.Il2CppRestore.Lift;
using AssetRipper.Il2CppRestore.Lift.Registration;
using AssetRipper.Il2CppRestore.Metadata;

namespace AssetRipper.Il2CppRestore.Emit;

/// <summary>
/// Everything shared across every method lifted in one run — built once, then handed to
/// <see cref="CSharpWriter"/> per type. A fresh <see cref="LiftContext"/> (method-specific: which method
/// this is, register seeding) is created per method from this.
/// </summary>
public sealed class LiftEnvironment
{
	public required Il2CppMetadata Metadata { get; init; }
	public required IBinaryImage Image { get; init; }
	public required StructDb.StructDb? Structs { get; init; }
	public required IReadOnlyDictionary<ulong, Usage> Usages { get; init; }
	public required IReadOnlyDictionary<ulong, MethodRef> MethodsByVa { get; init; }
	public required IReadOnlyDictionary<string, Il2CppCodeGenModule> CodeGenModules { get; init; }
	public required MethodAddressTable Addresses { get; init; }
	public required SortedDictionary<ulong, ulong> FunctionBoundaries { get; init; }
	public required IArchLifter Lifter { get; init; }

	/// <summary>Shared across the whole run so a helper learned while lifting one method is available to every other.</summary>
	public Dictionary<ulong, string> KnownHelpers { get; } = [];
}
