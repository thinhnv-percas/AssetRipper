namespace DSMCaps.PowerPc
{
	public sealed class PowerPcRegister : Register<PowerPcRegisterId>
	{
		internal static PowerPcRegister _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, PowerPcRegisterId _0020_000A)
		{
			PowerPcRegister result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new PowerPcRegister(_0020_000A, name);
			}
			return result;
		}

		internal PowerPcRegister(PowerPcRegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
