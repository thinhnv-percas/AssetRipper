namespace Microsoft.DiaSymReader;

public struct SymUnmanagedLineDelta
{
	public readonly int MethodToken;

	public readonly int Delta;

	public SymUnmanagedLineDelta(int methodToken, int delta)
	{
		MethodToken = methodToken;
		Delta = delta;
	}
}
