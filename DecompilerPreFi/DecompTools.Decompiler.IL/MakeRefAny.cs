using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class MakeRefAny : UnaryInstruction
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

	public MakeRefAny(ILInstruction argument, IType type)
		: base(OpCode.MakeRefAny, argument)
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
		visitor.VisitMakeRefAny(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitMakeRefAny(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitMakeRefAny(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is MakeRefAny makeRefAny && base.Argument.PerformMatch(makeRefAny.Argument, ref match) && type.Equals(makeRefAny.type);
	}
}
