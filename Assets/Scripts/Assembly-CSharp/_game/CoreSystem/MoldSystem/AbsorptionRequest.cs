using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004AA")]
	internal struct AbsorptionRequest
	{
		[Token(Token = "0x4000FAD")]
		[FieldOffset(Offset = "0x0")]
		public Entity entity;

		[Token(Token = "0x4000FAE")]
		[FieldOffset(Offset = "0x8")]
		public int column;

		[Token(Token = "0x4000FAF")]
		[FieldOffset(Offset = "0xC")]
		public int gameColor;
	}
}
