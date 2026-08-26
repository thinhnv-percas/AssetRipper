#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class UsingInstruction : ILInstruction, IStoreInstruction, IInstructionWithVariableOperand
{
	private ILVariable variable;

	public static readonly SlotInfo ResourceExpressionSlot = new SlotInfo("ResourceExpression", canInlineInto: true);

	private ILInstruction resourceExpression;

	public static readonly SlotInfo BodySlot = new SlotInfo("Body");

	private ILInstruction body;

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

	public ILInstruction ResourceExpression
	{
		get
		{
			return resourceExpression;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref resourceExpression, value, 0);
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

	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.MayWriteLocals | InstructionFlags.SideEffect | InstructionFlags.ControlFlow;

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("using (");
		Variable.WriteTo(output);
		output.Write(" = ");
		ResourceExpression.WriteTo(output, options);
		output.WriteLine(") {");
		output.Indent();
		Body.WriteTo(output, options);
		output.Unindent();
		output.WriteLine();
		output.Write("}");
	}

	public UsingInstruction(ILVariable variable, ILInstruction resourceExpression, ILInstruction body)
		: base(OpCode.UsingInstruction)
	{
		Debug.Assert(variable != null);
		this.variable = variable;
		ResourceExpression = resourceExpression;
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
			0 => resourceExpression, 
			1 => body, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			ResourceExpression = value;
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
			0 => ResourceExpressionSlot, 
			1 => BodySlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		UsingInstruction usingInstruction = (UsingInstruction)ShallowClone();
		usingInstruction.ResourceExpression = resourceExpression.Clone();
		usingInstruction.Body = body.Clone();
		return usingInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayWriteLocals | resourceExpression.Flags | body.Flags | InstructionFlags.ControlFlow | InstructionFlags.SideEffect;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitUsingInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitUsingInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitUsingInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is UsingInstruction usingInstruction && variable == usingInstruction.variable && resourceExpression.PerformMatch(usingInstruction.resourceExpression, ref match) && body.PerformMatch(usingInstruction.body, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(phase <= ILPhase.InILReader || IsDescendantOf(variable.Function));
		Debug.Assert(phase <= ILPhase.InILReader || variable.Function.Variables[variable.IndexInFunction] == variable);
		Debug.Assert(resourceExpression.ResultType == StackType.O);
	}
}
