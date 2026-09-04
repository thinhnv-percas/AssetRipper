using AssetRipper.Import.Logging;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.InstructionSets;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Reports, before anything expensive runs, what recovery can actually do with the binary in hand.
/// </summary>
/// <remarks>
/// Recovery works by lifting native code to Cpp2IL's ISIL and converting that to CIL. When the lift
/// produces nothing the run still succeeds: same file set, same class layouts, same signatures, every
/// method body empty. Nothing in the output distinguishes that from a game whose methods really are
/// empty, so this layer measures it and says so.
/// </remarks>
public sealed class Il2CppRecoveryDiagnosticsProcessingLayer : Cpp2IlProcessingLayer
{
	/// <summary>
	/// Methods to lift as a sample. Enough to be conclusive, small enough that the answer arrives in
	/// seconds rather than after the whole run.
	/// </summary>
	private const int SampleSize = 200;

	public override string Name => "IL2CPP Recovery Diagnostics";

	public override string Id => "recoverydiagnostics";

	public override void Process(ApplicationAnalysisContext appContext, Action<int, int>? progressCallback = null)
	{
		Cpp2IlInstructionSet instructionSet = appContext.InstructionSet;
		string instructionSetName = instructionSet.GetType().Name;

		Logger.Info(LogCategory.Import,
			$"Il2Cpp recovery: Unity {appContext.UnityVersion}, metadata v{appContext.MetadataVersion}, " +
			$"{(appContext.Binary.is32Bit ? "32" : "64")}-bit, instruction set {instructionSetName}.");

		ReportAssemblies(appContext);

		if (!CanProduceMethodBodies(instructionSet))
		{
			Logger.Warning(LogCategory.Import,
				$"Il2Cpp recovery: {instructionSetName} does not lift native code to ISIL, so method bodies cannot be " +
				"recovered from this binary and every method will be exported empty. Class layouts, method signatures, " +
				"field offsets and method addresses are unaffected. Bodies can be recovered from x86, x86-64 and ARM64 " +
				"binaries, but not from ARMv7 or WebAssembly.");

			progressCallback?.Invoke(1, 1);
			return;
		}

		SampleLifting(appContext);

		progressCallback?.Invoke(1, 1);
	}

	/// <summary>
	/// Names the assemblies recovery will attempt, because a reader looking at the wrong one sees empty
	/// bodies no matter how well recovery went: Cpp2IL stubs the framework assemblies by design.
	/// </summary>
	private static void ReportAssemblies(ApplicationAnalysisContext appContext)
	{
		List<string> gameAssemblies = [];
		int frameworkCount = 0;

		foreach (AssemblyAnalysisContext assembly in appContext.Assemblies)
		{
			if (IsFrameworkAssembly(assembly.CleanAssemblyName))
			{
				frameworkCount++;
			}
			else
			{
				gameAssemblies.Add(assembly.CleanAssemblyName);
			}
		}

		gameAssemblies.Sort(StringComparer.OrdinalIgnoreCase);

		Logger.Info(LogCategory.Import,
			$"Il2Cpp recovery: {gameAssemblies.Count} assemblies will be attempted, {frameworkCount} framework assemblies " +
			$"will be stubbed. Attempted: {(gameAssemblies.Count == 0 ? "none" : string.Join(", ", gameAssemblies))}");
	}

	/// <summary>
	/// Lifts a bounded sample of the game's own methods and reports how many produced ISIL.
	/// </summary>
	/// <remarks>
	/// This is the measurement that separates "the lifter produced nothing" from "the lifter worked and
	/// something later went wrong", and it costs a couple of seconds instead of a whole run.
	/// </remarks>
	private static void SampleLifting(ApplicationAnalysisContext appContext)
	{
		int sampled = 0;
		int lifted = 0;
		int empty = 0;
		int tooLarge = 0;
		int threw = 0;
		string? firstFailure = null;

		foreach (AssemblyAnalysisContext assembly in appContext.Assemblies)
		{
			if (IsFrameworkAssembly(assembly.CleanAssemblyName))
			{
				continue;
			}

			foreach (TypeAnalysisContext type in assembly.Types)
			{
				foreach (MethodAnalysisContext method in type.Methods)
				{
					if (sampled >= SampleSize)
					{
						goto done;
					}

					// A method with no native code of its own is not evidence either way.
					if (method.UnderlyingPointer == 0)
					{
						continue;
					}

					sampled++;

					try
					{
						method.EnsureRawBytes();

						if (method.RawBytes.Length > MethodAnalysisContext.MaxMethodSizeBytes)
						{
							tooLarge++;
							continue;
						}

						method.Analyze();

						if (method.ConvertedIsil.Count > 0)
						{
							lifted++;
						}
						else
						{
							empty++;
						}
					}
					catch (Exception ex)
					{
						threw++;
						firstFailure ??= $"{method.FullName}: {ex.GetType().Name}: {ex.Message}";
					}
					finally
					{
						// The real pass re-analyses; holding a sample's worth of graphs serves nothing.
						method.ReleaseAnalysisData();
					}
				}
			}
		}

	done:
		if (sampled == 0)
		{
			Logger.Warning(LogCategory.Import,
				"Il2Cpp recovery: no methods with native code were found in the game's own assemblies, so there is " +
				"nothing for recovery to work on. Check that the loaded files include the game's script assemblies.");
			return;
		}

		Logger.Info(LogCategory.Import,
			$"Il2Cpp recovery: sampled {sampled} methods from the game's assemblies — {lifted} lifted to ISIL, " +
			$"{empty} produced none, {tooLarge} over the {MethodAnalysisContext.MaxMethodSizeBytes} byte analysis cap, {threw} threw.");

		if (firstFailure is not null)
		{
			Logger.Warning(LogCategory.Import, $"Il2Cpp recovery: first lifting failure was {firstFailure}");
		}

		if (lifted == 0)
		{
			Logger.Warning(LogCategory.Import,
				"Il2Cpp recovery: nothing in the sample lifted to ISIL, so the exported method bodies will be empty. " +
				"This is the lifting stage failing, not the export.");
		}
		else if (lifted < sampled / 2)
		{
			Logger.Warning(LogCategory.Import,
				$"Il2Cpp recovery: only {lifted} of {sampled} sampled methods lifted to ISIL, so expect many empty bodies.");
		}
	}

	/// <summary>
	/// Whether Cpp2IL stubs this assembly's bodies rather than recovering them. Mirrors the test inside
	/// its IL recovery output format, which is where the decision is actually made.
	/// </summary>
	public static bool IsFrameworkAssembly(string assemblyName)
		=> assemblyName.StartsWith("UnityEngine", StringComparison.Ordinal)
		|| assemblyName.StartsWith("Unity.", StringComparison.Ordinal)
		|| assemblyName.StartsWith("System", StringComparison.Ordinal)
		|| assemblyName.StartsWith("mscorlib", StringComparison.Ordinal)
		|| assemblyName.StartsWith("netstandard", StringComparison.Ordinal);

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
