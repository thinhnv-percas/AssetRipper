using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting.Core;
using System.Composition.TypedParts.ActivationFeatures;
using System.Composition.TypedParts.Discovery;
using System.Linq;
using System.Reflection;

namespace System.Composition.TypedParts;

internal class TypedPartExportDescriptorProvider : ExportDescriptorProvider
{
	private readonly IDictionary<CompositionContract, ICollection<DiscoveredExport>> _discoveredParts = new Dictionary<CompositionContract, ICollection<DiscoveredExport>>();

	public TypedPartExportDescriptorProvider(IEnumerable<Type> types, AttributedModelProvider attributeContext)
	{
		ActivationFeature[] activationFeatures = CreateActivationFeatures(attributeContext);
		TypeInspector typeInspector = new TypeInspector(attributeContext, activationFeatures);
		foreach (Type type in types)
		{
			if (typeInspector.InspectTypeForPart(type.GetTypeInfo(), out var part))
			{
				AddDiscoveredPart(part);
			}
		}
	}

	private void AddDiscoveredPart(DiscoveredPart part)
	{
		foreach (DiscoveredExport discoveredExport in part.DiscoveredExports)
		{
			AddDiscoveredExport(discoveredExport);
		}
	}

	private void AddDiscoveredExport(DiscoveredExport export, CompositionContract contract = null)
	{
		CompositionContract key = contract ?? export.Contract;
		if (!_discoveredParts.TryGetValue(key, out var value))
		{
			value = new List<DiscoveredExport>();
			_discoveredParts.Add(key, value);
		}
		value.Add(export);
	}

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract contract, DependencyAccessor definitionAccessor)
	{
		DiscoverGenericParts(contract);
		DiscoverConstrainedParts(contract);
		if (!_discoveredParts.TryGetValue(contract, out var value))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		if (!value.Any((DiscoveredExport x) => x.Metadata.Any()))
		{
			_discoveredParts.Remove(contract);
		}
		return value.Select((DiscoveredExport de) => de.GetExportDescriptorPromise(contract, definitionAccessor)).ToArray();
	}

	private void DiscoverConstrainedParts(CompositionContract contract)
	{
		if (contract.MetadataConstraints == null)
		{
			return;
		}
		CompositionContract compositionContract = new CompositionContract(contract.ContractType, contract.ContractName);
		DiscoverGenericParts(compositionContract);
		if (!_discoveredParts.TryGetValue(compositionContract, out var value))
		{
			return;
		}
		foreach (DiscoveredExport export in value)
		{
			Dictionary<string, object> dictionary = contract.MetadataConstraints.Where((KeyValuePair<string, object> c) => export.Metadata.ContainsKey(c.Key)).ToDictionary((KeyValuePair<string, object> c) => c.Key, (KeyValuePair<string, object> c) => export.Metadata[c.Key]);
			if (dictionary.Count != 0)
			{
				CompositionContract compositionContract2 = new CompositionContract(compositionContract.ContractType, compositionContract.ContractName, dictionary);
				if (compositionContract2.Equals(contract))
				{
					AddDiscoveredExport(export, contract);
				}
			}
		}
	}

	private void DiscoverGenericParts(CompositionContract contract)
	{
		if (!contract.ContractType.IsConstructedGenericType)
		{
			return;
		}
		Type genericTypeDefinition = contract.ContractType.GetGenericTypeDefinition();
		CompositionContract key = contract.ChangeType(genericTypeDefinition);
		if (!_discoveredParts.TryGetValue(key, out var value))
		{
			return;
		}
		Type[] genericTypeArguments = contract.ContractType.GenericTypeArguments;
		foreach (DiscoveredExport item in value)
		{
			if (item.Part.TryCloseGenericPart(genericTypeArguments, out var closed))
			{
				AddDiscoveredPart(closed);
			}
		}
	}

	private static ActivationFeature[] CreateActivationFeatures(AttributedModelProvider attributeContext)
	{
		return new ActivationFeature[4]
		{
			new DisposalFeature(),
			new PropertyInjectionFeature(attributeContext),
			new OnImportsSatisfiedFeature(attributeContext),
			new LifetimeFeature()
		};
	}

	internal static ActivationFeature[] DebugGetActivationFeatures(AttributedModelProvider attributeContext)
	{
		return CreateActivationFeatures(attributeContext);
	}
}
