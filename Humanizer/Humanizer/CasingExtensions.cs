using System;

namespace Humanizer;

public static class CasingExtensions
{
	public static string ApplyCase(this string input, LetterCasing casing)
	{
		return casing switch
		{
			LetterCasing.Title => input.Transform(To.TitleCase), 
			LetterCasing.LowerCase => input.Transform(To.LowerCase), 
			LetterCasing.AllCaps => input.Transform(To.UpperCase), 
			LetterCasing.Sentence => input.Transform(To.SentenceCase), 
			_ => throw new ArgumentOutOfRangeException("casing"), 
		};
	}
}
