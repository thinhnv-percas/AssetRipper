using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class UnboxAny : UnaryInstruction
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

	public override StackType ResultType => type.GetStackType();

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	public UnboxAny(ILInstruction argument, IType type)
		: base(OpCode.UnboxAny, argument)
	{
		this.type = type;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.SideEffect | InstructionFlags.MayThrow;
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
		visitor.VisitUnboxAny(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitUnboxAny(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitUnboxAny(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is UnboxAny unboxAny && base.Argument.PerformMatch(unboxAny.Argument, ref match) && type.Equals(unboxAny.type);
	}
}
