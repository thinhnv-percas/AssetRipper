using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class Box : UnaryInstruction
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

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	public Box(ILInstruction argument, IType type)
		: base(OpCode.Box, argument)
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
		visitor.VisitBox(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitBox(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitBox(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Box box && base.Argument.PerformMatch(box.Argument, ref match) && type.Equals(box.type);
	}
}
