using System;

namespace McMaster.Extensions.CommandLineUtils.Validation;

public class ValidationBuilder : IOptionValidationBuilder, IValidationBuilder, IArgumentValidationBuilder
{
	private readonly CommandArgument _argument;

	private readonly CommandOption _option;

	public ValidationBuilder(CommandArgument argument)
	{
		_argument = argument ?? throw new ArgumentNullException("argument");
	}

	public ValidationBuilder(CommandOption option)
	{
		_option = option ?? throw new ArgumentNullException("option");
	}

	public void Use(IValidator validator)
	{
		_argument?.Validators.Add(validator);
		_option?.Validators.Add(validator);
	}

	void IArgumentValidationBuilder.Use(IArgumentValidator validator)
	{
		_argument?.Validators.Add(validator);
	}

	void IOptionValidationBuilder.Use(IOptionValidator validator)
	{
		_option?.Validators.Add(validator);
	}
}
public class ValidationBuilder<T> : ValidationBuilder, IArgumentValidationBuilder<T>, IArgumentValidationBuilder, IValidationBuilder, IValidationBuilder<T>, IOptionValidationBuilder<T>, IOptionValidationBuilder
{
	public ValidationBuilder(CommandArgument<T> argument)
		: base(argument)
	{
	}

	public ValidationBuilder(CommandOption<T> option)
		: base(option)
	{
	}
}
