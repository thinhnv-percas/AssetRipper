using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.Hosting.Providers.ExportFactory;

internal class ExportFactoryExportDescriptorProvider : ExportDescriptorProvider
{
	private static readonly MethodInfo s_getExportFactoryDefinitionsMethod = typeof(ExportFactoryExportDescriptorProvider).GetTypeInfo().GetDeclaredMethod("GetExportFactoryDescriptors");

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract exportKey, DependencyAccessor definitionAccessor)
	{
		if (!exportKey.ContractType.IsConstructedGenericType || (object)exportKey.ContractType.GetGenericTypeDefinition() != typeof(ExportFactory<>))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		MethodInfo methodInfo = s_getExportFactoryDefinitionsMethod.MakeGenericMethod(exportKey.ContractType.GenericTypeArguments[0]);
		Func<CompositionContract, DependencyAccessor, object> func = methodInfo.CreateStaticDelegate<Func<CompositionContract, DependencyAccessor, object>>();
		return (ExportDescriptorPromise[])func(exportKey, definitionAccessor);
	}

	private static ExportDescriptorPromise[] GetExportFactoryDescriptors<TProduct>(CompositionContract exportFactoryContract, DependencyAccessor definitionAccessor)
	{
		CompositionContract contract = exportFactoryContract.ChangeType(typeof(TProduct));
		string[] boundaries = EmptyArray<string>.Value;
		if (exportFactoryContract.TryUnwrapMetadataConstraint<IEnumerable<string>>("SharingBoundaryNames", out var constraintValue, out var remainingContract))
		{
			contract = remainingContract.ChangeType(typeof(TProduct));
			boundaries = (constraintValue ?? EmptyArray<string>.Value).ToArray();
		}
		return (from d in definitionAccessor.ResolveDependencies("product", contract, isPrerequisite: false)
			select new ExportDescriptorPromise(exportFactoryContract, Formatters.Format(typeof(ExportFactory<TProduct>)), isShared: false, () => new CompositionDependency[1] { d }, delegate
			{
				ExportDescriptor descriptor = d.Target.GetDescriptor();
				CompositeActivator da = descriptor.Activator;
				return ExportDescriptor.Create((LifetimeContext c, CompositionOperation o) => new ExportFactory<TProduct>(delegate
				{
					LifetimeContext lifetimeContext = new LifetimeContext(c, boundaries);
					return Tuple.Create<TProduct, Action>((TProduct)CompositionOperation.Run(lifetimeContext, da), lifetimeContext.Dispose);
				}), descriptor.Metadata);
			})).ToArray();
	}
}
