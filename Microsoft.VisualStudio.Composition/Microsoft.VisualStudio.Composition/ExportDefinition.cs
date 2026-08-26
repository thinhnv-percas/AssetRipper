using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

[DebuggerDisplay("{ContractName,nq}")]
public class ExportDefinition : IEquatable<ExportDefinition>
{
	public string ContractName { get; private set; }

	public IReadOnlyDictionary<string, object> Metadata { get; private set; }

	public ExportDefinition(string contractName, IReadOnlyDictionary<string, object> metadata)
	{
		Requires.NotNullOrEmpty(contractName, "contractName");
		Requires.NotNull(metadata, "metadata");
		ContractName = contractName;
		Metadata = metadata;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as ExportDefinition);
	}

	public override int GetHashCode()
	{
		return ContractName.GetHashCode();
	}

	public bool Equals(ExportDefinition other)
	{
		if (other == null)
		{
			return false;
		}
		if (ContractName == other.ContractName)
		{
			return ByValueEquality.Metadata.Equals(Metadata, other.Metadata);
		}
		return false;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter indentingTextWriter = IndentingTextWriter.Get(writer);
		indentingTextWriter.WriteLine("ContractName: {0}", ContractName);
		indentingTextWriter.WriteLine("Metadata:");
		using (indentingTextWriter.Indent())
		{
			foreach (KeyValuePair<string, object> item in Metadata)
			{
				indentingTextWriter.WriteLine("{0} = {1}", item.Key, item.Value);
			}
		}
	}

	internal void GetInputAssemblies(ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		ReflectionHelpers.GetInputAssembliesFromMetadata(assemblies, Metadata);
	}
}
