using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public static class TypeGuessing
	{
		private static readonly IType[] emptyTypes = new IType[0];

		private static int GetArgumentIndex(IEnumerable<Expression> arguments, AstNode parameter)
		{
			int num = 0;
			foreach (Expression argument in arguments)
			{
				if (argument == parameter)
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		private static IEnumerable<IType> GetAllValidTypesFromInvocation(CSharpAstResolver resolver, InvocationExpression invoke, AstNode parameter)
		{
			int index = GetArgumentIndex(invoke.Arguments, parameter);
			if (index >= 0)
			{
				MethodGroupResolveResult targetResult = resolver.Resolve(invoke.Target) as MethodGroupResolveResult;
				if (targetResult != null)
				{
					foreach (IMethod method in targetResult.Methods)
					{
						if (index < method.Parameters.Count)
						{
							if (method.Parameters[index].IsParams)
							{
								ArrayType arrayType = method.Parameters[index].Type as ArrayType;
								if (arrayType != null)
								{
									yield return arrayType.ElementType;
								}
							}
							yield return method.Parameters[index].Type;
						}
					}
					foreach (IEnumerable<IMethod> extensionMethod in targetResult.GetExtensionMethods())
					{
						foreach (IMethod item in extensionMethod)
						{
							IMethod i = item;
							if (CSharpResolver.IsEligibleExtensionMethod(targetResult.TargetType, item, useTypeInference: true, out IType[] outInferredTypes) && outInferredTypes != null)
							{
								i = item.Specialize(new TypeParameterSubstitution(null, outInferredTypes));
							}
							int correctedIndex = index + 1;
							if (correctedIndex < i.Parameters.Count)
							{
								if (i.Parameters[correctedIndex].IsParams)
								{
									ArrayType arrayType2 = i.Parameters[correctedIndex].Type as ArrayType;
									if (arrayType2 != null)
									{
										yield return arrayType2.ElementType;
									}
								}
								yield return i.Parameters[correctedIndex].Type;
							}
						}
					}
				}
			}
		}

		private static IEnumerable<IType> GetAllValidTypesFromObjectCreation(CSharpAstResolver resolver, ObjectCreateExpression invoke, AstNode parameter)
		{
			int index = GetArgumentIndex(invoke.Arguments, parameter);
			if (index < 0)
			{
				yield break;
			}
			ResolveResult resolveResult = resolver.Resolve(invoke.Type);
			if (resolveResult is TypeResolveResult)
			{
				IType type = ((TypeResolveResult)resolveResult).Type;
				if (type.Kind == TypeKind.Delegate && index == 0)
				{
					yield return type;
				}
				else
				{
					foreach (IMethod constructor in type.GetConstructors())
					{
						if (index < constructor.Parameters.Count)
						{
							yield return constructor.Parameters[index].Type;
						}
					}
				}
			}
		}

		public static IType GetElementType(CSharpAstResolver resolver, IType type)
		{
			if (type.Kind == TypeKind.Array || type.Kind == TypeKind.Dynamic)
			{
				if (type.Kind == TypeKind.Array)
				{
					return ((ArrayType)type).ElementType;
				}
				return resolver.Compilation.FindType(KnownTypeCode.Object);
			}
			foreach (IMethod method in type.GetMethods((IUnresolvedMethod m) => m.Name == "GetEnumerator"))
			{
				IType type2 = null;
				foreach (IProperty property in method.ReturnType.GetProperties((IUnresolvedProperty p) => p.Name == "Current"))
				{
					if (type2 == null || !property.ReturnType.IsKnownType(KnownTypeCode.Object))
					{
						type2 = property.ReturnType;
					}
				}
				if (type2 != null)
				{
					return type2;
				}
			}
			return resolver.Compilation.FindType(KnownTypeCode.Object);
		}

		private static IEnumerable<IType> GuessFromConstructorInitializer(CSharpAstResolver resolver, AstNode expr)
		{
			ConstructorInitializer constructorInitializer = expr.Parent as ConstructorInitializer;
			ResolveResult resolveResult = resolver.Resolve(expr.Parent);
			int index = GetArgumentIndex(constructorInitializer.Arguments, expr);
			if (index >= 0)
			{
				foreach (IMethod constructor in resolveResult.Type.GetConstructors())
				{
					if (index < constructor.Parameters.Count)
					{
						yield return constructor.Parameters[index].Type;
					}
				}
			}
		}

		public static IEnumerable<IType> GetValidTypes(CSharpAstResolver resolver, AstNode expr)
		{
			if (expr.Role == Roles.Condition)
			{
				return new IType[1]
				{
					resolver.Compilation.FindType(KnownTypeCode.Boolean)
				};
			}
			MemberReferenceExpression memberReferenceExpression = expr as MemberReferenceExpression;
			if (memberReferenceExpression != null)
			{
				ResolveResult resolveResult = resolver.Resolve(memberReferenceExpression.Target);
				if (!resolveResult.IsError && resolveResult.Type.Kind == TypeKind.Enum)
				{
					return new IType[1]
					{
						resolveResult.Type
					};
				}
			}
			if (expr.Parent is ParenthesizedExpression || expr.Parent is NamedArgumentExpression)
			{
				return GetValidTypes(resolver, expr.Parent);
			}
			if (expr.Parent is DirectionExpression)
			{
				AstNode parent = expr.Parent.Parent;
				if (parent is InvocationExpression)
				{
					InvocationExpression invoke = (InvocationExpression)parent;
					return GetAllValidTypesFromInvocation(resolver, invoke, expr.Parent);
				}
			}
			if (expr.Parent is ArrayInitializerExpression)
			{
				if (expr is NamedExpression)
				{
					return new IType[1]
					{
						resolver.Resolve(((NamedExpression)expr).Expression).Type
					};
				}
				ArrayInitializerExpression arrayInitializerExpression = expr.Parent as ArrayInitializerExpression;
				if (arrayInitializerExpression.IsSingleElement)
				{
					arrayInitializerExpression = (arrayInitializerExpression.Parent as ArrayInitializerExpression);
				}
				IType elementType = GetElementType(resolver, resolver.Resolve(arrayInitializerExpression.Parent).Type);
				if (elementType.Kind != TypeKind.Unknown)
				{
					return new IType[1]
					{
						elementType
					};
				}
			}
			if (expr.Parent is ObjectCreateExpression)
			{
				ObjectCreateExpression invoke2 = (ObjectCreateExpression)expr.Parent;
				return GetAllValidTypesFromObjectCreation(resolver, invoke2, expr);
			}
			if (expr.Parent is ArrayCreateExpression)
			{
				ArrayCreateExpression arrayCreateExpression = (ArrayCreateExpression)expr.Parent;
				if (!arrayCreateExpression.Type.IsNull)
				{
					return new IType[1]
					{
						resolver.Resolve(arrayCreateExpression.Type).Type
					};
				}
			}
			if (expr.Parent is InvocationExpression)
			{
				AstNode parent2 = expr.Parent;
				if (parent2 is InvocationExpression)
				{
					InvocationExpression invoke3 = (InvocationExpression)parent2;
					return GetAllValidTypesFromInvocation(resolver, invoke3, expr);
				}
			}
			if (expr.Parent is VariableInitializer)
			{
				VariableInitializer variableInitializer = (VariableInitializer)expr.Parent;
				FieldDeclaration parent3 = variableInitializer.GetParent<FieldDeclaration>();
				if (parent3 != null)
				{
					ResolveResult resolveResult2 = resolver.Resolve(parent3.ReturnType);
					if (!resolveResult2.IsError)
					{
						return new IType[1]
						{
							resolveResult2.Type
						};
					}
				}
				VariableDeclarationStatement parent4 = variableInitializer.GetParent<VariableDeclarationStatement>();
				if (parent4 != null)
				{
					ResolveResult resolveResult3 = resolver.Resolve(parent4.Type);
					if (!resolveResult3.IsError)
					{
						return new IType[1]
						{
							resolveResult3.Type
						};
					}
				}
				return new IType[1]
				{
					resolver.Resolve(variableInitializer).Type
				};
			}
			if (expr.Parent is CastExpression)
			{
				CastExpression castExpression = (CastExpression)expr.Parent;
				return new IType[1]
				{
					resolver.Resolve(castExpression.Type).Type
				};
			}
			if (expr.Parent is AsExpression)
			{
				AsExpression asExpression = (AsExpression)expr.Parent;
				return new IType[1]
				{
					resolver.Resolve(asExpression.Type).Type
				};
			}
			if (expr.Parent is AssignmentExpression)
			{
				AssignmentExpression assignmentExpression = (AssignmentExpression)expr.Parent;
				Expression node = (assignmentExpression.Left == expr) ? assignmentExpression.Right : assignmentExpression.Left;
				return new IType[1]
				{
					resolver.Resolve(node).Type
				};
			}
			if (expr.Parent is BinaryOperatorExpression)
			{
				BinaryOperatorExpression binaryOperatorExpression = (BinaryOperatorExpression)expr.Parent;
				Expression node2 = (binaryOperatorExpression.Left == expr) ? binaryOperatorExpression.Right : binaryOperatorExpression.Left;
				return new IType[1]
				{
					resolver.Resolve(node2).Type
				};
			}
			if (expr.Parent is ReturnStatement)
			{
				AstNode astNode = expr.Ancestors.FirstOrDefault((AstNode n) => (!(n is EntityDeclaration) && !(n is AnonymousMethodExpression)) ? (n is LambdaExpression) : true);
				if (astNode != null)
				{
					ResolveResult resolveResult4 = resolver.Resolve(astNode);
					if (!resolveResult4.IsError)
					{
						return new IType[1]
						{
							resolveResult4.Type
						};
					}
				}
				EntityDeclaration entityDeclaration = astNode as EntityDeclaration;
				if (entityDeclaration != null)
				{
					ResolveResult resolveResult5 = resolver.Resolve(entityDeclaration.ReturnType);
					if (!resolveResult5.IsError)
					{
						return new IType[1]
						{
							resolveResult5.Type
						};
					}
				}
			}
			if (expr.Parent is YieldReturnStatement)
			{
				ParameterizedType parameterizedType = null;
				AstNode astNode2 = expr.Ancestors.FirstOrDefault((AstNode n) => (!(n is EntityDeclaration) && !(n is AnonymousMethodExpression)) ? (n is LambdaExpression) : true);
				if (astNode2 != null)
				{
					ResolveResult resolveResult6 = resolver.Resolve(astNode2);
					if (!resolveResult6.IsError)
					{
						parameterizedType = (resolveResult6.Type as ParameterizedType);
					}
				}
				EntityDeclaration entityDeclaration2 = astNode2 as EntityDeclaration;
				if (entityDeclaration2 != null)
				{
					ResolveResult resolveResult7 = resolver.Resolve(entityDeclaration2.ReturnType);
					if (!resolveResult7.IsError)
					{
						parameterizedType = (resolveResult7.Type as ParameterizedType);
					}
				}
				if (parameterizedType != null && parameterizedType.FullName == "System.Collections.Generic.IEnumerable")
				{
					return new IType[1]
					{
						parameterizedType.TypeArguments.First()
					};
				}
			}
			if (expr.Parent is UnaryOperatorExpression)
			{
				switch (((UnaryOperatorExpression)expr.Parent).Operator)
				{
				case UnaryOperatorType.Not:
					return new IType[1]
					{
						resolver.Compilation.FindType(KnownTypeCode.Boolean)
					};
				case UnaryOperatorType.Minus:
				case UnaryOperatorType.Plus:
				case UnaryOperatorType.Increment:
				case UnaryOperatorType.Decrement:
				case UnaryOperatorType.PostIncrement:
				case UnaryOperatorType.PostDecrement:
					return new IType[1]
					{
						resolver.Compilation.FindType(KnownTypeCode.Int32)
					};
				}
			}
			if (expr.Parent is ConstructorInitializer)
			{
				return GuessFromConstructorInitializer(resolver, expr);
			}
			if (expr.Parent is NamedExpression)
			{
				ResolveResult resolveResult8 = resolver.Resolve(expr.Parent);
				if (!resolveResult8.IsError)
				{
					return new IType[1]
					{
						resolveResult8.Type
					};
				}
			}
			return Enumerable.Empty<IType>();
		}

		public static AstType GuessAstType(RefactoringContext context, AstNode expr)
		{
			IType[] lowerBounds = GetValidTypes(context.Resolver, expr).ToArray();
			IType type = new TypeInference(context.Compilation)
			{
				Algorithm = TypeInferenceAlgorithm.Improved
			}.FindTypeInBounds(lowerBounds, emptyTypes);
			if (type.Kind == TypeKind.ByReference)
			{
				type = ((ByReferenceType)type).ElementType;
			}
			if (type.Kind == TypeKind.Unknown)
			{
				return new PrimitiveType("object");
			}
			return context.CreateShortType(type);
		}

		public static IType GuessType(BaseRefactoringContext context, AstNode expr)
		{
			if (expr is SimpleType && expr.Role == Roles.TypeArgument)
			{
				if (expr.Parent is MemberReferenceExpression || expr.Parent is IdentifierExpression)
				{
					ResolveResult resolveResult = context.Resolve(expr.Parent);
					int num = expr.Parent.GetChildrenByRole(Roles.TypeArgument).TakeWhile((AstType c) => c != expr).Count();
					MethodGroupResolveResult methodGroupResolveResult = resolveResult as MethodGroupResolveResult;
					if (methodGroupResolveResult != null && methodGroupResolveResult.Methods.Any() && methodGroupResolveResult.Methods.First().TypeArguments.Count > num)
					{
						return methodGroupResolveResult.Methods.First().TypeParameters[num];
					}
				}
				else if (expr.Parent is MemberType || expr.Parent is SimpleType)
				{
					ResolveResult resolveResult2 = context.Resolve(expr.Parent);
					int num2 = expr.Parent.GetChildrenByRole(Roles.TypeArgument).TakeWhile((AstType c) => c != expr).Count();
					TypeResolveResult typeResolveResult = resolveResult2 as TypeResolveResult;
					if (typeResolveResult != null && typeResolveResult.Type.TypeParameterCount > num2)
					{
						return typeResolveResult.Type.GetDefinition().TypeParameters[num2];
					}
				}
			}
			IType[] lowerBounds = GetValidTypes(context.Resolver, expr).ToArray();
			return new TypeInference(context.Compilation)
			{
				Algorithm = TypeInferenceAlgorithm.Improved
			}.FindTypeInBounds(lowerBounds, emptyTypes);
		}
	}
}
