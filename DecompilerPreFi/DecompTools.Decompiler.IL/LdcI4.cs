using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdcI4 : SimpleInstruction
{
	public readonly int Value;

	public override StackType ResultType => StackType.I4;

	public LdcI4(int value)
		: base(OpCode.LdcI4)
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
		visitor.VisitLdcI4(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdcI4(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdcI4(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdcI4 ldcI && Value == ldcI.Value;
	}
}
