using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using System.Linq;
using System.Reflection;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class ReplaceMethodCallsWithOperators : DepthFirstAstVisitor<object, object>, IAstTransform
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
				expression.RemoveAnnotations<RestoreOriginalAssignOperatorAnnotation>();
				AssignmentExpression assignmentExpression = expression as AssignmentExpression;
				if (assignmentExpression == null)
				{
					assignmentExpression = new AssignmentExpression(((UnaryOperatorExpression)expression).Expression.Detach(), new PrimitiveExpression(1));
				}
				else
				{
					assignmentExpression.Operator = AssignmentOperatorType.Assign;
				}
				binaryOperatorExpression.Right = assignmentExpression.Right.Detach();
				assignmentExpression.Right = binaryOperatorExpression;
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
					Arguments = 
					{
						(Expression)new AnyNode()
					}
				}
			},
			MemberName = "TypeHandle"
		};

		private DecompilerContext context;

		private static readonly Expression getMethodOrConstructorFromHandlePattern = new TypePattern(typeof(MethodBase)).ToType().Invoke("GetMethodFromHandle", new NamedNode("ldtokenNode", new LdTokenPattern("method")).ToExpression().Member("MethodHandle"), new OptionalNode(new TypeOfExpression(new AnyNode("declaringType")).Member("TypeHandle"))).CastTo(new Choice
		{
			new TypePattern(typeof(MethodInfo)),
			new TypePattern(typeof(ConstructorInfo))
		});

		public ReplaceMethodCallsWithOperators(DecompilerContext context)
		{
			this.context = context;
		}

		public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
		{
			base.VisitInvocationExpression(invocationExpression, data);
			ProcessInvocationExpression(invocationExpression);
			return null;
		}

		internal static void ProcessInvocationExpression(InvocationExpression invocationExpression)
		{
			MethodReference methodReference = invocationExpression.Annotation<MethodReference>();
			if (methodReference == null)
			{
				return;
			}
			Expression[] array = invocationExpression.Arguments.ToArray();
			if (methodReference.Name == "Concat" && methodReference.DeclaringType.FullName == "System.String" && array.Length >= 2)
			{
				invocationExpression.Arguments.Clear();
				Expression expression = array[0];
				for (int i = 1; i < array.Length; i++)
				{
					expression = new BinaryOperatorExpression(expression, BinaryOperatorType.Add, array[i]);
				}
				invocationExpression.ReplaceWith(expression);
				return;
			}
			switch (methodReference.FullName)
			{
			case "System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)":
				if (array.Length == 1 && typeHandleOnTypeOfPattern.IsMatch(array[0]))
				{
					invocationExpression.ReplaceWith(((MemberReferenceExpression)array[0]).Target);
					return;
				}
				break;
			case "System.Reflection.FieldInfo System.Reflection.FieldInfo::GetFieldFromHandle(System.RuntimeFieldHandle)":
				if (array.Length == 1)
				{
					MemberReferenceExpression memberReferenceExpression3 = array[0] as MemberReferenceExpression;
					if (memberReferenceExpression3 != null && memberReferenceExpression3.MemberName == "FieldHandle" && memberReferenceExpression3.Target.Annotation<LdTokenAnnotation>() != null)
					{
						invocationExpression.ReplaceWith(memberReferenceExpression3.Target);
						return;
					}
				}
				break;
			case "System.Reflection.FieldInfo System.Reflection.FieldInfo::GetFieldFromHandle(System.RuntimeFieldHandle,System.RuntimeTypeHandle)":
			{
				if (array.Length != 2)
				{
					break;
				}
				MemberReferenceExpression memberReferenceExpression = array[0] as MemberReferenceExpression;
				MemberReferenceExpression memberReferenceExpression2 = array[1] as MemberReferenceExpression;
				if (memberReferenceExpression != null && memberReferenceExpression.MemberName == "FieldHandle" && memberReferenceExpression.Target.Annotation<LdTokenAnnotation>() != null && memberReferenceExpression2 != null && memberReferenceExpression2.MemberName == "TypeHandle" && memberReferenceExpression2.Target is TypeOfExpression)
				{
					Expression expression2 = ((InvocationExpression)memberReferenceExpression.Target).Arguments.Single();
					FieldReference fieldReference = expression2.Annotation<FieldReference>();
					if (fieldReference != null)
					{
						AstType astType = ((TypeOfExpression)memberReferenceExpression2.Target).Type.Detach();
						expression2.ReplaceWith(astType.Member(fieldReference.Name).WithAnnotation(fieldReference));
						invocationExpression.ReplaceWith(memberReferenceExpression.Target);
						return;
					}
				}
				break;
			}
			}
			BinaryOperatorType? binaryOperatorTypeFromMetadataName = GetBinaryOperatorTypeFromMetadataName(methodReference.Name);
			if (binaryOperatorTypeFromMetadataName.HasValue && array.Length == 2)
			{
				invocationExpression.Arguments.Clear();
				invocationExpression.ReplaceWith(new BinaryOperatorExpression(array[0], binaryOperatorTypeFromMetadataName.Value, array[1]).WithAnnotation(methodReference));
				return;
			}
			UnaryOperatorType? unaryOperatorTypeFromMetadataName = GetUnaryOperatorTypeFromMetadataName(methodReference.Name);
			if (unaryOperatorTypeFromMetadataName.HasValue && array.Length == 1)
			{
				array[0].Remove();
				invocationExpression.ReplaceWith(new UnaryOperatorExpression(unaryOperatorTypeFromMetadataName.Value, array[0]).WithAnnotation(methodReference));
			}
			else if (methodReference.Name == "op_Explicit" && array.Length == 1)
			{
				array[0].Remove();
				invocationExpression.ReplaceWith(array[0].CastTo(AstBuilder.ConvertType(methodReference.ReturnType, methodReference.MethodReturnType)).WithAnnotation(methodReference));
			}
			else if (methodReference.Name == "op_Implicit" && array.Length == 1)
			{
				invocationExpression.ReplaceWith(array[0]);
			}
			else if (methodReference.Name == "op_True" && array.Length == 1 && invocationExpression.Role == Roles.Condition)
			{
				invocationExpression.ReplaceWith(array[0]);
			}
		}

		private static BinaryOperatorType? GetBinaryOperatorTypeFromMetadataName(string name)
		{
			switch (name)
			{
			case "op_Addition":
				return BinaryOperatorType.Add;
			case "op_Subtraction":
				return BinaryOperatorType.Subtract;
			case "op_Multiply":
				return BinaryOperatorType.Multiply;
			case "op_Division":
				return BinaryOperatorType.Divide;
			case "op_Modulus":
				return BinaryOperatorType.Modulus;
			case "op_BitwiseAnd":
				return BinaryOperatorType.BitwiseAnd;
			case "op_BitwiseOr":
				return BinaryOperatorType.BitwiseOr;
			case "op_ExclusiveOr":
				return BinaryOperatorType.ExclusiveOr;
			case "op_LeftShift":
				return BinaryOperatorType.ShiftLeft;
			case "op_RightShift":
				return BinaryOperatorType.ShiftRight;
			case "op_Equality":
				return BinaryOperatorType.Equality;
			case "op_Inequality":
				return BinaryOperatorType.InEquality;
			case "op_LessThan":
				return BinaryOperatorType.LessThan;
			case "op_LessThanOrEqual":
				return BinaryOperatorType.LessThanOrEqual;
			case "op_GreaterThan":
				return BinaryOperatorType.GreaterThan;
			case "op_GreaterThanOrEqual":
				return BinaryOperatorType.GreaterThanOrEqual;
			default:
				return null;
			}
		}

		private static UnaryOperatorType? GetUnaryOperatorTypeFromMetadataName(string name)
		{
			if (!(name == "op_LogicalNot"))
			{
				if (!(name == "op_OnesComplement"))
				{
					if (!(name == "op_UnaryNegation"))
					{
						if (!(name == "op_UnaryPlus"))
						{
							if (!(name == "op_Increment"))
							{
								if (name == "op_Decrement")
								{
									return UnaryOperatorType.Decrement;
								}
								return null;
							}
							return UnaryOperatorType.Increment;
						}
						return UnaryOperatorType.Plus;
					}
					return UnaryOperatorType.Minus;
				}
				return UnaryOperatorType.BitNot;
			}
			return UnaryOperatorType.Not;
		}

		public override object VisitAssignmentExpression(AssignmentExpression assignment, object data)
		{
			base.VisitAssignmentExpression(assignment, data);
			BinaryOperatorExpression binaryOperatorExpression = assignment.Right as BinaryOperatorExpression;
			if (binaryOperatorExpression != null && assignment.Operator == AssignmentOperatorType.Assign && CanConvertToCompoundAssignment(assignment.Left) && assignment.Left.IsMatch(binaryOperatorExpression.Left))
			{
				assignment.Operator = GetAssignmentOperatorForBinaryOperator(binaryOperatorExpression.Operator);
				if (assignment.Operator != 0)
				{
					assignment.CopyAnnotationsFrom(binaryOperatorExpression);
					assignment.Right = binaryOperatorExpression.Right;
					assignment.AddAnnotation(new RestoreOriginalAssignOperatorAnnotation(binaryOperatorExpression));
				}
			}
			if (context.Settings.IntroduceIncrementAndDecrement && (assignment.Operator == AssignmentOperatorType.Add || assignment.Operator == AssignmentOperatorType.Subtract) && assignment.Right.IsMatch(new PrimitiveExpression(1)) && assignment.Annotation<MethodReference>() == null)
			{
				UnaryOperatorType op = (!(assignment.Parent is ExpressionStatement)) ? ((assignment.Operator == AssignmentOperatorType.Add) ? UnaryOperatorType.Increment : UnaryOperatorType.Decrement) : ((assignment.Operator == AssignmentOperatorType.Add) ? UnaryOperatorType.PostIncrement : UnaryOperatorType.PostDecrement);
				assignment.ReplaceWith(new UnaryOperatorExpression(op, assignment.Left.Detach()).CopyAnnotationsFrom(assignment));
			}
			return null;
		}

		public static AssignmentOperatorType GetAssignmentOperatorForBinaryOperator(BinaryOperatorType bop)
		{
			switch (bop)
			{
			case BinaryOperatorType.Add:
				return AssignmentOperatorType.Add;
			case BinaryOperatorType.Subtract:
				return AssignmentOperatorType.Subtract;
			case BinaryOperatorType.Multiply:
				return AssignmentOperatorType.Multiply;
			case BinaryOperatorType.Divide:
				return AssignmentOperatorType.Divide;
			case BinaryOperatorType.Modulus:
				return AssignmentOperatorType.Modulus;
			case BinaryOperatorType.ShiftLeft:
				return AssignmentOperatorType.ShiftLeft;
			case BinaryOperatorType.ShiftRight:
				return AssignmentOperatorType.ShiftRight;
			case BinaryOperatorType.BitwiseAnd:
				return AssignmentOperatorType.BitwiseAnd;
			case BinaryOperatorType.BitwiseOr:
				return AssignmentOperatorType.BitwiseOr;
			case BinaryOperatorType.ExclusiveOr:
				return AssignmentOperatorType.ExclusiveOr;
			default:
				return AssignmentOperatorType.Assign;
			}
		}

		private static bool CanConvertToCompoundAssignment(Expression left)
		{
			MemberReferenceExpression memberReferenceExpression = left as MemberReferenceExpression;
			if (memberReferenceExpression != null)
			{
				return IsWithoutSideEffects(memberReferenceExpression.Target);
			}
			IndexerExpression indexerExpression = left as IndexerExpression;
			if (indexerExpression != null)
			{
				if (IsWithoutSideEffects(indexerExpression.Target))
				{
					return indexerExpression.Arguments.All(IsWithoutSideEffects);
				}
				return false;
			}
			UnaryOperatorExpression unaryOperatorExpression = left as UnaryOperatorExpression;
			if (unaryOperatorExpression != null && unaryOperatorExpression.Operator == UnaryOperatorType.Dereference)
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
				MethodReference methodReference = match.Get<AstNode>("method").Single().Annotation<MethodReference>();
				if (match.Has("declaringType"))
				{
					Expression expression = match.Get<AstType>("declaringType").Single().Detach()
						.Member(methodReference.Name);
					expression = expression.Invoke(from p in methodReference.Parameters
						select new TypeReferenceExpression(AstBuilder.ConvertType(p.ParameterType, p)));
					expression.AddAnnotation(methodReference);
					match.Get<AstNode>("method").Single().ReplaceWith(expression);
				}
				castExpression.ReplaceWith(match.Get<AstNode>("ldtokenNode").Single());
			}
			return null;
		}

		void IAstTransform.Run(AstNode node)
		{
			node.AcceptVisitor(this, null);
		}
	}
}
