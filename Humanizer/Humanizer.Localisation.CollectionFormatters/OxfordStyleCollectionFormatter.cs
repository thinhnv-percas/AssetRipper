namespace Humanizer.Localisation.CollectionFormatters;

internal class OxfordStyleCollectionFormatter : DefaultCollectionFormatter
{
	public OxfordStyleCollectionFormatter(string defaultSeparator)
		: base(defaultSeparator ?? "and")
	{
	}

	protected override string GetConjunctionFormatString(int itemCount)
	{
		if (itemCount <= 2)
		{
			return "{0} {1} {2}";
		}
		return "{0}, {1} {2}";
	}
}
