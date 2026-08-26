using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdcF4 : SimpleInstruction
{
	public readonly float Value;

	public override StackType ResultType => StackType.F4;

	public LdcF4(float value)
		: base(OpCode.LdcF4)
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
		visitor.VisitLdcF4(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdcF4(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdcF4(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdcF4 ldcF && Value == ldcF.Value;
	}
}
