using System.Linq;
using System.Text;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class NamespaceDeclaration : AstNode
{
	public static readonly Role<AstNode> MemberRole = CompilationUnit.MemberRole;

	public string Name
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Identifier item in GetChildrenByRole(Roles.Identifier))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('.');
				}
				stringBuilder.Append(item.Name);
			}
			return stringBuilder.ToString();
		}
		set
		{
			GetChildrenByRole(Roles.Identifier).ReplaceWith(from ident in value.Split('.')
				select new Identifier(BoxedTextColor.Namespace, ident, TextLocation.Empty));
		}
	}

	public AstNodeCollection<Identifier> Identifiers => GetChildrenByRole(Roles.Identifier);

	public string FullName
	{
		get
		{
			if (base.Parent is NamespaceDeclaration namespaceDeclaration)
			{
				return BuildQualifiedName(namespaceDeclaration.FullName, Name);
			}
			return Name;
		}
	}

	public AstNodeCollection<AstNode> Members => GetChildrenByRole(MemberRole);

	public static string BuildQualifiedName(string name1, string name2)
	{
		if (string.IsNullOrEmpty(name1))
		{
			return name2;
		}
		if (string.IsNullOrEmpty(name2))
		{
			return name1;
		}
		return name1 + "." + name2;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitNamespaceDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is NamespaceDeclaration namespaceDeclaration && AstNode.MatchString(Name, namespaceDeclaration.Name))
		{
			return Members.DoMatch(namespaceDeclaration.Members, match);
		}
		return false;
	}
}
