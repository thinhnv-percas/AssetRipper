using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Validation;

[AttributeUsage(AttributeTargets.Property)]
public abstract class FilePathExistsAttributeBase : ValidationAttribute
{
	private readonly FilePathType _filePathType;

	internal FilePathExistsAttributeBase(FilePathType filePathType)
		: base(GetDefaultErrorMessage(filePathType))
	{
		_filePathType = filePathType;
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (!(value is string { Length: not 0 } text) || text.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
		{
			return new ValidationResult(FormatErrorMessage(value as string));
		}
		if (!Path.IsPathRooted(text) && validationContext.GetService(typeof(CommandLineContext)) is CommandLineContext commandLineContext)
		{
			text = Path.Combine(commandLineContext.WorkingDirectory, text);
		}
		if ((_filePathType & FilePathType.File) != 0 && File.Exists(text))
		{
			return ValidationResult.Success;
		}
		if ((_filePathType & FilePathType.Directory) != 0 && Directory.Exists(text))
		{
			return ValidationResult.Success;
		}
		return new ValidationResult(FormatErrorMessage(value as string));
	}

	private static string GetDefaultErrorMessage(FilePathType filePathType)
	{
		return filePathType switch
		{
			FilePathType.File => "The file '{0}' does not exist.", 
			FilePathType.Directory => "The directory '{0}' does not exist.", 
			_ => "The file path '{0}' does not exist.", 
		};
	}
}
