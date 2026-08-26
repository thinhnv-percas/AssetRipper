using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public class TypeAnalysis
{
	private sealed class ExpressionToInfer
	{
		public ILExpression Expression;

		public bool Done;

		public ILVariable DependsOnSingleLoad;

		public readonly List<ILVariable> Dependencies = new List<ILVariable>();

		public void Reset(ILExpression expr)
		{
			Expression = expr;
			Done = false;
			DependsOnSingleLoad = null;
			Dependencies.Clear();
		}

		private ExpressionToInfer()
		{
		}

		public static ExpressionToInfer Create(ILExpression expr)
		{
			return new ExpressionToInfer
			{
				Expression = expr
			};
		}

		public override string ToString()
		{
			if (Done)
			{
				return "[Done] " + Expression.ToString();
			}
			return Expression.ToString();
		}
	}

	private readonly List<ExpressionToInfer> expressionToInferList = new List<ExpressionToInfer>();

	private int expressionToInferListIndex;

	private DecompilerContext context;

	private ICorLibTypes typeSystem;

	private ILBlock method;

	private ModuleDef module;

	private readonly List<ExpressionToInfer> allExpressions = new List<ExpressionToInfer>();

	private readonly DefaultDictionary<ILVariable, List<ExpressionToInfer>> assignmentExpressions = new DefaultDictionary<ILVariable, List<ExpressionToInfer>>((ILVariable _) => new List<ExpressionToInfer>());

	private readonly HashSet<ILVariable> singleLoadVariables = new HashSet<ILVariable>();

	private readonly List<ILNode> ilnodes = new List<ILNode>();

	public const int NativeInt = 33;

	public void Run(DecompilerContext context, ILBlock method)
	{
		this.context = context;
		module = context.CurrentMethod.Module;
		typeSystem = module.CorLibTypes;
		this.method = method;
		allExpressions.Clear();
		assignmentExpressions.Clear();
		singleLoadVariables.Clear();
		ilnodes.Clear();
		expressionToInferListIndex = 0;
		CreateDependencyGraph(method);
		IdentifySingleLoadVariables();
		RunInference();
	}

	private ExpressionToInfer CreateExpressionToInfer(ILExpression expr)
	{
		List<ExpressionToInfer> list = expressionToInferList;
		ExpressionToInfer expressionToInfer;
		if (expressionToInferListIndex < list.Count)
		{
			expressionToInfer = list[expressionToInferListIndex];
			expressionToInfer.Reset(expr);
		}
		else
		{
			expressionToInfer = ExpressionToInfer.Create(expr);
			list.Add(expressionToInfer);
		}
		expressionToInferListIndex++;
		return expressionToInfer;
	}

	private void CreateDependencyGraph(ILNode node)
	{
		List<ILNode> list = ilnodes;
		list.Clear();
		list.Add(node);
		while (list.Count > 0)
		{
			node = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			if (node is ILCondition iLCondition)
			{
				iLCondition.Condition.ExpectedType = typeSystem.Boolean;
			}
			else if (node is ILWhileLoop iLWhileLoop)
			{
				if (iLWhileLoop.Condition != null)
				{
					iLWhileLoop.Condition.ExpectedType = typeSystem.Boolean;
				}
			}
			else if (node is ILTryCatchBlock.CatchBlockBase catchBlockBase)
			{
				if (catchBlockBase.ExceptionVariable != null && catchBlockBase.ExceptionType != null && catchBlockBase.ExceptionVariable.Type == null)
				{
					catchBlockBase.ExceptionVariable.Type = catchBlockBase.ExceptionType;
				}
			}
			else if (node is ILExpression iLExpression)
			{
				ExpressionToInfer expressionToInfer = CreateExpressionToInfer(iLExpression);
				allExpressions.Add(expressionToInfer);
				FindNestedAssignments(iLExpression, expressionToInfer);
				if (iLExpression.Code == ILCode.Stloc && iLExpression.Operand is ILVariable && ((ILVariable)iLExpression.Operand).Type == null)
				{
					assignmentExpressions[(ILVariable)iLExpression.Operand].Add(expressionToInfer);
				}
				continue;
			}
			int count = list.Count;
			foreach (ILNode child in node.GetChildren())
			{
				list.Add(child);
			}
			if (list.Count != count)
			{
				list.Reverse(count, list.Count - count);
			}
		}
	}

	private void FindNestedAssignments(ILExpression expr, ExpressionToInfer parent)
	{
		foreach (ILExpression argument in expr.Arguments)
		{
			if (argument.Code == ILCode.Stloc)
			{
				ExpressionToInfer expressionToInfer = CreateExpressionToInfer(argument);
				allExpressions.Add(expressionToInfer);
				FindNestedAssignments(argument, expressionToInfer);
				ILVariable iLVariable = (ILVariable)argument.Operand;
				if (iLVariable.Type == null)
				{
					assignmentExpressions[iLVariable].Add(expressionToInfer);
					parent.Dependencies.Add(iLVariable);
				}
			}
			else
			{
				if (((ILNode)argument).Match(ILCode.Ldloc, out ILVariable operand) && operand.Type == null)
				{
					parent.Dependencies.Add(operand);
				}
				FindNestedAssignments(argument, parent);
			}
		}
	}

	private void IdentifySingleLoadVariables()
	{
		IEnumerable<IGrouping<ILVariable, ExpressionToInfer>> source = from expr in allExpressions
			from v2 in expr.Dependencies
			let v = v2
			group expr by v;
		List<ILExpression> list = null;
		IGrouping<ILVariable, ExpressionToInfer>[] array = source.ToArray();
		foreach (IGrouping<ILVariable, ExpressionToInfer> grouping in array)
		{
			ILVariable v = grouping.Key;
			if (grouping.Count() != 1 || grouping.First().Expression.GetSelfAndChildrenRecursive(list ?? (list = new List<ILExpression>())).Count((ILExpression e) => e.Operand == v) != 1)
			{
				continue;
			}
			singleLoadVariables.Add(v);
			foreach (ExpressionToInfer item in assignmentExpressions[v])
			{
				item.DependsOnSingleLoad = v;
			}
		}
	}

	private void RunInference()
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		while (num < allExpressions.Count)
		{
			int num2 = num;
			foreach (ExpressionToInfer allExpression in allExpressions)
			{
				if (!allExpression.Done && allExpression.Dependencies.TrueForAll((ILVariable v) => v.Type != null || singleLoadVariables.Contains(v)) && ((allExpression.DependsOnSingleLoad == null || allExpression.DependsOnSingleLoad.Type != null) | flag))
				{
					RunInference(allExpression.Expression);
					allExpression.Done = true;
					num++;
				}
			}
			if (num == num2)
			{
				if (!flag)
				{
					flag = true;
					continue;
				}
				if (flag2)
				{
					num++;
				}
				else
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = false;
				flag = false;
			}
			foreach (KeyValuePair<ILVariable, List<ExpressionToInfer>> item in (IEnumerable<KeyValuePair<ILVariable, List<ExpressionToInfer>>>)assignmentExpressions)
			{
				ILVariable key = item.Key;
				if (key.Type != null || !(flag2 ? item.Value.Any((ExpressionToInfer e) => e.Done) : item.Value.All((ExpressionToInfer e) => e.Done)))
				{
					continue;
				}
				TypeSig typeSig = null;
				foreach (ExpressionToInfer item2 in item.Value)
				{
					ILExpression iLExpression = item2.Expression.Arguments.Single();
					if (iLExpression.InferredType != null)
					{
						typeSig = ((typeSig != null) ? TypeWithMoreInformation(typeSig, iLExpression.InferredType) : iLExpression.InferredType);
					}
				}
				if (typeSig == null)
				{
					typeSig = typeSystem.Object;
				}
				key.Type = typeSig;
				foreach (ExpressionToInfer item3 in item.Value)
				{
					item3.Expression.InferredType = typeSig;
					InferTypeForExpression(item3.Expression.Arguments.Single(), typeSig);
				}
			}
		}
	}

	private void RunInference(ILExpression expr)
	{
		bool flag = expr.Arguments.Any((ILExpression a) => a.ExpectedType == null);
		if ((expr.InferredType == null) | flag)
		{
			InferTypeForExpression(expr, expr.ExpectedType, flag);
		}
		foreach (ILExpression argument in expr.Arguments)
		{
			if (argument.Code != ILCode.Stloc)
			{
				RunInference(argument);
			}
		}
	}

	private TypeSig InferTypeForExpression(ILExpression expr, TypeSig expectedType, bool forceInferChildren = false)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		if (expectedType != null && !IsSameType(expr.ExpectedType, expectedType))
		{
			expr.ExpectedType = expectedType;
			if (expr.Code != ILCode.Stloc)
			{
				forceInferChildren = true;
			}
		}
		if (forceInferChildren || expr.InferredType == null)
		{
			expr.InferredType = DoInferTypeForExpression(expr, expectedType, forceInferChildren);
		}
		return expr.InferredType;
	}

	private TypeSig DoInferTypeForExpression(ILExpression expr, TypeSig expectedType, bool forceInferChildren = false)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		switch (expr.Code)
		{
		case ILCode.LogicNot:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments.Single(), typeSystem.Boolean);
			}
			return typeSystem.Boolean;
		case ILCode.LogicAnd:
		case ILCode.LogicOr:
			if (expr.Operand == null)
			{
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], typeSystem.Boolean);
					InferTypeForExpression(expr.Arguments[1], typeSystem.Boolean);
				}
				return typeSystem.Boolean;
			}
			goto case ILCode.Call;
		case ILCode.TernaryOp:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], typeSystem.Boolean);
			}
			return InferBinaryArguments(expr.Arguments[1], expr.Arguments[2], expectedType, forceInferChildren);
		case ILCode.NullCoalescing:
			return InferBinaryArguments(expr.Arguments[0], expr.Arguments[1], expectedType, forceInferChildren);
		case ILCode.Stloc:
		{
			ILVariable iLVariable3 = (ILVariable)expr.Operand;
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments.Single(), iLVariable3.Type);
			}
			return iLVariable3.Type;
		}
		case ILCode.Ldloc:
		{
			ILVariable iLVariable2 = (ILVariable)expr.Operand;
			if (iLVariable2.Type == null && singleLoadVariables.Contains(iLVariable2))
			{
				iLVariable2.Type = expectedType;
			}
			return iLVariable2.Type;
		}
		case ILCode.Ldloca:
		{
			ILVariable iLVariable = (ILVariable)expr.Operand;
			if (iLVariable.Type != null)
			{
				return new ByRefSig(iLVariable.Type);
			}
			return null;
		}
		case ILCode.Call:
		case ILCode.Callvirt:
		case ILCode.CallGetter:
		case ILCode.CallvirtGetter:
		case ILCode.CallSetter:
		case ILCode.CallvirtSetter:
		case ILCode.CallReadOnlySetter:
		{
			IMethod method = expr.Operand as IMethod;
			IList<TypeSig> list = method?.MethodSig.GetParameters();
			if (forceInferChildren && list != null && method.MethodSig != null)
			{
				for (int i = 0; i < expr.Arguments.Count; i++)
				{
					if (i == 0 && method.MethodSig.HasThis)
					{
						InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType(method.DeclaringType.ToTypeSig(), expr.GetPrefix(ILCode.Constrained)));
						continue;
					}
					int num = (method.MethodSig.HasThis ? (i - 1) : i);
					if (num < list.Count)
					{
						InferTypeForExpression(expr.Arguments[i], SubstituteTypeArgs(list[num], null, method));
					}
				}
			}
			if (expr.Code == ILCode.CallSetter || expr.Code == ILCode.CallvirtSetter)
			{
				return SubstituteTypeArgs(list.Last(), null, method);
			}
			return SubstituteTypeArgs(method.MethodSig.GetRetType(), null, method);
		}
		case ILCode.Newobj:
		{
			IMethod method2 = (IMethod)expr.Operand;
			if (forceInferChildren)
			{
				IList<TypeSig> parameters = method2.MethodSig.GetParameters();
				for (int j = 0; j < parameters.Count; j++)
				{
					InferTypeForExpression(expr.Arguments[j], SubstituteTypeArgs(parameters[j], null, method2));
				}
			}
			return method2.DeclaringType.ToTypeSig();
		}
		case ILCode.InitObject:
		case ILCode.InitCollection:
			return InferTypeForExpression(expr.Arguments[0], expectedType);
		case ILCode.InitializedObject:
			return expectedType;
		case ILCode.Ldfld:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType((!(expr.Operand is IField)) ? null : ((IField)expr.Operand).DeclaringType.ToTypeSig(), expr.GetPrefix(ILCode.Constrained)));
			}
			return GetFieldType(expr.Operand as IField);
		case ILCode.Ldsfld:
			return GetFieldType(expr.Operand as IField);
		case ILCode.Ldflda:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType((!(expr.Operand is IField)) ? null : ((IField)expr.Operand).DeclaringType.ToTypeSig(), expr.GetPrefix(ILCode.Constrained)));
			}
			return new ByRefSig(GetFieldType(expr.Operand as IField));
		case ILCode.Ldsflda:
			return new ByRefSig(GetFieldType(expr.Operand as IField));
		case ILCode.Stfld:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType((!(expr.Operand is IField)) ? null : ((IField)expr.Operand).DeclaringType.ToTypeSig(), expr.GetPrefix(ILCode.Constrained)));
				InferTypeForExpression(expr.Arguments[1], GetFieldType(expr.Operand as IField));
			}
			return GetFieldType(expr.Operand as IField);
		case ILCode.Stsfld:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], GetFieldType(expr.Operand as IField));
			}
			return GetFieldType(expr.Operand as IField);
		case ILCode.Ldind_Ref:
			return UnpackPointer(InferTypeForExpression(expr.Arguments[0], null));
		case ILCode.Stind_Ref:
			if (forceInferChildren)
			{
				TypeSig expectedType2 = UnpackPointer(InferTypeForExpression(expr.Arguments[0], null));
				InferTypeForExpression(expr.Arguments[1], expectedType2);
			}
			return null;
		case ILCode.Ldobj:
		{
			TypeSig typeSig4 = ((ITypeDefOrRef)expr.Operand).ToTypeSig();
			TypeSig typeSig5 = InferTypeForExpression(expr.Arguments[0], null);
			if (typeSig5 is PtrSig || typeSig5 is ByRefSig)
			{
				TypeSig next = typeSig5.Next;
				int informationAmount = GetInformationAmount(next);
				if (informationAmount == 1 && GetInformationAmount(typeSig4) == 8)
				{
					typeSig4 = next;
				}
				if (informationAmount >= 8 && informationAmount <= 64 && informationAmount == GetInformationAmount(typeSig4))
				{
					bool? flag = IsSigned(next);
					bool? flag2 = IsSigned(typeSig4);
					if (flag.HasValue && flag2.HasValue && (informationAmount >= 32 || flag == flag2))
					{
						typeSig4 = next;
					}
				}
			}
			if (typeSig5 is PtrSig)
			{
				InferTypeForExpression(expr.Arguments[0], new PtrSig(typeSig4));
			}
			else
			{
				InferTypeForExpression(expr.Arguments[0], new ByRefSig(typeSig4));
			}
			return typeSig4;
		}
		case ILCode.Stobj:
		{
			TypeSig typeSig7 = ((ITypeDefOrRef)expr.Operand).ToTypeSig();
			TypeSig typeSig8 = InferTypeForExpression(expr.Arguments[0], new ByRefSig(typeSig7));
			TypeSig typeSig9 = ((typeSig8 is PtrSig) ? ((PtrSig)typeSig8).Next : ((!(typeSig8 is ByRefSig)) ? null : ((ByRefSig)typeSig8).Next));
			if (typeSig9 != null)
			{
				int informationAmount2 = GetInformationAmount(typeSig9);
				if (informationAmount2 == 1 && GetInformationAmount(typeSig7) == 8)
				{
					typeSig7 = typeSig9;
				}
				else if (informationAmount2 == GetInformationAmount(typeSig7) && IsSigned(typeSig9).HasValue && IsSigned(typeSig7).HasValue)
				{
					typeSig7 = typeSig9;
				}
			}
			if (forceInferChildren)
			{
				if (typeSig8 is PtrSig)
				{
					InferTypeForExpression(expr.Arguments[0], new PtrSig(typeSig7));
				}
				else if (!IsSameType(typeSig7, (expr.Operand as ITypeDefOrRef).ToTypeSig()))
				{
					InferTypeForExpression(expr.Arguments[0], new ByRefSig(typeSig7));
				}
				InferTypeForExpression(expr.Arguments[1], typeSig7);
			}
			return typeSig7;
		}
		case ILCode.Initobj:
			return null;
		case ILCode.DefaultValue:
			return ((ITypeDefOrRef)expr.Operand).ToTypeSig();
		case ILCode.Localloc:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], null);
			}
			if (expectedType is PtrSig)
			{
				return expectedType;
			}
			return typeSystem.IntPtr;
		case ILCode.Sizeof:
			return typeSystem.Int32;
		case ILCode.PostIncrement:
		case ILCode.PostIncrement_Ovf:
		case ILCode.PostIncrement_Ovf_Un:
		{
			TypeSig typeSig14 = UnpackPointer(InferTypeForExpression(expr.Arguments[0], null));
			if (forceInferChildren && typeSig14 != null)
			{
				InferTypeForExpression(expr.Arguments[0], new ByRefSig(typeSig14));
			}
			return typeSig14;
		}
		case ILCode.Mkrefany:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], ((ITypeDefOrRef)expr.Operand).ToTypeSig());
			}
			return typeSystem.TypedReference;
		case ILCode.Refanytype:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], typeSystem.TypedReference);
			}
			return typeSystem.GetTypeRef("System", "RuntimeTypeHandle").ToTypeSig();
		case ILCode.Refanyval:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], typeSystem.TypedReference);
			}
			return new ByRefSig(((ITypeDefOrRef)expr.Operand).ToTypeSig());
		case ILCode.AddressOf:
		{
			TypeSig typeSig11 = InferTypeForExpression(expr.Arguments[0], UnpackPointer(expectedType));
			if (typeSig11 == null)
			{
				return null;
			}
			return new ByRefSig(typeSig11);
		}
		case ILCode.ValueOf:
			return GetNullableTypeArgument(InferTypeForExpression(expr.Arguments[0], CreateNullableType(expectedType)));
		case ILCode.NullableOf:
			return CreateNullableType(InferTypeForExpression(expr.Arguments[0], GetNullableTypeArgument(expectedType)));
		case ILCode.Neg:
		case ILCode.Not:
			return InferTypeForExpression(expr.Arguments.Single(), expectedType);
		case ILCode.Add:
			return InferArgumentsInAddition(expr, null, expectedType);
		case ILCode.Sub:
			return InferArgumentsInSubtraction(expr, null, expectedType);
		case ILCode.Mul:
		case ILCode.And:
		case ILCode.Or:
		case ILCode.Xor:
			return InferArgumentsInBinaryOperator(expr, null, expectedType);
		case ILCode.Add_Ovf:
			return InferArgumentsInAddition(expr, true, expectedType);
		case ILCode.Sub_Ovf:
			return InferArgumentsInSubtraction(expr, true, expectedType);
		case ILCode.Div:
		case ILCode.Rem:
		case ILCode.Mul_Ovf:
			return InferArgumentsInBinaryOperator(expr, true, expectedType);
		case ILCode.Add_Ovf_Un:
			return InferArgumentsInAddition(expr, false, expectedType);
		case ILCode.Sub_Ovf_Un:
			return InferArgumentsInSubtraction(expr, false, expectedType);
		case ILCode.Div_Un:
		case ILCode.Rem_Un:
		case ILCode.Mul_Ovf_Un:
			return InferArgumentsInBinaryOperator(expr, false, expectedType);
		case ILCode.Shl:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
			}
			if (expectedType != null && (expectedType.ElementType == ElementType.I4 || expectedType.ElementType == ElementType.U4 || expectedType.ElementType == ElementType.I8 || expectedType.ElementType == ElementType.U8))
			{
				return NumericPromotion(InferTypeForExpression(expr.Arguments[0], expectedType));
			}
			return NumericPromotion(InferTypeForExpression(expr.Arguments[0], null));
		case ILCode.Shr:
		case ILCode.Shr_Un:
		{
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
			}
			TypeSig typeSig15 = NumericPromotion(InferTypeForExpression(expr.Arguments[0], null));
			if (typeSig15 == null)
			{
				return null;
			}
			TypeSig typeSig16 = null;
			switch (typeSig15.GetElementType())
			{
			case ElementType.I4:
				if (expr.Code == ILCode.Shr_Un)
				{
					typeSig16 = typeSystem.UInt32;
				}
				break;
			case ElementType.U4:
				if (expr.Code == ILCode.Shr)
				{
					typeSig16 = typeSystem.Int32;
				}
				break;
			case ElementType.I8:
				if (expr.Code == ILCode.Shr_Un)
				{
					typeSig16 = typeSystem.UInt64;
				}
				break;
			case ElementType.U8:
				if (expr.Code == ILCode.Shr)
				{
					typeSig16 = typeSystem.UInt64;
				}
				break;
			}
			if (typeSig16 != null)
			{
				InferTypeForExpression(expr.Arguments[0], typeSig16);
				return typeSig16;
			}
			return typeSig15;
		}
		case ILCode.CompoundAssignment:
		{
			ILExpression iLExpression2 = expr.Arguments[0];
			if (iLExpression2.Code == ILCode.NullableOf)
			{
				iLExpression2 = iLExpression2.Arguments[0].Arguments[0];
			}
			TypeSig typeSig13 = InferTypeForExpression(iLExpression2.Arguments[0], null);
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], typeSig13);
			}
			return typeSig13;
		}
		case ILCode.Ldnull:
			return typeSystem.Object;
		case ILCode.Ldstr:
			return typeSystem.String;
		case ILCode.Ldftn:
		case ILCode.Ldvirtftn:
			return typeSystem.IntPtr;
		case ILCode.Ldc_I4:
			if (expectedType.GetElementType() == ElementType.Boolean && ((int)expr.Operand == 0 || (int)expr.Operand == 1))
			{
				return typeSystem.Boolean;
			}
			if (expectedType is PtrSig && (int)expr.Operand == 0)
			{
				return expectedType;
			}
			if (IsIntegerOrEnum(expectedType) && OperandFitsInType(expectedType, (int)expr.Operand))
			{
				return expectedType;
			}
			return typeSystem.Int32;
		case ILCode.Ldc_I8:
			if (expectedType is PtrSig && (long)expr.Operand == 0L)
			{
				return expectedType;
			}
			if (IsIntegerOrEnum(expectedType) && GetInformationAmount(expectedType) >= 33)
			{
				return expectedType;
			}
			return typeSystem.Int64;
		case ILCode.Ldc_R4:
			return typeSystem.Single;
		case ILCode.Ldc_R8:
			return typeSystem.Double;
		case ILCode.Ldc_Decimal:
			return typeSystem.GetTypeRef("System", "Decimal").ToTypeSig();
		case ILCode.Ldtoken:
			if (expr.Operand is ITypeDefOrRef)
			{
				return typeSystem.GetTypeRef("System", "RuntimeTypeHandle").ToTypeSig();
			}
			if ((expr.Operand as IField)?.FieldSig != null)
			{
				return typeSystem.GetTypeRef("System", "RuntimeFieldHandle").ToTypeSig();
			}
			return typeSystem.GetTypeRef("System", "RuntimeMethodHandle").ToTypeSig();
		case ILCode.Arglist:
			return typeSystem.GetTypeRef("System", "RuntimeArgumentHandle").ToTypeSig();
		case ILCode.Newarr:
			if (forceInferChildren)
			{
				TypeSig typeSig3 = InferTypeForExpression(expr.Arguments.Single(), null);
				if (default(SigComparer).Equals(typeSig3, typeSystem.IntPtr))
				{
					typeSig3 = typeSystem.Int64;
				}
				else if (default(SigComparer).Equals(typeSig3, typeSystem.UIntPtr))
				{
					typeSig3 = typeSystem.UInt64;
				}
				else if (!default(SigComparer).Equals(typeSig3, typeSystem.UInt32) && !default(SigComparer).Equals(typeSig3, typeSystem.Int64) && !default(SigComparer).Equals(typeSig3, typeSystem.UInt64))
				{
					typeSig3 = typeSystem.Int32;
				}
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments.Single(), typeSig3);
				}
			}
			return new SZArraySig(((ITypeDefOrRef)expr.Operand).ToTypeSig());
		case ILCode.InitArray:
		{
			TypeSig typeSig17 = ((ITypeDefOrRef)expr.Operand).ToTypeSig();
			if (forceInferChildren)
			{
				foreach (ILExpression argument in expr.Arguments)
				{
					InferTypeForExpression(argument, typeSig17.Next);
				}
			}
			return typeSig17;
		}
		case ILCode.Ldlen:
			return typeSystem.Int32;
		case ILCode.Ldelem_I1:
		case ILCode.Ldelem_U1:
		case ILCode.Ldelem_I2:
		case ILCode.Ldelem_U2:
		case ILCode.Ldelem_I4:
		case ILCode.Ldelem_U4:
		case ILCode.Ldelem_I8:
		case ILCode.Ldelem_I:
		case ILCode.Ldelem_R4:
		case ILCode.Ldelem_R8:
		case ILCode.Ldelem_Ref:
		{
			SZArraySig sZArraySig3 = InferTypeForExpression(expr.Arguments[0], null) as SZArraySig;
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
			}
			return sZArraySig3?.Next;
		}
		case ILCode.Ldelem:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
			}
			return ((ITypeDefOrRef)expr.Operand).ToTypeSig();
		case ILCode.Ldelema:
		{
			SZArraySig sZArraySig2 = InferTypeForExpression(expr.Arguments[0], null) as SZArraySig;
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
			}
			if (sZArraySig2 == null)
			{
				return null;
			}
			return new ByRefSig(sZArraySig2.Next);
		}
		case ILCode.Stelem_I:
		case ILCode.Stelem_I1:
		case ILCode.Stelem_I2:
		case ILCode.Stelem_I4:
		case ILCode.Stelem_I8:
		case ILCode.Stelem_R4:
		case ILCode.Stelem_R8:
		case ILCode.Stelem_Ref:
		case ILCode.Stelem:
		{
			SZArraySig sZArraySig = InferTypeForExpression(expr.Arguments[0], null) as SZArraySig;
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
				if (sZArraySig != null)
				{
					InferTypeForExpression(expr.Arguments[2], sZArraySig.Next);
				}
			}
			return sZArraySig?.Next;
		}
		case ILCode.Conv_I1:
		case ILCode.Conv_Ovf_I1_Un:
		case ILCode.Conv_Ovf_I1:
			return HandleConversion(8, targetSigned: true, expr.Arguments[0], expectedType, typeSystem.SByte);
		case ILCode.Conv_I2:
		case ILCode.Conv_Ovf_I2_Un:
		case ILCode.Conv_Ovf_I2:
			return HandleConversion(16, targetSigned: true, expr.Arguments[0], expectedType, typeSystem.Int16);
		case ILCode.Conv_I4:
		case ILCode.Conv_Ovf_I4_Un:
		case ILCode.Conv_Ovf_I4:
			return HandleConversion(32, targetSigned: true, expr.Arguments[0], expectedType, typeSystem.Int32);
		case ILCode.Conv_I8:
		case ILCode.Conv_Ovf_I8_Un:
		case ILCode.Conv_Ovf_I8:
			return HandleConversion(64, targetSigned: true, expr.Arguments[0], expectedType, typeSystem.Int64);
		case ILCode.Conv_Ovf_U1_Un:
		case ILCode.Conv_Ovf_U1:
		case ILCode.Conv_U1:
			return HandleConversion(8, targetSigned: false, expr.Arguments[0], expectedType, typeSystem.Byte);
		case ILCode.Conv_Ovf_U2_Un:
		case ILCode.Conv_Ovf_U2:
		case ILCode.Conv_U2:
			return HandleConversion(16, targetSigned: false, expr.Arguments[0], expectedType, typeSystem.UInt16);
		case ILCode.Conv_U4:
		case ILCode.Conv_Ovf_U4_Un:
		case ILCode.Conv_Ovf_U4:
			return HandleConversion(32, targetSigned: false, expr.Arguments[0], expectedType, typeSystem.UInt32);
		case ILCode.Conv_U8:
		case ILCode.Conv_Ovf_U8_Un:
		case ILCode.Conv_Ovf_U8:
			return HandleConversion(64, targetSigned: false, expr.Arguments[0], expectedType, typeSystem.UInt64);
		case ILCode.Conv_Ovf_I_Un:
		case ILCode.Conv_I:
		case ILCode.Conv_Ovf_I:
			return HandleConversion(33, targetSigned: true, expr.Arguments[0], expectedType, typeSystem.IntPtr);
		case ILCode.Conv_Ovf_U_Un:
		case ILCode.Conv_Ovf_U:
		case ILCode.Conv_U:
			return HandleConversion(33, targetSigned: false, expr.Arguments[0], expectedType, typeSystem.UIntPtr);
		case ILCode.Conv_R4:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], typeSystem.Single);
			}
			return typeSystem.Single;
		case ILCode.Conv_R8:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments[0], typeSystem.Double);
			}
			return typeSystem.Double;
		case ILCode.Conv_R_Un:
			if (expectedType == null || expectedType.ElementType != ElementType.R4)
			{
				return typeSystem.Double;
			}
			return typeSystem.Single;
		case ILCode.Castclass:
		case ILCode.Unbox_Any:
			return ((ITypeDefOrRef)expr.Operand).ToTypeSig();
		case ILCode.Unbox:
			return new ByRefSig(((ITypeDefOrRef)expr.Operand).ToTypeSig());
		case ILCode.Isinst:
		{
			TypeSig typeSig12 = ((ITypeDefOrRef)expr.Operand).ToTypeSig();
			if (!DnlibExtensions.IsValueType(typeSig12))
			{
				return typeSig12;
			}
			return typeSystem.Object;
		}
		case ILCode.Box:
		{
			TypeSig typeSig10 = ((ITypeDefOrRef)expr.Operand).ToTypeSig();
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments.Single(), typeSig10);
			}
			if (!DnlibExtensions.IsValueType(typeSig10))
			{
				return typeSig10;
			}
			return typeSystem.Object;
		}
		case ILCode.Cnull:
		case ILCode.Cnotnull:
			return typeSystem.Boolean;
		case ILCode.Ceq:
		case ILCode.Cne:
			if (forceInferChildren)
			{
				InferArgumentsInBinaryOperator(expr, null, null);
			}
			return typeSystem.Boolean;
		case ILCode.Cgt:
		case ILCode.Clt:
		case ILCode.Cge:
		case ILCode.Cle:
			if (forceInferChildren)
			{
				InferArgumentsInBinaryOperator(expr, true, null);
			}
			return typeSystem.Boolean;
		case ILCode.Cgt_Un:
		case ILCode.Clt_Un:
		case ILCode.Cge_Un:
		case ILCode.Cle_Un:
			if (forceInferChildren)
			{
				InferArgumentsInBinaryOperator(expr, false, null);
			}
			return typeSystem.Boolean;
		case ILCode.Brtrue:
		case ILCode.Endfilter:
			if (forceInferChildren)
			{
				InferTypeForExpression(expr.Arguments.Single(), typeSystem.Boolean);
			}
			return null;
		case ILCode.Br:
		case ILCode.Switch:
		case ILCode.Throw:
		case ILCode.Endfinally:
		case ILCode.Leave:
		case ILCode.Rethrow:
		case ILCode.LoopOrSwitchBreak:
		case ILCode.LoopContinue:
		case ILCode.YieldBreak:
			return null;
		case ILCode.Ret:
			if (forceInferChildren && expr.Arguments.Count == 1)
			{
				TypeSig typeSig6 = context.CurrentMethod.ReturnType;
				if (context.CurrentMethodIsAsync && typeSig6 != null && typeSig6.Namespace == "System.Threading.Tasks")
				{
					if (typeSig6.TypeName == "Task")
					{
						typeSig6 = typeSystem.Void;
					}
					else if (typeSig6.TypeName == "Task`1" && typeSig6.IsGenericInstanceType)
					{
						typeSig6 = ((GenericInstSig)typeSig6).GenericArguments[0];
					}
				}
				InferTypeForExpression(expr.Arguments[0], typeSig6);
			}
			return null;
		case ILCode.YieldReturn:
			if (forceInferChildren)
			{
				if (context.CurrentMethod.ReturnType is GenericInstSig genericInstSig)
				{
					InferTypeForExpression(expr.Arguments[0], genericInstSig.GenericArguments[0]);
				}
				else
				{
					InferTypeForExpression(expr.Arguments[0], typeSystem.Object);
				}
			}
			return null;
		case ILCode.Await:
		{
			TypeSig typeSig2 = InferTypeForExpression(expr.Arguments[0], null);
			if (typeSig2 != null && typeSig2.TypeName == "Task`1" && typeSig2.IsGenericInstanceType && typeSig2.Namespace == "System.Threading.Tasks")
			{
				return ((GenericInstSig)typeSig2).GenericArguments[0];
			}
			return null;
		}
		case ILCode.Pop:
			return null;
		case ILCode.Dup:
		case ILCode.Wrap:
		{
			ILExpression iLExpression = expr.Arguments.Single();
			return iLExpression.ExpectedType = InferTypeForExpression(iLExpression, expectedType);
		}
		default:
			return null;
		}
	}

	private TypeSig MakeRefIfValueType(TypeSig type, ILExpressionPrefix constrainedPrefix)
	{
		if (constrainedPrefix != null)
		{
			return new ByRefSig((constrainedPrefix.Operand as ITypeDefOrRef).ToTypeSig());
		}
		if (DnlibExtensions.IsValueType(type))
		{
			return new ByRefSig(type);
		}
		return type;
	}

	private TypeSig NumericPromotion(TypeSig type)
	{
		if (type == null)
		{
			return null;
		}
		ElementType elementType = type.ElementType;
		if (elementType - 4 <= ElementType.Char)
		{
			return typeSystem.Int32;
		}
		return type;
	}

	private TypeSig HandleConversion(int targetBitSize, bool targetSigned, ILExpression arg, TypeSig expectedType, TypeSig targetType)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		if (targetBitSize >= 33 && expectedType is PtrSig)
		{
			InferTypeForExpression(arg, expectedType);
			return expectedType;
		}
		TypeSig typeSig = InferTypeForExpression(arg, null);
		if (targetBitSize >= 33 && typeSig is ByRefSig)
		{
			PtrSig ptrSig = new PtrSig(((ByRefSig)typeSig).Next);
			InferTypeForExpression(arg, ptrSig);
			return ptrSig;
		}
		if (targetBitSize >= 33 && typeSig is PtrSig)
		{
			return typeSig;
		}
		return arg.ExpectedType = ((GetInformationAmount(expectedType) == targetBitSize && IsSigned(expectedType) == targetSigned) ? expectedType : targetType);
	}

	public static TypeSig GetFieldType(IField field)
	{
		return SubstituteTypeArgs(field?.FieldSig?.Type.RemoveModifiers(), field?.DeclaringType.ToTypeSig());
	}

	public static TypeSig SubstituteTypeArgs(TypeSig type, TypeSig typeContext = null, IMethod method = null)
	{
		IList<TypeSig> typeGenArgs = null;
		IList<TypeSig> methodGenArgs = null;
		if (typeContext == null)
		{
			typeContext = method.DeclaringType.ToTypeSig();
		}
		if (typeContext is GenericInstSig)
		{
			typeGenArgs = ((GenericInstSig)typeContext).GenericArguments;
		}
		if (method is MethodSpec { GenericInstMethodSig: not null } methodSpec)
		{
			methodGenArgs = methodSpec.GenericInstMethodSig.GenericArguments;
		}
		return GenericArgumentResolver.Resolve(type, typeGenArgs, methodGenArgs);
	}

	private static TypeSig UnpackPointer(TypeSig pointerOrManagedReference)
	{
		if (pointerOrManagedReference is ByRefSig || pointerOrManagedReference is PtrSig)
		{
			return pointerOrManagedReference.Next;
		}
		return null;
	}

	private static TypeSig GetNullableTypeArgument(TypeSig type)
	{
		GenericInstSig genericInstSig = type as GenericInstSig;
		if (!IsNullableType(genericInstSig))
		{
			return type;
		}
		return genericInstSig.GenericArguments[0];
	}

	private TypeSig CreateNullableType(TypeSig type)
	{
		if (type == null)
		{
			return null;
		}
		GenericInstSig genericInstSig = new GenericInstSig((ClassOrValueTypeSig)typeSystem.GetTypeRef("System", "Nullable`1").ToTypeSig());
		genericInstSig.GenericArguments.Add(type);
		return genericInstSig;
	}

	private TypeSig InferArgumentsInBinaryOperator(ILExpression expr, bool? isSigned, TypeSig expectedType)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		return InferBinaryArguments(expr.Arguments[0], expr.Arguments[1], expectedType);
	}

	private TypeSig InferArgumentsInAddition(ILExpression expr, bool? isSigned, TypeSig expectedType)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		ILExpression iLExpression = expr.Arguments[0];
		ILExpression iLExpression2 = expr.Arguments[1];
		TypeSig typeSig = DoInferTypeForExpression(iLExpression, expectedType);
		if (typeSig is PtrSig)
		{
			TypeSig inferredType = (iLExpression.ExpectedType = typeSig);
			iLExpression.InferredType = inferredType;
			InferTypeForExpression(iLExpression2, null);
			return typeSig;
		}
		if (IsEnum(typeSig))
		{
			TypeSig inferredType = (iLExpression.ExpectedType = typeSig);
			iLExpression.InferredType = inferredType;
			InferTypeForExpression(iLExpression2, GetEnumUnderlyingType(typeSig));
			return typeSig;
		}
		TypeSig typeSig4 = DoInferTypeForExpression(iLExpression2, expectedType);
		if (typeSig4 is PtrSig)
		{
			InferTypeForExpression(iLExpression, null);
			TypeSig inferredType = (iLExpression2.ExpectedType = typeSig4);
			iLExpression2.InferredType = inferredType;
			return typeSig4;
		}
		if (IsEnum(typeSig4))
		{
			TypeSig inferredType = (iLExpression2.ExpectedType = typeSig4);
			iLExpression2.InferredType = inferredType;
			InferTypeForExpression(iLExpression, GetEnumUnderlyingType(typeSig4));
			return typeSig4;
		}
		return InferBinaryArguments(iLExpression, iLExpression2, expectedType, forceInferChildren: false, typeSig, typeSig4);
	}

	private TypeSig InferArgumentsInSubtraction(ILExpression expr, bool? isSigned, TypeSig expectedType)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		ILExpression iLExpression = expr.Arguments[0];
		ILExpression iLExpression2 = expr.Arguments[1];
		TypeSig typeSig = DoInferTypeForExpression(iLExpression, expectedType);
		if (typeSig is PtrSig)
		{
			TypeSig inferredType = (iLExpression.ExpectedType = typeSig);
			iLExpression.InferredType = inferredType;
			TypeSig typeSig3 = InferTypeForExpression(iLExpression2, null);
			if (typeSig3 is PtrSig)
			{
				return typeSystem.IntPtr;
			}
			return typeSig;
		}
		if (IsEnum(typeSig))
		{
			TypeSig inferredType;
			if (expectedType != null && IsEnum(expectedType))
			{
				inferredType = (iLExpression.ExpectedType = typeSig);
				iLExpression.InferredType = inferredType;
				InferTypeForExpression(iLExpression2, GetEnumUnderlyingType(typeSig));
				return typeSig;
			}
			inferredType = (iLExpression.ExpectedType = typeSig);
			iLExpression.InferredType = inferredType;
			InferTypeForExpression(iLExpression2, typeSig);
			return GetEnumUnderlyingType(typeSig);
		}
		return InferBinaryArguments(iLExpression, iLExpression2, expectedType, forceInferChildren: false, typeSig);
	}

	private TypeSig InferBinaryArguments(ILExpression left, ILExpression right, TypeSig expectedType, bool forceInferChildren = false, TypeSig leftPreferred = null, TypeSig rightPreferred = null)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		if (leftPreferred == null)
		{
			leftPreferred = DoInferTypeForExpression(left, expectedType, forceInferChildren);
		}
		if (rightPreferred == null)
		{
			rightPreferred = DoInferTypeForExpression(right, expectedType, forceInferChildren);
		}
		if (IsSameType(leftPreferred, rightPreferred))
		{
			TypeSig typeSig = (right.ExpectedType = leftPreferred);
			TypeSig typeSig3 = (left.ExpectedType = typeSig);
			TypeSig typeSig5 = (right.InferredType = typeSig3);
			return left.InferredType = typeSig5;
		}
		if (IsSameType(rightPreferred, DoInferTypeForExpression(left, rightPreferred, forceInferChildren)))
		{
			TypeSig typeSig = (right.ExpectedType = rightPreferred);
			TypeSig typeSig3 = (left.ExpectedType = typeSig);
			TypeSig typeSig5 = (right.InferredType = typeSig3);
			return left.InferredType = typeSig5;
		}
		if (IsSameType(leftPreferred, DoInferTypeForExpression(right, leftPreferred, forceInferChildren)))
		{
			DoInferTypeForExpression(left, leftPreferred, forceInferChildren);
			TypeSig typeSig = (right.ExpectedType = leftPreferred);
			TypeSig typeSig3 = (left.ExpectedType = typeSig);
			TypeSig typeSig5 = (right.InferredType = typeSig3);
			return left.InferredType = typeSig5;
		}
		TypeSig expectedType2 = (right.ExpectedType = TypeWithMoreInformation(leftPreferred, rightPreferred));
		left.ExpectedType = expectedType2;
		left.InferredType = DoInferTypeForExpression(left, left.ExpectedType, forceInferChildren);
		right.InferredType = DoInferTypeForExpression(right, right.ExpectedType, forceInferChildren);
		return left.ExpectedType;
	}

	private TypeSig TypeWithMoreInformation(TypeSig leftPreferred, TypeSig rightPreferred)
	{
		int informationAmount = GetInformationAmount(leftPreferred);
		int informationAmount2 = GetInformationAmount(rightPreferred);
		if (informationAmount < informationAmount2)
		{
			return rightPreferred;
		}
		return leftPreferred;
	}

	public static TypeSig GetEnumUnderlyingType(TypeSig enumType)
	{
		if (enumType != null && !IsArrayPointerOrReference(enumType))
		{
			TypeDef typeDef = enumType.Resolve();
			if (typeDef != null && typeDef.IsEnum)
			{
				return typeDef.GetEnumUnderlyingType().RemovePinnedAndModifiers();
			}
		}
		return null;
	}

	public static int GetInformationAmount(TypeSig type)
	{
		type = GetEnumUnderlyingType(type) ?? type;
		if (type == null)
		{
			return 0;
		}
		switch (type.ElementType)
		{
		case ElementType.Void:
			return 0;
		case ElementType.Boolean:
			return 1;
		case ElementType.I1:
		case ElementType.U1:
			return 8;
		case ElementType.Char:
		case ElementType.I2:
		case ElementType.U2:
			return 16;
		case ElementType.I4:
		case ElementType.U4:
		case ElementType.R4:
			return 32;
		case ElementType.I8:
		case ElementType.U8:
		case ElementType.R8:
			return 64;
		case ElementType.I:
		case ElementType.U:
			return 33;
		default:
			return 100;
		}
	}

	public static bool IsIntegerOrEnum(TypeSig type)
	{
		return IsSigned(type).HasValue;
	}

	public static bool IsEnum(TypeSig type)
	{
		if (type == null || IsArrayPointerOrReference(type))
		{
			return false;
		}
		TypeSig type2 = type.RemovePinnedAndModifiers();
		return type2.Resolve()?.IsEnum ?? false;
	}

	private static bool? IsSigned(TypeSig type)
	{
		type = GetEnumUnderlyingType(type) ?? type;
		if (type == null)
		{
			return null;
		}
		switch (type.ElementType)
		{
		case ElementType.I1:
		case ElementType.I2:
		case ElementType.I4:
		case ElementType.I8:
		case ElementType.I:
			return true;
		case ElementType.Char:
		case ElementType.U1:
		case ElementType.U2:
		case ElementType.U4:
		case ElementType.U8:
		case ElementType.U:
			return false;
		default:
			return null;
		}
	}

	private static bool OperandFitsInType(TypeSig type, int num)
	{
		type = GetEnumUnderlyingType(type) ?? type;
		switch (type.GetElementType())
		{
		case ElementType.I1:
			if (-128 <= num)
			{
				return num <= 127;
			}
			return false;
		case ElementType.I2:
			if (-32768 <= num)
			{
				return num <= 32767;
			}
			return false;
		case ElementType.U1:
			if (0 <= num)
			{
				return num <= 255;
			}
			return false;
		case ElementType.Char:
			if (0 <= num)
			{
				return num <= 65535;
			}
			return false;
		case ElementType.U2:
			if (0 <= num)
			{
				return num <= 65535;
			}
			return false;
		default:
			return true;
		}
	}

	private static bool IsArrayPointerOrReference(TypeSig type)
	{
		while (type != null)
		{
			if (type is ArraySigBase || type is PtrSig || type is ByRefSig)
			{
				return true;
			}
			type = type.Next;
		}
		return false;
	}

	internal static bool IsNullableType(TypeSig type)
	{
		if (type is TypeDefOrRefSig typeDefOrRefSig)
		{
			if (typeDefOrRefSig.TypeDefOrRef != null && typeDefOrRefSig.TypeDefOrRef.Name == "Nullable`1")
			{
				return typeDefOrRefSig.TypeDefOrRef.Namespace == "System";
			}
			return false;
		}
		if (type is GenericInstSig)
		{
			return IsNullableType(((GenericInstSig)type).GenericType);
		}
		return false;
	}

	public static TypeCode GetTypeCode(TypeSig type)
	{
		if (type == null)
		{
			return TypeCode.Empty;
		}
		return type.RemovePinnedAndModifiers().GetElementType() switch
		{
			ElementType.Boolean => TypeCode.Boolean, 
			ElementType.Char => TypeCode.Char, 
			ElementType.I1 => TypeCode.SByte, 
			ElementType.U1 => TypeCode.Byte, 
			ElementType.I2 => TypeCode.Int16, 
			ElementType.U2 => TypeCode.UInt16, 
			ElementType.I4 => TypeCode.Int32, 
			ElementType.U4 => TypeCode.UInt32, 
			ElementType.I8 => TypeCode.Int64, 
			ElementType.U8 => TypeCode.UInt64, 
			ElementType.R4 => TypeCode.Single, 
			ElementType.R8 => TypeCode.Double, 
			ElementType.String => TypeCode.String, 
			_ => TypeCode.Object, 
		};
	}

	public static void Reset(ILBlock method, List<ILExpression> list_ILExpression)
	{
		foreach (ILExpression item in method.GetSelfAndChildrenRecursive(list_ILExpression))
		{
			item.InferredType = null;
			item.ExpectedType = null;
			if (item.Operand is ILVariable { GeneratedByDecompiler: not false } iLVariable)
			{
				iLVariable.Type = iLVariable.OriginalParameter?.Type ?? iLVariable.OriginalVariable?.Type;
			}
		}
	}

	public static bool IsSameType(IType type1, IType type2)
	{
		if (type1 == type2)
		{
			return true;
		}
		if (type1 == null || type2 == null)
		{
			return false;
		}
		return default(SigComparer).Equals(type1, type2);
	}
}
