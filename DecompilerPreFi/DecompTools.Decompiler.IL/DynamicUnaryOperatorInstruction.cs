using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicUnaryOperatorInstruction : DynamicInstruction
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ExpressionType _003COperation_003Ek__BackingField;

	public static readonly SlotInfo OperandSlot = new SlotInfo("Operand", canInlineInto: true);

	private ILInstruction operand;

	public CSharpArgumentInfo OperandArgumentInfo { get; }

	public ExpressionType Operation
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003COperation_003Ek__BackingField;
		}
	}

	public override StackType ResultType
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			ExpressionType operation = Operation;
			if ((int)operation - 83 <= 1)
			{
				return StackType.I4;
			}
			return StackType.O;
		}
	}

	public ILInstruction Operand
	{
		get
		{
			return operand;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref operand, value, 0);
		}
	}

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public DynamicUnaryOperatorInstruction(CSharpBinderFlags binderFlags, ExpressionType operation, IType context, CSharpArgumentInfo operandArgumentInfo, ILInstruction operand)
		: base(OpCode.DynamicUnaryOperatorInstruction, binderFlags, context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_003COperation_003Ek__BackingField = operation;
		OperandArgumentInfo = operandArgumentInfo;
		Operand = operand;
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
		DynamicInstruction.WriteArgumentList(output, options, (Operand, OperandArgumentInfo));
	}

	public override CSharpArgumentInfo GetArgumentInfoOfChild(int index)
	{
		if (index == 0)
		{
			return OperandArgumentInfo;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return operand;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Operand = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return OperandSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		DynamicUnaryOperatorInstruction dynamicUnaryOperatorInstruction = (DynamicUnaryOperatorInstruction)ShallowClone();
		dynamicUnaryOperatorInstruction.Operand = operand.Clone();
		return dynamicUnaryOperatorInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | operand.Flags;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicUnaryOperatorInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicUnaryOperatorInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicUnaryOperatorInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicUnaryOperatorInstruction dynamicUnaryOperatorInstruction && operand.PerformMatch(dynamicUnaryOperatorInstruction.operand, ref match);
	}
}
