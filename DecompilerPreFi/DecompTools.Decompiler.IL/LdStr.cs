using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdStr : SimpleInstruction
{
	public readonly string Value;

	public override StackType ResultType => StackType.O;

	public LdStr(string value)
		: base(OpCode.LdStr)
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
		visitor.VisitLdStr(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdStr(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdStr(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdStr ldStr && Value == ldStr.Value;
	}
}
