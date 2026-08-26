using System;

namespace Microsoft.DiaSymReader.Tools;

[Flags]
public enum PdbToXmlOptions
{
	Default = 0,
	ThrowOnError = 2,
	ResolveTokens = 4,
	IncludeTokens = 8,
	IncludeMethodSpans = 0x10,
	ExcludeDocuments = 0x20,
	ExcludeMethods = 0x40,
	ExcludeSequencePoints = 0x80,
	ExcludeScopes = 0x100,
	ExcludeNamespaces = 0x200,
	ExcludeAsyncInfo = 0x400,
	ExcludeCustomDebugInformation = 0x800,
	IncludeSourceServerInformation = 0x1000,
	IncludeEmbeddedSources = 0x2000,
	UseNativeReader = 0x4000
}
