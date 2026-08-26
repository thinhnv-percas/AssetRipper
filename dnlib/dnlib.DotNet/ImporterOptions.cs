using System;

namespace dnlib.DotNet;

[Flags]
public enum ImporterOptions
{
	TryToUseTypeDefs = 1,
	TryToUseMethodDefs = 2,
	TryToUseFieldDefs = 4,
	TryToUseDefs = TryToUseTypeDefs | TryToUseMethodDefs | TryToUseFieldDefs,
	FixSignature = int.MinValue
}
