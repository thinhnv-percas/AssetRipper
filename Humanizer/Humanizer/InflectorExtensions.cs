using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Humanizer.Inflections;

namespace Humanizer;

public static class InflectorExtensions
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static MatchEvaluator _003C_003E9__3_0;

		internal string _003CPascalize_003Eb__3_0(Match match)
		{
			return ((Capture)match.Groups[1]).Value.ToUpper();
		}
	}

	public static string Pluralize(this string word, bool inputIsKnownToBeSingular = true)
	{
		return Vocabularies.Default.Pluralize(word, inputIsKnownToBeSingular);
	}

	public static string Singularize(this string word, bool inputIsKnownToBePlural = true)
	{
		return Vocabularies.Default.Singularize(word, inputIsKnownToBePlural);
	}

	public static string Titleize(this string input)
	{
		return input.Humanize(LetterCasing.Title);
	}

	public static string Pascalize(this string input)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		object obj = _003C_003Ec._003C_003E9__3_0;
		if (obj == null)
		{
			MatchEvaluator val = (Match match) => ((Capture)match.Groups[1]).Value.ToUpper();
			_003C_003Ec._003C_003E9__3_0 = val;
			obj = (object)val;
		}
		return Regex.Replace(input, "(?:^|_)(.)", (MatchEvaluator)obj);
	}

	public static string Camelize(this string input)
	{
		string text = input.Pascalize();
		return text.Substring(0, 1).ToLower() + text.Substring(1);
	}

	public static string Underscore(this string input)
	{
		return Regex.Replace(Regex.Replace(Regex.Replace(input, "([\\p{Lu}]+)([\\p{Lu}][\\p{Ll}])", "$1_$2"), "([\\p{Ll}\\d])([\\p{Lu}])", "$1_$2"), "[-\\s]", "_").ToLower();
	}

	public static string Dasherize(this string underscoredWord)
	{
		return underscoredWord.Replace('_', '-');
	}

	public static string Hyphenate(this string underscoredWord)
	{
		return underscoredWord.Dasherize();
	}

	public static string Kebaberize(this string input)
	{
		return input.Underscore().Dasherize();
	}
}
