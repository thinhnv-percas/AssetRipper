using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public class TokenReference : IEquatable<TokenReference>
{
	public ModuleDef ModuleDef { get; }

	public uint Token { get; }

	public TokenReference(IMemberRef reference)
		: this(reference.Module, reference.MDToken.Raw)
	{
	}

	public TokenReference(ModuleDef module, uint token)
	{
		ModuleDef = module ?? throw new ArgumentNullException("module");
		Token = token;
	}

	public bool Equals(TokenReference other)
	{
		return other != null && Token == other.Token && ModuleDef == other.ModuleDef;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as TokenReference);
	}

	public override int GetHashCode()
	{
		return ((ModuleDef != null) ? ModuleDef.GetHashCode() : 0) ^ (int)Token;
	}

	public override string ToString()
	{
		return new MDToken(Token).ToString() + " " + ModuleDef.ToString();
	}
}
