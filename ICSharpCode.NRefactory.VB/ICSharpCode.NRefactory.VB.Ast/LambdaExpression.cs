using System.Linq;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class LambdaExpression : Expression
{
	public static readonly Role<VBModifierToken> ModifierRole = AttributedNode.ModifierRole;

	public LambdaExpressionModifiers Modifiers
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

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	internal static LambdaExpressionModifiers GetModifiers(AstNode node)
	{
		LambdaExpressionModifiers lambdaExpressionModifiers = (LambdaExpressionModifiers)0;
		foreach (VBModifierToken item in node.GetChildrenByRole(ModifierRole))
		{
			lambdaExpressionModifiers = (LambdaExpressionModifiers)((int)lambdaExpressionModifiers | (int)item.Modifier);
		}
		return lambdaExpressionModifiers;
	}

	internal static void SetModifiers(AstNode node, LambdaExpressionModifiers newValue)
	{
		LambdaExpressionModifiers modifiers = GetModifiers(node);
		AstNode astNode = null;
		foreach (Modifiers m in VBModifierToken.AllModifiers)
		{
			if (((uint)m & (uint)newValue) != 0)
			{
				if (((uint)m & (uint)modifiers) == 0)
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
			else if (((uint)m & (uint)modifiers) != 0)
			{
				node.GetChildrenByRole(ModifierRole).First((VBModifierToken t) => t.Modifier == m).Remove();
			}
		}
	}
}
