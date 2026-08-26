using System;

namespace Roslyn.Utilities;

internal static class DateTimeUtilities
{
	internal const string DateTimeDateDataFieldName = "dateData";

	private const long TicksMask = 4611686018427387903L;

	internal static DateTime ToDateTime(double raw)
	{
		return new DateTime(BitConverter.DoubleToInt64Bits(raw) & 0x3FFFFFFFFFFFFFFFL);
	}

	internal static DateTime ToDateTime(ulong raw)
	{
		return new DateTime((long)(raw & 0x3FFFFFFFFFFFFFFFL));
	}
}
