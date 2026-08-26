using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdMemberToken : SimpleInstruction
{
	private readonly IMember member;

	public IMember Member => member;

	public override StackType ResultType => StackType.O;

	public LdMemberToken(IMember member)
		: base(OpCode.LdMemberToken)
	{
		this.member = member;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		member.WriteTo(output);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdMemberToken(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdMemberToken(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdMemberToken(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdMemberToken ldMemberToken && member.Equals(ldMemberToken.member);
	}
}
