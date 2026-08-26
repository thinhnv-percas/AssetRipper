using System.Collections.Generic;
using ICSharpCode.TextEditor.Document;

namespace TextEditor;

public class RegionFoldingStrategy : IFoldingStrategy
{
	public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
	{
		List<FoldMarker> list = new List<FoldMarker>();
		Stack<int> stack = new Stack<int>();
		for (int i = 0; i < document.TotalNumberOfLines; i++)
		{
			LineSegment lineSegment = document.GetLineSegment(i);
			int textLength = document.TextLength;
			int j;
			for (j = lineSegment.Offset; j < textLength; j++)
			{
				char charAt;
				if ((charAt = document.GetCharAt(j)) != ' ' && charAt != '\t')
				{
					break;
				}
			}
			if (j == textLength)
			{
				break;
			}
			int num = j - lineSegment.Offset;
			if (document.GetCharAt(j) == '#')
			{
				string text = document.GetText(j, lineSegment.Length - num);
				if (text.StartsWith("#region"))
				{
					stack.Push(i);
				}
				if (text.StartsWith("#endregion") && stack.Count > 0)
				{
					int num2 = stack.Pop();
					list.Add(new FoldMarker(document, num2, document.GetLineSegment(num2).Length, i, num + "#endregion".Length));
				}
			}
		}
		return list;
	}
}
