using System;
using System.Collections.Generic;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class RemainingArgsPropertyConvention : IConvention
{
	private const BindingFlags PropertyBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		TypeInfo typeInfo = context.ModelType.GetTypeInfo();
		PropertyInfo property = typeInfo.GetProperty("RemainingArguments", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		property = property ?? typeInfo.GetProperty("RemainingArgs", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		if (property == null)
		{
			return;
		}
		SetPropertyDelegate setter = ReflectionHelper.GetPropertySetter(property);
		if (property.PropertyType == typeof(string[]))
		{
			context.Application.OnParsingComplete(delegate(ParseResult r)
			{
				setter(context.ModelAccessor.GetModel(), r.SelectedCommand.RemainingArguments.ToArray());
			});
			return;
		}
		if (!typeof(IReadOnlyList<string>).GetTypeInfo().IsAssignableFrom(property.PropertyType))
		{
			throw new InvalidOperationException(Strings.RemainingArgsPropsIsUnassignable(typeInfo));
		}
		context.Application.OnParsingComplete(delegate(ParseResult r)
		{
			setter(context.ModelAccessor.GetModel(), r.SelectedCommand.RemainingArguments);
		});
	}
}
