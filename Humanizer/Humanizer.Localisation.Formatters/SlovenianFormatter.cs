namespace Humanizer.Localisation.Formatters;

internal class SlovenianFormatter : DefaultFormatter
{
	private const string DualPostfix = "_Dual";

	private const string TrialQuadralPostfix = "_TrialQuadral";

	public SlovenianFormatter()
		: base("sl")
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
			return resourceKey + "_TrialQuadral";
		default:
			return resourceKey;
		}
	}
}
