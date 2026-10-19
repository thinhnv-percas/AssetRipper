using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x200011C")]
	public struct ParticleSpawnAge : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003B2")]
		[FieldOffset(Offset = "0x0")]
		public ushort value;
	}
}
