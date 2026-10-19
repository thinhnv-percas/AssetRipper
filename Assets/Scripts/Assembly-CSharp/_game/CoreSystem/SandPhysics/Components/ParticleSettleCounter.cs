using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x200011B")]
	public struct ParticleSettleCounter : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003AE")]
		[FieldOffset(Offset = "0x0")]
		public int framesBelowThreshold;

		[Token(Token = "0x40003AF")]
		[FieldOffset(Offset = "0x4")]
		public float2 anchorPosition;

		[Token(Token = "0x40003B0")]
		[FieldOffset(Offset = "0xC")]
		public int isolatedFrames;

		[Token(Token = "0x40003B1")]
		[FieldOffset(Offset = "0x10")]
		public int wallPenetrationFrames;
	}
}
