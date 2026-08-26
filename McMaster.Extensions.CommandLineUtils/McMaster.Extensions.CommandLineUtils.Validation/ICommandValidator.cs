using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils.Validation;

public interface ICommandValidator
{
	ValidationResult GetValidationResult(CommandLineApplication command, ValidationContext context);
}
