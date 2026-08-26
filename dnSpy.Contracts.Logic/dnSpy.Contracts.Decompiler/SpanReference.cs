namespace dnSpy.Contracts.Decompiler;

public readonly struct SpanReference
{
	public object Reference { get; }

	public TextSpan Span { get; }

	public string Id { get; }

	public SpanReference(object reference, TextSpan span, string id)
	{
		Reference = reference;
		Span = span;
		Id = id;
	}
}
