using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.OutputFormats;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Cpp2IL's IL recovery output format, with the per-run counters made readable so the import can say
/// how far recovery actually got.
/// </summary>
/// <remarks>
/// Empty method bodies have several causes that look identical in the output — an architecture with no
/// ISIL lifter, a framework assembly that is skipped by design, a method too large for analysis, a
/// conversion that failed — and none of them is visible from the exported scripts. These counts, with
/// the warning from <see cref="Il2CppRecoveryDiagnosticsProcessingLayer"/>, separate them.
/// </remarks>
public sealed class Il2CppIlRecoveryOutputFormat : AsmResolverDllOutputFormatIlRecovery
{
	private int failedMethodCount;

	/// <summary>Methods recovery was attempted on. Framework assemblies are skipped and not counted.</summary>
	public int AttemptedMethodCount => TotalMethodCount;

	/// <summary>
	/// Of those, the ones that got through without an exception. A method whose native code produced no
	/// ISIL is counted here too, and keeps an empty body, so this is not a count of recovered bodies.
	/// </summary>
	public int CompletedMethodCount => SuccessfulMethodCount;

	/// <summary>Methods whose conversion threw, and whose body is now a throw carrying the reason.</summary>
	public int FailedMethodCount => Volatile.Read(ref failedMethodCount);

	protected override void FillMethodBody(MethodDefinition methodDefinition, MethodAnalysisContext methodContext)
	{
		base.FillMethodBody(methodDefinition, methodContext);

		if (IsFailureBody(methodDefinition.CilMethodBody))
		{
			Interlocked.Increment(ref failedMethodCount);
		}
	}

	/// <summary>
	/// Recognises the body the base class emits when conversion throws: the message, an exception, a throw.
	/// </summary>
	private static bool IsFailureBody(CilMethodBody? body)
	{
		if (body is null || body.Instructions.Count != 3)
		{
			return false;
		}

		return body.Instructions[0].OpCode.Code == CilCode.Ldstr
			&& body.Instructions[1].OpCode.Code == CilCode.Newobj
			&& body.Instructions[2].OpCode.Code == CilCode.Throw;
	}
}
