using LibCpp2IL;
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

		ReportEncryptedRegions(appContext);
		ReportAssemblies(appContext);
		ReportFieldLayoutSelfCheck(appContext);

		if (!CanProduceMethodBodies(instructionSet))
		{
			Logger.Warning(LogCategory.Import,
				$"Il2Cpp recovery: {instructionSetName} does not lift native code to ISIL, so method bodies cannot be " +
				"recovered from this binary and every method will be exported empty. Class layouts, method signatures, " +
				"field offsets and method addresses are unaffected. Bodies can be recovered from x86, x86-64, ARM64 and " +
				"ARMv7 binaries, but not from WebAssembly.");

			progressCallback?.Invoke(1, 1);
			return;
		}

		SampleLifting(appContext);

		progressCallback?.Invoke(1, 1);
	}

	/// <summary>
	/// Says, per registration table, which of them lie in a region that is ciphertext on disk.
	/// </summary>
	/// <remarks>
	/// LibCpp2IL reports this too, but every Cpp2IL warning is mapped to <see cref="LogType.Verbose"/>
	/// on the way into this log, so a reader never sees it. It has to be said here to be said at all.
	/// The distinction the report exists to draw: a readable table whose targets are encrypted is not
	/// a misidentified registration - the pointers are right and the structs they name cannot be read,
	/// which is why an App Store build yields every declaration and no type size or method body.
	/// Measured on Jelly Blast, whose <c>typeDefinitionsSizes</c> table is 8702 correct pointers into
	/// a region of entropy 7.999 out of 8. See <c>reports/IOS_TYPE_DEFINITIONS_SIZES_ANALYSIS.md</c>.
	/// </remarks>
	private static void ReportEncryptedRegions(ApplicationAnalysisContext appContext)
	{
		Il2CppBinary binary = appContext.Binary;

		ulong[] sizePointers = binary.TypeDefinitionSizePointers;
		int encryptedSizes = 0;
		for (int i = 0; i < sizePointers.Length; i++)
		{
			if (sizePointers[i] != 0 && binary.IsVirtualAddressEncrypted(sizePointers[i]))
				encryptedSizes++;
		}

		(int encryptedFieldOffsets, int totalFieldOffsets) = binary.CountEncryptedFieldOffsetTables();

		if (encryptedFieldOffsets > 0)
		{
			Logger.Warning(LogCategory.Import,
				$"Il2Cpp recovery: {encryptedFieldOffsets} of {totalFieldOffsets} field offset tables point into a "
				+ "region that is encrypted on disk, so those offsets are reported as unknown rather than read as "
				+ "ciphertext - which would lay every field of the type out at a random offset with nothing "
				+ "downstream able to tell. The field layout self-check therefore has nothing to measure on this "
				+ "input; that is an unreadable input, not a recovery defect.");
		}

		if (encryptedSizes == 0)
			return;

		Logger.Warning(LogCategory.Import,
			$"Il2Cpp recovery: {encryptedSizes} of {sizePointers.Length} type definition sizes point into a region "
			+ "that is encrypted on disk, so those sizes are not readable and no class layout is written for them. "
			+ "The pointer table itself is correct - this is an encrypted input, not a misread binary. An App Store "
			+ "(FairPlay) iOS build encrypts the whole of __TEXT, which is where il2cpp puts the size and field-offset "
			+ "structs, while leaving the tables that address them in __DATA. Declarations, signatures and metadata "
			+ "are recovered normally; type sizes and method bodies cannot be. Supply a build that is not "
			+ "store-encrypted to recover those.");
	}



	/// <summary>
	/// Names the assemblies recovery will attempt, because a reader looking at the wrong one sees empty
	/// bodies no matter how well recovery went: Cpp2IL stubs the framework assemblies by design.
	/// </summary>
	/// <summary>
	/// How well the computed field layout reproduces the offsets metadata carries.
	/// </summary>
	/// <remarks>
	/// The layout is computed only for generic definitions, whose metadata offsets are all zero, so
	/// there is nothing to check it against where it is used. Every non-generic type carries the real
	/// offsets and the same walk has to reproduce them, which makes this the one exact measurement of
	/// it available. Read it before changing that walk: an off-by-a-field layout does not fail, it
	/// names the wrong field.
	/// </remarks>
	private static void ReportFieldLayoutSelfCheck(ApplicationAnalysisContext appContext)
	{
		(int reproduced, int mismatched, int incomplete) = Cpp2IL.Core.Analysis.GenericInstanceFieldLayout.SelfCheck(appContext);
		int total = reproduced + mismatched + incomplete;

		if (total == 0)
		{
			return;
		}

		Logger.Info(LogCategory.Import,
			$"Il2Cpp field layout self-check: of {total} non-generic types with measured offsets, " +
			$"{reproduced} reproduced exactly, {incomplete} laid out too few fields, {mismatched} disagreed.");
	}

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

		// These two return an empty instruction list for every method. WebAssembly has no other
		// implementation to switch to; ARM64 does, which is what the selector is for. ARMv7 lifts now,
		// see Source/External/Cpp2IL.Core/InstructionSets/ArmV7InstructionSet.cs.
		WasmInstructionSet or Arm64InstructionSet => false,

		_ => true,
	};
}
