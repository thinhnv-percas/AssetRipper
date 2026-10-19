using System;
using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreSystem.FrameSystem
{
	[Serializable]
	[Token(Token = "0x20004EE")]
	public struct WallSegment
	{
		[Token(Token = "0x4001087")]
		[FieldOffset(Offset = "0x0")]
		public float2 from;

		[Token(Token = "0x4001088")]
		[FieldOffset(Offset = "0x8")]
		public float2 to;

		[Token(Token = "0x60014B6")]
		[Address(RVA = "0x3CFDC54", Offset = "0x3CFDC54", Length = "0xC")]
		public WallSegment(float2 from, float2 to)
		{
			this.from = from;
			_ = from.y;
			this.to = to;
			_ = to.y;
		}
	}
}
