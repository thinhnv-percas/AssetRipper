using AssetRipper.Import.Logging;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.InstructionSets;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Says up front whether method bodies can be recovered from this particular binary.
/// </summary>
/// <remarks>
/// Recovery works by lifting native code to Cpp2IL's ISIL and converting that to CIL, and not every
/// architecture has a lifter. Where one is missing the output is silently indistinguishable from a
/// successful run with nothing to say — same file set, same signatures, empty bodies — so the one thing
/// this layer must do is make that visible instead of leaving it to be guessed.
/// </remarks>
public sealed class Il2CppRecoveryDiagnosticsProcessingLayer : Cpp2IlProcessingLayer
{
	public override string Name => "IL2CPP Recovery Diagnostics";

	public override string Id => "recoverydiagnostics";

	public override void Process(ApplicationAnalysisContext appContext, Action<int, int>? progressCallback = null)
	{
		Cpp2IlInstructionSet instructionSet = appContext.InstructionSet;
		string name = instructionSet.GetType().Name;

		if (CanProduceMethodBodies(instructionSet))
		{
			Logger.Info(LogCategory.Import, $"IL2Cpp method body recovery is available for this binary ({name}).");
		}
		else
		{
			Logger.Warning(LogCategory.Import,
				$"{name} does not lift native code to ISIL, so method bodies cannot be recovered from this binary and will be exported empty. " +
				"Class layouts, method signatures, field offsets and method addresses are unaffected. " +
				"Bodies can currently be recovered from x86, x86-64 and ARM64 binaries, but not from ARMv7 or WebAssembly.");
		}

		progressCallback?.Invoke(1, 1);
	}

	/// <summary>
	/// Whether <paramref name="instructionSet"/> produces ISIL, without which there is nothing for IL
	/// recovery to convert.
	/// </summary>
	public static bool CanProduceMethodBodies(Cpp2IlInstructionSet instructionSet) => instructionSet switch
	{
		// The selector answers for itself, since which way it points is a per-import decision.
		Arm64InstructionSetSelector => Arm64InstructionSetSelector.IsIsilCapable,

		// These three return an empty instruction list for every method. ARMv7 and WebAssembly have no
		// other implementation to switch to; ARM64 does, which is what the selector is for.
		ArmV7InstructionSet or WasmInstructionSet or Arm64InstructionSet => false,

		_ => true,
	};
}
