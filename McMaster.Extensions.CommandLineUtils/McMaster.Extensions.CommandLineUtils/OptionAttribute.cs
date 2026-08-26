using System;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class OptionAttribute : OptionAttributeBase
{
	public CommandOptionType? OptionType { get; set; }

	public OptionAttribute()
	{
	}

	public OptionAttribute(string template)
	{
		base.Template = template;
	}

	public OptionAttribute(CommandOptionType optionType)
		: this(null, null, optionType)
	{
	}

	public OptionAttribute(string template, CommandOptionType optionType)
		: this(template, null, optionType)
	{
	}

	public OptionAttribute(string template, string description, CommandOptionType optionType)
	{
		base.Template = template;
		base.Description = description;
		OptionType = optionType;
	}

	internal CommandOption Configure(CommandLineApplication app, PropertyInfo prop)
	{
		CommandOptionType optionType = GetOptionType(prop, app.ValueParsers);
		CommandOption commandOption;
		if (base.Template != null)
		{
			commandOption = new CommandOption(base.Template, optionType);
		}
		else
		{
			string text = prop.Name.ToKebabCase();
			commandOption = new CommandOption(optionType)
			{
				LongName = text,
				ShortName = text.Substring(0, 1),
				ValueName = prop.Name.ToConstantCase()
			};
		}
		Configure(commandOption);
		if (commandOption.Description == null)
		{
			commandOption.Description = prop.Name;
		}
		app.Options.Add(commandOption);
		return commandOption;
	}

	private CommandOptionType GetOptionType(PropertyInfo prop, ValueParserProvider valueParsers)
	{
		if (OptionType.HasValue)
		{
			return OptionType.Value;
		}
		if (!CommandOptionTypeMapper.Default.TryGetOptionType(prop.PropertyType, valueParsers, out var optionType))
		{
			throw new InvalidOperationException(Strings.CannotDetermineOptionType(prop));
		}
		return optionType;
	}
}
