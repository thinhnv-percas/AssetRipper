#define DEBUG
using System;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class NullableUnwrap : UnaryInstruction
{
	public readonly bool RefInput;

	public bool RefOutput => ResultType == StackType.Ref;

	public override StackType ResultType { get; }

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayUnwrapNull;

	public NullableUnwrap(StackType unwrappedType, ILInstruction argument, bool refInput = false)
		: base(OpCode.NullableUnwrap, argument)
	{
		ResultType = unwrappedType;
		RefInput = refInput;
		if (unwrappedType == StackType.Ref)
		{
			Debug.Assert(refInput);
		}
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		if (RefInput)
		{
			Debug.Assert(base.Argument.ResultType == StackType.Ref, "nullable.unwrap expects reference to nullable type as input");
		}
		else
		{
			Debug.Assert(base.Argument.ResultType == StackType.O, "nullable.unwrap expects nullable type as input");
		}
		Debug.Assert(Enumerable.Any<ILInstruction>(base.Ancestors, (Func<ILInstruction, bool>)((ILInstruction a) => a is NullableRewrap)));
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		output.Write("nullable.unwrap.");
		if (RefInput)
		{
			output.Write("refinput.");
		}
		output.Write(ResultType);
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayUnwrapNull;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNullableUnwrap(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNullableUnwrap(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNullableUnwrap(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is NullableUnwrap nullableUnwrap && base.Argument.PerformMatch(nullableUnwrap.Argument, ref match);
	}
}
