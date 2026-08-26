#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Leave : ILInstruction, IBranchOrLeaveInstruction
{
	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	private BlockContainer targetContainer;

	public ILInstruction Value
	{
		get
		{
			return value;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref this.value, value, 0);
		}
	}

	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.MayBranch | InstructionFlags.EndPointUnreachable;

	public BlockContainer TargetContainer
	{
		get
		{
			return targetContainer;
		}
		set
		{
			checked
			{
				if (targetContainer != null && base.IsConnected)
				{
					targetContainer.LeaveCount--;
				}
				targetContainer = value;
				if (targetContainer != null && base.IsConnected)
				{
					targetContainer.LeaveCount++;
				}
			}
		}
	}

	public string TargetLabel => (targetContainer?.EntryPoint != null) ? targetContainer.EntryPoint.Label : string.Empty;

	public bool IsLeavingFunction => targetContainer?.Parent is ILFunction;

	public bool TriggersFinallyBlock => Branch.GetExecutesFinallyBlock(this, TargetContainer);

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return value;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Value = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ValueSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		Leave leave = (Leave)ShallowClone();
		leave.Value = value.Clone();
		return leave;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLeave(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLeave(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLeave(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Leave leave && value.PerformMatch(leave.value, ref match) && TargetContainer == leave.TargetContainer;
	}

	public Leave(BlockContainer targetContainer, ILInstruction value = null)
		: base(OpCode.Leave)
	{
		this.targetContainer = targetContainer;
		Value = value ?? new Nop();
	}

	protected override InstructionFlags ComputeFlags()
	{
		return value.Flags | InstructionFlags.MayBranch | InstructionFlags.EndPointUnreachable;
	}

	protected override void Connected()
	{
		base.Connected();
		checked
		{
			if (targetContainer != null)
			{
				targetContainer.LeaveCount++;
			}
		}
	}

	protected override void Disconnected()
	{
		base.Disconnected();
		checked
		{
			if (targetContainer != null)
			{
				targetContainer.LeaveCount--;
			}
		}
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(phase <= ILPhase.InILReader || IsDescendantOf(targetContainer));
		Debug.Assert(phase <= ILPhase.InILReader || phase == ILPhase.InAsyncAwait || value.ResultType == targetContainer.ResultType);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (targetContainer != null)
		{
			output.Write(' ');
			output.WriteLocalReference(TargetLabel, targetContainer);
			output.Write(" (");
			value.WriteTo(output, options);
			output.Write(')');
		}
	}
}
