using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class PropertyDeclaration : MemberDeclaration
{
	public static readonly Role<Accessor> GetterRole = new Role<Accessor>("Getter", Accessor.Null);

	public static readonly Role<Accessor> SetterRole = new Role<Accessor>("Setter", Accessor.Null);

	public AstNodeCollection<VariableDeclarator> Variables => GetChildrenByRole(VariableDeclarator.VariableDeclaratorRole);

	public Identifier Name
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

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public AstNodeCollection<AttributeBlock> ReturnTypeAttributes => GetChildrenByRole(AttributeBlock.ReturnTypeAttributeBlockRole);

	public AstType ReturnType
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

	public AstNodeCollection<InterfaceMemberSpecifier> ImplementsClause => GetChildrenByRole(InterfaceMemberSpecifier.InterfaceMemberSpecifierRole);

	public Accessor Getter
	{
		get
		{
			return GetChildByRole(GetterRole);
		}
		set
		{
			SetChildByRole(GetterRole, value);
		}
	}

	public Accessor Setter
	{
		get
		{
			return GetChildByRole(SetterRole);
		}
		set
		{
			SetChildByRole(SetterRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPropertyDeclaration(this, data);
	}
}
