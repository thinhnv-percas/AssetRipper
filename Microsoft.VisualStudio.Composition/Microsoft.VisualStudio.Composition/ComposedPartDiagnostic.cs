using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;

namespace Microsoft.VisualStudio.Composition;

public class ComposedPartDiagnostic
{
	public IReadOnlyCollection<ComposedPart> Parts { get; private set; }

	public string Message { get; private set; }

	public ComposedPartDiagnostic(ComposedPart part, string formattedMessage)
		: this(ImmutableHashSet.Create(part), formattedMessage)
	{
	}

	public ComposedPartDiagnostic(ComposedPart part, string unformattedMessage, params object[] args)
		: this(part, string.Format(CultureInfo.CurrentCulture, unformattedMessage, args))
	{
	}

	public ComposedPartDiagnostic(IEnumerable<ComposedPart> parts, string formattedMessage)
	{
		Requires.NotNull(parts, "parts");
		Requires.NotNullOrEmpty(formattedMessage, "formattedMessage");
		Parts = ImmutableList.CreateRange(parts);
		Message = formattedMessage;
	}

	public ComposedPartDiagnostic(IEnumerable<ComposedPart> parts, string unformattedMessage, params object[] args)
		: this(parts, string.Format(CultureInfo.CurrentCulture, unformattedMessage, args))
	{
	}
}
