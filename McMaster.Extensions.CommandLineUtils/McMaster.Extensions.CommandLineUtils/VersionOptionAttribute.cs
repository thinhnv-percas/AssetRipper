using System;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public sealed class VersionOptionAttribute : OptionAttributeBase
{
	public string Version { get; set; }

	public VersionOptionAttribute(string version)
		: this("--version", version)
	{
	}

	public VersionOptionAttribute(string template, string version)
	{
		Version = version;
		base.Template = template;
		base.Description = "Show version information";
	}

	internal CommandOption Configure(CommandLineApplication app)
	{
		CommandOption commandOption = app.VersionOption(base.Template, Version);
		Configure(commandOption);
		return commandOption;
	}
}
