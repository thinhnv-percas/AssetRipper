using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using ICSharpCode.AvalonEdit.Document;

namespace ICSharpCode.AvalonEdit.Search;

internal class RegexSearchStrategy : ISearchStrategy, IEquatable<ISearchStrategy>
{
	private readonly Regex searchPattern;

	private readonly bool matchWholeWords;

	public RegexSearchStrategy(Regex searchPattern, bool matchWholeWords)
	{
		if (searchPattern == null)
		{
			throw new ArgumentNullException("searchPattern");
		}
		this.searchPattern = searchPattern;
		this.matchWholeWords = matchWholeWords;
	}

	public IEnumerable<ISearchResult> FindAll(ITextSource document, int offset, int length)
	{
		int endOffset = offset + length;
		foreach (Match result in searchPattern.Matches(document.Text))
		{
			int resultEndOffset = result.Length + result.Index;
			if (offset <= result.Index && endOffset >= resultEndOffset && (!matchWholeWords || (IsWordBorder(document, result.Index) && IsWordBorder(document, resultEndOffset))))
			{
				yield return new SearchResult
				{
					StartOffset = result.Index,
					Length = result.Length,
					Data = result
				};
			}
		}
	}

	private static bool IsWordBorder(ITextSource document, int offset)
	{
		return TextUtilities.GetNextCaretPosition(document, offset - 1, LogicalDirection.Forward, CaretPositioningMode.WordBorder) == offset;
	}

	public ISearchResult FindNext(ITextSource document, int offset, int length)
	{
		return FindAll(document, offset, length).FirstOrDefault();
	}

	public bool Equals(ISearchStrategy other)
	{
		if (other is RegexSearchStrategy regexSearchStrategy && regexSearchStrategy.searchPattern.ToString() == searchPattern.ToString() && regexSearchStrategy.searchPattern.Options == searchPattern.Options)
		{
			return regexSearchStrategy.searchPattern.RightToLeft == searchPattern.RightToLeft;
		}
		return false;
	}
}
