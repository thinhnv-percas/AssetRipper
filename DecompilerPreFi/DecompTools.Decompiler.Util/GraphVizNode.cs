using System;
using System.Globalization;
using System.IO;

namespace DecompTools.Decompiler.Util;

internal sealed class GraphVizNode
{
	public readonly string ID;

	public string label;

	public string labelloc;

	public int? fontsize;

	public double? height;

	public string margin;

	public string shape;

	public GraphVizNode(string id)
	{
		if (id == null)
		{
			throw new ArgumentNullException("id");
		}
		ID = id;
	}

	public GraphVizNode(int id)
	{
		ID = id.ToString(CultureInfo.InvariantCulture);
	}

	public void Save(TextWriter writer)
	{
		writer.Write(ID);
		writer.Write(" [");
		bool isFirst = true;
		GraphVizGraph.WriteAttribute(writer, "label", label, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "labelloc", labelloc, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "fontsize", fontsize, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "margin", margin, ref isFirst);
		GraphVizGraph.WriteAttribute(writer, "shape", shape, ref isFirst);
		writer.WriteLine("];");
	}
}
