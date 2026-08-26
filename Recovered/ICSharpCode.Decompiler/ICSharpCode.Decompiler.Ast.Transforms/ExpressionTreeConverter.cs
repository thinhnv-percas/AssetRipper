using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class ExpressionTreeConverter
	{
		private readonly DecompilerContext context;

		private Stack<ICSharpCode.NRefactory.CSharp.LambdaExpression> activeLambdas = new Stack<ICSharpCode.NRefactory.CSharp.LambdaExpression>();

		private static readonly ICSharpCode.NRefactory.CSharp.Expression emptyArrayPattern = new ArrayCreateExpression
		{
			Type = new AnyNode(),
			Arguments = 
			{
				(ICSharpCode.NRefactory.CSharp.Expression)new PrimitiveExpression(0)
			}
		};

		private static readonly ICSharpCode.NRefactory.CSharp.Expression getFieldFromHandlePattern = new TypePattern(typeof(FieldInfo)).ToType().Invoke("GetFieldFromHandle", new LdTokenPattern("field").ToExpression().Member("FieldHandle"), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle")));

		private static readonly ICSharpCode.NRefactory.CSharp.Expression getMethodFromHandlePattern = new TypePattern(typeof(MethodBase)).ToType().Invoke("GetMethodFromHandle", new LdTokenPattern("method").ToExpression().Member("MethodHandle"), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle"))).CastTo(new TypePattern(typeof(MethodInfo)));

		private static readonly Pattern trueOrFalse = new Choice
		{
			new PrimitiveExpression(true),
			new PrimitiveExpression(false)
		};

		private static readonly ICSharpCode.NRefactory.CSharp.Expression newObjectCtorPattern = new TypePattern(typeof(MethodBase)).ToType().Invoke("GetMethodFromHandle", new LdTokenPattern("ctor").ToExpression().Member("MethodHandle"), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle"))).CastTo(new TypePattern(typeof(ConstructorInfo)));

		private static readonly Pattern elementInitArrayPattern = ArrayInitializationPattern(typeof(ElementInit), new TypePattern(typeof(System.Linq.Expressions.Expression)).ToType().Invoke("ElementInit", new AnyNode("methodInfos"), new AnyNode("addArgumentsArrays")));

		private static readonly Pattern memberBindingArrayPattern = ArrayInitializationPattern(typeof(MemberBinding), new AnyNode("binding"));

		private static readonly INode expressionTypeReference = new TypeReferenceExpression(new TypePattern(typeof(System.Linq.Expressions.Expression)));

		private static readonly Pattern expressionArrayPattern = ArrayInitializationPattern(typeof(System.Linq.Expressions.Expression), new AnyNode("elements"));

		private static readonly TypeOfPattern typeOfPattern = new TypeOfPattern("type");

		public static bool CouldBeExpressionTree(ICSharpCode.NRefactory.CSharp.InvocationExpression expr)
		{
			if (expr != null && expr.Arguments.Count == 2)
			{
				MethodReference methodReference = expr.Annotation<MethodReference>();
				if (methodReference != null && methodReference.Name == "Lambda")
				{
					return methodReference.DeclaringType.FullName == "System.Linq.Expressions.Expression";
				}
				return false;
			}
			return false;
		}

		public static ICSharpCode.NRefactory.CSharp.Expression TryConvert(DecompilerContext context, ICSharpCode.NRefactory.CSharp.Expression expr)
		{
			ICSharpCode.NRefactory.CSharp.Expression expression = new ExpressionTreeConverter(context).Convert(expr);
			expression?.AddAnnotation(new ExpressionTreeLambdaAnnotation());
			return expression;
		}

		private ExpressionTreeConverter(DecompilerContext context)
		{
			this.context = context;
		}

		private ICSharpCode.NRefactory.CSharp.Expression Convert(ICSharpCode.NRefactory.CSharp.Expression expr)
		{
			ICSharpCode.NRefactory.CSharp.InvocationExpression invocationExpression = expr as ICSharpCode.NRefactory.CSharp.InvocationExpression;
			if (invocationExpression != null)
			{
				MethodReference methodReference = invocationExpression.Annotation<MethodReference>();
				if (methodReference != null && methodReference.DeclaringType.FullName == "System.Linq.Expressions.Expression")
				{
					switch (methodReference.Name)
					{
					case "Add":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Add, false);
					case "AddChecked":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Add, true);
					case "AddAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Add, false);
					case "AddAssignChecked":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Add, true);
					case "And":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.BitwiseAnd);
					case "AndAlso":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.ConditionalAnd);
					case "AndAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.BitwiseAnd);
					case "ArrayAccess":
					case "ArrayIndex":
						return ConvertArrayIndex(invocationExpression);
					case "ArrayLength":
						return ConvertArrayLength(invocationExpression);
					case "Assign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Assign);
					case "Call":
						return ConvertCall(invocationExpression);
					case "Coalesce":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.NullCoalescing);
					case "Condition":
						return ConvertCondition(invocationExpression);
					case "Constant":
						if (invocationExpression.Arguments.Count >= 1)
						{
							return invocationExpression.Arguments.First().Clone();
						}
						return NotSupported(expr);
					case "Convert":
						return ConvertCast(invocationExpression, isChecked: false);
					case "ConvertChecked":
						return ConvertCast(invocationExpression, isChecked: true);
					case "Divide":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Divide);
					case "DivideAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Divide);
					case "Equal":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Equality);
					case "ExclusiveOr":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.ExclusiveOr);
					case "ExclusiveOrAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.ExclusiveOr);
					case "Field":
						return ConvertField(invocationExpression);
					case "GreaterThan":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.GreaterThan);
					case "GreaterThanOrEqual":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.GreaterThanOrEqual);
					case "Invoke":
						return ConvertInvoke(invocationExpression);
					case "Lambda":
						return ConvertLambda(invocationExpression);
					case "LeftShift":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.ShiftLeft);
					case "LeftShiftAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.ShiftLeft);
					case "LessThan":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.LessThan);
					case "LessThanOrEqual":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.LessThanOrEqual);
					case "ListInit":
						return ConvertListInit(invocationExpression);
					case "MemberInit":
						return ConvertMemberInit(invocationExpression);
					case "Modulo":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Modulus);
					case "ModuloAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Modulus);
					case "Multiply":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Multiply, false);
					case "MultiplyChecked":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Multiply, true);
					case "MultiplyAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Multiply, false);
					case "MultiplyAssignChecked":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Multiply, true);
					case "Negate":
						return ConvertUnaryOperator(invocationExpression, UnaryOperatorType.Minus, false);
					case "NegateChecked":
						return ConvertUnaryOperator(invocationExpression, UnaryOperatorType.Minus, true);
					case "New":
						return ConvertNewObject(invocationExpression);
					case "NewArrayBounds":
						return ConvertNewArrayBounds(invocationExpression);
					case "NewArrayInit":
						return ConvertNewArrayInit(invocationExpression);
					case "Not":
						return ConvertUnaryOperator(invocationExpression, UnaryOperatorType.Not);
					case "NotEqual":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.InEquality);
					case "OnesComplement":
						return ConvertUnaryOperator(invocationExpression, UnaryOperatorType.BitNot);
					case "Or":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.BitwiseOr);
					case "OrAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.BitwiseOr);
					case "OrElse":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.ConditionalOr);
					case "Property":
						return ConvertProperty(invocationExpression);
					case "Quote":
						if (invocationExpression.Arguments.Count == 1)
						{
							return Convert(invocationExpression.Arguments.Single());
						}
						return NotSupported(invocationExpression);
					case "RightShift":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.ShiftRight);
					case "RightShiftAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.ShiftRight);
					case "Subtract":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Subtract, false);
					case "SubtractChecked":
						return ConvertBinaryOperator(invocationExpression, BinaryOperatorType.Subtract, true);
					case "SubtractAssign":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Subtract, false);
					case "SubtractAssignChecked":
						return ConvertAssignmentOperator(invocationExpression, AssignmentOperatorType.Subtract, true);
					case "TypeAs":
						return ConvertTypeAs(invocationExpression);
					case "TypeIs":
						return ConvertTypeIs(invocationExpression);
					}
				}
			}
			IdentifierExpression identifierExpression = expr as IdentifierExpression;
			if (identifierExpression != null)
			{
				ILVariable iLVariable = identifierExpression.Annotation<ILVariable>();
				if (iLVariable != null)
				{
					foreach (ICSharpCode.NRefactory.CSharp.LambdaExpression activeLambda in activeLambdas)
					{
						foreach (ParameterDeclaration parameter in activeLambda.Parameters)
						{
							if (parameter.Annotation<ILVariable>() == iLVariable)
							{
								return new IdentifierExpression(parameter.Name).WithAnnotation(iLVariable);
							}
						}
					}
				}
			}
			return NotSupported(expr);
		}

		private ICSharpCode.NRefactory.CSharp.Expression NotSupported(ICSharpCode.NRefactory.CSharp.Expression expr)
		{
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertLambda(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.LambdaExpression lambdaExpression = new ICSharpCode.NRefactory.CSharp.LambdaExpression();
			ICSharpCode.NRefactory.CSharp.Expression expression = invocation.Arguments.First();
			ArrayCreateExpression arrayCreateExpression = invocation.Arguments.Last() as ArrayCreateExpression;
			if (arrayCreateExpression == null)
			{
				return NotSupported(invocation);
			}
			ParameterDeclarationAnnotation parameterDeclarationAnnotation = expression.Annotation<ParameterDeclarationAnnotation>();
			if (parameterDeclarationAnnotation != null)
			{
				lambdaExpression.Parameters.AddRange(parameterDeclarationAnnotation.Parameters);
			}
			else if (!emptyArrayPattern.IsMatch(arrayCreateExpression))
			{
				return null;
			}
			activeLambdas.Push(lambdaExpression);
			ICSharpCode.NRefactory.CSharp.Expression expression2 = Convert(expression);
			activeLambdas.Pop();
			if (expression2 == null)
			{
				return null;
			}
			lambdaExpression.Body = expression2;
			return lambdaExpression;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertField(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.Expression other = invocation.Arguments.ElementAt(1);
			Match match = getFieldFromHandlePattern.Match(other);
			if (!match.Success)
			{
				return NotSupported(invocation);
			}
			FieldReference fieldReference = match.Get<AstNode>("field").Single().Annotation<FieldReference>();
			if (fieldReference == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = invocation.Arguments.ElementAt(0);
			ICSharpCode.NRefactory.CSharp.Expression expression2;
			if (expression is NullReferenceExpression)
			{
				expression2 = ((!match.Has("declaringType")) ? new TypeReferenceExpression(AstBuilder.ConvertType(fieldReference.DeclaringType)) : new TypeReferenceExpression(match.Get<AstType>("declaringType").Single().Clone()));
			}
			else
			{
				expression2 = Convert(expression);
				if (expression2 == null)
				{
					return null;
				}
			}
			return expression2.Member(fieldReference.Name).WithAnnotation(fieldReference);
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertProperty(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			Console.WriteLine(string.Concat(invocation));
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(1));
			if (!match.Success)
			{
				return NotSupported(invocation);
			}
			MethodReference methodReference = match.Get<AstNode>("method").Single().Annotation<MethodReference>();
			if (methodReference == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = invocation.Arguments.ElementAt(0);
			ICSharpCode.NRefactory.CSharp.Expression expression2;
			if (expression is NullReferenceExpression)
			{
				expression2 = ((!match.Has("declaringType")) ? new TypeReferenceExpression(AstBuilder.ConvertType(methodReference.DeclaringType)) : new TypeReferenceExpression(match.Get<AstType>("declaringType").Single().Clone()));
			}
			else
			{
				expression2 = Convert(expression);
				if (expression2 == null)
				{
					return null;
				}
			}
			Console.WriteLine(string.Concat(invocation));
			return expression2.Member(GetPropertyName(methodReference)).WithAnnotation(methodReference);
		}

		private string GetPropertyName(MethodReference accessor)
		{
			string text = accessor.Name;
			if (text.StartsWith("get_", StringComparison.Ordinal) || text.StartsWith("set_", StringComparison.Ordinal))
			{
				text = text.Substring(4);
			}
			return text;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertCall(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count < 2)
			{
				return NotSupported(invocation);
			}
			Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(0));
			ICSharpCode.NRefactory.CSharp.Expression expression;
			int num;
			if (match.Success)
			{
				expression = null;
				num = 1;
			}
			else
			{
				match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(1));
				if (!match.Success)
				{
					return NotSupported(invocation);
				}
				expression = invocation.Arguments.ElementAt(0);
				num = 2;
			}
			MethodReference methodReference = match.Get<AstNode>("method").Single().Annotation<MethodReference>();
			if (methodReference == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression2;
			if (expression == null || expression is NullReferenceExpression)
			{
				expression2 = ((!match.Has("declaringType")) ? new TypeReferenceExpression(AstBuilder.ConvertType(methodReference.DeclaringType)) : new TypeReferenceExpression(match.Get<AstType>("declaringType").Single().Clone()));
			}
			else
			{
				expression2 = Convert(expression);
				if (expression2 == null)
				{
					return null;
				}
			}
			MemberReferenceExpression memberReferenceExpression = expression2.Member(methodReference.Name);
			GenericInstanceMethod genericInstanceMethod = methodReference as GenericInstanceMethod;
			if (genericInstanceMethod != null)
			{
				foreach (TypeReference genericArgument in genericInstanceMethod.GenericArguments)
				{
					memberReferenceExpression.TypeArguments.Add(AstBuilder.ConvertType(genericArgument));
				}
			}
			IList<ICSharpCode.NRefactory.CSharp.Expression> list = null;
			if (invocation.Arguments.Count == num + 1)
			{
				ICSharpCode.NRefactory.CSharp.Expression arrayExpression = invocation.Arguments.ElementAt(num);
				list = ConvertExpressionsArray(arrayExpression);
			}
			if (list == null)
			{
				list = new List<ICSharpCode.NRefactory.CSharp.Expression>();
				foreach (ICSharpCode.NRefactory.CSharp.Expression item in invocation.Arguments.Skip(num))
				{
					ICSharpCode.NRefactory.CSharp.Expression expression3 = Convert(item);
					if (expression3 == null)
					{
						return null;
					}
					list.Add(expression3);
				}
			}
			MethodDefinition methodDefinition = methodReference.Resolve();
			if (methodDefinition != null && methodDefinition.IsGetter)
			{
				PropertyDefinition indexer = AstMethodBodyBuilder.GetIndexer(methodDefinition);
				if (indexer != null)
				{
					return new IndexerExpression(memberReferenceExpression.Target.Detach(), list).WithAnnotation(indexer);
				}
			}
			return new ICSharpCode.NRefactory.CSharp.InvocationExpression(memberReferenceExpression, list).WithAnnotation(methodReference);
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertInvoke(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			IList<ICSharpCode.NRefactory.CSharp.Expression> list = ConvertExpressionsArray(invocation.Arguments.ElementAt(1));
			if (expression != null && list != null)
			{
				return new ICSharpCode.NRefactory.CSharp.InvocationExpression(expression, list);
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertBinaryOperator(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, BinaryOperatorType op, bool? isChecked = default(bool?))
		{
			if (invocation.Arguments.Count < 2)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			if (expression == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression2 = Convert(invocation.Arguments.ElementAt(1));
			if (expression2 == null)
			{
				return null;
			}
			BinaryOperatorExpression binaryOperatorExpression = new BinaryOperatorExpression(expression, op, expression2);
			if (isChecked.HasValue)
			{
				binaryOperatorExpression.AddAnnotation(isChecked.Value ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
			}
			switch (invocation.Arguments.Count)
			{
			case 2:
				return binaryOperatorExpression;
			case 3:
			{
				Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(2));
				if (match.Success)
				{
					return binaryOperatorExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<MethodReference>());
				}
				return null;
			}
			case 4:
			{
				if (!trueOrFalse.IsMatch(invocation.Arguments.ElementAt(2)))
				{
					return null;
				}
				Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(3));
				if (match.Success)
				{
					return binaryOperatorExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<MethodReference>());
				}
				return null;
			}
			default:
				return NotSupported(invocation);
			}
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertAssignmentOperator(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, AssignmentOperatorType op, bool? isChecked = default(bool?))
		{
			return NotSupported(invocation);
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertUnaryOperator(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, UnaryOperatorType op, bool? isChecked = default(bool?))
		{
			if (invocation.Arguments.Count < 1)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			if (expression == null)
			{
				return null;
			}
			UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression(op, expression);
			if (isChecked.HasValue)
			{
				unaryOperatorExpression.AddAnnotation(isChecked.Value ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
			}
			switch (invocation.Arguments.Count)
			{
			case 1:
				return unaryOperatorExpression;
			case 2:
			{
				Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(1));
				if (match.Success)
				{
					return unaryOperatorExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<MethodReference>());
				}
				return null;
			}
			default:
				return NotSupported(invocation);
			}
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertCondition(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 3)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			ICSharpCode.NRefactory.CSharp.Expression expression2 = Convert(invocation.Arguments.ElementAt(1));
			ICSharpCode.NRefactory.CSharp.Expression expression3 = Convert(invocation.Arguments.ElementAt(2));
			if (expression != null && expression2 != null && expression3 != null)
			{
				return new ICSharpCode.NRefactory.CSharp.ConditionalExpression(expression, expression2, expression3);
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertNewObject(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count < 1 || invocation.Arguments.Count > 3)
			{
				return NotSupported(invocation);
			}
			Match match = newObjectCtorPattern.Match(invocation.Arguments.First());
			if (!match.Success)
			{
				return NotSupported(invocation);
			}
			MethodReference methodReference = match.Get<AstNode>("ctor").Single().Annotation<MethodReference>();
			if (methodReference == null)
			{
				return null;
			}
			AstType astType;
			TypeReference type;
			if (match.Has("declaringType"))
			{
				astType = match.Get<AstType>("declaringType").Single().Clone();
				type = astType.Annotation<TypeReference>();
			}
			else
			{
				astType = AstBuilder.ConvertType(methodReference.DeclaringType);
				type = methodReference.DeclaringType;
			}
			if (astType == null)
			{
				return null;
			}
			ObjectCreateExpression objectCreateExpression = new ObjectCreateExpression(astType);
			if (invocation.Arguments.Count >= 2)
			{
				IList<ICSharpCode.NRefactory.CSharp.Expression> list = ConvertExpressionsArray(invocation.Arguments.ElementAtOrDefault(1));
				if (list == null)
				{
					return null;
				}
				objectCreateExpression.Arguments.AddRange(list);
			}
			if (invocation.Arguments.Count >= 3 && type.IsAnonymousType())
			{
				MethodDefinition methodDefinition = methodReference.Resolve();
				if (methodDefinition == null || methodDefinition.Parameters.Count != objectCreateExpression.Arguments.Count)
				{
					return null;
				}
				AnonymousTypeCreateExpression anonymousTypeCreateExpression = new AnonymousTypeCreateExpression();
				ICSharpCode.NRefactory.CSharp.Expression[] array = objectCreateExpression.Arguments.ToArray();
				if (AstMethodBodyBuilder.CanInferAnonymousTypePropertyNamesFromArguments(array, methodDefinition.Parameters))
				{
					objectCreateExpression.Arguments.MoveTo(anonymousTypeCreateExpression.Initializers);
				}
				else
				{
					for (int i = 0; i < methodDefinition.Parameters.Count; i++)
					{
						anonymousTypeCreateExpression.Initializers.Add(new NamedExpression
						{
							Name = methodDefinition.Parameters[i].Name,
							Expression = array[i].Detach()
						});
					}
				}
				return anonymousTypeCreateExpression;
			}
			return objectCreateExpression;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertListInit(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			ObjectCreateExpression objectCreateExpression = Convert(invocation.Arguments.ElementAt(0)) as ObjectCreateExpression;
			if (objectCreateExpression == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression elementsArray = invocation.Arguments.ElementAt(1);
			ArrayInitializerExpression arrayInitializerExpression = ConvertElementInit(elementsArray);
			if (arrayInitializerExpression != null)
			{
				objectCreateExpression.Initializer = arrayInitializerExpression;
				return objectCreateExpression;
			}
			return null;
		}

		private ArrayInitializerExpression ConvertElementInit(ICSharpCode.NRefactory.CSharp.Expression elementsArray)
		{
			IList<ICSharpCode.NRefactory.CSharp.Expression> list = ConvertExpressionsArray(elementsArray);
			if (list != null)
			{
				return new ArrayInitializerExpression(list);
			}
			Match match = elementInitArrayPattern.Match(elementsArray);
			if (!match.Success)
			{
				return null;
			}
			ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
			foreach (ICSharpCode.NRefactory.CSharp.Expression item in match.Get<ICSharpCode.NRefactory.CSharp.Expression>("addArgumentsArrays"))
			{
				IList<ICSharpCode.NRefactory.CSharp.Expression> list2 = ConvertExpressionsArray(item);
				if (list2 == null)
				{
					return null;
				}
				arrayInitializerExpression.Elements.Add(new ArrayInitializerExpression(list2));
			}
			return arrayInitializerExpression;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertMemberInit(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			ObjectCreateExpression objectCreateExpression = Convert(invocation.Arguments.ElementAt(0)) as ObjectCreateExpression;
			if (objectCreateExpression == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression elementsArray = invocation.Arguments.ElementAt(1);
			ArrayInitializerExpression arrayInitializerExpression = ConvertMemberBindings(elementsArray);
			if (arrayInitializerExpression == null)
			{
				return null;
			}
			objectCreateExpression.Initializer = arrayInitializerExpression;
			return objectCreateExpression;
		}

		private ArrayInitializerExpression ConvertMemberBindings(ICSharpCode.NRefactory.CSharp.Expression elementsArray)
		{
			Match match = memberBindingArrayPattern.Match(elementsArray);
			if (!match.Success)
			{
				return null;
			}
			ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
			foreach (ICSharpCode.NRefactory.CSharp.Expression item in match.Get<ICSharpCode.NRefactory.CSharp.Expression>("binding"))
			{
				ICSharpCode.NRefactory.CSharp.InvocationExpression invocationExpression = item as ICSharpCode.NRefactory.CSharp.InvocationExpression;
				if (invocationExpression == null || invocationExpression.Arguments.Count != 2)
				{
					return null;
				}
				MemberReferenceExpression memberReferenceExpression = invocationExpression.Target as MemberReferenceExpression;
				if (memberReferenceExpression == null || !expressionTypeReference.IsMatch(memberReferenceExpression.Target))
				{
					return null;
				}
				ICSharpCode.NRefactory.CSharp.Expression other = invocationExpression.Arguments.ElementAt(0);
				ICSharpCode.NRefactory.CSharp.Expression expression = invocationExpression.Arguments.ElementAt(1);
				Match match2 = getMethodFromHandlePattern.Match(other);
				if (!match2.Success)
				{
					return null;
				}
				MethodReference methodReference = match2.Get<AstNode>("method").Single().Annotation<MethodReference>();
				if (methodReference == null)
				{
					return null;
				}
				string propertyName = GetPropertyName(methodReference);
				ICSharpCode.NRefactory.CSharp.Expression expression2;
				switch (memberReferenceExpression.MemberName)
				{
				case "Bind":
					expression2 = Convert(expression);
					break;
				case "MemberBind":
					expression2 = ConvertMemberBindings(expression);
					break;
				case "ListBind":
					expression2 = ConvertElementInit(expression);
					break;
				default:
					return null;
				}
				if (expression2 == null)
				{
					return null;
				}
				arrayInitializerExpression.Elements.Add(new NamedExpression(propertyName, expression2));
			}
			return arrayInitializerExpression;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertCast(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, bool isChecked)
		{
			if (invocation.Arguments.Count < 2)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			AstType astType = ConvertTypeReference(invocation.Arguments.ElementAt(1));
			if (expression != null && astType != null)
			{
				CastExpression castExpression = expression.CastTo(astType);
				castExpression.AddAnnotation(isChecked ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
				switch (invocation.Arguments.Count)
				{
				case 2:
					return castExpression;
				case 3:
				{
					Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(2));
					if (match.Success)
					{
						return castExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<MethodReference>());
					}
					return null;
				}
				}
			}
			return null;
		}

		private static Pattern ArrayInitializationPattern(Type arrayElementType, INode elementPattern)
		{
			return new Choice
			{
				new ArrayCreateExpression
				{
					Type = new TypePattern(arrayElementType),
					Arguments = 
					{
						(ICSharpCode.NRefactory.CSharp.Expression)new PrimitiveExpression(0)
					}
				},
				new ArrayCreateExpression
				{
					Type = new TypePattern(arrayElementType),
					AdditionalArraySpecifiers = 
					{
						new ArraySpecifier()
					},
					Initializer = new ArrayInitializerExpression
					{
						Elements = 
						{
							(ICSharpCode.NRefactory.CSharp.Expression)new Repeat(elementPattern)
						}
					}
				}
			};
		}

		private IList<ICSharpCode.NRefactory.CSharp.Expression> ConvertExpressionsArray(ICSharpCode.NRefactory.CSharp.Expression arrayExpression)
		{
			Match match = expressionArrayPattern.Match(arrayExpression);
			if (match.Success)
			{
				List<ICSharpCode.NRefactory.CSharp.Expression> list = new List<ICSharpCode.NRefactory.CSharp.Expression>();
				{
					foreach (ICSharpCode.NRefactory.CSharp.Expression item in match.Get<ICSharpCode.NRefactory.CSharp.Expression>("elements"))
					{
						ICSharpCode.NRefactory.CSharp.Expression expression = Convert(item);
						if (expression == null)
						{
							return null;
						}
						list.Add(expression);
					}
					return list;
				}
			}
			return null;
		}

		private AstType ConvertTypeReference(ICSharpCode.NRefactory.CSharp.Expression typeOfExpression)
		{
			Match match = typeOfPattern.Match(typeOfExpression);
			if (match.Success)
			{
				return match.Get<AstType>("type").Single().Clone();
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertTypeAs(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			AstType astType = ConvertTypeReference(invocation.Arguments.ElementAt(1));
			if (expression != null && astType != null)
			{
				return new AsExpression(expression, astType);
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertTypeIs(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.ElementAt(0));
			AstType astType = ConvertTypeReference(invocation.Arguments.ElementAt(1));
			if (expression != null && astType != null)
			{
				return new IsExpression
				{
					Expression = expression,
					Type = astType
				};
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertArrayIndex(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			ICSharpCode.NRefactory.CSharp.Expression expression = Convert(invocation.Arguments.First());
			if (expression == null)
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression expression2 = invocation.Arguments.ElementAt(1);
			ICSharpCode.NRefactory.CSharp.Expression expression3 = Convert(expression2);
			if (expression3 != null)
			{
				return new IndexerExpression(expression, expression3);
			}
			IList<ICSharpCode.NRefactory.CSharp.Expression> list = ConvertExpressionsArray(expression2);
			if (list != null)
			{
				return new IndexerExpression(expression, list);
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertArrayLength(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 1)
			{
				return NotSupported(invocation);
			}
			return Convert(invocation.Arguments.Single())?.Member("Length");
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertNewArrayInit(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			AstType astType = ConvertTypeReference(invocation.Arguments.ElementAt(0));
			IList<ICSharpCode.NRefactory.CSharp.Expression> list = ConvertExpressionsArray(invocation.Arguments.ElementAt(1));
			if (astType != null && list != null)
			{
				if (ContainsAnonymousType(astType))
				{
					astType = null;
				}
				return new ArrayCreateExpression
				{
					Type = astType,
					AdditionalArraySpecifiers = 
					{
						new ArraySpecifier()
					},
					Initializer = new ArrayInitializerExpression(list)
				};
			}
			return null;
		}

		private ICSharpCode.NRefactory.CSharp.Expression ConvertNewArrayBounds(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
		{
			if (invocation.Arguments.Count != 2)
			{
				return NotSupported(invocation);
			}
			AstType astType = ConvertTypeReference(invocation.Arguments.ElementAt(0));
			IList<ICSharpCode.NRefactory.CSharp.Expression> list = ConvertExpressionsArray(invocation.Arguments.ElementAt(1));
			if (astType != null && list != null)
			{
				if (ContainsAnonymousType(astType))
				{
					astType = null;
				}
				ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
				arrayCreateExpression.Type = astType;
				arrayCreateExpression.Arguments.AddRange(list);
				return arrayCreateExpression;
			}
			return null;
		}

		private bool ContainsAnonymousType(AstType type)
		{
			foreach (AstType item in type.DescendantsAndSelf.OfType<AstType>())
			{
				TypeReference typeReference = item.Annotation<TypeReference>();
				if (typeReference != null && typeReference.IsAnonymousType())
				{
					return true;
				}
			}
			return false;
		}
	}
}
