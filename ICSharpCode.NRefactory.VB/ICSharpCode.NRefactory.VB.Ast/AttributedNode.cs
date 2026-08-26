using System.Linq;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class AttributedNode : AstNode
{
	public static readonly Role<VBModifierToken> ModifierRole = new Role<VBModifierToken>("Modifier");

	public AstNodeCollection<AttributeBlock> Attributes => GetChildrenByRole(AttributeBlock.AttributeBlockRole);

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

	public AstNodeCollection<VBModifierToken> ModifierTokens => GetChildrenByRole(ModifierRole);

	internal static Modifiers GetModifiers(AstNode node)
	{
		Modifiers modifiers = Modifiers.None;
		foreach (VBModifierToken item in node.GetChildrenByRole(ModifierRole))
		{
			modifiers |= item.Modifier;
		}
		return modifiers;
	}

	internal static void SetModifiers(AstNode node, Modifiers newValue)
	{
		Modifiers modifiers = GetModifiers(node);
		AstNode astNode = node.GetChildrenByRole(Attribute.AttributeRole).LastOrDefault();
		foreach (Modifiers m in VBModifierToken.AllModifiers)
		{
			if ((m & newValue) != Modifiers.None)
			{
				if ((m & modifiers) == 0)
				{
					VBModifierToken vBModifierToken = new VBModifierToken(TextLocation.Empty, m);
					node.InsertChildAfter(astNode, vBModifierToken, ModifierRole);
					astNode = vBModifierToken;
				}
				else
				{
					astNode = node.GetChildrenByRole(ModifierRole).First((VBModifierToken t) => t.Modifier == m);
				}
			}
			else if ((m & modifiers) != Modifiers.None)
			{
				node.GetChildrenByRole(ModifierRole).First((VBModifierToken t) => t.Modifier == m).Remove();
			}
		}
	}

	protected bool MatchAttributesAndModifiers(AttributedNode o, Match match)
	{
		if (Modifiers == Modifiers.Any || Modifiers == o.Modifiers)
		{
			return Attributes.DoMatch(o.Attributes, match);
		}
		return false;
	}
}
