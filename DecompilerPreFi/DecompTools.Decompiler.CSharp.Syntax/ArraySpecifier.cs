using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ArraySpecifier : AstNode
{
	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

	public int Dimensions
	{
		get
		{
			return checked(1 + GetChildrenByRole(Roles.Comma).Count);
		}
		set
		{
			checked
			{
				int i;
				for (i = Dimensions; i > value; i--)
				{
					GetChildByRole(Roles.Comma).Remove();
				}
				for (; i < value; i++)
				{
					InsertChildBefore(GetChildByRole(Roles.Comma), new CSharpTokenNode(TextLocation.Empty, Roles.Comma), Roles.Comma);
				}
			}
		}
	}

	public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

	public ArraySpecifier()
	{
	}

	public ArraySpecifier(int dimensions)
	{
		Dimensions = dimensions;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitArraySpecifier(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitArraySpecifier(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitArraySpecifier(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ArraySpecifier arraySpecifier && Dimensions == arraySpecifier.Dimensions;
	}

	public override string ToString(CSharpFormattingOptions formattingOptions)
	{
		return "[" + new string(',', checked(Dimensions - 1)) + "]";
	}
}
