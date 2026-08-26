#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class TryCatchHandler : ILInstruction, IStoreInstruction, IInstructionWithVariableOperand
{
	public static readonly SlotInfo FilterSlot = new SlotInfo("Filter");

	private ILInstruction filter;

	public static readonly SlotInfo BodySlot = new SlotInfo("Body");

	private ILInstruction body;

	private ILVariable variable;

	public ILInstruction Filter
	{
		get
		{
			return filter;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref filter, value, 0);
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

	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.MayWriteLocals | InstructionFlags.ControlFlow;

	public TryCatchHandler(ILInstruction filter, ILInstruction body, ILVariable variable)
		: base(OpCode.TryCatchHandler)
	{
		Filter = filter;
		Body = body;
		Debug.Assert(variable != null);
		this.variable = variable;
	}

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => filter, 
			1 => body, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Filter = value;
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
			0 => FilterSlot, 
			1 => BodySlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		TryCatchHandler tryCatchHandler = (TryCatchHandler)ShallowClone();
		tryCatchHandler.Filter = filter.Clone();
		tryCatchHandler.Body = body.Clone();
		return tryCatchHandler;
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

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitTryCatchHandler(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitTryCatchHandler(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitTryCatchHandler(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is TryCatchHandler tryCatchHandler && filter.PerformMatch(tryCatchHandler.filter, ref match) && body.PerformMatch(tryCatchHandler.body, ref match) && variable == tryCatchHandler.variable;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(base.Parent is TryCatch);
		Debug.Assert(filter.ResultType == StackType.I4);
		Debug.Assert(IsDescendantOf(variable.Function));
	}

	protected override InstructionFlags ComputeFlags()
	{
		return filter.Flags | body.Flags | InstructionFlags.ControlFlow | InstructionFlags.MayWriteLocals;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("catch ");
		if (variable != null)
		{
			output.WriteLocalReference(variable.Name, variable, isDefinition: true);
			output.Write(" : ");
			DisassemblerHelpers.WriteOperand(output, variable.Type);
		}
		output.Write(" when (");
		filter.WriteTo(output, options);
		output.Write(')');
		output.Write(' ');
		body.WriteTo(output, options);
	}
}
