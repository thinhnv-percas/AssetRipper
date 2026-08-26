using Mono.Cecil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	internal class SymbolicEvaluationContext
	{
		private readonly FieldDefinition stateField;

		private readonly List<ILVariable> stateVariables = new List<ILVariable>();

		public SymbolicEvaluationContext(FieldDefinition stateField)
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
			{
				SymbolicValue symbolicValue2 = Eval(expr.Arguments[0]);
				SymbolicValue symbolicValue3 = Eval(expr.Arguments[1]);
				if (symbolicValue2.Type != SymbolicValueType.State && symbolicValue2.Type != SymbolicValueType.IntegerConstant)
				{
					return Failed();
				}
				if (symbolicValue3.Type != SymbolicValueType.IntegerConstant)
				{
					return Failed();
				}
				return new SymbolicValue(symbolicValue2.Type, symbolicValue2.Constant - symbolicValue3.Constant);
			}
			case ILCode.Ldfld:
				if (Eval(expr.Arguments[0]).Type != SymbolicValueType.This)
				{
					return Failed();
				}
				if ((expr.Operand as FieldReference).ResolveWithinSameModule() != stateField)
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
				if (iLVariable.IsParameter && iLVariable.OriginalParameter.Index < 0)
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
				SymbolicValue symbolicValue2 = Eval(expr.Arguments[0]);
				SymbolicValue symbolicValue3 = Eval(expr.Arguments[1]);
				if (symbolicValue2.Type != SymbolicValueType.State || symbolicValue3.Type != SymbolicValueType.IntegerConstant)
				{
					return Failed();
				}
				return new SymbolicValue((expr.Code == ILCode.Ceq) ? SymbolicValueType.StateEquals : SymbolicValueType.StateInEquals, symbolicValue3.Constant - symbolicValue2.Constant);
			}
			case ILCode.LogicNot:
			{
				SymbolicValue symbolicValue = Eval(expr.Arguments[0]).AsBool();
				if (symbolicValue.Type == SymbolicValueType.StateEquals)
				{
					return new SymbolicValue(SymbolicValueType.StateInEquals, symbolicValue.Constant);
				}
				if (symbolicValue.Type == SymbolicValueType.StateInEquals)
				{
					return new SymbolicValue(SymbolicValueType.StateEquals, symbolicValue.Constant);
				}
				return Failed();
			}
			default:
				return Failed();
			}
		}
	}
}
