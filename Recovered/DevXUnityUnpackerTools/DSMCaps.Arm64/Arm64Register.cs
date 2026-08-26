namespace DSMCaps.Arm64
{
	public sealed class Arm64Register : Register<Arm64RegisterId>
	{
		internal static Arm64Register _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, Arm64RegisterId _0020_000A)
		{
			Arm64Register result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new Arm64Register(_0020_000A, name);
			}
			return result;
		}

		internal Arm64Register(Arm64RegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
