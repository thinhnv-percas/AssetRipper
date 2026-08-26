using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Metadata;

public readonly struct ModuleTokenId : IEquatable<ModuleTokenId>
{
	private readonly ModuleId module;

	private readonly uint token;

	public ModuleId Module => module;

	public uint Token => token;

	public ModuleTokenId(ModuleId module, MDToken mdToken)
		: this(module, mdToken.Raw)
	{
	}

	public ModuleTokenId(ModuleId module, uint token)
	{
		this.module = module;
		this.token = token;
	}

	public ModuleTokenId(ModuleId module, int token)
	{
		this.module = module;
		this.token = (uint)token;
	}

	public bool Equals(ModuleTokenId other)
	{
		return token == other.token && module.Equals(other.module);
	}

	public override bool Equals(object obj)
	{
		return obj is ModuleTokenId && Equals((ModuleTokenId)obj);
	}

	public override int GetHashCode()
	{
		return module.GetHashCode() ^ (int)token;
	}

	public override string ToString()
	{
		return token.ToString("X8") + " " + module;
	}
}
