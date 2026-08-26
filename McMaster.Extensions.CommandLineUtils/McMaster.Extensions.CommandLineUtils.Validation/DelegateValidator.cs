using System;
using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils.Validation;

public class DelegateValidator : ICommandValidator, IArgumentValidator, IOptionValidator
{
	private readonly Func<ValidationContext, ValidationResult> _validator;

	public DelegateValidator(Func<ValidationContext, ValidationResult> validator)
	{
		_validator = validator ?? throw new ArgumentNullException("validator");
	}

	ValidationResult ICommandValidator.GetValidationResult(CommandLineApplication command, ValidationContext context)
	{
		return _validator(context);
	}

	ValidationResult IArgumentValidator.GetValidationResult(CommandArgument argument, ValidationContext context)
	{
		return _validator(context);
	}

	ValidationResult IOptionValidator.GetValidationResult(CommandOption option, ValidationContext context)
	{
		return _validator(context);
	}
}
