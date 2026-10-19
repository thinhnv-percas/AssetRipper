using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x200011A")]
	public struct ParticleRadius : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003AD")]
		[FieldOffset(Offset = "0x0")]
		public float value;
	}
}
