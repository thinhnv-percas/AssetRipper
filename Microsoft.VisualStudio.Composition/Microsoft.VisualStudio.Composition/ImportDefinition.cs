using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

[DebuggerDisplay("{ContractName,nq} ({Cardinality})")]
public class ImportDefinition : IEquatable<ImportDefinition>
{
	private readonly ImmutableList<IImportSatisfiabilityConstraint> exportConstraints;

	public string ContractName { get; private set; }

	public ImportCardinality Cardinality { get; private set; }

	public IReadOnlyCollection<string> ExportFactorySharingBoundaries { get; private set; }

	public IReadOnlyDictionary<string, object> Metadata { get; private set; }

	public IReadOnlyCollection<IImportSatisfiabilityConstraint> ExportConstraints => exportConstraints;

	public ImportDefinition(string contractName, ImportCardinality cardinality, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<IImportSatisfiabilityConstraint> additionalConstraints, IReadOnlyCollection<string> exportFactorySharingBoundaries)
	{
		Requires.NotNullOrEmpty(contractName, "contractName");
		Requires.NotNull(metadata, "metadata");
		Requires.NotNull(additionalConstraints, "additionalConstraints");
		Requires.NotNull(exportFactorySharingBoundaries, "exportFactorySharingBoundaries");
		ContractName = contractName;
		Cardinality = cardinality;
		Metadata = metadata;
		exportConstraints = additionalConstraints.ToImmutableList();
		ExportFactorySharingBoundaries = exportFactorySharingBoundaries.ToImmutableHashSet();
	}

	public ImportDefinition(string contractName, ImportCardinality cardinality, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<IImportSatisfiabilityConstraint> additionalConstraints)
		: this(contractName, cardinality, metadata, additionalConstraints, ImmutableHashSet.Create<string>())
	{
	}

	public ImportDefinition WithExportConstraints(IReadOnlyCollection<IImportSatisfiabilityConstraint> constraints)
	{
		return new ImportDefinition(ContractName, Cardinality, Metadata, constraints, ExportFactorySharingBoundaries);
	}

	public ImportDefinition AddExportConstraint(IImportSatisfiabilityConstraint constraint)
	{
		Requires.NotNull(constraint, "constraint");
		return WithExportConstraints(exportConstraints.Add(constraint));
	}

	public override int GetHashCode()
	{
		return ContractName.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as ImportDefinition);
	}

	public bool Equals(ImportDefinition other)
	{
		if (other == null)
		{
			return false;
		}
		if (ContractName == other.ContractName && Cardinality == other.Cardinality && ByValueEquality.Metadata.Equals(Metadata, other.Metadata) && ByValueEquality.EquivalentIgnoreOrder<IImportSatisfiabilityConstraint>().Equals(ExportConstraints, other.ExportConstraints))
		{
			return ByValueEquality.EquivalentIgnoreOrder<string>().Equals(ExportFactorySharingBoundaries, other.ExportFactorySharingBoundaries);
		}
		return false;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter indentingTextWriter = IndentingTextWriter.Get(writer);
		indentingTextWriter.WriteLine("ContractName: {0}", ContractName);
		indentingTextWriter.WriteLine("Cardinality: {0}", Cardinality);
		indentingTextWriter.WriteLine("Metadata:");
		using (indentingTextWriter.Indent())
		{
			Metadata.ToString(indentingTextWriter);
		}
		indentingTextWriter.WriteLine("ExportFactorySharingBoundaries: {0}", string.Join(", ", ExportFactorySharingBoundaries));
		indentingTextWriter.WriteLine("ExportConstraints: ");
		using (indentingTextWriter.Indent())
		{
			foreach (IImportSatisfiabilityConstraint item in ExportConstraints.OrderBy((IImportSatisfiabilityConstraint ec) => ec.GetType().Name))
			{
				indentingTextWriter.WriteLine(item.GetType().Name);
				using (indentingTextWriter.Indent())
				{
					item.ToString(indentingTextWriter);
				}
			}
		}
	}

	internal void GetInputAssemblies(ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		ReflectionHelpers.GetInputAssembliesFromMetadata(assemblies, Metadata);
	}
}
