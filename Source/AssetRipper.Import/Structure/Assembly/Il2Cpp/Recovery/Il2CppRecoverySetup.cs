using AssetRipper.Import.Configuration;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using AssetRipper.Import.Structure.Assembly.Managers;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.OutputFormats;
using Cpp2IL.Core.ProcessingLayers;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Installs IL2CPP source recovery into <see cref="IL2CppManager"/>. Takes effect only for
/// <see cref="ScriptContentLevel.Level3"/>; every other level keeps the current behaviour exactly.
/// </summary>
public static class Il2CppRecoverySetup
{
	/// <param name="structDbDirectory">Directory holding the runtime struct layout files. Null disables struct naming; everything else still works.</param>
	/// <param name="injectAddressAttributes">
	/// Adds <c>[Address]</c>, <c>[FieldOffset]</c> and <c>[Token]</c> to the exported scripts. This is the
	/// equivalent of the source tool's <c>// 0x18</c> field comments and <c>// Offset in libil2cpp.so:</c>
	/// method comments, and it is implemented by Cpp2IL already; AssetRipper simply does not run that layer today.
	/// </param>
	/// <param name="reconstructBodies">Attaches an approximate C# reconstruction to each method. Slow; see <see cref="NativeSourceOptions"/>.</param>
	/// <param name="nativeSourceOptions">Limits for the reconstruction, when it is enabled.</param>
	public static void Install(
		string? structDbDirectory,
		bool injectAddressAttributes = true,
		bool reconstructBodies = false,
		NativeSourceOptions? nativeSourceOptions = null)
	{
		List<Cpp2IlProcessingLayer> layers =
		[
			// Order matters. Attribute analysis creates the lists the later layers append to.
			new AttributeAnalysisProcessingLayer(),
			new MethodOverrideNameFixer(),
			new StructDbProcessingLayer(structDbDirectory),
		];

		if (injectAddressAttributes)
		{
			layers.Add(new AttributeInjectorProcessingLayer());
		}

		if (reconstructBodies)
		{
			layers.Add(new NativeSourceInjectionProcessingLayer(nativeSourceOptions ?? new NativeSourceOptions()));
		}

		IL2CppManager.RecoveryProcessingLayers = layers;

		// ISIL to CIL, so ILSpy produces real C# for the methods it can handle.
		IL2CppManager.RecoveryOutputFormat = new AsmResolverDllOutputFormatIlRecovery();
	}

	/// <summary>
	/// Installs or uninstalls recovery to match <paramref name="settings"/>.
	/// </summary>
	/// <remarks>
	/// Safe to call unconditionally before every import: it is what keeps the two static hooks on
	/// <see cref="IL2CppManager"/> in step with the settings the user last saved.
	/// </remarks>
	public static void Apply(ImportSettings settings)
	{
		if (settings.ScriptContentLevel is not ScriptContentLevel.Level3)
		{
			Uninstall();
			return;
		}

		Install(
			structDbDirectory: StructDbLocator.Find(settings.Il2CppStructDbPath),
			injectAddressAttributes: settings.EmitIl2CppOffsets,
			reconstructBodies: settings.ReconstructNativeBodies);
	}

	/// <summary>Restores stock behaviour.</summary>
	public static void Uninstall()
	{
		IL2CppManager.RecoveryProcessingLayers = null;
		IL2CppManager.RecoveryOutputFormat = null;
		Il2CppClassOffsetPatcher.Restore();
	}
}
