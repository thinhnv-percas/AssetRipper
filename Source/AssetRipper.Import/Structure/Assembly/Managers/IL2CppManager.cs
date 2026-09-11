using AsmResolver.DotNet;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using AssetRipper.Import.Structure.Platforms;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.InstructionSets;
using Cpp2IL.Core.OutputFormats;
using Cpp2IL.Core.ProcessingLayers;
using LibCpp2IL;
using LibCpp2IL.MachO;
using Cpp2IlApi = Cpp2IL.Core.Cpp2IlApi;

namespace AssetRipper.Import.Structure.Assembly.Managers;

public sealed class IL2CppManager : BaseManager
{
	static IL2CppManager()
	{
		InstructionSetRegistry.RegisterInstructionSet<X86InstructionSet>(DefaultInstructionSets.X86_32);
		InstructionSetRegistry.RegisterInstructionSet<X86InstructionSet>(DefaultInstructionSets.X86_64);
		InstructionSetRegistry.RegisterInstructionSet<WasmInstructionSet>(DefaultInstructionSets.WASM);
		InstructionSetRegistry.RegisterInstructionSet<ArmV7InstructionSet>(DefaultInstructionSets.ARM_V7);

		// Which ARM64 implementation to use depends on the content level, and that is not known here:
		// the registry takes one set per architecture and refuses a second. See Arm64InstructionSetSelector.
		InstructionSetRegistry.RegisterInstructionSet<Arm64InstructionSetSelector>(DefaultInstructionSets.ARM_V8);

		LibCpp2IlBinaryRegistry.RegisterBuiltInBinarySupport();
	}

	public static List<Cpp2IlProcessingLayer> DefaultProcessingLayers { get; } =
	[
		new AttributeAnalysisProcessingLayer(),
		new MethodOverrideNameFixer(),
	];

	public static AsmResolverDllOutputFormatDefault DefaultOutputFormat { get; } = new();

	public static List<Cpp2IlProcessingLayer>? RecoveryProcessingLayers { get; set; }

	public static AsmResolverDllOutputFormat? RecoveryOutputFormat { get; set; }

	public static event Action? ClearStaticState;

	public string? GameAssemblyPath { get; private set; }
	public string? UnityPlayerPath { get; private set; }
	public string? GameDataPath { get; private set; }
	public string? MetaDataPath { get; private set; }
	public UnityVersion UnityVersion { get; private set; }
	/// <summary>
	/// For when analysis is reimplimented in Cpp2IL.
	/// </summary>
	private readonly ScriptContentLevel contentLevel;

	public IL2CppManager(Action<string> requestAssemblyCallback, ScriptContentLevel level) : base(requestAssemblyCallback)
	{
		contentLevel = level;
	}

	public override ScriptingBackend ScriptingBackend => ScriptingBackend.IL2Cpp;

	public override void Initialize(PlatformGameStructure gameStructure)
	{
		string? gameDataPath = gameStructure.GameDataPath;
		if (string.IsNullOrWhiteSpace(gameDataPath))
		{
			throw new ArgumentException($"{nameof(gameStructure.GameDataPath)} cannot be null or whitespace.", nameof(gameStructure));
		}

		GameDataPath = gameDataPath;
		GameAssemblyPath = gameStructure.Il2CppGameAssemblyPath;
		UnityPlayerPath = gameStructure.UnityPlayerPath;
		MetaDataPath = gameStructure.Il2CppMetaDataPath;

		UnityVersion = gameStructure.Version ?? Cpp2IlApi.DetermineUnityVersion(UnityPlayerPath, GameDataPath);

		if (UnityVersion == default)
		{
			throw new Exception("Could not determine the unity version");
		}
		else
		{
			Logger.Info(LogCategory.Import, $"During Il2Cpp initialization, found Unity version: {UnityVersion}");
		}

		Logger.SendStatusChange("loading_step_parse_il2cpp_metadata");

		ClearStaticState?.Invoke();

		ReportEncryptedGameAssembly(GameAssemblyPath);

		Cpp2IlApi.InitializeLibCpp2Il(GameAssemblyPath!, MetaDataPath!, UnityVersion, false);

		Logger.SendStatusChange("loading_step_generate_dummy_dll");

		List<Cpp2IlProcessingLayer> processingLayers = contentLevel == ScriptContentLevel.Level3
			? RecoveryProcessingLayers ?? DefaultProcessingLayers
			: DefaultProcessingLayers;

		foreach (Cpp2IlProcessingLayer cpp2IlProcessingLayer in processingLayers)
		{
			cpp2IlProcessingLayer.PreProcess(Cpp2IlApi.CurrentAppContext, processingLayers);
		}

		foreach (Cpp2IlProcessingLayer cpp2IlProcessingLayer in processingLayers)
		{
			cpp2IlProcessingLayer.Process(Cpp2IlApi.CurrentAppContext);
		}

		AsmResolverDllOutputFormat outputFormat = contentLevel == ScriptContentLevel.Level3
			? RecoveryOutputFormat ?? DefaultOutputFormat
			: DefaultOutputFormat;

		List<AssemblyDefinition> assemblies = outputFormat.BuildAssemblies(Cpp2IlApi.CurrentAppContext);

		foreach (AssemblyDefinition assembly in assemblies)
		{
			Add(assembly);
		}
	}

	/// <summary>
	/// Says so, before anything tries to read it, when the game assembly is an encrypted Mach-O.
	/// </summary>
	/// <remarks>
	/// An iOS build downloaded from the App Store is FairPlay encrypted over its whole <c>__TEXT</c>
	/// segment. That covers the generated method bodies, and it also covers <c>__cstring</c> — so the
	/// search for the code registration, which works by finding the string <c>mscorlib.dll</c> and
	/// walking back to the module that names it, finds nothing and initialisation fails outright with
	/// "No codegen modules found for mscorlib". That message reads like a corrupt or unsupported binary
	/// and the real cause is not visible anywhere, hence this line ahead of it. Decrypting is a device
	/// operation: a dump from a jailbroken device, or any build that did not go through the App Store,
	/// has <c>cryptid</c> zero and imports normally.
	/// </remarks>
	private static void ReportEncryptedGameAssembly(string? gameAssemblyPath)
	{
		if (string.IsNullOrEmpty(gameAssemblyPath) || MachOEncryptionInfo.ReadFromFile(gameAssemblyPath) is not { } encryption)
		{
			return;
		}

		Logger.Warning(LogCategory.Import,
			$"The game assembly '{Path.GetFileName(gameAssemblyPath)}' is an encrypted Mach-O (FairPlay cryptid {encryption.CryptId}) " +
			$"over file offsets 0x{encryption.CryptOffset:X}-0x{encryption.CryptOffset + encryption.CryptSize:X}. That range holds the " +
			"native code and the string constants, so no method body can be recovered from it and IL2CPP initialization may fail " +
			"outright. This is an App Store build; a decrypted dump of the same app imports normally.");
	}

	~IL2CppManager()
	{
		Dispose(false);
	}
}
