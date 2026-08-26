using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class IsInst : UnaryInstruction
{
	private IType type;

	public IType Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
			InvalidateFlags();
		}
	}

	public override StackType ResultType => StackType.O;

	public IsInst(ILInstruction argument, IType type)
		: base(OpCode.IsInst, argument)
	{
		this.type = type;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		type.WriteTo(output);
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitIsInst(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitIsInst(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitIsInst(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is IsInst isInst && base.Argument.PerformMatch(isInst.Argument, ref match) && type.Equals(isInst.type);
	}
}
