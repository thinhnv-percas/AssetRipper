using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace McMaster.Extensions.CommandLineUtils.HelpText;

public class DefaultHelpTextGenerator : IHelpTextGenerator
{
	public static DefaultHelpTextGenerator Singleton { get; } = new DefaultHelpTextGenerator();

	public bool SortCommandsByName { get; set; } = true;

	protected DefaultHelpTextGenerator()
	{
	}

	public virtual void Generate(CommandLineApplication application, TextWriter output)
	{
		GenerateHeader(application, output);
		GenerateBody(application, output);
		GenerateFooter(application, output);
	}

	protected virtual void GenerateHeader(CommandLineApplication application, TextWriter output)
	{
		string fullNameAndVersion = application.GetFullNameAndVersion();
		if (!string.IsNullOrEmpty(fullNameAndVersion))
		{
			output.WriteLine(fullNameAndVersion);
			output.WriteLine();
		}
		if (!string.IsNullOrEmpty(application.Description))
		{
			output.WriteLine(application.Description);
			output.WriteLine();
		}
	}

	protected virtual void GenerateBody(CommandLineApplication application, TextWriter output)
	{
		List<CommandArgument> list = application.Arguments.Where((CommandArgument a) => a.ShowInHelpText).ToList();
		List<CommandOption> list2 = (from o in application.GetOptions()
			where o.ShowInHelpText
			select o).ToList();
		List<CommandLineApplication> list3 = application.Commands.Where((CommandLineApplication c) => c.ShowInHelpText).ToList();
		int firstColumnWidth = 2 + Math.Max((list.Count > 0) ? list.Max((CommandArgument a) => a.Name.Length) : 0, Math.Max((list2.Count > 0) ? list2.Max((CommandOption o) => Format(o).Length) : 0, (list3.Count > 0) ? list3.Max((CommandLineApplication c) => c.Name?.Length ?? 0) : 0));
		GenerateUsage(application, output, list, list2, list3);
		GenerateArguments(application, output, list, firstColumnWidth);
		GenerateOptions(application, output, list2, firstColumnWidth);
		GenerateCommands(application, output, list3, firstColumnWidth);
	}

	protected virtual void GenerateUsage(CommandLineApplication application, TextWriter output, IReadOnlyList<CommandArgument> visibleArguments, IReadOnlyList<CommandOption> visibleOptions, IReadOnlyList<CommandLineApplication> visibleCommands)
	{
		output.Write("Usage:");
		Stack<string> stack = new Stack<string>();
		for (CommandLineApplication commandLineApplication = application; commandLineApplication != null; commandLineApplication = commandLineApplication.Parent)
		{
			stack.Push(commandLineApplication.Name);
		}
		while (stack.Count > 0)
		{
			output.Write(' ');
			output.Write(stack.Pop());
		}
		if (visibleArguments.Any())
		{
			output.Write(" [arguments]");
		}
		if (visibleOptions.Any())
		{
			output.Write(" [options]");
		}
		if (visibleCommands.Any())
		{
			output.Write(" [command]");
		}
		if (application.AllowArgumentSeparator)
		{
			output.Write(" [[--] <arg>...]");
		}
		output.WriteLine();
	}

	protected virtual void GenerateArguments(CommandLineApplication application, TextWriter output, IReadOnlyList<CommandArgument> visibleArguments, int firstColumnWidth)
	{
		if (!visibleArguments.Any())
		{
			return;
		}
		output.WriteLine();
		output.WriteLine("Arguments:");
		string format = $"  {{0, -{firstColumnWidth}}}{{1}}";
		string newValue = Environment.NewLine + new string(' ', firstColumnWidth + 2);
		foreach (CommandArgument visibleArgument in visibleArguments)
		{
			string text = string.Format(format, visibleArgument.Name, visibleArgument.Description);
			text = text.Replace(Environment.NewLine, newValue);
			output.Write(text);
			output.WriteLine();
		}
	}

	protected virtual void GenerateOptions(CommandLineApplication application, TextWriter output, IReadOnlyList<CommandOption> visibleOptions, int firstColumnWidth)
	{
		if (!visibleOptions.Any())
		{
			return;
		}
		output.WriteLine();
		output.WriteLine("Options:");
		string format = $"  {{0, -{firstColumnWidth}}}{{1}}";
		string newValue = Environment.NewLine + new string(' ', firstColumnWidth + 2);
		foreach (CommandOption visibleOption in visibleOptions)
		{
			string text = string.Format(format, Format(visibleOption), visibleOption.Description);
			text = text.Replace(Environment.NewLine, newValue);
			output.Write(text);
			output.WriteLine();
		}
	}

	protected virtual void GenerateCommands(CommandLineApplication application, TextWriter output, IReadOnlyList<CommandLineApplication> visibleCommands, int firstColumnWidth)
	{
		if (!visibleCommands.Any())
		{
			return;
		}
		output.WriteLine();
		output.WriteLine("Commands:");
		string format = $"  {{0, -{firstColumnWidth}}}{{1}}";
		string newValue = Environment.NewLine + new string(' ', firstColumnWidth + 2);
		IReadOnlyList<CommandLineApplication> readOnlyList;
		if (!SortCommandsByName)
		{
			readOnlyList = visibleCommands;
		}
		else
		{
			IReadOnlyList<CommandLineApplication> readOnlyList2 = visibleCommands.OrderBy((CommandLineApplication c) => c.Name).ToList();
			readOnlyList = readOnlyList2;
		}
		foreach (CommandLineApplication item in readOnlyList)
		{
			string text = string.Format(format, item.Name, item.Description);
			text = text.Replace(Environment.NewLine, newValue);
			output.Write(text);
			output.WriteLine();
		}
		if (application.OptionHelp != null)
		{
			output.WriteLine();
			output.WriteLine("Run '" + application.Name + " [command] --" + application.OptionHelp.LongName + "' for more information about a command.");
		}
	}

	protected virtual void GenerateFooter(CommandLineApplication application, TextWriter output)
	{
		output.Write(application.ExtendedHelpText);
		output.WriteLine();
	}

	protected virtual string Format(CommandOption option)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(option.SymbolName))
		{
			stringBuilder.Append('-').Append(option.SymbolName);
		}
		if (!string.IsNullOrEmpty(option.ShortName))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append('|');
			}
			stringBuilder.Append('-').Append(option.ShortName);
		}
		if (!string.IsNullOrEmpty(option.LongName))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append('|');
			}
			stringBuilder.Append("--").Append(option.LongName);
		}
		if (!string.IsNullOrEmpty(option.ValueName) && option.OptionType != CommandOptionType.NoValue)
		{
			if (option.OptionType == CommandOptionType.SingleOrNoValue)
			{
				stringBuilder.Append("[:<").Append(option.ValueName).Append(">]");
			}
			else
			{
				stringBuilder.Append(" <").Append(option.ValueName).Append('>');
			}
		}
		return stringBuilder.ToString();
	}
}
