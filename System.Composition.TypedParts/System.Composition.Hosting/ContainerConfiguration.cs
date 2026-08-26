using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Debugging;
using System.Composition.Hosting.Core;
using System.Composition.Properties;
using System.Composition.TypedParts;
using System.Composition.TypedParts.Util;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace System.Composition.Hosting;

[DebuggerTypeProxy(typeof(ContainerConfigurationDebuggerProxy))]
public class ContainerConfiguration
{
	private AttributedModelProvider _defaultAttributeContext;

	private readonly IList<ExportDescriptorProvider> _addedSources = new List<ExportDescriptorProvider>();

	private readonly IList<Tuple<IEnumerable<Type>, AttributedModelProvider>> _types = new List<Tuple<IEnumerable<Type>, AttributedModelProvider>>();

	public CompositionHost CreateContainer()
	{
		List<ExportDescriptorProvider> list = _addedSources.ToList();
		foreach (Tuple<IEnumerable<Type>, AttributedModelProvider> type in _types)
		{
			AttributedModelProvider attributeContext = type.Item2 ?? _defaultAttributeContext ?? new DirectAttributeContext();
			list.Add(new TypedPartExportDescriptorProvider(type.Item1, attributeContext));
		}
		return CompositionHost.CreateCompositionHost(list.ToArray());
	}

	public ContainerConfiguration WithProvider(ExportDescriptorProvider exportDescriptorProvider)
	{
		if (exportDescriptorProvider == null)
		{
			throw new ArgumentNullException("exportDescriptorProvider");
		}
		_addedSources.Add(exportDescriptorProvider);
		return this;
	}

	public ContainerConfiguration WithDefaultConventions(AttributedModelProvider conventions)
	{
		if (conventions == null)
		{
			throw new ArgumentNullException("conventions");
		}
		if (_defaultAttributeContext != null)
		{
			throw new InvalidOperationException(System.Composition.Properties.Resources.ContainerConfiguration_DefaultConventionSet);
		}
		_defaultAttributeContext = conventions;
		return this;
	}

	public ContainerConfiguration WithPart(Type partType)
	{
		return WithPart(partType, null);
	}

	public ContainerConfiguration WithPart(Type partType, AttributedModelProvider conventions)
	{
		if ((object)partType == null)
		{
			throw new ArgumentNullException("partType");
		}
		return WithParts(new Type[1] { partType }, conventions);
	}

	public ContainerConfiguration WithPart<TPart>()
	{
		return WithPart<TPart>(null);
	}

	public ContainerConfiguration WithPart<TPart>(AttributedModelProvider conventions)
	{
		return WithPart(typeof(TPart), conventions);
	}

	public ContainerConfiguration WithParts(params Type[] partTypes)
	{
		return WithParts((IEnumerable<Type>)partTypes);
	}

	public ContainerConfiguration WithParts(IEnumerable<Type> partTypes)
	{
		return WithParts(partTypes, null);
	}

	public ContainerConfiguration WithParts(IEnumerable<Type> partTypes, AttributedModelProvider conventions)
	{
		if (partTypes == null)
		{
			throw new ArgumentNullException("partTypes");
		}
		_types.Add(Tuple.Create(partTypes, conventions));
		return this;
	}

	public ContainerConfiguration WithAssembly(Assembly assembly)
	{
		return WithAssembly(assembly, null);
	}

	public ContainerConfiguration WithAssembly(Assembly assembly, AttributedModelProvider conventions)
	{
		return WithAssemblies(new Assembly[1] { assembly }, conventions);
	}

	public ContainerConfiguration WithAssemblies(IEnumerable<Assembly> assemblies)
	{
		return WithAssemblies(assemblies, null);
	}

	public ContainerConfiguration WithAssemblies(IEnumerable<Assembly> assemblies, AttributedModelProvider conventions)
	{
		if (assemblies == null)
		{
			throw new ArgumentNullException("assemblies");
		}
		return WithParts(assemblies.SelectMany((Assembly a) => a.DefinedTypes.Select((TypeInfo dt) => dt.AsType())), conventions);
	}

	internal ExportDescriptorProvider[] DebugGetAddedExportDescriptorProviders()
	{
		return _addedSources.ToArray();
	}

	internal Tuple<IEnumerable<Type>, AttributedModelProvider>[] DebugGetRegisteredTypes()
	{
		return _types.ToArray();
	}

	internal AttributedModelProvider DebugGetDefaultAttributeContext()
	{
		return _defaultAttributeContext;
	}
}
