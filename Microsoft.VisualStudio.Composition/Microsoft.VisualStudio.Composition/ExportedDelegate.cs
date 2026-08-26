using System;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class ExportedDelegate
{
	private readonly object target;

	private readonly MethodInfo method;

	public ExportedDelegate(object target, MethodInfo method)
	{
		Requires.NotNull(method, "method");
		this.target = target;
		this.method = method;
	}

	public Delegate CreateDelegate(Type delegateType)
	{
		Requires.NotNull(delegateType, "delegateType");
		if (delegateType == typeof(Delegate) || delegateType == typeof(MulticastDelegate))
		{
			delegateType = ReflectionHelpers.GetContractTypeForDelegate(method);
		}
		try
		{
			return method.CreateDelegate(delegateType, target);
		}
		catch (ArgumentException)
		{
			return null;
		}
	}
}
