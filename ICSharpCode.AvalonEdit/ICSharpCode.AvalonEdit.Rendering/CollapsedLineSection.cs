using ICSharpCode.AvalonEdit.Document;

namespace ICSharpCode.AvalonEdit.Rendering;

public sealed class CollapsedLineSection
{
	private const string ID = "";

	private DocumentLine start;

	private DocumentLine end;

	private HeightTree heightTree;

	public bool IsCollapsed => start != null;

	public DocumentLine Start
	{
		get
		{
			return start;
		}
		internal set
		{
			start = value;
		}
	}

	public DocumentLine End
	{
		get
		{
			return end;
		}
		internal set
		{
			end = value;
		}
	}

	internal CollapsedLineSection(HeightTree heightTree, DocumentLine start, DocumentLine end)
	{
		this.heightTree = heightTree;
		this.start = start;
		this.end = end;
	}

	public void Uncollapse()
	{
		if (start != null)
		{
			heightTree.Uncollapse(this);
			start = null;
			end = null;
		}
	}

	public override string ToString()
	{
		return "[CollapsedSection Start=" + ((start != null) ? start.LineNumber.ToString() : "null") + " End=" + ((end != null) ? end.LineNumber.ToString() : "null") + "]";
	}
}
