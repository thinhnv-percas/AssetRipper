using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class InvalidExpression : SimpleInstruction
{
	public string Message;

	public StackType ExpectedResultType = StackType.Unknown;

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	public override StackType ResultType => ExpectedResultType;

	public InvalidExpression()
		: base(OpCode.InvalidExpression)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.SideEffect | InstructionFlags.MayThrow;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitInvalidExpression(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitInvalidExpression(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitInvalidExpression(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		InvalidExpression invalidExpression = other as InvalidExpression;
		return invalidExpression != null;
	}

	public InvalidExpression(string message)
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
