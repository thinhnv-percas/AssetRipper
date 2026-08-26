using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class ValidationErrorMethodConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		MethodInfo method = context.ModelType.GetTypeInfo().GetMethod("OnValidationError", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		if (!(method == null))
		{
			IModelAccessor accessor = context.ModelAccessor;
			context.Application.ValidationErrorHandler = delegate
			{
				object[] parameters = ReflectionHelper.BindParameters(method, context.Application);
				object obj = method.Invoke(accessor.GetModel(), parameters);
				return (!(method.ReturnType == typeof(int))) ? 1 : ((int)obj);
			};
		}
	}
}
