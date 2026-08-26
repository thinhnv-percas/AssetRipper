#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicSetMemberInstruction : DynamicInstruction
{
	public static readonly SlotInfo TargetSlot = new SlotInfo("Target", canInlineInto: true);

	private ILInstruction target;

	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	public string Name { get; }

	public CSharpArgumentInfo TargetArgumentInfo { get; }

	public CSharpArgumentInfo ValueArgumentInfo { get; }

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

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public DynamicSetMemberInstruction(CSharpBinderFlags binderFlags, string name, IType context, CSharpArgumentInfo targetArgumentInfo, ILInstruction target, CSharpArgumentInfo valueArgumentInfo, ILInstruction value)
		: base(OpCode.DynamicSetMemberInstruction, binderFlags, context)
	{
		Name = name;
		TargetArgumentInfo = targetArgumentInfo;
		Target = target;
		ValueArgumentInfo = valueArgumentInfo;
		Value = value;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		WriteBinderFlags(output, options);
		output.Write(' ');
		output.Write(Name);
		DynamicInstruction.WriteArgumentList(output, options, (Target, TargetArgumentInfo), (Value, ValueArgumentInfo));
	}

	public override CSharpArgumentInfo GetArgumentInfoOfChild(int index)
	{
		return index switch
		{
			0 => TargetArgumentInfo, 
			1 => ValueArgumentInfo, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		};
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
		DynamicSetMemberInstruction dynamicSetMemberInstruction = (DynamicSetMemberInstruction)ShallowClone();
		dynamicSetMemberInstruction.Target = target.Clone();
		dynamicSetMemberInstruction.Value = value.Clone();
		return dynamicSetMemberInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | target.Flags | value.Flags;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicSetMemberInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicSetMemberInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicSetMemberInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicSetMemberInstruction dynamicSetMemberInstruction && target.PerformMatch(dynamicSetMemberInstruction.target, ref match) && value.PerformMatch(dynamicSetMemberInstruction.value, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(target.ResultType == StackType.O);
	}
}
