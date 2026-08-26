namespace McMaster.Extensions.CommandLineUtils;

internal class Util
{
	private static class EmptyArrayCache<T>
	{
		internal static readonly T[] Value = new T[0];
	}

	public static T[] EmptyArray<T>()
	{
		return EmptyArrayCache<T>.Value;
	}
}
