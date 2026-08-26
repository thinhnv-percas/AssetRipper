using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal class SymbolicEvaluationContext
{
	private readonly FieldDef stateField;

	private readonly List<ILVariable> stateVariables = new List<ILVariable>();

	public List<ILVariable> StateVariables => stateVariables;

	public SymbolicEvaluationContext(FieldDef stateField)
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

	private SymbolicValue Failed()
	{
		return new SymbolicValue(SymbolicValueType.Unknown);
	}

	public SymbolicValue Eval(ILExpression expr)
	{
		switch (expr.Code)
		{
		case ILCode.Sub:
		case ILCode.Sub_Ovf:
		{
			SymbolicValue symbolicValue = Eval(expr.Arguments[0]);
			SymbolicValue symbolicValue2 = Eval(expr.Arguments[1]);
			if (symbolicValue.Type != SymbolicValueType.State && symbolicValue.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed();
			}
			if (symbolicValue2.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed();
			}
			return new SymbolicValue(symbolicValue.Type, symbolicValue.Constant - symbolicValue2.Constant);
		}
		case ILCode.Ldfld:
			if (Eval(expr.Arguments[0]).Type != SymbolicValueType.This)
			{
				return Failed();
			}
			if ((expr.Operand as IField).ResolveFieldWithinSameModule() != stateField)
			{
				return Failed();
			}
			return new SymbolicValue(SymbolicValueType.State);
		case ILCode.Ldloc:
		{
			ILVariable iLVariable = (ILVariable)expr.Operand;
			if (stateVariables.Contains(iLVariable))
			{
				return new SymbolicValue(SymbolicValueType.State);
			}
			if (iLVariable.IsParameter && iLVariable.OriginalParameter.IsHiddenThisParameter)
			{
				return new SymbolicValue(SymbolicValueType.This);
			}
			return Failed();
		}
		case ILCode.Ldc_I4:
			return new SymbolicValue(SymbolicValueType.IntegerConstant, (int)expr.Operand);
		case ILCode.Ceq:
		case ILCode.Cne:
		{
			SymbolicValue symbolicValue = Eval(expr.Arguments[0]);
			SymbolicValue symbolicValue2 = Eval(expr.Arguments[1]);
			if (symbolicValue.Type != SymbolicValueType.State || symbolicValue2.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed();
			}
			return new SymbolicValue((expr.Code == ILCode.Ceq) ? SymbolicValueType.StateEquals : SymbolicValueType.StateInEquals, symbolicValue2.Constant - symbolicValue.Constant);
		}
		case ILCode.LogicNot:
		{
			SymbolicValue symbolicValue3 = Eval(expr.Arguments[0]).AsBool();
			if (symbolicValue3.Type == SymbolicValueType.StateEquals)
			{
				return new SymbolicValue(SymbolicValueType.StateInEquals, symbolicValue3.Constant);
			}
			if (symbolicValue3.Type == SymbolicValueType.StateInEquals)
			{
				return new SymbolicValue(SymbolicValueType.StateEquals, symbolicValue3.Constant);
			}
			return Failed();
		}
		case ILCode.Cgt:
		{
			SymbolicValue symbolicValue = Eval(expr.Arguments[0]);
			SymbolicValue symbolicValue2 = Eval(expr.Arguments[1]);
			if (symbolicValue.Type != SymbolicValueType.State || symbolicValue2.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed();
			}
			return new SymbolicValue(SymbolicValueType.StateIsInRange, symbolicValue2.Constant - symbolicValue.Constant + 1, int.MaxValue);
		}
		case ILCode.Cgt_Un:
		{
			SymbolicValue symbolicValue = Eval(expr.Arguments[0]);
			SymbolicValue symbolicValue2 = Eval(expr.Arguments[1]);
			if (symbolicValue.Type != SymbolicValueType.State || symbolicValue2.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed();
			}
			int num = -symbolicValue.Constant;
			int num2 = num + symbolicValue2.Constant;
			if (num > num2)
			{
				return Failed();
			}
			return new SymbolicValue(SymbolicValueType.StateIsNotInRange, num, num2);
		}
		case ILCode.Cle_Un:
		{
			SymbolicValue symbolicValue = Eval(expr.Arguments[0]);
			SymbolicValue symbolicValue2 = Eval(expr.Arguments[1]);
			if (symbolicValue.Type != SymbolicValueType.State || symbolicValue2.Type != SymbolicValueType.IntegerConstant)
			{
				return Failed();
			}
			int num = -symbolicValue.Constant;
			int num2 = num + symbolicValue2.Constant;
			if (num > num2)
			{
				return Failed();
			}
			return new SymbolicValue(SymbolicValueType.StateIsInRange, num, num2);
		}
		default:
			return Failed();
		}
	}
}
