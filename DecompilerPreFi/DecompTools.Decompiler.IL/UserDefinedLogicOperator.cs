using System;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class UserDefinedLogicOperator : ILInstruction, IInstructionWithMethodOperand
{
	private readonly IMethod method;

	public static readonly SlotInfo LeftSlot = new SlotInfo("Left", canInlineInto: true);

	private ILInstruction left;

	public static readonly SlotInfo RightSlot = new SlotInfo("Right");

	private ILInstruction right;

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow | InstructionFlags.ControlFlow;

	public IMethod Method => method;

	public override StackType ResultType => StackType.O;

	public ILInstruction Left
	{
		get
		{
			return left;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref left, value, 0);
		}
	}

	public ILInstruction Right
	{
		get
		{
			return right;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref right, value, 1);
		}
	}

	protected override InstructionFlags ComputeFlags()
	{
		return DirectFlags | left.Flags | SemanticHelper.CombineBranches(InstructionFlags.None, right.Flags);
	}

	public UserDefinedLogicOperator(IMethod method, ILInstruction left, ILInstruction right)
		: base(OpCode.UserDefinedLogicOperator)
	{
		this.method = method;
		Left = left;
		Right = right;
	}

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => left, 
			1 => right, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Left = value;
			break;
		case 1:
			Right = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => LeftSlot, 
			1 => RightSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		UserDefinedLogicOperator userDefinedLogicOperator = (UserDefinedLogicOperator)ShallowClone();
		userDefinedLogicOperator.Left = left.Clone();
		userDefinedLogicOperator.Right = right.Clone();
		return userDefinedLogicOperator;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		method.WriteTo(output);
		output.Write('(');
		left.WriteTo(output, options);
		output.Write(", ");
		right.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitUserDefinedLogicOperator(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitUserDefinedLogicOperator(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitUserDefinedLogicOperator(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is UserDefinedLogicOperator userDefinedLogicOperator && method.Equals(userDefinedLogicOperator.method) && left.PerformMatch(userDefinedLogicOperator.left, ref match) && right.PerformMatch(userDefinedLogicOperator.right, ref match);
	}
}
