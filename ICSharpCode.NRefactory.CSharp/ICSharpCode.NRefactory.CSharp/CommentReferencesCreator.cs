using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp;

public sealed class CommentReferencesCreator
{
	private readonly List<CommentReference> refs;

	private readonly StringBuilder sb;

	public CommentReference[] CommentReferences => refs.ToArray();

	public string Text => sb.ToString();

	public CommentReferencesCreator(StringBuilder sb)
	{
		refs = new List<CommentReference>();
		this.sb = sb;
		this.sb.Clear();
	}

	public void AddText(string text)
	{
		Add(text, null, isLocal: false);
	}

	public void AddReference(string text, object @ref, bool isLocal = false)
	{
		Add(text, @ref, isLocal);
	}

	private void Add(string s, object @ref, bool isLocal)
	{
		refs.Add(new CommentReference(s.Length, @ref, isLocal));
		sb.Append(s);
	}
}
