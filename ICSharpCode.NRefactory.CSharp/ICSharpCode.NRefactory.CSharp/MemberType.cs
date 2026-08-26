using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class MemberType : AstType
{
	public static readonly Role<AstType> TargetRole = new Role<AstType>("Target", AstType.Null);

	private bool isDoubleColon;

	public bool IsDoubleColon
	{
		get
		{
			return isDoubleColon;
		}
		set
		{
			ThrowIfFrozen();
			isDoubleColon = value;
		}
	}

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

	public string MemberName
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
		}
	}

	public Identifier MemberNameToken
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

	public MemberType()
	{
	}

	public MemberType(AstType target, string memberName)
	{
		Target = target;
		MemberName = memberName;
	}

	public MemberType(AstType target, string memberName, IEnumerable<AstType> typeArguments)
	{
		Target = target;
		MemberName = memberName;
		foreach (AstType typeArgument in typeArguments)
		{
			AddChild(typeArgument, Roles.TypeArgument);
		}
	}

	public MemberType(AstType target, string memberName, params AstType[] typeArguments)
		: this(target, memberName, (IEnumerable<AstType>)typeArguments)
	{
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitMemberType(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitMemberType(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitMemberType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is MemberType memberType && IsDoubleColon == memberType.IsDoubleColon && AstNode.MatchString(MemberName, memberType.MemberName) && Target.DoMatch(memberType.Target, match))
		{
			return TypeArguments.DoMatch(memberType.TypeArguments, match);
		}
		return false;
	}

	public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider = null)
	{
		if (interningProvider == null)
		{
			interningProvider = InterningProvider.Dummy;
		}
		TypeOrNamespaceReference typeOrNamespaceReference = ((!IsDoubleColon) ? (Target.ToTypeReference(lookupMode, interningProvider) as TypeOrNamespaceReference) : ((!(Target is SimpleType simpleType)) ? null : interningProvider.Intern(new AliasNamespaceReference(interningProvider.Intern(simpleType.Identifier)))));
		if (typeOrNamespaceReference == null)
		{
			return SpecialType.UnknownType;
		}
		List<ITypeReference> list = new List<ITypeReference>();
		foreach (AstType typeArgument in TypeArguments)
		{
			list.Add(typeArgument.ToTypeReference(lookupMode, interningProvider));
		}
		string identifier = interningProvider.Intern(MemberName);
		return interningProvider.Intern(new MemberTypeOrNamespaceReference(typeOrNamespaceReference, identifier, interningProvider.InternList(list), lookupMode));
	}
}
