using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class EscapeInvalidIdentifiers : IAstTransform
{
	private bool IsValid(char ch)
	{
		if (char.IsLetterOrDigit(ch))
		{
			return true;
		}
		if (ch == '_')
		{
			return true;
		}
		return false;
	}

	private string ReplaceInvalid(string s)
	{
		string text = string.Concat(Enumerable.Select<char, string>((IEnumerable<char>)s, (Func<char, string>)((char ch) => IsValid(ch) ? ch.ToString() : $"_{(int)ch:X4}")));
		if (text.Length >= 1 && !char.IsLetter(text[0]) && text[0] != '_')
		{
			text = "_" + text;
		}
		return text;
	}

	public void Run(AstNode rootNode, TransformContext context)
	{
		foreach (Identifier item in Enumerable.OfType<Identifier>((IEnumerable)rootNode.DescendantsAndSelf))
		{
			item.Name = ReplaceInvalid(item.Name);
		}
	}
}
