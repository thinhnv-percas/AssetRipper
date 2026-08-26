using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class SimpleType : AstType
{
	private sealed class NullSimpleType : SimpleType
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}

		public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider)
		{
			return SpecialType.UnknownType;
		}
	}

	public new static readonly SimpleType Null = new NullSimpleType();

	public string Identifier
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, DecompTools.Decompiler.CSharp.Syntax.Identifier.Create(value));
		}
	}

	public Identifier IdentifierToken
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

	public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

	public SimpleType()
	{
	}

	public SimpleType(string identifier)
	{
		Identifier = identifier;
	}

	public SimpleType(Identifier identifier)
	{
		IdentifierToken = identifier;
	}

	public SimpleType(string identifier, TextLocation location)
	{
		SetChildByRole(Roles.Identifier, DecompTools.Decompiler.CSharp.Syntax.Identifier.Create(identifier, location));
	}

	public SimpleType(string identifier, IEnumerable<AstType> typeArguments)
	{
		Identifier = identifier;
		foreach (AstType typeArgument in typeArguments)
		{
			AddChild(typeArgument, Roles.TypeArgument);
		}
	}

	public SimpleType(string identifier, params AstType[] typeArguments)
		: this(identifier, (IEnumerable<AstType>)typeArguments)
	{
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitSimpleType(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitSimpleType(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSimpleType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is SimpleType simpleType && AstNode.MatchString(Identifier, simpleType.Identifier) && TypeArguments.DoMatch(simpleType.TypeArguments, match);
	}

	public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider = null)
	{
		if (interningProvider == null)
		{
			interningProvider = InterningProvider.Dummy;
		}
		List<ITypeReference> list = new List<ITypeReference>();
		foreach (AstType typeArgument in TypeArguments)
		{
			list.Add(typeArgument.ToTypeReference(lookupMode, interningProvider));
		}
		string text = interningProvider.Intern(Identifier);
		if (list.Count == 0 && string.IsNullOrEmpty(text))
		{
			return SpecialType.UnboundTypeArgument;
		}
		SimpleTypeOrNamespaceReference obj = new SimpleTypeOrNamespaceReference(text, interningProvider.InternList(list), lookupMode);
		return interningProvider.Intern(obj);
	}
}
