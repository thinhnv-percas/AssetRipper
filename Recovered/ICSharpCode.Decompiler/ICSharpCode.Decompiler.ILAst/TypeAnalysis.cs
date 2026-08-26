using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public class TypeAnalysis
	{
		private sealed class ExpressionToInfer
		{
			public ILExpression Expression;

			public bool Done;

			public ILVariable DependsOnSingleLoad;

			public List<ILVariable> Dependencies = new List<ILVariable>();

			public override string ToString()
			{
				if (Done)
				{
					return "[Done] " + Expression.ToString();
				}
				return Expression.ToString();
			}
		}

		private DecompilerContext context;

		private TypeSystem typeSystem;

		private ILBlock method;

		private ModuleDefinition module;

		private List<ExpressionToInfer> allExpressions = new List<ExpressionToInfer>();

		private DefaultDictionary<ILVariable, List<ExpressionToInfer>> assignmentExpressions = new DefaultDictionary<ILVariable, List<ExpressionToInfer>>((ILVariable _) => new List<ExpressionToInfer>());

		private HashSet<ILVariable> singleLoadVariables = new HashSet<ILVariable>();

		public const int NativeInt = 33;

		public static void Run(DecompilerContext context, ILBlock method)
		{
			TypeAnalysis typeAnalysis = new TypeAnalysis();
			typeAnalysis.context = context;
			typeAnalysis.module = context.CurrentMethod.Module;
			typeAnalysis.typeSystem = typeAnalysis.module.TypeSystem;
			typeAnalysis.method = method;
			typeAnalysis.CreateDependencyGraph(method);
			typeAnalysis.IdentifySingleLoadVariables();
			typeAnalysis.RunInference();
		}

		private void CreateDependencyGraph(ILNode node)
		{
			ILCondition iLCondition = node as ILCondition;
			if (iLCondition != null)
			{
				iLCondition.Condition.ExpectedType = typeSystem.Boolean;
			}
			ILWhileLoop iLWhileLoop = node as ILWhileLoop;
			if (iLWhileLoop != null && iLWhileLoop.Condition != null)
			{
				iLWhileLoop.Condition.ExpectedType = typeSystem.Boolean;
			}
			ILTryCatchBlock.CatchBlock catchBlock = node as ILTryCatchBlock.CatchBlock;
			if (catchBlock != null && catchBlock.ExceptionVariable != null && catchBlock.ExceptionType != null && catchBlock.ExceptionVariable.Type == null)
			{
				catchBlock.ExceptionVariable.Type = catchBlock.ExceptionType;
			}
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null)
			{
				ExpressionToInfer expressionToInfer = new ExpressionToInfer();
				expressionToInfer.Expression = iLExpression;
				allExpressions.Add(expressionToInfer);
				FindNestedAssignments(iLExpression, expressionToInfer);
				if (iLExpression.Code == ILCode.Stloc && ((ILVariable)iLExpression.Operand).Type == null)
				{
					assignmentExpressions[(ILVariable)iLExpression.Operand].Add(expressionToInfer);
				}
			}
			else
			{
				foreach (ILNode child in node.GetChildren())
				{
					CreateDependencyGraph(child);
				}
			}
		}

		private void FindNestedAssignments(ILExpression expr, ExpressionToInfer parent)
		{
			foreach (ILExpression argument in expr.Arguments)
			{
				if (argument.Code == ILCode.Stloc)
				{
					ExpressionToInfer expressionToInfer = new ExpressionToInfer();
					expressionToInfer.Expression = argument;
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
					if (argument.Match(ILCode.Ldloc, out ILVariable operand) && operand.Type == null)
					{
						parent.Dependencies.Add(operand);
					}
					FindNestedAssignments(argument, parent);
				}
			}
		}

		private void IdentifySingleLoadVariables()
		{
			IGrouping<ILVariable, ExpressionToInfer>[] array = (from expr in allExpressions
				from v in expr.Dependencies
				group expr by v).ToArray();
			foreach (IGrouping<ILVariable, ExpressionToInfer> grouping in array)
			{
				ILVariable v2 = grouping.Key;
				if (grouping.Count() == 1 && grouping.Single().Expression.GetSelfAndChildrenRecursive<ILExpression>().Count((ILExpression e) => e.Operand == v2) == 1)
				{
					singleLoadVariables.Add(v2);
					foreach (ExpressionToInfer item in assignmentExpressions[v2])
					{
						item.DependsOnSingleLoad = v2;
					}
				}
			}
		}

		private void RunInference()
		{
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			while (true)
			{
				if (num >= allExpressions.Count)
				{
					return;
				}
				int num2 = num;
				foreach (ExpressionToInfer allExpression in allExpressions)
				{
					if (!allExpression.Done && allExpression.Dependencies.TrueForAll((ILVariable v) => (v.Type == null) ? singleLoadVariables.Contains(v) : true) && ((allExpression.DependsOnSingleLoad == null || allExpression.DependsOnSingleLoad.Type != null) | flag))
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
						break;
					}
					flag2 = true;
				}
				else
				{
					flag2 = false;
					flag = false;
				}
				foreach (KeyValuePair<ILVariable, List<ExpressionToInfer>> item in (IEnumerable<KeyValuePair<ILVariable, List<ExpressionToInfer>>>)assignmentExpressions)
				{
					ILVariable key = item.Key;
					if (key.Type == null && (flag2 ? item.Value.Any((ExpressionToInfer e) => e.Done) : item.Value.All((ExpressionToInfer e) => e.Done)))
					{
						TypeReference typeReference = null;
						foreach (ExpressionToInfer item2 in item.Value)
						{
							ILExpression iLExpression = item2.Expression.Arguments.Single();
							if (iLExpression.InferredType != null)
							{
								typeReference = ((typeReference != null) ? TypeWithMoreInformation(typeReference, iLExpression.InferredType) : iLExpression.InferredType);
							}
						}
						if (typeReference == null)
						{
							typeReference = typeSystem.Object;
						}
						key.Type = typeReference;
						foreach (ExpressionToInfer item3 in item.Value)
						{
							item3.Expression.InferredType = typeReference;
							InferTypeForExpression(item3.Expression.Arguments.Single(), typeReference);
						}
					}
				}
			}
			throw new InvalidOperationException("Could not infer any expression");
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

		private TypeReference InferTypeForExpression(ILExpression expr, TypeReference expectedType, bool forceInferChildren = false)
		{
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

		private TypeReference DoInferTypeForExpression(ILExpression expr, TypeReference expectedType, bool forceInferChildren = false)
		{
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
				ILVariable iLVariable = (ILVariable)expr.Operand;
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments.Single(), iLVariable.Type);
				}
				return iLVariable.Type;
			}
			case ILCode.Ldloc:
			{
				ILVariable iLVariable3 = (ILVariable)expr.Operand;
				if (iLVariable3.Type == null && singleLoadVariables.Contains(iLVariable3))
				{
					iLVariable3.Type = expectedType;
				}
				return iLVariable3.Type;
			}
			case ILCode.Ldloca:
			{
				ILVariable iLVariable2 = (ILVariable)expr.Operand;
				if (iLVariable2.Type != null)
				{
					return new ByReferenceType(iLVariable2.Type);
				}
				return null;
			}
			case ILCode.Call:
			case ILCode.Callvirt:
			case ILCode.CallGetter:
			case ILCode.CallvirtGetter:
			case ILCode.CallSetter:
			case ILCode.CallvirtSetter:
			{
				MethodReference methodReference2 = (MethodReference)expr.Operand;
				if (forceInferChildren)
				{
					for (int j = 0; j < expr.Arguments.Count; j++)
					{
						if (j == 0 && methodReference2.HasThis)
						{
							InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType(methodReference2.DeclaringType, expr.GetPrefix(ILCode.Constrained)));
						}
						else
						{
							InferTypeForExpression(expr.Arguments[j], SubstituteTypeArgs(methodReference2.Parameters[methodReference2.HasThis ? (j - 1) : j].ParameterType, methodReference2));
						}
					}
				}
				if (expr.Code == ILCode.CallSetter || expr.Code == ILCode.CallvirtSetter)
				{
					return SubstituteTypeArgs(methodReference2.Parameters.Last().ParameterType, methodReference2);
				}
				return SubstituteTypeArgs(methodReference2.ReturnType, methodReference2);
			}
			case ILCode.Newobj:
			{
				MethodReference methodReference = (MethodReference)expr.Operand;
				if (forceInferChildren)
				{
					for (int i = 0; i < methodReference.Parameters.Count; i++)
					{
						InferTypeForExpression(expr.Arguments[i], SubstituteTypeArgs(methodReference.Parameters[i].ParameterType, methodReference));
					}
				}
				return methodReference.DeclaringType;
			}
			case ILCode.InitObject:
			case ILCode.InitCollection:
				return InferTypeForExpression(expr.Arguments[0], expectedType);
			case ILCode.InitializedObject:
				return expectedType;
			case ILCode.Ldfld:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType(((FieldReference)expr.Operand).DeclaringType, expr.GetPrefix(ILCode.Constrained)));
				}
				return GetFieldType((FieldReference)expr.Operand);
			case ILCode.Ldsfld:
				return GetFieldType((FieldReference)expr.Operand);
			case ILCode.Ldflda:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType(((FieldReference)expr.Operand).DeclaringType, expr.GetPrefix(ILCode.Constrained)));
				}
				return new ByReferenceType(GetFieldType((FieldReference)expr.Operand));
			case ILCode.Ldsflda:
				return new ByReferenceType(GetFieldType((FieldReference)expr.Operand));
			case ILCode.Stfld:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], MakeRefIfValueType(((FieldReference)expr.Operand).DeclaringType, expr.GetPrefix(ILCode.Constrained)));
					InferTypeForExpression(expr.Arguments[1], GetFieldType((FieldReference)expr.Operand));
				}
				return GetFieldType((FieldReference)expr.Operand);
			case ILCode.Stsfld:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], GetFieldType((FieldReference)expr.Operand));
				}
				return GetFieldType((FieldReference)expr.Operand);
			case ILCode.Ldind_Ref:
				return UnpackPointer(InferTypeForExpression(expr.Arguments[0], null));
			case ILCode.Stind_Ref:
				if (forceInferChildren)
				{
					TypeReference expectedType2 = UnpackPointer(InferTypeForExpression(expr.Arguments[0], null));
					InferTypeForExpression(expr.Arguments[1], expectedType2);
				}
				return null;
			case ILCode.Ldobj:
			{
				TypeReference typeReference4 = (TypeReference)expr.Operand;
				TypeReference typeReference5 = InferTypeForExpression(expr.Arguments[0], null);
				if (typeReference5 is PointerType || typeReference5 is ByReferenceType)
				{
					TypeReference elementType = ((TypeSpecification)typeReference5).ElementType;
					int informationAmount = GetInformationAmount(elementType);
					if (informationAmount == 1 && GetInformationAmount(typeReference4) == 8)
					{
						typeReference4 = elementType;
					}
					if (informationAmount >= 8 && informationAmount <= 64 && informationAmount == GetInformationAmount(typeReference4))
					{
						bool? flag = IsSigned(elementType);
						bool? flag2 = IsSigned(typeReference4);
						if (flag.HasValue && flag2.HasValue && (informationAmount >= 32 || flag == flag2))
						{
							typeReference4 = elementType;
						}
					}
				}
				if (typeReference5 is PointerType)
				{
					InferTypeForExpression(expr.Arguments[0], new PointerType(typeReference4));
				}
				else
				{
					InferTypeForExpression(expr.Arguments[0], new ByReferenceType(typeReference4));
				}
				return typeReference4;
			}
			case ILCode.Stobj:
			{
				TypeReference typeReference6 = (TypeReference)expr.Operand;
				TypeReference typeReference7 = InferTypeForExpression(expr.Arguments[0], new ByReferenceType(typeReference6));
				TypeReference typeReference8 = (typeReference7 is PointerType) ? ((PointerType)typeReference7).ElementType : ((!(typeReference7 is ByReferenceType)) ? null : ((ByReferenceType)typeReference7).ElementType);
				if (typeReference8 != null)
				{
					int informationAmount2 = GetInformationAmount(typeReference8);
					if (informationAmount2 == 1 && GetInformationAmount(typeReference6) == 8)
					{
						typeReference6 = typeReference8;
					}
					else if (informationAmount2 == GetInformationAmount(typeReference6) && IsSigned(typeReference8).HasValue && IsSigned(typeReference6).HasValue)
					{
						typeReference6 = typeReference8;
					}
				}
				if (forceInferChildren)
				{
					if (typeReference7 is PointerType)
					{
						InferTypeForExpression(expr.Arguments[0], new PointerType(typeReference6));
					}
					else if (!IsSameType(typeReference6, expr.Operand as TypeReference))
					{
						InferTypeForExpression(expr.Arguments[0], new ByReferenceType(typeReference6));
					}
					InferTypeForExpression(expr.Arguments[1], typeReference6);
				}
				return typeReference6;
			}
			case ILCode.Initobj:
				return null;
			case ILCode.DefaultValue:
				return (TypeReference)expr.Operand;
			case ILCode.Localloc:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], null);
				}
				if (expectedType is PointerType)
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
				TypeReference typeReference14 = UnpackPointer(InferTypeForExpression(expr.Arguments[0], null));
				if (forceInferChildren && typeReference14 != null)
				{
					InferTypeForExpression(expr.Arguments[0], new ByReferenceType(typeReference14));
				}
				return typeReference14;
			}
			case ILCode.Mkrefany:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], (TypeReference)expr.Operand);
				}
				return typeSystem.TypedReference;
			case ILCode.Refanytype:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], typeSystem.TypedReference);
				}
				return new TypeReference("System", "RuntimeTypeHandle", module, module.TypeSystem.CoreLibrary, valueType: true);
			case ILCode.Refanyval:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], typeSystem.TypedReference);
				}
				return new ByReferenceType((TypeReference)expr.Operand);
			case ILCode.AddressOf:
			{
				TypeReference typeReference11 = InferTypeForExpression(expr.Arguments[0], UnpackPointer(expectedType));
				if (typeReference11 == null)
				{
					return null;
				}
				return new ByReferenceType(typeReference11);
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
				if (expectedType != null && (expectedType.MetadataType == MetadataType.Int32 || expectedType.MetadataType == MetadataType.UInt32 || expectedType.MetadataType == MetadataType.Int64 || expectedType.MetadataType == MetadataType.UInt64))
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
				TypeReference typeReference15 = NumericPromotion(InferTypeForExpression(expr.Arguments[0], null));
				if (typeReference15 == null)
				{
					return null;
				}
				TypeReference typeReference16 = null;
				switch (typeReference15.MetadataType)
				{
				case MetadataType.Int32:
					if (expr.Code == ILCode.Shr_Un)
					{
						typeReference16 = typeSystem.UInt32;
					}
					break;
				case MetadataType.UInt32:
					if (expr.Code == ILCode.Shr)
					{
						typeReference16 = typeSystem.Int32;
					}
					break;
				case MetadataType.Int64:
					if (expr.Code == ILCode.Shr_Un)
					{
						typeReference16 = typeSystem.UInt64;
					}
					break;
				case MetadataType.UInt64:
					if (expr.Code == ILCode.Shr)
					{
						typeReference16 = typeSystem.UInt64;
					}
					break;
				}
				if (typeReference16 != null)
				{
					InferTypeForExpression(expr.Arguments[0], typeReference16);
					return typeReference16;
				}
				return typeReference15;
			}
			case ILCode.CompoundAssignment:
			{
				ILExpression iLExpression2 = expr.Arguments[0];
				if (iLExpression2.Code == ILCode.NullableOf)
				{
					iLExpression2 = iLExpression2.Arguments[0].Arguments[0];
				}
				TypeReference typeReference13 = InferTypeForExpression(iLExpression2.Arguments[0], null);
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[0], typeReference13);
				}
				return typeReference13;
			}
			case ILCode.Ldnull:
				return typeSystem.Object;
			case ILCode.Ldstr:
				return typeSystem.String;
			case ILCode.Ldftn:
			case ILCode.Ldvirtftn:
				return typeSystem.IntPtr;
			case ILCode.Ldc_I4:
				if (IsBoolean(expectedType) && ((int)expr.Operand == 0 || (int)expr.Operand == 1))
				{
					return typeSystem.Boolean;
				}
				if (expectedType is PointerType && (int)expr.Operand == 0)
				{
					return expectedType;
				}
				if (IsIntegerOrEnum(expectedType) && OperandFitsInType(expectedType, (int)expr.Operand))
				{
					return expectedType;
				}
				return typeSystem.Int32;
			case ILCode.Ldc_I8:
				if (expectedType is PointerType && (long)expr.Operand == 0L)
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
				return new TypeReference("System", "Decimal", module, module.TypeSystem.CoreLibrary, valueType: true);
			case ILCode.Ldtoken:
				if (expr.Operand is TypeReference)
				{
					return new TypeReference("System", "RuntimeTypeHandle", module, module.TypeSystem.CoreLibrary, valueType: true);
				}
				if (expr.Operand is FieldReference)
				{
					return new TypeReference("System", "RuntimeFieldHandle", module, module.TypeSystem.CoreLibrary, valueType: true);
				}
				return new TypeReference("System", "RuntimeMethodHandle", module, module.TypeSystem.CoreLibrary, valueType: true);
			case ILCode.Arglist:
				return new TypeReference("System", "RuntimeArgumentHandle", module, module.TypeSystem.CoreLibrary, valueType: true);
			case ILCode.Newarr:
				if (forceInferChildren)
				{
					TypeReference typeReference3 = InferTypeForExpression(expr.Arguments.Single(), null);
					if (typeReference3 == typeSystem.IntPtr)
					{
						typeReference3 = typeSystem.Int64;
					}
					else if (typeReference3 == typeSystem.UIntPtr)
					{
						typeReference3 = typeSystem.UInt64;
					}
					else if (typeReference3 != typeSystem.UInt32 && typeReference3 != typeSystem.Int64 && typeReference3 != typeSystem.UInt64)
					{
						typeReference3 = typeSystem.Int32;
					}
					if (forceInferChildren)
					{
						InferTypeForExpression(expr.Arguments.Single(), typeReference3);
					}
				}
				return new ArrayType((TypeReference)expr.Operand);
			case ILCode.InitArray:
			{
				ArrayType arrayType4 = (ArrayType)expr.Operand;
				if (forceInferChildren)
				{
					foreach (ILExpression argument in expr.Arguments)
					{
						InferTypeForExpression(argument, arrayType4.ElementType);
					}
					return arrayType4;
				}
				return arrayType4;
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
				ArrayType arrayType3 = InferTypeForExpression(expr.Arguments[0], null) as ArrayType;
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
				}
				return arrayType3?.ElementType;
			}
			case ILCode.Ldelem_Any:
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
				}
				return (TypeReference)expr.Operand;
			case ILCode.Ldelema:
			{
				ArrayType arrayType2 = InferTypeForExpression(expr.Arguments[0], null) as ArrayType;
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
				}
				if (arrayType2 == null)
				{
					return null;
				}
				return new ByReferenceType(arrayType2.ElementType);
			}
			case ILCode.Stelem_I:
			case ILCode.Stelem_I1:
			case ILCode.Stelem_I2:
			case ILCode.Stelem_I4:
			case ILCode.Stelem_I8:
			case ILCode.Stelem_R4:
			case ILCode.Stelem_R8:
			case ILCode.Stelem_Ref:
			case ILCode.Stelem_Any:
			{
				ArrayType arrayType = InferTypeForExpression(expr.Arguments[0], null) as ArrayType;
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments[1], typeSystem.Int32);
					if (arrayType != null)
					{
						InferTypeForExpression(expr.Arguments[2], arrayType.ElementType);
					}
				}
				return arrayType?.ElementType;
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
				if (expectedType == null || expectedType.MetadataType != MetadataType.Single)
				{
					return typeSystem.Double;
				}
				return typeSystem.Single;
			case ILCode.Castclass:
			case ILCode.Unbox_Any:
				return (TypeReference)expr.Operand;
			case ILCode.Unbox:
				return new ByReferenceType((TypeReference)expr.Operand);
			case ILCode.Isinst:
			{
				TypeReference typeReference12 = (TypeReference)expr.Operand;
				if (!typeReference12.IsValueType)
				{
					return typeReference12;
				}
				return typeSystem.Object;
			}
			case ILCode.Box:
			{
				TypeReference typeReference10 = (TypeReference)expr.Operand;
				if (forceInferChildren)
				{
					InferTypeForExpression(expr.Arguments.Single(), typeReference10);
				}
				if (!typeReference10.IsValueType)
				{
					return typeReference10;
				}
				return typeSystem.Object;
			}
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
					TypeReference typeReference9 = context.CurrentMethod.ReturnType;
					if (context.CurrentMethodIsAsync && typeReference9 != null && typeReference9.Namespace == "System.Threading.Tasks")
					{
						if (typeReference9.Name == "Task")
						{
							typeReference9 = typeSystem.Void;
						}
						else if (typeReference9.Name == "Task`1" && typeReference9.IsGenericInstance)
						{
							typeReference9 = ((GenericInstanceType)typeReference9).GenericArguments[0];
						}
					}
					InferTypeForExpression(expr.Arguments[0], typeReference9);
				}
				return null;
			case ILCode.YieldReturn:
				if (forceInferChildren)
				{
					GenericInstanceType genericInstanceType = context.CurrentMethod.ReturnType as GenericInstanceType;
					if (genericInstanceType != null)
					{
						InferTypeForExpression(expr.Arguments[0], genericInstanceType.GenericArguments[0]);
					}
					else
					{
						InferTypeForExpression(expr.Arguments[0], typeSystem.Object);
					}
				}
				return null;
			case ILCode.Await:
			{
				TypeReference typeReference2 = InferTypeForExpression(expr.Arguments[0], null);
				if (typeReference2 != null && typeReference2.Name == "Task`1" && typeReference2.IsGenericInstance && typeReference2.Namespace == "System.Threading.Tasks")
				{
					return ((GenericInstanceType)typeReference2).GenericArguments[0];
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

		private TypeReference MakeRefIfValueType(TypeReference type, ILExpressionPrefix constrainedPrefix)
		{
			if (constrainedPrefix != null)
			{
				return new ByReferenceType((TypeReference)constrainedPrefix.Operand);
			}
			if (type.IsValueType)
			{
				return new ByReferenceType(type);
			}
			return type;
		}

		private TypeReference NumericPromotion(TypeReference type)
		{
			if (type == null)
			{
				return null;
			}
			switch (type.MetadataType)
			{
			case MetadataType.SByte:
			case MetadataType.Byte:
			case MetadataType.Int16:
			case MetadataType.UInt16:
				return typeSystem.Int32;
			default:
				return type;
			}
		}

		private TypeReference HandleConversion(int targetBitSize, bool targetSigned, ILExpression arg, TypeReference expectedType, TypeReference targetType)
		{
			if (targetBitSize >= 33 && expectedType is PointerType)
			{
				InferTypeForExpression(arg, expectedType);
				return expectedType;
			}
			TypeReference typeReference = InferTypeForExpression(arg, null);
			if (targetBitSize >= 33 && typeReference is ByReferenceType)
			{
				PointerType pointerType = new PointerType(((ByReferenceType)typeReference).ElementType);
				InferTypeForExpression(arg, pointerType);
				return pointerType;
			}
			if (targetBitSize >= 33 && typeReference is PointerType)
			{
				return typeReference;
			}
			return arg.ExpectedType = ((GetInformationAmount(expectedType) == targetBitSize && IsSigned(expectedType) == targetSigned) ? expectedType : targetType);
		}

		public static TypeReference GetFieldType(FieldReference fieldReference)
		{
			return SubstituteTypeArgs(UnpackModifiers(fieldReference.FieldType), fieldReference);
		}

		public static TypeReference SubstituteTypeArgs(TypeReference type, MemberReference member)
		{
			if (type is TypeSpecification)
			{
				ArrayType arrayType = type as ArrayType;
				if (arrayType != null)
				{
					TypeReference typeReference = SubstituteTypeArgs(arrayType.ElementType, member);
					if (typeReference != arrayType.ElementType)
					{
						ArrayType arrayType2 = new ArrayType(typeReference);
						arrayType2.Dimensions.Clear();
						{
							foreach (ArrayDimension dimension in arrayType.Dimensions)
							{
								arrayType2.Dimensions.Add(dimension);
							}
							return arrayType2;
						}
					}
					return type;
				}
				ByReferenceType byReferenceType = type as ByReferenceType;
				if (byReferenceType != null)
				{
					TypeReference typeReference2 = SubstituteTypeArgs(byReferenceType.ElementType, member);
					if (typeReference2 == byReferenceType.ElementType)
					{
						return type;
					}
					return new ByReferenceType(typeReference2);
				}
				GenericInstanceType genericInstanceType = type as GenericInstanceType;
				if (genericInstanceType != null)
				{
					GenericInstanceType genericInstanceType2 = new GenericInstanceType(genericInstanceType.ElementType);
					bool flag = false;
					for (int i = 0; i < genericInstanceType.GenericArguments.Count; i++)
					{
						genericInstanceType2.GenericArguments.Add(SubstituteTypeArgs(genericInstanceType.GenericArguments[i], member));
						flag |= (genericInstanceType2.GenericArguments[i] != genericInstanceType.GenericArguments[i]);
					}
					if (!flag)
					{
						return type;
					}
					return genericInstanceType2;
				}
				OptionalModifierType optionalModifierType = type as OptionalModifierType;
				if (optionalModifierType != null)
				{
					TypeReference typeReference3 = SubstituteTypeArgs(optionalModifierType.ElementType, member);
					if (typeReference3 == optionalModifierType.ElementType)
					{
						return type;
					}
					return new OptionalModifierType(optionalModifierType.ModifierType, typeReference3);
				}
				RequiredModifierType requiredModifierType = type as RequiredModifierType;
				if (requiredModifierType != null)
				{
					TypeReference typeReference4 = SubstituteTypeArgs(requiredModifierType.ElementType, member);
					if (typeReference4 == requiredModifierType.ElementType)
					{
						return type;
					}
					return new RequiredModifierType(requiredModifierType.ModifierType, typeReference4);
				}
				PointerType pointerType = type as PointerType;
				if (pointerType != null)
				{
					TypeReference typeReference5 = SubstituteTypeArgs(pointerType.ElementType, member);
					if (typeReference5 == pointerType.ElementType)
					{
						return type;
					}
					return new PointerType(typeReference5);
				}
			}
			GenericParameter genericParameter = type as GenericParameter;
			if (genericParameter != null)
			{
				if (member.DeclaringType is ArrayType)
				{
					return ((ArrayType)member.DeclaringType).ElementType;
				}
				if (genericParameter.Owner.GenericParameterType == GenericParameterType.Method)
				{
					return ((GenericInstanceMethod)member).GenericArguments[genericParameter.Position];
				}
				return ((GenericInstanceType)member.DeclaringType).GenericArguments[genericParameter.Position];
			}
			return type;
		}

		private static TypeReference UnpackPointer(TypeReference pointerOrManagedReference)
		{
			ByReferenceType byReferenceType = pointerOrManagedReference as ByReferenceType;
			if (byReferenceType != null)
			{
				return byReferenceType.ElementType;
			}
			return (pointerOrManagedReference as PointerType)?.ElementType;
		}

		internal static TypeReference UnpackModifiers(TypeReference type)
		{
			while (type is OptionalModifierType || type is RequiredModifierType)
			{
				type = ((TypeSpecification)type).ElementType;
			}
			return type;
		}

		private static TypeReference GetNullableTypeArgument(TypeReference type)
		{
			GenericInstanceType genericInstanceType = type as GenericInstanceType;
			if (!IsNullableType(genericInstanceType))
			{
				return type;
			}
			return genericInstanceType.GenericArguments[0];
		}

		private GenericInstanceType CreateNullableType(TypeReference type)
		{
			if (type == null)
			{
				return null;
			}
			return new GenericInstanceType(new TypeReference("System", "Nullable`1", module, module.TypeSystem.CoreLibrary, valueType: true))
			{
				GenericArguments = 
				{
					type
				}
			};
		}

		private TypeReference InferArgumentsInBinaryOperator(ILExpression expr, bool? isSigned, TypeReference expectedType)
		{
			return InferBinaryArguments(expr.Arguments[0], expr.Arguments[1], expectedType);
		}

		private TypeReference InferArgumentsInAddition(ILExpression expr, bool? isSigned, TypeReference expectedType)
		{
			ILExpression iLExpression = expr.Arguments[0];
			ILExpression iLExpression2 = expr.Arguments[1];
			TypeReference typeReference = DoInferTypeForExpression(iLExpression, expectedType);
			if (typeReference is PointerType)
			{
				TypeReference typeReference4 = iLExpression.InferredType = (iLExpression.ExpectedType = typeReference);
				InferTypeForExpression(iLExpression2, null);
				return typeReference;
			}
			if (IsEnum(typeReference))
			{
				TypeReference typeReference4 = iLExpression.InferredType = (iLExpression.ExpectedType = typeReference);
				InferTypeForExpression(iLExpression2, GetEnumUnderlyingType(typeReference));
				return typeReference;
			}
			TypeReference typeReference7 = DoInferTypeForExpression(iLExpression2, expectedType);
			if (typeReference7 is PointerType)
			{
				InferTypeForExpression(iLExpression, null);
				TypeReference typeReference4 = iLExpression2.InferredType = (iLExpression2.ExpectedType = typeReference7);
				return typeReference7;
			}
			if (IsEnum(typeReference7))
			{
				TypeReference typeReference4 = iLExpression2.InferredType = (iLExpression2.ExpectedType = typeReference7);
				InferTypeForExpression(iLExpression, GetEnumUnderlyingType(typeReference7));
				return typeReference7;
			}
			return InferBinaryArguments(iLExpression, iLExpression2, expectedType, forceInferChildren: false, typeReference, typeReference7);
		}

		private TypeReference InferArgumentsInSubtraction(ILExpression expr, bool? isSigned, TypeReference expectedType)
		{
			ILExpression iLExpression = expr.Arguments[0];
			ILExpression iLExpression2 = expr.Arguments[1];
			TypeReference typeReference = DoInferTypeForExpression(iLExpression, expectedType);
			if (typeReference is PointerType)
			{
				TypeReference typeReference4 = iLExpression.InferredType = (iLExpression.ExpectedType = typeReference);
				if (InferTypeForExpression(iLExpression2, null) is PointerType)
				{
					return typeSystem.IntPtr;
				}
				return typeReference;
			}
			if (IsEnum(typeReference))
			{
				TypeReference typeReference4;
				if (expectedType != null && IsEnum(expectedType))
				{
					typeReference4 = (iLExpression.InferredType = (iLExpression.ExpectedType = typeReference));
					InferTypeForExpression(iLExpression2, GetEnumUnderlyingType(typeReference));
					return typeReference;
				}
				typeReference4 = (iLExpression.InferredType = (iLExpression.ExpectedType = typeReference));
				InferTypeForExpression(iLExpression2, typeReference);
				return GetEnumUnderlyingType(typeReference);
			}
			return InferBinaryArguments(iLExpression, iLExpression2, expectedType, forceInferChildren: false, typeReference);
		}

		private TypeReference InferBinaryArguments(ILExpression left, ILExpression right, TypeReference expectedType, bool forceInferChildren = false, TypeReference leftPreferred = null, TypeReference rightPreferred = null)
		{
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
				TypeReference typeReference2 = right.ExpectedType = leftPreferred;
				TypeReference typeReference4 = left.ExpectedType = typeReference2;
				TypeReference typeReference6 = right.InferredType = typeReference4;
				return left.InferredType = typeReference6;
			}
			if (IsSameType(rightPreferred, DoInferTypeForExpression(left, rightPreferred, forceInferChildren)))
			{
				TypeReference typeReference2 = right.ExpectedType = rightPreferred;
				TypeReference typeReference4 = left.ExpectedType = typeReference2;
				TypeReference typeReference6 = right.InferredType = typeReference4;
				return left.InferredType = typeReference6;
			}
			if (IsSameType(leftPreferred, DoInferTypeForExpression(right, leftPreferred, forceInferChildren)))
			{
				DoInferTypeForExpression(left, leftPreferred, forceInferChildren);
				TypeReference typeReference2 = right.ExpectedType = leftPreferred;
				TypeReference typeReference4 = left.ExpectedType = typeReference2;
				TypeReference typeReference6 = right.InferredType = typeReference4;
				return left.InferredType = typeReference6;
			}
			TypeReference typeReference18 = left.ExpectedType = (right.ExpectedType = TypeWithMoreInformation(leftPreferred, rightPreferred));
			left.InferredType = DoInferTypeForExpression(left, left.ExpectedType, forceInferChildren);
			right.InferredType = DoInferTypeForExpression(right, right.ExpectedType, forceInferChildren);
			return left.ExpectedType;
		}

		private TypeReference TypeWithMoreInformation(TypeReference leftPreferred, TypeReference rightPreferred)
		{
			int informationAmount = GetInformationAmount(leftPreferred);
			int informationAmount2 = GetInformationAmount(rightPreferred);
			if (informationAmount < informationAmount2)
			{
				return rightPreferred;
			}
			return leftPreferred;
		}

		public static TypeReference GetEnumUnderlyingType(TypeReference enumType)
		{
			if (enumType != null && !IsArrayPointerOrReference(enumType))
			{
				TypeDefinition typeDefinition = enumType.Resolve();
				if (typeDefinition != null && typeDefinition.IsEnum)
				{
					return typeDefinition.Fields.Single((FieldDefinition f) => !f.IsStatic).FieldType;
				}
			}
			return null;
		}

		public static int GetInformationAmount(TypeReference type)
		{
			type = (GetEnumUnderlyingType(type) ?? type);
			if (type == null)
			{
				return 0;
			}
			switch (type.MetadataType)
			{
			case MetadataType.Void:
				return 0;
			case MetadataType.Boolean:
				return 1;
			case MetadataType.SByte:
			case MetadataType.Byte:
				return 8;
			case MetadataType.Char:
			case MetadataType.Int16:
			case MetadataType.UInt16:
				return 16;
			case MetadataType.Int32:
			case MetadataType.UInt32:
			case MetadataType.Single:
				return 32;
			case MetadataType.Int64:
			case MetadataType.UInt64:
			case MetadataType.Double:
				return 64;
			case MetadataType.IntPtr:
			case MetadataType.UIntPtr:
				return 33;
			default:
				return 100;
			}
		}

		public static bool IsBoolean(TypeReference type)
		{
			if (type != null)
			{
				return type.MetadataType == MetadataType.Boolean;
			}
			return false;
		}

		public static bool IsIntegerOrEnum(TypeReference type)
		{
			return IsSigned(type).HasValue;
		}

		public static bool IsEnum(TypeReference type)
		{
			if (type == null || IsArrayPointerOrReference(type))
			{
				return false;
			}
			return type.Resolve()?.IsEnum ?? false;
		}

		private static bool? IsSigned(TypeReference type)
		{
			type = (GetEnumUnderlyingType(type) ?? type);
			if (type == null)
			{
				return null;
			}
			switch (type.MetadataType)
			{
			case MetadataType.SByte:
			case MetadataType.Int16:
			case MetadataType.Int32:
			case MetadataType.Int64:
			case MetadataType.IntPtr:
				return true;
			case MetadataType.Char:
			case MetadataType.Byte:
			case MetadataType.UInt16:
			case MetadataType.UInt32:
			case MetadataType.UInt64:
			case MetadataType.UIntPtr:
				return false;
			default:
				return null;
			}
		}

		private static bool OperandFitsInType(TypeReference type, int num)
		{
			type = (GetEnumUnderlyingType(type) ?? type);
			switch (type.MetadataType)
			{
			case MetadataType.SByte:
				if (-128 <= num)
				{
					return num <= 127;
				}
				return false;
			case MetadataType.Int16:
				if (-32768 <= num)
				{
					return num <= 32767;
				}
				return false;
			case MetadataType.Byte:
				if (0 <= num)
				{
					return num <= 255;
				}
				return false;
			case MetadataType.Char:
				if (0 <= num)
				{
					return num <= 65535;
				}
				return false;
			case MetadataType.UInt16:
				if (0 <= num)
				{
					return num <= 65535;
				}
				return false;
			default:
				return true;
			}
		}

		private static bool IsArrayPointerOrReference(TypeReference type)
		{
			for (TypeSpecification typeSpecification = type as TypeSpecification; typeSpecification != null; typeSpecification = (typeSpecification.ElementType as TypeSpecification))
			{
				if (typeSpecification is ArrayType || typeSpecification is PointerType || typeSpecification is ByReferenceType)
				{
					return true;
				}
			}
			return false;
		}

		internal static bool IsNullableType(TypeReference type)
		{
			if (type != null && type.Name == "Nullable`1")
			{
				return type.Namespace == "System";
			}
			return false;
		}

		public static TypeCode GetTypeCode(TypeReference type)
		{
			if (type == null)
			{
				return TypeCode.Empty;
			}
			switch (type.MetadataType)
			{
			case MetadataType.Boolean:
				return TypeCode.Boolean;
			case MetadataType.Char:
				return TypeCode.Char;
			case MetadataType.SByte:
				return TypeCode.SByte;
			case MetadataType.Byte:
				return TypeCode.Byte;
			case MetadataType.Int16:
				return TypeCode.Int16;
			case MetadataType.UInt16:
				return TypeCode.UInt16;
			case MetadataType.Int32:
				return TypeCode.Int32;
			case MetadataType.UInt32:
				return TypeCode.UInt32;
			case MetadataType.Int64:
				return TypeCode.Int64;
			case MetadataType.UInt64:
				return TypeCode.UInt64;
			case MetadataType.Single:
				return TypeCode.Single;
			case MetadataType.Double:
				return TypeCode.Double;
			case MetadataType.String:
				return TypeCode.String;
			case MetadataType.RequiredModifier:
			case MetadataType.OptionalModifier:
				return GetTypeCode(((IModifierType)type).ElementType);
			default:
				return TypeCode.Object;
			}
		}

		public static void Reset(ILBlock method)
		{
			foreach (ILExpression item in method.GetSelfAndChildrenRecursive<ILExpression>())
			{
				item.InferredType = null;
				item.ExpectedType = null;
				ILVariable iLVariable = item.Operand as ILVariable;
				if (iLVariable != null && iLVariable.IsGenerated)
				{
					iLVariable.Type = null;
				}
			}
		}

		public static bool IsSameType(TypeReference type1, TypeReference type2)
		{
			if (type1 == type2)
			{
				return true;
			}
			if (type1 == null || type2 == null)
			{
				return false;
			}
			return type1.FullName == type2.FullName;
		}
	}
}
