#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdObj : ILInstruction, ISupportsVolatilePrefix, ISupportsUnalignedPrefix
{
	public static readonly SlotInfo TargetSlot = new SlotInfo("Target", canInlineInto: true);

	private ILInstruction target;

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

	public LdObj(ILInstruction target, IType type)
		: base(OpCode.LdObj)
	{
		Target = target;
		this.type = type;
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
		LdObj ldObj = (LdObj)ShallowClone();
		ldObj.Target = target.Clone();
		return ldObj;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return target.Flags | InstructionFlags.SideEffect | InstructionFlags.MayThrow;
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
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdObj(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdObj(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdObj(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdObj ldObj && target.PerformMatch(ldObj.target, ref match) && type.Equals(ldObj.type) && IsVolatile == ldObj.IsVolatile && UnalignedPrefix == ldObj.UnalignedPrefix;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(target.ResultType == StackType.Ref || target.ResultType == StackType.I);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		if (options.UseFieldSugar)
		{
			if (MatchLdFld(out var iLInstruction, out var field))
			{
				WriteILRange(output, options);
				output.Write("ldfld ");
				field.WriteTo(output);
				output.Write('(');
				iLInstruction.WriteTo(output, options);
				output.Write(')');
				return;
			}
			if (MatchLdsFld(out field))
			{
				WriteILRange(output, options);
				output.Write("ldsfld ");
				field.WriteTo(output);
				return;
			}
		}
		OriginalWriteTo(output, options);
	}
}
