using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.VB.Ast;

namespace ICSharpCode.NRefactory.VB.Visitors;

public class CSharpToVBConverterVisitor : ICSharpCode.NRefactory.CSharp.IAstVisitor<object, AstNode>
{
	private enum ConvertedStatementKind
	{
		None,
		While,
		For
	}

	private class MemberInfo
	{
		public bool inIterator;
	}

	private struct ImplementsResult
	{
		public ITypeDefOrRef Type { get; }

		public string OriginalName { get; }

		public object Reference { get; }

		public ImplementsResult(IMethodDefOrRef method, object reference)
			: this(method.DeclaringType, method.Name, reference)
		{
		}

		public ImplementsResult(ITypeDefOrRef type, string originalName, object reference)
		{
			Type = type;
			OriginalName = originalName;
			Reference = reference;
		}
	}

	private IEnvironmentProvider provider;

	private Stack<ICSharpCode.NRefactory.VB.Ast.BlockStatement> blocks;

	private Stack<ICSharpCode.NRefactory.VB.Ast.TypeDeclaration> types;

	private Stack<MemberInfo> members;

	private readonly ModuleDef module;

	private int selectVarCount;

	private readonly Dictionary<ICSharpCode.NRefactory.CSharp.AstNode, ConvertedStatementKind> convertedKind = new Dictionary<ICSharpCode.NRefactory.CSharp.AstNode, ConvertedStatementKind>();

	private static readonly UTF8String stringMicrosoftVisualBasicCompilerServices = new UTF8String("Microsoft.VisualBasic.CompilerServices");

	private static readonly UTF8String stringStandardModuleAttribute = new UTF8String("StandardModuleAttribute");

	private Dictionary<TypeDef, Dictionary<string, uint>> modifiersDict = new Dictionary<TypeDef, Dictionary<string, uint>>();

	private StringBuilder createTypeStringBuilder = new StringBuilder();

	public CSharpToVBConverterVisitor(ModuleDef module, IEnvironmentProvider provider)
	{
		this.module = module;
		this.provider = provider;
		blocks = new Stack<ICSharpCode.NRefactory.VB.Ast.BlockStatement>();
		types = new Stack<ICSharpCode.NRefactory.VB.Ast.TypeDeclaration>();
		members = new Stack<MemberInfo>();
	}

	public AstNode VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data)
	{
		members.Push(new MemberInfo());
		MultiLineLambdaExpression multiLineLambdaExpression = new MultiLineLambdaExpression
		{
			Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)anonymousMethodExpression.Body.AcceptVisitor(this, data)
		};
		if (anonymousMethodExpression.IsAsync)
		{
			multiLineLambdaExpression.Modifiers |= LambdaExpressionModifiers.Async;
		}
		multiLineLambdaExpression.IsSub = anonymousMethodExpression.Body.Descendants.OfType<ICSharpCode.NRefactory.CSharp.ReturnStatement>().FirstOrDefault()?.Expression.IsNull ?? true;
		ConvertNodes(anonymousMethodExpression.Parameters, multiLineLambdaExpression.Parameters);
		if (members.Pop().inIterator)
		{
			multiLineLambdaExpression.Modifiers |= LambdaExpressionModifiers.Iterator;
		}
		return EndNode(anonymousMethodExpression, multiLineLambdaExpression);
	}

	public AstNode VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.InvocationExpression invocationExpression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression();
		switch (undocumentedExpression.UndocumentedExpressionType)
		{
		case UndocumentedExpressionType.ArgListAccess:
		case UndocumentedExpressionType.ArgList:
			invocationExpression.Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__ArgList")
			};
			break;
		case UndocumentedExpressionType.RefValue:
			invocationExpression.Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__RefValue")
			};
			break;
		case UndocumentedExpressionType.RefType:
			invocationExpression.Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__RefType")
			};
			break;
		case UndocumentedExpressionType.MakeRef:
			invocationExpression.Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__MakeRef")
			};
			break;
		default:
			throw new Exception("Invalid value for UndocumentedExpressionType");
		}
		ConvertNodes(undocumentedExpression.Arguments, invocationExpression.Arguments);
		return EndNode(undocumentedExpression, invocationExpression);
	}

	public AstNode VisitArrayCreateExpression(ICSharpCode.NRefactory.CSharp.ArrayCreateExpression arrayCreateExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ArrayCreateExpression arrayCreateExpression2 = new ICSharpCode.NRefactory.VB.Ast.ArrayCreateExpression
		{
			Type = (ICSharpCode.NRefactory.VB.Ast.AstType)arrayCreateExpression.Type.AcceptVisitor(this, data),
			Initializer = (ICSharpCode.NRefactory.VB.Ast.ArrayInitializerExpression)arrayCreateExpression.Initializer.AcceptVisitor(this, data)
		};
		ConvertNodes(arrayCreateExpression.Arguments, arrayCreateExpression2.Arguments, ReduceArrayUpperBoundExpression);
		ConvertNodes(arrayCreateExpression.AdditionalArraySpecifiers, arrayCreateExpression2.AdditionalArraySpecifiers);
		return EndNode(arrayCreateExpression, arrayCreateExpression2);
	}

	private ICSharpCode.NRefactory.VB.Ast.Expression ReduceArrayUpperBoundExpression(ICSharpCode.NRefactory.VB.Ast.Expression expression)
	{
		if (expression is ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression)
		{
			ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression primitiveExpression = expression as ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression;
			int? num = primitiveExpression.Value as int?;
			if (num.HasValue)
			{
				return new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(num.Value - 1);
			}
		}
		return new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression(expression, ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Subtract, new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(1));
	}

	public AstNode VisitArrayInitializerExpression(ICSharpCode.NRefactory.CSharp.ArrayInitializerExpression arrayInitializerExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ArrayInitializerExpression arrayInitializerExpression2 = new ICSharpCode.NRefactory.VB.Ast.ArrayInitializerExpression();
		ConvertNodes(arrayInitializerExpression.Elements, arrayInitializerExpression2.Elements);
		return EndNode(arrayInitializerExpression, arrayInitializerExpression2);
	}

	public AstNode VisitAsExpression(AsExpression asExpression, object data)
	{
		return EndNode(asExpression, new ICSharpCode.NRefactory.VB.Ast.CastExpression(CastType.TryCast, (ICSharpCode.NRefactory.VB.Ast.AstType)asExpression.Type.AcceptVisitor(this, data), (ICSharpCode.NRefactory.VB.Ast.Expression)asExpression.Expression.AcceptVisitor(this, data)));
	}

	public AstNode VisitAssignmentExpression(ICSharpCode.NRefactory.CSharp.AssignmentExpression assignmentExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Expression expression = (ICSharpCode.NRefactory.VB.Ast.Expression)assignmentExpression.Left.AcceptVisitor(this, data);
		ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.None;
		ICSharpCode.NRefactory.VB.Ast.Expression expression2 = (ICSharpCode.NRefactory.VB.Ast.Expression)assignmentExpression.Right.AcceptVisitor(this, data);
		switch (assignmentExpression.Operator)
		{
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Assign:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Assign;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Add:
			if (provider.HasEvent(expression))
			{
				AddRemoveHandlerStatement addRemoveHandlerStatement2 = new AddRemoveHandlerStatement
				{
					IsAddHandler = true
				};
				addRemoveHandlerStatement2.EventExpression = expression;
				addRemoveHandlerStatement2.DelegateExpression = expression2;
				return EndNode(assignmentExpression, addRemoveHandlerStatement2);
			}
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Add;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Subtract:
			if (provider.HasEvent(expression))
			{
				AddRemoveHandlerStatement addRemoveHandlerStatement = new AddRemoveHandlerStatement
				{
					IsAddHandler = false
				};
				addRemoveHandlerStatement.EventExpression = expression;
				addRemoveHandlerStatement.DelegateExpression = expression2;
				return EndNode(assignmentExpression, addRemoveHandlerStatement);
			}
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Subtract;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Multiply:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Multiply;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Divide:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Divide;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Modulus:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Assign;
			expression2 = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression((ICSharpCode.NRefactory.VB.Ast.Expression)expression.Clone(), ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Modulus, expression2);
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.ShiftLeft:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.ShiftLeft;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.ShiftRight:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.ShiftRight;
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.BitwiseAnd:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Assign;
			expression2 = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression((ICSharpCode.NRefactory.VB.Ast.Expression)expression.Clone(), ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.BitwiseAnd, expression2);
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.BitwiseOr:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Assign;
			expression2 = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression((ICSharpCode.NRefactory.VB.Ast.Expression)expression.Clone(), ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.BitwiseOr, expression2);
			break;
		case ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.ExclusiveOr:
			assignmentOperatorType = ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Assign;
			expression2 = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression((ICSharpCode.NRefactory.VB.Ast.Expression)expression.Clone(), ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ExclusiveOr, expression2);
			break;
		default:
			throw new Exception("Invalid value for AssignmentOperatorType: " + assignmentExpression.Operator);
		}
		ICSharpCode.NRefactory.VB.Ast.AssignmentExpression result = new ICSharpCode.NRefactory.VB.Ast.AssignmentExpression(expression, assignmentOperatorType, expression2);
		return EndNode(assignmentExpression, result);
	}

	public AstNode VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, object data)
	{
		InstanceExpression result = new InstanceExpression(InstanceExpressionType.MyBase, baseReferenceExpression.StartLocation);
		return EndNode(baseReferenceExpression, result);
	}

	public AstNode VisitBinaryOperatorExpression(ICSharpCode.NRefactory.CSharp.BinaryOperatorExpression binaryOperatorExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Expression expression = (ICSharpCode.NRefactory.VB.Ast.Expression)binaryOperatorExpression.Left.AcceptVisitor(this, data);
		ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.None;
		ICSharpCode.NRefactory.VB.Ast.Expression expression2 = (ICSharpCode.NRefactory.VB.Ast.Expression)binaryOperatorExpression.Right.AcceptVisitor(this, data);
		switch (binaryOperatorExpression.Operator)
		{
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.BitwiseAnd:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.BitwiseAnd;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.BitwiseOr:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.BitwiseOr;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.ConditionalAnd:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LogicalAnd;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.ConditionalOr:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LogicalOr;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.ExclusiveOr:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ExclusiveOr;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.GreaterThan:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.GreaterThan;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.GreaterThanOrEqual:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.GreaterThanOrEqual;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Equality:
			binaryOperatorType = ((!IsReferentialEquality(binaryOperatorExpression)) ? ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Equality : ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ReferenceEquality);
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.InEquality:
			binaryOperatorType = ((!IsReferentialEquality(binaryOperatorExpression)) ? ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.InEquality : ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ReferenceInequality);
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.LessThan:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LessThan;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.LessThanOrEqual:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LessThanOrEqual;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Add:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Add;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Subtract:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Subtract;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Multiply:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Multiply;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Divide:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Divide;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Modulus:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Modulus;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.ShiftLeft:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ShiftLeft;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.ShiftRight:
			binaryOperatorType = ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ShiftRight;
			break;
		case ICSharpCode.NRefactory.CSharp.BinaryOperatorType.NullCoalescing:
		{
			ICSharpCode.NRefactory.VB.Ast.ConditionalExpression result = new ICSharpCode.NRefactory.VB.Ast.ConditionalExpression
			{
				ConditionExpression = expression,
				FalseExpression = expression2
			};
			return EndNode(binaryOperatorExpression, result);
		}
		default:
			throw new Exception("Invalid value for BinaryOperatorType: " + binaryOperatorExpression.Operator);
		}
		return EndNode(binaryOperatorExpression, new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression(expression, binaryOperatorType, expression2));
	}

	private bool IsReferentialEquality(ICSharpCode.NRefactory.CSharp.BinaryOperatorExpression binaryOperatorExpression)
	{
		bool? flag = provider.IsReferenceType(binaryOperatorExpression.Left);
		bool? flag2 = provider.IsReferenceType(binaryOperatorExpression.Right);
		TypeCode typeCode = provider.ResolveExpression(binaryOperatorExpression.Left);
		TypeCode typeCode2 = provider.ResolveExpression(binaryOperatorExpression.Right);
		if (flag == true || flag2 == true)
		{
			if (typeCode != TypeCode.String)
			{
				return typeCode2 != TypeCode.String;
			}
			return false;
		}
		return false;
	}

	public AstNode VisitCastExpression(ICSharpCode.NRefactory.CSharp.CastExpression castExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.CastExpression castExpression2 = new ICSharpCode.NRefactory.VB.Ast.CastExpression();
		castExpression2.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)castExpression.Type.AcceptVisitor(this, data);
		castExpression2.CastType = GetCastType(castExpression2.Type, null);
		castExpression2.Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)castExpression.Expression.AcceptVisitor(this, data);
		if (castExpression2.CastType != CastType.CType)
		{
			castExpression2.Type = null;
		}
		return EndNode(castExpression, castExpression2);
	}

	private CastType GetCastType(ICSharpCode.NRefactory.VB.Ast.AstType type, object typeInformation)
	{
		if (!(type is ICSharpCode.NRefactory.VB.Ast.PrimitiveType primitiveType))
		{
			return CastType.CType;
		}
		return primitiveType.Keyword switch
		{
			"Boolean" => CastType.CBool, 
			"Byte" => CastType.CByte, 
			"Char" => CastType.CChar, 
			"Date" => CastType.CDate, 
			"Double" => CastType.CDbl, 
			"Decimal" => CastType.CDec, 
			"Integer" => CastType.CInt, 
			"Long" => CastType.CLng, 
			"Object" => CastType.CObj, 
			"SByte" => CastType.CSByte, 
			"Short" => CastType.CShort, 
			"Single" => CastType.CSng, 
			"String" => CastType.CStr, 
			"UInteger" => CastType.CUInt, 
			"ULong" => CastType.CULng, 
			"UShort" => CastType.CUShort, 
			_ => CastType.CType, 
		};
	}

	public AstNode VisitCheckedExpression(CheckedExpression checkedExpression, object data)
	{
		if (blocks.Count > 0)
		{
			blocks.Peek().AddChild(new Comment(" The following expression was wrapped in a checked-expression"), AstNode.Roles.Comment);
		}
		return EndNode(checkedExpression, checkedExpression.Expression.AcceptVisitor(this, data));
	}

	public AstNode VisitConditionalExpression(ICSharpCode.NRefactory.CSharp.ConditionalExpression conditionalExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ConditionalExpression result = new ICSharpCode.NRefactory.VB.Ast.ConditionalExpression
		{
			ConditionExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)conditionalExpression.Condition.AcceptVisitor(this, data),
			TrueExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)conditionalExpression.TrueExpression.AcceptVisitor(this, data),
			FalseExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)conditionalExpression.FalseExpression.AcceptVisitor(this, data)
		};
		return EndNode(conditionalExpression, result);
	}

	public AstNode VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, object data)
	{
		return EndNode(defaultValueExpression, new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(null));
	}

	public AstNode VisitDirectionExpression(DirectionExpression directionExpression, object data)
	{
		return EndNode(directionExpression, (ICSharpCode.NRefactory.VB.Ast.Expression)directionExpression.Expression.AcceptVisitor(this, data));
	}

	public AstNode VisitIdentifierExpression(ICSharpCode.NRefactory.CSharp.IdentifierExpression identifierExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.IdentifierExpression identifierExpression2 = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression();
		identifierExpression2.Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(identifierExpression.IdentifierToken.Annotations, identifierExpression.Identifier);
		ConvertNodes(identifierExpression.TypeArguments, identifierExpression2.TypeArguments);
		if (provider.IsMethodGroup(identifierExpression))
		{
			return EndNode(identifierExpression, new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression(ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.AddressOf, identifierExpression2));
		}
		return EndNode(identifierExpression, identifierExpression2);
	}

	public AstNode VisitIndexerExpression(IndexerExpression indexerExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.InvocationExpression invocationExpression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression((ICSharpCode.NRefactory.VB.Ast.Expression)indexerExpression.Target.AcceptVisitor(this, data));
		ConvertNodes(indexerExpression.Arguments, invocationExpression.Arguments);
		return EndNode(indexerExpression, invocationExpression);
	}

	public AstNode VisitInvocationExpression(ICSharpCode.NRefactory.CSharp.InvocationExpression invocationExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.InvocationExpression invocationExpression2 = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression((ICSharpCode.NRefactory.VB.Ast.Expression)invocationExpression.Target.AcceptVisitor(this, data));
		ConvertNodes(invocationExpression.Arguments, invocationExpression2.Arguments);
		return EndNode(invocationExpression, invocationExpression2);
	}

	public AstNode VisitIsExpression(IsExpression isExpression, object data)
	{
		TypeOfIsExpression result = new TypeOfIsExpression
		{
			Type = (ICSharpCode.NRefactory.VB.Ast.AstType)isExpression.Type.AcceptVisitor(this, data),
			TypeOfExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)isExpression.Expression.AcceptVisitor(this, data)
		};
		return EndNode(isExpression, result);
	}

	public AstNode VisitLambdaExpression(ICSharpCode.NRefactory.CSharp.LambdaExpression lambdaExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.LambdaExpression lambdaExpression2 = null;
		if (lambdaExpression.Body is ICSharpCode.NRefactory.CSharp.Expression)
		{
			SingleLineFunctionLambdaExpression singleLineFunctionLambdaExpression = new SingleLineFunctionLambdaExpression
			{
				EmbeddedExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)lambdaExpression.Body.AcceptVisitor(this, data)
			};
			ConvertNodes(lambdaExpression.Parameters, singleLineFunctionLambdaExpression.Parameters);
			lambdaExpression2 = singleLineFunctionLambdaExpression;
			return EndNode(lambdaExpression, lambdaExpression2);
		}
		throw new NotImplementedException();
	}

	public AstNode VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
	{
		MemberAccessExpression memberAccessExpression = new MemberAccessExpression();
		memberAccessExpression.Target = (ICSharpCode.NRefactory.VB.Ast.Expression)memberReferenceExpression.Target.AcceptVisitor(this, data);
		memberAccessExpression.MemberName = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(memberReferenceExpression.MemberNameToken.Annotations, memberReferenceExpression.MemberName);
		memberAccessExpression.MemberName.AddAnnotation(memberReferenceExpression.Annotation<IMemberRef>());
		bool flag = false;
		if (memberReferenceExpression.Parent is ICSharpCode.NRefactory.CSharp.InvocationExpression invocationExpression)
		{
			flag = invocationExpression.Annotation<dnlib.DotNet.IMethod>().ResolveMethodDef()?.CustomAttributes.IsDefined("System.Runtime.CompilerServices.ExtensionAttribute") ?? false;
		}
		if (!flag)
		{
			ConvertNodes(memberReferenceExpression.TypeArguments, memberAccessExpression.TypeArguments);
		}
		if (provider.IsMethodGroup(memberReferenceExpression))
		{
			return EndNode(memberReferenceExpression, new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression(ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.AddressOf, memberAccessExpression));
		}
		return EndNode(memberReferenceExpression, memberAccessExpression);
	}

	public AstNode VisitNamedArgumentExpression(ICSharpCode.NRefactory.CSharp.NamedArgumentExpression namedArgumentExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Expression result = new ICSharpCode.NRefactory.VB.Ast.NamedArgumentExpression
		{
			Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(namedArgumentExpression.NameToken.Annotations, namedArgumentExpression.Name),
			Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)namedArgumentExpression.Expression.AcceptVisitor(this, data)
		};
		return EndNode(namedArgumentExpression, result);
	}

	public AstNode VisitNamedExpression(NamedExpression namedExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Expression result = new FieldInitializerExpression
		{
			IsKey = true,
			Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(namedExpression.NameToken.Annotations, namedExpression.Name),
			Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)namedExpression.Expression.AcceptVisitor(this, data)
		};
		return EndNode(namedExpression, result);
	}

	public AstNode VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression, object data)
	{
		return EndNode(nullReferenceExpression, new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(null));
	}

	public AstNode VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
	{
		ObjectCreationExpression objectCreationExpression = new ObjectCreationExpression((ICSharpCode.NRefactory.VB.Ast.AstType)objectCreateExpression.Type.AcceptVisitor(this, data));
		ConvertNodes(objectCreateExpression.Arguments, objectCreationExpression.Arguments);
		if (objectCreationExpression.Arguments.FirstOrDefault() is ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression { Operator: ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.AddressOf } unaryOperatorExpression)
		{
			unaryOperatorExpression.Remove();
			return EndNode(objectCreateExpression, unaryOperatorExpression);
		}
		if (!objectCreateExpression.Initializer.IsNull)
		{
			objectCreationExpression.Initializer = (ICSharpCode.NRefactory.VB.Ast.ArrayInitializerExpression)objectCreateExpression.Initializer.AcceptVisitor(this, data);
		}
		return EndNode(objectCreateExpression, objectCreationExpression);
	}

	public AstNode VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression, object data)
	{
		AnonymousObjectCreationExpression anonymousObjectCreationExpression = new AnonymousObjectCreationExpression();
		ConvertNodes(anonymousTypeCreateExpression.Initializers, anonymousObjectCreationExpression.Initializer);
		return EndNode(anonymousTypeCreateExpression, anonymousObjectCreationExpression);
	}

	public AstNode VisitParenthesizedExpression(ICSharpCode.NRefactory.CSharp.ParenthesizedExpression parenthesizedExpression, object data)
	{
		ICSharpCode.NRefactory.CSharp.Expression expression = parenthesizedExpression.Expression;
		if (expression is ICSharpCode.NRefactory.CSharp.CastExpression || expression is AsExpression || expression is TypeOfExpression || expression is ICSharpCode.NRefactory.CSharp.ConditionalExpression || expression is ICSharpCode.NRefactory.CSharp.ParenthesizedExpression)
		{
			return expression.AcceptVisitor(this, data);
		}
		ICSharpCode.NRefactory.VB.Ast.ParenthesizedExpression parenthesizedExpression2 = new ICSharpCode.NRefactory.VB.Ast.ParenthesizedExpression();
		parenthesizedExpression2.Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)expression.AcceptVisitor(this, data);
		return EndNode(parenthesizedExpression, parenthesizedExpression2);
	}

	public AstNode VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, object data)
	{
		return EndNode(pointerReferenceExpression, ((ICSharpCode.NRefactory.VB.Ast.Expression)pointerReferenceExpression.Target.AcceptVisitor(this, data)).Invoke2(BoxedTextColor.InstanceMethod, "Dereference").Member(pointerReferenceExpression.MemberNameToken.Annotation<object>(), pointerReferenceExpression.MemberName));
	}

	public AstNode VisitPrimitiveExpression(ICSharpCode.NRefactory.CSharp.PrimitiveExpression primitiveExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Expression result = ((!string.IsNullOrEmpty(primitiveExpression.Value as string)) ? ConvertToConcat(primitiveExpression.Value.ToString()) : ((!(primitiveExpression.Value is char)) ? new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(primitiveExpression.Value) : ConvertToSpecialChar((char)primitiveExpression.Value)));
		return EndNode(primitiveExpression, result);
	}

	private ICSharpCode.NRefactory.VB.Ast.Expression ConvertToConcat(string literal)
	{
		Stack<ICSharpCode.NRefactory.VB.Ast.Expression> stack = new Stack<ICSharpCode.NRefactory.VB.Ast.Expression>();
		int num = 0;
		for (int i = 0; i < literal.Length; i++)
		{
			switch (literal[i])
			{
			case '\0':
			case '\b':
			case '\t':
			case '\n':
			case '\v':
			case '\f':
			case '\u0085':
			case '\u2028':
			case '\u2029':
			{
				string value = literal.Substring(num, i - num);
				if (!string.IsNullOrEmpty(value))
				{
					stack.Push(new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(value));
				}
				stack.Push(ConvertToSpecialChar(literal[i]));
				num = i + 1;
				continue;
			}
			case '\r':
			{
				string value = literal.Substring(num, i - num);
				if (!string.IsNullOrEmpty(value))
				{
					stack.Push(new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(value));
				}
				if (i + 1 < literal.Length && literal[i + 1] == '\n')
				{
					i++;
					stack.Push(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbCrLf")));
				}
				else
				{
					stack.Push(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbCr")));
				}
				num = i + 1;
				continue;
			}
			}
			if (char.IsControl(literal[i]))
			{
				string value = literal.Substring(num, i - num);
				if (!string.IsNullOrEmpty(value))
				{
					stack.Push(new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(value));
				}
				stack.Push(new ICSharpCode.NRefactory.VB.Ast.InvocationExpression(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.StaticMethod, "ChrW")), new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression((int)literal[i])));
				num = i + 1;
			}
		}
		if (num < literal.Length)
		{
			string value2 = literal.Substring(num);
			stack.Push(new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(value2));
		}
		ICSharpCode.NRefactory.VB.Ast.Expression expression = stack.Pop();
		while (stack.Any())
		{
			expression = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression(stack.Pop(), ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Concat, expression);
		}
		return expression;
	}

	private ICSharpCode.NRefactory.VB.Ast.Expression ConvertToSpecialChar(char ch)
	{
		switch (ch)
		{
		case '\0':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbNullChar"));
		case '\b':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbBack"));
		case '\f':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbFormFeed"));
		case '\r':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbCr"));
		case '\n':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbLf"));
		case '\t':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbTab"));
		case '\v':
			return new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.CreateLiteralField("vbVerticalTab"));
		default:
			if (char.IsControl(ch))
			{
				return new ICSharpCode.NRefactory.VB.Ast.InvocationExpression(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression(ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.StaticMethod, "ChrW")), new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression((int)ch));
			}
			return new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(ch);
		}
	}

	public AstNode VisitSizeOfExpression(SizeOfExpression sizeOfExpression, object data)
	{
		return EndNode(sizeOfExpression, new ICSharpCode.NRefactory.VB.Ast.InvocationExpression(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
		{
			Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__SizeOf")
		}, new ICSharpCode.NRefactory.VB.Ast.TypeReferenceExpression((ICSharpCode.NRefactory.VB.Ast.AstType)sizeOfExpression.Type.AcceptVisitor(this, data))));
	}

	public AstNode VisitStackAllocExpression(StackAllocExpression stackAllocExpression, object data)
	{
		return EndNode(stackAllocExpression, new ICSharpCode.NRefactory.VB.Ast.InvocationExpression(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
		{
			Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__StackAlloc")
		}, new ICSharpCode.NRefactory.VB.Ast.TypeReferenceExpression((ICSharpCode.NRefactory.VB.Ast.AstType)stackAllocExpression.Type.AcceptVisitor(this, data)), (ICSharpCode.NRefactory.VB.Ast.Expression)stackAllocExpression.CountExpression.AcceptVisitor(this, data)));
	}

	public AstNode VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, object data)
	{
		InstanceExpression result = new InstanceExpression(InstanceExpressionType.Me, thisReferenceExpression.StartLocation);
		return EndNode(thisReferenceExpression, result);
	}

	public AstNode VisitTypeOfExpression(TypeOfExpression typeOfExpression, object data)
	{
		GetTypeExpression getTypeExpression = new GetTypeExpression();
		getTypeExpression.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)typeOfExpression.Type.AcceptVisitor(this, data);
		return EndNode(typeOfExpression, getTypeExpression);
	}

	public AstNode VisitTypeReferenceExpression(ICSharpCode.NRefactory.CSharp.TypeReferenceExpression typeReferenceExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.TypeReferenceExpression result = new ICSharpCode.NRefactory.VB.Ast.TypeReferenceExpression((ICSharpCode.NRefactory.VB.Ast.AstType)typeReferenceExpression.Type.AcceptVisitor(this, data));
		return EndNode(typeReferenceExpression, result);
	}

	public AstNode VisitUnaryOperatorExpression(ICSharpCode.NRefactory.CSharp.UnaryOperatorExpression unaryOperatorExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Expression expression;
		switch (unaryOperatorExpression.Operator)
		{
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Not:
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.BitNot:
			expression = new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression
			{
				Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data),
				Operator = ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Not
			};
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Minus:
			expression = new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression
			{
				Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data),
				Operator = ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Minus
			};
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Plus:
			expression = new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression
			{
				Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data),
				Operator = ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Plus
			};
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Increment:
			expression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression();
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__Increment")
			};
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Arguments.Add((ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data));
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.PostIncrement:
			expression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression();
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__PostIncrement")
			};
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Arguments.Add((ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data));
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Decrement:
			expression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression();
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__Decrement")
			};
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Arguments.Add((ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data));
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.PostDecrement:
			expression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression();
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__PostDecrement")
			};
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Arguments.Add((ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data));
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.AddressOf:
			expression = new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression
			{
				Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data),
				Operator = ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.AddressOf
			};
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Dereference:
			expression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression();
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__Dereference")
			};
			((ICSharpCode.NRefactory.VB.Ast.InvocationExpression)expression).Arguments.Add((ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data));
			break;
		case ICSharpCode.NRefactory.CSharp.UnaryOperatorType.Await:
			expression = new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression
			{
				Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)unaryOperatorExpression.Expression.AcceptVisitor(this, data),
				Operator = ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Await
			};
			break;
		default:
			throw new Exception("Invalid value for UnaryOperatorType");
		}
		return EndNode(unaryOperatorExpression, expression);
	}

	public AstNode VisitUncheckedExpression(UncheckedExpression uncheckedExpression, object data)
	{
		blocks.Peek().AddChild(new Comment(" The following expression was wrapped in a unchecked-expression"), AstNode.Roles.Comment);
		return EndNode(uncheckedExpression, uncheckedExpression.Expression.AcceptVisitor(this, data));
	}

	public AstNode VisitQueryExpression(ICSharpCode.NRefactory.CSharp.QueryExpression queryExpression, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.QueryExpression queryExpression2 = new ICSharpCode.NRefactory.VB.Ast.QueryExpression();
		ConvertNodes(queryExpression.Clauses, queryExpression2.QueryOperators);
		return EndNode(queryExpression, queryExpression2);
	}

	public AstNode VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitQueryFromClause(QueryFromClause queryFromClause, object data)
	{
		FromQueryOperator fromQueryOperator = new FromQueryOperator();
		fromQueryOperator.Variables.Add(new CollectionRangeVariableDeclaration
		{
			Identifier = new VariableIdentifier
			{
				Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(queryFromClause.IdentifierToken.Annotations, queryFromClause.Identifier)
			},
			Type = (ICSharpCode.NRefactory.VB.Ast.AstType)queryFromClause.Type.AcceptVisitor(this, data),
			Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)queryFromClause.Expression.AcceptVisitor(this, data)
		});
		return EndNode(queryFromClause, fromQueryOperator);
	}

	public AstNode VisitQueryLetClause(QueryLetClause queryLetClause, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitQueryWhereClause(QueryWhereClause queryWhereClause, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitQueryJoinClause(QueryJoinClause queryJoinClause, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitQueryOrderClause(QueryOrderClause queryOrderClause, object data)
	{
		OrderByQueryOperator orderByQueryOperator = new OrderByQueryOperator();
		ConvertNodes(queryOrderClause.Orderings, orderByQueryOperator.Expressions);
		return EndNode(queryOrderClause, orderByQueryOperator);
	}

	public AstNode VisitQueryOrdering(QueryOrdering queryOrdering, object data)
	{
		OrderExpression orderExpression = new OrderExpression();
		orderExpression.Direction = (ICSharpCode.NRefactory.VB.Ast.QueryOrderingDirection)queryOrdering.Direction;
		orderExpression.Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)queryOrdering.Expression.AcceptVisitor(this, data);
		return EndNode(queryOrdering, orderExpression);
	}

	public AstNode VisitQuerySelectClause(QuerySelectClause querySelectClause, object data)
	{
		SelectQueryOperator selectQueryOperator = new SelectQueryOperator();
		selectQueryOperator.Variables.Add(new ICSharpCode.NRefactory.VB.Ast.VariableInitializer
		{
			Identifier = new VariableIdentifier
			{
				Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Local, "SelectVar" + selectVarCount)
			},
			Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)querySelectClause.Expression.AcceptVisitor(this, data)
		});
		return EndNode(querySelectClause, selectQueryOperator);
	}

	public AstNode VisitQueryGroupClause(QueryGroupClause queryGroupClause, object data)
	{
		GroupByQueryOperator groupByQueryOperator = new GroupByQueryOperator();
		throw new NotImplementedException();
	}

	public AstNode VisitAttribute(ICSharpCode.NRefactory.CSharp.Attribute attribute, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Attribute attribute2 = new ICSharpCode.NRefactory.VB.Ast.Attribute();
		Enum.TryParse<AttributeTarget>(((AttributeSection)attribute.Parent).AttributeTarget, ignoreCase: true, out var result);
		attribute2.Target = result;
		attribute2.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)attribute.Type.AcceptVisitor(this, data);
		ConvertNodes(attribute.Arguments, attribute2.Arguments);
		return EndNode(attribute, attribute2);
	}

	public AstNode VisitAttributeSection(AttributeSection attributeSection, object data)
	{
		AttributeBlock attributeBlock = new AttributeBlock();
		ConvertNodes(attributeSection.Attributes, attributeBlock.Attributes);
		return EndNode(attributeSection, attributeBlock);
	}

	public AstNode VisitDelegateDeclaration(ICSharpCode.NRefactory.CSharp.DelegateDeclaration delegateDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.DelegateDeclaration delegateDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.DelegateDeclaration();
		ConvertNodes(delegateDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), delegateDeclaration2.Attributes);
		ConvertNodes(delegateDeclaration.ModifierTokens, delegateDeclaration2.ModifierTokens);
		delegateDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(delegateDeclaration.NameToken.Annotations, delegateDeclaration.Name);
		delegateDeclaration2.IsSub = IsSub(delegateDeclaration.ReturnType);
		ConvertNodes(delegateDeclaration.Parameters, delegateDeclaration2.Parameters);
		ConvertNodes(delegateDeclaration.TypeParameters, delegateDeclaration2.TypeParameters);
		ConvertNodes(delegateDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), delegateDeclaration2.ReturnTypeAttributes);
		if (!delegateDeclaration2.IsSub)
		{
			delegateDeclaration2.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)delegateDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		return EndNode(delegateDeclaration, delegateDeclaration2);
	}

	public AstNode VisitNamespaceDeclaration(ICSharpCode.NRefactory.CSharp.NamespaceDeclaration namespaceDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.NamespaceDeclaration namespaceDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.NamespaceDeclaration();
		foreach (ICSharpCode.NRefactory.CSharp.Identifier identifierType in namespaceDeclaration.IdentifierTypes)
		{
			ICSharpCode.NRefactory.VB.Ast.Identifier identifier = new ICSharpCode.NRefactory.VB.Ast.Identifier(BoxedTextColor.Namespace, identifierType.Name, TextLocation.Empty);
			CopyAnnotations(identifierType, identifier);
			namespaceDeclaration2.Identifiers.Add(identifier);
		}
		ConvertMembers(namespaceDeclaration, namespaceDeclaration2, ICSharpCode.NRefactory.CSharp.NamespaceDeclaration.MemberRole, ICSharpCode.NRefactory.VB.Ast.NamespaceDeclaration.MemberRole);
		return EndNode(namespaceDeclaration, namespaceDeclaration2);
	}

	public AstNode VisitTypeDeclaration(ICSharpCode.NRefactory.CSharp.TypeDeclaration typeDeclaration, object data)
	{
		if (typeDeclaration.ClassType == ICSharpCode.NRefactory.CSharp.ClassType.Enum)
		{
			EnumDeclaration enumDeclaration = new EnumDeclaration();
			CopyAnnotations(typeDeclaration, enumDeclaration);
			ConvertNodes(typeDeclaration.Attributes, enumDeclaration.Attributes);
			ConvertNodes(typeDeclaration.ModifierTokens, enumDeclaration.ModifierTokens);
			if (typeDeclaration.BaseTypes.Any())
			{
				ICSharpCode.NRefactory.CSharp.AstType astType = typeDeclaration.BaseTypes.First();
				enumDeclaration.UnderlyingType = (ICSharpCode.NRefactory.VB.Ast.AstType)astType.AcceptVisitor(this, data);
			}
			enumDeclaration.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(typeDeclaration.NameToken.Annotations, typeDeclaration.Name);
			ConvertMembers(typeDeclaration, enumDeclaration, Roles.TypeMemberRole, EnumDeclaration.MemberRole);
			return EndNode(typeDeclaration, enumDeclaration);
		}
		ICSharpCode.NRefactory.VB.Ast.TypeDeclaration typeDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.TypeDeclaration();
		CopyAnnotations(typeDeclaration, typeDeclaration2);
		if (typeDeclaration.ClassType == ICSharpCode.NRefactory.CSharp.ClassType.Class && HasAttribute(typeDeclaration.Attributes, "Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute", out var foundAttribute))
		{
			typeDeclaration2.ClassType = ICSharpCode.NRefactory.VB.Ast.ClassType.Module;
			AttributeSection attributeSection = (AttributeSection)foundAttribute.Parent;
			if (attributeSection.Attributes.Count == 1)
			{
				attributeSection.Remove();
			}
			else
			{
				foundAttribute.Remove();
			}
		}
		else
		{
			switch (typeDeclaration.ClassType)
			{
			case ICSharpCode.NRefactory.CSharp.ClassType.Class:
				typeDeclaration2.ClassType = ICSharpCode.NRefactory.VB.Ast.ClassType.Class;
				break;
			case ICSharpCode.NRefactory.CSharp.ClassType.Struct:
				typeDeclaration2.ClassType = ICSharpCode.NRefactory.VB.Ast.ClassType.Struct;
				break;
			case ICSharpCode.NRefactory.CSharp.ClassType.Interface:
				typeDeclaration2.ClassType = ICSharpCode.NRefactory.VB.Ast.ClassType.Interface;
				break;
			default:
				throw new InvalidOperationException("Invalid value for ClassType");
			}
		}
		if ((typeDeclaration.Modifiers & ICSharpCode.NRefactory.CSharp.Modifiers.Static) == ICSharpCode.NRefactory.CSharp.Modifiers.Static)
		{
			typeDeclaration2.ClassType = ICSharpCode.NRefactory.VB.Ast.ClassType.Module;
			typeDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		ConvertNodes(typeDeclaration.Attributes, typeDeclaration2.Attributes);
		ConvertNodes(typeDeclaration.ModifierTokens, typeDeclaration2.ModifierTokens);
		ConvertNodes(typeDeclaration.TypeParameters, typeDeclaration2.TypeParameters);
		if (typeDeclaration.Parent is ICSharpCode.NRefactory.CSharp.TypeDeclaration && typeDeclaration2.ClassType == ICSharpCode.NRefactory.VB.Ast.ClassType.Module)
		{
			typeDeclaration2.ClassType = ICSharpCode.NRefactory.VB.Ast.ClassType.Class;
			typeDeclaration2.Modifiers &= ~ICSharpCode.NRefactory.VB.Ast.Modifiers.Static;
			typeDeclaration2.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.NotInheritable;
		}
		if (typeDeclaration.BaseTypes.Any())
		{
			ICSharpCode.NRefactory.CSharp.AstType astType2 = typeDeclaration.BaseTypes.First();
			if (provider.GetTypeKindForAstType(astType2) != TypeKind.Interface)
			{
				ConvertNodes(typeDeclaration.BaseTypes.Skip(1), typeDeclaration2.ImplementsTypes);
				typeDeclaration2.InheritsType = (ICSharpCode.NRefactory.VB.Ast.AstType)astType2.AcceptVisitor(this, data);
			}
			else
			{
				ConvertNodes(typeDeclaration.BaseTypes, typeDeclaration2.ImplementsTypes);
			}
		}
		typeDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(typeDeclaration.NameToken.Annotations, typeDeclaration.Name);
		types.Push(typeDeclaration2);
		ConvertMembers(typeDeclaration, typeDeclaration2, Roles.TypeMemberRole, ICSharpCode.NRefactory.VB.Ast.TypeDeclaration.MemberRole);
		types.Pop();
		return EndNode(typeDeclaration, typeDeclaration2);
	}

	public AstNode VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration, object data)
	{
		ImportsStatement importsStatement = new ImportsStatement();
		AliasImportsClause child = new AliasImportsClause
		{
			Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(usingAliasDeclaration.AliasToken.Annotations, usingAliasDeclaration.Alias),
			Alias = (ICSharpCode.NRefactory.VB.Ast.AstType)usingAliasDeclaration.Import.AcceptVisitor(this, data)
		};
		importsStatement.AddChild(child, ImportsStatement.ImportsClauseRole);
		return EndNode(usingAliasDeclaration, importsStatement);
	}

	public AstNode VisitUsingDeclaration(UsingDeclaration usingDeclaration, object data)
	{
		ImportsStatement importsStatement = new ImportsStatement();
		MemberImportsClause child = new MemberImportsClause
		{
			Member = (ICSharpCode.NRefactory.VB.Ast.AstType)usingDeclaration.Import.AcceptVisitor(this, data)
		};
		importsStatement.AddChild(child, ImportsStatement.ImportsClauseRole);
		return EndNode(usingDeclaration, importsStatement);
	}

	public AstNode VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitBlockStatement(ICSharpCode.NRefactory.CSharp.BlockStatement blockStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.BlockStatement blockStatement2 = new ICSharpCode.NRefactory.VB.Ast.BlockStatement();
		blocks.Push(blockStatement2);
		blockStatement2.HiddenStart = blockStatement.HiddenStart.GetAllRecursiveILSpans();
		blockStatement2.HiddenEnd = blockStatement.HiddenEnd.GetAllRecursiveILSpans();
		ConvertNodes(blockStatement, blockStatement2.Statements);
		blocks.Pop();
		return EndNode(blockStatement, blockStatement2);
	}

	public AstNode VisitBreakStatement(BreakStatement breakStatement, object data)
	{
		ExitStatement exitStatement = new ExitStatement(ExitKind.None);
		foreach (ICSharpCode.NRefactory.CSharp.AstNode ancestor in breakStatement.Ancestors)
		{
			if (ancestor is ICSharpCode.NRefactory.CSharp.MethodDeclaration)
			{
				exitStatement.ExitKind = (IsSub(((ICSharpCode.NRefactory.CSharp.MethodDeclaration)ancestor).ReturnType) ? ExitKind.Sub : ExitKind.Function);
				break;
			}
			if (ancestor is ICSharpCode.NRefactory.CSharp.PropertyDeclaration)
			{
				exitStatement.ExitKind = ExitKind.Property;
				break;
			}
			if (ancestor is DoWhileStatement)
			{
				exitStatement.ExitKind = ExitKind.Do;
				break;
			}
			if (ancestor is ICSharpCode.NRefactory.CSharp.ForStatement || ancestor is ForeachStatement)
			{
				if (!convertedKind.TryGetValue(ancestor, out var value) || value != ConvertedStatementKind.While)
				{
					exitStatement.ExitKind = ExitKind.For;
				}
				else
				{
					exitStatement.ExitKind = ExitKind.While;
				}
				break;
			}
			if (ancestor is ICSharpCode.NRefactory.CSharp.WhileStatement)
			{
				exitStatement.ExitKind = ExitKind.While;
				break;
			}
			if (ancestor is SwitchStatement)
			{
				exitStatement.ExitKind = ExitKind.Select;
				break;
			}
			if (ancestor is TryCatchStatement)
			{
				exitStatement.ExitKind = ExitKind.Try;
				break;
			}
		}
		return EndNode(breakStatement, exitStatement);
	}

	public AstNode VisitCheckedStatement(CheckedStatement checkedStatement, object data)
	{
		blocks.Peek().AddChild(new Comment(" The following expression was wrapped in a checked-statement"), AstNode.Roles.Comment);
		ICSharpCode.NRefactory.VB.Ast.BlockStatement blockStatement = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)checkedStatement.Body.AcceptVisitor(this, data);
		foreach (ICSharpCode.NRefactory.VB.Ast.Statement item in (IEnumerable<ICSharpCode.NRefactory.VB.Ast.Statement>)blockStatement)
		{
			item.Remove();
			blocks.Peek().Add(item);
		}
		return EndNode<AstNode>(checkedStatement, null);
	}

	public AstNode VisitContinueStatement(ICSharpCode.NRefactory.CSharp.ContinueStatement continueStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ContinueStatement continueStatement2 = new ICSharpCode.NRefactory.VB.Ast.ContinueStatement(ContinueKind.None);
		foreach (ICSharpCode.NRefactory.CSharp.AstNode ancestor in continueStatement.Ancestors)
		{
			if (ancestor is DoWhileStatement)
			{
				continueStatement2.ContinueKind = ContinueKind.Do;
				break;
			}
			if (ancestor is ICSharpCode.NRefactory.CSharp.ForStatement || ancestor is ForeachStatement)
			{
				if (!convertedKind.TryGetValue(ancestor, out var value) || value != ConvertedStatementKind.While)
				{
					continueStatement2.ContinueKind = ContinueKind.For;
				}
				else
				{
					continueStatement2.ContinueKind = ContinueKind.While;
				}
				break;
			}
			if (ancestor is ICSharpCode.NRefactory.CSharp.WhileStatement)
			{
				continueStatement2.ContinueKind = ContinueKind.While;
				break;
			}
		}
		return EndNode(continueStatement, continueStatement2);
	}

	public AstNode VisitDoWhileStatement(DoWhileStatement doWhileStatement, object data)
	{
		DoLoopStatement doLoopStatement = new DoLoopStatement();
		doLoopStatement.ConditionType = ConditionType.LoopWhile;
		doLoopStatement.Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)doWhileStatement.Condition.AcceptVisitor(this, data);
		doLoopStatement.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)doWhileStatement.EmbeddedStatement.AcceptVisitor(this, data);
		return EndNode(doWhileStatement, doLoopStatement);
	}

	public AstNode VisitEmptyStatement(EmptyStatement emptyStatement, object data)
	{
		return EndNode<ICSharpCode.NRefactory.VB.Ast.Statement>(emptyStatement, null);
	}

	public AstNode VisitExpressionStatement(ICSharpCode.NRefactory.CSharp.ExpressionStatement expressionStatement, object data)
	{
		AstNode astNode = expressionStatement.Expression.AcceptVisitor(this, data);
		if (astNode is ICSharpCode.NRefactory.VB.Ast.Expression)
		{
			astNode = new ICSharpCode.NRefactory.VB.Ast.ExpressionStatement((ICSharpCode.NRefactory.VB.Ast.Expression)astNode);
		}
		return EndNode(expressionStatement, astNode);
	}

	public AstNode VisitFixedStatement(FixedStatement fixedStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.BlockStatement blockStatement = blocks.Peek();
		blockStatement.AddChild(new Comment(" Emulating fixed-Statement, might not be entirely correct!"), AstNode.Roles.Comment);
		LocalDeclarationStatement localDeclarationStatement = new LocalDeclarationStatement();
		localDeclarationStatement.Modifiers = ICSharpCode.NRefactory.VB.Ast.Modifiers.Dim;
		TryStatement tryStatement = new TryStatement();
		tryStatement.FinallyBlock = new ICSharpCode.NRefactory.VB.Ast.BlockStatement();
		foreach (ICSharpCode.NRefactory.CSharp.VariableInitializer variable in fixedStatement.Variables)
		{
			VariableDeclaratorWithTypeAndInitializer variableDeclaratorWithTypeAndInitializer = new VariableDeclaratorWithTypeAndInitializer();
			variableDeclaratorWithTypeAndInitializer.Identifiers.Add(new VariableIdentifier
			{
				Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(variable.NameToken.Annotations, variable.Name)
			});
			variableDeclaratorWithTypeAndInitializer.Type = ICSharpCode.NRefactory.VB.Ast.SimpleType.CreateWithColor(BoxedTextColor.ValueType, "GCHandle");
			variableDeclaratorWithTypeAndInitializer.Initializer = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression(new MemberAccessExpression
			{
				Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
				{
					Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.ValueType, "GCHandle")
				},
				MemberName = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.StaticMethod, "Alloc")
			}, (ICSharpCode.NRefactory.VB.Ast.Expression)variable.Initializer.AcceptVisitor(this, data), new MemberAccessExpression
			{
				Target = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
				{
					Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Enum, "GCHandleType")
				},
				MemberName = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.EnumField, "Pinned")
			});
			VariableDeclaratorWithTypeAndInitializer element = variableDeclaratorWithTypeAndInitializer;
			localDeclarationStatement.Variables.Add(element);
			tryStatement.FinallyBlock.Add(new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(variable.NameToken.Annotations, variable.Name)
			}.Invoke2(BoxedTextColor.InstanceMethod, "Free"));
		}
		blockStatement.Add(localDeclarationStatement);
		tryStatement.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)fixedStatement.EmbeddedStatement.AcceptVisitor(this, data);
		foreach (ICSharpCode.NRefactory.VB.Ast.IdentifierExpression item in tryStatement.Body.Descendants.OfType<ICSharpCode.NRefactory.VB.Ast.IdentifierExpression>())
		{
			item.ReplaceWith((AstNode expr) => ((ICSharpCode.NRefactory.VB.Ast.Expression)expr).Invoke2(BoxedTextColor.InstanceMethod, "AddrOfPinnedObject"));
		}
		return EndNode(fixedStatement, tryStatement);
	}

	public AstNode VisitForeachStatement(ForeachStatement foreachStatement, object data)
	{
		ForEachStatement forEachStatement = new ForEachStatement
		{
			Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)foreachStatement.EmbeddedStatement.AcceptVisitor(this, data),
			InExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)foreachStatement.InExpression.AcceptVisitor(this, data),
			Variable = new ICSharpCode.NRefactory.VB.Ast.VariableInitializer
			{
				Identifier = new VariableIdentifier
				{
					Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(foreachStatement.VariableNameToken.Annotations, foreachStatement.VariableName)
				},
				Type = (ICSharpCode.NRefactory.VB.Ast.AstType)foreachStatement.VariableType.AcceptVisitor(this, data)
			}
		};
		forEachStatement.HiddenInitializer = foreachStatement.HiddenInitializer.GetAllRecursiveILSpans();
		forEachStatement.HiddenGetEnumeratorILSpans = foreachStatement.HiddenGetEnumeratorNode.GetAllRecursiveILSpans();
		forEachStatement.HiddenMoveNextILSpans = foreachStatement.HiddenMoveNextNode.GetAllRecursiveILSpans();
		forEachStatement.HiddenGetCurrentILSpans = foreachStatement.HiddenGetCurrentNode.GetAllRecursiveILSpans();
		return EndNode(foreachStatement, forEachStatement);
	}

	public AstNode VisitForStatement(ICSharpCode.NRefactory.CSharp.ForStatement forStatement, object data)
	{
		if (!forStatement.Initializers.Any() && forStatement.Condition.IsNull && !forStatement.Iterators.Any())
		{
			return EndNode(forStatement, new ICSharpCode.NRefactory.VB.Ast.WhileStatement
			{
				Condition = new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(true),
				Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)forStatement.EmbeddedStatement.AcceptVisitor(this, data)
			});
		}
		ICSharpCode.NRefactory.CSharp.AstNode pattern = new ICSharpCode.NRefactory.CSharp.ForStatement
		{
			Initializers = { (ICSharpCode.NRefactory.CSharp.Statement)new NamedNode("iteratorVar", new Choice
			{
				new VariableDeclarationStatement
				{
					Type = new Choice
					{
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("long"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("ulong"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("int"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("uint"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("short"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("ushort"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("sbyte"),
						new ICSharpCode.NRefactory.CSharp.PrimitiveType("byte")
					},
					Variables = { (ICSharpCode.NRefactory.CSharp.VariableInitializer)new AnyNode() }
				},
				new ICSharpCode.NRefactory.CSharp.ExpressionStatement(new ICSharpCode.NRefactory.CSharp.AssignmentExpression())
			}) },
			Condition = new NamedNode("condition", new ICSharpCode.NRefactory.CSharp.BinaryOperatorExpression
			{
				Left = new NamedNode("ident", new ICSharpCode.NRefactory.CSharp.IdentifierExpression(Pattern.AnyString)),
				Operator = ICSharpCode.NRefactory.CSharp.BinaryOperatorType.Any,
				Right = new AnyNode("endExpr")
			}),
			Iterators = { (ICSharpCode.NRefactory.CSharp.Statement)new ICSharpCode.NRefactory.CSharp.ExpressionStatement(new NamedNode("increment", new ICSharpCode.NRefactory.CSharp.AssignmentExpression
			{
				Left = new Backreference("ident"),
				Operator = ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Any,
				Right = new NamedNode("factor", new AnyNode())
			})) },
			EmbeddedStatement = new NamedNode("body", new AnyNode())
		};
		Match match = pattern.Match(forStatement);
		if (match.Success)
		{
			ICSharpCode.NRefactory.CSharp.Statement statement = match.Get<ICSharpCode.NRefactory.CSharp.Statement>("iteratorVar").SingleOrDefault();
			AstNode astNode;
			if (statement is VariableDeclarationStatement)
			{
				ICSharpCode.NRefactory.CSharp.VariableInitializer variableInitializer = ((VariableDeclarationStatement)statement).Variables.First();
				astNode = new ICSharpCode.NRefactory.VB.Ast.VariableInitializer
				{
					Identifier = new VariableIdentifier
					{
						Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(variableInitializer.NameToken.Annotations, variableInitializer.Name)
					},
					Type = (ICSharpCode.NRefactory.VB.Ast.AstType)((VariableDeclarationStatement)statement).Type.AcceptVisitor(this, data),
					Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)variableInitializer.Initializer.AcceptVisitor(this, data)
				};
				CopyAnnotations(variableInitializer, astNode);
			}
			else
			{
				if (!(statement is ICSharpCode.NRefactory.CSharp.ExpressionStatement))
				{
					goto IL_0486;
				}
				astNode = statement.AcceptVisitor(this, data);
			}
			bool flag = false;
			bool flag2 = false;
			ICSharpCode.NRefactory.VB.Ast.Expression expression = ICSharpCode.NRefactory.VB.Ast.Expression.Null;
			ICSharpCode.NRefactory.CSharp.BinaryOperatorExpression binaryOperatorExpression = match.Get<ICSharpCode.NRefactory.CSharp.BinaryOperatorExpression>("condition").SingleOrDefault();
			ICSharpCode.NRefactory.VB.Ast.Expression expression2 = (ICSharpCode.NRefactory.VB.Ast.Expression)match.Get<ICSharpCode.NRefactory.CSharp.Expression>("endExpr").SingleOrDefault().AcceptVisitor(this, data);
			if (binaryOperatorExpression.Operator == ICSharpCode.NRefactory.CSharp.BinaryOperatorType.LessThanOrEqual || binaryOperatorExpression.Operator == ICSharpCode.NRefactory.CSharp.BinaryOperatorType.GreaterThanOrEqual)
			{
				expression = expression2;
			}
			if (binaryOperatorExpression.Operator == ICSharpCode.NRefactory.CSharp.BinaryOperatorType.LessThan)
			{
				expression = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression(expression2, ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Subtract, new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(1));
			}
			if (binaryOperatorExpression.Operator == ICSharpCode.NRefactory.CSharp.BinaryOperatorType.GreaterThan)
			{
				expression = new ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression(expression2, ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Add, new ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression(1));
			}
			ICSharpCode.NRefactory.VB.Ast.Expression expression3 = ICSharpCode.NRefactory.VB.Ast.Expression.Null;
			ICSharpCode.NRefactory.CSharp.AssignmentExpression assignmentExpression = match.Get<ICSharpCode.NRefactory.CSharp.AssignmentExpression>("increment").SingleOrDefault();
			ICSharpCode.NRefactory.VB.Ast.Expression expression4 = (ICSharpCode.NRefactory.VB.Ast.Expression)match.Get<ICSharpCode.NRefactory.CSharp.Expression>("factor").SingleOrDefault().AcceptVisitor(this, data);
			if (assignmentExpression.Operator == ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Add && expression4 is ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression && !IsEqual(((ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression)expression4).Value, 1))
			{
				expression3 = expression4;
			}
			if (assignmentExpression.Operator == ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Subtract)
			{
				expression3 = new ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression(ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Minus, expression4);
			}
			if (!expression.IsNull)
			{
				CopyAnnotations(binaryOperatorExpression, expression);
				flag = true;
			}
			if (!expression3.IsNull)
			{
				CopyAnnotations(assignmentExpression, expression3);
				flag2 = true;
			}
			if (!flag && !expression3.IsNull)
			{
				CopyAnnotations(binaryOperatorExpression, expression3);
			}
			if (!flag2 && !expression.IsNull)
			{
				CopyAnnotations(assignmentExpression, expression);
			}
			return new ICSharpCode.NRefactory.VB.Ast.ForStatement
			{
				Variable = astNode,
				ToExpression = expression,
				StepExpression = expression3,
				Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)match.Get<ICSharpCode.NRefactory.CSharp.Statement>("body").Single().AcceptVisitor(this, data)
			};
		}
		goto IL_0486;
		IL_0486:
		convertedKind[forStatement] = ConvertedStatementKind.While;
		ICSharpCode.NRefactory.VB.Ast.WhileStatement whileStatement = new ICSharpCode.NRefactory.VB.Ast.WhileStatement
		{
			Condition = (ICSharpCode.NRefactory.VB.Ast.Expression)forStatement.Condition.AcceptVisitor(this, data),
			Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)forStatement.EmbeddedStatement.AcceptVisitor(this, data)
		};
		ConvertNodes(forStatement.Iterators, whileStatement.Body.Statements);
		foreach (ICSharpCode.NRefactory.CSharp.Statement initializer in forStatement.Initializers)
		{
			blocks.Peek().Statements.Add((ICSharpCode.NRefactory.VB.Ast.Statement)initializer.AcceptVisitor(this, data));
		}
		convertedKind.Remove(forStatement);
		return EndNode(forStatement, whileStatement);
	}

	private bool IsEqual(object value, int num)
	{
		if (value is byte)
		{
			return (byte)value == num;
		}
		if (value is sbyte)
		{
			return (sbyte)value == num;
		}
		if (value is short)
		{
			return (short)value == num;
		}
		if (value is ushort)
		{
			return (ushort)value == num;
		}
		if (value is int)
		{
			return (int)value == num;
		}
		if (value is uint)
		{
			return (uint)value == num;
		}
		if (value is long)
		{
			return (long)value == num;
		}
		if (value is ulong)
		{
			return (ulong)value == (ulong)num;
		}
		throw new InvalidCastException();
	}

	public AstNode VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitGotoStatement(GotoStatement gotoStatement, object data)
	{
		return EndNode(gotoStatement, new GoToStatement
		{
			Label = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Label, gotoStatement.Label)
			}
		});
	}

	public AstNode VisitIfElseStatement(ICSharpCode.NRefactory.CSharp.IfElseStatement ifElseStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.IfElseStatement ifElseStatement2 = new ICSharpCode.NRefactory.VB.Ast.IfElseStatement();
		ifElseStatement2.Condition = (ICSharpCode.NRefactory.VB.Ast.Expression)ifElseStatement.Condition.AcceptVisitor(this, data);
		ifElseStatement2.Body = (ICSharpCode.NRefactory.VB.Ast.Statement)ifElseStatement.TrueStatement.AcceptVisitor(this, data);
		ifElseStatement2.ElseBlock = (ICSharpCode.NRefactory.VB.Ast.Statement)ifElseStatement.FalseStatement.AcceptVisitor(this, data);
		return EndNode(ifElseStatement, ifElseStatement2);
	}

	public AstNode VisitLabelStatement(LabelStatement labelStatement, object data)
	{
		return EndNode(labelStatement, new LabelDeclarationStatement
		{
			Label = new ICSharpCode.NRefactory.VB.Ast.IdentifierExpression
			{
				Identifier = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Label, labelStatement.Label)
			}
		});
	}

	public AstNode VisitLockStatement(LockStatement lockStatement, object data)
	{
		SyncLockStatement syncLockStatement = new SyncLockStatement();
		syncLockStatement.Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)lockStatement.Expression.AcceptVisitor(this, data);
		syncLockStatement.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)lockStatement.EmbeddedStatement.AcceptVisitor(this, data);
		return EndNode(lockStatement, syncLockStatement);
	}

	public AstNode VisitReturnStatement(ICSharpCode.NRefactory.CSharp.ReturnStatement returnStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ReturnStatement result = new ICSharpCode.NRefactory.VB.Ast.ReturnStatement((ICSharpCode.NRefactory.VB.Ast.Expression)returnStatement.Expression.AcceptVisitor(this, data));
		return EndNode(returnStatement, result);
	}

	public AstNode VisitSwitchStatement(SwitchStatement switchStatement, object data)
	{
		SelectStatement selectStatement = new SelectStatement
		{
			Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)switchStatement.Expression.AcceptVisitor(this, data)
		};
		ConvertNodes(switchStatement.SwitchSections, selectStatement.Cases);
		selectStatement.HiddenEnd = switchStatement.HiddenEnd.GetAllRecursiveILSpans();
		return EndNode(switchStatement, selectStatement);
	}

	public AstNode VisitSwitchSection(SwitchSection switchSection, object data)
	{
		CaseStatement caseStatement = new CaseStatement();
		ConvertNodes(switchSection.CaseLabels, caseStatement.Clauses);
		if (switchSection.Statements.Count == 1 && switchSection.Statements.FirstOrDefault() is ICSharpCode.NRefactory.CSharp.BlockStatement)
		{
			caseStatement.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)switchSection.Statements.FirstOrDefault().AcceptVisitor(this, data);
		}
		else
		{
			caseStatement.Body = new ICSharpCode.NRefactory.VB.Ast.BlockStatement();
			ConvertNodes(switchSection.Statements, caseStatement.Body.Statements);
		}
		if (caseStatement.Body.LastOrDefault() is ExitStatement && ((ExitStatement)caseStatement.Body.LastOrDefault()).ExitKind == ExitKind.Select)
		{
			caseStatement.Body.LastOrDefault().Remove();
		}
		return EndNode(switchSection, caseStatement);
	}

	public AstNode VisitCaseLabel(CaseLabel caseLabel, object data)
	{
		return EndNode(caseLabel, new SimpleCaseClause
		{
			Expression = (ICSharpCode.NRefactory.VB.Ast.Expression)caseLabel.Expression.AcceptVisitor(this, data)
		});
	}

	public AstNode VisitThrowStatement(ICSharpCode.NRefactory.CSharp.ThrowStatement throwStatement, object data)
	{
		return EndNode(throwStatement, new ICSharpCode.NRefactory.VB.Ast.ThrowStatement((ICSharpCode.NRefactory.VB.Ast.Expression)throwStatement.Expression.AcceptVisitor(this, data)));
	}

	public AstNode VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
	{
		TryStatement tryStatement = new TryStatement();
		tryStatement.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)tryCatchStatement.TryBlock.AcceptVisitor(this, data);
		tryStatement.FinallyBlock = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)tryCatchStatement.FinallyBlock.AcceptVisitor(this, data);
		ConvertNodes(tryCatchStatement.CatchClauses, tryStatement.CatchBlocks);
		return EndNode(tryCatchStatement, tryStatement);
	}

	public AstNode VisitCatchClause(CatchClause catchClause, object data)
	{
		CatchBlock catchBlock = new CatchBlock();
		if (!catchClause.Type.IsNull)
		{
			catchBlock.ExceptionType = (ICSharpCode.NRefactory.VB.Ast.AstType)catchClause.Type.AcceptVisitor(this, data);
		}
		if (!catchClause.VariableNameToken.IsNull)
		{
			catchBlock.ExceptionVariable = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(catchClause.VariableNameToken.Annotations, catchClause.VariableName);
		}
		if (!catchClause.Condition.IsNull)
		{
			catchBlock.WhenExpression = (ICSharpCode.NRefactory.VB.Ast.Expression)catchClause.Condition.AcceptVisitor(this, data);
		}
		ConvertNodes(catchClause.Body.Statements, catchBlock.Statements);
		return EndNode(catchClause, catchBlock);
	}

	public AstNode VisitUncheckedStatement(UncheckedStatement uncheckedStatement, object data)
	{
		AstNode result = uncheckedStatement.Body.AcceptVisitor(this, data);
		return EndNode(uncheckedStatement, result);
	}

	public AstNode VisitUnsafeStatement(UnsafeStatement unsafeStatement, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitUsingStatement(ICSharpCode.NRefactory.CSharp.UsingStatement usingStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.UsingStatement usingStatement2 = new ICSharpCode.NRefactory.VB.Ast.UsingStatement();
		usingStatement2.Resources.Add(usingStatement.ResourceAcquisition.AcceptVisitor(this, data));
		usingStatement2.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)usingStatement.EmbeddedStatement.AcceptVisitor(this, data);
		return EndNode(usingStatement, usingStatement2);
	}

	public AstNode VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
	{
		LocalDeclarationStatement localDeclarationStatement = new LocalDeclarationStatement();
		localDeclarationStatement.Modifiers = ICSharpCode.NRefactory.VB.Ast.Modifiers.Dim;
		ConvertNodes(variableDeclarationStatement.Variables, localDeclarationStatement.Variables);
		return EndNode(variableDeclarationStatement, localDeclarationStatement);
	}

	public AstNode VisitWhileStatement(ICSharpCode.NRefactory.CSharp.WhileStatement whileStatement, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.WhileStatement result = new ICSharpCode.NRefactory.VB.Ast.WhileStatement
		{
			Condition = (ICSharpCode.NRefactory.VB.Ast.Expression)whileStatement.Condition.AcceptVisitor(this, data),
			Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)whileStatement.EmbeddedStatement.AcceptVisitor(this, data)
		};
		return EndNode(whileStatement, result);
	}

	public AstNode VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement, object data)
	{
		MemberInfo memberInfo = members.Peek();
		memberInfo.inIterator = true;
		return EndNode(yieldBreakStatement, new ICSharpCode.NRefactory.VB.Ast.ReturnStatement());
	}

	public AstNode VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement, object data)
	{
		MemberInfo memberInfo = members.Peek();
		memberInfo.inIterator = true;
		return EndNode(yieldReturnStatement, new YieldStatement((ICSharpCode.NRefactory.VB.Ast.Expression)yieldReturnStatement.Expression.AcceptVisitor(this, data)));
	}

	public AstNode VisitAccessor(ICSharpCode.NRefactory.CSharp.Accessor accessor, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Accessor accessor2 = new ICSharpCode.NRefactory.VB.Ast.Accessor();
		ConvertNodes(accessor.Attributes, accessor2.Attributes);
		ConvertNodes(accessor.ModifierTokens, accessor2.ModifierTokens);
		accessor2.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)accessor.Body.AcceptVisitor(this, data);
		return EndNode(accessor, accessor2);
	}

	public AstNode VisitConstructorDeclaration(ICSharpCode.NRefactory.CSharp.ConstructorDeclaration constructorDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ConstructorDeclaration constructorDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.ConstructorDeclaration();
		ConvertNodes(constructorDeclaration.Attributes, constructorDeclaration2.Attributes);
		ConvertNodes(constructorDeclaration.ModifierTokens, constructorDeclaration2.ModifierTokens);
		ConvertNodes(constructorDeclaration.Parameters, constructorDeclaration2.Parameters);
		constructorDeclaration2.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)constructorDeclaration.Body.AcceptVisitor(this, data);
		if (!constructorDeclaration.Initializer.IsNull)
		{
			constructorDeclaration2.Body.Statements.InsertBefore(constructorDeclaration2.Body.FirstOrDefault(), (ICSharpCode.NRefactory.VB.Ast.Statement)constructorDeclaration.Initializer.AcceptVisitor(this, data));
		}
		return EndNode(constructorDeclaration, constructorDeclaration2);
	}

	public AstNode VisitConstructorInitializer(ConstructorInitializer constructorInitializer, object data)
	{
		MemberAccessExpression memberAccessExpression = new MemberAccessExpression();
		InstanceExpression instanceExpression = (InstanceExpression)(memberAccessExpression.Target = new InstanceExpression((constructorInitializer.ConstructorInitializerType != ConstructorInitializerType.This) ? InstanceExpressionType.MyBase : InstanceExpressionType.Me, TextLocation.Empty));
		ICSharpCode.NRefactory.VB.Ast.Identifier identifier = (memberAccessExpression.MemberName = new ICSharpCode.NRefactory.VB.Ast.Identifier(BoxedTextColor.Keyword, "New", TextLocation.Empty));
		ICSharpCode.NRefactory.VB.Ast.InvocationExpression invocationExpression = new ICSharpCode.NRefactory.VB.Ast.InvocationExpression(memberAccessExpression);
		dnlib.DotNet.IMethod method = constructorInitializer.Annotation<dnlib.DotNet.IMethod>();
		instanceExpression.AddAnnotation(method?.DeclaringType);
		identifier.AddAnnotation(method);
		CopyAnnotations(constructorInitializer, instanceExpression);
		ConvertNodes(constructorInitializer.Arguments, invocationExpression.Arguments);
		return EndNode(constructorInitializer, new ICSharpCode.NRefactory.VB.Ast.ExpressionStatement(invocationExpression));
	}

	public AstNode VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.MethodDeclaration methodDeclaration = new ICSharpCode.NRefactory.VB.Ast.MethodDeclaration
		{
			Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.InstanceMethod, "Finalize"),
			IsSub = true
		};
		ConvertNodes(destructorDeclaration.Attributes, methodDeclaration.Attributes);
		ConvertNodes(destructorDeclaration.ModifierTokens, methodDeclaration.ModifierTokens);
		methodDeclaration.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Overrides;
		methodDeclaration.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)destructorDeclaration.Body.AcceptVisitor(this, data);
		return EndNode(destructorDeclaration, methodDeclaration);
	}

	public AstNode VisitEnumMemberDeclaration(ICSharpCode.NRefactory.CSharp.EnumMemberDeclaration enumMemberDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.EnumMemberDeclaration enumMemberDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.EnumMemberDeclaration();
		ConvertNodes(enumMemberDeclaration.Attributes, enumMemberDeclaration2.Attributes);
		enumMemberDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(enumMemberDeclaration.NameToken.Annotations, enumMemberDeclaration.Name);
		enumMemberDeclaration2.Value = (ICSharpCode.NRefactory.VB.Ast.Expression)enumMemberDeclaration.Initializer.AcceptVisitor(this, data);
		return EndNode(enumMemberDeclaration, enumMemberDeclaration2);
	}

	private bool IsOwnerAModule(ICSharpCode.NRefactory.CSharp.AstNode node)
	{
		if (types.Count > 0 && types.Peek().ClassType == ICSharpCode.NRefactory.VB.Ast.ClassType.Module)
		{
			return true;
		}
		IMemberDef memberDef = node.Annotation<IMemberDef>();
		if (memberDef == null)
		{
			return false;
		}
		TypeDef declaringType = memberDef.DeclaringType;
		if (declaringType != null && declaringType.DeclaringType == null && declaringType.IsSealed)
		{
			return declaringType.IsDefined(stringMicrosoftVisualBasicCompilerServices, stringStandardModuleAttribute);
		}
		return false;
	}

	public AstNode VisitEventDeclaration(ICSharpCode.NRefactory.CSharp.EventDeclaration eventDeclaration, object data)
	{
		members.Push(new MemberInfo());
		ICSharpCode.NRefactory.VB.Ast.EventDeclaration eventDeclaration2 = null;
		foreach (ICSharpCode.NRefactory.CSharp.VariableInitializer variable in eventDeclaration.Variables)
		{
			eventDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.EventDeclaration();
			ConvertNodes(eventDeclaration.Attributes, eventDeclaration2.Attributes);
			if (types.Any() && IsOwnerAModule(eventDeclaration))
			{
				eventDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
			}
			eventDeclaration2.Modifiers = ConvertModifiers(eventDeclaration.Modifiers, eventDeclaration);
			eventDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(variable.NameToken.Annotations, variable.Name);
			eventDeclaration2.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)eventDeclaration.ReturnType.AcceptVisitor(this, data);
			CreateImplementsClausesForEvent(eventDeclaration, eventDeclaration2);
		}
		members.Pop();
		return EndNode(eventDeclaration, eventDeclaration2);
	}

	public AstNode VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.EventDeclaration eventDeclaration = new ICSharpCode.NRefactory.VB.Ast.EventDeclaration();
		members.Push(new MemberInfo());
		ConvertNodes(customEventDeclaration.Attributes, eventDeclaration.Attributes);
		if (IsOwnerAModule(customEventDeclaration))
		{
			customEventDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		eventDeclaration.Modifiers = ConvertModifiers(customEventDeclaration.Modifiers, customEventDeclaration);
		eventDeclaration.IsCustom = true;
		eventDeclaration.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(customEventDeclaration.NameToken.Annotations, customEventDeclaration.Name);
		eventDeclaration.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)customEventDeclaration.ReturnType.AcceptVisitor(this, data);
		CreateImplementsClausesForEvent(customEventDeclaration, eventDeclaration);
		eventDeclaration.AddHandlerBlock = (ICSharpCode.NRefactory.VB.Ast.Accessor)customEventDeclaration.AddAccessor.AcceptVisitor(this, data);
		eventDeclaration.RemoveHandlerBlock = (ICSharpCode.NRefactory.VB.Ast.Accessor)customEventDeclaration.RemoveAccessor.AcceptVisitor(this, data);
		members.Pop();
		return EndNode(customEventDeclaration, eventDeclaration);
	}

	public AstNode VisitFieldDeclaration(ICSharpCode.NRefactory.CSharp.FieldDeclaration fieldDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.FieldDeclaration fieldDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.FieldDeclaration();
		members.Push(new MemberInfo());
		ConvertNodes(fieldDeclaration.Attributes, fieldDeclaration2.Attributes);
		if (IsOwnerAModule(fieldDeclaration))
		{
			fieldDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		ICSharpCode.NRefactory.CSharp.Modifiers modifiers = fieldDeclaration.Modifiers;
		if (modifiers == ICSharpCode.NRefactory.CSharp.Modifiers.None)
		{
			modifiers |= ICSharpCode.NRefactory.CSharp.Modifiers.Private;
		}
		fieldDeclaration2.Modifiers = ConvertModifiers(modifiers, fieldDeclaration);
		ConvertNodes(fieldDeclaration.Variables, fieldDeclaration2.Variables);
		members.Pop();
		return EndNode(fieldDeclaration, fieldDeclaration2);
	}

	public AstNode VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration propertyDeclaration = new ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration();
		members.Push(new MemberInfo());
		ConvertNodes(indexerDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), propertyDeclaration.Attributes);
		propertyDeclaration.Getter = (ICSharpCode.NRefactory.VB.Ast.Accessor)indexerDeclaration.Getter.AcceptVisitor(this, data);
		if (IsOwnerAModule(indexerDeclaration))
		{
			indexerDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		propertyDeclaration.Modifiers = ConvertModifiers(indexerDeclaration.Modifiers, indexerDeclaration);
		propertyDeclaration.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.InstanceProperty, indexerDeclaration.Name);
		ConvertNodes(indexerDeclaration.Parameters, propertyDeclaration.Parameters);
		ConvertNodes(indexerDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), propertyDeclaration.ReturnTypeAttributes);
		CreateImplementsClausesForProperty(indexerDeclaration, propertyDeclaration);
		propertyDeclaration.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)indexerDeclaration.ReturnType.AcceptVisitor(this, data);
		propertyDeclaration.Setter = (ICSharpCode.NRefactory.VB.Ast.Accessor)indexerDeclaration.Setter.AcceptVisitor(this, data);
		if (!propertyDeclaration.Setter.IsNull)
		{
			AstNodeCollection<ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration> parameters = propertyDeclaration.Setter.Parameters;
			ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration parameterDeclaration = new ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration();
			ICSharpCode.NRefactory.VB.Ast.Identifier identifier = (parameterDeclaration.Name = new ICSharpCode.NRefactory.VB.Ast.Identifier(BoxedTextColor.Parameter, "value", TextLocation.Empty));
			parameterDeclaration.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)indexerDeclaration.ReturnType.AcceptVisitor(this, data);
			parameters.Add(parameterDeclaration);
			MethodDef methodDef = propertyDeclaration.Setter.Annotation<MethodDef>();
			if (methodDef != null)
			{
				Parameter parameter = methodDef.Parameters.FirstOrDefault((Parameter a) => a.IsNormalMethodParameter);
				if (parameter != null)
				{
					identifier.AddAnnotation(parameter);
				}
			}
		}
		members.Pop();
		return EndNode(indexerDeclaration, propertyDeclaration);
	}

	public AstNode VisitMethodDeclaration(ICSharpCode.NRefactory.CSharp.MethodDeclaration methodDeclaration, object data)
	{
		if (IsOwnerAModule(methodDeclaration))
		{
			methodDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		if ((methodDeclaration.Modifiers & ICSharpCode.NRefactory.CSharp.Modifiers.Extern) == ICSharpCode.NRefactory.CSharp.Modifiers.Extern && HasAttribute(methodDeclaration.Attributes, "System.Runtime.InteropServices.DllImportAttribute", out var foundAttribute))
		{
			ExternalMethodDeclaration externalMethodDeclaration = new ExternalMethodDeclaration();
			members.Push(new MemberInfo());
			AttributeSection attributeSection = (AttributeSection)foundAttribute.Parent;
			if (attributeSection.Attributes.Count == 1)
			{
				attributeSection.Remove();
			}
			else
			{
				foundAttribute.Remove();
			}
			externalMethodDeclaration.Library = (foundAttribute.Arguments.First().AcceptVisitor(this, data) as ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression).Value.ToString();
			externalMethodDeclaration.CharsetModifier = ConvertCharset(foundAttribute.Arguments);
			externalMethodDeclaration.Alias = ConvertAlias(foundAttribute.Arguments);
			ConvertNodes(methodDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), externalMethodDeclaration.Attributes);
			ConvertNodes(methodDeclaration.ModifierTokens, externalMethodDeclaration.ModifierTokens);
			externalMethodDeclaration.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(methodDeclaration.NameToken.Annotations, methodDeclaration.Name);
			externalMethodDeclaration.IsSub = IsSub(methodDeclaration.ReturnType);
			ConvertNodes(methodDeclaration.Parameters, externalMethodDeclaration.Parameters);
			ConvertNodes(methodDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), externalMethodDeclaration.ReturnTypeAttributes);
			if (!externalMethodDeclaration.IsSub)
			{
				externalMethodDeclaration.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)methodDeclaration.ReturnType.AcceptVisitor(this, data);
			}
			if (members.Pop().inIterator)
			{
				externalMethodDeclaration.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Iterator;
			}
			externalMethodDeclaration.Modifiers &= ~ICSharpCode.NRefactory.VB.Ast.Modifiers.Shared;
			return EndNode(methodDeclaration, externalMethodDeclaration);
		}
		ICSharpCode.NRefactory.VB.Ast.MethodDeclaration methodDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.MethodDeclaration();
		members.Push(new MemberInfo());
		ConvertNodes(methodDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), methodDeclaration2.Attributes);
		ConvertNodes(methodDeclaration.ModifierTokens, methodDeclaration2.ModifierTokens);
		methodDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(methodDeclaration.NameToken.Annotations, methodDeclaration.Name);
		methodDeclaration2.IsSub = IsSub(methodDeclaration.ReturnType);
		ConvertNodes(methodDeclaration.Parameters, methodDeclaration2.Parameters);
		ConvertNodes(methodDeclaration.TypeParameters, methodDeclaration2.TypeParameters);
		ConvertNodes(methodDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), methodDeclaration2.ReturnTypeAttributes);
		CreateImplementsClausesForMethod(methodDeclaration, methodDeclaration2);
		if (!methodDeclaration2.IsSub)
		{
			methodDeclaration2.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)methodDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		if (methodDeclaration.IsExtensionMethod)
		{
			AttributeBlock attributeBlock = new AttributeBlock();
			TypeRef type = module.UpdateRowId(module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "ExtensionAttribute"));
			attributeBlock.Attributes.Add(new ICSharpCode.NRefactory.VB.Ast.Attribute
			{
				Type = CreateType(type)
			});
			methodDeclaration2.Attributes.Add(attributeBlock);
		}
		MethodDef methodDef = methodDeclaration.Annotation<MethodDef>();
		if (methodDef != null)
		{
			methodDeclaration2.Modifiers |= GetExtraMethodModifiers(methodDef);
		}
		methodDeclaration2.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)methodDeclaration.Body.AcceptVisitor(this, data);
		if (members.Pop().inIterator)
		{
			methodDeclaration2.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Iterator;
		}
		return EndNode(methodDeclaration, methodDeclaration2);
	}

	private ICSharpCode.NRefactory.VB.Ast.Modifiers GetExtraMethodModifiers(MethodDef md)
	{
		uint value2;
		if (!modifiersDict.TryGetValue(md.DeclaringType, out var value))
		{
			modifiersDict.Add(md.DeclaringType, value = new Dictionary<string, uint>());
			foreach (MethodDef method in md.DeclaringType.Methods)
			{
				value.TryGetValue(method.Name, out value2);
				if (!method.IsNewSlot && (method.IsAbstract || method.IsFinal || method.IsVirtual))
				{
					value2++;
				}
				value2 += 65536;
				value[method.Name] = value2;
			}
		}
		if (value.TryGetValue(md.Name, out value2))
		{
			uint num = value2 & 0xFFFF;
			uint num2 = value2 >> 16;
			if (num >= 1 && num2 > 1)
			{
				return ICSharpCode.NRefactory.VB.Ast.Modifiers.Overloads;
			}
		}
		return ICSharpCode.NRefactory.VB.Ast.Modifiers.None;
	}

	private static MethodBaseSig GetMethodBaseSig(ITypeDefOrRef type, MethodBaseSig msig, IList<TypeSig> methodGenArgs = null)
	{
		IList<TypeSig> list = null;
		if (type is TypeSpec typeSpec)
		{
			GenericInstSig genericInstSig = typeSpec.TypeSig.ToGenericInstSig();
			if (genericInstSig != null)
			{
				list = genericInstSig.GenericArguments;
			}
		}
		if (list == null && methodGenArgs == null)
		{
			return msig;
		}
		return GenericArgumentResolver.Resolve(msig, list, methodGenArgs);
	}

	private static ITypeDefOrRef GetReplacedType(ITypeDefOrRef iface, ITypeDefOrRef typeToFix)
	{
		IList<TypeSig> list = null;
		if (iface is TypeSpec typeSpec)
		{
			GenericInstSig genericInstSig = typeSpec.TypeSig.ToGenericInstSig();
			if (genericInstSig != null)
			{
				list = genericInstSig.GenericArguments;
			}
		}
		if (list == null)
		{
			return typeToFix;
		}
		return GenericArgumentResolver.Resolve(typeToFix.ToTypeSig(), list, null).ToTypeDefOrRef();
	}

	private static bool IsSameType(List<ImplementsResult> overrides, ITypeDefOrRef type, UTF8String memberName)
	{
		if (overrides == null)
		{
			return false;
		}
		foreach (ImplementsResult @override in overrides)
		{
			if (!(@override.OriginalName != memberName) && new SigComparer((SigComparerOptions)0u).Equals(type, @override.Type))
			{
				return true;
			}
		}
		return false;
	}

	private IEnumerable<ImplementsResult> GetMethods(MethodDef method)
	{
		List<ImplementsResult> overrides = null;
		foreach (MethodOverride @override in method.Overrides)
		{
			MethodDef methodDef = @override.MethodDeclaration.ResolveMethodDef();
			if (methodDef != null && methodDef.DeclaringType.IsInterface)
			{
				ImplementsResult implementsResult = new ImplementsResult(@override.MethodDeclaration, @override.MethodDeclaration);
				if (overrides == null)
				{
					overrides = new List<ImplementsResult>();
				}
				overrides.Add(implementsResult);
				yield return implementsResult;
			}
		}
		SigComparer comparer = new SigComparer((SigComparerOptions)0u, method.Module);
		foreach (InterfaceImpl ii in method.DeclaringType.Interfaces)
		{
			TypeDef typeDef = ii.Interface.Resolve();
			if (typeDef == null)
			{
				continue;
			}
			foreach (MethodDef method2 in typeDef.Methods)
			{
				if (!(method2.Name != method.Name))
				{
					MethodBaseSig methodBaseSig = GetMethodBaseSig(ii.Interface, method2.MethodSig);
					if (comparer.Equals(methodBaseSig, method.MethodSig) && !IsSameType(overrides, ii.Interface, method2.Name))
					{
						yield return new ImplementsResult(ii.Interface, method2.Name, method2);
					}
				}
			}
		}
	}

	private static IEnumerable<ImplementsResult> GetProperties(PropertyDef prop)
	{
		List<ImplementsResult> overrides = null;
		MethodDef methodDef = prop.GetMethod ?? prop.SetMethod;
		if (methodDef != null)
		{
			foreach (MethodOverride @override in methodDef.Overrides)
			{
				MethodDef m = @override.MethodDeclaration.ResolveMethodDef();
				if (m == null || !m.DeclaringType.IsInterface)
				{
					continue;
				}
				PropertyDef propertyDef = m.DeclaringType.Properties.FirstOrDefault((PropertyDef a) => a.GetMethod == m || a.SetMethod == m);
				if (propertyDef != null)
				{
					ImplementsResult implementsResult = new ImplementsResult(@override.MethodDeclaration.DeclaringType, propertyDef.Name, ((object)GetProperty(@override.MethodDeclaration)) ?? ((object)@override.MethodDeclaration));
					if (overrides == null)
					{
						overrides = new List<ImplementsResult>();
					}
					overrides.Add(implementsResult);
					yield return implementsResult;
				}
			}
		}
		SigComparer comparer = new SigComparer((SigComparerOptions)0u, prop.Module);
		foreach (InterfaceImpl ii in prop.DeclaringType.Interfaces)
		{
			TypeDef typeDef = ii.Interface.Resolve();
			if (typeDef == null)
			{
				continue;
			}
			foreach (PropertyDef property in typeDef.Properties)
			{
				if (!(property.Name != prop.Name))
				{
					MethodBaseSig methodBaseSig = GetMethodBaseSig(ii.Interface, property.PropertySig);
					if (methodBaseSig.HasThis != prop.PropertySig.HasThis)
					{
						methodBaseSig = new MethodSig(methodBaseSig.CallingConvention, methodBaseSig.GenParamCount, methodBaseSig.RetType, methodBaseSig.Params, methodBaseSig.ParamsAfterSentinel);
						methodBaseSig.HasThis = prop.PropertySig.HasThis;
					}
					if (comparer.Equals(methodBaseSig, prop.PropertySig) && !IsSameType(overrides, ii.Interface, property.Name))
					{
						yield return new ImplementsResult(ii.Interface, property.Name, property);
					}
				}
			}
		}
	}

	private static PropertyDef GetProperty(IMethodDefOrRef method)
	{
		MethodDef methodDef = method.ResolveMethodDef();
		if (methodDef == null)
		{
			return null;
		}
		foreach (PropertyDef property in methodDef.DeclaringType.Properties)
		{
			if (property.GetMethods.Contains(methodDef))
			{
				return property;
			}
			if (property.SetMethods.Contains(methodDef))
			{
				return property;
			}
			if (property.OtherMethods.Contains(methodDef))
			{
				return property;
			}
		}
		return null;
	}

	private static EventDef GetEvent(IMethodDefOrRef method)
	{
		MethodDef methodDef = method.ResolveMethodDef();
		if (methodDef == null)
		{
			return null;
		}
		foreach (EventDef @event in methodDef.DeclaringType.Events)
		{
			if (@event.AddMethod == methodDef || @event.RemoveMethod == methodDef || @event.InvokeMethod == methodDef)
			{
				return @event;
			}
			if (@event.OtherMethods.Contains(methodDef))
			{
				return @event;
			}
		}
		return null;
	}

	private static IEnumerable<ImplementsResult> GetEvents(EventDef evt)
	{
		List<ImplementsResult> overrides = null;
		MethodDef methodDef = evt.AddMethod ?? evt.RemoveMethod ?? evt.InvokeMethod;
		if (methodDef != null)
		{
			foreach (MethodOverride @override in methodDef.Overrides)
			{
				MethodDef m = @override.MethodDeclaration.ResolveMethodDef();
				if (m == null || !m.DeclaringType.IsInterface)
				{
					continue;
				}
				EventDef eventDef = m.DeclaringType.Events.FirstOrDefault((EventDef a) => a.AddMethod == m || a.RemoveMethod == m || a.InvokeMethod == m);
				if (eventDef != null)
				{
					ImplementsResult implementsResult = new ImplementsResult(@override.MethodDeclaration.DeclaringType, eventDef.Name, ((object)GetEvent(@override.MethodDeclaration)) ?? ((object)@override.MethodDeclaration));
					if (overrides == null)
					{
						overrides = new List<ImplementsResult>();
					}
					overrides.Add(implementsResult);
					yield return implementsResult;
				}
			}
		}
		SigComparer comparer = new SigComparer((SigComparerOptions)0u, evt.Module);
		foreach (InterfaceImpl ii in evt.DeclaringType.Interfaces)
		{
			TypeDef typeDef = ii.Interface.Resolve();
			if (typeDef == null)
			{
				continue;
			}
			foreach (EventDef @event in typeDef.Events)
			{
				if (!(@event.Name != evt.Name))
				{
					ITypeDefOrRef replacedType = GetReplacedType(ii.Interface, @event.EventType);
					if (comparer.Equals(replacedType, evt.EventType) && !IsSameType(overrides, ii.Interface, @event.Name))
					{
						yield return new ImplementsResult(ii.Interface, @event.Name, @event);
					}
				}
			}
		}
	}

	private ICSharpCode.NRefactory.VB.Ast.AstType CreateType(ITypeDefOrRef type)
	{
		ConvertTypeOptions options = ConvertTypeOptions.IncludeNamespace;
		ICSharpCode.NRefactory.CSharp.AstType astType = AstBuilder.ConvertType(type, createTypeStringBuilder, null, options);
		return (ICSharpCode.NRefactory.VB.Ast.AstType)astType.AcceptVisitor(this, null);
	}

	private void CreateImplementsClausesForMethod(ICSharpCode.NRefactory.CSharp.MethodDeclaration orig, ICSharpCode.NRefactory.VB.Ast.MethodDeclaration result)
	{
		MethodDef methodDef = orig.Annotation<MethodDef>();
		if (methodDef == null || !methodDef.IsVirtual)
		{
			return;
		}
		TypeDef declaringType = methodDef.DeclaringType;
		if (declaringType.IsInterface)
		{
			return;
		}
		foreach (ImplementsResult method in GetMethods(methodDef))
		{
			result.ImplementsClause.Add(InterfaceMemberSpecifier.CreateWithData(CreateType(method.Type), method.OriginalName, method.Reference));
		}
	}

	private void CreateImplementsClausesForProperty(IndexerDeclaration orig, ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration result)
	{
		PropertyDef propertyDef = orig.Annotation<PropertyDef>();
		if (propertyDef == null)
		{
			return;
		}
		MethodDef getMethod = propertyDef.GetMethod;
		if (getMethod != null && !getMethod.IsVirtual)
		{
			MethodDef setMethod = propertyDef.SetMethod;
			if (setMethod != null && !setMethod.IsVirtual)
			{
				return;
			}
		}
		TypeDef declaringType = propertyDef.DeclaringType;
		if (declaringType.IsInterface)
		{
			return;
		}
		foreach (ImplementsResult property in GetProperties(propertyDef))
		{
			result.ImplementsClause.Add(InterfaceMemberSpecifier.CreateWithData(CreateType(property.Type), property.OriginalName, property.Reference));
		}
	}

	private void CreateImplementsClausesForProperty(ICSharpCode.NRefactory.CSharp.PropertyDeclaration orig, ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration result)
	{
		PropertyDef propertyDef = orig.Annotation<PropertyDef>();
		if (propertyDef == null)
		{
			return;
		}
		MethodDef getMethod = propertyDef.GetMethod;
		if (getMethod != null && !getMethod.IsVirtual)
		{
			MethodDef setMethod = propertyDef.SetMethod;
			if (setMethod != null && !setMethod.IsVirtual)
			{
				return;
			}
		}
		TypeDef declaringType = propertyDef.DeclaringType;
		if (declaringType.IsInterface)
		{
			return;
		}
		foreach (ImplementsResult property in GetProperties(propertyDef))
		{
			result.ImplementsClause.Add(InterfaceMemberSpecifier.CreateWithData(CreateType(property.Type), property.OriginalName, property.Reference));
		}
	}

	private void CreateImplementsClausesForEvent(CustomEventDeclaration orig, ICSharpCode.NRefactory.VB.Ast.EventDeclaration result)
	{
		EventDef eventDef = orig.Annotation<EventDef>();
		if (eventDef == null)
		{
			return;
		}
		MethodDef addMethod = eventDef.AddMethod;
		if (addMethod != null && !addMethod.IsVirtual)
		{
			MethodDef removeMethod = eventDef.RemoveMethod;
			if (removeMethod != null && !removeMethod.IsVirtual)
			{
				MethodDef invokeMethod = eventDef.InvokeMethod;
				if (invokeMethod != null && !invokeMethod.IsVirtual)
				{
					return;
				}
			}
		}
		TypeDef declaringType = eventDef.DeclaringType;
		if (declaringType.IsInterface)
		{
			return;
		}
		foreach (ImplementsResult @event in GetEvents(eventDef))
		{
			result.ImplementsClause.Add(InterfaceMemberSpecifier.CreateWithData(CreateType(@event.Type), @event.OriginalName, @event.Reference));
		}
	}

	private void CreateImplementsClausesForEvent(ICSharpCode.NRefactory.CSharp.EventDeclaration orig, ICSharpCode.NRefactory.VB.Ast.EventDeclaration result)
	{
		EventDef eventDef = orig.Annotation<EventDef>();
		if (eventDef == null)
		{
			return;
		}
		MethodDef addMethod = eventDef.AddMethod;
		if (addMethod != null && !addMethod.IsVirtual)
		{
			MethodDef removeMethod = eventDef.RemoveMethod;
			if (removeMethod != null && !removeMethod.IsVirtual)
			{
				MethodDef invokeMethod = eventDef.InvokeMethod;
				if (invokeMethod != null && !invokeMethod.IsVirtual)
				{
					return;
				}
			}
		}
		TypeDef declaringType = eventDef.DeclaringType;
		if (declaringType.IsInterface)
		{
			return;
		}
		foreach (ImplementsResult @event in GetEvents(eventDef))
		{
			result.ImplementsClause.Add(InterfaceMemberSpecifier.CreateWithData(CreateType(@event.Type), @event.OriginalName, @event.Reference));
		}
	}

	private string ConvertAlias(ICSharpCode.NRefactory.CSharp.AstNodeCollection<ICSharpCode.NRefactory.CSharp.Expression> arguments)
	{
		ICSharpCode.NRefactory.CSharp.AssignmentExpression pattern = new ICSharpCode.NRefactory.CSharp.AssignmentExpression
		{
			Left = new ICSharpCode.NRefactory.CSharp.IdentifierExpression("EntryPoint"),
			Operator = ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Assign,
			Right = new AnyNode("alias")
		};
		Match match = arguments.Select((ICSharpCode.NRefactory.CSharp.Expression expr) => pattern.Match(expr)).FirstOrDefault((Match r) => r.Success);
		if (match.Success && match.Has("alias"))
		{
			return match.Get<ICSharpCode.NRefactory.CSharp.PrimitiveExpression>("alias").First().Value.ToString();
		}
		return null;
	}

	private CharsetModifier ConvertCharset(ICSharpCode.NRefactory.CSharp.AstNodeCollection<ICSharpCode.NRefactory.CSharp.Expression> arguments)
	{
		ICSharpCode.NRefactory.CSharp.AssignmentExpression pattern = new ICSharpCode.NRefactory.CSharp.AssignmentExpression
		{
			Left = new ICSharpCode.NRefactory.CSharp.IdentifierExpression("CharSet"),
			Operator = ICSharpCode.NRefactory.CSharp.AssignmentOperatorType.Assign,
			Right = new NamedNode("modifier", new MemberReferenceExpression
			{
				Target = new ICSharpCode.NRefactory.CSharp.TypeReferenceExpression
				{
					Type = new AnyNode()
				},
				MemberName = Pattern.AnyString
			})
		};
		Match match = arguments.Select((ICSharpCode.NRefactory.CSharp.Expression expr) => pattern.Match(expr)).FirstOrDefault((Match r) => r.Success);
		if (match.Success && match.Has("modifier"))
		{
			switch (match.Get<MemberReferenceExpression>("modifier").First().MemberName)
			{
			case "Auto":
				return CharsetModifier.Auto;
			case "Ansi":
				return CharsetModifier.Ansi;
			case "Unicode":
				return CharsetModifier.Unicode;
			}
		}
		return CharsetModifier.None;
	}

	private bool IsSub(ICSharpCode.NRefactory.CSharp.AstType returnType)
	{
		if (returnType is ICSharpCode.NRefactory.CSharp.PrimitiveType primitiveType)
		{
			return primitiveType.Keyword == "void";
		}
		return false;
	}

	public AstNode VisitOperatorDeclaration(ICSharpCode.NRefactory.CSharp.OperatorDeclaration operatorDeclaration, object data)
	{
		members.Push(new MemberInfo());
		if (IsOwnerAModule(operatorDeclaration))
		{
			operatorDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		MemberDeclaration result;
		if (operatorDeclaration.OperatorType == OperatorType.Increment || operatorDeclaration.OperatorType == OperatorType.Decrement)
		{
			ICSharpCode.NRefactory.VB.Ast.MethodDeclaration methodDeclaration = new ICSharpCode.NRefactory.VB.Ast.MethodDeclaration();
			result = methodDeclaration;
			ConvertNodes(operatorDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), methodDeclaration.Attributes);
			ConvertNodes(operatorDeclaration.ModifierTokens, methodDeclaration.ModifierTokens);
			methodDeclaration.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(VisualBasicMetadataTextColorProvider.Instance.GetColor(operatorDeclaration.Annotation<dnlib.DotNet.IMethod>() ?? BoxedTextColor.InstanceMethod), (operatorDeclaration.OperatorType == OperatorType.Increment) ? "op_Increment" : "op_Decrement");
			ConvertNodes(operatorDeclaration.Parameters, methodDeclaration.Parameters);
			ConvertNodes(operatorDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), methodDeclaration.ReturnTypeAttributes);
			methodDeclaration.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)operatorDeclaration.ReturnType.AcceptVisitor(this, data);
			methodDeclaration.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)operatorDeclaration.Body.AcceptVisitor(this, data);
		}
		else
		{
			ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration operatorDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration();
			result = operatorDeclaration2;
			ConvertNodes(operatorDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), operatorDeclaration2.Attributes);
			ConvertNodes(operatorDeclaration.ModifierTokens, operatorDeclaration2.ModifierTokens);
			switch (operatorDeclaration.OperatorType)
			{
			case OperatorType.LogicalNot:
			case OperatorType.OnesComplement:
				operatorDeclaration2.Operator = OverloadableOperatorType.Not;
				break;
			case OperatorType.True:
				operatorDeclaration2.Operator = OverloadableOperatorType.IsTrue;
				break;
			case OperatorType.False:
				operatorDeclaration2.Operator = OverloadableOperatorType.IsFalse;
				break;
			case OperatorType.Implicit:
				operatorDeclaration2.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Widening;
				operatorDeclaration2.Operator = OverloadableOperatorType.CType;
				break;
			case OperatorType.Explicit:
				operatorDeclaration2.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Narrowing;
				operatorDeclaration2.Operator = OverloadableOperatorType.CType;
				break;
			case OperatorType.Addition:
				operatorDeclaration2.Operator = OverloadableOperatorType.Add;
				break;
			case OperatorType.Subtraction:
				operatorDeclaration2.Operator = OverloadableOperatorType.Subtract;
				break;
			case OperatorType.UnaryPlus:
				operatorDeclaration2.Operator = OverloadableOperatorType.UnaryPlus;
				break;
			case OperatorType.UnaryNegation:
				operatorDeclaration2.Operator = OverloadableOperatorType.UnaryMinus;
				break;
			case OperatorType.Multiply:
				operatorDeclaration2.Operator = OverloadableOperatorType.Multiply;
				break;
			case OperatorType.Division:
				operatorDeclaration2.Operator = OverloadableOperatorType.Divide;
				break;
			case OperatorType.Modulus:
				operatorDeclaration2.Operator = OverloadableOperatorType.Modulus;
				break;
			case OperatorType.BitwiseAnd:
				operatorDeclaration2.Operator = OverloadableOperatorType.BitwiseAnd;
				break;
			case OperatorType.BitwiseOr:
				operatorDeclaration2.Operator = OverloadableOperatorType.BitwiseOr;
				break;
			case OperatorType.ExclusiveOr:
				operatorDeclaration2.Operator = OverloadableOperatorType.ExclusiveOr;
				break;
			case OperatorType.LeftShift:
				operatorDeclaration2.Operator = OverloadableOperatorType.ShiftLeft;
				break;
			case OperatorType.RightShift:
				operatorDeclaration2.Operator = OverloadableOperatorType.ShiftRight;
				break;
			case OperatorType.Equality:
				operatorDeclaration2.Operator = OverloadableOperatorType.Equality;
				break;
			case OperatorType.Inequality:
				operatorDeclaration2.Operator = OverloadableOperatorType.InEquality;
				break;
			case OperatorType.GreaterThan:
				operatorDeclaration2.Operator = OverloadableOperatorType.GreaterThan;
				break;
			case OperatorType.LessThan:
				operatorDeclaration2.Operator = OverloadableOperatorType.LessThan;
				break;
			case OperatorType.GreaterThanOrEqual:
				operatorDeclaration2.Operator = OverloadableOperatorType.GreaterThanOrEqual;
				break;
			case OperatorType.LessThanOrEqual:
				operatorDeclaration2.Operator = OverloadableOperatorType.LessThanOrEqual;
				break;
			default:
				throw new Exception("Invalid value for OperatorType");
			}
			ConvertNodes(operatorDeclaration.Parameters, operatorDeclaration2.Parameters);
			ConvertNodes(operatorDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), operatorDeclaration2.ReturnTypeAttributes);
			operatorDeclaration2.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)operatorDeclaration.ReturnType.AcceptVisitor(this, data);
			operatorDeclaration2.Body = (ICSharpCode.NRefactory.VB.Ast.BlockStatement)operatorDeclaration.Body.AcceptVisitor(this, data);
		}
		members.Pop();
		return EndNode(operatorDeclaration, result);
	}

	public AstNode VisitParameterDeclaration(ICSharpCode.NRefactory.CSharp.ParameterDeclaration parameterDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration parameterDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration();
		ConvertNodes(parameterDeclaration.Attributes, parameterDeclaration2.Attributes);
		parameterDeclaration2.Modifiers = ConvertParamModifiers(parameterDeclaration.ParameterModifier);
		if ((parameterDeclaration.ParameterModifier & ParameterModifier.Out) == ParameterModifier.Out)
		{
			AttributeBlock attributeBlock = new AttributeBlock();
			TypeRef type = module.UpdateRowId(module.CorLibTypes.GetTypeRef("System.Runtime.InteropServices", "OutAttribute"));
			attributeBlock.Attributes.Add(new ICSharpCode.NRefactory.VB.Ast.Attribute
			{
				Type = CreateType(type)
			});
			parameterDeclaration2.Attributes.Add(attributeBlock);
		}
		parameterDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(parameterDeclaration.NameToken.Annotations, parameterDeclaration.Name);
		parameterDeclaration2.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)parameterDeclaration.Type.AcceptVisitor(this, data);
		parameterDeclaration2.OptionalValue = (ICSharpCode.NRefactory.VB.Ast.Expression)parameterDeclaration.DefaultExpression.AcceptVisitor(this, data);
		if (!parameterDeclaration2.OptionalValue.IsNull)
		{
			parameterDeclaration2.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Optional;
		}
		return EndNode(parameterDeclaration, parameterDeclaration2);
	}

	private ICSharpCode.NRefactory.VB.Ast.Modifiers ConvertParamModifiers(ParameterModifier mods)
	{
		switch (mods)
		{
		case ParameterModifier.None:
		case ParameterModifier.This:
			return ICSharpCode.NRefactory.VB.Ast.Modifiers.None;
		case ParameterModifier.In:
		case ParameterModifier.Ref:
		case ParameterModifier.Out:
			return ICSharpCode.NRefactory.VB.Ast.Modifiers.ByRef;
		case ParameterModifier.Params:
			return ICSharpCode.NRefactory.VB.Ast.Modifiers.ParamArray;
		default:
			throw new Exception("Invalid value for ParameterModifier");
		}
	}

	public AstNode VisitPropertyDeclaration(ICSharpCode.NRefactory.CSharp.PropertyDeclaration propertyDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration propertyDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration();
		members.Push(new MemberInfo());
		if (IsOwnerAModule(propertyDeclaration))
		{
			propertyDeclaration.Modifiers &= ~ICSharpCode.NRefactory.CSharp.Modifiers.Static;
		}
		ConvertNodes(propertyDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget != "return"), propertyDeclaration2.Attributes);
		propertyDeclaration2.Getter = (ICSharpCode.NRefactory.VB.Ast.Accessor)propertyDeclaration.Getter.AcceptVisitor(this, data);
		propertyDeclaration2.Modifiers = ConvertModifiers(propertyDeclaration.Modifiers, propertyDeclaration);
		propertyDeclaration2.Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(propertyDeclaration.NameToken.Annotations, propertyDeclaration.Name);
		ConvertNodes(propertyDeclaration.Attributes.Where((AttributeSection section) => section.AttributeTarget == "return"), propertyDeclaration2.ReturnTypeAttributes);
		CreateImplementsClausesForProperty(propertyDeclaration, propertyDeclaration2);
		propertyDeclaration2.ReturnType = (ICSharpCode.NRefactory.VB.Ast.AstType)propertyDeclaration.ReturnType.AcceptVisitor(this, data);
		propertyDeclaration2.Setter = (ICSharpCode.NRefactory.VB.Ast.Accessor)propertyDeclaration.Setter.AcceptVisitor(this, data);
		if (!propertyDeclaration2.Setter.IsNull)
		{
			AstNodeCollection<ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration> parameters = propertyDeclaration2.Setter.Parameters;
			ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration parameterDeclaration = new ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration();
			ICSharpCode.NRefactory.VB.Ast.Identifier identifier = (parameterDeclaration.Name = new ICSharpCode.NRefactory.VB.Ast.Identifier(BoxedTextColor.Parameter, "value", TextLocation.Empty));
			parameterDeclaration.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)propertyDeclaration.ReturnType.AcceptVisitor(this, data);
			parameters.Add(parameterDeclaration);
			MethodDef methodDef = propertyDeclaration2.Setter.Annotation<MethodDef>();
			if (methodDef != null)
			{
				Parameter parameter = methodDef.Parameters.FirstOrDefault((Parameter a) => a.IsNormalMethodParameter);
				if (parameter != null)
				{
					identifier.AddAnnotation(parameter);
				}
			}
		}
		if (members.Pop().inIterator)
		{
			propertyDeclaration2.Modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Iterator;
		}
		ConvertNodes(propertyDeclaration.Variables, propertyDeclaration2.Variables);
		ConvertNodes(provider.GetParametersForProperty(propertyDeclaration), propertyDeclaration2.Parameters);
		return EndNode(propertyDeclaration, propertyDeclaration2);
	}

	public AstNode VisitVariableInitializer(ICSharpCode.NRefactory.CSharp.VariableInitializer variableInitializer, object data)
	{
		VariableDeclaratorWithTypeAndInitializer variableDeclaratorWithTypeAndInitializer = new VariableDeclaratorWithTypeAndInitializer();
		variableDeclaratorWithTypeAndInitializer.Type = (ICSharpCode.NRefactory.VB.Ast.AstType)variableInitializer.Parent.GetChildByRole(Roles.Type).AcceptVisitor(this, data);
		variableDeclaratorWithTypeAndInitializer.Identifiers.Add(new VariableIdentifier
		{
			Name = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(variableInitializer.NameToken.Annotations, variableInitializer.Name)
		});
		variableDeclaratorWithTypeAndInitializer.Initializer = (ICSharpCode.NRefactory.VB.Ast.Expression)variableInitializer.Initializer.AcceptVisitor(this, data);
		return EndNode(variableInitializer, variableDeclaratorWithTypeAndInitializer);
	}

	public AstNode VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitSyntaxTree(SyntaxTree syntaxTree, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.CompilationUnit compilationUnit = new ICSharpCode.NRefactory.VB.Ast.CompilationUnit();
		foreach (ICSharpCode.NRefactory.CSharp.AstNode child in syntaxTree.Children)
		{
			compilationUnit.AddChild(child.AcceptVisitor(this, null), ICSharpCode.NRefactory.VB.Ast.CompilationUnit.MemberRole);
		}
		return EndNode(syntaxTree, compilationUnit);
	}

	public AstNode VisitSimpleType(ICSharpCode.NRefactory.CSharp.SimpleType simpleType, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.SimpleType simpleType2 = new ICSharpCode.NRefactory.VB.Ast.SimpleType(simpleType.IdentifierToken.Annotations, simpleType.Identifier);
		ConvertNodes(simpleType.TypeArguments, simpleType2.TypeArguments);
		return EndNode(simpleType, simpleType2);
	}

	public AstNode VisitMemberType(MemberType memberType, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.AstType astType = null;
		astType = ((!(memberType.Target is ICSharpCode.NRefactory.CSharp.SimpleType) || !((ICSharpCode.NRefactory.CSharp.SimpleType)memberType.Target).Identifier.Equals("global", StringComparison.Ordinal)) ? ((ICSharpCode.NRefactory.VB.Ast.AstType)memberType.Target.AcceptVisitor(this, data)) : new ICSharpCode.NRefactory.VB.Ast.PrimitiveType("Global"));
		QualifiedType qualifiedType = new QualifiedType(astType, ICSharpCode.NRefactory.VB.Ast.Identifier.Create(memberType.MemberNameToken.Annotations, memberType.MemberName));
		ConvertNodes(memberType.TypeArguments, qualifiedType.TypeArguments);
		return EndNode(memberType, qualifiedType);
	}

	public AstNode VisitComposedType(ICSharpCode.NRefactory.CSharp.ComposedType composedType, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.AstType astType = new ICSharpCode.NRefactory.VB.Ast.ComposedType();
		ConvertNodes(composedType.ArraySpecifiers, ((ICSharpCode.NRefactory.VB.Ast.ComposedType)astType).ArraySpecifiers);
		((ICSharpCode.NRefactory.VB.Ast.ComposedType)astType).BaseType = (ICSharpCode.NRefactory.VB.Ast.AstType)composedType.BaseType.AcceptVisitor(this, data);
		((ICSharpCode.NRefactory.VB.Ast.ComposedType)astType).HasNullableSpecifier = composedType.HasNullableSpecifier;
		for (int i = 0; i < composedType.PointerRank; i++)
		{
			ICSharpCode.NRefactory.VB.Ast.SimpleType simpleType = new ICSharpCode.NRefactory.VB.Ast.SimpleType(ICSharpCode.NRefactory.VB.Ast.Identifier.Create(BoxedTextColor.Keyword, "__Pointer"));
			simpleType.TypeArguments.Add(astType);
			astType = simpleType;
		}
		return EndNode(composedType, astType);
	}

	public AstNode VisitArraySpecifier(ICSharpCode.NRefactory.CSharp.ArraySpecifier arraySpecifier, object data)
	{
		return EndNode(arraySpecifier, new ICSharpCode.NRefactory.VB.Ast.ArraySpecifier(arraySpecifier.Dimensions));
	}

	public AstNode VisitPrimitiveType(ICSharpCode.NRefactory.CSharp.PrimitiveType primitiveType, object data)
	{
		return EndNode(primitiveType, new ICSharpCode.NRefactory.VB.Ast.PrimitiveType(primitiveType.Keyword switch
		{
			"object" => "Object", 
			"bool" => "Boolean", 
			"char" => "Char", 
			"sbyte" => "SByte", 
			"byte" => "Byte", 
			"short" => "Short", 
			"ushort" => "UShort", 
			"int" => "Integer", 
			"uint" => "UInteger", 
			"long" => "Long", 
			"ulong" => "ULong", 
			"float" => "Single", 
			"double" => "Double", 
			"decimal" => "Decimal", 
			"string" => "String", 
			"new" => "New", 
			"struct" => "Structure", 
			"class" => "Class", 
			"void" => "Void", 
			"__arglist" => "__ArgList", 
			_ => "unknown", 
		}));
	}

	public AstNode VisitComment(ICSharpCode.NRefactory.CSharp.Comment comment, object data)
	{
		if (!comment.IsDocumentation)
		{
			return null;
		}
		Comment result = new Comment(comment.Content, comment.CommentType == CommentType.Documentation);
		if (comment.CommentType == CommentType.MultiLine)
		{
			throw new NotImplementedException();
		}
		return EndNode(comment, result);
	}

	public AstNode VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective, object data)
	{
		return null;
	}

	public AstNode VisitTypeParameterDeclaration(ICSharpCode.NRefactory.CSharp.TypeParameterDeclaration typeParameterDeclaration, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.TypeParameterDeclaration typeParameterDeclaration2 = new ICSharpCode.NRefactory.VB.Ast.TypeParameterDeclaration
		{
			Variance = typeParameterDeclaration.Variance,
			NameToken = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(typeParameterDeclaration.NameToken.Annotations, typeParameterDeclaration.Name)
		};
		typeParameterDeclaration2.NameToken.AddAnnotation(typeParameterDeclaration.Annotation<object>());
		Constraint constraint = typeParameterDeclaration.Parent.GetChildrenByRole(Roles.Constraint).SingleOrDefault((Constraint c) => c.TypeParameter.Identifier == typeParameterDeclaration.Name);
		if (constraint != null)
		{
			ConvertNodes(constraint.BaseTypes, typeParameterDeclaration2.Constraints);
		}
		return EndNode(typeParameterDeclaration, typeParameterDeclaration2);
	}

	public AstNode VisitConstraint(Constraint constraint, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode, object data)
	{
		if (cSharpTokenNode is CSharpModifierToken cSharpModifierToken)
		{
			ICSharpCode.NRefactory.VB.Ast.Modifiers modifiers = ConvertModifiers(cSharpModifierToken.Modifier, cSharpModifierToken.Parent);
			VBModifierToken result = null;
			if (modifiers != ICSharpCode.NRefactory.VB.Ast.Modifiers.None)
			{
				result = new VBModifierToken(TextLocation.Empty, modifiers);
				return EndNode(cSharpTokenNode, result);
			}
			return EndNode(cSharpTokenNode, result);
		}
		throw new NotSupportedException("Should never visit individual tokens");
	}

	private ICSharpCode.NRefactory.VB.Ast.Modifiers ConvertModifiers(ICSharpCode.NRefactory.CSharp.Modifiers modifier, ICSharpCode.NRefactory.CSharp.AstNode container)
	{
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Any) == ICSharpCode.NRefactory.CSharp.Modifiers.Any)
		{
			return ICSharpCode.NRefactory.VB.Ast.Modifiers.Any;
		}
		ICSharpCode.NRefactory.VB.Ast.Modifiers modifiers = ICSharpCode.NRefactory.VB.Ast.Modifiers.None;
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Const) == ICSharpCode.NRefactory.CSharp.Modifiers.Const)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Const;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Partial) == ICSharpCode.NRefactory.CSharp.Modifiers.Partial)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Partial;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Abstract) == ICSharpCode.NRefactory.CSharp.Modifiers.Abstract)
		{
			modifiers = ((!(container is ICSharpCode.NRefactory.CSharp.TypeDeclaration)) ? (modifiers | ICSharpCode.NRefactory.VB.Ast.Modifiers.MustOverride) : (modifiers | ICSharpCode.NRefactory.VB.Ast.Modifiers.MustInherit));
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Static) == ICSharpCode.NRefactory.CSharp.Modifiers.Static)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Shared;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Public) == ICSharpCode.NRefactory.CSharp.Modifiers.Public)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Public;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Protected) == ICSharpCode.NRefactory.CSharp.Modifiers.Protected)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Protected;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Internal) == ICSharpCode.NRefactory.CSharp.Modifiers.Internal)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Friend;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Private) == ICSharpCode.NRefactory.CSharp.Modifiers.Private)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Private;
		}
		if (container is IndexerDeclaration)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Default;
		}
		bool flag = IsWriteableProperty(container);
		bool flag2 = IsReadableProperty(container);
		if (flag && !flag2)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.WriteOnly;
		}
		if (flag2 && !flag)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.ReadOnly;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Override) == ICSharpCode.NRefactory.CSharp.Modifiers.Override)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Overrides;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Virtual) == ICSharpCode.NRefactory.CSharp.Modifiers.Virtual)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Overridable;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Async) == ICSharpCode.NRefactory.CSharp.Modifiers.Async)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.Async;
		}
		if ((modifier & ICSharpCode.NRefactory.CSharp.Modifiers.Sealed) == ICSharpCode.NRefactory.CSharp.Modifiers.Sealed)
		{
			modifiers |= ICSharpCode.NRefactory.VB.Ast.Modifiers.NotInheritable;
		}
		return modifiers;
	}

	private bool IsReadableProperty(ICSharpCode.NRefactory.CSharp.AstNode container)
	{
		if (container is IndexerDeclaration)
		{
			IndexerDeclaration indexerDeclaration = container as IndexerDeclaration;
			return !indexerDeclaration.Getter.IsNull;
		}
		if (container is ICSharpCode.NRefactory.CSharp.PropertyDeclaration)
		{
			ICSharpCode.NRefactory.CSharp.PropertyDeclaration propertyDeclaration = container as ICSharpCode.NRefactory.CSharp.PropertyDeclaration;
			return !propertyDeclaration.Getter.IsNull;
		}
		return false;
	}

	private bool IsWriteableProperty(ICSharpCode.NRefactory.CSharp.AstNode container)
	{
		if (container is IndexerDeclaration)
		{
			IndexerDeclaration indexerDeclaration = container as IndexerDeclaration;
			return !indexerDeclaration.Setter.IsNull;
		}
		if (container is ICSharpCode.NRefactory.CSharp.PropertyDeclaration)
		{
			ICSharpCode.NRefactory.CSharp.PropertyDeclaration propertyDeclaration = container as ICSharpCode.NRefactory.CSharp.PropertyDeclaration;
			return !propertyDeclaration.Setter.IsNull;
		}
		return false;
	}

	public AstNode VisitIdentifier(ICSharpCode.NRefactory.CSharp.Identifier identifier, object data)
	{
		ICSharpCode.NRefactory.VB.Ast.Identifier result = ICSharpCode.NRefactory.VB.Ast.Identifier.Create(identifier.Annotations, identifier.Name, identifier.StartLocation);
		return EndNode(identifier, result);
	}

	public AstNode VisitPatternPlaceholder(ICSharpCode.NRefactory.CSharp.AstNode placeholder, Pattern pattern, object data)
	{
		throw new NotImplementedException();
	}

	private void ConvertNodes<T>(IEnumerable<ICSharpCode.NRefactory.CSharp.AstNode> nodes, AstNodeCollection<T> result, Func<T, T> transform = null) where T : AstNode
	{
		foreach (ICSharpCode.NRefactory.CSharp.AstNode node in nodes)
		{
			T val = (T)node.AcceptVisitor(this, null);
			if (transform != null)
			{
				val = transform(val);
			}
			if (val != null)
			{
				result.Add(val);
			}
		}
	}

	private void ConvertMembers<T, S, M>(ICSharpCode.NRefactory.CSharp.AstNode parent, T result, Role<S> sourceRole, Role<M> targetRole) where T : AstNode where S : ICSharpCode.NRefactory.CSharp.AstNode where M : AstNode
	{
		foreach (ICSharpCode.NRefactory.CSharp.AstNode child in parent.Children)
		{
			if (child.Role == Roles.Comment)
			{
				Comment comment = (Comment)child.AcceptVisitor(this, null);
				if (comment != null)
				{
					result.AddChild(comment, AstNode.Roles.Comment);
				}
			}
			if (child.Role == sourceRole)
			{
				M val = (M)child.AcceptVisitor(this, null);
				if (val != null)
				{
					result.AddChild(val, targetRole);
				}
			}
		}
	}

	private T EndNode<T>(ICSharpCode.NRefactory.CSharp.AstNode node, T result) where T : AstNode
	{
		if (result != null)
		{
			CopyComments(node, result);
			CopyAnnotations(node, result);
		}
		return result;
	}

	private void CopyAnnotations<T>(ICSharpCode.NRefactory.CSharp.AstNode node, T result) where T : AstNode
	{
		foreach (object annotation in node.Annotations)
		{
			result.AddAnnotation(annotation);
		}
	}

	private bool HasAttribute(ICSharpCode.NRefactory.CSharp.AstNodeCollection<AttributeSection> attributes, string name, out ICSharpCode.NRefactory.CSharp.Attribute foundAttribute)
	{
		foreach (ICSharpCode.NRefactory.CSharp.Attribute item in attributes.SelectMany((AttributeSection a) => a.Attributes))
		{
			if (provider.GetTypeNameForAttribute(item) == name)
			{
				foundAttribute = item;
				return true;
			}
		}
		foundAttribute = null;
		return false;
	}

	public AstNode VisitDocumentationReference(DocumentationReference documentationReference, object data)
	{
		throw new NotImplementedException();
	}

	public AstNode VisitNewLine(NewLineNode newLineNode, object data)
	{
		return null;
	}

	public AstNode VisitWhitespace(WhitespaceNode whitespaceNode, object data)
	{
		return null;
	}

	public AstNode VisitText(TextNode textNode, object data)
	{
		return null;
	}

	public AstNode VisitNullNode(ICSharpCode.NRefactory.CSharp.AstNode nullNode, object data)
	{
		return null;
	}

	public AstNode VisitErrorNode(ICSharpCode.NRefactory.CSharp.AstNode errorNode, object data)
	{
		return null;
	}

	private void CopyComments(ICSharpCode.NRefactory.CSharp.AstNode node, AstNode result)
	{
		foreach (ICSharpCode.NRefactory.CSharp.Comment item in node.GetChildrenByRole(Roles.Comment).Reverse())
		{
			if (!item.IsDocumentation)
			{
				result.InsertChildAfter(null, new Comment(item.Content)
				{
					References = item.References
				}, AstNode.Roles.Comment);
			}
		}
	}
}
