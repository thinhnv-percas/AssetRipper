using System;

namespace Microsoft.DiaSymReader;

[Flags]
public enum SymUnmanagedWriterCreationOptions
{
	Default = 0,
	UseAlternativeLoadPath = 2,
	UseComRegistry = 4,
	Deterministic = 8
}
