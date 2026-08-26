using System;

namespace McMaster.Extensions.CommandLineUtils;

public class CommandParsingException : Exception
{
	public CommandLineApplication Command { get; }

	public CommandParsingException(CommandLineApplication command, string message)
		: base(message)
	{
		Command = command;
	}

	public CommandParsingException(CommandLineApplication command, string message, Exception innerException)
		: base(message, innerException)
	{
		Command = command;
	}
}
