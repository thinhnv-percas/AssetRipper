using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[Serializable]
	[Token(Token = "0x2000627")]
	public class BoosterCountEntry
	{
		[Token(Token = "0x4001541")]
		[FieldOffset(Offset = "0x10")]
		public string BoosterId;

		[Token(Token = "0x4001542")]
		[FieldOffset(Offset = "0x18")]
		public int Count;

		[Token(Token = "0x6001A5B")]
		[Address(RVA = "0x3D52C50", Offset = "0x3D52C50", Length = "0x8")]
		public BoosterCountEntry()
		{
		}
	}
}
