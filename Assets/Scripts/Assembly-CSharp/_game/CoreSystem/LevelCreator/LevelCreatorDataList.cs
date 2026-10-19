using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.LevelCreator
{
	[Serializable]
	[Token(Token = "0x20004BA")]
	public class LevelCreatorDataList
	{
		[Token(Token = "0x4000FE3")]
		[FieldOffset(Offset = "0x10")]
		public LevelCreatorData[] levels;

		[Token(Token = "0x60013E7")]
		[Address(RVA = "0x3CEFEEC", Offset = "0x3CEFEEC", Length = "0x8")]
		public LevelCreatorDataList()
		{
		}
	}
}
