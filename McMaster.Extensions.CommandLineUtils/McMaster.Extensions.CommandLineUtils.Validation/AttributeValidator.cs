using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Validation;

public class AttributeValidator : IValidator, IOptionValidator, IArgumentValidator, ICommandValidator
{
	private readonly ValidationAttribute _attribute;

	public AttributeValidator(ValidationAttribute attribute)
	{
		_attribute = attribute ?? throw new ArgumentNullException("attribute");
	}

	public ValidationResult GetValidationResult(CommandOption option, ValidationContext context)
	{
		if (_attribute is RequiredAttribute && option.OptionType == CommandOptionType.NoValue && option.HasValue())
		{
			return ValidationResult.Success;
		}
		return GetValidationResult(option.Values, context);
	}

	public ValidationResult GetValidationResult(CommandArgument argument, ValidationContext context)
	{
		return GetValidationResult(argument.Values, context);
	}

	private ValidationResult GetValidationResult(List<string> values, ValidationContext context)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (_attribute is RequiredAttribute && values.Count == 0)
		{
			return _attribute.GetValidationResult(null, context);
		}
		foreach (string value in values)
		{
			ValidationResult validationResult = _attribute.GetValidationResult(value, context);
			if (validationResult != ValidationResult.Success)
			{
				return validationResult;
			}
		}
		return ValidationResult.Success;
	}

	public ValidationResult GetValidationResult(CommandLineApplication command, ValidationContext context)
	{
		object obj = (command as IModelAccessor)?.GetModel();
		if (obj == null)
		{
			return _attribute.GetValidationResult(command, context);
		}
		return _attribute.GetValidationResult(obj, context);
	}
}
