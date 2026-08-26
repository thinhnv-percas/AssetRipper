using System;
using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class NamespaceDeclaration : AstNode
{
	public static readonly Role<AstNode> MemberRole = SyntaxTree.MemberRole;

	public static readonly Role<AstType> NamespaceNameRole = new Role<AstType>("NamespaceName", AstType.Null);

	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode NamespaceToken => GetChildByRole(Roles.NamespaceKeyword);

	public AstType NamespaceName
	{
		get
		{
			return GetChildByRole(NamespaceNameRole) ?? AstType.Null;
		}
		set
		{
			SetChildByRole(NamespaceNameRole, value);
		}
	}

	public string Name
	{
		get
		{
			return UsingDeclaration.ConstructNamespace(NamespaceName);
		}
		set
		{
			string[] array = value.Split(new char[1] { '.' });
			NamespaceName = ConstructType(array, checked(array.Length - 1));
		}
	}

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

	public IEnumerable<string> Identifiers
	{
		get
		{
			Stack<string> val = new Stack<string>();
			AstType astType = NamespaceName;
			while (astType is MemberType)
			{
				MemberType memberType = (MemberType)astType;
				val.Push(memberType.MemberName);
				astType = memberType.Target;
			}
			if (astType is SimpleType)
			{
				val.Push(((SimpleType)astType).Identifier);
			}
			return (IEnumerable<string>)val;
		}
	}

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public AstNodeCollection<AstNode> Members => GetChildrenByRole(MemberRole);

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	private static AstType ConstructType(string[] arr, int i)
	{
		if (i < 0 || i >= arr.Length)
		{
			throw new ArgumentOutOfRangeException("i");
		}
		if (i == 0)
		{
			return new SimpleType(arr[i]);
		}
		return new MemberType(ConstructType(arr, checked(i - 1)), arr[i]);
	}

	public NamespaceDeclaration()
	{
	}

	public NamespaceDeclaration(string name)
	{
		Name = name;
	}

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

	public void AddMember(AstNode child)
	{
		AddChild(child, MemberRole);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitNamespaceDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitNamespaceDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitNamespaceDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is NamespaceDeclaration namespaceDeclaration && AstNode.MatchString(Name, namespaceDeclaration.Name) && Members.DoMatch(namespaceDeclaration.Members, match);
	}
}
