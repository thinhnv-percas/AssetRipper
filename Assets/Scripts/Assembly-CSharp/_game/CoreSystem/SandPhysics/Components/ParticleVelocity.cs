using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x200011E")]
	public struct ParticleVelocity : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003B8")]
		[FieldOffset(Offset = "0x0")]
		public float2 value;
	}
}
