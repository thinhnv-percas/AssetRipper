namespace Microsoft.DiaSymReader;

public enum SymUnmanagedSearchPolicy
{
	AllowRegistryAccess = 1,
	AllowSymbolServerAccess = 2,
	AllowOriginalPathAccess = 4,
	AllowReferencePathAccess = 8
}
