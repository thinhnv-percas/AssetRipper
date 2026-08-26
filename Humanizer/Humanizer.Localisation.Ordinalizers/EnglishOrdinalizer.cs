namespace Humanizer.Localisation.Ordinalizers;

internal class EnglishOrdinalizer : DefaultOrdinalizer
{
	public override string Convert(int number, string numberString)
	{
		int num = number % 100;
		if (num >= 11 && num <= 13)
		{
			return numberString + "th";
		}
		return (number % 10) switch
		{
			1 => numberString + "st", 
			2 => numberString + "nd", 
			3 => numberString + "rd", 
			_ => numberString + "th", 
		};
	}
}
