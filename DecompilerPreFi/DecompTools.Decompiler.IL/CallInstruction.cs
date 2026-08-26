#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public abstract class CallInstruction : ILInstruction
{
	public static readonly SlotInfo ArgumentsSlot = new SlotInfo("Arguments", canInlineInto: true);

	public readonly IMethod Method;

	public bool IsTail;

	public IType ConstrainedTo;

	public bool ILStackWasEmpty;

	public InstructionCollection<ILInstruction> Arguments { get; private set; }

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	public bool IsInstanceCall => !Method.IsStatic && OpCode != OpCode.NewObj;

	public override StackType ResultType
	{
		get
		{
			if (OpCode == OpCode.NewObj)
			{
				return Method.DeclaringType.GetStackType();
			}
			return Method.ReturnType.GetStackType();
		}
	}

	protected CallInstruction(OpCode opCode, params ILInstruction[] arguments)
		: base(opCode)
	{
		Arguments = new InstructionCollection<ILInstruction>(this, 0);
		Arguments.AddRange(arguments);
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
		CallInstruction callInstruction = (CallInstruction)ShallowClone();
		callInstruction.Arguments = new InstructionCollection<ILInstruction>(callInstruction, 0);
		callInstruction.Arguments.AddRange(Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Arguments, (Func<ILInstruction, ILInstruction>)((ILInstruction arg) => arg.Clone())));
		return callInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return Enumerable.Aggregate<ILInstruction, InstructionFlags>((IEnumerable<ILInstruction>)Arguments, InstructionFlags.None, (Func<InstructionFlags, ILInstruction, InstructionFlags>)((InstructionFlags f, ILInstruction arg) => f | arg.Flags)) | InstructionFlags.MayThrow | InstructionFlags.SideEffect;
	}

	public static CallInstruction Create(OpCode opCode, IMethod method)
	{
		return opCode switch
		{
			OpCode.Call => new Call(method), 
			OpCode.CallVirt => new CallVirt(method), 
			OpCode.NewObj => new NewObj(method), 
			_ => throw new ArgumentException("Not a valid call opcode"), 
		};
	}

	protected CallInstruction(OpCode opCode, IMethod method)
		: base(opCode)
	{
		Debug.Assert(method != null);
		Method = method;
		Arguments = new InstructionCollection<ILInstruction>(this, 0);
	}

	public IParameter GetParameter(int argumentIndex)
	{
		int num = ((!Method.IsStatic && OpCode != OpCode.NewObj) ? 1 : 0);
		if (argumentIndex < num)
		{
			return null;
		}
		return Method.Parameters[checked(argumentIndex - num)];
	}

	internal static StackType ExpectedTypeForThisPointer(IType type)
	{
		if (type.Kind == TypeKind.TypeParameter)
		{
			return StackType.Ref;
		}
		return type.IsReferenceType switch
		{
			true => StackType.O, 
			false => StackType.Ref, 
			_ => StackType.Unknown, 
		};
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		int num = ((OpCode != OpCode.NewObj && !Method.IsStatic) ? 1 : 0);
		checked
		{
			Debug.Assert(Method.Parameters.Count + num == Arguments.Count);
			if (num == 1 && Arguments[0].ResultType != ExpectedTypeForThisPointer(ConstrainedTo ?? Method.DeclaringType))
			{
				Debug.Fail("Stack type mismatch in 'this' argument in call to " + Method.Name + "()");
			}
			for (int i = 0; i < Method.Parameters.Count; i++)
			{
				if (Arguments[num + i].ResultType != Method.Parameters[i].Type.GetStackType())
				{
					Debug.Fail($"Stack type mismatch in parameter {i} in call to {Method.Name}()");
				}
			}
		}
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (ConstrainedTo != null)
		{
			output.Write("constrained[");
			ConstrainedTo.WriteTo(output);
			output.Write("].");
		}
		if (IsTail)
		{
			output.Write("tail.");
		}
		output.Write(OpCode);
		output.Write(' ');
		Method.WriteTo(output);
		output.Write('(');
		for (int i = 0; i < Arguments.Count; i = checked(i + 1))
		{
			if (i > 0)
			{
				output.Write(", ");
			}
			Arguments[i].WriteTo(output, options);
		}
		output.Write(')');
	}

	protected internal sealed override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is CallInstruction callInstruction && OpCode == callInstruction.OpCode && Method.Equals(callInstruction.Method) && IsTail == callInstruction.IsTail && object.Equals(ConstrainedTo, callInstruction.ConstrainedTo) && ListMatch.DoMatch(Arguments, callInstruction.Arguments, ref match);
	}
}
