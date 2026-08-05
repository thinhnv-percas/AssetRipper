using AsmResolver.DotNet;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.OutputFormats;

namespace AssetRipper.Import.Structure.Assembly.Recovery;

/// <summary>
/// Wraps Cpp2IL's IL recovery output format to record the outcome for each method.
/// </summary>
public sealed class InstrumentedIlRecoveryOutputFormat : AsmResolverDllOutputFormatIlRecovery
{
	protected override void FillMethodBody(MethodDefinition methodDefinition, MethodAnalysisContext methodContext)
	{
		base.FillMethodBody(methodDefinition, methodContext);

		if (!Il2CppRecoveryReport.Enabled)
		{
			return;
		}

		string assembly = methodDefinition.DeclaringModule?.Name?.ToString() ?? "";
		(MethodRecoveryOutcome outcome, int instructionCount, string? failureMessage) = MethodBodyClassifier.Classify(assembly, methodDefinition);
		Il2CppRecoveryReport.Add(new MethodRecoveryRecord(assembly, methodContext.FullName, outcome, instructionCount, failureMessage));
	}
}
