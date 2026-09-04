using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.Model;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Model.CustomAttributes;
using System.Reflection;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Attaches an approximate C# reconstruction of each method's native body as a custom attribute, so the
/// text survives into ILSpy's output.
/// </summary>
/// <remarks>
/// Must run after <c>AttributeAnalysisProcessingLayer</c>: methods whose custom attribute list has not
/// been created yet are skipped.
/// </remarks>
public sealed class NativeSourceInjectionProcessingLayer(NativeSourceOptions options) : Cpp2IlProcessingLayer
{
	private const string AttributeNamespace = "AssetRipperInjected";
	private const string AttributeName = "NativeSourceAttribute";
	private const string BodyFieldName = "Body";

	public override string Name => "Native Source Injector";

	public override string Id => "nativesource";

	public override void Process(ApplicationAnalysisContext appContext, Action<int, int>? progressCallback = null)
	{
		RuntimeStructDb? db = StructDbProcessingLayer.Get(appContext);
		RuntimeStructAccessAnnotator? annotator = db is null ? null : new RuntimeStructAccessAnnotator(db);

		MultiAssemblyInjectedType attributeType = appContext.InjectTypeIntoAllAssemblies(
			AttributeNamespace, AttributeName, appContext.SystemTypes.SystemAttributeType);

		Dictionary<AssemblyAnalysisContext, InjectedFieldAnalysisContext> bodyFields =
			attributeType.InjectFieldToAllAssemblies(BodyFieldName, appContext.SystemTypes.SystemStringType, FieldAttributes.Public);

		Dictionary<AssemblyAnalysisContext, InjectedMethodAnalysisContext> constructors = attributeType.InjectConstructor(false);

		long remainingBudget = options.TotalCharacterBudget;
		int injected = 0;
		int done = 0;
		int total = appContext.Assemblies.Count;

		foreach (AssemblyAnalysisContext assembly in appContext.Assemblies)
		{
			progressCallback?.Invoke(done++, total);

			if (!options.ShouldProcessAssembly(assembly.CleanAssemblyName))
			{
				continue;
			}

			InjectedFieldAnalysisContext bodyField = bodyFields[assembly];
			InjectedMethodAnalysisContext constructor = constructors[assembly];

			foreach (TypeAnalysisContext type in assembly.Types)
			{
				foreach (MethodAnalysisContext method in type.Methods)
				{
					if (remainingBudget <= 0)
					{
						goto budgetExhausted;
					}

					string body = TryReconstruct(method, annotator);
					if (body.Length == 0)
					{
						continue;
					}

					if (body.Length > options.MaximumCharactersPerMethod)
					{
						body = body[..options.MaximumCharactersPerMethod] + "\n// ... truncated";
					}

					AnalyzedCustomAttribute attribute = new(constructor);
					attribute.Fields.Add(new(bodyField,
						new CustomAttributePrimitiveParameter(body, attribute, CustomAttributeParameterKind.Field, 0)));
					method.CustomAttributes!.Add(attribute);

					remainingBudget -= body.Length;
					injected++;
				}
			}
		}

	budgetExhausted:
		if (remainingBudget <= 0)
		{
			Logger.Warning(LogCategory.Import,
				$"Native source injection stopped after {injected} methods: the {options.TotalCharacterBudget} character budget was exhausted. " +
				"Raise NativeSourceOptions.TotalCharacterBudget to cover more methods.");
		}
		else
		{
			Logger.Info(LogCategory.Import, $"Native source injection: reconstructed {injected} method bodies.");
		}

		progressCallback?.Invoke(total, total);
	}

	private string TryReconstruct(MethodAnalysisContext method, RuntimeStructAccessAnnotator? annotator)
	{
		// No attribute list means attribute analysis has not run for this method, and there is nowhere to put the text.
		if (method.CustomAttributes is null || method.UnderlyingPointer == 0)
		{
			return "";
		}

		// RawBytes stays BinarySlice.Empty until this is called, so the size cap below would otherwise
		// never reject anything and the largest methods would be analysed in full.
		method.EnsureRawBytes();

		if (method.RawBytes.Length == 0 || method.RawBytes.Length > options.MaximumMethodSizeBytes)
		{
			return "";
		}

		try
		{
			method.Analyze();
			return new PseudoCSharpWriter(annotator).Write(method, options.MaximumStatements);
		}
		catch (Exception ex)
		{
			// One unanalysable method must not stop the run; note it on the method and move on.
			method.AddWarning($"Native source reconstruction failed: {ex.GetType().Name}: {ex.Message}");
			return "";
		}
		finally
		{
			method.ReleaseAnalysisData();
		}
	}
}

/// <summary>Limits for <see cref="NativeSourceInjectionProcessingLayer"/>.</summary>
public sealed record NativeSourceOptions
{
	/// <summary>Methods larger than this many bytes of machine code are skipped.</summary>
	public int MaximumMethodSizeBytes { get; init; } = 8 * 1024;

	/// <summary>Statements written per method before the rest is summarised.</summary>
	public int MaximumStatements { get; init; } = 400;

	/// <summary>Characters kept per method.</summary>
	public int MaximumCharactersPerMethod { get; init; } = 8 * 1024;

	/// <summary>
	/// Total characters across all methods. The <c>#US</c> heap is addressed by 24-bit offsets, so an
	/// unbounded dump produces an assembly that cannot be written; the default leaves ample headroom.
	/// </summary>
	public long TotalCharacterBudget { get; init; } = 8L * 1024 * 1024;

	/// <summary>Assemblies to reconstruct. Framework assemblies are excluded by default: their bodies are not what anyone is reading for.</summary>
	public Func<string, bool> ShouldProcessAssembly { get; init; } = static name =>
		!name.StartsWith("UnityEngine", StringComparison.Ordinal)
		&& !name.StartsWith("Unity.", StringComparison.Ordinal)
		&& !name.StartsWith("System", StringComparison.Ordinal)
		&& !name.StartsWith("mscorlib", StringComparison.Ordinal)
		&& !name.StartsWith("netstandard", StringComparison.Ordinal);
}
