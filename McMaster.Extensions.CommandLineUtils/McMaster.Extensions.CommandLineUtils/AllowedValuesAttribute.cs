using System;
using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Property)]
public sealed class AllowedValuesAttribute : ValidationAttribute
{
	private readonly string[] _allowedValues;

	public StringComparison Comparer { get; set; }

	public bool IgnoreCase
	{
		get
		{
			if (Comparer != StringComparison.CurrentCultureIgnoreCase && Comparer != StringComparison.InvariantCultureIgnoreCase)
			{
				return Comparer == StringComparison.OrdinalIgnoreCase;
			}
			return true;
		}
		set
		{
			Comparer = (value ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
		}
	}

	public AllowedValuesAttribute(params string[] allowedValues)
		: this(StringComparison.CurrentCulture, allowedValues)
	{
	}

	public AllowedValuesAttribute(StringComparison comparer, params string[] allowedValues)
		: base(GetDefaultError(allowedValues))
	{
		_allowedValues = allowedValues ?? new string[0];
		Comparer = comparer;
	}

	private static string GetDefaultError(string[] allowedValues)
	{
		return "Invalid value '{0}'. Allowed values are: " + string.Join(", ", allowedValues);
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is string text)
		{
			for (int i = 0; i < _allowedValues.Length; i++)
			{
				if (text.Equals(_allowedValues[i], Comparer))
				{
					return ValidationResult.Success;
				}
			}
		}
		return new ValidationResult(FormatErrorMessage(value as string));
	}
}
