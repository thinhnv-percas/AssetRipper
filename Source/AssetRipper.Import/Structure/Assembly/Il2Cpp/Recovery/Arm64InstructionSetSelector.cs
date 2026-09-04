using Cpp2IL.Core.Api;
using Cpp2IL.Core.Il2CppApiFunctions;
using Cpp2IL.Core.InstructionSets;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Registered for ARM64 in place of either concrete implementation, and forwards to whichever one the
/// current import needs.
/// </summary>
/// <remarks>
/// <para>
/// Cpp2IL ships two ARM64 implementations. <see cref="Arm64InstructionSet"/> returns an empty ISIL list
/// for every method, so IL recovery finds nothing to convert and writes a stub — which is exactly the
/// empty method bodies an ARM64 game produces at <c>ScriptContentLevel.Level3</c>.
/// <see cref="NewArmV8InstructionSet"/> is the one that actually lifts ARM64 to ISIL.
/// </para>
/// <para>
/// The choice cannot be made where the instruction sets are registered: registration happens once in a
/// static constructor, <see cref="InstructionSetRegistry"/> stores one set per architecture and refuses
/// to be told twice, and the content level is not known until an import starts. Hence the indirection.
/// </para>
/// </remarks>
public sealed class Arm64InstructionSetSelector : Cpp2IlInstructionSet
{
	private static readonly Lazy<Arm64InstructionSet> legacy = new(() => new Arm64InstructionSet());
	private static readonly Lazy<NewArmV8InstructionSet> isilCapable = new(() => new NewArmV8InstructionSet());

	/// <summary>
	/// True to use the implementation that can lift ARM64 to ISIL, which is what method body recovery
	/// needs. False — the default — keeps the implementation every content level below
	/// <c>Level3</c> has always used.
	/// </summary>
	public static bool PreferIsilCapable { get; set; }

	/// <summary>Whether the selector is currently pointing at an implementation that produces ISIL.</summary>
	public static bool IsIsilCapable => PreferIsilCapable;

	private static Cpp2IlInstructionSet Current => PreferIsilCapable ? isilCapable.Value : legacy.Value;

	public override BinarySlice GetRawBytesForMethod(MethodAnalysisContext context, bool isAttributeGenerator)
		=> Current.GetRawBytesForMethod(context, isAttributeGenerator);

	public override ulong GetPointerForMethod(MethodAnalysisContext context)
		=> Current.GetPointerForMethod(context);

	public override List<Instruction> GetIsilFromMethod(MethodAnalysisContext context)
		=> Current.GetIsilFromMethod(context);

	public override List<IOperand> GetParameterOperandsFromMethod(MethodAnalysisContext context)
		=> Current.GetParameterOperandsFromMethod(context);

	public override BaseKeyFunctionAddresses CreateKeyFunctionAddressesInstance()
		=> Current.CreateKeyFunctionAddressesInstance();

	public override string PrintAssembly(MethodAnalysisContext context)
		=> Current.PrintAssembly(context);
}
