using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class CSharpModifierToken : CSharpTokenNode
{
	private Modifiers modifier;

	private static readonly Modifiers[] allModifiers = new Modifiers[19]
	{
		Modifiers.Public,
		Modifiers.Private,
		Modifiers.Protected,
		Modifiers.Internal,
		Modifiers.New,
		Modifiers.Unsafe,
		Modifiers.Abstract,
		Modifiers.Virtual,
		Modifiers.Sealed,
		Modifiers.Static,
		Modifiers.Override,
		Modifiers.Ref,
		Modifiers.Readonly,
		Modifiers.Volatile,
		Modifiers.Extern,
		Modifiers.Partial,
		Modifiers.Const,
		Modifiers.Async,
		Modifiers.Any
	};

	private static readonly Modifiers[] typeModifiers = new Modifiers[19]
	{
		Modifiers.Public,
		Modifiers.Private,
		Modifiers.Protected,
		Modifiers.Internal,
		Modifiers.New,
		Modifiers.Unsafe,
		Modifiers.Abstract,
		Modifiers.Virtual,
		Modifiers.Sealed,
		Modifiers.Static,
		Modifiers.Override,
		Modifiers.Readonly,
		Modifiers.Ref,
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

	public static IEnumerable<Modifiers> TypeModifiers => typeModifiers;

	public override string ToString(CSharpFormattingOptions formattingOptions)
	{
		return GetModifierName(Modifier);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is CSharpModifierToken cSharpModifierToken)
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
		return modifier switch
		{
			Modifiers.Private => "private", 
			Modifiers.Internal => "internal", 
			Modifiers.Protected => "protected", 
			Modifiers.Public => "public", 
			Modifiers.Abstract => "abstract", 
			Modifiers.Virtual => "virtual", 
			Modifiers.Sealed => "sealed", 
			Modifiers.Static => "static", 
			Modifiers.Override => "override", 
			Modifiers.Ref => "ref", 
			Modifiers.Readonly => "readonly", 
			Modifiers.Const => "const", 
			Modifiers.New => "new", 
			Modifiers.Partial => "partial", 
			Modifiers.Extern => "extern", 
			Modifiers.Volatile => "volatile", 
			Modifiers.Unsafe => "unsafe", 
			Modifiers.Async => "async", 
			Modifiers.Any => "any", 
			_ => throw new NotSupportedException("Invalid value for Modifiers"), 
		};
	}

	public static int GetModifierLength(Modifiers modifier)
	{
		return modifier switch
		{
			Modifiers.Private => "private".Length, 
			Modifiers.Internal => "internal".Length, 
			Modifiers.Protected => "protected".Length, 
			Modifiers.Public => "public".Length, 
			Modifiers.Abstract => "abstract".Length, 
			Modifiers.Virtual => "virtual".Length, 
			Modifiers.Sealed => "sealed".Length, 
			Modifiers.Static => "static".Length, 
			Modifiers.Override => "override".Length, 
			Modifiers.Ref => "ref".Length, 
			Modifiers.Readonly => "readonly".Length, 
			Modifiers.Const => "const".Length, 
			Modifiers.New => "new".Length, 
			Modifiers.Partial => "partial".Length, 
			Modifiers.Extern => "extern".Length, 
			Modifiers.Volatile => "volatile".Length, 
			Modifiers.Unsafe => "unsafe".Length, 
			Modifiers.Async => "async".Length, 
			Modifiers.Any => "any".Length, 
			_ => throw new NotSupportedException("Invalid value for Modifiers"), 
		};
	}

	public static Modifiers GetModifierValue(string modifier)
	{
		return modifier switch
		{
			"private" => Modifiers.Private, 
			"internal" => Modifiers.Internal, 
			"protected" => Modifiers.Protected, 
			"public" => Modifiers.Public, 
			"abstract" => Modifiers.Abstract, 
			"virtual" => Modifiers.Virtual, 
			"sealed" => Modifiers.Sealed, 
			"static" => Modifiers.Static, 
			"override" => Modifiers.Override, 
			"ref" => Modifiers.Ref, 
			"readonly" => Modifiers.Readonly, 
			"const" => Modifiers.Const, 
			"new" => Modifiers.New, 
			"partial" => Modifiers.Partial, 
			"extern" => Modifiers.Extern, 
			"volatile" => Modifiers.Volatile, 
			"unsafe" => Modifiers.Unsafe, 
			"async" => Modifiers.Async, 
			"any" => Modifiers.Any, 
			_ => throw new NotSupportedException("Invalid value for Modifiers"), 
		};
	}
}
