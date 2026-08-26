using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LocAllocSpan : UnaryInstruction
{
	private IType type;

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

	public override StackType ResultType => StackType.O;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow;

	public LocAllocSpan(ILInstruction argument, IType type)
		: base(OpCode.LocAllocSpan, argument)
	{
		this.type = type;
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
		type.WriteTo(output);
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLocAllocSpan(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLocAllocSpan(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLocAllocSpan(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LocAllocSpan locAllocSpan && base.Argument.PerformMatch(locAllocSpan.Argument, ref match) && type.Equals(locAllocSpan.type);
	}
}
