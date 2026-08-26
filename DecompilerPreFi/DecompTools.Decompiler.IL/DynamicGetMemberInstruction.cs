#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicGetMemberInstruction : DynamicInstruction
{
	public static readonly SlotInfo TargetSlot = new SlotInfo("Target", canInlineInto: true);

	private ILInstruction target;

	public string Name { get; }

	public CSharpArgumentInfo TargetArgumentInfo { get; }

	public override StackType ResultType => StackType.O;

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

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public DynamicGetMemberInstruction(CSharpBinderFlags binderFlags, string name, IType context, CSharpArgumentInfo targetArgumentInfo, ILInstruction target)
		: base(OpCode.DynamicGetMemberInstruction, binderFlags, context)
	{
		Name = name;
		TargetArgumentInfo = targetArgumentInfo;
		Target = target;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		WriteBinderFlags(output, options);
		output.Write(' ');
		output.Write(Name);
		DynamicInstruction.WriteArgumentList(output, options, (Target, TargetArgumentInfo));
	}

	public override CSharpArgumentInfo GetArgumentInfoOfChild(int index)
	{
		if (index != 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return TargetArgumentInfo;
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
		DynamicGetMemberInstruction dynamicGetMemberInstruction = (DynamicGetMemberInstruction)ShallowClone();
		dynamicGetMemberInstruction.Target = target.Clone();
		return dynamicGetMemberInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | target.Flags;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicGetMemberInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicGetMemberInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicGetMemberInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicGetMemberInstruction dynamicGetMemberInstruction && target.PerformMatch(dynamicGetMemberInstruction.target, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(target.ResultType == StackType.O);
	}
}
