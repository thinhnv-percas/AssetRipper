using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.IL.Transforms;

internal class ILInstructionMatchComparer : IEqualityComparer<ILInstruction>
{
	public static readonly ILInstructionMatchComparer Instance = new ILInstructionMatchComparer();

	public bool Equals(ILInstruction x, ILInstruction y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null)
		{
			return false;
		}
		return SemanticHelper.IsPure(x.Flags) && SemanticHelper.IsPure(y.Flags) && x.Match(y).Success;
	}

	public int GetHashCode(ILInstruction obj)
	{
		throw new NotSupportedException();
	}
}
