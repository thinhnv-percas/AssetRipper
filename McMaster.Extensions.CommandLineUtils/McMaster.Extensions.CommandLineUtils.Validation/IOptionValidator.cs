using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils.Validation;

public interface IOptionValidator
{
	ValidationResult GetValidationResult(CommandOption option, ValidationContext context);
}
