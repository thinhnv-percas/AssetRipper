using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x2000119")]
	public struct ParticlePosition : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003AC")]
		[FieldOffset(Offset = "0x0")]
		public float2 value;
	}
}
