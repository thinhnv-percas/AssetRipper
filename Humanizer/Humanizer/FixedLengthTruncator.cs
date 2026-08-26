namespace Humanizer;

internal class FixedLengthTruncator : ITruncator
{
	public string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right)
	{
		if (value == null)
		{
			return null;
		}
		if (value.Length == 0)
		{
			return value;
		}
		if (truncationString == null || truncationString.Length > length)
		{
			if (truncateFrom != TruncateFrom.Right)
			{
				return value.Substring(value.Length - length);
			}
			return value.Substring(0, length);
		}
		if (truncateFrom == TruncateFrom.Left)
		{
			if (value.Length <= length)
			{
				return value;
			}
			return truncationString + value.Substring(value.Length - length + truncationString.Length);
		}
		if (value.Length <= length)
		{
			return value;
		}
		return value.Substring(0, length - truncationString.Length) + truncationString;
	}
}
