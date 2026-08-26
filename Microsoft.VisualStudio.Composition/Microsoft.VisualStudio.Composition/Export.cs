using System;
using System.Collections.Generic;

namespace Microsoft.VisualStudio.Composition;

public class Export
{
	private readonly Lazy<object> exportedValueGetter;

	public ExportDefinition Definition { get; private set; }

	public IReadOnlyDictionary<string, object> Metadata => Definition.Metadata;

	public object Value => exportedValueGetter.Value;

	public Export(string contractName, IReadOnlyDictionary<string, object> metadata, Func<object> exportedValueGetter)
		: this(new ExportDefinition(contractName, metadata), exportedValueGetter)
	{
	}

	public Export(ExportDefinition definition, Func<object> exportedValueGetter)
		: this(definition, new Lazy<object>(exportedValueGetter))
	{
	}

	public Export(ExportDefinition definition, Lazy<object> exportedValueGetter)
	{
		Requires.NotNull(definition, "definition");
		Requires.NotNull(exportedValueGetter, "exportedValueGetter");
		Definition = definition;
		this.exportedValueGetter = exportedValueGetter;
	}
}
