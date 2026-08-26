using System;
using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils;

internal class CommandLineValidationContextFactory
{
	private readonly CommandLineApplication _app;

	public CommandLineValidationContextFactory(CommandLineApplication app)
	{
		_app = app ?? throw new ArgumentNullException("app");
	}

	public ValidationContext Create(CommandLineApplication app)
	{
		return new ValidationContext(app, _app, null);
	}

	public ValidationContext Create(CommandArgument argument)
	{
		return new ValidationContext(argument, _app, null);
	}

	public ValidationContext Create(CommandOption option)
	{
		return new ValidationContext(option, _app, null);
	}
}
