using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicLogicOperatorInstruction : DynamicInstruction
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ExpressionType _003COperation_003Ek__BackingField;

	public static readonly SlotInfo LeftSlot = new SlotInfo("Left", canInlineInto: true);

	private ILInstruction left;

	public static readonly SlotInfo RightSlot = new SlotInfo("Right");

	private ILInstruction right;

	public CSharpArgumentInfo LeftArgumentInfo { get; }

	public CSharpArgumentInfo RightArgumentInfo { get; }

	public ExpressionType Operation
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003COperation_003Ek__BackingField;
		}
	}

	public override StackType ResultType => StackType.O;

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow | InstructionFlags.ControlFlow;

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

	public DynamicLogicOperatorInstruction(CSharpBinderFlags binderFlags, ExpressionType operation, IType context, CSharpArgumentInfo leftArgumentInfo, ILInstruction left, CSharpArgumentInfo rightArgumentInfo, ILInstruction right)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector(OpCode.DynamicLogicOperatorInstruction, binderFlags, context);
		Operation = operation;
		LeftArgumentInfo = leftArgumentInfo;
		Left = left;
		RightArgumentInfo = rightArgumentInfo;
		Right = right;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		WriteILRange(output, options);
		output.Write(OpCode);
		WriteBinderFlags(output, options);
		output.Write(' ');
		output.Write(((object)Operation/*cast due to constrained. prefix*/).ToString());
		DynamicInstruction.WriteArgumentList(output, options, (Left, LeftArgumentInfo), (Right, RightArgumentInfo));
	}

	protected override InstructionFlags ComputeFlags()
	{
		return DirectFlags | Left.Flags | SemanticHelper.CombineBranches(Right.Flags, InstructionFlags.None);
	}

	public override CSharpArgumentInfo GetArgumentInfoOfChild(int index)
	{
		return index switch
		{
			0 => LeftArgumentInfo, 
			1 => RightArgumentInfo, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		};
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
		DynamicLogicOperatorInstruction dynamicLogicOperatorInstruction = (DynamicLogicOperatorInstruction)ShallowClone();
		dynamicLogicOperatorInstruction.Left = left.Clone();
		dynamicLogicOperatorInstruction.Right = right.Clone();
		return dynamicLogicOperatorInstruction;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicLogicOperatorInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicLogicOperatorInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicLogicOperatorInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicLogicOperatorInstruction dynamicLogicOperatorInstruction && left.PerformMatch(dynamicLogicOperatorInstruction.left, ref match) && right.PerformMatch(dynamicLogicOperatorInstruction.right, ref match);
	}
}
