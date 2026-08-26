#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class StObj : ILInstruction, ISupportsVolatilePrefix, ISupportsUnalignedPrefix
{
	public static readonly SlotInfo TargetSlot = new SlotInfo("Target", canInlineInto: true);

	private ILInstruction target;

	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	private IType type;

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

	public ILInstruction Value
	{
		get
		{
			return value;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref this.value, value, 1);
		}
	}

	public IType Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
			InvalidateFlags();
		}
	}

	public bool IsVolatile { get; set; }

	public byte UnalignedPrefix { get; set; }

	public override StackType ResultType => type.GetStackType();

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	public StObj(ILInstruction target, ILInstruction value, IType type)
		: base(OpCode.StObj)
	{
		Target = target;
		Value = value;
		this.type = type;
	}

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => target, 
			1 => value, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Target = value;
			break;
		case 1:
			Value = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => TargetSlot, 
			1 => ValueSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		StObj stObj = (StObj)ShallowClone();
		stObj.Target = target.Clone();
		stObj.Value = value.Clone();
		return stObj;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return target.Flags | value.Flags | InstructionFlags.SideEffect | InstructionFlags.MayThrow;
	}

	private void OriginalWriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (IsVolatile)
		{
			output.Write("volatile.");
		}
		if (UnalignedPrefix > 0)
		{
			output.Write("unaligned(" + UnalignedPrefix + ").");
		}
		output.Write(OpCode);
		output.Write(' ');
		type.WriteTo(output);
		output.Write('(');
		target.WriteTo(output, options);
		output.Write(", ");
		value.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitStObj(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitStObj(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitStObj(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is StObj stObj && target.PerformMatch(stObj.target, ref match) && value.PerformMatch(stObj.value, ref match) && type.Equals(stObj.type) && IsVolatile == stObj.IsVolatile && UnalignedPrefix == stObj.UnalignedPrefix;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(target.ResultType == StackType.Ref || target.ResultType == StackType.I);
		Debug.Assert(value.ResultType == type.GetStackType());
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		if (options.UseFieldSugar)
		{
			if (MatchStFld(out var iLInstruction, out var field, out var iLInstruction2))
			{
				WriteILRange(output, options);
				output.Write("stfld ");
				field.WriteTo(output);
				output.Write('(');
				iLInstruction.WriteTo(output, options);
				output.Write(", ");
				iLInstruction2.WriteTo(output, options);
				output.Write(')');
				return;
			}
			if (MatchStsFld(out field, out iLInstruction2))
			{
				WriteILRange(output, options);
				output.Write("stsfld ");
				field.WriteTo(output);
				output.Write('(');
				iLInstruction2.WriteTo(output, options);
				output.Write(')');
				return;
			}
		}
		OriginalWriteTo(output, options);
	}
}
