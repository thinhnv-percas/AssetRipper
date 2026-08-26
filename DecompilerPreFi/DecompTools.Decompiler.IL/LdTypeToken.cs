using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdTypeToken : SimpleInstruction
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

	public LdTypeToken(IType type)
		: base(OpCode.LdTypeToken)
	{
		this.type = type;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		type.WriteTo(output);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdTypeToken(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdTypeToken(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdTypeToken(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdTypeToken ldTypeToken && type.Equals(ldTypeToken.type);
	}
}
