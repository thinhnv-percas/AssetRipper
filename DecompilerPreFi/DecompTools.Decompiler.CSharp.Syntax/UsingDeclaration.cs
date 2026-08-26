using System.Collections.Generic;
using System.Text;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class UsingDeclaration : AstNode
{
	public static readonly TokenRole UsingKeywordRole = new TokenRole("using");

	public static readonly Role<AstType> ImportRole = new Role<AstType>("Import", AstType.Null);

	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode UsingToken => GetChildByRole(UsingKeywordRole);

	public AstType Import
	{
		get
		{
			return GetChildByRole(ImportRole);
		}
		set
		{
			SetChildByRole(ImportRole, value);
		}
	}

	public string Namespace => ConstructNamespace(Import);

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	internal static string ConstructNamespace(AstType type)
	{
		Stack<string> val = new Stack<string>();
		while (type is MemberType)
		{
			MemberType memberType = (MemberType)type;
			val.Push(memberType.MemberName);
			type = memberType.Target;
			if (memberType.IsDoubleColon)
			{
				val.Push("::");
			}
			else
			{
				val.Push(".");
			}
		}
		if (type is SimpleType)
		{
			val.Push(((SimpleType)type).Identifier);
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (val.Count > 0)
		{
			stringBuilder.Append(val.Pop());
		}
		return stringBuilder.ToString();
	}

	public UsingDeclaration()
	{
	}

	public UsingDeclaration(string nameSpace)
	{
		AddChild(AstType.Create(nameSpace), ImportRole);
	}

	public UsingDeclaration(AstType import)
	{
		AddChild(import, ImportRole);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitUsingDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitUsingDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUsingDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is UsingDeclaration usingDeclaration && Import.DoMatch(usingDeclaration.Import, match);
	}
}
