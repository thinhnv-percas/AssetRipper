using System.Collections.Generic;
using System.Text;
using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class NamespaceDeclaration : AstNode
{
	public static readonly Role<AstNode> MemberRole = SyntaxTree.MemberRole;

	public static readonly Role<AstType> NamespaceNameRole = new Role<AstType>("NamespaceName", AstType.Null);

	private static StringBuilder cachedStringBuilder = new StringBuilder();

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
			NamespaceName = CreateNamespaceNameType(value, new AssemblyRefUser());
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
			Stack<string> stack = new Stack<string>();
			AstType astType = NamespaceName;
			while (astType is MemberType)
			{
				MemberType memberType = (MemberType)astType;
				stack.Push(memberType.MemberName);
				astType = memberType.Target;
			}
			if (astType is SimpleType)
			{
				stack.Push(((SimpleType)astType).Identifier);
			}
			return stack;
		}
	}

	public IEnumerable<Identifier> IdentifierTypes
	{
		get
		{
			Stack<Identifier> stack = new Stack<Identifier>();
			AstType astType = NamespaceName;
			while (astType is MemberType)
			{
				MemberType memberType = (MemberType)astType;
				stack.Push(memberType.MemberNameToken);
				astType = memberType.Target;
			}
			if (astType is SimpleType)
			{
				stack.Push(((SimpleType)astType).IdentifierToken);
			}
			return stack;
		}
	}

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public AstNodeCollection<AstNode> Members => GetChildrenByRole(MemberRole);

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	private static AstType CreateNamespaceNameType(string ns, IAssembly asm)
	{
		StringBuilder stringBuilder = Interlocked.CompareExchange(ref cachedStringBuilder, null, cachedStringBuilder) ?? new StringBuilder();
		string[] array = ns.Split('.');
		stringBuilder.Clear();
		stringBuilder.Append(array[0]);
		SimpleType simpleType;
		AstType astType = (simpleType = new SimpleType(array[0]).WithAnnotation(BoxedTextColor.Namespace));
		simpleType.IdentifierToken.WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(asm, array[0]));
		for (int i = 1; i < array.Length; i++)
		{
			stringBuilder.Append('.');
			stringBuilder.Append(array[i]);
			string text = stringBuilder.ToString();
			astType = new MemberType
			{
				Target = astType,
				MemberNameToken = Identifier.Create(array[i]).WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(asm, text))
			}.WithAnnotation(BoxedTextColor.Namespace);
		}
		if (stringBuilder.Capacity <= 1000)
		{
			cachedStringBuilder = stringBuilder;
		}
		return astType;
	}

	public NamespaceDeclaration()
	{
	}

	public NamespaceDeclaration(string name)
	{
		Name = name;
	}

	public NamespaceDeclaration(string name, IAssembly asm)
	{
		NamespaceName = CreateNamespaceNameType(name, asm);
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
		if (other is NamespaceDeclaration namespaceDeclaration && AstNode.MatchString(Name, namespaceDeclaration.Name))
		{
			return Members.DoMatch(namespaceDeclaration.Members, match);
		}
		return false;
	}
}
