using System.Text;

namespace System.IO;

internal static class StringBuilderCache
{
	private const int MAX_BUILDER_SIZE = 260;

	private const int DEFAULT_CAPACITY = 16;

	[ThreadStatic]
	private static StringBuilder t_cachedInstance;

	public static StringBuilder Acquire(int capacity = 16)
	{
		if (capacity <= 260)
		{
			StringBuilder stringBuilder = t_cachedInstance;
			if (stringBuilder != null && capacity <= stringBuilder.Capacity)
			{
				t_cachedInstance = null;
				stringBuilder.Clear();
				return stringBuilder;
			}
		}
		return new StringBuilder(capacity);
	}

	public static void Release(StringBuilder sb)
	{
		if (sb.Capacity <= 260)
		{
			t_cachedInstance = sb;
		}
	}

	public static string GetStringAndRelease(StringBuilder sb)
	{
		string result = sb.ToString();
		Release(sb);
		return result;
	}
}
