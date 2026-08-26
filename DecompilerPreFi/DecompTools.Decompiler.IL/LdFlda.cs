#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdFlda : ILInstruction, IInstructionWithFieldOperand
{
	public static readonly SlotInfo TargetSlot = new SlotInfo("Target", canInlineInto: true);

	private ILInstruction target;

	public bool DelayExceptions;

	private readonly IField field;

	public ILInstruction Target
	{
		get
		{
			return target;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref target, value, 0);
		}
	}

	public IField Field => field;

	public override StackType ResultType => target.ResultType.IsIntegerType() ? StackType.I : StackType.Ref;

	public override InstructionFlags DirectFlags => (!DelayExceptions) ? InstructionFlags.MayThrow : InstructionFlags.None;

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		switch (field.DeclaringType.IsReferenceType)
		{
		case true:
			Debug.Assert(target.ResultType == StackType.O, "Class fields can only be accessed with an object on the stack");
			break;
		case false:
			Debug.Assert(target.ResultType == StackType.I || target.ResultType == StackType.Ref, "Struct fields can only be accessed with a pointer on the stack");
			break;
		case null:
			Debug.Assert(target.ResultType == StackType.O || target.ResultType == StackType.I || target.ResultType == StackType.Ref);
			break;
		}
	}

	public LdFlda(ILInstruction target, IField field)
		: base(OpCode.LdFlda)
	{
		Target = target;
		this.field = field;
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return target;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Target = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return TargetSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		LdFlda ldFlda = (LdFlda)ShallowClone();
		ldFlda.Target = target.Clone();
		return ldFlda;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return (InstructionFlags)((int)target.Flags | ((!DelayExceptions) ? 256 : 0));
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (DelayExceptions)
		{
			output.Write("delayex.");
		}
		output.Write(OpCode);
		output.Write(' ');
		field.WriteTo(output);
		output.Write('(');
		target.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdFlda(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdFlda(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdFlda(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdFlda ldFlda && target.PerformMatch(ldFlda.target, ref match) && DelayExceptions == ldFlda.DelayExceptions && field.Equals(ldFlda.field);
	}
}
