using System;
using System.Collections;
using System.Collections.Generic;

namespace dnSpy.Decompiler.ILSpy.Core.XmlDoc;

internal struct XmlDocLine : IEnumerable<SubString?>, IEnumerable, IEnumerator<SubString?>, IDisposable, IEnumerator
{
	private readonly string s;

	private readonly int end;

	private SubString? current;

	private SubStringInfo? indent;

	private StringLineIterator iter;

	private int emptyLines;

	public SubString? Current => current;

	object IEnumerator.Current => current;

	public XmlDocLine(string s)
		: this(s, 0, s.Length)
	{
	}

	public XmlDocLine(string s, int start, int length)
	{
		this.s = s;
		end = start + length;
		current = null;
		indent = null;
		iter = new StringLineIterator(s, start, end - start);
		emptyLines = 0;
	}

	public XmlDocLine GetEnumerator()
	{
		return this;
	}

	IEnumerator<SubString?> IEnumerable<SubString?>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		if (!indent.HasValue)
		{
			do
			{
				if (!iter.MoveNext())
				{
					return false;
				}
			}
			while (IsWhiteSpace(s, iter.Current));
			indent = GetIndentation(s, iter.Current);
		}
		else if (emptyLines == 0)
		{
			goto IL_0061;
		}
		goto IL_0070;
		IL_0070:
		if (IsWhiteSpace(s, iter.Current))
		{
			emptyLines++;
			goto IL_0061;
		}
		if (emptyLines != 0)
		{
			if (emptyLines != -1)
			{
				emptyLines--;
				if (emptyLines == 0)
				{
					emptyLines = -1;
				}
				current = null;
				return true;
			}
			emptyLines = 0;
		}
		Trim(out var trimmedIndex, out var trimmedEnd);
		current = new SubString(s, trimmedIndex, trimmedEnd - trimmedIndex);
		return true;
		IL_0061:
		if (!iter.MoveNext())
		{
			return false;
		}
		goto IL_0070;
	}

	private void Trim(out int trimmedIndex, out int trimmedEnd)
	{
		int index = iter.Current.Index;
		int num = index + iter.Current.Length;
		if (indent.Value.Length > iter.Current.Length)
		{
			trimmedIndex = index;
			trimmedEnd = num;
			return;
		}
		int num2 = index + indent.Value.Length;
		int num3 = index;
		int num4 = indent.Value.Index;
		while (num3 < num2)
		{
			if (s[num3] != s[num4])
			{
				trimmedIndex = index;
				trimmedEnd = num;
				return;
			}
			num3++;
			num4++;
		}
		trimmedIndex = index + indent.Value.Length;
		trimmedEnd = num;
	}

	private SubStringInfo GetIndentation(string doc, SubStringInfo info)
	{
		int num = info.Index + info.Length;
		int i;
		for (i = info.Index; i < num && char.IsWhiteSpace(doc[i]); i++)
		{
		}
		return new SubStringInfo(info.Index, i - info.Index);
	}

	private bool IsWhiteSpace(string doc, SubStringInfo info)
	{
		int num = info.Index + info.Length;
		for (int i = info.Index; i < num; i++)
		{
			if (!char.IsWhiteSpace(doc[i]))
			{
				return false;
			}
		}
		return true;
	}

	public void Reset()
	{
		throw new NotImplementedException();
	}
}
