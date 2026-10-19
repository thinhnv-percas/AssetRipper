using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.MoldSystem
{
	[Serializable]
	[Token(Token = "0x200049F")]
	public struct AbsorptionProfile
	{
		[Token(Token = "0x4000F46")]
		[FieldOffset(Offset = "0x0")]
		public float attractSpeed;

		[Token(Token = "0x4000F47")]
		[FieldOffset(Offset = "0x4")]
		public float minSpeed;

		[Token(Token = "0x4000F48")]
		[FieldOffset(Offset = "0x8")]
		public float maxSpeed;

		[Token(Token = "0x4000F49")]
		[FieldOffset(Offset = "0xC")]
		public float zCurveHeight;

		[Token(Token = "0x4000F4A")]
		[FieldOffset(Offset = "0x10")]
		public float zCurveSkew;

		[Token(Token = "0x4000F4B")]
		[FieldOffset(Offset = "0x14")]
		public float yAnticipation;

		[Token(Token = "0x4000F4C")]
		[FieldOffset(Offset = "0x18")]
		public float targetScatter;
	}
}
