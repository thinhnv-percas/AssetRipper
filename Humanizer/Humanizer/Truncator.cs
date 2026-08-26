namespace Humanizer;

public static class Truncator
{
	public static ITruncator FixedLength => new FixedLengthTruncator();

	public static ITruncator FixedNumberOfCharacters => new FixedNumberOfCharactersTruncator();

	public static ITruncator FixedNumberOfWords => new FixedNumberOfWordsTruncator();
}
