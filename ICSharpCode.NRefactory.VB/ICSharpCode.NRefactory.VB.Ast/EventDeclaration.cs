using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class EventDeclaration : MemberDeclaration
{
	public static readonly Role<Accessor> AddHandlerRole = new Role<Accessor>("AddHandler", Accessor.Null);

	public static readonly Role<Accessor> RemoveHandlerRole = new Role<Accessor>("RemoveHandler", Accessor.Null);

	public static readonly Role<Accessor> RaiseEventRole = new Role<Accessor>("RaiseEvent", Accessor.Null);

	public bool IsCustom { get; set; }

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

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public AstNodeCollection<InterfaceMemberSpecifier> ImplementsClause => GetChildrenByRole(InterfaceMemberSpecifier.InterfaceMemberSpecifierRole);

	public Accessor AddHandlerBlock
	{
		get
		{
			return GetChildByRole(AddHandlerRole);
		}
		set
		{
			SetChildByRole(AddHandlerRole, value);
		}
	}

	public Accessor RemoveHandlerBlock
	{
		get
		{
			return GetChildByRole(RemoveHandlerRole);
		}
		set
		{
			SetChildByRole(RemoveHandlerRole, value);
		}
	}

	public Accessor RaiseEventBlock
	{
		get
		{
			return GetChildByRole(RaiseEventRole);
		}
		set
		{
			SetChildByRole(RaiseEventRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEventDeclaration(this, data);
	}
}
