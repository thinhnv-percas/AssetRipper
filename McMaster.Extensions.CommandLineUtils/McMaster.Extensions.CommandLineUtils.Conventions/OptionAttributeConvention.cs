using System;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class OptionAttributeConvention : OptionAttributeConventionBase<OptionAttribute>, IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		PropertyInfo[] properties = ReflectionHelper.GetProperties(context.ModelType);
		foreach (PropertyInfo propertyInfo in properties)
		{
			OptionAttribute customAttribute = propertyInfo.GetCustomAttribute<OptionAttribute>();
			if (customAttribute != null)
			{
				EnsureDoesNotHaveHelpOptionAttribute(propertyInfo);
				EnsureDoesNotHaveVersionOptionAttribute(propertyInfo);
				OptionAttributeConventionBase<OptionAttribute>.EnsureDoesNotHaveArgumentAttribute(propertyInfo);
				CommandOption option = customAttribute.Configure(context.Application, propertyInfo);
				AddOption(context, option, propertyInfo);
			}
		}
	}

	private static void EnsureDoesNotHaveVersionOptionAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<VersionOptionAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothHelpOptionAndVersionOptionAttributesCannotBeSpecified(prop));
		}
	}

	private static void EnsureDoesNotHaveHelpOptionAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<VersionOptionAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothHelpOptionAndVersionOptionAttributesCannotBeSpecified(prop));
		}
	}
}
