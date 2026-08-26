namespace dnSpy.Contracts.Decompiler;

public readonly struct TextSpanData<TData>
{
	public TextSpan Span { get; }

	public TData Data { get; }

	public TextSpanData(TextSpan span, TData data)
	{
		Span = span;
		Data = data;
	}
}
