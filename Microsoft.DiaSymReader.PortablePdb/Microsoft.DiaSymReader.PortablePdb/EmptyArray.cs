namespace Microsoft.DiaSymReader.PortablePdb;

internal static class EmptyArray<T>
{
	public static readonly T[] Instance = new T[0];
}
