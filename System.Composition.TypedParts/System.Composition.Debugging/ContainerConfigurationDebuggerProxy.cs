using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Composition.TypedParts;
using System.Composition.TypedParts.ActivationFeatures;
using System.Composition.TypedParts.Discovery;
using System.Composition.TypedParts.Util;
using System.Diagnostics;
using System.Reflection;

namespace System.Composition.Debugging;

internal class ContainerConfigurationDebuggerProxy
{
	private readonly ContainerConfiguration _configuration;

	private DiscoveredPart[] _discoveredParts;

	private Type[] _ignoredTypes;

	[DebuggerDisplay("Added Providers")]
	public ExportDescriptorProvider[] AddedExportDescriptorProviders => _configuration.DebugGetAddedExportDescriptorProviders();

	[DebuggerDisplay("Discovered Parts")]
	public DiscoveredPart[] DiscoveredParts
	{
		get
		{
			InitDiscovery();
			return _discoveredParts;
		}
	}

	[DebuggerDisplay("Ignored Types")]
	public Type[] IgnoredTypes
	{
		get
		{
			InitDiscovery();
			return _ignoredTypes;
		}
	}

	public ContainerConfigurationDebuggerProxy(ContainerConfiguration configuration)
	{
		_configuration = configuration;
	}

	private void InitDiscovery()
	{
		if (_discoveredParts != null)
		{
			return;
		}
		Tuple<IEnumerable<Type>, AttributedModelProvider>[] array = _configuration.DebugGetRegisteredTypes();
		AttributedModelProvider attributedModelProvider = _configuration.DebugGetDefaultAttributeContext() ?? new DirectAttributeContext();
		List<DiscoveredPart> list = new List<DiscoveredPart>();
		List<Type> list2 = new List<Type>();
		Tuple<IEnumerable<Type>, AttributedModelProvider>[] array2 = array;
		foreach (Tuple<IEnumerable<Type>, AttributedModelProvider> tuple in array2)
		{
			AttributedModelProvider attributeContext = tuple.Item2 ?? attributedModelProvider;
			ActivationFeature[] activationFeatures = TypedPartExportDescriptorProvider.DebugGetActivationFeatures(attributeContext);
			TypeInspector typeInspector = new TypeInspector(attributeContext, activationFeatures);
			foreach (Type item in tuple.Item1)
			{
				if (typeInspector.InspectTypeForPart(item.GetTypeInfo(), out var part))
				{
					list.Add(part);
				}
				else
				{
					list2.Add(item);
				}
			}
		}
		_discoveredParts = list.ToArray();
		_ignoredTypes = list2.ToArray();
	}
}
