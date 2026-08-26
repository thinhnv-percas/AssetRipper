using System;
using System.Composition.Hosting;
using System.Composition.Hosting.Properties;

namespace Microsoft.Internal;

internal static class ThrowHelper
{
	private static Exception LogException(Exception e)
	{
		return e;
	}

	public static ArgumentException ArgumentException(string message)
	{
		ArgumentException ex = new ArgumentException(message);
		LogException(ex);
		return ex;
	}

	public static CompositionFailedException CardinalityMismatch_TooManyExports(string exportKey)
	{
		CompositionFailedException ex = new CompositionFailedException(string.Format(Resources.CardinalityMismatch_TooManyExports, new object[1] { exportKey }));
		LogException(ex);
		return ex;
	}

	public static CompositionFailedException CompositionException(string message)
	{
		CompositionFailedException ex = new CompositionFailedException(message);
		LogException(ex);
		return ex;
	}

	internal static Exception NotImplemented_MetadataCycles()
	{
		NotImplementedException ex = new NotImplementedException(Resources.NotImplemented_MetadataCycles);
		LogException(ex);
		return ex;
	}
}
