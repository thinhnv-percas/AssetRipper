using System;
using System.ComponentModel.DataAnnotations;

namespace DecompTools.Decompiler.Console;

[AttributeUsage(AttributeTargets.Class)]
public class ProjectOptionRequiresOutputDirectoryValidationAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext context)
	{
		if (value is ILSpyCmdProgram { CreateCompilableProjectFlag: not false } iLSpyCmdProgram && string.IsNullOrEmpty(iLSpyCmdProgram.OutputDirectory))
		{
			return new ValidationResult("--project cannot be used unless --outputdir is also specified");
		}
		return ValidationResult.Success;
	}
}
