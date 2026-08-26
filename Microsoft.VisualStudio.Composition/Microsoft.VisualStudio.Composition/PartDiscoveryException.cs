using System;

namespace Microsoft.VisualStudio.Composition;

public class PartDiscoveryException : Exception
{
	public string AssemblyPath { get; set; }

	public Type ScannedType { get; set; }

	public PartDiscoveryException()
	{
	}

	public PartDiscoveryException(string message)
		: base(message)
	{
	}

	public PartDiscoveryException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
