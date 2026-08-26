#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicIsEventInstruction : DynamicInstruction
{
	public static readonly SlotInfo ArgumentSlot = new SlotInfo("Argument", canInlineInto: true);

	private ILInstruction argument;

	public string Name { get; }

	public override StackType ResultType => StackType.I4;

	public ILInstruction Argument
	{
		get
		{
			return argument;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref argument, value, 0);
		}
	}

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public DynamicIsEventInstruction(CSharpBinderFlags binderFlags, string name, IType context, ILInstruction argument)
		: base(OpCode.DynamicIsEventInstruction, binderFlags, context)
	{
		Name = name;
		Argument = argument;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		WriteBinderFlags(output, options);
		output.Write(' ');
		output.Write('(');
		Argument.WriteTo(output, options);
		output.Write(')');
	}

	public override CSharpArgumentInfo GetArgumentInfoOfChild(int index)
	{
		return default(CSharpArgumentInfo);
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return argument;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Argument = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ArgumentSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		DynamicIsEventInstruction dynamicIsEventInstruction = (DynamicIsEventInstruction)ShallowClone();
		dynamicIsEventInstruction.Argument = argument.Clone();
		return dynamicIsEventInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | argument.Flags;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicIsEventInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicIsEventInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicIsEventInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicIsEventInstruction dynamicIsEventInstruction && argument.PerformMatch(dynamicIsEventInstruction.argument, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(argument.ResultType == StackType.O);
	}
}
