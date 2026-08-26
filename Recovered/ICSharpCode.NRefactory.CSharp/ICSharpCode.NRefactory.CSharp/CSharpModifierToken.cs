using ICSharpCode.NRefactory.PatternMatching;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CSharpModifierToken : CSharpTokenNode
	{
		private Modifiers modifier;

		private static readonly Modifiers[] allModifiers = new Modifiers[18]
		{
			Modifiers.Public,
			Modifiers.Protected,
			Modifiers.Private,
			Modifiers.Internal,
			Modifiers.New,
			Modifiers.Unsafe,
			Modifiers.Abstract,
			Modifiers.Virtual,
			Modifiers.Sealed,
			Modifiers.Static,
			Modifiers.Override,
			Modifiers.Readonly,
			Modifiers.Volatile,
			Modifiers.Extern,
			Modifiers.Partial,
			Modifiers.Const,
			Modifiers.Async,
			Modifiers.Any
		};

		public Modifiers Modifier
		{
			get
			{
				return modifier;
			}
			set
			{
				ThrowIfFrozen();
				modifier = value;
			}
		}

		public override TextLocation EndLocation => new TextLocation(StartLocation.Line, StartLocation.Column + GetModifierLength(Modifier));

		public static IEnumerable<Modifiers> AllModifiers => allModifiers;

		public override string ToString(CSharpFormattingOptions formattingOptions)
		{
			return GetModifierName(Modifier);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			CSharpModifierToken cSharpModifierToken = other as CSharpModifierToken;
			if (cSharpModifierToken != null)
			{
				return modifier == cSharpModifierToken.modifier;
			}
			return false;
		}

		public CSharpModifierToken(TextLocation location, Modifiers modifier)
			: base(location, null)
		{
			Modifier = modifier;
		}

		public static string GetModifierName(Modifiers modifier)
		{
			switch (modifier)
			{
			case Modifiers.Private:
				return "private";
			case Modifiers.Internal:
				return "internal";
			case Modifiers.Protected:
				return "protected";
			case Modifiers.Public:
				return "public";
			case Modifiers.Abstract:
				return "abstract";
			case Modifiers.Virtual:
				return "virtual";
			case Modifiers.Sealed:
				return "sealed";
			case Modifiers.Static:
				return "static";
			case Modifiers.Override:
				return "override";
			case Modifiers.Readonly:
				return "readonly";
			case Modifiers.Const:
				return "const";
			case Modifiers.New:
				return "new";
			case Modifiers.Partial:
				return "partial";
			case Modifiers.Extern:
				return "extern";
			case Modifiers.Volatile:
				return "volatile";
			case Modifiers.Unsafe:
				return "unsafe";
			case Modifiers.Async:
				return "async";
			case Modifiers.Any:
				return "any";
			default:
				throw new NotSupportedException("Invalid value for Modifiers");
			}
		}

		public static int GetModifierLength(Modifiers modifier)
		{
			switch (modifier)
			{
			case Modifiers.Private:
				return "private".Length;
			case Modifiers.Internal:
				return "internal".Length;
			case Modifiers.Protected:
				return "protected".Length;
			case Modifiers.Public:
				return "public".Length;
			case Modifiers.Abstract:
				return "abstract".Length;
			case Modifiers.Virtual:
				return "virtual".Length;
			case Modifiers.Sealed:
				return "sealed".Length;
			case Modifiers.Static:
				return "static".Length;
			case Modifiers.Override:
				return "override".Length;
			case Modifiers.Readonly:
				return "readonly".Length;
			case Modifiers.Const:
				return "const".Length;
			case Modifiers.New:
				return "new".Length;
			case Modifiers.Partial:
				return "partial".Length;
			case Modifiers.Extern:
				return "extern".Length;
			case Modifiers.Volatile:
				return "volatile".Length;
			case Modifiers.Unsafe:
				return "unsafe".Length;
			case Modifiers.Async:
				return "async".Length;
			case Modifiers.Any:
				return "any".Length;
			default:
				throw new NotSupportedException("Invalid value for Modifiers");
			}
		}

		public static Modifiers GetModifierValue(string modifier)
		{
			switch (modifier)
			{
			case "private":
				return Modifiers.Private;
			case "internal":
				return Modifiers.Internal;
			case "protected":
				return Modifiers.Protected;
			case "public":
				return Modifiers.Public;
			case "abstract":
				return Modifiers.Abstract;
			case "virtual":
				return Modifiers.Virtual;
			case "sealed":
				return Modifiers.Sealed;
			case "static":
				return Modifiers.Static;
			case "override":
				return Modifiers.Override;
			case "readonly":
				return Modifiers.Readonly;
			case "const":
				return Modifiers.Const;
			case "new":
				return Modifiers.New;
			case "partial":
				return Modifiers.Partial;
			case "extern":
				return Modifiers.Extern;
			case "volatile":
				return Modifiers.Volatile;
			case "unsafe":
				return Modifiers.Unsafe;
			case "async":
				return Modifiers.Async;
			case "any":
				return Modifiers.Any;
			default:
				throw new NotSupportedException("Invalid value for Modifiers");
			}
		}
	}
}
