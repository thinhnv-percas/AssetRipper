using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.Formatters;

internal class RussianFormatter : DefaultFormatter
{
	public RussianFormatter()
		: base("ru")
	{
	}

	protected override string GetResourceKey(string resourceKey, int number)
	{
		RussianGrammaticalNumber grammaticalNumber = RussianGrammaticalNumberDetector.Detect(number);
		string suffix = GetSuffix(grammaticalNumber);
		return resourceKey + suffix;
	}

	private string GetSuffix(RussianGrammaticalNumber grammaticalNumber)
	{
		return grammaticalNumber switch
		{
			RussianGrammaticalNumber.Singular => "_Singular", 
			RussianGrammaticalNumber.Paucal => "_Paucal", 
			_ => "", 
		};
	}
}
