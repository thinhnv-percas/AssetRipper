using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdFtn : SimpleInstruction, IInstructionWithMethodOperand
{
	private readonly IMethod method;

	public IMethod Method => method;

	public override StackType ResultType => StackType.I;

	public LdFtn(IMethod method)
		: base(OpCode.LdFtn)
	{
		this.method = method;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		method.WriteTo(output);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdFtn(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdFtn(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdFtn(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdFtn ldFtn && method.Equals(ldFtn.method);
	}
}
