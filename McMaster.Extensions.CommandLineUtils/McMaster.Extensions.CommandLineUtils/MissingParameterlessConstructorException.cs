using System;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils;

public class MissingParameterlessConstructorException : TargetException
{
	public Type Type { get; private set; }

	public MissingParameterlessConstructorException(Type type, Exception innerException)
		: base("Class " + type.FullName + " does not have a parameterless constructor", innerException)
	{
		Type = type;
	}
}
