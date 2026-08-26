using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class SymbolicEvaluationContext
{
	private readonly IField stateField;

	private readonly List<ILVariable> stateVariables = new List<ILVariable>();

	private static readonly SymbolicValue Failed = new SymbolicValue(SymbolicValueType.Unknown);

	public IEnumerable<ILVariable> StateVariables => stateVariables;

	public SymbolicEvaluationContext(IField stateField)
	{
		this.stateField = stateField;
	}

	public void AddStateVariable(ILVariable v)
	{
		if (!stateVariables.Contains(v))
		{
			stateVariables.Add(v);
		}
	}

	public SymbolicValue Eval(ILInstruction inst)
	{
		if (inst is BinaryNumericInstruction { Operator: BinaryNumericOperator.Sub, CheckForOverflow: false } binaryNumericInstruction)
		{
			SymbolicValue symbolicValue = Eval(binaryNumericInstruction.Left);
			SymbolicValue symbolicValue2 = Eval(binaryNumericInstruction.Right);
			if (symbolicValue.Type != SymbolicValueType.State && symbolicValue.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed;
			}
			if (symbolicValue2.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed;
			}
			return new SymbolicValue(symbolicValue.Type, symbolicValue.Constant - symbolicValue2.Constant);
		}
		if (inst.MatchLdFld(out var target, out var field))
		{
			if (Eval(target).Type != SymbolicValueType.This)
			{
				return Failed;
			}
			if (field.MemberDefinition != stateField)
			{
				return Failed;
			}
			return new SymbolicValue(SymbolicValueType.State);
		}
		if (inst.MatchLdLoc(out var variable))
		{
			if (stateVariables.Contains(variable))
			{
				return new SymbolicValue(SymbolicValueType.State);
			}
			if (variable.Kind == VariableKind.Parameter && variable.Index < 0)
			{
				return new SymbolicValue(SymbolicValueType.This);
			}
			return Failed;
		}
		if (inst.MatchLdcI4(out var value))
		{
			return new SymbolicValue(SymbolicValueType.IntegerConstant, value);
		}
		if (inst is Comp comp)
		{
			SymbolicValue symbolicValue3 = Eval(comp.Left);
			SymbolicValue symbolicValue4 = Eval(comp.Right);
			if (symbolicValue3.Type == SymbolicValueType.State && symbolicValue4.Type == SymbolicValueType.IntegerConstant)
			{
				LongSet valueSet = SwitchAnalysis.MakeSetWhereComparisonIsTrue(comp.Kind, symbolicValue4.Constant, comp.Sign).AddOffset(-symbolicValue3.Constant);
				return new SymbolicValue(SymbolicValueType.StateInSet, valueSet);
			}
			if (symbolicValue3.Type == SymbolicValueType.StateInSet && symbolicValue4.Type == SymbolicValueType.IntegerConstant)
			{
				if (comp.Kind == ComparisonKind.Equality && symbolicValue4.Constant == 0)
				{
					return new SymbolicValue(SymbolicValueType.StateInSet, symbolicValue3.ValueSet.Invert());
				}
				if (comp.Kind == ComparisonKind.Inequality && symbolicValue4.Constant != 0)
				{
					return new SymbolicValue(SymbolicValueType.StateInSet, symbolicValue3.ValueSet);
				}
				return Failed;
			}
			return Failed;
		}
		return Failed;
	}
}
