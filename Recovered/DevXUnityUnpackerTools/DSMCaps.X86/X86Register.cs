namespace DSMCaps.X86
{
	public sealed class X86Register : Register<X86RegisterId>
	{
		internal static X86Register _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, X86RegisterId _0020_000A)
		{
			X86Register result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new X86Register(_0020_000A, name);
			}
			return result;
		}

		internal X86Register(X86RegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
