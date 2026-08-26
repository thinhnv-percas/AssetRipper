using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils;

public static class ValidationExtensions
{
	public static CommandOption IsRequired(this CommandOption option, bool allowEmptyStrings = false, string errorMessage = null)
	{
		RequiredAttribute validationAttr = GetValidationAttr<RequiredAttribute>(errorMessage);
		validationAttr.AllowEmptyStrings = allowEmptyStrings;
		option.Validators.Add(new AttributeValidator(validationAttr));
		return option;
	}

	public static CommandOption<T> IsRequired<T>(this CommandOption<T> option, bool allowEmptyStrings = false, string errorMessage = null)
	{
		((CommandOption)option).IsRequired(allowEmptyStrings, errorMessage);
		return option;
	}

	public static CommandArgument IsRequired(this CommandArgument argument, bool allowEmptyStrings = false, string errorMessage = null)
	{
		RequiredAttribute validationAttr = GetValidationAttr<RequiredAttribute>(errorMessage);
		validationAttr.AllowEmptyStrings = allowEmptyStrings;
		argument.Validators.Add(new AttributeValidator(validationAttr));
		return argument;
	}

	public static CommandArgument<T> IsRequired<T>(this CommandArgument<T> argument, bool allowEmptyStrings = false, string errorMessage = null)
	{
		((CommandArgument)argument).IsRequired(allowEmptyStrings, errorMessage);
		return argument;
	}

	public static CommandOption Accepts(this CommandOption option, Action<IOptionValidationBuilder> configure)
	{
		if (configure == null)
		{
			throw new ArgumentNullException("configure");
		}
		ValidationBuilder obj = new ValidationBuilder(option);
		configure(obj);
		return option;
	}

	public static CommandArgument Accepts(this CommandArgument argument, Action<IArgumentValidationBuilder> configure)
	{
		if (configure == null)
		{
			throw new ArgumentNullException("configure");
		}
		ValidationBuilder obj = new ValidationBuilder(argument);
		configure(obj);
		return argument;
	}

	public static IOptionValidationBuilder Accepts(this CommandOption option)
	{
		return new ValidationBuilder(option);
	}

	public static IArgumentValidationBuilder Accepts(this CommandArgument argument)
	{
		return new ValidationBuilder(argument);
	}

	public static CommandOption<T> Accepts<T>(this CommandOption<T> option, Action<IOptionValidationBuilder<T>> configure)
	{
		if (configure == null)
		{
			throw new ArgumentNullException("configure");
		}
		ValidationBuilder<T> obj = new ValidationBuilder<T>(option);
		configure(obj);
		return option;
	}

	public static CommandArgument<T> Accepts<T>(this CommandArgument<T> argument, Action<IArgumentValidationBuilder<T>> configure)
	{
		if (configure == null)
		{
			throw new ArgumentNullException("configure");
		}
		ValidationBuilder<T> obj = new ValidationBuilder<T>(argument);
		configure(obj);
		return argument;
	}

	public static IOptionValidationBuilder<T> Accepts<T>(this CommandOption<T> option)
	{
		return new ValidationBuilder<T>(option);
	}

	public static IArgumentValidationBuilder<T> Accepts<T>(this CommandArgument<T> argument)
	{
		return new ValidationBuilder<T>(argument);
	}

	public static IValidationBuilder Enum<TEnum>(this IValidationBuilder builder, bool ignoreCase = false) where TEnum : struct
	{
		if (!typeof(TEnum).GetTypeInfo().IsEnum)
		{
			throw new ArgumentException("Type parameter T must be an enum.");
		}
		StringComparison comparer = (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		return builder.Values(comparer, System.Enum.GetNames(typeof(TEnum)));
	}

	public static IValidationBuilder Values(this IValidationBuilder builder, params string[] allowedValues)
	{
		return builder.Values(ignoreCase: false, allowedValues);
	}

	public static IValidationBuilder Values(this IValidationBuilder builder, bool ignoreCase, params string[] allowedValues)
	{
		StringComparison comparer = (ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
		return builder.Values(comparer, allowedValues);
	}

	public static IValidationBuilder Values(this IValidationBuilder builder, StringComparison comparer, params string[] allowedValues)
	{
		return builder.Satisfies<AllowedValuesAttribute>(null, new object[2] { comparer, allowedValues });
	}

	public static IValidationBuilder EmailAddress(this IValidationBuilder builder, string errorMessage = null)
	{
		return builder.Satisfies<EmailAddressAttribute>(errorMessage, new object[0]);
	}

	public static IValidationBuilder ExistingFile(this IValidationBuilder builder, string errorMessage = null)
	{
		return builder.Satisfies<FileExistsAttribute>(errorMessage, new object[0]);
	}

	public static IValidationBuilder ExistingDirectory(this IValidationBuilder builder, string errorMessage = null)
	{
		return builder.Satisfies<DirectoryExistsAttribute>(errorMessage, new object[0]);
	}

	public static IValidationBuilder ExistingFileOrDirectory(this IValidationBuilder builder, string errorMessage = null)
	{
		return builder.Satisfies<FileOrDirectoryExistsAttribute>(errorMessage, new object[0]);
	}

	public static IValidationBuilder LegalFilePath(this IValidationBuilder builder, string errorMessage = null)
	{
		return builder.Satisfies<LegalFilePathAttribute>(errorMessage, new object[0]);
	}

	public static IValidationBuilder MinLength(this IValidationBuilder builder, int length, string errorMessage = null)
	{
		return builder.Satisfies<MinLengthAttribute>(errorMessage, new object[1] { length });
	}

	public static IValidationBuilder MaxLength(this IValidationBuilder builder, int length, string errorMessage = null)
	{
		return builder.Satisfies<MaxLengthAttribute>(errorMessage, new object[1] { length });
	}

	public static IValidationBuilder RegularExpression(this IValidationBuilder builder, string pattern, string errorMessage = null)
	{
		return builder.Satisfies<RegularExpressionAttribute>(errorMessage, new object[1] { pattern });
	}

	public static IValidationBuilder Satisfies<TAttribute>(this IValidationBuilder builder, string errorMessage = null, params object[] ctorArgs) where TAttribute : ValidationAttribute
	{
		TAttribute validationAttr = GetValidationAttr<TAttribute>(errorMessage, ctorArgs);
		builder.Use(new AttributeValidator(validationAttr));
		return builder;
	}

	public static IValidationBuilder<int> Range(this IValidationBuilder<int> builder, int minimum, int maximum, string errorMessage = null)
	{
		RangeAttribute validationAttr = GetValidationAttr<RangeAttribute>(errorMessage, new object[2] { minimum, maximum });
		builder.Use(new AttributeValidator(validationAttr));
		return builder;
	}

	public static IValidationBuilder<double> Range(this IValidationBuilder<double> builder, double minimum, double maximum, string errorMessage = null)
	{
		RangeAttribute validationAttr = GetValidationAttr<RangeAttribute>(errorMessage, new object[2] { minimum, maximum });
		builder.Use(new AttributeValidator(validationAttr));
		return builder;
	}

	public static CommandLineApplication OnValidate(this CommandLineApplication command, Func<ValidationContext, ValidationResult> validate)
	{
		command.Validators.Add(new DelegateValidator(validate));
		return command;
	}

	public static CommandArgument OnValidate(this CommandArgument argument, Func<ValidationContext, ValidationResult> validate)
	{
		argument.Validators.Add(new DelegateValidator(validate));
		return argument;
	}

	public static CommandOption OnValidate(this CommandOption option, Func<ValidationContext, ValidationResult> validate)
	{
		option.Validators.Add(new DelegateValidator(validate));
		return option;
	}

	private static T GetValidationAttr<T>(string errorMessage, object[] ctorArgs = null) where T : ValidationAttribute
	{
		T val = (T)Activator.CreateInstance(typeof(T), ctorArgs ?? new object[0]);
		if (errorMessage != null)
		{
			val.ErrorMessage = errorMessage;
		}
		return val;
	}
}
