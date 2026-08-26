using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils.Validation;

public interface IArgumentValidator
{
	ValidationResult GetValidationResult(CommandArgument argument, ValidationContext context);
}
