namespace Humanizer.Localisation.Formatters;

internal class HebrewFormatter : DefaultFormatter
{
	private const string DualPostfix = "_Dual";

	private const string PluralPostfix = "_Plural";

	public HebrewFormatter()
		: base("he")
	{
	}

	protected override string GetResourceKey(string resourceKey, int number)
	{
		switch (number)
		{
		case 2:
			return resourceKey + "_Dual";
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			return resourceKey + "_Plural";
		default:
			return resourceKey;
		}
	}
}
