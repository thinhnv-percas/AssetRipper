using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class InterfaceMemberSpecifier : AstNode
{
	public static readonly Role<InterfaceMemberSpecifier> InterfaceMemberSpecifierRole = new Role<InterfaceMemberSpecifier>("InterfaceMemberSpecifier");

	public Expression Target
	{
		get
		{
			return GetChildByRole(Roles.Expression);
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public Identifier Member
	{
		get
		{
			return GetChildByRole(Roles.Identifier);
		}
		set
		{
			SetChildByRole(Roles.Identifier, value);
		}
	}

	public static InterfaceMemberSpecifier CreateWithColor(AstType target, string member, object data)
	{
		return new InterfaceMemberSpecifier(target, member, data);
	}

	public static InterfaceMemberSpecifier CreateWithData(AstType target, string member, object data)
	{
		return new InterfaceMemberSpecifier(target, member, data);
	}

	public InterfaceMemberSpecifier(Expression target, Identifier member)
	{
		Target = target;
		Member = member;
	}

	private InterfaceMemberSpecifier(AstType target, string member, object data)
	{
		Target = new TypeReferenceExpression(target);
		Member = new Identifier(data, member, TextLocation.Empty);
	}

	public InterfaceMemberSpecifier(AstType target, string member, IEnumerable<object> annotations)
	{
		Target = new TypeReferenceExpression(target);
		Member = Identifier.Create(annotations, member);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is InterfaceMemberSpecifier interfaceMemberSpecifier && Target.DoMatch(interfaceMemberSpecifier.Target, match))
		{
			return Member.DoMatch(interfaceMemberSpecifier.Member, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitInterfaceMemberSpecifier(this, data);
	}
}
