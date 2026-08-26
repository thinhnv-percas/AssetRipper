using System;

namespace Microsoft.DiaSymReader;

[Flags]
public enum SymUnmanagedReaderCreationOptions
{
	Default = 0,
	UseAlternativeLoadPath = 2,
	UseComRegistry = 4
}
