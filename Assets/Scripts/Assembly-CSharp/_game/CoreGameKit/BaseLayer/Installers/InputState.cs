using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x200068A")]
	public struct InputState
	{
		[Token(Token = "0x4001664")]
		[FieldOffset(Offset = "0x0")]
		public bool IsDown;

		[Token(Token = "0x4001665")]
		[FieldOffset(Offset = "0x1")]
		public bool IsPressed;

		[Token(Token = "0x4001666")]
		[FieldOffset(Offset = "0x2")]
		public bool IsUp;
	}
}
