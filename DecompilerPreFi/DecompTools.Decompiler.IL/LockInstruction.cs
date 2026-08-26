#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LockInstruction : ILInstruction
{
	public static readonly SlotInfo OnExpressionSlot = new SlotInfo("OnExpression", canInlineInto: true);

	private ILInstruction onExpression;

	public static readonly SlotInfo BodySlot = new SlotInfo("Body");

	private ILInstruction body;

	public ILInstruction OnExpression
	{
		get
		{
			return onExpression;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref onExpression, value, 0);
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

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.ControlFlow;

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("lock (");
		OnExpression.WriteTo(output, options);
		output.WriteLine(") {");
		output.Indent();
		Body.WriteTo(output, options);
		output.Unindent();
		output.WriteLine();
		output.Write("}");
	}

	public LockInstruction(ILInstruction onExpression, ILInstruction body)
		: base(OpCode.LockInstruction)
	{
		OnExpression = onExpression;
		Body = body;
	}

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => onExpression, 
			1 => body, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			OnExpression = value;
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
			0 => OnExpressionSlot, 
			1 => BodySlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		LockInstruction lockInstruction = (LockInstruction)ShallowClone();
		lockInstruction.OnExpression = onExpression.Clone();
		lockInstruction.Body = body.Clone();
		return lockInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return onExpression.Flags | body.Flags | InstructionFlags.ControlFlow | InstructionFlags.SideEffect;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLockInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLockInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLockInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LockInstruction lockInstruction && onExpression.PerformMatch(lockInstruction.onExpression, ref match) && body.PerformMatch(lockInstruction.body, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(onExpression.ResultType == StackType.O);
	}
}
