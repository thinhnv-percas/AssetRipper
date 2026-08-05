using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;

namespace AssetRipper.Import.Structure.Assembly.Recovery;

/// <summary>
/// Determines what happened to a method body after Cpp2IL attempted to recover it.
/// </summary>
/// <remarks>
/// Cpp2IL swallows its own recovery failures and releases its analysis data before returning, so the
/// outcome has to be read back off the generated body rather than from the analysis context.
/// </remarks>
public static class MethodBodyClassifier
{
	public static (MethodRecoveryOutcome Outcome, int InstructionCount, string? FailureMessage) Classify(string assembly, MethodDefinition methodDefinition)
	{
		CilMethodBody? body = methodDefinition.CilMethodBody;
		if (body is null)
		{
			return (MethodRecoveryOutcome.NoBody, 0, null);
		}

		CilInstructionCollection instructions = body.Instructions;

		if (IsExcludedFromAnalysis(assembly))
		{
			return (MethodRecoveryOutcome.Excluded, instructions.Count, null);
		}

		if (TryGetFailureMessage(instructions, out string? message))
		{
			return (MethodRecoveryOutcome.Failed, instructions.Count, message);
		}

		return IsMinimalImplementation(instructions)
			? (MethodRecoveryOutcome.Minimal, instructions.Count, null)
			: (MethodRecoveryOutcome.Recovered, instructions.Count, null);
	}

	/// <summary>
	/// Mirrors the assembly exclusion that Cpp2IL applies for performance.
	/// </summary>
	public static bool IsExcludedFromAnalysis(string assembly)
	{
		return assembly.StartsWith("UnityEngine.", StringComparison.Ordinal)
			|| assembly.StartsWith("Unity.", StringComparison.Ordinal)
			|| assembly.StartsWith("System.", StringComparison.Ordinal)
			|| assembly == "System"
			|| assembly.StartsWith("mscorlib", StringComparison.Ordinal);
	}

	/// <summary>
	/// Detects the <c>throw new Exception(message)</c> body that Cpp2IL emits when recovery fails.
	/// </summary>
	public static bool TryGetFailureMessage(CilInstructionCollection instructions, out string? message)
	{
		if (instructions.Count == 3
			&& instructions[0].OpCode.Code is CilCode.Ldstr
			&& instructions[1].OpCode.Code is CilCode.Newobj
			&& instructions[2].OpCode.Code is CilCode.Throw)
		{
			message = instructions[0].Operand as string;
			return true;
		}

		message = null;
		return false;
	}

	/// <summary>
	/// Determines whether a body only loads a default value and returns, which is what Cpp2IL falls
	/// back to when no instructions could be lifted.
	/// </summary>
	/// <remarks>
	/// A genuinely recovered method that does nothing but return a constant is indistinguishable from
	/// this fallback. Such methods are rare enough not to distort aggregate statistics.
	/// </remarks>
	public static bool IsMinimalImplementation(CilInstructionCollection instructions)
	{
		foreach (CilInstruction instruction in instructions)
		{
			switch (instruction.OpCode.Code)
			{
				case CilCode.Nop:
				case CilCode.Ret:
				case CilCode.Ldnull:
				case CilCode.Ldc_I4:
				case CilCode.Ldc_I4_S:
				case CilCode.Ldc_I4_M1:
				case CilCode.Ldc_I4_0:
				case CilCode.Ldc_I4_1:
				case CilCode.Ldc_I4_2:
				case CilCode.Ldc_I4_3:
				case CilCode.Ldc_I4_4:
				case CilCode.Ldc_I4_5:
				case CilCode.Ldc_I4_6:
				case CilCode.Ldc_I4_7:
				case CilCode.Ldc_I4_8:
				case CilCode.Ldc_I8:
				case CilCode.Ldc_R4:
				case CilCode.Ldc_R8:
				case CilCode.Ldloc:
				case CilCode.Ldloc_S:
				case CilCode.Ldloc_0:
				case CilCode.Ldloc_1:
				case CilCode.Ldloc_2:
				case CilCode.Ldloc_3:
				case CilCode.Ldloca:
				case CilCode.Ldloca_S:
				case CilCode.Initobj:
					continue;
				default:
					return false;
			}
		}

		return true;
	}
}
