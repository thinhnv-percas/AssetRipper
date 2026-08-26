using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class IntroduceUnsafeModifier : DepthFirstAstVisitor<object, bool>, IAstTransform
	{
		private sealed class PointerArithmetic
		{
		}

		public static readonly object PointerArithmeticAnnotation = new PointerArithmetic();

		public void Run(AstNode compilationUnit)
		{
			compilationUnit.AcceptVisitor(this, null);
		}

		protected override bool VisitChildren(AstNode node, object data)
		{
			bool flag = false;
			AstNode nextSibling;
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = nextSibling)
			{
				nextSibling = astNode.NextSibling;
				flag |= astNode.AcceptVisitor(this, data);
			}
			if (flag && node is EntityDeclaration && !(node is Accessor))
			{
				((EntityDeclaration)node).Modifiers |= Modifiers.Unsafe;
				return false;
			}
			return flag;
		}

		public override bool VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, object data)
		{
			base.VisitPointerReferenceExpression(pointerReferenceExpression, data);
			return true;
		}

		public override bool VisitComposedType(ComposedType composedType, object data)
		{
			if (composedType.PointerRank > 0)
			{
				return true;
			}
			return base.VisitComposedType(composedType, data);
		}

		public override bool VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, object data)
		{
			bool result = base.VisitUnaryOperatorExpression(unaryOperatorExpression, data);
			if (unaryOperatorExpression.Operator == UnaryOperatorType.Dereference)
			{
				BinaryOperatorExpression binaryOperatorExpression = unaryOperatorExpression.Expression as BinaryOperatorExpression;
				if (binaryOperatorExpression != null && binaryOperatorExpression.Operator == BinaryOperatorType.Add && binaryOperatorExpression.Annotation<PointerArithmetic>() != null)
				{
					IndexerExpression indexerExpression = new IndexerExpression();
					indexerExpression.Target = binaryOperatorExpression.Left.Detach();
					indexerExpression.Arguments.Add(binaryOperatorExpression.Right.Detach());
					indexerExpression.CopyAnnotationsFrom(unaryOperatorExpression);
					indexerExpression.CopyAnnotationsFrom(binaryOperatorExpression);
					unaryOperatorExpression.ReplaceWith(indexerExpression);
				}
				return true;
			}
			if (unaryOperatorExpression.Operator == UnaryOperatorType.AddressOf)
			{
				return true;
			}
			return result;
		}

		public override bool VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
		{
			bool result = base.VisitMemberReferenceExpression(memberReferenceExpression, data);
			UnaryOperatorExpression unaryOperatorExpression = memberReferenceExpression.Target as UnaryOperatorExpression;
			if (unaryOperatorExpression != null && unaryOperatorExpression.Operator == UnaryOperatorType.Dereference)
			{
				PointerReferenceExpression pointerReferenceExpression = new PointerReferenceExpression
				{
					Target = unaryOperatorExpression.Expression.Detach(),
					MemberName = memberReferenceExpression.MemberName
				};
				memberReferenceExpression.TypeArguments.MoveTo(pointerReferenceExpression.TypeArguments);
				pointerReferenceExpression.CopyAnnotationsFrom(unaryOperatorExpression);
				pointerReferenceExpression.CopyAnnotationsFrom(memberReferenceExpression);
				memberReferenceExpression.ReplaceWith(pointerReferenceExpression);
			}
			return result;
		}

		public override bool VisitStackAllocExpression(StackAllocExpression stackAllocExpression, object data)
		{
			base.VisitStackAllocExpression(stackAllocExpression, data);
			return true;
		}
	}
}
