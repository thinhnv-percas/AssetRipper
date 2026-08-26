using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class InvalidBranch : SimpleInstruction
{
	public string Message;

	public StackType ExpectedResultType = StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow | InstructionFlags.EndPointUnreachable;

	public override StackType ResultType => ExpectedResultType;

	public InvalidBranch()
		: base(OpCode.InvalidBranch)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.SideEffect | InstructionFlags.MayThrow | InstructionFlags.EndPointUnreachable;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitInvalidBranch(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitInvalidBranch(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitInvalidBranch(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		InvalidBranch invalidBranch = other as InvalidBranch;
		return invalidBranch != null;
	}

	public InvalidBranch(string message)
		: this()
	{
		Message = message;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (!string.IsNullOrEmpty(Message))
		{
			output.Write("(\"");
			output.Write(Message);
			output.Write("\")");
		}
	}
}
