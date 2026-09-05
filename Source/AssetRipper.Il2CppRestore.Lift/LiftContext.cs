using AssetRipper.Il2CppRestore.Binary;
using AssetRipper.Il2CppRestore.Lift.Registration;
using AssetRipper.Il2CppRestore.Metadata;
using AssetRipper.Il2CppRestore.StructDb;

namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// Everything one call to <see cref="IArchLifter.Lift"/> needs to turn raw instructions into
/// <see cref="Statement"/>s for a single method — bundled here so the lift loop itself stays about the
/// instructions, not about threading four different lookups through every case.
/// </summary>
public sealed class LiftContext
{
	public required Il2CppMetadata Metadata { get; init; }
	public required IBinaryImage Image { get; init; }
	public required StructDb.StructDb? Structs { get; init; }
	public required IReadOnlyDictionary<ulong, Usage> Usages { get; init; }
	public required IReadOnlyDictionary<ulong, MethodRef> MethodsByVa { get; init; }
	public required MethodRef Current { get; init; }

	/// <summary>Runtime helper addresses learned by <see cref="Arm64Lifter.LearnHelpers"/>, shared across every method lifted in the same run.</summary>
	public Dictionary<ulong, string> KnownHelpers { get; } = [];

	private int _tempCounter;

	/// <summary>A fresh, unique local name for a call result — see <see cref="SymValue.CallResult"/>.</summary>
	public string NextTempName() => $"ret{_tempCounter++}";
}
