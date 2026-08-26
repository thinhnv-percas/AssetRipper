using System;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class VersionOptionAttributeConvention : OptionAttributeConventionBase<VersionOptionAttribute>, IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		VersionOptionAttribute customAttribute = context.ModelType.GetTypeInfo().GetCustomAttribute<VersionOptionAttribute>();
		customAttribute?.Configure(context.Application);
		PropertyInfo[] properties = ReflectionHelper.GetProperties(context.ModelType);
		VersionOptionAttribute versionOptionAttribute = null;
		PropertyInfo prop = null;
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			VersionOptionAttribute customAttribute2 = propertyInfo.GetCustomAttribute<VersionOptionAttribute>();
			if (customAttribute2 != null)
			{
				if (versionOptionAttribute != null)
				{
					throw new InvalidOperationException("Multiple VersionOptionAttributes found. VersionOptionAttribute should only be used on one property per type.");
				}
				if (customAttribute != null)
				{
					throw new InvalidOperationException("Multiple VersionOptionAttributes found. VersionOptionAttribute should only be used one per type, either on one property or on the type.");
				}
				versionOptionAttribute = customAttribute2;
				prop = propertyInfo;
				EnsureDoesNotHaveOptionAttribute(propertyInfo);
				EnsureDoesNotHaveHelpOptionAttribute(propertyInfo);
				OptionAttributeConventionBase<VersionOptionAttribute>.EnsureDoesNotHaveArgumentAttribute(propertyInfo);
			}
		}
		if (versionOptionAttribute != null)
		{
			CommandOption option = versionOptionAttribute.Configure(context.Application);
			AddOption(context, option, prop);
		}
	}

	private static void EnsureDoesNotHaveOptionAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<OptionAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothOptionAndVersionOptionAttributesCannotBeSpecified(prop));
		}
	}

	private static void EnsureDoesNotHaveHelpOptionAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<HelpOptionAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothHelpOptionAndVersionOptionAttributesCannotBeSpecified(prop));
		}
	}
}
