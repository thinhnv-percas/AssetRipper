using System;

namespace DecompTools.Decompiler.IL.Patterns;

public abstract class PatternInstruction : ILInstruction
{
	public override InstructionFlags DirectFlags
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override StackType ResultType => StackType.Unknown;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		throw new NotSupportedException();
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		throw new NotSupportedException();
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		throw new NotSupportedException();
	}

	protected override InstructionFlags ComputeFlags()
	{
		throw new NotSupportedException();
	}

	protected PatternInstruction(OpCode opCode)
		: base(opCode)
	{
	}
}
