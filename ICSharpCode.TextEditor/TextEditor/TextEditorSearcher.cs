using System;
using System.Drawing;
using ICSharpCode.TextEditor.Document;

namespace TextEditor;

public class TextEditorSearcher : IDisposable
{
	private IDocument _document;

	private TextMarker _region;

	public bool MatchCase;

	public bool MatchWholeWordOnly;

	private string _lookFor;

	private string _lookFor2;

	public IDocument Document
	{
		get
		{
			return _document;
		}
		set
		{
			if (_document != value)
			{
				ClearScanRegion();
				_document = value;
			}
		}
	}

	public bool HasScanRegion => _region != null;

	public int BeginOffset
	{
		get
		{
			if (_region != null)
			{
				return _region.Offset;
			}
			return 0;
		}
	}

	public int EndOffset
	{
		get
		{
			if (_region != null)
			{
				return _region.EndOffset;
			}
			return _document.TextLength;
		}
	}

	public string LookFor
	{
		get
		{
			return _lookFor;
		}
		set
		{
			_lookFor = value;
		}
	}

	public void SetScanRegion(ISelection sel)
	{
		SetScanRegion(sel.Offset, sel.Length);
	}

	public void SetScanRegion(int offset, int length)
	{
		Color backgroundColor = _document.HighlightingStrategy.GetColorFor("Default").BackgroundColor;
		_region = new TextMarker(offset, length, TextMarkerType.SolidBlock, backgroundColor.HalfMix(Color.FromArgb(160, 160, 160)));
		_document.MarkerStrategy.AddMarker(_region);
	}

	public void ClearScanRegion()
	{
		if (_region != null)
		{
			_document.MarkerStrategy.RemoveMarker(_region);
			_region = null;
		}
	}

	public void Dispose()
	{
		ClearScanRegion();
		GC.SuppressFinalize(this);
	}

	~TextEditorSearcher()
	{
		Dispose();
	}

	public TextRange FindNext(int beginAtOffset, bool searchBackward, out bool loopedAround)
	{
		loopedAround = false;
		int beginOffset = BeginOffset;
		int endOffset = EndOffset;
		int num = beginAtOffset.InRange(beginOffset, endOffset);
		_lookFor2 = (MatchCase ? _lookFor : _lookFor.ToUpperInvariant());
		TextRange textRange;
		if (searchBackward)
		{
			textRange = FindNextIn(beginOffset, num, searchBackward: true);
			if (textRange == null)
			{
				loopedAround = true;
				textRange = FindNextIn(num, endOffset, searchBackward: true);
			}
		}
		else
		{
			textRange = FindNextIn(num, endOffset, searchBackward: false);
			if (textRange == null)
			{
				loopedAround = true;
				textRange = FindNextIn(beginOffset, num, searchBackward: false);
			}
		}
		return textRange;
	}

	private TextRange FindNextIn(int offset1, int offset2, bool searchBackward)
	{
		offset2 -= _lookFor.Length;
		Func<char, char, bool> func = ((!MatchCase) ? ((Func<char, char, bool>)((char lookFor, char c) => lookFor == char.ToUpperInvariant(c))) : ((Func<char, char, bool>)((char lookFor, char c) => lookFor == c)));
		Func<int, bool> func2 = ((!MatchWholeWordOnly) ? new Func<int, bool>(IsPartWordMatch) : new Func<int, bool>(IsWholeWordMatch));
		char arg = _lookFor2[0];
		if (searchBackward)
		{
			for (int num = offset2; num >= offset1; num--)
			{
				if (func(arg, _document.GetCharAt(num)) && func2(num))
				{
					return new TextRange(_document, num, _lookFor.Length);
				}
			}
		}
		else
		{
			for (int num2 = offset1; num2 <= offset2; num2++)
			{
				if (func(arg, _document.GetCharAt(num2)) && func2(num2))
				{
					return new TextRange(_document, num2, _lookFor.Length);
				}
			}
		}
		return null;
	}

	private bool IsWholeWordMatch(int offset)
	{
		if (IsWordBoundary(offset) && IsWordBoundary(offset + _lookFor.Length))
		{
			return IsPartWordMatch(offset);
		}
		return false;
	}

	private bool IsWordBoundary(int offset)
	{
		if (offset > 0 && offset < _document.TextLength && IsAlphaNumeric(offset - 1))
		{
			return !IsAlphaNumeric(offset);
		}
		return true;
	}

	private bool IsAlphaNumeric(int offset)
	{
		char charAt = _document.GetCharAt(offset);
		if (!char.IsLetterOrDigit(charAt))
		{
			return charAt == '_';
		}
		return true;
	}

	private bool IsPartWordMatch(int offset)
	{
		string text = _document.GetText(offset, _lookFor.Length);
		if (!MatchCase)
		{
			text = text.ToUpperInvariant();
		}
		return text == _lookFor2;
	}
}
