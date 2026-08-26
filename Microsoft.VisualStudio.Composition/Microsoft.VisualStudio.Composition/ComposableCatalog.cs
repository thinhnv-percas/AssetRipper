using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class ComposableCatalog : IEquatable<ComposableCatalog>
{
	private ImmutableHashSet<ComposablePartDefinition> parts;

	private ImmutableDictionary<string, ImmutableList<ExportDefinitionBinding>> exportsByContract;

	public IImmutableSet<ComposablePartDefinition> Parts => parts;

	public DiscoveredParts DiscoveredParts { get; private set; }

	internal Resolver Resolver { get; }

	private ComposableCatalog(ImmutableHashSet<ComposablePartDefinition> parts, ImmutableDictionary<string, ImmutableList<ExportDefinitionBinding>> exportsByContract, DiscoveredParts discoveredParts, Resolver resolver)
	{
		Requires.NotNull(parts, "parts");
		Requires.NotNull(exportsByContract, "exportsByContract");
		Requires.NotNull(discoveredParts, "discoveredParts");
		Requires.NotNull(resolver, "resolver");
		this.parts = parts;
		this.exportsByContract = exportsByContract;
		DiscoveredParts = discoveredParts;
		Resolver = resolver;
	}

	public static ComposableCatalog Create(Resolver resolver)
	{
		return new ComposableCatalog(ImmutableHashSet.Create<ComposablePartDefinition>(), ImmutableDictionary.Create<string, ImmutableList<ExportDefinitionBinding>>(), DiscoveredParts.Empty, resolver);
	}

	public ComposableCatalog AddPart(ComposablePartDefinition partDefinition)
	{
		Requires.NotNull(partDefinition, "partDefinition");
		ImmutableHashSet<ComposablePartDefinition> immutableHashSet = parts.Add(partDefinition);
		if (immutableHashSet == parts)
		{
			return this;
		}
		ImmutableDictionary<string, ImmutableList<ExportDefinitionBinding>> immutableDictionary = exportsByContract;
		foreach (ExportDefinition exportedType in partDefinition.ExportedTypes)
		{
			ImmutableList<ExportDefinitionBinding> valueOrDefault = immutableDictionary.GetValueOrDefault(exportedType.ContractName, ImmutableList.Create<ExportDefinitionBinding>());
			immutableDictionary = immutableDictionary.SetItem(exportedType.ContractName, valueOrDefault.Add(new ExportDefinitionBinding(exportedType, partDefinition, default(MemberRef))));
		}
		foreach (KeyValuePair<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMember in partDefinition.ExportingMembers)
		{
			MemberRef key = exportingMember.Key;
			foreach (ExportDefinition item in exportingMember.Value)
			{
				ImmutableList<ExportDefinitionBinding> valueOrDefault2 = immutableDictionary.GetValueOrDefault(item.ContractName, ImmutableList.Create<ExportDefinitionBinding>());
				immutableDictionary = immutableDictionary.SetItem(item.ContractName, valueOrDefault2.Add(new ExportDefinitionBinding(item, partDefinition, key)));
			}
		}
		return new ComposableCatalog(immutableHashSet, immutableDictionary, DiscoveredParts, Resolver);
	}

	public ComposableCatalog AddParts(IEnumerable<ComposablePartDefinition> parts)
	{
		Requires.NotNull(parts, "parts");
		return parts.Aggregate(this, (ComposableCatalog catalog, ComposablePartDefinition part) => catalog.AddPart(part));
	}

	public ComposableCatalog AddParts(DiscoveredParts parts)
	{
		Requires.NotNull(parts, "parts");
		ComposableCatalog composableCatalog = AddParts(parts.Parts);
		return new ComposableCatalog(composableCatalog.parts, composableCatalog.exportsByContract, composableCatalog.DiscoveredParts.Merge(parts), composableCatalog.Resolver);
	}

	public ComposableCatalog AddCatalog(ComposableCatalog catalogToMerge)
	{
		Requires.NotNull(catalogToMerge, "catalogToMerge");
		ComposableCatalog composableCatalog = AddParts(catalogToMerge.Parts);
		return new ComposableCatalog(composableCatalog.parts, composableCatalog.exportsByContract, composableCatalog.DiscoveredParts.Merge(catalogToMerge.DiscoveredParts), composableCatalog.Resolver);
	}

	public ComposableCatalog AddCatalogs(IEnumerable<ComposableCatalog> catalogsToMerge)
	{
		Requires.NotNull(catalogsToMerge, "catalogsToMerge");
		return catalogsToMerge.Aggregate(this, (ComposableCatalog aggregate, ComposableCatalog mergeCatalog) => aggregate.AddCatalog(mergeCatalog));
	}

	public IReadOnlyCollection<AssemblyName> GetInputAssemblies()
	{
		ImmutableHashSet<AssemblyName>.Builder builder = ImmutableHashSet.CreateBuilder(ByValueEquality.AssemblyName);
		foreach (ComposablePartDefinition part in Parts)
		{
			part.GetInputAssemblies(builder);
		}
		return builder.ToImmutable();
	}

	public bool Equals(ComposableCatalog other)
	{
		if (other == null)
		{
			return false;
		}
		return parts.SetEquals(other.parts);
	}

	public override int GetHashCode()
	{
		int num = Parts.Count;
		foreach (ComposablePartDefinition part in Parts)
		{
			num += part.GetHashCode();
		}
		return num;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter indentingTextWriter = IndentingTextWriter.Get(writer);
		using (indentingTextWriter.Indent())
		{
			foreach (ComposablePartDefinition part in parts)
			{
				indentingTextWriter.WriteLine("Part");
				using (indentingTextWriter.Indent())
				{
					part.ToString(indentingTextWriter);
				}
			}
		}
	}

	public IReadOnlyList<ExportDefinitionBinding> GetExports(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		ImmutableList<ExportDefinitionBinding> immutableList = exportsByContract.GetValueOrDefault(importDefinition.ContractName, ImmutableList.Create<ExportDefinitionBinding>());
		if (TryGetOpenGenericExport(importDefinition, out var contractName, out var genericTypeArguments))
		{
			ImmutableList<ExportDefinitionBinding> valueOrDefault = exportsByContract.GetValueOrDefault(contractName, ImmutableList.Create<ExportDefinitionBinding>());
			immutableList = immutableList.AddRange(valueOrDefault.Select((ExportDefinitionBinding export) => export.CloseGenericExport(genericTypeArguments)));
		}
		return ImmutableList.CreateRange(immutableList.Where((ExportDefinitionBinding export) => importDefinition.ExportConstraints.All((IImportSatisfiabilityConstraint c) => c.IsSatisfiedBy(export.ExportDefinition))));
	}

	internal static bool TryGetOpenGenericExport(ImportDefinition importDefinition, out string contractName, out Type[] typeArguments)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		if (importDefinition.Metadata.TryGetValue<string>("System.ComponentModel.Composition.GenericContractName", out contractName) && importDefinition.Metadata.TryGetValue<Type[]>("System.ComponentModel.Composition.GenericParameters", out typeArguments))
		{
			return true;
		}
		contractName = null;
		typeArguments = null;
		return false;
	}
}
