using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public abstract class EntityDeclaration : AstNode
{
	public static readonly Role<AttributeSection> AttributeRole = new Role<AttributeSection>("Attribute");

	public static readonly Role<AttributeSection> UnattachedAttributeRole = new Role<AttributeSection>("UnattachedAttribute");

	public static readonly Role<CSharpModifierToken> ModifierRole = new Role<CSharpModifierToken>("Modifier");

	public static readonly Role<AstType> PrivateImplementationTypeRole = new Role<AstType>("PrivateImplementationType", AstType.Null);

	public override NodeType NodeType => NodeType.Member;

	public abstract SymbolKind SymbolKind { get; }

	public AstNodeCollection<AttributeSection> Attributes => GetChildrenByRole(AttributeRole);

	public Modifiers Modifiers
	{
		get
		{
			return GetModifiers(this);
		}
		set
		{
			SetModifiers(this, value);
		}
	}

	public IEnumerable<CSharpModifierToken> ModifierTokens => GetChildrenByRole(ModifierRole);

	public virtual string Name
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value, TextLocation.Empty));
		}
	}

	public virtual Identifier NameToken
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

	public virtual AstType ReturnType
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

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public bool HasModifier(Modifiers mod)
	{
		return (Modifiers & mod) == mod;
	}

	internal static Modifiers GetModifiers(AstNode node)
	{
		Modifiers modifiers = Modifiers.None;
		foreach (CSharpModifierToken item in node.GetChildrenByRole(ModifierRole))
		{
			modifiers |= item.Modifier;
		}
		return modifiers;
	}

	internal static void SetModifiers(AstNode node, Modifiers newValue)
	{
		Modifiers modifiers = GetModifiers(node);
		AstNode astNode = Enumerable.LastOrDefault<AttributeSection>((IEnumerable<AttributeSection>)node.GetChildrenByRole(AttributeRole));
		foreach (Modifiers m in CSharpModifierToken.AllModifiers)
		{
			if ((m & newValue) != Modifiers.None)
			{
				if ((m & modifiers) == 0)
				{
					CSharpModifierToken cSharpModifierToken = new CSharpModifierToken(TextLocation.Empty, m);
					node.InsertChildAfter(astNode, cSharpModifierToken, ModifierRole);
					astNode = cSharpModifierToken;
				}
				else
				{
					astNode = Enumerable.First<CSharpModifierToken>((IEnumerable<CSharpModifierToken>)node.GetChildrenByRole(ModifierRole), (Func<CSharpModifierToken, bool>)((CSharpModifierToken t) => t.Modifier == m));
				}
			}
			else if ((m & modifiers) != Modifiers.None)
			{
				Enumerable.First<CSharpModifierToken>((IEnumerable<CSharpModifierToken>)node.GetChildrenByRole(ModifierRole), (Func<CSharpModifierToken, bool>)((CSharpModifierToken t) => t.Modifier == m)).Remove();
			}
		}
	}

	protected bool MatchAttributesAndModifiers(EntityDeclaration o, Match match)
	{
		return (Modifiers == Modifiers.Any || Modifiers == o.Modifiers) && Attributes.DoMatch(o.Attributes, match);
	}
}
