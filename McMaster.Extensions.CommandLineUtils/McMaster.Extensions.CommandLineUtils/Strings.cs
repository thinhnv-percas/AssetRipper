using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils;

internal static class Strings
{
	public const string DefaultHelpTemplate = "-?|-h|--help";

	public const string DefaultHelpOptionDescription = "Show help information";

	public const string DefaultVersionTemplate = "--version";

	public const string DefaultVersionOptionDescription = "Show version information";

	public const string IsNullOrEmpty = "Value is null or empty.";

	public const string PathMustNotBeRelative = "File path must not be relative.";

	public const string NoValueTypesMustBeBoolean = "Cannot specify CommandOptionType.NoValue unless the type is boolean.";

	public const string AmbiguousOnExecuteMethod = "Could not determine which 'OnExecute' or 'OnExecuteAsync' method to use. Multiple methods with this name were found";

	public const string NoOnExecuteMethodFound = "No method named 'OnExecute' or 'OnExecuteAsync' could be found";

	public static string MultipleValuesArgumentShouldBeCollection = "ArgumentAttribute.MultipleValues should be true if the property type is an array or collection.";

	public const string HelpOptionOnTypeAndProperty = "Multiple HelpOptionAttributes found. HelpOptionAttribute should only be used one per type, either on one property or on the type.";

	public const string MultipleHelpOptionPropertiesFound = "Multiple HelpOptionAttributes found. HelpOptionAttribute should only be used on one property per type.";

	public const string VersionOptionOnTypeAndProperty = "Multiple VersionOptionAttributes found. VersionOptionAttribute should only be used one per type, either on one property or on the type.";

	public const string MultipleVersionOptionPropertiesFound = "Multiple VersionOptionAttributes found. VersionOptionAttribute should only be used on one property per type.";

	public static string InvalidOnExecuteReturnType(string methodName)
	{
		return methodName + " must have a return type of int or void, or if the method is async, Task<int> or Task.";
	}

	public static string InvalidOnValidateReturnType(Type modelType)
	{
		return "The OnValidate method on " + modelType.FullName + " must return " + typeof(ValidationResult).FullName;
	}

	public static string CannotDetermineOptionType(PropertyInfo member)
	{
		return "Could not automatically determine the CommandOptionType for type " + member.PropertyType.FullName + ". Set the OptionType on the OptionAttribute declaration for " + member.DeclaringType.FullName + "." + member.Name + ".";
	}

	public static string OptionNameIsAmbiguous(string optionName, PropertyInfo first, PropertyInfo second)
	{
		return "Ambiguous option name. Both " + first.DeclaringType.FullName + "." + first.Name + " and " + second.DeclaringType.FullName + "." + second.Name + " produce a CommandOption with the name '" + optionName + "'";
	}

	public static string DuplicateSubcommandName(string commandName)
	{
		return "The subcommand name '" + commandName + "' has already been been specified. Subcommand names must be unique.";
	}

	public static string BothOptionAndArgumentAttributesCannotBeSpecified(PropertyInfo prop)
	{
		return "Cannot specify both OptionAttribute and ArgumentAttribute on property " + prop.DeclaringType.Name + "." + prop.Name + ".";
	}

	public static string BothOptionAndHelpOptionAttributesCannotBeSpecified(PropertyInfo prop)
	{
		return "Cannot specify both OptionAttribute and HelpOptionAttribute on property " + prop.DeclaringType.Name + "." + prop.Name + ".";
	}

	public static string BothOptionAndVersionOptionAttributesCannotBeSpecified(PropertyInfo prop)
	{
		return "Cannot specify both OptionAttribute and VersionOptionAttribute on property " + prop.DeclaringType.Name + "." + prop.Name + ".";
	}

	internal static string UnsupportedParameterTypeOnMethod(string methodName, ParameterInfo methodParam)
	{
		return "Unsupported type on " + methodName + " '" + methodParam.ParameterType.FullName + "' on parameter " + methodParam.Name;
	}

	public static string BothHelpOptionAndVersionOptionAttributesCannotBeSpecified(PropertyInfo prop)
	{
		return "Cannot specify both HelpOptionAttribute and VersionOptionAttribute on property " + prop.DeclaringType.Name + "." + prop.Name + ".";
	}

	public static string DuplicateArgumentPosition(int order, PropertyInfo first, PropertyInfo second)
	{
		return $"Duplicate value for argument order. Both {first.DeclaringType.FullName}.{first.Name} and {second.DeclaringType.FullName}.{second.Name} have set Order = {order}";
	}

	public static string OnlyLastArgumentCanAllowMultipleValues(string lastArgName)
	{
		return "The last argument '" + lastArgName + "' accepts multiple values. No more argument can be added.";
	}

	public static string CannotDetermineParserType(Type type)
	{
		return "Could not automatically determine how to convert string values into " + type.FullName;
	}

	public static string CannotDetermineParserType(PropertyInfo prop)
	{
		return "Could not automatically determine how to convert string values into " + prop.PropertyType.FullName + " on property " + prop.DeclaringType.Name + "." + prop.Name + ".";
	}

	public static string RemainingArgsPropsIsUnassignable(TypeInfo typeInfo)
	{
		return "The RemainingArguments property type on " + typeInfo.Name + " is invalid. It must be assignable from string[].";
	}

	public static string NoPropertyOrMethodFound(string memberName, Type type)
	{
		return "Could not find a property or method named " + memberName + " on type " + type.FullName;
	}

	public static string NoParameterTypeRegistered(Type modelType, Type paramType)
	{
		return $"The constructor of type '{modelType}' contains the parameter of type '{paramType}' is not registered, Ensure the type '{paramType}' are registered in additional services with CommandLineApplication.Conventions.UseConstructorInjection(IServiceProvider additionalServices)";
	}

	public static string NoAnyPublicConstuctorFound(Type modelType)
	{
		return $"Could not find any public constructors of type '{modelType}'";
	}

	public static string NoMatchedConstructorFound(Type modelType)
	{
		return $"Could not found any matched constructors of type '{modelType}'";
	}
}
