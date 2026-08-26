using System;

namespace DecompTools.Decompiler.TypeSystem;

[Flags]
public enum TypeSystemOptions
{
	None = 0,
	Dynamic = 1,
	Tuple = 2,
	ExtensionMethods = 4,
	OnlyPublicAPI = 8,
	Uncached = 0x10,
	DecimalConstants = 0x20,
	KeepModifiers = 0x40,
	ReadOnlyStructsAndParameters = 0x80,
	RefStructs = 0x100,
	UnmanagedConstraints = 0x200,
	NullabilityAnnotations = 0x400,
	Default = Dynamic | Tuple | ExtensionMethods | DecimalConstants | ReadOnlyStructsAndParameters | RefStructs | UnmanagedConstraints | NullabilityAnnotations
}
