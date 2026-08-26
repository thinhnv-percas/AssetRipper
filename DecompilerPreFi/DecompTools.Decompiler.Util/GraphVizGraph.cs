using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace DecompTools.Decompiler.Util;

internal sealed class GraphVizGraph
{
	private List<GraphVizNode> nodes = new List<GraphVizNode>();

	private List<GraphVizEdge> edges = new List<GraphVizEdge>();

	public string rankdir;

	public string Title;

	public void AddEdge(GraphVizEdge edge)
	{
		edges.Add(edge);
	}

	public void AddNode(GraphVizNode node)
	{
		nodes.Add(node);
	}

	public void Save(string fileName)
	{
		using StreamWriter writer = new StreamWriter(fileName);
		Save(writer);
	}

	public void Show()
	{
		Show(null);
	}

	public void Show(string name)
	{
		if (name == null)
		{
			name = Title;
		}
		if (name != null)
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char oldChar in invalidFileNameChars)
			{
				name = name.Replace(oldChar, '-');
			}
		}
		string text = ((name != null) ? Path.Combine(Path.GetTempPath(), name) : Path.GetTempFileName());
		Save(text + ".gv");
		Process.Start("dot", "\"" + text + ".gv\" -Tpng -o \"" + text + ".png\"").WaitForExit();
		Process.Start(text + ".png");
	}

	private static string Escape(string text)
	{
		if (Regex.IsMatch(text, "^[\\w\\d]+$"))
		{
			return text;
		}
		return "\"" + text.Replace("\\", "\\\\").Replace("\r", "").Replace("\n", "\\n")
			.Replace("\"", "\\\"") + "\"";
	}

	private static void WriteGraphAttribute(TextWriter writer, string name, string value)
	{
		if (value != null)
		{
			writer.WriteLine("{0}={1};", name, Escape(value));
		}
	}

	internal static void WriteAttribute(TextWriter writer, string name, double? value, ref bool isFirst)
	{
		if (value.HasValue)
		{
			WriteAttribute(writer, name, value.Value.ToString(CultureInfo.InvariantCulture), ref isFirst);
		}
	}

	internal static void WriteAttribute(TextWriter writer, string name, bool? value, ref bool isFirst)
	{
		if (value.HasValue)
		{
			WriteAttribute(writer, name, value.Value ? "true" : "false", ref isFirst);
		}
	}

	internal static void WriteAttribute(TextWriter writer, string name, string value, ref bool isFirst)
	{
		if (value != null)
		{
			if (isFirst)
			{
				isFirst = false;
			}
			else
			{
				writer.Write(',');
			}
			writer.Write("{0}={1}", name, Escape(value));
		}
	}

	public void Save(TextWriter writer)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		writer.WriteLine("digraph G {");
		writer.WriteLine("node [fontsize = 16];");
		WriteGraphAttribute(writer, "rankdir", rankdir);
		foreach (GraphVizNode node in nodes)
		{
			node.Save(writer);
		}
		foreach (GraphVizEdge edge in edges)
		{
			edge.Save(writer);
		}
		writer.WriteLine("}");
	}
}
