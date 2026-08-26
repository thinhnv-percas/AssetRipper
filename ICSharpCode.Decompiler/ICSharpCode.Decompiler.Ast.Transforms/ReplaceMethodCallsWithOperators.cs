using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class ReplaceMethodCallsWithOperators : DepthFirstAstVisitor<object, object>, IAstTransformPoolObject, IAstTransform
{
	public class RestoreOriginalAssignOperatorAnnotation
	{
		private readonly BinaryOperatorExpression binaryOperatorExpression;

		public RestoreOriginalAssignOperatorAnnotation(BinaryOperatorExpression binaryOperatorExpression)
		{
			this.binaryOperatorExpression = binaryOperatorExpression;
		}

		public AssignmentExpression Restore(Expression expression)
		{
			List<ILSpan> allRecursiveILSpans = expression.GetAllRecursiveILSpans();
			expression.RemoveAnnotations<RestoreOriginalAssignOperatorAnnotation>();
			AssignmentExpression assignmentExpression = expression as AssignmentExpression;
			if (assignmentExpression == null)
			{
				UnaryOperatorExpression unaryOperatorExpression = (UnaryOperatorExpression)expression;
				assignmentExpression = new AssignmentExpression(unaryOperatorExpression.Expression.Detach(), new PrimitiveExpression(1));
			}
			else
			{
				assignmentExpression.Operator = AssignmentOperatorType.Assign;
			}
			binaryOperatorExpression.Right = assignmentExpression.Right.Detach();
			assignmentExpression.Right = binaryOperatorExpression;
			assignmentExpression.AddAnnotation(allRecursiveILSpans);
			return assignmentExpression;
		}
	}

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

	private DecompilerContext context;

	private readonly StringBuilder stringBuilder;

	private static readonly UTF8String systemString = new UTF8String("System");

	private static readonly UTF8String typeString = new UTF8String("Type");

	private static readonly UTF8String systemReflectionString = new UTF8String("System.Reflection");

	private static readonly UTF8String fieldInfoString = new UTF8String("FieldInfo");

	private static readonly Expression getMethodOrConstructorFromHandlePattern = new TypePattern(typeof(MethodBase)).ToType().Invoke2(BoxedTextColor.StaticMethod, "GetMethodFromHandle", new NamedNode("ldtokenNode", new LdTokenPattern("method")).ToExpression().Member("MethodHandle", BoxedTextColor.InstanceProperty), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle", BoxedTextColor.InstanceProperty))).CastTo(new Choice
	{
		new TypePattern(typeof(MethodInfo)),
		new TypePattern(typeof(ConstructorInfo))
	});

	public ReplaceMethodCallsWithOperators(DecompilerContext context)
	{
		stringBuilder = new StringBuilder();
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		this.context = context;
	}

	public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
	{
		base.VisitInvocationExpression(invocationExpression, data);
		ProcessInvocationExpression(invocationExpression, stringBuilder);
		return null;
	}

	private static bool CheckType(ITypeDefOrRef tdr, UTF8String expNs, UTF8String expName)
	{
		if (tdr is TypeRef typeRef)
		{
			if (typeRef.Name == expName)
			{
				return typeRef.Namespace == expNs;
			}
			return false;
		}
		if (tdr is TypeDef typeDef)
		{
			if (typeDef.Name == expName)
			{
				return typeDef.Namespace == expNs;
			}
			return false;
		}
		return false;
	}

	internal static void ProcessInvocationExpression(InvocationExpression invocationExpression, StringBuilder sb)
	{
		IMethod method = invocationExpression.Annotation<IMethod>();
		if (method == null)
		{
			return;
		}
		MethodDebugInfoBuilder annotation = invocationExpression.Annotation<MethodDebugInfoBuilder>();
		Expression[] array = invocationExpression.Arguments.ToArray();
		if (method.Name == "Concat" && method.DeclaringType != null && array.Length >= 2 && method.DeclaringType.FullName == "System.String")
		{
			invocationExpression.Arguments.Clear();
			Expression expression = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				expression = new BinaryOperatorExpression(expression, BinaryOperatorType.Add, array[i]);
			}
			invocationExpression.ReplaceWith(expression);
			expression.AddAnnotation(invocationExpression.GetAllRecursiveILSpans());
			expression.AddAnnotation(annotation);
			return;
		}
		string text = ((CheckType(method.DeclaringType, systemString, typeString) || CheckType(method.DeclaringType, systemReflectionString, fieldInfoString)) ? method.Name.String : string.Empty);
		if (!(text == "GetTypeFromHandle"))
		{
			if (text == "GetFieldFromHandle")
			{
				if (array.Length == 1 && method.FullName == "System.Reflection.FieldInfo System.Reflection.FieldInfo::GetFieldFromHandle(System.RuntimeFieldHandle)")
				{
					if (array[0] is MemberReferenceExpression { MemberName: "FieldHandle" } memberReferenceExpression && memberReferenceExpression.Target.Annotation<LdTokenAnnotation>() != null)
					{
						invocationExpression.ReplaceWith(memberReferenceExpression.Target.WithAnnotation(invocationExpression.GetAllRecursiveILSpans()).WithAnnotation(annotation));
						return;
					}
				}
				else if (array.Length == 2 && method.FullName == "System.Reflection.FieldInfo System.Reflection.FieldInfo::GetFieldFromHandle(System.RuntimeFieldHandle,System.RuntimeTypeHandle)")
				{
					MemberReferenceExpression memberReferenceExpression2 = array[0] as MemberReferenceExpression;
					MemberReferenceExpression memberReferenceExpression3 = array[1] as MemberReferenceExpression;
					if (memberReferenceExpression2 != null && memberReferenceExpression2.MemberName == "FieldHandle" && memberReferenceExpression2.Target.Annotation<LdTokenAnnotation>() != null && memberReferenceExpression3 != null && memberReferenceExpression3.MemberName == "TypeHandle" && memberReferenceExpression3.Target is TypeOfExpression)
					{
						Expression expression2 = ((InvocationExpression)memberReferenceExpression2.Target).Arguments.Single();
						IField field = expression2.Annotation<IField>();
						if (field != null)
						{
							List<ILSpan> allRecursiveILSpans = invocationExpression.GetAllRecursiveILSpans();
							AstType astType = ((TypeOfExpression)memberReferenceExpression3.Target).Type.Detach();
							expression2.ReplaceWith(astType.Member(field.Name, field).WithAnnotation(field));
							invocationExpression.ReplaceWith(memberReferenceExpression2.Target.WithAnnotation(allRecursiveILSpans).WithAnnotation(annotation));
							return;
						}
					}
				}
			}
		}
		else if (array.Length == 1 && method.FullName == "System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)" && typeHandleOnTypeOfPattern.IsMatch(array[0]))
		{
			invocationExpression.ReplaceWith(((MemberReferenceExpression)array[0]).Target.WithAnnotation(invocationExpression.GetAllRecursiveILSpans()).WithAnnotation(annotation));
			return;
		}
		BinaryOperatorType? binaryOperatorTypeFromMetadataName = GetBinaryOperatorTypeFromMetadataName(method.Name);
		if (binaryOperatorTypeFromMetadataName.HasValue && array.Length == 2)
		{
			invocationExpression.Arguments.Clear();
			invocationExpression.ReplaceWith(new BinaryOperatorExpression(array[0], binaryOperatorTypeFromMetadataName.Value, array[1]).WithAnnotation(method).WithAnnotation(invocationExpression.GetAllRecursiveILSpans()).WithAnnotation(annotation));
			return;
		}
		UnaryOperatorType? unaryOperatorTypeFromMetadataName = GetUnaryOperatorTypeFromMetadataName(method.Name);
		if (unaryOperatorTypeFromMetadataName.HasValue && array.Length == 1)
		{
			array[0].Remove();
			invocationExpression.ReplaceWith(new UnaryOperatorExpression(unaryOperatorTypeFromMetadataName.Value, array[0]).WithAnnotation(method).WithAnnotation(invocationExpression.GetAllRecursiveILSpans()).WithAnnotation(annotation));
		}
		else if (method.Name == "op_Explicit" && array.Length == 1)
		{
			array[0].Remove();
			invocationExpression.ReplaceWith(array[0].CastTo(AstBuilder.ConvertType(method.MethodSig.GetRetType(), sb)).WithAnnotation(method).WithAnnotation(invocationExpression.GetAllRecursiveILSpans())
				.WithAnnotation(annotation));
		}
		else if (method.Name == "op_Implicit" && array.Length == 1)
		{
			invocationExpression.ReplaceWith(array[0].WithAnnotation(invocationExpression.GetAllRecursiveILSpans()).WithAnnotation(annotation));
		}
		else if (method.Name == "op_True" && array.Length == 1 && invocationExpression.Role == Roles.Condition)
		{
			invocationExpression.ReplaceWith(array[0].WithAnnotation(invocationExpression.GetAllRecursiveILSpans()).WithAnnotation(annotation));
		}
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

	public override object VisitAssignmentExpression(AssignmentExpression assignment, object data)
	{
		base.VisitAssignmentExpression(assignment, data);
		if (assignment.Right is BinaryOperatorExpression binaryOperatorExpression && assignment.Operator == AssignmentOperatorType.Assign && CanConvertToCompoundAssignment(assignment.Left) && assignment.Left.IsMatch(binaryOperatorExpression.Left))
		{
			assignment.Operator = GetAssignmentOperatorForBinaryOperator(binaryOperatorExpression.Operator);
			if (assignment.Operator != AssignmentOperatorType.Assign)
			{
				assignment.CopyAnnotationsFrom(binaryOperatorExpression);
				assignment.Right = binaryOperatorExpression.Right.WithAnnotation(assignment.Right.GetAllRecursiveILSpans());
				assignment.AddAnnotation(new RestoreOriginalAssignOperatorAnnotation(binaryOperatorExpression));
			}
		}
		if (context.Settings.IntroduceIncrementAndDecrement && (assignment.Operator == AssignmentOperatorType.Add || assignment.Operator == AssignmentOperatorType.Subtract) && assignment.Right.IsMatch(new PrimitiveExpression(1)) && assignment.Annotation<IMethod>() == null)
		{
			UnaryOperatorType op = ((!(assignment.Parent is ExpressionStatement)) ? ((assignment.Operator == AssignmentOperatorType.Add) ? UnaryOperatorType.Increment : UnaryOperatorType.Decrement) : ((assignment.Operator == AssignmentOperatorType.Add) ? UnaryOperatorType.PostIncrement : UnaryOperatorType.PostDecrement));
			assignment.ReplaceWith(new UnaryOperatorExpression(op, assignment.Left.Detach()).CopyAnnotationsFrom(assignment).WithAnnotation(assignment.GetAllRecursiveILSpans()));
		}
		return null;
	}

	public static AssignmentOperatorType GetAssignmentOperatorForBinaryOperator(BinaryOperatorType bop)
	{
		return bop switch
		{
			BinaryOperatorType.Add => AssignmentOperatorType.Add, 
			BinaryOperatorType.Subtract => AssignmentOperatorType.Subtract, 
			BinaryOperatorType.Multiply => AssignmentOperatorType.Multiply, 
			BinaryOperatorType.Divide => AssignmentOperatorType.Divide, 
			BinaryOperatorType.Modulus => AssignmentOperatorType.Modulus, 
			BinaryOperatorType.ShiftLeft => AssignmentOperatorType.ShiftLeft, 
			BinaryOperatorType.ShiftRight => AssignmentOperatorType.ShiftRight, 
			BinaryOperatorType.BitwiseAnd => AssignmentOperatorType.BitwiseAnd, 
			BinaryOperatorType.BitwiseOr => AssignmentOperatorType.BitwiseOr, 
			BinaryOperatorType.ExclusiveOr => AssignmentOperatorType.ExclusiveOr, 
			_ => AssignmentOperatorType.Assign, 
		};
	}

	private static bool CanConvertToCompoundAssignment(Expression left)
	{
		if (left is MemberReferenceExpression memberReferenceExpression)
		{
			return IsWithoutSideEffects(memberReferenceExpression.Target);
		}
		if (left is IndexerExpression indexerExpression)
		{
			if (IsWithoutSideEffects(indexerExpression.Target))
			{
				return indexerExpression.Arguments.All(IsWithoutSideEffects);
			}
			return false;
		}
		if (left is UnaryOperatorExpression { Operator: UnaryOperatorType.Dereference } unaryOperatorExpression)
		{
			return IsWithoutSideEffects(unaryOperatorExpression.Expression);
		}
		return IsWithoutSideEffects(left);
	}

	private static bool IsWithoutSideEffects(Expression left)
	{
		if (!(left is ThisReferenceExpression) && !(left is IdentifierExpression) && !(left is TypeReferenceExpression))
		{
			return left is BaseReferenceExpression;
		}
		return true;
	}

	public override object VisitCastExpression(CastExpression castExpression, object data)
	{
		base.VisitCastExpression(castExpression, data);
		Match match = getMethodOrConstructorFromHandlePattern.Match(castExpression);
		if (match.Success)
		{
			List<ILSpan> allRecursiveILSpans = castExpression.GetAllRecursiveILSpans();
			IMethod method = match.Get<AstNode>("method").Single().Annotation<IMethod>();
			if (method != null && match.Has("declaringType"))
			{
				Expression expression = match.Get<AstType>("declaringType").Single().Detach()
					.Member(method.Name, method);
				expression = expression.Invoke(from p in method.MethodSig.GetParameters()
					select new TypeReferenceExpression(AstBuilder.ConvertType(p, stringBuilder)));
				expression.AddAnnotation(method);
				match.Get<AstNode>("method").Single().ReplaceWith(expression);
			}
			castExpression.ReplaceWith(match.Get<AstNode>("ldtokenNode").Single().WithAnnotation(allRecursiveILSpans));
		}
		return null;
	}

	void IAstTransform.Run(AstNode node)
	{
		node.AcceptVisitor(this, null);
	}
}
