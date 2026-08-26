using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

internal static class SemanticHelper
{
	internal static InstructionFlags CombineBranches(InstructionFlags trueFlags, InstructionFlags falseFlags)
	{
		return (trueFlags & falseFlags) | ((trueFlags | falseFlags) & ~InstructionFlags.EndPointUnreachable);
	}

	internal static bool IsPure(InstructionFlags inst)
	{
		return (inst & ~(InstructionFlags.MayReadLocals | InstructionFlags.ControlFlow)) == 0;
	}

	internal static bool MayReorder(ILInstruction inst1, ILInstruction inst2)
	{
		if (!IsPure(inst1.Flags) && !IsPure(inst2.Flags))
		{
			return false;
		}
		if (Inst2MightWriteToVariableReadByInst1(inst1, inst2))
		{
			return false;
		}
		if (Inst2MightWriteToVariableReadByInst1(inst2, inst1))
		{
			return false;
		}
		return true;
	}

	private static bool Inst2MightWriteToVariableReadByInst1(ILInstruction inst1, ILInstruction inst2)
	{
		if (!inst1.HasFlag(InstructionFlags.MayReadLocals))
		{
			return false;
		}
		HashSet<ILVariable> val = Enumerable.Select<LdLoc, ILVariable>(Enumerable.OfType<LdLoc>((IEnumerable)inst1.Descendants), (Func<LdLoc, ILVariable>)((LdLoc load) => load.Variable)).ToHashSet();
		if (inst2.HasFlag(InstructionFlags.SideEffect) && Enumerable.Any<ILVariable>((IEnumerable<ILVariable>)val, (Func<ILVariable, bool>)((ILVariable v) => v.AddressCount > 0)))
		{
			return true;
		}
		foreach (ILInstruction descendant in inst2.Descendants)
		{
			if (descendant.HasDirectFlag(InstructionFlags.MayWriteLocals))
			{
				ILVariable variable = ((IInstructionWithVariableOperand)descendant).Variable;
				if (val.Contains(variable))
				{
					return true;
				}
			}
		}
		return false;
	}
}
