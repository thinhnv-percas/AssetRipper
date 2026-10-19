using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x2000675")]
	public class LevelDatabaseSerializable
	{
		[Token(Token = "0x4001623")]
		[FieldOffset(Offset = "0x10")]
		public LevelSerializable[] levels;

		[Token(Token = "0x6001B5B")]
		[Address(RVA = "0x3D5DAF0", Offset = "0x3D5DAF0", Length = "0x8")]
		public LevelDatabaseSerializable()
		{
		}
	}
}
