using System;
using System.Collections;
using System.Collections.Generic;

namespace dnSpy.Decompiler.ILSpy.Core.XmlDoc;

internal struct StringLineIterator : IEnumerable<SubStringInfo>, IEnumerable, IEnumerator<SubStringInfo>, IDisposable, IEnumerator
{
	private readonly string s;

	private int index;

	private readonly int end;

	private SubStringInfo info;

	private bool finished;

	private static readonly char[] newLineChars = new char[5] { '\r', '\n', '\u0085', '\u2028', '\u2029' };

	public SubStringInfo Current => info;

	object IEnumerator.Current => info;

	public StringLineIterator(string s, int index, int length)
	{
		this.s = s;
		this.index = index;
		end = index + length;
		info = default(SubStringInfo);
		finished = false;
	}

	public StringLineIterator GetEnumerator()
	{
		return this;
	}

	IEnumerator<SubStringInfo> IEnumerable<SubStringInfo>.GetEnumerator()
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
		int num = s.IndexOfAny(newLineChars, index, end - index);
		if (num < 0)
		{
			if (finished)
			{
				return false;
			}
			info = new SubStringInfo(index, end - index);
			finished = true;
			return true;
		}
		int length = num - index;
		info = new SubStringInfo(index, length);
		if (s[num] == '\r' && num + 1 < s.Length && s[num + 1] == '\n')
		{
			num++;
		}
		index = num + 1;
		return true;
	}

	public void Reset()
	{
		throw new NotImplementedException();
	}
}
