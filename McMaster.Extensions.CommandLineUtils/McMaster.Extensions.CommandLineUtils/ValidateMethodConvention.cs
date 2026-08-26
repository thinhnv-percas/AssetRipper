using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Conventions;

namespace McMaster.Extensions.CommandLineUtils;

public class ValidateMethodConvention : IConvention
{
	public void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		MethodInfo method = context.ModelType.GetTypeInfo().GetMethod("OnValidate", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		if (method == null)
		{
			return;
		}
		if (method.ReturnType != typeof(ValidationResult))
		{
			throw new InvalidOperationException(Strings.InvalidOnValidateReturnType(context.ModelType));
		}
		IModelAccessor accessor = context.ModelAccessor;
		ParameterInfo[] methodParams = method.GetParameters();
		context.Application.OnValidate(delegate(ValidationContext ctx)
		{
			object[] array = new object[methodParams.Length];
			for (int i = 0; i < methodParams.Length; i++)
			{
				ParameterInfo parameterInfo = methodParams[i];
				if (typeof(ValidationContext).GetTypeInfo().IsAssignableFrom(parameterInfo.ParameterType))
				{
					array[i] = ctx;
				}
				else
				{
					if (!typeof(CommandLineContext).GetTypeInfo().IsAssignableFrom(parameterInfo.ParameterType))
					{
						throw new InvalidOperationException(Strings.UnsupportedParameterTypeOnMethod(method.Name, parameterInfo));
					}
					array[i] = context.Application._context;
				}
			}
			return (ValidationResult)method.Invoke(accessor.GetModel(), array);
		});
	}
}
