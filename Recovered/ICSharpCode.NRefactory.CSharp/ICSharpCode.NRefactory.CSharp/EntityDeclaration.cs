using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public abstract class EntityDeclaration : AstNode
	{
		public static readonly Role<AttributeSection> AttributeRole = new Role<AttributeSection>("Attribute");

		public static readonly Role<AttributeSection> UnattachedAttributeRole = new Role<AttributeSection>("UnattachedAttribute");

		public static readonly Role<CSharpModifierToken> ModifierRole = new Role<CSharpModifierToken>("Modifier");

		public static readonly Role<AstType> PrivateImplementationTypeRole = new Role<AstType>("PrivateImplementationType", AstType.Null);

		public override NodeType NodeType => NodeType.Member;

		public abstract SymbolKind SymbolKind
		{
			get;
		}

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
			AstNode prevSibling = node.GetChildrenByRole(AttributeRole).LastOrDefault();
			foreach (Modifiers i in CSharpModifierToken.AllModifiers)
			{
				if ((i & newValue) != 0)
				{
					if ((i & modifiers) == Modifiers.None)
					{
						CSharpModifierToken cSharpModifierToken = new CSharpModifierToken(TextLocation.Empty, i);
						node.InsertChildAfter(prevSibling, cSharpModifierToken, ModifierRole);
						prevSibling = cSharpModifierToken;
					}
					else
					{
						prevSibling = node.GetChildrenByRole(ModifierRole).First((CSharpModifierToken t) => t.Modifier == i);
					}
				}
				else if ((i & modifiers) != 0)
				{
					node.GetChildrenByRole(ModifierRole).First((CSharpModifierToken t) => t.Modifier == i).Remove();
				}
			}
		}

		protected bool MatchAttributesAndModifiers(EntityDeclaration o, Match match)
		{
			if (Modifiers == Modifiers.Any || Modifiers == o.Modifiers)
			{
				return Attributes.DoMatch(o.Attributes, match);
			}
			return false;
		}
	}
}
