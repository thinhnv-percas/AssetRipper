namespace dnSpy.Contracts.Decompiler;

public readonly struct LineSeparator
{
	public int Position { get; }

	public LineSeparator(int position)
	{
		Position = position;
	}
}
