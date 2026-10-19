using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004AB")]
	internal struct ArrivalRequest
	{
		[Token(Token = "0x4000FB0")]
		[FieldOffset(Offset = "0x0")]
		public Entity entity;

		[Token(Token = "0x4000FB1")]
		[FieldOffset(Offset = "0x8")]
		public int entityIndex;

		[Token(Token = "0x4000FB2")]
		[FieldOffset(Offset = "0xC")]
		public int entityGeneration;

		[Token(Token = "0x4000FB3")]
		[FieldOffset(Offset = "0x10")]
		public int gameColor;
	}
}
