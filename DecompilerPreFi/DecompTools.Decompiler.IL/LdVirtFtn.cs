using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdVirtFtn : UnaryInstruction, IInstructionWithMethodOperand
{
	private readonly IMethod method;

	public IMethod Method => method;

	public override StackType ResultType => StackType.I;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow;

	public LdVirtFtn(ILInstruction argument, IMethod method)
		: base(OpCode.LdVirtFtn, argument)
	{
		this.method = method;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		method.WriteTo(output);
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdVirtFtn(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdVirtFtn(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdVirtFtn(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdVirtFtn ldVirtFtn && base.Argument.PerformMatch(ldVirtFtn.Argument, ref match) && method.Equals(ldVirtFtn.method);
	}
}
