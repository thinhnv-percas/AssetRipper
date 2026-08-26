using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.VisualStudio.Composition;

public class ExportMetadataValueImportConstraint : IImportSatisfiabilityConstraint, IEquatable<IImportSatisfiabilityConstraint>, IDescriptiveToString
{
	public string Name { get; private set; }

	public object Value { get; private set; }

	public ExportMetadataValueImportConstraint(string name, object value)
	{
		Requires.NotNullOrEmpty(name, "name");
		Name = name;
		Value = value;
	}

	public bool IsSatisfiedBy(ExportDefinition exportDefinition)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		if (exportDefinition.Metadata.TryGetValue(Name, out var value) && EqualityComparer<object>.Default.Equals(Value, value))
		{
			return true;
		}
		return false;
	}

	public bool Equals(IImportSatisfiabilityConstraint obj)
	{
		if (!(obj is ExportMetadataValueImportConstraint exportMetadataValueImportConstraint))
		{
			return false;
		}
		if (Name == exportMetadataValueImportConstraint.Name)
		{
			return EqualityComparer<object>.Default.Equals(Value, exportMetadataValueImportConstraint.Value);
		}
		return false;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter.Get(writer).WriteLine("{0} = {1}", Name, Value);
	}
}
