using System;

namespace McMaster.Extensions.CommandLineUtils;

public abstract class OptionAttributeBase : Attribute
{
	public string Template { get; set; }

	public string ShortName { get; set; }

	public string LongName { get; set; }

	public string SymbolName { get; set; }

	public string ValueName { get; set; }

	public string Description { get; set; }

	public bool ShowInHelpText { get; set; } = true;

	public bool Inherited { get; set; }

	internal void Configure(CommandOption option)
	{
		option.Description = Description ?? option.Description;
		option.Inherited = Inherited;
		option.ShowInHelpText = ShowInHelpText;
		option.ShortName = ShortName ?? option.ShortName;
		option.LongName = LongName ?? option.LongName;
		option.ValueName = ValueName ?? option.ValueName;
		option.SymbolName = SymbolName ?? option.SymbolName;
		if (option.Template == null)
		{
			option.Template = option.ToTemplateString();
		}
	}
}
