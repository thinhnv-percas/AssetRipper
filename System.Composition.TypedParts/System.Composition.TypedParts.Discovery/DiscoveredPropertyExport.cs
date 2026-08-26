using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Composition.TypedParts.Discovery;

internal class DiscoveredPropertyExport : DiscoveredExport
{
	private static readonly MethodInfo s_activatorInvoke = typeof(CompositeActivator).GetRuntimeMethod("Invoke", new Type[2]
	{
		typeof(LifetimeContext),
		typeof(CompositionOperation)
	});

	private readonly PropertyInfo _property;

	public DiscoveredPropertyExport(CompositionContract contract, IDictionary<string, object> metadata, PropertyInfo property)
		: base(contract, metadata)
	{
		_property = property;
	}

	protected override ExportDescriptor GetExportDescriptor(CompositeActivator partActivator)
	{
		ParameterExpression[] array = new ParameterExpression[2]
		{
			Expression.Parameter(typeof(LifetimeContext)),
			Expression.Parameter(typeof(CompositionOperation))
		};
		Expression<CompositeActivator> expression = Expression.Lambda<CompositeActivator>(Expression.Property(Expression.Convert(Expression.Call(Expression.Constant(partActivator), s_activatorInvoke, array), _property.DeclaringType), _property), array);
		return ExportDescriptor.Create(expression.Compile(), base.Metadata);
	}

	public override DiscoveredExport CloseGenericExport(TypeInfo closedPartType, Type[] genericArguments)
	{
		Type newContractType = base.Contract.ContractType.MakeGenericType(genericArguments);
		CompositionContract contract = base.Contract.ChangeType(newContractType);
		PropertyInfo runtimeProperty = closedPartType.AsType().GetRuntimeProperty(_property.Name);
		return new DiscoveredPropertyExport(contract, base.Metadata, runtimeProperty);
	}
}
