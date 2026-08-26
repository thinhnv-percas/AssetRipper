using System.Globalization;
using Microsoft.Internal;

namespace System.Composition;

internal static class ExceptionBuilder
{
	public static ArgumentException Argument_ExpressionMustBeNew(string parameterName)
	{
		return CreateArgumentException(Microsoft.Internal.Strings.Argument_ExpressionMustBeNew, parameterName);
	}

	public static ArgumentException Argument_ExpressionMustBePropertyMember(string parameterName)
	{
		return CreateArgumentException(Microsoft.Internal.Strings.Argument_ExpressionMustBePropertyMember, parameterName);
	}

	public static ArgumentException Argument_ExpressionMustBeVoidMethodWithNoArguments(string methodName)
	{
		return CreateArgumentException(Microsoft.Internal.Strings.Argument_ExpressionMustBeVoidMethodWithNoArguments, methodName);
	}

	private static ArgumentException CreateArgumentException(string message, string parameterName)
	{
		Microsoft.Internal.Assumes.NotNull(parameterName);
		return new ArgumentException(Format(message, parameterName), parameterName);
	}

	private static string Format(string format, params string[] arguments)
	{
		return string.Format(CultureInfo.CurrentCulture, format, arguments);
	}
}
