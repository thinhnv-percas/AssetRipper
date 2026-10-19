using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x200009F")]
	public struct CubeBreakEvent : IBufferElementData
	{
		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x0")]
		public float2 position;

		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x8")]
		public float size;

		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0xC")]
		public float rotation;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x10")]
		public GameColor gameColor;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x14")]
		public int cubeIndex;
	}
}
