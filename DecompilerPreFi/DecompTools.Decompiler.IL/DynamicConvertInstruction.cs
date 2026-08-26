#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicConvertInstruction : DynamicInstruction
{
	private IType type;

	public static readonly SlotInfo ArgumentSlot = new SlotInfo("Argument", canInlineInto: true);

	private ILInstruction argument;

	public override StackType ResultType => type.GetStackType();

	public bool IsChecked => (base.BinderFlags & CSharpBinderFlags.CheckedContext) != 0;

	public bool IsExplicit => (base.BinderFlags & CSharpBinderFlags.ConvertExplicit) != 0;

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

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		WriteBinderFlags(output, options);
		output.Write(' ');
		type.WriteTo(output);
		output.Write('(');
		argument.WriteTo(output, options);
		output.Write(')');
	}

	public DynamicConvertInstruction(CSharpBinderFlags binderFlags, IType type, IType context, ILInstruction argument)
		: base(OpCode.DynamicConvertInstruction, binderFlags, context)
	{
		Type = type;
		Argument = argument;
	}

	protected internal override bool PerformMatch(ref ListMatch listMatch, ref Match match)
	{
		return base.PerformMatch(ref listMatch, ref match);
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
		DynamicConvertInstruction dynamicConvertInstruction = (DynamicConvertInstruction)ShallowClone();
		dynamicConvertInstruction.Argument = argument.Clone();
		return dynamicConvertInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | argument.Flags;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicConvertInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicConvertInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicConvertInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicConvertInstruction dynamicConvertInstruction && type.Equals(dynamicConvertInstruction.type) && argument.PerformMatch(dynamicConvertInstruction.argument, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(argument.ResultType == StackType.O);
	}
}
