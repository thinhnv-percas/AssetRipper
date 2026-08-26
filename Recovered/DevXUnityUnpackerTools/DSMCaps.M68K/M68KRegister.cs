namespace DSMCaps.M68K
{
	public sealed class M68KRegister : Register<M68KRegisterId>
	{
		internal static M68KRegister _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, M68KRegisterId _0020_000A)
		{
			M68KRegister result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new M68KRegister(_0020_000A, name);
			}
			return result;
		}

		internal M68KRegister(M68KRegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
