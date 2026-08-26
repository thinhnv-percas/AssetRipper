#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdLen : ILInstruction
{
	public static readonly SlotInfo ArraySlot = new SlotInfo("Array", canInlineInto: true);

	private ILInstruction array;

	private readonly StackType resultType;

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

	public override InstructionFlags DirectFlags => InstructionFlags.MayThrow;

	public override StackType ResultType => resultType;

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
		LdLen ldLen = (LdLen)ShallowClone();
		ldLen.Array = array.Clone();
		return ldLen;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return array.Flags | InstructionFlags.MayThrow;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdLen(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdLen(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdLen(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdLen ldLen && array.PerformMatch(ldLen.array, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(array.ResultType == StackType.O);
	}

	public LdLen(StackType type, ILInstruction array)
		: base(OpCode.LdLen)
	{
		Debug.Assert(type == StackType.I || type == StackType.I4 || type == StackType.I8);
		resultType = type;
		Array = array;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('.');
		output.Write(resultType);
		output.Write('(');
		array.WriteTo(output, options);
		output.Write(')');
	}
}
