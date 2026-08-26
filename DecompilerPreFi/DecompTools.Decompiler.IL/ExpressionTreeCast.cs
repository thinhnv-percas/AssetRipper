using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class ExpressionTreeCast : UnaryInstruction
{
	private IType type;

	public bool IsChecked { get; set; }

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

	public override StackType ResultType => type.GetStackType();

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow;

	public ExpressionTreeCast(IType type, ILInstruction argument, bool isChecked)
		: base(OpCode.ExpressionTreeCast, argument)
	{
		Type = type;
		IsChecked = isChecked;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (IsChecked)
		{
			output.Write(".checked");
		}
		output.Write(' ');
		type.WriteTo(output);
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitExpressionTreeCast(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitExpressionTreeCast(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitExpressionTreeCast(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is ExpressionTreeCast expressionTreeCast && base.Argument.PerformMatch(expressionTreeCast.Argument, ref match) && type.Equals(expressionTreeCast.type) && IsChecked == expressionTreeCast.IsChecked;
	}
}
