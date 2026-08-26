#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class PinnedRegion : ILInstruction, IStoreInstruction, IInstructionWithVariableOperand
{
	private ILVariable variable;

	public static readonly SlotInfo InitSlot = new SlotInfo("Init", canInlineInto: true);

	private ILInstruction init;

	public static readonly SlotInfo BodySlot = new SlotInfo("Body");

	private ILInstruction body;

	public override StackType ResultType => StackType.Void;

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

	public ILInstruction Init
	{
		get
		{
			return init;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref init, value, 0);
		}
	}

	public ILInstruction Body
	{
		get
		{
			return body;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref body, value, 1);
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.MayWriteLocals;

	public PinnedRegion(ILVariable variable, ILInstruction init, ILInstruction body)
		: base(OpCode.PinnedRegion)
	{
		Debug.Assert(variable != null);
		this.variable = variable;
		Init = init;
		Body = body;
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
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => init, 
			1 => body, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Init = value;
			break;
		case 1:
			Body = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => InitSlot, 
			1 => BodySlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		PinnedRegion pinnedRegion = (PinnedRegion)ShallowClone();
		pinnedRegion.Init = init.Clone();
		pinnedRegion.Body = body.Clone();
		return pinnedRegion;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayWriteLocals | init.Flags | body.Flags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		variable.WriteTo(output);
		output.Write('(');
		init.WriteTo(output, options);
		output.Write(", ");
		body.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitPinnedRegion(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitPinnedRegion(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitPinnedRegion(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is PinnedRegion pinnedRegion && variable == pinnedRegion.variable && init.PerformMatch(pinnedRegion.init, ref match) && body.PerformMatch(pinnedRegion.body, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(phase <= ILPhase.InILReader || IsDescendantOf(variable.Function));
		Debug.Assert(phase <= ILPhase.InILReader || variable.Function.Variables[variable.IndexInFunction] == variable);
	}
}
