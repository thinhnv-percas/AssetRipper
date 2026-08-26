using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Microsoft.VisualStudio.Composition;

public class CompositionFailedException : Exception
{
	public IImmutableStack<IReadOnlyCollection<ComposedPartDiagnostic>> Errors { get; private set; }

	public CompositionFailedException()
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

	public CompositionFailedException(string message, IImmutableStack<IReadOnlyCollection<ComposedPartDiagnostic>> errors)
		: this(message)
	{
		Requires.NotNull(errors, "errors");
		Errors = errors;
	}
}
