using System.Security;
using System.Text;

namespace System;

public static class StringNormalizationExtensions
{
	public static bool IsNormalized(this string value)
	{
		return value.IsNormalized();
	}

	[SecurityCritical]
	public static bool IsNormalized(this string value, NormalizationForm normalizationForm)
	{
		return value.IsNormalized(normalizationForm);
	}

	public static string Normalize(this string value)
	{
		return value.Normalize();
	}

	[SecurityCritical]
	public static string Normalize(this string value, NormalizationForm normalizationForm)
	{
		return value.Normalize(normalizationForm);
	}
}
