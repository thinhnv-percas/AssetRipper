using System;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public sealed class HelpOptionAttribute : OptionAttributeBase
{
	public HelpOptionAttribute()
		: this("-?|-h|--help")
	{
	}

	public HelpOptionAttribute(string template)
	{
		base.Template = template;
		base.Description = "Show help information";
	}

	internal CommandOption Configure(CommandLineApplication app)
	{
		CommandOption commandOption = app.HelpOption(base.Template);
		Configure(commandOption);
		return commandOption;
	}
}
