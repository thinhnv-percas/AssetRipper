using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class DefaultHelpOptionConvention : IConvention
{
	public const string DefaultHelpTemplate = "-?|-h|--help";

	private readonly string _template;

	public DefaultHelpOptionConvention(string template)
	{
		_template = template;
	}

	public void Apply(ConventionContext context)
	{
		if (context.Application.OptionHelp != null)
		{
			return;
		}
		if (context.ModelType != null)
		{
			TypeInfo typeInfo = context.ModelType.GetTypeInfo();
			if (typeInfo.GetCustomAttribute<SuppressDefaultHelpOptionAttribute>() != null || typeInfo.Assembly.GetCustomAttribute<SuppressDefaultHelpOptionAttribute>() != null)
			{
				return;
			}
		}
		CommandOption commandOption = new CommandOption(_template, CommandOptionType.NoValue)
		{
			Description = "Show help information",
			Inherited = false
		};
		foreach (CommandOption option in context.Application.GetOptions())
		{
			if (string.Equals(commandOption.LongName, option.LongName))
			{
				commandOption.LongName = null;
			}
			if (string.Equals(commandOption.ShortName, option.ShortName))
			{
				commandOption.ShortName = null;
			}
			if (string.Equals(commandOption.SymbolName, option.SymbolName))
			{
				commandOption.SymbolName = null;
			}
		}
		if (commandOption.LongName != null || commandOption.ShortName != null || commandOption.SymbolName != null)
		{
			context.Application.OptionHelp = commandOption;
			context.Application.Options.Add(commandOption);
		}
	}
}
