#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public sealed class SwitchInstruction : ILInstruction
{
	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	public static readonly SlotInfo SectionSlot = new SlotInfo("Section", canInlineInto: false, isCollection: true);

	public bool IsLifted;

	private ILInstruction value;

	public readonly InstructionCollection<SwitchSection> Sections;

	public override StackType ResultType => StackType.Void;

	public ILInstruction Value
	{
		get
		{
			return value;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref this.value, value, 0);
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitSwitchInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitSwitchInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitSwitchInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is SwitchInstruction switchInstruction && IsLifted == switchInstruction.IsLifted && Value.PerformMatch(switchInstruction.Value, ref match) && ListMatch.DoMatch(Sections, switchInstruction.Sections, ref match);
	}

	public SwitchInstruction(ILInstruction value)
		: base(OpCode.SwitchInstruction)
	{
		Value = value;
		Sections = new InstructionCollection<SwitchSection>(this, 1);
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = InstructionFlags.EndPointUnreachable;
		foreach (SwitchSection section in Sections)
		{
			instructionFlags = SemanticHelper.CombineBranches(instructionFlags, section.Flags);
		}
		return value.Flags | InstructionFlags.ControlFlow | instructionFlags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("switch");
		if (IsLifted)
		{
			output.Write(".lifted");
		}
		output.Write(" (");
		value.WriteTo(output, options);
		output.Write(") ");
		output.MarkFoldStart("{...}");
		output.WriteLine("{");
		output.Indent();
		foreach (SwitchSection section in Sections)
		{
			section.WriteTo(output, options);
			output.WriteLine();
		}
		output.Unindent();
		output.Write('}');
		output.MarkFoldEnd();
	}

	protected override int GetChildCount()
	{
		return checked(1 + Sections.Count);
	}

	protected override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return value;
		}
		return Sections[checked(index - 1)];
	}

	protected override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Value = value;
		}
		else
		{
			Sections[checked(index - 1)] = (SwitchSection)value;
		}
	}

	protected override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ValueSlot;
		}
		return SectionSlot;
	}

	public override ILInstruction Clone()
	{
		SwitchInstruction switchInstruction = new SwitchInstruction(value.Clone());
		switchInstruction.AddILRange(this);
		switchInstruction.Value = value.Clone();
		switchInstruction.Sections.AddRange(Enumerable.Select<SwitchSection, SwitchSection>((IEnumerable<SwitchSection>)Sections, (Func<SwitchSection, SwitchSection>)((SwitchSection h) => (SwitchSection)h.Clone())));
		return switchInstruction;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		bool flag = IsLifted;
		LongSet other = LongSet.Empty;
		foreach (SwitchSection section in Sections)
		{
			if (section.HasNullLabel)
			{
				Debug.Assert(flag, "Duplicate 'case null' or 'case null' in non-lifted switch.");
				flag = false;
			}
			Debug.Assert(!section.Labels.IsEmpty || section.HasNullLabel);
			Debug.Assert(!section.Labels.Overlaps(other));
			other = other.UnionWith(section.Labels);
		}
		Debug.Assert(other.SetEquals(LongSet.Universe), "switch does not handle all possible cases");
		Debug.Assert(!flag, "Lifted switch is missing 'case null'");
		Debug.Assert(IsLifted ? (value.ResultType == StackType.O) : (value.ResultType == StackType.I4 || value.ResultType == StackType.I8));
	}
}
