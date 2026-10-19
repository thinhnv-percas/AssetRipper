using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x2000503")]
	public struct PolygonWithHoles
	{
		[Token(Token = "0x40010C3")]
		[FieldOffset(Offset = "0x0")]
		public float2[] outer;

		[Token(Token = "0x40010C4")]
		[FieldOffset(Offset = "0x8")]
		public List<float2[]> holes;
	}
}
