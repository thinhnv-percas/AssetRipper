#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class ArrayToPointer : ILInstruction
{
	public static readonly SlotInfo ArraySlot = new SlotInfo("Array", canInlineInto: true);

	private ILInstruction array;

	public ILInstruction Array
	{
		get
		{
			return array;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref array, value, 0);
		}
	}

	public override StackType ResultType => StackType.Ref;

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	public ArrayToPointer(ILInstruction array)
		: base(OpCode.ArrayToPointer)
	{
		Array = array;
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return array;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Array = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ArraySlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		ArrayToPointer arrayToPointer = (ArrayToPointer)ShallowClone();
		arrayToPointer.Array = array.Clone();
		return arrayToPointer;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return array.Flags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('(');
		array.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitArrayToPointer(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitArrayToPointer(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitArrayToPointer(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is ArrayToPointer arrayToPointer && array.PerformMatch(arrayToPointer.array, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(array.ResultType == StackType.O);
	}
}
