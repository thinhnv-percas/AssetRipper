// The obfuscator puts the compiler-generated types <Module> and
// <PrivateImplementationDetails> in method signatures, which is legal IL but has
// no C# spelling. ILSpy escapes the names to _003CModule_003E /
// _003CPrivateImplementationDetails_003E but does not emit the declarations
// (they are hidden types). Every call site passes null, so empty stubs are
// enough to make the decompiled source compile.
internal class _003CModule_003E
{
}

internal class _003CPrivateImplementationDetails_003E
{
}

// The obfuscated type below declares an extension method, but its own name is
// also used as a parameter type in 48 signatures -- so in C# it can be neither
// `static class` (needed for the extension method) nor non-static (needed for
// the parameter usage). Keeping the class non-static and re-exposing the method
// from this host satisfies both call styles.
internal static class _ExtensionHost
{
	internal static System.Collections.Generic.IEnumerable<System.Type> _0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020(this System.Reflection.Assembly _0020)
	{
		return _0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020(_0020);
	}
}

// The real entry point is [STAThread] _0020_000A_..._000A() on the obfuscated
// class below (-.cs:931). C# requires the entry point to be literally named
// `Main`, so this forwards to it. Referenced by <StartupObject> in the csproj.
internal static class Program
{
	[System.STAThread]
	internal static void Main()
	{
		_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A();
	}
}
