using System;
using System.Collections.Generic;

namespace McMaster.Extensions.CommandLineUtils;

public class UnrecognizedCommandParsingException : CommandParsingException
{
	public IEnumerable<string> NearestMatches { get; }

	public UnrecognizedCommandParsingException(CommandLineApplication command, IEnumerable<string> nearestMatches, string message)
		: base(command, message)
	{
		NearestMatches = nearestMatches ?? throw new ArgumentNullException("nearestMatches");
	}
}
