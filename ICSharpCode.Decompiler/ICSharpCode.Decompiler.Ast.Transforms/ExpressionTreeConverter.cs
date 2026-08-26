using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class ExpressionTreeConverter
{
	private readonly DecompilerContext context;

	private Stack<ICSharpCode.NRefactory.CSharp.LambdaExpression> activeLambdas = new Stack<ICSharpCode.NRefactory.CSharp.LambdaExpression>();

	private readonly StringBuilder stringBuilder;

	private static readonly ICSharpCode.NRefactory.CSharp.Expression emptyArrayPattern = new ArrayCreateExpression
	{
		Type = new AnyNode(),
		Arguments = { (ICSharpCode.NRefactory.CSharp.Expression)new PrimitiveExpression(0) }
	};

	private static readonly ICSharpCode.NRefactory.CSharp.Expression getFieldFromHandlePattern = new TypePattern(typeof(FieldInfo)).ToType().Invoke2(BoxedTextColor.StaticMethod, "GetFieldFromHandle", new LdTokenPattern("field").ToExpression().Member("FieldHandle", BoxedTextColor.InstanceProperty), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle", BoxedTextColor.InstanceProperty)));

	private static readonly ICSharpCode.NRefactory.CSharp.Expression getMethodFromHandlePattern = new TypePattern(typeof(MethodBase)).ToType().Invoke2(BoxedTextColor.StaticMethod, "GetMethodFromHandle", new LdTokenPattern("method").ToExpression().Member("MethodHandle", BoxedTextColor.InstanceProperty), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle", BoxedTextColor.InstanceProperty))).CastTo(new TypePattern(typeof(MethodInfo)));

	private static readonly Pattern trueOrFalse = new Choice
	{
		new PrimitiveExpression(true),
		new PrimitiveExpression(false)
	};

	private static readonly ICSharpCode.NRefactory.CSharp.Expression newObjectCtorPattern = new TypePattern(typeof(MethodBase)).ToType().Invoke2(BoxedTextColor.StaticMethod, "GetMethodFromHandle", new LdTokenPattern("ctor").ToExpression().Member("MethodHandle", BoxedTextColor.InstanceProperty), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle", BoxedTextColor.InstanceProperty))).CastTo(new TypePattern(typeof(ConstructorInfo)));

	private static readonly Pattern elementInitArrayPattern = ArrayInitializationPattern(typeof(ElementInit), new TypePattern(typeof(System.Linq.Expressions.Expression)).ToType().Invoke("ElementInit", new AnyNode("methodInfos"), new AnyNode("addArgumentsArrays")));

	private static readonly Pattern memberBindingArrayPattern = ArrayInitializationPattern(typeof(MemberBinding), new AnyNode("binding"));

	private static readonly INode expressionTypeReference = new TypeReferenceExpression(new TypePattern(typeof(System.Linq.Expressions.Expression)));

	private static readonly Pattern expressionArrayPattern = ArrayInitializationPattern(typeof(System.Linq.Expressions.Expression), new AnyNode("elements"));

	private static readonly TypeOfPattern typeOfPattern = new TypeOfPattern("type");

	private IMDTokenProvider Create_SystemArray_get_Length_result;

	private bool Create_SystemArray_get_Length_result_initd;

	public static bool CouldBeExpressionTree(ICSharpCode.NRefactory.CSharp.InvocationExpression expr)
	{
		if (expr != null && expr.Arguments.Count == 2)
		{
			IMethod method = expr.Annotation<IMethod>();
			if (method != null && method.Name == "Lambda" && method.DeclaringType != null)
			{
				return method.DeclaringType.FullName == "System.Linq.Expressions.Expression";
			}
			return false;
		}
		return false;
	}

	public static ICSharpCode.NRefactory.CSharp.Expression TryConvert(DecompilerContext context, ICSharpCode.NRefactory.CSharp.Expression expr, StringBuilder sb)
	{
		ICSharpCode.NRefactory.CSharp.Expression expression = new ExpressionTreeConverter(context, sb).Convert(expr);
		expression?.AddAnnotation(new ExpressionTreeLambdaAnnotation());
		return expression;
	}

	private ExpressionTreeConverter(DecompilerContext context, StringBuilder sb)
	{
		this.context = context;
		stringBuilder = sb;
	}

	private ICSharpCode.NRefactory.CSharp.Expression Convert(ICSharpCode.NRefactory.CSharp.Expression expr)
	{
		if (expr is ICSharpCode.NRefactory.CSharp.InvocationExpression invocationExpression)
		{
			IMethod method = invocationExpression.Annotation<IMethod>();
			if (method != null && method.DeclaringType != null && method.DeclaringType.FullName == "System.Linq.Expressions.Expression")
			{
				switch (method.Name)
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
		if (expr is IdentifierExpression identifierExpression)
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
							return IdentifierExpression.Create(parameter.Name, iLVariable.IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local).WithAnnotation(iLVariable);
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
		if (!(invocation.Arguments.Last() is ArrayCreateExpression other))
		{
			return NotSupported(invocation);
		}
		ParameterDeclarationAnnotation parameterDeclarationAnnotation = expression.Annotation<ParameterDeclarationAnnotation>();
		if (parameterDeclarationAnnotation != null)
		{
			lambdaExpression.Parameters.AddRange(parameterDeclarationAnnotation.GetParameters());
		}
		else if (!emptyArrayPattern.IsMatch(other))
		{
			return null;
		}
		activeLambdas.Push(lambdaExpression);
		ICSharpCode.NRefactory.CSharp.Expression expression2 = Convert(expression);
		activeLambdas.Pop();
		if (expression2 == null)
		{
			lambdaExpression.Parameters.Clear();
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
		IField field = match.Get<AstNode>("field").Single().Annotation<IField>();
		if (field == null)
		{
			return null;
		}
		ICSharpCode.NRefactory.CSharp.Expression expression = invocation.Arguments.ElementAt(0);
		ICSharpCode.NRefactory.CSharp.Expression expression2;
		if (expression is NullReferenceExpression)
		{
			expression2 = ((!match.Has("declaringType")) ? new TypeReferenceExpression(AstBuilder.ConvertType(field.DeclaringType, stringBuilder)) : new TypeReferenceExpression(match.Get<AstType>("declaringType").Single().Clone()));
		}
		else
		{
			expression2 = Convert(expression);
			if (expression2 == null)
			{
				return null;
			}
		}
		return expression2.Member(field.Name, field).WithAnnotation(field);
	}

	private ICSharpCode.NRefactory.CSharp.Expression ConvertProperty(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return NotSupported(invocation);
		}
		Match match = getMethodFromHandlePattern.Match(invocation.Arguments.ElementAt(1));
		if (!match.Success)
		{
			return NotSupported(invocation);
		}
		IMethod method = match.Get<AstNode>("method").Single().Annotation<IMethod>();
		if (method == null)
		{
			return null;
		}
		ICSharpCode.NRefactory.CSharp.Expression expression = invocation.Arguments.ElementAt(0);
		ICSharpCode.NRefactory.CSharp.Expression expression2;
		if (expression is NullReferenceExpression)
		{
			expression2 = ((!match.Has("declaringType")) ? new TypeReferenceExpression(AstBuilder.ConvertType(method.DeclaringType, stringBuilder)) : new TypeReferenceExpression(match.Get<AstType>("declaringType").Single().Clone()));
		}
		else
		{
			expression2 = Convert(expression);
			if (expression2 == null)
			{
				return null;
			}
		}
		return expression2.Member(GetPropertyName(method), (method.MethodSig == null || method.MethodSig.HasThis) ? BoxedTextColor.InstanceProperty : BoxedTextColor.StaticProperty).WithAnnotation(method);
	}

	private string GetPropertyName(IMethod accessor)
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
		IMethod method = match.Get<AstNode>("method").Single().Annotation<IMethod>();
		if (method == null)
		{
			return null;
		}
		ICSharpCode.NRefactory.CSharp.Expression expression2;
		if (expression == null || expression is NullReferenceExpression)
		{
			expression2 = ((!match.Has("declaringType")) ? new TypeReferenceExpression(AstBuilder.ConvertType(method.DeclaringType, stringBuilder)) : new TypeReferenceExpression(match.Get<AstType>("declaringType").Single().Clone()));
		}
		else
		{
			expression2 = Convert(expression);
			if (expression2 == null)
			{
				return null;
			}
		}
		MemberReferenceExpression memberReferenceExpression = expression2.Member(method.Name, method);
		if (method is MethodSpec { GenericInstMethodSig: not null } methodSpec)
		{
			foreach (TypeSig genericArgument in methodSpec.GenericInstMethodSig.GenericArguments)
			{
				memberReferenceExpression.TypeArguments.Add(AstBuilder.ConvertType(genericArgument, stringBuilder));
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
		MethodDef methodDef = method.Resolve();
		if (methodDef != null)
		{
			if (methodDef.IsGetter)
			{
				PropertyDef indexer = AstMethodBodyBuilder.GetIndexer(methodDef);
				if (indexer != null)
				{
					return new IndexerExpression(memberReferenceExpression.Target.Detach(), list).WithAnnotation(indexer);
				}
			}
		}
		else if (method.Name == "get_Item")
		{
			return new IndexerExpression(memberReferenceExpression.Target.Detach(), list).WithAnnotation(method);
		}
		return new ICSharpCode.NRefactory.CSharp.InvocationExpression(memberReferenceExpression, list).WithAnnotation(method);
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

	private ICSharpCode.NRefactory.CSharp.Expression ConvertBinaryOperator(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, BinaryOperatorType op, bool? isChecked = null)
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
				return binaryOperatorExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<IMethod>());
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
				return binaryOperatorExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<IMethod>());
			}
			return null;
		}
		default:
			return NotSupported(invocation);
		}
	}

	private ICSharpCode.NRefactory.CSharp.Expression ConvertAssignmentOperator(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, AssignmentOperatorType op, bool? isChecked = null)
	{
		return NotSupported(invocation);
	}

	private ICSharpCode.NRefactory.CSharp.Expression ConvertUnaryOperator(ICSharpCode.NRefactory.CSharp.InvocationExpression invocation, UnaryOperatorType op, bool? isChecked = null)
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
				return unaryOperatorExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<IMethod>());
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
		IMethod method = match.Get<AstNode>("ctor").Single().Annotation<IMethod>();
		if (method == null)
		{
			return null;
		}
		AstType astType;
		ITypeDefOrRef type;
		if (match.Has("declaringType"))
		{
			astType = match.Get<AstType>("declaringType").Single().Clone();
			type = astType.Annotation<ITypeDefOrRef>();
		}
		else
		{
			astType = AstBuilder.ConvertType(method.DeclaringType, stringBuilder);
			type = method.DeclaringType;
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
			MethodDef methodDef = method.Resolve();
			if (methodDef == null)
			{
				return null;
			}
			int parametersSkip = methodDef.Parameters.GetParametersSkip();
			if (methodDef.Parameters.Count - parametersSkip != objectCreateExpression.Arguments.Count)
			{
				return null;
			}
			AnonymousTypeCreateExpression anonymousTypeCreateExpression = new AnonymousTypeCreateExpression();
			ICSharpCode.NRefactory.CSharp.Expression[] array = objectCreateExpression.Arguments.ToArray();
			if (AstMethodBodyBuilder.CanInferAnonymousTypePropertyNamesFromArguments(array, methodDef.Parameters))
			{
				objectCreateExpression.Arguments.MoveTo(anonymousTypeCreateExpression.Initializers);
			}
			else
			{
				for (int i = 0; i < methodDef.Parameters.Count - parametersSkip; i++)
				{
					anonymousTypeCreateExpression.Initializers.Add(new NamedExpression
					{
						NameToken = Identifier.Create(methodDef.Parameters[i + parametersSkip].Name).WithAnnotation(methodDef.Parameters[i + parametersSkip]),
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
		if (!(Convert(invocation.Arguments.ElementAt(0)) is ObjectCreateExpression objectCreateExpression))
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
		if (!(Convert(invocation.Arguments.ElementAt(0)) is ObjectCreateExpression objectCreateExpression))
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
			if (!(item is ICSharpCode.NRefactory.CSharp.InvocationExpression invocationExpression) || invocationExpression.Arguments.Count != 2)
			{
				return null;
			}
			if (!(invocationExpression.Target is MemberReferenceExpression memberReferenceExpression) || !expressionTypeReference.IsMatch(memberReferenceExpression.Target))
			{
				return null;
			}
			ICSharpCode.NRefactory.CSharp.Expression other = invocationExpression.Arguments.ElementAt(0);
			ICSharpCode.NRefactory.CSharp.Expression expression = invocationExpression.Arguments.ElementAt(1);
			Match match2 = getMethodFromHandlePattern.Match(other);
			if (match2.Success)
			{
				IMethod method = match2.Get<AstNode>("method").Single().Annotation<IMethod>();
				if (method == null)
				{
					return null;
				}
				string propertyName = GetPropertyName(method);
				object idAnnotation = ((method.MethodSig == null || method.MethodSig.HasThis) ? BoxedTextColor.InstanceProperty : BoxedTextColor.StaticProperty);
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
				arrayInitializerExpression.Elements.Add(new NamedExpression(propertyName, expression2, idAnnotation));
				continue;
			}
			return null;
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
					return castExpression.WithAnnotation(match.Get<AstNode>("method").Single().Annotation<IMethod>());
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
				Arguments = { (ICSharpCode.NRefactory.CSharp.Expression)new PrimitiveExpression(0) }
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
					Elements = { (ICSharpCode.NRefactory.CSharp.Expression)new Repeat(elementPattern) }
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
		return Convert(invocation.Arguments.Single())?.Member("Length", BoxedTextColor.InstanceProperty).WithAnnotation(Create_SystemArray_get_Length());
	}

	private ModuleDef GetModule()
	{
		if (context.CurrentMethod != null && context.CurrentMethod.Module != null)
		{
			return context.CurrentMethod.Module;
		}
		if (context.CurrentType != null && context.CurrentType.Module != null)
		{
			return context.CurrentType.Module;
		}
		if (context.CurrentModule != null)
		{
			return context.CurrentModule;
		}
		return null;
	}

	private IMDTokenProvider Create_SystemArray_get_Length()
	{
		if (Create_SystemArray_get_Length_result_initd)
		{
			return Create_SystemArray_get_Length_result;
		}
		Create_SystemArray_get_Length_result_initd = true;
		ModuleDef module = GetModule();
		if (module == null)
		{
			return null;
		}
		TypeRef typeRef = module.CorLibTypes.GetTypeRef("System", "Array");
		CorLibTypeSig @int = module.CorLibTypes.Int32;
		MemberRefUser memberRefUser = (MemberRefUser)(Create_SystemArray_get_Length_result = new MemberRefUser(module, "get_Length", MethodSig.CreateInstance(@int), typeRef));
		MethodDef methodDef = memberRefUser.ResolveMethod();
		if (methodDef == null || methodDef.DeclaringType == null)
		{
			return memberRefUser;
		}
		PropertyDef propertyDef = methodDef.DeclaringType.FindProperty("Length");
		if (propertyDef == null)
		{
			return memberRefUser;
		}
		Create_SystemArray_get_Length_result = propertyDef;
		return propertyDef;
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
			ITypeDefOrRef typeDefOrRef = item.Annotation<ITypeDefOrRef>();
			if (typeDefOrRef != null && typeDefOrRef.IsAnonymousType())
			{
				return true;
			}
		}
		return false;
	}
}
