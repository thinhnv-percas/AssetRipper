using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Providers.Metadata;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.Hosting.Providers.ExportFactory;

internal class ExportFactoryWithMetadataExportDescriptorProvider : ExportDescriptorProvider
{
	private static readonly MethodInfo s_getLazyDefinitionsMethod = typeof(ExportFactoryWithMetadataExportDescriptorProvider).GetTypeInfo().GetDeclaredMethod("GetExportFactoryDescriptors");

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract contract, DependencyAccessor definitionAccessor)
	{
		if (!contract.ContractType.GetTypeInfo().IsGenericType || (object)contract.ContractType.GetGenericTypeDefinition() != typeof(ExportFactory<, >))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		Type[] genericTypeArguments = contract.ContractType.GenericTypeArguments;
		MethodInfo methodInfo = s_getLazyDefinitionsMethod.MakeGenericMethod(genericTypeArguments[0], genericTypeArguments[1]);
		Func<CompositionContract, DependencyAccessor, object> func = methodInfo.CreateStaticDelegate<Func<CompositionContract, DependencyAccessor, object>>();
		return (ExportDescriptorPromise[])func(contract, definitionAccessor);
	}

	private static ExportDescriptorPromise[] GetExportFactoryDescriptors<TProduct, TMetadata>(CompositionContract exportFactoryContract, DependencyAccessor definitionAccessor)
	{
		CompositionContract contract = exportFactoryContract.ChangeType(typeof(TProduct));
		string[] boundaries = EmptyArray<string>.Value;
		if (exportFactoryContract.TryUnwrapMetadataConstraint<IEnumerable<string>>("SharingBoundaryNames", out var constraintValue, out var remainingContract))
		{
			contract = remainingContract.ChangeType(typeof(TProduct));
			boundaries = (constraintValue ?? EmptyArray<string>.Value).ToArray();
		}
		Func<IDictionary<string, object>, TMetadata> metadataProvider = MetadataViewProvider.GetMetadataViewProvider<TMetadata>();
		return (from d in definitionAccessor.ResolveDependencies("product", contract, isPrerequisite: false)
			select new ExportDescriptorPromise(exportFactoryContract, typeof(ExportFactory<TProduct, TMetadata>).Name, isShared: false, () => new CompositionDependency[1] { d }, delegate
			{
				ExportDescriptor dsc = d.Target.GetDescriptor();
				return ExportDescriptor.Create((LifetimeContext c, CompositionOperation o) => new ExportFactory<TProduct, TMetadata>(delegate
				{
					LifetimeContext lifetimeContext = new LifetimeContext(c, boundaries);
					return Tuple.Create<TProduct, Action>((TProduct)CompositionOperation.Run(lifetimeContext, dsc.Activator), lifetimeContext.Dispose);
				}, metadataProvider(dsc.Metadata)), dsc.Metadata);
			})).ToArray();
	}
}
