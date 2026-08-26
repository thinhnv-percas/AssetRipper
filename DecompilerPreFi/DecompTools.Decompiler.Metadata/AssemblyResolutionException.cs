using System;
using System.IO;

namespace DecompTools.Decompiler.Metadata;

public sealed class AssemblyResolutionException : FileNotFoundException
{
	public IAssemblyReference Reference { get; }

	public AssemblyResolutionException(IAssemblyReference reference)
		: this(reference, null)
	{
	}

	public AssemblyResolutionException(IAssemblyReference reference, Exception innerException)
		: base($"Failed to resolve assembly: '{reference}'", innerException)
	{
		Reference = reference;
	}
}
