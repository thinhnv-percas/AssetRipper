#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class UserDefinedCompoundAssign : CompoundAssignmentInstruction
{
	public readonly IMethod Method;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public bool IsLifted => false;

	public override StackType ResultType => Method.ReturnType.GetStackType();

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitUserDefinedCompoundAssign(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitUserDefinedCompoundAssign(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitUserDefinedCompoundAssign(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is UserDefinedCompoundAssign userDefinedCompoundAssign && Method.Equals(userDefinedCompoundAssign.Method) && CompoundAssignmentType == userDefinedCompoundAssign.CompoundAssignmentType && base.Target.PerformMatch(userDefinedCompoundAssign.Target, ref match) && base.Value.PerformMatch(userDefinedCompoundAssign.Value, ref match);
	}

	public UserDefinedCompoundAssign(IMethod method, CompoundAssignmentType compoundAssignmentType, ILInstruction target, ILInstruction value)
		: base(OpCode.UserDefinedCompoundAssign, compoundAssignmentType, target, value)
	{
		Method = method;
		Debug.Assert(Method.IsOperator || IsStringConcat(method));
		Debug.Assert(compoundAssignmentType == CompoundAssignmentType.EvaluatesToNewValue || Method.Name == "op_Increment" || Method.Name == "op_Decrement");
		Debug.Assert(CompoundAssignmentInstruction.IsValidCompoundAssignmentTarget(base.Target));
	}

	public static bool IsStringConcat(IMethod method)
	{
		return method.Name == "Concat" && method.IsStatic && method.DeclaringType.IsKnownType(KnownTypeCode.String);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (CompoundAssignmentType == CompoundAssignmentType.EvaluatesToNewValue)
		{
			output.Write(".new");
		}
		else
		{
			output.Write(".old");
		}
		output.Write(' ');
		Method.WriteTo(output);
		output.Write('(');
		base.Target.WriteTo(output, options);
		output.Write(", ");
		base.Value.WriteTo(output, options);
		output.Write(')');
	}
}
