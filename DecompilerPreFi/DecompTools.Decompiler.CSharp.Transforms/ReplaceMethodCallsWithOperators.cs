using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class ReplaceMethodCallsWithOperators : DepthFirstAstVisitor, IAstTransform
{
	private static readonly MemberReferenceExpression typeHandleOnTypeOfPattern = new MemberReferenceExpression
	{
		Target = new Choice
		{
			new TypeOfExpression(new AnyNode()),
			new UndocumentedExpression
			{
				UndocumentedExpressionType = UndocumentedExpressionType.RefType,
				Arguments = { (Expression)new AnyNode() }
			}
		},
		MemberName = "TypeHandle"
	};

	private TransformContext context;

	private static readonly Expression getMethodOrConstructorFromHandlePattern = new CastExpression(new Choice
	{
		new TypePattern(typeof(MethodInfo)),
		new TypePattern(typeof(ConstructorInfo))
	}, new InvocationExpression(new MemberReferenceExpression(new TypeReferenceExpression(new TypePattern(typeof(MethodBase)).ToType()), "GetMethodFromHandle"), new NamedNode("ldtokenNode", new MemberReferenceExpression(new LdTokenPattern("method").ToExpression(), "MethodHandle")), new OptionalNode(new MemberReferenceExpression(new TypeOfExpression(new AnyNode("declaringType")), "TypeHandle"))));

	public override void VisitInvocationExpression(InvocationExpression invocationExpression)
	{
		base.VisitInvocationExpression(invocationExpression);
		ProcessInvocationExpression(invocationExpression);
	}

	private void ProcessInvocationExpression(InvocationExpression invocationExpression)
	{
		if (!(invocationExpression.GetSymbol() is IMethod method))
		{
			return;
		}
		Expression[] array = Enumerable.ToArray<Expression>((IEnumerable<Expression>)invocationExpression.Arguments);
		if (method.Name == "Concat" && method.DeclaringType.FullName == "System.String" && CheckArgumentsForStringConcat(array))
		{
			invocationExpression.Arguments.Clear();
			Expression expression = array[0];
			for (int i = 1; i < array.Length; i = checked(i + 1))
			{
				expression = new BinaryOperatorExpression(expression, BinaryOperatorType.Add, array[i]);
			}
			expression.CopyAnnotationsFrom(invocationExpression);
			invocationExpression.ReplaceWith(expression);
			return;
		}
		string fullName = method.FullName;
		if (!(fullName == "System.Type.GetTypeFromHandle"))
		{
			if (fullName == "System.Activator.CreateInstance" && array.Length == 0 && method.TypeArguments.Count == 1 && IsInstantiableTypeParameter(method.TypeArguments[0]))
			{
				invocationExpression.ReplaceWith(new ObjectCreateExpression(context.TypeSystemAstBuilder.ConvertType(Enumerable.First<IType>((IEnumerable<IType>)method.TypeArguments))));
			}
		}
		else if (array.Length == 1 && typeHandleOnTypeOfPattern.IsMatch(array[0]))
		{
			Expression target = ((MemberReferenceExpression)array[0]).Target;
			target.CopyInstructionsFrom(invocationExpression);
			invocationExpression.ReplaceWith(target);
			return;
		}
		BinaryOperatorType? binaryOperatorTypeFromMetadataName = GetBinaryOperatorTypeFromMetadataName(method.Name);
		if (binaryOperatorTypeFromMetadataName.HasValue && array.Length == 2)
		{
			invocationExpression.Arguments.Clear();
			invocationExpression.ReplaceWith(new BinaryOperatorExpression(array[0], binaryOperatorTypeFromMetadataName.Value, array[1]).CopyAnnotationsFrom(invocationExpression));
			return;
		}
		UnaryOperatorType? unaryOperatorTypeFromMetadataName = GetUnaryOperatorTypeFromMetadataName(method.Name);
		if (unaryOperatorTypeFromMetadataName.HasValue && array.Length == 1)
		{
			array[0].Remove();
			invocationExpression.ReplaceWith(new UnaryOperatorExpression(unaryOperatorTypeFromMetadataName.Value, array[0]).CopyAnnotationsFrom(invocationExpression));
		}
		else if (method.Name == "op_Explicit" && array.Length == 1)
		{
			array[0].Remove();
			invocationExpression.ReplaceWith(new CastExpression(context.TypeSystemAstBuilder.ConvertType(method.ReturnType), array[0]).CopyAnnotationsFrom(invocationExpression));
		}
		else if (method.Name == "op_True" && array.Length == 1 && invocationExpression.Role == Roles.Condition)
		{
			invocationExpression.ReplaceWith(array[0]);
		}
	}

	private bool IsInstantiableTypeParameter(IType type)
	{
		return type is ITypeParameter typeParameter && typeParameter.HasDefaultConstructorConstraint;
	}

	private bool CheckArgumentsForStringConcat(Expression[] arguments)
	{
		if (arguments.Length < 2)
		{
			return false;
		}
		return arguments[0].GetResolveResult().Type.IsKnownType(KnownTypeCode.String) || arguments[1].GetResolveResult().Type.IsKnownType(KnownTypeCode.String);
	}

	private static BinaryOperatorType? GetBinaryOperatorTypeFromMetadataName(string name)
	{
		return name switch
		{
			"op_Addition" => BinaryOperatorType.Add, 
			"op_Subtraction" => BinaryOperatorType.Subtract, 
			"op_Multiply" => BinaryOperatorType.Multiply, 
			"op_Division" => BinaryOperatorType.Divide, 
			"op_Modulus" => BinaryOperatorType.Modulus, 
			"op_BitwiseAnd" => BinaryOperatorType.BitwiseAnd, 
			"op_BitwiseOr" => BinaryOperatorType.BitwiseOr, 
			"op_ExclusiveOr" => BinaryOperatorType.ExclusiveOr, 
			"op_LeftShift" => BinaryOperatorType.ShiftLeft, 
			"op_RightShift" => BinaryOperatorType.ShiftRight, 
			"op_Equality" => BinaryOperatorType.Equality, 
			"op_Inequality" => BinaryOperatorType.InEquality, 
			"op_LessThan" => BinaryOperatorType.LessThan, 
			"op_LessThanOrEqual" => BinaryOperatorType.LessThanOrEqual, 
			"op_GreaterThan" => BinaryOperatorType.GreaterThan, 
			"op_GreaterThanOrEqual" => BinaryOperatorType.GreaterThanOrEqual, 
			_ => null, 
		};
	}

	private static UnaryOperatorType? GetUnaryOperatorTypeFromMetadataName(string name)
	{
		return name switch
		{
			"op_LogicalNot" => UnaryOperatorType.Not, 
			"op_OnesComplement" => UnaryOperatorType.BitNot, 
			"op_UnaryNegation" => UnaryOperatorType.Minus, 
			"op_UnaryPlus" => UnaryOperatorType.Plus, 
			"op_Increment" => UnaryOperatorType.Increment, 
			"op_Decrement" => UnaryOperatorType.Decrement, 
			_ => null, 
		};
	}

	public override void VisitCastExpression(CastExpression castExpression)
	{
		base.VisitCastExpression(castExpression);
		Match match = getMethodOrConstructorFromHandlePattern.Match(castExpression);
		if (!match.Success)
		{
			return;
		}
		IMethod method = Enumerable.Single<AstNode>(match.Get<AstNode>("method")).GetSymbol() as IMethod;
		if (match.Has("declaringType") && method != null)
		{
			Expression target = new MemberReferenceExpression(new TypeReferenceExpression(Enumerable.Single<AstType>(match.Get<AstType>("declaringType")).Detach()), method.Name);
			target = new InvocationExpression(target, Enumerable.Select<IParameter, TypeReferenceExpression>((IEnumerable<IParameter>)method.Parameters, (Func<IParameter, TypeReferenceExpression>)((IParameter p) => new TypeReferenceExpression(context.TypeSystemAstBuilder.ConvertType(p.Type)))));
			Enumerable.Single<AstNode>(match.Get<AstNode>("method")).ReplaceWith(target);
		}
		castExpression.ReplaceWith(Enumerable.Single<AstNode>(match.Get<AstNode>("ldtokenNode")).CopyAnnotationsFrom(castExpression));
	}

	void IAstTransform.Run(AstNode rootNode, TransformContext context)
	{
		try
		{
			this.context = context;
			rootNode.AcceptVisitor(this);
		}
		finally
		{
			this.context = null;
		}
	}
}
