namespace DSMCaps.Arm
{
	public sealed class ArmRegister : Register<ArmRegisterId>
	{
		internal static ArmRegister _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, ArmRegisterId _0020_000A)
		{
			ArmRegister result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new ArmRegister(_0020_000A, name);
			}
			return result;
		}

		internal ArmRegister(ArmRegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
