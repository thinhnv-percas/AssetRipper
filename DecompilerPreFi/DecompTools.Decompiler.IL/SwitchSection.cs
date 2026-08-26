using System;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public sealed class SwitchSection : ILInstruction
{
	public static readonly SlotInfo BodySlot = new SlotInfo("Body");

	private ILInstruction body;

	public ILInstruction Body
	{
		get
		{
			return body;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref body, value, 0);
		}
	}

	public override StackType ResultType => StackType.Void;

	public bool HasNullLabel { get; set; }

	public LongSet Labels { get; set; }

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return body;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Body = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return BodySlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		SwitchSection switchSection = (SwitchSection)ShallowClone();
		switchSection.Body = body.Clone();
		return switchSection;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitSwitchSection(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitSwitchSection(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitSwitchSection(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is SwitchSection switchSection && body.PerformMatch(switchSection.body, ref match) && Labels.SetEquals(switchSection.Labels) && HasNullLabel == switchSection.HasNullLabel;
	}

	public SwitchSection()
		: base(OpCode.SwitchSection)
	{
		Labels = LongSet.Empty;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return body.Flags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.WriteLocalReference("case", this, isDefinition: true);
		output.Write(' ');
		if (HasNullLabel)
		{
			output.Write("null");
			if (!Labels.IsEmpty)
			{
				output.Write(", ");
				output.Write(Labels.ToString());
			}
		}
		else
		{
			output.Write(Labels.ToString());
		}
		output.Write(": ");
		body.WriteTo(output, options);
	}
}
