using System;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class HelpOptionAttributeConvention : OptionAttributeConventionBase<HelpOptionAttribute>, IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		HelpOptionAttribute customAttribute = context.ModelType.GetTypeInfo().GetCustomAttribute<HelpOptionAttribute>();
		customAttribute?.Configure(context.Application);
		PropertyInfo[] properties = ReflectionHelper.GetProperties(context.ModelType);
		HelpOptionAttribute helpOptionAttribute = null;
		PropertyInfo prop = null;
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			HelpOptionAttribute customAttribute2 = propertyInfo.GetCustomAttribute<HelpOptionAttribute>();
			if (customAttribute2 != null)
			{
				if (helpOptionAttribute != null)
				{
					throw new InvalidOperationException("Multiple HelpOptionAttributes found. HelpOptionAttribute should only be used on one property per type.");
				}
				if (customAttribute != null)
				{
					throw new InvalidOperationException("Multiple HelpOptionAttributes found. HelpOptionAttribute should only be used one per type, either on one property or on the type.");
				}
				helpOptionAttribute = customAttribute2;
				prop = propertyInfo;
				EnsureDoesNotHaveVersionOptionAttribute(propertyInfo);
				EnsureDoesNotHaveOptionAttribute(propertyInfo);
				OptionAttributeConventionBase<HelpOptionAttribute>.EnsureDoesNotHaveArgumentAttribute(propertyInfo);
			}
		}
		if (helpOptionAttribute != null)
		{
			CommandOption option = helpOptionAttribute.Configure(context.Application);
			AddOption(context, option, prop);
		}
	}

	private static void EnsureDoesNotHaveOptionAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<OptionAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothOptionAndHelpOptionAttributesCannotBeSpecified(prop));
		}
	}

	private static void EnsureDoesNotHaveVersionOptionAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<VersionOptionAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothHelpOptionAndVersionOptionAttributesCannotBeSpecified(prop));
		}
	}
}
