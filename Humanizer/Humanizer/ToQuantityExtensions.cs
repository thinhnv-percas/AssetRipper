using System;

namespace Humanizer;

public static class ToQuantityExtensions
{
	public static string ToQuantity(this string input, int quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
	{
		return input.ToQuantity(quantity, showQuantityAs, null, null);
	}

	public static string ToQuantity(this string input, int quantity, string format, IFormatProvider formatProvider = null)
	{
		return input.ToQuantity(quantity, ShowQuantityAs.Numeric, format, formatProvider);
	}

	public static string ToQuantity(this string input, long quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
	{
		return input.ToQuantity(quantity, showQuantityAs, null, null);
	}

	public static string ToQuantity(this string input, long quantity, string format, IFormatProvider formatProvider = null)
	{
		return input.ToQuantity(quantity, ShowQuantityAs.Numeric, format, formatProvider);
	}

	private static string ToQuantity(this string input, long quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric, string format = null, IFormatProvider formatProvider = null)
	{
		string text = ((quantity == 1) ? input.Singularize(inputIsKnownToBePlural: false) : input.Pluralize(inputIsKnownToBeSingular: false));
		return showQuantityAs switch
		{
			ShowQuantityAs.None => text, 
			ShowQuantityAs.Numeric => string.Format(formatProvider, "{0} {1}", new object[2]
			{
				quantity.ToString(format, formatProvider),
				text
			}), 
			_ => string.Format("{0} {1}", new object[2]
			{
				quantity.ToWords(),
				text
			}), 
		};
	}
}
