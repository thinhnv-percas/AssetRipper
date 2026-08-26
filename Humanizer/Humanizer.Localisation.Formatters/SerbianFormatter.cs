namespace Humanizer.Localisation.Formatters;

internal class SerbianFormatter : DefaultFormatter
{
	private const string PaucalPostfix = "_Paucal";

	public SerbianFormatter(string localeCode)
		: base(localeCode)
	{
	}

	protected override string GetResourceKey(string resourceKey, int number)
	{
		int num = number % 10;
		if (num > 1 && num < 5)
		{
			return resourceKey + "_Paucal";
		}
		return resourceKey;
	}
}
