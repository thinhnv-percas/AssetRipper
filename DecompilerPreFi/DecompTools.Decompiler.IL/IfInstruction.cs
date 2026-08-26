#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class IfInstruction : ILInstruction
{
	public static readonly SlotInfo ConditionSlot = new SlotInfo("Condition", canInlineInto: true);

	private ILInstruction condition;

	public static readonly SlotInfo TrueInstSlot = new SlotInfo("TrueInst");

	private ILInstruction trueInst;

	public static readonly SlotInfo FalseInstSlot = new SlotInfo("FalseInst");

	private ILInstruction falseInst;

	public ILInstruction Condition
	{
		get
		{
			return condition;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref condition, value, 0);
		}
	}

	public ILInstruction TrueInst
	{
		get
		{
			return trueInst;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref trueInst, value, 1);
		}
	}

	public ILInstruction FalseInst
	{
		get
		{
			return falseInst;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref falseInst, value, 2);
		}
	}

	public override StackType ResultType
	{
		get
		{
			if (trueInst.HasDirectFlag(InstructionFlags.EndPointUnreachable))
			{
				return falseInst.ResultType;
			}
			return trueInst.ResultType;
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	protected sealed override int GetChildCount()
	{
		return 3;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => condition, 
			1 => trueInst, 
			2 => falseInst, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Condition = value;
			break;
		case 1:
			TrueInst = value;
			break;
		case 2:
			FalseInst = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => ConditionSlot, 
			1 => TrueInstSlot, 
			2 => FalseInstSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		IfInstruction ifInstruction = (IfInstruction)ShallowClone();
		ifInstruction.Condition = condition.Clone();
		ifInstruction.TrueInst = trueInst.Clone();
		ifInstruction.FalseInst = falseInst.Clone();
		return ifInstruction;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitIfInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitIfInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitIfInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is IfInstruction ifInstruction && condition.PerformMatch(ifInstruction.condition, ref match) && trueInst.PerformMatch(ifInstruction.trueInst, ref match) && falseInst.PerformMatch(ifInstruction.falseInst, ref match);
	}

	public IfInstruction(ILInstruction condition, ILInstruction trueInst, ILInstruction falseInst = null)
		: base(OpCode.IfInstruction)
	{
		Condition = condition;
		TrueInst = trueInst;
		FalseInst = falseInst ?? new Nop();
	}

	public static IfInstruction LogicAnd(ILInstruction lhs, ILInstruction rhs)
	{
		return new IfInstruction(lhs, rhs, new LdcI4(0));
	}

	public static IfInstruction LogicOr(ILInstruction lhs, ILInstruction rhs)
	{
		return new IfInstruction(lhs, new LdcI4(1), rhs);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(condition.ResultType == StackType.I4);
		Debug.Assert(trueInst.ResultType == falseInst.ResultType || trueInst.HasDirectFlag(InstructionFlags.EndPointUnreachable) || falseInst.HasDirectFlag(InstructionFlags.EndPointUnreachable));
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.ControlFlow | condition.Flags | SemanticHelper.CombineBranches(trueInst.Flags, falseInst.Flags);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (options.UseLogicOperationSugar)
		{
			if (MatchLogicAnd(out var lhs, out var rhs))
			{
				output.Write("logic.and(");
				lhs.WriteTo(output, options);
				output.Write(", ");
				rhs.WriteTo(output, options);
				output.Write(')');
				return;
			}
			if (MatchLogicOr(out lhs, out rhs))
			{
				output.Write("logic.or(");
				lhs.WriteTo(output, options);
				output.Write(", ");
				rhs.WriteTo(output, options);
				output.Write(')');
				return;
			}
		}
		output.Write(OpCode);
		output.Write(" (");
		condition.WriteTo(output, options);
		output.Write(") ");
		trueInst.WriteTo(output, options);
		if (falseInst.OpCode != OpCode.Nop)
		{
			output.Write(" else ");
			falseInst.WriteTo(output, options);
		}
	}

	internal static bool IsInConditionSlot(ILInstruction inst)
	{
		SlotInfo slotInfo = inst.SlotInfo;
		if (slotInfo == ConditionSlot)
		{
			return true;
		}
		if (slotInfo == TrueInstSlot || slotInfo == FalseInstSlot || slotInfo == NullCoalescingInstruction.FallbackInstSlot)
		{
			return IsInConditionSlot(inst.Parent);
		}
		if (inst.Parent is Comp comp)
		{
			if (comp.Left == inst && comp.Right.MatchLdcI4(0))
			{
				return true;
			}
			if (comp.Right == inst && comp.Left.MatchLdcI4(0))
			{
				return true;
			}
		}
		return false;
	}
}
