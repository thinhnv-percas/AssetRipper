using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class CompositionConfiguration
{
	[DebuggerDisplay("{PartDefinition.Type.Name}")]
	private class PartBuilder
	{
		public ComposablePartDefinition PartDefinition { get; set; }

		public ISet<string> RequiredSharingBoundaries { get; private set; }

		public HashSet<PartBuilder> ImportingParts { get; private set; }

		public IReadOnlyDictionary<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>> SatisfyingExports { get; private set; }

		internal PartBuilder(ComposablePartDefinition partDefinition, IReadOnlyDictionary<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>> importedParts)
		{
			Requires.NotNull(partDefinition, "partDefinition");
			Requires.NotNull(importedParts, "importedParts");
			PartDefinition = partDefinition;
			RequiredSharingBoundaries = ImmutableHashSet.CreateBuilder<string>();
			SatisfyingExports = importedParts;
			ImportingParts = new HashSet<PartBuilder>();
		}

		public void ApplySharingBoundary()
		{
			ApplySharingBoundary(PartDefinition.SharingBoundary);
		}

		private void ApplySharingBoundary(string sharingBoundary)
		{
			if (string.IsNullOrEmpty(sharingBoundary) || !RequiredSharingBoundaries.Add(sharingBoundary))
			{
				return;
			}
			foreach (PartBuilder importingPart in ImportingParts)
			{
				importingPart.ApplySharingBoundary(sharingBoundary);
			}
		}

		public void ReportImportingPart(PartBuilder part)
		{
			ImportingParts.Add(part);
		}
	}

	[DebuggerDisplay("{Name}")]
	private class SharingBoundaryTree
	{
		public string Name { get; private set; }

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public ImmutableHashSet<SharingBoundaryTree> Children { get; private set; }

		public SharingBoundaryTree(string name, ImmutableHashSet<SharingBoundaryTree> children)
		{
			Requires.NotNull(name, "name");
			Requires.NotNull(children, "children");
			Name = name;
			Children = children;
		}
	}

	private class SharingBoundaryMetadata
	{
		internal ImmutableHashSet<string> ParentBoundariesUnion { get; private set; }

		internal ImmutableHashSet<string> ParentBoundariesIntersection { get; private set; }

		private SharingBoundaryMetadata(ISet<string> initialParentBoundaries)
		{
			Requires.NotNull(initialParentBoundaries, "initialParentBoundaries");
			ParentBoundariesUnion = initialParentBoundaries.ToImmutableHashSet();
			ParentBoundariesIntersection = ParentBoundariesUnion;
		}

		private SharingBoundaryMetadata(ImmutableHashSet<string> parentBoundariesUnion, ImmutableHashSet<string> parentBoundariesIntersection)
		{
			Requires.NotNull(parentBoundariesUnion, "parentBoundariesUnion");
			Requires.NotNull(parentBoundariesIntersection, "parentBoundariesIntersection");
			ParentBoundariesUnion = parentBoundariesUnion;
			ParentBoundariesIntersection = parentBoundariesIntersection;
		}

		internal static SharingBoundaryMetadata InitialFactoryEncountered(ISet<string> parentBoundaries)
		{
			return new SharingBoundaryMetadata(parentBoundaries);
		}

		internal SharingBoundaryMetadata AdditionalFactoryEncountered(ISet<string> parentBoundaries)
		{
			return new SharingBoundaryMetadata(ParentBoundariesUnion.Union(parentBoundaries), ParentBoundariesIntersection.Intersect(parentBoundaries));
		}
	}

	internal class ExportDefinitionPracticallyEqual : IEqualityComparer<ExportDefinition>
	{
		internal static ExportDefinitionPracticallyEqual Default = new ExportDefinitionPracticallyEqual();

		private ExportDefinitionPracticallyEqual()
		{
		}

		public bool Equals(ExportDefinition x, ExportDefinition y)
		{
			if (string.Equals(x.ContractName, y.ContractName, StringComparison.Ordinal))
			{
				return string.Equals(x.Metadata.GetValueOrDefault("ExportTypeIdentity") as string, y.Metadata.GetValueOrDefault("ExportTypeIdentity") as string, StringComparison.Ordinal);
			}
			return false;
		}

		public int GetHashCode(ExportDefinition obj)
		{
			return obj.ContractName.GetHashCode();
		}
	}

	private class ReferenceEquality<T> : IEqualityComparer<T> where T : class
	{
		internal static readonly ReferenceEquality<T> Default = new ReferenceEquality<T>();

		private ReferenceEquality()
		{
		}

		public bool Equals(T x, T y)
		{
			return x == y;
		}

		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}
	}

	private static readonly ImmutableHashSet<ComposablePartDefinition> AlwaysBundledParts = ImmutableHashSet.Create<ComposablePartDefinition>(ExportProvider.ExportProviderPartDefinition, PassthroughMetadataViewProvider.PartDefinition, MetadataViewClassProvider.PartDefinition, ExportMetadataViewInterfaceEmitProxy.PartDefinition).Add(MetadataViewImplProxy.PartDefinition);

	private ImmutableDictionary<ComposablePartDefinition, string> effectiveSharingBoundaryOverrides;

	public ComposableCatalog Catalog { get; private set; }

	public ISet<ComposedPart> Parts { get; private set; }

	public IReadOnlyDictionary<Type, ExportDefinitionBinding> MetadataViewsAndProviders { get; private set; }

	public IImmutableStack<IReadOnlyCollection<ComposedPartDiagnostic>> CompositionErrors { get; private set; }

	internal Resolver Resolver => Catalog.Resolver;

	private CompositionConfiguration(ComposableCatalog catalog, ISet<ComposedPart> parts, IReadOnlyDictionary<Type, ExportDefinitionBinding> metadataViewsAndProviders, IImmutableStack<IReadOnlyCollection<ComposedPartDiagnostic>> compositionErrors, ImmutableDictionary<ComposablePartDefinition, string> effectiveSharingBoundaryOverrides)
	{
		Requires.NotNull(catalog, "catalog");
		Requires.NotNull(parts, "parts");
		Requires.NotNull(metadataViewsAndProviders, "metadataViewsAndProviders");
		Requires.NotNull(compositionErrors, "compositionErrors");
		Requires.NotNull(effectiveSharingBoundaryOverrides, "effectiveSharingBoundaryOverrides");
		Catalog = catalog;
		Parts = parts;
		MetadataViewsAndProviders = metadataViewsAndProviders;
		CompositionErrors = compositionErrors;
		this.effectiveSharingBoundaryOverrides = effectiveSharingBoundaryOverrides;
	}

	public static CompositionConfiguration Create(ComposableCatalog catalog)
	{
		Requires.NotNull(catalog, "catalog");
		ComposableCatalog customizedCatalog = catalog.AddParts(AlwaysBundledParts);
		Dictionary<ComposablePartDefinition, PartBuilder> dictionary = new Dictionary<ComposablePartDefinition, PartBuilder>(ReferenceEquality<ComposablePartDefinition>.Default);
		foreach (ComposablePartDefinition part in customizedCatalog.Parts)
		{
			ImmutableDictionary<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>> importedParts = part.Imports.ToImmutableDictionary((ImportDefinitionBinding i) => i, (ImportDefinitionBinding i) => customizedCatalog.GetExports(i.ImportDefinition));
			dictionary.Add(part, new PartBuilder(part, importedParts));
		}
		foreach (PartBuilder value in dictionary.Values)
		{
			foreach (ComposablePartDefinition item2 in (from entry in value.SatisfyingExports
				where !entry.Key.IsExportFactory || entry.Key.ImportDefinition.ExportFactorySharingBoundaries.Count == 0
				from export in entry.Value
				select export.PartDefinition).Distinct(ReferenceEquality<ComposablePartDefinition>.Default))
			{
				dictionary[item2].ReportImportingPart(value);
			}
		}
		foreach (PartBuilder value2 in dictionary.Values)
		{
			value2.ApplySharingBoundary();
		}
		ImmutableDictionary<ComposablePartDefinition, string> immutableDictionary = ComputeInferredSharingBoundaries(dictionary.Values);
		ImmutableHashSet<ComposedPart>.Builder builder = ImmutableHashSet.CreateBuilder<ComposedPart>();
		foreach (PartBuilder value3 in dictionary.Values)
		{
			ComposedPart item = new ComposedPart(value3.PartDefinition, value3.SatisfyingExports, value3.RequiredSharingBoundaries.ToImmutableHashSet());
			builder.Add(item);
		}
		ImmutableHashSet<ComposedPart> immutableHashSet = builder.ToImmutable();
		ImmutableDictionary<Type, ExportDefinitionBinding> metadataViewProvidersMap = GetMetadataViewProvidersMap(customizedCatalog);
		List<ComposedPartDiagnostic> list = new List<ComposedPartDiagnostic>();
		foreach (ComposedPart item3 in immutableHashSet)
		{
			list.AddRange(item3.Validate(metadataViewProvidersMap));
		}
		list.AddRange(FindLoops(immutableHashSet));
		if (list.Count > 0)
		{
			ImmutableHashSet<ComposablePartDefinition> immutableHashSet2 = ImmutableHashSet.CreateRange(from p in list.SelectMany((ComposedPartDiagnostic error) => error.Parts)
				select p.Definition);
			if (immutableHashSet2.IsEmpty)
			{
				throw new CompositionFailedException(Strings.FailStableComposition, ImmutableStack.Create((IReadOnlyCollection<ComposedPartDiagnostic>)list));
			}
			IImmutableSet<ComposablePartDefinition> parts = catalog.Parts.Except(immutableHashSet2);
			return Create(ComposableCatalog.Create(catalog.Resolver).AddParts(parts)).WithErrors(list);
		}
		return new CompositionConfiguration(catalog, immutableHashSet, metadataViewProvidersMap, ImmutableStack<IReadOnlyCollection<ComposedPartDiagnostic>>.Empty, immutableDictionary);
	}

	private static ImmutableDictionary<Type, ExportDefinitionBinding> GetMetadataViewProvidersMap(ComposableCatalog customizedCatalog)
	{
		Requires.NotNull(customizedCatalog, "customizedCatalog");
		List<Tuple<IMetadataViewProvider, ExportDefinitionBinding>> source = (from part in customizedCatalog.Parts
			from export in part.ExportDefinitions
			where export.Value.ContractName == ContractNameServices.GetTypeIdentity(typeof(IMetadataViewProvider))
			orderby ExportProvider.GetOrderMetadata(export.Value.Metadata) descending
			let exportDefinitionBinding = new ExportDefinitionBinding(export.Value, part, default(MemberRef))
			let provider = (IMetadataViewProvider)part.ImportingConstructorInfo.Invoke(Type.EmptyTypes)
			select Tuple.Create(provider, exportDefinitionBinding)).ToList();
		HashSet<Type> obj = new HashSet<Type>(from part in customizedCatalog.Parts
			from import in part.Imports
			where import.MetadataType != null
			select import.MetadataType)
		{
			typeof(IDictionary<string, object>),
			typeof(IReadOnlyDictionary<string, object>)
		};
		ImmutableDictionary<Type, ExportDefinitionBinding>.Builder builder = ImmutableDictionary.CreateBuilder<Type, ExportDefinitionBinding>();
		foreach (Type metadataType in obj)
		{
			Tuple<IMetadataViewProvider, ExportDefinitionBinding> tuple = source.FirstOrDefault((Tuple<IMetadataViewProvider, ExportDefinitionBinding> p) => p.Item1.IsMetadataViewSupported(metadataType));
			if (tuple != null)
			{
				builder.Add(metadataType, tuple.Item2);
			}
		}
		return builder.ToImmutable();
	}

	public IExportProviderFactory CreateExportProviderFactory()
	{
		return RuntimeComposition.CreateRuntimeComposition(this).CreateExportProviderFactory();
	}

	public string GetEffectiveSharingBoundary(ComposablePartDefinition partDefinition)
	{
		Requires.NotNull(partDefinition, "partDefinition");
		Requires.Argument(partDefinition.IsShared, "partDefinition", Strings.PartIsNotShared);
		return effectiveSharingBoundaryOverrides.GetValueOrDefault(partDefinition) ?? partDefinition.SharingBoundary;
	}

	public CompositionConfiguration ThrowOnErrors()
	{
		Catalog.DiscoveredParts.ThrowOnErrors();
		if (CompositionErrors.IsEmpty)
		{
			return this;
		}
		throw new CompositionFailedException(Strings.ErrorsInComposition, CompositionErrors);
	}

	internal CompositionConfiguration WithErrors(IReadOnlyCollection<ComposedPartDiagnostic> errors)
	{
		Requires.NotNull(errors, "errors");
		return new CompositionConfiguration(Catalog, Parts, MetadataViewsAndProviders, CompositionErrors.Push(errors), effectiveSharingBoundaryOverrides);
	}

	private static ImmutableStack<T> PathExistsBetween<T>(T origin, T target, Func<T, IEnumerable<T>> getDirectLinks, HashSet<T> visited)
	{
		Requires.NotNullAllowStructs(origin, "origin");
		Requires.NotNullAllowStructs(target, "target");
		Requires.NotNull(getDirectLinks, "getDirectLinks");
		Requires.NotNull(visited, "visited");
		if (visited.Add(origin))
		{
			foreach (T item in getDirectLinks(origin))
			{
				if (item.Equals(target))
				{
					return ImmutableStack.Create(target);
				}
				ImmutableStack<T> immutableStack = PathExistsBetween(item, target, getDirectLinks, visited);
				if (!immutableStack.IsEmpty)
				{
					return immutableStack.Push(item);
				}
			}
		}
		return ImmutableStack<T>.Empty;
	}

	private static IEnumerable<ComposedPartDiagnostic> FindLoops(IEnumerable<ComposedPart> parts)
	{
		Requires.NotNull(parts, "parts");
		Dictionary<ComposablePartDefinition, ComposedPart> partByPartDefinition = parts.ToDictionary((ComposedPart p) => p.Definition);
		Dictionary<TypeRef, ComposedPart> partByPartType = parts.ToDictionary((ComposedPart p) => p.Definition.TypeRef);
		Dictionary<ComposedPart, IReadOnlyList<KeyValuePair<ImportDefinitionBinding, ComposedPart>>> partsAndDirectImports = new Dictionary<ComposedPart, IReadOnlyList<KeyValuePair<ImportDefinitionBinding, ComposedPart>>>();
		foreach (ComposedPart part in parts)
		{
			List<KeyValuePair<ImportDefinitionBinding, ComposedPart>> value = (from importAndExports in part.SatisfyingExports
				from export in importAndExports.Value
				let exportingPart = partByPartDefinition[export.PartDefinition]
				select new KeyValuePair<ImportDefinitionBinding, ComposedPart>(importAndExports.Key, exportingPart)).ToList();
			partsAndDirectImports.Add(part, value);
		}
		Func<Func<KeyValuePair<ImportDefinitionBinding, ComposedPart>, bool>, Func<ComposedPart, IEnumerable<ComposedPart>>> getDirectLinksWithFilter = (Func<KeyValuePair<ImportDefinitionBinding, ComposedPart>, bool> filter) => (ComposedPart part) => from ip in partsAndDirectImports[part].Where(filter)
			select ip.Value;
		HashSet<ComposedPart> visited = new HashSet<ComposedPart>();
		HashSet<ComposedPart> nonSharedPartsInLoops = new HashSet<ComposedPart>();
		foreach (ComposedPart key2 in partsAndDirectImports.Keys)
		{
			if (!nonSharedPartsInLoops.Contains(key2))
			{
				visited.Clear();
				ImmutableStack<ComposedPart> immutableStack = PathExistsBetween(key2, key2, getDirectLinksWithFilter((KeyValuePair<ImportDefinitionBinding, ComposedPart> ip) => !ip.Key.IsExportFactory && (!ip.Value.Definition.IsShared || PartCreationPolicyConstraint.IsNonSharedInstanceRequired(ip.Key.ImportDefinition))), visited);
				if (!immutableStack.IsEmpty)
				{
					immutableStack = immutableStack.Push(key2);
					nonSharedPartsInLoops.UnionWith(immutableStack);
					yield return new ComposedPartDiagnostic(immutableStack, Strings.LoopBetweenNonSharedParts);
				}
			}
		}
		Func<KeyValuePair<ImportDefinitionBinding, ComposedPart>, bool> importingConstructorFilter = (KeyValuePair<ImportDefinitionBinding, ComposedPart> ip) => !ip.Key.IsExportFactory && !ip.Key.IsLazy;
		foreach (KeyValuePair<ComposedPart, IReadOnlyList<KeyValuePair<ImportDefinitionBinding, ComposedPart>>> item in partsAndDirectImports)
		{
			ComposedPart importingPart = item.Key;
			foreach (KeyValuePair<ImportDefinitionBinding, ComposedPart> item2 in item.Value)
			{
				ImportDefinitionBinding key = item2.Key;
				ComposedPart value2 = item2.Value;
				if (!key.ImportingParameterRef.IsEmpty && importingConstructorFilter(item2))
				{
					visited.Clear();
					ImmutableStack<ComposedPart> immutableStack2 = PathExistsBetween(value2, importingPart, getDirectLinksWithFilter(importingConstructorFilter), visited);
					if (!immutableStack2.IsEmpty)
					{
						immutableStack2 = immutableStack2.Push(value2).Push(partByPartType[key.ComposablePartTypeRef]);
						yield return new ComposedPartDiagnostic(immutableStack2, Strings.LoopInvolvingImportingCtorArgumentAndAllNonLazyImports);
					}
				}
			}
		}
	}

	private static ImmutableDictionary<ComposablePartDefinition, string> ComputeInferredSharingBoundaries(IEnumerable<PartBuilder> partBuilders)
	{
		Requires.NotNull(partBuilders, "partBuilders");
		ImmutableDictionary<string, SharingBoundaryMetadata> sharingBoundariesAndMetadata = ComputeSharingBoundaryMetadata(partBuilders);
		ImmutableDictionary<ComposablePartDefinition, string>.Builder builder = ImmutableDictionary.CreateBuilder<ComposablePartDefinition, string>();
		foreach (PartBuilder partBuilder in partBuilders)
		{
			if (!partBuilder.PartDefinition.IsSharingBoundaryInferred)
			{
				continue;
			}
			List<string> list = (from boundary in partBuilder.RequiredSharingBoundaries
				let others = partBuilder.RequiredSharingBoundaries.ToImmutableHashSet().Remove(boundary)
				where !others.Any((string other) => sharingBoundariesAndMetadata[other].ParentBoundariesUnion.Contains(boundary))
				where others.All((string other) => sharingBoundariesAndMetadata[boundary].ParentBoundariesIntersection.Contains(other))
				select boundary).ToList();
			if (list.Count == 1)
			{
				builder.Add(partBuilder.PartDefinition, list[0]);
			}
			else if (list.Count > 1)
			{
				throw new CompositionFailedException(string.Format(CultureInfo.CurrentCulture, Strings.UnableToDeterminePrimarySharingBoundary, new object[1] { ReflectionHelpers.GetTypeName(partBuilder.PartDefinition.Type, genericTypeDefinition: false, evenNonPublic: true, null, null) }));
			}
		}
		return builder.ToImmutable();
	}

	private static ImmutableDictionary<string, SharingBoundaryMetadata> ComputeSharingBoundaryMetadata(IEnumerable<PartBuilder> partBuilders)
	{
		Requires.NotNull(partBuilders, "partBuilders");
		var enumerable = from partBuilder in partBuilders
			from import in partBuilder.PartDefinition.Imports
			from sharingBoundary in import.ImportDefinition.ExportFactorySharingBoundaries
			select new
			{
				ParentSharingBoundaries = partBuilder.RequiredSharingBoundaries,
				ChildSharingBoundary = sharingBoundary
			};
		ImmutableDictionary<string, SharingBoundaryMetadata>.Builder builder = ImmutableDictionary.CreateBuilder<string, SharingBoundaryMetadata>();
		foreach (var item in enumerable)
		{
			SharingBoundaryMetadata value = ((!builder.TryGetValue(item.ChildSharingBoundary, out var value2)) ? SharingBoundaryMetadata.InitialFactoryEncountered(item.ParentSharingBoundaries) : value2.AdditionalFactoryEncountered(item.ParentSharingBoundaries));
			builder[item.ChildSharingBoundary] = value;
		}
		return builder.ToImmutable();
	}

	public XDocument CreateDgml()
	{
		return CreateDgml(Parts);
	}

	private static XDocument CreateDgml(ISet<ComposedPart> parts)
	{
		Requires.NotNull(parts, "parts");
		XDocument xDocument = Dgml.Create(out var nodes, out var links, "Sugiyama", "RightToLeft").WithStyle("ExportFactory", new Dictionary<string, string> { { "StrokeDashArray", "2,2" } }, "Link").WithStyle("VsMEFBuiltIn", new Dictionary<string, string> { { "Visibility", "Hidden" } });
		foreach (string item in parts.Select((ComposedPart p) => p.Definition.SharingBoundary).Distinct())
		{
			if (!string.IsNullOrEmpty(item))
			{
				nodes.Add(Dgml.Node(item, item, "Expanded"));
			}
		}
		foreach (ComposedPart part in parts)
		{
			XElement xElement = Dgml.Node(part.Definition.Id, ReflectionHelpers.GetTypeName(part.Definition.Type, genericTypeDefinition: false, evenNonPublic: true, null, null));
			if (!string.IsNullOrEmpty(part.Definition.SharingBoundary))
			{
				xElement.ContainedBy(part.Definition.SharingBoundary, xDocument);
			}
			if (part.Definition.Metadata.TryGetValue<string[]>("VsMEFDgmlCategories", out var value))
			{
				xElement = xElement.WithCategories(value);
			}
			nodes.Add(xElement);
			foreach (ImportDefinitionBinding key in part.SatisfyingExports.Keys)
			{
				foreach (ExportDefinitionBinding item2 in part.SatisfyingExports[key])
				{
					string label = ((!item2.ExportedValueTypeRef.Equals(item2.PartDefinition.TypeRef)) ? item2.ExportedValueType.ToString() : null);
					XElement xElement2 = Dgml.Link(item2.PartDefinition.Id, part.Definition.Id, label);
					if (key.IsExportFactory)
					{
						xElement2 = xElement2.WithCategories("ExportFactory");
					}
					links.Add(xElement2);
				}
			}
		}
		return xDocument;
	}
}
