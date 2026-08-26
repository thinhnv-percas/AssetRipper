using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Nop : SimpleInstruction
{
	public string Comment;

	public NopKind Kind;

	public override StackType ResultType => StackType.Void;

	public Nop()
		: base(OpCode.Nop)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNop(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNop(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNop(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		Nop nop = other as Nop;
		return nop != null;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (Kind != NopKind.Normal)
		{
			output.Write("." + Kind.ToString().ToLowerInvariant());
		}
		if (!string.IsNullOrEmpty(Comment))
		{
			output.Write(" // " + Comment);
		}
	}
}
