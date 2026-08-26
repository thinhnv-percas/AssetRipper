using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdsFlda : SimpleInstruction, IInstructionWithFieldOperand
{
	private readonly IField field;

	public override StackType ResultType => StackType.Ref;

	public IField Field => field;

	public LdsFlda(IField field)
		: base(OpCode.LdsFlda)
	{
		this.field = field;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		field.WriteTo(output);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdsFlda(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdsFlda(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdsFlda(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdsFlda ldsFlda && field.Equals(ldsFlda.field);
	}
}
