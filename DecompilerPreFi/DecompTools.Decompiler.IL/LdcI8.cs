using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdcI8 : SimpleInstruction
{
	public readonly long Value;

	public override StackType ResultType => StackType.I8;

	public LdcI8(long value)
		: base(OpCode.LdcI8)
	{
		Value = value;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		DisassemblerHelpers.WriteOperand(output, Value);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdcI8(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdcI8(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdcI8(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdcI8 ldcI && Value == ldcI.Value;
	}
}
