using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Config
{
	[Serializable]
	[Token(Token = "0x200062C")]
	public class BoosterRemoteConfigWrapper
	{
		[Token(Token = "0x400154E")]
		[FieldOffset(Offset = "0x10")]
		public BoosterRemoteConfigData[] Boosters;

		[Token(Token = "0x6001A74")]
		[Address(RVA = "0x3D5380C", Offset = "0x3D5380C", Length = "0x8")]
		public BoosterRemoteConfigWrapper()
		{
		}
	}
}
