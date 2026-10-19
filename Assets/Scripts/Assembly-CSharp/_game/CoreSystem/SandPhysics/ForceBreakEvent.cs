using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A0")]
	public struct ForceBreakEvent : IBufferElementData
	{
		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x0")]
		public float2 position;

		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x8")]
		public float size;

		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0xC")]
		public float rotation;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x10")]
		public GameColor gameColor;

		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x14")]
		public int cubeIndex;

		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x18")]
		public int totalClaimedCount;

		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x1C")]
		public int targetStartIndex;

		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x20")]
		public int targetCount;
	}
}
