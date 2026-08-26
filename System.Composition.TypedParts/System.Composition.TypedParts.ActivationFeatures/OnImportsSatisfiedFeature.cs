using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Composition.Properties;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Composition.TypedParts.ActivationFeatures;

internal class OnImportsSatisfiedFeature : ActivationFeature
{
	private readonly AttributedModelProvider _attributeContext;

	public OnImportsSatisfiedFeature(AttributedModelProvider attributeContext)
	{
		if (attributeContext == null)
		{
			throw new ArgumentNullException("attributeContext");
		}
		_attributeContext = attributeContext;
	}

	public override CompositeActivator RewriteActivator(TypeInfo partType, CompositeActivator activator, IDictionary<string, object> partMetadata, IEnumerable<CompositionDependency> dependencies)
	{
		CompositeActivator compositeActivator = activator;
		Type type = partType.AsType();
		IEnumerable<MethodInfo> enumerable = from mi in type.GetRuntimeMethods()
			where _attributeContext.GetDeclaredAttribute<OnImportsSatisfiedAttribute>(mi.DeclaringType, mi) != null
			select mi;
		foreach (MethodInfo item in enumerable)
		{
			if (((!item.IsPublic && !item.IsAssembly) | item.IsStatic) || (object)item.ReturnType != typeof(void) || item.IsGenericMethodDefinition || item.GetParameters().Length != 0)
			{
				string message = string.Format(System.Composition.Properties.Resources.OnImportsSatisfiedFeature_AttributeError, new object[2] { partType, item.Name });
				throw new CompositionFailedException(message);
			}
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "ois");
			Action<object> call = Expression.Lambda<Action<object>>(Expression.Call(Expression.Convert(parameterExpression, partType.AsType()), item), new ParameterExpression[1] { parameterExpression }).Compile();
			CompositeActivator prev = compositeActivator;
			compositeActivator = delegate(LifetimeContext c, CompositionOperation o)
			{
				object psn = prev(c, o);
				o.AddPostCompositionAction(delegate
				{
					call(psn);
				});
				return psn;
			};
		}
		return compositeActivator;
	}
}
