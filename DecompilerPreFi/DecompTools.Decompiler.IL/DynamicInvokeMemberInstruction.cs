using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicInvokeMemberInstruction : DynamicInstruction
{
	public static readonly SlotInfo ArgumentsSlot = new SlotInfo("Arguments", canInlineInto: true);

	public string Name { get; }

	public IReadOnlyList<IType> TypeArguments { get; }

	public IReadOnlyList<CSharpArgumentInfo> ArgumentInfo { get; }

	public override StackType ResultType => StackType.O;

	public InstructionCollection<ILInstruction> Arguments { get; private set; }

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public DynamicInvokeMemberInstruction(CSharpBinderFlags binderFlags, string name, IType[] typeArguments, IType context, CSharpArgumentInfo[] argumentInfo, ILInstruction[] arguments)
		: base(OpCode.DynamicInvokeMemberInstruction, binderFlags, context)
	{
		Name = name;
		TypeArguments = typeArguments ?? Empty<IType>.Array;
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
		output.Write(Name);
		if (TypeArguments.Count > 0)
		{
			output.Write('<');
			int num = 0;
			foreach (IType typeArgument in TypeArguments)
			{
				if (num > 0)
				{
					output.Write(", ");
				}
				typeArgument.WriteTo(output);
				num = checked(num + 1);
			}
			output.Write('>');
		}
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
		DynamicInvokeMemberInstruction dynamicInvokeMemberInstruction = (DynamicInvokeMemberInstruction)ShallowClone();
		dynamicInvokeMemberInstruction.Arguments = new InstructionCollection<ILInstruction>(dynamicInvokeMemberInstruction, 0);
		dynamicInvokeMemberInstruction.Arguments.AddRange(Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Arguments, (Func<ILInstruction, ILInstruction>)((ILInstruction arg) => arg.Clone())));
		return dynamicInvokeMemberInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect | Enumerable.Aggregate<ILInstruction, InstructionFlags>((IEnumerable<ILInstruction>)Arguments, InstructionFlags.None, (Func<InstructionFlags, ILInstruction, InstructionFlags>)((InstructionFlags f, ILInstruction arg) => f | arg.Flags));
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicInvokeMemberInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicInvokeMemberInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicInvokeMemberInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicInvokeMemberInstruction dynamicInvokeMemberInstruction && ListMatch.DoMatch(Arguments, dynamicInvokeMemberInstruction.Arguments, ref match);
	}
}
