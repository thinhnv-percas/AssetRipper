using System;

namespace Humanizer.Localisation;

public class ResourceKeys
{
	public static class DateHumanize
	{
		public const string Now = "DateHumanize_Now";

		public const string Never = "DateHumanize_Never";

		private const string DateTimeFormat = "DateHumanize_{0}{1}{2}";

		private const string Ago = "Ago";

		private const string FromNow = "FromNow";

		public static string GetResourceKey(TimeUnit timeUnit, Tense timeUnitTense, int count = 1)
		{
			ValidateRange(count);
			object obj;
			switch (count)
			{
			case 0:
				return "DateHumanize_Now";
			default:
				obj = "Multiple";
				break;
			case 1:
				obj = "Single";
				break;
			}
			string text = (string)obj;
			string text2 = ((timeUnitTense == Tense.Future) ? "FromNow" : "Ago");
			string text3 = timeUnit.ToString().ToQuantity(count, ShowQuantityAs.None);
			return "DateHumanize_{0}{1}{2}".FormatWith(text, text3, text2);
		}
	}

	public static class TimeSpanHumanize
	{
		private const string TimeSpanFormat = "TimeSpanHumanize_{0}{1}{2}";

		private const string Zero = "TimeSpanHumanize_Zero";

		public static string GetResourceKey(TimeUnit unit, int count = 1)
		{
			ValidateRange(count);
			if (count == 0)
			{
				return "TimeSpanHumanize_Zero";
			}
			return "TimeSpanHumanize_{0}{1}{2}".FormatWith((count == 1) ? "Single" : "Multiple", unit, (count == 1) ? "" : "s");
		}
	}

	private const string Single = "Single";

	private const string Multiple = "Multiple";

	private static void ValidateRange(int count)
	{
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
	}
}
