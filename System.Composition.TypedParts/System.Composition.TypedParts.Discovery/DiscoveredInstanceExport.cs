using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Reflection;

namespace System.Composition.TypedParts.Discovery;

internal class DiscoveredInstanceExport : DiscoveredExport
{
	public DiscoveredInstanceExport(CompositionContract contract, IDictionary<string, object> metadata)
		: base(contract, metadata)
	{
	}

	protected override ExportDescriptor GetExportDescriptor(CompositeActivator partActivator)
	{
		return ExportDescriptor.Create(partActivator, base.Metadata);
	}

	public override DiscoveredExport CloseGenericExport(TypeInfo closedPartType, Type[] genericArguments)
	{
		Type newContractType = base.Contract.ContractType.MakeGenericType(genericArguments);
		CompositionContract contract = base.Contract.ChangeType(newContractType);
		return new DiscoveredInstanceExport(contract, base.Metadata);
	}
}
