using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ArrayCreateExpression : Expression
{
	public static readonly Role<ArraySpecifier> AdditionalArraySpecifierRole = new Role<ArraySpecifier>("AdditionalArraySpecifier");

	public static readonly Role<ArrayInitializerExpression> InitializerRole = new Role<ArrayInitializerExpression>("Initializer", ArrayInitializerExpression.Null);

	public AstType Type
	{
		get
		{
			return GetChildByRole(Roles.Type);
		}
		set
		{
			SetChildByRole(Roles.Type, value);
		}
	}

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

	public AstNodeCollection<ArraySpecifier> AdditionalArraySpecifiers => GetChildrenByRole(AdditionalArraySpecifierRole);

	public ArrayInitializerExpression Initializer
	{
		get
		{
			return GetChildByRole(InitializerRole);
		}
		set
		{
			SetChildByRole(InitializerRole, value);
		}
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitArrayCreateExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ArrayCreateExpression arrayCreateExpression && Type.DoMatch(arrayCreateExpression.Type, match) && Arguments.DoMatch(arrayCreateExpression.Arguments, match) && AdditionalArraySpecifiers.DoMatch(arrayCreateExpression.AdditionalArraySpecifiers, match))
		{
			return Initializer.DoMatch(arrayCreateExpression.Initializer, match);
		}
		return false;
	}
}
