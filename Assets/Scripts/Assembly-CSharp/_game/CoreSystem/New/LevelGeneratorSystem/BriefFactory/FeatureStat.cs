using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003AF")]
	public class FeatureStat
	{
		[Token(Token = "0x4000B52")]
		[FieldOffset(Offset = "0x10")]
		public int min;

		[Token(Token = "0x4000B53")]
		[FieldOffset(Offset = "0x14")]
		public int median;

		[Token(Token = "0x4000B54")]
		[FieldOffset(Offset = "0x18")]
		public int max;

		[Token(Token = "0x4000B55")]
		[FieldOffset(Offset = "0x1C")]
		public int p25;

		[Token(Token = "0x4000B56")]
		[FieldOffset(Offset = "0x20")]
		public int p75;

		[Token(Token = "0x4000B57")]
		[FieldOffset(Offset = "0x28")]
		public double presenceRate;

		[Token(Token = "0x6000F5A")]
		[Address(RVA = "0x3C9C6E0", Offset = "0x3C9C6E0", Length = "0x8")]
		public FeatureStat()
		{
		}
	}
}
