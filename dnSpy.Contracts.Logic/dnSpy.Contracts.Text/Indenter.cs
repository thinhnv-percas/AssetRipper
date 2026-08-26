using System;
using System.Collections.Generic;
using System.Text;

namespace dnSpy.Contracts.Text;

public sealed class Indenter
{
	private readonly int indentSize;

	private readonly int tabSize;

	private readonly bool useTabs;

	private readonly List<string> cachedStrings;

	private StringBuilder sb;

	private int indentLevel;

	public string String => GetIndentString(indentLevel);

	public Indenter(int indentSize, int tabSize, bool useTabs)
	{
		if (indentSize <= 0)
		{
			throw new ArgumentOutOfRangeException("indentSize");
		}
		if (tabSize <= 0)
		{
			throw new ArgumentOutOfRangeException("tabSize");
		}
		this.indentSize = indentSize;
		this.tabSize = tabSize;
		this.useTabs = useTabs;
		cachedStrings = new List<string>();
	}

	public void IncreaseIndent()
	{
		indentLevel++;
	}

	public void DecreaseIndent()
	{
		if (indentLevel == 0)
		{
			throw new InvalidOperationException();
		}
		indentLevel--;
	}

	private string GetIndentString(int level)
	{
		while (cachedStrings.Count <= level)
		{
			cachedStrings.Add(null);
		}
		string text = cachedStrings[level];
		if (text != null)
		{
			return text;
		}
		text = CreateIndentString(level);
		cachedStrings[level] = text;
		return text;
	}

	private string CreateIndentString(int level)
	{
		int num = level * indentSize;
		if (!useTabs)
		{
			return new string(' ', num);
		}
		int num2 = num / tabSize;
		int num3 = num % tabSize;
		if (num3 == 0)
		{
			return new string('\t', num2);
		}
		if (sb == null)
		{
			sb = new StringBuilder();
		}
		sb.Append('\t', num2);
		sb.Append(' ', num3);
		string result = sb.ToString();
		sb.Clear();
		return result;
	}

	public void Reset()
	{
		indentLevel = 0;
		cachedStrings.Clear();
	}
}
