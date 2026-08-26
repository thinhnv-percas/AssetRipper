#define DEBUG
using System;
using System.Diagnostics;
using System.IO;
using dnlib.DotNet;

namespace dnSpy.Contracts.Metadata;

public readonly struct ModuleId : IEquatable<ModuleId>
{
	[Flags]
	private enum Flags : byte
	{
		IsDynamic = 1,
		IsInMemory = 2,
		NameOnly = 4,
		CompareMask = IsDynamic | IsInMemory
	}

	private static readonly StringComparer AssemblyNameComparer = StringComparer.OrdinalIgnoreCase;

	private static readonly StringComparer ModuleNameComparer = StringComparer.OrdinalIgnoreCase;

	private readonly string asmFullName;

	private readonly string moduleName;

	private readonly Flags flags;

	public string AssemblyFullName => asmFullName ?? string.Empty;

	public string ModuleName => moduleName ?? string.Empty;

	public bool IsDynamic => (flags & Flags.IsDynamic) != 0;

	public bool IsInMemory => (flags & Flags.IsInMemory) != 0;

	public bool ModuleNameOnly => (flags & Flags.NameOnly) != 0;

	public static implicit operator ModuleId(string moduleFilename)
	{
		return Create(moduleFilename);
	}

	public ModuleId(string asmFullName, string moduleName, bool isDynamic, bool isInMemory, bool nameOnly)
	{
		Debug.Assert(asmFullName == null || !asmFullName.Contains("\\:"));
		this.asmFullName = asmFullName ?? string.Empty;
		this.moduleName = moduleName ?? string.Empty;
		flags = (Flags)0;
		if (isDynamic)
		{
			flags |= Flags.IsDynamic;
		}
		if (isInMemory)
		{
			flags |= Flags.IsInMemory;
		}
		if (nameOnly)
		{
			flags |= Flags.NameOnly;
		}
	}

	public static ModuleId Create(string moduleFilename)
	{
		return new ModuleId(string.Empty, GetFullName(moduleFilename), isDynamic: false, isInMemory: false, nameOnly: true);
	}

	private static string GetFullName(string filename)
	{
		try
		{
			if (!string.IsNullOrEmpty(filename))
			{
				return Path.GetFullPath(filename);
			}
		}
		catch
		{
		}
		return filename;
	}

	public static ModuleId CreateFromFile(ModuleDef module)
	{
		return new ModuleId(module.Assembly?.FullName ?? string.Empty, module.Location, isDynamic: false, isInMemory: false, nameOnly: false);
	}

	public static ModuleId CreateInMemory(ModuleDef module)
	{
		return new ModuleId(module.Assembly?.FullName ?? string.Empty, module.Name, isDynamic: false, isInMemory: true, nameOnly: false);
	}

	public static ModuleId Create(ModuleDef module, bool isDynamic, bool isInMemory)
	{
		return new ModuleId(module.Assembly?.FullName ?? string.Empty, (!isInMemory) ? module.Location : module.Name.String, isDynamic, isInMemory, nameOnly: false);
	}

	public static ModuleId Create(string asmFullName, string moduleName, bool isDynamic, bool isInMemory, bool moduleNameOnly)
	{
		return new ModuleId(asmFullName, moduleName, isDynamic, isInMemory, moduleNameOnly);
	}

	public static bool operator ==(ModuleId a, ModuleId b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(ModuleId a, ModuleId b)
	{
		return !a.Equals(b);
	}

	public bool Equals(ModuleId other)
	{
		return (ModuleNameOnly || other.ModuleNameOnly || AssemblyNameComparer.Equals(AssemblyFullName, other.AssemblyFullName)) && ModuleNameComparer.Equals(ModuleName, other.ModuleName) && (flags & Flags.CompareMask) == (other.flags & Flags.CompareMask);
	}

	public override bool Equals(object obj)
	{
		bool num = obj is ModuleId;
		ModuleId other = (num ? ((ModuleId)obj) : default(ModuleId));
		return num && Equals(other);
	}

	public override int GetHashCode()
	{
		return ModuleNameComparer.GetHashCode(ModuleName) ^ (int)((uint)(flags & Flags.CompareMask) << 16);
	}

	public override string ToString()
	{
		if (ModuleNameOnly)
		{
			return $"DYN={(IsDynamic ? 1 : 0)} MEM={(IsInMemory ? 1 : 0)} [{ModuleName}]";
		}
		return $"DYN={(IsDynamic ? 1 : 0)} MEM={(IsInMemory ? 1 : 0)} {AssemblyFullName} [{ModuleName}]";
	}
}
