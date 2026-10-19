using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

namespace _game.CoreSystem.SandPhysics.Components
{
	[MaterialProperty("_BaseColor", -1)]
	[Token(Token = "0x2000120")]
	public struct SandParticleColor : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003B9")]
		[FieldOffset(Offset = "0x0")]
		public float4 value;
	}
}
