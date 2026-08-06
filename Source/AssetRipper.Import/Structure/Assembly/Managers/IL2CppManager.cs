using AsmResolver.DotNet;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Recovery;
using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;
using AssetRipper.Import.Structure.Platforms;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.InstructionSets;
using Cpp2IL.Core.OutputFormats;
using Cpp2IL.Core.ProcessingLayers;
using LibCpp2IL;
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
		bool useNewArm64 = false;
		if (useNewArm64)
		{
			InstructionSetRegistry.RegisterInstructionSet<NewArmV8InstructionSet>(DefaultInstructionSets.ARM_V8);
		}
		else
		{
			InstructionSetRegistry.RegisterInstructionSet<Arm64InstructionSet>(DefaultInstructionSets.ARM_V8);
		}

		LibCpp2IlBinaryRegistry.RegisterBuiltInBinarySupport();
	}

	public static List<Cpp2IlProcessingLayer> DefaultProcessingLayers { get; } =
	[
		new AttributeAnalysisProcessingLayer(),
		new MethodOverrideNameFixer(),
	];

	public static AsmResolverDllOutputFormatDefault DefaultOutputFormat { get; } = new();

	/// <summary>
	/// The processing layers used for <see cref="ScriptContentLevel.Level3"/>.
	/// </summary>
	public static List<Cpp2IlProcessingLayer>? RecoveryProcessingLayers { get; set; } =
	[
		new AttributeAnalysisProcessingLayer(),
		new MethodOverrideNameFixer(),
	];

	/// <summary>
	/// The output format used for <see cref="ScriptContentLevel.Level3"/>.
	/// </summary>
	/// <remarks>
	/// Unlike <see cref="DefaultOutputFormat"/>, this attempts to lift the native machine code of each
	/// method back into CIL. It only succeeds for a fraction of methods, so
	/// <see cref="Il2CppRecoveryReport"/> records the outcome of each attempt.
	/// </remarks>
	public static AsmResolverDllOutputFormat? RecoveryOutputFormat { get; set; } = new InstrumentedIlRecoveryOutputFormat();

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

		Cpp2IlApi.InitializeLibCpp2Il(GameAssemblyPath!, MetaDataPath!, UnityVersion, false);

		Logger.SendStatusChange("loading_step_generate_dummy_dll");

		// Level 4 is level 3 plus native decompilation, so both use the IL recovery path.
		bool recovering = contentLevel is ScriptContentLevel.Level3 or ScriptContentLevel.Level4;

		List<Cpp2IlProcessingLayer> processingLayers = recovering
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

		AsmResolverDllOutputFormat outputFormat = recovering
			? RecoveryOutputFormat ?? DefaultOutputFormat
			: DefaultOutputFormat;

		if (recovering)
		{
			Il2CppRecoveryReport.Clear();
		}

		List<AssemblyDefinition> assemblies = outputFormat.BuildAssemblies(Cpp2IlApi.CurrentAppContext);

		if (recovering)
		{
			ReportRecoveryResults();
		}

		if (contentLevel == ScriptContentLevel.Level4)
		{
			RunGhidraDecompilation();
		}

		foreach (AssemblyDefinition assembly in assemblies)
		{
			Add(assembly);
		}
	}

	private void RunGhidraDecompilation()
	{
		if (string.IsNullOrEmpty(GameAssemblyPath))
		{
			Logger.Warning(LogCategory.Import, "Cannot run Ghidra because the game assembly path is unknown.");
			return;
		}

		string outputDirectory = Path.Join(AppContext.BaseDirectory, $"GhidraDecompilation_{DateTime.Now:yyyyMMdd_HHmmss}");
		Logger.SendStatusChange("loading_step_decompile_with_ghidra");
		GhidraDecompiler.TryDecompile(Cpp2IlApi.CurrentAppContext, GameAssemblyPath, outputDirectory);
	}

	private static void ReportRecoveryResults()
	{
		if (Il2CppRecoveryReport.Count == 0)
		{
			return;
		}

		Il2CppRecoveryReport.LogSummary();

		string? reportPath = Il2CppRecoveryReport.TryWriteCsv(AppContext.BaseDirectory);
		if (reportPath is not null)
		{
			Logger.Info(LogCategory.Import, $"Il2Cpp method recovery report written to {reportPath}");
		}
	}

	~IL2CppManager()
	{
		Dispose(false);
	}
}
