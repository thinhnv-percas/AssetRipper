using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Property)]
public sealed class LegalFilePathAttribute : ValidationAttribute
{
	public LegalFilePathAttribute()
		: base("'{0}' is an invalid file path.")
	{
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is string fileName)
		{
			try
			{
				new FileInfo(fileName);
				return ValidationResult.Success;
			}
			catch
			{
			}
		}
		return new ValidationResult(FormatErrorMessage(value as string));
	}
}
