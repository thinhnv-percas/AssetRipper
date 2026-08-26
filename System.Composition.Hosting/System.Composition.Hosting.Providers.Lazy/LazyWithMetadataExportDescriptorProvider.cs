using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Providers.Metadata;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Reflection;

namespace System.Composition.Hosting.Providers.Lazy;

internal class LazyWithMetadataExportDescriptorProvider : ExportDescriptorProvider
{
	private static readonly MethodInfo s_getLazyDefinitionsMethod = typeof(LazyWithMetadataExportDescriptorProvider).GetTypeInfo().GetDeclaredMethod("GetLazyDefinitions");

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract exportKey, DependencyAccessor definitionAccessor)
	{
		if (!exportKey.ContractType.IsConstructedGenericType || (object)exportKey.ContractType.GetGenericTypeDefinition() != typeof(System.Lazy<, >))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		Type[] genericTypeArguments = exportKey.ContractType.GenericTypeArguments;
		MethodInfo methodInfo = s_getLazyDefinitionsMethod.MakeGenericMethod(genericTypeArguments[0], genericTypeArguments[1]);
		Func<CompositionContract, DependencyAccessor, object> func = methodInfo.CreateStaticDelegate<Func<CompositionContract, DependencyAccessor, object>>();
		return (ExportDescriptorPromise[])func(exportKey, definitionAccessor);
	}

	private static ExportDescriptorPromise[] GetLazyDefinitions<TValue, TMetadata>(CompositionContract lazyContract, DependencyAccessor definitionAccessor)
	{
		Func<IDictionary<string, object>, TMetadata> metadataProvider = MetadataViewProvider.GetMetadataViewProvider<TMetadata>();
		return (from d in definitionAccessor.ResolveDependencies("value", lazyContract.ChangeType(typeof(TValue)), isPrerequisite: false)
			select new ExportDescriptorPromise(lazyContract, Formatters.Format(typeof(System.Lazy<TValue, TMetadata>)), isShared: false, () => new CompositionDependency[1] { d }, delegate
			{
				ExportDescriptor dsc = d.Target.GetDescriptor();
				CompositeActivator da = dsc.Activator;
				return ExportDescriptor.Create((LifetimeContext c, CompositionOperation o) => new System.Lazy<TValue, TMetadata>(() => (TValue)CompositionOperation.Run(c, da), metadataProvider(dsc.Metadata)), dsc.Metadata);
			})).ToArray();
	}
}
