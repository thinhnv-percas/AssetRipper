using System;
using McMaster.Extensions.CommandLineUtils.Conventions;

namespace McMaster.Extensions.CommandLineUtils;

public static class ConventionBuilderExtensions
{
	public static IConventionBuilder UseDefaultConventions(this IConventionBuilder builder)
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		return builder.UseAttributes().SetAppNameFromEntryAssembly().SetRemainingArgsPropertyOnModel()
			.SetSubcommandPropertyOnModel()
			.SetParentPropertyOnModel()
			.UseOnExecuteMethodFromModel()
			.UseOnValidateMethodFromModel()
			.UseOnValidationErrorMethodFromModel()
			.UseConstructorInjection()
			.UseDefaultHelpOption()
			.UseCommandNameFromModelType();
	}

	public static IConventionBuilder UseDefaultHelpOption(this IConventionBuilder builder, string template = "-?|-h|--help")
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		return builder.AddConvention(new DefaultHelpOptionConvention(template));
	}

	public static IConventionBuilder UseAttributes(this IConventionBuilder builder)
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		return builder.AddConvention(new AttributeConvention()).UseCommandAttribute().UseVersionOptionFromMemberAttribute()
			.UseVersionOptionAttribute()
			.UseHelpOptionAttribute()
			.UseOptionAttributes()
			.UseArgumentAttributes()
			.UseSubcommandAttributes();
	}

	public static IConventionBuilder SetRemainingArgsPropertyOnModel(this IConventionBuilder builder)
	{
		return builder.AddConvention(new RemainingArgsPropertyConvention());
	}

	public static IConventionBuilder SetSubcommandPropertyOnModel(this IConventionBuilder builder)
	{
		return builder.AddConvention(new SubcommandPropertyConvention());
	}

	public static IConventionBuilder SetParentPropertyOnModel(this IConventionBuilder builder)
	{
		return builder.AddConvention(new ParentPropertyConvention());
	}

	public static IConventionBuilder SetAppNameFromEntryAssembly(this IConventionBuilder builder)
	{
		return builder.AddConvention(new AppNameFromEntryAssemblyConvention());
	}

	public static IConventionBuilder UseCommandAttribute(this IConventionBuilder builder)
	{
		return builder.AddConvention(new CommandAttributeConvention());
	}

	public static IConventionBuilder UseVersionOptionFromMemberAttribute(this IConventionBuilder builder)
	{
		return builder.AddConvention(new VersionOptionFromMemberAttributeConvention());
	}

	public static IConventionBuilder UseVersionOptionAttribute(this IConventionBuilder builder)
	{
		return builder.AddConvention(new VersionOptionAttributeConvention());
	}

	public static IConventionBuilder UseHelpOptionAttribute(this IConventionBuilder builder)
	{
		return builder.AddConvention(new HelpOptionAttributeConvention());
	}

	public static IConventionBuilder UseOptionAttributes(this IConventionBuilder builder)
	{
		return builder.AddConvention(new OptionAttributeConvention());
	}

	public static IConventionBuilder UseArgumentAttributes(this IConventionBuilder builder)
	{
		return builder.AddConvention(new ArgumentAttributeConvention());
	}

	public static IConventionBuilder UseSubcommandAttributes(this IConventionBuilder builder)
	{
		return builder.AddConvention(new SubcommandAttributeConvention());
	}

	public static IConventionBuilder UseOnValidateMethodFromModel(this IConventionBuilder builder)
	{
		return builder.AddConvention(new ValidateMethodConvention());
	}

	public static IConventionBuilder UseOnValidationErrorMethodFromModel(this IConventionBuilder builder)
	{
		return builder.AddConvention(new ValidationErrorMethodConvention());
	}

	public static IConventionBuilder UseOnExecuteMethodFromModel(this IConventionBuilder builder)
	{
		return builder.AddConvention(new ExecuteMethodConvention());
	}

	public static IConventionBuilder UseConstructorInjection(this IConventionBuilder builder)
	{
		return builder.AddConvention(new ConstructorInjectionConvention());
	}

	public static IConventionBuilder UseConstructorInjection(this IConventionBuilder builder, IServiceProvider additionalServices)
	{
		return builder.AddConvention(new ConstructorInjectionConvention(additionalServices));
	}

	public static IConventionBuilder UseCommandNameFromModelType(this IConventionBuilder builder)
	{
		return builder.AddConvention(new CommandNameFromTypeConvention());
	}
}
