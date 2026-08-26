using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer;

public static class To
{
	public static IStringTransformer TitleCase => new ToTitleCase();

	public static IStringTransformer LowerCase => new ToLowerCase();

	public static IStringTransformer UpperCase => new ToUpperCase();

	public static IStringTransformer SentenceCase => new ToSentenceCase();

	public static string Transform(this string input, params IStringTransformer[] transformers)
	{
		return Enumerable.Aggregate<IStringTransformer, string>((IEnumerable<IStringTransformer>)transformers, input, (Func<string, IStringTransformer, string>)((string current, IStringTransformer stringTransformer) => stringTransformer.Transform(current)));
	}
}
