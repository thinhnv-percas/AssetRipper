using System.Globalization;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class UnknownIdentifierResolveResult : ResolveResult
{
	private readonly string identifier;

	private readonly int typeArgumentCount;

	public string Identifier => identifier;

	public int TypeArgumentCount => typeArgumentCount;

	public override bool IsError => true;

	public UnknownIdentifierResolveResult(string identifier, int typeArgumentCount = 0)
		: base(SpecialType.UnknownType)
	{
		this.identifier = identifier;
		this.typeArgumentCount = typeArgumentCount;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[{0} {1}]", GetType().Name, identifier);
	}
}
