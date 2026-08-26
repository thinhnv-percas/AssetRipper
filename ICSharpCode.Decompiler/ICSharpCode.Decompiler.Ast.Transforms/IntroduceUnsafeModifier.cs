using System.Linq;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class IntroduceUnsafeModifier : DepthFirstAstVisitor<object, bool>, IAstTransformPoolObject, IAstTransform
{
	private sealed class PointerArithmetic
	{
	}

	public static readonly object PointerArithmeticAnnotation = new PointerArithmetic();

	public void Run(AstNode compilationUnit)
	{
		compilationUnit.AcceptVisitor(this, null);
	}

	public void Reset(DecompilerContext context)
	{
	}

	protected override bool VisitChildren(AstNode node, object data)
	{
		bool flag = false;
		AstNode astNode = node.FirstChild;
		while (astNode != null)
		{
			AstNode nextSibling = astNode.NextSibling;
			flag |= astNode.AcceptVisitor(this, data);
			astNode = nextSibling;
		}
		if (flag && node is EntityDeclaration && !(node is Accessor))
		{
			EntityDeclaration entityDeclaration = (EntityDeclaration)node;
			entityDeclaration.Modifiers |= Modifiers.Unsafe;
			Comment[] array = entityDeclaration.GetChildrenByRole(Roles.Comment).Reverse().ToArray();
			Comment[] array2 = array;
			foreach (Comment comment in array2)
			{
				comment.Remove();
				entityDeclaration.InsertChildAfter(null, comment, Roles.Comment);
			}
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
			if (unaryOperatorExpression.Expression is BinaryOperatorExpression { Operator: BinaryOperatorType.Add } binaryOperatorExpression && binaryOperatorExpression.Annotation<PointerArithmetic>() != null)
			{
				IndexerExpression indexerExpression = new IndexerExpression();
				indexerExpression.Target = binaryOperatorExpression.Left.Detach();
				indexerExpression.Arguments.Add(binaryOperatorExpression.Right.Detach());
				indexerExpression.CopyAnnotationsFrom(unaryOperatorExpression);
				indexerExpression.CopyAnnotationsFrom(binaryOperatorExpression);
				indexerExpression.AddAnnotation(unaryOperatorExpression.GetAllRecursiveILSpans());
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
		if (memberReferenceExpression.Target is UnaryOperatorExpression { Operator: UnaryOperatorType.Dereference } unaryOperatorExpression)
		{
			PointerReferenceExpression pointerReferenceExpression = new PointerReferenceExpression();
			pointerReferenceExpression.Target = unaryOperatorExpression.Expression.Detach();
			pointerReferenceExpression.MemberNameToken = (Identifier)memberReferenceExpression.MemberNameToken.Clone();
			memberReferenceExpression.TypeArguments.MoveTo(pointerReferenceExpression.TypeArguments);
			pointerReferenceExpression.CopyAnnotationsFrom(unaryOperatorExpression);
			pointerReferenceExpression.CopyAnnotationsFrom(memberReferenceExpression);
			pointerReferenceExpression.AddAnnotation(memberReferenceExpression.GetAllRecursiveILSpans());
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
