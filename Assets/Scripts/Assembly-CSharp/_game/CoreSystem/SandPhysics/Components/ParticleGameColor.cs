using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x2000118")]
	public struct ParticleGameColor : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003AB")]
		[FieldOffset(Offset = "0x0")]
		public int value;
	}
}
