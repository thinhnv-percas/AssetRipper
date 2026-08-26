namespace ICSharpCode.NRefactory.CSharp;

public struct CommentReference
{
	public readonly int Length;

	public readonly object Reference;

	public readonly bool IsLocal;

	public CommentReference(int len, object @ref, bool isLocal = false)
	{
		Length = len;
		Reference = @ref;
		IsLocal = isLocal;
	}
}
