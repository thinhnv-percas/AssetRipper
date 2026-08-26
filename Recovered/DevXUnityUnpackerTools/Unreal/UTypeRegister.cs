using System;

namespace Unreal
{
	public class UTypeRegister : Attribute
	{
		internal string _0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;

		internal EGame _0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A;

		public UTypeRegister()
		{
		}

		internal UTypeRegister(string name)
		{
			_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 = name;
		}

		internal UTypeRegister(string name, EGame game)
		{
			_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 = name;
			_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A = game;
		}
	}
}
