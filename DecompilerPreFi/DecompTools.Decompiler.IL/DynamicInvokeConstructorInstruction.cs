using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicInvokeConstructorInstruction : DynamicInstruction
{
	public static readonly SlotInfo ArgumentsSlot = new SlotInfo("Arguments", canInlineInto: true);

	public IReadOnlyList<CSharpArgumentInfo> ArgumentInfo { get; }

	public override StackType ResultType => StackType.O;

	public InstructionCollection<ILInstruction> Arguments { get; private set; }

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public DynamicInvokeConstructorInstruction(CSharpBinderFlags binderFlags, IType context, CSharpArgumentInfo[] argumentInfo, ILInstruction[] arguments)
		: base(OpCode.DynamicInvokeConstructorInstruction, binderFlags, context)
	{
		ArgumentInfo = argumentInfo;
		Arguments = new InstructionCollection<ILInstruction>(this, 0);
		Arguments.AddRange(arguments);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		WriteBinderFlags(output, options);
		output.Write(' ');
		output.Write(".ctor");
		DynamicInstruction.WriteArgumentList(output, options, Arguments.Zip(ArgumentInfo));
	}

	public override CSharpArgumentInfo GetArgumentInfoOfChild(int index)
	{
		if (index < 0 || index >= ArgumentInfo.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return ArgumentInfo[index];
	}

	protected sealed override int GetChildCount()
	{
		return Arguments.Count;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return Arguments[index];
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		Arguments[index] = value;
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return ArgumentsSlot;
	}

	public sealed override ILInstruction Clone()
	{
		DynamicInvokeConstructorInstruction dynamicInvokeConstructorInstruction = (DynamicInvokeConstructorInstruction)ShallowClone();
		dynamicInvokeConstructorInstruction.Arguments = new InstructionCollection<ILInstruction>(dynamicInvokeConstructorInstruction, 0);
		dynamicInvokeConstructorInstruction.Arguments.AddRange(Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Arguments, (Func<ILInstruction, ILInstruction>)((ILInstruction arg) => arg.Clone())));
		return dynamicInvokeConstructorInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | Enumerable.Aggregate<ILInstruction, InstructionFlags>((IEnumerable<ILInstruction>)Arguments, InstructionFlags.None, (Func<InstructionFlags, ILInstruction, InstructionFlags>)((InstructionFlags f, ILInstruction arg) => f | arg.Flags));
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicInvokeConstructorInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicInvokeConstructorInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicInvokeConstructorInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicInvokeConstructorInstruction dynamicInvokeConstructorInstruction && ListMatch.DoMatch(Arguments, dynamicInvokeConstructorInstruction.Arguments, ref match);
	}
}
