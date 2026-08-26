#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdLoca : SimpleInstruction, IAddressInstruction, IInstructionWithVariableOperand
{
	private ILVariable variable;

	public override StackType ResultType => StackType.Ref;

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
				variable.RemoveAddressInstruction(this);
			}
			variable = value;
			if (base.IsConnected)
			{
				variable.AddAddressInstruction(this);
			}
		}
	}

	public int IndexInAddressInstructionList { get; set; } = -1;

	int IInstructionWithVariableOperand.IndexInVariableInstructionMapping
	{
		get
		{
			return ((IAddressInstruction)this).IndexInAddressInstructionList;
		}
		set
		{
			((IAddressInstruction)this).IndexInAddressInstructionList = value;
		}
	}

	public LdLoca(ILVariable variable)
		: base(OpCode.LdLoca)
	{
		Debug.Assert(variable != null);
		this.variable = variable;
	}

	protected override void Connected()
	{
		base.Connected();
		variable.AddAddressInstruction(this);
	}

	protected override void Disconnected()
	{
		variable.RemoveAddressInstruction(this);
		base.Disconnected();
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
		visitor.VisitLdLoca(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdLoca(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdLoca(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdLoca ldLoca && variable == ldLoca.variable;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(phase <= ILPhase.InILReader || IsDescendantOf(variable.Function));
		Debug.Assert(phase <= ILPhase.InILReader || variable.Function.Variables[variable.IndexInFunction] == variable);
	}
}
