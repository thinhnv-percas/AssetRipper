namespace DSMCaps.Mips
{
	public sealed class MipsRegister : Register<MipsRegisterId>
	{
		internal static MipsRegister _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, MipsRegisterId _0020_000A)
		{
			MipsRegister result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new MipsRegister(_0020_000A, name);
			}
			return result;
		}

		internal MipsRegister(MipsRegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
