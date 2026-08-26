using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Reflection;

namespace System.Composition.Hosting.Providers.ImportMany;

internal class ImportManyExportDescriptorProvider : ExportDescriptorProvider
{
	private static readonly MethodInfo s_getImportManyDefinitionMethod = typeof(ImportManyExportDescriptorProvider).GetTypeInfo().GetDeclaredMethod("GetImportManyDescriptor");

	private static readonly Type[] s_supportedContractTypes = new Type[3]
	{
		typeof(IList<>),
		typeof(ICollection<>),
		typeof(IEnumerable<>)
	};

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract contract, DependencyAccessor definitionAccessor)
	{
		if (!contract.ContractType.IsArray && (!contract.ContractType.IsConstructedGenericType || !s_supportedContractTypes.Contains(contract.ContractType.GetGenericTypeDefinition())))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		if (!contract.TryUnwrapMetadataConstraint<bool>("IsImportMany", out var _, out var remainingContract))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		Type type = (contract.ContractType.IsArray ? contract.ContractType.GetElementType() : contract.ContractType.GenericTypeArguments[0]);
		CompositionContract arg = remainingContract.ChangeType(type);
		MethodInfo methodInfo = s_getImportManyDefinitionMethod.MakeGenericMethod(type);
		Func<CompositionContract, CompositionContract, DependencyAccessor, object> func = methodInfo.CreateStaticDelegate<Func<CompositionContract, CompositionContract, DependencyAccessor, object>>();
		return new ExportDescriptorPromise[1] { (ExportDescriptorPromise)func(contract, arg, definitionAccessor) };
	}

	private static ExportDescriptorPromise GetImportManyDescriptor<TElement>(CompositionContract importManyContract, CompositionContract elementContract, DependencyAccessor definitionAccessor)
	{
		return new ExportDescriptorPromise(importManyContract, typeof(TElement[]).Name, isShared: false, () => definitionAccessor.ResolveDependencies("item", elementContract, isPrerequisite: true), delegate(IEnumerable<CompositionDependency> d)
		{
			ExportDescriptor[] dependentDescriptors = d.Select((CompositionDependency el) => el.Target.GetDescriptor()).ToArray();
			return ExportDescriptor.Create((LifetimeContext c, CompositionOperation o) => dependentDescriptors.Select((ExportDescriptor e) => (TElement)e.Activator(c, o)).ToArray(), ExportDescriptorProvider.NoMetadata);
		});
	}
}
