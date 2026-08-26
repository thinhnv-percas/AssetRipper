using System;
using System.Collections.Generic;
using System.Linq;

namespace dnSpy.Contracts.Decompiler;

public abstract class DecompilerSettingsBase
{
	public abstract int Version { get; }

	public abstract IEnumerable<IDecompilerOption> Options { get; }

	public abstract event EventHandler VersionChanged;

	public abstract DecompilerSettingsBase Clone();

	public IDecompilerOption TryGetOption(Guid guid)
	{
		return Options.FirstOrDefault((IDecompilerOption a) => a.Guid == guid);
	}

	public IDecompilerOption TryGetOption(string name)
	{
		return Options.FirstOrDefault((IDecompilerOption a) => StringComparer.Ordinal.Equals(a.Name, name));
	}

	public bool GetBoolean(Guid guid)
	{
		return (TryGetOption(guid)?.Value as bool?) ?? false;
	}

	public bool GetBoolean(string name)
	{
		return (TryGetOption(name)?.Value as bool?) ?? false;
	}

	public abstract override bool Equals(object obj);

	public abstract override int GetHashCode();
}
