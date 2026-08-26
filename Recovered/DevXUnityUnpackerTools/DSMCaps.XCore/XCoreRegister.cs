namespace DSMCaps.XCore
{
	public sealed class XCoreRegister : Register<XCoreRegisterId>
	{
		internal static XCoreRegister _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(CapstoneDisassembler _0020, XCoreRegisterId _0020_000A)
		{
			XCoreRegister result = null;
			if (_0020_000A != 0)
			{
				string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_0020.Handle, (int)_0020_000A);
				result = new XCoreRegister(_0020_000A, name);
			}
			return result;
		}

		internal XCoreRegister(XCoreRegisterId id, string name)
			: base(id, name)
		{
		}
	}
}
