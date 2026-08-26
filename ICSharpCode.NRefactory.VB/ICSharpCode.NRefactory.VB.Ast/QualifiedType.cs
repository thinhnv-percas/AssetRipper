using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class QualifiedType : AstType
{
	public static readonly Role<AstType> TargetRole = new Role<AstType>("Target", AstType.Null);

	public AstType Target
	{
		get
		{
			return GetChildByRole(TargetRole);
		}
		set
		{
			SetChildByRole(TargetRole, value);
		}
	}

	public string Name => GetChildByRole(Roles.Identifier).Name;

	public Identifier NameToken => GetChildByRole(Roles.Identifier);

	public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

	public QualifiedType(AstType target, Identifier name)
	{
		Target = target;
		SetChildByRole(Roles.Identifier, name);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQualifiedType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is QualifiedType qualifiedType && AstNode.MatchString(Name, qualifiedType.Name))
		{
			return Target.DoMatch(qualifiedType.Target, match);
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(Target);
		stringBuilder.Append('.');
		stringBuilder.Append(Name);
		if (TypeArguments.Any())
		{
			stringBuilder.Append('(');
			stringBuilder.Append(string.Join(", ", TypeArguments));
			stringBuilder.Append(')');
		}
		return stringBuilder.ToString();
	}
}
