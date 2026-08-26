using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class VBModifierToken : VBTokenNode
{
	private Modifiers modifier;

	private static readonly List<KeyValuePair<Modifiers, int>> lengthTable = new List<KeyValuePair<Modifiers, int>>
	{
		new KeyValuePair<Modifiers, int>(Modifiers.Public, "Public".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Protected, "Protected".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Private, "Private".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Friend, "Friend".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.MustInherit, "MustInherit".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.MustOverride, "MustOverride".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Overridable, "Overridable".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.NotInheritable, "NotInheritable".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.NotOverridable, "NotOverridable".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Dim, "Dim".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Const, "Const".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Shared, "Shared".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Static, "Static".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Overrides, "Overrides".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.ReadOnly, "ReadOnly".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.WriteOnly, "WriteOnly".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Shadows, "Shadows".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Partial, "Partial".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Overloads, "Overloads".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.WithEvents, "WithEvents".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Default, "Default".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Optional, "Optional".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.ByVal, "ByVal".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.ByRef, "ByRef".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.ParamArray, "ParamArray".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Narrowing, "Narrowing".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Widening, "Widening".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Async, "Async".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Iterator, "Iterator".Length),
		new KeyValuePair<Modifiers, int>(Modifiers.Any, "Any".Length)
	};

	public Modifiers Modifier
	{
		get
		{
			return modifier;
		}
		set
		{
			for (int i = 0; i < lengthTable.Count; i++)
			{
				if (lengthTable[i].Key == value)
				{
					modifier = value;
					tokenLength = lengthTable[i].Value;
					return;
				}
			}
			throw new ArgumentException(string.Concat("Modifier ", value, " is invalid."));
		}
	}

	public static IEnumerable<Modifiers> AllModifiers => lengthTable.Select((KeyValuePair<Modifiers, int> p) => p.Key);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is VBModifierToken vBModifierToken)
		{
			return modifier == vBModifierToken.modifier;
		}
		return false;
	}

	public VBModifierToken(TextLocation location, Modifiers modifier)
		: base(location, 0)
	{
		Modifier = modifier;
	}

	public static string GetModifierName(Modifiers modifier)
	{
		return modifier switch
		{
			Modifiers.Private => "Private", 
			Modifiers.Friend => "Friend", 
			Modifiers.Protected => "Protected", 
			Modifiers.Public => "Public", 
			Modifiers.MustInherit => "MustInherit", 
			Modifiers.MustOverride => "MustOverride", 
			Modifiers.Overridable => "Overridable", 
			Modifiers.NotInheritable => "NotInheritable", 
			Modifiers.NotOverridable => "NotOverridable", 
			Modifiers.Const => "Const", 
			Modifiers.Shared => "Shared", 
			Modifiers.Static => "Static", 
			Modifiers.Overrides => "Overrides", 
			Modifiers.ReadOnly => "ReadOnly", 
			Modifiers.Shadows => "Shadows", 
			Modifiers.Partial => "Partial", 
			Modifiers.Overloads => "Overloads", 
			Modifiers.WithEvents => "WithEvents", 
			Modifiers.Default => "Default", 
			Modifiers.Dim => "Dim", 
			Modifiers.WriteOnly => "WriteOnly", 
			Modifiers.Optional => "Optional", 
			Modifiers.ByVal => "ByVal", 
			Modifiers.ByRef => "ByRef", 
			Modifiers.ParamArray => "ParamArray", 
			Modifiers.Widening => "Widening", 
			Modifiers.Narrowing => "Narrowing", 
			Modifiers.Async => "Async", 
			Modifiers.Iterator => "Iterator", 
			_ => throw new NotSupportedException("Invalid value for Modifiers: " + modifier), 
		};
	}
}
