using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x2000685")]
	public readonly struct ScreenPointInput
	{
		[Token(Token = "0x400165C")]
		[FieldOffset(Offset = "0x0")]
		public readonly float2 Position;

		[Token(Token = "0x6001BC0")]
		[Address(RVA = "0x3D64C3C", Offset = "0x3D64C3C", Length = "0x8")]
		public ScreenPointInput(float2 position)
		{
			Position = position;
			_ = position.y;
		}
	}
}
