using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdcF8 : SimpleInstruction
{
	public readonly double Value;

	public override StackType ResultType => StackType.F8;

	public LdcF8(double value)
		: base(OpCode.LdcF8)
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
		visitor.VisitLdcF8(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdcF8(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdcF8(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdcF8 ldcF && Value == ldcF.Value;
	}
}
