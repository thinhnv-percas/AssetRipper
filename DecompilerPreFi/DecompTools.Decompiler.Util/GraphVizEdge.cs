using System;
using System.Globalization;
using System.IO;

namespace DecompTools.Decompiler.Util;

internal sealed class GraphVizEdge
{
	public readonly string Source;

	public readonly string Target;

	public string color;

	public bool? constraint;

	public string label;

	public string style;

	public int? fontsize;

	public GraphVizEdge(string source, string target)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		Source = source;
		Target = target;
	}

	public GraphVizEdge(int source, int target)
	{
		Source = source.ToString(CultureInfo.InvariantCulture);
		Target = target.ToString(CultureInfo.InvariantCulture);
	}

	public void Save(TextWriter writer)
	{
		writer.Write("{0} -> {1} [", Source, Target);
		bool isFirst = true;
		GraphVizGraph.WriteAttribute(writer, "label", label, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "style", style, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "fontsize", fontsize, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "color", color, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "constraint", constraint, ref isFirst);
		writer.WriteLine("];");
	}
}
