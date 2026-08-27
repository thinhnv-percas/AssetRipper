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

// The real entry point used to be [STAThread] _0020_000A_..._000A() on the
// obfuscated class below (-.cs:931), which -- after skipping decoy/debug-log
// branches never taken outside a debugger -- resolves and invokes
// DevXUnityUnpackerTools through three more CJK-permutation dispatcher hops
// (空記草 -> 記草空 -> 草記空, see FINDINGS.md §5) ending in a CSharpCodeProvider
// runtime-compiled loader shim that hash-resolves and decrypts the
// DevXUnityUnpackerTools sidecar file. ROADMAP.md P7b replaces all of that
// with a direct call into the now-decompiled Tools entry point; the original
// chain is left in place, unused, as the only buildable record of that
// obfuscation layer (same treatment as Memrestore/DeCompess in
// DevXUnityUnpackerRun/Program.cs for P7a).
internal static class Program
{
	[System.STAThread]
	internal static void Main()
	{
		// The bypassed chain called these two before ever reaching Tools.
		System.Windows.Forms.Application.EnableVisualStyles();
		System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
		new 例子子().子子例();
	}
}
