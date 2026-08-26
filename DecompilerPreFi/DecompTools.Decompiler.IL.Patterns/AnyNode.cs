using System;

namespace DecompTools.Decompiler.IL.Patterns;

public sealed class AnyNode : PatternInstruction
{
	private CaptureGroup group;

	public AnyNode(CaptureGroup group = null)
		: base(OpCode.AnyNode)
	{
		this.group = group;
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		if (other == null)
		{
			return false;
		}
		match.Add(group, other);
		return true;
	}

	protected sealed override int GetChildCount()
	{
		return 0;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		return (AnyNode)ShallowClone();
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('(');
		output.Write(')');
	}
}
