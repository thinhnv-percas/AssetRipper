using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace McMaster.Extensions.CommandLineUtils;

public static class CommandLineApplicationExtensions
{
	public static CommandArgument<T> Argument<T>(this CommandLineApplication app, string name, string description, bool multipleValues = false)
	{
		return app.Argument<T>(name, description, delegate
		{
		}, multipleValues);
	}

	public static CommandOption<T> Option<T>(this CommandLineApplication app, string template, string description, CommandOptionType optionType)
	{
		return app.Option<T>(template, description, optionType, delegate
		{
		}, inherited: false);
	}

	public static CommandOption<T> Option<T>(this CommandLineApplication app, string template, string description, CommandOptionType optionType, bool inherited)
	{
		return app.Option<T>(template, description, optionType, delegate
		{
		}, inherited);
	}

	public static CommandOption<T> Option<T>(this CommandLineApplication app, string template, string description, CommandOptionType optionType, Action<CommandOption> configuration)
	{
		return app.Option<T>(template, description, optionType, configuration, inherited: false);
	}

	public static CommandOption HelpOption(this CommandLineApplication app)
	{
		return app.HelpOption("-?|-h|--help");
	}

	public static CommandOption HelpOption(this CommandLineApplication app, bool inherited)
	{
		return app.HelpOption("-?|-h|--help", inherited);
	}

	public static CommandOption VerboseOption(this CommandLineApplication app)
	{
		return app.VerboseOption("-v|--verbose");
	}

	public static CommandOption VerboseOption(this CommandLineApplication app, string template)
	{
		return app.Option(template, "Show verbose output", CommandOptionType.NoValue, inherited: true);
	}

	public static void OnExecute(this CommandLineApplication app, Func<Task> action)
	{
		app.OnExecute(async delegate
		{
			await action();
			return 0;
		});
	}

	public static void OnExecute(this CommandLineApplication app, Action action)
	{
		app.OnExecute(delegate
		{
			action();
			return 0;
		});
	}

	public static void OnValidationError(this CommandLineApplication app, Func<ValidationResult, int> action)
	{
		app.ValidationErrorHandler = action;
	}

	public static void OnValidationError(this CommandLineApplication app, Action<ValidationResult> action)
	{
		app.OnValidationError(delegate(ValidationResult r)
		{
			action(r);
			return 1;
		});
	}

	public static CommandOption VersionOptionFromAssemblyAttributes(this CommandLineApplication app, Assembly assembly)
	{
		return VersionOptionFromAssemblyAttributes(app, "--version", assembly);
	}

	public static CommandOption VersionOptionFromAssemblyAttributes(CommandLineApplication app, string template, Assembly assembly)
	{
		return app.VersionOption(template, GetInformationalVersion(assembly));
	}

	private static string GetInformationalVersion(Assembly assembly)
	{
		string text = assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return assembly?.GetName().Version.ToString();
	}
}
