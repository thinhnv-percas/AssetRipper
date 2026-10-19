using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x200066D")]
	public class LevelOrderConfigSerializable
	{
		[Token(Token = "0x4001600")]
		[FieldOffset(Offset = "0x10")]
		public string[] m_levelEntries;

		[Token(Token = "0x4001601")]
		[FieldOffset(Offset = "0x18")]
		public string[] m_loopedLevelEntries;

		[Token(Token = "0x4001602")]
		[FieldOffset(Offset = "0x20")]
		public int m_algorithm;

		[Token(Token = "0x4001603")]
		[FieldOffset(Offset = "0x28")]
		public string m_migrationAnchorUniqueId;

		[Token(Token = "0x6001B37")]
		[Address(RVA = "0x3D5C04C", Offset = "0x3D5C04C", Length = "0x8")]
		public LevelOrderConfigSerializable()
		{
		}
	}
}
