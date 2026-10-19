using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x2000116")]
	public struct AbsorptionArcData : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x400039E")]
		[FieldOffset(Offset = "0x0")]
		public float2 startPos;

		[Token(Token = "0x400039F")]
		[FieldOffset(Offset = "0x8")]
		public float2 targetOffset;

		[Token(Token = "0x40003A0")]
		[FieldOffset(Offset = "0x10")]
		public float progress;

		[Token(Token = "0x40003A1")]
		[FieldOffset(Offset = "0x14")]
		public int targetEntityIndex;

		[Token(Token = "0x40003A2")]
		[FieldOffset(Offset = "0x18")]
		public int targetEntityGeneration;

		[Token(Token = "0x40003A3")]
		[FieldOffset(Offset = "0x1C")]
		public float startZ;

		[Token(Token = "0x40003A4")]
		[FieldOffset(Offset = "0x20")]
		public float attractSpeed;

		[Token(Token = "0x40003A5")]
		[FieldOffset(Offset = "0x24")]
		public float minSpeed;

		[Token(Token = "0x40003A6")]
		[FieldOffset(Offset = "0x28")]
		public float maxSpeed;

		[Token(Token = "0x40003A7")]
		[FieldOffset(Offset = "0x2C")]
		public float zCurveHeight;

		[Token(Token = "0x40003A8")]
		[FieldOffset(Offset = "0x30")]
		public float zCurveSkew;

		[Token(Token = "0x40003A9")]
		[FieldOffset(Offset = "0x34")]
		public float yAnticipation;

		[Token(Token = "0x40003AA")]
		[FieldOffset(Offset = "0x38")]
		public float dispatchStartScale;
	}
}
