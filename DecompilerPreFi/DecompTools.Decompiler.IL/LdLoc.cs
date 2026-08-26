#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdLoc : SimpleInstruction, ILoadInstruction, IInstructionWithVariableOperand
{
	private ILVariable variable;

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
				variable.RemoveLoadInstruction(this);
			}
			variable = value;
			if (base.IsConnected)
			{
				variable.AddLoadInstruction(this);
			}
		}
	}

	public int IndexInLoadInstructionList { get; set; } = -1;

	int IInstructionWithVariableOperand.IndexInVariableInstructionMapping
	{
		get
		{
			return ((ILoadInstruction)this).IndexInLoadInstructionList;
		}
		set
		{
			((ILoadInstruction)this).IndexInLoadInstructionList = value;
		}
	}

	public override StackType ResultType => variable.StackType;

	public override InstructionFlags DirectFlags => InstructionFlags.MayReadLocals;

	public LdLoc(ILVariable variable)
		: base(OpCode.LdLoc)
	{
		Debug.Assert(variable != null);
		this.variable = variable;
	}

	protected override void Connected()
	{
		base.Connected();
		variable.AddLoadInstruction(this);
	}

	protected override void Disconnected()
	{
		variable.RemoveLoadInstruction(this);
		base.Disconnected();
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayReadLocals;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		variable.WriteTo(output);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdLoc(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdLoc(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdLoc(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdLoc ldLoc && variable == ldLoc.variable;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(phase <= ILPhase.InILReader || IsDescendantOf(variable.Function));
		Debug.Assert(phase <= ILPhase.InILReader || variable.Function.Variables[variable.IndexInFunction] == variable);
	}
}
