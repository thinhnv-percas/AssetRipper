using System;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public static class PatternExtensions
{
	public static Match Match(this INode pattern, INode other)
	{
		if (pattern == null)
		{
			throw new ArgumentNullException("pattern");
		}
		Match match = DecompTools.Decompiler.CSharp.Syntax.PatternMatching.Match.CreateNew();
		if (pattern.DoMatch(other, match))
		{
			return match;
		}
		return default(Match);
	}

	public static bool IsMatch(this INode pattern, INode other)
	{
		if (pattern == null)
		{
			throw new ArgumentNullException("pattern");
		}
		return pattern.DoMatch(other, DecompTools.Decompiler.CSharp.Syntax.PatternMatching.Match.CreateNew());
	}

	public static AstType ToType(this Pattern pattern)
	{
		return pattern;
	}

	public static Expression ToExpression(this Pattern pattern)
	{
		return pattern;
	}

	public static Statement ToStatement(this Pattern pattern)
	{
		return pattern;
	}

	public static Expression WithName(this Expression node, string patternGroupName)
	{
		return new NamedNode(patternGroupName, node);
	}

	public static Statement WithName(this Statement node, string patternGroupName)
	{
		return new NamedNode(patternGroupName, node);
	}
}
