using System.Linq;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ArraySpecifier : AstNode
{
	public VBTokenNode LParToken => GetChildByRole(Roles.LPar);

	public int Dimensions
	{
		get
		{
			return 1 + GetChildrenByRole(Roles.Comma).Count();
		}
		set
		{
			int i;
			for (i = Dimensions; i > value; i--)
			{
				GetChildByRole(Roles.Comma).Remove();
			}
			for (; i < value; i++)
			{
				InsertChildBefore(GetChildByRole(Roles.Comma), new VBTokenNode(TextLocation.Empty, 1), Roles.Comma);
			}
		}
	}

	public VBTokenNode RParToken => GetChildByRole(Roles.LPar);

	public ArraySpecifier()
	{
	}

	public ArraySpecifier(int dimensions)
	{
		Dimensions = dimensions;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitArraySpecifier(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ArraySpecifier arraySpecifier)
		{
			return Dimensions == arraySpecifier.Dimensions;
		}
		return false;
	}

	public override string ToString()
	{
		return "(" + new string(',', Dimensions - 1) + ")";
	}
}
