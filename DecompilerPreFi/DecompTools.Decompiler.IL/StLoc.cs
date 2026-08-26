#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class StLoc : ILInstruction, IStoreInstruction, IInstructionWithVariableOperand
{
	internal bool IsStackAdjustment;

	internal bool ILStackWasEmpty;

	private ILVariable variable;

	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	public ILVariable Variable
	{
		get
		{
			return variable;
		}
		set
		{
			Debug.Assert(value != null);
			if (base.IsConnected)
			{
				variable.RemoveStoreInstruction(this);
			}
			variable = value;
			if (base.IsConnected)
			{
				variable.AddStoreInstruction(this);
			}
		}
	}

	public int IndexInStoreInstructionList { get; set; } = -1;

	int IInstructionWithVariableOperand.IndexInVariableInstructionMapping
	{
		get
		{
			return ((IStoreInstruction)this).IndexInStoreInstructionList;
		}
		set
		{
			((IStoreInstruction)this).IndexInStoreInstructionList = value;
		}
	}

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

	public override StackType ResultType => variable.StackType;

	public override InstructionFlags DirectFlags => InstructionFlags.MayWriteLocals;

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(phase <= ILPhase.InILReader || IsDescendantOf(variable.Function));
		Debug.Assert(phase <= ILPhase.InILReader || variable.Function.Variables[variable.IndexInFunction] == variable);
		Debug.Assert(value.ResultType == variable.StackType);
	}

	public StLoc(ILVariable variable, ILInstruction value)
		: base(OpCode.StLoc)
	{
		Debug.Assert(variable != null);
		this.variable = variable;
		Value = value;
	}

	protected override void Connected()
	{
		base.Connected();
		variable.AddStoreInstruction(this);
	}

	protected override void Disconnected()
	{
		variable.RemoveStoreInstruction(this);
		base.Disconnected();
	}

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
		StLoc stLoc = (StLoc)ShallowClone();
		stLoc.Value = value.Clone();
		return stLoc;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayWriteLocals | value.Flags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		variable.WriteTo(output);
		output.Write('(');
		value.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitStLoc(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitStLoc(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitStLoc(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is StLoc stLoc && variable == stLoc.variable && value.PerformMatch(stLoc.value, ref match);
	}
}
