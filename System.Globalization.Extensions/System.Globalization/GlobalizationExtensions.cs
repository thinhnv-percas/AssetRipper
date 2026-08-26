namespace System.Globalization;

public static class GlobalizationExtensions
{
	public static StringComparer GetStringComparer(this CompareInfo compareInfo, CompareOptions options)
	{
		if (compareInfo == null)
		{
			throw new ArgumentNullException("compareInfo");
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return StringComparer.Ordinal;
		case CompareOptions.OrdinalIgnoreCase:
			return StringComparer.OrdinalIgnoreCase;
		default:
			if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.StringSort)) != CompareOptions.None)
			{
				throw new ArgumentException(SR.Argument_InvalidFlag, "options");
			}
			return new CultureAwareComparer(compareInfo, options);
		}
	}
}
