using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Reflection;

namespace System.Composition.Hosting.Providers.Lazy;

internal class LazyExportDescriptorProvider : ExportDescriptorProvider
{
	private static readonly MethodInfo s_getLazyDefinitionsMethod = typeof(LazyExportDescriptorProvider).GetTypeInfo().GetDeclaredMethod("GetLazyDefinitions");

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract exportKey, DependencyAccessor definitionAccessor)
	{
		if (!exportKey.ContractType.IsConstructedGenericType || (object)exportKey.ContractType.GetGenericTypeDefinition() != typeof(Lazy<>))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		MethodInfo methodInfo = s_getLazyDefinitionsMethod.MakeGenericMethod(exportKey.ContractType.GenericTypeArguments[0]);
		Func<CompositionContract, DependencyAccessor, object> func = methodInfo.CreateStaticDelegate<Func<CompositionContract, DependencyAccessor, object>>();
		return (ExportDescriptorPromise[])func(exportKey, definitionAccessor);
	}

	private static ExportDescriptorPromise[] GetLazyDefinitions<TValue>(CompositionContract lazyContract, DependencyAccessor definitionAccessor)
	{
		return (from d in definitionAccessor.ResolveDependencies("value", lazyContract.ChangeType(typeof(TValue)), isPrerequisite: false)
			select new ExportDescriptorPromise(lazyContract, Formatters.Format(typeof(Lazy<TValue>)), isShared: false, () => new CompositionDependency[1] { d }, delegate
			{
				ExportDescriptor descriptor = d.Target.GetDescriptor();
				CompositeActivator da = descriptor.Activator;
				return ExportDescriptor.Create((LifetimeContext c, CompositionOperation o) => new Lazy<TValue>(() => (TValue)CompositionOperation.Run(c, da)), descriptor.Metadata);
			})).ToArray();
	}
}
