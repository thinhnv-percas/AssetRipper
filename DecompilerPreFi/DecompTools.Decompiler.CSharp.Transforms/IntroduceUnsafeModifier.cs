using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class IntroduceUnsafeModifier : DepthFirstAstVisitor<bool>, IAstTransform
{
	public void Run(AstNode compilationUnit, TransformContext context)
	{
		compilationUnit.AcceptVisitor(this);
	}

	public static bool IsUnsafe(AstNode node)
	{
		return node.AcceptVisitor(new IntroduceUnsafeModifier());
	}

	protected override bool VisitChildren(AstNode node)
	{
		bool flag = false;
		AstNode astNode = node.FirstChild;
		while (astNode != null)
		{
			AstNode nextSibling = astNode.NextSibling;
			flag |= astNode.AcceptVisitor(this);
			astNode = nextSibling;
		}
		if (flag && node is EntityDeclaration && !(node is Accessor))
		{
			((EntityDeclaration)node).Modifiers |= Modifiers.Unsafe;
			return false;
		}
		return flag;
	}

	public override bool VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
	{
		base.VisitPointerReferenceExpression(pointerReferenceExpression);
		return true;
	}

	public override bool VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
	{
		base.VisitSizeOfExpression(sizeOfExpression);
		return true;
	}

	public override bool VisitComposedType(ComposedType composedType)
	{
		if (composedType.PointerRank > 0)
		{
			return true;
		}
		return base.VisitComposedType(composedType);
	}

	public override bool VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
	{
		bool result = base.VisitUnaryOperatorExpression(unaryOperatorExpression);
		if (unaryOperatorExpression.Operator == UnaryOperatorType.Dereference)
		{
			if (unaryOperatorExpression.Expression is BinaryOperatorExpression { Operator: BinaryOperatorType.Add } binaryOperatorExpression && binaryOperatorExpression.GetResolveResult() is OperatorResolveResult operatorResolveResult)
			{
				ResolveResult resolveResult = Enumerable.FirstOrDefault<ResolveResult>((IEnumerable<ResolveResult>)operatorResolveResult.Operands);
				if (resolveResult != null && resolveResult.Type.Kind == TypeKind.Pointer)
				{
					IndexerExpression indexerExpression = new IndexerExpression();
					indexerExpression.Target = binaryOperatorExpression.Left.Detach();
					indexerExpression.Arguments.Add(binaryOperatorExpression.Right.Detach());
					indexerExpression.CopyAnnotationsFrom(unaryOperatorExpression);
					indexerExpression.CopyAnnotationsFrom(binaryOperatorExpression);
					unaryOperatorExpression.ReplaceWith(indexerExpression);
				}
			}
			return true;
		}
		if (unaryOperatorExpression.Operator == UnaryOperatorType.AddressOf)
		{
			return true;
		}
		return result;
	}

	public override bool VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
	{
		bool result = base.VisitMemberReferenceExpression(memberReferenceExpression);
		if (memberReferenceExpression.Target is UnaryOperatorExpression { Operator: UnaryOperatorType.Dereference } unaryOperatorExpression)
		{
			PointerReferenceExpression pointerReferenceExpression = new PointerReferenceExpression();
			pointerReferenceExpression.Target = unaryOperatorExpression.Expression.Detach();
			pointerReferenceExpression.MemberName = memberReferenceExpression.MemberName;
			memberReferenceExpression.TypeArguments.MoveTo(pointerReferenceExpression.TypeArguments);
			pointerReferenceExpression.CopyAnnotationsFrom(unaryOperatorExpression);
			pointerReferenceExpression.RemoveAnnotations<ResolveResult>();
			pointerReferenceExpression.CopyAnnotationsFrom(memberReferenceExpression);
			memberReferenceExpression.ReplaceWith(pointerReferenceExpression);
		}
		ResolveResult resolveResult = memberReferenceExpression.GetResolveResult();
		if (resolveResult != null)
		{
			if (resolveResult.Type is PointerType)
			{
				return true;
			}
			if (resolveResult is MemberResolveResult memberResolveResult && memberResolveResult.Member.ReturnType.Kind == TypeKind.Delegate)
			{
				IMethod method = memberResolveResult.Member.ReturnType.GetDefinition()?.GetDelegateInvokeMethod();
				if (method != null && (method.ReturnType is PointerType || Enumerable.Any<IParameter>((IEnumerable<IParameter>)method.Parameters, (Func<IParameter, bool>)((IParameter p) => p.Type is PointerType))))
				{
					return true;
				}
			}
		}
		return result;
	}

	public override bool VisitIdentifierExpression(IdentifierExpression identifierExpression)
	{
		bool result = base.VisitIdentifierExpression(identifierExpression);
		ResolveResult resolveResult = identifierExpression.GetResolveResult();
		if (resolveResult != null)
		{
			if (resolveResult.Type is PointerType)
			{
				return true;
			}
			if (resolveResult is MemberResolveResult memberResolveResult && memberResolveResult.Member.ReturnType.Kind == TypeKind.Delegate)
			{
				IMethod method = memberResolveResult.Member.ReturnType.GetDefinition()?.GetDelegateInvokeMethod();
				if (method != null && (method.ReturnType is PointerType || Enumerable.Any<IParameter>((IEnumerable<IParameter>)method.Parameters, (Func<IParameter, bool>)((IParameter p) => p.Type is PointerType))))
				{
					return true;
				}
			}
		}
		return result;
	}

	public override bool VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
	{
		bool result = base.VisitStackAllocExpression(stackAllocExpression);
		if (stackAllocExpression.GetResolveResult()?.Type is PointerType)
		{
			return true;
		}
		return result;
	}

	public override bool VisitInvocationExpression(InvocationExpression invocationExpression)
	{
		bool result = base.VisitInvocationExpression(invocationExpression);
		ResolveResult resolveResult = invocationExpression.GetResolveResult();
		if (resolveResult != null && resolveResult.Type is PointerType)
		{
			return true;
		}
		return result;
	}

	public override bool VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
	{
		base.VisitFixedVariableInitializer(fixedVariableInitializer);
		return true;
	}
}
