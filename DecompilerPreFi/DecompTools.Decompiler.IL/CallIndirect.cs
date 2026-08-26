#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class CallIndirect : ILInstruction
{
	public static readonly SlotInfo ArgumentSlot = new SlotInfo("Argument", canInlineInto: true, isCollection: true);

	public static readonly SlotInfo FunctionPointerSlot = new SlotInfo("FunctionPointer", canInlineInto: true);

	public readonly InstructionCollection<ILInstruction> Arguments;

	private ILInstruction functionPointer;

	public SignatureCallingConvention CallingConvention { get; }

	public IType ReturnType { get; }

	public ImmutableArray<IType> ParameterTypes { get; }

	public ILInstruction FunctionPointer
	{
		get
		{
			return functionPointer;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref functionPointer, value, Arguments.Count);
		}
	}

	public override StackType ResultType => ReturnType.GetStackType();

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	protected internal override void InstructionCollectionUpdateComplete()
	{
		base.InstructionCollectionUpdateComplete();
		if (functionPointer?.Parent == this)
		{
			functionPointer.ChildIndex = Arguments.Count;
		}
	}

	public CallIndirect(SignatureCallingConvention callingConvention, IType returnType, ImmutableArray<IType> parameterTypes, IEnumerable<ILInstruction> arguments, ILInstruction functionPointer)
		: base(OpCode.CallIndirect)
	{
		CallingConvention = callingConvention;
		ReturnType = returnType ?? throw new ArgumentNullException("returnType");
		ParameterTypes = parameterTypes.ToImmutableArray();
		Arguments = new InstructionCollection<ILInstruction>(this, 0);
		Arguments.AddRange(arguments);
		FunctionPointer = functionPointer;
	}

	public override ILInstruction Clone()
	{
		return new CallIndirect(CallingConvention, ReturnType, ParameterTypes, Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Arguments, (Func<ILInstruction, ILInstruction>)((ILInstruction inst) => inst.Clone())), functionPointer.Clone()).WithILRange(this);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(Arguments.Count == ParameterTypes.Length);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("call.indirect ");
		ReturnType.WriteTo(output);
		output.Write('(');
		bool flag = true;
		foreach (var (iLInstruction, type) in Enumerable.Zip<ILInstruction, IType, (ILInstruction, IType)>((IEnumerable<ILInstruction>)Arguments, (IEnumerable<IType>)ParameterTypes, (Func<ILInstruction, IType, (ILInstruction, IType)>)((ILInstruction a, IType b) => (a: a, b: b))))
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				output.Write(", ");
			}
			iLInstruction.WriteTo(output, options);
			output.Write(" : ");
			type.WriteTo(output);
		}
		if (Arguments.Count > 0)
		{
			output.Write(", ");
		}
		functionPointer.WriteTo(output, options);
		output.Write(')');
	}

	protected override int GetChildCount()
	{
		return checked(Arguments.Count + 1);
	}

	protected override ILInstruction GetChild(int index)
	{
		if (index == Arguments.Count)
		{
			return functionPointer;
		}
		return Arguments[index];
	}

	protected override void SetChild(int index, ILInstruction value)
	{
		if (index == Arguments.Count)
		{
			FunctionPointer = value;
		}
		else
		{
			Arguments[index] = value;
		}
	}

	protected override SlotInfo GetChildSlot(int index)
	{
		if (index == Arguments.Count)
		{
			return FunctionPointerSlot;
		}
		return ArgumentSlot;
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = DirectFlags;
		foreach (ILInstruction argument in Arguments)
		{
			instructionFlags |= argument.Flags;
		}
		return instructionFlags | functionPointer.Flags;
	}

	private bool EqualSignature(CallIndirect other)
	{
		if (CallingConvention != other.CallingConvention)
		{
			return false;
		}
		if (ParameterTypes.Length != other.ParameterTypes.Length)
		{
			return false;
		}
		for (int i = 0; i < ParameterTypes.Length; i = checked(i + 1))
		{
			if (!ParameterTypes[i].Equals(other.ParameterTypes[i]))
			{
				return false;
			}
		}
		return ReturnType.Equals(other.ReturnType);
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitCallIndirect(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitCallIndirect(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitCallIndirect(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is CallIndirect callIndirect && EqualSignature(callIndirect) && ListMatch.DoMatch(Arguments, callIndirect.Arguments, ref match) && FunctionPointer.PerformMatch(callIndirect.FunctionPointer, ref match);
	}
}
