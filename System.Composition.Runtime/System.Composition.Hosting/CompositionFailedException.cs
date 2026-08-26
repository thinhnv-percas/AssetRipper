using System.Composition.Properties;

namespace System.Composition.Hosting;

public class CompositionFailedException : Exception
{
	public CompositionFailedException()
		: base(System.Composition.Properties.Resources.CompositionFailedDefaultExceptionMessage)
	{
	}

	public CompositionFailedException(string message)
		: base(message)
	{
	}

	public CompositionFailedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
